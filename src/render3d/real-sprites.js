import { NATIONS } from '../data/nations.js';
import { WEAPONS } from '../data/weapons.js';
import { BODIES, ROLES, ROLE_NAMES, roleLook } from '../data/roles.js';
import { REAL } from './assets-real.js';
import { makeRealSoldier3 } from './soldiers.js';
import { CLIPLIB, sampleClipQuat, driveClipSoldier } from './clips.js';
import { driveRealSoldier } from './retarget.js';
import { fitSpriteGun } from './gun-pose.js';

export const REAL_SPRITES={renderer:null,scene:null,camera:null,failed:false,cache:{}};

export const REAL_SPRITE_FEET=0.77;

export function realSpriteKey(un){return un.role+'|'+un.weapon+'|'+un.skin+'|'+(un.skin==='nacion'&&un.nation?un.nation.id:'std')+'|'+(un.charKey||un.name||'');}

export function realSpriteUnit(role,weapon,skin,nation,char){
  const r=ROLES[role];if(!r)return null;
  const body=BODIES[r.body]||BODIES.medio;
  return {id:700+ROLE_NAMES.indexOf(role),team:'A',role:role,weapon:weapon||r.weapons[0],skin:skin||'nacion',nation:nation||NATIONS[0],x:0,y:0,dx:0,dy:0,hp:body.hp,maxHp:body.hp,energy:body.energy,maxEnergy:body.energy,alive:true,invisible:false,body:r.body,facing:0,charKey:characterKey(char),charName:char?char.name:role,charTexture:char&&char.texture?char.texture:'',charMesh:char&&char.mesh?char.mesh:''};
}

export function initRealSpriteRenderer(){
  if(REAL_SPRITES.renderer||REAL_SPRITES.failed)return !!REAL_SPRITES.renderer;
  if(typeof THREE==='undefined'){REAL_SPRITES.failed=true;return false;}
  try{
    const renderer=new THREE.WebGLRenderer({antialias:true,alpha:true,preserveDrawingBuffer:true});
    renderer.setPixelRatio(1);
    renderer.setSize(512,512);
    renderer.setClearColor(0x000000,0);
    const scene=new THREE.Scene();
    scene.add(new THREE.HemisphereLight(0xfff2d8,0x2a3320,1.05));
    const sun=new THREE.DirectionalLight(0xffe9bb,1.8);sun.position.set(-4,7,3);scene.add(sun);
    const fill=new THREE.DirectionalLight(0x9fc4ff,0.4);fill.position.set(5,3,-4);scene.add(fill);
    const camera=new THREE.PerspectiveCamera(38,1,0.1,50);
    camera.position.set(2.2,1.35,1.7);
    camera.lookAt(0.1,0.52,0);
    REAL_SPRITES.renderer=renderer;REAL_SPRITES.scene=scene;REAL_SPRITES.camera=camera;
    return true;
  }catch(e){REAL_SPRITES.failed=true;return false;}
}

export const SPRITE_AIM_CT={fire2h:0.40,fireBurst:0.35,fireHeavy:0.45,fireMini:0.35,fireShoulder:0.60,fire1h:1.00,fireMelee:0.30,fire1hHeavy:0.45};

export function poseSpriteClip(un,grp,clip,ct,clipKey){
  const pack=CLIPLIB.pack;if(!pack||!clip)return false;
  const ud=grp.userData;if(ud&&ud.meshy)return false;
  if(!ud||!ud.bones||!ud.bindLocal||!ud.curQ)return false;
  ud._clipKey=clipKey||'';
  const tq=new THREE.Quaternion(),tp=new THREE.Vector3(),tp2=new THREE.Vector3(),pelvis=new THREE.Vector3();
  const retarget=!!(ud.isClassRig&&ud.baseRestWorldQ&&ud.sourcePoseQ);
  for(let n=0;n<24;n++){
    for(let i=0;i<ud.bones.length;i++){
      const tr=clip.rot[pack.bones[i]];
      const restQ=retarget?ud.baseRestQ[i]:ud.bindLocal[i];
      if(tr)sampleClipQuat(tr,ct,tq);else tq.copy(restQ);
      if(retarget){
        ud.sourcePoseQ[i].copy(tq);
      }else{
        ud.curQ[i].slerp(tq,0.45);
        ud.bones[i].quaternion.copy(ud.curQ[i]);
      }
    }
    if(retarget){
      retargetPoseToRig(ud.sourcePoseQ,ud.baseRestWorldQ,ud.bindWorldQ,ud.sourceParents,ud.parents,ud.sourceWorldQ,ud.targetWorldQ,ud.targetLocalQ);
      for(let i=0;i<ud.bones.length;i++){
        ud.curQ[i].slerp(ud.targetLocalQ[i],0.45);
        ud.bones[i].quaternion.copy(ud.curQ[i]);
      }
    }
    if(clip.root)sampleClipPos(clip.root,ct,tp);else tp.set(0,0,0);
    ud.curDelta.lerp(tp,0.45);
    pelvis.copy(ud.bindPos[1]);
    rootBonePositionForClip(ud.bindPos[0],pelvis,ud.curDelta,tp2.copy(pelvis).applyQuaternion(ud.bones[0].quaternion),ud.bones[0].position);
  }
  return true;
}

export function poseSpriteAim(un,grp){
  const pack=CLIPLIB.pack;if(!pack||!pack.clips)return false;
  const key=(typeof fireClipFor==='function')?fireClipFor(un.weapon):null;
  const clip=key?pack.clips[key]:null;
  const ct=key?SPRITE_AIM_CT[key]:null;
  if(!clip||ct==null)return false;
  return poseSpriteClip(un,grp,clip,ct,key);
}

export function renderRealSprite(un){
  if(!un||!un.role||!WEAPONS[un.weapon])return null;
  const key=realSpriteKey(un);
  if(REAL_SPRITES.cache[key])return REAL_SPRITES.cache[key];
  if(!REAL.ready||!initRealSpriteRenderer())return null;
  let grp=null;
  try{
    /* El retrato/sprite se sigue fotografiando con la malla base: su camara
       y encuadre estan calibrados para ella y las mallas de clase tienen
       proporciones distintas. */
    const _fb=window.__forceBaseModel;window.__forceBaseModel=true;
    try{grp=makeRealSoldier3(un);}finally{window.__forceBaseModel=_fb;}
    /* Fuera el disco de bando, el anillo de energía y el anillo de
       selección: en la vista clásica los dibuja el propio tablero bajo
       los pies del sprite, igual que hacía con los de Argon. */
    const hideDisc=()=>{const ud=grp.userData;if(ud.baseMesh)ud.baseMesh.visible=false;if(ud.contactSh)ud.contactSh.visible=false;if(ud.baseChev)ud.baseChev.visible=false;if(ud.segs)ud.segs.forEach(s=>{s.visible=false;});if(ud.selRing)ud.selRing.visible=false;};
    hideDisc();
    /* Postura de la foto: el fotograma de apunte del clip de su arma,
       con el arma encajada en las manos de esa postura. Si los clips
       no han cargado o el de su familia no está, se cae a la postura
       de reposo de siempre: driveClipSoldier y driveRealSoldier leen
       el estado global de partida (G) al final; durante el menú no hay
       partida, así que se les pasa una vacía y se restaura al
       terminar, sin tocar la real. */
    let posed=false;
    const lkPose=roleLook(un.role).pose;
    if(CLIPLIB.ready&&lkPose&&CLIPLIB.pack&&CLIPLIB.pack.clips&&CLIPLIB.pack.clips[lkPose.clip])posed=poseSpriteClip(un,grp,CLIPLIB.pack.clips[lkPose.clip],lkPose.ct,lkPose.clip);
    if(!posed&&CLIPLIB.ready)posed=poseSpriteAim(un,grp);
    if(posed){
      fitSpriteGun(un,grp);
    }else{
      const hadG=G;
      if(!G)G={selected:null,over:false,winner:null,units:[],turn:'A',round:1};
      try{
        for(let i=0;i<16;i++){
          if(CLIPLIB.ready)driveClipSoldier(un,grp,900,false);
          else driveRealSoldier(un,grp,900,false);
        }
      }finally{G=hadG;}
      /* También en la foto de reserva el arma va anclada a la mano
         de la postura: sin este encaje quedaba en su punto fijo de
         construcción (0,16, 0,68), flotando delante del pecho. */
      fitSpriteGun(un,grp);
    }
    hideDisc();
    REAL_SPRITES.scene.add(grp);
    REAL_SPRITES.renderer.render(REAL_SPRITES.scene,REAL_SPRITES.camera);
    const url=REAL_SPRITES.renderer.domElement.toDataURL('image/png');
    REAL_SPRITES.scene.remove(grp);
    const img=new Image();
    img.onload=()=>{if(G)draw();};
    img.src=url;
    REAL_SPRITES.cache[key]={url:url,img:img};
    return REAL_SPRITES.cache[key];
  }catch(e){
    if(grp&&REAL_SPRITES.scene)REAL_SPRITES.scene.remove(grp);
    REAL_SPRITES.failed=true;
    return null;
  }
}

export function getRealSpriteImage(un){
  const e=renderRealSprite(un);
  return (e&&e.img&&e.img.complete&&e.img.naturalWidth>0)?e.img:null;
}

export function getRealSpriteURL(un){
  const e=renderRealSprite(un);
  return e?e.url:null;
}
