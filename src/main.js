import { GRID_CACHE, NATIVE_MAP_IDS, DEBUG_GRID, DEBUG_WEAPONS, setBoardSize, applyNativeGrid, nativeTile, nativeEdgeBits, nativeSolidEdge, nativeBlocked, tileWorldY, spawnsFor, boardCenter, preloadNativeGrids, buildMap, obAt, barrelAt, unitAt, deployedAt, droneAt, blocked, canStep, SMOKE_TURNS, smokeAt, smokeBlocksLOS, inBeacon, moveCostOf, reachable, DRAW_MOVE_MS_PER_TILE, drawMovePath, startDrawMove, smoothDrawStep, updateUnitDrawPosition, pathDist, gridLineCells, hasLOS, coverLevel, coverBonus, isFlanked, hitChance, falloffFactor, SPAWNS_A, SPAWNS_B, charAbilitiesFor, hasCharAction, hasCharIcon, applyCharacterAbilities, unitHasAction, canHealSpecial, canReviveSpecial, canSnipeSpecial, charForKey, makeUnit, startGame, log, teamName, aliveCount, selectUnit, spendEnergy, fireClipFor, playOnce, damage, explodeBarrel, tryShoot, setOverwatch, checkOverwatch, maybeDropLoot, pickupLoot, explodeNear, throwGrenade, COVER_COST, GAS_COST, GAS_DMG, GAS_TURNS, SWEEP_COST, SWEEP_RANGE, placeCover, throwGas, sweepDetect, ORB_COST, ORB_DMG, ORB_RANGE, fireOrbital, TRANQ_COST, TRANQ_RANGE, WATER_COST, WATER_RANGE, WATER_PUSH, TOOL_COST, TOOL_RANGE, TOOL_HEAL, throwTranq, waterCannon, useToolkit, SHIELD_COST, SHIELD_TURNS, SHIELD_MULT, ARTY_COST, ARTY_DMG, ARTY_RANGE, BEES_COST, BEES_DMG, BEES_TURNS, BEES_RANGE, useShield, fireArtillery, throwBees, MOLOTOV_COST, MOLOTOV_DMG, MOLOTOV_TURNS, CRATE_COST, TELE_COST, TELE_RANGE, throwMolotov, placeHealthCrate, teleportUnit, throwSmoke, MINE_DMG, MINE_COST, mineAt, viewerTeam, placeMine, checkMines, FLASH_COST, FLASH_RANGE, STUN_ENERGY_PEN, STUN_AIM_PEN, applyStun, throwFlash, guideDrone, useSpecial, deployTurret, captureTurret, turretFire, scoreDominationFor, checkBeaconAtTurnEnd, checkWin, endGame, showModal, closeModal, backToMenu, endTurn, aiUnitAct, runAI, setHoverTile, hoverTile, tileFromEvent, boardTileClick, undoLastMove, setCHAR_PREFS, CHAR_PREFS, loadChars, saveChars, CAST_BODIES, ROLE_BODY, charsForRole, characterForRole, characterKey } from './game/index.js';
import { $, nationById, flagHTML, emblemHTML, LEAF_SVG, flagArtHTML, PORTRAIT_CACHE, rolePortraitURL, setStep, LS_CAMPAIGN, DOM_ZONES, DOM_TARGET, DOM_MAX_ROUNDS, ESCORT_START, ESCORT_EXT, ESCORT_MAX_ROUNDS, ESCORT_DRONE_MAXHP, ESCORT_DRONE_HP, ESCORT_GUIDES_PER_ROUND, isExtraction, domZones, escortStart, escortExt, loadCampaign, saveCampaign, effSetupMode, effMode, inDomZone, domControl, LS_NATION, LS_WINS, LS_GAMES, toast, buildNationGrid, charNameFor, renderNationChip, screenStateFor, syncPlayingViewport, showScreen, enterApp, refreshGuerra, syncDiffSeg, renderCampaignPanel, openSetup, syncMapSeg, wireSkinSeg, syncSkinSegs, squadRows, buildSquads, readSquad, updateUI, setArsFilter, arsFilter, arsOrigin, setArsOrigin, buildArsenal, buildDeployables, openDeployable3D, COINS_KEY, armTab, renderAbilityCatalog, renderBarracks, openBarracks, coinsGet, coinsSet, CLASS_LABEL, ABILITY_CATALOG, ABILITY_IMPL } from './ui/index.js';
import { VIEW_MODE, setViewMode3, T3, setT3, w2cx, isSoftwareGL3, isMobileGL3, _toonGrad, toonGrad3, mat3, box3, TEX3, procTex3, texMat3, makeContactShadow3, skyTheme3, EMBLEM_TEX, nationTintColor, CAMO_TEX, camoTexture, emblemTexture, soldierColors3, makeSoldier3, makeGunProp3, REAL, parseOBJ3, ROLE_SCALES, setROLE_SCALES, ROLE_MODEL_FILES, ROLE_OUTFIT_FILES, loadRealSoldier, skState, loadSkirmishTop, loadSkirmishGeo, buildSkirmishGeo3, makeDrone3, MESHY_MODELS, MESHY_LOADING, validatedRigBoneInverses, sameRigBoneOrder, normalizeMeshyRig, normalizeMeshyRigGlobal, parseMeshyOBJ, loadMeshyModel, makeSkinnedModel, HAS_THREE, WEAPON_MESH_FILE, WEAPON_LEN, WEAPON_COVER_BY_FILE, WEAPONS_ORIGINAL, setWEAPON_METADATA, WEAPON_METADATA, setWEAPON_CALIBRATIONS, WEAPON_CALIBRATIONS, setWEAPON_SOCKETS, WEAPON_SOCKETS, weaponCalibration, weaponMeta, WEAPON_THUMB_CACHE, set_wThumbR, _wThumbR, renderWeaponThumb, weaponCoverURL, GUN_MESH_CACHE, parseOBJStatic, weaponFileForRef, weaponCategoryForFile, weaponTargetLength, gunRotationFor, gunRotatedBounds, makeRealGun3, gunSwapWaiters, attachRealGun, makeGunAnchor, _gpDir, _gpTwoH, _gpFwd, _gpUp, _gpZ, _gpY, _gpOrigin, _gpQuat, _gpRecoil, _gpMat, _gpSocketQ, _gpParentQ, _gpRPalm, _gpLPalm, _gpFA, _gpPalmR, _gpPalmL, _smooth01, gunPoseFromHand, fitGunToHand3, fitSpriteGun, fitLiveGun3, CLIPLIB, CLIP_BLEND_MS, CLIP_BLEND_DEATH_MS, _cq, _cq2, _cv, _cv2, _cv3, CLIP_EVENT_LOG, _hitWhite, _retargetDelta, _retargetInverse, clipPulse, fireWeaponFeedback, clipEventFeedback, dispatchClipEvents, clipTrackAt, sampleClipQuat, sampleClipPos, worldRotationsFromLocal, retargetPoseToRig, rootBonePositionForClip, driveClipSoldier, _rq, _rq2, _sv, AXIS_X3, AXIS_Y3, AXIS_Z3, rotAxisQ, aimR, boneTargetQ, driveRealSoldier, makeRealSoldier3, REAL_SPRITES, REAL_SPRITE_FEET, realSpriteKey, realSpriteUnit, initRealSpriteRenderer, SPRITE_AIM_CT, poseSpriteClip, poseSpriteAim, renderRealSprite, getRealSpriteImage, getRealSpriteURL, buildThemedProps3, build3DWorld, rebuildDyn3, rebuildHighlights3, fx3Spawn, fx3Shot, fx3Proj, fx3Explosion, fx3Sparks, fx3Float, tickFx3D, updateHover3D, updateUnitHuds3D, resetCamState, resetCam3D, fitViewerDistance, viewerCenterOffset, init3D, setViewMode } from './render3d/index.js';
import { hash2, rr, lg, rg, shade, block3D, drawFloorTile, drawWall, drawContainer, drawCrate, drawBarrel, drawMedkit, drawPlatform, segRing, classicBoardMetrics, classicTileFromPoint, draw, drawDrone, drawDeployed, ROLE_SVG_ID, ARGON_DEFS, ARGON_SYMBOLS, ARGON_READY, SPRITE_CACHE, shadeHex, buildSpriteSVG, spriteDataURI, getSpriteImage, buildSpriteStrip, SKIN_TONES, drawSoldier, REDUCED_MOTION, FX, fxFloat, fxBurst, fxTracer, drawFX, fxLoop } from './render2d/index.js';
import { MEM_STORE, lsGet, lsSet, lsRemove, rngState, setTurnSeed, rng, isWeekend, msToNextSaturday, fmtCountdown, facingVec, angleToFacing, facingYaw, shortestArc, dist, cheb, LS_SOUND, AC, soundOn, audioCtx, tone, noiseBurst, sfx, AU_BASE, AU_AMBIENT, auPlay, auWeapon, auWeaponFile, auClick, auVoice, AMBIENT_FILE, auAmbient, MUSIC_TRACKS, AU_MUSIC, auMusicStart, auMusicStop, auStopAmbient, renderSoundBtn } from './core-and-audio.js';
import { NATIONS, NATION_ART, SKINS } from './data/nations.js';
import { WEAPONS, PISTOL, WEAPON_SFX, DMR_WEAPONS } from './data/weapons.js';
import { originalWeaponProfile } from './render3d/assets-weapons.js';
import { BODIES, ROLES, ROLE_NAMES, DEFAULT_SQUADS, ROLE_LOOK, roleLook, gameplayModelPresentation, ROLE_PORTRAIT, VOICE_FILES } from './data/roles.js';
import { CHARACTERS, CHARACTER_ABILITIES, ABILITY_OBJECTS, CAST_TEXTURE_FILE, CHAR_ABILITY_ACTIONS, CHAR_VOICE, MESHY_CAST, OWN_CAST, ORIG_CAST, sculptedWeaponUnit } from './data/cast.js';
import { CAMPAIGN_MISSIONS, SKIRMISH_GEO, MAPS_ORIGINAL, MAP_DEFS } from './data/maps.js';
import { STEP_META, AUX_LABELS, AUX_HINTS } from './data/ui-copy.js';
import { wireUI } from './ui/wiring.js';
import { quickStart, quickSmoke, quickFlash } from './game/quick.js';
import { _keysHeld, wireKeyboard } from './game/keyboard.js';
import { DEMO, setDEMO, setDemoNation, buildDemo, rebuildDemo, demoStatus, renderDemoFrame } from './game/demo.js';
import { build3DFrame, render3DFrame } from './render3d/runtime.js';
import { installEarlyBridge, installFullBridge } from './bridge.js';
import { TUTORIAL_MISSION, TUTORIAL_STEPS, radioLines, campaignStars, missionById, rosterKey } from './data/maps.js';
import { activeOriginalMission } from './ui/ui-shell.js';
import { wireCampaignUI, renderTutorialStep, hideTutorialStep, tutorialHint, renderCampaignRadio } from './ui/campaign-ui.js';
import { configureTutorial, startTutorial, skipTutorial, replayTutorial, tutorialAdvance, tutorialEvent, tutorialCheck, isTutorialActive, tutorialStep, LS_TUTORIAL } from './game/tutorial.js';
"use strict";
let flowStep='nation';
let myNation=null, pickedNation=null;
let setup={mode:'baliza',fmt:4,opp:'ia',rivalNation:null,skinA:'nacion',skinB:'nacion',map:'almacen',difficulty:'normal',campaignMission:0,squadChars:{A:{},B:{}}};
let G=null;
function markTutorialDone(){
  const c=loadCampaign();saveCampaign(Object.assign({},c,{tutorialDone:true}));renderCampaignPanel();
}
configureTutorial({
  getGame:()=>G,
  show:(step,index,total)=>{renderTutorialStep(step,index,total);toast(step.text);try{auVoice({name:'Hipster Dave',role:'Comando'},'select',0.45);}catch(e){}},
  advance:(step,index,total)=>{renderTutorialStep(step,index,total);try{auVoice({name:'Hipster Dave',role:'Comando'},'confirm',0.45);}catch(e){}},
  hint:(step)=>{if(step)tutorialHint(step.text);},
  hide:hideTutorialStep,
  complete:()=>{markTutorialDone();toast('Instrucción completada: ya puedes jugar la Operación Londres.');},
  skip:()=>{markTutorialDone();hideTutorialStep();toast('Instrucción omitida. Puedes repetirla cuando quieras.');}
});
document.querySelectorAll('#mainTabs button').forEach(b=>b.onclick=()=>{showScreen('scr-'+b.dataset.tab);if(b.dataset.tab==='arsenal')armTab('armas');});
document.querySelectorAll('[data-back]').forEach(b=>b.onclick=()=>showScreen('scr-play'));
setInterval(()=>{if(!isWeekend())$('#guerraCountdown').textContent=fmtCountdown(msToNextSaturday());else if($('#scr-play').classList.contains('on'))refreshGuerra();},1000);
document.querySelectorAll('[data-start]').forEach(b=>b.onclick=()=>openSetup(b.dataset.start));
document.querySelectorAll('#diffSeg button').forEach(b=>b.onclick=()=>{if(setup.mode==='campana')return;setup.difficulty=b.dataset.diff;syncDiffSeg();});
document.querySelectorAll('#fmtSeg button').forEach(b=>b.onclick=()=>{setup.fmt=+b.dataset.fmt;document.querySelectorAll('#fmtSeg button').forEach(x=>x.classList.toggle('on',x===b));buildSquads();});
document.querySelectorAll('#mapSeg button').forEach(b=>b.onclick=()=>{setup.map=b.dataset.map;syncMapSeg();});
document.querySelectorAll('#oppSeg button').forEach(b=>b.onclick=()=>{setup.opp=b.dataset.opp;document.querySelectorAll('#oppSeg button').forEach(x=>x.classList.toggle('on',x===b));buildSquads();});
wireSkinSeg('skinSegA','skinA');wireSkinSeg('skinSegB','skinB');
$('#cancelSetup').onclick=()=>{$('#setupArea').style.display='none';$('#menuArea').style.display='block';document.body.dataset.state='menu';syncPlayingViewport();setStep('mode');refreshGuerra();};
function launchConfigured(){
  const mission=activeOriginalMission();
  const squadA=readSquad('A'),squadB=readSquad('B');
  startGame(squadA,squadB);
  if(!mission)return;
  G.campaignName=mission.id;G.campaignTitle=mission.title;G.campaignTurnLimit=mission.turnLimit;
  const lines=radioLines(mission.id);
  if(lines[0]){toast('📻 '+lines[0]);log('📻 '+lines[0]);}
  if(setup.mode==='tutorial')startTutorial();
}
function beginTutorial(){openSetup('tutorial');launchConfigured();}
$('#launchBtn').onclick=launchConfigured;
function advanceUnitYaw(un,t){
  const target=facingYaw(un);
  if(un._dispYaw==null||REDUCED_MOTION){un._dispYaw=target;un._turnTo=target;un._turnFrom=null;un._turning=false;un._turnProg=0;un._turnDelta=0;return un._dispYaw;}
  if(un._turnFrom==null&&Math.abs(shortestArc(target-un._dispYaw))>0.02){
    un._turnFrom=un._dispYaw;un._turnTo=target;un._turnT0=t;
    const ad=Math.abs(shortestArc(target-un._turnFrom));
    un._turnDur=Math.max(200,Math.min(560,ad/(Math.PI/2)*300));
  }
  if(un._turnFrom!=null){
    if(Math.abs(shortestArc(target-un._turnTo))>0.02){
      un._turnFrom=un._dispYaw;un._turnTo=target;un._turnT0=t;
      const ad2=Math.abs(shortestArc(target-un._turnFrom));
      un._turnDur=Math.max(200,Math.min(560,ad2/(Math.PI/2)*300));
    }
    const p=(t-un._turnT0)/un._turnDur;
    if(p>=1){un._dispYaw=un._turnTo;un._turnFrom=null;un._turning=false;un._turnProg=0;un._turnDelta=0;}
    else{
      const e=p<0.5?2*p*p:1-Math.pow(-2*p+2,2)/2;
      un._dispYaw=un._turnFrom+shortestArc(un._turnTo-un._turnFrom)*e;
      un._turning=true;un._turnProg=p;un._turnDelta=shortestArc(un._turnTo-un._dispYaw);
    }
  }
  return un._dispYaw;
}
let W=12,H=12;
let BEACON=[{x:5,y:5},{x:6,y:5},{x:5,y:6},{x:6,y:6}];
let TURRET_POS={x:5,y:5};
let NATIVE_GRID=null;
preloadNativeGrids();
let uid=0;
try{document.addEventListener('click',function(e){try{if(e.target&&e.target.closest&&e.target.closest('button'))auClick();}catch(err){}});}catch(e){}
$('#quitBtn').onclick=()=>{showModal('<h2>¿Abandonar la partida?</h2><p>Se perderá el progreso de esta partida. Tu nación y tu marcador de Guerra de Naciones no se tocan.</p><div style="display:flex;gap:10px;justify-content:center;flex-wrap:wrap;margin-top:14px"><button class="btn danger big" onclick="closeModal();backToMenu()">Sí, abandonar</button><button class="btn big" onclick="closeModal()">Seguir jugando</button></div>');};
$('#endTurnBtn').onclick=()=>{tutorialEvent('endTurn');endTurn();};
$('#soundBtn').onclick=()=>{soundOn=!soundOn;try{lsSet(LS_SOUND,soundOn?'1':'0');}catch(e){}renderSoundBtn();if(soundOn)sfx('turn');try{if(!soundOn){auMusicStop();auStopAmbient();}else if(G&&G.units&&G.units.length){auMusicStart();auAmbient(G.map.theme);}}catch(e){}toast(soundOn?'Sonido activado: disparos, ambiente y música del original.':'Sonido desactivado.');};
renderSoundBtn();
const canvas=$('#board'),ctx=canvas.getContext('2d');
requestAnimationFrame(fxLoop);
canvas.addEventListener('mousemove',e=>{setHoverTile(tileFromEvent(e));if(G)draw();});
canvas.addEventListener('click',e=>boardTileClick(tileFromEvent(e)));
fetch('assets/argon-soldiers.svg').then(r=>{if(!r.ok)throw new Error('svg');return r.text();}).then(txt=>{
  const doc=new DOMParser().parseFromString(txt,'image/svg+xml');
  const defsEl=doc.querySelector('defs');if(!defsEl)return;
  ARGON_DEFS=Array.prototype.slice.call(defsEl.children).filter(el=>el.tagName!=='symbol').map(el=>new XMLSerializer().serializeToString(el)).join('');
  doc.querySelectorAll('symbol').forEach(sym=>{ARGON_SYMBOLS[sym.id]=Array.prototype.map.call(sym.childNodes,n=>new XMLSerializer().serializeToString(n)).join('');});
  ARGON_READY=true;
  buildSpriteStrip();
  if(G)draw();
}).catch(()=>{});
let bridgeFull=null;
if(typeof THREE!=='undefined'){
installEarlyBridge({
get $(){return $;},get G(){return G;},set G(v){G=v;},
get W(){return W;},set W(v){W=v;},get H(){return H;},
set H(v){H=v;},get BEACON(){return BEACON;},set BEACON(v){BEACON=v;},
get TURRET_POS(){return TURRET_POS;},set TURRET_POS(v){TURRET_POS=v;},get NATIVE_GRID(){return NATIVE_GRID;},
set NATIVE_GRID(v){NATIVE_GRID=v;},get flowStep(){return flowStep;},set flowStep(v){flowStep=v;},
get myNation(){return myNation;},set myNation(v){myNation=v;setDemoNation(v);},get pickedNation(){return pickedNation;},
set pickedNation(v){pickedNation=v;},get setup(){return setup;},set setup(v){setup=v;},
get uid(){return uid;},set uid(v){uid=v;},get hoverTile(){return hoverTile;},
set hoverTile(v){setHoverTile(v);},get arsFilter(){return arsFilter;},set arsFilter(v){setArsFilter(v);},
get DEMO(){return DEMO;},set DEMO(v){setDEMO(v);},get CHAR_PREFS(){return CHAR_PREFS;},
set CHAR_PREFS(v){setCHAR_PREFS(v);},
});
bridgeFull={
get $(){return $;},get ABILITY_CATALOG(){return ABILITY_CATALOG;},get ABILITY_IMPL(){return ABILITY_IMPL;},
get ABILITY_OBJECTS(){return ABILITY_OBJECTS;},get AC(){return AC;},get AMBIENT_FILE(){return AMBIENT_FILE;},
get ARGON_DEFS(){return ARGON_DEFS;},get AUX_HINTS(){return AUX_HINTS;},get AUX_LABELS(){return AUX_LABELS;},
get AU_AMBIENT(){return AU_AMBIENT;},get AU_BASE(){return AU_BASE;},get AU_MUSIC(){return AU_MUSIC;},
get AXIS_X3(){return AXIS_X3;},get BEACON(){return BEACON;},set BEACON(v){BEACON=v;},
get BODIES(){return BODIES;},get CAMO_TEX(){return CAMO_TEX;},get CAMPAIGN_MISSIONS(){return CAMPAIGN_MISSIONS;},
get CAST_BODIES(){return CAST_BODIES;},get CAST_TEXTURE_FILE(){return CAST_TEXTURE_FILE;},get CATS(){return CATS;},
get CHARACTERS(){return CHARACTERS;},get CHARACTER_ABILITIES(){return CHARACTER_ABILITIES;},get CHAR_ABILITY_ACTIONS(){return CHAR_ABILITY_ACTIONS;},
get CHAR_PREFS(){return CHAR_PREFS;},set CHAR_PREFS(v){setCHAR_PREFS(v);},get CHAR_VOICE(){return CHAR_VOICE;},
get CLASS_LABEL(){return CLASS_LABEL;},get CLASS_ORDER(){return CLASS_ORDER;},get CLIPLIB(){return CLIPLIB;},
get CLIP_BLEND_MS(){return CLIP_BLEND_MS;},get CLIP_EVENT_LOG(){return CLIP_EVENT_LOG;},get COINS_KEY(){return COINS_KEY;},
get COMMANDER_CRATE_ABILITIES(){return COMMANDER_CRATE_ABILITIES;},get COVER_COST(){return COVER_COST;},get DEBUG_GRID(){return DEBUG_GRID;},
get DEBUG_WEAPONS(){return DEBUG_WEAPONS;},get DEFAULT_SQUADS(){return DEFAULT_SQUADS;},get DEMO(){return DEMO;},
set DEMO(v){setDEMO(v);},get DMR_WEAPONS(){return DMR_WEAPONS;},get DOM_TARGET(){return DOM_TARGET;},
get DOM_ZONES(){return DOM_ZONES;},get DRAW_MOVE_MS_PER_TILE(){return DRAW_MOVE_MS_PER_TILE;},get EMBLEM_TEX(){return EMBLEM_TEX;},
get ESCORT_EXT(){return ESCORT_EXT;},get ESCORT_MAX_ROUNDS(){return ESCORT_MAX_ROUNDS;},get ESCORT_START(){return ESCORT_START;},
get FLASH_COST(){return FLASH_COST;},get FX(){return FX;},get G(){return G;},
set G(v){G=v;},get GRID_CACHE(){return GRID_CACHE;},get GUN_MESH_CACHE(){return GUN_MESH_CACHE;},
get HAS_THREE(){return HAS_THREE;},get LEAF_SVG(){return LEAF_SVG;},get LS_CAMPAIGN(){return LS_CAMPAIGN;},get LS_TUTORIAL(){return LS_TUTORIAL;},
get LS_CHARS(){return LS_CHARS;},get LS_NATION(){return LS_NATION;},get LS_SOUND(){return LS_SOUND;},
get MAP_DEFS(){return MAP_DEFS;},get MAPS_ORIGINAL(){return MAPS_ORIGINAL;},get MAP_PIECES(){return MAP_PIECES;},
get MEM_STORE(){return MEM_STORE;},get MESHY_CAST(){return MESHY_CAST;},get MESHY_MODELS(){return MESHY_MODELS;},
get MINE_DMG(){return MINE_DMG;},get MOLOTOV_COST(){return MOLOTOV_COST;},get MUSIC_TRACKS(){return MUSIC_TRACKS;},
get NATIONS(){return NATIONS;},get NATION_ART(){return NATION_ART;},get NATIVE_GRID(){return NATIVE_GRID;},
set NATIVE_GRID(v){NATIVE_GRID=v;},get NATIVE_MAP_IDS(){return NATIVE_MAP_IDS;},get ORB_COST(){return ORB_COST;},
get ORIG_CAST(){return ORIG_CAST;},get OWN_CAST(){return OWN_CAST;},get PISTOL(){return PISTOL;},
get PORTRAIT_CACHE(){return PORTRAIT_CACHE;},get REAL(){return REAL;},get REAL_SPRITES(){return REAL_SPRITES;},
get REAL_SPRITE_FEET(){return REAL_SPRITE_FEET;},get REDUCED_MOTION(){return REDUCED_MOTION;},get ROLES(){return ROLES;},
get ROLE_BODY(){return ROLE_BODY;},get ROLE_LOOK(){return ROLE_LOOK;},get ROLE_MODEL_FILES(){return ROLE_MODEL_FILES;},
get ROLE_NAMES(){return ROLE_NAMES;},get ROLE_OUTFIT_FILES(){return ROLE_OUTFIT_FILES;},get ROLE_PORTRAIT(){return ROLE_PORTRAIT;},
get ROLE_SCALES(){return ROLE_SCALES;},get ROLE_SVG_ID(){return ROLE_SVG_ID;},get SHIELD_COST(){return SHIELD_COST;},
get SKINS(){return SKINS;},get SKIN_TONES(){return SKIN_TONES;},get SKIRMISH_GEO(){return SKIRMISH_GEO;},
get SMOKE_TURNS(){return SMOKE_TURNS;},get SPAWNS_A(){return SPAWNS_A;},get SPAWNS_B(){return SPAWNS_B;},
get SPRITE_AIM_CT(){return SPRITE_AIM_CT;},get SPRITE_CACHE(){return SPRITE_CACHE;},get STEP_META(){return STEP_META;},
get T3(){return T3;},get TEX3(){return TEX3;},get TUTORIAL_MISSION(){return TUTORIAL_MISSION;},get TUTORIAL_STEPS(){return TUTORIAL_STEPS;},get TRANQ_COST(){return TRANQ_COST;},
get TURRET_POS(){return TURRET_POS;},set TURRET_POS(v){TURRET_POS=v;},get TUT_TEXTS(){return TUT_TEXTS;},
get VIEW_MODE(){return VIEW_MODE;},get VOICE_FILES(){return VOICE_FILES;},get W(){return W;},
set W(v){W=v;},get H(){return H;},set H(v){H=v;},
get WEAPONS(){return WEAPONS;},get WEAPONS_ORIGINAL(){return WEAPONS_ORIGINAL;},get WEAPON_CALIBRATIONS(){return WEAPON_CALIBRATIONS;},get WEAPON_SOCKETS(){return WEAPON_SOCKETS;},
get WEAPON_COVER_BY_FILE(){return WEAPON_COVER_BY_FILE;},get WEAPON_LEN(){return WEAPON_LEN;},get WEAPON_MESH_FILE(){return WEAPON_MESH_FILE;},
get WEAPON_METADATA(){return WEAPON_METADATA;},get WEAPON_SFX(){return WEAPON_SFX;},get WEAPON_THUMB_CACHE(){return WEAPON_THUMB_CACHE;},
get _cq(){return _cq;},get _gpDir(){return _gpDir;},get _gpOrigin(){return _gpOrigin;},
get _gpPalmR(){return _gpPalmR;},get _gpRPalm(){return _gpRPalm;},get _gpUp(){return _gpUp;},
get _hitWhite(){return _hitWhite;},get _keysHeld(){return _keysHeld;},get _retargetDelta(){return _retargetDelta;},
get _rq(){return _rq;},get _smooth01(){return _smooth01;},get _toonGrad(){return _toonGrad;},
get _undoBtn(){return _undoBtn;},get _wThumbR(){return _wThumbR;},get advanceUnitYaw(){return advanceUnitYaw;},
get aiUnitAct(){return aiUnitAct;},get aimR(){return aimR;},get aliveCount(){return aliveCount;},
get angleToFacing(){return angleToFacing;},get applyCharacterAbilities(){return applyCharacterAbilities;},get applyNativeGrid(){return applyNativeGrid;},
get applyStun(){return applyStun;},get armTab(){return armTab;},get arsFilter(){return arsFilter;},get arsOrigin(){return arsOrigin;},get setArsOrigin(){return setArsOrigin;},get openDeployable3D(){return openDeployable3D;},get originalWeaponProfile(){return originalWeaponProfile;},
set arsFilter(v){setArsFilter(v);},get attachRealGun(){return attachRealGun;},get auAmbient(){return auAmbient;},
get auClick(){return auClick;},get auMusicStart(){return auMusicStart;},get auMusicStop(){return auMusicStop;},
get auPlay(){return auPlay;},get auStopAmbient(){return auStopAmbient;},get auVoice(){return auVoice;},
get auWeapon(){return auWeapon;},get auWeaponFile(){return auWeaponFile;},get audioCtx(){return audioCtx;},get backToMenu(){return backToMenu;},
get barrelAt(){return barrelAt;},get block3D(){return block3D;},get blocked(){return blocked;},
get boardCenter(){return boardCenter;},get boardTileClick(){return boardTileClick;},get boneTargetQ(){return boneTargetQ;},
get box3(){return box3;},get build3DWorld(){return build3DWorld;},get buildArsenal(){return buildArsenal;},get buildDeployables(){return buildDeployables;},
get buildDemo(){return buildDemo;},get buildMap(){return buildMap;},get buildNationGrid(){return buildNationGrid;},
get buildSkirmishGeo3(){return buildSkirmishGeo3;},get buildSpriteSVG(){return buildSpriteSVG;},get buildSpriteStrip(){return buildSpriteStrip;},
get buildSquads(){return buildSquads;},get buildThemedProps3(){return buildThemedProps3;},get camoTexture(){return camoTexture;},
get canHealSpecial(){return canHealSpecial;},get canReviveSpecial(){return canReviveSpecial;},get canSnipeSpecial(){return canSnipeSpecial;},
get canStep(){return canStep;},get canvas(){return canvas;},get ctx(){return ctx;},
get captureTurret(){return captureTurret;},get charAbilitiesFor(){return charAbilitiesFor;},get charForKey(){return charForKey;},
get charNameFor(){return charNameFor;},get characterForRole(){return characterForRole;},get characterKey(){return characterKey;},
get charsForRole(){return charsForRole;},get cheb(){return cheb;},get checkBeaconAtTurnEnd(){return checkBeaconAtTurnEnd;},
get checkMines(){return checkMines;},get checkOverwatch(){return checkOverwatch;},get checkWin(){return checkWin;},
get classicBoardMetrics(){return classicBoardMetrics;},get classicTileFromPoint(){return classicTileFromPoint;},get clipEventFeedback(){return clipEventFeedback;},
get clipPulse(){return clipPulse;},get clipTrackAt(){return clipTrackAt;},get closeModal(){return closeModal;},
get coinsGet(){return coinsGet;},get coinsSet(){return coinsSet;},get coverBonus(){return coverBonus;},
get coverLevel(){return coverLevel;},get damage(){return damage;},get demoStatus(){return demoStatus;},
get demoUnit(){return demoUnit;},get deployTurret(){return deployTurret;},get deployedAt(){return deployedAt;},
get dispatchClipEvents(){return dispatchClipEvents;},get dist(){return dist;},get domControl(){return domControl;},
get domZones(){return domZones;},get draw(){return draw;},get drawBarrel(){return drawBarrel;},
get drawContainer(){return drawContainer;},get drawCrate(){return drawCrate;},get drawDeployed(){return drawDeployed;},
get drawDrone(){return drawDrone;},get drawFX(){return drawFX;},get drawFloorTile(){return drawFloorTile;},
get drawMedkit(){return drawMedkit;},get drawMovePath(){return drawMovePath;},get drawPlatform(){return drawPlatform;},
get drawSoldier(){return drawSoldier;},get drawWall(){return drawWall;},get driveClipSoldier(){return driveClipSoldier;},
get driveRealSoldier(){return driveRealSoldier;},get droneAt(){return droneAt;},get effMode(){return effMode;},
get effSetupMode(){return effSetupMode;},get emblemHTML(){return emblemHTML;},get emblemTexture(){return emblemTexture;},
get endGame(){return endGame;},get endTurn(){return endTurn;},get enterApp(){return enterApp;},
get escortExt(){return escortExt;},get escortStart(){return escortStart;},get explodeBarrel(){return explodeBarrel;},
get explodeNear(){return explodeNear;},get facingVec(){return facingVec;},get facingYaw(){return facingYaw;},
get falloffFactor(){return falloffFactor;},get fireArtillery(){return fireArtillery;},get fireClipFor(){return fireClipFor;},
get fireOrbital(){return fireOrbital;},get fireWeaponFeedback(){return fireWeaponFeedback;},get fitGunToHand3(){return fitGunToHand3;},
get fitLiveGun3(){return fitLiveGun3;},get fitSpriteGun(){return fitSpriteGun;},get fitViewerDistance(){return fitViewerDistance;},
get flagArtHTML(){return flagArtHTML;},get flagHTML(){return flagHTML;},get flowStep(){return flowStep;},
set flowStep(v){flowStep=v;},get fmtCountdown(){return fmtCountdown;},get fx3Explosion(){return fx3Explosion;},
get fx3Float(){return fx3Float;},get fx3Proj(){return fx3Proj;},get fx3Shot(){return fx3Shot;},
get fx3Sparks(){return fx3Sparks;},get fx3Spawn(){return fx3Spawn;},get fxBurst(){return fxBurst;},
get fxFloat(){return fxFloat;},get fxLoop(){return fxLoop;},get fxTracer(){return fxTracer;},
get gameplayModelPresentation(){return gameplayModelPresentation;},get getRealSpriteImage(){return getRealSpriteImage;},get getRealSpriteURL(){return getRealSpriteURL;},
get getSpriteImage(){return getSpriteImage;},get gridLineCells(){return gridLineCells;},get guideDrone(){return guideDrone;},
get gunPoseFromHand(){return gunPoseFromHand;},get gunRotatedBounds(){return gunRotatedBounds;},get gunRotationFor(){return gunRotationFor;},
get gunSwapWaiters(){return gunSwapWaiters;},get hasCharAction(){return hasCharAction;},get hasCharIcon(){return hasCharIcon;},
get hasLOS(){return hasLOS;},get hash2(){return hash2;},get hitChance(){return hitChance;},
get hoverTile(){return hoverTile;},set hoverTile(v){setHoverTile(v);},get inBeacon(){return inBeacon;},
get inDomZone(){return inDomZone;},get init3D(){return init3D;},get initRealSpriteRenderer(){return initRealSpriteRenderer;},
get isExtraction(){return isExtraction;},get isFlanked(){return isFlanked;},get isMobileGL3(){return isMobileGL3;},
get isSoftwareGL3(){return isSoftwareGL3;},get isWeekend(){return isWeekend;},get lg(){return lg;},
get loadCampaign(){return loadCampaign;},get loadChars(){return loadChars;},get loadMeshyModel(){return loadMeshyModel;},
get loadRealSoldier(){return loadRealSoldier;},get loadSkirmishGeo(){return loadSkirmishGeo;},get loadSkirmishTop(){return loadSkirmishTop;},
get log(){return log;},get lsGet(){return lsGet;},get lsRemove(){return lsRemove;},
get lsSet(){return lsSet;},get makeContactShadow3(){return makeContactShadow3;},get makeDrone3(){return makeDrone3;},
get makeGunAnchor(){return makeGunAnchor;},get makeGunProp3(){return makeGunProp3;},get makeRealGun3(){return makeRealGun3;},
get makeRealSoldier3(){return makeRealSoldier3;},get makeSkinnedModel(){return makeSkinnedModel;},get makeSoldier3(){return makeSoldier3;},
get makeUnit(){return makeUnit;},get mat3(){return mat3;},get maybeDropLoot(){return maybeDropLoot;},
get mineAt(){return mineAt;},get moveCostOf(){return moveCostOf;},get msToNextSaturday(){return msToNextSaturday;},
get myNation(){return myNation;},set myNation(v){myNation=v;setDemoNation(v);},get pickedNation(){return pickedNation;},
set pickedNation(v){pickedNation=v;},get nationById(){return nationById;},get nationTintColor(){return nationTintColor;},
get nativeBlocked(){return nativeBlocked;},get nativeEdgeBits(){return nativeEdgeBits;},get nativeSolidEdge(){return nativeSolidEdge;},
get nativeTile(){return nativeTile;},get noiseBurst(){return noiseBurst;},get normalizeMeshyRig(){return normalizeMeshyRig;},
get normalizeMeshyRigGlobal(){return normalizeMeshyRigGlobal;},get obAt(){return obAt;},get openBarracks(){return openBarracks;},
get openSetup(){return openSetup;},get parseMeshyOBJ(){return parseMeshyOBJ;},get parseOBJ3(){return parseOBJ3;},
get parseOBJStatic(){return parseOBJStatic;},get pathDist(){return pathDist;},get pickupLoot(){return pickupLoot;},
get placeCover(){return placeCover;},get placeHealthCrate(){return placeHealthCrate;},get placeMine(){return placeMine;},
get playOnce(){return playOnce;},get poseSpriteAim(){return poseSpriteAim;},get poseSpriteClip(){return poseSpriteClip;},
get preloadNativeGrids(){return preloadNativeGrids;},get procTex3(){return procTex3;},get reachable(){return reachable;},
get readSquad(){return readSquad;},get realSpriteKey(){return realSpriteKey;},get realSpriteUnit(){return realSpriteUnit;},
get rebuildDemo(){return rebuildDemo;},get rebuildDyn3(){return rebuildDyn3;},get rebuildHighlights3(){return rebuildHighlights3;},
get refreshGuerra(){return refreshGuerra;},get renderAbilityCatalog(){return renderAbilityCatalog;},get renderBarracks(){return renderBarracks;},
get renderCampaignPanel(){return renderCampaignPanel;},get renderNationChip(){return renderNationChip;},get renderRealSprite(){return renderRealSprite;},
get renderSoundBtn(){return renderSoundBtn;},get renderWeaponThumb(){return renderWeaponThumb;},get resetCam3D(){return resetCam3D;},
get resetCamState(){return resetCamState;},get retargetPoseToRig(){return retargetPoseToRig;},get rg(){return rg;},
get rng(){return rng;},get rngState(){return rngState;},get roleLook(){return roleLook;},
get rolePortraitURL(){return rolePortraitURL;},get rootBonePositionForClip(){return rootBonePositionForClip;},get rotAxisQ(){return rotAxisQ;},
get rr(){return rr;},get sameRigBoneOrder(){return sameRigBoneOrder;},get sampleClipPos(){return sampleClipPos;},
get sampleClipQuat(){return sampleClipQuat;},get saveCampaign(){return saveCampaign;},get saveChars(){return saveChars;},
get scoreDominationFor(){return scoreDominationFor;},get screenStateFor(){return screenStateFor;},get sculptedWeaponUnit(){return sculptedWeaponUnit;},
get segRing(){return segRing;},get selectUnit(){return selectUnit;},get setBoardSize(){return setBoardSize;},
get setOverwatch(){return setOverwatch;},get setStep(){return setStep;},get setTurnSeed(){return setTurnSeed;},
get setViewMode(){return setViewMode;},get setup(){return setup;},set setup(v){setup=v;},
get sfx(){return sfx;},get shade(){return shade;},get shadeHex(){return shadeHex;},
get shortestArc(){return shortestArc;},get showModal(){return showModal;},get showScreen(){return showScreen;},
get skState(){return skState;},get skyTheme3(){return skyTheme3;},get smokeAt(){return smokeAt;},
get smokeBlocksLOS(){return smokeBlocksLOS;},get smoothDrawStep(){return smoothDrawStep;},get soldierColors3(){return soldierColors3;},
get spawnsFor(){return spawnsFor;},get spendEnergy(){return spendEnergy;},get spriteDataURI(){return spriteDataURI;},
get squadRows(){return squadRows;},get startDrawMove(){return startDrawMove;},get startGame(){return startGame;},
get sweepDetect(){return sweepDetect;},get syncDiffSeg(){return syncDiffSeg;},get syncMapSeg(){return syncMapSeg;},
get syncPlayingViewport(){return syncPlayingViewport;},get syncSkinSegs(){return syncSkinSegs;},get teamName(){return teamName;},
get teleportUnit(){return teleportUnit;},get texMat3(){return texMat3;},get throwBees(){return throwBees;},
get throwFlash(){return throwFlash;},get throwGas(){return throwGas;},get throwGrenade(){return throwGrenade;},
get throwMolotov(){return throwMolotov;},get throwSmoke(){return throwSmoke;},get throwTranq(){return throwTranq;},
get tickFx3D(){return tickFx3D;},get tileFromEvent(){return tileFromEvent;},get tileWorldY(){return tileWorldY;},
get toast(){return toast;},get tone(){return tone;},get toonGrad3(){return toonGrad3;},get activeOriginalMission(){return activeOriginalMission;},get campaignStars(){return campaignStars;},get isTutorialActive(){return isTutorialActive;},get missionById(){return missionById;},get radioLines(){return radioLines;},get renderTutorialStep(){return renderTutorialStep;},get replayTutorial(){return replayTutorial;},get rosterKey(){return rosterKey;},get skipTutorial(){return skipTutorial;},get startTutorial(){return startTutorial;},get tutorialAdvance(){return tutorialAdvance;},get tutorialCheck(){return tutorialCheck;},get tutorialEvent(){return tutorialEvent;},get tutorialIndex(){return tutorialIndex;},get tutorialStep(){return tutorialStep;},
get tryShoot(){return tryShoot;},get turretFire(){return turretFire;},get tutHide(){return tutHide;},
get tutShow(){return tutShow;},get uid(){return uid;},set uid(v){uid=v;},
get undoLastMove(){return undoLastMove;},get unitAt(){return unitAt;},get unitHasAction(){return unitHasAction;},
get updateHover3D(){return updateHover3D;},get updateUI(){return updateUI;},get updateUnitDrawPosition(){return updateUnitDrawPosition;},
get updateUnitHuds3D(){return updateUnitHuds3D;},get useShield(){return useShield;},get useSpecial(){return useSpecial;},
get useToolkit(){return useToolkit;},get validatedRigBoneInverses(){return validatedRigBoneInverses;},get viewerCenterOffset(){return viewerCenterOffset;},
get viewerTeam(){return viewerTeam;},get w2cx(){return w2cx;},get waterCannon(){return waterCannon;},
get weaponCalibration(){return weaponCalibration;},get weaponCategoryForFile(){return weaponCategoryForFile;},get weaponCoverURL(){return weaponCoverURL;},
get weaponFileForRef(){return weaponFileForRef;},get weaponMeta(){return weaponMeta;},get weaponTargetLength(){return weaponTargetLength;},
get wireSkinSeg(){return wireSkinSeg;},get worldRotationsFromLocal(){return worldRotationsFromLocal;},
};
installFullBridge(bridgeFull);
loadRealSoldier({get G(){return G;},get T3(){return T3;},get VIEW_MODE(){return VIEW_MODE;},draw,updateUI,build3DWorld,rebuildDemo,PORTRAIT_CACHE,REAL_SPRITES});
}
fetch('assets/weapons/weapon_metadata.json').then(r=>r.ok?r.json():{}).then(m=>{setWEAPON_METADATA(m||{});}).catch(e=>{console.error('[weapon_metadata]',e);});
fetch('assets/weapons/weapon_calibrations.json').then(r=>r.ok?r.json():{}).then(c=>{setWEAPON_CALIBRATIONS(c||{});}).catch(e=>{console.error('[weapon_calibrations]',e);});
fetch('assets/weapons/weapon_sockets.json').then(r=>r.ok?r.json():{}).then(s=>{setWEAPON_SOCKETS(s||{});}).catch(e=>{console.error('[weapon_sockets]',e);});
if(typeof window!=='undefined')window.__csnEvents=CLIP_EVENT_LOG;
try{window.__csnCam={get cam(){return T3&&T3.cam;},get t3(){return T3;}};}catch(e){}
document.querySelectorAll('#viewSeg button').forEach(b=>b.onclick=()=>setViewMode(b.dataset.view));
window.__build3D=function(){ build3DFrame(); };
window.__render3D=function(){ render3DFrame({G,keysHeld:_keysHeld,hoverTile,advanceUnitYaw,TURRET_POS}); };
wireKeyboard({get G(){return G;},selectUnit,updateUI,draw,undoLastMove});
window.__renderDemo=function(){ renderDemoFrame({get G(){return G;},set G(v){G=v;},myNation}); };
window.quickStart=function(mapId){ quickStart(mapId,{myNation,setup,get G(){return G;}}); };
const COMMANDER_CRATE_ABILITIES=[
 {icon:'PlayerAbility_06_Health_Crate_alpha',n:'Caja de salud',d:'Crea una caja de salud en el mapa.',obj:'crate'},
 {icon:'PlayerAbility_08_Improved_Ammo_alpha',n:'Caja de munición',d:'Crea una caja de munición de alta velocidad.',obj:'crate'},
 {icon:'PlayerAbility_10_Pain_Killers_alpha',n:'Caja de analgésicos',d:'Crea una caja de analgésicos.',obj:'crate'},
 {icon:'PlayerAbility_11_Team_Spirit_alpha',n:'Caja de espíritu de equipo',d:'Crea una caja de espíritu de equipo.',obj:'crate'}
];
const TUT_TEXTS={
  undo:'Deshacer: vuelve atrás el último movimiento de tu soldado en este turno (botón ↶ del panel de acción).',
  settings:'Ajustes: el botón de sonido (🔊) silencia o activa los efectos; la cámara se ajusta con Q/E, +/− y C.',
  home:'Inicio: desde la partida, «Abandonar» te devuelve al menú sin borrar tu nación ni las monedas.',
  confirm:'Confirmar: «Terminar turno» cierra tu turno y deja actuar al rival. La vista 2D/3D se cambia sin tocar la partida.'
};
function tutShow(){const b=document.getElementById('tutBubble');if(b)b.style.display='block';}
function tutHide(){const b=document.getElementById('tutBubble');if(b)b.style.display='none';lsSet('radsoldiers_tut','1');}
window.quickSmoke=function(){ quickSmoke({myNation,setup,get G(){return G;}}); };
window.quickFlash=function(){ quickFlash({myNation,setup,get G(){return G;}}); };
wireUI({get G(){return G;},TUT_TEXTS,tutShow,tutHide});
/* ================= INIT ================= */
buildNationGrid();buildArsenal();
wireCampaignUI({getMission:()=>activeOriginalMission()||TUTORIAL_MISSION,getProgress:loadCampaign,showModal,audio:auVoice,toast,startTutorial:beginTutorial,skipTutorial,replayTutorial:beginTutorial,tutorialAdvance});
loadSkirmishTop('skirmish03');loadSkirmishTop('skirmish04');
(function(){
  setCHAR_PREFS(loadChars());
  const params=new URLSearchParams(window.location.search||'');
  const auto=params.get('autostart');
  const saved=lsGet(LS_NATION);const found=saved?nationById(saved):null;
  if(auto){
    myNation=found||NATIONS[0];setDemoNation(myNation);
    try{enterApp();}
    catch(e){try{renderNationChip();}catch(e2){} $('#mainTabs').style.display='flex'; showScreen('scr-play');}
    if(auto==='smoke')window.quickSmoke();
    else if(auto==='flash')window.quickFlash();
    else if(auto==='skirmish')window.quickStart('skirmish');
    else window.quickStart(MAP_DEFS[auto]?auto:'almacen');
    return;
  }
  if(found){myNation=found;setDemoNation(myNation);
    try{enterApp();}
    catch(e){try{renderNationChip();}catch(e2){} $('#mainTabs').style.display='flex'; showScreen('scr-play');}
  }
  else{if(saved)lsRemove(LS_NATION); showScreen('scr-nation');}
})();
$('#guerraCountdown').textContent=fmtCountdown(msToNextSaturday());
if(bridgeFull)installFullBridge(bridgeFull);
