import { shadeHex, SKIN_TONES } from '../render2d/sprites.js';
import { ROLES } from '../data/roles.js';
import { SKINS } from '../data/nations.js';
import { TEAM_A, TEAM_B } from './env.js';

export let VIEW_MODE='3d';

export function setViewMode3(v){VIEW_MODE=v;}

export let T3=null;

export function setT3(v){T3=v;}

export function w2cx(x){return x-boardCenter().x;}

export function w2cz(y){return y-boardCenter().y;}

export function isSoftwareGL3(renderer){
  try{
    const gl=renderer&&renderer.getContext?renderer.getContext():null;
    if(!gl)return true;
    const dbg=gl.getExtension('WEBGL_DEBUG_RENDERER_INFO');
    const rStr=(dbg?gl.getParameter(dbg.UNMASKED_RENDERER_WEBGL):gl.getParameter(gl.RENDERER))||'';
    return /SwiftShader|llvmpipe|Software|Mesa/i.test(rStr);
  }catch(e){return false;}
}

export function isMobileGL3(){
  try{return /Android|iPhone|iPad|iPod|Mobile/i.test(navigator.userAgent||'')||Math.min(innerWidth||0,innerHeight||0)<=640;}catch(e){return false;}
}

export let _toonGrad=null;

export function toonGrad3(){
  if(!_toonGrad&&typeof THREE!=='undefined'){
    try{
      const gc=document.createElement('canvas');gc.width=8;gc.height=1;
      const gx=gc.getContext('2d');
      gx.fillStyle='#4a5056';gx.fillRect(0,0,2,1);
      gx.fillStyle='#8d9498';gx.fillRect(2,0,2,1);
      gx.fillStyle='#d8dede';gx.fillRect(4,0,2,1);
      gx.fillStyle='#ffffff';gx.fillRect(6,0,2,1);
      _toonGrad=new THREE.CanvasTexture(gc);
      _toonGrad.minFilter=THREE.NearestFilter;_toonGrad.magFilter=THREE.NearestFilter;
    }catch(e){}
  }
  return _toonGrad;
}

export function mat3(color,rough,flat){
  const g=toonGrad3();
  if(g&&THREE.MeshToonMaterial){
    const m=new THREE.MeshToonMaterial({color:color,gradientMap:g});
    if(flat!==false)m.flatShading=true;
    return m;
  }
  return new THREE.MeshStandardMaterial({color:color,roughness:rough==null?0.85:rough,metalness:0.04,flatShading:flat!==false});
}

export function box3(w,h,d,color,x,y,z,rough){
  const m=new THREE.Mesh(new THREE.BoxGeometry(w,h,d),mat3(color,rough));
  m.position.set(x||0,y||0,z||0);m.castShadow=true;m.receiveShadow=true;return m;
}

export const TEX3={};

export function procTex3(kind,arg){
  const key=kind+':'+(arg||'');
  if(TEX3[key])return TEX3[key];
  if(typeof THREE==='undefined')return null;
  try{
    const cv=document.createElement('canvas');
    cv.width=cv.height=(kind==='shadow'?128:512);
    const g=cv.getContext('2d'),S=cv.width;
    if(kind==='shadow'){
      const rg2=g.createRadialGradient(S/2,S/2,S*0.08,S/2,S/2,S*0.48);
      rg2.addColorStop(0,'rgba(8,10,8,0.58)');
      rg2.addColorStop(0.65,'rgba(8,10,8,0.26)');
      rg2.addColorStop(1,'rgba(8,10,8,0)');
      g.fillStyle=rg2;g.fillRect(0,0,S,S);
      const t=new THREE.CanvasTexture(cv);TEX3[key]=t;return t;
    }
    if(kind==='wall'){
      g.fillStyle='#868c92';g.fillRect(0,0,S,S);
      for(let i=0;i<240;i++){g.fillStyle=i%2?'rgba(255,255,255,0.06)':'rgba(0,0,0,0.08)';g.fillRect((i*73)%S,(i*137)%S,6,4);}
      g.fillStyle='rgba(255,255,255,0.16)';g.fillRect(0,0,S,14);g.fillRect(0,0,12,S);
      g.fillStyle='rgba(0,0,0,0.22)';g.fillRect(0,S-14,S,14);g.fillRect(S-12,0,12,S);
      g.strokeStyle='rgba(35,38,42,0.55)';g.lineWidth=4;g.strokeRect(10,10,S-20,S-20);
      g.save();g.beginPath();g.rect(12,S-64,S-24,40);g.clip();
      for(let k=-S;k<S*2;k+=36){g.fillStyle=(Math.floor(k/36)%2)?'#222426':'#f2b234';g.save();g.translate(k,S-72);g.rotate(0.55);g.fillRect(0,0,22,88);g.restore();}
      g.restore();
      [[26,26],[S-26,26],[26,S-76],[S-26,S-76]].forEach(p=>{g.beginPath();g.arc(p[0],p[1],5,0,7);g.fillStyle='#4a5056';g.fill();});
    } else if(kind==='shelf'){
      const base=arg||'#d9b13a';
      g.fillStyle=base;g.fillRect(0,0,S,S);
      for(let i=0;i<8;i++){
        const x=i*(S/8);
        g.fillStyle='rgba(255,255,255,0.12)';g.fillRect(x+4,16,S/16-2,S-32);
        g.fillStyle='rgba(0,0,0,0.16)';g.fillRect(x+S/16+2,16,S/16-4,S-32);
      }
      g.strokeStyle='rgba(0,0,0,0.34)';g.lineWidth=14;g.strokeRect(7,7,S-14,S-14);
      g.fillStyle='rgba(248,245,234,0.88)';g.fillRect(28,34,64,42);
      g.fillStyle='rgba(28,30,32,0.72)';g.fillRect(36,44,48,6);g.fillRect(36,56,36,6);
    } else if(kind==='crate'){
      g.fillStyle='#9b6d37';g.fillRect(0,0,S,S);
      for(let i=0;i<5;i++){
        const y=18+i*44;
        g.fillStyle=(i%2)?'#a7773e':'#8f6330';g.fillRect(16,y,S-32,40);
        g.fillStyle='rgba(0,0,0,0.22)';g.fillRect(16,y+38,S-32,3);
      }
      g.strokeStyle='#6d4a20';g.lineWidth=20;g.strokeRect(10,10,S-20,S-20);
      g.strokeStyle='rgba(90,58,22,0.75)';g.lineWidth=18;
      g.beginPath();g.moveTo(22,22);g.lineTo(S-22,S-22);g.moveTo(S-22,22);g.lineTo(22,S-22);g.stroke();
      g.strokeStyle='rgba(255,235,195,0.22)';g.lineWidth=4;g.strokeRect(20,20,S-40,S-40);
      [[24,24],[S-24,24],[24,S-24],[S-24,S-24]].forEach(p=>{g.beginPath();g.arc(p[0],p[1],6,0,7);g.fillStyle='#2c2620';g.fill();});
    } else if(kind==='barrel'){
      const lg2=g.createLinearGradient(0,0,S,0);
      lg2.addColorStop(0,'#9d261f');lg2.addColorStop(0.28,'#de4538');lg2.addColorStop(0.55,'#e76457');lg2.addColorStop(1,'#8f201a');
      g.fillStyle=lg2;g.fillRect(0,0,S,S);
      g.fillStyle='#6d1814';g.fillRect(0,68,S,14);g.fillRect(0,174,S,14);
      g.fillStyle='#f2c037';g.beginPath();g.moveTo(S*0.5,S*0.36);g.lineTo(S*0.64,S*0.62);g.lineTo(S*0.36,S*0.62);g.closePath();g.fill();
      g.fillStyle='#6d1814';g.font='bold 42px Barlow,sans-serif';g.textAlign='center';g.fillText('!',S*0.5,S*0.59);
    } else if(kind==='medkit'){
      g.fillStyle='#f2f0e6';g.fillRect(0,0,S,S);
      g.strokeStyle='#b8b5a6';g.lineWidth=14;g.strokeRect(7,7,S-14,S-14);
      g.fillStyle='#d92c2c';
      g.fillRect(S*0.41,S*0.2,S*0.18,S*0.6);
      g.fillRect(S*0.2,S*0.41,S*0.6,S*0.18);
    } else if(kind==='apron'){
      g.fillStyle='#2a302b';g.fillRect(0,0,S,S);
      const step=S/4;
      for(let y=0;y<4;y++)for(let x=0;x<4;x++){
        g.fillStyle=((x+y)%2)?'#313731':'#2c322d';
        g.fillRect(x*step+2,y*step+2,step-4,step-4);
      }
      g.strokeStyle='rgba(15,17,15,0.55)';g.lineWidth=3;
      for(let k=0;k<=4;k++){g.beginPath();g.moveTo(k*step,0);g.lineTo(k*step,S);g.stroke();g.beginPath();g.moveTo(0,k*step);g.lineTo(S,k*step);g.stroke();}
    }
    const tex=new THREE.CanvasTexture(cv);
    tex.colorSpace=THREE.SRGBColorSpace;
    tex.anisotropy=4;
    if(kind==='apron'){tex.wrapS=THREE.RepeatWrapping;tex.wrapT=THREE.RepeatWrapping;tex.repeat.set(5,5);}
    TEX3[key]=tex;return tex;
  }catch(e){return null;}
}

export function texMat3(kind,arg,rough){
  const t=procTex3(kind,arg),g=toonGrad3();
  if(t&&g&&THREE.MeshToonMaterial)return new THREE.MeshToonMaterial({color:0xffffff,map:t,gradientMap:g});
  if(t)return new THREE.MeshStandardMaterial({color:0xffffff,map:t,roughness:rough==null?0.85:rough,metalness:0.04});
  return mat3(arg||'#888888',rough);
}

export function makeContactShadow3(radius,y){
  const t=procTex3('shadow');
  if(!t)return null;
  const m=new THREE.Mesh(new THREE.CircleGeometry(radius||0.44,18),new THREE.MeshBasicMaterial({map:t,transparent:true,depthWrite:false,opacity:0.86}));
  m.rotation.x=-Math.PI/2;m.position.y=y==null?0.008:y;m.renderOrder=1;
  return m;
}

export function skyTheme3(theme){
  if(theme==='skirmish03'||theme==='skirmish04')return {bg:0x24313d,fog:0x24313d};
  if(theme==='plaza')return {bg:0x2d2c26,fog:0x2d2c26};
  if(theme==='dock'||theme==='astillero')return {bg:0x1e2c33,fog:0x1e2c33};
  if(theme==='market')return {bg:0x322a22,fog:0x322a22};
  if(theme==='warehouse')return {bg:0x232b31,fog:0x232b31};
  if(theme==='yard')return {bg:0x2b2620,fog:0x2b2620};
  if(theme==='terminal'||theme==='depot')return {bg:0x222930,fog:0x222930};
  if(theme==='platform'||theme==='cruce')return {bg:0x2b2624,fog:0x2b2624};
  if(theme==='rotonda')return {bg:0x272a25,fog:0x272a25};
  return {bg:0x212922,fog:0x212922};
}

export let EMBLEM_TEX={};

export function nationTintColor(nation){
  if(!nation||!nation.colors)return '#ffffff';
  let best=nation.colors[0],bestSat=-1;
  nation.colors.forEach(hex=>{
    const c=new THREE.Color(hex);
    const mx=Math.max(c.r,c.g,c.b),mn=Math.min(c.r,c.g,c.b);
    const sat=mx>0?(mx-mn)/mx:0;
    if(sat>bestSat){bestSat=sat;best=hex;}
  });
  return best;
}

export let CAMO_TEX=null;

export function camoTexture(){
  if(CAMO_TEX)return CAMO_TEX;
  try{
    const cv=document.createElement('canvas');cv.width=cv.height=256;
    const cx=cv.getContext('2d');
    const cols=['#5a6346','#3f4a34','#6e6a4a','#2f3628','#6b5b3e'];
    cx.fillStyle=cols[0];cx.fillRect(0,0,256,256);
    let sd=1337;const rnd=()=>{sd=(sd*1103515245+12345)&0x7fffffff;return sd/0x7fffffff;};
    for(let i=0;i<160;i++){
      const x=rnd()*256,y=rnd()*256,r=6+rnd()*22;
      cx.fillStyle=cols[1+Math.floor(rnd()*(cols.length-1))];
      cx.beginPath();
      for(let k=0;k<7;k++){const a=k/7*Math.PI*2;const rr=r*(0.6+rnd()*0.7);const px=x+Math.cos(a)*rr,py=y+Math.sin(a)*rr;k?cx.lineTo(px,py):cx.moveTo(px,py);}
      cx.closePath();cx.fill();
    }
    CAMO_TEX=new THREE.CanvasTexture(cv);CAMO_TEX.colorSpace=THREE.SRGBColorSpace;CAMO_TEX.wrapS=CAMO_TEX.wrapT=THREE.RepeatWrapping;
    return CAMO_TEX;
  }catch(e){return null;}
}

export function emblemTexture(nation){
  if(!nation)return null;
  if(EMBLEM_TEX[nation.id])return EMBLEM_TEX[nation.id];
  try{
    const cv=document.createElement('canvas');cv.width=cv.height=64;
    const cx=cv.getContext('2d');
    cx.clearRect(0,0,64,64);
    cx.fillStyle='#f7df9a';cx.font='bold 46px serif';cx.textAlign='center';cx.textBaseline='middle';
    cx.fillText(nation.emblem||'★',32,35);
    const t=new THREE.CanvasTexture(cv);t.colorSpace=THREE.SRGBColorSpace;
    EMBLEM_TEX[nation.id]=t;return t;
  }catch(e){return null;}
}

export function soldierColors3(un){
  const isNat=un.skin==='nacion';
  const isClass=un.skin==='clase';
  const nc=un.nation?un.nation.colors:['#66704f','#3e4630','#59613f'];
  return {
    uni:isNat?nc[0]:(un.skin==='camuflaje'?'#5a6346':(isClass?(ROLES[un.role]?ROLES[un.role].color:SKINS.estandar.uniform):SKINS.estandar.uniform)),
    helm:isNat?((nc[2]==='#FFFFFF'||nc[2]===nc[0])?shadeHex(nc[0],-25):nc[2]):SKINS.estandar.helmet,
    band:isNat?nc[1]:'#3e4630',
    team:un.team==='A'?TEAM_A:TEAM_B,
    role:ROLES[un.role].color,
    skin:SKIN_TONES[un.id%SKIN_TONES.length]
  };
}


