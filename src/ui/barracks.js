import { BODIES, ROLES } from '../data/roles.js';
import { WEAPONS } from '../data/weapons.js';
import { ORIG_CAST, OWN_CAST } from '../data/cast.js';
import { lsGet, lsSet } from '../core-and-audio.js';
import { CAST_BODIES, CHAR_PREFS, charsForRole, loadChars, setCHAR_PREFS } from '../game/chars.js';
import { rolePortraitURL, showScreen } from './ui-shell.js';
import { ABILITY_CATALOG, ABILITY_IMPL, CLASS_LABEL } from './abilities.js';

export const COINS_KEY='radsoldiers_coins';

export function armTab(which){
  const esArmas=which!=='habilidades';
  document.querySelectorAll('#armTabSeg button').forEach(x=>x.classList.toggle('on',x.dataset.armtab===(esArmas?'armas':'habilidades')));
  const f=document.getElementById('arsFilters'),g=document.getElementById('arsenalGrid'),ap=document.getElementById('abilityPanel');
  if(f)f.style.display=esArmas?'':'none';
  if(g)g.style.display=esArmas?'':'none';
  if(ap)ap.style.display=esArmas?'none':'';
}

export function renderAbilityCatalog(){
  const el=document.getElementById('abilityCatalog');if(!el)return;
  el.innerHTML=ABILITY_CATALOG.map(a=>{
    const imp=ABILITY_IMPL[a.f];
    return '<div class="ab-card'+(imp?' on':'')+'"><img src="assets/ui/ability/'+a.f+'.png" alt=""/><b>'+a.n+'</b><small>'+(imp?('en juego · '+imp):'pendiente')+'</small></div>';
  }).join('');
}

export function renderBarracks(){
  const el=document.getElementById('barrContent'),nt=document.getElementById('barrNation');
  if(!el)return;
  if(nt)nt.innerHTML=myNation?('<b>'+myNation.name+'</b>'+(myNation.pers?' · '+myNation.pers.name:'')+' · 🪙 '+coinsGet()+' · skins: Estándar, Camuflaje, Clase y Nación'):('Sin nación elegida · 🪙 '+coinsGet());
  const roles=Object.keys(ROLES);
  const catOrder=[];const byCat={};
  Object.entries(WEAPONS).forEach(([name,w])=>{if(!byCat[w.cat]){byCat[w.cat]=[];catOrder.push(w.cat);}byCat[w.cat].push(name+' ('+w.dmg+'/'+w.rng+')');});
  setCHAR_PREFS(loadChars());
  /* Tropas: la pantalla principal del Cuartel, visual, con el retrato del
     modelo real de cada rol y su selector de personaje. */
  const troops=roles.map(r=>{
    const body=BODIES[ROLES[r].body];
    const opts=charsForRole(r);
    const cur=(CHAR_PREFS[r]||(opts[0]&&opts[0].name)||'');
    const current=opts.find(o=>o.name===cur)||opts[0];
    const sel='<select data-charrole="'+r+'" class="barrack-sel">'+opts.map(o=>'<option'+(o.name===cur?' selected':'')+'>'+o.name+'</option>').join('')+'</select>';
    return '<div class="panel barrack-card"><img class="barrack-portrait" src="'+(rolePortraitURL(r,current)||'assets/ui/retrato_capitan.png')+'" alt="Retrato de '+r+'"/><div class="barrack-info"><h3>'+r+'</h3><p class="sub" style="margin:0">'+body.name+' · '+ROLES[r].weapons.length+' armas</p>'+sel+'<p class="sub tiny">'+ROLES[r].special+'</p></div></div>';
  }).join('');
  const cast=CAST_BODIES().map(body=>{
    const list=OWN_CAST.concat(ORIG_CAST).filter(c=>c.body===body);
    if(!list.length)return '';
    return '<h3 style="margin:12px 0 4px;font-size:14px">'+(CLASS_LABEL[body]||body)+' <span class="sub" style="font-size:12px">· '+list.length+'</span></h3><div class="grid3">'+
      list.map(c=>'<div class="panel" style="'+(c.play?'border-color:var(--amber)':'opacity:.75')+'"><b style="font-size:13px">'+(c.own?'★ ':'')+c.name+'</b><p class="sub" style="margin:2px 0 0;font-size:11px">'+c.body+' · '+c.outfit+'</p>'+(c.bio?'<p class="sub" style="margin:3px 0 0;font-size:11px;opacity:.9">'+c.bio+'</p>':'')+(c.play?'<span class="tag amber" style="margin-top:4px">jugable · '+c.role+(c.own?' · propio':'')+'</span>':'<span class="tag" style="margin-top:4px">pendiente</span>')+'</div>').join('')+
      '</div>';
  }).join('');
  el.innerHTML=
    '<div class="panel" style="margin-top:12px"><h2>Tus tropas</h2><p class="sub" style="margin:0 0 6px">Un personaje por rol. El retrato es el modelo del juego con su uniforme.</p><div class="barrack-grid">'+troops+'</div></div>'+
    '<details class="more" style="margin-top:12px"><summary>Reparto completo · '+(OWN_CAST.length+ORIG_CAST.length)+' personajes</summary>'+cast+'</details>'+
    '<details class="more" style="margin-top:12px"><summary>Arsenal · '+Object.keys(WEAPONS).length+' armas por categoría</summary>'+
      catOrder.map(c=>'<p class="sub" style="margin:6px 0 0"><b>'+c+'</b>: '+byCat[c].join(' · ')+'</p>').join('')+
    '</details>'+
    '<details class="more" style="margin-top:12px"><summary>Desbloqueos</summary><p class="sub" style="margin:6px 0 0">Skins: <b>Estándar</b>, <b>Camuflaje</b>, <b>Clase</b> y <b>Nación</b> (ninguna tiene pasivas). Monedas: <b>🪙 '+coinsGet()+'</b> (25 por victoria contra la IA). Armas: todas disponibles al configurar la partida.</p></details>';
}

export function openBarracks(){renderBarracks();showScreen('scr-barracks');}

export function coinsGet(){return Math.max(0,parseInt(lsGet(COINS_KEY)||'500',10)||0);}

export function coinsSet(n){lsSet(COINS_KEY,String(Math.max(0,n)));const t=document.getElementById('coinsTag');if(t)t.textContent='🪙 '+coinsGet();}
