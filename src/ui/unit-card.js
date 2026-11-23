import { BODIES, ROLES } from '../data/roles.js';
import { WEAPONS } from '../data/weapons.js';
import { CAMPAIGN_MISSIONS } from '../data/maps.js';
import { SKINS } from '../data/nations.js';
import { cheb, dist } from '../core/geometry.js';
import { ARGON_READY, ROLE_SVG_ID, spriteDataURI } from '../render2d/sprites.js';
import { draw } from '../render2d/board.js';
import { getRealSpriteURL } from '../render3d/real-sprites.js';
import { WEAPON_MESH_FILE, WEAPON_COVER_BY_FILE, WEAPONS_ORIGINAL } from '../render3d/assets-weapons.js';
import { inBeacon, obAt } from '../game/board.js';
import { aliveCount, canHealSpecial, canReviveSpecial, canSnipeSpecial, selectUnit, setOverwatch, teamName, unitHasAction } from '../game/combat.js';
import { MINE_COST, MINE_DMG, captureTurret, useSpecial } from '../game/missions.js';
import { tutorialCheck, tutorialEvent } from '../game/tutorial.js';
import { ARTY_COST, ARTY_DMG, ARTY_RANGE, BEES_COST, BEES_DMG, BEES_RANGE, BEES_TURNS, COVER_COST, CRATE_COST, GAS_COST, GAS_DMG, GAS_TURNS, MOLOTOV_COST, MOLOTOV_DMG, MOLOTOV_TURNS, ORB_COST, ORB_DMG, ORB_RANGE, SHIELD_COST, SWEEP_COST, SWEEP_RANGE, TELE_COST, TELE_RANGE, TOOL_COST, TOOL_HEAL, TOOL_RANGE, TRANQ_COST, TRANQ_RANGE, WATER_COST, WATER_PUSH, WATER_RANGE, useShield, useToolkit } from '../game/gadgets.js';
import { $, DOM_MAX_ROUNDS, DOM_TARGET, ESCORT_GUIDES_PER_ROUND, ESCORT_MAX_ROUNDS, domControl, domZones, effMode, escortExt, flagHTML, emblemHTML, rolePortraitURL, setStep, syncPlayingViewport, toast } from './ui-shell.js';
import { vitalsMarkup } from './arcade-hud.js';
import { ABILITY_IMPL } from './abilities.js';

export function updateUI(){
  if(!G)return;
  tutorialCheck(G);
  const pill=$('#turnPill');
  pill.className='turn-pill '+G.turn;
  pill.textContent=G.over?'Partida terminada':'Turno: '+teamName(G.turn)+(G.aiBusy?' · la IA está jugando…':'');
  $('#roundLabel').textContent='Ronda '+G.round+(effMode(G)==='dominacion'?(' / '+DOM_MAX_ROUNDS):effMode(G)==='escolta'?(' / '+ESCORT_MAX_ROUNDS):'')+' · '+G.map.name+' · '+(effMode(G)==='eliminacion'?'Eliminación':effMode(G)==='dominacion'?'Dominación':effMode(G)==='escolta'?'Escolta del dron':G.mode==='guerra'?'Guerra de Naciones':G.mode==='tutorial'||G.isTutorial?('Instrucción de Dave'):G.mode==='campana'?('Campaña · Misión '+(G.campaignMission+1)+' · '+CAMPAIGN_MISSIONS[G.campaignMission].title):'Captura de baliza')+(G.opp==='ia'?(' · IA '+G.difficulty):'')+' · Quedan '+aliveCount('A')+' contra '+aliveCount('B');
  $('#hudScoreA').textContent='J1 · '+aliveCount('A');
  $('#hudScoreB').textContent='RIVAL · '+aliveCount('B');
  const squadTitle=$('#hudSquadTitle');if(squadTitle)squadTitle.textContent=teamName(G.turn);
  const vitals=$('#squadVitals');
  if(vitals){
    vitals.innerHTML=vitalsMarkup(G.units,G.turn,G.selected,ROLES);
    vitals.onclick=e=>{
      const btn=e.target&&e.target.closest?e.target.closest('[data-hud-unit]'):null;
      if(!btn)return;
      const u=G.units[+btn.dataset.hudUnit];
      if(u&&u.alive&&u.team===G.turn&&!G.aiBusy){selectUnit(u);tutorialEvent('select',{unit:u});}
    };
  }
  setStep('battle',(G.over?'Partida terminada':'Ronda '+G.round+' · '+teamName(G.turn))+(G.aiBusy?' · IA pensando':''));
  const bm=$('#beaconMeter');
  if(effMode(G)!=='baliza'){bm.style.display='none';}
  else{bm.style.display='flex';bm.innerHTML='<span style="color:var(--teamA)">J1</span>'+[0,1,2,3,4].map(i=>'<i class="pip '+(G.beacon.A>i?'full':'')+'"></i>').join('')+'<span style="margin-left:8px;color:var(--teamB)">Rival</span>'+[0,1,2,3,4].map(i=>'<i class="pip '+(G.beacon.B>i?'full':'')+'"></i>').join('');}
  const dm=$('#domMeter');
  if(dm){if(effMode(G)!=='dominacion'){dm.style.display='none';}else{dm.style.display='flex';dm.innerHTML='<span>⬢ Dominación · primero a '+DOM_TARGET+'</span><span class="dom-zone '+(G.dom.A>=G.dom.B?'A':'')+'">J1 '+G.dom.A+' pts</span><span class="dom-zone '+(G.dom.B>G.dom.A?'B':'')+'">Rival '+G.dom.B+' pts</span>'+domZones().map(z=>{const c=domControl(z);return '<span class="dom-zone '+(c||'N')+'">'+z.name+': '+(c==='A'?'J1':c==='B'?'Rival':'en disputa')+'</span>';}).join('');}}
  const em=$('#escortMeter');
  if(em){if(effMode(G)!=='escolta'||!G.drone){em.style.display='none';}else{em.style.display='flex';const dd=Math.min.apply(null,escortExt().map(t2=>cheb(G.drone,t2)));em.innerHTML='<span>🤖 Escolta · la defensa aguanta '+ESCORT_MAX_ROUNDS+' rondas</span><span class="dom-zone '+(G.drone.hp>G.drone.maxHp*0.35?'A':'B')+'">Dron '+G.drone.hp+'/'+G.drone.maxHp+' PV</span>'+(G.drone.alive?('<span class="dom-zone N">⇪ a '+dd+' casillas de la extracción</span><span class="dom-zone N">Guiados esta ronda: '+(ESCORT_GUIDES_PER_ROUND-G.drone.movesLeft)+'/'+ESCORT_GUIDES_PER_ROUND+'</span>'):'<span class="dom-zone B">Dron destruido</span>');}}
  $('#endTurnBtn').disabled=G.aiBusy||G.over;
  const ub=$('#undoBtn');if(ub)ub.disabled=G.aiBusy||G.over||!G.lastMoveUndo||(G.opp==='ia'&&G.turn==='B');
  /* roster */
  const r=$('#roster');r.innerHTML='';
  G.units.forEach(u=>{
    const b=document.createElement('button');
    b.className=(G.selected===u?'sel':'')+(u.alive?'':' dead');
    b.innerHTML=(rolePortraitURL(u.role,u)?'<img class="roster-portrait" src="'+rolePortraitURL(u.role,u)+'" alt=""/>':'')+'<span class="role-dot" style="background:'+ROLES[u.role].color+'"></span><span style="flex:none"><b>'+u.role+'</b>'+(u.name&&u.name!==u.role?'<br><small style="color:var(--muted)">'+u.name+'</small>':'')+((u.alive?[u.stunned?'💫':(u.invisible?'👻':''),u.overwatch?'👁':'',u.suppressed?'⚡':'',((u.beesT||0)>0)?'🐝':'',((u.shieldT||0)>0)?'🛡':'',(u.hp<=u.maxHp*0.35?'🩹':'')]:[]).filter(Boolean).length?'<br><small title="estados">'+[u.stunned?'💫':(u.invisible?'👻':''),u.overwatch?'👁':'',u.suppressed?'⚡':'',((u.beesT||0)>0)?'🐝':'',((u.shieldT||0)>0)?'🛡':'',(u.hp<=u.maxHp*0.35?'🩹':'')].filter(Boolean).join('')+'</small>':'')+(u.vetLevel?'<span class="vet-badge">Vet. '+u.vetLevel+'</span>':'')+' <span style="color:'+(u.team==='A'?'var(--teamA)':'var(--teamB)')+'">●'+u.team+'</span><br><small style="color:var(--muted)">'+u.weapon+' · ⚡'+(u.alive?u.energy:0)+'</small></span><span class="mini-hp"><i style="width:'+Math.round(u.hp/u.maxHp*100)+'%"></i></span><b class="mono" style="font-size:13px">'+(u.alive?u.hp+' PV':'K.O.')+'</b>';
    b.onclick=()=>{if(u.alive&&u.team===G.turn&&!G.aiBusy){selectUnit(u);tutorialEvent('select',{unit:u});}};
    r.appendChild(b);
  });
  /* unit card */
  const u=G.selected,card=$('#unitCard');
  if(!u){card.innerHTML='<h3>Sin selección</h3><p class="sub">Toca uno de tus soldados.</p>';$('#weaponInfo').textContent='—';return;}
  const w=WEAPONS[u.weapon];
  const isTurn=u.team===G.turn&&u.alive&&!G.aiBusy&&!G.over;
  const onTurret=u.x===TURRET_POS.x&&u.y===TURRET_POS.y;
  /* HUD del original: icono de clase, vida, energía, habilidades y carátula del arma. */
  const ROLE_CLASS_ICON={Francotirador:'Soldier',Artillero:'Soldier',Espía:'Agent',Médico:'Medic',Ingeniero:'Engineer',Comando:'Soldier',Capitán:'Commander'};
  const classIco=ROLE_CLASS_ICON[u.role]||'Soldier';
  const charAbs=u.charAbilities||[];
  const abBg=u.team==='A'?'assets/ui/orig/CharAbility_background_blue.png':'assets/ui/orig/CharAbility_background_red.png';
  const abChips=charAbs.map(a=>'<span class="ab-chip" style="background-image:url(\''+abBg+'\');'+(a.implemented?'':'opacity:.58')+'" title="'+a.n+' · '+a.d+(a.implemented?' · en juego · '+ABILITY_IMPL[a.icon]:' · solo informativo (aún no implementada)')+'"><img class="ab-ico" src="assets/ui/ability/'+a.icon+'.png" alt=""/>'+a.n+(a.implemented?'':' ℹ')+'</span>').join('');
  const wpMesh=(typeof WEAPON_MESH_FILE!=='undefined'?WEAPON_MESH_FILE[u.weapon]:null);
  const wpCover=wpMesh&&typeof WEAPON_COVER_BY_FILE!=='undefined'&&WEAPON_COVER_BY_FILE[wpMesh]?'<img class="wp-cover" src="assets/weapons/covers/'+WEAPON_COVER_BY_FILE[wpMesh]+'.png" alt=""/>':'';
  const wpOrig=wpMesh&&typeof WEAPONS_ORIGINAL!=='undefined'&&WEAPONS_ORIGINAL[wpMesh]?WEAPONS_ORIGINAL[wpMesh].name:null;
  let tileCov=0;[[1,0],[-1,0],[0,1],[0,-1]].forEach(dd=>{const o=obAt(u.x+dd[0],u.y+dd[1]);if(!o)return;const lv=o.type==='wall'||o.type==='shelf'?3:(o.type==='crate'?(o.hp>o.maxHp/2?2:1):0);if(lv>tileCov)tileCov=lv;});
  const covIco=tileCov>0?'<img class="cov-ico" src="assets/ui/orig/hud_icon_emote_cover'+(tileCov*25)+'.png" alt=""/>':'';
  const covTxt=tileCov>0?' · '+covIco+' Cobertura '+tileCov+' (−'+[0,12,25,40][tileCov]+'%)':'';
  const resBits=['Granadas M67: '+u.grenades];
  if(unitHasAction(u,'crate'))resBits.push('Cajas de salud: '+(u.crates||0));
  if(canHealSpecial(u))resBits.push('Curaciones: '+u.heals);
  if(canReviveSpecial(u))resBits.push('Reanimación: '+u.revives);
  if(unitHasAction(u,'mine'))resBits.push('Claymores M18A1: '+(u.mines||0));
  if(unitHasAction(u,'flash'))resBits.push('Aturdidoras M84: '+(u.flashes||0));
  if(unitHasAction(u,'smoke'))resBits.push('Humo M18: '+(u.smokes||0));
  if(unitHasAction(u,'toolkit'))resBits.push('Kits: '+(u.toolkits||0));
  if(unitHasAction(u,'arty'))resBits.push('Artillería: '+(u.arty||0));
  card.innerHTML=(()=>{const pUrl=rolePortraitURL(u.role,u);if(pUrl)return '<img class="unit-sprite" src="'+pUrl+'" alt="Retrato del '+u.role+'"/>';const rsUrl=getRealSpriteURL(u);if(rsUrl)return '<img class="unit-sprite" src="'+rsUrl+'" alt="Sprite del '+u.role+' renderizado desde el modelo real, en el tablero"/>';return (ARGON_READY&&ROLE_SVG_ID[u.role]?'<img class="unit-sprite" src="'+spriteDataURI(ROLE_SVG_ID[u.role],u.skin,u.nation)+'" alt="Sprite del '+u.role+' en el tablero"/>':'');})()+'<h3><span class="role-dot" style="background:'+ROLES[u.role].color+';width:14px;height:14px"></span><img class="class-ico" src="assets/ui/orig/Class_'+classIco+'_alpha.png" alt=""/>'+u.role+' <span class="sub" style="font-size:12px">'+u.name+'</span> <span style="color:'+(u.team==='A'?'var(--teamA)':'var(--teamB)')+';font-size:15px">'+teamName(u.team)+'</span></h3>'+
   '<div style="display:flex;align-items:center;gap:8px">'+(u.skin==='nacion'?flagHTML(u.nation)+emblemHTML(u.nation)+'<span class="sub">Skin Nación · '+u.nation.name+' · '+u.nation.emblemName+'</span>':'<span class="sub">Skin '+(SKINS[u.skin]?SKINS[u.skin].name:'Estándar')+' · '+(SKINS[u.skin]?SKINS[u.skin].desc:'soldado genérico')+'</span>')+(u.invisible?'<span class="sub">· 👁 invisible este turno</span>':'')+(u.stunned?'<span class="sub" style="color:#e8c84e">· 💫 aturdido por la M84</span>':'')+'</div>'+
   '<div class="hpbar"><i class="'+(u.hp<=u.maxHp*0.3?'low':'')+'" style="width:'+Math.round(u.hp/u.maxHp*100)+'%"></i></div><div class="statline"><img class="hud-ico" src="assets/ui/orig/hud_icon_health.png" alt=""/>Vida <b class="mono">'+u.hp+'/'+u.maxHp+'</b> · Cuerpo '+(BODIES[u.body]?BODIES[u.body].name:u.body)+' · Posición ('+(u.x+1)+','+(u.y+1)+')'+(inBeacon(u.x,u.y)?' · <b style="color:var(--amber)">en la baliza</b>':'') +(u.overwatch?' · <b style="color:var(--amber)">en vigilancia</b>':'')+covTxt+'</div>'+
   '<div class="epips">'+Array.from({length:u.maxEnergy},(_,i)=>'<i class="'+(i<u.energy?'':'off')+'"></i>').join('')+'</div><div class="statline"><img class="hud-ico" src="assets/ui/orig/AP_alpha.png" alt=""/>Energía <b class="mono">'+u.energy+'/'+u.maxEnergy+'</b> · Mover: '+u.moveCost+' ⚡/casilla · '+resBits.join(' · ')+'</div>'+
   (abChips?'<div class="ab-row">'+abChips+'</div>':'')+
   '<div class="actions">'+
   '<button data-act="shoot" class="'+(G.actionMode==='shoot'?'on':'')+'" '+(isTurn?'':'disabled')+' title="'+(w.real||'')+' — '+(w.note||'')+'">'+wpCover+'🎯 Disparar [1] · '+u.weapon+'<small>'+w.dmg+' daño · alcance '+w.rng+' · '+w.cost+' ⚡ — luego toca al enemigo</small></button>'+
   '<button data-act="pistol" class="'+(G.actionMode==='pistol'?'on':'')+'" '+(isTurn?'':'disabled')+'>🔫 Pistola M9 [2]<small>22 daño · alcance 3 · 1 ⚡</small></button>'+
   '<button data-act="grenade" class="'+(G.actionMode==='grenade'?'on':'')+'" '+(isTurn&&u.grenades>0?'':'disabled')+'><img class="ab-ico" src="assets/ui/ability/CharAbility_14_Frag_Grenade_alpha.png" alt=""/>Granada M67 [3]<small>75 daño en área · lanza a 3 · 2 ⚡ · quedan '+u.grenades+'</small></button>'+
       (unitHasAction(u,'smoke')?'<button data-act="smoke" class="'+(G.actionMode==='smoke'?'on':'')+'" '+(isTurn&&(u.smokes||0)>0?'':'disabled')+'>💨 Humo M18<small>Sin daño · lanza a 4 · 2 ⚡ · quedan '+(u.smokes||0)+' · tapa la visión 2 rondas en cruz (radio 1), no el movimiento</small></button>':'')+
       (unitHasAction(u,'flash')?'<button data-act="flash" class="'+(G.actionMode==='flash'?'on':'')+'" '+(isTurn&&(u.flashes||0)>0?'':'disabled')+'><img class="ab-ico" src="assets/ui/ability/CharAbility_09_Concussion_Grenade_alpha.png" alt=""/>Aturdidora M84<small>Sin daño · lanza a 4 · 2 ⚡ · quedan '+(u.flashes||0)+' · aturde en radio 1 durante 1 turno: −6 ⚡ y −25 de puntería, sin fuego de respuesta ni vigilancia · también ciega a los tuyos</small></button>':'')+
   '<button data-act="overwatch" '+(isTurn&&!u.overwatch&&u.energy>=3?'':'disabled')+'>👁 Vigilancia [4]<small>3 ⚡ · dispara gratis al primer enemigo que se mueva a su alcance en el turno rival</small></button>'+
    (unitHasAction(u,'special')?'<button data-act="special" class="'+(G.actionMode==='special'||G.actionMode==='deploy'?'on':'')+'" '+(isTurn?'':'disabled')+'>★ '+((charAbs.find(a=>a.implemented&&a.action==='special')||{}).n||ROLES[u.role].special)+' [5]<small>'+((charAbs.find(a=>a.implemented&&a.action==='special')||{}).d||ROLES[u.role].sdesc)+'</small></button>':'')+

   (effMode(G)!=='dominacion'&&onTurret&&G.map.turret.owner!==u.team?'<button data-act="capture" '+(isTurn&&u.energy>=2?'':'disabled')+'>⚙ Capturar torreta central<small>2 ⚡ · disparará al final de tus turnos</small></button>':'')+
       (unitHasAction(u,'deploy')?'<button data-act="deploy" class="'+(G.actionMode==='deploy'?'on':'')+'" '+(isTurn?'':'disabled')+'>🛠 Torreta M2 (desplegar)<small>5 ⚡ · casilla adyacente · 120 PV</small></button>':'')+
       (unitHasAction(u,'mine')?'<button data-act="mine" class="'+(G.actionMode==='mine'?'on':'')+'" '+(isTurn&&(u.mines||0)>0?'':'disabled')+'>💥 Claymore M18A1<small>'+MINE_COST+' ⚡ · casilla adyacente · quedan '+(u.mines||0)+' · oculta al enemigo · '+MINE_DMG+' de daño a quien la pise</small></button>':'')+
       (unitHasAction(u,'cover')?'<button data-act="cover" class="'+(G.actionMode==='cover'?'on':'')+'" '+(isTurn&&(u.covers||0)>0?'':'disabled')+'>🧱 Cobertura desplegable<small>'+COVER_COST+' ⚡ · casilla adyacente · quedan '+(u.covers||0)+' · 60 PV, estorba el paso y da cobertura</small></button>':'')+
       (unitHasAction(u,'gas')?'<button data-act="gas" class="'+(G.actionMode==='gas'?'on':'')+'" '+(isTurn&&(u.gases||0)>0?'':'disabled')+'><img class="ab-ico" src="assets/ui/ability/CharAbility_15_Gas_Grenade_alpha.png" alt=""/>Granada de gas<small>'+GAS_COST+' ⚡ · lanza a 3 · quedan '+(u.gases||0)+' · nube '+GAS_TURNS+' rondas: '+GAS_DMG+' de daño por turno en radio 1</small></button>':'')+
       (unitHasAction(u,'molotov')?'<button data-act="molotov" class="'+(G.actionMode==='molotov'?'on':'')+'" '+(isTurn&&(u.molotovs||0)>0?'':'disabled')+'><img class="ab-ico" src="assets/ui/ability/CharAbility_50_Molotov_alpha.png" alt=""/>Cóctel molotov<small>'+MOLOTOV_COST+' ⚡ · lanza a 3 · quedan '+(u.molotovs||0)+' · fuego '+MOLOTOV_TURNS+' rondas: '+MOLOTOV_DMG+' por turno en radio 1</small></button>':'')+
       (unitHasAction(u,'crate')?'<button data-act="crate" class="'+(G.actionMode==='crate'?'on':'')+'" '+(isTurn&&(u.crates||0)>0?'':'disabled')+'>✚ Caja de salud<small>'+CRATE_COST+' ⚡ · casilla adyacente · quedan '+(u.crates||0)+' · +75 PV a quien la recoja</small></button>':'')+
       (unitHasAction(u,'teleport')?'<button data-act="teleport" class="'+(G.actionMode==='teleport'?'on':'')+'" '+(isTurn&&(u.teleports||0)>0?'':'disabled')+'>🌀 Teletransporte<small>'+TELE_COST+' ⚡ · salto a '+TELE_RANGE+' casillas · quedan '+(u.teleports||0)+'</small></button>':'')+
       (unitHasAction(u,'shield')?'<button data-act="shield" class="'+(G.actionMode==='shield'?'on':'')+'" '+(isTurn&&(u.shields||0)>0?'':'disabled')+'><img class="ab-ico" src="assets/ui/ability/CharAbility_24_Juggernaut_alpha.png" alt=""/>Escudo antidisturbios<small>'+SHIELD_COST+' ⚡ · quedan '+(u.shields||0)+' · recibe un 55 % del daño el próximo turno</small></button>':'')+
       (unitHasAction(u,'arty')?'<button data-act="arty" class="'+(G.actionMode==='arty'?'on':'')+'" '+(isTurn&&(u.arty||0)>0?'':'disabled')+'><img class="ab-ico" src="assets/ui/ability/CharAbility_43_Support_Fire_alpha.png" alt=""/>Artillería<small>'+ARTY_COST+' ⚡ · lanza a '+ARTY_RANGE+' · quedan '+(u.arty||0)+' · '+ARTY_DMG+' en el centro y 35 en radio 1</small></button>':'')+
       (unitHasAction(u,'bees')?'<button data-act="bees" class="'+(G.actionMode==='bees'?'on':'')+'" '+(isTurn&&(u.bees||0)>0?'':'disabled')+'>🐝 Bomba de abejas<small>'+BEES_COST+' ⚡ · un enemigo a '+BEES_RANGE+' · quedan '+(u.bees||0)+' · '+BEES_DMG+' por turno durante '+BEES_TURNS+'</small></button>':'')+
       (unitHasAction(u,'tranq')?'<button data-act="tranq" class="'+(G.actionMode==='tranq'?'on':'')+'" '+(isTurn&&(u.tranqs||0)>0?'':'disabled')+'>💉 Tranquilizante<small>'+TRANQ_COST+' ⚡ · un enemigo a '+TRANQ_RANGE+' · quedan '+(u.tranqs||0)+' · lo aturde su siguiente turno sin daño</small></button>':'')+
       (unitHasAction(u,'water')?'<button data-act="water" class="'+(G.actionMode==='water'?'on':'')+'" '+(isTurn&&(u.water||0)>0?'':'disabled')+'><img class="ab-ico" src="assets/ui/ability/CharAbility_52_WaterCannon_alpha.png" alt=""/>Cañón de agua<small>'+WATER_COST+' ⚡ · un enemigo a '+WATER_RANGE+' · quedan '+(u.water||0)+' · lo empuja hasta '+WATER_PUSH+' casillas sin daño</small></button>':'')+
       (unitHasAction(u,'toolkit')?'<button data-act="toolkit" '+(isTurn&&(u.toolkits||0)>0?'':'disabled')+'><img class="ab-ico" src="assets/ui/ability/CharAbility_45_Toolkit_alpha.png" alt=""/>Kit de herramientas<small>'+TOOL_COST+' ⚡ · repara '+TOOL_HEAL+' PV a tu torreta desplegada (a '+TOOL_RANGE+' casillas) · quedan '+(u.toolkits||0)+'</small></button>':'')+
       (unitHasAction(u,'deployRocket')?'<button data-act="deployRocket" class="'+(G.actionMode==='deployRocket'?'on':'')+'" '+(isTurn?'':'disabled')+'>🚀 Torreta de cohetes (desplegar)<small>5 ⚡ · casilla adyacente · 100 PV · dispara 60 en el objetivo y 30 en radio 1</small></button>':'')+
       (unitHasAction(u,'orbital')?'<button data-act="orbital" class="'+(G.actionMode==='orbital'?'on':'')+'" '+(isTurn&&(u.orbitals||0)>0?'':'disabled')+'>🛰 Láser orbital<small>'+ORB_COST+' ⚡ · lanza a '+ORB_RANGE+' · quedan '+(u.orbitals||0)+' · '+ORB_DMG+' en una sola casilla, sin salpicadura</small></button>':'')+
       (unitHasAction(u,'sweep')?'<button data-act="sweep" class="'+(G.actionMode==='sweep'?'on':'')+'" '+(isTurn&&(u.sweeps||0)>0?'':'disabled')+'><img class="ab-ico" src="assets/ui/ability/CharAbility_13_Detection_Aura_alpha.png" alt=""/>Barrido detector<small>'+SWEEP_COST+' ⚡ · radio '+SWEEP_RANGE+' · quedan '+(u.sweeps||0)+' · revela invisibles</small></button>':'')+
   (effMode(G)==='escolta'&&G.drone&&G.drone.alive&&u.team==='A'?'<button data-act="guide" class="'+(G.actionMode==='drone'?'on':'')+'" '+(isTurn&&dist(u,G.drone)<=1&&u.energy>=2&&G.drone.movesLeft>0?'':'disabled')+'>🤖 Guiar dron · 2 ⚡<small>Mueve el dron 1 casilla · quedan '+G.drone.movesLeft+' guiados esta ronda · tienes que estar pegado a él — luego toca la casilla destino junto al dron</small></button>':'')+
   '</div>'+(u.team!==G.turn?'<p class="sub" style="margin-top:8px">Este soldado es del bando rival: podrás actuar con él en su turno'+(G.opp==='ia'?' (lo mueve la IA)':'')+'.</p>':'');
  /* Tooltip de cada accion y traslado del bloque a la barra inferior. */
  try{card.querySelectorAll('.actions button').forEach(b=>{const t=(b.getAttribute('title')||'');const txt=b.textContent.replace(/\s+/g,' ').trim();b.title=(t?t+' — ':'')+txt;});}catch(e){}
  try{
    const bar=document.getElementById('actionBar');
    const acts=card.querySelector('.actions');
    if(bar){
      bar.innerHTML='';
      if(acts)bar.appendChild(acts);
      else bar.innerHTML='<p class="sub" style="margin:0">Selecciona un soldado para ver sus acciones.</p>';
    }
  }catch(e){}
  syncPlayingViewport();
  document.querySelectorAll('[data-act]').forEach(b=>b.onclick=()=>{
    const act=b.dataset.act;
    if(act==='shoot'){G.actionMode='shoot';toast('Toca a un enemigo en alcance para disparar con '+u.weapon+'. Pasa el cursor sobre él para ver la puntería.');}
    if(act==='pistol'){G.actionMode='pistol';toast('Toca a un enemigo a 3 casillas o menos para disparar la M9.');}
    if(act==='grenade'){G.actionMode='grenade';tutorialEvent('grenade',{armed:true});toast('Toca la casilla destino de la M67 (máx. 3 casillas).');}
    if(act==='smoke'){G.actionMode='smoke';toast('Toca la casilla centro de la cortina M18 (máx. 4 casillas): tapará esa casilla y las 4 adyacentes durante 2 rondas.');}
    if(act==='mine'){G.actionMode='mine';toast('Toca una casilla adyacente libre para colocar la Claymore: el enemigo no la verá hasta pisarla.');}
    if(act==='flash'){G.actionMode='flash';toast('Toca la casilla donde estallará la M84 (máx. 4 casillas): aturdirá a todo soldado en radio 1, también a los tuyos; solo se salva quien la lanza, que aparta la mirada.');}
    if(act==='cover'){G.actionMode='cover';toast('Toca una casilla adyacente libre para levantar la cobertura (60 PV).');}
    if(act==='gas'){G.actionMode='gas';toast('Toca la casilla central de la nube de gas (máx. 3 casillas).');}
    if(act==='sweep'){G.actionMode='sweep';toast('Toca el centro del barrido (radio '+SWEEP_RANGE+'): revela a los invisibles.');}
    if(act==='molotov'){G.actionMode='molotov';toast('Toca la casilla central del fuego (máx. 3 casillas).');}
    if(act==='crate'){G.actionMode='crate';toast('Toca una casilla adyacente libre para dejar la caja de Salud.');}
    if(act==='teleport'){G.actionMode='teleport';toast('Toca una casilla libre a '+TELE_RANGE+' o menos: el Espía se teletransporta.');}
    if(act==='shield'){useShield(u);}
    if(act==='arty'){G.actionMode='arty';toast('Toca la casilla del bombardeo (máx. '+ARTY_RANGE+' casillas).');}
    if(act==='bees'){G.actionMode='bees';toast('Toca a un enemigo a '+BEES_RANGE+' casillas o menos.');}
    if(act==='tranq'){G.actionMode='tranq';toast('Toca a un enemigo a '+TRANQ_RANGE+' casillas o menos: queda aturdido su siguiente turno.');}
    if(act==='water'){G.actionMode='water';toast('Toca a un enemigo a '+WATER_RANGE+' casillas o menos: lo empuja sin daño.');}
    if(act==='toolkit'){useToolkit(u);}
    if(act==='deployRocket'){G.actionMode='deployRocket';toast('Toca una casilla adyacente libre: la torreta de cohetes dispara a 6 casillas con salpicadura.');}
    if(act==='orbital'){G.actionMode='orbital';toast('Toca la casilla del láser orbital (máx. '+ORB_RANGE+' casillas): 80 de daño exacto en esa casilla.');}
    if(act==='overwatch'){setOverwatch(u);}
    if(act==='special'){useSpecial(u,null);}
    if(act==='capture'){captureTurret(u);}
    if(act==='deploy'){useSpecial(u,null);}
    if(act==='guide'){G.actionMode='drone';toast('Toca una casilla libre pegada al dron para moverlo ahí: cuesta 2 ⚡ de '+u.role+' y cuenta como uno de los '+ESCORT_GUIDES_PER_ROUND+' guiados de la ronda.');}
    updateUI();draw();
  });
  $('#weaponInfo').innerHTML=(wpCover?'<div style="display:flex;align-items:center;gap:10px;margin-bottom:6px">'+wpCover+'<span><b style="color:var(--ink)">'+u.weapon+'</b>'+(wpOrig?' <span class="sub">· original: '+wpOrig+'</span>':'')+'</span></div>':'')+'<b style="color:var(--ink)">'+u.weapon+'</b> · '+w.cat+'<br>'+w.real+'<br><span style="color:var(--ink)">En el juego:</span> '+w.dmg+' daño · alcance '+w.rng+' casillas · '+w.cost+' ⚡. '+w.note+'<br><br><b style="color:var(--ink)">Especial · '+ROLES[u.role].special+':</b> '+ROLES[u.role].sdesc;
}
