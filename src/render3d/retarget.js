import { HAS_THREE } from './env.js';
import { clipPulse, _hitWhite } from './clips.js';

export const _rq=HAS_THREE?new THREE.Quaternion():null,_rq2=HAS_THREE?new THREE.Quaternion():null,_sv=HAS_THREE?new THREE.Vector3():null;

export const AXIS_X3=HAS_THREE?new THREE.Vector3(1,0,0):null,AXIS_Y3=HAS_THREE?new THREE.Vector3(0,1,0):null,AXIS_Z3=HAS_THREE?new THREE.Vector3(0,0,1):null;

export function rotAxisQ(axis,ang){return new THREE.Quaternion().setFromAxisAngle(axis,ang);}

export function aimR(pitch,yawIn,rollIn,sgn){
  return rotAxisQ(AXIS_Y3,rollIn*sgn).multiply(rotAxisQ(AXIS_Z3,yawIn*sgn)).multiply(rotAxisQ(AXIS_X3,pitch));
}

export function boneTargetQ(ud,idx,R){
  const bw=ud.bindWorldQ[idx];
  _rq.copy(bw).invert().multiply(R).multiply(bw);
  return new THREE.Quaternion().copy(ud.bindLocal[idx]).multiply(_rq);
}

export function driveRealSoldier(un,mesh,t,moving){
  const ud=mesh.userData;if(ud&&ud.meshy)return;
  const ts=t/1000;
  const rdt=(ud._realLastT!=null&&(t-ud._realLastT)>0)?Math.min(100,t-ud._realLastT):16.7;
  ud._realLastT=t;
  ud._firePulse=clipPulse(ud._firePulse,180,rdt);
  ud._flashPulse=clipPulse(ud._flashPulse,90,rdt);
  ud._hitPulse=clipPulse(ud._hitPulse,260,rdt);
  ud._deathPulse=clipPulse(ud._deathPulse,420,rdt);
  let name='idle',ct=0;
  if(!un.alive){name='death';ct=un._deathT!=null?(t-un._deathT)/1000:9;}
  else if(un._shootT!=null&&(t-un._shootT)<1150){name='fire';ct=(t-un._shootT)/1000;}
  else if(un._hitT!=null&&(t-un._hitT)<500){name='hit';ct=(t-un._hitT)/1000;}
  else if(moving)name='walk';
  const bn=ud.byName;
  const targets={};
  const rootOff=new THREE.Vector3();
  const put=(boneName,R)=>{const i=bn[boneName];if(i!=null)targets[i]=boneTargetQ(ud,i,R);};
  /* Postura de apunte a dos manos. En la pose de bind los brazos cuelgan
     abiertos y las manos quedan bajas y a ±0,38 laterales (medido por
     cinemática directa sobre las bindpose del IPA), así que el arma se
     veía flotando delante del soldado sin que nadie la sujetara. Estos
     giros llevan las manos a ≈(0,30 hacia delante, 0,73 de alto, ±0,19
     laterales) en el espacio del grupo, que es donde va ahora el arma
     (subida de 0,55 a 0,68 de alto y pegada al pecho): el soldado la
     sujeta en reposo, andando, disparando y encajando tiros, con la
     fuerza s atenuando la postura al andar o al recibir un impacto. */
  const aimPose=(s,extra)=>{
    const ex=extra||0;
    put('Bip001 L UpperArm',aimR((-1.09+ex)*s,0.40*s,-0.41*s,1));
    put('Bip001 R UpperArm',aimR((-0.95+ex)*s,0.39*s,-0.43*s,-1));
    put('Bip001 L Forearm',aimR(-0.07*s,0.14*s,0,1));
    put('Bip001 R Forearm',aimR(-0.08*s,0.40*s,0,-1));
  };
  if(name!=='death')aimPose(1);
  if(name==='idle'&&!REDUCED_MOTION){
    aimPose(1,0.012*Math.sin(ts*0.8+un.id)); /* el arma se mece con la respiración */
    put('Bip001 Spine1',rotAxisQ(AXIS_X3,0.06+0.025*Math.sin(ts*1.35+un.id*1.7)));
    put('Bip001 Head',rotAxisQ(AXIS_X3,0.022*Math.sin(ts*0.9+un.id)));
    rootOff.z=0.004*Math.sin(ts*1.35+un.id*1.7);
  } else if(name==='walk'&&!REDUCED_MOTION){
    ud.walkPh+=0.30;
    const ph=ud.walkPh,s=Math.sin(ph);
    aimPose(0.8+0.03*Math.cos(2*ph)); /* el arma bota suave con los pasos */
    put('Bip001 L Thigh',rotAxisQ(AXIS_X3,0.55*s));
    put('Bip001 R Thigh',rotAxisQ(AXIS_X3,-0.55*s));
    put('Bip001 L Calf',rotAxisQ(AXIS_X3,0.50*Math.max(0,Math.sin(ph-2.2))));
    put('Bip001 R Calf',rotAxisQ(AXIS_X3,0.50*Math.max(0,Math.sin(ph+Math.PI-2.2))));
    put('Bip001 L Foot',rotAxisQ(AXIS_X3,-0.22*s));
    put('Bip001 R Foot',rotAxisQ(AXIS_X3,0.22*s));
    put('Bip001 Spine',rotAxisQ(AXIS_X3,0.06+0.04*Math.sin(2*ph)));
    rootOff.z=0.022*Math.abs(Math.cos(ph));
  } else if(name==='fire'){
    const env=REDUCED_MOTION?0:(ct<0.06?ct/0.06:Math.exp(-(ct-0.06)*6.5));
    if(env>0.01){
      aimPose(1,-0.13*env);
      put('Bip001 Spine1',rotAxisQ(AXIS_X3,-0.13*env));
      put('Bip001 Head',rotAxisQ(AXIS_X3,-0.07*env));
      rootOff.y=0.035*env;
    }
  } else if(name==='hit'){
    const env=REDUCED_MOTION?0:Math.sin(Math.PI*Math.min(1,ct/0.45));
    if(env>0.01){
      aimPose(0.55);
      put('Bip001 Spine',rotAxisQ(AXIS_X3,-0.20*env));
      put('Bip001 Head',rotAxisQ(AXIS_X3,-0.26*env));
      rootOff.y=0.03*env;
    }
  } else if(name==='death'){
    const d=REDUCED_MOTION?1:Math.min(1,ct/0.7),e=1-Math.pow(1-d,3);
    const ri=bn['Bip001'];if(ri!=null)targets[ri]=rotAxisQ(AXIS_X3,-1.42*e);
    put('Bip001 L Thigh',rotAxisQ(AXIS_X3,0.30*e));
    put('Bip001 R Thigh',rotAxisQ(AXIS_X3,0.22*e));
    put('Bip001 L Calf',rotAxisQ(AXIS_X3,0.38*e));
    put('Bip001 R Calf',rotAxisQ(AXIS_X3,0.30*e));
    put('Bip001 L UpperArm',rotAxisQ(AXIS_X3,0.45*e));
    put('Bip001 R UpperArm',rotAxisQ(AXIS_X3,0.45*e));
    rootOff.y=0.06*e;rootOff.z=-0.02*e;
  }
  const k=REDUCED_MOTION?1:(name==='death'?0.45:0.38);
  for(let i=0;i<ud.bones.length;i++){
    const tgt=targets[i]||ud.bindLocal[i];
    ud.curQ[i].slerp(tgt,k);
    ud.bones[i].quaternion.copy(ud.curQ[i]);
  }
  ud.curRootP.lerp(rootOff,k);ud.bones[0].position.copy(ud.curRootP);
  if(ud.gun&&ud.gun.userData&&ud.gun.userData.flash){
    ud.gun.userData.flash.material.opacity=Math.min(0.95,(ud._flashPulse||0)*0.95);
  }
  if(ud.hitColor&&_hitWhite&&ud.mesh3.material.color){
    ud.mesh3.material.color.copy(ud.hitColor).lerp(_hitWhite,Math.min(0.55,(ud._hitPulse||0)*0.55));
  }
  ud.mesh3.material.opacity=un.invisible?0.45:1;
  ud.mesh3.material.transparent=!!un.invisible;
  if(un.alive){
    const ratio=un.maxHp?un.hp/un.maxHp:1;
    const col=ratio>0.5?'#69d66f':ratio>0.25?'#f2b234':'#ff6b5e';
    ud.segs.forEach((s,i)=>{s.visible=i<un.energy;s.material.color.set(col);});
    ud.selRing.visible=(G.selected===un);
    if(ud.selRing.visible&&!REDUCED_MOTION)ud.selRing.rotation.z=t/900;
  } else {ud.segs.forEach(s=>{s.visible=false;});ud.selRing.visible=false;}
}
