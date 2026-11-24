import { cheb } from '../core/geometry.js';
import { sfx, auPlay } from '../core-and-audio.js';
import { fx3Explosion, fx3Proj } from '../render3d/fx3d.js';
import { barrelAt, blocked, inBeacon, smokeAt } from './board.js';
import { damage, explodeBarrel, playOnce, spendEnergy, hasCharAction, checkOverwatch, log, pickupLoot } from './combat.js';

export const COVER_COST=3, GAS_COST=3, GAS_DMG=12, GAS_TURNS=2, SWEEP_COST=2, SWEEP_RANGE=3;

export function placeCover(u,x,y){
  try{auPlay('sfx/abilities/drop_cover.mp3',0.55);}catch(e){}
  if(u.role!=='Ingeniero'&&!hasCharAction(u,'cover')){toast('La cobertura desplegable no está disponible para este personaje.');return;}
  if((u.covers||0)<=0){toast('Sin coberturas: el Ingeniero lleva 2 por partida.');return;}
  if(u.energy<COVER_COST){toast('La cobertura cuesta '+COVER_COST+' ⚡.');return;}
  if(cheb(u,{x,y})!==1){toast('La cobertura se despliega en una casilla adyacente.');return;}
  if(blocked(x,y)||inBeacon(x,y)){toast('Esa casilla está ocupada o es la baliza.');return;}
  G.lastMoveUndo=null;spendEnergy(u,COVER_COST);u.covers--;
  G.map.obstacles.push({type:'shelf',x,y,hp:60,cover:true});
  playOnce(u,'interact');sfx('place');
  log('🧱 '+u.role+' despliega cobertura en ('+(x+1)+','+(y+1)+'): 60 PV, estorba el paso y da cobertura. Quedan '+u.covers+'.');
  G.actionMode='move';updateUI();draw();
}

export function throwGas(u,x,y){
  if(u.role!=='Artillero'&&!hasCharAction(u,'gas')){toast('La granada de gas no está disponible para este personaje.');return;}
  if((u.gases||0)<=0){toast('Sin granadas de gas: el Artillero lleva 2 por partida.');return;}
  if(u.energy<GAS_COST){toast('La granada de gas cuesta '+GAS_COST+' ⚡.');return;}
  if(cheb(u,{x,y})>3){toast('La granada de gas se lanza a 3 casillas como máximo.');return;}
  if(cheb(u,{x,y})===0){toast('No te lances la granada de gas a los pies.');return;}
  G.lastMoveUndo=null;spendEnergy(u,GAS_COST);u.gases--;playOnce(u,'throw');
  if(typeof fx3Proj==='function')fx3Proj(u,{x,y},'m67');
  G.smoke.push({x,y,team:u.team,left:GAS_TURNS,kind:'gas'});
  log('☣ '+u.role+' ('+u.team+') lanza una granada de gas a ('+(x+1)+','+(y+1)+'): nube de '+GAS_TURNS+' rondas, '+GAS_DMG+' de daño por turno en radio 1.');
  G.actionMode='move';updateUI();draw();
}

export function sweepDetect(u,x,y){
  if(u.role!=='Espía'&&!hasCharAction(u,'sweep')){toast('El barrido detector no está disponible para este personaje.');return;}
  if((u.sweeps||0)<=0){toast('Sin barridos: el Espía lleva 1 por partida.');return;}
  if(u.energy<SWEEP_COST){toast('El barrido cuesta '+SWEEP_COST+' ⚡.');return;}
  if(cheb(u,{x,y})>SWEEP_RANGE){toast('El barrido alcanza '+SWEEP_RANGE+' casillas.');return;}
  G.lastMoveUndo=null;spendEnergy(u,SWEEP_COST);u.sweeps--;
  let found=0;
  G.units.filter(e=>e.alive&&e.team!==u.team&&e.invisible&&cheb(e,{x,y})<=1).forEach(e=>{e.invisible=false;e.invisTurns=0;found++;});
  playOnce(u,'interact');sfx('place');
  log('📡 '+u.role+' barre la zona de ('+(x+1)+','+(y+1)+'): '+(found?('revela '+found+' enemigo(s) invisible(s).'):'no hay invisibles en el radio.'));
  G.actionMode='move';updateUI();draw();
}

export const ORB_COST=4, ORB_DMG=80, ORB_RANGE=6;

export function fireOrbital(u,x,y){
  try{auPlay('sfx/weapons/strike_laser_a.mp3',0.6);}catch(e){}
  if(u.role!=='Artillero'&&!hasCharAction(u,'orbital')){toast('El láser orbital no está disponible para este personaje.');return;}
  if((u.orbitals||0)<=0){toast('Sin cargas orbitales: el Artillero lleva 1 por partida.');return;}
  if(u.energy<ORB_COST){toast('El láser orbital cuesta '+ORB_COST+' ⚡.');return;}
  if(cheb(u,{x,y})>ORB_RANGE){toast('El láser orbital alcanza '+ORB_RANGE+' casillas.');return;}
  G.lastMoveUndo=null;spendEnergy(u,ORB_COST);u.orbitals--;playOnce(u,'throw');sfx('boom');FX.shake=Math.max(FX.shake,10);
  if(typeof fx3Explosion==='function')fx3Explosion(x,y,'expl');
  fxBurst(x,y,18,'#8fd8ff');
  log('🛰 '+u.role+' ('+u.team+') pide el láser orbital sobre ('+(x+1)+','+(y+1)+'): '+ORB_DMG+' de daño en esa casilla (no hay salpicadura).');
  G.units.filter(t=>t.alive&&t.x===x&&t.y===y).forEach(t=>damage(t,ORB_DMG,'El láser orbital',u.team));
  if(G.drone&&G.drone.alive&&G.drone.x===x&&G.drone.y===y)damage(G.drone,ORB_DMG,'El láser orbital',u.team);
  G.actionMode='move';checkWin();updateUI();draw();
}

export const TRANQ_COST=2, TRANQ_RANGE=3, WATER_COST=3, WATER_RANGE=3, WATER_PUSH=2, TOOL_COST=3, TOOL_RANGE=2, TOOL_HEAL=80;

export function throwTranq(u,target){
  if(u.role!=='Espía'&&!hasCharAction(u,'tranq')){toast('El tranquilizante no está disponible para este personaje.');return;}
  if((u.tranqs||0)<=0){toast('Sin tranquilizantes: el Espía lleva 1 por partida.');return;}
  if(u.energy<TRANQ_COST){toast('El tranquilizante cuesta '+TRANQ_COST+' ⚡.');return;}
  if(!target||target.team===u.team){toast('Elige un enemigo a '+TRANQ_RANGE+' casillas o menos.');return;}
  if(cheb(u,target)>TRANQ_RANGE){toast('El tranquilizante alcanza '+TRANQ_RANGE+' casillas.');return;}
  G.lastMoveUndo=null;spendEnergy(u,TRANQ_COST);u.tranqs--;playOnce(u,'throw');sfx('flash');
  applyStun(target);
  log('💉 '+u.role+' dispara el tranquilizante a '+target.role+': queda aturdido su siguiente turno (sin daño).');
  G.actionMode='move';checkWin();updateUI();draw();
}

export function waterCannon(u,target){
  if(u.role!=='Comando'&&!hasCharAction(u,'water')){toast('El cañón de agua no está disponible para este personaje.');return;}
  if((u.water||0)<=0){toast('Sin cargas de cañón de agua.');return;}
  if(u.energy<WATER_COST){toast('El cañón de agua cuesta '+WATER_COST+' ⚡.');return;}
  if(!target||target.team===u.team){toast('Elige un enemigo a '+WATER_RANGE+' casillas o menos.');return;}
  if(cheb(u,target)>WATER_RANGE){toast('El cañón de agua alcanza '+WATER_RANGE+' casillas.');return;}
  G.lastMoveUndo=null;spendEnergy(u,WATER_COST);u.water--;playOnce(u,'throw');sfx('place');
  const ax=target.x-u.x,ay=target.y-u.y;
  const sx=Math.sign(ax),sy=Math.sign(ay);
  let px=target.x,py=target.y;
  for(let k=0;k<WATER_PUSH;k++){
    const nx=px+sx,ny=py+sy;
    if(nx<0||ny<0||nx>=W||ny>=H)break;
    if(blocked(nx,ny)||G.units.some(o=>o!==target&&o.alive&&o.x===nx&&o.y===ny))break;
    px=nx;py=ny;
  }
  if(px!==target.x||py!==target.y){target.x=px;target.y=py;target.dx=px;target.dy=py;checkMines(target);}
  log('💦 '+u.role+' ('+u.team+') dispara el cañón de agua: empuja a '+target.role+' hasta ('+(target.x+1)+','+(target.y+1)+') sin daño.');
  G.actionMode='move';updateUI();draw();
}

export function useToolkit(u){
  if(u.role!=='Ingeniero'&&!hasCharAction(u,'toolkit')){toast('El kit de herramientas no está disponible para este personaje.');return;}
  if((u.toolkits||0)<=0){toast('Sin kits: el Ingeniero lleva 2 por partida.');return;}
  if(u.energy<TOOL_COST){toast('El kit cuesta '+TOOL_COST+' ⚡.');return;}
  const t=G.deployed.filter(d=>d.alive&&d.team===u.team&&d.hp<d.maxHp).sort((a,b)=>cheb(u,a)-cheb(u,b))[0];
  if(!t){toast('No hay torretas propias dañadas: el kit repara desplegables.');return;}
  if(cheb(u,t)>TOOL_RANGE){toast('El kit alcanza '+TOOL_RANGE+' casillas.');return;}
  G.lastMoveUndo=null;spendEnergy(u,TOOL_COST);u.toolkits--;
  t.hp=Math.min(t.maxHp,t.hp+TOOL_HEAL);playOnce(u,'interact');sfx('place');
  log('🔧 '+u.role+' repara la torreta de ('+(t.x+1)+','+(t.y+1)+'): +'+TOOL_HEAL+' PV (ahora '+t.hp+'/'+t.maxHp+').');
  updateUI();draw();
}

export const SHIELD_COST=3, SHIELD_TURNS=1, SHIELD_MULT=0.55, ARTY_COST=4, ARTY_DMG=60, ARTY_RANGE=3, BEES_COST=2, BEES_DMG=8, BEES_TURNS=2, BEES_RANGE=4;
export const TRUNK_COST=3, TRUNK_DMG=91, TRUNK_RANGE=5;

export function useShield(u){
  if(u.role!=='Comando'&&!hasCharAction(u,'shield')){toast('El escudo antidisturbios no está disponible para este personaje.');return;}
  if((u.shields||0)<=0){toast('Sin escudo antidisturbios.');return;}
  if(u.energy<SHIELD_COST){toast('El escudo cuesta '+SHIELD_COST+' ⚡.');return;}
  G.lastMoveUndo=null;spendEnergy(u,SHIELD_COST);u.shields--;u.shieldT=SHIELD_TURNS;
  playOnce(u,'interact');sfx('place');
  log('🛡 '+u.role+' levanta el escudo antidisturbios: recibe un 55 % del daño durante '+SHIELD_TURNS+' turno.');
  updateUI();draw();
}

export function fireArtillery(u,x,y){
  try{auPlay('sfx/weapons/strike_artillery_a.mp3',0.6);}catch(e){}
  if(u.role!=='Artillero'&&!hasCharAction(u,'arty')){toast('La artillería no está disponible para este personaje.');return;}
  if((u.arty||0)<=0){toast('Sin cargas de artillería: el Artillero lleva 2 por partida.');return;}
  if(u.energy<ARTY_COST){toast('La artillería cuesta '+ARTY_COST+' ⚡.');return;}
  if(cheb(u,{x,y})>ARTY_RANGE){toast('La artillería alcanza '+ARTY_RANGE+' casillas.');return;}
  if(cheb(u,{x,y})===0){toast('La artillería no cae sobre tus propios pies.');return;}
  G.lastMoveUndo=null;spendEnergy(u,ARTY_COST);u.arty--;playOnce(u,'throw');sfx('boom');FX.shake=Math.max(FX.shake,13);
  if(typeof fx3Explosion==='function')fx3Explosion(x,y,'expl');
  fxBurst(x,y,26,'#ff9640');
  log('💥 '+u.role+' ('+u.team+') pide artillería sobre ('+(x+1)+','+(y+1)+'): '+ARTY_DMG+' de daño en el centro y 35 alrededor.');
  G.units.filter(t=>t.alive&&cheb(t,{x,y})<=1).forEach(t=>damage(t,t.x===x&&t.y===y?ARTY_DMG:35,'La artillería',u.team));
  if(G.drone&&G.drone.alive&&cheb(G.drone,{x,y})<=1)damage(G.drone,G.drone.x===x&&G.drone.y===y?ARTY_DMG:35,'La artillería',u.team);
  G.map.obstacles.filter(o=>cheb(o,{x,y})<=1).forEach(o=>{if(o.type==='crate')o.hp-=ARTY_DMG;});
  G.map.obstacles=G.map.obstacles.filter(o=>!(o.type==='crate'&&o.hp<=0));
  const b=barrelAt(x,y)||G.map.barrels.find(bb=>bb.alive&&cheb(bb,{x,y})<=1);if(b)explodeBarrel(b,'la artillería',u.team);
  G.actionMode='move';checkWin();updateUI();draw();
}

export function throwTrunk(u,x,y){
  try{auPlay('sfx/weapons/axe_swing_01.mp3',0.6);}catch(e){}
  if(u.role!=='Artillero'&&!hasCharAction(u,'trunk')){toast('El Trunkquilizer no está disponible para este personaje.');return;}
  if((u.trunks||0)<=0){toast('Sin cargas de Trunkquilizer: Tree Mendez lleva 1 por partida.');return;}
  if(u.energy<TRUNK_COST){toast('El Trunkquilizer cuesta '+TRUNK_COST+' ⚡.');return;}
  const dx=x-u.x,dy=y-u.y;
  if(!dx&&!dy){toast('Apunta a una casilla para trazar la línea.');return;}
  if(Math.max(Math.abs(dx),Math.abs(dy))>TRUNK_RANGE){toast('El Trunkquilizer alcanza '+TRUNK_RANGE+' casillas.');return;}
  const sx=Math.abs(dx)>=Math.abs(dy)?Math.sign(dx):0, sy=Math.abs(dx)>=Math.abs(dy)?0:Math.sign(dy);
  const cells=[];for(let i=1;i<=TRUNK_RANGE;i++){const cx=u.x+sx*i,cy=u.y+sy*i;if(cx>=0&&cy>=0&&cx<(G.W||99)&&cy<(G.H||99))cells.push({x:cx,y:cy});}
  if(!cells.length){toast('La línea no cabe en el tablero desde ahí.');return;}
  G.lastMoveUndo=null;spendEnergy(u,TRUNK_COST);u.trunks--;playOnce(u,'throw');sfx('boom');FX.shake=Math.max(FX.shake,10);
  cells.forEach(c=>{if(typeof fx3Explosion==='function')fx3Explosion(c.x,c.y,'expl');fxBurst(c.x,c.y,14,'#b8d94e');});
  log('🌳 '+u.role+' ('+u.team+') golpea con el Trunkquilizer en línea: '+TRUNK_DMG+' de daño en '+cells.length+' casillas.');
  G.units.filter(t=>t.alive&&cells.some(c=>c.x===t.x&&c.y===t.y)).forEach(t=>damage(t,TRUNK_DMG,'El Trunkquilizer',u.team));
  if(G.drone&&G.drone.alive&&cells.some(c=>c.x===G.drone.x&&c.y===G.drone.y))damage(G.drone,TRUNK_DMG,'El Trunkquilizer',u.team);
  G.map.obstacles.filter(o=>cells.some(c=>c.x===o.x&&c.y===o.y)).forEach(o=>{if(o.type==='crate')o.hp-=TRUNK_DMG;});
  G.map.obstacles=G.map.obstacles.filter(o=>!(o.type==='crate'&&o.hp<=0));
  const b=G.map.barrels.find(bb=>bb.alive&&cells.some(c=>c.x===bb.x&&c.y===bb.y));if(b)explodeBarrel(b,'el Trunkquilizer',u.team);
  G.actionMode='move';checkWin();updateUI();draw();
}

export function throwBees(u,target){
  if(u.role!=='Espía'&&!hasCharAction(u,'bees')){toast('La bomba de abejas no está disponible para este personaje.');return;}
  if((u.bees||0)<=0){toast('Sin bombas de abejas: el Espía lleva 1 por partida.');return;}
  if(u.energy<BEES_COST){toast('La bomba de abejas cuesta '+BEES_COST+' ⚡.');return;}
  if(!target||target.team===u.team){toast('Elige un enemigo a '+BEES_RANGE+' casillas o menos.');return;}
  if(cheb(u,target)>BEES_RANGE){toast('La bomba de abejas alcanza '+BEES_RANGE+' casillas.');return;}
  G.lastMoveUndo=null;spendEnergy(u,BEES_COST);u.bees--;playOnce(u,'throw');
  target.beesT=BEES_TURNS;target.beesTeam=u.team;
  log('🐝 '+u.role+' lanza la bomba de abejas a '+target.role+': '+BEES_DMG+' de daño por turno durante '+BEES_TURNS+' turnos.');
  G.actionMode='move';updateUI();draw();
}

export const MOLOTOV_COST=3, MOLOTOV_DMG=15, MOLOTOV_TURNS=2, CRATE_COST=3, TELE_COST=3, TELE_RANGE=4;

export function throwMolotov(u,x,y){
  try{auPlay('sfx/weapons/grenade_throw_01.mp3',0.5);}catch(e){}
  if(u.role!=='Artillero'&&!hasCharAction(u,'molotov')){toast('El cóctel molotov no está disponible para este personaje.');return;}
  if((u.molotovs||0)<=0){toast('Sin molotovs: el Artillero lleva 2 por partida.');return;}
  if(u.energy<MOLOTOV_COST){toast('El molotov cuesta '+MOLOTOV_COST+' ⚡.');return;}
  if(cheb(u,{x,y})>3){toast('El molotov se lanza a 3 casillas como máximo.');return;}
  if(cheb(u,{x,y})===0){toast('No te lances el molotov a los pies.');return;}
  G.lastMoveUndo=null;spendEnergy(u,MOLOTOV_COST);u.molotovs--;playOnce(u,'throw');sfx('boom');
  if(typeof fx3Proj==='function')fx3Proj(u,{x,y},'m67');
  G.smoke.push({x,y,team:u.team,left:MOLOTOV_TURNS,kind:'fuego'});
  log('🔥 '+u.role+' ('+u.team+') lanza un molotov a ('+(x+1)+','+(y+1)+'): fuego de '+MOLOTOV_TURNS+' rondas, '+MOLOTOV_DMG+' de daño por turno en radio 1 (no corta la visión).');
  G.actionMode='move';updateUI();draw();
}

export function placeHealthCrate(u,x,y){
  if(u.role!=='Médico'&&!hasCharAction(u,'crate')){toast('La caja de salud no está disponible para este personaje.');return;}
  if((u.crates||0)<=0){toast('Sin cajas: el Médico lleva 2 por partida.');return;}
  if(u.energy<CRATE_COST){toast('La caja de salud cuesta '+CRATE_COST+' ⚡.');return;}
  if(cheb(u,{x,y})!==1){toast('La caja se deja en una casilla adyacente libre.');return;}
  if(blocked(x,y)||inBeacon(x,y)){toast('Esa casilla está ocupada o es la baliza.');return;}
  G.lastMoveUndo=null;spendEnergy(u,CRATE_COST);u.crates--;playOnce(u,'interact');sfx('place');
  G.lootBoxes.push({x,y,kind:'salud'});
  log('✚ '+u.role+' deja una caja de Salud en ('+(x+1)+','+(y+1)+'): +75 PV a quien se plante encima. Quedan '+u.crates+'.');
  G.actionMode='move';updateUI();draw();
}

export function teleportUnit(u,x,y){
  if(u.role!=='Espía'&&!hasCharAction(u,'teleport')){toast('El teletransporte no está disponible para este personaje.');return;}
  if((u.teleports||0)<=0){toast('Sin cargas de teletransporte: el Espía lleva 1 por partida.');return;}
  if(u.energy<TELE_COST){toast('El teletransporte cuesta '+TELE_COST+' ⚡.');return;}
  if(cheb(u,{x,y})>TELE_RANGE){toast('El teletransporte alcanza '+TELE_RANGE+' casillas.');return;}
  if(cheb(u,{x,y})===0){toast('Ya estás en esa casilla.');return;}
  if(blocked(x,y)||inBeacon(x,y)||unitAt(x,y)){toast('Esa casilla está ocupada o es la baliza.');return;}
  G.lastMoveUndo=null;spendEnergy(u,TELE_COST);u.teleports--;
  const fx0=u.x,fy0=u.y;u.x=x;u.y=y;u.dx=x;u.dy=y;u.movedThisTurn=true;
  playOnce(u,'interact');sfx('flash');
  log('🌀 '+u.role+' se teletransporta de ('+(fx0+1)+','+(fy0+1)+') a ('+(x+1)+','+(y+1)+').');
  checkMines(u);checkOverwatch(u);pickupLoot(u);
  G.actionMode='move';updateUI();draw();
}

export function throwSmoke(u,x,y){
  if(u.role!=='Espía'&&!hasCharAction(u,'smoke')){toast('La M18 de humo no está disponible para este personaje.');return;}
  if((u.smokes||0)<=0){toast('Sin granadas de humo M18: el Espía lleva 2 por partida.');return;}
  if(u.energy<2){toast('La M18 cuesta 2 de energía.');return;}
  if(cheb(u,{x,y})>4){toast('La M18 se lanza a 4 casillas como máximo.');return;}
  if(cheb(u,{x,y})===0){toast('La M18 no se lanza a los propios pies: elige una casilla a 1–4 de distancia.');return;}
  G.lastMoveUndo=null;
  spendEnergy(u,2);u.smokes--;playOnce(u,'throw');
  if(typeof fx3Proj==='function')fx3Proj(u,{x,y},'smoke');
  if(typeof fx3Explosion==='function')fx3Explosion(x,y,'smoke');
  if(!G.smoke)G.smoke=[];
  const tiles=[{x,y},{x:x+1,y},{x:x-1,y},{x,y:y+1},{x,y:y-1}].filter(t=>t.x>=0&&t.y>=0&&t.x<W&&t.y<H);
  tiles.forEach(t=>{if(!smokeAt(t.x,t.y))G.smoke.push({x:t.x,y:t.y,team:u.team,left:SMOKE_TURNS,untilRound:G.round+SMOKE_TURNS});});
  log('💨 '+u.role+' ('+u.team+') lanza una M18: cortina de humo sobre ('+(x+1)+','+(y+1)+') y sus casillas adyacentes. La visión a través del humo queda bloqueada '+SMOKE_TURNS+' rondas; el movimiento, no.');
  fxBurst(x,y,10,'#cfd4d9');
  G.actionMode='move';updateUI();draw();
}
