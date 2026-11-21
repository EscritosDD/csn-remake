import { MAP_PIECES } from '../data/map-pieces.js';

/* Mapas del original: dimensiones medidas en la geometria del IPA (unidades del original; 1 unidad = 1 casilla) y en el juego (escala del .bin). El tablero de CSN es 12x12; el suelo del mapa original es mayor (el juego lo escala). */


/* Piezas de mapa del original (281): cada una es un grupo del OBJ del mapa, con su nombre de GameObject, su archivo, su mapa y sus dimensiones en unidades del original. La textura es el atlas compartido T_Atlas_01_D (el original reparte la geometria entre dos atlas, mat 0/1, y el OBJ exportado no trae material por pieza; el atlas 0 cubre ~99% de los triangulos). */


/* ================= VISOR 3D DE GALERIA =================
   Consume los modelos, texturas y constructores que ya usa el juego. */
(function(){
  const stage=document.getElementById('viewerCanvas');
  if(!stage||typeof THREE==='undefined')return;
  const status=document.getElementById('viewerStatus');
  const zoomControl=document.getElementById('viewerZoom');
  const texturePreview=document.getElementById('viewerTexture');
  const viewer={
    renderer:null,scene:null,camera:null,spin:null,platform:null,meshyFill:null,meshyRim:null,
    baseDistance:3,drag:null,dragVel:0,lastFrame:0,selection:0,
    kind:'roles',name:'',skinIndex:0,weapon:'',idleActor:null,gripActor:null,idleClipKey:'idle2h',
    frameRequested:false,models:{roles:{},weapons:{},props:{},pieces:{}},textures:{},bodyGeo:{},pieceMap:'Skirmish_03'
  };
  try{window.__csnViewer={get state(){return viewer;}};}catch(e){}
  /* Skins por cuerpo: cada cuerpo tiene solo sus variantes de outfit
     (archivos *_d.png del original, en assets/soldier/cast/). Las 8
     skins genéricas de antes eran outfits de Soldier_Light y no casan
     con los demás cuerpos (UV incompatible: una textura va mapeada a
     un cuerpo concreto), así que ya no se usan. Dos cuerpos se
     comparten de verdad en el original (un solo .obj por cuerpo):
     Sneaky Pete y Mme La Hacque comparten Agent_Light, y Sister
     Florence y Textbook Kate comparten Medic; se distinguen por su
     textura principal. Archie Fletcher usa el cuerpo Rambo
     (Soldier_Light_Rambo.obj, de su bundle ArchieFletcherOutfits),
     una malla distinta de la de Hipster Dave (Soldier_Light.obj). */
  const VIEWER_BODY_SKINS={
    'Soldier_SAS':['Soldier_SAS_d.png','Soldier_SAS_Decon_d.png','Soldier_SAS_Veteran_d.png'],
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
    'Commander_F':['Commander_F_d.png','Commander_F_African_d.png','Commander_F_Asian_d.png','Commander_F_Latino_d.png']
  };
  /* Personajes del original (ORIG_CAST, los 17, incluidos Soap y Spud).
     Soap usa Soldier_SAS.obj y Spud usa Soldier_Spud.obj, extraídos de sus
     propios bundles; antes se filtraban por parecerse al soldado genérico.
     Cada personaje muestra la malla de su cuerpo (body) y su textura
     propia (outfit, en assets/soldier/cast/); el rol solo se usa para
     mostrarlo y como respaldo cuando el cuerpo no trae rol. Los 3
     diseños Meshy de Dani se mantienen como entradas propias. */
  const VIEWER_ROLE_FALLBACK={
    'Riot Medic':'Médico','Megan McNick':'Ingeniero','Carlito Grosso':'Ingeniero',
    'Riot Engineer':'Ingeniero','Commander (F)':'Capitán'
  };
  const VIEWER_CAST_TEXTURE=CAST_TEXTURE_FILE;
  /* Cuerpo -> .obj en assets/soldier/bodies/ (solo los cuerpos que no
     son una clase del repo). Los demás cuerpos usan REAL.byRole o el
     soldado genérico (REAL), según VIEWER_BODY_ROLE. */
  const VIEWER_BODY_FILE={
    'Soldier_SAS':'Soldier_SAS.obj',
    'Soldier_Spud':'Soldier_Spud.obj',
    'Soldier_Heavy':'Soldier_Heavy.obj',
    'Soldier_Light_Rambo':'Soldier_Light_Rambo.obj',
    'Agent_Light':'Agent_Light.obj',
    'Medic_therapist':'Medic_therapist_1248v.obj',
    'Engineer_Light':'Engineer_Light.obj',
    'Engineer_Heavy':'Engineer_Heavy.obj',
    'Engineer (RiotCop)':'Engineer_RiotCop.obj',
    'CommanderM':'CommanderM.obj',
    'Commander_F':'CommanderF.obj'
  };
  /* Archie Fletcher y Commander (M) tienen cuerpo propio en sus bundles
     (Soldier_Light_Rambo y Commander), distinto del cuerpo genérico. */
  const VIEWER_BODY_OVERRIDE={'Archie Fletcher':'Soldier_Light_Rambo','Commander (M)':'CommanderM'};
  const VIEWER_BODY_ROLE={'Medic':'Médico','Engineer':'Ingeniero','Agent_Heavy':'Comando','Commander':'Capitán'};
  /* Armas por rol: las del propio juego (ROLES[rol].weapons, las que ofrece
     el setup de partida). Cada rol solo puede equipar las suyas: las de
     francotirador no las lleva cualquiera. Se listan los nombres CSN; la
     malla sale de WEAPON_MESH_FILE. Los personajes sin rol no tienen armas. */
  const VIEWER_ROLE_WEAPONS={};
  if(typeof ROLES!=='undefined'&&typeof WEAPON_MESH_FILE!=='undefined'){
    Object.keys(ROLES).forEach(role=>{
      VIEWER_ROLE_WEAPONS[role]=(ROLES[role].weapons||[]).filter(w=>WEAPON_MESH_FILE[w]);
    });
  }
  /* Frente de los diseños Meshy (medido en su OBJ: la cara mira a +Z salvo
     el Artillero, que mira a -Z). El arma debe apuntar hacia el frente del
     modelo, no siempre a +X como en los del IPA. */
  const VIEWER_MESHY_FRONT={Francotirador:1,Espia:1,Artillero:-1,Medico:1,Ingeniero:1};
  const viewerCharacters=[
    ...ORIG_CAST.map((character,index)=>{
      const role=character.role||VIEWER_ROLE_FALLBACK[character.name]||'';
      const body=VIEWER_BODY_OVERRIDE[character.name]||character.body;
      const bodyFile=VIEWER_BODY_FILE[body]||'';
      const bodyRole=VIEWER_BODY_ROLE[body]||'';
      return {
        key:'original:'+String(index+1).padStart(2,'0'),
        label:character.name,name:character.name,role,bio:character.bio||'',
        body,bodyFile,bodyRole,
        outfit:VIEWER_CAST_TEXTURE[character.name]||'',
        file:bodyFile||(bodyRole?ROLE_MODEL_FILES[bodyRole]+'.obj':'soldier.obj')
      };
    }),
    ...MESHY_CAST.map(c=>({...c,key:c.key,label:c.label,name:c.name,role:c.role,mesh:c.mesh,bio:c.bio}))
  ];
  viewerCharacters.forEach(entry=>{
    if(entry.mesh){entry.skins=[{key:'own',label:'Textura Meshy'}];return;}
    const variants=VIEWER_BODY_SKINS[entry.body]||[];
    const ordered=entry.outfit
      ?[entry.outfit,...variants.filter(file=>file!==entry.outfit)]
      :variants;
    entry.skins=ordered.map((file,index)=>({
      key:'cast:'+file,label:'Skin '+String(index+1).padStart(2,'0')+' · '+file
    }));
  });
  const viewerWeaponFiles=[
    'AssaultRifle','Rifle','Pistol','SniperRifle_weapon','Shotgun','RPG','Crossbow',
    'SledgeHammer','Uzi','Revolver','RiotShotgun','M95','LightMachineGun','Molotov',
    'Knife','Katana','WoodAxe','MP5K','Chainsaw','Minigun','BaseballBat_SOURCE',
    'SpikedClub_weapon','FragGrenade'
  ];
  /* Objetos del original con modelo y textura extraídos. Las mallas de
     habilidades viven en BasicAbilities/Abilities/Abilities02 y se exportan
     a assets/props/ con X espejada y winding invertido, igual que pipeline.py. */
  const viewerPropFiles=[
    {key:'CommCrate_124tri',label:'Caja de botín',file:'CommCrate_124tri.obj',tex:'TreasureCrate_d.png',note:'Caja de comandante / botín del original.'},
    {key:'CommCrate_180tri',label:'Caja de botín (variante)',file:'CommCrate_180tri.obj',tex:'TreasureCrate_d.png',note:'Variante de 180 triángulos de la caja.'},
    {key:'UAV',label:'UAV',file:'UAV.obj',tex:'UAV_d.png',note:'Dron explorador del original.'},
    {key:'GatlingTurret',label:'Torreta Gatling',file:'GatlingTurret.obj',tex:'MGTurret_d.png',note:'Torreta Gatling del original.'},
    {key:'RocketTurret',label:'Torreta de cohetes',file:'RocketTurret.obj',tex:'RocketTurret_d.png',note:'Torreta de cohetes del original.'},
    {key:'SpiderMine',label:'Mina',file:'SpiderMine.obj',tex:'SpiderMine_d.png',note:'Mina desplegable del original.'},
    {key:'RemoteCharge',label:'Carga remota',file:'RemoteCharge.obj',tex:'RemoteCharge_d.png',note:'Carga remota del original.'},
    {key:'DeployableCover',label:'Cobertura desplegable',file:'DeployableCover.obj',tex:'DeployableCover_d.png',note:'Cobertura desplegable del original.'},
    {key:'ObjectiveRocket',label:'Cohete objetivo',file:'ObjectiveRocket.obj',tex:'Rocket_d.png',note:'Cohete objetivo del mapa.'},
    {key:'RiotShieldBot',label:'Shield-O-Bot',file:'RiotShieldBot.obj',tex:'RiotShieldBot_d.png',note:'Robot escudo del original.'}
  ];
  /* Ficha de habilidades de un personaje: icono, nombre y descripción;
     si la habilidad usa un dron u objeto, ofrece ver su malla extraída. */
  function abilityCardHTML(ability){
    const obj=ability.obj?ABILITY_OBJECTS[ability.obj]:null;
    const objLine=obj
      ?'<br><span class="sub">Objeto: '+obj.name+'. '+(obj.model
        ?'<button type="button" data-viewer-prop="'+obj.model+'" style="text-decoration:underline;cursor:pointer">Ver en 3D</button> · '+obj.note
        :obj.note)+'</span>'
      :'';
    return '<div class="ab-card on" style="display:flex;gap:8px;align-items:center;text-align:left"><img src="assets/ui/ability/'+ability.icon+'.png" alt="" style="width:34px;height:34px;flex:none"/><span><b>'+ability.n+'</b><br><small>'+ability.d+objLine+'</small></span></div>';
  }
  function renderViewerAbilities(entry){
    const box=document.getElementById('viewerAbilities');
    if(!box)return;
    if(entry&&entry.mesh){box.innerHTML='<p class="sub" style="margin:0">Diseño propio de Dani: sin habilidades del original.</p>';return;}
    if(!entry||!entry.name){box.innerHTML='';return;}
    const list=CHARACTER_ABILITIES[entry.name];
    if(list===undefined){box.innerHTML='';return;}
    if(!list.length){
      box.innerHTML='<p class="sub" style="margin:0"><b>Habilidades:</b> el Capitán tenía una selección aparte de habilidades de comandante; las concretas no están en el material legible del original.</p>';
      return;
    }
    box.innerHTML='<p class="sub" style="margin:0 0 6px"><b>Habilidades del original:</b></p>'+list.map(abilityCardHTML).join('');
    box.querySelectorAll('[data-viewer-prop]').forEach(button=>{
      button.onclick=()=>{
        document.querySelectorAll('#viewerKinds button').forEach(item=>item.classList.toggle('on',item.dataset.kind==='props'));
        viewer.kind='props';viewer.skinIndex=0;
        selectModel('props',button.dataset.viewerProp);
      };
    });
  }
  const wait=ms=>new Promise(resolve=>setTimeout(resolve,ms));
  function setStatus(message,visible){
    status.textContent=message;
    status.style.display=visible?'grid':'none';
  }
  function ensureRenderer(){
    if(viewer.renderer)return true;
    try{
      viewer.renderer=new THREE.WebGLRenderer({antialias:true,alpha:true});
      viewer.renderer.setPixelRatio(Math.min(window.devicePixelRatio||1,2));
      viewer.renderer.setClearColor(0x11150f,0);
      stage.insertBefore(viewer.renderer.domElement,status);
      viewer.scene=new THREE.Scene();
      viewer.scene.add(new THREE.HemisphereLight(0xe7f0d9,0x30372b,2));
      const key=new THREE.DirectionalLight(0xffedc2,2.4);key.position.set(3,5,4);viewer.scene.add(key);
      const fill=new THREE.DirectionalLight(0x9bb8d1,1.1);fill.position.set(-4,2,-3);viewer.scene.add(fill);
      viewer.meshyFill=new THREE.DirectionalLight(0xd7ebff,1.8);viewer.meshyFill.position.set(-3,2,5);viewer.meshyFill.intensity=0;viewer.scene.add(viewer.meshyFill);
      viewer.meshyRim=new THREE.DirectionalLight(0xffd9a8,2.2);viewer.meshyRim.position.set(3,4,-4);viewer.meshyRim.intensity=0;viewer.scene.add(viewer.meshyRim);
      viewer.camera=new THREE.PerspectiveCamera(36,1,0.01,80);
      viewer.spin=new THREE.Group();viewer.scene.add(viewer.spin);
      viewer.platform=new THREE.Mesh(
        new THREE.CircleGeometry(1,48),
        new THREE.MeshStandardMaterial({color:0x30382a,roughness:0.9,metalness:0})
      );
      viewer.platform.rotation.x=-Math.PI/2;
      viewer.scene.add(viewer.platform);
      return true;
    }catch(error){
      setStatus('No se pudo iniciar el visor WebGL: '+error.message,true);
      return false;
    }
  }
  function updateCamera(){
    const zoom=+(zoomControl.value||1);
    viewer.camera.position.set(0,viewer.baseDistance*0.22,viewer.baseDistance/zoom);
    viewer.camera.lookAt(0,0,0);
  }
  function resize(){
    if(!viewer.renderer||!document.getElementById('scr-viewer').classList.contains('on'))return;
    const width=Math.max(1,stage.clientWidth),height=Math.max(1,stage.clientHeight);
    viewer.renderer.setSize(width,height,false);
    viewer.camera.aspect=width/height;
    viewer.camera.updateProjectionMatrix();
  }
  function frame(now){
    if(!document.getElementById('scr-viewer').classList.contains('on')){
      viewer.frameRequested=false;
      return;
    }
    if(viewer.renderer){
      const idle=CLIPLIB.ready&&CLIPLIB.pack&&CLIPLIB.pack.clips[viewer.idleClipKey];
      if(viewer.idleActor&&idle)poseSpriteClip(null,viewer.idleActor,idle,(now/1000)%idle.dur,viewer.idleClipKey);
      if(viewer.gripActor&&viewer.gripActor.userData.gun)
        fitGunToHand3(viewer.gripActor.userData.gripUnit,viewer.gripActor,false);
      const dt=viewer.lastFrame?Math.min(0.05,(now-viewer.lastFrame)/1000):0.016;
      if(!viewer.drag&&viewer.spin&&viewer.spin.children.length){
        viewer.spin.rotation.y+=dt*0.22;
        if(Math.abs(viewer.dragVel)>1e-4){
          viewer.spin.rotation.y+=viewer.dragVel*dt;
          viewer.dragVel*=Math.exp(-dt/0.25);
        }else viewer.dragVel=0;
      }
      viewer.renderer.render(viewer.scene,viewer.camera);
      refreshTexturePreview();
    }
    viewer.lastFrame=now;
    requestAnimationFrame(frame);
  }
  function refreshTexturePreview(){
    let texture=null;
    if(viewer.spin)viewer.spin.traverse(object=>{
      if(!texture&&object.material){
        const mats=Array.isArray(object.material)?object.material:[object.material];
        const mat=mats.find(item=>item.map&&item.map.image);
        if(mat)texture=mat.map;
      }
    });
    const image=texture&&texture.image;
    const src=image&&(image.currentSrc||image.src);
    if(src&&texturePreview.src!==src){texturePreview.src=src;texturePreview.hidden=false;}
  }
  function mount(model){
    if(model.parent)model.parent.remove(model);
    model.position.set(0,0,0);
    while(viewer.spin.children.length)viewer.spin.remove(viewer.spin.children[0]);
    if(model.userData&&model.userData.bones&&model.userData.bindLocal&&CLIPLIB.ready)
      poseViewerRest(model,model.userData.idleClipKey||'idle2h',0);
    model.updateMatrixWorld(true);
    model.traverse(object=>{
      if(object.isSkinnedMesh&&object.skeleton)object.skeleton.update();
    });
    model.updateMatrixWorld(true);
    const bounds=new THREE.Box3();
    const meshBounds=new THREE.Box3();
    model.traverse(object=>{
      if(!object.isMesh||!object.geometry)return;
      /* El arma equipada no entra en el encuadre: si contara, el cañón
         desplazaría el centro y el soldado quedaría descentrado. */
      let p=object.parent;
      while(p&&p!==model){if(p.userData&&p.userData.isViewerGun)return;p=p.parent;}
      if(object.isSkinnedMesh){
        if(object.computeBoundingBox)object.computeBoundingBox();
        if(object.boundingBox&&!object.boundingBox.isEmpty()){
          meshBounds.copy(object.boundingBox).applyMatrix4(object.matrixWorld);
        }else meshBounds.setFromObject(object,true);
      }else meshBounds.setFromObject(object,true);
      bounds.union(meshBounds);
    });
    const size=new THREE.Vector3(),center=new THREE.Vector3();
    bounds.getSize(size);bounds.getCenter(center);
    if(!Number.isFinite(size.x)||Math.max(size.x,size.y,size.z)<0.001)throw new Error('El modelo no contiene geometría visible.');
    const centerOffset=viewerCenterOffset(center);
    const centered=new THREE.Group();
    centered.position.set(centerOffset.x,centerOffset.y,centerOffset.z);
    centered.add(model);
    viewer.spin.add(centered);
    centered.updateMatrixWorld(true);
    viewer.idleActor=viewer.kind==='roles'&&model.userData.animatable?model:null;
    viewer.gripActor=viewer.kind==='roles'&&model.userData.grip?model:null;
    if(viewer.meshyFill)viewer.meshyFill.intensity=viewer.kind==='roles'&&model.userData.meshy?1.8:0;
    if(viewer.meshyRim)viewer.meshyRim.intensity=viewer.kind==='roles'&&model.userData.meshy?2.2:0;
    viewer.idleClipKey=model.userData.idleClipKey||'idle2h';
    if(viewer.gripActor&&viewer.gripActor.userData.gun)
      fitGunToHand3(viewer.gripActor.userData.gripUnit,viewer.gripActor,false);
    viewer.spin.rotation.set(viewer.kind==='weapons'?0.25:0,-0.55,0);
    const platformRadius=Math.max(0.35,Math.max(size.x,size.z)*0.72);
    viewer.platform.scale.set(platformRadius,platformRadius,1);
    viewer.platform.position.y=bounds.min.y-center.y-0.02;
    resize();
    viewer.baseDistance=fitViewerDistance(size,viewer.camera.fov,viewer.camera.aspect);
    updateCamera();
    viewer.renderer.render(viewer.scene,viewer.camera);
    refreshTexturePreview();
    setStatus('',false);
  }
  function refreshList(){
    const list=document.getElementById('viewerList');
    const controls=document.getElementById('viewerCharacterControls');
    const pieceControls=document.getElementById('viewerPieceControls');
    const characterSelect=document.getElementById('viewerCharacterSelect');
    controls.style.display=viewer.kind==='roles'?'grid':'none';
    pieceControls.style.display=viewer.kind==='pieces'?'grid':'none';
    list.style.display=viewer.kind==='roles'?'none':'flex';
    if(viewer.kind==='roles'){
      characterSelect.replaceChildren();
      viewerCharacters.forEach(entry=>{
        const option=document.createElement('option');
        option.value=entry.key;option.textContent=entry.label;
        characterSelect.appendChild(option);
      });
      characterSelect.value=viewer.name;
      const entry=viewerCharacters.find(item=>item.key===viewer.name)||viewerCharacters[0];
      const skin=entry.skins[Math.min(viewer.skinIndex,entry.skins.length-1)];
      document.getElementById('viewerSkinName').textContent=skin.label;
      document.getElementById('viewerSkinPrev').disabled=entry.skins.length<2;
      document.getElementById('viewerSkinNext').disabled=entry.skins.length<2;
      /* Selector de arma: solo las del rol del personaje. Sin rol o sin
         armas, se oculta (el personaje se ve sin arma, como hasta ahora). */
      const weaponSelect=document.getElementById('viewerWeaponSelect');
      const weaponLabel=document.getElementById('viewerWeaponLabel');
      const roleWeapons=(entry.role&&VIEWER_ROLE_WEAPONS[entry.role])||[];
      const sculpted=!!entry.sculptedWeapon;
      if(sculpted||(viewer.weapon&&!roleWeapons.includes(viewer.weapon)))viewer.weapon='';
      weaponSelect.replaceChildren();
      const noneOption=document.createElement('option');
      noneOption.value='';noneOption.textContent=sculpted?'Sin acople (arma ya esculpida)':'Sin arma';
      weaponSelect.appendChild(noneOption);
      roleWeapons.forEach(weapon=>{
        const option=document.createElement('option');
        option.value=weapon;option.textContent=weapon;
        weaponSelect.appendChild(option);
      });
      weaponSelect.value='';
      weaponSelect.disabled=sculpted;
      weaponLabel.style.display=roleWeapons.length||sculpted?'':'none';
      document.getElementById('viewerWeaponLabelText').textContent=sculpted?'Arma del diseño propio (No se acopla otra arma)':'Arma';
      return;
    }
    if(viewer.kind==='pieces'){
      const mapSelect=document.getElementById('viewerPieceMapSelect');
      if(!mapSelect.options.length){
        MAPS_ORIGINAL.forEach(map=>{
          const option=document.createElement('option');
          option.value=map.name;option.textContent=map.name+' ('+map.pieces+' piezas)';
          mapSelect.appendChild(option);
        });
      }
      mapSelect.value=viewer.pieceMap;
      const pieces=MAP_PIECES.filter(piece=>piece.m===viewer.pieceMap);
      document.getElementById('viewerPieceCount').textContent=pieces.length+' piezas · mapa '+viewer.pieceMap;
      list.innerHTML='';
      pieces.forEach((entry,index)=>{
        const button=document.createElement('button');
        const meshName=(entry.f||entry.k).split('/').pop();
        button.type='button';button.textContent=entry.l+' · '+String(index+1).padStart(2,'0');
        button.title=entry.f||entry.k;
        button.setAttribute('aria-label',entry.l+' ('+meshName+')');
        button.classList.toggle('on',viewer.name===entry.k);
        button.onclick=()=>selectModel('pieces',entry.k);
        list.appendChild(button);
      });
      return;
    }
    const entries=viewer.kind==='props'
      ?viewerPropFiles.map(prop=>({key:prop.key,label:prop.label,file:prop.file}))
      :viewerWeaponFiles.map(file=>({key:file,label:(WEAPONS_ORIGINAL[file]||{}).name||file,file}));
    list.innerHTML='';
    entries.forEach(entry=>{
      const button=document.createElement('button');
      button.type='button';button.textContent=entry.label;
      button.classList.toggle('on',viewer.name===entry.key);
      button.onclick=()=>selectModel(viewer.kind,entry.key);
      list.appendChild(button);
    });
  }
  function showModelInfo(kind,key){
    const entry=kind==='roles'
      ?viewerCharacters.find(item=>item.key===key)
      :kind==='props'
        ?viewerPropFiles.find(item=>item.key===key)
        :kind==='pieces'
          ?MAP_PIECES.find(item=>item.k===key)
          :viewerWeaponFiles.includes(key)?{label:(WEAPONS_ORIGINAL[key]||{}).name||key,name:(WEAPONS_ORIGINAL[key]||{}).name||key,file:key,orig:WEAPONS_ORIGINAL[key]||null}:null;
    if(!entry)throw new Error('El modelo seleccionado no pertenece al catálogo del visor.');
    document.getElementById('viewerName').textContent=entry.name||entry.label||entry.l;
    document.getElementById('viewerDescription').textContent=kind==='roles'
      ?(entry.mesh
        ?'Diseño Meshy independiente · '+entry.mesh+'.'
        :'Rol: '+(entry.role||'—')+'. '+(entry.bio||''))
      :kind==='props'
        ?(entry.note||'Objeto del original extraído de sus assetbundles.')
        :kind==='pieces'
          ?'Pieza de '+entry.m+' · '+entry.s[0]+' × '+entry.s[1]+' × '+entry.s[2]+' unidades (1 unidad = 1 casilla).'
          :entry.orig
            ?(entry.orig.cat+' · Roles: '+entry.orig.roles+' · '+entry.orig.dims[0]+' × '+entry.orig.dims[1]+' × '+entry.orig.dims[2]+(entry.orig.uses.length?(' · Usada por: '+entry.orig.uses.join(', ')):'' ))
            :'Malla y textura del arsenal · '+entry.file+'.obj';
    document.getElementById('viewerAssetInfo').textContent=kind==='roles'
      ?((entry.mesh
        ?('Malla '+entry.mesh+'.obj · Textura Meshy.')
        :('Malla '+entry.file+' · '+(entry.outfit?('Textura '+entry.outfit):entry.skins[Math.min(viewer.skinIndex,entry.skins.length-1)].label)+'.'))
        +(viewer.weapon?(' Arma: '+viewer.weapon+' ('+((WEAPONS_ORIGINAL[WEAPON_MESH_FILE[viewer.weapon]]||{}).name||WEAPON_MESH_FILE[viewer.weapon])+')'+(weaponMeta(WEAPON_MESH_FILE[viewer.weapon])?' · socket '+weaponMeta(WEAPON_MESH_FILE[viewer.weapon]).attachmentJoint:'')+'.'):''))
      :kind==='props'
        ?('Malla '+entry.file+' · Textura '+entry.tex+'.')
        :kind==='pieces'
          ?('Malla '+entry.f+' · Textura T_Atlas_01_D.png (atlas compartido).')
          :entry.orig
            ?('Malla '+entry.file+'.obj · Textura '+entry.orig.tex+'.png ('+entry.orig.texSize[0]+'×'+entry.orig.texSize[1]+') · '+entry.orig.verts+' vértices · '+(entry.orig.cover?('Carátula: '+entry.orig.cover+'.'):('Sin carátula en el original.')))
            :'';
    texturePreview.hidden=true;
    texturePreview.removeAttribute('src');
    renderViewerAbilities(kind==='roles'?entry:null);
    return {entry,skin:kind==='roles'?entry.skins[Math.min(viewer.skinIndex,entry.skins.length-1)]:null};
  }
  /* Carga un objeto (prop) del original: OBJ estático con su textura,
     misma rotación Z-arriba que las mallas de soldado. */
  async function loadViewerProp(entry){
    const path='assets/props/'+entry.file;
    if(viewer.bodyGeo[path])return viewer.bodyGeo[path];
    const text=await fetch(path).then(r=>{if(!r.ok)throw new Error('No se pudo cargar el objeto '+entry.file);return r.text();});
    let count=0;
    for(const line of text.split('\n')){if(line.startsWith('v '))count++;}
    const skin={skinIndex:new Array(count*4).fill(0),skinWeight:new Array(count*4).fill(0)};
    const geo=parseOBJ3(text,skin);
    geo.deleteAttribute('skinIndex');
    geo.deleteAttribute('skinWeight');
    geo.computeVertexNormals();
    geo.computeBoundingBox();
    const size=new THREE.Vector3();
    geo.boundingBox.getSize(size);
    const max=Math.max(size.x,size.y,size.z)||1;
    if(max!==1)geo.scale(1/max,1/max,1/max);
    viewer.bodyGeo[path]=geo;
    return geo;
  }
  /* Carga una pieza de mapa del original: OBJ estatico de
     assets/maps/pieces/ con el atlas compartido T_Atlas_01_D
     (assets/maps/textures/). Misma rotacion Z-arriba que las mallas
     de soldado y los props. La escala se normaliza a 1 (como los
     props) para encuadrarla; sus dimensiones reales van en la ficha. */
  async function loadViewerPiece(entry){
    const path='assets/maps/pieces/'+entry.f;
    if(viewer.bodyGeo[path])return viewer.bodyGeo[path];
    const text=await fetch(path).then(r=>{if(!r.ok)throw new Error('No se pudo cargar la pieza '+entry.f);return r.text();});
    let count=0;
    for(const line of text.split('\n')){if(line.startsWith('v '))count++;}
    const skin={skinIndex:new Array(count*4).fill(0),skinWeight:new Array(count*4).fill(0)};
    const geo=parseOBJ3(text,skin);
    geo.deleteAttribute('skinIndex');
    geo.deleteAttribute('skinWeight');
    geo.computeVertexNormals();
    geo.computeBoundingBox();
    const size=new THREE.Vector3();
    geo.boundingBox.getSize(size);
    const max=Math.max(size.x,size.y,size.z)||1;
    if(max!==1)geo.scale(1/max,1/max,1/max);
    viewer.bodyGeo[path]=geo;
    return geo;
  }
  function normalizeMeshyRig(rig){return normalizeMeshyRigGlobal(rig);}
  function parseViewerOBJ(text,rig){return parseMeshyOBJ(text,rig);}
  async function loadViewerMeshy(entry){
    const base='assets/personajes_propios/'+entry.mesh;
    const [response,rigResponse,texture]=await Promise.all([
      fetch(base+'.obj'),fetch(base+'_rig.json'),
      new Promise((resolve,reject)=>{
        /* Cada diseño Meshy es autocontenido en assets/personajes_propios/
           (obj + rig + tex): la textura ya no es la de clase en
           assets/soldier/, porque esas clases volvieron a ser del original. */
        new THREE.TextureLoader().load(base+'_tex.png',resolve,undefined,reject);
      })
    ]);
    if(!response.ok)throw new Error('No se pudo cargar el OBJ Meshy de '+entry.mesh+'.');
    if(!rigResponse.ok)throw new Error('No se pudo cargar el rig Meshy de '+entry.mesh+'.');
    texture.colorSpace=THREE.SRGBColorSpace;
    const [objText,rawRig]=await Promise.all([response.text(),rigResponse.json()]);
    const rig=normalizeMeshyRig(rawRig);
    const geometry=parseViewerOBJ(objText,rig);
    const model=makeViewerRiggedModel(geometry,rig,texture,{
      meshy:true,role:entry.role
    });
    if(rig.bones[1].pos[2]>rig.bones[1].pos[1]+0.1)model.rotation.x=-Math.PI/2;
    model.userData.gripUnit={role:entry.role,weapon:''};
    return model;
  }
  function makeViewerRiggedModel(geometry,data,texture,options={}){return makeSkinnedModel(geometry,data,texture,options);}
  function poseViewerRest(model,clipKey,ct){
    const pack=CLIPLIB.pack,clip=pack&&pack.clips&&pack.clips[clipKey];
    const ud=model&&model.userData;
    if(ud&&ud.meshy)return false;
    if(!clip||!ud||!ud.bones||!ud.bindLocal)return false;
    const tq=new THREE.Quaternion();
    const retarget=!!(ud.isClassRig&&ud.baseRestWorldQ&&ud.sourcePoseQ);
    const rootP=new THREE.Vector3(),rootT=new THREE.Vector3(),pelvis=new THREE.Vector3();
    for(let n=0;n<24;n++){
      for(let i=0;i<ud.bones.length;i++){
        const tr=clip.rot[pack.bones[i]];
        const restQ=retarget?ud.baseRestQ[i]:ud.bindLocal[i];
        if(tr)sampleClipQuat(tr,ct,tq);else tq.copy(restQ);
        if(retarget){
          ud.sourcePoseQ[i].copy(tq);
        }else{
          ud.bones[i].quaternion.copy(tq);
        }
      }
      if(retarget){
        retargetPoseToRig(ud.sourcePoseQ,ud.baseRestWorldQ,ud.bindWorldQ,ud.sourceParents,ud.parents,ud.sourceWorldQ,ud.targetWorldQ,ud.targetLocalQ);
        for(let i=0;i<ud.bones.length;i++)ud.bones[i].quaternion.copy(ud.targetLocalQ[i]);
      }
      if(clip.root)sampleClipPos(clip.root,ct,rootT);else rootT.set(0,0,0);
      rootP.copy(ud.curDelta).lerp(rootT,0.45);
      pelvis.copy(ud.bindPos[1]);
      rootBonePositionForClip(ud.bindPos[0],pelvis,rootP,rootT.copy(pelvis).applyQuaternion(ud.bones[0].quaternion),ud.bones[0].position);
    }
    ud._clipKey=clipKey;
    model.updateMatrixWorld(true);
    return true;
  }
  /* Carga un cuerpo de assets/soldier/bodies/ con el cargador del juego
     (parseOBJ3). Los .obj de bodies/ no traen rig, así que se parsean
     con un skin a cero: el visor los muestra como malla estática y
     borra skinIndex/skinWeight al clonar, igual que los roles. La
     altura se normaliza a la de los modelos de clase (~1.14) con el
     percentil 95 de Z, robusto a un accesorio alto: Agent_Light viene
     a 3.55 y sin normalizar se vería gigante. */
  async function loadViewerBody(file){
    const path='assets/soldier/bodies/'+file;
    if(viewer.bodyGeo[path])return viewer.bodyGeo[path];
    const text=await fetch(path).then(r=>{if(!r.ok)throw new Error('No se pudo cargar el cuerpo '+file);return r.text();});
    let count=0;
    for(const line of text.split('\n')){if(line.startsWith('v '))count++;}
    const skin={skinIndex:new Array(count*4).fill(0),skinWeight:new Array(count*4).fill(0)};
    const geo=parseOBJ3(text,skin);
    const pos=geo.attributes.position.array;
    const zs=[];
    for(let i=2;i<pos.length;i+=3)zs.push(pos[i]);
    zs.sort((a,b)=>a-b);
    const p95=zs[Math.floor(zs.length*0.95)]||1;
    const scale=1.14/p95;
    if(scale!==1)geo.scale(scale,scale,scale);
    viewer.bodyGeo[path]=geo;
    return geo;
  }
  async function makeViewerOriginal(entry,skin){
    /* La geometría la decide el cuerpo (entry.body), no el rol: cada
       personaje muestra la malla de su cuerpo. Los 4 roles IPA usan
       REAL.byRole; los cuerpos variantes se cargan de bodies/; el
       cuerpo Soldier_Light usa el soldado genérico (REAL). */
    let source=null,bodyGeo=null;
    if(entry.bodyFile){
      bodyGeo=await loadViewerBody(entry.bodyFile);
    }else if(entry.bodyRole){
      source=REAL.byRole[entry.bodyRole];
      if(!source)throw new Error('El modelo de clase '+entry.bodyRole+' todavía no está disponible.');
    }else{
      source=REAL;
    }
    let texture=null;
    if(skin.key&&skin.key.indexOf('cast:')===0){
      const texturePath='assets/soldier/cast/'+skin.key.slice(5);
      if(viewer.textures[texturePath])texture=viewer.textures[texturePath];
      else{
        texture=await new Promise((resolve,reject)=>{
          new THREE.TextureLoader().load(texturePath,resolve,undefined,reject);
        });
        texture.colorSpace=THREE.SRGBColorSpace;
        viewer.textures[texturePath]=texture;
      }
    }else if(skin.key==='native'&&source){
      texture=source.tex;
    }
    if(!texture)throw new Error('El modelo no tiene una textura disponible.');
    /* Solo el cuerpo Soldier_Light del repo (Hipster Dave, el soldado
       genérico) usa el modelo con esqueleto y pose de reposo animada.
       Sister Florence se monta también con esqueleto, pero con la pose
       de reposo retargetizada y sin animación, para que el arma se
       enganche a sus manos. El resto sigue siendo malla estática:
       forzar animatable en todos es lo que descabaló los modelos. */
    if(!entry.bodyFile&&!entry.bodyRole){
      const model=makeViewerRiggedModel(source.geo.clone(),source.data,texture,{animatable:true,grip:true});
      model.scale.setScalar(1.15);
      const mesh=model.userData.mesh3;
      model.remove(mesh);
      const spin=new THREE.Group();
      spin.rotation.y=Math.PI/2;
      model.add(spin);
      const tilt=new THREE.Group();
      tilt.rotation.x=-Math.PI/2;
      spin.add(tilt);
      mesh.scale.setScalar(0.95);
      tilt.add(mesh);
      return model;
    }
    if(entry.rigPose&&source){
      const started=Date.now();
      while(!CLIPLIB.ready&&Date.now()-started<5000)await wait(50);
      const baseData=sameRigBoneOrder(REAL.data&&REAL.data.bones,source.data.bones)?REAL.data:null;
      const baseRestQ=baseData?baseData.bones.map(b=>new THREE.Quaternion(b.quat[0],b.quat[1],b.quat[2],b.quat[3])):null;
      const baseParents=baseData?baseData.bones.map(b=>b.parent):null;
      const model=makeViewerRiggedModel(source.geo.clone(),source.data,texture,{
        baseRestQ,baseParents,grip:true,role:entry.role
      });
      model.scale.setScalar(1.15);
      const mesh=model.userData.mesh3;
      model.remove(mesh);
      const spin=new THREE.Group();
      spin.rotation.y=Math.PI/2;
      const lk=roleLook(entry.role);
      if(lk&&lk.s)spin.scale.set(lk.s[0],lk.s[1],lk.s[2]);
      model.add(spin);
      const tilt=new THREE.Group();
      tilt.rotation.x=-Math.PI/2;
      spin.add(tilt);
      mesh.scale.setScalar(0.95);
      tilt.add(mesh);
      poseViewerRest(model,'idle2h',0);
      model.userData.gripUnit={role:entry.role,weapon:''};
      return model;
    }
    const geometry=bodyGeo?bodyGeo.clone():(source?source.geo.clone():null);
    if(!geometry)throw new Error('El modelo no tiene una geometría disponible.');
    geometry.deleteAttribute('skinIndex');
    geometry.deleteAttribute('skinWeight');
    geometry.computeVertexNormals();
    const mesh=new THREE.Mesh(geometry,new THREE.MeshStandardMaterial({
      map:texture,roughness:0.85,metalness:0.02,transparent:false,opacity:1,depthWrite:true,
      side:THREE.FrontSide
    }));
    mesh.castShadow=true;
    const model=new THREE.Group();
    model.scale.setScalar(1.15);
    const spin=new THREE.Group();spin.rotation.y=Math.PI/2;model.add(spin);
    const tilt=new THREE.Group();tilt.rotation.x=-Math.PI/2;spin.add(tilt);
    mesh.scale.setScalar(0.95);tilt.add(mesh);
    model.userData.staticRole=true;
    return model;
  }
  async function syncViewerGun(model,entry,token){
    const wanted=(entry&&entry.sculptedWeapon)?'':(viewer.weapon||'');
    const current=(model.userData&&model.userData.viewerGunWeapon)||'';
    if(current===wanted)return;
    if(model.userData&&model.userData.viewerGun){
      model.remove(model.userData.viewerGun);
      if(model.userData.gun===model.userData.viewerGun)model.userData.gun=null;
      model.userData.viewerGun=null;
      model.userData.viewerGunWeapon='';
    }
    if(!wanted)return;
    const meshFile=weaponFileForRef(wanted);
    if(!meshFile)return;
    if(!GUN_MESH_CACHE[meshFile])makeRealGun3(meshFile);
    if(!GUN_MESH_CACHE[meshFile]){
      const started=Date.now();
      while(GUN_MESH_CACHE[meshFile]===null&&Date.now()-started<10000){
        if(token!==viewer.selection)return;
        await wait(100);
      }
      if(!GUN_MESH_CACHE[meshFile])throw new Error('No se pudo cargar la malla de esta arma.');
    }
    const holder=GUN_MESH_CACHE[meshFile].clone(true);
    const gunMeta=holder.userData.meta||weaponMeta(meshFile);
    let gunGroup;
    if(model.userData&&model.userData.grip){
      gunGroup=makeGunAnchor({role:entry.role,weapon:wanted});
      gunGroup.userData.isViewerGun=true;
      gunGroup.add(holder);
    }else{
      gunGroup=makeGunAnchor({role:entry.role,weapon:wanted});
      gunGroup.userData.isViewerGun=true;
      gunGroup.position.set(0.18,0.62,0);
      gunGroup.rotation.set(0,0,0);
      gunGroup.add(holder);
    }
    gunGroup.userData.file=meshFile;
    gunGroup.userData.meta=gunMeta;
    if(DEBUG_WEAPONS){
      const marker=new THREE.Mesh(new THREE.SphereGeometry(0.045,12,8),new THREE.MeshBasicMaterial({color:0xff3300,depthTest:false}));
      marker.userData.isViewerGun=true;
      gunGroup.add(marker);
      console.info('[debugWeapons]',meshFile,gunMeta&&gunMeta.attachmentJoint,holder.userData.calibration);
    }
    model.add(gunGroup);
    model.userData.viewerGun=gunGroup;
    model.userData.viewerGunWeapon=wanted;
    if(model.userData.grip){
      model.userData.gun=gunGroup;
      model.userData.gripUnit={role:entry.role,weapon:wanted};
      fitGunToHand3(model.userData.gripUnit,model,false);
    }
  }
  async function selectModel(kind,name){
    viewer.kind=kind;viewer.name=name;
    const token=++viewer.selection;
    refreshList();
    let selection;
    try{selection=showModelInfo(kind,name);}
    catch(error){setStatus(error.message,true);return;}
    if(!ensureRenderer())return;
    setStatus('Cargando modelo y textura…',true);
    try{
      const {entry,skin}=selection;
      const modelKey=kind==='roles'?name+'|'+skin.key:name;
      let model=viewer.models[kind][modelKey];
      if(!model&&kind==='roles'){
        if(entry.mesh){
          model=await loadViewerMeshy(entry);
        }else{
          const started=Date.now();
          while((!REAL.ready||(entry.role&&!(REAL.byRole&&REAL.byRole[entry.role])))&&Date.now()-started<10000){
            if(token!==viewer.selection)return;
            await wait(100);
          }
          if(!REAL.ready||(entry.role&&!(REAL.byRole&&REAL.byRole[entry.role])))
            throw new Error('El modelo original todavía no está disponible.');
          model=await makeViewerOriginal(entry,skin);
        }
        viewer.models.roles[modelKey]=model;
      }else if(!model&&kind==='props'){
        const geo=await loadViewerProp(entry);
        const texturePath='assets/props/'+entry.tex;
        let texture=viewer.textures[texturePath];
        if(!texture){
          texture=await new Promise((resolve,reject)=>{
            new THREE.TextureLoader().load(texturePath,resolve,undefined,reject);
          });
          texture.colorSpace=THREE.SRGBColorSpace;
          viewer.textures[texturePath]=texture;
        }
        const mesh=new THREE.Mesh(geo.clone(),new THREE.MeshStandardMaterial({
          map:texture,roughness:0.85,metalness:0.02,transparent:false,opacity:1,depthWrite:true,
          side:THREE.DoubleSide
        }));
        mesh.castShadow=true;
        model=new THREE.Group();
        model.scale.setScalar(1.15);
        const spin=new THREE.Group();spin.rotation.y=Math.PI/2;model.add(spin);
        const tilt=new THREE.Group();tilt.rotation.x=-Math.PI/2;spin.add(tilt);
        mesh.scale.setScalar(0.95);tilt.add(mesh);
        model.userData.staticRole=true;
        viewer.models.props[name]=model;
      }else if(!model&&kind==='pieces'){
        const geo=await loadViewerPiece(entry);
        const texturePath='assets/maps/textures/T_Atlas_01_D.png';
        let texture=viewer.textures[texturePath];
        if(!texture){
          texture=await new Promise((resolve,reject)=>{
            new THREE.TextureLoader().load(texturePath,resolve,undefined,reject);
          });
          texture.colorSpace=THREE.SRGBColorSpace;
          viewer.textures[texturePath]=texture;
        }
        const mesh=new THREE.Mesh(geo.clone(),new THREE.MeshStandardMaterial({
          map:texture,roughness:0.85,metalness:0.02,transparent:false,opacity:1,depthWrite:true,
          side:THREE.DoubleSide
        }));
        mesh.castShadow=true;
        model=new THREE.Group();
        model.scale.setScalar(1.15);
        const spin=new THREE.Group();spin.rotation.y=Math.PI/2;model.add(spin);
        const tilt=new THREE.Group();tilt.rotation.x=-Math.PI/2;spin.add(tilt);
        mesh.scale.setScalar(0.95);tilt.add(mesh);
        model.userData.staticRole=true;
        viewer.models.pieces[name]=model;
      }else if(!model){
        const meshFile=entry.file;
        if(!GUN_MESH_CACHE[meshFile])makeRealGun3(meshFile);
        if(!GUN_MESH_CACHE[meshFile]){
          const started=Date.now();
          while(GUN_MESH_CACHE[meshFile]===null&&Date.now()-started<10000){
            if(token!==viewer.selection)return;
            await wait(100);
          }
          if(!GUN_MESH_CACHE[meshFile])throw new Error('No se pudo cargar la malla de esta arma.');
        }
        model=GUN_MESH_CACHE[meshFile].clone(true);
        viewer.models.weapons[name]=model;
      }
      if(token!==viewer.selection)return;
      if(kind==='roles'){
        try{await syncViewerGun(model,entry,token);}
        catch(error){setStatus('No se pudo equipar el arma: '+error.message,true);}
        if(token!==viewer.selection)return;
      }
      mount(model);
      document.getElementById('viewerAssetInfo').textContent=kind==='roles'
        ?(model.userData.meshy?'Malla OBJ y textura Meshy en pose del modelo · '+skin.label+'.':'Malla '+entry.file+' · '+skin.label+'.')
        :kind==='props'
          ?('Malla '+entry.file+' · Textura '+entry.tex+'.')
          :kind==='pieces'
            ?('Malla '+entry.f+' · Textura T_Atlas_01_D.png (atlas compartido).')
            :'Malla y textura del arsenal · '+entry.file+'.obj';
    }catch(error){
      if(token===viewer.selection)setStatus('No se pudo mostrar el modelo: '+error.message,true);
    }
  }
  function activate(){
    refreshList();
    resize();
    const kindButton=document.querySelector('#viewerKinds button.on');
    viewer.kind=kindButton?kindButton.dataset.kind:'roles';
    const names=viewer.kind==='roles'?viewerCharacters.map(entry=>entry.key):viewer.kind==='props'?viewerPropFiles.map(entry=>entry.key):viewer.kind==='pieces'?MAP_PIECES.filter(piece=>piece.m===viewer.pieceMap).map(piece=>piece.k):viewerWeaponFiles;
    selectModel(viewer.kind,names.includes(viewer.name)?viewer.name:names[0]);
    if(!viewer.frameRequested){viewer.frameRequested=true;requestAnimationFrame(frame);}
  }
  document.getElementById('viewerCharacterSelect').onchange=event=>{
    viewer.skinIndex=0;
    viewer.weapon='';
    selectModel('roles',event.target.value);
  };
  document.getElementById('viewerWeaponSelect').onchange=event=>{
    viewer.weapon=event.target.value||'';
    selectModel('roles',viewer.name);
  };
  document.getElementById('viewerPieceMapSelect').onchange=event=>{
    viewer.pieceMap=event.target.value;
    viewer.skinIndex=0;
    const names=MAP_PIECES.filter(piece=>piece.m===viewer.pieceMap).map(piece=>piece.k);
    selectModel('pieces',names[0]);
  };
  const stepSkin=delta=>{
    const entry=viewerCharacters.find(item=>item.key===viewer.name);
    if(!entry||entry.skins.length<2)return;
    viewer.skinIndex=(viewer.skinIndex+delta+entry.skins.length)%entry.skins.length;
    selectModel('roles',entry.key);
  };
  document.getElementById('viewerSkinPrev').onclick=()=>stepSkin(-1);
  document.getElementById('viewerSkinNext').onclick=()=>stepSkin(1);
  document.querySelectorAll('#viewerKinds button').forEach(button=>{
    button.onclick=()=>{
      document.querySelectorAll('#viewerKinds button').forEach(item=>item.classList.toggle('on',item===button));
      viewer.kind=button.dataset.kind;
      viewer.skinIndex=0;
      const names=viewer.kind==='roles'?viewerCharacters.map(entry=>entry.key):viewer.kind==='props'?viewerPropFiles.map(entry=>entry.key):viewer.kind==='pieces'?MAP_PIECES.filter(piece=>piece.m===viewer.pieceMap).map(piece=>piece.k):viewerWeaponFiles;
      selectModel(viewer.kind,names[0]);
    };
  });
  zoomControl.oninput=updateCamera;
  stage.addEventListener('wheel',event=>{
    event.preventDefault();
    zoomControl.value=String(Math.max(+zoomControl.min,Math.min(+zoomControl.max,+zoomControl.value+(event.deltaY<0?0.1:-0.1))));
    updateCamera();
  },{passive:false});
  stage.addEventListener('pointerdown',event=>{
    viewer.drag={x:event.clientX,y:event.clientY,t:event.timeStamp};
    viewer.dragVel=0;
    stage.setPointerCapture(event.pointerId);
  });
  stage.addEventListener('pointermove',event=>{
    if(!viewer.drag)return;
    const dx=event.clientX-viewer.drag.x,dy=event.clientY-viewer.drag.y;
    const dt=Math.max(0.008,Math.min(0.05,(event.timeStamp-viewer.drag.t)/1000));
    viewer.drag={x:event.clientX,y:event.clientY,t:event.timeStamp};
    viewer.spin.rotation.y+=dx*0.008;
    viewer.spin.rotation.x=Math.max(-0.65,Math.min(0.65,viewer.spin.rotation.x+dy*0.006));
    viewer.dragVel=Math.max(-3,Math.min(3,dx*0.008/dt));
  });
  const stopDrag=()=>{viewer.drag=null;};
  stage.addEventListener('pointerup',stopDrag);
  stage.addEventListener('pointercancel',stopDrag);
  const menuButton=document.getElementById('mnuViewer');
  const tabButton=document.querySelector('#mainTabs [data-tab="viewer"]');
  [menuButton,tabButton].forEach(button=>{
    if(button)button.onclick=()=>{showScreen('scr-viewer');activate();};
  });
  window.addEventListener('resize',resize);
})();
