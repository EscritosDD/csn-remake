import { BODIES, ROLES, ROLE_NAMES, roleLook } from '../data/roles.js';
import { WEAPONS } from '../data/weapons.js';
import { WEAPONS_ORIGINAL, WEAPON_MESH_FILE, weaponCoverURL } from '../render3d/assets-weapons.js';
import { auWeaponFile, auDeployable } from '../audio/sound.js';
import { DEPLOYABLES } from '../data/deployables.js';
import { ORIG_CAST, OWN_CAST } from '../data/cast.js';
import { SKINS } from '../data/nations.js';
import { lsGet, lsSet } from '../core-and-audio.js';
import { loadChars, saveChars, setCHAR_PREFS } from '../game/chars.js';
import { scanCardBoxes } from '../viewer/card-stage.js';
import { $, rolePortraitURL, toast } from './ui-shell.js';

export const CATS=['Todas','Fusiles de asalto','Subfusiles','Ametralladoras','Francotirador','Escopetas','Lanzacohetes','Lanzagranadas','Pistolas','Cuerpo a cuerpo','Consumible'];
export const ORIGINS=['Todas','Juego original','CSN'];
export let arsFilter='Todas';
export let arsOrigin='Todas';
export let arsSection='weapons';
const arEsc=value=>String(value==null?'':value).replace(/[&<>"]/g,char=>({'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;'}[char]));

export function setArsFilter(v){arsFilter=v;}
export function setArsOrigin(v){arsOrigin=v;}
export function setArsSection(v){arsSection=v==='deployables'?'deployables':v==='abilities'?'abilities':'weapons';}

const arScan=()=>{if(typeof scanCardBoxes==='function')scanCardBoxes();};
const arSpecAttr=spec=>'data-card-spec=\''+JSON.stringify(spec).replace(/'/g,'&#39;')+'\'';
const arCategoryHit=(cat,filter)=>filter==='Todas'||cat===filter||(filter==='Consumible'&&cat==='Consumibles')||(filter==='Consumibles'&&cat==='Consumible');
const arOpen=spec=>{if(window.__csnInspector&&window.__csnInspector.open)window.__csnInspector.open(spec);};

function arCard3dBox(spec,label){
  return '<div class="card-3d-box" '+arSpecAttr(spec)+' aria-label="Modelo 3D de '+arEsc(label)+'"><img class="card-3d-thumb is-loading" alt="" hidden/><span class="card-3d-badge">3D</span></div>';
}

function arOriginalCardHTML(file){
  const info=WEAPONS_ORIGINAL[file]||{};
  const spec={kind:'weapons',key:file,file,label:info.name||file,inspect:true};
  return '<article class="catalog-card weapon-original"><header><span class="tag amber">Juego original</span><span class="catalog-count">'+arEsc(info.cat||'Arma')+'</span></header>'+
    arCard3dBox(spec,info.name||file)+
    '<div class="card-body"><h3>'+arEsc(info.name||file)+'</h3><p class="real">'+arEsc((info.uses||[]).join(' · ')||'Sin equivalente CSN')+'</p>'+
    '<div class="wstats"><div><b>'+arEsc(info.verts||'?')+'</b><span>Vértices</span></div><div><b>'+arEsc((info.texSize||[]).join('×'))+'</b><span>Textura</span></div><div><b>'+arEsc((info.dims||[]).join(' × '))+'</b><span>Medidas</span></div></div>'+
    '<p class="note sub">'+arEsc(info.roles||'Sin asignación específica en el original.')+'</p>'+
    '<div class="card-actions"><button type="button" class="btn ghost" data-au-file="'+arEsc(file)+'">🔊 Escuchar sonido original</button><button type="button" class="btn ghost" data-inspector-open>Ampliar</button></div></div></article>';
}

function arCsnCardHTML(name,weapon){
  const file=WEAPON_MESH_FILE[name]||'AssaultRifle';
  const roles=ROLE_NAMES.filter(role=>ROLES[role].weapons.includes(name)).join(', ')||(weapon.cat==='Pistolas'?'Todos (secundaria)':'Sin asignar');
  const spec={kind:'weapons',key:file,file,label:name,csn:{name,cat:weapon.cat,dmg:weapon.dmg,rng:weapon.rng,cost:weapon.cost,note:weapon.note,real:weapon.real,roles},inspect:true};
  return '<article class="catalog-card weapon-csn" '+arSpecAttr(spec)+'><header><span class="tag">CSN</span><span class="catalog-count">'+arEsc(weapon.cat)+'</span></header>'+
    '<div class="card-3d-box" aria-label="Vista táctica de '+arEsc(name)+'"><div class="card-3d-empty"><span class="csn-ico">'+(weapon.cat==='Cuerpo a cuerpo'?'✕':'◆')+'</span><b>'+arEsc(weapon.cat.toUpperCase())+'</b><span>Modelo 3D CSN pendiente</span></div></div>'+
    '<div class="card-body"><h3>'+arEsc(name)+'</h3><p class="real">'+arEsc(weapon.real)+'</p><p class="note">'+arEsc(weapon.note)+(weapon.once?' <b>Un solo uso por partida.</b>':'')+(weapon.aoe?' Daño en área.':'')+'</p>'+
    '<div class="wstats"><div><b>'+weapon.dmg+'</b><span>Daño</span></div><div><b>'+weapon.rng+'</b><span>Casillas</span></div><div><b>'+weapon.cost+' ⚡</b><span>Coste</span></div></div>'+
    '<p class="note sub">Roles: '+arEsc(roles)+'</p><button type="button" class="inspector-open" data-inspector-open>Ver ficha y 3D ampliado →</button></div></article>';
}

function arDeployableCardHTML(prop){
  const spec={kind:'props',key:prop.key,file:prop.file,label:prop.label,inspect:true};
  return '<article class="catalog-card"><header><span class="tag amber">Juego original</span><span class="catalog-count">'+arEsc(prop.key)+'</span></header>'+
    arCard3dBox(spec,prop.label)+
    '<div class="card-body"><h3>'+arEsc(prop.label)+'</h3><p class="note">'+arEsc(prop.note)+'</p><p class="note sub">Malla '+arEsc(prop.file)+' · Textura '+arEsc(prop.tex)+'</p><button type="button" class="btn ghost" data-au-deployable="'+arEsc(prop.key)+'">🔊 Escuchar sonido</button> <button type="button" class="inspector-open" data-inspector-open>Ver en 3D ampliado →</button></div></article>';
}

function arBindCards(grid){
  const lab=grid.querySelector('[data-glb-lab-open]');
  if(lab)lab.onclick=()=>{if(window.__csnGlbLab&&window.__csnGlbLab.open)window.__csnGlbLab.open('weapons');};
  grid.querySelectorAll('[data-au-file]').forEach(button=>{button.onclick=event=>{event.stopPropagation();auWeaponFile(button.dataset.auFile);};});
  grid.querySelectorAll('[data-au-deployable]').forEach(button=>{button.onclick=event=>{event.stopPropagation();auDeployable(button.dataset.auDeployable);};});
  grid.querySelectorAll('.catalog-card').forEach(card=>{
    card.onclick=()=>{
      const box=card.querySelector('[data-card-spec]');
      const raw=card.dataset.cardSpec||(box&&box.dataset.cardSpec);
      if(raw){try{arOpen(JSON.parse(raw));}catch(error){}}
    };
  });
}

function arBuildFilters(originalCount,csnCount,cats){
  const f=$('#arsFilters');if(!f)return;
  const origin=document.createElement('div');origin.className='seg origin-seg';
  origin.innerHTML=ORIGINS.map(item=>'<button type="button" data-origin-value="'+arEsc(item)+'"'+(item===arsOrigin?' class="on"':'')+'>'+arEsc(item)+(item==='Juego original'?' ('+originalCount+')':item==='CSN'?' ('+csnCount+')':' ('+(originalCount+csnCount)+')')+'</button>').join('');
  origin.querySelectorAll('button').forEach(button=>{button.onclick=()=>{arsOrigin=button.dataset.originValue;buildArsenal();};});
  const row=document.createElement('div');row.className='weapon-filter-row';
  row.innerHTML=cats.map(([cat,count])=>'<button type="button" data-filter-value="'+arEsc(cat)+'"'+(cat===arsFilter?' class="on"':'')+'>'+arEsc(cat)+' ('+count+')</button>').join('');
  row.querySelectorAll('button').forEach(button=>{button.onclick=()=>{arsFilter=button.dataset.filterValue;buildArsenal();};});
  f.replaceChildren(origin,row);
}

const STORE_WEAPON_KEY='csn_store_weapon', STORE_SKIN_KEY='csn_store_skin';
let storeSection='weapons';
const arCoins=()=>typeof window!=='undefined'&&typeof window.coinsGet==='function'?window.coinsGet():500;

function arStoreCard(opts){
  const meta=(opts.meta||[]).map(item=>'<span>'+arEsc(item)+'</span>').join('');
  const art=opts.art?'<img class="store-art" src="'+arEsc(opts.art)+'" alt=""/>':'';
  const on=opts.equipped?' on':'';
  return '<article class="store-card" data-store-kind="'+arEsc(opts.kind)+'" data-store-key="'+arEsc(opts.key)+'">'+art+
    '<div class="store-info"><h3>'+arEsc(opts.title)+'</h3><p>'+arEsc(opts.sub||'')+'</p><div class="store-meta">'+meta+'</div></div>'+
    '<div class="store-buy"><span class="store-price">Incluido · 🪙 '+arCoins()+'</span><button type="button" data-store-equip="'+arEsc(opts.kind)+'" data-store-key="'+arEsc(opts.key)+'" class="'+on.trim()+'">'+(opts.equipped?'Equipado':'Equipar')+'</button></div></article>';
}

function arStoreCards(){
  if(storeSection==='characters'){
    const prefs=loadChars();
    return ORIG_CAST.concat(OWN_CAST).map(char=>{
      const key=char.key||((char.own?'own:':'original:')+char.name);
      const equipped=Object.keys(prefs).some(role=>prefs[role]===char.name||prefs[role]===key);
      return arStoreCard({kind:'character',key,title:char.name,sub:(char.role||'Soldado')+' · '+(char.bio||''),meta:[char.own?'CSN':'Juego original',char.defaultWeapon||'Sin arma'],art:rolePortraitURL(char.role,char)||'assets/ui/icono_original.png',equipped});
    }).join('');
  }
  if(storeSection==='skins'){
    const equipped=lsGet(STORE_SKIN_KEY)||'nacion';
    return Object.entries(SKINS).map(([key,skin])=>arStoreCard({kind:'skin',key,title:skin.name,sub:skin.desc,meta:['Sin pasiva',key==='nacion'?'Bandera y emblema':'Uniforme'],art:'assets/ui/icono_original.png',equipped:key===equipped})).join('');
  }
  const equipped=lsGet(STORE_WEAPON_KEY)||'';
  return Object.entries(WEAPONS).map(([name,weapon])=>arStoreCard({kind:'weapon',key:name,title:name,sub:weapon.note||weapon.real||'',meta:[weapon.cat,weapon.dmg+' daño',weapon.rng+' casillas',weapon.cost+' ⚡'],art:weaponCoverURL(name)||'assets/ui/icono_original.png',equipped:name===equipped})).join('');
}

function arStoreEquip(button){
  const kind=button.dataset.storeEquip,key=button.dataset.storeKey;
  if(kind==='weapon')lsSet(STORE_WEAPON_KEY,key);
  else if(kind==='skin'){
    lsSet(STORE_SKIN_KEY,key);
    if(typeof window!=='undefined'&&window.setup)window.setup.skinA=key;
    if(typeof window!=='undefined'&&typeof window.syncSkinSegs==='function')window.syncSkinSegs();
    if(typeof window!=='undefined'&&typeof window.buildSquads==='function')window.buildSquads();
  } else {
    const char=ORIG_CAST.concat(OWN_CAST).find(item=>(item.key||((item.own?'own:':'original:')+item.name))===key);
    if(char&&char.role){const prefs=loadChars();prefs[char.role]=char.name;saveChars(prefs);setCHAR_PREFS(prefs);}
  }
  toast((kind==='weapon'?'Arma':kind==='skin'?'Skin':'Personaje')+' equipado: '+key+'.');
  arRenderStore();
}

function arRenderStore(){
  const cats=$('#storeCats');
  if(cats&&!cats._bound){
    cats._bound=true;
    cats.querySelectorAll('button[data-store-cat]').forEach(button=>{button.onclick=()=>{storeSection=button.dataset.storeCat;arRenderStore();};});
  }
  if(cats)cats.querySelectorAll('button').forEach(button=>button.classList.toggle('on',button.dataset.storeCat===storeSection));
  const coin=$('#arsCoins');if(coin)coin.textContent='🪙 '+arCoins();
  const barrCoin=$('#barrCoins');if(barrCoin)barrCoin.textContent='🪙 '+arCoins();
  const grid=$('#storeGrid');if(!grid)return;
  grid.innerHTML=arStoreCards()||'<p class="store-empty">No hay artículos en esta categoría.</p>';
  grid.querySelectorAll('[data-store-equip]').forEach(button=>{button.onclick=()=>arStoreEquip(button);});
}

export function buildDeployables(){
  const grid=$('#deployableGrid');if(!grid)return;
  grid.innerHTML=DEPLOYABLES.map(arDeployableCardHTML).join('');
  arBindCards(grid);arScan();
}

function arSetSection(section){
  arsSection=section==='deployables'?'deployables':section==='abilities'?'abilities':'weapons';
  const sectionSeg=$('#arsSectionSeg');if(sectionSeg)sectionSeg.querySelectorAll('button').forEach(button=>button.classList.toggle('on',button.dataset.arssec===arsSection));
  const weapons=$('#arsenalGrid'),deployables=$('#deployablePanel'),filters=$('#arsFilters'),abilityPanel=$('#abilityPanel');
  if(weapons)weapons.style.display=arsSection==='weapons'?'':'none';
  if(deployables)deployables.style.display=arsSection==='deployables'?'':'none';
  if(filters)filters.style.display=arsSection==='weapons'?'':'none';
  if(abilityPanel)abilityPanel.style.display=arsSection==='abilities'?'':'none';
}

export function buildArsenal(){
  arRenderStore();
  const sectionSeg=$('#arsSectionSeg');
  if(sectionSeg&&!sectionSeg._bound){
    sectionSeg._bound=true;
    sectionSeg.querySelectorAll('button[data-arssec]').forEach(button=>{button.onclick=()=>arSetSection(button.dataset.arssec);});
  }
  const originalFiles=Object.keys(WEAPONS_ORIGINAL);
  const csnEntries=Object.entries(WEAPONS);
  const catCounts=CATS.map(cat=>[cat,originalFiles.filter(file=>arCategoryHit((WEAPONS_ORIGINAL[file]||{}).cat||'Otros',cat)).length+csnEntries.filter(([,w])=>arCategoryHit(w.cat,cat)).length]);
  arBuildFilters(originalFiles.length,csnEntries.length,catCounts);
  const grid=$('#arsenalGrid');if(grid){
    const originals=originalFiles.filter(file=>{
      const cat=(WEAPONS_ORIGINAL[file]||{}).cat||'Otros';
      return (arsOrigin==='Todas'||arsOrigin==='Juego original')&&arCategoryHit(cat,arsFilter);
    });
    const csn=csnEntries.filter(([name,w])=>(arsOrigin==='Todas'||arsOrigin==='CSN')&&arCategoryHit(w.cat,arsFilter));
    grid.innerHTML='<div class="catalog-head" style="grid-column:1/-1"><h2>Armas</h2><span class="catalog-count">'+originalFiles.length+' originales · '+csnEntries.length+' CSN</span>'+
      '<button type="button" class="btn ghost glb-lab-open" data-glb-lab-open>📥 Probar arma .glb</button></div>'+
      originals.map(arOriginalCardHTML).join('')+csn.map(([name,w])=>arCsnCardHTML(name,w)).join('');
    arBindCards(grid);
  }
  buildDeployables();arSetSection(arsSection);arScan();
  const rt=$('#rolesTable');
  if(rt)rt.innerHTML=ROLE_NAMES.map(role=>{
    const body=BODIES[ROLES[role].body];
    return '<div style="display:flex;gap:10px;padding:9px 0;border-bottom:1px dashed var(--line);flex-wrap:wrap;align-items:center"><span class="role-dot" style="background:'+ROLES[role].color+';margin-top:5px"></span>'+(rolePortraitURL(role)?'<img class="role-thumb" src="'+rolePortraitURL(role)+'" alt="Retrato del '+role+'"/>':'')+'<b style="min-width:120px">'+role+'</b><span class="mono" style="font-size:13.5px">'+body.name+' · '+roleLook(role).silueta+' · '+body.hp+' PV · '+body.energy+' ⚡ · mover '+body.moveCost+' ⚡/casilla</span><span style="flex:1;min-width:220px" class="sub">'+ROLES[role].desc+' Armas: '+ROLES[role].weapons.join(', ')+'.</span></div>';
  }).join('');
}

export function openDeployable3D(key){
  const prop=DEPLOYABLES.find(item=>item.key===key);
  if(!prop)return false;
  arOpen({kind:'props',key:prop.key,file:prop.file,label:prop.label,inspect:true});
  return true;
}

if(typeof window!=='undefined'&&!window.openDeployable3D)window.openDeployable3D=openDeployable3D;
