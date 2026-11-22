import { WEAPONS_ORIGINAL, WEAPON_MESH_FILE, weaponFileForRef, originalWeaponProfile } from '../render3d/assets-weapons.js';
import { prettySkinName } from '../data/skin-names.js';
import { CHARACTER_ABILITIES, ABILITY_OBJECTS } from '../data/cast.js';
import { DEPLOYABLES } from '../data/deployables.js';
import { auWeaponFile, auDeployable, auVoice } from '../core-and-audio.js';
import { getCardStage, setCardStagePaused, setStageZoom, stageZoom, renderStage, snapshotStage, scanCardBoxes } from './card-stage.js';

const insEsc=value=>String(value==null?'':value).replace(/[&<>"]/g,char=>({'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;'}[char]));
let insRoot=null;
let insStage=null;
let insPanel=null;
let insTitle=null;
let insKicker=null;
let insFire=null;
let insAuto=null;
let insPrev=null;
let insNext=null;
let insCurrent=null;
let insBound=false;

export function isInspectorOpen(){return !!(insRoot&&!insRoot.hidden);}

function insElements(){
  if(insRoot)return true;
  insRoot=document.getElementById('inspectorRoot');
  if(!insRoot)return false;
  insStage=document.getElementById('inspectorStage');
  insPanel=document.getElementById('inspectorPanel');
  insTitle=document.getElementById('inspectorTitle');
  insKicker=document.getElementById('inspectorKicker');
  insFire=document.getElementById('inspectorFire');
  insAuto=document.getElementById('inspectorAuto');
  insPrev=document.getElementById('inspectorPrev');
  insNext=document.getElementById('inspectorNext');
  return true;
}

function insViewer(){return typeof window!=='undefined'?window.__csnViewer:null;}
function insEngine(){return typeof window!=='undefined'?window.__csnCardEngine:null;}

function insWriteSpec(spec){
  insCurrent={...spec,inspect:false};
  if(insCurrent.kind==='roles')insCurrent.weapon=insCurrent.weapon?weaponFileForRef(insCurrent.weapon)||insCurrent.weapon:'';
  if(insStage)insStage.dataset.cardSpec=JSON.stringify(insCurrent);
}

function insSkinLabel(skin,index){
  const file=skin&&skin.key&&skin.key.indexOf('cast:')===0?skin.key.slice(5):skin&&skin.label;
  return prettySkinName(file,index);
}

function insWeaponOptions(current){
  const groups=new Map();
  (insViewer()&&insViewer().getWeaponFiles()||[]).forEach(file=>{
    const cat=(WEAPONS_ORIGINAL[file]||{}).cat||'Otros';
    if(!groups.has(cat))groups.set(cat,[]);
    groups.get(cat).push(file);
  });
  return '<option value="">Sin arma (solo personaje)</option>'+[...groups.entries()].map(([cat,files])=>
    '<optgroup label="'+insEsc(cat)+'">'+files.map(file=>'<option value="'+insEsc(file)+'"'+(file===current?' selected':'')+'>'+insEsc((WEAPONS_ORIGINAL[file]||{}).name||file)+'</option>').join('')+'</optgroup>').join('');
}

function insAbilities(entry){
  const list=CHARACTER_ABILITIES[entry.name]||[];
  if(entry.mesh)return '<p class="note sub">Diseño propio CSN: sin habilidades del original.</p>';
  if(!list.length)return '<p class="note sub">Sin habilidades legibles del original.</p>';
  return list.map(ability=>{
    const obj=ability.obj?ABILITY_OBJECTS[ability.obj]:null;
    const link=obj&&obj.model?'<button type="button" class="inspector-link" data-inspector-prop="'+insEsc(obj.model)+'">Inspeccionar desplegable: '+insEsc(obj.name||ability.n)+' →</button>':'';
    return '<div class="inspector-ability"><img src="assets/ui/ability/'+insEsc(ability.icon)+'.png" alt=""/><div><b>'+insEsc(ability.n)+'</b><small>'+insEsc(ability.d)+'</small>'+link+'</div></div>';
  }).join('');
}

function insRolePanel(spec,entry){
  const csn=!!entry.mesh;
  const entries=entry.skins||[];
  const labels=entries.map(insSkinLabel);
  const skinIndex=Number(spec.skinIndex)||0;
  const skinName=labels[skinIndex]||'Estándar';
  const skins='<button type="button" class="inspector-skin-step" data-inspector-skin-step="-1" aria-label="Skin anterior"'+(entries.length<2?' disabled':'')+'>‹</button>'+
    '<span class="inspector-skin-name" data-inspector-skin-name="'+skinIndex+'">'+insEsc(skinName)+'</span>'+
    '<button type="button" class="inspector-skin-step" data-inspector-skin-step="1" aria-label="Skin siguiente"'+(entries.length<2?' disabled':'')+'>›</button>';
  const weaponBlock=csn?'<p class="note sub">Modelo Meshy propio: sin pose, clips ni retarget y sin acople de arma.</p>':
    '<label class="inspector-select"><span>Arma del original · '+((insViewer()&&insViewer().getWeaponFiles()||[]).length)+' disponibles</span><select data-inspector-weapon>'+insWeaponOptions(spec.weapon)+'</select></label>';
  return '<div class="inspector-tags"><span class="tag'+(csn?'':' amber')+'">'+(csn?'CSN':'Juego original')+'</span><span class="tag">'+insEsc(entry.role||'Sin rol')+'</span></div>'+
    '<p class="inspector-bio">'+insEsc(entry.bio||'')+'</p>'+
    '<h3>Skin</h3><div class="inspector-skins">'+skins+'</div>'+weaponBlock+
    '<h3>Habilidades del original</h3><div class="inspector-abilities">'+insAbilities(entry)+'</div>';
}

function insWeaponPanel(spec){
  const info=WEAPONS_ORIGINAL[spec.file]||{};
  const csn=spec.csn||null;
  const profile=originalWeaponProfile(spec.file)||{};
  const stats=csn?'<div class="wstats"><div><b>'+insEsc(csn.dmg)+'</b><span>Daño</span></div><div><b>'+insEsc(csn.rng)+'</b><span>Casillas</span></div><div><b>'+insEsc(csn.cost)+' ⚡</b><span>Coste</span></div></div>':'';
  const data=csn?'<p class="note"><b>Ficha real:</b> '+insEsc(csn.real||'')+'</p>'+
      '<p class="note sub"><b>Roles:</b> '+insEsc(csn.roles||'')+'</p>'+
      '<p class="note sub">Modelo 3D CSN pendiente · '+insEsc(csn.note||'')+'</p>'+stats:
    '<p class="note sub">'+insEsc(info.cat||'Arma')+' · '+insEsc(info.roles||'Sin asignación específica')+'</p>'+
    '<p class="note sub">'+insEsc((info.dims||[]).join(' × '))+' m · '+insEsc(info.verts||'?')+' vértices · '+insEsc(info.uses&&info.uses.join(', ')||'Sin equivalente CSN')+'</p>'+
    '<p class="note sub">Presentación 3D del arma de referencia'+(profile.actionLabel?' · '+insEsc(profile.actionLabel):'')+'.</p>';
  return '<div class="inspector-tags"><span class="tag'+(csn?'':' amber')+'">'+(csn?'CSN':'Juego original')+'</span><span class="tag">'+insEsc(info.cat||(csn&&csn.cat)||'Arma')+'</span></div>'+
    '<p class="inspector-bio">'+insEsc(info.note||csn&&csn.real||info.name||spec.label||'')+'</p>'+data;
}

function insGlbPanel(spec){
  return '<div class="inspector-tags"><span class="tag amber">Competitivo</span><span class="tag">.glb</span></div>'+
    '<p class="inspector-bio">'+insEsc(spec.label||'Modelo competitivo')+'</p>'+
    '<p class="note sub">Modelo: '+insEsc(spec.glbUrl||'sin cargar')+'.</p>';
}

function insPropPanel(spec){
  const prop=DEPLOYABLES.find(item=>item.key===spec.key)||{};
  return '<div class="inspector-tags"><span class="tag amber">Juego original</span><span class="tag">Objeto desplegable</span></div>'+
    '<p class="inspector-bio">'+insEsc(prop.note||prop.label||spec.label||'')+'</p>'+
    '<p class="note sub">Malla '+insEsc(prop.file||'')+' · Textura '+insEsc(prop.tex||'')+'.</p>';
}

function insRenderPanel(){
  if(!insPanel||!insCurrent)return;
  const viewer=insViewer();
  const entry=insCurrent.kind==='roles'&&viewer?viewer.getEntry(insCurrent.key):null;
  insKicker.textContent=insCurrent.kind==='roles'?'Personaje':insCurrent.kind==='props'?'Desplegable':insCurrent.kind==='glb'?'Laboratorio .glb':'Arma';
  insTitle.textContent=entry?entry.label:insCurrent.label||'Modelo 3D';
  insPanel.innerHTML=entry?insRolePanel(insCurrent,entry):insCurrent.kind==='glb'?insGlbPanel(insCurrent):insCurrent.kind==='props'?insPropPanel(insCurrent):insWeaponPanel(insCurrent);
  const oldLab=insPanel.querySelector('.glb-lab');if(oldLab)oldLab.remove();
  if(insCurrent.kind==='glb'&&window.__csnGlbLab&&window.__csnGlbLab.mount)window.__csnGlbLab.mount(insPanel,{kind:insCurrent.labKind||'chars',url:insCurrent.glbUrl,label:insCurrent.label});
  insPanel.querySelectorAll('[data-inspector-skin-step]').forEach(button=>{button.onclick=()=>{
    const entry=viewer&&insCurrent.kind==='roles'?viewer.getEntry(insCurrent.key):null;
    const count=entry&&entry.skins?entry.skins.length:0;
    if(count<2)return;
    const step=+button.dataset.inspectorSkinStep;
    const skinIndex=((Number(insCurrent.skinIndex)||0)+step+count)%count;
    const spec={...insCurrent,skinIndex};
    insWriteSpec(spec);
    if(insEngine()&&insStage)insEngine().activate(insStage,spec);
    insRenderPanel();
  };});
  const weaponSelect=insPanel.querySelector('[data-inspector-weapon]');
  if(weaponSelect)weaponSelect.onchange=()=>{
    const spec={...insCurrent,weapon:weaponSelect.value};
    insWriteSpec(spec);
    if(insEngine()&&insStage)insEngine().activate(insStage,spec);
    insUpdateFire();
  };
  insPanel.querySelectorAll('[data-inspector-prop]').forEach(button=>{button.onclick=()=>{closeInspector();if(window.openDeployable3D)window.openDeployable3D(button.dataset.inspectorProp);};});
  insUpdateFire();
}

function insUpdateFire(){
  if(!insFire||!insCurrent)return;
  insFire.disabled=false;
  const viewer=insViewer();
  if(insCurrent.kind==='glb'){
    insFire.hidden=false;
    insFire.textContent='▶ Probar animación de disparo';
    insFire.onclick=()=>{if(window.__csnGlbLab&&window.__csnGlbLab.play)window.__csnGlbLab.play('fire');};
    return;
  }
  if(insCurrent.kind==='roles'){
    const entry=viewer&&viewer.getEntry(insCurrent.key);
    if(entry&&entry.mesh){insFire.hidden=true;return;}
    const file=weaponFileForRef(insCurrent.weapon||'');
    const profile=file&&originalWeaponProfile(file);
    insFire.hidden=false;
    if(!file){insFire.disabled=true;insFire.textContent='Elige un arma para probar disparo';insFire.onclick=null;return;}
    insFire.textContent='▶ '+(profile&&profile.actionLabel||'Probar disparo');
    insFire.onclick=()=>{if(viewer&&viewer.fire){const label=insFire.textContent;insFire.textContent='▶ Reproduciendo…';setTimeout(()=>{insFire.textContent=label;},900);viewer.fire(insCurrent);}};
    return;
  }
  if(insCurrent.kind==='weapons'){
    if(insCurrent.csn){insFire.hidden=true;return;}
    insFire.hidden=false;insFire.textContent='🔊 Escuchar sonido original';
    insFire.onclick=()=>auWeaponFile(weaponFileForRef(insCurrent.weapon||insCurrent.file)||insCurrent.file);
    return;
  }
  if(insCurrent.kind==='props'){
    const prop=DEPLOYABLES.find(item=>item.key===insCurrent.key);
    if(!prop||!prop.sfx){insFire.hidden=true;return;}
    insFire.hidden=false;insFire.textContent='🔊 Escuchar sonido del desplegable';
    insFire.onclick=()=>auDeployable(insCurrent.key);
    return;
  }
  insFire.hidden=true;
}

function insNavEntries(){
  const viewer=insViewer();
  if(!viewer||!insCurrent)return [];
  if(insCurrent.kind==='roles')return (viewer.getRoster()||[]).map(entry=>({
    kind:'roles',key:entry.key,skinIndex:0,weapon:'',
    file:entry.file||entry.mesh||'',label:entry.label
  }));
  if(insCurrent.kind==='weapons')return (viewer.getWeaponFiles()||[]).map(file=>({
    kind:'weapons',key:file,file,weapon:file,label:(WEAPONS_ORIGINAL[file]||{}).name||file
  }));
  if(insCurrent.kind==='props')return DEPLOYABLES.map(prop=>({...prop,kind:'props',key:prop.key}));
  return [];
}

async function insOpen(spec){return openInspector(spec);}

function insNavigate(delta){
  if(!insCurrent||insCurrent.kind==='glb')return;
  const entries=insNavEntries();
  if(entries.length<2)return;
  const index=entries.findIndex(entry=>entry.key===insCurrent.key);
  const next=index<0?0:(index+delta+entries.length)%entries.length;
  insOpen(entries[next]);
}

function insBindDrag(){
  if(!insStage||insStage.dataset.csnDragBound==='1')return;
  insStage.dataset.csnDragBound='1';
  let drag=null,dragVel=0;
  const state=()=>insViewer()&&insViewer().state;
  insStage.addEventListener('pointerdown',event=>{
    if(event.button!==undefined&&event.button!==0)return;
    if(!getCardStage())return;
    drag={x:event.clientX,y:event.clientY,t:event.timeStamp};
    if(state()){state().drag=drag;state().dragVel=0;}
    try{insStage.setPointerCapture(event.pointerId);}catch(error){}
  });
  insStage.addEventListener('pointermove',event=>{
    if(!drag)return;
    const stage=getCardStage();if(!stage)return;
    const dx=event.clientX-drag.x,dy=event.clientY-drag.y;
    const dt=Math.max(0.008,Math.min(0.05,(event.timeStamp-drag.t)/1000));
    drag={x:event.clientX,y:event.clientY,t:event.timeStamp};
    stage.spin.rotation.y+=dx*0.008;
    stage.spin.rotation.x=Math.max(-0.65,Math.min(0.65,stage.spin.rotation.x+dy*0.006));
    dragVel=Math.max(-3,Math.min(3,dx*0.008/dt));
    if(state()){state().drag=drag;state().dragVel=dragVel;}
    renderStage();
  });
  const end=()=>{if(!drag)return;drag=null;if(state()){state().drag=null;state().dragVel=dragVel;}snapshotStage();};
  insStage.addEventListener('pointerup',end);
  insStage.addEventListener('pointercancel',end);
  insStage.addEventListener('wheel',event=>{
    event.preventDefault();
    setStageZoom(stageZoom()+(event.deltaY<0?0.12:-0.12));
    renderStage();
  },{passive:false});
}

function insBind(){
  if(insBound)return;
  insBound=true;
  insBindDrag();
  const close=document.getElementById('inspectorClose');
  if(close)close.onclick=closeInspector;
  const backdrop=insRoot.querySelector('[data-inspector-close]');
  if(backdrop)backdrop.onclick=closeInspector;
  document.addEventListener('keydown',event=>{
    if(!isInspectorOpen())return;
    const tag=event.target&&event.target.tagName;
    if(tag==='INPUT'||tag==='TEXTAREA'||tag==='SELECT')return;
    if(event.key==='Escape')closeInspector();
    else if(event.key==='ArrowLeft'){event.preventDefault();insNavigate(-1);}
    else if(event.key==='ArrowRight'){event.preventDefault();insNavigate(1);}
  });
  document.querySelectorAll('[data-inspector-zoom]').forEach(button=>{button.onclick=()=>{setStageZoom(stageZoom()+(+button.dataset.inspectorZoom||0),false);renderStage();};});
  const reset=document.getElementById('inspectorReset');
  if(reset)reset.onclick=()=>{const stage=getCardStage();if(stage)stage.spin.rotation.set(0,-0.55,0);setStageZoom(1,false);renderStage();};
  if(insAuto)insAuto.onclick=()=>{
    const viewer=insViewer();const next=!(viewer&&viewer.state&&viewer.state.inspectorAutoSpin);
    if(viewer&&viewer.state)viewer.state.inspectorAutoSpin=next;
    insAuto.setAttribute('aria-pressed',next?'true':'false');
    insAuto.classList.toggle('on',next);
  };
  if(insPrev)insPrev.onclick=()=>insNavigate(-1);
  if(insNext)insNext.onclick=()=>insNavigate(1);
}

export async function openInspector(spec){
  if(!insElements()||!spec||typeof spec!=='object'||!['roles','weapons','props','glb'].includes(spec.kind))return false;
  insBind();
  setCardStagePaused(true);
  const viewer=insViewer();
  if(viewer&&viewer.state){viewer.state.inspectorOpen=true;viewer.state.inspectorAutoSpin=false;}
  if(insAuto){insAuto.setAttribute('aria-pressed','false');insAuto.classList.remove('on');}
  insRoot.hidden=false;
  document.body.classList.add('inspector-open');
  insWriteSpec({...spec});
  scanCardBoxes(insRoot);
  const engine=insEngine();
  if(engine&&insStage)await engine.activate(insStage,insCurrent);
  insRenderPanel();
  const navCount=insNavEntries().length;
  if(insPrev)insPrev.hidden=navCount<2;
  if(insNext)insNext.hidden=insPrev.hidden;
  renderStage();
  return true;
}

export function closeInspector(){
  if(!isInspectorOpen())return;
  insRoot.hidden=true;
  document.body.classList.remove('inspector-open');
  const viewer=insViewer();
  if(viewer&&viewer.state){viewer.state.inspectorOpen=false;viewer.state.inspectorAutoSpin=false;}
  if(viewer&&viewer.unmount)viewer.unmount();
  setCardStagePaused(false);
  scanCardBoxes();
}

if(typeof window!=='undefined')window.__csnInspector={open:openInspector,close:closeInspector,isOpen:isInspectorOpen,zoom:()=>stageZoom()};
