import { VIEW_MODE, setViewMode3, T3, setT3, isSoftwareGL3, isMobileGL3 } from './scene.js';
import { build3DWorld } from './world.js';

export function resetCamState(cam){
  cam.yaw=-0.4363;cam.dist=8.5;cam.panX=0;cam.panZ=0.35;
}

export function resetCam3D(){
  if(!T3||!T3.cam)return;
  resetCamState(T3.cam);
}

export function fitViewerDistance(size,fovDegrees,aspect,margin=1.12){
  const radius=Math.hypot(size.x,size.y,size.z)*0.5;
  const halfVertical=fovDegrees*Math.PI/360;
  const halfHorizontal=Math.atan(Math.tan(halfVertical)*Math.max(0.01,aspect));
  const halfFov=Math.min(halfVertical,halfHorizontal);
  return Math.max(0.01,radius/Math.sin(halfFov)*margin);
}

export function viewerCenterOffset(center){
  return {x:-center.x,y:-center.y,z:-center.z};
}

export function init3D(){
  if(T3)return true;
  if(typeof THREE==='undefined')return false;
  const wrap=document.getElementById('glWrap');if(!wrap)return false;
  const renderer=new THREE.WebGLRenderer({antialias:true});
  const isSw=isSoftwareGL3(renderer);
  renderer.setPixelRatio(isSw?1:Math.min(isMobileGL3()?1.5:(window.devicePixelRatio||1),2));
  renderer.outputColorSpace=THREE.SRGBColorSpace;
  renderer.toneMapping=THREE.ACESFilmicToneMapping;
  renderer.toneMappingExposure=1.12;
  renderer.shadowMap.enabled=!isSw;
  if(!isSw)renderer.shadowMap.type=THREE.PCFSoftShadowMap;
  wrap.appendChild(renderer.domElement);
  const scene=new THREE.Scene();
  scene.background=new THREE.Color(0x212922);
  scene.fog=new THREE.Fog(0x212922,28,50);
  const camera=new THREE.PerspectiveCamera(37.5,1.6,0.1,120);
  scene.add(new THREE.HemisphereLight(0xd8ecff,0x3c462e,1.15));
  const sun=new THREE.DirectionalLight(0xeb825c,1.6); /* cálida del original (0,92, 0,51, 0,36) */
  sun.position.set(-7,13,5);
  if(!isSw){
    sun.castShadow=true;
    sun.shadow.mapSize.set(1024,1024);
    sun.shadow.bias=-0.0005;sun.shadow.normalBias=0.02;
    sun.shadow.camera.left=-8.5;sun.shadow.camera.right=8.5;sun.shadow.camera.top=8.5;sun.shadow.camera.bottom=-8.5;
  }
  scene.add(sun);
  const fill=new THREE.DirectionalLight(0xa6cfff,0.55);fill.position.set(7,5,-6);scene.add(fill); /* fría del original (0,65, 0,81, 1,0) */
  const rim=new THREE.DirectionalLight(0x9fe8ff,0.85);rim.position.set(5,8,-9);scene.add(rim);
  const camState={yaw:-0.4363,curYaw:-0.4363,dist:8.5,curDist:8.5,panX:0,curPanX:0,panZ:0.35,curPanZ:0.35}; /* cámara del original: yaw 335°, distancia 8,5 (zoom 0,5), FOV 37,5° */
  setT3({renderer:renderer,scene:scene,camera:camera,isSw:isSw,rim:rim,cam:camState,units:new Map(),hudPool:new Map(),fxItems:[],dynSig:'__none__',hlSig:'__none__',hoverSig:'__none__',ray:new THREE.Raycaster(),lastW:0,lastH:0,lastFrame:0,lastRender:0});
  /* Máscaras de casilla del original (floortile_*, 256×256, blancas sobre negro: el color lo pone el material, como alphaMap). */
  T3.tileMasks={};
  ['attack','placement','heal','aoe','returnfire','willattack'].forEach(function(mk){
    new THREE.TextureLoader().load('assets/ui/orig/floortile_'+mk+'_alpha.png',function(tx){tx.colorSpace=THREE.SRGBColorSpace;T3.tileMasks[mk]=tx;if(T3){T3.hlMatCache={};T3.hlSig='__none__';}});
  });
  const tileFromPointer=function(e){
    const r=renderer.domElement.getBoundingClientRect();
    const nx=((e.clientX-r.left)/r.width)*2-1, ny=-((e.clientY-r.top)/r.height)*2+1;
    T3.ray.setFromCamera({x:nx,y:ny},camera);
    const plane=new THREE.Plane(new THREE.Vector3(0,1,0),-0.05);
    const pt=new THREE.Vector3();
    if(!T3.ray.ray.intersectPlane(plane,pt))return null;
    const tx=Math.floor(pt.x+6), ty=Math.floor(pt.z+6);
    return (tx>=0&&ty>=0&&tx<W&&ty<H)?{x:tx,y:ty}:null;
  };
  let drag={active:false,mode:null,sx:0,sy:0,moved:0,syaw:0,spx:0,spz:0};
  const cvEl=renderer.domElement;
  cvEl.addEventListener('contextmenu',e=>e.preventDefault());
  cvEl.addEventListener('pointerdown',e=>{
    drag.active=true;drag.sx=e.clientX;drag.sy=e.clientY;drag.moved=0;
    drag.syaw=camState.yaw;drag.spx=camState.panX;drag.spz=camState.panZ;
    drag.mode=(e.button===2||(e.button===0&&e.shiftKey))?'orbit':((e.button===1||(e.button===0&&e.altKey))?'pan':'click');
  });
  window.addEventListener('pointermove',e=>{
    if(!drag.active)return;
    const dx=e.clientX-drag.sx,dy=e.clientY-drag.sy;
    drag.moved=Math.max(drag.moved,Math.hypot(dx,dy));
    if(drag.mode==='orbit'&&drag.moved>4){camState.yaw=drag.syaw-dx*0.008;}
    else if(drag.mode==='pan'&&drag.moved>4){
      const cs=Math.cos(camState.yaw),sn=Math.sin(camState.yaw),sc=camState.dist*0.0014;
      camState.panX=Math.max(-5.5,Math.min(5.5,drag.spx-(dx*cs+dy*sn)*sc));
      camState.panZ=Math.max(-5.5,Math.min(5.5,drag.spz-(dy*cs-dx*sn)*sc));
    }
  });
  window.addEventListener('pointerup',e=>{
    if(!drag.active)return;
    const wasClick=(drag.mode==='click'&&drag.moved<=6&&e.target===cvEl);
    drag.active=false;
    if(wasClick){const t=tileFromPointer(e);if(t)boardTileClick(t);}
  });
  cvEl.addEventListener('mousemove',e=>{hoverTile=tileFromPointer(e);});
  cvEl.addEventListener('mouseleave',()=>{hoverTile=null;});
  cvEl.addEventListener('wheel',e=>{
    e.preventDefault();
    camState.dist=Math.max(6,Math.min(11,camState.dist+e.deltaY*0.01));
  },{passive:false});
  document.querySelectorAll('.gl-controls button[data-cam]').forEach(btn=>{
    btn.onclick=()=>{
      const act=btn.dataset.cam;
      if(act==='rotL')camState.yaw-=0.38;
      else if(act==='rotR')camState.yaw+=0.38;
      else if(act==='zoomIn')camState.dist=Math.max(6,camState.dist-1.8);
      else if(act==='zoomOut')camState.dist=Math.min(11,camState.dist+1.8);
      else if(act==='reset')resetCam3D();
      btn.blur();
    };
  });
  return true;
}

export function setViewMode(m){
  const fail=document.getElementById('glFail');
  if(m==='3d'&&!init3D()){
    setViewMode3('2d');
    toast('La vista 3D no ha podido cargar en este dispositivo: sigues en la vista clásica, con la misma partida.');
    if(fail){fail.style.display='block';fail.innerHTML='<b>La vista 3D no ha podido arrancar en este dispositivo</b> y por eso ves el tablero clásico de siempre. La partida es la misma y se juega igual; el aviso queda aquí para que sepas que no es que falte el 3D, es que aquí no ha arrancado.';}
  } else {setViewMode3(m);if(fail)fail.style.display='none';}
  const is3=VIEW_MODE==='3d';
  document.getElementById('glWrap').style.display=is3?'block':'none';
  document.getElementById('board').style.display=is3?'none':'block';
  document.querySelectorAll('#viewSeg button').forEach(b=>b.classList.toggle('on',b.dataset.view===VIEW_MODE));
  if(is3&&G)build3DWorld();
  if(G)draw();
}
