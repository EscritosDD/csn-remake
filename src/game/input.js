import { PISTOL, WEAPONS } from '../data/weapons.js';
import { angleToFacing, cheb } from '../core/geometry.js';
import { sfx } from '../core-and-audio.js';
import { effMode, toast } from '../ui/ui-shell.js';
import { classicTileFromPoint, draw } from '../render2d/board.js';
import { fxFloat } from '../render2d/fx.js';
import { barrelAt, blocked, deployedAt, droneAt, drawMovePath, hasLOS, hitChance, obAt, reachable, smokeBlocksLOS, startDrawMove, unitAt } from './board.js';
import { canHealSpecial, canSnipeSpecial, checkOverwatch, explodeBarrel, log, pickupLoot, playOnce, selectUnit, spendEnergy, throwGrenade, tryShoot } from './combat.js';
import { checkMines, deployTurret, guideDrone, mineAt, throwFlash, useSpecial } from './missions.js';
import { fireArtillery, fireOrbital, placeCover, placeHealthCrate, sweepDetect, teleportUnit, throwBees, throwGas, throwMolotov, throwSmoke, throwTranq, waterCannon } from './gadgets.js';
import { tutorialEvent } from './tutorial.js';

export let hoverTile=null;
export function setHoverTile(v){hoverTile=v;}

export function tileFromEvent(e){
  const r=canvas.getBoundingClientRect();
  const px=((e.touches?e.touches[0].clientX:e.clientX)-r.left)/r.width*canvas.width;
  const py=((e.touches?e.touches[0].clientY:e.clientY)-r.top)/r.height*canvas.height;
  return classicTileFromPoint(px,py,canvas.width,canvas.height);
}

export function boardTileClick(t){
  if(!G||G.over||G.aiBusy)return;
  if(G.opp==='ia'&&G.turn==='B')return;
  if(!t)return;
  const u=G.selected;
  const clickedUnit=unitAt(t.x,t.y);
  const clickedDeployed=deployedAt(t.x,t.y);
  if(G.actionMode==='deploy'&&u){deployTurret(u,t.x,t.y);return;}
  if(G.actionMode==='grenade'&&u){if(u.grenades>0&&u.energy>=2&&cheb(u,t)<=3)tutorialEvent('grenade',{cover:0});throwGrenade(u,t.x,t.y);return;}
  if(G.actionMode==='smoke'&&u){throwSmoke(u,t.x,t.y);return;}
  if(G.actionMode==='mine'&&u){placeMine(u,t.x,t.y);return;}
  if(G.actionMode==='flash'&&u){if((u.flashes||0)>0&&u.energy>=2&&cheb(u,t)<=4)tutorialEvent('grenade',{cover:0});throwFlash(u,t.x,t.y);return;}
  if(G.actionMode==='cover'&&u){placeCover(u,t.x,t.y);return;}
  if(G.actionMode==='gas'&&u){throwGas(u,t.x,t.y);return;}
  if(G.actionMode==='sweep'&&u){sweepDetect(u,t.x,t.y);return;}
  if(G.actionMode==='molotov'&&u){throwMolotov(u,t.x,t.y);return;}
  if(G.actionMode==='crate'&&u){placeHealthCrate(u,t.x,t.y);return;}
  if(G.actionMode==='teleport'&&u){teleportUnit(u,t.x,t.y);return;}
  if(G.actionMode==='arty'&&u){fireArtillery(u,t.x,t.y);return;}
  if(G.actionMode==='deployRocket'&&u){deployTurret(u,t.x,t.y,'rocket');return;}
  if(G.actionMode==='orbital'&&u){fireOrbital(u,t.x,t.y);return;}
  if(G.actionMode==='drone'&&u){
    const cu0=unitAt(t.x,t.y);
    if(cu0&&cu0.team===G.turn){selectUnit(cu0);return;}
    guideDrone(u,t.x,t.y);return;
  }
  if(G.actionMode==='bees'&&u){if(clickedUnit&&clickedUnit.team!==u.team)throwBees(u,clickedUnit);return;}
  if(G.actionMode==='tranq'&&u){if(clickedUnit&&clickedUnit.team!==u.team)throwTranq(u,clickedUnit);return;}
  if(G.actionMode==='water'&&u){if(clickedUnit&&clickedUnit.team!==u.team)waterCannon(u,clickedUnit);return;}
  if(clickedUnit){
    if(clickedUnit.team===G.turn){
      if(G.actionMode==='special'&&u&&(canHealSpecial(u)||u.role==='Capitán')){useSpecial(u,clickedUnit);G.actionMode='move';updateUI();draw();return;}
       selectUnit(clickedUnit);tutorialEvent('select',{unit:clickedUnit});return;
     } else {
       if(!u||u.team!==G.turn){toast('Selecciona primero a uno de tus soldados.');return;}
       if(G.actionMode==='special'&&canSnipeSpecial(u)){useSpecial(u,clickedUnit);tutorialEvent('shoot',{ok:true,target:clickedUnit});return;}
       if(G.actionMode==='pistol'){const ok=tryShoot(u,clickedUnit,PISTOL,null);tutorialEvent('shoot',{ok:ok!==false,target:clickedUnit});return;}
       const ok=tryShoot(u,clickedUnit,u.weapon,null);tutorialEvent('shoot',{ok:ok!==false,target:clickedUnit});return;
    }
  }
  if(clickedDeployed&&u){
    if(clickedDeployed.team!==G.turn){
      const w=WEAPONS[u.weapon];if(u.energy>=w.cost&&cheb(u,clickedDeployed)<=w.rng&&hasLOS(u,clickedDeployed)&&!smokeBlocksLOS(u,clickedDeployed)){spendEnergy(u,w.cost);clickedDeployed.hp-=w.dmg;log(u.role+' dispara a la torreta desplegada: −'+w.dmg+' PV.');if(clickedDeployed.hp<=0){clickedDeployed.alive=false;log('Torreta desplegada destruida.');}updateUI();draw();}
      else toast(smokeBlocksLOS(u,clickedDeployed)?'Sin tiro: el humo M18 corta la línea de visión hasta la torreta.':'Torreta fuera de alcance o sin línea de visión.');
      return;
    }
  }
  /* El dron de Escolta: la escolta no le dispara (lo guía o lo repara
     con el especial del Médico) y la defensa le dispara tocándolo con
     el modo de disparo activo, como a un soldado más. */
  const dAt=droneAt(t.x,t.y);
  if(dAt&&u&&u.team===G.turn){
    if(G.actionMode==='special'){useSpecial(u,dAt);return;}
    if(u.team==='A'){
      toast(G.actionMode==='shoot'||G.actionMode==='pistol'
        ? 'El dron es de tu escuadra: no le dispares. Pega un soldado a él y pulsa «Guiar dron» para moverlo hacia la extracción.'
        : 'Tu dron averiado: '+dAt.hp+'/'+dAt.maxHp+' PV · le quedan '+dAt.movesLeft+' guiados esta ronda. Pega un soldado a él y pulsa «Guiar dron»; el Médico lo repara con su especial.');
      return;
    }
    if(G.actionMode==='pistol'){tryShoot(u,dAt,PISTOL,null);return;}
    if(G.actionMode==='shoot'){tryShoot(u,dAt,u.weapon,null);return;}
    toast('Ese es el dron que escolta el rival ('+dAt.hp+' PV): pulsa «Disparar» y luego tócalo para intentar destruirlo. Si pisa la extracción del este, pierdes.');
    return;
  }
  const b=barrelAt(t.x,t.y);
  if(b&&u&&G.actionMode!=='move'){
    const w=G.actionMode==='pistol'?WEAPONS[PISTOL]:WEAPONS[u.weapon];
    if(u.energy>=w.cost&&cheb(u,t)<=w.rng&&hasLOS(u,t)&&!smokeBlocksLOS(u,t)){spendEnergy(u,w.cost);explodeBarrel(b,u.role);updateUI();draw();}
    else toast(smokeBlocksLOS(u,t)?'Sin tiro: el humo M18 corta la línea de visión hasta el barril.':'Barril fuera de alcance de tu arma.');
    return;
  }
  if(b&&u&&G.actionMode==='move'){toast('Para explotar el barril: pulsa «Disparar» y luego toca el barril. Hará 70 de daño en las casillas adyacentes.');return;}
  const obClicked=obAt(t.x,t.y);
  if(obClicked&&u&&u.team===G.turn&&(G.actionMode==='shoot'||G.actionMode==='pistol')){
    if(obClicked.type!=='crate'){toast('Esa cobertura no se puede destruir: es un muro o una estantería.');return;}
    const w=G.actionMode==='pistol'?WEAPONS[PISTOL]:WEAPONS[u.weapon];
    if(u.energy<w.cost){toast('Energía insuficiente para disparar.');return;}
    if(smokeBlocksLOS(u,t)){toast('Sin tiro: el humo M18 corta la línea de visión hasta la caja.');return;}
    if(cheb(u,t)>w.rng||!hasLOS(u,t)){toast('Caja fuera de alcance o sin línea de visión.');return;}
    spendEnergy(u,w.cost);obClicked.hp-=w.dmg;log(u.role+' dispara a la caja de ('+(t.x+1)+','+(t.y+1)+'): −'+w.dmg+' PV de cobertura.');
    if(obClicked.hp<=0){G.map.obstacles=G.map.obstacles.filter(o=>o!==obClicked);log('La caja queda destruida: esa cobertura ya no protege a nadie.');}
    updateUI();draw();return;
  }
  if(u&&u.team===G.turn){
    const reach=reachable(u,u.energy);
    const k=t.x+','+t.y;
    if(reach.has(k)){
      const cost=reach.get(k);const fx=u.x,fy=u.y;
      const snap={unitId:u.id,x:fx,y:fy,energy:u.energy,facing:u.facing,movedThisTurn:u.movedThisTurn};
      const hadMine=!!mineAt(t.x,t.y);
      const hadWatcher=G.units.some(w2=>w2.alive&&w2.team!==u.team&&w2.overwatch&&!w2.stunned&&!u.invisible&&hitChance(w2,u,WEAPONS[w2.weapon])>0);
      const hadLoot=(G.lootBoxes||[]).some(b2=>b2.x===t.x&&b2.y===t.y);
      const hadMedkit=G.map.medkits.some(m=>!m.used&&m.x===t.x&&m.y===t.y);
      const movePath=drawMovePath(u,{x:fx,y:fy},{x:t.x,y:t.y});
      const stepFrom=movePath&&movePath.length>1?movePath[movePath.length-2]:{x:fx,y:fy};
      const ff2=angleToFacing(t.x-stepFrom.x,t.y-stepFrom.y);if(ff2!=null)u.facing=ff2;
      u.x=t.x;u.y=t.y;u.energy-=cost;u.movedThisTurn=true;checkMines(u);checkOverwatch(u);pickupLoot(u);
      if(u.alive&&movePath&&movePath.length>1)startDrawMove(u,movePath);
      log(u.role+' ('+u.team+') se mueve de ('+(fx+1)+','+(fy+1)+') a ('+(t.x+1)+','+(t.y+1)+') · −'+cost+' ⚡.');
      const mk=G.map.medkits.find(m=>!m.used&&m.x===t.x&&m.y===t.y);
      if(mk&&u.alive){mk.used=true;u.hp=Math.min(u.maxHp,u.hp+50);playOnce(u,'pickup');fxFloat(t.x,t.y,'+50 PV','#8df09a');log('✚ '+u.role+' recoge el botiquín del mapa: +50 PV (ahora '+u.hp+').');}
      if(effMode(G)!=='dominacion'&&t.x===TURRET_POS.x&&t.y===TURRET_POS.y&&G.map.turret.owner!==u.team)toast('Estás sobre la torreta central: pulsa «Capturar torreta» (2 ⚡).');
      G.lastMoveUndo=(!hadMine&&!hadWatcher&&!hadLoot&&!hadMedkit&&u.alive&&!G.over)?snap:null;
      let tileCov=0;[[1,0],[-1,0],[0,1],[0,-1]].forEach(dd=>{const o=obAt(t.x+dd[0],t.y+dd[1]);if(!o)return;const lv=o.type==='wall'||o.type==='shelf'?3:(o.type==='crate'?(o.hp>o.maxHp/2?2:1):0);if(lv>tileCov)tileCov=lv;});
      tutorialEvent('move',{cover:tileCov,tile:t});
      updateUI();draw();return;
    }
    if(obAt(t.x,t.y)){toast('Casilla bloqueada por cobertura. Las cajas se destruyen con «Disparar» y tocando la caja, o con un barril cercano.');return;}
    toast('Fuera del alcance de movimiento con la energía que le queda ('+u.energy+' ⚡).');
  }
}

export function undoLastMove(){
  if(!G||G.over||G.aiBusy||!G.lastMoveUndo)return;
  const s=G.lastMoveUndo,u=G.units.find(x=>x.id===s.unitId&&x.alive&&x.team===G.turn);
  G.lastMoveUndo=null;
  if(!u){updateUI();return;}
  if(blocked(s.x,s.y)&&(s.x!==u.x||s.y!==u.y)){toast('La casilla original ya está ocupada.');updateUI();return;}
  u.x=s.x;u.y=s.y;u.energy=s.energy;u.facing=s.facing;u.movedThisTurn=s.movedThisTurn;
  G.selected=u;G.actionMode='move';sfx('turn');
  log('↶ '+u.role+' ('+u.team+') deshace su último movimiento y recupera la energía.');
  toast('Movimiento deshecho · energía restaurada ('+u.energy+' ⚡).');
  updateUI();draw();
}
