import { shadeHex, SKIN_TONES } from '../render2d/sprites.js';
import { ROLES, roleLook } from '../data/roles.js';
import { SKINS } from '../data/nations.js';
import { makeGunProp3 } from './gun.js';

export let VIEW_MODE='3d';

export function setViewMode3(v){VIEW_MODE=v;}

export let T3=null;

export function setT3(v){T3=v;}

export function w2cx(x){return x-boardCenter().x;}

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
      gx.fillStyle='#63686c';gx.fillRect(0,0,2,1);
      gx.fillStyle='#9fa5a8';gx.fillRect(2,0,2,1);
      gx.fillStyle='#d1d5d4';gx.fillRect(4,0,2,1);
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
    team:un.team==='A'?'#387EC9':'#C95338',
    role:ROLES[un.role].color,
    skin:SKIN_TONES[un.id%SKIN_TONES.length]
  };
}

export function makeSoldier3(un){
  const c=soldierColors3(un);
  const g=new THREE.Group();
  const lk3=roleLook(un.role);
  const bulky=lk3.s[0];
  /* disco de bando, sombra de contacto, flecha de orientación y anillo de energía */
  const contactSh=makeContactShadow3(0.42,0.008);if(contactSh)g.add(contactSh);
  const base=new THREE.Mesh(new THREE.CylinderGeometry(0.31,0.34,0.035,24),mat3(c.team,0.6));
  base.position.y=0.02;base.receiveShadow=true;g.add(base);
  const chev=new THREE.Mesh(new THREE.ConeGeometry(0.085,0.14,3),new THREE.MeshBasicMaterial({color:un.team==='A'?0x7ae7ff:0xffa07a}));
  chev.rotation.z=-Math.PI/2;chev.scale.set(0.28,1,1);chev.position.set(0.37,0.036,0);g.add(chev);
  const segs=[];
  for(let i=0;i<un.maxEnergy;i++){
    const a=-Math.PI/2+i*(Math.PI*2/un.maxEnergy);
    const s=box3(0.075,0.028,0.045,'#69d66f',Math.cos(a)*0.42,0.035,Math.sin(a)*0.42,0.5);
    s.rotation.y=-a;g.add(s);segs.push(s);
  }
  const selRing=new THREE.Mesh(new THREE.TorusGeometry(0.5,0.016,8,40),new THREE.MeshBasicMaterial({color:0xffffff}));
  selRing.rotation.x=Math.PI/2;selRing.position.y=0.03;selRing.visible=false;g.add(selRing);
  /* cuerpo articulado: caderas, hombros, cuello y arma con pivote propio.
     Este soldado de cajas es solo la reserva: se usa si la malla real del
     IPA no ha cargado. El soldado de verdad es el de makeRealSoldier3, con
     la malla, el skinning y la textura del original. Cada pieza cuelga del
     hueso más cercano (cadera para
     pierna y bota, hombro para brazo y mano, cuello para la cabeza, hombros
     para el arma) y el sistema de animación mueve los pivotes, no la malla. */
  const body=new THREE.Group();body.scale.set(1,lk3.s[1],1);g.add(body);
  function makeLeg(sideZ){
    const hip=new THREE.Group();hip.position.set(0,0.28,sideZ);
    const leg=box3(0.11,0.27,0.13,shadeHex(c.uni,-34),0,-0.135,0);
    const boot=box3(0.17,0.06,0.12,'#241f1a',0.03,-0.27,0);
    hip.add(leg,boot);body.add(hip);return hip;
  }
  const hipL=makeLeg(0.1*bulky), hipR=makeLeg(-0.1*bulky);
  const torso=box3(0.26,0.36,0.4*bulky,c.uni,0,0.45,0);
  const chest=box3(0.05,0.26,0.3*bulky,c.role,0.14,0.45,0);
  body.add(torso,chest);
  if(un.role==='Artillero'){ /* cinta de munición cruzada */
    const belt=box3(0.3,0.05,0.44,'#e8c84e',0.02,0.5,0,0.6);belt.rotation.x=0.6;body.add(belt);
  }
  if(un.role==='Médico'){ /* botiquín a la espalda */
    const kit=box3(0.1,0.2,0.24,'#eef0e6',-0.19,0.48,0);body.add(kit);
    body.add(box3(0.03,0.13,0.045,'#d92c2c',-0.25,0.48,0,0.5));
    body.add(box3(0.03,0.045,0.13,'#d92c2c',-0.25,0.48,0,0.5));
  }
  if(un.role==='Ingeniero'){ /* mochila de herramientas */
    body.add(box3(0.12,0.26,0.28,'#5b5348',-0.2,0.5,0));
  }
  /* brazos con pivote en el hombro: sujetan el arma y absorben el retroceso */
  function makeArm(sideZ){
    const sh=new THREE.Group();sh.position.set(0,0.60,sideZ);
    const arm=box3(0.26,0.09,0.1,shadeHex(c.uni,-8),0.13,-0.06,0);
    const hand=new THREE.Mesh(new THREE.SphereGeometry(0.05,10,8),mat3(c.skin,0.65));
    hand.position.set(0.27,-0.07,0);hand.castShadow=true;
    sh.add(arm,hand);body.add(sh);return sh;
  }
  const armL=makeArm(0.21*bulky), armR=makeArm(-0.21*bulky);
  /* === EL ARMA, ENORME: la misma silueta por categoría del soldado real === */
  const gun=makeGunProp3(un);gun.position.set(0.08,0.52,0);body.add(gun);
  const muzzle=gun.userData.flash;
  /* CABEZA GRANDE con casco abovedado y banda de nación */
  const head=new THREE.Group();head.position.y=0.82;body.add(head);
  const skull=new THREE.Mesh(new THREE.SphereGeometry(0.17,22,18),mat3(c.skin,0.65));
  skull.castShadow=true;head.add(skull);
  if(un.role==='Espía'){
    const hood=new THREE.Mesh(new THREE.SphereGeometry(0.185,22,18,0,Math.PI*2,0,Math.PI*0.62),mat3('#353144',0.8));
    hood.castShadow=true;head.add(hood);
  } else {
    const helm=new THREE.Mesh(new THREE.SphereGeometry(0.185,22,14,0,Math.PI*2,0,Math.PI*0.55),mat3(c.helm,0.7));
    helm.position.y=0.015;helm.castShadow=true;head.add(helm);
    const brim=box3(0.4,0.03,0.42,shadeHex(c.helm,-14),0.01,0.045,0,0.7);head.add(brim);
    const band=new THREE.Mesh(new THREE.CylinderGeometry(0.188,0.188,0.05,22,1,true),mat3(c.band,0.7));
    band.position.y=0.045;head.add(band);
  }
  if(un.role==='Capitán'){
    const star=box3(0.02,0.09,0.09,'#ffd94d',0.16,0.1,0,0.4);head.add(star);
  }
  if(un.role==='Médico'){
    head.add(box3(0.1,0.05,0.14,'#ffffff',0,0.19,0,0.5));
    head.add(box3(0.03,0.035,0.05,'#d92c2c',0,0.225,0,0.5));
  }
  if(un.role==='Ingeniero'){
    head.add(box3(0.4,0.025,0.42,'#e8c84e',0.01,0.085,0,0.7));
  }
  if(un.role==='Comando'){
    head.add(box3(0.34,0.06,0.34,shadeHex(c.role,-18),0,0.075,0,0.7));
  }
  if(un.role==='Francotirador'){ /* flecos de ghillie sobre el casco */
    for(let i=0;i<6;i++){const a=i/6*Math.PI*2+0.3;head.add(box3(0.03,0.13,0.03,i%2?'#5d7a28':'#3e5620',Math.sin(a)*0.14,0.02,Math.cos(a)*0.14,0.85));}
  }
  if(un.role==='Artillero'){ /* cascos de comunicaciones a las orejas */
    head.add(box3(0.1,0.12,0.045,'#1e1e22',0,-0.02,0.185,0.6));
    head.add(box3(0.1,0.12,0.045,'#1e1e22',0,-0.02,-0.185,0.6));
  }
  if(un.role==='Médico'){ /* la cruz también sobre la gorra blanca */
    head.add(box3(0.13,0.03,0.045,'#d92c2c',0,0.232,0,0.5));
    head.add(box3(0.045,0.03,0.13,'#d92c2c',0,0.232,0,0.5));
  }
  /* ojos que miran al frente (hacia donde apunta el arma) */
  [-0.065,0.065].forEach(z=>{
    const eye=new THREE.Mesh(new THREE.SphereGeometry(0.02,8,8),new THREE.MeshBasicMaterial({color:0x1c1a17}));
    eye.position.set(0.155,0.01,z);head.add(eye);
  });
  g.userData={body:body,segs:segs,selRing:selRing,contactSh:contactSh,baseChev:chev,hipL:hipL,hipR:hipR,armL:armL,armR:armR,head:head,gun:gun,muzzle:muzzle,walkPhase:Math.random()*6.28,prevX:null,prevY:null,deathK:0,aimAng:un.team==='A'?0:Math.PI};
  return g;
}
