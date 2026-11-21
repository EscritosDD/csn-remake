export const REAL={ready:false,data:null,geo:null,tex:null,castTex:{}};

export function parseOBJ3(txt,skin){
  const P=[],UV=[],idxMap={};
  const pos=[],uv=[],si=[],sw=[],outIdx=[];
  txt.split('\n').forEach(line=>{
    const p=line.trim().split(/\s+/);
    if(p[0]==='v')P.push([-(+p[1]),+p[2],+p[3]]);
    else if(p[0]==='vt')UV.push([+p[1],+p[2]]);
    else if(p[0]==='f'){
      for(let i=1;i<=3;i++){
        const t=p[i].split('/');const vi=+t[0]-1,ti=+t[1]-1,ni=+t[2]-1;
        const key=vi+'/'+ti+'/'+ni;
        if(idxMap[key]==null){
          idxMap[key]=pos.length/3;
          pos.push(P[vi][0],P[vi][1],P[vi][2]);
          if(UV[ti])uv.push(Math.min(0.998,Math.max(0.002,UV[ti][0])),Math.min(0.998,Math.max(0.002,UV[ti][1])));else uv.push(0.5,0.5);
          for(let k=0;k<4;k++){si.push(skin.skinIndex[vi*4+k]);sw.push(skin.skinWeight[vi*4+k]);}
        }
        outIdx.push(idxMap[key]);
      }
    }
  });
  let vol=0;
  for(let i=0;i<outIdx.length;i+=3){
    const a=outIdx[i]*3,b=outIdx[i+1]*3,c=outIdx[i+2]*3;
    vol+=(pos[a]*(pos[b+1]*pos[c+2]-pos[b+2]*pos[c+1])-pos[a+1]*(pos[b]*pos[c+2]-pos[b+2]*pos[c])+pos[a+2]*(pos[b]*pos[c+1]-pos[b+1]*pos[c]))/6;
  }
  if(vol<0)for(let i=0;i<outIdx.length;i+=3){const t=outIdx[i+1];outIdx[i+1]=outIdx[i+2];outIdx[i+2]=t;}
  const g=new THREE.BufferGeometry();
  g.setAttribute('position',new THREE.Float32BufferAttribute(pos,3));
  g.setAttribute('uv',new THREE.Float32BufferAttribute(uv,2));
  g.setAttribute('skinIndex',new THREE.Float32BufferAttribute(si,4));
  g.setAttribute('skinWeight',new THREE.Float32BufferAttribute(sw,4));
  g.setIndex(outIdx);
  g.computeVertexNormals();
  return g;
}

export let ROLE_SCALES={};
export function setROLE_SCALES(v){ROLE_SCALES=v;}

export const ROLE_MODEL_FILES={'Francotirador':'Francotirador','Artillero':'Artillero','Espía':'Espia','Médico':'Medico','Ingeniero':'Ingeniero','Comando':'Comando','Capitán':'Capitan'};

export const ROLE_OUTFIT_FILES={'Francotirador':'veteran','Artillero':'deerhunter','Espía':'spetsnaz','Médico':'decon','Ingeniero':'rambo','Comando':'deltaforce','Capitán':'base'};

export function loadRealSoldier(){
  if(typeof THREE==='undefined')return;
  REAL.texByRole={};REAL.byRole={};REAL.castTex={};
  fetch('assets/soldier_scales.json').then(r=>r.json()).then(sc=>{ROLE_SCALES=sc||{};}).catch(()=>{});
  fetch('assets/soldier_clips.json').then(r=>{if(!r.ok)throw new Error('clips');return r.json();}).then(pack=>{CLIPLIB.pack=pack;CLIPLIB.ready=true;}).catch(()=>{});
  const texLoad=(path)=>new Promise(res=>{new THREE.TextureLoader().load(path,t=>{
    t.colorSpace=THREE.SRGBColorSpace;t.generateMipmaps=false;
    t.minFilter=THREE.LinearFilter;t.magFilter=THREE.LinearFilter;
    t.wrapS=THREE.ClampToEdgeWrapping;t.wrapT=THREE.ClampToEdgeWrapping;
    res(t);
  },undefined,()=>res(null));});
  const loadRole=(role,file)=>Promise.all([
    fetch('assets/soldier/'+file+'.obj').then(r=>{if(!r.ok)throw new Error('obj');return r.text();}),
    fetch('assets/soldier/'+file+'_rig.json').then(r=>{if(!r.ok)throw new Error('rig');return r.json();}),
    texLoad('assets/soldier/'+file+'_tex.png')
  ]).then(([objTxt,data,tex])=>{
    const geo=parseOBJ3(objTxt,data);
    REAL.byRole[role]={data:data,geo:geo,tex:tex};
    return role;
  }).catch(()=>null);
  Promise.all([
    fetch('assets/soldier.obj').then(r=>{if(!r.ok)throw new Error('obj');return r.text();}),
    fetch('assets/soldier_rig.json').then(r=>{if(!r.ok)throw new Error('rig');return r.json();}),
    texLoad('assets/soldier/outfits/base.png')
  ]).then(([objTxt,data,baseTex])=>{
    REAL.data=data;REAL.geo=parseOBJ3(objTxt,data);REAL.tex=baseTex||null;REAL.ready=true;
    return Promise.all(Object.entries(ROLE_MODEL_FILES).map(([role,file])=>loadRole(role,file)));
  }).then(list=>{
    /* Uniformes por clase como respaldo si faltara su textura. */
    return Promise.all(Object.entries(ROLE_OUTFIT_FILES).map(([role,file])=>
      file==='base'?Promise.resolve([role,null]):texLoad('assets/soldier/outfits/'+file+'.png').then(t=>[role,t])
    ));
  }).then(pairs=>{
    (pairs||[]).forEach(([role,t])=>{if(t)REAL.texByRole[role]=t;});
    return Promise.all([
      Promise.all(Object.values(CAST_TEXTURE_FILE).map(file=>texLoad('assets/soldier/cast/'+file).then(t=>[file,t]))),
      Promise.all(MESHY_CAST.map(c=>loadMeshyModel(c.mesh)))
    ]).then(([casts])=>{
      (casts||[]).forEach(([file,t])=>{if(t)REAL.castTex[file]=t;});
    });
  }).then(()=>{
    Object.keys(PORTRAIT_CACHE).forEach(k=>delete PORTRAIT_CACHE[k]);
    REAL_SPRITES.cache={};REAL_SPRITES.failed=false;
    if(typeof buildSpriteStrip==='function')buildSpriteStrip();
    if(typeof rebuildDemo==='function')rebuildDemo();
    if(G&&T3&&VIEW_MODE==='3d')build3DWorld();
    if(G){updateUI();draw();}
  }).catch(()=>{});
}
