import { CAMPAIGN_MISSIONS } from '../data/maps.js';
import { WEAPONS } from '../data/weapons.js';
import { cheb, dist, angleToFacing } from '../core/geometry.js';
import { lsGet, lsSet } from '../core/storage.js';
import { sfx, auPlay } from '../core-and-audio.js';
import { fx3Explosion, fx3Shot } from '../render3d/fx3d.js';
import { DOM_TARGET, DOM_MAX_ROUNDS, ESCORT_MAX_ROUNDS, ESCORT_GUIDES_PER_ROUND, LS_NATION, LS_WINS, LS_GAMES, LS_CAMPAIGN, loadCampaign, saveCampaign, effMode, domControl, domZones, isExtraction, openSetup, renderCampaignPanel, renderNationChip } from '../ui/ui-shell.js';
import { blocked, inBeacon, hasLOS, smokeBlocksLOS } from './board.js';
import { damage, log, playOnce, spendEnergy, tryShoot, aliveCount, teamName, hasCharAction, hasCharIcon, pickupLoot, checkOverwatch } from './combat.js';
export const MINE_DMG=60,MINE_COST=3;

export function mineAt(x,y){return (G&&G.mines||[]).find(m=>m.x===x&&m.y===y)||null;}

export function viewerTeam(){if(!G)return 'A';return G.opp==='local'?G.turn:'A';}

export function placeMine(u,x,y){
  try{auPlay('sfx/abilities/landmine_place.mp3',0.5);}catch(e){}
  if(u.role!=='Ingeniero'&&!hasCharAction(u,'mine')){toast('La Claymore M18A1 no está disponible para este personaje.');return;}
  if((u.mines||0)<=0){toast('Sin Claymores: el Ingeniero lleva 2 por partida.');return;}
  if(u.energy<MINE_COST){toast('Colocar la Claymore cuesta '+MINE_COST+' ⚡.');return;}
  if(dist(u,{x,y})!==1){toast('La Claymore va en una casilla adyacente al Ingeniero.');return;}
  if(mineAt(x,y)){toast('Ya hay una mina en esa casilla.');return;}
  if(blocked(x,y)||(x===TURRET_POS.x&&y===TURRET_POS.y)||G.map.medkits.some(m=>!m.used&&m.x===x&&m.y===y)){toast('La Claymore necesita una casilla adyacente libre: sin soldados, cobertura, botiquines ni la plataforma de la torreta.');return;}
  G.lastMoveUndo=null;
  spendEnergy(u,MINE_COST);u.mines--;playOnce(u,'deploy');sfx('place');
  if(!G.mines)G.mines=[];
  G.mines.push({x:x,y:y,team:u.team});
  /* En el registro solo se dan las coordenadas si quien mira la
     partida es el bando que la colocó; si la coloca la IA, el
     jugador solo sabe que hay una mina nueva en algún sitio. */
  const vis=(G.opp==='local'||u.team==='A');
  log('💥 '+u.role+' ('+u.team+') coloca una Claymore M18A1'+(vis?(' en ('+(x+1)+','+(y+1)+')'):' en algún punto del tablero')+': oculta para el enemigo, '+MINE_DMG+' de daño a quien la pise.');
  G.actionMode='move';updateUI();draw();
}

export function checkMines(u){
  if(!G||!u||!u.alive||u.isDrone)return;
  const m=mineAt(u.x,u.y);
  if(!m||m.team===u.team)return;
  G.lastMoveUndo=null;
  G.mines=G.mines.filter(mm=>mm!==m);
  FX.shake=9;try{auPlay('sfx/weapons/landmine_explode.mp3',0.6);}catch(e){}fxBurst(u.x,u.y,16,'#ffb03a');fxFloat(u.x,u.y,'💥','#ffe1a8');if(typeof fx3Explosion==='function')fx3Explosion(u.x,u.y,'expl');
  log('💥 ¡'+u.role+' ('+u.team+') pisa la Claymore M18A1 colocada en ('+(u.x+1)+','+(u.y+1)+')! La mina se consume en la explosión.');
  damage(u,MINE_DMG,'La explosión de la Claymore M18A1',m.team);
  checkWin();
}

export const FLASH_COST=2,FLASH_RANGE=4,STUN_ENERGY_PEN=6,STUN_AIM_PEN=25;

export function applyStun(t){
  const was=t.stunned;
  t.stunned=true;t.stunFresh=true;
  if(t.overwatch){t.overwatch=false;log('👁 La vigilancia de '+t.role+' ('+t.team+') se rompe con el fogonazo de la M84.');}
  log('💫 '+t.role+' ('+t.team+') queda '+(was?'aturdido otra vez':'aturdido')+': en su próximo turno empezará con −'+STUN_ENERGY_PEN+' ⚡, disparará con −'+STUN_AIM_PEN+' de puntería y hasta entonces no devuelve el fuego ni puede vigilar.');
}

export function throwFlash(u,x,y){
  if(u.role!=='Comando'&&!hasCharAction(u,'flash')){toast('La M84 aturdidora no está disponible para este personaje.');return;}
  if((u.flashes||0)<=0){toast('Sin aturdidoras M84.');return;}
  if(u.energy<FLASH_COST){toast('La M84 cuesta '+FLASH_COST+' de energía.');return;}
  if(cheb(u,{x,y})>FLASH_RANGE){toast('La M84 se lanza a '+FLASH_RANGE+' casillas como máximo.');return;}
  G.lastMoveUndo=null;
  spendEnergy(u,FLASH_COST);u.flashes--;playOnce(u,'throw');sfx('flash');
  if(typeof fx3Proj==='function')fx3Proj(u,{x,y},'flash');
  if(typeof fx3Explosion==='function')fx3Explosion(x,y,'flash');
  const f=angleToFacing(x-u.x,y-u.y);if(f!=null)u.facing=f;
  FX.shake=Math.max(FX.shake,3);
  fxBurst(x,y,16,'#fff3b0');fxFloat(x,y,'✸ M84','#ffe98a');
  log('✸ '+u.role+' ('+u.team+') lanza una granada aturdidora M84 a ('+(x+1)+','+(y+1)+'): 170–180 dB y millones de candelas, sin daño. Todo soldado en radio 1 queda aturdido, de los dos bandos; solo se salva quien la lanza.');
  let hit=0;
  G.units.filter(t=>t.alive&&t!==u&&cheb(t,{x,y})<=1).forEach(t=>{applyStun(t);hit++;});
  if(!hit)log('La M84 estalla en ('+(x+1)+','+(y+1)+') sin cegar a nadie: fogonazo perdido.');
  G.actionMode='move';checkWin();updateUI();draw();
}

export function guideDrone(u,x,y){
  const d=G.drone;
  if(!d||!d.alive){toast('El dron ya no puede moverse.');return;}
  if(u.team!=='A'){toast('Solo la escuadra escolta puede guiar el dron.');return;}
  if(d.movesLeft<=0){toast('El dron ya ha avanzado '+ESCORT_GUIDES_PER_ROUND+' casillas esta ronda: su motor averiado no da más de sí hasta la siguiente.');G.actionMode='move';updateUI();draw();return;}
  if(dist(u,d)>1){toast('Para guiar el dron tienes que estar pegado a él. Acércate primero y luego pulsa «Guiar dron».');G.actionMode='move';updateUI();draw();return;}
  if(u.energy<2){toast('Guiar el dron cuesta 2 ⚡ y a '+u.role+' le quedan '+u.energy+'.');return;}
  if(dist(d,{x,y})!==1){toast('El dron solo avanza 1 casilla: toca una casilla pegada a él.');return;}
  if(blocked(x,y)){toast('Esa casilla está ocupada o bloqueada: el dron necesita una adyacente libre.');return;}
  G.lastMoveUndo=null;
  spendEnergy(u,2);d.movesLeft--;d.movedThisTurn=true;
  const fx=d.x,fy=d.y,f=angleToFacing(x-fx,y-fy);if(f!=null)d.facing=f;
  d.x=x;d.y=y;
  /* La escolta camina CON el dron: si al empujarlo deja de quedarle
     pegado, se recoloca en la casilla que el dron acaba de dejar libre
     (siempre hay una adyacente y era la regla del modo: el dron avanza
     "siempre con escolta al lado", manteniendo el −53 % de blindaje). */
  if(dist(u,d)>1&&!blocked(fx,fy)&&!(u.x===fx&&u.y===fy)){
    const ff2=angleToFacing(fx-u.x,fy-u.y);if(ff2!=null)u.facing=ff2;
    u.x=fx;u.y=fy;u.movedThisTurn=true;checkMines(u);checkOverwatch(u);pickupLoot(u);
  }
  log('🤖 '+u.role+' guía el dron de ('+(fx+1)+','+(fy+1)+') a ('+(x+1)+','+(y+1)+') · −2 ⚡. Al dron le quedan '+d.hp+' PV y '+d.movesLeft+' guiados esta ronda.');
  if(isExtraction(x,y)){d.delivered=true;log('⇪ ¡El dron pisa la zona de extracción!');}
  G.actionMode='move';checkWin();updateUI();draw();
}

export function useSpecial(u,target){
  /* Especiales sobre el dron (modo Escolta): el Médico de la escolta lo
     repara y el Francotirador rival puede aplicarle el tiro certero.
     Cualquier otro especial sobre el dron no tiene sentido y se avisa. */
  if(target&&target.isDrone){
    if(u.role==='Médico'&&u.team==='A'){
      if(dist(u,target)>1){toast('Pégate al dron para repararlo: el Médico trabaja sobre casillas adyacentes.');return;}
      if(!target.alive){toast('El dron ya está destruido: no hay reparación posible.');return;}
      if(target.hp>=target.maxHp){toast('El dron ya está al completo ('+target.maxHp+' PV).');return;}
      if(u.heals<=0){toast('Sin reparaciones: el IFAK se ha gastado (2 por partida, entre curar y reparar).');return;}
      if(u.energy<3){toast('Reparar el dron cuesta 3 ⚡.');return;}
      G.lastMoveUndo=null;spendEnergy(u,3);u.heals--;playOnce(u,'interact');target.hp=Math.min(target.maxHp,target.hp+80);
      fxFloat(target.x,target.y,'+80 PV','#8df09a');if(typeof fx3Explosion==='function')fx3Explosion(target.x,target.y,'heal');
      log('🔧 '+u.role+' repara el dron sobre la marcha: +80 PV (ahora '+target.hp+'/'+target.maxHp+').');
      G.actionMode='move';updateUI();draw();return;
    }
    if(u.role==='Francotirador'&&u.team!=='A'){
      if(u.energy<WEAPONS[u.weapon].cost){toast('Sin energía para disparar.');return;}
      const mult=target.movedThisTurn?1:1.5;
      if(mult===1)toast('El dron se ha movido este turno: sin bonificación de tiro certero.');
      else toast('Tiro certero sobre el dron: no se ha movido este turno. Daño ×1,5.');
      const ok=tryShoot(u,target,u.weapon,mult);if(ok){u.energy=Math.max(0,u.energy-3);}G.actionMode='move';return;
    }
    toast('Ese especial no se puede usar sobre el dron.'+(u.role==='Médico'?' Solo lo repara el Médico de la escuadra que escolta.':''));
    return;
  }
  const role=u.role;
  if(role==='Espía'||hasCharIcon(u,'CharAbility_17_Ghost_alpha')){
    if(u.energy<3){toast('Invisibilidad cuesta 3 ⚡.');return;}
    G.lastMoveUndo=null;spendEnergy(u,3);u.invisible=true;u.invisTurns=1;
    fxFloat(u.x,u.y,'👁 INVISIBLE','#c8a8ff');
    log(u.role+' ('+u.team+') activa invisibilidad: no puede ser objetivo este turno.');updateUI();draw();return;
  }
  if(role==='Francotirador'||hasCharIcon(u,'CharAbility_42_Sniper_Rifle_Specialization_alpha')){
    if(!target||target.team===u.team){toast('Tiro certero: elige un enemigo como objetivo.');G.actionMode='special';updateUI();draw();return;}
    if(u.energy<WEAPONS[u.weapon].cost){toast('Sin energía para disparar.');return;}
    const mult=target.movedThisTurn?1:1.5;
    if(mult===1)toast('El objetivo se ha movido este turno: sin bonificación de tiro certero.');
    else toast('Tiro certero: el objetivo no se ha movido. Daño ×1,5.');
    const ok=tryShoot(u,target,u.weapon,mult);if(ok){u.energy=Math.max(0,u.energy-3);}G.actionMode='move';return;
  }
  if(role==='Médico'||hasCharIcon(u,'CharAbility_30_Medkit_alpha')){
    if(!target||target.team!==u.team){toast('Elige un aliado adyacente para curar o reanimar.');G.actionMode='special';updateUI();draw();return;}
    if(dist(u,target)>1){toast('El Médico actúa sobre aliados adyacentes.');return;}
    if(!target.alive){
      if(hasCharIcon(u,'CharAbility_30_Medkit_alpha')&&!hasCharIcon(u,'CharAbility_36_Revive_alpha')){toast('Este personaje cura, pero no tiene Reanimar entre sus habilidades.');return;}
      if(u.revives<=0){toast('Reanimación ya usada.');return;}
      if(u.energy<4){toast('Reanimar cuesta 4 ⚡.');return;}
      G.lastMoveUndo=null;spendEnergy(u,4);u.revives--;playOnce(u,'interact');target.alive=true;target.hp=80;target.energy=0;target._deathT=null;
      fxFloat(target.x,target.y,'✚ REANIMADO','#8df09a');if(typeof fx3Explosion==='function')fx3Explosion(target.x,target.y,'heal');
      log('✚ '+u.role+' reanima a '+target.role+' con 80 PV.');updateUI();draw();return;
    }
    if(target.hp>=target.maxHp){toast('Ese aliado está al completo.');return;}
    if(u.heals<=0){toast('Sin curaciones del IFAK (2 por partida).');return;}
    if(u.energy<3){toast('Curar cuesta 3 ⚡.');return;}
    G.lastMoveUndo=null;spendEnergy(u,3);u.heals--;playOnce(u,'interact');target.hp=Math.min(target.maxHp,target.hp+80);
    fxFloat(target.x,target.y,'+80 PV','#8df09a');if(typeof fx3Explosion==='function')fx3Explosion(target.x,target.y,'heal');
    log('✚ '+u.role+' cura 80 PV a '+target.role+'. Ahora tiene '+target.hp+' PV.');
    G.actionMode='move';updateUI();draw();return;
  }
  if(role==='Capitán'){
    if(u.captainUsed){toast('Orden de mando ya usada este turno.');return;}
    if(!target||target.team!==u.team||target===u){toast('Elige a otro aliado para darle +3 de energía.');G.actionMode='special';updateUI();draw();return;}
    G.lastMoveUndo=null;u.captainUsed=true;playOnce(u,'interact');target.energy=Math.min(target.maxEnergy+3,target.energy+3);
    fxFloat(target.x,target.y,'+3 ⚡','#ffd94d');if(typeof fx3Explosion==='function')fx3Explosion(target.x,target.y,'heal');
    log('★ Orden de mando: '+target.role+' recupera 3 de energía.');
    G.actionMode='move';updateUI();draw();return;
  }
  if(role==='Ingeniero'||hasCharIcon(u,'CharAbility_16_Gatling_Turret_alpha')){G.actionMode='deploy';toast('Toca una casilla adyacente libre para desplegar la torreta M2 (5 ⚡).');updateUI();draw();return;}
  if(role==='Artillero'){toast('La supresión va con sus ametralladoras: cada impacto resta 2 de energía al enemigo en su siguiente turno. Con lanzacohetes, daño en área.');return;}
  if(role==='Comando'){toast('El Comando lleva una M67 extra (botón Granada) y 2 aturdidoras M84 (botón Aturdidora): sin daño, pero dejan al enemigo viendo estrellas durante un turno.');return;}
}

export function deployTurret(u,x,y,type){
  try{auPlay('sfx/abilities/ability_beep.mp3',0.5);}catch(e){}
  type=type||'m2';
  if(u.energy<5){toast('Desplegar la torreta cuesta 5 ⚡ (un turno casi entero).');return;}
  if(dist(u,{x,y})!==1||blocked(x,y)){toast('La torreta va en una casilla adyacente libre.');return;}
  G.lastMoveUndo=null;spendEnergy(u,5);playOnce(u,'deploy');sfx('place');
  const hpT=type==='rocket'?100:120;
  G.deployed.push({x,y,hp:hpT,maxHp:hpT,team:u.team,alive:true,type:type});
  log(u.role+' ('+u.team+') despliega una torreta '+(type==='rocket'?'de cohetes':'M2 Browning')+' en ('+(x+1)+','+(y+1)+').');
  G.actionMode='move';updateUI();draw();
}

export function captureTurret(u){
  if(effMode(G)==='dominacion'){toast('En Dominación no se usa la torreta central.');return;}
  if(G&&G.round<2){toast('La torreta central se calibra en la ronda 1: se puede capturar desde la ronda 2.');return;}
  if(!(u.x===TURRET_POS.x&&u.y===TURRET_POS.y)){toast('La torreta capturable solo se captura desde su casilla central.');return;}
  if(G.map.turret.owner===u.team){toast('La torreta central ya es de tu bando.');return;}
  if(u.energy<2){toast('Capturar la torreta cuesta 2 ⚡.');return;}
  G.lastMoveUndo=null;spendEnergy(u,2);playOnce(u,'interact');sfx('place');G.map.turret.owner=u.team;
  fxFloat(u.x,u.y,'⚙ CAPTURADA','#ffd94d');
  log('⚙ '+u.role+' ('+u.team+') captura la torreta central. Disparará al final de cada turno de su bando.');
  updateUI();draw();
}

export function turretFire(ownerTeam){
  const targets=G.units.filter(u=>u.alive&&u.team!==ownerTeam&&!u.invisible);
  const fire=(pos,dmg,rng,label)=>{
    /* Las torretas respetan el humo igual que un soldado: su fuego
       iba directo a damage() pasando solo por hasLOS, sin la
       comprobación de humo, así que la torreta central y las M2
       desplegadas acertaban a través de una cortina M18 que a un
       soldado le cortaba el tiro. Ahora, si el objetivo más cercano
       está tapado, la torreta busca el siguiente que sí se vea, y
       si todos están tras el humo, no dispara. */
    const inR=targets.filter(t=>cheb(pos,t)<=rng&&hasLOS(pos,t)&&!smokeBlocksLOS(pos,t)).sort((a,b)=>cheb(pos,a)-cheb(pos,b));
    if(inR.length){
      fxTracer(pos,inR[0]);if(typeof fx3Shot==='function')fx3Shot(pos,inR[0],'Ametralladoras');sfx('shoot');
      damage(inR[0],dmg,label,ownerTeam);
    }
  };
  if(effMode(G)!=='dominacion'&&G.map.turret.owner===ownerTeam)fire(TURRET_POS,30,6,'La torreta central');
  G.deployed.filter(t=>t.alive&&t.team===ownerTeam).forEach(t=>{
    if(t.type==='rocket'){
      const inR=targets.filter(x=>cheb(t,x)<=6&&hasLOS(t,x)&&!smokeBlocksLOS(t,x)).sort((a,b)=>cheb(t,a)-cheb(t,b));
      if(inR.length){const tg=inR[0];fxTracer(t,tg);if(typeof fx3Shot==='function')fx3Shot(t,tg,'Lanzacohetes');sfx('boom');
        damage(tg,60,'La torreta de cohetes',ownerTeam);
        G.units.filter(u=>u.alive&&u.team!==ownerTeam&&u!==tg&&cheb(u,tg)<=1).forEach(u=>damage(u,30,'La torreta de cohetes',ownerTeam));}
    } else fire(t,45,6,'La torreta M2 desplegada');
  });
}

export function scoreDominationFor(team){
  if(!G||effMode(G)!=='dominacion'||G.round<2)return;
  let pts=0;const held=[];
  domZones().forEach(z=>{if(domControl(z)===team){pts++;held.push(z.name);}});
  if(pts===3)pts++;
  if(pts>0){
    G.dom[team]+=pts;
    log('⬢ Inicio de turno de '+teamName(team)+' (R'+G.round+') en Dominación: '+held.join(', ')+' → +'+pts+' (total J1 '+G.dom.A+' · Rival '+G.dom.B+').');
  }
}

export function checkBeaconAtTurnEnd(teamJustPlayed){
  if(effMode(G)==='eliminacion'||effMode(G)==='dominacion'||effMode(G)==='escolta')return;
  ['A','B'].forEach(t=>{
    const mine=G.units.some(u=>u.alive&&u.team===t&&inBeacon(u.x,u.y));
    const enemy=G.units.some(u=>u.alive&&u.team!==t&&inBeacon(u.x,u.y));
    if(t===teamJustPlayed){
      if(mine&&!enemy){G.beacon[t]++;log('⚑ '+teamName(t)+' aguanta la baliza: '+G.beacon[t]+'/5.');}
      else if(G.beacon[t]>0&&( !mine||enemy)){G.beacon[t]=0;log('La racha de baliza de '+teamName(t)+' se rompe.');}
    }
  });
}

export function checkWin(){
  if(!G||G.over)return true;
  const a=aliveCount('A'),b=aliveCount('B');
  let winner=null,reason='';
  if(effMode(G)==='escolta'&&G.drone&&G.drone.delivered){winner='A';reason='El dron averiado llegó a la zona de extracción con '+G.drone.hp+' PV.';}
  else if(effMode(G)==='escolta'&&G.drone&&!G.drone.alive){winner='B';reason='El dron ha sido destruido antes de llegar a la extracción.';}
  else if(a===0&&b===0){winner='draw';reason='Ambas escuadras han caído.';}
  else if(b===0){winner='A';reason='Escuadra enemiga eliminada.';}
  else if(a===0){winner='B';reason='Tu escuadra ha sido eliminada.';}
  else if(effMode(G)==='baliza'){
    if(G.beacon.A>=5){winner='A';reason='Baliza aguantada durante 5 turnos.';}
    if(G.beacon.B>=5){winner='B';reason='La baliza enemiga llegó a 5 turnos.';}
  }
  else if(effMode(G)==='dominacion'&&(G._domRoundDone||G.round>DOM_MAX_ROUNDS)){
    if((G.dom.A>=DOM_TARGET||G.dom.B>=DOM_TARGET)&&G.dom.A!==G.dom.B){
      if(G.dom.A>G.dom.B){winner='A';reason='Dominación al cerrar ronda: '+G.dom.A+' a '+G.dom.B+'.';}
      else{winner='B';reason='Dominación rival al cerrar ronda: '+G.dom.B+' a '+G.dom.A+'.';}
    } else if(G.round>DOM_MAX_ROUNDS||(G._domRoundDone&&G.round>=DOM_MAX_ROUNDS)){
      if(G.dom.A>G.dom.B){winner='A';reason='Dominación al final de la ronda '+DOM_MAX_ROUNDS+': '+G.dom.A+' a '+G.dom.B+'.';}
      else if(G.dom.B>G.dom.A){winner='B';reason='Dominación al final de la ronda '+DOM_MAX_ROUNDS+': '+G.dom.B+' a '+G.dom.A+'.';}
      else{winner='draw';reason='Dominación empatada a '+G.dom.A+' al final de la ronda '+DOM_MAX_ROUNDS+'.';}
    }
  }
  else if(effMode(G)==='escolta'){
    if(G.round>ESCORT_MAX_ROUNDS){winner='B';reason='El dron no llegó a la extracción en '+ESCORT_MAX_ROUNDS+' rondas: la defensa aguanta y la escolta fracasa.';}
  }
  if(winner){G.over=true;endGame(winner,reason);return true;}
  return false;
}

export function endGame(winner,reason){
  G.winner=winner;
  document.body.dataset.state='gameover';
  sfx(winner==='A'?'win':winner==='B'?'lose':'turn');
  draw();updateUI();
  let title,extra='';
  if(winner==='draw')title='Empate mutuo';
  else if(winner==='A')title='¡Victoria!';
  else title='Derrota';
  if(G.mode==='guerra'){
    if(winner==='A'){lsSet(LS_WINS,+(lsGet(LS_WINS)||0)+1);
      extra='<div class="score-big">+1</div><p>Punto para <b>'+myNation.name+'</b>. Victorias de tu nación en este dispositivo: <b>'+(lsGet(LS_WINS)||0)+'</b>.</p>';renderNationChip();}
    else extra='<p>'+G.rivalNation.name+' se lleva el punto esta vez. Tu nación conserva sus <b>'+(lsGet(LS_WINS)||0)+'</b> victorias en este dispositivo.</p>';
  }
  if(effMode(G)==='escolta'&&G.drone){
    if(winner==='A'&&G.drone.delivered)extra='<p>🤖 El dron llegó a la extracción con <b>'+G.drone.hp+' PV</b> de '+G.drone.maxHp+': la escolta cumple su misión y la defensa se queda mirando la zona vacía.</p>';
    else if(!G.drone.alive)extra='<p>🤖 El dron quedó destruido en la casilla ('+(G.drone.x+1)+','+(G.drone.y+1)+'). Sin dron no hay extracción: la defensa se impone.</p>';
    else extra='<p>🤖 El dron sobrevivió con <b>'+G.drone.hp+' PV</b> en la casilla ('+(G.drone.x+1)+','+(G.drone.y+1)+'), pero la partida se decidió por eliminación antes de que llegara a la extracción.</p>';
  }
  let campaignButtons='';
  if(G.mode==='campana'){
    const idx=G.campaignMission;
    if(winner==='A'){
      const c=loadCampaign();
      const vet=c.vet.slice();
      if(!(idx<c.next))G.units.filter(u=>u.team==='A').forEach(u=>{const s=(u.slotIndex!=null?u.slotIndex:G.units.filter(x=>x.team==='A').indexOf(u));if(u.alive)vet[s]=(vet[s]||0)+1;});
      const isLast=idx>=CAMPAIGN_MISSIONS.length-1;
      saveCampaign({next:isLast?CAMPAIGN_MISSIONS.length:Math.max(c.next,idx+1),vet:vet,done:isLast?true:c.done});
      const gained=G.units.filter(u=>u.team==='A'&&u.alive).map(u=>u.role).join(', ')||'ninguno';
      extra='<p><b>Misión '+(idx+1)+' superada.</b> Veterania ganada por sobrevivir: '+gained+'. Esos soldados empiezan la siguiente misión con +25 PV y +1 ⚡ más por cada nivel.</p>'+(isLast?'<div class="score-big">OPERACIÓN COMPLETADA</div><p>Has cerrado las '+CAMPAIGN_MISSIONS.length+' misiones de Operación Londres.</p>':'<p>Siguiente misión: <b>'+CAMPAIGN_MISSIONS[idx+1].title+'</b> · '+CAMPAIGN_MISSIONS[idx+1].brief+'</p>');
      campaignButtons=isLast?'':'<button class="btn primary big" onclick="closeModal();openSetup(\'campana\','+(idx+1)+')">Siguiente misión ▶</button>';
    } else {
      extra='<p><b>Misión '+(idx+1)+' no superada.</b> No pierdes veterania ni progreso: repite esta misión con otra escuadra o con las mismas armas.</p>';
      campaignButtons='<button class="btn primary big" onclick="closeModal();openSetup(\'campana\','+idx+')">Reintentar misión ↻</button>';
    }
    if(typeof renderCampaignPanel==='function')renderCampaignPanel();
  }
  if(winner==='A'&&G.opp==='ia')coinsSet(coinsGet()+25);
  const survivors=G.units.filter(u=>u.alive).map(u=>u.role+' ('+u.team+', '+u.hp+' PV)').join(' · ')||'Sin supervivientes.';
  const ST=G.stats||{A:{dmg:0,kills:0},B:{dmg:0,kills:0}};
  const aliveN=t=>G.units.filter(u=>u.alive&&u.team===t).length;
  const squadLine='<p class="sub" style="margin:8px 0 0;font-size:12px">Tu escuadra: '+G.units.filter(u=>u.team==='A'&&!u.isDrone).map(u=>u.name+' ('+u.role+', '+(SKINS[u.skin]?SKINS[u.skin].name:'Estándar')+')').join(' · ')+'</p>';
  const resTable='<div class="res-table"><div class="res-row head"><span>Bando</span><span>Vivos</span><span>Daño</span><span>Derribos</span></div>'+
    ['A','B'].map(t=>'<div class="res-row"><span>'+(t==='A'?'Tú':'Rival')+'</span><span>'+aliveN(t)+'</span><span>'+ST[t].dmg+'</span><span>'+ST[t].kills+'</span></div>').join('')+'</div>';
  const won=(winner==='A'),lbl=(winner==='A'?'VICTORIA':winner==='draw'?'EMPATE':'DERROTA');
  const modeArt=effMode(G)==='dominacion'?'modo_dominacion':effMode(G)==='escolta'?'modo_escolta':effMode(G)==='baliza'?'modo_baliza':'modo_eliminacion';
  showModal('<div class="endWrap '+(won?'win':'lose')+'"><div class="endBanner">'+lbl+'</div><img class="endArt" src="assets/ui/'+modeArt+'.png" alt=""/><h2>'+title+'</h2><p><b>'+reason+'</b></p>'+extra+'<p class="sub">Partida de '+G.round+' rondas. Supervivientes: '+survivors+'</p>'+resTable+squadLine+'<div style="display:flex;gap:10px;justify-content:center;flex-wrap:wrap;margin-top:14px">'+campaignButtons+'<button class="btn primary big" onclick="closeModal();backToMenu()">Volver al menú</button>'+(G.mode==='campana'?'':'<button class="btn big" onclick="closeModal();openSetup(G.mode)">Revancha</button>')+'</div></div>');
}
