import { BODIES, ROLES } from '../data/roles.js';
import { WEAPONS } from '../data/weapons.js';
import { ORIG_CAST, OWN_CAST, MESHY_CAST, CHARACTER_ABILITIES } from '../data/cast.js';
import { SKINS } from '../data/nations.js';
import { lsGet, lsSet } from '../core-and-audio.js';
import { WEAPONS_ORIGINAL, WEAPON_MESH_FILE, originalWeaponProfile } from '../render3d/assets-weapons.js';
import { CAST_BODIES, CHAR_PREFS, charsForRole, loadChars, setCHAR_PREFS } from '../game/chars.js';
import { rolePortraitURL, showScreen } from './ui-shell.js';
import { ABILITY_CATALOG, ABILITY_IMPL, CLASS_LABEL } from './abilities.js';
import { setArsSection } from './arsenal.js';
import { scanCardBoxes } from '../viewer/card-stage.js';

export const COINS_KEY='radsoldiers_coins';
const BARR_WEAPON_KEY='csn_store_weapon', BARR_SKIN_KEY='csn_store_skin';
let barrRole='',barrChar='',barrFocus='arma';

export function armTab(which){
  setArsSection(which==='habilidades'?'abilities':'weapons');
}

export function renderAbilityCatalog(){
  const el=document.getElementById('abilityCatalog');if(!el)return;
  el.innerHTML=ABILITY_CATALOG.map(a=>{
    const imp=ABILITY_IMPL[a.f];
    return '<div class="ab-card'+(imp?' on':'')+'"><img src="assets/ui/ability/'+a.f+'.png" alt=""/><b>'+a.n+'</b><small>'+(imp?('en juego · '+imp):'pendiente')+'</small></div>';
  }).join('');
}

function barrKey(role,name){
  const idx=ORIG_CAST.findIndex(c=>c.name===name&&(!role||c.role===role));
  if(idx>=0)return 'original:'+String(idx+1).padStart(2,'0');
  const meshy=MESHY_CAST.find(c=>c.name===name||c.label===name);
  if(meshy)return meshy.key;
  const fallback=ORIG_CAST.findIndex(c=>c.role===role);
  return 'original:'+String(Math.max(0,fallback)+1).padStart(2,'0');
}

function barrWeaponFor(char){
  const saved=lsGet(BARR_WEAPON_KEY);
  return saved||(char&&char.defaultWeapon)||(ROLES[barrRole]&&ROLES[barrRole].weapons[0])||'M4A1';
}

function barrDetail(char,weapon){
  if(barrFocus==='arma'){
    const file=WEAPON_MESH_FILE[weapon]||weapon;
    const profile=originalWeaponProfile(file);
    return 'Arma: '+((WEAPONS_ORIGINAL[file]||{}).name||weapon)+' · '+(profile&&profile.actionLabel||'sin acción registrada');
  }
  if(barrFocus==='habilidad'){
    const list=CHARACTER_ABILITIES[char&&char.name]||[];
    return list.length?('Habilidad: '+list[0].n+' · '+list[0].d):'Habilidad: este personaje no tiene una habilidad propia registrada.';
  }
  if(barrFocus==='skin'){
    const key=lsGet(BARR_SKIN_KEY)||'nacion';
    return 'Skin: '+(SKINS[key]&&SKINS[key].name||key)+' · '+(SKINS[key]&&SKINS[key].desc||'');
  }
  const body=BODIES[ROLES[barrRole].body];
  return 'Estadísticas: '+body.name+' · '+body.hp+' PV · '+body.energy+' ⚡ · mover '+body.moveCost+' ⚡/casilla.';
}

export function renderBarracks(){
  const el=document.getElementById('barrContent'),nt=document.getElementById('barrNation');
  if(!el)return;
  setCHAR_PREFS(loadChars());
  if(!barrRole||!barrChar){
    const role=Object.keys(CHAR_PREFS)[0]||'Comando';
    const opts=charsForRole(role);
    barrRole=role;barrChar=CHAR_PREFS[role]||(opts[0]&&opts[0].name)||'Hipster Dave';
  }
  const opts=charsForRole(barrRole);
  const char=opts.find(c=>c.name===barrChar)||opts[0]||ORIG_CAST[0];
  if(nt)nt.innerHTML=myNation?('<b>'+myNation.name+'</b>'+(myNation.pers?' · '+myNation.pers.name:'')+' · 🪙 '+coinsGet()+' · skins: Estándar, Camuflaje, Clase y Nación'):('Sin nación elegida · 🪙 '+coinsGet());
  const coin=document.getElementById('barrCoins');if(coin)coin.textContent='🪙 '+coinsGet();
  const weapon=barrWeaponFor(char),file=WEAPON_MESH_FILE[weapon]||weapon;
  const specKey=barrKey(barrRole,char.name);
  const viewerEntry=typeof window!=='undefined'&&window.__csnViewer&&window.__csnViewer.getEntry?window.__csnViewer.getEntry(specKey):null;
  const spec={kind:'roles',key:specKey,skinIndex:0,weapon,file:(viewerEntry&&viewerEntry.file)||char.file||char.mesh||'',label:char.name,inspect:true};
  const specAttr='data-card-spec=\''+JSON.stringify(spec).replace(/'/g,'&#39;')+'\'';
  const picks=Object.keys(ROLES).map(role=>charsForRole(role).map(c=>{
    const on=c.name===char.name?' on':'';
    return '<button type="button" class="barracks-pick'+on+'" data-charrole="'+role+'" data-charname="'+c.name+'" aria-pressed="'+(on?'true':'false')+'"><img src="'+(rolePortraitURL(role,c)||'assets/ui/retrato_capitan.png')+'" alt=""/><span>'+c.name+'</span></button>';
  }).join('')).join('');
  const round=[['arma','🔫'],['habilidad','✦'],['skin','🎨'],['stats','📊']].map(([key,icon])=>{
    const label={arma:'Arma',habilidad:'Habilidad',skin:'Skin',stats:'Estadísticas'}[key];
    return '<button type="button" data-barr-focus="'+key+'" class="'+(barrFocus===key?'on':'')+'" title="'+label+'" aria-label="'+label+'">'+icon+'</button>';
  }).join('');
  const catOrder=[];const byCat={};
  Object.entries(WEAPONS).forEach(([name,w])=>{if(!byCat[w.cat]){byCat[w.cat]=[];catOrder.push(w.cat);}byCat[w.cat].push(name+' ('+w.dmg+'/'+w.rng+')');});
  const cast=CAST_BODIES().map(body=>{
    const list=OWN_CAST.concat(ORIG_CAST).filter(c=>c.body===body);
    if(!list.length)return '';
    return '<h3 style="margin:12px 0 4px;font-size:14px">'+(CLASS_LABEL[body]||body)+' <span class="sub" style="font-size:12px">· '+list.length+'</span></h3><div class="grid3">'+
      list.map(c=>'<div class="panel" style="'+(c.play?'border-color:var(--amber)':'opacity:.75')+'"><b style="font-size:13px">'+(c.own?'★ ':'')+c.name+'</b><p class="sub" style="margin:2px 0 0;font-size:11px">'+c.body+' · '+c.outfit+'</p>'+(c.bio?'<p class="sub" style="margin:3px 0 0;font-size:11px;opacity:.9">'+c.bio+'</p>':'')+(c.play?'<span class="tag amber" style="margin-top:4px">jugable · '+c.role+(c.own?' · propio':'')+'</span>':'<span class="tag" style="margin-top:4px">pendiente</span>')+'</div>').join('')+
      '</div>';
  }).join('');
  el.innerHTML=
    '<div class="barracks-hero"><div class="barracks-stage"><div class="card-3d-box" '+specAttr+' aria-label="Modelo 3D de '+char.name+'"><img class="card-3d-thumb is-loading" alt="" hidden/><span class="card-3d-badge">3D</span></div></div>'+
    '<div class="barracks-id"><span class="kicker">'+barrRole+'</span><h2>'+char.name+'</h2><p class="sub">'+(char.bio||'')+'</p><p class="barr-weapon">🔫 '+barrWeaponFor(char)+'</p>'+
    '<div class="barracks-round">'+round+'</div><div class="barrack-detail">'+barrDetail(char,weapon)+'</div></div></div>'+
    '<div class="barracks-picks" aria-label="Seleccionar personaje">'+picks+'</div>'+
    '<div class="barracks-secondary">'+
      '<details class="more"><summary>Reparto completo · '+(OWN_CAST.length+ORIG_CAST.length)+' personajes</summary>'+cast+'</details>'+
      '<details class="more"><summary>Arsenal · '+Object.keys(WEAPONS).length+' armas por categoría</summary>'+
        catOrder.map(c=>'<p class="sub" style="margin:6px 0 0"><b>'+c+'</b>: '+byCat[c].join(' · ')+'</p>').join('')+
      '</details>'+
      '<details class="more"><summary>Desbloqueos</summary><p class="sub" style="margin:6px 0 0">Skins: <b>Estándar</b>, <b>Camuflaje</b>, <b>Clase</b> y <b>Nación</b> (ninguna tiene pasivas). Monedas: <b>🪙 '+coinsGet()+'</b> (25 por victoria contra la IA). Armas: todas disponibles al configurar la partida.</p></details>'+
    '</div>';
  const stage=el.querySelector('.barracks-stage .card-3d-box');
  scanCardBoxes(el);
  const mount=()=>{
    if(!stage||!stage.isConnected)return;
    const engine=typeof window!=='undefined'&&window.__csnCardEngine;
    if(engine&&engine.activate)engine.activate(stage,spec);
    else setTimeout(mount,200);
  };
  mount();
  el.querySelectorAll('.barracks-pick').forEach(button=>{button.onclick=()=>{
    barrRole=button.dataset.charrole;barrChar=button.dataset.charname;
    const prefs=loadChars();prefs[barrRole]=barrChar;saveChars(prefs);setCHAR_PREFS(prefs);
    renderBarracks();if(typeof window!=='undefined'&&typeof window.buildSquads==='function')window.buildSquads();
  };});
  el.querySelectorAll('[data-barr-focus]').forEach(button=>{button.onclick=()=>{barrFocus=button.dataset.barrFocus;renderBarracks();};});
  if(stage)stage.onclick=()=>{const engine=typeof window!=='undefined'&&window.__csnCardEngine;if(engine&&engine.activate)engine.activate(stage,spec);};
}

export function openBarracks(){renderBarracks();showScreen('scr-barracks');}

export function coinsGet(){return Math.max(0,parseInt(lsGet(COINS_KEY)||'500',10)||0);}

export function coinsSet(n){lsSet(COINS_KEY,String(Math.max(0,n)));const t=document.getElementById('coinsTag');if(t)t.textContent='🪙 '+coinsGet();const b=document.getElementById('barrCoins');if(b)b.textContent='🪙 '+coinsGet();const a=document.getElementById('arsCoins');if(a)a.textContent='🪙 '+coinsGet();}
