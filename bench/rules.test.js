'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const vm = require('node:vm');

function loadEngine() {
  const html = fs.readFileSync(path.join(__dirname, '..', 'index.html'), 'utf8');
  let code = (html.match(/<script(?![^>]*\bsrc=)[^>]*>([\s\S]*?)<\/script>/i) || [])[1];
  assert.ok(code, 'inline script must exist in index.html');
  const mark = '/* ================= INIT ================= */';
  const idx = code.indexOf(mark);
  assert.ok(idx > 0, 'INIT marker must exist');
  code = code.slice(0, idx);
  code += '\n;globalThis.__api={startGame,endTurn,checkWin,coverLevel,isFlanked,hasLOS,smokeBlocksLOS,throwSmoke,placeMine,checkMines,throwFlash,damage,guideDrone,scoreDominationFor,domControl,ROLES,WEAPONS,NATIONS,DOM_ZONES,DOM_TARGET,ESCORT_EXT,ESCORT_DRONE_HP,ESCORT_DRONE_MAXHP,get G(){return G;},get setup(){return setup;},set myNation(v){myNation=v;},mkSquad(n){return DEFAULT_SQUADS[n].map(r=>({role:r,weapon:ROLES[r].weapons[0]}));}};';

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
  vm.runInContext(code, sb, { filename: 'index.html' });
  return sb.__api;
}

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
  api.placeMine(eng, 4, 4);
  assert.equal(G.mines.length, 1);

  ally.x = 4; ally.y = 4;
  const allyHp = ally.hp;
  api.checkMines(ally);
  assert.equal(ally.hp, allyHp);
  assert.equal(G.mines.length, 1);

  const droneHp = G.drone.hp;
  G.drone.x = 4; G.drone.y = 4;
  api.checkMines(G.drone);
  assert.equal(G.drone.hp, droneHp);
  assert.equal(G.mines.length, 1);

  enemy.x = 4; enemy.y = 4;
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
