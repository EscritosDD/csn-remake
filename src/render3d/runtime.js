import { VIEW_MODE, T3, w2cx, init3D, setViewMode, build3DWorld, rebuildDyn3, rebuildHighlights3, updateHover3D, tickFx3D, updateUnitHuds3D, driveClipSoldier, driveRealSoldier, fitLiveGun3, updateGlbActor, crossFadeTo, CLIPLIB, CLIP_EVENT_LOG, skState, arcadeFxStats, TEAM_A_HEX, TEAM_B_HEX } from './index.js';
import { REDUCED_MOTION, FX } from '../render2d/index.js';
import { domControl } from '../ui/index.js';
import { tileWorldY } from '../game/index.js';
import { cheb, shortestArc } from '../core-and-audio.js';

export function build3DFrame(){
  if(VIEW_MODE!=='3d')return;
  if(!init3D()){setViewMode('2d');return;}
  document.getElementById('glWrap').style.display='block';
  document.getElementById('board').style.display='none';
  build3DWorld();
}

export function render3DFrame(ctx){
const {G,hoverTile,advanceUnitYaw,TURRET_POS}=ctx;
  if(!T3||VIEW_MODE!=='3d'||!G)return;
  const wrap=document.getElementById('glWrap');
  const w=wrap.clientWidth,h=wrap.clientHeight;
  if(!w||!h)return;
  const t=FX.t;
  const dt=T3.lastFrame?Math.min(0.05,(t-T3.lastFrame)/1000):0.016;
  T3.lastFrame=t;
  if(w!==T3.lastW||h!==T3.lastH){T3.lastW=w;T3.lastH=h;T3.renderer.setSize(w,h,false);T3.camera.aspect=w/h;T3.camera.updateProjectionMatrix();}
  /* cámara táctica interactiva con amortiguación exponencial + sacudida */
  const c=T3.cam;
  const panSp=5.5*dt;
  if(ctx.keysHeld['w']||ctx.keysHeld['arrowup']){c.panZ=Math.max(-5.5,c.panZ-Math.cos(c.yaw)*panSp);c.panX=Math.max(-5.5,c.panX-Math.sin(c.yaw)*panSp);}
  if(ctx.keysHeld['s']||ctx.keysHeld['arrowdown']){c.panZ=Math.min(5.5,c.panZ+Math.cos(c.yaw)*panSp);c.panX=Math.min(5.5,c.panX+Math.sin(c.yaw)*panSp);}
  if(ctx.keysHeld['a']||ctx.keysHeld['arrowleft']){c.panX=Math.max(-5.5,c.panX-Math.cos(c.yaw)*panSp);c.panZ=Math.min(5.5,c.panZ+Math.sin(c.yaw)*panSp);}
  if(ctx.keysHeld['d']||ctx.keysHeld['arrowright']){c.panX=Math.min(5.5,c.panX+Math.cos(c.yaw)*panSp);c.panZ=Math.max(-5.5,c.panZ-Math.sin(c.yaw)*panSp);}
  /* La camara acompaña el disparo: se desliza hacia donde ocurre la accion
     (tambien en turnos de la IA) y vuelve a quedarse quieta despues. */
  if(G&&G._camFocus&&Date.now()<G._camFocus.until){
    const fx=Math.max(-5.5,Math.min(5.5,w2cx(G._camFocus.x)));
    const fz=Math.max(-5.5,Math.min(5.5,w2cx(G._camFocus.y)));
    const k=Math.min(1,dt*1.7);
    c.panX+=(fx-c.panX)*k;
    c.panZ+=(fz-c.panZ)*k;
  }
  const damp=REDUCED_MOTION?1:(1-Math.exp(-10*dt));
  c.curYaw+=(c.yaw-c.curYaw)*damp;
  c.curDist+=(c.dist-c.curDist)*damp;
  c.curPanX+=(c.panX-c.curPanX)*damp;
  c.curPanZ+=(c.panZ-c.curPanZ)*damp;
  const sway=REDUCED_MOTION?0:Math.sin(t/4600)*0.025;
  const zoomZ=Math.max(0,Math.min(1,(c.curDist-6)/5)),pitch=(40+20*zoomZ)*Math.PI/180,horiz=Math.cos(pitch)*c.curDist,camY=Math.sin(pitch)*c.curDist; /* cámara del original: pitch 40–60° y FOV 30–45° acoplados al zoom (0,5 → 50°, 8,5, 37,5°) */
  if(Math.abs(T3.camera.fov-(30+15*zoomZ))>0.01){T3.camera.fov=30+15*zoomZ;T3.camera.updateProjectionMatrix();}
  let shx=0,shy=0;
  if(FX.shake>0.4&&!REDUCED_MOTION){shx=(Math.random()-0.5)*FX.shake*0.03;shy=(Math.random()-0.5)*FX.shake*0.03;}
  T3.camera.position.set(c.curPanX+Math.sin(c.curYaw+sway)*horiz+shx,camY+shy,c.curPanZ+Math.cos(c.curYaw+sway)*horiz);
  T3.camera.lookAt(c.curPanX,0.2,c.curPanZ);
  /* baliza, polvo y torreta central */
  if(T3.beacon)T3.beacon.material.opacity=REDUCED_MOTION?0.16:(0.13+0.06*Math.sin(t/520));
  if(T3.extMats)T3.extMats.forEach(m=>{m.opacity=REDUCED_MOTION?0.2:(0.16+0.07*Math.sin(t/520));});
  if(T3.droneMesh&&G.drone){
    const d=G.drone,m=T3.droneMesh,rx=d.dx!=null?d.dx:d.x,ry=d.dy!=null?d.dy:d.y;
    m.position.x=w2cx(rx);m.position.z=w2cx(ry);
    m.rotation.y=-advanceUnitYaw(d,t);
    if(d.alive){
      m.position.y=0.42+tileWorldY(rx,ry)+(REDUCED_MOTION?0:Math.sin(t/480)*0.03);m.rotation.z=0;
      if(!REDUCED_MOTION)m.userData.rotors.forEach((r,i)=>{r.rotation.y=t/55+i*1.3;});
      if(m.userData.light)m.userData.light.material.opacity=0.5+0.5*Math.abs(Math.sin(t/330));
    } else {m.position.y=0.12;m.rotation.z=0.55;}
  }
  if(T3.domRings)T3.domRings.forEach(dr=>{const dc=domControl(dr.zone);dr.ring.material.color.set(dc==='A'?TEAM_A_HEX:dc==='B'?TEAM_B_HEX:0xf4f1e6);});
  if(T3.dust&&!REDUCED_MOTION){T3.dust.rotation.y=t/60000;T3.dust.position.y=Math.sin(t/1400)*0.08;}
  if(T3.cannon){
    let ang=G.map.turret.owner==='B'?Math.PI:0;
    const foes=G.units.filter(e=>e.alive&&e.team!==G.map.turret.owner);
    if(G.map.turret.owner&&foes.length){foes.sort((a,b)=>cheb(TURRET_POS,a)-cheb(TURRET_POS,b));ang=Math.atan2(foes[0].y-TURRET_POS.y,foes[0].x-TURRET_POS.x);}
    else if(!G.map.turret.owner&&!REDUCED_MOTION)ang=Math.sin(t/1500)*1.1;
    if(T3._cannonYaw==null||REDUCED_MOTION)T3._cannonYaw=ang;
    else T3._cannonYaw+=shortestArc(ang-T3._cannonYaw)*0.16;
    T3.cannon.rotation.y=-T3._cannonYaw;
  }
  if(T3.obMeshes)T3.obMeshes.forEach(r=>{r.mesh.visible=G.map.obstacles.indexOf(r.o)>=0;});
  if(T3.barrelMeshes)T3.barrelMeshes.forEach(r=>{r.mesh.visible=!!r.b.alive;});
  if(T3.medkitMeshes)T3.medkitMeshes.forEach(r=>{r.mesh.visible=!r.m.used;});
  const dynSig=(G.lootBoxes||[]).map(b=>b.x+','+b.y+','+b.kind).join('|')+'#'+G.deployed.map(d=>d.x+','+d.y+','+d.team+','+d.alive).join('|')+'#'+(G.map.turret.owner||'-')+'#'+(G.smoke||[]).map(s=>s.x+','+s.y+','+s.left).join('|')+'#'+(G.mines||[]).map(m=>m.x+','+m.y+','+m.team).join('|')+'#'+G.units.filter(u=>u.stunned).map(u=>u.id).join(',');
  if(dynSig!==T3.dynSig){T3.dynSig=dynSig;rebuildDyn3();}
  if(T3.dynGroup)T3.dynGroup.children.forEach(ch=>{if(ch.userData.loot&&!REDUCED_MOTION){ch.position.y=0.05+Math.sin(t/480+ch.position.x*2.1)*0.05;ch.rotation.y=t/1400;}});
  const sel=G.selected;
  const hlSig=[sel?sel.id:'-',sel?sel.energy:0,G.actionMode,G.turn,G.round,G.aiBusy?1:0,G.units.map(u=>u.x+','+u.y+','+(u.alive?1:0)+','+(u.invisible?1:0)).join(';'),(G.smoke||[]).length,G.drone?(G.drone.x+','+G.drone.y+','+G.drone.hp):''].join('#');
  if(hlSig!==T3.hlSig){T3.hlSig=hlSig;rebuildHighlights3();}
  if(T3.hoverRing){
    if(hoverTile){T3.hoverRing.visible=true;T3.hoverRing.position.x=w2cx(hoverTile.x);T3.hoverRing.position.z=w2cx(hoverTile.y);}
    else T3.hoverRing.visible=false;
  }
  updateHover3D(w,h);
  tickFx3D(w,h);
  updateUnitHuds3D(w,h);
  G.units.forEach(un=>{
    const mesh=T3.units.get(un.id);if(!mesh)return;
    const rx=un.dx!=null?un.dx:un.x, ry=un.dy!=null?un.dy:un.y;
    mesh.position.x=w2cx(rx);mesh.position.z=w2cx(ry);
    if(mesh.userData.hpArc){const f=Math.max(0,Math.min(1,un.hp/un.maxHp));mesh.userData.hpArc.geometry.setDrawRange(0,Math.floor(64*6*f));mesh.userData.hpArc.visible=un.alive;}
    const ud=mesh.userData;
    const moving=Math.abs(un.x-rx)>0.03||Math.abs(un.y-ry)>0.03||!!un._drawPath;
    if(ud.glbActor){
      updateGlbActor(ud.glbActor,dt);
      const state=moving?'walk':(un.firing?'fire':'idle');
      if(ud.glbState!==state){crossFadeTo(ud.glbActor,state,0.18,true);ud.glbState=state;}
    }
    mesh.position.y=0.05+tileWorldY(rx,ry)+(moving&&!REDUCED_MOTION?Math.abs(Math.sin((ud._gaitPhase||0)*Math.PI*2+un.id))*0.045:0);
    const yaw=advanceUnitYaw(un,t);
    mesh.rotation.y=-yaw;
    const turnLean=(un._turning&&!REDUCED_MOTION)?Math.sin((un._turnProg||0)*Math.PI)*0.07*(un._turnDelta>=0?1:-1):0;
    mesh.rotation.z=turnLean;
    if(un._turning&&!REDUCED_MOTION)mesh.position.y+=Math.sin((un._turnProg||0)*Math.PI)*0.025;
    if(ud.baseChev)ud.baseChev.visible=!!un.alive;
    if(ud.real&&!ud.glbActor){if(CLIPLIB.ready)driveClipSoldier(un,mesh,t,moving);else driveRealSoldier(un,mesh,t,moving||!!un._turning);fitLiveGun3(un,mesh);}
    else if(un.alive){
      mesh.rotation.z=turnLean;
      ud.body.position.y=REDUCED_MOTION?0:Math.sin(t/430+un.id*1.93)*0.02;
      ud.body.rotation.z=0;
      mesh.traverse(o=>{if(o.material&&o.material.transparent)o.opacity=un.invisible?0.45:1;});
      const ratio=un.maxHp?un.hp/un.maxHp:1;
      const col=ratio>0.5?'#69d66f':ratio>0.25?'#f2b234':'#ff6b5e';
      ud.segs.forEach((s,i)=>{s.visible=i<un.energy;s.material.color.set(col);});
      ud.selRing.visible=(G.selected===un);
      if(ud.selRing.visible&&!REDUCED_MOTION)ud.selRing.rotation.z=t/900;
    } else {
      ud.body.rotation.z=1.35;ud.body.position.y=-0.32;
      ud.segs.forEach(s=>{s.visible=false;});
      ud.selRing.visible=false;
    }
  });
  /* En WebGL por software (SwiftShader), limitar a ~28 fps evita saturar CPU */
  if(!T3.isSw||t-T3.lastRender>=34||T3.fxItems.length>0||FX.shake>0.4){
    T3.lastRender=t;
    T3.renderer.render(T3.scene,T3.camera);
  }
  try{const _s=skState(G.map.theme);window.__csn3d={theme:G.map.theme,geo:!!(_s&&_s.ready),units:T3.units?T3.units.size:0,tris:T3.renderer.info.render.triangles,calls:T3.renderer.info.render.calls,sw:T3.isSw,frame:((window.__csn3d&&window.__csn3d.frame)||0)+1,ev:CLIP_EVENT_LOG.length,evLast:CLIP_EVENT_LOG[CLIP_EVENT_LOG.length-1]||null,exp:T3.renderer.toneMappingExposure,rim:!!T3.rim,arc:arcadeFxStats()};}catch(e){}
}
