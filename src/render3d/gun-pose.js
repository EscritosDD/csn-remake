import { HAS_THREE } from './env.js';
import { roleLook } from '../data/roles.js';
import { WEAPON_SOCKETS, WEAPON_MESH_FILE } from './assets-weapons.js';

export const _gpDir=HAS_THREE?new THREE.Vector3():null,_gpTwoH=HAS_THREE?new THREE.Vector3():null,_gpFwd=HAS_THREE?new THREE.Vector3(1,0,0):null;

export const _gpUp=HAS_THREE?new THREE.Vector3(0,1,0):null,_gpZ=HAS_THREE?new THREE.Vector3():null,_gpY=HAS_THREE?new THREE.Vector3():null;

export const _gpOrigin=HAS_THREE?new THREE.Vector3():null,_gpQuat=HAS_THREE?new THREE.Quaternion():null,_gpRecoil=HAS_THREE?new THREE.Quaternion():null,_gpMat=HAS_THREE?new THREE.Matrix4():null,_gpSocketQ=HAS_THREE?new THREE.Quaternion():null,_gpParentQ=HAS_THREE?new THREE.Quaternion():null;

export const _gpRPalm=HAS_THREE?new THREE.Vector3():null,_gpLPalm=HAS_THREE?new THREE.Vector3():null,_gpFA=HAS_THREE?new THREE.Vector3():null;

export const _gpRS=HAS_THREE?new THREE.Vector3():null,_gpLS=HAS_THREE?new THREE.Vector3():null;

export const _gpPalmR=HAS_THREE?new THREE.Vector3(-0.103,0.016,0):null,_gpPalmL=HAS_THREE?new THREE.Vector3(-0.102,0.016,0):null;

const GP_ONE_HAND_FILES=new Set(['Pistol','Revolver','Uzi','FragGrenade','Molotov','Knife','Katana','WoodAxe','BaseballBat_SOURCE','SpikedClub_weapon']);

export function gunIsOneHanded(file,cat){
  const ref=WEAPON_MESH_FILE[file||'']||'';
  return GP_ONE_HAND_FILES.has(file)||GP_ONE_HAND_FILES.has(ref)||cat==='Pistolas'||cat==='Consumible'||
    (cat==='Subfusiles'&&(file==='Uzi'||ref==='Uzi'))||
    (cat==='Cuerpo a cuerpo'&&file!=='SledgeHammer'&&file!=='Chainsaw');
}

export function _smooth01(e0,e1,x){const t=Math.max(0,Math.min(1,(x-e0)/(e1-e0)));return t*t*(3-2*t);}


export function gunPoseFromHand(rPalm,fa,grip,lPalm,opts){
  _gpDir.copy(rPalm).sub(fa);
  if(_gpDir.lengthSq()<1e-6)return null;
  _gpDir.normalize();
  const is1h=!!(opts&&opts.is1h);
  const roleH=(opts&&opts.roleH)||1;
  const roleAvg=(opts&&opts.rigSpan)||(opts&&opts.roleAvg)||1;
  const w2hPrev=Math.max(0,Math.min(1,Number(opts&&opts.w2hPrev)||0));
  _gpDir.lerp(_gpFwd,is1h?0.30:0.32).normalize();
  let w2h=0;
  if(!is1h&&lPalm&&!(opts&&opts.force1h)){
    const span=rPalm.distanceTo(lPalm)/roleAvg;
    const ly=lPalm.y/roleH;
    const target=_smooth01(0.28,0.42,ly)*_smooth01(0.20,0.28,span)*(1-_smooth01(0.52,0.62,span));
    w2h=w2hPrev+(target-w2hPrev)*(target>w2hPrev?0.28:0.12);
    if(target>0.985||target<0.01)w2h=target;
    if(w2h>0.001){
      _gpTwoH.copy(lPalm).sub(rPalm);
      if(_gpTwoH.lengthSq()>1e-6){
        _gpTwoH.normalize();
        _gpDir.lerp(_gpTwoH,w2h).normalize();
      }
    }
  }
  _gpZ.crossVectors(_gpDir,_gpUp);
  if(_gpZ.lengthSq()<1e-4)_gpZ.set(0,0,1);else _gpZ.normalize();
  _gpY.crossVectors(_gpZ,_gpDir).normalize();
  const g=grip||{x:0.2,y:-0.05,scale:1};
  const gs=g.scale||1;
  _gpOrigin.copy(rPalm).addScaledVector(_gpDir,-g.x*gs).addScaledVector(_gpY,-g.y*gs);
  _gpMat.makeBasis(_gpDir,_gpY,_gpZ);
  _gpQuat.setFromRotationMatrix(_gpMat);
  return {origin:_gpOrigin,dir:_gpDir,quat:_gpQuat,w2h};
}

export function fitGunToHand3(un,grp,isLive){
  if(!HAS_THREE)return;
  const ud=grp&&grp.userData;if(ud&&ud.meshy)return;
  if(!ud||!ud.gun||!ud.byName||!ud.bones)return;
  const parent=ud.gun.parent;if(!parent)return;
  if(grp.updateWorldMatrix)grp.updateWorldMatrix(true,true);else grp.updateMatrixWorld(true);
  const sr=WEAPON_SOCKETS.handRight&&WEAPON_SOCKETS.handRight.pos;
  const sl=WEAPON_SOCKETS.handLeft&&WEAPON_SOCKETS.handLeft.pos;
  if(Array.isArray(sr)&&sr.length===3&&sr.every(Number.isFinite)){_gpPalmR.fromArray(sr);_gpPalmR.x=-Math.abs(_gpPalmR.x);}
  else _gpPalmR.set(-0.103,0.016,0);
  if(Array.isArray(sl)&&sl.length===3&&sl.every(Number.isFinite)){_gpPalmL.fromArray(sl);_gpPalmL.x=-Math.abs(_gpPalmL.x);}
  else _gpPalmL.set(-0.102,0.016,0);
  const bR=ud.bones[ud.byName['Bip001 R Hand']];
  const bFA=ud.bones[ud.byName['Bip001 R Forearm']];
  if(!bR||!bFA)return;
  _gpRPalm.copy(_gpPalmR).applyMatrix4(bR.matrixWorld);
  parent.worldToLocal(_gpRPalm);
  _gpFA.setFromMatrixPosition(bFA.matrixWorld);
  parent.worldToLocal(_gpFA);
  const bL=ud.bones[ud.byName['Bip001 L Hand']];
  let hasL=false;
  if(bL){
    _gpLPalm.copy(_gpPalmL).applyMatrix4(bL.matrixWorld);
    parent.worldToLocal(_gpLPalm);
    hasL=true;
  }
  const bRU=ud.bones[ud.byName['Bip001 R UpperArm']];
  const bLU=ud.bones[ud.byName['Bip001 L UpperArm']];
  const lk=roleLook(un.role);
  const roleSpan=(lk.s[0]+lk.s[1]+lk.s[2])/3;
  let rigSpan=roleSpan;
  if(bRU&&bLU){
    _gpRS.setFromMatrixPosition(bRU.matrixWorld);parent.worldToLocal(_gpRS);
    _gpLS.setFromMatrixPosition(bLU.matrixWorld);parent.worldToLocal(_gpLS);
    rigSpan=Math.max(0.5,Math.min(1.6,(_gpRS.distanceTo(_gpRPalm)+_gpRS.distanceTo(_gpLS))/1.2))*0.7+roleSpan*0.3;
  }
  const gunData=ud.gun.userData||{};
  const ck=ud._clipKey||'';
  const is1h=gunIsOneHanded(gunData.file||'',gunData.cat||'');
  const force1h=(ck==='death'||ck==='deathExpl'||ck==='hit'||ck==='hitBurst'||ck==='hitExpl'||ck==='throw'||ck==='deploy'||ck==='interact'||ck==='victory'||ck==='pickup');
  const pose=gunPoseFromHand(_gpRPalm,_gpFA,gunData.grip,hasL?_gpLPalm:null,{
    is1h:is1h,
    force1h:force1h,
    roleH:lk.s[1],
    rigSpan:rigSpan,
    w2hPrev:ud._viewW2H||0
  });
  if(!pose)return;
  ud._viewW2H=force1h||is1h?0:pose.w2h;
  if(isLive&&ud._firePulse>0){
    pose.origin.addScaledVector(pose.dir,-0.055*ud._firePulse);
    pose.quat.multiply(_gpRecoil.setFromAxisAngle(_gpUp,0.035*ud._firePulse));
  }
  const gunRef=gunData.file||ud.gun;
  if(ud._viewGunRef!==gunRef){
    ud._viewGunRef=gunRef;
    ud.gun.position.copy(pose.origin);
    ud.gun.quaternion.copy(pose.quat);
  }else{
    ud.gun.position.lerp(pose.origin,isLive?0.45:0.28);
    ud.gun.quaternion.slerp(pose.quat,isLive?0.35:0.22);
  }
}


export function fitSpriteGun(un,grp){fitGunToHand3(un,grp,false);}

export function fitLiveGun3(un,grp){
  if(!(grp&&grp.userData&&grp.userData.real))return;
  fitGunToHand3(un,grp,true);
}
