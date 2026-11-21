import { HAS_THREE } from './env.js';
import { roleLook } from '../data/roles.js';

export const _gpDir=HAS_THREE?new THREE.Vector3():null,_gpTwoH=HAS_THREE?new THREE.Vector3():null,_gpFwd=HAS_THREE?new THREE.Vector3(1,0,0):null;

export const _gpUp=HAS_THREE?new THREE.Vector3(0,1,0):null,_gpZ=HAS_THREE?new THREE.Vector3():null,_gpY=HAS_THREE?new THREE.Vector3():null;

export const _gpOrigin=HAS_THREE?new THREE.Vector3():null,_gpQuat=HAS_THREE?new THREE.Quaternion():null,_gpRecoil=HAS_THREE?new THREE.Quaternion():null,_gpMat=HAS_THREE?new THREE.Matrix4():null,_gpSocketQ=HAS_THREE?new THREE.Quaternion():null,_gpParentQ=HAS_THREE?new THREE.Quaternion():null;

export const _gpRPalm=HAS_THREE?new THREE.Vector3():null,_gpLPalm=HAS_THREE?new THREE.Vector3():null,_gpFA=HAS_THREE?new THREE.Vector3():null;

export const _gpPalmR=HAS_THREE?new THREE.Vector3(-0.103,0.016,0):null,_gpPalmL=HAS_THREE?new THREE.Vector3(-0.102,0.016,0):null;

export function _smooth01(e0,e1,x){const t=Math.max(0,Math.min(1,(x-e0)/(e1-e0)));return t*t*(3-2*t);}

export function gunPoseFromHand(rPalm,fa,grip,lPalm,opts){
  _gpDir.copy(rPalm).sub(fa);
  if(_gpDir.lengthSq()<1e-6)return null;
  _gpDir.normalize();
  const is1h=!!(opts&&opts.is1h);
  const roleH=(opts&&opts.roleH)||1;
  const roleAvg=(opts&&opts.roleAvg)||1;
  _gpDir.lerp(_gpFwd,is1h?0.30:0.32).normalize();
  let w2h=0;
  if(!is1h&&lPalm&&!(opts&&opts.force1h)){
    const span=rPalm.distanceTo(lPalm)/roleAvg;
    const ly=lPalm.y/roleH;
    w2h=_smooth01(0.28,0.42,ly)*_smooth01(0.20,0.28,span)*(1-_smooth01(0.52,0.62,span));
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
  return {origin:_gpOrigin,dir:_gpDir,quat:_gpQuat};
}

export function fitGunToHand3(un,grp,isLive){
  if(!HAS_THREE)return;
  const ud=grp&&grp.userData;if(ud&&ud.meshy)return;
  if(!ud||!ud.gun||!ud.byName||!ud.bones)return;
  const parent=ud.gun.parent;if(!parent)return;
  if(grp.updateWorldMatrix)grp.updateWorldMatrix(true,true);else grp.updateMatrixWorld(true);
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
  const lk=roleLook(un.role);
  const ck=ud._clipKey||'';
  const is1h=(ud.gun.userData.cat==='Pistolas');
  const force1h=(ck==='death'||ck==='deathExpl'||ck==='hit'||ck==='hitBurst'||ck==='hitExpl'||ck==='throw'||ck==='deploy'||ck==='interact'||ck==='victory'||ck==='pickup');
  const pose=gunPoseFromHand(_gpRPalm,_gpFA,ud.gun.userData.grip,hasL?_gpLPalm:null,{
    is1h:is1h,
    force1h:force1h,
    roleH:lk.s[1],
    roleAvg:(lk.s[0]+lk.s[1]+lk.s[2])/3
  });
  if(!pose)return;
  if(isLive&&ud._firePulse>0){
    pose.origin.addScaledVector(pose.dir,-0.055*ud._firePulse);
    pose.quat.multiply(_gpRecoil.setFromAxisAngle(_gpUp,0.035*ud._firePulse));
  }
  ud.gun.position.copy(pose.origin);
  ud.gun.quaternion.copy(pose.quat);
}

export function fitSpriteGun(un,grp){fitGunToHand3(un,grp,false);}

export function fitLiveGun3(un,grp){
  if(!(grp&&grp.userData&&grp.userData.real))return;
  fitGunToHand3(un,grp,true);
}
