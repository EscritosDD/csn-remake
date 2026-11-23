import { CLIPLIB } from './clips.js';
import { CAST_TEXTURE_FILE, MESHY_CAST, ORIG_CAST } from '../data/cast.js';
import { buildSpriteStrip } from '../render2d/sprites.js';
import { loadMeshyModel } from './assets-meshy.js';
import { VIEWER_BODY_FILE, VIEWER_BODY_OVERRIDE, VIEWER_BODY_ROLE, scaleRigForGeometry } from '../viewer/body-loader.js';

export const REAL={ready:false,data:null,geo:null,tex:null,castTex:{},byBody:{},bodyLoading:{}};

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

export function bodySpecForUnit(un){
  if(!un)return null;
  const ch=ORIG_CAST.find(c=>c.name===(un.charName||un.name));
  if(!ch)return null;
  const body=VIEWER_BODY_OVERRIDE[ch.name]||ch.body||'';
  const bodyFile=VIEWER_BODY_FILE[body];
  const bodyRole=VIEWER_BODY_ROLE[body];
  if(!bodyFile&&!bodyRole)return null;
  const file=bodyFile||ROLE_MODEL_FILES[bodyRole]+'.obj';
  return {key:body||ch.name,file,prefix:bodyFile?'assets/soldier/bodies/':'assets/soldier/',charName:ch.name,texture:CAST_TEXTURE_FILE[ch.name]||''};
}

async function loadBodyRecord(spec){
  const base=spec.prefix+spec.file;
  const [objRes,rigRes]=await Promise.all([fetch(base),fetch(base.replace(/\.obj$/,'_rig.json'))]);
  if(!objRes.ok||!rigRes.ok)return null;
  const text=await objRes.text();
  const rig=await rigRes.json();
  let count=0;
  for(const line of text.split('\n'))if(line.startsWith('v '))count++;
  const valid=!!(rig.bones&&rig.skinIndex&&rig.skinIndex.length===count*4&&rig.skinWeight&&rig.skinWeight.length===count*4);
  const skin=valid?{skinIndex:rig.skinIndex,skinWeight:rig.skinWeight}:{skinIndex:new Array(count*4).fill(0),skinWeight:new Array(count*4).fill(0)};
  const geo=parseOBJ3(text,skin);
  const pos=geo.attributes.position.array,zs=[];
  for(let i=2;i<pos.length;i+=3)zs.push(pos[i]);
  zs.sort((a,b)=>a-b);
  const p95=zs[Math.floor(zs.length*0.95)]||1,scale=1.14/p95;
  if(scale!==1)geo.scale(scale,scale,scale);
  const data=valid&&scale!==1?scaleRigForGeometry(rig,scale,THREE).rig:(valid?rig:null);
  if(!data)return null;
  const rec={data,geo,tex:(spec.texture&&REAL.castTex[spec.texture])||null,charName:spec.charName};
  REAL.byBody[spec.key]=rec;
  return rec;
}

export function ensureSquadBodies(units){
  if(typeof THREE==='undefined')return Promise.resolve();
  const specs=(units||[]).map(bodySpecForUnit).filter(Boolean);
  const todo=[];
  for(const spec of specs){
    if(REAL.byBody[spec.key]||REAL.bodyLoading[spec.key])continue;
    REAL.bodyLoading[spec.key]=loadBodyRecord(spec).catch(()=>null).then(rec=>{delete REAL.bodyLoading[spec.key];return rec;});
    todo.push(REAL.bodyLoading[spec.key]);
  }
  return Promise.all(todo);
}

export function loadRealSoldier(ctx={}){
  if(typeof THREE==='undefined')return;
  const {draw=()=>{},updateUI=()=>{},build3DWorld=()=>{},rebuildDemo=()=>{},PORTRAIT_CACHE,REAL_SPRITES}=ctx;
  REAL.texByRole={};REAL.byRole={};REAL.castTex={};REAL.byBody={};REAL.bodyLoading={};
  fetch('assets/soldier_scales.json').then(r=>r.json()).then(sc=>{ROLE_SCALES=sc||{};}).catch(err=>console.error('[loadRealSoldier:escalas]',err));
  fetch('assets/soldier_clips.json').then(r=>{if(!r.ok)throw new Error('clips');return r.json();}).then(pack=>{CLIPLIB.pack=pack;CLIPLIB.ready=true;}).catch(err=>console.error('[loadRealSoldier:clips]',err));
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
      Promise.all(MESHY_CAST.map(c=>loadMeshyModel(c.mesh,REAL)))
    ]).then(([casts])=>{
      (casts||[]).forEach(([file,t])=>{if(t)REAL.castTex[file]=t;});
    });
  }).then(()=>ensureSquadBodies(ctx.G&&ctx.G.units)).then(()=>{
    if(PORTRAIT_CACHE)Object.keys(PORTRAIT_CACHE).forEach(k=>delete PORTRAIT_CACHE[k]);
    if(REAL_SPRITES){REAL_SPRITES.cache={};REAL_SPRITES.failed=false;}
    buildSpriteStrip();
    rebuildDemo();
    if(ctx.G&&ctx.T3&&ctx.VIEW_MODE==='3d')build3DWorld();
    if(ctx.G){updateUI();draw();}
  }).catch(err=>console.error('[loadRealSoldier]',err));
}
