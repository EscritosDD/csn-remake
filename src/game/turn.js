import { cheb } from '../core/geometry.js';
import { auMusicStop, auStopAmbient, sfx, setTurnSeed } from '../core-and-audio.js';
import { effMode, refreshGuerra, renderCampaignPanel, renderNationChip, showScreen, syncPlayingViewport } from '../ui/ui-shell.js';
import { checkBeaconAtTurnEnd, checkWin, scoreDominationFor, turretFire } from './missions.js';
import { damage, log, maybeDropLoot, teamName } from './combat.js';

export function showModal(html){$('#modalBox').innerHTML=html;$('#modal').classList.add('on');}

export function closeModal(){$('#modal').classList.remove('on');}

export function backToMenu(){try{auStopAmbient();}catch(e){}try{auMusicStop();}catch(e){}try{const hp=document.querySelector('#scr-play .hero');if(hp)hp.style.display='';}catch(e){}$('#gameArea').style.display='none';$('#setupArea').style.display='none';$('#menuArea').style.display='block';G=null;document.body.dataset.state='menu';syncPlayingViewport();showScreen('scr-play');refreshGuerra();renderNationChip();if(typeof renderCampaignPanel==='function')renderCampaignPanel();}

export function endTurn(){
  if(!G||G.over||G.aiBusy)return;
  G.lastMoveUndo=null;
  turretFire(G.turn);
  if(checkWin())return;
  checkBeaconAtTurnEnd(G.turn);
  if(checkWin())return;
  const next=G.turn==='A'?'B':'A';
  if(next==='A'){
    if(effMode(G)==='dominacion'){G._domRoundDone=true;if(checkWin())return;G._domRoundDone=false;}
    G.round++;maybeDropLoot();
    if(effMode(G)==='dominacion'&&G.round>DOM_MAX_ROUNDS){if(checkWin())return;}
    if(effMode(G)==='escolta'&&G.round>ESCORT_MAX_ROUNDS){if(checkWin())return;}
    if(G.drone){G.drone.movesLeft=ESCORT_GUIDES_PER_ROUND;G.drone.movedThisTurn=false;}
  }
  if(effMode(G)==='dominacion'&&G.round>=2){scoreDominationFor(next);}
  /* Humo de las M18: cada cortina envejece al empezar el turno de
     quien la lanzó y se disipa cuando su contador llega a 0, así que
     tapa durante SMOKE_TURNS rondas completas de los dos bandos. */
  if(G.smoke&&G.smoke.length){
    const before=G.smoke.length;
    G.smoke.forEach(s=>{if(s.team===next)s.left--;});
    G.smoke=G.smoke.filter(s=>s.left>0);
    if(G.smoke.length<before)log('💨 Una cortina de humo de M18 se disipa: la visión vuelve a pasar por esas casillas.');
  }
  /* Buffs de las cajas de habilidad: envejecen al empezar el turno de su dueño. */
  G.units.filter(x=>x.alive&&x.team===next).forEach(x=>{
    if(x.buffDmgT>0){x.buffDmgT--;if(x.buffDmgT<=0){x.buffDmg=0;log('· '+x.role+' pierde el bonus de munición mejorada.');}}
    if(x.buffArmorT>0){x.buffArmorT--;if(x.buffArmorT<=0){x.buffArmor=0;log('· '+x.role+' pierde la protección de analgésicos.');}}
  });
  /* Nube de gas: daña a todo soldado en su radio al empezar un turno. */
  if(G.smoke&&G.smoke.some(s=>s.kind==='gas')){
    G.units.filter(x=>x.alive&&G.smoke.some(g=>g.kind==='gas'&&cheb(x,g)<=1)).forEach(x=>{const g=G.smoke.find(z=>z.kind==='gas'&&cheb(x,z)<=1);damage(x,GAS_DMG,'La nube de gas',g&&g.team);});
  }
  if(G.smoke&&G.smoke.some(s=>s.kind==='fuego')){
    G.units.filter(x=>x.alive&&G.smoke.some(f=>f.kind==='fuego'&&cheb(x,f)<=1)).forEach(x=>{const f=G.smoke.find(z=>z.kind==='fuego'&&cheb(x,z)<=1);damage(x,MOLOTOV_DMG,'El fuego del molotov',f&&f.team);});
  }
  /* Escudo (duración) y abejas (daño por turno) al empezar el turno de su dueño. */
  G.units.filter(x=>x.alive&&x.team===next).forEach(x=>{
    if(x.shieldT>0){x.shieldT--;if(x.shieldT<=0)log('· '+x.role+' baja el escudo antidisturbios.');}
    if(x.beesT>0){x.beesT--;damage(x,BEES_DMG,'La bomba de abejas',x.beesTeam);}
  });
  if(checkWin())return;
  /* Aturdidos por la M84: quien cierra su turno ya servido (la bandera
     puesta y el turno aturdido ya empezado, stunFresh en falso) se
     despeja aquí, al acabar ESE turno suyo y no antes: así un aliado
     cegado por el fogonazo propio durante el turno de su bando no se
     libra sin pagarlo, y un enemigo cegado lo paga entero en el suyo. */
  G.units.filter(u=>u.team===G.turn&&u.stunned&&!u.stunFresh).forEach(u=>{u.stunned=false;log('💫 '+u.role+' ('+u.team+') se despeja del fogonazo de la M84: vuelve a ver y a oír con normalidad.');});
  G.turn=next;G.selected=null;setTurnSeed(G.round,next);sfx('turn');
  G.units.filter(u=>u.team===next).forEach(u=>{
    let pen=(u.suppressed?2:0);
    if(u.stunned&&u.stunFresh){pen+=STUN_ENERGY_PEN;u.stunFresh=false;log('💫 '+u.role+' ('+next+') empieza su turno aturdido por la M84: −'+STUN_ENERGY_PEN+' ⚡ de salida y −'+STUN_AIM_PEN+' de puntería en cada tiro de este turno.');}
    u.energy=u.maxEnergy-pen;if(u.energy<0)u.energy=0;
    u.suppressed=false;u.captainUsed=false;u.movedThisTurn=false;u.hasShot=false;u.overwatch=false;
    if(u.invisible){u.invisTurns--;if(u.invisTurns<0)u.invisible=false;}
  });
  G.units.filter(u=>u.team!==next).forEach(u=>{u.movedThisTurn=false;});
  log('— Turno de '+teamName(next)+' (ronda '+G.round+').');
  const first=G.units.find(u=>u.team===next&&u.alive);if(first)G.selected=first;
  updateUI();draw();
  if(G.opp==='local'){
    showModal('<h2>Turno del '+(next==='A'?'Jugador 1':'Jugador 2')+'</h2><p>Pasa el dispositivo. Tu escuadra: <b>'+teamName(next)+'</b>.</p><button class="btn primary big" onclick="closeModal()">Estoy listo · Jugar</button>');
  } else if(next==='B'){
    runAI().catch(err=>{if(G)G.aiBusy=false;console.error(err);});
  }
}
