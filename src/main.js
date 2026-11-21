import { GRID_CACHE, NATIVE_MAP_IDS, DEBUG_GRID, DEBUG_WEAPONS, setBoardSize, applyNativeGrid, nativeTile, nativeEdgeBits, nativeSolidEdge, nativeBlocked, tileWorldY, spawnsFor, boardCenter, preloadNativeGrids, buildMap, obAt, barrelAt, unitAt, deployedAt, droneAt, blocked, canStep, SMOKE_TURNS, smokeAt, smokeBlocksLOS, inBeacon, moveCostOf, reachable, DRAW_MOVE_MS_PER_TILE, drawMovePath, startDrawMove, smoothDrawStep, updateUnitDrawPosition, pathDist, gridLineCells, hasLOS, coverLevel, coverBonus, isFlanked, hitChance, falloffFactor, SPAWNS_A, SPAWNS_B, charAbilitiesFor, hasCharAction, hasCharIcon, applyCharacterAbilities, unitHasAction, canHealSpecial, canReviveSpecial, canSnipeSpecial, charForKey, makeUnit, startGame, log, teamName, aliveCount, selectUnit, spendEnergy, fireClipFor, playOnce, damage, explodeBarrel, tryShoot, setOverwatch, checkOverwatch, maybeDropLoot, pickupLoot, explodeNear, throwGrenade, COVER_COST, GAS_COST, GAS_DMG, GAS_TURNS, SWEEP_COST, SWEEP_RANGE, placeCover, throwGas, sweepDetect, ORB_COST, ORB_DMG, ORB_RANGE, fireOrbital, TRANQ_COST, TRANQ_RANGE, WATER_COST, WATER_RANGE, WATER_PUSH, TOOL_COST, TOOL_RANGE, TOOL_HEAL, throwTranq, waterCannon, useToolkit, SHIELD_COST, SHIELD_TURNS, SHIELD_MULT, ARTY_COST, ARTY_DMG, ARTY_RANGE, BEES_COST, BEES_DMG, BEES_TURNS, BEES_RANGE, useShield, fireArtillery, throwBees, MOLOTOV_COST, MOLOTOV_DMG, MOLOTOV_TURNS, CRATE_COST, TELE_COST, TELE_RANGE, throwMolotov, placeHealthCrate, teleportUnit, throwSmoke, MINE_DMG, MINE_COST, mineAt, viewerTeam, placeMine, checkMines, FLASH_COST, FLASH_RANGE, STUN_ENERGY_PEN, STUN_AIM_PEN, applyStun, throwFlash, guideDrone, useSpecial, deployTurret, captureTurret, turretFire, scoreDominationFor, checkBeaconAtTurnEnd, checkWin, endGame, showModal, closeModal, backToMenu, endTurn, aiUnitAct, runAI, setHoverTile, hoverTile, tileFromEvent, boardTileClick, undoLastMove } from './game/index.js';
import { $, nationById, flagHTML, emblemHTML, LEAF_SVG, flagArtHTML, PORTRAIT_CACHE, rolePortraitURL, setStep, LS_CAMPAIGN, DOM_ZONES, DOM_TARGET, DOM_MAX_ROUNDS, ESCORT_START, ESCORT_EXT, ESCORT_MAX_ROUNDS, ESCORT_DRONE_MAXHP, ESCORT_DRONE_HP, ESCORT_GUIDES_PER_ROUND, isExtraction, domZones, escortStart, escortExt, loadCampaign, saveCampaign, effSetupMode, effMode, inDomZone, domControl, LS_NATION, LS_WINS, LS_GAMES, toast, buildNationGrid, charNameFor, renderNationChip, screenStateFor, syncPlayingViewport, showScreen, enterApp, refreshGuerra, syncDiffSeg, renderCampaignPanel, openSetup, syncMapSeg, wireSkinSeg, syncSkinSegs, squadRows, buildSquads, readSquad } from './ui/index.js';
import { VIEW_MODE, setViewMode3, T3, setT3, w2cx, isSoftwareGL3, isMobileGL3, _toonGrad, toonGrad3, mat3, box3, TEX3, procTex3, texMat3, makeContactShadow3, skyTheme3, EMBLEM_TEX, nationTintColor, CAMO_TEX, camoTexture, emblemTexture, soldierColors3, makeSoldier3, makeGunProp3, REAL, parseOBJ3, ROLE_SCALES, setROLE_SCALES, ROLE_MODEL_FILES, ROLE_OUTFIT_FILES, loadRealSoldier, skState, loadSkirmishTop, loadSkirmishGeo, buildSkirmishGeo3, makeDrone3, MESHY_MODELS, MESHY_LOADING, validatedRigBoneInverses, sameRigBoneOrder, normalizeMeshyRig, normalizeMeshyRigGlobal, parseMeshyOBJ, loadMeshyModel, makeSkinnedModel, HAS_THREE, WEAPON_MESH_FILE, WEAPON_LEN, WEAPON_COVER_BY_FILE, WEAPONS_ORIGINAL, setWEAPON_METADATA, WEAPON_METADATA, setWEAPON_CALIBRATIONS, WEAPON_CALIBRATIONS, weaponCalibration, weaponMeta, WEAPON_THUMB_CACHE, set_wThumbR, _wThumbR, renderWeaponThumb, weaponCoverURL, GUN_MESH_CACHE, parseOBJStatic, weaponFileForRef, weaponCategoryForFile, weaponTargetLength, gunRotationFor, gunRotatedBounds, makeRealGun3, gunSwapWaiters, attachRealGun, makeGunAnchor, _gpDir, _gpTwoH, _gpFwd, _gpUp, _gpZ, _gpY, _gpOrigin, _gpQuat, _gpRecoil, _gpMat, _gpSocketQ, _gpParentQ, _gpRPalm, _gpLPalm, _gpFA, _gpPalmR, _gpPalmL, _smooth01, gunPoseFromHand, fitGunToHand3, fitSpriteGun, fitLiveGun3, CLIPLIB, CLIP_BLEND_MS, CLIP_BLEND_DEATH_MS, _cq, _cq2, _cv, _cv2, _cv3, CLIP_EVENT_LOG, _hitWhite, _retargetDelta, _retargetInverse, clipPulse, fireWeaponFeedback, clipEventFeedback, dispatchClipEvents, clipTrackAt, sampleClipQuat, sampleClipPos, worldRotationsFromLocal, retargetPoseToRig, rootBonePositionForClip, driveClipSoldier, _rq, _rq2, _sv, AXIS_X3, AXIS_Y3, AXIS_Z3, rotAxisQ, aimR, boneTargetQ, driveRealSoldier, makeRealSoldier3, REAL_SPRITES, REAL_SPRITE_FEET, realSpriteKey, realSpriteUnit, initRealSpriteRenderer, SPRITE_AIM_CT, poseSpriteClip, poseSpriteAim, renderRealSprite, getRealSpriteImage, getRealSpriteURL, buildThemedProps3, build3DWorld, rebuildDyn3, rebuildHighlights3, fx3Spawn, fx3Shot, fx3Proj, fx3Explosion, fx3Sparks, fx3Float, tickFx3D, updateHover3D, updateUnitHuds3D, resetCamState, resetCam3D, fitViewerDistance, viewerCenterOffset, init3D, setViewMode } from './render3d/index.js';
import { hash2, rr, lg, rg, shade, block3D, drawFloorTile, drawWall, drawContainer, drawCrate, drawBarrel, drawMedkit, drawPlatform, segRing, classicBoardMetrics, classicTileFromPoint, draw, drawDrone, drawDeployed, ROLE_SVG_ID, ARGON_DEFS, ARGON_SYMBOLS, ARGON_READY, SPRITE_CACHE, shadeHex, buildSpriteSVG, spriteDataURI, getSpriteImage, buildSpriteStrip, SKIN_TONES, drawSoldier, REDUCED_MOTION, FX, fxFloat, fxBurst, fxTracer, drawFX, fxLoop } from './render2d/index.js';
import { MEM_STORE, lsGet, lsSet, lsRemove, rngState, setTurnSeed, rng, isWeekend, msToNextSaturday, fmtCountdown, facingVec, angleToFacing, facingYaw, shortestArc, dist, cheb, LS_SOUND, AC, soundOn, audioCtx, tone, noiseBurst, sfx, AU_BASE, AU_AMBIENT, auPlay, auWeapon, auClick, auVoice, AMBIENT_FILE, auAmbient, MUSIC_TRACKS, AU_MUSIC, auMusicStart, auMusicStop, auStopAmbient, renderSoundBtn } from './core-and-audio.js';
import { NATIONS, NATION_ART, SKINS } from './data/nations.js';
import { WEAPONS, PISTOL, WEAPON_SFX, DMR_WEAPONS } from './data/weapons.js';
import { BODIES, ROLES, ROLE_NAMES, DEFAULT_SQUADS, ROLE_LOOK, roleLook, gameplayModelPresentation, ROLE_PORTRAIT, VOICE_FILES } from './data/roles.js';
import { CHARACTERS, CHARACTER_ABILITIES, ABILITY_OBJECTS, CAST_TEXTURE_FILE, CHAR_ABILITY_ACTIONS, CHAR_VOICE, MESHY_CAST, OWN_CAST, ORIG_CAST, sculptedWeaponUnit } from './data/cast.js';
import { CAMPAIGN_MISSIONS, SKIRMISH_GEO, MAPS_ORIGINAL, MAP_DEFS } from './data/maps.js';
import { STEP_META, AUX_LABELS, AUX_HINTS } from './data/ui-copy.js';

"use strict";
/* ================= DATA ================= */
/* Solo los 12 países importantes. Cada nación se identifica por los colores de
   su bandera y por el emblema de sus fuerzas armadas (motivo simplificado y
   redibujado para el juego, no una copia del escudo oficial). */


/* Escudos de nación de la Fase 1 (assets/ui/nacion_*.png), por id de nación. */





/* Skins iniciales: solo dos, y las dos son solo aspecto, sin pasivas.
   Las skins futuras sí darán pasivas pequeñas. */





/* Personajes con nombre del original (BuildManifestCharacterData.cs).
   CSN los usa como nombre y personalidad de cada soldado; el rol es nuestro
   (la clase real del original vive en un enum ofuscado y no se puede leer). */








/* ============ SILUETA Y PERSONALIDAD DE CADA ROL ============
   En el original cada clase se reconocía de un vistazo por el CUERPO
   antes que por el equipo: el pesado era un armario, el francotirador
   un espagueti con fusil, el espía un retaco oscuro. Aquí cada rol
   lleva su propia escala [ancho, alto, fondo] sobre la misma malla
   (aplicada en el grupo spin de makeRealSoldier3, así que vale igual
   para la vista 3D, para el sprite de la vista clásica, para la
   ficha y para las tarjetas de rol, que salen de ese mismo modelo),
   un descriptor de silueta para las tarjetas y, en tres roles, una
   pose de tarjeta distinta del apunte genérico: el Médico en su
   gesto de interactuar, el Ingeniero agachado desplegando y el
   Capitán dando la orden. Los tiradores conservan el fotograma de
   apunte de su familia de arma, que ya difiere por arma. */



/* ============ RETRATOS DE ROL (assets/ui/retrato_*.png) ============
   Los siete retratos de busto aprobados por Dani (generados fuera, en
   Gemini Studio, y descargados como PNG transparentes de 512×512):
   son la imagen de cada rol en el HUD —la ficha de la unidad
   seleccionada, la lista de escuadras, las tarjetas de «Los 7 roles»
   y su tabla— en lugar del retrato fotografiado desde el modelo 3D.
   El sprite del tablero no cambia: en la vista clásica y en la 3D el
   soldado sigue saliendo del modelo, porque ahí es un cuerpo entero
   en su pose, no un busto. */

/* Retrato del rol: se renderiza del MODELO REAL del juego (chibi, con su
   uniforme) para que toda la interfaz hable el mismo idioma visual. El PNG
   pintado queda solo como respaldo mientras carga el modelo. */



/* ================= STATE ================= */


let flowStep='nation';

let myNation=null, pickedNation=null;
let setup={mode:'baliza',fmt:4,opp:'ia',rivalNation:null,skinA:'nacion',skinB:'nacion',map:'almacen',difficulty:'normal',campaignMission:0,squadChars:{A:{},B:{}}};

/* ===== DOMINACIÓN: tres zonas, puntuación por ronda =====
   Depósito (3,4) y Muelle (8,7) son casillas únicas opuestas (simetría
   de 180°), verificadas libres de muros, estanterías, cajas y barriles
   en los trece tableros, y el Centro es el bloque 2×2 de la baliza,
   simétrico consigo mismo. Control = al menos un soldado propio dentro
   y ninguno enemigo. */


/* ===== ESCOLTA: el dron averiado y la extracción =====
   El dron sale de (1,5), pegado al despliegue oeste de la escuadra que
   escolta (la del Jugador 1), y la extracción es el bloque 2×2 del este
   (10,5),(11,5),(10,6),(11,6). Las cinco casillas están verificadas
   libres de muros, estanterías, cajas y barriles en los trece
   tableros, y salida y extracción son simétricas a 180° entre sí.
   Guiado: un soldado de la escolta adyacente al dron lo mueve 1 casilla
   por 2 ⚡, con un máximo de 2 guiados por ronda entre toda la
   escuadra. El dron entra entero (240 de 240 PV) y el Médico puede
   repararlo. La defensa gana destruyéndolo, eliminando a la escolta o
   aguantando ESCORT_MAX_ROUNDS rondas. */







/* ===== CAMPAÑA · OPERACIÓN LONDRES ===== */



/* Modo efectivo del SETUP: en campana manda el objetivo de la mision
   (eliminacion, baliza, dominacion, escolta). */




let G=null;

/* Acceso seguro al almacenamiento: en algunos navegadores y webviews el
   localStorage lanza un error al leerlo (iframe sin permiso, modo privado,
   almacenamiento bloqueado). Antes, ese error al confirmar la nación
   abortaba la entrada al juego y el jugador se quedaba en la pantalla de
   selección para siempre. Ahora toda lectura/escritura pasa por aquí y,
   si el almacenamiento falla, se usa una copia en memoria de la sesión:
   el juego siempre deja entrar, aunque la nación no persista al cerrar. */










/* ================= NATION FLOW ================= */







document.querySelectorAll('#mainTabs button').forEach(b=>b.onclick=()=>showScreen('scr-'+b.dataset.tab));
document.querySelectorAll('[data-back]').forEach(b=>b.onclick=()=>showScreen('scr-play'));

/* ================= GUERRA DE NACIONES ================= */

setInterval(()=>{if(!isWeekend())$('#guerraCountdown').textContent=fmtCountdown(msToNextSaturday());else if($('#scr-play').classList.contains('on'))refreshGuerra();},1000);

/* ================= SETUP ================= */
document.querySelectorAll('[data-start]').forEach(b=>b.onclick=()=>openSetup(b.dataset.start));
(function(){const cb=document.getElementById('campaignBtn');if(cb)cb.onclick=()=>{const p=document.getElementById('campaignPanel');if(p){p.style.display='block';renderCampaignPanel();p.scrollIntoView({behavior:'smooth',block:'start'});}};const rb=document.getElementById('campaignResetBtn');if(rb)rb.onclick=()=>{saveCampaign({next:0,vet:[],done:false});renderCampaignPanel();toast('Campaña reiniciada: vuelves a la Misión 1, sin veterania.');};})();

document.querySelectorAll('#diffSeg button').forEach(b=>b.onclick=()=>{if(setup.mode==='campana')return;setup.difficulty=b.dataset.diff;syncDiffSeg();});



document.querySelectorAll('#fmtSeg button').forEach(b=>b.onclick=()=>{setup.fmt=+b.dataset.fmt;document.querySelectorAll('#fmtSeg button').forEach(x=>x.classList.toggle('on',x===b));buildSquads();});

document.querySelectorAll('#mapSeg button').forEach(b=>b.onclick=()=>{setup.map=b.dataset.map;syncMapSeg();});
document.querySelectorAll('#oppSeg button').forEach(b=>b.onclick=()=>{setup.opp=b.dataset.opp;document.querySelectorAll('#oppSeg button').forEach(x=>x.classList.toggle('on',x===b));buildSquads();});

wireSkinSeg('skinSegA','skinA');wireSkinSeg('skinSegB','skinB');

$('#cancelSetup').onclick=()=>{$('#setupArea').style.display='none';$('#menuArea').style.display='block';document.body.dataset.state='menu';syncPlayingViewport();setStep('mode');refreshGuerra();};




$('#launchBtn').onclick=()=>startGame(readSquad('A'),readSquad('B'));

/* ============ Azar con semilla por turno (como el original) ============
   La partida es reproducible: al empezar cada turno se fija una semilla
   con la ronda y el bando, y todos los tiros, críticos y dispersiones de
   ese turno salen de ella en orden. */





/* ================= GIRO ANIMADO (sin clip de giro en el IPA) =================
   Entre los 22 clips del original ya convertidos no hay ninguno de giro:
   el soldado cambiaba de dirección de mira de golpe, rotando en el sitio
   en un solo fotograma, y en la vista 3D ni siquiera miraba hacia su
   dirección de mira lógica (la que decide cobertura y flanqueo), sino
   hacia el enemigo más cercano, así que lo que se veía y lo que las
   reglas calculaban podían ser dos direcciones distintas. Esta capa lo
   cierra en código, sin inventar un clip que no existe: la orientación
   visual de cada soldado persigue su dirección de mira lógica por el
   arco más corto, con una duración proporcional al ángulo (unos 300 ms
   por cuarto de vuelta, entre 200 y 560 ms), acelerando al salir y
   frenando al llegar. Mientras el giro dura, el soldado da el pasito de
   ajuste (el clip de paso suena en la vista 3D y el cuerpo se inclina y
   se estrecha un instante en la clásica) en vez de pivotar como una
   peonza. Con «reducir movimiento» el giro vuelve a ser instantáneo.
   El estado vive en la propia unidad (_dispYaw, _turnFrom, _turnTo,
   _turnT0, _turnDur, _turning, _turnProg, _turnDelta) y las dos vistas
   llaman a la misma función, así que giran a la vez y en el mismo
   sentido. Devuelve la guiñada visual actual en radianes, en el mismo
   convenio que ya usa el juego: atan2(dy, dx) sobre la cuadrícula. */


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
      /* La mira cambia a mitad de giro: se reinicia desde donde va. */
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

/* ================= MAP ================= */
let W=12,H=12;
let BEACON=[{x:5,y:5},{x:6,y:5},{x:5,y:6},{x:6,y:6}];
let TURRET_POS={x:5,y:5};
let NATIVE_GRID=null;














preloadNativeGrids();
/* Los trece tableros comparten baliza, torreta y zonas de despliegue, y
   los trece layouts guardan simetría de 180° (cada pieza en (x,y) tiene
   su pareja en (11−x,11−y)), así que ningún bando nace con ventaja. El
   Patio es un mapa nuevo construido en código, como se construyó el
   Almacén; el tercero y el cuarto son Skirmish_03 y Skirmish_04 del IPA,
   con su geometría real como capa visual sobre la misma cuadrícula, con
   las reglas intactas. El quinto, Skirmish_05, entra en esta ronda
   construido en código como el Patio (su paquete del IPA no está entre
   los archivos extraídos, así que no trae geometría real: trae su
   disposición jugable propia, verificada pieza a pieza, y su suelo de
   depósito londinense dibujado en código en las dos vistas). El
   sexto, Skirmish_06 · Los andenes, entra en la ronda siguiente por
   el mismo camino: construido en código, con su disposición propia
   verificada pieza a pieza y su suelo de andén dibujado en código en
   las dos vistas. El séptimo y el octavo, Skirmish_07 · El mercado y
   Skirmish_08 · La terminal, entran en esta ronda por el mismo camino:
   construidos en código, con sus disposiciones propias verificadas
   pieza a pieza y sus suelos (mercado y terminal) dibujados en código
   en las dos vistas. El noveno y el décimo, Skirmish_01 · La plaza y
   Skirmish_02 · El embarcadero, cierran el conjunto en esta ronda por
   el mismo camino: construidos en código, con sus disposiciones
   propias verificadas pieza a pieza y sus suelos (plaza y embarcadero)
   dibujados en código en las dos vistas. Y el undécimo,
   Skirmish_09 · La rotonda, entra en esta ronda por el mismo camino
   y corrige el conteo del conjunto: la numeración del original
   salta del 06 al 08 (el 07 de aquí es un tablero de código que
   ocupa el hueco) y sigue con el 09, el 10 y el 11, así que con el
   09 dentro quedan dos, el 10 y el 11. Y el duodécimo y el
   decimotercero, Skirmish_10 · El cruce y Skirmish_11 · El
   astillero, cierran el conjunto en esta ronda por el mismo
   camino: construidos en código, con sus disposiciones propias
   verificadas pieza a pieza y sus suelos (cruce y astillero)
   dibujados en código en las dos vistas. Con los dos dentro, los
   ocho números Skirmish del original están en el remake y el
   total de tableros pasa a trece. */









/* ===== M18 · HUMO =====
   La cortina de humo de la M18: dura 2 rondas completas (se disipa al
   empezar el turno de quien la lanzó en la segunda ronda siguiente,
   en endTurn), y bloquea la visión a través de sus casillas, pero no
   el movimiento: se puede entrar en la cortina y cruzarla, y dentro
   de ella nadie ve ni es visto a más de 1 casilla (cuerpo a cuerpo
   sí: a 1 casilla el tiro se resuelve igual). El humo es del tablero,
   no de un bando: tapa a los dos por igual. */







/* BFS reachable with energy budget */








/* Sensores y visibilidad del original (GameGridComponent.cs, GameTileComponent.cs):
   la línea de visión avanza por el rayo en pasos de 0,25 unidades y mira cada casilla
   que cruza; una casilla con VisBlocker o un obstáculo que bloquea la línea corta el
   rayo, y solo la cobertura máxima (nivel 3) bloquea la visión. La visibilidad de la
   IA tiene 4 estados (AIVisBlocked / CurrentlyVisible / NeverVisible / RecentlyVisible).
   CSN usa Bresenham por casillas (equivalente para el bloqueo por casilla) y la
   cobertura direccional de 4 niveles (0–3) con penalización [0,12,25,40]. */








/* ================= GAME ================= */
/* Despliegues: las diez casillas están verificadas libres de muros,
   estanterías, cajas y barriles en los trece tableros, y cada una tiene
   su pareja simétrica a 180°. El quinto despliegue ocupaba antes una
   casilla de muro en el Almacén (el 5 contra 5 nacía con un soldado
   dentro de la pared); ahora cierra la columna de despliegue. */


let uid=0;

















/* ---- actions ---- */

/* Clip de disparo del original según el arma usada (vista 3D): la pistola
   va a una mano y cada familia de arma tiene el suyo en el IPA. */

/* Gesto único del original en la vista 3D (granada, despliegue, recogida…). */










/* ================= SONIDO SINTETIZADO =================
   Capa de sonido sin archivos: todo se genera con WebAudio en el
   momento (ruido filtrado para disparos y explosiones, tonos cortos
   para avisos y fanfarrias), así que no hay nada que cargar ni que
   pueda fallar por red. El navegador solo deja sonar tras un gesto
   del usuario, así que el contexto se crea o se reanuda en cada
   toque. Botón de silencio en la barra de turno; la preferencia se
   guarda en este dispositivo, como la nación y la campaña. */



document.addEventListener('pointerdown',()=>{audioCtx();});



/* ================= AUDIO DEL ORIGINAL (F5) =================
   Los clips salen del IPA: sonidos de arma por categoria, explosiones,
   voces de cada personaje (select, confirm, pain, death, firing, thanks)
   y ambiente por mapa. Se crean elementos Audio por reproduccion y se
   respeta el boton de silencio. */


/* Voz propia por personaje (los 17 del IPA); los propios caen a la voz de
   su rol. */






/* Clic de interfaz del original: un toque corto en cada botón. Un solo
   oyente delegado lo cubre todo (menú, partida, visor, ajustes) sin tocar
   cada botón a mano; respeta el interruptor de sonido porque auPlay ya lo
   comprueba. */

try{document.addEventListener('click',function(e){try{if(e.target&&e.target.closest&&e.target.closest('button'))auClick();}catch(err){}});}catch(e){}

/* Ambiente por mapa: varios mapas comparten el mismo archivo de ambiente
   del original (mismo contenido), así que los temas duplicados apuntan al
   archivo canónico y no se guarda una copia por mapa. */


/* Musica del original: siete temas de partida del IPA, uno al azar por
   partida, en bucle y a volumen bajo. */






/* ---- M18 · GRANADA DE HUMO (solo el Espía) ----
   El Espía lanza la M18 a 4 casillas como máximo (2 ⚡, lleva 2) y la
   cortina tapa esa casilla y las 4 adyacentes en cruz (radio 1):
   bloquea la visión a través de ella durante 2 rondas completas y se
   disipa al empezar el turno de quien la lanzó en la segunda ronda
   siguiente. No hace daño y no bloquea el movimiento: solo la vista,
   y para los dos bandos. */
/* ================= HABILIDADES DEL ORIGINAL (F4) =================
   Cobertura desplegable, granada de gas y barrido detector, con los
   parametros del esquema AbilityGameplayData.cs (RequiredAP, MaxUses,
   MaxRange, Radius, TickDamage). */




/* Orbital laser: un solo disparo de precision desde arriba. */


/* ===== LOTE 5 (F4): tranquilizante, canon de agua y kit de herramientas ===== */




/* ===== LOTE 4 (F4): escudo antidisturbios, artillería y bomba de abejas ===== */




/* ===== LOTE 3 (F4): molotov, caja de salud y teletransporte ===== */





/* ---- M18A1 · MINA CLAYMORE (solo el Ingeniero) ----
   El Ingeniero lleva 2 Claymores por partida (3 ⚡) y las coloca en
   una casilla adyacente libre. La mina es invisible para el bando
   contrario en las dos vistas: solo la ve quien la colocó (contra la
   IA, el jugador; a dos jugadores, el bando que tiene el turno, que
   es quien sostiene el dispositivo), dibujada a ras de suelo con su
   LED rojo. No bloquea el movimiento ni la visión: se descubre
   pisándola, y entonces hace MINE_DMG de daño explosivo al soldado
   que entra en su casilla y se consume. Las propias nunca estallan
   bajo los pies de su bando, y el dron de Escolta no las pisa (vuela
   bajo, no presiona el suelo). El disparador es la casilla destino
   del movimiento, la misma en la que el soldado acaba su avance. */





/* ---- M84 · GRANADA ATURDIDORA (solo el Comando) ----
   La tercera pieza de equipo especial del juego, tras el humo del
   Espía y la Claymore del Ingeniero, y la que el Arsenal fichaba
   como diseño («aturde 1 turno en radio 1, sin daño»): el Comando
   lleva 2 M84 por partida (2 ⚡, lanzamiento a 4 casillas, en arco
   como la M67, así que ni el humo ni los muros la paran) y el
   fogonazo aturde a TODO soldado en radio 1 de la casilla destino
   (la casilla y las 8 que la rodean), de los dos bandos: la luz no
   distingue uniformes. Solo se salva quien la lanza, que aparta la
   mirada. El dron de Escolta no se aturde: es una máquina.
   El estado ATURDIDO dura 1 turno del aturdido, y se sirve así: la
   bandera (stunned) se pone en el acto y ya corta el fuego de
   respuesta y rompe la vigilancia del aturdido; al empezar su
   siguiente turno (stunFresh) paga −6 ⚡ de salida y durante ese
   turno dispara con −25 de puntería (hitChance) y no puede ponerse
   en vigilancia; al cerrar ese turno la bandera se retira en
   endTurn. No se apila: una segunda M84 sobre un aturdido renueva
   el turno, no lo duplica. Aturde también al Espía invisible,
   porque no es un disparo dirigido sino un fogonazo en área, pero
   no le quita la invisibilidad. */



/* ---- ESCOLTA: guiar el dron ----
   El dron no se mueve solo: un soldado de la escolta pegado a él paga
   2 ⚡ y lo mueve 1 casilla a una adyacente libre, con un máximo de
   ESCORT_GUIDES_PER_ROUND guiados por ronda entre toda la escuadra
   (el contador vive en el propio dron y se renueva al empezar el turno
   de la escolta). Si la casilla destino es de la extracción, la
   partida se gana en el acto. */






/* ---- turn flow ---- */







$('#quitBtn').onclick=()=>{showModal('<h2>¿Abandonar la partida?</h2><p>Se perderá el progreso de esta partida. Tu nación y tu marcador de Guerra de Naciones no se tocan.</p><div style="display:flex;gap:10px;justify-content:center;flex-wrap:wrap;margin-top:14px"><button class="btn danger big" onclick="closeModal();backToMenu()">Sí, abandonar</button><button class="btn big" onclick="closeModal()">Seguir jugando</button></div>');};


$('#endTurnBtn').onclick=endTurn;
$('#soundBtn').onclick=()=>{soundOn=!soundOn;try{lsSet(LS_SOUND,soundOn?'1':'0');}catch(e){}renderSoundBtn();if(soundOn)sfx('turn');try{if(!soundOn){auMusicStop();auStopAmbient();}else if(G&&G.units&&G.units.length){auMusicStart();auAmbient(G.map.theme);}}catch(e){}toast(soundOn?'Sonido activado: disparos, ambiente y música del original.':'Sonido desactivado.');};
renderSoundBtn();

/* ---- AI ---- */



/* ---- board interaction ---- */
const canvas=$('#board'),ctx=canvas.getContext('2d');

/* ================= VIDA DEL TABLERO =================
   Capa de animación continua sobre el mismo tablero de siempre: no cambia
   ninguna regla ni ninguna cifra, solo cómo se ve el paso del tiempo.
   Los soldados guardan una posición de dibujo (dx, dy) que persigue a su
   casilla lógica (x, y), así que se desplazan con inercia en vez de
   aparecer de golpe; en reposo respiran con un balanceo leve; los disparos
   dejan trazadora e impacto; el daño sube en números flotantes; y las
   explosiones sacuden la cámara. Con «reducir movimiento» activado en el
   sistema, todo esto se apaga y el tablero vuelve a dibujarse estático. */







requestAnimationFrame(fxLoop);

canvas.addEventListener('mousemove',e=>{setHoverTile(tileFromEvent(e));if(G)draw();});


const _undoBtn=document.getElementById('undoBtn');if(_undoBtn)_undoBtn.onclick=undoLastMove;
canvas.addEventListener('click',e=>boardTileClick(tileFromEvent(e)));

/* ---- unit card / UI ---- */
function updateUI(){
  if(!G)return;
  const pill=$('#turnPill');
  pill.className='turn-pill '+G.turn;
  pill.textContent=G.over?'Partida terminada':'Turno: '+teamName(G.turn)+(G.aiBusy?' · la IA está jugando…':'');
  $('#roundLabel').textContent='Ronda '+G.round+(effMode(G)==='dominacion'?(' / '+DOM_MAX_ROUNDS):effMode(G)==='escolta'?(' / '+ESCORT_MAX_ROUNDS):'')+' · '+G.map.name+' · '+(effMode(G)==='eliminacion'?'Eliminación':effMode(G)==='dominacion'?'Dominación':effMode(G)==='escolta'?'Escolta del dron':G.mode==='guerra'?'Guerra de Naciones':G.mode==='campana'?('Campaña · Misión '+(G.campaignMission+1)+' · '+CAMPAIGN_MISSIONS[G.campaignMission].title):'Captura de baliza')+(G.opp==='ia'?(' · IA '+G.difficulty):'')+' · Quedan '+aliveCount('A')+' contra '+aliveCount('B');
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
    b.onclick=()=>{if(u.alive&&u.team===G.turn&&!G.aiBusy)selectUnit(u);};
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
    if(act==='grenade'){G.actionMode='grenade';toast('Toca la casilla destino de la M67 (máx. 3 casillas).');}
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

/* ================= DRAW · estilo 3D estilizado =================
   Tablero urbano cenital inclinado como el original: losas de hormigón
   con juntas, grietas, alcantarillas y marcas pintadas; muros, contenedores
   y cajas con volumen (cara superior, frontal y lateral con luz desde
   arriba a la izquierda); barriles cilíndricos; y soldados cabezones con
   degradados, contorno grueso, sombra suave y el anillo segmentado de
   energía a los pies característico de RAD Soldiers. */





/* Bloque con volumen: base en la casilla, cara superior desplazada arriba */












/* El dron averiado de Escolta: cuerpo con cuatro rotores que giran,
   luz ámbar de aviso, anillo de la escuadra que escolta bajo el casco y
   su barra de vida flotante, como la de los soldados. Dañado, echa
   humo; destruido, queda volcado en el suelo con la cruz de baja. Se
   dibuja desde su posición interpolada (dx, dy), igual que los
   soldados: tampoco él se teletransporta. */


/* ================= SPRITES SVG (código de Argon) DENTRO DEL JUEGO =================
   Los 7 soldados viven en [la hoja SVG de Argon viaja como archivo: assets/argon-soldiers.svg] como <symbol> con clases
   .uniforme/.casco/.piel/.botas y degradados de volumen. Aquí se cargan una
   vez, se convierten en imágenes y el tablero los dibuja con drawImage en
   cada casilla: son el soldado real de la partida, no una ilustración.
   Con la skin de Nación, los degradados del uniforme y del casco se tiñen
   con los colores de la bandera de esa nación antes de rasterizar. */








fetch('assets/argon-soldiers.svg').then(r=>{if(!r.ok)throw new Error('svg');return r.text();}).then(txt=>{
  const doc=new DOMParser().parseFromString(txt,'image/svg+xml');
  const defsEl=doc.querySelector('defs');if(!defsEl)return;
  ARGON_DEFS=Array.prototype.slice.call(defsEl.children).filter(el=>el.tagName!=='symbol').map(el=>new XMLSerializer().serializeToString(el)).join('');
  doc.querySelectorAll('symbol').forEach(sym=>{ARGON_SYMBOLS[sym.id]=Array.prototype.map.call(sym.childNodes,n=>new XMLSerializer().serializeToString(n)).join('');});
  ARGON_READY=true;
  buildSpriteStrip();
  if(G)draw();
}).catch(()=>{});



/* ================= VISTA 3D DEL TABLERO =================
   La capa que le faltaba al remake: el mismo tablero y las mismas reglas,
   pero levantados en volumen con Three.js. El escenario (losas, muros,
   contenedores, cajas, barriles, botiquines, baliza y torreta) se modela
   en el espacio, y cada soldado es la malla real del IPA (Soldier_Light
   con su skinning Bip001 y su textura Soldier_Light_d; el movimiento
   sobre ese esqueleto son los clips del original ya convertidos: reposo,
   paso, fuego por familia de arma, impactos, muertes y gestos, con el
   movimiento reconstruido en código solo como reserva), con el arma de su rol
   construida en código, los colores de bando #387EC9 y #C95338 en el
   disco y el anillo segmentado de energía bajo los pies. El soldado de
   cajas de makeSoldier3 queda como reserva por si la malla no carga. Los
   clics en el escenario 3D se resuelven por raycast a la
   casilla y entran por la misma boardTileClick del tablero clásico:
   una sola lógica de partida para las dos vistas. */





















/* ================= EL SOLDADO REAL DEL IPA =================
   La revisión del IPA de iOS trajo las tres piezas que faltaban, y esta es
   la que las une: la malla Soldier_Light (1.211 vértices, OBJ del IPA) con
   su skinning de verdad (18 huesos Bip001, matrices bindpose 4×4 y 4 pesos
   por vértice que suman 1,0, verificados en el inventario), el atlas real
   del cuerpo Soldier_Light_d (PVRTC decodificado a PNG: chaleco, piel y
   cara con bandana). El horneado previo ([el rig viaja como archivo: assets/soldier_rig.json]) trae
   los locales de hueso derivados de las bindpose y los pesos por vértice.
   Los clips del original sí se reproducen (driveClipSoldier, más abajo):
   el desajuste que los tuvo meses aparcados no era de los clips sino del
   decodificador con el que se leían los cuaterniones comprimidos de
   Unity 4.2, que doblaba los campos anteriores al componente omitido
   cuando este era Y o Z y tomaba siempre positivo el omitido, que puede
   ser negativo. Con el decodificador corregido, el idle de referencia
   (Take 001) cae a RMS 0,0049 contra la pose de bind, sin alinear nada.
   Los 40 clips del original van ya convertidos en
   assets/soldier_clips.json: cada clave lleva horneada la conversión de
   frames entre el espacio de los clips y el de este rig (verificada en
   la pose de bind con error ≤0,25°), y el movimiento de raíz entra como
   desplazamiento de la pelvis reescalado por 0,358/0,699, porque las
   curvas de posición de los clips pertenecen a un bípede de animación
   más alto que esta malla. La verificación por cinemática directa sobre
   el paquete convertido deja los pies en el suelo en reposo y al andar
   y el cuerpo tendido al final de las dos muertes. driveRealSoldier (el
   movimiento reconstruido en código, con los giros conjugados desde la
   pose de bind) queda solo como reserva por si el archivo de clips no
   cargara. Si la malla no carga, la vista 3D sigue con el soldado de
   cajas de makeSoldier3, con la misma partida. */


/* Modelos del original por CLASE: cada rol carga su malla, su rig de
   huesos y su textura de uniforme del IPA (Soldier_Light/Heavy, Agent_Light/
   Heavy, Medic, Engineer, Commander). Si un rol falla, cae al modelo base. */

/* ===== MODELOS POR CLASE =====
   Las siete mallas del IPA (Soldier_Light, Soldier_Heavy, Agent, Medic,
   Engineer, Commander) con sus rigs reextraidos EN EL ORDEN DE HUESOS DEL
   RIG BASE: los clips se aplican por indice (pack.bones[i] -> bones[i]),
   asi que compartir el orden es lo que los hace compatibles. Cada clase
   conserva sus proporciones reales; la escala la normaliza ROLE_SCALES. */



loadRealSoldier();
/* ================= SKIRMISH DEL IPA: 03 Y 04 REALES =================
   La geometría completa de Theme_01_Skirmish_03 y Theme_01_Skirmish_04,
   compuesta fuera de la página desde los propios paquetes del IPA con
   un solo método, verificado contra el primer mapa antes de usarlo en
   el segundo (la composición reproduce el .bin del 03 al vértice y al
   triángulo: 84.939 vértices, 45.942 triángulos, grupos de 137.082 y
   744 índices): por cada MeshRenderer se aplicó la matriz mundo de su
   Transform a los vértices de su malla y cada submalla quedó asignada
   al atlas de su material (leído del paquete: T_Atlas_01_D para casi
   todo; T_Atlas_02_U —que usa la misma imagen que T_Atlas_02_D— para
   los detalles: 248 triángulos en el 03 y 2.845 en el 04). Las
   submallas del paquete son tiras de triángulos con costuras
   degeneradas, y entran ya desplegadas en triángulos reales (los
   degenerados se descartan). Fuera se quedaron la malla de colisión
   (Clip), las tarjetas de desvanecido de fuera de tablero, las luces
   giratorias y las partículas: lo que queda son 84.939 vértices y
   45.942 triángulos en [la geometría viaja como archivo: assets/maps/skirmish03.bin] y 80.571 vértices y
   45.030 triángulos en [la geometría viaja como archivo: assets/maps/skirmish04.bin] (cabecera JSON +
   posiciones/UV en Float32 + índices en Uint32), con los dos atlas en
   JPEG (los mismos archivos de atlas sirven para los dos mapas: el
   IPA los trae idénticos en ambos paquetes). El eje Z va espejado al
   pasar de Unity a Three.js y la triangulación lleva el orden de
   índices girado para compensarlo; las normales se calculan al
   construir la geometría. La escala (15/41,33 en el 03; 15/42,83 en
   el 04) deja el suelo de cada mapa —41,33 × 33,33 unidades el 03 y
   42,83 × 39,33 el 04— abrazando el tablero de 12×12: el suelo del 03
   ya nacía centrado en el origen, y el del 04 entra recentrado (su
   centro caía a 0,75 y −1,0 unidades del origen) para abrazarlo
   igual. La geometría es la capa visual de estos tableros y no toca
   ni una regla. En la vista clásica, la misma geometría se ve como
   plano cenital ([el plano cenital viaja como archivo: assets/maps/skirmish03_top.jpg] y skirmish04_top.jpg,
   generados desde estas mismas caras y atlas). Si los archivos no
   cargan, el tablero sigue con sus losas de reserva y la partida no
   cambia. */





/* El dron averiado de Escolta en 3D: casco con placa ámbar, cuatro
   rotores que giran sobre sus brazos, luz de aviso que parpadea y el
   anillo de la escuadra que escolta bajo el fuselaje. Se crea una vez
   por partida en build3DWorld y __render3D lo mueve desde la posición
   interpolada del dron (dx, dy), como a los soldados. */

/* ================= ARMAS REALES DEL ORIGINAL (F14) =================
   Las 23 mallas de armas extraidas del IPA (assets/weapons/*.obj + su
   textura) se cargan y se colocan en el mismo anclaje que el arma
   procedural: grupo con el canon hacia +X. Las mallas vienen en Z arriba,
   asi que el grupo se gira -90 grados en X y se escala por categoria. */


/* Caratulas de la Armeria: el arte item_weapon_* del original cuando existe
   para la malla, y si no un render del propio modelo 3D. */

/* Catálogo de las 23 armas del original (fase 3): nombre original del juego
   (de la carátula item_weapon_* cuando existe; si no, nombre limpio de la
   malla), modelo .obj, textura propia (nombre original en index.json y
   tamaño), dimensiones medidas de la caja (x, y, z en unidades del .obj,
   Z arriba), vértices, carátula, armas de CSN que usan la malla y roles.
   Las texturas son las del IPA (index.json); las dimensiones se midieron
   del .obj. La carátula 09 (M16A2) existe en el original pero no está
   asignada a ninguna malla del repo; la 11 (Jackhammer) tiene carátula
   pero su malla no está entre las 23 extraídas. */

/* Metadatos reales de UnitWeapon extraídos de los assetbundles. Se cargan
   en cuanto está disponible el JSON; mientras tanto los acoples usan la
   configuración actual como respaldo. */


fetch('assets/weapons/weapon_metadata.json').then(r=>r.ok?r.json():{}).then(m=>{WEAPON_METADATA=m||{};}).catch(()=>{});
fetch('assets/weapons/weapon_calibrations.json').then(r=>r.ok?r.json():{}).then(c=>{WEAPON_CALIBRATIONS=c||{};}).catch(()=>{});


























/* Si la librería three.js no llega a cargar (sin red, CDN caído), el juego
   entero debe seguir funcionando en la vista clásica: por eso estos
   objetos temporales se crean solo si THREE existe. Sin este guarda, un
   fallo del CDN mataba el script completo en esta línea y ni siquiera la
   selección de nación se dibujaba. Todo lo demás de la capa 3D ya
   comprobaba typeof THREE antes de tocarlo (loadRealSoldier, init3D). */





/* Giro compuesto de la postura de apunte, en el espacio del IPA: primero
   el cabeceo (X, levantar el brazo hacia delante), luego la guiñada
   hacia dentro (Z, cerrar el brazo hacia el centro del pecho) y por
   último el balanceo (Y, pegarlo al cuerpo). sgn espeja el lado. */

/* Objetivo de un hueso: su rotación local de bind con un giro aplicado en
   el espacio del IPA (X lateral, -Y hacia delante, Z arriba), conjugado a
   su espacio local con su orientación de bind. Así cada hueso se mueve
   sobre el esqueleto real sin tocar ni un peso. */


/* ================= LOS CLIPS DEL ORIGINAL, REPRODUCIÉNDOSE =================
   [los clips viajan como archivo: assets/soldier_clips.json] trae 40 clips del IPA ya convertidos a este
   rig (reposo a una y dos manos, paso, disparo por familia de arma,
   impacto de bala, de ráfaga y de explosión, muerte por bala y por
   explosión, lanzar granada, desplegar torreta, interactuar, recoger y
   victoria), con la conversión de frames horneada en cada clave y el
   movimiento de raíz como desplazamiento de pelvis reescalado. Aquí solo
   hay que muestrear: buscar el tramo de claves, interpolar con slerp y
   dejar que el suavizado sobre curQ cosa los cambios de clip sin saltos.
   La máquina de estados sale de los mismos campos que ya usa la partida:
   _shootT/_fireKey al disparar, _hitT/_hitKind al encajar, _deathT y
   _deathKind al caer, _onceKey/_onceT para los gestos únicos.

   INTERPOLACIÓN ENTRE CLIPS (fundido cruzado): muestrear dentro de un
   clip ya era continuo, pero el CAMBIO de clip no: al pasar de reposo a
   paso, de paso a disparo o de un gesto al reposo, la pose objetivo
   saltaba a la del clip nuevo y solo el suavizado exponencial de curQ
   disimulaba el tirón, con un resultado que además dependía de la tasa
   de refresco (a 120 Hz el mismo factor por fotograma converge el doble
   de rápido que a 60 Hz). Ahora cada cambio de clip abre un fundido:
   durante la ventana del fundido se muestrean los DOS clips a la vez
   (el saliente sigue avanzando desde el instante en que se cortó) y la
   pose objetivo es el slerp entre ambas con peso smoothstep, así que
   ningún hueso salta ni un grado entre fotograma y fotograma. Las
   ventanas son cortas y según la urgencia del gesto: 140 ms al caer
   muerto y 200 ms en el resto (reposo↔paso, disparo, gestos, el cambio
   de variante de reposo que rota cada 11 s). Los impactos son la
   excepción y entran sin fundido, medido sobre el propio banco: el
   primer tramo de esos clips ya trae el latigazo del golpe (la mano
   izquierda barre 1,5 rad en los primeros 20 ms del clip de impacto),
   y retener la pose durante el fundido solo concentraba ese barrido en
   menos fotogramas al soltarlo (1,27 rad de salto con fundido de 90 ms
   y 1,15 con 50 ms, contra 0,90 dejándolo entrar directo con el
   suavizado de siempre). El desplazamiento de raíz se funde igual,
   con lerp entre los dos clips. Y el suavizado de curQ que va detrás ya
   no usa un factor fijo por fotograma: se convierte a independiente de
   la tasa de refresco con el dt real entre fotogramas, para que el
   soldado se mueva igual a 30, 60 o 120 Hz. Con «reducir movimiento»
   no hay fundido: el corte es instantáneo, como todo lo demás. */




if(typeof window!=='undefined')window.__csnEvents=CLIP_EVENT_LOG;












/* ================= SPRITES 2D DESDE EL MODELO 3D REAL =================
   La vista clásica dibujaba los sprites SVG de Argon y la vista 3D la
   malla real del IPA, y eran dos soldados que no se parecían en nada:
   Dani lo señaló y esta ronda lo cierra sin generar ningún modelo nuevo,
   porque el modelo ya existe. En cuanto la malla Soldier_Light y su
   textura están cargadas, un renderizador fuera de pantalla la levanta
   con el mismo constructor de la vista 3D (makeRealSoldier3: misma
   malla, mismo skinning, misma textura, el arma de su rol y su mochila,
   la silueta de su tipo de cuerpo y el tinte de su skin y su nación),
   la deja en la postura de apunte de sus propios clips (o en la postura
   reconstruida si los clips no hubieran cargado), le encaja el arma en
   las manos de esa postura y la fotografía en tres cuartos con la luz
   de la vista 3D, y guarda el PNG resultante como sprite, uno por
   combinación de rol, arma, skin y nación. Ese sprite
   es el que la vista clásica dibuja casilla a casilla: las dos vistas
   muestran ya al mismo soldado. (La tira de roles y la ficha del
   soldado ya no usan esta foto: muestran los retratos de busto de
   assets/ui/retrato_*.png.) Si WebGL no está disponible o el
   renderizado falla,
   todo cae en silencio a los sprites SVG de Argon, como hasta ahora, y
   la partida no cambia. El encuadre (cámara a (2.2, 1.35, 1.7) mirando
   a (0.1, 0.52, 0), FOV 38°) deja los pies al 77 % de la altura del
   fotograma: REAL_SPRITE_FEET es esa fracción y el dibujo la usa para
   apoyar los pies del sprite sobre su casilla. */





/* Fotograma de apunte por familia de arma: el instante asentado de cada
   clip de disparo del IPA, medido sobre el propio esqueleto (la mano de
   apoyo ya ha llegado al guardamanos, la cabeza sigue alta y el
   retroceso aún no ha hundido la postura). La pistola es la excepción:
   su clip levanta el brazo con el culatazo y el apunte asentado, con el
   brazo ya extendido hacia delante, llega al segundo. */

/* Deja el soldado en un fotograma concreto de un clip, muestreando
   ese instante las veces que haga falta hasta que la interpolación
   sobre curQ converge, igual que hace driveClipSoldier fotograma a
   fotograma en la vista 3D. */

/* La foto por defecto: el fotograma de apunte del clip de su arma.
   Devuelve false si el clip de esa familia no está en el paquete, y
   el llamador cae a la postura de reposo de siempre. Tres roles no
   salen apuntando en su foto: su pose es la de su gesto (ROLE_LOOK),
   y renderRealSprite la intenta antes que esta. */

/* Encaje del arma anclado a las palmas reales:
   - Bip001 R Hand y Bip001 L Hand son las articulaciones de las muñecas;
     la palma donde cierra el puño queda ~10,3 cm hacia −X en el espacio
     local de cada hueso de mano (medido directamente sobre la malla
     corregida). Anclar ahí la empuñadura evita que el arma cuelgue de
     la muñeca.
   - En armas largas en reposo o apunte/disparo, ambas manos sostienen el
     fusil (palma D → palma I) con transición suave (smoothstep) según la
     altura de la mano izquierda y la separación entre palmas; al andar,
     con pistola o en gestos/impactos, manda el antebrazo derecho con
     estabilización suave hacia +X.
   - Tanto la foto de sprites (fitSpriteGun) como el vivo (fitLiveGun3)
     usan este mismo cálculo convertido al espacio local de ud.gun.parent
     en el mismo fotograma, sin retrasos ni sobrescrituras. */













/* ================= PROPS DECORATIVOS POR MAPA (F5) =================
   Cada tema recibe su propio juego de props construidos en código (formas
   simples + textura procedural), colocados en el anillo exterior: fuera de
   la cuadrícula jugable de 12x12, así que no tapan casillas ni tocan una
   sola regla. Sirven para que cada mapa se lea como un lugar distinto y no
   como el mismo tablero con otro cielo. */




/* ================= EFECTOS 3D EN VIVO (FX3) ================= */









/* Enganche de diagnostico: permite a las herramientas de captura acercar la
   camara para revisar modelos (no afecta al juego). */
try{window.__csnCam={get cam(){return T3&&T3.cam;},get t3(){return T3;}};}catch(e){}






document.querySelectorAll('#viewSeg button').forEach(b=>b.onclick=()=>setViewMode(b.dataset.view));
window.__build3D=function(){
  if(VIEW_MODE!=='3d')return;
  if(!init3D()){setViewMode('2d');return;}
  document.getElementById('glWrap').style.display='block';
  document.getElementById('board').style.display='none';
  build3DWorld();
};
window.__render3D=function(){
  if(!T3||VIEW_MODE!=='3d'||!G)return;
  const wrap=document.getElementById('glWrap');
  const w=wrap.clientWidth,h=wrap.clientHeight;
  if(!w||!h)return;
  const t=FX.t;
  const dt=T3.lastFrame?Math.min(0.05,(t-T3.lastFrame)/1000):0.016;
  T3.lastFrame=t;
  if(w!==T3.lastW||h!==T3.lastH){T3.lastW=w;T3.lastH=h;T3.renderer.setSize(w,h,false);T3.camera.aspect=w/h;T3.camera.updateProjectionMatrix();}
  /* cámara táctica interactiva con amortiguación exponencial + sacudida */
  const c=T3.cam;
  const panSp=5.5*dt;
  if(_keysHeld['w']||_keysHeld['arrowup']){c.panZ=Math.max(-5.5,c.panZ-Math.cos(c.yaw)*panSp);c.panX=Math.max(-5.5,c.panX-Math.sin(c.yaw)*panSp);}
  if(_keysHeld['s']||_keysHeld['arrowdown']){c.panZ=Math.min(5.5,c.panZ+Math.cos(c.yaw)*panSp);c.panX=Math.min(5.5,c.panX+Math.sin(c.yaw)*panSp);}
  if(_keysHeld['a']||_keysHeld['arrowleft']){c.panX=Math.max(-5.5,c.panX-Math.cos(c.yaw)*panSp);c.panZ=Math.min(5.5,c.panZ+Math.sin(c.yaw)*panSp);}
  if(_keysHeld['d']||_keysHeld['arrowright']){c.panX=Math.min(5.5,c.panX+Math.cos(c.yaw)*panSp);c.panZ=Math.max(-5.5,c.panZ-Math.sin(c.yaw)*panSp);}
  /* La camara acompaña el disparo: se desliza hacia donde ocurre la accion
     (tambien en turnos de la IA) y vuelve a quedarse quieta despues. */
  if(G&&G._camFocus&&Date.now()<G._camFocus.until){
    const fx=Math.max(-5.5,Math.min(5.5,w2cx(G._camFocus.x)));
    const fz=Math.max(-5.5,Math.min(5.5,w2cx(G._camFocus.y)));
    const k=Math.min(1,dt*1.7);
    c.panX+=(fx-c.panX)*k;
    c.panZ+=(fz-c.panZ)*k;
  }
  const damp=REDUCED_MOTION?1:(1-Math.exp(-10*dt));
  c.curYaw+=(c.yaw-c.curYaw)*damp;
  c.curDist+=(c.dist-c.curDist)*damp;
  c.curPanX+=(c.panX-c.curPanX)*damp;
  c.curPanZ+=(c.panZ-c.curPanZ)*damp;
  const sway=REDUCED_MOTION?0:Math.sin(t/4600)*0.025;
  const zoomZ=Math.max(0,Math.min(1,(c.curDist-6)/5)),pitch=(40+20*zoomZ)*Math.PI/180,horiz=Math.cos(pitch)*c.curDist,camY=Math.sin(pitch)*c.curDist; /* cámara del original: pitch 40–60° y FOV 30–45° acoplados al zoom (0,5 → 50°, 8,5, 37,5°) */
  if(Math.abs(T3.camera.fov-(30+15*zoomZ))>0.01){T3.camera.fov=30+15*zoomZ;T3.camera.updateProjectionMatrix();}
  let shx=0,shy=0;
  if(FX.shake>0.4&&!REDUCED_MOTION){shx=(Math.random()-0.5)*FX.shake*0.03;shy=(Math.random()-0.5)*FX.shake*0.03;}
  T3.camera.position.set(c.curPanX+Math.sin(c.curYaw+sway)*horiz+shx,camY+shy,c.curPanZ+Math.cos(c.curYaw+sway)*horiz);
  T3.camera.lookAt(c.curPanX,0.2,c.curPanZ);
  /* baliza, polvo y torreta central */
  if(T3.beacon)T3.beacon.material.opacity=REDUCED_MOTION?0.16:(0.13+0.06*Math.sin(t/520));
  if(T3.extMats)T3.extMats.forEach(m=>{m.opacity=REDUCED_MOTION?0.2:(0.16+0.07*Math.sin(t/520));});
  if(T3.droneMesh&&G.drone){
    const d=G.drone,m=T3.droneMesh,rx=d.dx!=null?d.dx:d.x,ry=d.dy!=null?d.dy:d.y;
    m.position.x=w2cx(rx);m.position.z=w2cx(ry);
    m.rotation.y=-advanceUnitYaw(d,t);
    if(d.alive){
      m.position.y=0.42+tileWorldY(rx,ry)+(REDUCED_MOTION?0:Math.sin(t/480)*0.03);m.rotation.z=0;
      if(!REDUCED_MOTION)m.userData.rotors.forEach((r,i)=>{r.rotation.y=t/55+i*1.3;});
      if(m.userData.light)m.userData.light.material.opacity=0.5+0.5*Math.abs(Math.sin(t/330));
    } else {m.position.y=0.12;m.rotation.z=0.55;}
  }
  if(T3.domRings)T3.domRings.forEach(dr=>{const dc=domControl(dr.zone);dr.ring.material.color.set(dc==='A'?0x39c2d7:dc==='B'?0xff7a45:0xf4f1e6);});
  if(T3.dust&&!REDUCED_MOTION){T3.dust.rotation.y=t/60000;T3.dust.position.y=Math.sin(t/1400)*0.08;}
  if(T3.cannon){
    let ang=G.map.turret.owner==='B'?Math.PI:0;
    const foes=G.units.filter(e=>e.alive&&e.team!==G.map.turret.owner);
    if(G.map.turret.owner&&foes.length){foes.sort((a,b)=>cheb(TURRET_POS,a)-cheb(TURRET_POS,b));ang=Math.atan2(foes[0].y-TURRET_POS.y,foes[0].x-TURRET_POS.x);}
    else if(!G.map.turret.owner&&!REDUCED_MOTION)ang=Math.sin(t/1500)*1.1;
    if(T3._cannonYaw==null||REDUCED_MOTION)T3._cannonYaw=ang;
    else T3._cannonYaw+=shortestArc(ang-T3._cannonYaw)*0.16;
    T3.cannon.rotation.y=-T3._cannonYaw;
  }
  if(T3.obMeshes)T3.obMeshes.forEach(r=>{r.mesh.visible=G.map.obstacles.indexOf(r.o)>=0;});
  if(T3.barrelMeshes)T3.barrelMeshes.forEach(r=>{r.mesh.visible=!!r.b.alive;});
  if(T3.medkitMeshes)T3.medkitMeshes.forEach(r=>{r.mesh.visible=!r.m.used;});
  const dynSig=(G.lootBoxes||[]).map(b=>b.x+','+b.y+','+b.kind).join('|')+'#'+G.deployed.map(d=>d.x+','+d.y+','+d.team+','+d.alive).join('|')+'#'+(G.map.turret.owner||'-')+'#'+(G.smoke||[]).map(s=>s.x+','+s.y+','+s.left).join('|')+'#'+(G.mines||[]).map(m=>m.x+','+m.y+','+m.team).join('|')+'#'+G.units.filter(u=>u.stunned).map(u=>u.id).join(',');
  if(dynSig!==T3.dynSig){T3.dynSig=dynSig;rebuildDyn3();}
  if(T3.dynGroup)T3.dynGroup.children.forEach(ch=>{if(ch.userData.loot&&!REDUCED_MOTION){ch.position.y=0.05+Math.sin(t/480+ch.position.x*2.1)*0.05;ch.rotation.y=t/1400;}});
  const sel=G.selected;
  const hlSig=[sel?sel.id:'-',sel?sel.energy:0,G.actionMode,G.turn,G.round,G.aiBusy?1:0,G.units.map(u=>u.x+','+u.y+','+(u.alive?1:0)+','+(u.invisible?1:0)).join(';'),(G.smoke||[]).length,G.drone?(G.drone.x+','+G.drone.y+','+G.drone.hp):''].join('#');
  if(hlSig!==T3.hlSig){T3.hlSig=hlSig;rebuildHighlights3();}
  if(T3.hoverRing){
    if(hoverTile){T3.hoverRing.visible=true;T3.hoverRing.position.x=w2cx(hoverTile.x);T3.hoverRing.position.z=w2cx(hoverTile.y);}
    else T3.hoverRing.visible=false;
  }
  updateHover3D(w,h);
  tickFx3D(w,h);
  updateUnitHuds3D(w,h);
  G.units.forEach(un=>{
    const mesh=T3.units.get(un.id);if(!mesh)return;
    const rx=un.dx!=null?un.dx:un.x, ry=un.dy!=null?un.dy:un.y;
    mesh.position.x=w2cx(rx);mesh.position.z=w2cx(ry);
    if(mesh.userData.hpArc){const f=Math.max(0,Math.min(1,un.hp/un.maxHp));mesh.userData.hpArc.geometry.setDrawRange(0,Math.floor(64*6*f));mesh.userData.hpArc.visible=un.alive;}
    const ud=mesh.userData;
    const moving=Math.abs(un.x-rx)>0.03||Math.abs(un.y-ry)>0.03||!!un._drawPath;
    mesh.position.y=0.05+tileWorldY(rx,ry)+(moving&&!REDUCED_MOTION?Math.abs(Math.sin((ud._gaitPhase||0)*Math.PI*2+un.id))*0.045:0);
    const yaw=advanceUnitYaw(un,t);
    mesh.rotation.y=-yaw;
    const turnLean=(un._turning&&!REDUCED_MOTION)?Math.sin((un._turnProg||0)*Math.PI)*0.07*(un._turnDelta>=0?1:-1):0;
    mesh.rotation.z=turnLean;
    if(un._turning&&!REDUCED_MOTION)mesh.position.y+=Math.sin((un._turnProg||0)*Math.PI)*0.025;
    if(ud.baseChev)ud.baseChev.visible=!!un.alive;
    if(ud.real){if(CLIPLIB.ready)driveClipSoldier(un,mesh,t,moving);else driveRealSoldier(un,mesh,t,moving||!!un._turning);fitLiveGun3(un,mesh);}
    else if(un.alive){
      mesh.rotation.z=turnLean;
      ud.body.position.y=REDUCED_MOTION?0:Math.sin(t/430+un.id*1.93)*0.02;
      ud.body.rotation.z=0;
      mesh.traverse(o=>{if(o.material&&o.material.transparent)o.opacity=un.invisible?0.45:1;});
      const ratio=un.maxHp?un.hp/un.maxHp:1;
      const col=ratio>0.5?'#69d66f':ratio>0.25?'#f2b234':'#ff6b5e';
      ud.segs.forEach((s,i)=>{s.visible=i<un.energy;s.material.color.set(col);});
      ud.selRing.visible=(G.selected===un);
      if(ud.selRing.visible&&!REDUCED_MOTION)ud.selRing.rotation.z=t/900;
    } else {
      ud.body.rotation.z=1.35;ud.body.position.y=-0.32;
      ud.segs.forEach(s=>{s.visible=false;});
      ud.selRing.visible=false;
    }
  });
  /* En WebGL por software (SwiftShader), limitar a ~28 fps evita saturar CPU */
  if(!T3.isSw||t-T3.lastRender>=34||T3.fxItems.length>0||FX.shake>0.4){
    T3.lastRender=t;
    T3.renderer.render(T3.scene,T3.camera);
  }
  try{const _s=skState(G.map.theme);window.__csn3d={theme:G.map.theme,geo:!!(_s&&_s.ready),units:T3.units?T3.units.size:0,tris:T3.renderer.info.render.triangles,calls:T3.renderer.info.render.calls,sw:T3.isSw,frame:((window.__csn3d&&window.__csn3d.frame)||0)+1,ev:CLIP_EVENT_LOG.length,evLast:CLIP_EVENT_LOG[CLIP_EVENT_LOG.length-1]||null};}catch(e){}
};
/* ================= ATAJOS DE TECLADO EN PARTIDA ================= */
const _keysHeld={};
window.addEventListener('blur',()=>{Object.keys(_keysHeld).forEach(k=>{_keysHeld[k]=false;});});
document.addEventListener('visibilitychange',()=>{if(document.hidden)Object.keys(_keysHeld).forEach(k=>{_keysHeld[k]=false;});});
window.addEventListener('keyup',e=>{_keysHeld[e.key.toLowerCase()]=false;});
window.addEventListener('keydown',e=>{
  if(document.body.dataset.state!=='playing'||!G||G.over||G.aiBusy)return;
  const tag=(e.target&&e.target.tagName)||'';
  if(tag==='INPUT'||tag==='TEXTAREA'||tag==='SELECT')return;
  const k=e.key.toLowerCase();
  _keysHeld[k]=true;
  if(['arrowup','arrowdown','arrowleft','arrowright'].includes(k))return;
  if(k==='tab'){
    e.preventDefault();
    const mine=G.units.filter(u=>u.alive&&u.team===G.turn);
    if(mine.length){const idx=mine.indexOf(G.selected);selectUnit(mine[(idx+1)%mine.length]);}
    return;
  }
  if(k==='escape'){if(G.actionMode!=='move'){G.actionMode='move';updateUI();draw();}return;}
  if(k==='z'){e.preventDefault();undoLastMove();return;}
  const actMap={'1':'shoot','2':'pistol','3':'grenade','4':'overwatch','5':'special'};
  if(actMap[k]){const btn=document.querySelector('#actionBar [data-act="'+actMap[k]+'"]');if(btn&&!btn.disabled){btn.click();btn.blur();}return;}
  if(T3&&T3.cam&&VIEW_MODE==='3d'){
    if(k==='q')T3.cam.yaw-=0.38;
    else if(k==='e')T3.cam.yaw+=0.38;
    else if(k==='c')resetCam3D();
    else if(k==='+'||k==='=')T3.cam.dist=Math.max(6,T3.cam.dist-1.8);
    else if(k==='-'||k==='_')T3.cam.dist=Math.min(11,T3.cam.dist+1.8);
  }
});

/* ================= ARSENAL UI ================= */
const CATS=['Todas','Fusiles de asalto','Subfusiles','Ametralladoras','Francotirador','Escopetas','Lanzacohetes','Lanzagranadas','Pistolas'];
let arsFilter='Todas';
function buildArsenal(){
  const f=$('#arsFilters');f.innerHTML='';
  CATS.forEach(c=>{const b=document.createElement('button');b.textContent=c;b.className=c===arsFilter?'on':'';b.onclick=()=>{arsFilter=c;buildArsenal();};f.appendChild(b);});
  const g=$('#arsenalGrid');g.innerHTML='';
  Object.entries(WEAPONS).filter(([n,w])=>arsFilter==='Todas'||w.cat===arsFilter).forEach(([name,w])=>{
    const roles=ROLE_NAMES.filter(r=>ROLES[r].weapons.includes(name)).join(', ')||(w.cat==='Pistolas'?'Todos (secundaria)':'—');
    const d=document.createElement('div');d.className='weapon';
    const cover=weaponCoverURL(name);
    d.innerHTML='<div class="wcoverWrap">'+(cover?('<img class="wcover" src="'+cover+'" alt="" loading="lazy">'):'')+'</div><span class="tag">'+w.cat+'</span><h3>'+name+'</h3><p class="real">'+w.real+'</p><div class="wstats"><div><b>'+w.dmg+'</b><span>Daño</span></div><div><b>'+w.rng+'</b><span>Casillas</span></div><div><b>'+w.cost+' ⚡</b><span>Coste</span></div><div><b style="font-size:12px;padding-top:4px">'+roles.split(',')[0]+'</b><span>Rol</span></div></div><p class="note">'+w.note+(w.once?' <b>Un solo uso por partida.</b>':'')+(w.aoe?' Daño en área.':'')+'</p>';
    g.appendChild(d);
    if(!cover){
      const img=d.querySelector('.wcoverWrap');
      const tryThumb=()=>{const u=renderWeaponThumb(name)||(makeRealGun3(name),renderWeaponThumb(name));if(u&&img){img.innerHTML='<img class="wcover" src="'+u+'" alt="">';}else{setTimeout(tryThumb,700);}};
      setTimeout(tryThumb,500);
    }
  });
  const rt=$('#rolesTable');rt.innerHTML=ROLE_NAMES.map(r=>{const bd=BODIES[ROLES[r].body];return '<div style="display:flex;gap:10px;padding:9px 0;border-bottom:1px dashed var(--line);flex-wrap:wrap;align-items:center"><span class="role-dot" style="background:'+ROLES[r].color+';margin-top:5px"></span>'+(rolePortraitURL(r)?'<img class="role-thumb" src="'+rolePortraitURL(r)+'" alt="Retrato del '+r+'"/>':'')+'<b style="min-width:120px">'+r+'</b><span class="mono" style="font-size:13.5px">'+bd.name+' · '+roleLook(r).silueta+' · '+bd.hp+' PV · '+bd.energy+' ⚡ · mover '+bd.moveCost+' ⚡/casilla</span><span style="flex:1;min-width:220px" class="sub">'+ROLES[r].desc+' Armas: '+ROLES[r].weapons.join(', ')+'.</span></div>';}).join('');
}

/* ================= ESCENARIO 3D EN VIVO (PRIMERA PANTALLA) =================
   Hasta ahora todo lo nuevo vivía dentro de la partida: nación, menú,
   configuración y despliegue antes de ver un solo polígono, y si la
   librería 3D fallaba al cargar desde su CDN, la partida caía en
   silencio a la vista clásica y la página se veía exactamente igual
   que siempre. Dos arreglos: la librería Three.js viaja ya dentro del
   propio artefacto ([Three.js viaja como archivo: assets/three.min.js] sin depender de ningún CDN),
   y este escenario renderiza la vista 3D en la primera pantalla, con
   los mismos soldados y el mismo escenario en volumen de la partida,
   más dos botones que entran directos a jugar en 3D. */
let DEMO=null;
function demoStatus(msg){const el=document.getElementById('demoStatus');if(el)el.textContent=msg;}
function demoUnit(id,team,role,weapon){
  return {id:id,team:team,role:role,weapon:weapon,skin:'nacion',nation:myNation||NATIONS[0],x:0,y:0,dx:0,dy:0,maxEnergy:8,energy:8,maxHp:250,hp:250,alive:true,invisible:false,body:ROLES[role]?ROLES[role].body:'medio'};
}
function buildDemo(){
  if(DEMO)return true;
  const wrap=document.getElementById('demoWrap');if(!wrap)return false;
  if(typeof THREE==='undefined'){demoStatus('La vista 3D no ha podido cargar en este dispositivo: dentro de la partida seguirás viendo el tablero clásico, con las mismas reglas.');return false;}
  let renderer;
  try{renderer=new THREE.WebGLRenderer({antialias:true});}
  catch(e){demoStatus('Tu dispositivo no ha podido abrir WebGL, así que el 3D no puede mostrarse aquí: dentro de la partida seguirás viendo el tablero clásico, con las mismas reglas.');return false;}
  const isSw=isSoftwareGL3(renderer);
  renderer.setPixelRatio(isSw?1:Math.min(isMobileGL3()?1.5:(window.devicePixelRatio||1),2));
  renderer.outputColorSpace=THREE.SRGBColorSpace;
  renderer.toneMapping=THREE.ACESFilmicToneMapping;
  renderer.toneMappingExposure=1.08;
  renderer.shadowMap.enabled=!isSw;
  if(!isSw)renderer.shadowMap.type=THREE.PCFSoftShadowMap;
  wrap.appendChild(renderer.domElement);
  const scene=new THREE.Scene();
  const sky=skyTheme3('almacen');
  scene.background=new THREE.Color(sky.bg);
  scene.fog=new THREE.Fog(sky.fog,22,42);
  const camera=new THREE.PerspectiveCamera(37.5,2,0.1,120);
  scene.add(new THREE.HemisphereLight(0xd8ecff,0x3c462e,1.15));
  const sun=new THREE.DirectionalLight(0xffe8b8,1.8);
  sun.position.set(-6,12,5);
  if(!isSw){sun.castShadow=true;sun.shadow.mapSize.set(1024,1024);sun.shadow.bias=-0.0005;sun.shadow.normalBias=0.02;}
  scene.add(sun);
  const fill=new THREE.DirectionalLight(0x8ec5ff,0.55);fill.position.set(7,5,-6);scene.add(fill);
  const stage=new THREE.Group();scene.add(stage);
  const apron=new THREE.Mesh(new THREE.PlaneGeometry(26,26),texMat3('apron',null,0.95));
  apron.rotation.x=-Math.PI/2;apron.position.y=-0.12;apron.receiveShadow=true;stage.add(apron);
  const curb=new THREE.Mesh(new THREE.BoxGeometry(7.46,0.14,7.46),mat3('#4f534c',0.9));
  curb.position.y=-0.06;curb.receiveShadow=true;stage.add(curb);
  [[-3.92,-3.92],[3.92,-3.92],[-3.92,3.92],[3.92,3.92]].forEach(cp=>{
    const bollard=new THREE.Mesh(new THREE.CylinderGeometry(0.13,0.15,0.4,10),mat3('#3a3e42',0.7));
    bollard.position.set(cp[0],0.1,cp[1]);bollard.castShadow=true;stage.add(bollard);
    const cap=new THREE.Mesh(new THREE.CylinderGeometry(0.14,0.14,0.055,10),mat3('#f2b234',0.5));
    cap.position.set(cp[0],0.32,cp[1]);stage.add(cap);
  });
  for(let y=0;y<7;y++)for(let x=0;x<7;x++){
    const h=hash2(x,y);
    const tile=box3(0.97,0.09,0.97,['#99968e','#918e85','#a09d94','#8b887f'][Math.floor(h*4)],x-3,0,y-3,0.95);
    tile.castShadow=false;stage.add(tile);
  }
  const beacon=new THREE.Mesh(new THREE.PlaneGeometry(1.94,1.94),new THREE.MeshBasicMaterial({color:0xf2b234,transparent:true,opacity:0.16,depthWrite:false}));
  beacon.rotation.x=-Math.PI/2;beacon.position.set(0,0.06,0);stage.add(beacon);
  [[0,-1.0,2.04,0.06],[0,1.0,2.04,0.06],[-1.0,0,0.06,2.04],[1.0,0,0.06,2.04]].forEach(e=>{
    const rim=new THREE.Mesh(new THREE.BoxGeometry(e[2],0.03,e[3]),new THREE.MeshBasicMaterial({color:0xf2b234}));
    rim.position.set(e[0],0.04,e[1]);stage.add(rim);
  });
  const wallMat=texMat3('wall',null,0.85),crateMat=texMat3('crate',null,0.9),barrelMat=texMat3('barrel',null,0.55);
  const wallGeo=new THREE.BoxGeometry(0.86,0.72,0.86),shelfGeo=new THREE.BoxGeometry(0.86,0.88,0.86),crateGeo=new THREE.BoxGeometry(0.76,0.5,0.76);
  [[-2,-2,'wall'],[2,2,'wall'],[-2,2,'crate'],[2,-2,'crate'],[0,-3,'shelf','#d9b13a','#a9862a'],[0,3,'shelf','#3f8b93','#2e6a71']].forEach(p=>{
    const grp=new THREE.Group();grp.position.set(p[0],0,p[1]);
    const sh=makeContactShadow3(0.5,0.048);if(sh)grp.add(sh);
    if(p[2]==='wall'){
      const b=new THREE.Mesh(wallGeo,wallMat);b.position.y=0.41;b.castShadow=true;b.receiveShadow=true;grp.add(b);
      grp.add(box3(0.92,0.09,0.92,'#585e64',0,0.08,0,0.85));
      grp.add(box3(0.92,0.06,0.92,'#b4bac0',0,0.8,0,0.75));
    } else if(p[2]==='shelf'){
      const b=new THREE.Mesh(shelfGeo,texMat3('shelf',p[3],0.8));b.position.y=0.49;b.castShadow=true;b.receiveShadow=true;grp.add(b);
      grp.add(box3(0.9,0.05,0.9,p[4],0,0.95,0,0.8));
    } else {
      const b=new THREE.Mesh(crateGeo,crateMat);b.position.y=0.3;b.castShadow=true;b.receiveShadow=true;grp.add(b);
      grp.add(box3(0.8,0.05,0.8,'#b88b50',0,0.57,0,0.88));
    }
    stage.add(grp);
  });
  const mkBarrel=(bx,bz)=>{
    const grp=new THREE.Group();grp.position.set(bx,0,bz);
    const sh=makeContactShadow3(0.38,0.048);if(sh)grp.add(sh);
    const cyl=new THREE.Mesh(new THREE.CylinderGeometry(0.28,0.28,0.68,18),barrelMat);
    cyl.position.y=0.39;cyl.castShadow=true;cyl.receiveShadow=true;grp.add(cyl);
    const ring1=new THREE.Mesh(new THREE.TorusGeometry(0.285,0.016,8,24),mat3('#7c1d18',0.5));
    ring1.rotation.x=Math.PI/2;ring1.position.y=0.25;grp.add(ring1);
    const ring2=ring1.clone();ring2.position.y=0.55;grp.add(ring2);
    const lid=new THREE.Mesh(new THREE.CylinderGeometry(0.26,0.26,0.02,16),mat3('#e87266',0.45));
    lid.position.y=0.74;grp.add(lid);
    stage.add(grp);
  };
  mkBarrel(-3,0);mkBarrel(3,0);
  const defs=[[901,'A','Comando','M4A1',-1.5,-1.2],[902,'A','Médico','M4A1',-1.5,1.1],[903,'B','Artillero','M249 SAW',1.5,-1.1],[904,'B','Espía','MP7',1.5,1.2]];
  const units=[];
  const meshes=defs.map(d=>{
    const un=demoUnit(d[0],d[1],d[2],d[3]);
    units.push(un);
    const mesh=REAL.ready?makeRealSoldier3(un):makeSoldier3(un);
    mesh.position.set(d[4],0.05,d[5]);
    mesh.rotation.y=d[1]==='A'?-Math.PI/2:Math.PI/2;
    stage.add(mesh);return mesh;
  });
  DEMO={renderer:renderer,scene:scene,camera:camera,stage:stage,meshes:meshes,units:units,beacon:beacon,lastW:0,lastH:0};
  demoStatus(REAL.ready
    ? 'Vista 3D activa: el soldado que gira es el del original de 2012 (su malla, su textura y su esqueleto), sobre el escenario en volumen. Pulsa «Jugar ahora en 3D» y lo mueves tú.'
    : 'Vista 3D activa: escenario en volumen y soldados sobre la cuadrícula, renderizados ahora mismo. Pulsa «Jugar ahora en 3D» y juegas en este mismo 3D.');
  return true;
}
function rebuildDemo(){
  if(!DEMO)return;
  const wrap=document.getElementById('demoWrap');
  if(wrap&&DEMO.renderer&&DEMO.renderer.domElement&&DEMO.renderer.domElement.parentNode===wrap)wrap.removeChild(DEMO.renderer.domElement);
  if(DEMO.renderer)DEMO.renderer.dispose();
  DEMO=null;buildDemo();
}
window.__renderDemo=function(){
  if(!DEMO)return;
  const wrap=document.getElementById('demoWrap');
  const panel=document.getElementById('demoPanel');
  if(!wrap||!panel||!panel.offsetParent)return;
  const w=wrap.clientWidth,h=wrap.clientHeight;
  if(!w||!h)return;
  if(w!==DEMO.lastW||h!==DEMO.lastH){DEMO.lastW=w;DEMO.lastH=h;DEMO.renderer.setSize(w,h,false);DEMO.camera.aspect=w/h;DEMO.camera.updateProjectionMatrix();}
  const t=FX.t;
  DEMO.stage.rotation.y=REDUCED_MOTION?0.6:t/9000;
  if(DEMO.beacon)DEMO.beacon.material.opacity=REDUCED_MOTION?0.16:(0.13+0.06*Math.sin(t/520));
  DEMO.meshes.forEach((m,i)=>{m.position.y=0.05+(REDUCED_MOTION?0:Math.abs(Math.sin(t/700+i*1.7))*0.03);});
  /* Los soldados del escaparate también se animan con sus clips y
     llevan el arma anclada a la mano, como en la partida: antes el
     escenario no movía ni un hueso, así que enseñaban la pose de
     bind (brazos colgando a los lados) con el arma clavada en su
     punto fijo de construcción, flotando delante del pecho — la
     primera arma flotante que se veía al abrir la página. Los
     motores de pose leen el estado global de partida; fuera de
     partida se les pasa una vacía y se restaura, como en la foto
     de los sprites. */
  {
    const hadG=G;
    if(!G)G={selected:null,over:false,winner:null,units:[],turn:'A',round:1};
    try{
      DEMO.meshes.forEach((m,i)=>{
        const un=DEMO.units&&DEMO.units[i];if(!un)return;
        const ud=m.userData;
        if(ud&&ud.real){if(CLIPLIB.ready)driveClipSoldier(un,m,t,false);else driveRealSoldier(un,m,t,false);fitLiveGun3(un,m);}
      });
    }catch(e){}
    G=hadG;
  }
  DEMO.camera.position.set(0,7.6,8.6);
  DEMO.camera.lookAt(0,0,0.2);
  DEMO.renderer.render(DEMO.scene,DEMO.camera);
};
/* Partida rápida en 3D: salta la configuración entera y despliega con
   la escuadra por defecto, para que el 3D se vea a un toque de la
   primera pantalla. */
function quickStart(mapId){
  if(!myNation){toast('Primero elige una nación aquí abajo y confírmala: en cuanto entres, este mismo botón te despliega en 3D.');return;}
  setup.mode='baliza';setup.fmt=4;setup.opp='ia';setup.map=mapId;setup.skinA='nacion';setup.rivalNation=null;setup.difficulty='normal';
  const mk=role=>({role:role,weapon:ROLES[role].weapons[0]});
  const squad=DEFAULT_SQUADS[4].map(mk);
  setViewMode3('3d');
  document.querySelectorAll('#viewSeg button').forEach(b=>b.classList.toggle('on',b.dataset.view==='3d'));
  startGame(squad,DEFAULT_SQUADS[4].map(mk));
  if(VIEW_MODE!=='3d')toast('La vista 3D no ha arrancado en este dispositivo: juegas en la vista clásica, con la misma partida.');
}
document.getElementById('quickStartBtn').onclick=()=>quickStart('almacen');
document.getElementById('quickSkirmishBtn').onclick=()=>quickStart('skirmish');

/* Reparto del original (17 personajes del IPA) con clase, traje y si es jugable. */
const LS_CHARS='csn_chars_v1';
let CHAR_PREFS={};
function loadChars(){try{const r=JSON.parse(lsGet(LS_CHARS)||'{}');if(!r||typeof r!=='object'||Array.isArray(r))return {};const out={};for(const role of Object.keys(r)){const v=r[role];if(typeof v!=='string')continue;if(charsForRole(role).some(c=>c.name===v||c.key===v))out[role]=v;}return out;}catch(e){return {};}}
function saveChars(v){try{lsSet(LS_CHARS,JSON.stringify(v));}catch(e){}}
/* Personajes nuevos propios de CSN: nombre, clase (cuerpo del IPA) y rol. */

const CLASS_LABEL={'Soldier_Light':'Soldado ligero','Soldier_Heavy':'Soldado pesado','Agent_Light':'Agente ligero','Medic':'Médico','Engineer':'Ingeniero','Engineer_Light':'Ingeniero ligero','Agent_Heavy':'Agente pesado','Commander':'Comandante','Medic_therapist':'Médico (terapia)','Engineer_Heavy':'Ingeniero pesado','Engineer (RiotCop)':'Ingeniero antidisturbios','Commander_F':'Comandante (F)'};
const CLASS_ORDER=['Soldier_Light','Soldier_Heavy','Agent_Light','Medic','Engineer','Agent_Heavy','Commander'];
function CAST_BODIES(){
  const seen=[];OWN_CAST.concat(ORIG_CAST).forEach(c=>{if(!seen.includes(c.body))seen.push(c.body);});
  return seen.sort((a,b)=>{const ia=CLASS_ORDER.indexOf(a),ib=CLASS_ORDER.indexOf(b);return (ia<0?99:ia)-(ib<0?99:ib);});
}
const ROLE_BODY={'Francotirador':'Soldier_Light','Artillero':'Soldier_Heavy','Espía':'Agent_Light','Médico':'Medic','Ingeniero':'Engineer','Comando':'Agent_Heavy','Capitán':'Commander'};
function charsForRole(role){
  const orig=ORIG_CAST.filter(c=>c.play&&c.role===role).map(c=>Object.assign({},c,{texture:CAST_TEXTURE_FILE[c.name]||''}));
  const meshy=MESHY_CAST.filter(c=>c.play&&c.role===role);
  const own=OWN_CAST.filter(c=>c.role===role);
  return orig.concat(meshy).concat(own);
}
function characterForRole(role,slot){
  const opts=charsForRole(role);if(!opts.length)return null;
  const prefs=(typeof CHAR_PREFS!=='undefined'&&CHAR_PREFS)?CHAR_PREFS:{};
  const chosen=opts.find(c=>c.name===prefs[role]||c.key===prefs[role]);
  return chosen||opts[slot%opts.length];
}
function characterKey(ch){return ch?(ch.key||((ch.own?'own:':'original:')+ch.name)):'';}


/* ---- Habilidades por personaje del original (Fase 1) ----
   Fuente: las bios cortas de cada personaje en Characters.assetbundle
   (UnityRaw, legible), donde cada bio nombra sus dos habilidades. Las
   habilidades son de la CLASE (UnitClass.Abilities[]); cada personaje
   usa las de su clase y el jugador elegía cuáles llevaba a la partida
   (SelectedAbilities[]). Los nombres entre paréntesis son los nombres
   reales del personaje en el original (Sister Florence es Angela Merci,
   Riot Medic es Gus Marx, Riot Agent es Juan DaCova, Riot Engineer es
   Dee Hatlacker, Commander (M) es Rick Rickson y Commander (F) es Lida
   Eroica). Los dos capitanes no tienen habilidades concretas en el
   material legible: su bio dice solo «una amplia variedad de habilidades
   ofensivas y de apoyo» y el código confirma una selección aparte de
   habilidades de comandante. 'obj' enlaza con ABILITY_OBJECTS. */

/* Drones y objetos que usan las habilidades. Todas estas mallas y texturas
   están en los assetbundles del IPA (BasicAbilities, Abilities y Abilities02)
   y se han extraído a assets/props/ con la convención del pipeline original. */

/* Habilidades de caja del comandante (PlayerAbility, no de un personaje
   concreto): crean cajas en el mapa (salud, munición, analgésicos,
   espíritu de equipo). La caja es el único objeto con modelo y textura
   extraídos; se ve en el visor como objeto. */
const COMMANDER_CRATE_ABILITIES=[
 {icon:'PlayerAbility_06_Health_Crate_alpha',n:'Caja de salud',d:'Crea una caja de salud en el mapa.',obj:'crate'},
 {icon:'PlayerAbility_08_Improved_Ammo_alpha',n:'Caja de munición',d:'Crea una caja de munición de alta velocidad.',obj:'crate'},
 {icon:'PlayerAbility_10_Pain_Killers_alpha',n:'Caja de analgésicos',d:'Crea una caja de analgésicos.',obj:'crate'},
 {icon:'PlayerAbility_11_Team_Spirit_alpha',n:'Caja de espíritu de equipo',d:'Crea una caja de espíritu de equipo.',obj:'crate'}
];

/* ---- Catalogo de las 52 habilidades del original (F1/F3 + Fase 1) ---- */
const ABILITY_CATALOG=[
  {f:'CharAbility_00_walkshoot_alpha',n:'walkshoot'},
  {f:'CharAbility_01_Adrenaline_alpha',n:'Adrenaline'},
  {f:'CharAbility_03_AR_Specialization_alpha',n:'AR Specialization'},
  {f:'CharAbility_04_Armour_Piercing_alpha',n:'Armour Piercing'},
  {f:'CharAbility_05_Backlash_Aura_alpha',n:'Backlash Aura'},
  {f:'CharAbility_06_Backstab_alpha',n:'Backstab'},
  {f:'CharAbility_07_Caltrops_alpha',n:'Caltrops'},
  {f:'CharAbility_08_Charm_alpha',n:'Charm'},
  {f:'CharAbility_09_Concussion_Grenade_alpha',n:'Concussion Grenade'},
  {f:'CharAbility_10_Da_Boot_alpha',n:'Da Boot'},
  {f:'CharAbility_11_Dead_Eye_Aura_alpha',n:'Dead Eye Aura'},
  {f:'CharAbility_12_Deployable_Cover_alpha',n:'Deployable Cover'},
  {f:'CharAbility_13_Detection_Aura_alpha',n:'Detection Aura'},
  {f:'CharAbility_14_Frag_Grenade_alpha',n:'Frag Grenade'},
  {f:'CharAbility_15_Gas_Grenade_alpha',n:'Gas Grenade'},
  {f:'CharAbility_16_Gatling_Turret_alpha',n:'Gatling Turret'},
  {f:'CharAbility_17_Ghost_alpha',n:'Ghost'},
  {f:'CharAbility_18_Hack_alpha',n:'Hack'},
  {f:'CharAbility_19_Headshot_alpha',n:'Headshot'},
  {f:'CharAbility_20_Healing_Aura_alpha',n:'Healing Aura'},
  {f:'CharAbility_21_Healing_Grenade_alpha',n:'Healing Grenade'},
  {f:'CharAbility_22_Health_Buff_Aura_alpha',n:'Health Buff Aura'},
  {f:'CharAbility_23_HMG_Specialization_alpha',n:'HMG Specialization'},
  {f:'CharAbility_24_Juggernaut_alpha',n:'Juggernaut'},
  {f:'CharAbility_25_Juggernaut_Passive_alpha',n:'Juggernaut Passive'},
  {f:'CharAbility_26_Kinetic_Animal_alpha',n:'Kinetic Animal'},
  {f:'CharAbility_27_Landmines_alpha',n:'Landmines'},
  {f:'CharAbility_28_Last_Stand_alpha',n:'Last Stand'},
  {f:'CharAbility_29_Last_Stand_Aura_alpha',n:'Last Stand Aura'},
  {f:'CharAbility_30_Medkit_alpha',n:'Medkit'},
  {f:'CharAbility_31_Melee_Specialization_alpha',n:'Melee Specialization'},
  {f:'CharAbility_32_Metabolism_alpha',n:'Metabolism'},
  {f:'CharAbility_33_Nail_Mines_alpha',n:'Nail Mines'},
  {f:'CharAbility_34_Pistol_Specialization_alpha',n:'Pistol Specialization'},
  {f:'CharAbility_35_Remote_Charge_alpha',n:'Remote Charge'},
  {f:'CharAbility_36_Revive_alpha',n:'Revive'},
  {f:'CharAbility_37_Rocket_Turret_alpha',n:'Rocket Turret'},
  {f:'CharAbility_38_Rush_Aura_alpha',n:'Rush Aura'},
  {f:'CharAbility_39_Shotgun_Specialization_alpha',n:'Shotgun Specialization'},
  {f:'CharAbility_40_Slayer_alpha',n:'Slayer'},
  {f:'CharAbility_41_SMG_Specialization_alpha',n:'SMG Specialization'},
  {f:'CharAbility_42_Sniper_Rifle_Specialization_alpha',n:'Sniper Rifle Specialization'},
  {f:'CharAbility_43_Support_Fire_alpha',n:'Support Fire'},
  {f:'CharAbility_44_Swarm_Aura_alpha',n:'Swarm Aura'},
  {f:'CharAbility_45_Toolkit_alpha',n:'Toolkit'},
  {f:'CharAbility_46_UAV_alpha',n:'UAV'},
  {f:'CharAbility_47_Vampire_alpha',n:'Vampire'},
  {f:'CharAbility_48_bazooka_alpha',n:'bazooka'},
  {f:'CharAbility_49_crossbow_alpha',n:'crossbow'},
  {f:'CharAbility_50_Molotov_alpha',n:'Molotov'},
  {f:'CharAbility_51_RiotShield_alpha',n:'RiotShield'},
  {f:'CharAbility_52_WaterCannon_alpha',n:'WaterCannon'}
];
const ABILITY_IMPL={
  'CharAbility_14_Frag_Grenade_alpha':'Granada M67',
  'CharAbility_15_Gas_Grenade_alpha':'Granada de gas',
  'CharAbility_09_Concussion_Grenade_alpha':'Aturdidora M84',
  'CharAbility_50_Molotov_alpha':'Molotov',
  'CharAbility_45_Toolkit_alpha':'Kit',
  'CharAbility_52_WaterCannon_alpha':'Cañón de agua',
  'CharAbility_13_Detection_Aura_alpha':'Barrido',
  'CharAbility_43_Support_Fire_alpha':'Artillería',
  'CharAbility_24_Juggernaut_alpha':'Escudo',
  'CharAbility_17_Ghost_alpha':'Invisibilidad',
  'CharAbility_30_Medkit_alpha':'Curación',
  'CharAbility_36_Revive_alpha':'Reanimar',
  'CharAbility_42_Sniper_Rifle_Specialization_alpha':'Tiro certero',
  'CharAbility_23_HMG_Specialization_alpha':'Supresión',
  'CharAbility_07_Caltrops_alpha':'Minas',
  'CharAbility_33_Nail_Mines_alpha':'Claymore',
  'CharAbility_12_Deployable_Cover_alpha':'Cobertura desplegable',
  'CharAbility_27_Landmines_alpha':'Minas',
  'CharAbility_37_Rocket_Turret_alpha':'Torreta de cohetes',
  'CharAbility_16_Gatling_Turret_alpha':'Torreta M2',
  'CharAbility_38_Rush_Aura_alpha':'Teletransporte',
  'CharAbility_44_Swarm_Aura_alpha':'Bomba de abejas'
};
/* Pestañas de la Armeria: armas (filtros y rejilla) o catalogo. */
function armTab(which){
  const esArmas=which!=='habilidades';
  document.querySelectorAll('#armTabSeg button').forEach(x=>x.classList.toggle('on',x.dataset.armtab===(esArmas?'armas':'habilidades')));
  const f=document.getElementById('arsFilters'),g=document.getElementById('arsenalGrid'),ap=document.getElementById('abilityPanel');
  if(f)f.style.display=esArmas?'':'none';
  if(g)g.style.display=esArmas?'':'none';
  if(ap)ap.style.display=esArmas?'none':'';
}
function renderAbilityCatalog(){
  const el=document.getElementById('abilityCatalog');if(!el)return;
  el.innerHTML=ABILITY_CATALOG.map(a=>{
    const imp=ABILITY_IMPL[a.f];
    return '<div class="ab-card'+(imp?' on':'')+'"><img src="assets/ui/ability/'+a.f+'.png" alt=""/><b>'+a.n+'</b><small>'+(imp?('en juego · '+imp):'pendiente')+'</small></div>';
  }).join('');
}

/* Barra inferior de acciones: el bloque se mantiene fuera del área de juego
   para poder reservar un viewport desplazable encima de ella. */
(function(){
  const ga=document.getElementById('gameArea');
  if(ga&&!document.getElementById('actionBar')){
    const bar=document.createElement('div');bar.id='actionBar';bar.className='actionBar';
    document.body.appendChild(bar);
  }
  syncPlayingViewport();
  window.addEventListener('resize',()=>requestAnimationFrame(syncPlayingViewport),{passive:true});
})();
/* Tooltip completo de las acciones del HUD: el detalle queda en una linea
   con puntos suspensivos y el texto entero aparece al pasar el raton. */
document.addEventListener('mouseover',e=>{
  const b=e.target&&e.target.closest?e.target.closest('.actions button'):null;
  if(b&&!b.title){b.title=b.textContent.replace(/\s+/g,' ').trim();}
},{passive:true});
/* ---- Cuartel (F9): tropas, skins, arsenal y desbloqueos ---- */
function renderBarracks(){
  const el=document.getElementById('barrContent'),nt=document.getElementById('barrNation');
  if(!el)return;
  if(nt)nt.innerHTML=myNation?('<b>'+myNation.name+'</b>'+(myNation.pers?' · '+myNation.pers.name:'')+' · 🪙 '+coinsGet()+' · skins: Estándar, Camuflaje, Clase y Nación'):('Sin nación elegida · 🪙 '+coinsGet());
  const roles=Object.keys(ROLES);
  const catOrder=[];const byCat={};
  Object.entries(WEAPONS).forEach(([name,w])=>{if(!byCat[w.cat]){byCat[w.cat]=[];catOrder.push(w.cat);}byCat[w.cat].push(name+' ('+w.dmg+'/'+w.rng+')');});
  CHAR_PREFS=loadChars();
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

function openBarracks(){renderBarracks();showScreen('scr-barracks');}
/* ---- Menu estilo original (F6): entradas directas y monedas ---- */
const COINS_KEY='radsoldiers_coins';
function coinsGet(){return Math.max(0,parseInt(lsGet(COINS_KEY)||'500',10)||0);}
function coinsSet(n){lsSet(COINS_KEY,String(Math.max(0,n)));const t=document.getElementById('coinsTag');if(t)t.textContent='🪙 '+coinsGet();}
/* ---- Tutorial en bocadillo (F6): explica los 4 botones del original ---- */
const TUT_TEXTS={
  undo:'Deshacer: vuelve atrás el último movimiento de tu soldado en este turno (botón ↶ del panel de acción).',
  settings:'Ajustes: el botón de sonido (🔊) silencia o activa los efectos; la cámara se ajusta con Q/E, +/− y C.',
  home:'Inicio: desde la partida, «Abandonar» te devuelve al menú sin borrar tu nación ni las monedas.',
  confirm:'Confirmar: «Terminar turno» cierra tu turno y deja actuar al rival. La vista 2D/3D se cambia sin tocar la partida.'
};
function tutShow(){const b=document.getElementById('tutBubble');if(b)b.style.display='block';}
function tutHide(){const b=document.getElementById('tutBubble');if(b)b.style.display='none';lsSet('radsoldiers_tut','1');}
(function wireTutorial(){
  const b=document.getElementById('tutBubble');if(!b)return;
  b.querySelectorAll('[data-tut]').forEach(btn=>btn.onclick=()=>{const k=btn.dataset.tut;const t=document.getElementById('tutText');if(t)t.textContent=TUT_TEXTS[k]||'';toast(TUT_TEXTS[k]||'');});
  const d=document.getElementById('tutDone');if(d)d.onclick=tutHide;
})();
(function wireOrigMenu(){
  const q=document.getElementById('mnuQuick');if(q)q.onclick=()=>quickStart('almacen');
  const o=document.getElementById('mnuOnline');if(o)o.onclick=()=>toast('Sin servidor de partidas: el online del original no está disponible. Juega contra la IA o a dos jugadores en local.');
  /* Challenges abre la seleccion de capitulos; desde ahi se elige mision. */
  const c=document.getElementById('mnuChallenges');if(c)c.onclick=()=>{
    const p=document.getElementById('campaignPanel');
    if(p){p.style.display='block';renderCampaignPanel();p.scrollIntoView({behavior:'smooth',block:'center'});}
    else{const b=document.querySelector('[data-start="campana"]');if(b)b.click();}
  };
  const e=document.getElementById('mnuExpansions');if(e)e.onclick=()=>toast('Expansiones: aún no hay contenido descargable. El arte propio y las skins llegan por fases.');
  const bk=document.getElementById('mnuBarracks');if(bk)bk.onclick=openBarracks;
  document.addEventListener('change',(e)=>{const t=e.target;if(t&&t.dataset&&t.dataset.charrole){const role=t.dataset.charrole;CHAR_PREFS=loadChars();CHAR_PREFS[role]=t.value;saveChars(CHAR_PREFS);const opts=charsForRole(role),cur=opts.find(o=>o.name===t.value)||opts[0],card=t.closest('.barrack-card'),img=card&&card.querySelector('.barrack-portrait');if(img)img.src=rolePortraitURL(role,cur)||'assets/ui/retrato_capitan.png';if(G)updateUI();else if(typeof buildSquads==='function')buildSquads();toast('Personaje de '+role+': '+t.value+'.');}});
  const ar=document.getElementById('mnuArmory');if(ar)ar.onclick=()=>{showScreen('scr-arsenal');armTab('armas');};
  document.querySelectorAll('#armTabSeg button').forEach(b=>b.onclick=()=>armTab(b.dataset.armtab));
  const bb=document.getElementById('barrBack');if(bb)bb.onclick=()=>showScreen('scr-play');
  coinsSet(coinsGet());
  renderAbilityCatalog();
  /* Reglas plegables: el muro de texto de "Como se juega" pasa a 23
     resumenes de una linea que se abren al tocar (F9). */
  try{
    document.querySelectorAll('.howto > div').forEach(d=>{
      if(d.dataset.plegado)return;d.dataset.plegado='1';
      const t=d.querySelector('b');const ps=Array.from(d.querySelectorAll('p'));
      const det=document.createElement('details');det.className='rule';
      const sum=document.createElement('summary');
      sum.innerHTML=t?t.innerHTML:'Regla';
      det.appendChild(sum);
      ps.forEach(p=>det.appendChild(p));
      d.innerHTML='';d.appendChild(det);
    });
  }catch(e){}
})();
/* Pantalla de carga: se cierra cuando el soldado real está listo (o a los 9 s). */
(function bootScreen(){
  const start=()=>{
    const el=document.getElementById('bootScreen'),fill=document.getElementById('bootFill'),msg=document.getElementById('bootMsg');
    if(!el)return;
    let p=6;const t0=Date.now();
    const it=setInterval(()=>{
      p=Math.min(96,p+2+Math.random()*3);
      if(typeof REAL!=='undefined'&&REAL.ready){p=Math.min(100,p+12);if(msg)msg.textContent='Listo: soldado, animaciones y mapas cargados.';}
      if(fill)fill.style.width=p+'%';
      if(p>=100||Date.now()-t0>9000){clearInterval(it);el.style.transition='opacity .45s';el.style.opacity='0';setTimeout(()=>{el.style.display='none';},480);}
    },130);
  };
  if(document.readyState==='loading')document.addEventListener('DOMContentLoaded',start);else start();
})();
/* Partida de prueba del humo M18: el 5 contra 5 es la única escuadra
   por defecto con Espía, así que esta entrada despliega ese formato
   en el Almacén con el Espía del jugador ya seleccionado y su botón
   de humo a un toque, para verificar la cortina dentro de la partida
   sin pasar por la configuración ni montar la escuadra a mano. */
function quickSmoke(){
  if(!myNation){toast('Primero elige una nación aquí abajo y confírmala: en cuanto entres, este mismo botón te despliega con tu Espía listo.');return;}
  setup.mode='baliza';setup.fmt=5;setup.opp='ia';setup.map='almacen';setup.skinA='nacion';setup.rivalNation=null;setup.difficulty='normal';
  const mk=role=>({role:role,weapon:ROLES[role].weapons[0]});
  setViewMode3('3d');
  document.querySelectorAll('#viewSeg button').forEach(b=>b.classList.toggle('on',b.dataset.view==='3d'));
  startGame(DEFAULT_SQUADS[5].map(mk),DEFAULT_SQUADS[5].map(mk));
  const spy=G?G.units.find(u=>u.team==='A'&&u.role==='Espía'&&u.alive):null;
  if(spy)selectUnit(spy);
  toast('Tu Espía va seleccionado y lleva 2 granadas M18: acércalo al centro, pulsa «Humo M18» y tapa la línea entre los dos bandos. A través de la cortina, el indicador dirá «Sin tiro · humo M18».');
  if(VIEW_MODE!=='3d')toast('La vista 3D no ha arrancado en este dispositivo: la prueba del humo se juega igual en la vista clásica.');
}
document.getElementById('quickSmokeBtn').onclick=()=>quickSmoke();
/* Partida de prueba de la M84: la escuadra de 4 por defecto ya abre
   con un Comando, así que esta entrada despliega ese formato en el
   Almacén con el Comando del jugador ya seleccionado y sus 2
   aturdidoras a un toque, para comprobar el fogonazo dentro de la
   partida sin pasar por la configuración. */
function quickFlash(){
  if(!myNation){toast('Primero elige una nación aquí abajo y confírmala: en cuanto entres, este mismo botón te despliega con tu Comando listo.');return;}
  setup.mode='baliza';setup.fmt=4;setup.opp='ia';setup.map='almacen';setup.skinA='nacion';setup.rivalNation=null;setup.difficulty='normal';
  const mk=role=>({role:role,weapon:ROLES[role].weapons[0]});
  setViewMode3('3d');
  document.querySelectorAll('#viewSeg button').forEach(b=>b.classList.toggle('on',b.dataset.view==='3d'));
  startGame(DEFAULT_SQUADS[4].map(mk),DEFAULT_SQUADS[4].map(mk));
  const cmd=G?G.units.find(u=>u.team==='A'&&u.role==='Comando'&&u.alive):null;
  if(cmd)selectUnit(cmd);
  toast('Tu Comando va seleccionado y lleva 2 aturdidoras M84: acércalo al enemigo, pulsa «Aturdidora M84» y deja caer el fogonazo sobre un grupo. Los aturdidos llevarán el 💫 encima, no devolverán el fuego y empezarán su turno con −6 ⚡ y −25 de puntería.');
  if(VIEW_MODE!=='3d')toast('La vista 3D no ha arrancado en este dispositivo: la prueba de la M84 se juega igual en la vista clásica.');
}
document.getElementById('quickFlashBtn').onclick=()=>quickFlash();

Object.defineProperty(window,"$",{configurable:true,get:()=>$});
Object.defineProperty(window,"G",{configurable:true,get:()=>G,set:v=>{G=v;}});
Object.defineProperty(window,"W",{configurable:true,get:()=>W,set:v=>{W=v;}});
Object.defineProperty(window,"H",{configurable:true,get:()=>H,set:v=>{H=v;}});
Object.defineProperty(window,"BEACON",{configurable:true,get:()=>BEACON,set:v=>{BEACON=v;}});
Object.defineProperty(window,"TURRET_POS",{configurable:true,get:()=>TURRET_POS,set:v=>{TURRET_POS=v;}});
Object.defineProperty(window,"NATIVE_GRID",{configurable:true,get:()=>NATIVE_GRID,set:v=>{NATIVE_GRID=v;}});
Object.defineProperty(window,"flowStep",{configurable:true,get:()=>flowStep,set:v=>{flowStep=v;}});
Object.defineProperty(window,"myNation",{configurable:true,get:()=>myNation,set:v=>{myNation=v;}});
Object.defineProperty(window,"pickedNation",{configurable:true,get:()=>pickedNation,set:v=>{pickedNation=v;}});
Object.defineProperty(window,"setup",{configurable:true,get:()=>setup,set:v=>{setup=v;}});
Object.defineProperty(window,"uid",{configurable:true,get:()=>uid,set:v=>{uid=v;}});
Object.defineProperty(window,"hoverTile",{configurable:true,get:()=>hoverTile,set:v=>{setHoverTile(v);}});
Object.defineProperty(window,"arsFilter",{configurable:true,get:()=>arsFilter,set:v=>{arsFilter=v;}});
Object.defineProperty(window,"DEMO",{configurable:true,get:()=>DEMO,set:v=>{DEMO=v;}});
Object.defineProperty(window,"CHAR_PREFS",{configurable:true,get:()=>CHAR_PREFS,set:v=>{CHAR_PREFS=v;}});

/* ================= INIT ================= */
buildNationGrid();buildArsenal();
loadSkirmishTop('skirmish03');loadSkirmishTop('skirmish04');
/* La lectura de la nación guardada y la entrada al juego van separadas:
   si la entrada fallara por cualquier motivo, no se debe volver a la
   pantalla de selección como si no hubiera nación elegida. */
(function(){
  CHAR_PREFS=loadChars();
  const params=new URLSearchParams(window.location.search||'');
  const auto=params.get('autostart');
  const saved=lsGet(LS_NATION);const found=saved?nationById(saved):null;
  if(auto){
    myNation=found||NATIONS[0];
    try{enterApp();}
    catch(e){try{renderNationChip();}catch(e2){} $('#mainTabs').style.display='flex'; showScreen('scr-play');}
    if(auto==='smoke')quickSmoke();
    else if(auto==='flash')quickFlash();
    else if(auto==='skirmish')quickStart('skirmish');
    else quickStart(MAP_DEFS[auto]?auto:'almacen');
    return;
  }
  if(found){myNation=found;
    try{enterApp();}
    catch(e){try{renderNationChip();}catch(e2){} $('#mainTabs').style.display='flex'; showScreen('scr-play');}
  }
  else{if(saved)lsRemove(LS_NATION); showScreen('scr-nation');}
})();
$('#guerraCountdown').textContent=fmtCountdown(msToNextSaturday());


Object.defineProperty(window,"$",{configurable:true,get:()=>$});
Object.defineProperty(window,"ABILITY_CATALOG",{configurable:true,get:()=>ABILITY_CATALOG});
Object.defineProperty(window,"ABILITY_IMPL",{configurable:true,get:()=>ABILITY_IMPL});
Object.defineProperty(window,"ABILITY_OBJECTS",{configurable:true,get:()=>ABILITY_OBJECTS});
Object.defineProperty(window,"AC",{configurable:true,get:()=>AC});
Object.defineProperty(window,"AMBIENT_FILE",{configurable:true,get:()=>AMBIENT_FILE});
Object.defineProperty(window,"ARGON_DEFS",{configurable:true,get:()=>ARGON_DEFS});
Object.defineProperty(window,"AUX_HINTS",{configurable:true,get:()=>AUX_HINTS});
Object.defineProperty(window,"AUX_LABELS",{configurable:true,get:()=>AUX_LABELS});
Object.defineProperty(window,"AU_AMBIENT",{configurable:true,get:()=>AU_AMBIENT});
Object.defineProperty(window,"AU_BASE",{configurable:true,get:()=>AU_BASE});
Object.defineProperty(window,"AU_MUSIC",{configurable:true,get:()=>AU_MUSIC});
Object.defineProperty(window,"AXIS_X3",{configurable:true,get:()=>AXIS_X3});
Object.defineProperty(window,"BEACON",{configurable:true,get:()=>BEACON,set:v=>{BEACON=v;}});
Object.defineProperty(window,"BODIES",{configurable:true,get:()=>BODIES});
Object.defineProperty(window,"CAMO_TEX",{configurable:true,get:()=>CAMO_TEX});
Object.defineProperty(window,"CAMPAIGN_MISSIONS",{configurable:true,get:()=>CAMPAIGN_MISSIONS});
Object.defineProperty(window,"CAST_BODIES",{configurable:true,get:()=>CAST_BODIES});
Object.defineProperty(window,"CAST_TEXTURE_FILE",{configurable:true,get:()=>CAST_TEXTURE_FILE});
Object.defineProperty(window,"CATS",{configurable:true,get:()=>CATS});
Object.defineProperty(window,"CHARACTERS",{configurable:true,get:()=>CHARACTERS});
Object.defineProperty(window,"CHARACTER_ABILITIES",{configurable:true,get:()=>CHARACTER_ABILITIES});
Object.defineProperty(window,"CHAR_ABILITY_ACTIONS",{configurable:true,get:()=>CHAR_ABILITY_ACTIONS});
Object.defineProperty(window,"CHAR_PREFS",{configurable:true,get:()=>CHAR_PREFS,set:v=>{CHAR_PREFS=v;}});
Object.defineProperty(window,"CHAR_VOICE",{configurable:true,get:()=>CHAR_VOICE});
Object.defineProperty(window,"CLASS_LABEL",{configurable:true,get:()=>CLASS_LABEL});
Object.defineProperty(window,"CLASS_ORDER",{configurable:true,get:()=>CLASS_ORDER});
Object.defineProperty(window,"CLIPLIB",{configurable:true,get:()=>CLIPLIB});
Object.defineProperty(window,"CLIP_BLEND_MS",{configurable:true,get:()=>CLIP_BLEND_MS});
Object.defineProperty(window,"CLIP_EVENT_LOG",{configurable:true,get:()=>CLIP_EVENT_LOG});
Object.defineProperty(window,"COINS_KEY",{configurable:true,get:()=>COINS_KEY});
Object.defineProperty(window,"COMMANDER_CRATE_ABILITIES",{configurable:true,get:()=>COMMANDER_CRATE_ABILITIES});
Object.defineProperty(window,"COVER_COST",{configurable:true,get:()=>COVER_COST});
Object.defineProperty(window,"DEBUG_GRID",{configurable:true,get:()=>DEBUG_GRID});
Object.defineProperty(window,"DEBUG_WEAPONS",{configurable:true,get:()=>DEBUG_WEAPONS});
Object.defineProperty(window,"DEFAULT_SQUADS",{configurable:true,get:()=>DEFAULT_SQUADS});
Object.defineProperty(window,"DEMO",{configurable:true,get:()=>DEMO,set:v=>{DEMO=v;}});
Object.defineProperty(window,"DMR_WEAPONS",{configurable:true,get:()=>DMR_WEAPONS});
Object.defineProperty(window,"DOM_TARGET",{configurable:true,get:()=>DOM_TARGET});
Object.defineProperty(window,"DOM_ZONES",{configurable:true,get:()=>DOM_ZONES});
Object.defineProperty(window,"DRAW_MOVE_MS_PER_TILE",{configurable:true,get:()=>DRAW_MOVE_MS_PER_TILE});
Object.defineProperty(window,"EMBLEM_TEX",{configurable:true,get:()=>EMBLEM_TEX});
Object.defineProperty(window,"ESCORT_EXT",{configurable:true,get:()=>ESCORT_EXT});
Object.defineProperty(window,"ESCORT_MAX_ROUNDS",{configurable:true,get:()=>ESCORT_MAX_ROUNDS});
Object.defineProperty(window,"ESCORT_START",{configurable:true,get:()=>ESCORT_START});
Object.defineProperty(window,"FLASH_COST",{configurable:true,get:()=>FLASH_COST});
Object.defineProperty(window,"FX",{configurable:true,get:()=>FX});
Object.defineProperty(window,"G",{configurable:true,get:()=>G,set:v=>{G=v;}});
Object.defineProperty(window,"GRID_CACHE",{configurable:true,get:()=>GRID_CACHE});
Object.defineProperty(window,"GUN_MESH_CACHE",{configurable:true,get:()=>GUN_MESH_CACHE});
Object.defineProperty(window,"HAS_THREE",{configurable:true,get:()=>HAS_THREE});
Object.defineProperty(window,"LEAF_SVG",{configurable:true,get:()=>LEAF_SVG});
Object.defineProperty(window,"LS_CAMPAIGN",{configurable:true,get:()=>LS_CAMPAIGN});
Object.defineProperty(window,"LS_CHARS",{configurable:true,get:()=>LS_CHARS});
Object.defineProperty(window,"LS_NATION",{configurable:true,get:()=>LS_NATION});
Object.defineProperty(window,"LS_SOUND",{configurable:true,get:()=>LS_SOUND});
Object.defineProperty(window,"MAP_DEFS",{configurable:true,get:()=>MAP_DEFS});
Object.defineProperty(window,"MAPS_ORIGINAL",{configurable:true,get:()=>MAPS_ORIGINAL});
Object.defineProperty(window,"MAP_DEFS",{configurable:true,get:()=>MAP_DEFS});
Object.defineProperty(window,"MAP_PIECES",{configurable:true,get:()=>MAP_PIECES});
Object.defineProperty(window,"MEM_STORE",{configurable:true,get:()=>MEM_STORE});
Object.defineProperty(window,"MESHY_CAST",{configurable:true,get:()=>MESHY_CAST});
Object.defineProperty(window,"MESHY_MODELS",{configurable:true,get:()=>MESHY_MODELS});
Object.defineProperty(window,"MINE_DMG",{configurable:true,get:()=>MINE_DMG});
Object.defineProperty(window,"MOLOTOV_COST",{configurable:true,get:()=>MOLOTOV_COST});
Object.defineProperty(window,"MUSIC_TRACKS",{configurable:true,get:()=>MUSIC_TRACKS});
Object.defineProperty(window,"NATIONS",{configurable:true,get:()=>NATIONS});
Object.defineProperty(window,"NATION_ART",{configurable:true,get:()=>NATION_ART});
Object.defineProperty(window,"NATIVE_GRID",{configurable:true,get:()=>NATIVE_GRID,set:v=>{NATIVE_GRID=v;}});
Object.defineProperty(window,"NATIVE_MAP_IDS",{configurable:true,get:()=>NATIVE_MAP_IDS});
Object.defineProperty(window,"ORB_COST",{configurable:true,get:()=>ORB_COST});
Object.defineProperty(window,"ORIG_CAST",{configurable:true,get:()=>ORIG_CAST});
Object.defineProperty(window,"OWN_CAST",{configurable:true,get:()=>OWN_CAST});
Object.defineProperty(window,"PISTOL",{configurable:true,get:()=>PISTOL});
Object.defineProperty(window,"PORTRAIT_CACHE",{configurable:true,get:()=>PORTRAIT_CACHE});
Object.defineProperty(window,"REAL",{configurable:true,get:()=>REAL});
Object.defineProperty(window,"REAL_SPRITES",{configurable:true,get:()=>REAL_SPRITES});
Object.defineProperty(window,"REAL_SPRITE_FEET",{configurable:true,get:()=>REAL_SPRITE_FEET});
Object.defineProperty(window,"REDUCED_MOTION",{configurable:true,get:()=>REDUCED_MOTION});
Object.defineProperty(window,"ROLES",{configurable:true,get:()=>ROLES});
Object.defineProperty(window,"ROLE_BODY",{configurable:true,get:()=>ROLE_BODY});
Object.defineProperty(window,"ROLE_LOOK",{configurable:true,get:()=>ROLE_LOOK});
Object.defineProperty(window,"ROLE_MODEL_FILES",{configurable:true,get:()=>ROLE_MODEL_FILES});
Object.defineProperty(window,"ROLE_NAMES",{configurable:true,get:()=>ROLE_NAMES});
Object.defineProperty(window,"ROLE_OUTFIT_FILES",{configurable:true,get:()=>ROLE_OUTFIT_FILES});
Object.defineProperty(window,"ROLE_PORTRAIT",{configurable:true,get:()=>ROLE_PORTRAIT});
Object.defineProperty(window,"ROLE_SCALES",{configurable:true,get:()=>ROLE_SCALES});
Object.defineProperty(window,"ROLE_SVG_ID",{configurable:true,get:()=>ROLE_SVG_ID});
Object.defineProperty(window,"SHIELD_COST",{configurable:true,get:()=>SHIELD_COST});
Object.defineProperty(window,"SKINS",{configurable:true,get:()=>SKINS});
Object.defineProperty(window,"SKIN_TONES",{configurable:true,get:()=>SKIN_TONES});
Object.defineProperty(window,"SKIRMISH_GEO",{configurable:true,get:()=>SKIRMISH_GEO});
Object.defineProperty(window,"SMOKE_TURNS",{configurable:true,get:()=>SMOKE_TURNS});
Object.defineProperty(window,"SPAWNS_A",{configurable:true,get:()=>SPAWNS_A});
Object.defineProperty(window,"SPAWNS_B",{configurable:true,get:()=>SPAWNS_B});
Object.defineProperty(window,"SPRITE_AIM_CT",{configurable:true,get:()=>SPRITE_AIM_CT});
Object.defineProperty(window,"SPRITE_CACHE",{configurable:true,get:()=>SPRITE_CACHE});
Object.defineProperty(window,"STEP_META",{configurable:true,get:()=>STEP_META});
Object.defineProperty(window,"T3",{configurable:true,get:()=>T3});
Object.defineProperty(window,"TEX3",{configurable:true,get:()=>TEX3});
Object.defineProperty(window,"TRANQ_COST",{configurable:true,get:()=>TRANQ_COST});
Object.defineProperty(window,"TURRET_POS",{configurable:true,get:()=>TURRET_POS,set:v=>{TURRET_POS=v;}});
Object.defineProperty(window,"TUT_TEXTS",{configurable:true,get:()=>TUT_TEXTS});
Object.defineProperty(window,"VIEW_MODE",{configurable:true,get:()=>VIEW_MODE});
Object.defineProperty(window,"VOICE_FILES",{configurable:true,get:()=>VOICE_FILES});
Object.defineProperty(window,"W",{configurable:true,get:()=>W,set:v=>{W=v;}});
Object.defineProperty(window,"H",{configurable:true,get:()=>H,set:v=>{H=v;}});
Object.defineProperty(window,"WEAPONS",{configurable:true,get:()=>WEAPONS});
Object.defineProperty(window,"WEAPONS_ORIGINAL",{configurable:true,get:()=>WEAPONS_ORIGINAL});
Object.defineProperty(window,"WEAPON_CALIBRATIONS",{configurable:true,get:()=>WEAPON_CALIBRATIONS});
Object.defineProperty(window,"WEAPON_COVER_BY_FILE",{configurable:true,get:()=>WEAPON_COVER_BY_FILE});
Object.defineProperty(window,"WEAPON_LEN",{configurable:true,get:()=>WEAPON_LEN});
Object.defineProperty(window,"WEAPON_MESH_FILE",{configurable:true,get:()=>WEAPON_MESH_FILE});
Object.defineProperty(window,"WEAPON_METADATA",{configurable:true,get:()=>WEAPON_METADATA});
Object.defineProperty(window,"WEAPON_SFX",{configurable:true,get:()=>WEAPON_SFX});
Object.defineProperty(window,"WEAPON_THUMB_CACHE",{configurable:true,get:()=>WEAPON_THUMB_CACHE});
Object.defineProperty(window,"_cq",{configurable:true,get:()=>_cq});
Object.defineProperty(window,"_gpDir",{configurable:true,get:()=>_gpDir});
Object.defineProperty(window,"_gpOrigin",{configurable:true,get:()=>_gpOrigin});
Object.defineProperty(window,"_gpPalmR",{configurable:true,get:()=>_gpPalmR});
Object.defineProperty(window,"_gpRPalm",{configurable:true,get:()=>_gpRPalm});
Object.defineProperty(window,"_gpUp",{configurable:true,get:()=>_gpUp});
Object.defineProperty(window,"_hitWhite",{configurable:true,get:()=>_hitWhite});
Object.defineProperty(window,"_keysHeld",{configurable:true,get:()=>_keysHeld});
Object.defineProperty(window,"_retargetDelta",{configurable:true,get:()=>_retargetDelta});
Object.defineProperty(window,"_rq",{configurable:true,get:()=>_rq});
Object.defineProperty(window,"_smooth01",{configurable:true,get:()=>_smooth01});
Object.defineProperty(window,"_toonGrad",{configurable:true,get:()=>_toonGrad});
Object.defineProperty(window,"_undoBtn",{configurable:true,get:()=>_undoBtn});
Object.defineProperty(window,"_wThumbR",{configurable:true,get:()=>_wThumbR});
Object.defineProperty(window,"advanceUnitYaw",{configurable:true,get:()=>advanceUnitYaw});
Object.defineProperty(window,"aiUnitAct",{configurable:true,get:()=>aiUnitAct});
Object.defineProperty(window,"aimR",{configurable:true,get:()=>aimR});
Object.defineProperty(window,"aliveCount",{configurable:true,get:()=>aliveCount});
Object.defineProperty(window,"angleToFacing",{configurable:true,get:()=>angleToFacing});
Object.defineProperty(window,"applyCharacterAbilities",{configurable:true,get:()=>applyCharacterAbilities});
Object.defineProperty(window,"applyNativeGrid",{configurable:true,get:()=>applyNativeGrid});
Object.defineProperty(window,"applyStun",{configurable:true,get:()=>applyStun});
Object.defineProperty(window,"armTab",{configurable:true,get:()=>armTab});
Object.defineProperty(window,"arsFilter",{configurable:true,get:()=>arsFilter,set:v=>{arsFilter=v;}});
Object.defineProperty(window,"attachRealGun",{configurable:true,get:()=>attachRealGun});
Object.defineProperty(window,"auAmbient",{configurable:true,get:()=>auAmbient});
Object.defineProperty(window,"auClick",{configurable:true,get:()=>auClick});
Object.defineProperty(window,"auMusicStart",{configurable:true,get:()=>auMusicStart});
Object.defineProperty(window,"auMusicStop",{configurable:true,get:()=>auMusicStop});
Object.defineProperty(window,"auPlay",{configurable:true,get:()=>auPlay});
Object.defineProperty(window,"auStopAmbient",{configurable:true,get:()=>auStopAmbient});
Object.defineProperty(window,"auVoice",{configurable:true,get:()=>auVoice});
Object.defineProperty(window,"auWeapon",{configurable:true,get:()=>auWeapon});
Object.defineProperty(window,"audioCtx",{configurable:true,get:()=>audioCtx});
Object.defineProperty(window,"backToMenu",{configurable:true,get:()=>backToMenu});
Object.defineProperty(window,"barrelAt",{configurable:true,get:()=>barrelAt});
Object.defineProperty(window,"block3D",{configurable:true,get:()=>block3D});
Object.defineProperty(window,"blocked",{configurable:true,get:()=>blocked});
Object.defineProperty(window,"boardCenter",{configurable:true,get:()=>boardCenter});
Object.defineProperty(window,"boardTileClick",{configurable:true,get:()=>boardTileClick});
Object.defineProperty(window,"boneTargetQ",{configurable:true,get:()=>boneTargetQ});
Object.defineProperty(window,"box3",{configurable:true,get:()=>box3});
Object.defineProperty(window,"build3DWorld",{configurable:true,get:()=>build3DWorld});
Object.defineProperty(window,"buildArsenal",{configurable:true,get:()=>buildArsenal});
Object.defineProperty(window,"buildDemo",{configurable:true,get:()=>buildDemo});
Object.defineProperty(window,"buildMap",{configurable:true,get:()=>buildMap});
Object.defineProperty(window,"buildNationGrid",{configurable:true,get:()=>buildNationGrid});
Object.defineProperty(window,"buildSkirmishGeo3",{configurable:true,get:()=>buildSkirmishGeo3});
Object.defineProperty(window,"buildSpriteSVG",{configurable:true,get:()=>buildSpriteSVG});
Object.defineProperty(window,"buildSpriteStrip",{configurable:true,get:()=>buildSpriteStrip});
Object.defineProperty(window,"buildSquads",{configurable:true,get:()=>buildSquads});
Object.defineProperty(window,"buildThemedProps3",{configurable:true,get:()=>buildThemedProps3});
Object.defineProperty(window,"camoTexture",{configurable:true,get:()=>camoTexture});
Object.defineProperty(window,"canHealSpecial",{configurable:true,get:()=>canHealSpecial});
Object.defineProperty(window,"canReviveSpecial",{configurable:true,get:()=>canReviveSpecial});
Object.defineProperty(window,"canSnipeSpecial",{configurable:true,get:()=>canSnipeSpecial});
Object.defineProperty(window,"canStep",{configurable:true,get:()=>canStep});
Object.defineProperty(window,"canvas",{configurable:true,get:()=>canvas});
Object.defineProperty(window,"ctx",{configurable:true,get:()=>ctx});
Object.defineProperty(window,"captureTurret",{configurable:true,get:()=>captureTurret});
Object.defineProperty(window,"charAbilitiesFor",{configurable:true,get:()=>charAbilitiesFor});
Object.defineProperty(window,"charForKey",{configurable:true,get:()=>charForKey});
Object.defineProperty(window,"charNameFor",{configurable:true,get:()=>charNameFor});
Object.defineProperty(window,"characterForRole",{configurable:true,get:()=>characterForRole});
Object.defineProperty(window,"characterKey",{configurable:true,get:()=>characterKey});
Object.defineProperty(window,"charsForRole",{configurable:true,get:()=>charsForRole});
Object.defineProperty(window,"cheb",{configurable:true,get:()=>cheb});
Object.defineProperty(window,"checkBeaconAtTurnEnd",{configurable:true,get:()=>checkBeaconAtTurnEnd});
Object.defineProperty(window,"checkMines",{configurable:true,get:()=>checkMines});
Object.defineProperty(window,"checkOverwatch",{configurable:true,get:()=>checkOverwatch});
Object.defineProperty(window,"checkWin",{configurable:true,get:()=>checkWin});
Object.defineProperty(window,"classicBoardMetrics",{configurable:true,get:()=>classicBoardMetrics});
Object.defineProperty(window,"classicTileFromPoint",{configurable:true,get:()=>classicTileFromPoint});
Object.defineProperty(window,"clipEventFeedback",{configurable:true,get:()=>clipEventFeedback});
Object.defineProperty(window,"clipPulse",{configurable:true,get:()=>clipPulse});
Object.defineProperty(window,"clipTrackAt",{configurable:true,get:()=>clipTrackAt});
Object.defineProperty(window,"closeModal",{configurable:true,get:()=>closeModal});
Object.defineProperty(window,"coinsGet",{configurable:true,get:()=>coinsGet});
Object.defineProperty(window,"coinsSet",{configurable:true,get:()=>coinsSet});
Object.defineProperty(window,"coverBonus",{configurable:true,get:()=>coverBonus});
Object.defineProperty(window,"coverLevel",{configurable:true,get:()=>coverLevel});
Object.defineProperty(window,"damage",{configurable:true,get:()=>damage});
Object.defineProperty(window,"demoStatus",{configurable:true,get:()=>demoStatus});
Object.defineProperty(window,"demoUnit",{configurable:true,get:()=>demoUnit});
Object.defineProperty(window,"deployTurret",{configurable:true,get:()=>deployTurret});
Object.defineProperty(window,"deployedAt",{configurable:true,get:()=>deployedAt});
Object.defineProperty(window,"dispatchClipEvents",{configurable:true,get:()=>dispatchClipEvents});
Object.defineProperty(window,"dist",{configurable:true,get:()=>dist});
Object.defineProperty(window,"domControl",{configurable:true,get:()=>domControl});
Object.defineProperty(window,"domZones",{configurable:true,get:()=>domZones});
Object.defineProperty(window,"draw",{configurable:true,get:()=>draw});
Object.defineProperty(window,"drawBarrel",{configurable:true,get:()=>drawBarrel});
Object.defineProperty(window,"drawContainer",{configurable:true,get:()=>drawContainer});
Object.defineProperty(window,"drawCrate",{configurable:true,get:()=>drawCrate});
Object.defineProperty(window,"drawDeployed",{configurable:true,get:()=>drawDeployed});
Object.defineProperty(window,"drawDrone",{configurable:true,get:()=>drawDrone});
Object.defineProperty(window,"drawFX",{configurable:true,get:()=>drawFX});
Object.defineProperty(window,"drawFloorTile",{configurable:true,get:()=>drawFloorTile});
Object.defineProperty(window,"drawMedkit",{configurable:true,get:()=>drawMedkit});
Object.defineProperty(window,"drawMovePath",{configurable:true,get:()=>drawMovePath});
Object.defineProperty(window,"drawPlatform",{configurable:true,get:()=>drawPlatform});
Object.defineProperty(window,"drawSoldier",{configurable:true,get:()=>drawSoldier});
Object.defineProperty(window,"drawWall",{configurable:true,get:()=>drawWall});
Object.defineProperty(window,"driveClipSoldier",{configurable:true,get:()=>driveClipSoldier});
Object.defineProperty(window,"driveRealSoldier",{configurable:true,get:()=>driveRealSoldier});
Object.defineProperty(window,"droneAt",{configurable:true,get:()=>droneAt});
Object.defineProperty(window,"effMode",{configurable:true,get:()=>effMode});
Object.defineProperty(window,"effSetupMode",{configurable:true,get:()=>effSetupMode});
Object.defineProperty(window,"emblemHTML",{configurable:true,get:()=>emblemHTML});
Object.defineProperty(window,"emblemTexture",{configurable:true,get:()=>emblemTexture});
Object.defineProperty(window,"endGame",{configurable:true,get:()=>endGame});
Object.defineProperty(window,"endTurn",{configurable:true,get:()=>endTurn});
Object.defineProperty(window,"enterApp",{configurable:true,get:()=>enterApp});
Object.defineProperty(window,"escortExt",{configurable:true,get:()=>escortExt});
Object.defineProperty(window,"escortStart",{configurable:true,get:()=>escortStart});
Object.defineProperty(window,"explodeBarrel",{configurable:true,get:()=>explodeBarrel});
Object.defineProperty(window,"explodeNear",{configurable:true,get:()=>explodeNear});
Object.defineProperty(window,"facingVec",{configurable:true,get:()=>facingVec});
Object.defineProperty(window,"facingYaw",{configurable:true,get:()=>facingYaw});
Object.defineProperty(window,"falloffFactor",{configurable:true,get:()=>falloffFactor});
Object.defineProperty(window,"fireArtillery",{configurable:true,get:()=>fireArtillery});
Object.defineProperty(window,"fireClipFor",{configurable:true,get:()=>fireClipFor});
Object.defineProperty(window,"fireOrbital",{configurable:true,get:()=>fireOrbital});
Object.defineProperty(window,"fireWeaponFeedback",{configurable:true,get:()=>fireWeaponFeedback});
Object.defineProperty(window,"fitGunToHand3",{configurable:true,get:()=>fitGunToHand3});
Object.defineProperty(window,"fitLiveGun3",{configurable:true,get:()=>fitLiveGun3});
Object.defineProperty(window,"fitSpriteGun",{configurable:true,get:()=>fitSpriteGun});
Object.defineProperty(window,"fitViewerDistance",{configurable:true,get:()=>fitViewerDistance});
Object.defineProperty(window,"flagArtHTML",{configurable:true,get:()=>flagArtHTML});
Object.defineProperty(window,"flagHTML",{configurable:true,get:()=>flagHTML});
Object.defineProperty(window,"flowStep",{configurable:true,get:()=>flowStep,set:v=>{flowStep=v;}});
Object.defineProperty(window,"fmtCountdown",{configurable:true,get:()=>fmtCountdown});
Object.defineProperty(window,"fx3Explosion",{configurable:true,get:()=>fx3Explosion});
Object.defineProperty(window,"fx3Float",{configurable:true,get:()=>fx3Float});
Object.defineProperty(window,"fx3Proj",{configurable:true,get:()=>fx3Proj});
Object.defineProperty(window,"fx3Shot",{configurable:true,get:()=>fx3Shot});
Object.defineProperty(window,"fx3Sparks",{configurable:true,get:()=>fx3Sparks});
Object.defineProperty(window,"fx3Spawn",{configurable:true,get:()=>fx3Spawn});
Object.defineProperty(window,"fxBurst",{configurable:true,get:()=>fxBurst});
Object.defineProperty(window,"fxFloat",{configurable:true,get:()=>fxFloat});
Object.defineProperty(window,"fxLoop",{configurable:true,get:()=>fxLoop});
Object.defineProperty(window,"fxTracer",{configurable:true,get:()=>fxTracer});
Object.defineProperty(window,"gameplayModelPresentation",{configurable:true,get:()=>gameplayModelPresentation});
Object.defineProperty(window,"getRealSpriteImage",{configurable:true,get:()=>getRealSpriteImage});
Object.defineProperty(window,"getRealSpriteURL",{configurable:true,get:()=>getRealSpriteURL});
Object.defineProperty(window,"getSpriteImage",{configurable:true,get:()=>getSpriteImage});
Object.defineProperty(window,"gridLineCells",{configurable:true,get:()=>gridLineCells});
Object.defineProperty(window,"guideDrone",{configurable:true,get:()=>guideDrone});
Object.defineProperty(window,"gunPoseFromHand",{configurable:true,get:()=>gunPoseFromHand});
Object.defineProperty(window,"gunRotatedBounds",{configurable:true,get:()=>gunRotatedBounds});
Object.defineProperty(window,"gunRotationFor",{configurable:true,get:()=>gunRotationFor});
Object.defineProperty(window,"gunSwapWaiters",{configurable:true,get:()=>gunSwapWaiters});
Object.defineProperty(window,"hasCharAction",{configurable:true,get:()=>hasCharAction});
Object.defineProperty(window,"hasCharIcon",{configurable:true,get:()=>hasCharIcon});
Object.defineProperty(window,"hasLOS",{configurable:true,get:()=>hasLOS});
Object.defineProperty(window,"hash2",{configurable:true,get:()=>hash2});
Object.defineProperty(window,"hitChance",{configurable:true,get:()=>hitChance});
Object.defineProperty(window,"hoverTile",{configurable:true,get:()=>hoverTile,set:v=>{setHoverTile(v);}});
Object.defineProperty(window,"inBeacon",{configurable:true,get:()=>inBeacon});
Object.defineProperty(window,"inDomZone",{configurable:true,get:()=>inDomZone});
Object.defineProperty(window,"init3D",{configurable:true,get:()=>init3D});
Object.defineProperty(window,"initRealSpriteRenderer",{configurable:true,get:()=>initRealSpriteRenderer});
Object.defineProperty(window,"isExtraction",{configurable:true,get:()=>isExtraction});
Object.defineProperty(window,"isFlanked",{configurable:true,get:()=>isFlanked});
Object.defineProperty(window,"isMobileGL3",{configurable:true,get:()=>isMobileGL3});
Object.defineProperty(window,"isSoftwareGL3",{configurable:true,get:()=>isSoftwareGL3});
Object.defineProperty(window,"isWeekend",{configurable:true,get:()=>isWeekend});
Object.defineProperty(window,"lg",{configurable:true,get:()=>lg});
Object.defineProperty(window,"loadCampaign",{configurable:true,get:()=>loadCampaign});
Object.defineProperty(window,"loadChars",{configurable:true,get:()=>loadChars});
Object.defineProperty(window,"loadMeshyModel",{configurable:true,get:()=>loadMeshyModel});
Object.defineProperty(window,"loadRealSoldier",{configurable:true,get:()=>loadRealSoldier});
Object.defineProperty(window,"loadSkirmishGeo",{configurable:true,get:()=>loadSkirmishGeo});
Object.defineProperty(window,"loadSkirmishTop",{configurable:true,get:()=>loadSkirmishTop});
Object.defineProperty(window,"log",{configurable:true,get:()=>log});
Object.defineProperty(window,"lsGet",{configurable:true,get:()=>lsGet});
Object.defineProperty(window,"lsRemove",{configurable:true,get:()=>lsRemove});
Object.defineProperty(window,"lsSet",{configurable:true,get:()=>lsSet});
Object.defineProperty(window,"makeContactShadow3",{configurable:true,get:()=>makeContactShadow3});
Object.defineProperty(window,"makeDrone3",{configurable:true,get:()=>makeDrone3});
Object.defineProperty(window,"makeGunAnchor",{configurable:true,get:()=>makeGunAnchor});
Object.defineProperty(window,"makeGunProp3",{configurable:true,get:()=>makeGunProp3});
Object.defineProperty(window,"makeRealGun3",{configurable:true,get:()=>makeRealGun3});
Object.defineProperty(window,"makeRealSoldier3",{configurable:true,get:()=>makeRealSoldier3});
Object.defineProperty(window,"makeSkinnedModel",{configurable:true,get:()=>makeSkinnedModel});
Object.defineProperty(window,"makeSoldier3",{configurable:true,get:()=>makeSoldier3});
Object.defineProperty(window,"makeUnit",{configurable:true,get:()=>makeUnit});
Object.defineProperty(window,"mat3",{configurable:true,get:()=>mat3});
Object.defineProperty(window,"maybeDropLoot",{configurable:true,get:()=>maybeDropLoot});
Object.defineProperty(window,"mineAt",{configurable:true,get:()=>mineAt});
Object.defineProperty(window,"moveCostOf",{configurable:true,get:()=>moveCostOf});
Object.defineProperty(window,"msToNextSaturday",{configurable:true,get:()=>msToNextSaturday});
Object.defineProperty(window,"myNation",{configurable:true,get:()=>myNation,set:v=>{myNation=v;}});
Object.defineProperty(window,"pickedNation",{configurable:true,get:()=>pickedNation,set:v=>{pickedNation=v;}});
Object.defineProperty(window,"nationById",{configurable:true,get:()=>nationById});
Object.defineProperty(window,"nationTintColor",{configurable:true,get:()=>nationTintColor});
Object.defineProperty(window,"nativeBlocked",{configurable:true,get:()=>nativeBlocked});
Object.defineProperty(window,"nativeEdgeBits",{configurable:true,get:()=>nativeEdgeBits});
Object.defineProperty(window,"nativeSolidEdge",{configurable:true,get:()=>nativeSolidEdge});
Object.defineProperty(window,"nativeTile",{configurable:true,get:()=>nativeTile});
Object.defineProperty(window,"noiseBurst",{configurable:true,get:()=>noiseBurst});
Object.defineProperty(window,"normalizeMeshyRig",{configurable:true,get:()=>normalizeMeshyRig});
Object.defineProperty(window,"normalizeMeshyRigGlobal",{configurable:true,get:()=>normalizeMeshyRigGlobal});
Object.defineProperty(window,"obAt",{configurable:true,get:()=>obAt});
Object.defineProperty(window,"openBarracks",{configurable:true,get:()=>openBarracks});
Object.defineProperty(window,"openSetup",{configurable:true,get:()=>openSetup});
Object.defineProperty(window,"parseMeshyOBJ",{configurable:true,get:()=>parseMeshyOBJ});
Object.defineProperty(window,"parseOBJ3",{configurable:true,get:()=>parseOBJ3});
Object.defineProperty(window,"parseOBJStatic",{configurable:true,get:()=>parseOBJStatic});
Object.defineProperty(window,"pathDist",{configurable:true,get:()=>pathDist});
Object.defineProperty(window,"pickupLoot",{configurable:true,get:()=>pickupLoot});
Object.defineProperty(window,"placeCover",{configurable:true,get:()=>placeCover});
Object.defineProperty(window,"placeHealthCrate",{configurable:true,get:()=>placeHealthCrate});
Object.defineProperty(window,"placeMine",{configurable:true,get:()=>placeMine});
Object.defineProperty(window,"playOnce",{configurable:true,get:()=>playOnce});
Object.defineProperty(window,"poseSpriteAim",{configurable:true,get:()=>poseSpriteAim});
Object.defineProperty(window,"poseSpriteClip",{configurable:true,get:()=>poseSpriteClip});
Object.defineProperty(window,"preloadNativeGrids",{configurable:true,get:()=>preloadNativeGrids});
Object.defineProperty(window,"procTex3",{configurable:true,get:()=>procTex3});
Object.defineProperty(window,"quickFlash",{configurable:true,get:()=>quickFlash});
Object.defineProperty(window,"quickSmoke",{configurable:true,get:()=>quickSmoke});
Object.defineProperty(window,"quickStart",{configurable:true,get:()=>quickStart});
Object.defineProperty(window,"reachable",{configurable:true,get:()=>reachable});
Object.defineProperty(window,"readSquad",{configurable:true,get:()=>readSquad});
Object.defineProperty(window,"realSpriteKey",{configurable:true,get:()=>realSpriteKey});
Object.defineProperty(window,"realSpriteUnit",{configurable:true,get:()=>realSpriteUnit});
Object.defineProperty(window,"rebuildDemo",{configurable:true,get:()=>rebuildDemo});
Object.defineProperty(window,"rebuildDyn3",{configurable:true,get:()=>rebuildDyn3});
Object.defineProperty(window,"rebuildHighlights3",{configurable:true,get:()=>rebuildHighlights3});
Object.defineProperty(window,"refreshGuerra",{configurable:true,get:()=>refreshGuerra});
Object.defineProperty(window,"renderAbilityCatalog",{configurable:true,get:()=>renderAbilityCatalog});
Object.defineProperty(window,"renderBarracks",{configurable:true,get:()=>renderBarracks});
Object.defineProperty(window,"renderCampaignPanel",{configurable:true,get:()=>renderCampaignPanel});
Object.defineProperty(window,"renderNationChip",{configurable:true,get:()=>renderNationChip});
Object.defineProperty(window,"renderRealSprite",{configurable:true,get:()=>renderRealSprite});
Object.defineProperty(window,"renderSoundBtn",{configurable:true,get:()=>renderSoundBtn});
Object.defineProperty(window,"renderWeaponThumb",{configurable:true,get:()=>renderWeaponThumb});
Object.defineProperty(window,"resetCam3D",{configurable:true,get:()=>resetCam3D});
Object.defineProperty(window,"resetCamState",{configurable:true,get:()=>resetCamState});
Object.defineProperty(window,"retargetPoseToRig",{configurable:true,get:()=>retargetPoseToRig});
Object.defineProperty(window,"rg",{configurable:true,get:()=>rg});
Object.defineProperty(window,"rng",{configurable:true,get:()=>rng});
Object.defineProperty(window,"rngState",{configurable:true,get:()=>rngState});
Object.defineProperty(window,"roleLook",{configurable:true,get:()=>roleLook});
Object.defineProperty(window,"rolePortraitURL",{configurable:true,get:()=>rolePortraitURL});
Object.defineProperty(window,"rootBonePositionForClip",{configurable:true,get:()=>rootBonePositionForClip});
Object.defineProperty(window,"rotAxisQ",{configurable:true,get:()=>rotAxisQ});
Object.defineProperty(window,"rr",{configurable:true,get:()=>rr});
Object.defineProperty(window,"sameRigBoneOrder",{configurable:true,get:()=>sameRigBoneOrder});
Object.defineProperty(window,"sampleClipPos",{configurable:true,get:()=>sampleClipPos});
Object.defineProperty(window,"sampleClipQuat",{configurable:true,get:()=>sampleClipQuat});
Object.defineProperty(window,"saveCampaign",{configurable:true,get:()=>saveCampaign});
Object.defineProperty(window,"saveChars",{configurable:true,get:()=>saveChars});
Object.defineProperty(window,"scoreDominationFor",{configurable:true,get:()=>scoreDominationFor});
Object.defineProperty(window,"screenStateFor",{configurable:true,get:()=>screenStateFor});
Object.defineProperty(window,"sculptedWeaponUnit",{configurable:true,get:()=>sculptedWeaponUnit});
Object.defineProperty(window,"segRing",{configurable:true,get:()=>segRing});
Object.defineProperty(window,"selectUnit",{configurable:true,get:()=>selectUnit});
Object.defineProperty(window,"setBoardSize",{configurable:true,get:()=>setBoardSize});
Object.defineProperty(window,"setOverwatch",{configurable:true,get:()=>setOverwatch});
Object.defineProperty(window,"setStep",{configurable:true,get:()=>setStep});
Object.defineProperty(window,"setTurnSeed",{configurable:true,get:()=>setTurnSeed});
Object.defineProperty(window,"setViewMode",{configurable:true,get:()=>setViewMode});
Object.defineProperty(window,"setup",{configurable:true,get:()=>setup,set:v=>{setup=v;}});
Object.defineProperty(window,"sfx",{configurable:true,get:()=>sfx});
Object.defineProperty(window,"shade",{configurable:true,get:()=>shade});
Object.defineProperty(window,"shadeHex",{configurable:true,get:()=>shadeHex});
Object.defineProperty(window,"shortestArc",{configurable:true,get:()=>shortestArc});
Object.defineProperty(window,"showModal",{configurable:true,get:()=>showModal});
Object.defineProperty(window,"showScreen",{configurable:true,get:()=>showScreen});
Object.defineProperty(window,"skState",{configurable:true,get:()=>skState});
Object.defineProperty(window,"skyTheme3",{configurable:true,get:()=>skyTheme3});
Object.defineProperty(window,"smokeAt",{configurable:true,get:()=>smokeAt});
Object.defineProperty(window,"smokeBlocksLOS",{configurable:true,get:()=>smokeBlocksLOS});
Object.defineProperty(window,"smoothDrawStep",{configurable:true,get:()=>smoothDrawStep});
Object.defineProperty(window,"soldierColors3",{configurable:true,get:()=>soldierColors3});
Object.defineProperty(window,"spawnsFor",{configurable:true,get:()=>spawnsFor});
Object.defineProperty(window,"spendEnergy",{configurable:true,get:()=>spendEnergy});
Object.defineProperty(window,"spriteDataURI",{configurable:true,get:()=>spriteDataURI});
Object.defineProperty(window,"squadRows",{configurable:true,get:()=>squadRows});
Object.defineProperty(window,"startDrawMove",{configurable:true,get:()=>startDrawMove});
Object.defineProperty(window,"startGame",{configurable:true,get:()=>startGame});
Object.defineProperty(window,"sweepDetect",{configurable:true,get:()=>sweepDetect});
Object.defineProperty(window,"syncDiffSeg",{configurable:true,get:()=>syncDiffSeg});
Object.defineProperty(window,"syncMapSeg",{configurable:true,get:()=>syncMapSeg});
Object.defineProperty(window,"syncPlayingViewport",{configurable:true,get:()=>syncPlayingViewport});
Object.defineProperty(window,"syncSkinSegs",{configurable:true,get:()=>syncSkinSegs});
Object.defineProperty(window,"teamName",{configurable:true,get:()=>teamName});
Object.defineProperty(window,"teleportUnit",{configurable:true,get:()=>teleportUnit});
Object.defineProperty(window,"texMat3",{configurable:true,get:()=>texMat3});
Object.defineProperty(window,"throwBees",{configurable:true,get:()=>throwBees});
Object.defineProperty(window,"throwFlash",{configurable:true,get:()=>throwFlash});
Object.defineProperty(window,"throwGas",{configurable:true,get:()=>throwGas});
Object.defineProperty(window,"throwGrenade",{configurable:true,get:()=>throwGrenade});
Object.defineProperty(window,"throwMolotov",{configurable:true,get:()=>throwMolotov});
Object.defineProperty(window,"throwSmoke",{configurable:true,get:()=>throwSmoke});
Object.defineProperty(window,"throwTranq",{configurable:true,get:()=>throwTranq});
Object.defineProperty(window,"tickFx3D",{configurable:true,get:()=>tickFx3D});
Object.defineProperty(window,"tileFromEvent",{configurable:true,get:()=>tileFromEvent});
Object.defineProperty(window,"tileWorldY",{configurable:true,get:()=>tileWorldY});
Object.defineProperty(window,"toast",{configurable:true,get:()=>toast});
Object.defineProperty(window,"tone",{configurable:true,get:()=>tone});
Object.defineProperty(window,"toonGrad3",{configurable:true,get:()=>toonGrad3});
Object.defineProperty(window,"tryShoot",{configurable:true,get:()=>tryShoot});
Object.defineProperty(window,"turretFire",{configurable:true,get:()=>turretFire});
Object.defineProperty(window,"tutHide",{configurable:true,get:()=>tutHide});
Object.defineProperty(window,"tutShow",{configurable:true,get:()=>tutShow});
Object.defineProperty(window,"uid",{configurable:true,get:()=>uid,set:v=>{uid=v;}});
Object.defineProperty(window,"undoLastMove",{configurable:true,get:()=>undoLastMove});
Object.defineProperty(window,"unitAt",{configurable:true,get:()=>unitAt});
Object.defineProperty(window,"unitHasAction",{configurable:true,get:()=>unitHasAction});
Object.defineProperty(window,"updateHover3D",{configurable:true,get:()=>updateHover3D});
Object.defineProperty(window,"updateUI",{configurable:true,get:()=>updateUI});
Object.defineProperty(window,"updateUnitDrawPosition",{configurable:true,get:()=>updateUnitDrawPosition});
Object.defineProperty(window,"updateUnitHuds3D",{configurable:true,get:()=>updateUnitHuds3D});
Object.defineProperty(window,"useShield",{configurable:true,get:()=>useShield});
Object.defineProperty(window,"useSpecial",{configurable:true,get:()=>useSpecial});
Object.defineProperty(window,"useToolkit",{configurable:true,get:()=>useToolkit});
Object.defineProperty(window,"validatedRigBoneInverses",{configurable:true,get:()=>validatedRigBoneInverses});
Object.defineProperty(window,"viewerCenterOffset",{configurable:true,get:()=>viewerCenterOffset});
Object.defineProperty(window,"viewerTeam",{configurable:true,get:()=>viewerTeam});
Object.defineProperty(window,"w2cx",{configurable:true,get:()=>w2cx});
Object.defineProperty(window,"waterCannon",{configurable:true,get:()=>waterCannon});
Object.defineProperty(window,"weaponCalibration",{configurable:true,get:()=>weaponCalibration});
Object.defineProperty(window,"weaponCategoryForFile",{configurable:true,get:()=>weaponCategoryForFile});
Object.defineProperty(window,"weaponCoverURL",{configurable:true,get:()=>weaponCoverURL});
Object.defineProperty(window,"weaponFileForRef",{configurable:true,get:()=>weaponFileForRef});
Object.defineProperty(window,"weaponMeta",{configurable:true,get:()=>weaponMeta});
Object.defineProperty(window,"weaponTargetLength",{configurable:true,get:()=>weaponTargetLength});
Object.defineProperty(window,"wireSkinSeg",{configurable:true,get:()=>wireSkinSeg});
Object.defineProperty(window,"worldRotationsFromLocal",{configurable:true,get:()=>worldRotationsFromLocal});

