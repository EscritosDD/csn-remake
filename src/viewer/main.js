import { ensureCardStage, activeCard, resizeStage, renderStage, snapshotStage, computeAccurateBounds, setCardModelBuilder, setCardStageCallbacks, setCardRestPose, setStageBaseDistance, setStageZoom, stageZoom, mountStageInto, unmountStage, scanCardBoxes, isCardStageRendering } from './card-stage.js';
import { loadGlbActor, updateGlbActor, playOnce, disposeGlbActor } from '../render3d/actor-glb.js';
import { setGlbLabActor } from '../ui/glb-lab.js';
import { renderTroopCards } from './troop-cards.js';
import { openInspector } from './inspector.js';
import { originalWeaponProfile, WEAPONS_ORIGINAL, weaponFileForRef, positionGunFlash } from '../render3d/assets-weapons.js';
import { DEPLOYABLES } from '../data/deployables.js';
import { auWeaponFile, auVoice } from '../core-and-audio.js';
(function(){ const stage=document.getElementById('viewerCanvas'); if(!stage||typeof THREE==='undefined')return;
  const status=document.getElementById('viewerStatus'); const zoomControl=document.getElementById('viewerZoom'); const texturePreview=document.getElementById('viewerTexture');
  const viewer={ renderer:null,scene:null,camera:null,spin:null,platform:null,meshyFill:null,meshyRim:null, baseDistance:3,drag:null,dragVel:0,lastFrame:0,selection:0,
    kind:'roles',name:'',skinIndex:0,weapon:'',weaponChar:'',weaponTouched:false,idleActor:null,gripActor:null,idleClipKey:'idle2h',testFire:null,
    frameRequested:false,models:{roles:{},weapons:{},props:{}},textures:{},bodyGeo:{},bodyRig:{},cardModel:null,cardMode:false,inspectorOpen:false,inspectorAutoSpin:false }; try{window.__csnViewer={get state(){return viewer;},getRoster:()=>viewerCharacters,getWeaponFiles:()=>viewerWeaponFiles,getEntry:key=>viewerCharacters.find(item=>item.key===key)||null,activate:spec=>activateSpec(activeCard().box||document.querySelector('#inspectorStage'),spec),fire:null,unmount:()=>unmountStage(),getCardBox:()=>activeCard().box};}catch(e){}
  const cardStage=ensureCardStage(stage);
  if(cardStage){viewer.renderer=cardStage.renderer;viewer.scene=cardStage.scene;viewer.camera=cardStage.camera;viewer.spin=cardStage.spin;viewer.platform=cardStage.platform;viewer.meshyFill=cardStage.meshyFill;viewer.meshyRim=cardStage.meshyRim;}
  const VIEWER_BODY_SKINS={ 'Soldier_SAS':['Soldier_SAS_d.png','Soldier_SAS_Decon_d.png','Soldier_SAS_Veteran_d.png'],
    'Soldier_Spud':['Soldier_d.png','Soldier_Decon_d.png','Soldier_ForestCamo_d.png','Soldier_Veteran_d.png'],
    'Soldier_Light':['Soldier_Light_d.png','Soldier_Light_Decon_d.png','Soldier_Light_DeltaForce_d.png','Soldier_Light_Halloween_d.png','Soldier_Light_Spetsnaz_d.png','Soldier_Light_Veteran_d.png'],
    'Soldier_Light_Rambo':['Soldier_Light_Rambo_d.png','Soldier_Light_Rambo_Decon_d.png','Soldier_Light_Rambo_DeerHunter_d.png','Soldier_Light_Rambo_Veteran_d.png'],
    'Soldier_Heavy':['Soldier_heavy_d.png','Soldier_heavy_GermanSpecialForces_d.png','Soldier_Heavy_Decon_d.png','Soldier_Heavy_Veteran_d.png'],
    'Agent_Light':['Agent_light_d.png','Agent_light_Decon_d.png','Agent_light_JewelThief_d.png','Agent_light_Veteran_d.png'],
    'Agent_Heavy':['Agent_Heavy_d.png','Agent_Heavy_Decon_d.png','Agent_Heavy_Skin1_d.png','Agent_Heavy_Veteran_d.png'],
    'Medic':['Medic_d.png','Medic_Decon_d.png','Medic_Halloween_d.png','Medic_Rescue_d.png','Medic_Spetsnaz_d.png','Medic_Veteran_d.png'],
    'Medic_therapist':['Medic_Therapist_d.png','Medic_Therapist_Decon_d.png','Medic_Therapist_Surgeon_d.png','Medic_Therapist_Veteran_d.png'],
    'Engineer':['Engineer_d.png','Engineer_Decon_d.png','Engineer_Halloween_d.png','Engineer_Spetsnaz_d.png','Engineer_Veteran_d.png'],
    'Engineer_Light':['Engineer_Light_d.png','Engineer_Light_Decon_d.png','Engineer_Light_Trinity_d.png','Engineer_Light_Veteran_d.png'],
    'Engineer_Heavy':['Engineer_Heavy2_d.png','Engineer_Heavy_Decon_d.png','Engineer_Heavy_EOD_d.png','Engineer_Heavy_Veteran_d.png'],
    'Engineer (RiotCop)':['Engineer_RiotCop_d.png','Engineer_RiotCop_Decon_d.png','Engineer_RiotCop_Skin1_d.png','Engineer_RiotCop_Veteran_d.png'],
    'Commander':['Commander_d.png','Commander_African_d.png','Commander_Asian_d.png','Commander_Latino_d.png'],
    'CommanderM':['Commander_d.png','Commander_African_d.png','Commander_Asian_d.png','Commander_Latino_d.png'],
    'Commander_F':['Commander_F_d.png','Commander_F_African_d.png','Commander_F_Asian_d.png','Commander_F_Latino_d.png'] }; const VIEWER_ROLE_FALLBACK={
    'Riot Medic':'Médico','Megan McNick':'Ingeniero','Carlito Grosso':'Ingeniero', 'Riot Engineer':'Ingeniero','Commander (F)':'Capitán' }; const VIEWER_CAST_TEXTURE=CAST_TEXTURE_FILE;
  const VIEWER_BODY_FILE={ 'Soldier_SAS':'Soldier_SAS.obj', 'Soldier_Spud':'Soldier_Spud.obj', 'Soldier_Heavy':'Soldier_Heavy.obj', 'Soldier_Light_Rambo':'Soldier_Light_Rambo.obj',
    'Agent_Light':'Agent_Light.obj', 'Medic_therapist':'Medic_therapist_1248v.obj', 'Engineer_Light':'Engineer_Light.obj', 'Engineer_Heavy':'Engineer_Heavy.obj',
    'Engineer (RiotCop)':'Engineer_RiotCop.obj', 'CommanderM':'CommanderM.obj', 'Commander_F':'CommanderF.obj' };
  const VIEWER_BODY_OVERRIDE={'Archie Fletcher':'Soldier_Light_Rambo','Commander (M)':'CommanderM'};
  const VIEWER_BODY_ROLE={'Medic':'Médico','Engineer':'Ingeniero','Agent_Heavy':'Comando','Commander':'Capitán'};
  const VIEWER_MESHY_FRONT={Francotirador:1,Espia:1,Artillero:-1,Medico:1,Ingeniero:1};
  const viewerCharacters=[ ...ORIG_CAST.map((character,index)=>{ const role=character.role||VIEWER_ROLE_FALLBACK[character.name]||'';
      const body=VIEWER_BODY_OVERRIDE[character.name]||character.body; const bodyFile=VIEWER_BODY_FILE[body]||''; const bodyRole=VIEWER_BODY_ROLE[body]||''; return {
        key:'original:'+String(index+1).padStart(2,'0'), label:character.name,name:character.name,role,bio:character.bio||'', defaultWeapon:character.defaultWeapon||'', body,bodyFile,bodyRole,
        rigPose:!!character.rigPose||!!bodyRole||(!bodyFile&&!bodyRole),
        canGrip:!!character.rigPose||!!bodyRole||!!bodyFile||(!bodyFile&&!bodyRole),
        outfit:VIEWER_CAST_TEXTURE[character.name]||'', file:bodyFile||(bodyRole?ROLE_MODEL_FILES[bodyRole]+'.obj':'soldier.obj') }; }),
    ...MESHY_CAST.map(c=>({...c,key:c.key,label:c.label,name:c.name,role:c.role,mesh:c.mesh,bio:c.bio})) ]; viewerCharacters.forEach(entry=>{
    if(entry.mesh){entry.skins=[{key:'own',label:'Textura Meshy'}];return;}; const variants=VIEWER_BODY_SKINS[entry.body]||[]; const ordered=entry.outfit
      ?[entry.outfit,...variants.filter(file=>file!==entry.outfit)] :variants; entry.skins=ordered.map((file,index)=>({
      key:'cast:'+file,label:'Skin '+String(index+1).padStart(2,'0')+' · '+file })); });   const viewerWeaponFiles=[
    'AssaultRifle','Rifle','Pistol','SniperRifle_weapon','Shotgun','RPG','Crossbow', 'SledgeHammer','Uzi','Revolver','RiotShotgun','M95','LightMachineGun','Molotov',
    'Knife','Katana','WoodAxe','MP5K','Chainsaw','Minigun','BaseballBat_SOURCE', 'SpikedClub_weapon','FragGrenade' ]; const viewerPropFiles=DEPLOYABLES; function abilityCardHTML(ability){
    const obj=ability.obj?ABILITY_OBJECTS[ability.obj]:null; const objLine=obj ?'<br><span class="sub">Objeto: '+obj.name+'. '+(obj.model
        ?'<button type="button" data-viewer-prop="'+obj.model+'" style="text-decoration:underline;cursor:pointer">Ver en 3D</button> · '+obj.note :obj.note)+'</span>' :'';
    return '<div class="ab-card on" style="display:flex;gap:8px;align-items:center;text-align:left"><img src="assets/ui/ability/'+ability.icon+'.png" alt="" style="width:34px;height:34px;flex:none"/><span><b>'+ability.n+'</b><br><small>'+ability.d+objLine+'</small></span></div>';
  }; function renderViewerAbilities(entry){ const box=document.getElementById('viewerAbilities'); if(!box)return;
    if(entry&&entry.mesh){box.innerHTML='<p class="sub" style="margin:0">Diseño propio de Dani: sin habilidades del original.</p>';return;}
    if(!entry||!entry.name){box.innerHTML='';return;}; const list=CHARACTER_ABILITIES[entry.name]; if(list===undefined){box.innerHTML='';return;}; if(!list.length){
      box.innerHTML='<p class="sub" style="margin:0"><b>Habilidades:</b> el Capitán tenía una selección aparte de habilidades de comandante; las concretas no están en el material legible del original.</p>';
      return; }; box.innerHTML='<p class="sub" style="margin:0 0 6px"><b>Habilidades del original:</b></p>'+list.map(abilityCardHTML).join('');
    box.querySelectorAll('[data-viewer-prop]').forEach(button=>{ button.onclick=()=>{if(window.openDeployable3D)window.openDeployable3D(button.dataset.viewerProp);}; }); };   const idleForWeapon=w=>{const file=weaponFileForRef(w)||w;const profile=file&&originalWeaponProfile(file);return profile?profile.idleClip:'idle2h';}; const wait=ms=>new Promise(resolve=>setTimeout(resolve,ms)); function setStatus(message,visible){

    status.textContent=message; status.style.display=visible?'grid':'none'; };   function ensureRenderer(){ if(viewer.renderer)return true; setStatus('No se pudo iniciar el visor WebGL.',true); return false; };   function updateCamera(){
    const zoom=+(zoomControl&&zoomControl.value||stageZoom()||1); viewer.camera.position.set(0,viewer.baseDistance*0.22,viewer.baseDistance/zoom); viewer.camera.lookAt(0,0,0); }; function resize(){
    if(!viewer.renderer)return; const target=activeCard().box||stage; resizeStage(target); viewer.camera.aspect=viewer.renderer.domElement.width/Math.max(1,viewer.renderer.domElement.height);
    viewer.camera.updateProjectionMatrix(); };   function frame(now){
    const visible=document.getElementById('scr-viewer').classList.contains('on')||viewer.inspectorOpen;
    const liveBox=activeCard().box;
    const mounted=!!(liveBox&&viewer.renderer&&viewer.renderer.domElement.parentNode===liveBox);
    if(!visible||!mounted||isCardStageRendering()||(viewer.inspectorOpen&&(!liveBox||liveBox.id!=='inspectorStage'))){
      viewer.lastFrame=now;
      requestAnimationFrame(frame);
      return;
    }
    if(viewer.renderer){
      const dt=viewer.lastFrame?Math.min(0.05,(now-viewer.lastFrame)/1000):0.016;
      if(viewer.glbActor)updateGlbActor(viewer.glbActor,dt);
      const clips=CLIPLIB.ready&&CLIPLIB.pack&&CLIPLIB.pack.clips;
      let clipKey=viewer.idleClipKey,clip=clips&&clips[clipKey],ct=(now/1000)%(clip&&clip.dur||1),signature=clipKey+'|'+(viewer.weapon||'');
      if(viewer.testFire&&clips&&clips[viewer.testFire.key]){const elapsed=(now-viewer.testFire.start)/1000,fire=clips[viewer.testFire.key];
        if(elapsed<fire.dur){clip=fire;clipKey=viewer.testFire.key;ct=elapsed;signature=clipKey+'|fire|'+(viewer.weapon||'');}else viewer.testFire=null;}
      if(viewer.idleActor&&viewer.idleActor.userData&&viewer.idleActor.userData._firePulse>0)viewer.idleActor.userData._firePulse=Math.max(0,viewer.idleActor.userData._firePulse-dt*5.5);
      if(viewer.idleActor&&clip&&!viewer.glbActor){ if(!poseViewerClip(viewer.idleActor,clip,ct,clipKey,signature,now,dt*1000))poseSpriteClip(null,viewer.idleActor,clip,ct,clipKey); }
      if(viewer.testFire&&viewer.idleActor&&!viewer.glbActor)dispatchViewerFire(viewer.idleActor,clip,clipKey,ct,viewer.weapon);
      if(viewer.gripActor&&viewer.gripActor.userData.gun)fitGunToHand3(viewer.gripActor.userData.gripUnit,viewer.gripActor,false);
      const testGun=viewer.gripActor&&viewer.gripActor.userData.gun,testFlash=testGun&&testGun.userData.flash;
      if(testFlash&&testGun.userData._testFlash>0){const k=testGun.userData._testFlash=Math.max(0,testGun.userData._testFlash-dt*16),sharp=k<0.45?k/0.45:1;
        testFlash.traverse(o=>{if(o.isMesh&&o.material)o.material.opacity=sharp;else if(o.isPointLight)o.intensity=k*1.4;});testFlash.scale.setScalar(0.65+0.35*k);}
      if(!viewer.drag&&viewer.spin&&viewer.spin.children.length){
        if(Math.abs(viewer.dragVel)>1e-4){ viewer.spin.rotation.y+=viewer.dragVel*dt; viewer.dragVel*=Math.exp(-dt/0.25); }
        else { viewer.dragVel=0; if(!viewer.inspectorOpen||viewer.inspectorAutoSpin)viewer.spin.rotation.y+=dt*0.22; }
      } renderStage(); refreshTexturePreview();
    }
    viewer.lastFrame=now;
    requestAnimationFrame(frame);
  }
  function refreshTexturePreview(){ let texture=null; if(viewer.spin)viewer.spin.traverse(object=>{ if(!texture&&object.material){
        const mats=Array.isArray(object.material)?object.material:[object.material]; const mat=mats.find(item=>item.map&&item.map.image); if(mat)texture=mat.map; } });
    const image=texture&&texture.image; const src=image&&(image.currentSrc||image.src); if(src&&texturePreview.src!==src){texturePreview.src=src;texturePreview.hidden=false;} }
  function mount(model){
    const glbActor=model&&model.userData?model.userData.glbActor:null;
    if(viewer.glbActor&&viewer.glbActor!==glbActor)disposeGlbActor(viewer.glbActor);
    viewer.glbActor=glbActor||null;setGlbLabActor(viewer.glbActor);
    if(model.parent)model.parent.remove(model); model.position.set(0,0,0); while(viewer.spin.children.length)viewer.spin.remove(viewer.spin.children[0]);
    if(!glbActor&&model.userData&&!model.userData.meshy&&CLIPLIB.ready)
      poseViewerRest(model,model.userData.idleClipKey||'idle2h',0);
    model.updateMatrixWorld(true);
    model.traverse(object=>{ if(object.isSkinnedMesh&&object.skeleton)object.skeleton.update(); }); model.updateMatrixWorld(true); const bounds=computeAccurateBounds(model);
    const size=new THREE.Vector3(),center=new THREE.Vector3();
    bounds.getSize(size);bounds.getCenter(center);
    if(!Number.isFinite(size.x)||Math.max(size.x,size.y,size.z)<0.001)throw new Error('El modelo no contiene geometría visible.');
    const centerOffset=viewerCenterOffset(center); const centered=new THREE.Group(); centered.position.set(centerOffset.x,centerOffset.y,centerOffset.z); centered.add(model);
    viewer.spin.add(centered); centered.updateMatrixWorld(true); viewer.idleActor=!glbActor&&viewer.kind==='roles'&&model.userData.animatable?model:null;
    viewer.gripActor=viewer.kind==='roles'&&model.userData.grip?model:null; if(viewer.meshyFill)viewer.meshyFill.intensity=viewer.kind==='roles'&&model.userData.meshy?1.8:0;
    if(viewer.meshyRim)viewer.meshyRim.intensity=viewer.kind==='roles'&&model.userData.meshy?2.2:0; viewer.idleClipKey=model.userData.idleClipKey||(viewer.weapon?idleForWeapon(viewer.weapon):'idle2h');
    if(viewer.gripActor&&viewer.gripActor.userData.gun)
      fitGunToHand3(viewer.gripActor.userData.gripUnit,viewer.gripActor,false);
    viewer.spin.rotation.set(viewer.kind==='weapons'?0.25:0,-0.55,0); const platformRadius=Math.max(0.35,Math.max(size.x,size.z)*0.72);
    viewer.platform.scale.set(platformRadius,platformRadius,1); viewer.platform.position.y=bounds.min.y-center.y-0.02; resize();
    viewer.baseDistance=Math.min(6,fitViewerDistance(size,viewer.camera.fov,viewer.camera.aspect)); setStageBaseDistance(viewer.baseDistance); updateCamera(); renderStage(); refreshTexturePreview();
    setStatus('',false); }; function refreshList(){
    const list=document.getElementById('viewerList'); const controls=document.getElementById('viewerCharacterControls'); const characterSelect=document.getElementById('viewerCharacterSelect');
    if(controls)controls.style.display=viewer.kind==='roles'?'grid':'none'; if(list)list.style.display=viewer.kind==='roles'?'none':'flex';
    if(viewer.kind==='roles'){
      if(characterSelect){characterSelect.replaceChildren(); viewerCharacters.forEach(entry=>{const option=document.createElement('option');option.value=entry.key;option.textContent=entry.label;characterSelect.appendChild(option);});characterSelect.value=viewer.name;}
      const entry=viewerCharacters.find(item=>item.key===viewer.name)||viewerCharacters[0]; const skin=entry.skins[Math.min(viewer.skinIndex,entry.skins.length-1)];
      const skinName=document.getElementById('viewerSkinName');if(skinName)skinName.textContent=skin.label;
      const prev=document.getElementById('viewerSkinPrev'),next=document.getElementById('viewerSkinNext');if(prev)prev.disabled=entry.skins.length<2;if(next)next.disabled=entry.skins.length<2;
      const weaponSelect=document.getElementById('viewerWeaponSelect'); const weaponLabel=document.getElementById('viewerWeaponLabel');
      const sculpted=!!entry.sculptedWeapon,noGrip=!entry.canGrip;
      const validWeapon=w=>!!w&&(viewerWeaponFiles.includes(w)||!!WEAPONS_ORIGINAL[w]||!!WEAPONS_ORIGINAL[weaponFileForRef(w)||'']);
      if(viewer.weapon&&!viewerWeaponFiles.includes(viewer.weapon))viewer.weapon=weaponFileForRef(viewer.weapon)||viewer.weapon;
      if(!viewer.weaponTouched||viewer.weaponChar!==entry.key)viewer.weapon='';
      if(sculpted||noGrip||!validWeapon(viewer.weapon))viewer.weapon=''; viewer.weaponChar=entry.key;
      if(weaponSelect){weaponSelect.replaceChildren();const noneOption=document.createElement('option');noneOption.value='';noneOption.textContent=sculpted?'Sin acople (arma ya esculpida)':'Sin arma';weaponSelect.appendChild(noneOption);
        viewerWeaponFiles.forEach(weapon=>{const option=document.createElement('option');option.value=weapon;option.textContent=(WEAPONS_ORIGINAL[weapon]||{}).name||weapon;weaponSelect.appendChild(option);});weaponSelect.value=viewer.weapon||'';weaponSelect.disabled=sculpted||noGrip;}
      const fireBtn=document.getElementById('viewerFireBtn');if(fireBtn)fireBtn.disabled=sculpted||noGrip||!viewer.weapon;
      if(weaponLabel)weaponLabel.style.display=sculpted||noGrip?'none':'';
      const labelText=document.getElementById('viewerWeaponLabelText');if(labelText)labelText.textContent=sculpted?'Arma del diseño propio (No se acople otra arma)':'Arma';return;
    }
    const entries=viewer.kind==='props'?viewerPropFiles.map(prop=>({key:prop.key,label:prop.label,file:prop.file})):viewerWeaponFiles.map(file=>({key:file,label:(WEAPONS_ORIGINAL[file]||{}).name||file,file}));
    if(list){list.innerHTML='';entries.forEach(entry=>{const button=document.createElement('button');button.type='button';button.textContent=entry.label;button.classList.toggle('on',viewer.name===entry.key);button.onclick=()=>selectModel(viewer.kind,entry.key);list.appendChild(button);});}
  }; function showModelInfo(kind,key){
    const entry=kind==='roles'?viewerCharacters.find(item=>item.key===key):kind==='props'?viewerPropFiles.find(item=>item.key===key)
      :viewerWeaponFiles.includes(key)?{label:(WEAPONS_ORIGINAL[key]||{}).name||key,name:(WEAPONS_ORIGINAL[key]||{}).name||key,file:key,orig:WEAPONS_ORIGINAL[key]||null}:null;
    if(!entry)throw new Error('El modelo seleccionado no pertenece al catálogo del visor.');
    const nameEl=document.getElementById('viewerName'),descEl=document.getElementById('viewerDescription'),assetEl=document.getElementById('viewerAssetInfo');
    if(nameEl)nameEl.textContent=entry.name||entry.label;
    if(descEl)descEl.textContent=kind==='roles'?(entry.mesh?'Diseño Meshy independiente · '+entry.mesh+'.':'Rol: '+(entry.role||'—')+'. '+(entry.bio||''))
      :kind==='props'?(entry.note||'Objeto del original extraído de sus assetbundles.')
      :entry.orig?(entry.orig.cat+' · Roles: '+entry.orig.roles+' · '+entry.orig.dims[0]+' × '+entry.orig.dims[1]+' × '+entry.orig.dims[2]+(entry.orig.uses.length?(' · Usada por: '+entry.orig.uses.join(', ')):''))
      :'Malla y textura del arsenal · '+entry.file+'.obj';
    if(assetEl)assetEl.textContent=kind==='roles'?((entry.mesh?('Malla '+entry.mesh+'.obj · Textura Meshy.'):('Malla '+entry.file+' · '+(entry.outfit?('Textura '+entry.outfit):entry.skins[Math.min(viewer.skinIndex,entry.skins.length-1)].label)+'.'))
      +(viewer.weapon?(' Arma: '+viewer.weapon+'.'):'')):kind==='props'?('Malla '+entry.file+' · Textura '+entry.tex+'.')
      :entry.orig?('Malla '+entry.file+'.obj · Textura '+entry.orig.tex+'.png ('+entry.orig.texSize[0]+'×'+entry.orig.texSize[1]+') · '+entry.orig.verts+' vértices · '+(entry.orig.cover?('Carátula: '+entry.orig.cover+'.'):('Sin carátula en el original.'))):'';
    texturePreview.hidden=true;texturePreview.removeAttribute('src');renderViewerAbilities(kind==='roles'?entry:null);
    return {entry,skin:kind==='roles'?entry.skins[Math.min(viewer.skinIndex,entry.skins.length-1)]:null};
  }; async function loadViewerProp(entry){
    const path='assets/props/'+entry.file; if(viewer.bodyGeo[path])return viewer.bodyGeo[path];
    const text=await fetch(path).then(r=>{if(!r.ok)throw new Error('No se pudo cargar el objeto '+entry.file);return r.text();}); let count=0;
    for(const line of text.split('\n')){if(line.startsWith('v '))count++;}; const skin={skinIndex:new Array(count*4).fill(0),skinWeight:new Array(count*4).fill(0)};
    const geo=parseOBJ3(text,skin); geo.deleteAttribute('skinIndex'); geo.deleteAttribute('skinWeight'); geo.computeVertexNormals(); geo.computeBoundingBox();
    const size=new THREE.Vector3(); geo.boundingBox.getSize(size); const max=Math.max(size.x,size.y,size.z)||1; if(max!==1)geo.scale(1/max,1/max,1/max); viewer.bodyGeo[path]=geo;
    return geo; }; function normalizeMeshyRig(rig){return normalizeMeshyRigGlobal(rig);}; function parseViewerOBJ(text,rig){return parseMeshyOBJ(text,rig);}
  async function loadViewerMeshy(entry){ const base='assets/personajes_propios/'+entry.mesh; const [response,rigResponse,texture]=await Promise.all([
      fetch(base+'.obj'),fetch(base+'_rig.json'), new Promise((resolve,reject)=>{ new THREE.TextureLoader().load(base+'_tex.png',resolve,undefined,reject); }) ]);
    if(!response.ok)throw new Error('No se pudo cargar el OBJ Meshy de '+entry.mesh+'.'); if(!rigResponse.ok)throw new Error('No se pudo cargar el rig Meshy de '+entry.mesh+'.');
    texture.colorSpace=THREE.SRGBColorSpace; texture.generateMipmaps=false; texture.minFilter=THREE.LinearFilter; texture.magFilter=THREE.LinearFilter; texture.wrapS=THREE.ClampToEdgeWrapping; texture.wrapT=THREE.ClampToEdgeWrapping; texture.needsUpdate=true; const [objText,rawRig]=await Promise.all([response.text(),rigResponse.json()]); const rig=normalizeMeshyRig(rawRig);
    const geometry=parseViewerOBJ(objText,rig); const model=makeViewerRiggedModel(geometry,rig,texture,{ meshy:true,role:entry.role });
    if(rig.bones[1].pos[2]>rig.bones[1].pos[1]+0.1)model.rotation.x=-Math.PI/2; model.userData.gripUnit={role:entry.role,weapon:''}; return model; }
  function makeViewerRiggedModel(geometry,data,texture,options={}){return makeSkinnedModel(geometry,data,texture,options);}; function poseViewerRest(model,clipKey,ct){
    const pack=CLIPLIB.pack,clip=pack&&pack.clips&&pack.clips[clipKey]; const ud=model&&model.userData; if(ud&&ud.meshy)return false;
    if(!clip||!ud||!ud.bones||!ud.bindLocal)return false; const tq=new THREE.Quaternion(); const retarget=!!(ud.isClassRig&&ud.baseRestWorldQ&&ud.sourcePoseQ);
    const rootP=new THREE.Vector3(),rootT=new THREE.Vector3(),pelvis=new THREE.Vector3(); for(let n=0;n<24;n++){ for(let i=0;i<ud.bones.length;i++){
        const tr=clip.rot[pack.bones[i]]; const restQ=retarget?ud.baseRestQ[i]:ud.bindLocal[i]; if(tr)sampleClipQuat(tr,ct,tq);else tq.copy(restQ); if(retarget){
          ud.sourcePoseQ[i].copy(tq); }else{ ud.bones[i].quaternion.copy(tq); } }; if(retarget){
        retargetPoseToRig(ud.sourcePoseQ,ud.baseRestWorldQ,ud.bindWorldQ,ud.sourceParents,ud.parents,ud.sourceWorldQ,ud.targetWorldQ,ud.targetLocalQ);
        for(let i=0;i<ud.bones.length;i++)ud.bones[i].quaternion.copy(ud.targetLocalQ[i]); }; if(clip.root)sampleClipPos(clip.root,ct,rootT);else rootT.set(0,0,0);
      rootP.copy(ud.curDelta).lerp(rootT,0.45); pelvis.copy(ud.bindPos[1]);
      rootBonePositionForClip(ud.bindPos[0],pelvis,rootP,rootT.copy(pelvis).applyQuaternion(ud.bones[0].quaternion),ud.bones[0].position); }; ud._clipKey=clipKey;
    model.updateMatrixWorld(true); return true; };
  const _vpQ=[],_vpPrevQ=[],_vpTmpQ=new THREE.Quaternion(),_vpRootA=new THREE.Vector3(),_vpRootB=new THREE.Vector3(),_vpPelvis=new THREE.Vector3(),_vpRootOut=new THREE.Vector3();
  for(let i=0;i<24;i++){_vpQ.push(new THREE.Quaternion());_vpPrevQ.push(new THREE.Quaternion());}
  function sampleViewerPose(ud,clip,ct,outQ,outRoot){ const pack=CLIPLIB.pack; if(!pack)return false;
    const retarget=!!(ud.isClassRig&&ud.baseRestWorldQ&&ud.sourcePoseQ);
    if(clip&&clip.root)sampleClipPos(clip.root,ct,outRoot);else outRoot.set(0,0,0);
    for(let i=0;i<ud.bones.length;i++){ const tr=clip&&clip.rot[pack.bones[i]]; const restQ=retarget?ud.baseRestQ[i]:ud.bindLocal[i];
      if(tr)sampleClipQuat(tr,ct,_vpTmpQ);else _vpTmpQ.copy(restQ); if(retarget)ud.sourcePoseQ[i].copy(_vpTmpQ);else outQ[i].copy(_vpTmpQ); }
    if(retarget){ retargetPoseToRig(ud.sourcePoseQ,ud.baseRestWorldQ,ud.bindWorldQ,ud.sourceParents,ud.parents,ud.sourceWorldQ,ud.targetWorldQ,ud.targetLocalQ);
      for(let i=0;i<ud.bones.length;i++)outQ[i].copy(ud.targetLocalQ[i]); }; return true; }
  function poseViewerClip(model,clip,ct,key,signature,now,dtMs){ const ud=model&&model.userData; if(!clip||!ud||!ud.bones||!ud.curQ)return false;
    const sig=signature||key; if(ud._viewerPoseSig!==sig){ ud._viewerBlend=(ud._viewerPoseSig&&ud._viewerClip)?{clip:ud._viewerClip,ct:ud._viewerCt||0,t0:now}:null; ud._viewerPoseSig=sig; };
    ud._clipKey=key; ud._viewerClip=clip; ud._viewerCt=ct; let prevClip=null,prevCt=0,w=1;
    if(ud._viewerBlend){ const dur=typeof CLIP_BLEND_MS!=='undefined'?CLIP_BLEND_MS:200; const p=(now-ud._viewerBlend.t0)/dur;
      if(p>=1||!ud._viewerBlend.clip)ud._viewerBlend=null; else{ prevClip=ud._viewerBlend.clip; prevCt=ud._viewerBlend.ct+(now-ud._viewerBlend.t0)/1000;
        if(prevClip.loop)prevCt%=prevClip.dur||1;else prevCt=Math.min(prevCt,prevClip.dur||prevCt); w=typeof _smooth01==='function'?_smooth01(0,1,p):Math.max(0,Math.min(1,p)); } }
    if(!sampleViewerPose(ud,clip,ct,_vpQ,_vpRootA))return false;
    if(prevClip){ sampleViewerPose(ud,prevClip,prevCt,_vpPrevQ,_vpRootB); for(let i=0;i<ud.bones.length;i++){ _vpPrevQ[i].slerp(_vpQ[i],w); _vpQ[i].copy(_vpPrevQ[i]); }
      _vpRootB.lerp(_vpRootA,w); _vpRootA.copy(_vpRootB); };
    const reduced=typeof REDUCED_MOTION!=='undefined'&&REDUCED_MOTION; const step=Math.max(0,Math.min(100,dtMs||16.7)); const k=reduced?1:1-Math.pow(0.55,step/16.7);
    for(let i=0;i<ud.bones.length;i++){ ud.curQ[i].slerp(_vpQ[i],k); ud.bones[i].quaternion.copy(ud.curQ[i]); }
    ud.curDelta.lerp(_vpRootA,k); _vpPelvis.copy(ud.bindPos[1]);
    rootBonePositionForClip(ud.bindPos[0],_vpPelvis,ud.curDelta,_vpRootOut.copy(_vpPelvis).applyQuaternion(ud.bones[0].quaternion),ud.bones[0].position);
    model.updateMatrixWorld(true); return true; }
  function dispatchViewerFire(actor,clip,key,ct,weapon){ const ud=actor&&actor.userData; if(!ud||!clip||!clip.events||!clip.events.length)return;
    let st=ud._viewerFireEvents; if(!st||st.key!==key){st={key:key,seen:{},ct:ct,shots:0};ud._viewerFireEvents=st;}; if(ct<st.ct-0.08)st.seen={};
    const file=weaponFileForRef(weapon)||weapon,profile=originalWeaponProfile(file),canFire=!profile||profile.hasMuzzleFlash!==false;
    for(let i=0;i<clip.events.length;i++){ const e=clip.events[i],f=e.f||''; if(st.seen[i]||e.t>ct+0.0005)continue; st.seen[i]=1;
      if(f==='PlayFiring'||!(f==='PlayWeaponFire'||(f==='OnAnimEvent'&&Number(e.i)===10))||!canFire)continue;
      const now=performance.now(),throttle=/Mini/.test(file)?55:(/fireBurst|fire1hBurst|fireMini/.test((profile&&profile.fireClip)||key)?95:140);
      if(!ud._lastViewerSfx||now-ud._lastViewerSfx>throttle){if(typeof auWeaponFile==='function')auWeaponFile(file);else if(typeof auWeapon==='function')auWeapon(((typeof WEAPONS!=='undefined'&&WEAPONS[weapon])||{}).cat,weapon);ud._lastViewerSfx=now;}
      ud._firePulse=1;const gun=ud.gun,flash=gun&&gun.userData&&gun.userData.flash;st.shots++;
      if(flash&&gun.userData.hasMuzzleFlash!==false){const sign=st.shots%2?1:-1,s=0.78+Math.random()*0.34;
        flash.rotation.x=sign*(0.18+Math.random()*0.32);flash.rotation.z=Math.random()*Math.PI;flash.scale.set(s,s,s);
        flash.traverse(o=>{if(o.isMesh&&o.material)o.material.opacity=1;else if(o.isPointLight)o.intensity=1.4;});gun.userData._testFlash=1;}
    }
    st.ct=ct; };
  async function loadViewerBody(file){ const path='assets/soldier/bodies/'+file; if(viewer.bodyGeo[path])return viewer.bodyGeo[path];
    const rigPath=path.replace(/\.obj$/, '_rig.json'); const [response,rigResponse]=await Promise.all([fetch(path),fetch(rigPath)]);
    if(!response.ok)throw new Error('No se pudo cargar el cuerpo '+file); const text=await response.text(); let count=0;
    for(const line of text.split('\n')){if(line.startsWith('v '))count++;}; const rig=rigResponse.ok?await rigResponse.json():null;
    const hasRig=!!(rig&&rig.bones&&rig.skinIndex&&rig.skinIndex.length===count*4&&rig.skinWeight&&rig.skinWeight.length===count*4);
    const skin=hasRig?{skinIndex:rig.skinIndex,skinWeight:rig.skinWeight}:{skinIndex:new Array(count*4).fill(0),skinWeight:new Array(count*4).fill(0)};
    const geo=parseOBJ3(text,skin); const pos=geo.attributes.position.array; const zs=[]; for(let i=2;i<pos.length;i+=3)zs.push(pos[i]); zs.sort((a,b)=>a-b);
    const p95=zs[Math.floor(zs.length*0.95)]||1; const scale=1.14/p95; if(scale!==1)geo.scale(scale,scale,scale);
    viewer.bodyGeo[path]=geo; if(hasRig)viewer.bodyRig[path]=rig; return geo; }
  async function makeRiggedViewerActor(geometry,data,texture,entry){ const started=Date.now();
    while(!CLIPLIB.ready&&Date.now()-started<5000)await wait(50);
    const baseData=sameRigBoneOrder(REAL.data&&REAL.data.bones,data.bones)?REAL.data:null;
    const baseRestQ=baseData?baseData.bones.map(b=>new THREE.Quaternion(b.quat[0],b.quat[1],b.quat[2],b.quat[3])):null;
    const baseParents=baseData?baseData.bones.map(b=>b.parent):null;
    const model=makeViewerRiggedModel(geometry,data,texture,{animatable:true,baseRestQ,baseParents,grip:true,role:entry.role});
    model.scale.setScalar(1.15); const mesh=model.userData.mesh3; model.remove(mesh); const spin=new THREE.Group();
    spin.rotation.y=Math.PI/2; model.add(spin); const tilt=new THREE.Group(); tilt.rotation.x=-Math.PI/2; spin.add(tilt);
    mesh.scale.setScalar(0.95); tilt.add(mesh); poseViewerRest(model,idleForWeapon(viewer.weapon||''),0);
    model.userData.gripUnit={role:entry.role,weapon:viewer.weapon||''}; return model; }
  async function makeViewerOriginal(entry,skin){ let source=null,bodyGeo=null; if(entry.bodyFile){ bodyGeo=await loadViewerBody(entry.bodyFile); }else if(entry.bodyRole){

      source=REAL.byRole[entry.bodyRole]; if(!source)throw new Error('El modelo de clase '+entry.bodyRole+' todavía no está disponible.'); }else{ source=REAL; }; let texture=null;
    if(skin.key&&skin.key.indexOf('cast:')===0){ const texturePath='assets/soldier/cast/'+skin.key.slice(5); if(viewer.textures[texturePath])texture=viewer.textures[texturePath];
      else{ texture=await new Promise((resolve,reject)=>{ new THREE.TextureLoader().load(texturePath,resolve,undefined,reject); }); texture.colorSpace=THREE.SRGBColorSpace;
        viewer.textures[texturePath]=texture; } }else if(skin.key==='native'&&source){ texture=source.tex; }; if(!texture)throw new Error('El modelo no tiene una textura disponible.');
    if(!entry.bodyFile&&!entry.bodyRole){ const model=makeViewerRiggedModel(source.geo.clone(),source.data,texture,{animatable:true,grip:true}); model.scale.setScalar(1.15);
      const mesh=model.userData.mesh3; model.remove(mesh); const spin=new THREE.Group(); spin.rotation.y=Math.PI/2; model.add(spin); const tilt=new THREE.Group();
      tilt.rotation.x=-Math.PI/2; spin.add(tilt); mesh.scale.setScalar(0.95); tilt.add(mesh); return model; }; if(entry.rigPose&&source)return await makeRiggedViewerActor(source.geo.clone(),source.data,texture,entry);
    if(entry.bodyFile){ const rig=viewer.bodyRig['assets/soldier/bodies/'+entry.bodyFile]; if(rig&&bodyGeo)return await makeRiggedViewerActor(bodyGeo.clone(),rig,texture,entry); };
    const geometry=bodyGeo?bodyGeo.clone():(source?source.geo.clone():null); if(!geometry)throw new Error('El modelo no tiene una geometría disponible.');
    geometry.deleteAttribute('skinIndex'); geometry.deleteAttribute('skinWeight'); geometry.computeVertexNormals(); const mesh=new THREE.Mesh(geometry,new THREE.MeshStandardMaterial({
      map:texture,roughness:0.85,metalness:0.02,transparent:false,opacity:1,depthWrite:true, side:THREE.FrontSide })); mesh.castShadow=true; const model=new THREE.Group();
    model.scale.setScalar(1.15); const spin=new THREE.Group();spin.rotation.y=Math.PI/2;model.add(spin); const tilt=new THREE.Group();tilt.rotation.x=-Math.PI/2;spin.add(tilt);
    mesh.scale.setScalar(0.95);tilt.add(mesh); model.userData.staticRole=true; return model; };   async function syncViewerGun(model,entry,token){
    const rawWanted=(entry&&entry.sculptedWeapon)?'':(viewer.weapon||''); const wanted=rawWanted?(weaponFileForRef(rawWanted)||rawWanted):''; const current=(model.userData&&model.userData.viewerGunWeapon)||'';
    const idleKey=wanted?idleForWeapon(wanted):'idle2h';
    if(model&&model.userData){model.userData.idleClipKey=idleKey;if(viewer.idleClipKey!==idleKey){viewer.idleClipKey=idleKey;if(model.userData._viewerClip)model.userData._viewerBlend={clip:model.userData._viewerClip,ct:model.userData._viewerCt||0,t0:performance.now()};}if(!wanted)viewer.testFire=null;}
    if(current===wanted)return;
    if(model.userData&&model.userData.viewerGun){ model.remove(model.userData.viewerGun); if(model.userData.gun===model.userData.viewerGun)model.userData.gun=null;
      model.userData.viewerGun=null; model.userData.viewerGunWeapon=''; }; if(!wanted)return; const meshFile=weaponFileForRef(wanted); if(!meshFile)return;
    if(!GUN_MESH_CACHE[meshFile])makeRealGun3(meshFile); if(!GUN_MESH_CACHE[meshFile]){ const started=Date.now(); while(GUN_MESH_CACHE[meshFile]===null&&Date.now()-started<10000){
        if(token!==viewer.selection)return; await wait(100); }; if(!GUN_MESH_CACHE[meshFile])throw new Error('No se pudo cargar la malla de esta arma.'); }
    const sourceGun=GUN_MESH_CACHE[meshFile]; if(sourceGun.userData&&sourceGun.userData.texReady)await sourceGun.userData.texReady; if(token!==viewer.selection)return;
    if(model.userData&&model.userData._viewerClip)model.userData._viewerBlend={clip:model.userData._viewerClip,ct:model.userData._viewerCt||0,t0:performance.now()};
    if(!model.userData||!model.userData.grip)return; const holder=sourceGun.clone(true); holder.userData.texReady=sourceGun.userData.texReady; const gunMeta=holder.userData.meta||weaponMeta(meshFile);
    const gunGroup=makeGunAnchor({role:entry.role,weapon:wanted}); gunGroup.userData.isViewerGun=true; gunGroup.add(holder); positionGunFlash(gunGroup,holder,gunGroup.userData.cat);
    gunGroup.userData.file=meshFile; gunGroup.userData.meta=gunMeta; if(DEBUG_WEAPONS){
      const marker=new THREE.Mesh(new THREE.SphereGeometry(0.045,12,8),new THREE.MeshBasicMaterial({color:0xff3300,depthTest:false})); marker.userData.isViewerGun=true;
      gunGroup.add(marker); console.info('[debugWeapons]',meshFile,gunMeta&&gunMeta.attachmentJoint,holder.userData.calibration); }; model.add(gunGroup);
    model.userData.viewerGun=gunGroup; model.userData.viewerGunWeapon=wanted; if(model.userData.grip){ model.userData.gun=gunGroup;
      model.userData.gripUnit={role:entry.role,weapon:wanted}; fitGunToHand3(model.userData.gripUnit,model,false); } };   async function selectModel(kind,name){
    viewer.kind=kind;viewer.name=name;viewer.testFire=null;if(kind!=='roles')viewer.weapon='';viewer.idleClipKey=viewer.weapon?idleForWeapon(viewer.weapon):'idle2h'; const token=++viewer.selection; refreshList(); let selection;
    try{selection=showModelInfo(kind,name);}catch(error){setStatus(error.message,true);return;}
    if(!ensureRenderer())return; setStatus('Cargando modelo y textura…',true);
    try{
      const {entry,skin}=selection; const modelKey=kind==='roles'?name+'|'+skin.key:name; let model=viewer.models[kind][modelKey];
      if(!model&&kind==='roles'){
        if(entry.mesh){model=await loadViewerMeshy(entry);}
        else{const started=Date.now();
          while((!REAL.ready||(entry.role&&!(REAL.byRole&&REAL.byRole[entry.role])))&&Date.now()-started<10000){if(token!==viewer.selection)return;await wait(100);}
          if(!REAL.ready||(entry.role&&!(REAL.byRole&&REAL.byRole[entry.role])))throw new Error('El modelo original todavía no está disponible.');
          model=await makeViewerOriginal(entry,skin);}
        viewer.models.roles[modelKey]=model;
      }else if(!model&&kind==='props'){
        const geo=await loadViewerProp(entry); const texturePath='assets/props/'+entry.tex; let texture=viewer.textures[texturePath];
        if(!texture){texture=await new Promise((resolve,reject)=>{new THREE.TextureLoader().load(texturePath,resolve,undefined,reject);});texture.colorSpace=THREE.SRGBColorSpace;viewer.textures[texturePath]=texture;}
        const mesh=new THREE.Mesh(geo.clone(),new THREE.MeshStandardMaterial({map:texture,roughness:0.85,metalness:0.02,transparent:false,opacity:1,depthWrite:true,side:THREE.DoubleSide}));
        mesh.castShadow=true;model=new THREE.Group();model.scale.setScalar(1.15);const spin=new THREE.Group();spin.rotation.y=Math.PI/2;model.add(spin);
        const tilt=new THREE.Group();tilt.rotation.x=-Math.PI/2;spin.add(tilt);mesh.scale.setScalar(0.95);tilt.add(mesh);model.userData.staticRole=true;viewer.models.props[name]=model;
      }else if(!model){
        const meshFile=entry.file; if(!GUN_MESH_CACHE[meshFile])makeRealGun3(meshFile);
        if(!GUN_MESH_CACHE[meshFile]){const started=Date.now();while(GUN_MESH_CACHE[meshFile]===null&&Date.now()-started<10000){if(token!==viewer.selection)return;await wait(100);}
          if(!GUN_MESH_CACHE[meshFile])throw new Error('No se pudo cargar la malla de esta arma.');}
        const sourceGun=GUN_MESH_CACHE[meshFile];
        if(sourceGun.userData&&sourceGun.userData.texReady)await sourceGun.userData.texReady;
        if(token!==viewer.selection)return;
        model=sourceGun.clone(true);model.userData.texReady=sourceGun.userData.texReady;viewer.models.weapons[name]=model;
      } if(token!==viewer.selection)return;
      if(kind==='roles'){try{await syncViewerGun(model,entry,token);}catch(error){setStatus('No se pudo equipar el arma: '+error.message,true);}if(token!==viewer.selection)return;}
      viewer.cardModel=model; mount(model);
      const infoEl=document.getElementById('viewerAssetInfo'); if(infoEl)infoEl.textContent=kind==='roles'?(model.userData.meshy?'Malla OBJ y textura Meshy en pose del modelo · '+skin.label+'.':'Malla '+entry.file+' · '+skin.label+'.')
        :kind==='props'?('Malla '+entry.file+' · Textura '+entry.tex+'.'):'Malla y textura del arsenal · '+entry.file+'.obj';
      return model;
    }catch(error){if(token===viewer.selection)setStatus('No se pudo mostrar el modelo: '+error.message,true);return null;}
  }
  function clearStagePlaceholder(box){
    if(!box||box.id!=='inspectorStage')return;
    const empty=box.querySelector('.card-3d-empty');
    if(empty)empty.remove();
    const img=box.querySelector('.card-3d-thumb');
    if(img)img.classList.remove('is-hidden');
  }
  function showCsnPlaceholder(box,spec){
    clearStagePlaceholder(box);
    const empty=document.createElement('div');
    empty.className='card-3d-empty';
    const icon=document.createElement('span');icon.className='csn-ico';icon.textContent='◆';
    const title=document.createElement('b');title.textContent=spec.label||(spec.csn&&spec.csn.cat)||'Arma CSN';
    const note=document.createElement('span');note.textContent='Modelo 3D CSN pendiente';
    empty.append(icon,title,note);
    box.appendChild(empty);
    const img=box.querySelector('.card-3d-thumb');
    if(img)img.classList.add('is-hidden');
  }
  async function waitTextures(model){
    if(!model||typeof model.traverse!=='function')return false;
    const started=Date.now();
    while(Date.now()-started<8000){
      let ready=true,hasMap=false;
      model.traverse(object=>{
        if(!object.isMesh||!object.material)return;
        const mats=Array.isArray(object.material)?object.material:[object.material];
        for(const mat of mats){
          if(!mat.map)continue;
          hasMap=true;
          const image=mat.map.image;
          if(!image||image.complete===false)ready=false;
        }
      });
      if(hasMap&&ready)return true;
      await wait(60);
    }
    return false;
  }
  let cardBuild=null;
  async function buildCardModel(spec){
    if(!cardStage||!spec||!spec.kind)return null;
    if(cardBuild)await cardBuild.catch(()=>{});
    cardBuild=(async()=>{
      viewer.cardMode=true;
      if(spec.kind==='glb'){
        if(!spec.glbUrl)throw new Error('Falta la ruta .glb.');
        const actor=await loadGlbActor(spec.glbUrl,{height:1.08,rotationY:spec.rotationY||0});
        actor.root.userData.glbActor=actor;
        actor.root.userData.animatable=true;
        actor.root.userData.grip=true;
        actor.root.userData.idleClipKey='idle';
        actor.root.userData.glbOwned=true;
        viewer.cardModel=actor.root;
        return actor.root;
      }
      if(spec.kind==='roles'){
        const entry=viewerCharacters.find(item=>item.key===spec.key);
        if(entry&&!entry.mesh){
          const started=Date.now();
          while((!REAL.ready||!CLIPLIB.ready||(entry.role&&!(REAL.byRole&&REAL.byRole[entry.role])))&&Date.now()-started<15000){await wait(50);}
          if(!REAL.ready||!CLIPLIB.ready)throw new Error('Modelo original o clips todavía no disponibles.');
        }
        viewer.skinIndex=spec.skinIndex||0;viewer.weapon=spec.weapon||'';viewer.weaponTouched=true;viewer.weaponChar=spec.key;await selectModel('roles',spec.key);
      }
      else await selectModel(spec.kind,spec.key);
      if(!viewer.cardModel||!await waitTextures(viewer.cardModel))return null;
      return viewer.cardModel;
    })();
    try{return await cardBuild;}catch(error){if(typeof console!=='undefined'&&console.warn)console.warn('[cardStage:build]',error.message||error);return null;}finally{cardBuild=null;}
  }
  async function activateSpec(box,spec){
    if(!box||!spec||!spec.kind||!cardStage)return;
    if(spec.csn){unmountStage();showCsnPlaceholder(box,spec);if(viewer.inspectorOpen&&!viewer.frameRequested){viewer.frameRequested=true;requestAnimationFrame(frame);}return;}
    clearStagePlaceholder(box);
    const model=await buildCardModel(spec);
    if(!model)return;
    mountStageInto(box,spec);
    setStageZoom(stageZoom(),false);
    if(viewer.inspectorOpen&&!viewer.frameRequested){viewer.frameRequested=true;requestAnimationFrame(frame);}
  }
  function entryFor(spec){return viewerCharacters.find(item=>item.key===spec.key)||null;}
  async function fireSpec(spec){
    if(!spec)return;
    if(spec.kind==='glb'){if(viewer.glbActor)playOnce(viewer.glbActor,'fire');return;}
    if(spec.kind!=='roles')return;
    const entry=entryFor(spec); if(!entry||entry.mesh)return;
    const weapon=spec.weapon||viewer.weapon; if(!weapon)return;
    const file=weaponFileForRef(weapon)||weapon,profile=originalWeaponProfile(file)||{};
    let key=profile.fireClip;if(!key||!CLIPLIB.ready||!CLIPLIB.pack||!CLIPLIB.pack.clips||!CLIPLIB.pack.clips[key])key=typeof fireClipFor==='function'?fireClipFor(weapon):(idleForWeapon(weapon)==='idle1h'?'fire1h':'fire2h');
    if(!CLIPLIB.ready||!CLIPLIB.pack||!CLIPLIB.pack.clips||!CLIPLIB.pack.clips[key])return;
    const same=viewer.cardMode&&!viewer.glbActor&&viewer.name===spec.key&&viewer.weapon===weapon&&viewer.idleActor;
    if(!same){viewer.weapon=weapon;viewer.weaponTouched=true;await activateSpec(activeCard().box||document.querySelector('.card-3d-box[data-card-spec]'),spec);}
    viewer.weapon=weapon;viewer.idleClipKey=idleForWeapon(weapon);
    const actor=viewer.idleActor||viewer.gripActor;if(actor&&actor.userData){actor.userData._viewerFireEvents=null;actor.userData._lastViewerSfx=0;}
    viewer.testFire={key:key,start:performance.now()};auVoice({name:entry.name,role:entry.role},'firing',0.55);
  }
  const cardEngine={scan:()=>scanCardBoxes(),activate:activateSpec,fire:fireSpec,activateFirst:()=>{
    const box=document.querySelector('#troopGrid .card-3d-box[data-card-spec]');
    if(box){try{return activateSpec(box,JSON.parse(box.dataset.cardSpec));}catch(error){return null;}}
    return null;
  }};
  try{window.__csnCardEngine=cardEngine;window.__csnViewer.fire=fireSpec;}catch(error){}
  setCardModelBuilder(buildCardModel);
  setCardRestPose(model=>{
    if(!model||model.userData&&model.userData.meshy)return;
    poseViewerRest(model,model.userData&&model.userData.idleClipKey||'idle2h',0);
    model.traverse(object=>{if(object.isSkinnedMesh&&object.skeleton)object.skeleton.update();});
  });
  setCardStageCallbacks({onActivate:activateSpec,onInspect:(box,spec)=>openInspector(spec),onZoom:value=>{if(zoomControl)zoomControl.value=String(value);}});
  function activate(){
    refreshList();resize();const kindButton=document.querySelector('#viewerKinds button.on');viewer.kind=kindButton?kindButton.dataset.kind:'roles';
    const names=viewer.kind==='roles'?viewerCharacters.map(entry=>entry.key):viewer.kind==='props'?viewerPropFiles.map(entry=>entry.key):viewerWeaponFiles;
    if(!names.includes(viewer.name)||viewer.cardMode)viewer.name=names[0];
    selectModel(viewer.kind,viewer.name);
    if(!viewer.frameRequested){viewer.frameRequested=true;requestAnimationFrame(frame);}
    cardEngine.scan();
  }
  const characterSelect=document.getElementById('viewerCharacterSelect');if(characterSelect)characterSelect.onchange=event=>{viewer.skinIndex=0;viewer.weaponTouched=false;selectModel('roles',event.target.value);};
  const weaponSelect=document.getElementById('viewerWeaponSelect');if(weaponSelect)weaponSelect.onchange=event=>{viewer.weapon=event.target.value||'';viewer.weaponTouched=true;selectModel('roles',viewer.name);};
  const fireTestBtn=document.getElementById('viewerFireBtn');if(fireTestBtn)fireTestBtn.onclick=()=>{
    const weapon=viewer.weapon;if(!weapon||viewer.kind!=='roles'||!viewer.idleActor)return;
    const file=weaponFileForRef(weapon)||weapon;const profile=originalWeaponProfile(file)||{};
    let key=profile.fireClip;if(!key||!CLIPLIB.ready||!CLIPLIB.pack||!CLIPLIB.pack.clips||!CLIPLIB.pack.clips[key])key=typeof fireClipFor==='function'?fireClipFor(weapon):(idleForWeapon(weapon)==='idle1h'?'fire1h':'fire2h');
    if(CLIPLIB.ready&&CLIPLIB.pack&&CLIPLIB.pack.clips&&CLIPLIB.pack.clips[key]){const ud=viewer.idleActor.userData;
      ud._viewerFireEvents=null;ud._lastViewerSfx=0;ud._firePulse=1;viewer.idleClipKey=idleForWeapon(weapon);viewer.testFire={key:key,start:performance.now()};
      const entry=viewerCharacters.find(item=>item.key===viewer.name);if(entry)auVoice({name:entry.name,role:entry.role},'firing',0.55);}
  };
  const stepSkin=delta=>{const entry=viewerCharacters.find(item=>item.key===viewer.name);if(!entry||entry.skins.length<2)return;
    viewer.skinIndex=(viewer.skinIndex+delta+entry.skins.length)%entry.skins.length;selectModel('roles',entry.key);};
  const skinPrev=document.getElementById('viewerSkinPrev'),skinNext=document.getElementById('viewerSkinNext');if(skinPrev)skinPrev.onclick=()=>stepSkin(-1);if(skinNext)skinNext.onclick=()=>stepSkin(1);
  document.querySelectorAll('#viewerKinds button').forEach(button=>{button.onclick=()=>{
    document.querySelectorAll('#viewerKinds button').forEach(item=>item.classList.toggle('on',item===button));viewer.kind=button.dataset.kind;viewer.skinIndex=0;
    const names=viewer.kind==='roles'?viewerCharacters.map(entry=>entry.key):viewer.kind==='props'?viewerPropFiles.map(entry=>entry.key):viewerWeaponFiles;
    selectModel(viewer.kind,names[0]);};});
  if(zoomControl)zoomControl.oninput=()=>{setStageZoom(+zoomControl.value,false);updateCamera();};
  stage.addEventListener('wheel',event=>{event.preventDefault();setStageZoom(stageZoom()+(event.deltaY<0?0.1:-0.1));},{passive:false});
  stage.addEventListener('pointerdown',event=>{viewer.drag={x:event.clientX,y:event.clientY,t:event.timeStamp};viewer.dragVel=0;try{stage.setPointerCapture(event.pointerId);}catch(error){}});
  stage.addEventListener('pointermove',event=>{if(!viewer.drag)return;const dx=event.clientX-viewer.drag.x,dy=event.clientY-viewer.drag.y;
    const dt=Math.max(0.008,Math.min(0.05,(event.timeStamp-viewer.drag.t)/1000));viewer.drag={x:event.clientX,y:event.clientY,t:event.timeStamp};viewer.spin.rotation.y+=dx*0.008;
    viewer.spin.rotation.x=Math.max(-0.65,Math.min(0.65,viewer.spin.rotation.x+dy*0.006));viewer.dragVel=Math.max(-3,Math.min(3,dx*0.008/dt));});
  const stopDrag=()=>{viewer.drag=null;snapshotStage();};stage.addEventListener('pointerup',stopDrag);stage.addEventListener('pointercancel',stopDrag);
  const menuButton=document.getElementById('mnuViewer');const tabButton=document.querySelector('#mainTabs [data-tab="viewer"]');[menuButton,tabButton].forEach(button=>{
    if(button)button.onclick=()=>{showScreen('scr-viewer');activate();};});
  window.addEventListener('resize',resize);
  renderTroopCards(viewerCharacters,viewerWeaponFiles);
  cardEngine.scan();
})();
