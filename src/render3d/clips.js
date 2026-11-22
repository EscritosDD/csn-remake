import { HAS_THREE } from './env.js';
import { WEAPONS } from '../data/weapons.js';
import { shortestArc } from '../core-and-audio.js';

export const CLIPLIB={ready:false,pack:null};

export const CLIP_BLEND_MS=200,CLIP_BLEND_DEATH_MS=140;

export const _cq=HAS_THREE?new THREE.Quaternion():null,_cq2=HAS_THREE?new THREE.Quaternion():null,_cv=HAS_THREE?new THREE.Vector3():null,_cv2=HAS_THREE?new THREE.Vector3():null,_cv3=HAS_THREE?new THREE.Vector3():null;

export const CLIP_EVENT_LOG=[];

export const _hitWhite=HAS_THREE?new THREE.Color(0xffffff):null;

export const _retargetDelta=HAS_THREE?new THREE.Quaternion():null,_retargetInverse=HAS_THREE?new THREE.Quaternion():null;

export function clipPulse(v,ms,dt){return Math.max(0,(v||0)-dt/ms);}

export function releasePendingVisualHit(shooter,t){
  const target=shooter&&shooter._shootTarget,pending=target&&target._pendingHit;
  if(!pending)return;
  const now=(t==null&&typeof FX!=='undefined')?FX.t:t;
  target._hitT=now;target._hitAmt=pending.amt;target._hitKind=pending.kind;
  if(pending.death&&target._deathT==null){target._deathT=now;target._deathKind=pending.kind;}
  target._pendingHit=null;target._visualDelayUntil=null;
}

export function fireWeaponFeedback(un,ud,full){
  const shooter=(un&&un.x!=null)?un:null,target=shooter&&shooter._shootAt,cat=shooter&&shooter._shootCat;
  const shot=shooter&&shooter._shootT,now=(typeof performance!=='undefined'?performance.now():Date.now());
  if(shooter&&shot!==shooter._lastFxShot){shooter._lastFxShot=shot;shooter._lastFxAt=0;shooter._voicedShotAt=null;}
  releasePendingVisualHit(shooter);
  const loud=!!full&&now-(shooter&&shooter._lastFxAt||0)>=100;
  if(loud&&shooter){
    shooter._lastFxAt=now;
    auWeapon(cat,shooter._shootW);
    if(shooter._voicedShotAt!==shot){shooter._voicedShotAt=shot;if(Math.random()<0.6)auVoice(shooter,'firing',0.42);}
  }
  if(ud){
    ud._firePulse=Math.max(ud._firePulse||0,full?1:0.42);
    ud._flashPulse=1;
  }
  if(shooter&&target&&target.x!=null){
    if(full&&loud){fxBurst(shooter.x,shooter.y,3,'#ffe9a8');if(typeof fx3Shot==='function')fx3Shot(shooter,target,cat);}
    if(!full||loud)fxTracer(shooter,target);
  }
}


export function clipEventFeedback(un,ud,key,clip,e,ct,t){
  const f=e.f||'';let acted=false;
  if(f==='PlayWeaponFire'||(f==='OnAnimEvent'&&e.i===10)||f==='PlayFiring'){
    if(key==='throw'||key==='deploy'||key==='interact')ud._firePulse=Math.max(ud._firePulse||0,0.4);
    else if(f!=='PlayFiring')fireWeaponFeedback(un,ud,f==='PlayWeaponFire');
    else ud._firePulse=Math.max(ud._firePulse||0,0.35);
    acted=true;
  } else if(f==='PlayHit'||f==='PlayPain'||f==='PlayBulletBy'){
    ud._hitPulse=1;
    if(f==='PlayHit'){try{auPlay('sfx/weapons/bullet_hit_0'+(1+Math.floor(Math.random()*2))+'.mp3',0.25);}catch(e){}}
    acted=true;
  } else if(f==='PlayBodyFall'||f==='PlayDeath'||f==='PlayWeaponDrop'){
    ud._deathPulse=1;
    if(!REDUCED_MOTION&&un.x!=null)fxBurst(un.x,un.y,f==='PlayWeaponDrop'?3:6,'#9c8f7b');
    acted=true;
  } else if(f==='PlayAppreciation'){
    auVoice(un,'thanks',0.5);acted=true;
  }
  if(acted){
    if(CLIP_EVENT_LOG.length>=160)CLIP_EVENT_LOG.shift();
    CLIP_EVENT_LOG.push({u:un.id||0,k:key,f:f,i:e.i||0,ct:+ct.toFixed(3),t:Math.round(t)});
  }
}

export function dispatchClipEvents(un,ud,clip,key,ct,t){
  if(!clip||!clip.events||!clip.events.length||!ud)return;
  if(!(G&&G.units&&G.units.indexOf(un)>=0))return;
  let st=ud._clipEventState;
  if(!st||st.key!==key){st={key:key,ct:ct,seen:{}};ud._clipEventState=st;}
  if(ct<st.ct-0.08)st.seen={};
  for(let i=0;i<clip.events.length;i++){
    const e=clip.events[i];
    if(!st.seen[i]&&e.t<=ct+0.0005){
      st.seen[i]=1;
      clipEventFeedback(un,ud,key,clip,e,ct,t);
    }
  }
  st.ct=ct;
}

export function clipTrackAt(tr,t){
  const ts=tr.t;
  if(t<=ts[0])return 0;
  if(t>=ts[ts.length-1])return ts.length-1;
  let lo=0,hi=ts.length-1;
  while(hi-lo>1){const mid=(lo+hi)>>1;if(ts[mid]<=t)lo=mid;else hi=mid;}
  return lo;
}

export function sampleClipQuat(tr,t,out){
  const i=clipTrackAt(tr,t),a=tr.q[i];
  if(i>=tr.q.length-1||t<=tr.t[i]){out.set(a[0],a[1],a[2],a[3]);return out;}
  const b=tr.q[i+1];
  let ax=a[0],ay=a[1],az=a[2],aw=a[3];
  let bx=b[0],by=b[1],bz=b[2],bw=b[3];
  let cos=ax*bx+ay*by+az*bz+aw*bw;
  if(cos<0){bx=-bx;by=-by;bz=-bz;bw=-bw;cos=-cos;}
  const alpha=(t-tr.t[i])/(tr.t[i+1]-tr.t[i]);
  let s0,s1;
  if(cos>0.9995){s0=1-alpha;s1=alpha;}
  else{
    const theta=Math.acos(Math.max(-1,Math.min(1,cos))),sin=Math.sin(theta);
    s0=Math.sin((1-alpha)*theta)/sin;s1=Math.sin(alpha*theta)/sin;
  }
  out.set(s0*ax+s1*bx,s0*ay+s1*by,s0*az+s1*bz,s0*aw+s1*bw);
  return out;
}

export function sampleClipPos(tr,t,out){
  const i=clipTrackAt(tr,t),a=tr.p[i];
  if(i>=tr.p.length-1||t<=tr.t[i]){out.set(a[0],a[1],a[2]);return out;}
  const b=tr.p[i+1],k=(t-tr.t[i])/(tr.t[i+1]-tr.t[i]);
  out.set(a[0]+(b[0]-a[0])*k,a[1]+(b[1]-a[1])*k,a[2]+(b[2]-a[2])*k);
  return out;
}

export function worldRotationsFromLocal(localQ,parents){
  const worldQ=[];
  for(let i=0;i<localQ.length;i++){
    const parent=parents[i];
    worldQ[i]=parent>=0?worldQ[parent].clone().multiply(localQ[i]):localQ[i].clone();
  }
  return worldQ;
}

export function retargetPoseToRig(sourcePoseQ,sourceRestWorldQ,targetRestWorldQ,sourceParents,targetParents,sourceWorldQ,targetWorldQ,targetLocalQ){
  for(let i=0;i<sourcePoseQ.length;i++){
    const sourceParent=sourceParents[i];
    if(sourceParent>=0)sourceWorldQ[i].copy(sourceWorldQ[sourceParent]).multiply(sourcePoseQ[i]);
    else sourceWorldQ[i].copy(sourcePoseQ[i]);
    _retargetDelta.copy(sourceWorldQ[i])
      .multiply(_retargetInverse.copy(sourceRestWorldQ[i]).invert())
      .multiply(targetRestWorldQ[i]);
    targetWorldQ[i].copy(_retargetDelta);
    const targetParent=targetParents[i];
    if(targetParent>=0)targetLocalQ[i].copy(targetWorldQ[targetParent]).invert().multiply(targetWorldQ[i]);
    else targetLocalQ[i].copy(targetWorldQ[i]);
  }
}

export function rootBonePositionForClip(rootBase,pelvisOffset,delta,rotatedPelvis,out){
  out.x=rootBase.x+pelvisOffset.x+delta.x-rotatedPelvis.x;
  out.y=rootBase.y+pelvisOffset.y+delta.y-rotatedPelvis.y;
  out.z=rootBase.z+pelvisOffset.z+delta.z-rotatedPelvis.z;
  return out;
}

export function driveClipSoldier(un,mesh,t,moving){
  if(window.__noClips)return; /* diagnostico: reposo puro */
  if(un._pendingHit&&t-un._pendingHit.t>1200)releasePendingVisualHit(un,t);
  const ud=mesh.userData;if(ud&&ud.meshy)return;
  const pack=CLIPLIB.pack,clips=pack.clips,ts=t/1000;
  const wcat=WEAPONS[un.weapon]&&WEAPONS[un.weapon].cat;
  const stance=wcat==='Pistolas'?'1h':wcat==='Cuerpo a cuerpo'?'Melee':'2h';
  const gdX=un.dx!=null?un.dx:un.x,gdY=un.dy!=null?un.dy:un.y;
  const gdt=(ud._gaitLastT!=null&&t-ud._gaitLastT>0)?Math.min(100,t-ud._gaitLastT):16.7;
  const gstep=Math.hypot(gdX-(ud._gaitX!=null?ud._gaitX:gdX),gdY-(ud._gaitY!=null?ud._gaitY:gdY));
  const gspeed=gstep/(gdt/1000);
  ud._gaitLastT=t;ud._gaitX=gdX;ud._gaitY=gdY;
  if(!REDUCED_MOTION){
    if(un._turning)ud._gaitPhase=(ud._gaitPhase||0)+gdt/1000;
    else if(gstep>0.0005)ud._gaitPhase=(ud._gaitPhase||0)+gstep/0.42;
    if(ud._gaitPhase>10000)ud._gaitPhase%=1;
  }
  const walking=!REDUCED_MOTION&&(gspeed>0.15||moving||un._turning);
  let key=null,ct=0;
  if(!un.alive){
    key=un._deathKind==='expl'?'deathExpl':'death';
    ct=un._deathT!=null?(t-un._deathT)/1000:99;
  } else if(REDUCED_MOTION){
    key='idle'+stance;ct=0;
  } else if(un._onceKey&&clips[un._onceKey]&&(ts-un._onceT/1000)<clips[un._onceKey].dur){
    key=un._onceKey;ct=ts-un._onceT/1000;
  } else if(un._shootT!=null&&clips[un._fireKey||'fire2h']&&(t-un._shootT)<clips[un._fireKey||'fire2h'].dur*1000){
    /* La ventana de disparo dura lo que dura el clip de esa familia de
       arma (2,0–4,4 s según el arma), no un corte fijo: antes todos se
       interrumpían a los 1,4 s y el soldado volvía al reposo a mitad de
       la animación de fuego y recuperación del original. */
    key=un._fireKey||'fire2h';ct=(t-un._shootT)/1000;
  } else if(un._hitT!=null&&clips[(wcat==='Cuerpo a cuerpo')?'hitMelee':(un._hitKind==='expl'?'hitExpl':(un._hitKind==='burst'?'hitBurst':'hit'))]&&(t-un._hitT)<clips[(wcat==='Cuerpo a cuerpo')?'hitMelee':(un._hitKind==='expl'?'hitExpl':(un._hitKind==='burst'?'hitBurst':'hit'))].dur*1000){
    key=(wcat==='Cuerpo a cuerpo')?'hitMelee':(un._hitKind==='expl'?'hitExpl':(un._hitKind==='burst'?'hitBurst':'hit'));ct=(t-un._hitT)/1000;
  } else if(G&&G.over&&G.winner===un.team){
    key='victory';ct=(ts+ud.clipPhase)%clips.victory.dur;
  } else if(un._turning&&clips['turn'+stance+'L']){
    const arc=shortestArc((un._turnTo||0)-(un._turnFrom||0));
    const turnKey=Math.abs(arc)>2.3?('turn'+stance+'180'):('turn'+stance+(arc>0?'L':'R'));
    key=clips[turnKey]?turnKey:'turn'+stance+'L';ct=(un._turnProg||0)*clips[key].dur;
  } else if(walking){
    key='walk'+stance;ct=((ud._gaitPhase||0)+ud.clipPhase)%clips[key].dur;
  } else {
    /* Reposo por postura: cada postura alterna su segundo reposo una de
       cada cuatro veces (2h idle2h2, 1h idle1h2, cuerpo a cuerpo
       idleMelee2), como hace el original con sus dos reposos por arma. */
    const idleAlt={ '2h':'idle2h2', '1h':'idle1h2', 'Melee':'idleMelee2' }[stance];
    key=((Math.floor(ts/11)+un.id)%4===0&&clips[idleAlt])?idleAlt:'idle'+stance;
    ct=(ts+ud.clipPhase)%clips[key].dur;
  }
  const clip=clips[key];
  if(!clip){ud._clipKey=key;ud._blendFrom=null;driveRealSoldier(un,mesh,t,moving);return;}
  if(!clip.loop)ct=Math.min(ct,clip.dur);
  /* Fundido cruzado al cambiar de clip: si la clave cambia, el clip
     saliente queda registrado con su tiempo de corte y, durante su
     ventana, se muestrea en paralelo avanzando desde ese instante; la
     pose objetivo de cada hueso es el slerp entre los dos clips con
     peso smoothstep del tiempo transcurrido. Sin cambio de clave no
     hay fundido y el muestreo es el de siempre. */
  let prevClip=null,prevCt=0,blendW=1;
  if(ud._clipKey!==key){
    /* Los impactos entran sin fundido (ver la nota de la cabecera):
       su primer tramo ya es el latigazo, y retenerlo lo concentra. */
    const noBlend=(key==='hit'||key==='hitBurst'||key==='hitExpl');
    ud._blendFrom=(!REDUCED_MOTION&&!noBlend&&ud._clipKey&&clips[ud._clipKey])
      ?{key:ud._clipKey,ct:ud._clipCt||0,t0:t}:null;
    ud._clipKey=key;
  }
  ud._clipCt=ct;
  if(ud._blendFrom){
    const pc=clips[ud._blendFrom.key];
    const dur=(key==='death'||key==='deathExpl')?CLIP_BLEND_DEATH_MS:CLIP_BLEND_MS;
    const w=(t-ud._blendFrom.t0)/dur;
    if(!pc||w>=1){ud._blendFrom=null;}
    else{
      const wc=w<0?0:w;
      blendW=wc*wc*(3-2*wc);
      prevClip=pc;
      prevCt=ud._blendFrom.ct+(t-ud._blendFrom.t0)/1000;
      if(pc.loop)prevCt%=pc.dur;else prevCt=Math.min(prevCt,pc.dur);
    }
  }
  /* Suavizado sobre curQ independiente de la tasa de refresco: el
     factor por fotograma se recalcula con el dt real, así 0,45 a 60 Hz
     sigue siendo 0,45 a 60 Hz se mire a 30 o a 120 fotogramas. Si el
     reloj no avanza (la foto de los sprites llama con el mismo t), se
     usa el paso nominal para que la convergencia de esa foto no cambie. */
  const dtMs=(ud._clipLastT!=null&&(t-ud._clipLastT)>0)?Math.min(100,t-ud._clipLastT):16.7;
  ud._clipLastT=t;
  const baseK=(key==='death'||key==='deathExpl')?0.5:0.45;
  const k=REDUCED_MOTION?1:1-Math.pow(1-baseK,dtMs/16.7);
  ud._firePulse=clipPulse(ud._firePulse,180,dtMs);
  ud._flashPulse=clipPulse(ud._flashPulse,90,dtMs);
  ud._hitPulse=clipPulse(ud._hitPulse,260,dtMs);
  ud._deathPulse=clipPulse(ud._deathPulse,420,dtMs);
  dispatchClipEvents(un,ud,clip,key,ct,t);
  const retarget=!!(ud.isClassRig&&ud.baseRestWorldQ&&ud.sourcePoseQ);
  for(let i=0;i<ud.bones.length;i++){
    const tr=clip.rot[pack.bones[i]];
    const restQ=retarget?ud.baseRestQ[i]:ud.bindLocal[i];
    if(tr)sampleClipQuat(tr,ct,_cq);else _cq.copy(restQ);
    if(prevClip){
      const ptr=prevClip.rot[pack.bones[i]];
      if(ptr)sampleClipQuat(ptr,prevCt,_cq2);else _cq2.copy(restQ);
      _cq2.slerp(_cq,blendW);
      _cq.copy(_cq2);
    }
    if(retarget){
      ud.sourcePoseQ[i].copy(_cq);
    }else{
      ud.curQ[i].slerp(_cq,k);
      ud.bones[i].quaternion.copy(ud.curQ[i]);
    }
  }
  if(retarget){
    retargetPoseToRig(ud.sourcePoseQ,ud.baseRestWorldQ,ud.bindWorldQ,ud.sourceParents,ud.parents,ud.sourceWorldQ,ud.targetWorldQ,ud.targetLocalQ);
    for(let i=0;i<ud.bones.length;i++){
      ud.curQ[i].slerp(ud.targetLocalQ[i],k);
      ud.bones[i].quaternion.copy(ud.curQ[i]);
    }
  }
  /* La raíz conserva su offset de bind además de aplicar el movimiento del
     clip; algunos rigs colocan el hueso raíz a la altura de la pelvis. */
  if(clip.root)sampleClipPos(clip.root,ct,_cv);else _cv.set(0,0,0);
  if(prevClip){
    if(prevClip.root)sampleClipPos(prevClip.root,prevCt,_cv3);else _cv3.set(0,0,0);
    _cv3.lerp(_cv,blendW);
    _cv.copy(_cv3);
  }
  ud.curDelta.lerp(_cv,k);
  const rootBase=ud.bindPos[0],pelvOff=ud.bindPos[1];
  rootBonePositionForClip(rootBase,pelvOff,ud.curDelta,_cv.copy(pelvOff).applyQuaternion(ud.bones[0].quaternion),_cv2);
  ud.bones[0].position.copy(_cv2);
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
