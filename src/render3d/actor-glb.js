import { loadGLB } from './gltf-loader.js';
import { COMPETITIVE_ASSETS, disposeObject3D } from './asset-cache.js';

const STATE_WORDS={
  idle:['idle','breath','stand'],
  idle1h:['idle1h','idleonehand','idleone'],
  idle2h:['idle2h','idletwohand','idletwo'],
  walk:['walk','run','move','march'],
  fire:['fire','shoot','attack','shot'],
  hit:['hit','hurt','damage','pain'],
  death:['death','die','dead','down'],
  victory:['victory','win','celebrate','cheer'],
};

export function normalizeBoneName(name){
  return String(name||'').toLowerCase().replace(/[\s_\-.|]/g,'').replace(/^mixamorig/i,'').replace(/^armature/i,'');
}

function stateForClipName(name){
  const normalized=normalizeBoneName(name);
  for(const state of ['idle1h','idle2h']){
    if(STATE_WORDS[state].some(word=>normalized.includes(word)))return state;
  }
  for(const state in STATE_WORDS){
    if(state==='idle1h'||state==='idle2h')continue;
    if(STATE_WORDS[state].some(word=>normalized.includes(word)))return state;
  }
  return null;
}

function buildBoneMap(root){
  const bones=new Map();
  root.traverse(object=>{
    if(!object.isBone)return;
    const key=normalizeBoneName(object.name);
    if(!bones.has(key))bones.set(key,object);
  });
  return bones;
}

function findBone(bones,names){
  for(const name of names){
    const key=normalizeBoneName(name);
    if(bones.has(key))return bones.get(key);
    for(const candidate of bones.keys())if(candidate.includes(key))return bones.get(candidate);
  }
  return null;
}

function computeActorBounds(root){
  root.updateMatrixWorld(true);
  const box=new THREE.Box3();
  root.traverse(object=>{
    if(!object.geometry)return;
    if(!object.geometry.boundingBox)object.geometry.computeBoundingBox();
    const source=object.geometry.boundingBox;
    if(source&&!source.isEmpty())box.union(source.clone().applyMatrix4(object.matrixWorld));
  });
  return box;
}

function frameRoot(root,height){
  root.updateMatrixWorld(true);
  const box=computeActorBounds(root);
  if(box.isEmpty())return {size:new THREE.Vector3(),center:new THREE.Vector3()};
  const size=box.getSize(new THREE.Vector3()),center=box.getCenter(new THREE.Vector3());
  const scale=size.y>0.001?height/size.y:1;
  root.scale.multiplyScalar(scale);
  root.position.x-=center.x*scale;
  root.position.z-=center.z*scale;
  root.position.y-=box.min.y*scale;
  root.updateMatrixWorld(true);
  return {size,center,scale};
}

function collectActions(actor,animations){
  if(!THREE.AnimationMixer||!animations||!animations.length)return;
  actor.mixer=new THREE.AnimationMixer(actor.root);
  animations.forEach((clip,index)=>{
    const state=stateForClipName(clip.name)||'idle';
    const action=actor.mixer.clipAction(clip);
    if(!actor.actions[state])actor.actions[state]=action;
    actor.clipNames[index]=clip.name;
  });
}

export function createGlbCharacterActor(loaded,options={}){
  if(!loaded||!loaded.scene||!THREE)throw new Error('No se pudo crear el actor GLB.');
  const root=loaded.scene;
  const height=options.height||1.08;
  if(options.rotationY)root.rotation.y+=options.rotationY;
  const framing=frameRoot(root,height);
  root.traverse(object=>{
    if(!object.material)return;
    const materials=Array.isArray(object.material)?object.material:[object.material];
    materials.forEach(material=>{
      if(!material||material.userData&&material.userData.glbOwned===false)return;
      material.side=THREE.FrontSide;
      material.alphaTest=0;
      material.needsUpdate=true;
    });
  });
  const actor={
    root,
    bones:buildBoneMap(root),
    animations:loaded.animations||[],
    actions:{},
    clipNames:{},
    mixer:null,
    current:null,
    weapon:null,
    sockets:{},
    stats:loaded.stats||{},
    framing,
    dispose(){disposeGlbActor(this);},
  };
  collectActions(actor,actor.animations);
  actor.sockets.right=resolveWeaponSocket(actor,'right');
  actor.sockets.left=resolveWeaponSocket(actor,'left');
  return actor;
}

export async function loadGlbActor(url,options={}){
  const loaded=await COMPETITIVE_ASSETS.get('glb:'+url,()=>loadGLB(url,options));
  return createGlbCharacterActor(loaded,options);
}

export function resolveWeaponSocket(actor,hand='right'){
  if(!actor)return null;
  const key=hand==='left'?'left':'right';
  if(actor.sockets&&actor.sockets[key])return actor.sockets[key];
  const names=key==='left'?['LeftHand','hand.L','mixamorigLeftHand']:['RightHand','hand.R','mixamorigRightHand'];
  const bone=findBone(actor.bones||new Map(),names);
  const socket=bone||new THREE.Object3D();
  if(!bone)socket.position.set(key==='left'?-0.28:0.28,-0.05,0.16);
  socket.name='glb_socket_'+key;
  socket.userData.glbOwned=true;
  if(bone)bone.add(socket);
  return socket;
}

export function equipWeapon(actor,weapon,hand='right'){
  if(!actor||!weapon)return null;
  const socket=resolveWeaponSocket(actor,hand);
  if(socket.parent!==weapon.parent)socket.add(weapon);
  actor.weapon=weapon;
  return weapon;
}

export function getMuzzleWorldPos(actor,out){
  const target=out||new THREE.Vector3();
  const weapon=actor&&actor.weapon;
  if(weapon){
    let muzzle=null;
    weapon.traverse(object=>{if(!muzzle&&/municion|muzzle|boca/i.test(object.name))muzzle=object;});
    if(muzzle)return muzzle.getWorldPosition(target);
    if(weapon.userData&&weapon.userData.glbMuzzle)return weapon.userData.glbMuzzle.getWorldPosition(target);
    const box=computeActorBounds(weapon);
    if(!box.isEmpty())return box.getCenter(target).setX(box.max.x);
  }
  const socket=resolveWeaponSocket(actor,'right');
  return socket?socket.getWorldPosition(target):target.set(0,0,0);
}

export function crossFadeTo(actor,state,duration=0.18,loop=true){
  if(!actor||!actor.mixer)return null;
  const action=actor.actions[state]||actor.actions.idle;
  if(!action)return null;
  if(actor.current&&actor.current!==action)actor.current.fadeOut(duration);
  action.reset();
  action.setLoop(!!loop,loop?Infinity:1);
  action.clampWhenFinished=!loop;
  action.fadeIn(duration).play();
  actor.current=action;
  return action;
}

export function playOnce(actor,state){return crossFadeTo(actor,state,0.1,false);}

export function updateGlbActor(actor,dt){if(actor&&actor.mixer)actor.mixer.update(Math.max(0,dt||0));}

export function disposeGlbActor(actor){
  if(!actor)return 0;
  if(actor.mixer){
    actor.mixer.stopAllAction();
    actor.mixer.uncacheRoot(actor.root);
    actor.mixer=null;
  }
  actor.actions={};
  const result=disposeObject3D(actor.root);
  if(actor.root&&actor.root.parent)actor.root.parent.remove(actor.root);
  return result.geometries+result.materials+result.textures;
}
