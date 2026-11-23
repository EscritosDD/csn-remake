import { NATIONS } from '../data/nations.js';
import { ROLES } from '../data/roles.js';
import { hash2, REDUCED_MOTION, FX } from '../render2d/index.js';
import { isSoftwareGL3, isMobileGL3, skyTheme3, texMat3, mat3, box3, makeContactShadow3, makeSoldier3, makeRealSoldier3, REAL, CLIPLIB, driveClipSoldier, driveRealSoldier, fitLiveGun3 } from '../render3d/index.js';

export let DEMO=null;
let demoNation=null;
export function setDEMO(v){DEMO=v;}
export function setDemoNation(v){demoNation=v;}
export function demoStatus(msg){const el=document.getElementById('demoStatus');if(el)el.textContent=msg;}
export function demoUnit(id,team,role,weapon){
  return {id:id,team:team,role:role,weapon:weapon,skin:'nacion',nation:demoNation||NATIONS[0],x:0,y:0,dx:0,dy:0,maxEnergy:8,energy:8,maxHp:250,hp:250,alive:true,invisible:false,body:ROLES[role]?ROLES[role].body:'medio'};
}
export function buildDemo(){
  if(DEMO)return true;
  const wrap=document.getElementById('demoWrap');if(!wrap)return false;
  if(typeof THREE==='undefined'){demoStatus('La vista 3D no ha podido cargar en este dispositivo: dentro de la partida seguirás viendo el tablero clásico, con las mismas reglas.');return false;}
  let renderer;
  try{renderer=new THREE.WebGLRenderer({antialias:true});}
  catch(e){demoStatus('Tu dispositivo no ha podido abrir WebGL, así que el 3D no puede mostrarse aquí: dentro de la partida seguirás viendo el tablero clásico, con las mismas reglas.');return false;}
  const isSw=isSoftwareGL3(renderer);
  renderer.setPixelRatio(isSw?1:Math.min(isMobileGL3()?1.5:(window.devicePixelRatio||1),2));
  renderer.outputColorSpace=THREE.SRGBColorSpace;
  renderer.toneMapping=THREE.ACESFilmicToneMapping;
  renderer.toneMappingExposure=1.12;
  renderer.shadowMap.enabled=!isSw;
  if(!isSw)renderer.shadowMap.type=THREE.PCFSoftShadowMap;
  wrap.appendChild(renderer.domElement);
  const scene=new THREE.Scene();
  const sky=skyTheme3('almacen');
  scene.background=new THREE.Color(sky.bg);
  scene.fog=new THREE.Fog(sky.fog,22,42);
  const camera=new THREE.PerspectiveCamera(37.5,2,0.1,120);
  scene.add(new THREE.HemisphereLight(0xd8ecff,0x3c462e,1.15));
  const sun=new THREE.DirectionalLight(0xffe8b8,1.6);
  sun.position.set(-6,12,5);
  if(!isSw){sun.castShadow=true;sun.shadow.mapSize.set(1024,1024);sun.shadow.bias=-0.0005;sun.shadow.normalBias=0.02;}
  scene.add(sun);
  const fill=new THREE.DirectionalLight(0x8ec5ff,0.55);fill.position.set(7,5,-6);scene.add(fill);
  const rim=new THREE.DirectionalLight(0x9fe8ff,0.85);rim.position.set(5,8,-9);scene.add(rim);
  const stage=new THREE.Group();scene.add(stage);
  const apron=new THREE.Mesh(new THREE.PlaneGeometry(26,26),texMat3('apron',null,0.95));
  apron.rotation.x=-Math.PI/2;apron.position.y=-0.12;apron.receiveShadow=true;stage.add(apron);
  const curb=new THREE.Mesh(new THREE.BoxGeometry(7.46,0.14,7.46),mat3('#4f534c',0.9));
  curb.position.y=-0.06;curb.receiveShadow=true;stage.add(curb);
  [[-3.92,-3.92],[3.92,-3.92],[-3.92,3.92],[3.92,3.92]].forEach(cp=>{
    const bollard=new THREE.Mesh(new THREE.CylinderGeometry(0.13,0.15,0.4,10),mat3('#3a3e42',0.7));
    bollard.position.set(cp[0],0.1,cp[1]);bollard.castShadow=true;stage.add(bollard);
    const cap=new THREE.Mesh(new THREE.CylinderGeometry(0.14,0.14,0.055,10),mat3('#f2b234',0.5));
    cap.position.set(cp[0],0.32,cp[1]);stage.add(cap);
  });
  for(let y=0;y<7;y++)for(let x=0;x<7;x++){
    const h=hash2(x,y);
    const tile=box3(0.97,0.09,0.97,['#99968e','#918e85','#a09d94','#8b887f'][Math.floor(h*4)],x-3,0,y-3,0.95);
    tile.castShadow=false;stage.add(tile);
  }
  const beacon=new THREE.Mesh(new THREE.PlaneGeometry(1.94,1.94),new THREE.MeshBasicMaterial({color:0xf2b234,transparent:true,opacity:0.16,depthWrite:false}));
  beacon.rotation.x=-Math.PI/2;beacon.position.set(0,0.06,0);stage.add(beacon);
  [[0,-1.0,2.04,0.06],[0,1.0,2.04,0.06],[-1.0,0,0.06,2.04],[1.0,0,0.06,2.04]].forEach(e=>{
    const rim=new THREE.Mesh(new THREE.BoxGeometry(e[2],0.03,e[3]),new THREE.MeshBasicMaterial({color:0xf2b234}));
    rim.position.set(e[0],0.04,e[1]);stage.add(rim);
  });
  const wallMat=texMat3('wall',null,0.85),crateMat=texMat3('crate',null,0.9),barrelMat=texMat3('barrel',null,0.55);
  const wallGeo=new THREE.BoxGeometry(0.86,0.72,0.86),shelfGeo=new THREE.BoxGeometry(0.86,0.88,0.86),crateGeo=new THREE.BoxGeometry(0.76,0.5,0.76);
  [[-2,-2,'wall'],[2,2,'wall'],[-2,2,'crate'],[2,-2,'crate'],[0,-3,'shelf','#d9b13a','#a9862a'],[0,3,'shelf','#3f8b93','#2e6a71']].forEach(p=>{
    const grp=new THREE.Group();grp.position.set(p[0],0,p[1]);
    const sh=makeContactShadow3(0.5,0.048);if(sh)grp.add(sh);
    if(p[2]==='wall'){
      const b=new THREE.Mesh(wallGeo,wallMat);b.position.y=0.41;b.castShadow=true;b.receiveShadow=true;grp.add(b);
      grp.add(box3(0.92,0.09,0.92,'#585e64',0,0.08,0,0.85));
      grp.add(box3(0.92,0.06,0.92,'#b4bac0',0,0.8,0,0.75));
    } else if(p[2]==='shelf'){
      const b=new THREE.Mesh(shelfGeo,texMat3('shelf',p[3],0.8));b.position.y=0.49;b.castShadow=true;b.receiveShadow=true;grp.add(b);
      grp.add(box3(0.9,0.05,0.9,p[4],0,0.95,0,0.8));
    } else {
      const b=new THREE.Mesh(crateGeo,crateMat);b.position.y=0.3;b.castShadow=true;b.receiveShadow=true;grp.add(b);
      grp.add(box3(0.8,0.05,0.8,'#b88b50',0,0.57,0,0.88));
    }
    stage.add(grp);
  });
  const mkBarrel=(bx,bz)=>{
    const grp=new THREE.Group();grp.position.set(bx,0,bz);
    const sh=makeContactShadow3(0.38,0.048);if(sh)grp.add(sh);
    const cyl=new THREE.Mesh(new THREE.CylinderGeometry(0.28,0.28,0.68,18),barrelMat);
    cyl.position.y=0.39;cyl.castShadow=true;cyl.receiveShadow=true;grp.add(cyl);
    const ring1=new THREE.Mesh(new THREE.TorusGeometry(0.285,0.016,8,24),mat3('#7c1d18',0.5));
    ring1.rotation.x=Math.PI/2;ring1.position.y=0.25;grp.add(ring1);
    const ring2=ring1.clone();ring2.position.y=0.55;grp.add(ring2);
    const lid=new THREE.Mesh(new THREE.CylinderGeometry(0.26,0.26,0.02,16),mat3('#e87266',0.45));
    lid.position.y=0.74;grp.add(lid);
    stage.add(grp);
  };
  mkBarrel(-3,0);mkBarrel(3,0);
  const defs=[[901,'A','Comando','M4A1',-1.5,-1.2],[902,'A','Médico','M4A1',-1.5,1.1],[903,'B','Artillero','M249 SAW',1.5,-1.1],[904,'B','Espía','MP7',1.5,1.2]];
  const units=[];
  const meshes=defs.map(d=>{
    const un=demoUnit(d[0],d[1],d[2],d[3]);
    units.push(un);
    const mesh=REAL.ready?makeRealSoldier3(un):makeSoldier3(un);
    mesh.position.set(d[4],0.05,d[5]);
    mesh.rotation.y=d[1]==='A'?-Math.PI/2:Math.PI/2;
    stage.add(mesh);return mesh;
  });
  DEMO={renderer:renderer,scene:scene,camera:camera,rim:rim,stage:stage,meshes:meshes,units:units,beacon:beacon,lastW:0,lastH:0};
  demoStatus(REAL.ready
    ? 'Vista 3D activa: el soldado que gira es el del original de 2012 (su malla, su textura y su esqueleto), sobre el escenario en volumen. Pulsa «Jugar ahora en 3D» y lo mueves tú.'
    : 'Vista 3D activa: escenario en volumen y soldados sobre la cuadrícula, renderizados ahora mismo. Pulsa «Jugar ahora en 3D» y juegas en este mismo 3D.');
  return true;
}
export function rebuildDemo(){
  if(!DEMO)return;
  const wrap=document.getElementById('demoWrap');
  if(wrap&&DEMO.renderer&&DEMO.renderer.domElement&&DEMO.renderer.domElement.parentNode===wrap)wrap.removeChild(DEMO.renderer.domElement);
  if(DEMO.renderer)DEMO.renderer.dispose();
  DEMO=null;buildDemo();
}
export function renderDemoFrame(ctx){
 const {myNation}=ctx;
  if(!DEMO)return;
  const wrap=document.getElementById('demoWrap');
  const panel=document.getElementById('demoPanel');
  if(!wrap||!panel||!panel.offsetParent)return;
  const w=wrap.clientWidth,h=wrap.clientHeight;
  if(!w||!h)return;
  if(w!==DEMO.lastW||h!==DEMO.lastH){DEMO.lastW=w;DEMO.lastH=h;DEMO.renderer.setSize(w,h,false);DEMO.camera.aspect=w/h;DEMO.camera.updateProjectionMatrix();}
  const t=FX.t;
  DEMO.stage.rotation.y=REDUCED_MOTION?0.6:t/9000;
  if(DEMO.beacon)DEMO.beacon.material.opacity=REDUCED_MOTION?0.16:(0.13+0.06*Math.sin(t/520));
  DEMO.meshes.forEach((m,i)=>{m.position.y=0.05+(REDUCED_MOTION?0:Math.abs(Math.sin(t/700+i*1.7))*0.03);});
  /* Los soldados del escaparate también se animan con sus clips y
     llevan el arma anclada a la mano, como en la partida: antes el
     escenario no movía ni un hueso, así que enseñaban la pose de
     bind (brazos colgando a los lados) con el arma clavada en su
     punto fijo de construcción, flotando delante del pecho — la
     primera arma flotante que se veía al abrir la página. Los
     motores de pose leen el estado global de partida; fuera de
     partida se les pasa una vacía y se restaura, como en la foto
     de los sprites. */
  {
    const hadG=ctx.G;
    if(!ctx.G)ctx.G={selected:null,over:false,winner:null,units:[],turn:'A',round:1};
    try{
      DEMO.meshes.forEach((m,i)=>{
        const un=DEMO.units&&DEMO.units[i];if(!un)return;
        const ud=m.userData;
        if(ud&&ud.real){if(CLIPLIB.ready)driveClipSoldier(un,m,t,false);else driveRealSoldier(un,m,t,false);fitLiveGun3(un,m);}
      });
    }catch(e){}
    ctx.G=hadG;
  }
  DEMO.camera.position.set(0,7.6,8.6);
  DEMO.camera.lookAt(0,0,0.2);
  DEMO.renderer.render(DEMO.scene,DEMO.camera);
};
