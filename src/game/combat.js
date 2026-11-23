import { NATIONS } from '../data/nations.js';
import { ROLES, BODIES } from '../data/roles.js';
import { WEAPONS, PISTOL } from '../data/weapons.js';
import { CHARACTERS, CHARACTER_ABILITIES, CHAR_ABILITY_ACTIONS } from '../data/cast.js';
import { MAP_DEFS, CAMPAIGN_MISSIONS, TUTORIAL_MISSION } from '../data/maps.js';
import { cheb, shortestArc } from '../core/geometry.js';
import { sfx, auVoice } from '../core-and-audio.js';
import { CLIPLIB } from '../render3d/clips.js';

export const SPAWNS_A=[{x:0,y:3},{x:0,y:5},{x:1,y:6},{x:0,y:7},{x:0,y:6}];

export const SPAWNS_B=[{x:11,y:8},{x:11,y:6},{x:10,y:5},{x:11,y:4},{x:11,y:5}];

export function charAbilitiesFor(ch){
  if(!ch||!ch.name)return [];
  const list=CHARACTER_ABILITIES[ch.name];
  if(!list)return [];
  return list.map(a=>({icon:a.icon,n:a.n,d:a.d,obj:a.obj,action:CHAR_ABILITY_ACTIONS[a.icon]||null,implemented:!!CHAR_ABILITY_ACTIONS[a.icon]}));
}

export function hasCharAction(u,action){return !!(u&&u.charAbilities&&u.charAbilities.some(a=>a.implemented&&a.action===action));}

export function hasCharIcon(u,icon){return !!(u&&u.charAbilities&&u.charAbilities.some(a=>a.implemented&&a.icon===icon));}

export function applyCharacterAbilities(u){
  const ensure=(key,n)=>{if((u[key]||0)<n)u[key]=n;};
  if(hasCharAction(u,'smoke'))ensure('smokes',2);
  if(hasCharAction(u,'flash'))ensure('flashes',2);
  if(hasCharAction(u,'molotov'))ensure('molotovs',2);
  if(hasCharAction(u,'toolkit'))ensure('toolkits',2);
  if(hasCharAction(u,'water'))ensure('water',2);
  if(hasCharAction(u,'shield'))ensure('shields',1);
  if(hasCharAction(u,'arty'))ensure('arty',2);
  if(hasCharAction(u,'mine'))ensure('mines',2);
  if(hasCharAction(u,'cover'))ensure('covers',2);
  if(hasCharAction(u,'gas'))ensure('gases',2);
  if(hasCharAction(u,'crate'))ensure('crates',2);
  if(hasCharAction(u,'teleport'))ensure('teleports',1);
  if(hasCharAction(u,'bees'))ensure('bees',1);
  if(hasCharAction(u,'sweep'))ensure('sweeps',1);
  if(hasCharAction(u,'orbital'))ensure('orbitals',1);
  if(hasCharAction(u,'tranq'))ensure('tranqs',1);
}

export function unitHasAction(u,action){
  if(!u)return false;
  if(['shoot','pistol','grenade','overwatch','capture','guide'].includes(action))return true;
  if(action==='special')return hasCharAction(u,'special')||!(u.charAbilities&&u.charAbilities.length);
  if(u.charAbilities&&u.charAbilities.length)return hasCharAction(u,action);
  const roleActions={smoke:'Espía',flash:'Comando',mine:'Ingeniero',cover:'Ingeniero',gas:'Artillero',molotov:'Artillero',crate:'Médico',teleport:'Espía',shield:'Comando',arty:'Artillero',bees:'Espía',tranq:'Espía',water:'Comando',toolkit:'Ingeniero',deployRocket:'Ingeniero',orbital:'Artillero',sweep:'Espía',deploy:'Ingeniero'};
  return roleActions[action]===u.role;
}

export function canHealSpecial(u){return !!(u&&(u.role==='Médico'||hasCharIcon(u,'CharAbility_30_Medkit_alpha')||hasCharIcon(u,'CharAbility_36_Revive_alpha')));}

export function canReviveSpecial(u){return !!(u&&((u.role==='Médico'&&!(u.charAbilities&&u.charAbilities.length))||hasCharIcon(u,'CharAbility_36_Revive_alpha')));}

export function canSnipeSpecial(u){return !!(u&&(u.role==='Francotirador'||hasCharIcon(u,'CharAbility_42_Sniper_Rifle_Specialization_alpha')));}

export function charForKey(role,key){
  const origOnly=setup.mode==='campana'||setup.mode==='tutorial'||!!setup.isTutorial;
  const opts=charsForRole(role,origOnly);
  return opts.find(c=>characterKey(c)===key)||opts[0]||null;
}

export function makeUnit(team,def,i,nation,skin){
  const list=spawnsFor(team);const sp=list[i%list.length]||(team==='A'?SPAWNS_A[0]:SPAWNS_B[0]);
  const origOnly=setup.mode==='campana'||setup.mode==='tutorial'||!!setup.isTutorial;
  const ch=(def&&def.charKey?charForKey(def.role,def.charKey):null)||characterForRole(def.role,i,origOnly);
  const role=ROLES[def.role];
  const body=BODIES[role.body]||BODIES.medio;
  let hp=body.hp,maxHp=body.hp,energy=body.energy,maxEnergy=body.energy,vetLevel=0;
  /* Veterania de campaña: solo tu escuadra, por posición, acumulada al sobrevivir misiones */
  if(team==='A'&&setup.mode==='campana'){const c=loadCampaign();vetLevel=(c.vet&&c.vet[i])||0;if(vetLevel>0){maxHp+=vetLevel*25;hp=maxHp;maxEnergy+=vetLevel;energy=maxEnergy;}}
  /* Dificultad de la IA: solo la escuadra rival cuando juega la máquina */
  if(team==='B'&&setup.opp==='ia'){if(setup.difficulty==='veterano'){maxEnergy+=1;energy=maxEnergy;}else if(setup.difficulty==='elite'){maxEnergy+=2;energy=maxEnergy;maxHp+=25;hp=maxHp;}}
  const u={id:++uid,team,role:def.role,name:ch?ch.name:def.role,charKey:characterKey(ch),charName:ch?ch.name:def.role,charBio:ch?ch.bio:'',charTexture:ch&&ch.texture?ch.texture:'',charMesh:ch&&ch.mesh?ch.mesh:'',charAbilities:charAbilitiesFor(ch),weapon:def.weapon,skin:skin||'nacion',x:sp.x,y:sp.y,dx:sp.x,dy:sp.y,hp:hp,maxHp:maxHp,
    energy:energy,maxEnergy:maxEnergy,alive:true,invisible:false,invisTurns:0,suppressed:false,stunned:false,stunFresh:false,vetLevel:vetLevel,slotIndex:i,
    grenades:def.role==='Comando'?2:1,flashes:def.role==='Comando'?2:0,smokes:def.role==='Espía'?2:0,mines:def.role==='Ingeniero'?2:0,covers:def.role==='Ingeniero'?2:0,gases:def.role==='Artillero'?2:0,sweeps:def.role==='Espía'?1:0,molotovs:def.role==='Artillero'?2:0,crates:def.role==='Médico'?2:0,teleports:def.role==='Espía'?1:0,shields:def.role==='Comando'?1:0,arty:def.role==='Artillero'?2:0,bees:def.role==='Espía'?1:0,tranqs:def.role==='Espía'?1:0,water:def.role==='Comando'?2:0,toolkits:def.role==='Ingeniero'?2:0,orbitals:def.role==='Artillero'?1:0,heals:2,revives:1,captainUsed:false,movedThisTurn:false,
    specialUsedTurn:false,onceUsed:false,nation,hasShot:false,
    facing:team==='A'?0:2,overwatch:false,returnKey:'',body:role.body,moveCost:body.moveCost};
  applyCharacterAbilities(u);
  return u;
}

export function startGame(squadA,squadB){
  resetCam3D();
  uid=0;
  const rivalNation=setup.mode==='guerra'?setup.rivalNation:(setup.opp==='local'?myNation:NATIONS[Math.floor(Math.random()*NATIONS.length)]);
  const campMission=setup.mode==='tutorial'?TUTORIAL_MISSION:(setup.mode==='campana'?CAMPAIGN_MISSIONS[setup.campaignMission]:null);
  const matchSeed=((Math.random()*0x7fffffff)>>>0)||1;
  G={mode:setup.mode,opp:setup.opp,turn:'A',round:1,matchSeed,units:[],map:buildMap(setup.map),deployed:[],lootBoxes:[],lootDropped:{},
     beacon:{A:0,B:0},dom:{A:0,B:0},stats:{A:{dmg:0,kills:0},B:{dmg:0,kills:0}},smoke:[],mines:[],drone:effSetupMode()==='escolta'?{isDrone:true,role:'Dron averiado',team:'A',x:escortStart().x,y:escortStart().y,dx:escortStart().x,dy:escortStart().y,hp:ESCORT_DRONE_HP,maxHp:ESCORT_DRONE_MAXHP,alive:true,invisible:false,weapon:null,facing:0,movesLeft:ESCORT_GUIDES_PER_ROUND,movedThisTurn:false,delivered:false}:null,difficulty:setup.opp==='ia'?setup.difficulty:'normal',isTutorial:setup.mode==='tutorial',campaignMission:setup.mode==='campana'?setup.campaignMission:(setup.mode==='tutorial'?0:null),campaignName:campMission?campMission.id:null,campaignTitle:campMission?campMission.title:null,campaignTurnLimit:campMission?campMission.turnLimit:null,campaignObjective:campMission?campMission.objective:null,
     selected:null,actionMode:'move',over:false,aiBusy:false,lastMoveUndo:null,rivalNation,
     names:{A:myNation.name+' (J1)',B:setup.mode==='guerra'?rivalNation.name+' (IA)':(setup.opp==='ia'?'Escuadra IA':'Jugador 2')}};
  document.body.dataset.state='playing';
  setStep('battle','Ronda 1 · '+G.names.A);
  /* Al jugar se retira la portada: el 3D ocupa la pantalla. */
  try{const hp=document.querySelector('#scr-play .hero');if(hp)hp.style.display='none';const mp=document.getElementById('menuArea');if(mp)mp.style.display='none';}catch(e){}
  try{auAmbient(G.map.theme);}catch(e){}
  try{auMusicStart();}catch(e){}
  setTurnSeed(1,'A');
  squadA.forEach((d,i)=>G.units.push(makeUnit('A',d,i,myNation,setup.skinA)));
  squadB.forEach((d,i)=>G.units.push(makeUnit('B',d,i,rivalNation,setup.opp==='local'?setup.skinB:'nacion')));
  const startTheme=(MAP_DEFS[setup.map]||{}).theme;
  if(startTheme&&skState(startTheme)){loadSkirmishTop(startTheme);loadSkirmishGeo(startTheme);}
  if(setup.mode==='guerra'){lsSet(LS_GAMES,+(lsGet(LS_GAMES)||0)+1);}
  $('#setupArea').style.display='none';$('#menuArea').style.display='none';$('#gameArea').style.display='block';
  $('#log').innerHTML='';
  log('Despliegue en el mapa '+G.map.name+'. Modo: '+(effMode(G)==='eliminacion'?'Eliminación':effMode(G)==='dominacion'?'Dominación':effMode(G)==='escolta'?'Escolta del dron':G.mode==='guerra'?'Guerra de Naciones · Captura de baliza':'Captura de baliza')+(G.mode==='campana'?(' · Campaña Misión '+(G.campaignMission+1)+' · '+CAMPAIGN_MISSIONS[G.campaignMission].title):'')+(G.mode==='tutorial'?(' · '+TUTORIAL_MISSION.title):'')+' · Dificultad IA: '+G.difficulty+' · '+setup.fmt+' contra '+setup.fmt+'.');
  if(effMode(G)==='dominacion')log('⬢ Dominación: mantén las zonas (Depósito, Centro, Muelle) hasta el inicio de tu siguiente turno (desde la ronda 2): +1 punto por zona y +1 extra si dominas las tres. Gana quien llegue a '+DOM_TARGET+' puntos.');
  if(effMode(G)==='escolta')log('🤖 Escolta: el dron averiado ('+ESCORT_DRONE_HP+'/'+ESCORT_DRONE_MAXHP+' PV) espera en (2,6). Pega un soldado a él (daño reducido a ~la mitad mientras tenga escolta pegado), pulsa «Guiar dron» (2 ⚡) y toca la casilla destino: máximo '+ESCORT_GUIDES_PER_ROUND+' guiados por ronda. Si pisa la extracción del este (columnas 11–12, filas 6–7), gana la escolta; si el dron cae o pasan '+ESCORT_MAX_ROUNDS+' rondas, gana la defensa.');
  G.units.filter(u=>u.team==='A'&&u.vetLevel>0).forEach(u=>log('★ '+u.role+' entra con veterania nivel '+u.vetLevel+': +'+(u.vetLevel*25)+' PV y +'+u.vetLevel+' ⚡ por las misiones que ya sobrevivió.'));
  if(G.mode==='guerra')log('⚑ '+myNation.name+' contra '+rivalNation.name+'. Que gane tu nación.');
  log('Turno de '+G.names.A+'. Toca un soldado para seleccionarlo, toca una casilla iluminada para mover y a un enemigo para disparar.');
  selectUnit(G.units.find(u=>u.team==='A'));
  updateUI();draw();
  if(window.__build3D)window.__build3D();
  if(!lsGet('radsoldiers_tut'))setTimeout(tutShow,900);
  window.scrollTo({top:0,behavior:'smooth'});
}

export function log(msg){const el=$('#log');const d=document.createElement('div');const safe=String(msg).replace(/&/g,'&amp;').replace(/</g,'&lt;').replace(/>/g,'&gt;').replace(/&lt;b&gt;/g,'<b>').replace(/&lt;\/b&gt;/g,'</b>');d.innerHTML='<span class="t">R'+(G?G.round:'–')+'</span> '+safe;el.prepend(d);}

export function teamName(t){return G.names[t];}

export function aliveCount(t){return G.units.filter(u=>u.team===t&&u.alive).length;}

export function selectUnit(u){if(!u)return;G.selected=u;G.actionMode='move';if(u.team===G.turn)auVoice(u,'select',0.45);updateUI();draw();}

export function spendEnergy(u,n){u.energy-=n;}

export function fireClipFor(weaponName){
  const cat=(WEAPONS[weaponName]||{}).cat;
  if(weaponName==='M1911'||weaponName==='Desert Eagle')return 'fire1hHeavy';
  if(weaponName==='MP7'||weaponName==='UMP45'||weaponName==='KRISS Vector')return 'fire1hBurst';
  if(cat==='Subfusiles')return 'fireBurst';
  if(weaponName==='M134 Minigun')return 'fireMini';
  if(cat==='Pistolas')return 'fire1h';
  if(cat==='Cuerpo a cuerpo')return 'fireMelee';
  if(cat==='Ametralladoras')return 'fireBurst';
  if(cat==='Francotirador')return (weaponName==='M110 SASS'||weaponName==='SVD Dragunov'||weaponName==='Mk 14 EBR'||weaponName==='PSG-1')?'fire2h':'fireHeavy';
  if(cat==='Lanzacohetes'||cat==='Lanzagranadas')return 'fireShoulder';
  if(cat==='Escopetas')return 'fireHeavy';
  return 'fire2h';
}


export function playOnce(u,key){if(u){u._onceKey=key;u._onceT=FX.t;}}

export function damage(target,dmg,srcLabel,srcTeam){
  if(!target.alive)return;
  if(target.isDrone&&G&&G.units&&G.units.some(u=>u.alive&&u.team==='A'&&cheb(u,target)<=1)){
    dmg=Math.max(1,Math.round(dmg*0.47));
  }
  if(target.buffArmor&&!target.isDrone)dmg=Math.max(1,Math.round(dmg*target.buffArmor));
  if(target.shieldT>0&&!target.isDrone)dmg=Math.max(1,Math.round(dmg*SHIELD_MULT));
  target.hp-=dmg;
  const dmgTeam=srcTeam||(G&&G._dmgTeam)||null;
  if(G&&G.stats&&dmgTeam&&dmgTeam!==target.team){const st=G.stats[dmgTeam];st.dmg+=dmg;if(target.hp<=0)st.kills++;}
  /* Tipo de impacto, para elegir el clip del original en la vista 3D:
     explosión (barril, M67, salpicadura, lanzacohetes, lanzagranadas),
     ráfaga (ametralladoras) o bala; la muerte hereda el mismo tipo. */
  const expl=/explos|M67|salpicadura|barril|RPG|AT4|M72|M203|M32/i.test(srcLabel||'');
  const kind=expl?'expl':(/M249|M240|PKM|MG3/.test(srcLabel||'')?'burst':'bullet');
  target._hitAmt=Math.min(1,dmg/70);target._hitKind=kind;
  const delayed=target._visualDelayUntil!=null&&FX.t<target._visualDelayUntil;
  if(delayed)target._pendingHit={t:FX.t,amt:target._hitAmt,kind:kind,death:false};
  else target._hitT=FX.t;
  /* Impacto seco del original (bala), solo en dano no explosivo. */
  if(!expl&&(!CLIPLIB.ready||window.__noClips||REDUCED_MOTION||VIEW_MODE!=='3d')){try{auPlay('sfx/weapons/bullet_hit_0'+(1+Math.floor(Math.random()*2))+'.mp3',0.25);}catch(e){}}
  if(target.hp<=0&&target._deathT==null){
    if(delayed&&target._pendingHit)target._pendingHit.death=true;
    else{target._deathT=FX.t;target._deathKind=kind;}
  }
  if(target.x!=null){fxFloat(target.x,target.y,'−'+dmg,'#ffd9d2');fxBurst(target.x,target.y,7,'#ffb199');}
  log(srcLabel+' hace <b>'+dmg+'</b> de daño a '+target.role+' ('+target.team+'). Le quedan '+Math.max(0,target.hp)+' PV.');
  if(target.hp<=0){target.hp=0;target.alive=false;target.invisible=false;if(!target.isDrone)auVoice(target,'death',0.55);log('✕ '+target.role+' ('+target.team+') eliminado.');}
  else if(!target.isDrone&&Math.random()<0.2)auVoice(target,'pain',0.35);
}

export function explodeBarrel(b,srcLabel,srcTeam){
  try{auPlay('sfx/weapons/cluster_explode.mp3',0.6);}catch(e){}
  if(!b.alive)return;b.alive=false;G.lastMoveUndo=null;FX.shake=11;sfx('boom');fxBurst(b.x,b.y,22,'#ffb03a');fxFloat(b.x,b.y,'💥','#ffe1a8');if(typeof fx3Explosion==='function')fx3Explosion(b.x,b.y,'expl');
  log('💥 ¡Barril explotado por '+srcLabel+'! 70 de daño en las casillas adyacentes.');
  G.units.filter(u=>u.alive&&cheb(u,b)<=1).forEach(u=>damage(u,70,'La explosión del barril',srcTeam));
  if(G.drone&&G.drone.alive&&cheb(G.drone,b)<=1)damage(G.drone,70,'La explosión del barril',srcTeam);
  G.map.obstacles.filter(o=>o.type==='crate'&&cheb(o,b)<=1).forEach(o=>{o.hp-=70;});
  G.map.obstacles=G.map.obstacles.filter(o=>!(o.type==='crate'&&o.hp<=0));
  G.map.barrels.filter(o=>o.alive&&o!==b&&cheb(o,b)<=1).forEach(o=>explodeBarrel(o,'la reacción en cadena',srcTeam));
  checkWin();
}

export function tryShoot(shooter,target,weaponName,multiplier,opts){
  if(!shooter||!shooter.alive)return false;
  opts=opts||{};
  if(G)G._dmgTeam=shooter.team;
  if(G&&target&&target.x!=null)G._camFocus={x:target.x,y:target.y,until:Date.now()+2600};
  const w=WEAPONS[weaponName];
  const freeCost=!!opts.freeCost;
  if(!freeCost&&shooter.energy<w.cost){toast('Energía insuficiente: '+weaponName+' cuesta '+w.cost+' ⚡.');return false;}
  if(w.once&&shooter.onceUsed){toast(weaponName+' ya se gastó: es de un solo uso por partida.');return false;}
  let p=hitChance(shooter,target,w);
  /* La penalización solo se aplica a un tiro posible: aplicarla sobre
     un p de 0 lo resucitaba a un 5 % mínimo, y el fuego de respuesta y
     la vigilancia podían disparar así a través del humo, de un muro o
     contra un objetivo invisible. */
  if(opts.hitPenalty&&p>0)p=Math.max(5,p-opts.hitPenalty);
  if(p<=0){if(!opts.silent)toast(target.invisible?'Ese objetivo es invisible.':(smokeBlocksLOS(shooter,target)?'Sin tiro: el humo M18 corta la línea de visión. Acércate a 1 casilla o rodea la cortina.':'Sin tiro: fuera de alcance o sin línea de visión.'));return false;}
  G.lastMoveUndo=null;
  if(!freeCost)spendEnergy(shooter,w.cost);shooter.hasShot=true;if(shooter.invisible){shooter.invisible=false;log('La invisibilidad del Espía se rompe al disparar.');}
  if(w.once)shooter.onceUsed=true;
  const f=angleToFacing(target.x-shooter.x,target.y-shooter.y);if(f!=null)shooter.facing=f;
  shooter._shootT=FX.t;shooter._shootW=weaponName;shooter._shootCat=w.cat;shooter._shootAt=target&&target.x!=null?{x:target.x,y:target.y}:null;shooter._shootTarget=target&&target.x!=null?target:null;shooter._fireKey=fireClipFor(weaponName);
  const fireClipNow=CLIPLIB.ready&&CLIPLIB.pack&&CLIPLIB.pack.clips&&CLIPLIB.pack.clips[shooter._fireKey];
  const deferredFire=!!(fireClipNow&&fireClipNow.events&&fireClipNow.events.length&&!window.__noClips&&!REDUCED_MOTION&&VIEW_MODE==='3d');
  if(deferredFire&&shooter._shootTarget){shooter._shootTarget._visualDelayUntil=FX.t+1200;shooter._shootTarget._pendingHit=null;}
  if(!deferredFire){const m3=T3&&T3.units&&T3.units.get?T3.units.get(shooter.id):null;fireWeaponFeedback(shooter,m3&&m3.userData,true);}
  const roll=rng()*100;
  let hit=false;
  if(roll<p){
    hit=true;
    let dmg=w.dmg;
    if(weaponName==='Remington 870'||weaponName==='Benelli M4'){dmg=cheb(shooter,target)<=1?w.dmg:Math.round(w.dmg*0.45);}
    dmg=dmg*falloffFactor(shooter,target,w);
    dmg=dmg*(0.85+rng()*0.3);
    let crit=false;
    if(rng()<0.15){dmg=dmg*1.5;crit=true;}
    if(multiplier)dmg=dmg*multiplier;
    if(G&&G.opp==='ia'&&shooter.team==='B'){if(G.difficulty==='recluta')dmg=dmg*0.85;else if(G.difficulty==='elite')dmg=dmg*1.15;}
    if(shooter.buffDmg)dmg=dmg*(1+shooter.buffDmg);
    dmg=Math.max(1,Math.round(dmg));
    damage(target,dmg,shooter.role+' ('+shooter.team+') con '+weaponName+(crit?' · ¡CRÍTICO ×1,5!':'')+(opts.isReturn?' · fuego de respuesta':'')+(opts.isOverwatch?' · vigilancia':''),shooter.team);
    /* Empujón del original (KnockbackDistance): las escopetas y los lanzadores
       desplazan 1 casilla al objetivo vivo si la casilla está libre. */
    if(w.kb&&target.alive&&!target.isDrone&&target.x!=null&&!opts.isReturn){
      const ax=target.x-shooter.x,ay=target.y-shooter.y;
      const dirs=Math.abs(ax)>=Math.abs(ay)?[[Math.sign(ax),0],[0,Math.sign(ay)]]:[[0,Math.sign(ay)],[Math.sign(ax),0]];
      for(const [dx,dy] of dirs){
        if(!dx&&!dy)continue;const nx=target.x+dx,ny=target.y+dy;
        if(nx<0||ny<0||nx>=W||ny>=H)continue;
        if(blocked(nx,ny)||G.units.some(o=>o!==target&&o.alive&&o.x===nx&&o.y===ny))continue;
        target.x=nx;target.y=ny;target.dx=nx;target.dy=ny;log('💥 El empujón de '+weaponName+' desplaza a '+target.role+' a ('+(nx+1)+','+(ny+1)+').');checkMines(target);break;
      }
    }
    if(crit&&target.x!=null)fxFloat(target.x,target.y-0.25,'¡CRÍTICO!','#ffd94d');
    if(w.aoe&&target.x!=null&&typeof fx3Explosion==='function')fx3Explosion(target.x,target.y,'expl');
    /* Impacto del cohete (RPG/AT4/M72): el lanzamiento ya sonó con
       rocketlauncher_fire y el impacto lleva su propio sonido del
       original. Los lanzagranadas no lo necesitan: su cluster_explode
       ya suena al disparar. */
    if(w.aoe&&w.cat==='Lanzacohetes'&&target.x!=null)try{auPlay('sfx/weapons/launcher_explode.mp3',0.55);}catch(e){}
    if(w.aoe&&target.role){G.units.filter(u=>u.alive&&u!==target&&cheb(u,target)<=1).forEach(u=>damage(u,Math.round(dmg*0.45),shooter.role+' · salpicadura',shooter.team));if(G.drone&&G.drone.alive&&target!==G.drone&&cheb(G.drone,target)<=1)damage(G.drone,Math.round(dmg*0.45),shooter.role+' · salpicadura',shooter.team);explodeNear(target,shooter.team);}
    if(w.supp&&target.alive&&!target.isDrone){target.suppressed=true;log(target.role+' queda suprimido: −2 de energía en su siguiente turno.');}
  } else {
    if(target.x!=null)fxFloat(target.x,target.y,'FALLO','#b8c2b0');
    log(shooter.role+' ('+shooter.team+') dispara con '+weaponName+(opts.isReturn?' (respuesta)':'')+' y <b>falla</b> ('+p+'% de acierto).');
  }
  /* Fuego de respuesta: todas las armas lo llevan activado en el original.
     Si el objetivo sobrevive, tiene al atacante en alcance y visión y aún
     no ha respondido este turno, devuelve el fuego gratis, con −20 de
     puntería y daño ×0,6. Su respuesta no provoca otra respuesta. */
  if(!opts.isReturn&&!opts.noReturn&&target&&target.role&&target.weapon&&target.alive&&shooter.alive){
    const key=G.round+'-'+G.turn+'-'+target.id;
    if(target.returnKey!==key&&!target.invisible&&!target.stunned){
      const tw=WEAPONS[target.weapon];
      if(tw&&cheb(target,shooter)<=tw.rng&&hasLOS(target,shooter)&&hitChance(target,shooter,tw)>0){
        target.returnKey=key;
        log('↩ Fuego de respuesta de '+target.role+' ('+target.team+').');
        tryShoot(target,shooter,target.weapon,0.6,{isReturn:true,freeCost:true,hitPenalty:20,noReturn:true,silent:true});
      }
    }
  }
  G._dmgTeam=null;
  checkWin();updateUI();draw();return true;
}

export function setOverwatch(u){
  if(u.stunned){toast('Un soldado aturdido por la M84 no puede quedarse en vigilancia: está viendo estrellas.');return;}
  if(u.overwatch){toast('Ya está en vigilancia este turno.');return;}
  if(u.energy<3){toast('La vigilancia cuesta 3 ⚡.');return;}
  G.lastMoveUndo=null;
  spendEnergy(u,3);u.overwatch=true;
  fxFloat(u.x,u.y,'👁 VIGILANCIA','#ffd98a');
  log('👁 '+u.role+' ('+u.team+') se queda en vigilancia: disparará al primer enemigo que se mueva a su alcance.');
  updateUI();draw();
}

export function checkOverwatch(mover){
  if(!G||G.over||!mover.alive)return;
  const watchers=G.units.filter(w=>w.alive&&w.team!==mover.team&&w.overwatch&&!w.stunned&&!mover.invisible);
  for(const wch of watchers){
    if(!mover.alive)break;
    if(!wch.overwatch)continue;
    const ww=WEAPONS[wch.weapon];
    /* La vigilancia se comprueba entera antes de gastarla (alcance,
       línea de visión y humo, vía hitChance): antes solo miraba
       hasLOS, así que un enemigo que cruzaba detrás de una cortina
       de humo consumía la vigilancia y el registro anunciaba un
       disparo que nunca ocurría. Si el humo corta la visión, la
       vigilancia se queda puesta y el que se mueve pasa sin tiro. */
    if(ww&&hitChance(wch,mover,ww)>0){
      wch.overwatch=false;
      log('👁 ¡Vigilancia! '+wch.role+' ('+wch.team+') dispara sobre '+mover.role+' al moverse.');
      tryShoot(wch,mover,wch.weapon,null,{freeCost:true,isOverwatch:true,hitPenalty:10,noReturn:true,silent:true});
    }
  }
}

export function maybeDropLoot(){
  if(!G||G.over)return;
  if(G.round!==3&&G.round!==6)return;
  if(G.lootDropped[G.round])return;
  G.lootDropped[G.round]=true;
  const cand=[[5,4],[6,7],[4,5],[7,6],[5,7],[4,6],[6,4],[4,7]].filter(c=>!blocked(c[0],c[1])&&!inBeacon(c[0],c[1])&&!(c[0]===TURRET_POS.x&&c[1]===TURRET_POS.y));
  if(!cand.length)return;
  const pick=cand[Math.floor(rng()*cand.length)];
  /* Las 4 cajas del original (CrateGameObjectComponent.cs): Salud, Munición
     mejorada, Analgésicos y Espíritu de equipo. */
  const kinds=[['salud','Salud'],['municion','Munición mejorada'],['analgesico','Analgésicos'],['espiritu','Espíritu de equipo']];
  const pk=kinds[Math.floor(rng()*kinds.length)];
  G.lootBoxes.push({x:pick[0],y:pick[1],kind:pk[0]});
  log('📦 Cae una caja de '+pk[1]+' en ('+(pick[0]+1)+','+(pick[1]+1)+'). Quien se plante encima la recoge.');
}

export function pickupLoot(u){
  if(!G||!G.lootBoxes||!u.alive)return;
  const idx=G.lootBoxes.findIndex(b=>b.x===u.x&&b.y===u.y);
  if(idx<0)return;
  const box=G.lootBoxes.splice(idx,1)[0];
  if(box.kind==='salud'){u.hp=Math.min(u.maxHp,u.hp+75);log('📦 '+u.role+' recoge la caja de Salud: +75 PV (ahora '+u.hp+').');}
  else if(box.kind==='municion'){u.buffDmg=0.20;u.buffDmgT=2;log('📦 '+u.role+' recoge la caja de Munición mejorada: +20 % de daño durante 2 turnos.');}
  else if(box.kind==='analgesico'){u.buffArmor=0.78;u.buffArmorT=2;log('📦 '+u.role+' recoge la caja de Analgésicos: −22 % de daño recibido durante 2 turnos.');}
  else {G.units.filter(a=>a.alive&&a.team===u.team).forEach(a=>{a.energy=Math.min(a.maxEnergy,a.energy+3);});log('📦 '+u.role+' abre la caja de Espíritu de equipo: +3 ⚡ a toda la escuadra.');}
  playOnce(u,'pickup');
}

export function explodeNear(pos,srcTeam){const b=G.map.barrels.find(x=>x.alive&&cheb(x,pos)<=1);if(b)explodeBarrel(b,'la salpicadura',srcTeam);}

export function throwGrenade(u,x,y){
  try{auPlay('sfx/weapons/grenade_throw_01.mp3',0.5);}catch(e){}
  if(u.grenades<=0){toast('Sin granadas M67.');return;}
  if(u.energy<2){toast('La granada cuesta 2 de energía.');return;}
  if(cheb(u,{x,y})>3){toast('La M67 se lanza a 3 casillas como máximo.');return;}
  G.lastMoveUndo=null;
  spendEnergy(u,2);u.grenades--;playOnce(u,'throw');sfx('boom');
  if(typeof fx3Proj==='function')fx3Proj(u,{x,y},'m67');
  if(typeof fx3Explosion==='function')fx3Explosion(x,y,'expl');
  fxBurst(x,y,18,'#ff9640');FX.shake=Math.max(FX.shake,9);
  log(u.role+' ('+u.team+') lanza una M67 a ('+(x+1)+','+(y+1)+').');
  G.units.filter(t=>t.alive&&cheb(t,{x,y})<=1).forEach(t=>damage(t,t.x===x&&t.y===y?75:35,'La M67',u.team));
  if(G.drone&&G.drone.alive&&cheb(G.drone,{x,y})<=1)damage(G.drone,G.drone.x===x&&G.drone.y===y?75:35,'La M67',u.team);
  const b=barrelAt(x,y)||G.map.barrels.find(bb=>bb.alive&&cheb(bb,{x,y})<=1);if(b)explodeBarrel(b,'la M67',u.team);
  G.actionMode='move';checkWin();updateUI();draw();
}
