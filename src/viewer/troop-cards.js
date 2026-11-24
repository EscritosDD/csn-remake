import { WEAPONS_ORIGINAL, originalWeaponProfile, weaponFileForRef } from '../render3d/assets-weapons.js';
import { prettySkinName } from '../data/skin-names.js';
import { CHARACTER_ABILITIES, ABILITY_OBJECTS } from '../data/cast.js';
import { scanCardBoxes } from './card-stage.js';

let tcRoster=[];
let tcWeaponFiles=[];
const tcState={origin:'Todas',role:'Todas',cards:{}};
const tcEsc=value=>String(value==null?'':value).replace(/[&<>"]/g,char=>({'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;'}[char]));
const tcScan=()=>{if(typeof scanCardBoxes==='function')scanCardBoxes();};
const tcSpecAttr=spec=>'data-card-spec=\''+JSON.stringify(spec).replace(/'/g,'&#39;')+'\'';
const tcCardState=entry=>tcState.cards[entry.key]||(tcState.cards[entry.key]={skinIndex:0,weapon:entry.defaultWeapon||''});

function tcCard3dBox(spec,label){
  return '<div class="card-3d-box" '+tcSpecAttr(spec)+' aria-label="Modelo 3D de '+tcEsc(label)+'"><img class="card-3d-thumb is-loading" alt="" hidden/><span class="card-3d-badge">3D</span></div>';
}

function tcAbilitiesHTML(entry){
  const list=CHARACTER_ABILITIES[entry.name]||[];
  if(!list.length)return '';
  return '<div class="ability-mini">'+list.slice(0,4).map(ability=>{
    const obj=ability.obj?ABILITY_OBJECTS[ability.obj]:null;
    return '<img src="assets/ui/ability/'+tcEsc(ability.icon)+'.png" alt="" title="'+tcEsc(ability.n)+(obj?' · '+tcEsc(obj.name):'')+'"/>';
  }).join('')+'</div>';
}

function tcTroopCardHTML(entry,index){
  const csn=!!entry.mesh;
  const saved=tcCardState(entry);
  const origin=csn?'CSN':'Juego original';
  const weapon=csn?'':(saved.weapon||entry.defaultWeapon||'');
  const weaponFile=csn?'':weaponFileForRef(weapon);
  const profile=csn?null:originalWeaponProfile(weaponFile);
  const skinIndex=Math.min(saved.skinIndex||0,Math.max(0,(entry.skins||[]).length-1));
  const skin=entry.skins&&entry.skins[skinIndex];
  const spec={kind:'roles',key:entry.key,skinIndex,weapon,file:entry.file||entry.mesh||'',label:entry.label,inspect:true};
  return '<article class="catalog-card troop-card" data-origin="'+origin+'" data-role="'+tcEsc(entry.role||'')+'" data-troop-key="'+tcEsc(entry.key)+'">'+
    '<header><span class="tag'+(csn?'':' amber')+'">'+origin+'</span><span class="catalog-count">'+String(index+1).padStart(2,'0')+'</span></header>'+
    tcCard3dBox(spec,entry.label)+
    '<div class="card-body"><h3>'+tcEsc(entry.label)+'</h3>'+
    '<div class="card-meta"><span class="tag">'+tcEsc(entry.role||'Sin rol')+'</span><span class="tag">'+(csn?'Prototipo 3D':tcEsc(prettySkinName(skin&&skin.key&&skin.key.indexOf('cast:')===0?skin.key.slice(5):skin&&skin.label,skinIndex)))+'</span></div>'+
    '<p class="note sub">'+tcEsc(entry.bio||'')+'</p>'+
    (csn?'<p class="note">Diseño propio CSN · malla '+tcEsc(entry.mesh)+'. Sin pose, clips ni retarget.</p>'
      :'<p class="note sub">Arma: '+tcEsc((WEAPONS_ORIGINAL[weapon]||{}).name||weapon||'sin arma')+' · '+(profile&&profile.actionLabel||'Sin acción')+'.</p>')+
    tcAbilitiesHTML(entry)+
    '<button type="button" class="inspector-open" data-inspector-open>Ver ficha y 3D ampliado →</button></div></article>';
}

function tcOpenCard(card){
  const box=card.querySelector('.card-3d-box[data-card-spec]');
  if(!box)return;
  try{
    const spec=JSON.parse(box.dataset.cardSpec);
    if(window.__csnInspector&&window.__csnInspector.open)window.__csnInspector.open(spec);
  }catch(error){}
}

function tcBuildFilters(){
  const container=document.getElementById('troopFilters');if(!container)return;
  const origins=['Todas','Juego original','CSN'];
  const roles=['Todas','Francotirador','Artillero','Espía','Médico','Ingeniero','Comando','Capitán'];
  container.innerHTML='<div class="weapon-filter-row" data-group="origin">'+origins.map(value=>{
    const count=value==='Todas'?tcRoster.length:tcRoster.filter(entry=>value==='CSN'?!!entry.mesh:!entry.mesh).length;
    return '<button type="button" data-value="'+tcEsc(value)+'"'+(value===tcState.origin?' class="on"':'')+'>'+tcEsc(value)+' ('+count+')</button>';
  }).join('')+'</div><div class="weapon-filter-row" data-group="role">'+roles.map(value=>'<button type="button" data-value="'+tcEsc(value)+'"'+(value===tcState.role?' class="on"':'')+'>'+tcEsc(value==='Todas'?'Todos los roles':value)+'</button>').join('')+'</div>';
  container.querySelectorAll('[data-group="origin"] button').forEach(button=>{button.onclick=()=>{tcState.origin=button.dataset.value;renderTroopCards();};});
  container.querySelectorAll('[data-group="role"] button').forEach(button=>{button.onclick=()=>{tcState.role=button.dataset.value;renderTroopCards();};});
}

export function renderTroopCards(characters,files){
  if(Array.isArray(characters))tcRoster=characters;
  if(Array.isArray(files))tcWeaponFiles=files;
  tcBuildFilters();
  const grid=document.getElementById('troopGrid');if(!grid)return;
  const originCount=tcRoster.filter(entry=>!!entry.mesh).length;
  const visible=tcRoster.map((entry,index)=>({entry,index})).filter(({entry})=>
    (tcState.origin==='Todas'||(tcState.origin==='CSN'?!!entry.mesh:!entry.mesh))&&
    (tcState.role==='Todas'||(entry.role||'Sin rol')===tcState.role));
  grid.innerHTML='<div class="catalog-head" style="grid-column:1/-1"><h2>Personajes</h2><span class="catalog-count">'+tcRoster.length+' tropas · '+(tcRoster.length-originCount)+' originales · '+originCount+' CSN · '+tcWeaponFiles.length+' armas</span>'+
    '<button type="button" class="btn ghost glb-lab-open" data-glb-lab-open>📥 Probar personaje .glb</button></div>'+
    (visible.length?visible.map(({entry,index})=>tcTroopCardHTML(entry,index)).join(''):'<p class="sub" style="grid-column:1/-1">No hay tropas para este filtro.</p>');
  visible.forEach(({entry})=>{const card=grid.querySelector('[data-troop-key="'+tcEsc(entry.key)+'"]');if(card){
    const open=card.querySelector('[data-inspector-open]');if(open)open.onclick=event=>{event.stopPropagation();tcOpenCard(card);};
    card.onclick=()=>tcOpenCard(card);
  }});
  const lab=grid.querySelector('[data-glb-lab-open]');
  if(lab)lab.onclick=()=>{if(window.__csnGlbLab&&window.__csnGlbLab.open)window.__csnGlbLab.open('chars');};
  tcScan();
}

export function setTroopOrigin(value){tcState.origin=value==='CSN'||value==='Juego original'?value:'Todas';renderTroopCards();}
export function setTroopRole(value){tcState.role=value||'Todas';renderTroopCards();}

if(typeof window!=='undefined'&&!window.__csnTroopCards)window.__csnTroopCards={render:renderTroopCards,setOrigin:setTroopOrigin,setRole:setTroopRole,getRoster:()=>tcRoster,getWeaponFiles:()=>tcWeaponFiles};
