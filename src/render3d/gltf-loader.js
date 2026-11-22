const GLB_MAGIC=0x46546c67;
const CHUNK_JSON=0x4e4f534a;
const CHUNK_BIN=0x004e4942;
const COMPONENTS={5120:Int8Array,5121:Uint8Array,5122:Int16Array,5123:Uint16Array,5125:Uint32Array,5126:Float32Array};
const TYPE_ITEMS={SCALAR:1,VEC2:2,VEC3:3,VEC4:4,MAT2:4,MAT3:9,MAT4:16};

function textDecoder(){
  if(typeof TextDecoder==='function')return new TextDecoder('utf-8');
  return {decode(bytes){let out='';for(let i=0;i<bytes.length;i++)out+=String.fromCharCode(bytes[i]);try{return decodeURIComponent(escape(out));}catch(error){return out;}}};
}

function readAccessor(json,binary,index){
  if(!Number.isInteger(index)||!json.accessors||!json.accessors[index])return null;
  const accessor=json.accessors[index];
  const View=COMPONENTS[accessor.componentType];
  const itemSize=TYPE_ITEMS[accessor.type];
  if(!View||!itemSize)return null;
  const count=accessor.count||0;
  const bufferView=Number.isInteger(accessor.bufferView)?json.bufferViews&&json.bufferViews[accessor.bufferView]:null;
  const componentBytes=View.BYTES_PER_ELEMENT;
  const natural=itemSize*componentBytes;
  const stride=(bufferView&&bufferView.byteStride)||natural;
  const offset=(bufferView?bufferView.byteOffset||0:0)+(accessor.byteOffset||0);
  let array;
  if(!bufferView){
    array=new View(count*itemSize);
  }else if(stride===natural){
    array=new View(binary.buffer,binary.byteOffset+offset,count*itemSize);
  }else{
    array=new View(count*itemSize);
    const data=new DataView(binary.buffer,binary.byteOffset+offset,count*stride);
    const get=data[['Int8','Uint8','Int16','Uint16','Uint32','Float32'][Object.keys(COMPONENTS).indexOf(String(accessor.componentType))]+''];
    for(let i=0;i<count;i++)for(let c=0;c<itemSize;c++)array[i*itemSize+c]=get.call(data,i*stride+c*componentBytes,true);
  }
  return {array,itemSize,count,normalized:!!accessor.normalized,componentType:accessor.componentType};
}

function textureUrl(json,binary,index,options){
  const imageIndex=json.textures&&json.textures[index]&&json.textures[index].source;
  const image=json.images&&imageIndex!=null?json.images[imageIndex]:null;
  if(!image)return null;
  if(image.bufferView!=null&&typeof Blob==='function'&&typeof URL!=='undefined'&&typeof URL.createObjectURL==='function'){
    const view=json.bufferViews[image.bufferView];
    if(!view)return null;
    const bytes=binary.slice(view.byteOffset||0,(view.byteOffset||0)+view.byteLength);
    return URL.createObjectURL(new Blob([bytes],{type:image.mimeType||'application/octet-stream'}));
  }
  if(!image.uri)return null;
  if(/^[a-z]+:/i.test(image.uri)||image.uri.indexOf('data:')===0)return image.uri;
  return (options.baseUrl||'')+image.uri;
}

function buildTexture(json,binary,index,options){
  if(options.skipTextures||!THREE.TextureLoader)return null;
  const url=textureUrl(json,binary,index,options);
  if(!url)return null;
  const texture=new THREE.TextureLoader().load(url);
  const sampler=json.textures&&json.textures[index]&&Number.isInteger(json.textures[index].sampler)?json.samplers&&json.samplers[json.textures[index].sampler]:null;
  if(sampler){
    const wrap={33071:THREE.ClampToEdgeWrapping,33648:THREE.MirroredRepeatWrapping,10497:THREE.RepeatWrapping};
    texture.wrapS=wrap[sampler.wrapS]||THREE.ClampToEdgeWrapping;
    texture.wrapT=wrap[sampler.wrapT]||THREE.ClampToEdgeWrapping;
    texture.magFilter=sampler.magFilter===9728?THREE.NearestFilter:THREE.LinearFilter;
    texture.minFilter=({9728:THREE.NearestFilter,9729:THREE.LinearFilter,9984:THREE.NearestMipmapNearestFilter,9985:THREE.LinearMipmapNearestFilter,9986:THREE.NearestMipmapLinearFilter,9987:THREE.LinearMipmapLinearFilter})[sampler.minFilter]||THREE.LinearMipmapLinearFilter;
  }
  texture.userData={glbUrl:url,glbOwned:true};
  return texture;
}

function buildMaterial(json,binary,index,options){
  const def=json.materials&&json.materials[index]||{};
  const pbr=def.pbrMetallicRoughness||{};
  const color=pbr.baseColorFactor&&pbr.baseColorFactor.length>=3?new THREE.Color(pbr.baseColorFactor[0],pbr.baseColorFactor[1],pbr.baseColorFactor[2]):new THREE.Color(1,1,1);
  const material=new THREE.MeshStandardMaterial({
    color,
    metalness:pbr.metallicFactor==null?1:pbr.metallicFactor,
    roughness:pbr.roughnessFactor==null?1:pbr.roughnessFactor,
    transparent:def.alphaMode==='BLEND',
    alphaTest:def.alphaMode==='MASK'?(def.alphaCutoff==null?0.5:def.alphaCutoff):0,
    side:def.doubleSided?THREE.DoubleSide:THREE.FrontSide,
    emissive:def.emissiveFactor&&def.emissiveFactor.length>=3?new THREE.Color(def.emissiveFactor[0],def.emissiveFactor[1],def.emissiveFactor[2]):new THREE.Color(0,0,0),
  });
  if(Number.isInteger(pbr.baseColorTexture&&pbr.baseColorTexture.index))material.map=buildTexture(json,binary,pbr.baseColorTexture.index,options);
  if(Number.isInteger(pbr.metallicRoughnessTexture&&pbr.metallicRoughnessTexture.index))material.metalnessMap=buildTexture(json,binary,pbr.metallicRoughnessTexture.index,options);
  if(Number.isInteger(def.normalTexture&&def.normalTexture.index))material.normalMap=buildTexture(json,binary,def.normalTexture.index,options);
  if(Number.isInteger(def.emissiveTexture&&def.emissiveTexture.index))material.emissiveMap=buildTexture(json,binary,def.emissiveTexture.index,options);
  material.name=def.name||('material_'+index);
  material.userData.glbOwned=true;
  return material;
}

function buildPrimitive(json,binary,primitive,material,skeleton,stats,options){
  const geometry=new THREE.BufferGeometry();
  const map={POSITION:'position',NORMAL:'normal',TEXCOORD_0:'uv',TEXCOORD_1:'uv2',COLOR_0:'color',JOINTS_0:'skinIndex',WEIGHTS_0:'skinWeight'};
  for(const semantic in map){
    const accessor=readAccessor(json,binary,primitive.attributes&&primitive.attributes[semantic]);
    if(accessor)geometry.setAttribute(map[semantic],new THREE.BufferAttribute(accessor.array,accessor.itemSize,accessor.normalized));
  }
  if(primitive.indices!=null){
    const indices=readAccessor(json,binary,primitive.indices);
    if(indices)geometry.setIndex(new THREE.BufferAttribute(indices.array,1));
  }
  if(!geometry.attributes.normal)geometry.computeVertexNormals();
  geometry.computeBoundingBox();
  geometry.computeBoundingSphere();
  geometry.userData.glbOwned=true;
  stats.primitives++;
  stats.vertices+=geometry.attributes.position?geometry.attributes.position.count:0;
  stats.triangles+=geometry.index?geometry.index.count/3:(geometry.attributes.position?geometry.attributes.position.count/3:0);
  const mesh=skeleton?new THREE.SkinnedMesh(geometry,material):new THREE.Mesh(geometry,material);
  if(skeleton){mesh.bind(skeleton);stats.skinnedMeshes++;}
  mesh.userData.glbOwned=true;
  return mesh;
}

function bindingName(node){
  if(!node.name)node.name='node';
  return THREE.PropertyBinding&&THREE.PropertyBinding.sanitizeNodeName?THREE.PropertyBinding.sanitizeNodeName(node.name):node.name;
}

function buildAnimations(json,binary,nodes,options){
  return (json.animations||[]).map((animation,animationIndex)=>{
    const tracks=[];
    for(const channel of animation.channels||[]){
      const sampler=animation.samplers&&animation.samplers[channel.sampler];
      const node=nodes[channel.target&&channel.target.node];
      if(!sampler||!node)continue;
      const times=readAccessor(json,binary,sampler.input);
      const values=readAccessor(json,binary,sampler.output);
      if(!times||!values)continue;
      const path=channel.target.path;
      const trackPath=path==='rotation'?'quaternion':path;
      if(!['translation','rotation','scale'].includes(path))continue;
      const Track=path==='rotation'?THREE.QuaternionKeyframeTrack:THREE.VectorKeyframeTrack;
      if(!Track)continue;
      tracks.push(new Track(bindingName(node)+'.'+trackPath,Array.from(times.array),Array.from(values.array)));
    }
    return new THREE.AnimationClip(animation.name||('clip_'+animationIndex),-1,tracks);
  });
}

export function parseGLB(input,options={}){
  const isArrayBuffer=value=>Object.prototype.toString.call(value)==='[object ArrayBuffer]';
  let buffer=null;
  if(isArrayBuffer(input))buffer=input;
  else if(input&&isArrayBuffer(input.buffer))buffer=input.byteOffset===0&&input.byteLength===input.buffer.byteLength?input.buffer:input.buffer.slice(input.byteOffset,input.byteOffset+input.byteLength);
  if(!buffer||buffer.byteLength<20)throw new Error('GLB inválido: cabecera truncada.');
  const head=new DataView(buffer);
  if(head.getUint32(0,true)!==GLB_MAGIC)throw new Error('GLB inválido: magic incorrecto.');
  if(head.getUint32(4,true)!==2)throw new Error('GLB inválido: solo se admite versión 2.');
  if(head.getUint32(8,true)>buffer.byteLength)throw new Error('GLB inválido: longitud declarada mayor que el buffer.');
  let json=null,binary=new Uint8Array(0);
  for(let offset=12;offset+8<=buffer.byteLength;){
    const length=head.getUint32(offset,true),type=head.getUint32(offset+4,true);
    if(offset+8+length>buffer.byteLength)throw new Error('GLB inválido: chunk truncado.');
    if(type===CHUNK_JSON)json=JSON.parse(textDecoder().decode(new Uint8Array(buffer,offset+8,length)));
    if(type===CHUNK_BIN)binary=new Uint8Array(buffer,offset+8,length);
    offset+=8+length+((4-length%4)%4);
  }
  if(!json||!Array.isArray(json.nodes))throw new Error('GLB inválido: falta el JSON de la escena.');
  const stats={nodes:json.nodes.length,meshes:(json.meshes||[]).length,primitives:0,vertices:0,triangles:0,skins:(json.skins||[]).length,skinnedMeshes:0,animations:(json.animations||[]).length,textures:(json.textures||[]).length,materials:(json.materials||[]).length};
  const jointSet=new Set();
  (json.skins||[]).forEach(skin=>(skin.joints||[]).forEach(index=>jointSet.add(index)));
  const nodes=json.nodes.map((node,index)=>{
    const object=jointSet.has(index)&&THREE.Bone?new THREE.Bone():new THREE.Object3D();
    object.name=node.name||('node_'+index);
    if(node.translation)object.position.fromArray(node.translation);
    if(node.rotation)object.quaternion.fromArray(node.rotation);
    if(node.scale)object.scale.fromArray(node.scale);
    object.userData.glbOwned=true;
    return object;
  });
  const parents=new Set();
  nodes.forEach((object,index)=>{
    for(const child of json.nodes[index].children||[]){
      if(nodes[child]){object.add(nodes[child]);parents.add(child);}
    }
  });
  const skeletons=(json.skins||[]).map(skin=>{
    const bones=(skin.joints||[]).map(index=>nodes[index]).filter(Boolean);
    const inverses=[];
    const accessor=readAccessor(json,binary,skin.inverseBindMatrices);
    if(accessor)for(let i=0;i<bones.length;i++){
      const matrix=new THREE.Matrix4();
      if(accessor.array.length>=(i+1)*16)matrix.fromArray(accessor.array,i*16);
      inverses.push(matrix);
    }
    return new THREE.Skeleton(bones,inverses);
  });
  json.nodes.forEach((node,index)=>{
    if(node.mesh==null||!json.meshes||!json.meshes[node.mesh])return;
    const material=Number.isInteger(node.mesh)&&json.meshes[node.mesh].primitives&&json.meshes[node.mesh].primitives[0]&&Number.isInteger(json.meshes[node.mesh].primitives[0].material)?buildMaterial(json,binary,json.meshes[node.mesh].primitives[0].material,options):null;
    const skeleton=Number.isInteger(node.skin)?skeletons[node.skin]:null;
    const meshDef=json.meshes[node.mesh];
    const parts=(meshDef.primitives||[]).map(primitive=>buildPrimitive(json,binary,primitive,material,skeleton,stats,options));
    const holder=parts.length===1?parts[0]:new THREE.Group();
    if(parts.length>1)parts.forEach(part=>holder.add(part));
    holder.name=meshDef.name||nodes[index].name;
    nodes[index].add(holder);
  });
  const scene=new THREE.Group();
  scene.name='GLBScene';
  nodes.forEach((node,index)=>{if(!parents.has(index))scene.add(node);});
  const animations=buildAnimations(json,binary,nodes,options);
  return {scene,animations,stats,json};
}

export async function loadGLB(url,options={}){
  if(typeof fetch!=='function')throw new Error('loadGLB requiere fetch.');
  const response=await fetch(url);
  if(!response||response.ok===false)throw new Error('No se pudo cargar GLB: '+url);
  const buffer=await response.arrayBuffer();
  return parseGLB(buffer,{...options,baseUrl:options.baseUrl||url.slice(0,url.lastIndexOf('/')+1)});
}
