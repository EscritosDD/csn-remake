'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const vm = require('node:vm');

function loadEngine() {
  let code = fs.readFileSync(path.join(__dirname, '..', 'src', 'main.js'), 'utf8');
  assert.ok(code, 'src/main.js must exist');
  code = code.replace(/^\s*import\s+[^;]+;\s*$/gm, '');
  const mark = '/* ================= INIT ================= */';
  const idx = code.indexOf(mark);
  assert.ok(idx > 0, 'INIT marker must exist');
  code = code.slice(0, idx);
  code += '\n;globalThis.__api={startGame,endTurn,checkWin,coverLevel,isFlanked,hasLOS,smokeBlocksLOS,throwSmoke,placeMine,checkMines,throwFlash,damage,tryShoot,applyShotDamage,guideDrone,scoreDominationFor,domControl,screenStateFor,classicBoardMetrics,classicTileFromPoint,fitViewerDistance,viewerCenterOffset,gameplayModelPresentation,rootBonePositionForClip,validatedRigBoneInverses,sampleClipQuat,clipTrackAt,resetCamState,resetCam3D,setBoardSize,preloadNativeGrids,boardCenter,w2cx,w2cz,tileFromWorldPoint,camPanBounds,camDefaultDist,bodySpecForUnit,ensureSquadBodies,REAL,ROLES,WEAPONS,NATIONS,DOM_ZONES,DOM_TARGET,ESCORT_EXT,ESCORT_DRONE_HP,ESCORT_DRONE_MAXHP,get G(){return G;},get T3(){return T3;},set T3(v){setT3(v);},setBuild3D(fn){window.__build3D=fn;},dispatchClipEvents,get CLIP_EVENT_LOG(){return CLIP_EVENT_LOG;},fireClipFor,setTHREE(v){globalThis.THREE=v;},get setup(){return setup;},set myNation(v){myNation=v;},mkSquad(n){return DEFAULT_SQUADS[n].map(r=>({role:r,weapon:ROLES[r].weapons[0]}));}};';

  const magic = () => {
    const f = () => {};
    return new Proxy(f, {
      get: (t, p) => (p === Symbol.toPrimitive ? () => 0 : (p === 'then' || p === Symbol.iterator || p === 'catch' || p === 'finally') ? undefined : magic()),
      set: () => true,
      apply: () => magic(),
    });
  };
  const sb = {
    console, Math, JSON, Object, Array, String, Number, Boolean, Function,
    parseInt, parseFloat, isNaN, Date, RegExp, Error, TypeError, Promise,
    Symbol, Map, Set, WeakMap, Reflect, Proxy, encodeURIComponent, decodeURIComponent,
    Infinity, NaN, undefined,
    document: magic(),
    localStorage: { getItem: () => null, setItem: () => {}, removeItem: () => {} },
    sessionStorage: { getItem: () => null, setItem: () => {}, removeItem: () => {} },
    navigator: {},
    location: { search: '' },
    history: {},
    screen: { width: 1200, height: 1200 },
    innerWidth: 1200, innerHeight: 1200,
    matchMedia: () => ({ matches: false, addEventListener: () => {} }),
    requestAnimationFrame: () => 0, cancelAnimationFrame: () => {},
    setTimeout: fn => { fn(); return 0; }, clearTimeout: () => {},
    setInterval: () => 0, clearInterval: () => {},
    performance: { now: () => Date.now() },
    fetch: () => Promise.resolve({ ok: true, json: async () => ({}) }),
    Image: function () { return magic(); },
    scrollTo: () => {}, getComputedStyle: () => magic(),
    addEventListener: () => {}, removeEventListener: () => {},
  };
  sb.window = sb; sb.self = sb; sb.globalThis = sb;
  vm.createContext(sb);
  const modules = [
    'data/nations', 'data/weapons', 'data/roles', 'data/cast', 'data/campaign', 'data/maps', 'data/map-pieces', 'data/deployables', 'data/ui-copy', 'data/skin-names', 'data/catalog-competitive', 'bridge', 'ui/arcade-hud', 'ui/campaign-tally', 'ui/campaign-ui', 'ui/setup-preview', 'ui/ui-shell', 'ui/abilities', 'ui/unit-card', 'ui/arsenal', 'ui/barracks', 'ui/wiring', 'ui/glb-lab', 'game/board', 'game/combat', 'game/gadgets', 'game/missions', 'game/turn', 'game/ai-escort', 'game/ai', 'game/tutorial', 'game/input', 'game/chars', 'game/demo', 'game/keyboard', 'game/quick',
    'core/storage', 'core/rng', 'core/time', 'core/geometry', 'audio/sound',
    'render2d/tiles', 'render2d/board', 'render2d/sprites', 'render2d/fx', 'render3d/runtime', 'render3d/env', 'render3d/fx-arcade',
    'render3d/scene', 'render3d/gun', 'render3d/fallback-soldier', 'render3d/assets-real', 'render3d/assets-geo', 'render3d/assets-meshy', 'render3d/assets-weapons', 'render3d/gltf-loader', 'render3d/asset-cache', 'render3d/actor-glb', 'render3d/gun-pose', 'render3d/clips', 'render3d/retarget', 'render3d/soldiers', 'render3d/real-sprites', 'render3d/world-props', 'render3d/world', 'render3d/fx3d', 'render3d/camera3d', 'viewer/body-loader', 'viewer/card-stage', 'viewer/troop-cards', 'viewer/inspector'
  ];
  for (const name of modules) {
    const src = fs.readFileSync(path.join(__dirname, '..', 'src', name + '.js'), 'utf8')
      .replace(/^\s*import\s+[^;]+;\s*$/gm, '')
      .replace(/^export\s+/gm, '');
    const decls = [...src.matchAll(/^(async function|function|let|const|var)\s+([A-Za-z_$][\w$]*)/gm)]
      .map(m => ({ n: m[2], mutable: m[1] === 'let' || m[1] === 'var' }));
    const expose = decls.map(d => d.mutable
      ? 'Object.defineProperty(globalThis,"' + d.n + '",{configurable:true,get:()=>' + d.n + ',set:v=>{' + d.n + '=v;}});'
      : 'globalThis.' + d.n + '=' + d.n + ';').join('');
    vm.runInContext(src + '\n;' + expose, sb, { filename: 'src/' + name + '.js' });
  }
  vm.runInContext(code, sb, { filename: 'index.html' });
  return sb.__api;
}

test('authored gameplay models use viewer-compatible proportions, surfaces, textures, and gear', () => {
  const api = loadEngine();
  const style = api.gameplayModelPresentation('Artillero', true);
  assert.deepEqual(Array.from(style.scale), [1, 1, 1]);
  assert.equal(style.addRoleGear, false);
  assert.equal(style.preserveTexture, true);
  assert.equal(style.twoSided, true);
  assert.ok(style.emissiveIntensity > 0);
});

test('generic gameplay fallback retains role-specific proportions and gear', () => {
  const api = loadEngine();
  const style = api.gameplayModelPresentation('Artillero', false);
  assert.deepEqual(Array.from(style.scale), [1.3, 1.04, 1.22]);
  assert.equal(style.addRoleGear, true);
  assert.equal(style.preserveTexture, false);
  assert.equal(style.twoSided, false);
  assert.equal(style.emissiveIntensity, 0);
});

test('invalid rig bind matrices are recalculated while valid ones are preserved', () => {
  const api = loadEngine();
  const identity = () => [1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1];
  const rowMajorTranslation = x => [1, 0, 0, x, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1];
  class Matrix4 {
    constructor(elements = identity()) { this.elements = elements.slice(); }
    set(...v) {
      this.elements = [v[0], v[4], v[8], v[12], v[1], v[5], v[9], v[13],
        v[2], v[6], v[10], v[14], v[3], v[7], v[11], v[15]];
      return this;
    }
    clone() { return new Matrix4(this.elements); }
    multiply(other) {
      this.elements[12] += other.elements[12];
      this.elements[13] += other.elements[13];
      this.elements[14] += other.elements[14];
      return this;
    }
    invert() {
      this.elements[12] *= -1;
      this.elements[13] *= -1;
      this.elements[14] *= -1;
      return this;
    }
    determinant() { return 1; }
  }
  api.setTHREE({ Matrix4 });
  const bone = { matrixWorld: new Matrix4([1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 0, 0, 1]), updateMatrixWorld() {} };
  const data = { bones: [{ parent: -1 }], skinBones: [0], boneInverses: [rowMajorTranslation(-2)] };
  const valid = api.validatedRigBoneInverses(data, [bone]);
  assert.equal(valid[0].elements[12], -2);

  data.boneInverses = [rowMajorTranslation(-1)];
  const repaired = api.validatedRigBoneInverses(data, [bone]);
  assert.equal(repaired[0].elements[12], -2);
});

test('clip root keeps a rig root offset while following pelvis motion', () => {
  const api = loadEngine();
  const result = {};
  api.rootBonePositionForClip(
    { x: 0, y: 0.855, z: 0 },
    { x: 0, y: 0.2, z: 0 },
    { x: 0, y: 0.05, z: 0 },
    { x: 0, y: 0.1, z: 0 },
    result,
  );
  assert.deepEqual(result, { x: 0, y: 1.005, z: 0 });
});

test('clip quaternion sampling interpolates even when output aliases scratch', () => {
  const api = loadEngine();
  const track = { t: [0, 1], q: [[1, 0, 0, 0], [0, 0, 0, 1]] };
  const out = { x: 0, y: 0, z: 0, w: 0, set(x, y, z, w) { this.x = x; this.y = y; this.z = z; this.w = w; return this; } };
  api.sampleClipQuat(track, 0.5, out);
  assert.ok(Math.abs(out.x - Math.SQRT1_2) < 0.001);
  assert.ok(Math.abs(out.w - Math.SQRT1_2) < 0.001);
  assert.ok(Math.abs(Math.hypot(out.x, out.y, out.z, out.w) - 1) < 0.001);
});

test('screen state preserves a live game when returning to Play', () => {
  const api = loadEngine();
  assert.equal(api.screenStateFor('scr-play', { over: false }), 'playing');
  assert.equal(api.screenStateFor('scr-play', { over: true }), 'gameover');
  assert.equal(api.screenStateFor('scr-viewer', { over: false }), 'menu');
  assert.equal(api.screenStateFor('scr-nation', { over: false }), 'nation');
});

test('new matches reset tactical camera state', () => {
  const api = loadEngine();
  api.myNation = api.NATIONS[0];
  api.T3 = { cam: { yaw: 1.2, dist: 6, panX: 4, panZ: -3 } };
  api.setBuild3D(() => {});
  Object.assign(api.setup, { mode: 'eliminacion', fmt: 2, opp: 'local', map: 'almacen', difficulty: 'normal' });
  api.startGame(api.mkSquad(2), api.mkSquad(2));
  assert.deepEqual({ ...api.T3.cam }, { yaw: -0.4363, dist: 8.5, panX: 0, panZ: 0.35 });
});

test('2D board margins preserve tile hit testing across canvas aspect ratios', () => {
  const api = loadEngine();
  const square = api.classicBoardMetrics(960, 960);
  assert.deepEqual({ ...square }, { S: 72, offsetX: 48, offsetY: 48 });
  assert.deepEqual({ ...api.classicTileFromPoint(square.offsetX + square.S / 2, square.offsetY + square.S / 2, 960, 960) }, { x: 0, y: 0 });
  assert.equal(api.classicTileFromPoint(24, 480, 960, 960), null);
  const wide = api.classicBoardMetrics(1200, 960);
  assert.deepEqual({ ...api.classicTileFromPoint(wide.offsetX + 11.5 * wide.S, wide.offsetY + 11.5 * wide.S, 1200, 960) }, { x: 11, y: 11 });
});

test('3D viewer framing is based on model bounds rather than model category', () => {
  const api = loadEngine();
  assert.deepEqual({ ...api.viewerCenterOffset({ x: 2, y: -3, z: 4 }) }, { x: -2, y: 3, z: -4 });
  const base = api.fitViewerDistance({ x: 0.75, y: 1.02, z: 0.61 }, 36, 1.5);
  const larger = api.fitViewerDistance({ x: 1.5, y: 2.04, z: 1.22 }, 36, 1.5);
  assert.ok(base > 0);
  assert.ok(larger > base);
});

test('coverLevel directional levels (0/1/2/3) and isFlanked', () => {
  const api = loadEngine();
  api.myNation = api.NATIONS[0];
  Object.assign(api.setup, { mode: 'eliminacion', fmt: 2, opp: 'local', map: 'almacen', difficulty: 'normal' });
  api.startGame(api.mkSquad(2), api.mkSquad(2));
  const G = api.G;
  G.map.obstacles = [
    { x: 5, y: 4, type: 'wall', hp: 999, maxHp: 999 },
    { x: 4, y: 5, type: 'crate', hp: 50, maxHp: 50 },
    { x: 5, y: 6, type: 'crate', hp: 20, maxHp: 50 },
  ];
  const target = { x: 5, y: 5, facing: 0 }; // facing east (+X)
  assert.equal(api.coverLevel(target, { x: 5, y: 2 }), 3); // wall to north
  assert.equal(api.coverLevel(target, { x: 2, y: 5 }), 2); // intact crate to west
  assert.equal(api.coverLevel(target, { x: 5, y: 9 }), 1); // damaged crate to south
  assert.equal(api.coverLevel(target, { x: 8, y: 5 }), 0); // open east side
  assert.equal(api.isFlanked({ x: 2, y: 5 }, target), true);  // behind facing (+X vs -X)
  assert.equal(api.isFlanked({ x: 8, y: 5 }, target), false); // in front of facing
});

test('M18 smoke blocks cross-tile LOS but allows adjacent cheb<=1 fire', () => {
  const api = loadEngine();
  api.myNation = api.NATIONS[0];
  Object.assign(api.setup, { mode: 'eliminacion', fmt: 5, opp: 'local', map: 'patio', difficulty: 'normal' });
  api.startGame(api.mkSquad(5), api.mkSquad(5));
  const G = api.G;
  G.map.obstacles = [];
  const spy = G.units.find(u => u.team === 'A' && u.role === 'Espía');
  spy.x = 2; spy.y = 5; spy.energy = 10;
  api.throwSmoke(spy, 5, 5);
  assert.ok(G.smoke.length >= 4);
  assert.equal(api.smokeBlocksLOS({ x: 2, y: 5 }, { x: 8, y: 5 }), true);  // crosses smoked tile (5,5)
  assert.equal(api.smokeBlocksLOS({ x: 5, y: 5 }, { x: 6, y: 5 }), false); // adjacent cheb<=1 passes
  assert.equal(api.smokeBlocksLOS({ x: 2, y: 1 }, { x: 8, y: 1 }), false); // clear lane
});

test('M84 flashbang applies stun without damage and clears after stunned unit turn ends', () => {
  const api = loadEngine();
  api.myNation = api.NATIONS[0];
  Object.assign(api.setup, { mode: 'eliminacion', fmt: 4, opp: 'local', map: 'almacen', difficulty: 'normal' });
  api.startGame(api.mkSquad(4), api.mkSquad(4));
  const G = api.G;
  const cmd = G.units.find(u => u.team === 'A' && u.role === 'Comando');
  const foe = G.units.find(u => u.team === 'B');
  cmd.x = 3; cmd.y = 5; cmd.energy = 10;
  foe.x = 6; foe.y = 5; foe.overwatch = true;
  const hpBefore = foe.hp;
  api.throwFlash(cmd, 6, 5);
  assert.equal(foe.hp, hpBefore);
  assert.equal(foe.stunned, true);
  assert.equal(foe.overwatch, false);
  assert.equal(cmd.stunned, false);

  api.endTurn(); // begins B's turn: foe pays -6 energy penalty, stunFresh->false
  assert.equal(G.turn, 'B');
  assert.equal(foe.energy, foe.maxEnergy - 6);
  assert.equal(foe.stunned, true);

  api.endTurn(); // ends B's turn: stun clears
  assert.equal(G.turn, 'A');
  assert.equal(foe.stunned, false);
});

test('M18A1 Claymore ignores allies and Escort drone, detonates only on enemy step', () => {
  const api = loadEngine();
  api.myNation = api.NATIONS[0];
  Object.assign(api.setup, { mode: 'escolta', fmt: 4, opp: 'local', map: 'almacen', difficulty: 'normal' });
  api.startGame(api.mkSquad(4), api.mkSquad(4));
  const G = api.G;
  const eng = G.units.find(u => u.team === 'A' && u.role === 'Ingeniero');
  const ally = G.units.find(u => u.team === 'A' && u !== eng);
  const enemy = G.units.find(u => u.team === 'B');
  eng.x = 4; eng.y = 5; eng.energy = 10;
  ally.x = 0; ally.y = 0;
  api.placeMine(eng, 3, 5);
  assert.equal(G.mines.length, 1);

  ally.x = 3; ally.y = 5;
  const allyHp = ally.hp;
  api.checkMines(ally);
  assert.equal(ally.hp, allyHp);
  assert.equal(G.mines.length, 1);

  const droneHp = G.drone.hp;
  G.drone.x = 3; G.drone.y = 5;
  api.checkMines(G.drone);
  assert.equal(G.drone.hp, droneHp);
  assert.equal(G.mines.length, 1);

  enemy.x = 3; enemy.y = 5;
  const enemyHp = enemy.hp;
  api.checkMines(enemy);
  assert.equal(enemy.hp, enemyHp - 60);
  assert.equal(G.mines.length, 0);
});

test('Dominacion settles only at full round completion (_domRoundDone)', () => {
  const api = loadEngine();
  api.myNation = api.NATIONS[0];
  Object.assign(api.setup, { mode: 'dominacion', fmt: 4, opp: 'local', map: 'almacen', difficulty: 'normal' });
  api.startGame(api.mkSquad(4), api.mkSquad(4));
  const G = api.G;
  G.round = 5;
  G.dom.A = api.DOM_TARGET - 1;
  G.dom.B = api.DOM_TARGET - 1;
  // Team A holds Centro + Depósito -> +2 on next A turn start
  const [a0, a1] = G.units.filter(u => u.team === 'A');
  a0.x = 3; a0.y = 4;
  a1.x = 5; a1.y = 5;
  // Team B holds Muelle -> +1 on B turn start
  const [b0] = G.units.filter(u => u.team === 'B');
  b0.x = 8; b0.y = 7;

  // End A turn -> B scores +1 -> reaches DOM_TARGET (10), NOT over yet because round isn't done!
  api.endTurn();
  assert.equal(G.turn, 'B');
  assert.equal(G.dom.B, api.DOM_TARGET);
  assert.equal(G.over, false);

  // Move G.dom.A ahead to verify Team A wins when closing the round cleanly
  G.dom.A = api.DOM_TARGET + 1;
  api.endTurn();
  assert.equal(G.over, true);
  assert.equal(G.winner, 'A');
});

test('Escolta guarded drone reduces damage to 47% and wins on extraction', () => {
  const api = loadEngine();
  api.myNation = api.NATIONS[0];
  Object.assign(api.setup, { mode: 'escolta', fmt: 4, opp: 'local', map: 'almacen', difficulty: 'normal' });
  api.startGame(api.mkSquad(4), api.mkSquad(4));
  const G = api.G;
  G.units.forEach(u => { if (u.team === 'A') { u.x = 0; u.y = 0; } });
  G.drone.x = 5; G.drone.y = 5;
  const unguardedStart = G.drone.hp;
  api.damage(G.drone, 40, 'Prueba');
  assert.equal(unguardedStart - G.drone.hp, 40);

  // Escolta pegada -> dano reducido al 47 % (regla medida en F1)
  const guard = G.units.find(u => u.team === 'A');
  guard.x = 5; guard.y = 4;
  const guardedStart = G.drone.hp;
  api.damage(G.drone, 40, 'Prueba');
  assert.equal(guardedStart - G.drone.hp, Math.round(40 * 0.47));

  // Guide onto extraction tile -> Team A wins immediately
  G.units.forEach(u => { if (u.team === 'B') { u.x = 11; u.y = 11; } });
  G.drone.x = 9; G.drone.y = 5; G.drone.movesLeft = 2;
  guard.x = 9; guard.y = 4; guard.energy = 6;
  api.guideDrone(guard, 10, 5);
  assert.equal(G.over, true);
  assert.equal(G.winner, 'A');
});

test('crates give cover without blocking LOS; walls and shelves do', () => {
  const api = loadEngine();
  api.myNation = api.NATIONS[0];
  Object.assign(api.setup, { mode: 'eliminacion', fmt: 2, opp: 'local', map: 'almacen', difficulty: 'normal' });
  api.startGame(api.mkSquad(2), api.mkSquad(2));
  const G = api.G;
  const from = { x: 2, y: 5 }, to = { x: 8, y: 5 };
  G.map.obstacles = [{ x: 5, y: 5, type: 'crate', hp: 50, maxHp: 50 }];
  assert.equal(api.hasLOS(from, to), true);
  G.map.obstacles = [{ x: 5, y: 5, type: 'shelf', hp: 999, maxHp: 999 }];
  assert.equal(api.hasLOS(from, to), false);
});

test('damage accounting credits the source team and kills from area sources', () => {
  const api = loadEngine();
  api.myNation = api.NATIONS[0];
  Object.assign(api.setup, { mode: 'eliminacion', fmt: 2, opp: 'local', map: 'almacen', difficulty: 'normal' });
  api.startGame(api.mkSquad(2), api.mkSquad(2));
  const G = api.G;
  const foe = G.units.find(u => u.team === 'B');
  G.stats.A = { dmg: 0, kills: 0 };
  api.damage(foe, 20, 'M67', 'A');
  assert.equal(G.stats.A.dmg, 20);
  assert.equal(G.stats.A.kills, 0);
  foe.hp = 1;
  api.damage(foe, 20, 'M67', 'A');
  assert.equal(G.stats.A.kills, 1);
});

test('turn-start damage resolves victory before the next side moves', () => {
  const api = loadEngine();
  api.myNation = api.NATIONS[0];
  Object.assign(api.setup, { mode: 'eliminacion', fmt: 2, opp: 'local', map: 'almacen', difficulty: 'normal' });
  api.startGame(api.mkSquad(2), api.mkSquad(2));
  const G = api.G;
  const foes = G.units.filter(u => u.team === 'B');
  foes.slice(1).forEach(u => { u.alive = false; u.hp = 0; });
  const last = foes[0];
  last.alive = true; last.hp = 1; last.x = 5; last.y = 5;
  G.map.obstacles = [];
  G.smoke = [{ x: 5, y: 5, team: 'A', left: 2, kind: 'gas' }];
  api.endTurn();
  assert.equal(G.over, true);
  assert.equal(G.winner, 'A');
});

test('dead shooters cannot fire', () => {
  const api = loadEngine();
  api.myNation = api.NATIONS[0];
  Object.assign(api.setup, { mode: 'eliminacion', fmt: 2, opp: 'local', map: 'almacen', difficulty: 'normal' });
  api.startGame(api.mkSquad(2), api.mkSquad(2));
  const G = api.G;
  const shooter = G.units.find(u => u.team === 'A');
  const target = G.units.find(u => u.team === 'B');
  shooter.alive = false;
  assert.equal(api.tryShoot(shooter, target, 'M4A1', null), false);
});

test('weapon families select their authored firing clip', () => {
  const api = loadEngine();
  const clip = name => api.fireClipFor(name);
  assert.equal(clip('M1911'), 'fire1hHeavy');
  assert.equal(clip('Desert Eagle'), 'fire1hHeavy');
  assert.equal(clip('M9'), 'fire1h');
  assert.equal(clip('MP7'), 'fire1hBurst');
  assert.equal(clip('UMP45'), 'fire1hBurst');
  assert.equal(clip('KRISS Vector'), 'fire1hBurst');
  assert.equal(clip('MP5'), 'fireBurst');
  assert.equal(clip('M249 SAW'), 'fireBurst');
  assert.equal(clip('M134 Minigun'), 'fireMini');
  assert.equal(clip('Remington 870'), 'fireHeavy');
  assert.equal(clip('M40'), 'fireHeavy');
  assert.equal(clip('M110 SASS'), 'fire2h');
  assert.equal(clip('SVD Dragunov'), 'fire2h');
  assert.equal(clip('Mk 14 EBR'), 'fire2h');
  assert.equal(clip('PSG-1'), 'fire2h');
  assert.equal(clip('M203'), 'fireShoulder');
  assert.equal(clip('RPG-7'), 'fireShoulder');
  api.WEAPONS.Katana = { cat: 'Cuerpo a cuerpo' };
  assert.equal(clip('Katana'), 'fireMelee');
});

test('clip events fire once per crossing and reset when the clip rewinds', () => {
  const api = loadEngine();
  api.myNation = api.NATIONS[0];
  Object.assign(api.setup, { mode: 'eliminacion', fmt: 2, opp: 'local', map: 'almacen', difficulty: 'normal' });
  api.startGame(api.mkSquad(2), api.mkSquad(2));
  const un = api.G.units[0];
  const ud = {};
  const clip = { events: [{ f: 'PlayFoley', t: 0.1 }, { f: 'PlayWeaponFire', t: 0.5 }, { f: 'OnAnimEvent', i: 10, t: 0.5 }] };
  const before = api.CLIP_EVENT_LOG.length;
  api.dispatchClipEvents(un, ud, clip, 'fire2h', 0.2, 1000);
  assert.equal(api.CLIP_EVENT_LOG.length, before);
  api.dispatchClipEvents(un, ud, clip, 'fire2h', 0.6, 1010);
  let fired = api.CLIP_EVENT_LOG.slice(before).filter(e => e.f === 'PlayWeaponFire');
  assert.equal(fired.length, 1);
  assert.equal(ud._firePulse, 1);
  assert.equal(ud._flashPulse, 1);
  api.dispatchClipEvents(un, ud, clip, 'fire2h', 0.7, 1020);
  fired = api.CLIP_EVENT_LOG.slice(before).filter(e => e.f === 'PlayWeaponFire');
  assert.equal(fired.length, 1);
  api.dispatchClipEvents(un, ud, clip, 'fire2h', 0, 1030);
  api.dispatchClipEvents(un, ud, clip, 'fire2h', 0.6, 1040);
  fired = api.CLIP_EVENT_LOG.slice(before).filter(e => e.f === 'PlayWeaponFire');
  assert.equal(fired.length, 2);
});

test('cada bala de una rafaga tiene feedback propio y el dano se aplica en su evento', () => {
  const api = loadEngine();
  api.myNation = api.NATIONS[0];
  Object.assign(api.setup, { mode: 'eliminacion', fmt: 2, opp: 'local', map: 'almacen', difficulty: 'normal' });
  api.startGame(api.mkSquad(2), api.mkSquad(2));
  const un = api.G.units[0], foe = api.G.units.find(u => u.team === 'B'), ud = {};
  const clip = { events: [0.1, 0.2, 0.3].map(t => ({ f: 'OnAnimEvent', i: 10, t })) };
  un._shootT = 1000; un._shootW = 'MP5'; un._shootCat = 'Subfusiles';
  un._shootAt = { x: foe.x, y: foe.y }; un._shootTarget = foe;
  foe._visualDelayUntil = 9999; foe._pendingHit = null;
  un._pendingShot = { target: foe, w: api.WEAPONS.MP5, weaponName: 'MP5', dmg: 20, hit: true, crit: false, label: 'MP5', opts: {}, p: 100 };
  un._resolveShot = () => api.applyShotDamage(un);
  const before = api.CLIP_EVENT_LOG.length, hp = foe.hp;
  api.dispatchClipEvents(un, ud, clip, 'fireBurst', 0.15, 1100);
  assert.equal(api.CLIP_EVENT_LOG.slice(before).filter(e => e.f === 'OnAnimEvent' && e.i === 10).length, 1);
  assert.equal(foe.hp, hp - 20);
  api.dispatchClipEvents(un, ud, clip, 'fireBurst', 0.35, 1200);
  assert.equal(api.CLIP_EVENT_LOG.slice(before).filter(e => e.f === 'OnAnimEvent' && e.i === 10).length, 3);
  assert.equal(foe.hp, hp - 20);
});

test('el look arcade 3D usa paleta pop, exposición 1.12 y FX agrupados sin renderer extra', () => {
  const read = f => fs.readFileSync(path.join(__dirname, '..', 'src', f), 'utf8');
  const env = read('render3d/env.js');
  const cam = read('render3d/camera3d.js');
  const demo = read('game/demo.js');
  const arcade = read('render3d/fx-arcade.js');
  assert.match(env, /TEAM_A_HEX=0x00e5ff/);
  assert.match(env, /TEAM_B_HEX=0xff3d71/);
  assert.match(env, /SELECT_LIME_HEX=0xb8ff2c/);
  assert.match(cam, /toneMappingExposure=1\.12/);
  assert.match(demo, /toneMappingExposure=1\.12/);
  assert.match(cam, /new THREE\.DirectionalLight\(0x9fe8ff,0\.85\)/);
  assert.doesNotMatch(arcade, /new THREE\.WebGLRenderer/);
  assert.match(arcade, /REDUCED_MOTION/);
  assert.match(read('render3d/fx3d.js'), /tickArcadeFx\(w,h,FX\.t\)/);
});

test('la conversion 3D separa X y Z y el raycast respeta mapas no cuadrados', () => {
  const api = loadEngine();
  api.setBoardSize(23, 17);
  assert.deepStrictEqual({ ...api.boardCenter() }, { x: 11, y: 8 });
  assert.equal(api.w2cx(0), -11);
  assert.equal(api.w2cz(0), -8);
  for (const [x, y] of [[0, 0], [11, 8], [22, 16], [3, 15]]) {
    assert.deepStrictEqual({ ...api.tileFromWorldPoint(api.w2cx(x), api.w2cz(y)) }, { x, y });
  }
  assert.equal(api.tileFromWorldPoint(api.w2cx(-1), api.w2cz(0)), null);
  assert.equal(api.tileFromWorldPoint(api.w2cx(23), api.w2cz(16)), null);
  assert.deepStrictEqual({ ...api.camPanBounds() }, { x: 23 * 0.55, z: 17 * 0.55 });
  api.setBoardSize(11, 24);
  assert.deepStrictEqual({ ...api.boardCenter() }, { x: 5, y: 11.5 });
  assert.equal(api.w2cx(10), 5);
  assert.equal(api.w2cz(23), 11.5);
  assert.deepStrictEqual({ ...api.tileFromWorldPoint(api.w2cx(10), api.w2cz(23)) }, { x: 10, y: 23 });
  api.setBoardSize(12, 12);
});

test('el reparto resuelve cuerpo exacto, textura de cast y rechaza cuerpos sin malla propia', () => {
  const api = loadEngine();
  const rambo = api.bodySpecForUnit({ charName: 'Archie Fletcher', role: 'Artillero', name: 'Archie Fletcher' });
  assert.equal(rambo.file, 'Soldier_Light_Rambo.obj');
  assert.match(rambo.prefix, /bodies\/$/);
  assert.equal(rambo.texture, 'Soldier_Light_Rambo_DeerHunter_d.png');
  const commander = api.bodySpecForUnit({ charName: 'Commander (M)', role: 'Capitán' });
  assert.equal(commander.file, 'CommanderM.obj');
  const medic = api.bodySpecForUnit({ charName: 'Sister Florence', role: 'Médico' });
  assert.equal(medic.file, 'Medic.obj');
  const dave = api.bodySpecForUnit({ charName: 'Hipster Dave', role: 'Comando' });
  assert.equal(dave.file, 'Soldier_Light.obj');
  assert.equal(dave.texture, 'Soldier_Light_DeltaForce_d.png');
  const pete = api.bodySpecForUnit({ charName: 'Sneaky Pete', role: 'Francotirador' });
  assert.equal(pete.file, 'Agent.obj');
  assert.equal(pete.texture, 'Agent_d.png');
  const gus = api.bodySpecForUnit({ charName: 'Riot Medic', role: 'Médico' });
  assert.equal(gus.file, 'Medic_therapist_959v.obj');
  assert.equal(gus.texture, 'Medic_Heavy_d.png');
  const kate = api.bodySpecForUnit({ charName: 'Textbook Kate', role: 'Médico' });
  assert.equal(kate.file, 'Medic_therapist_1248v.obj');
  assert.equal(kate.texture, 'Medic_Therapist_d.png');
  assert.ok(api.REAL.byBody);
  assert.ok(api.REAL.bodyLoading);
});

test('el soldado prioriza actor GLB, malla propia, cuerpo del cast y finalmente el generico', () => {
  const read = f => fs.readFileSync(path.join(__dirname, '..', 'src', f), 'utf8');
  const src = read('render3d/soldiers.js');
  const glb = src.indexOf('if(un.glbActor&&un.glbActor.root)return makeGlbSoldier3(un);');
  const meshy = src.indexOf('const meshy=(!window.__forceBaseModel&&un.charMesh&&MESHY_MODELS[un.charMesh])||null;');
  const body = src.indexOf('const bodySpec=!meshy&&!window.__forceBaseModel?bodySpecForUnit(un):null;');
  const record = src.indexOf('const bodyRec=bodySpec&&REAL.byBody[bodySpec.key]?REAL.byBody[bodySpec.key]:null;');
  const model = src.indexOf('const RD=meshy||bodyRec||');
  const exact = src.indexOf('const exactTex=(meshy||bodyRec)&&castTex?castTex:null;');
  assert.ok(glb >= 0 && meshy > glb && body > meshy && record > body && model > record && exact > model);
  assert.match(src, /presentation\.preserveTexture\s*\?new THREE\.MeshStandardMaterial\(\{map:roleTex,roughness:0\.82,metalness:0\.02,side:materialSide\}\)/);
  assert.match(src, /if\(presentation\.emissiveIntensity>0\)\{/);
  assert.match(read('game/combat.js'), /ensureSquadBodies\(G\.units\)/);
});

test('baliza y torreta se dibujan solo en sus modos y las rejillas se precargan antes de desplegar', () => {
  const read = f => fs.readFileSync(path.join(__dirname, '..', 'src', f), 'utf8');
  const world = read('render3d/world.js');
  assert.match(world, /const drawBeacon3=mode3==='baliza'\|\|mode3==='dominacion'/);
  assert.match(world, /if\(mode3!=='dominacion'\)\{/);
  assert.match(world, /tileWorldY\(BEACON\[0\]\.x,BEACON\[0\]\.y\)\+0\.06/);
  assert.match(world, /tileWorldY\(TURRET_POS\.x,TURRET_POS\.y\)\+0\.06/);
  assert.match(world, /tileWorldY\(Math\.floor\(anchor\.x\),Math\.floor\(anchor\.y\)\)\+0\.07/);
  assert.match(read('game/missions.js'), /effMode\(G\)!=='dominacion'&&G\.map\.turret\.owner===ownerTeam/);
  assert.match(world, /w2cz\(/);
  assert.doesNotMatch(world, /w2cx\([^)]*\.y\)/);
  assert.match(read('game/board.js'), /if\(!gridsReady\)gridsReady=Promise\.all/);
  assert.match(read('game/quick.js'), /await preloadNativeGrids\(\)/);
  assert.match(read('main.js'), /async function deployMissionData/);
  assert.match(read('main.js'), /async function launchConfigured/);
});
