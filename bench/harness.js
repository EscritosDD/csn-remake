// bench/harness.js — Harness IA contra IA sobre el motor real del juego.
//
// Carga el <script> inline de index.html en un contexto sin navegador (stubs),
// y juega partidas automáticas llamando a las funciones reales startGame /
// aiUnitAct / endTurn / checkWin. No reimplementa la lógica: usa el motor.
//
// Uso:
//   node bench/harness.js <modo> <mapa> <partidas> <formato>
//   modo: eliminacion | baliza | dominacion   (escolta aún no, IA asimétrica)
//   mapa: almacen | patio | skirmish | skirmish04 | ... (claves de MAP_DEFS)
//   partidas: número de simulaciones (def. 10)
//   formato: 2 | 4 | 5 (def. 4)
'use strict';
const fs = require('fs');
const path = require('path');
const vm = require('vm');

let code = fs.readFileSync(path.join(__dirname, '..', 'src', 'main.js'), 'utf8')
  .replace(/^\s*import\s+[^;]+;\s*$/gm, '');
if (!code) { console.error('No se encontró src/main.js'); process.exit(1); }
// Cortar el INIT final (construcción de DOM/red): no hace falta para la lógica.
const mark = '/* ================= INIT ================= */';
const i = code.indexOf(mark);
if (i >= 0) code = code.slice(0, i);

// Exportar la API del motor al sandbox (mismo ámbito léxico).
code += '\n;globalThis.__g={startGame,runAI,endTurn,aiUnitAct,checkWin,endGame,'
  + 'get G(){return G;},get setup(){return setup;},set myNation(v){myNation=v;},get myNation(){return myNation;},'
  + 'ROLES,BODIES,WEAPONS,DEFAULT_SQUADS,NATIONS,'
  + 'mkSquad(n){return DEFAULT_SQUADS[n].map(r=>({role:r,weapon:ROLES[r].weapons[0]}));}};';

// ---- Stub universal: objeto invocable que absorbe todo, coercible a 0/'' ----
function magic() {
  const fn = function () {};
  return new Proxy(fn, {
    get(t, p) {
      if (p === Symbol.toPrimitive) return (h) => (h === 'string' ? '' : 0);
      if (p === 'then' || p === Symbol.iterator || p === 'catch' || p === 'finally') return undefined;
      if (p === 'length') return 0;
      if (p === 'name') return 'stub';
      return magic();
    },
    set() { return true; },
    apply() { return magic(); },
    construct() { return magic(); },
    has() { return true; },
    ownKeys() { return []; },
    getOwnPropertyDescriptor() { return { configurable: true, enumerable: false }; },
  });
}
function fakeDoc() {
  const d = magic();
  return d;
}
function makeStore() {
  const s = Object.create(null);
  return { getItem: k => (k in s ? s[k] : null), setItem: (k, v) => { s[k] = String(v); }, removeItem: k => { delete s[k]; }, clear() { for (const k in s) delete s[k]; } };
}

const sandbox = {};
sandbox.window = sandbox;
sandbox.self = sandbox;
sandbox.globalThis = sandbox;
sandbox.console = console;
sandbox.Math = Math; sandbox.JSON = JSON; sandbox.Object = Object; sandbox.Array = Array;
sandbox.String = String; sandbox.Number = Number; sandbox.Boolean = Boolean; sandbox.Function = Function;
sandbox.parseInt = parseInt; sandbox.parseFloat = parseFloat; sandbox.isNaN = isNaN;
sandbox.Date = Date; sandbox.RegExp = RegExp; sandbox.Error = Error; sandbox.TypeError = TypeError;
sandbox.Promise = Promise; sandbox.Symbol = Symbol; sandbox.Map = Map; sandbox.Set = Set; sandbox.WeakMap = WeakMap;
sandbox.Reflect = Reflect; sandbox.Proxy = Proxy;
sandbox.encodeURIComponent = encodeURIComponent; sandbox.decodeURIComponent = decodeURIComponent;
sandbox.Infinity = Infinity; sandbox.NaN = NaN; sandbox.undefined = undefined;
sandbox.document = fakeDoc();
sandbox.localStorage = makeStore();
sandbox.sessionStorage = makeStore();
sandbox.navigator = { userAgent: 'node-harness', platform: 'node' };
sandbox.location = { href: '', search: '', hash: '', host: '', hostname: '', pathname: '/' };
sandbox.history = { pushState() {}, replaceState() {} };
sandbox.screen = { width: 1200, height: 1200 };
sandbox.innerWidth = 1200; sandbox.innerHeight = 1200;
sandbox.matchMedia = () => ({ matches: false, addEventListener() {}, removeEventListener() {}, addListener() {}, removeListener() {} });
sandbox.requestAnimationFrame = () => 0;
sandbox.cancelAnimationFrame = () => {};
sandbox.setTimeout = (fn, ms) => setTimeout(fn, 0);          // el retardo de la IA es cosmético
sandbox.clearTimeout = clearTimeout;
sandbox.setInterval = (fn, ms) => setInterval(fn, 1000000); // no debe usarse en lógica
sandbox.clearInterval = clearInterval;
sandbox.performance = { now: () => Date.now() };
sandbox.fetch = () => Promise.resolve({ ok: true, text: async () => '', json: async () => ({}), arrayBuffer: async () => new ArrayBuffer(0) });
sandbox.Image = function () { return magic(); };
sandbox.AudioContext = undefined; sandbox.webkitAudioContext = undefined;
// Métodos de window que el motor puede llamar en caliente
sandbox.scrollTo = () => {}; sandbox.scrollBy = () => {}; sandbox.scroll = () => {};
sandbox.getComputedStyle = () => magic(); sandbox.getSelection = () => magic();
sandbox.alert = () => {}; sandbox.confirm = () => true; sandbox.prompt = () => null;
sandbox.open = () => magic(); sandbox.close = () => {}; sandbox.focus = () => {};
sandbox.blur = () => {}; sandbox.print = () => {}; sandbox.stop = () => {};
sandbox.addEventListener = () => {}; sandbox.removeEventListener = () => {};
sandbox.dispatchEvent = () => true; sandbox.requestIdleCallback = () => 0;
sandbox.cancelIdleCallback = () => {}; sandbox.btoa = (s) => ''; sandbox.atob = (s) => '';

vm.createContext(sandbox);
const modules = [
  'data/nations', 'data/weapons', 'data/roles', 'data/cast', 'data/maps', 'data/map-pieces', 'data/deployables', 'data/ui-copy', 'data/skin-names', 'data/catalog-competitive', 'bridge', 'ui/ui-shell', 'ui/abilities', 'ui/unit-card', 'ui/arsenal', 'ui/barracks', 'ui/wiring', 'ui/glb-lab', 'game/board', 'game/combat', 'game/gadgets', 'game/missions', 'game/turn', 'game/ai-escort', 'game/ai', 'game/input', 'game/chars', 'game/demo', 'game/keyboard', 'game/quick',
  'core/storage', 'core/rng', 'core/time', 'core/geometry', 'audio/sound',
  'render2d/tiles', 'render2d/board', 'render2d/sprites', 'render2d/fx', 'render3d/runtime',
  'render3d/scene', 'render3d/gun', 'render3d/fallback-soldier', 'render3d/assets-real', 'render3d/assets-geo', 'render3d/assets-meshy', 'render3d/env', 'render3d/assets-weapons', 'render3d/gltf-loader', 'render3d/asset-cache', 'render3d/actor-glb', 'render3d/gun-pose', 'render3d/clips', 'render3d/retarget', 'render3d/soldiers', 'render3d/real-sprites', 'render3d/world-props', 'render3d/world', 'render3d/fx3d', 'render3d/camera3d', 'viewer/card-stage', 'viewer/troop-cards', 'viewer/inspector'
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
  vm.runInContext(src + '\n;' + expose, sandbox, { filename: 'src/' + name + '.js' });
}
vm.runInContext(code, sandbox, { filename: 'src/main.js' });
const g = sandbox.__g;

// ---- Driver de partida (ambos bandos por IA, dificultad simétrica) ----
function hpSum(team) {
  let s = g.G.units.filter(x => x.alive && x.team === team).reduce((a, x) => a + x.hp, 0);
  if (team === 'A' && g.G.drone && g.G.drone.alive) s += g.G.drone.hp;
  return s;
}
async function playTeam(team, stats) {
  const foe = team === 'A' ? 'B' : 'A';
  const units = g.G.units.filter(u => u.alive && u.team === team);
  for (const u of units) {
    if (g.G.over) break;
    const dmg0 = hpSum(foe);
    const alive0 = g.G.units.filter(x => x.alive && x.team === foe).length;
    g.G.selected = u;
    await g.aiUnitAct(u);
    const dmg1 = hpSum(foe);
    const alive1 = g.G.units.filter(x => x.alive && x.team === foe).length;
    if (stats) {
      const k = team + ':' + u.role;
      stats[k] = stats[k] || { dmg: 0, kills: 0, acts: 0 };
      stats[k].acts++;
      stats[k].dmg += Math.max(0, dmg0 - dmg1);
      stats[k].kills += Math.max(0, alive0 - alive1);
    }
  }
}
async function oneGame(mode, map, fmt) {
  const stats = {};
  g.myNation = g.NATIONS[0];
  Object.assign(g.setup, { mode, fmt, opp: 'local', rivalNation: null, skinA: 'nacion', skinB: 'nacion', map, difficulty: 'normal', campaignMission: 0 });
  g.startGame(g.mkSquad(fmt), g.mkSquad(fmt));
  let guard = 0;
  while (!g.G.over && guard++ < 400) {
    const team = g.G.turn;
    await playTeam(team, stats);
    if (g.G.over) break;
    g.endTurn();
  }
  const G = g.G;
  return {
    winner: G.winner, rounds: G.round, over: G.over,
    hpA: G.units.filter(u => u.team === 'A' && u.alive).reduce((s, u) => s + u.hp, 0),
    hpB: G.units.filter(u => u.team === 'B' && u.alive).reduce((s, u) => s + u.hp, 0),
    domA: G.dom ? G.dom.A : null, domB: G.dom ? G.dom.B : null,
    dronePos: G.drone ? (G.drone.x + ',' + G.drone.y) : null,
    droneDelivered: G.drone ? G.drone.delivered : null,
    droneAlive: G.drone ? G.drone.alive : null,
    log: G.log ? G.log.slice(-80) : null,
    stats,
  };
}

async function main() {
  const mode = process.argv[2] || 'eliminacion';
  const map = process.argv[3] || 'almacen';
  const games = Math.max(1, +(process.argv[4] || 10));
  const fmt = [2, 4, 5].includes(+(process.argv[5])) ? +(process.argv[5]) : 4;
  const wins = { A: 0, B: 0, draw: 0, guard: 0 };
  const roleTotals = {};
  let totalRounds = 0;
  console.log(`Harness IA-vs-IA · modo=${mode} mapa=${map} formato=${fmt}v${fmt} partidas=${games}`);
  for (let n = 1; n <= games; n++) {
    const r = await oneGame(mode, map, fmt);
    const w = r.over ? (r.winner || 'draw') : 'guard';
    wins[w] = (wins[w] || 0) + 1;
    totalRounds += r.rounds;
    if (r.stats) for (const k in r.stats) { const t = roleTotals[k] = roleTotals[k] || { dmg: 0, kills: 0, acts: 0 }; t.dmg += r.stats[k].dmg; t.kills += r.stats[k].kills; t.acts += r.stats[k].acts; }
    if (process.argv[6] === 'log' && r.log) {
      const drones = r.log.filter(l => /dron|escolta|Dron|Escolta/i.test(l));
      if (drones.length) console.log('   LOG DRON:\n    ' + drones.join('\n    '));
    }
    console.log(`  #${String(n).padStart(3)} ${String(w).padEnd(6)} rondas=${String(r.rounds).padEnd(3)} hpA=${String(r.hpA).padEnd(4)} hpB=${String(r.hpB).padEnd(4)}${r.domA != null ? ` domA=${r.domA} domB=${r.domB}` : ''}${r.dronePos != null ? ` dron=${r.dronePos} entregado=${r.droneDelivered} vivo=${r.droneAlive}` : ''}`);
  }
  console.log('---');
  console.log(`  Victorias A: ${wins.A} · B: ${wins.B} · empates: ${wins.draw} · sin resolver: ${wins.guard || 0}`);
  console.log(`  Rondas medias por partida: ${(totalRounds / games).toFixed(1)}`);
  if (process.argv[6] === 'roles' || process.argv[7] === 'roles') {
    console.log('  --- efectividad por rol (dano total / kills / acciones) ---');
    Object.entries(roleTotals).sort((a, b) => b[1].dmg - a[1].dmg).forEach(([k, v]) => console.log(`    ${k.padEnd(22)} dmg=${String(v.dmg).padEnd(6)} kills=${String(v.kills).padEnd(3)} act=${v.acts} media=${(v.dmg / Math.max(1, v.acts)).toFixed(1)}`));
  }
}

main().then(() => process.exit(0)).catch(e => { console.error('ERROR:', e); process.exit(1); });
