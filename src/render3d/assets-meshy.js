import { REAL } from './assets-real.js';

export const MESHY_MODELS={},MESHY_LOADING={};

export function validatedRigBoneInverses(data,bones,provided){
  const inverses=provided||data.boneInverses.map(a=>new THREE.Matrix4().set(
    a[0],a[1],a[2],a[3],a[4],a[5],a[6],a[7],
    a[8],a[9],a[10],a[11],a[12],a[13],a[14],a[15]
  ));
  if(inverses.length!==data.skinBones.length)
    throw new Error('El rig no tiene una matriz bind por cada hueso de piel.');
  data.bones.forEach((bone,i)=>{if(bone.parent<0)bones[i].updateMatrixWorld(true);});
  const identity=new THREE.Matrix4();
  let maxError=0;
  data.skinBones.forEach((boneIndex,i)=>{
    const bind=bones[boneIndex].matrixWorld.clone().multiply(inverses[i]);
    bind.elements.forEach((value,j)=>{maxError=Math.max(maxError,Math.abs(value-identity.elements[j]));});
  });
  if(maxError<=0.001)return inverses;
  return data.skinBones.map(boneIndex=>{
    const bind=bones[boneIndex].matrixWorld;
    const determinant=bind.determinant();
    if(!Number.isFinite(determinant)||Math.abs(determinant)<1e-12)
      throw new Error('El rig contiene una bind pose singular.');
    return bind.clone().invert();
  });
}

export function sameRigBoneOrder(source,target){
  return !!source&&!!target&&source.length===target.length&&source.every((bone,i)=>bone.name===target[i].name);
}

export function normalizeMeshyRig(rig){
  if(Array.isArray(rig.skinIndex[0]))return rig;
  const skinIndex=[],skinWeight=[];
  for(let i=0;i<rig.skinIndex.length;i+=4){
    skinIndex.push(rig.skinIndex.slice(i,i+4));
    skinWeight.push(rig.skinWeight.slice(i,i+4));
  }
  return Object.assign({},rig,{skinIndex,skinWeight});
}

export const normalizeMeshyRigGlobal=normalizeMeshyRig;

export function parseMeshyOBJ(text,rig){
  const vertices=[],uvs=[],normals=[],positions=[],outUvs=[],outNormals=[],skinIndices=[],skinWeights=[];
  const resolveIndex=(index,length)=>index<0?length+index:index-1;
  for(const line of text.split(/\r?\n/)){
    const parts=line.trim().split(/\s+/);
    if(parts[0]==='v')vertices.push([+parts[1],+parts[2],+parts[3]]);
    else if(parts[0]==='vt')uvs.push([+parts[1],+parts[2]]);
    else if(parts[0]==='vn')normals.push([+parts[1],+parts[2],+parts[3]]);
    else if(parts[0]==='f'){
      const face=parts.slice(1).map(token=>{
        const indices=token.split('/');
        return {v:resolveIndex(+indices[0],vertices.length),uv:indices[1]?resolveIndex(+indices[1],uvs.length):-1,n:indices[2]?resolveIndex(+indices[2],normals.length):-1};
      });
      for(let i=1;i<face.length-1;i++){
        for(const corner of [face[0],face[i],face[i+1]]){
          const vertex=vertices[corner.v],uv=uvs[corner.uv],normal=normals[corner.n];
          if(!vertex)throw new Error('El OBJ Meshy contiene una cara inválida.');
          const boneIndices=rig.skinIndex[corner.v],boneWeights=rig.skinWeight[corner.v];
          if(!boneIndices||!boneWeights||boneIndices.length!==4||boneWeights.length!==4)throw new Error('El rig Meshy no contiene pesos para todos los vértices.');
          positions.push(vertex[0],vertex[1],vertex[2]);
          outUvs.push(uv?uv[0]:0,uv?uv[1]:0);
          if(normal)outNormals.push(normal[0],normal[1],normal[2]);
          skinIndices.push(...boneIndices);
          skinWeights.push(...boneWeights);
        }
      }
    }
  }
  if(!positions.length)throw new Error('El OBJ Meshy no contiene caras.');
  const geometry=new THREE.BufferGeometry();
  geometry.setAttribute('position',new THREE.Float32BufferAttribute(positions,3));
  geometry.setAttribute('uv',new THREE.Float32BufferAttribute(outUvs,2));
  if(outNormals.length===positions.length)geometry.setAttribute('normal',new THREE.Float32BufferAttribute(outNormals,3));
  else geometry.computeVertexNormals();
  geometry.setAttribute('skinIndex',new THREE.Float32BufferAttribute(skinIndices,4));
  geometry.setAttribute('skinWeight',new THREE.Float32BufferAttribute(skinWeights,4));
  geometry.computeBoundingBox();
  return geometry;
}

export function loadMeshyModel(mesh){
  if(MESHY_MODELS[mesh])return Promise.resolve(MESHY_MODELS[mesh]);
  if(MESHY_LOADING[mesh])return MESHY_LOADING[mesh];
  if(typeof THREE==='undefined')return Promise.resolve(null);
  MESHY_LOADING[mesh]=Promise.all([
    fetch('assets/personajes_propios/'+mesh+'.obj'),
    fetch('assets/personajes_propios/'+mesh+'_rig.json'),
    new Promise(res=>{new THREE.TextureLoader().load('assets/personajes_propios/'+mesh+'_tex.png',t=>{t.colorSpace=THREE.SRGBColorSpace;res(t);},undefined,()=>res(null));})
  ]).then(async ([objRes,rigRes,tex])=>{
    if(!objRes.ok||!rigRes.ok)return null;
    const [objText,rawRig]=await Promise.all([objRes.text(),rigRes.json()]);
    const data=normalizeMeshyRig(rawRig);
    const geo=parseMeshyOBJ(objText,data);
    const size=new THREE.Vector3();geo.boundingBox.getSize(size);
    const maxDim=Math.max(size.x,size.y,size.z)||1;
    const started=Date.now();
    while(!(REAL.ready&&REAL.data&&REAL.data.bones)&&Date.now()-started<5000)await wait(50);
    const baseData=sameRigBoneOrder(REAL.data&&REAL.data.bones,data.bones)?REAL.data:null;
    return {geo:geo,data:data,tex:tex,scale:0.95*1.14/maxDim,zUp:!!(data.bones[1]&&data.bones[1].pos[2]>data.bones[1].pos[1]+0.1),baseRestQ:baseData?baseData.bones.map(b=>new THREE.Quaternion(b.quat[0],b.quat[1],b.quat[2],b.quat[3])):null,baseRestParents:baseData?baseData.bones.map(b=>b.parent):null};
  }).then(model=>{if(model)MESHY_MODELS[mesh]=model;return model;}).catch(()=>null).finally(()=>{delete MESHY_LOADING[mesh];});
  return MESHY_LOADING[mesh];
}

export function makeSkinnedModel(geometry,data,texture,options={}){
  const model=new THREE.Group();
  const bones=data.bones.map(b=>{
    const bone=new THREE.Bone();
    bone.name=b.name;
    bone.position.fromArray(b.pos);
    bone.quaternion.fromArray(b.quat);
    if(b.scale)bone.scale.fromArray(b.scale);
    return bone;
  });
  data.bones.forEach((b,i)=>{if(b.parent>=0)bones[b.parent].add(bones[i]);});
  const inverses=validatedRigBoneInverses(data,bones);
  const skeleton=new THREE.Skeleton(data.skinBones.map(i=>bones[i]),inverses);
  if(texture)texture.colorSpace=THREE.SRGBColorSpace;
  const mesh=new THREE.SkinnedMesh(geometry,new THREE.MeshStandardMaterial({
    map:texture,roughness:0.85,metalness:0.02,transparent:false,opacity:1,depthWrite:true,alphaTest:0,
    side:THREE.FrontSide
  }));
  mesh.add(bones[0]);
  mesh.bind(skeleton,new THREE.Matrix4());
  mesh.frustumCulled=false;
  mesh.castShadow=true;
  model.add(mesh);
  const parents=data.bones.map(b=>b.parent);
  const bindLocal=data.bones.map(b=>new THREE.Quaternion(b.quat[0],b.quat[1],b.quat[2],b.quat[3]));
  const bindWorldQ=worldRotationsFromLocal(bindLocal,parents);
  const baseRestQ=options.baseRestQ||null;
  const sourceParents=baseRestQ?(options.baseParents||parents):parents;
  model.userData={
    bones,bindLocal,
    curQ:data.bones.map(b=>new THREE.Quaternion(b.quat[0],b.quat[1],b.quat[2],b.quat[3])),
    bindPos:data.bones.map(b=>new THREE.Vector3(b.pos[0],b.pos[1],b.pos[2])),
    curDelta:new THREE.Vector3(),mesh3:mesh,meshy:!!options.meshy,
    animatable:!!options.animatable,idleClipKey:options.idleClipKey||'idle2h',idleRole:options.idleRole,
    baseRestQ,baseRestWorldQ:baseRestQ?worldRotationsFromLocal(baseRestQ,sourceParents):null,
    bindWorldQ,parents,sourceParents,
    sourcePoseQ:data.bones.map(()=>new THREE.Quaternion()),
    sourceWorldQ:data.bones.map(()=>new THREE.Quaternion()),
    targetWorldQ:data.bones.map(()=>new THREE.Quaternion()),
    targetLocalQ:data.bones.map(()=>new THREE.Quaternion()),
    isClassRig:!!baseRestQ,grip:!!options.grip,role:options.role||'',gun:null,
    byName:Object.fromEntries(bones.map((bone,index)=>[bone.name,index]))
  };
  return model;
}
