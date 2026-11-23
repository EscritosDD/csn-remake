'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const vm = require('node:vm');

const root = path.dirname(__dirname);
const read = file => fs.readFileSync(path.join(root, file), 'utf8');
const stage = read('src/viewer/card-stage.js');
const viewer = read('src/viewer/main.js');
const arsenal = read('src/ui/arsenal.js');
const troops = read('src/viewer/troop-cards.js');
const inspector = read('src/viewer/inspector.js');
const weaponsJs = read('src/render3d/assets-weapons.js');
const soundJs = read('src/audio/sound.js');
const indexHtml = read('index.html');
const cardsCss = read('styles/cards.css');

function loadCardStage() {
  const sandbox = { THREE: {}, console, Date, Math, Number, Object, Array, Map, Set, Promise, setTimeout };
  sandbox.globalThis = sandbox;
  vm.createContext(sandbox);
  vm.runInContext(stage.replace(/\bexport\s+/g, '') + '\n;globalThis.__probe={getQueue:()=>queue,setCallbacks:setCardStageCallbacks,register:registerCardBox};', sandbox);
  return sandbox.__probe;
}

function fakeBox(isConnected) {
  return { isConnected, dataset: {}, addEventListener() {}, querySelector: () => null };
}

test('las tarjetas 3D comparten un único renderer con buffer de captura', () => {
  assert.equal((stage.match(/new THREE\.WebGLRenderer/g)||[]).length, 1);
  assert.match(stage, /preserveDrawingBuffer:true/);
  assert.match(stage, /IntersectionObserver/);
  assert.match(stage, /const thumbs=new Map\(\)/);
  assert.match(stage, /function renderThumbnail\(spec,model\)/);
  assert.match(stage, /function mountStageInto\(box,spec\)/);
  assert.doesNotMatch(viewer, /new THREE\.WebGLRenderer/);
  assert.match(viewer, /ensureCardStage\(stage\)/);
  assert.match(viewer, /setCardModelBuilder\(buildCardModel\)/);
  assert.match(viewer, /window\.__csnCardEngine=cardEngine/);
});

test('el visor usa el motor de tarjetas sin controles de piezas', () => {
  assert.match(viewer, /renderTroopCards\(viewerCharacters,viewerWeaponFiles\)/);
  assert.doesNotMatch(viewer, /setTimeout\(\(\)=>cardEngine\.activateFirst\(\),400\)/);
  assert.match(viewer, /isCardStageRendering\(\)/);
  assert.match(viewer, /auVoice\(\{name:entry\.name,role:entry\.role\},'firing',0\.55\)/);
  assert.doesNotMatch(viewer, /viewerPiece/);
  assert.doesNotMatch(viewer, /loadViewerPiece/);
  assert.doesNotMatch(viewer, /kind==='pieces'/);
  assert.doesNotMatch(viewer, /roleWeapons/);
});

test('Armería separa origen, CSN sin malla y desplegables', () => {
  assert.match(arsenal, /export const ORIGINS=\['Todas','Juego original','CSN'\]/);
  assert.match(arsenal, /Modelo 3D CSN pendiente/);
  assert.match(arsenal, /export function buildDeployables\(\)/);
  assert.match(arsenal, /export function openDeployable3D\(key\)/);
  assert.match(arsenal, /window\.openDeployable3D=openDeployable3D/);
  assert.match(arsenal, /data-au-file/);
});

test('Tropas muestra tarjetas limpias y abre el inspector ampliado', async () => {
  const { DEPLOYABLES } = await import('../src/data/deployables.js');
  assert.equal(DEPLOYABLES.length, 10);
  assert.match(troops, /data-inspector-open/);
  assert.doesNotMatch(troops, /card-3d-tools/);
  assert.doesNotMatch(troops, /data-weapon-select/);
  assert.match(troops, /data-origin="'\+origin\+'"/);
  assert.match(troops, /Sin pose, clips ni retarget\./);
  assert.match(troops, /getWeaponFiles:\(\)=>tcWeaponFiles/);
  assert.match(cardsCss, /minmax\(260px,1fr\)/);
  assert.match(cardsCss, /gap:14px/);
  assert.match(cardsCss, /transform 220ms cubic-bezier\(0\.22,1,0\.36,1\),box-shadow 220ms ease,border-color 220ms ease/);
  assert.match(cardsCss, /background:var\(--stage\)/);
});

test('las miniaturas esperan a la textura del arma y no crean otro renderer', () => {
  assert.match(weaponsJs, /const texReady=new Promise\(resolve=>\{resolveTex=resolve;\}\)/);
  assert.match(weaponsJs, /texReady:texReady/);
  assert.match(weaponsJs, /resolveTex\(t\)/);
  assert.doesNotMatch(weaponsJs, /new THREE\.WebGLRenderer/);
  assert.match(stage, /stage\.renderer\.clear\(true,true,true\)/);
  assert.match(stage, /restPose\(model\)/);
  assert.match(stage, /url\.length>2048/);
  assert.match(stage, /setCardStagePaused/);
});

test('el inspector ampliado reúne skins, 23 armas, sonido y desplegables', async () => {
  const { prettySkinName } = await import('../src/data/skin-names.js');
  assert.equal(prettySkinName('Soldier_Light_DeltaForce_d.png'), 'Delta Force');
  assert.equal(prettySkinName('Soldier_Light_Rambo_DeerHunter_d.png'), 'Deer Hunter');
  assert.equal(prettySkinName('Soldier_SAS_Veteran_d.png'), 'Veterano');
  assert.equal(prettySkinName('Medic_Halloween_d.png'), 'Halloween');
  assert.equal(prettySkinName('Engineer_Heavy_EOD_d.png'), 'EOD');
  assert.equal(prettySkinName('Soldier_d.png'), 'Estándar');
  assert.doesNotMatch(prettySkinName('Soldier_Light_DeltaForce_d.png'), /_d\.png/);
  assert.match(inspector, /prettySkinName/);
  assert.match(inspector, /data-inspector-skin-step/);
  assert.match(inspector, /getWeaponFiles\(\)/);
  assert.match(inspector, /Sin arma \(solo personaje\)/);
  assert.match(inspector, /Elige un arma para probar disparo/);
  assert.match(inspector, /insFire\.disabled=true/);
  assert.match(inspector, /Inspeccionar desplegable/);
  assert.match(inspector, /auWeaponFile/);
  assert.match(inspector, /insFire\.textContent='▶ '\+\(profile&&profile\.actionLabel\|\|'Probar disparo'\)/);
  assert.match(inspector, /setCardStagePaused\(true\)/);
  assert.match(inspector, /viewer\.state\.inspectorOpen=true/);
  assert.match(inspector, /Escape/);
  assert.match(indexHtml, /id="inspectorRoot" class="inspector-root" hidden/);
  assert.match(indexHtml, /id="inspectorStage" class="card-3d-box inspector-stage"/);
  assert.match(indexHtml, /id="inspectorReset"/);
  assert.doesNotMatch(indexHtml, /id="armTabSeg"/);
  assert.match(indexHtml, /Desplegables y objetos \(10\)/);
  assert.match(indexHtml, /Habilidades del original \(52\)/);
  assert.match(cardsCss, /width:min\(94vw,1120px\)/);
  assert.match(cardsCss, /min-height:620px/);
  assert.match(cardsCss, /blur\(8px\)/);
  assert.match(cardsCss, /grid-template-columns:62% 38%/);
  assert.match(cardsCss, /grid-template-columns:44px minmax\(0,1fr\) 44px/);
});

test('onInspect(box, spec) entrega el spec al inspector y nunca el nodo DOM', () => {
  const engine = loadCardStage();
  const seen = [];
  const spec = { kind: 'weapons', key: 'Pistol', file: 'Pistol', label: 'M9', inspect: true };
  const listeners = {};
  const box = fakeBox(true);
  box.addEventListener = (type, fn) => { listeners[type] = fn; };
  engine.setCallbacks({ onInspect: (receivedBox, receivedSpec) => seen.push(receivedSpec) });
  engine.register(box, spec);
  listeners.pointerdown({ button: 0, clientX: 0, clientY: 0, pointerId: 1 });
  assert.equal(seen.length, 1);
  assert.equal(seen[0], spec);
  assert.notEqual(seen[0], box);
  assert.equal(typeof seen[0].kind, 'string');
  assert.match(viewer, /onInspect:\(box,spec\)=>openInspector\(spec\)/);
});

test('queueThumb sustituye la tarea en cola cuando su caja anterior fue desconectada', () => {
  const engine = loadCardStage();
  const spec = { kind: 'roles', key: 'original:01', skinIndex: 0, weapon: '', inspect: true };
  const first = fakeBox(true);
  const second = fakeBox(true);
  engine.register(first, spec);
  const key = 'roles|original:01|0||';
  assert.equal(engine.getQueue().filter(task => task.key === key).length, 1);
  first.isConnected = false;
  engine.register(second, spec);
  const replaced = engine.getQueue().find(task => task.key === key);
  assert.ok(replaced);
  assert.equal(replaced.box, second);
  assert.equal(replaced.spec, spec);
});

test('auPlay en bucle es pausable y auWeaponFile usa el SFX exacto de las 23 armas', async () => {
  const { auPlay, auWeaponFile } = await import('../src/audio/sound.js');
  const { originalWeaponProfile, WEAPONS_ORIGINAL } = await import('../src/render3d/assets-weapons.js');
  const expected = {
    AssaultRifle: 'assaultrifle_fire.mp3', Rifle: 'semiautorifle_fire.mp3', Pistol: 'beretta_fire.mp3',
    Revolver: 'revolver_fire.mp3', Uzi: 'submachinegun_fire.mp3', MP5K: 'mp5k_fire.mp3',
    LightMachineGun: 'lmg_fire.mp3', Minigun: 'minigun_fire.mp3', SniperRifle_weapon: 'sniperrifle_fire.mp3',
    M95: 'm95_fire.mp3', Shotgun: 'shotgun_fire.mp3', RiotShotgun: 'riotshotgun_fire.wav',
    RPG: 'rocketlauncher_fire.mp3', Crossbow: 'crossbow_fire.mp3', Knife: 'knife_slash_01.mp3',
    Katana: 'knife_slash_01.mp3', WoodAxe: 'axe_swing_01.mp3', SledgeHammer: '2h_swing_01.mp3',
    BaseballBat_SOURCE: 'baseballbat_hit_01.mp3', SpikedClub_weapon: 'spikedclub_hit_01.mp3',
    Chainsaw: 'chainsaw_swing_01.mp3', FragGrenade: 'grenade_throw_01.mp3', Molotov: 'grenade_throw_01.mp3',
  };
  assert.equal(Object.keys(WEAPONS_ORIGINAL).length, 23);
  assert.equal(Object.keys(expected).length, 23);
  for (const [file, sfx] of Object.entries(expected)) assert.equal(originalWeaponProfile(file).sfx, sfx, file);
  const played = [];
  const previousAudio = globalThis.Audio;
  globalThis.Audio = class {
    constructor(src) { this.src = src; this.paused = false; }
    play() { played.push(this.src); return Promise.resolve(); }
    pause() { this.paused = true; }
  };
  try {
    const loop = auPlay('music/game_subtle_01.mp3', 0.15, true);
    assert.equal(typeof loop.pause, 'function');
    loop.pause();
    assert.equal(loop.paused, true);
    assert.equal(loop.loop, true);
    played.length = 0;
    for (const file of Object.keys(expected)) auWeaponFile(file);
    await new Promise(resolve => setImmediate(resolve));
    assert.deepEqual(played, Object.values(expected).map(sfx => 'assets/audio/sfx/weapons/' + sfx));
  } finally {
    globalThis.Audio = previousAudio;
  }
  assert.match(soundJs, /if\(loop===true\)return playElement\(path,level,true\)/);
  assert.match(soundJs, /AUDIO_PENDING\.has\(path\)/);
  assert.match(soundJs, /AUDIO_BUFFERS\.set\(path,buffer\)/);
});

test('el Inspector navega personajes, armas y desplegables con flechas', () => {
  assert.match(inspector, /function insNavEntries\(\)/);
  assert.match(inspector, /async function insOpen\(spec\)\{return openInspector\(spec\);\}/);
  assert.match(inspector, /insOpen\(entries\[next\]\)/);
  assert.match(inspector, /if\(insCurrent\.kind==='weapons'\)return \(viewer\.getWeaponFiles\(\)\|\|\[\]\)\.map/);
  assert.match(inspector, /if\(insCurrent\.kind==='props'\)return DEPLOYABLES\.map/);
  assert.match(inspector, /event\.key==='ArrowLeft'/);
  assert.match(inspector, /event\.key==='ArrowRight'/);
  assert.match(inspector, /if\(insPrev\)insPrev\.hidden=navCount<2/);
  assert.doesNotMatch(inspector, /insOpen\(\{kind:'roles'/);
});

test('las 23 armas originales se pueden equipar y disparar desde cualquier personaje', () => {
  const weapons = read('src/render3d/assets-weapons.js');
  assert.match(viewer, /const validWeapon=w=>!!w&&\(viewerWeaponFiles\.includes\(w\)\|\|!!WEAPONS_ORIGINAL\[w\]\|\|!!WEAPONS_ORIGINAL\[weaponFileForRef\(w\)\|\|''\]\)/);
  assert.match(viewer, /if\(!viewer\.weaponTouched\|\|viewer\.weaponChar!==entry\.key\)viewer\.weapon=''/);
  assert.match(viewer, /viewer\.weapon=spec\.weapon\|\|'';viewer\.weaponTouched=true;viewer\.weaponChar=spec\.key;await selectModel\('roles',spec\.key\)/);
  assert.match(viewer, /const wanted=rawWanted\?\(weaponFileForRef\(rawWanted\)\|\|rawWanted\):''/);
  assert.match(viewer, /const idleForWeapon=w=>\{const file=weaponFileForRef\(w\)\|\|w;const profile=file&&originalWeaponProfile\(file\);return profile\?profile\.idleClip:'idle2h'/);
  assert.match(weapons, /const cat=\(WEAPONS\[un\.weapon\]\|\|\{\}\)\.cat\|\|\(file&&String\(\(WEAPONS_ORIGINAL\[file\]\|\|\{\}\)\.cat\|\|''\)\.split\(' \/ '\)\[0\]\)\|\|'Fusiles de asalto'/);
});

test('Tropas arranca sin arma y el Inspector no hereda el gesto de inspección', () => {
  assert.ok(troops.includes("{skinIndex:0,weapon:''}"));
  assert.ok(troops.includes("const weapon=csn?'':(saved.weapon||'');"));
  assert.ok(inspector.includes('insCurrent={...spec,inspect:false};'));
  assert.ok(inspector.includes("kind:'roles',key:entry.key,skinIndex:0,weapon:'',"));
  assert.match(inspector, /insStage\.addEventListener\('pointerdown'/);
  assert.match(inspector, /insStage\.addEventListener\('pointermove'/);
  assert.ok(inspector.includes('stage.spin.rotation.set(0,-0.55,0);'));
  assert.match(indexHtml, /id="inspectorAuto"/);
  assert.match(viewer, /if\(!viewer\.inspectorOpen\|\|viewer\.inspectorAutoSpin\)viewer\.spin\.rotation\.y\+=dt\*0\.22/);
});

test('Minigun está en Ametralladoras y las armas sin fogonazo nunca disparan flash', () => {
  assert.ok(weaponsJs.includes("'M134 Minigun':'Minigun'"));
  assert.ok(weaponsJs.includes("cat:'Ametralladoras',uses:['M134 Minigun']"));
  assert.ok(weaponsJs.includes('blending:THREE.AdditiveBlending'));
  assert.ok(weaponsJs.includes('flash.visible=hasFlash'));
  assert.match(viewer, /profile\.hasMuzzleFlash!==false/);
  assert.match(viewer, /_testFlash-dt\*16/);
  assert.match(viewer, /f==='PlayFiring'\|\|!\(f==='PlayWeaponFire'/);
  assert.doesNotMatch(viewer, /f==='PlayWeaponFire'\|\|f==='PlayFiring'/);
  assert.ok(weaponsJs.includes("'Crossbow'") && weaponsJs.includes("ORIGINAL_NO_FLASH"));
});

test('el visor cambia el idle exacto de cada arma y no reconstruye al disparar', () => {
  assert.match(viewer, /viewer\.idleClipKey=model\.userData\.idleClipKey\|\|\(viewer\.weapon\?idleForWeapon\(viewer\.weapon\):'idle2h'\)/);
  assert.match(viewer, /viewer\.idleClipKey=viewer\.weapon\?idleForWeapon\(viewer\.weapon\):'idle2h'/);
  assert.match(viewer, /model\.userData\.idleClipKey=idleKey;if\(viewer\.idleClipKey!==idleKey\)/);
  assert.match(viewer, /const same=viewer\.cardMode&&!viewer\.glbActor&&viewer\.name===spec\.key&&viewer\.weapon===weapon&&viewer\.idleActor/);
  assert.match(viewer, /viewer\.idleClipKey=idleForWeapon\(weapon\)/);
  assert.match(viewer, /viewer\.idleActor\.userData\._firePulse=Math\.max\(0,viewer\.idleActor\.userData\._firePulse-dt\*5\.5\)/);
  assert.match(viewer, /if\(!visible\|\|!mounted\|\|isCardStageRendering\(\)/);
  assert.doesNotMatch(viewer, /if\(!visible\|\|!inspectorLive/);
  const pose = read('src/render3d/gun-pose.js');
  assert.match(pose, /const hardTrack=!!\(ud\._firePulse>0\|\|ud\._testFlash>0\|\|\/\^\(fire\|throw\|melee\|deploy\|interact\)\//);
  assert.match(pose, /ud\.gun\.position\.copy\(pose\.origin\)/);
  assert.doesNotMatch(pose, /isLive\?0\.45:0\.28/);
});

test('el fogonazo es texturizado, compartido y se coloca en la boca real', () => {
  assert.match(weaponsJs, /export function positionGunFlash\(gunGroup,holder,cat\)/);
  assert.match(weaponsJs, /positionGunFlash\(gun,holder,cat\)/);
  assert.match(weaponsJs, /positionGunFlash\(gun,holder,cat\)/);
  assert.match(weaponsJs, /tex\.userData=\{sharedAsset:true\}/);
  assert.match(weaponsJs, /new THREE\.CanvasTexture\(canvas\)/);
  assert.match(weaponsJs, /new THREE\.PointLight\(0xffb84a,0,2\.2\)/);
  assert.match(weaponsJs, /\[\[0,0,0\],\[Math\.PI\/2,0,0\],\[0,Math\.PI\/2,0\]\]/);
  assert.match(viewer, /flash\.traverse\(o=>\{if\(o\.isMesh&&o\.material\)o\.material\.opacity=1;else if\(o\.isPointLight\)o\.intensity=1\.4;\}\)/);
  assert.match(read('src/render3d/asset-cache.js'), /!texture\.userData\.sharedAsset/);
  assert.match(read('src/render3d/clips.js'), /flash\.traverse\(o=>\{if\(o\.isMesh&&o\.material\)o\.material\.opacity=f/);
});
