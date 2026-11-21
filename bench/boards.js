// bench/boards.js — Banco ejecutable de los 13 tableros (sin cambiar ningún número del juego).
//
// Qué hace: lee MAP_DEFS de index.html (los datos de mapa reales), replica
// los algoritmos exactos del juego (pathDist = BFS ignorando unidades, L1426;
// cheb, L1411) y mide, por tablero: casillas libres conectadas, pasos a la
// baliza desde el despliegue más cercano (A y B), ruta del dron hasta la
// casilla más cercana de la extracción, simetría 180° de las cinco familias
// de piezas y solapes. Al final coteja contra las dos tablas publicadas
// (la auditoría del 16/11 y la entrada de la página) para señalar dónde
// coinciden y dónde no.
//
// Uso:  node bench/boards.js
'use strict';
const fs = require('fs');
const path = require('path');

const html = fs.readFileSync(path.join(__dirname, '..', 'index.html'), 'utf8');

// --- 1. Extraer MAP_DEFS del juego (datos reales, no una copia) ---
const m = html.match(/const MAP_DEFS=(\{[\s\S]*?\n\});/);
if (!m) { console.error('FALLO: no se pudo extraer MAP_DEFS de index.html'); process.exit(1); }
const MAP_DEFS = eval('(' + m[1] + ')');

// --- 2. Constantes del juego (citas de línea en index.html) ---
const W = 12, H = 12;                                                       // L1039
const BEACON = [{x:5,y:5},{x:6,y:5},{x:5,y:6},{x:6,y:6}];                   // L1040
const ESCORT_START = {x:1,y:5};                                             // L771
const ESCORT_EXT = [{x:10,y:5},{x:11,y:5},{x:10,y:6},{x:11,y:6}];           // L772
const SPAWNS_A = [{x:0,y:3},{x:0,y:5},{x:1,y:6},{x:0,y:7},{x:0,y:6}];       // L1492
const SPAWNS_B = [{x:11,y:8},{x:11,y:6},{x:10,y:5},{x:11,y:4},{x:11,y:5}];  // L1493

// --- 3. Algoritmos exactos del juego ---
const key = (x, y) => x + ',' + y;
const cheb = (a, b) => Math.max(Math.abs(a.x - b.x), Math.abs(a.y - b.y));  // L1411

// obstáculos = walls + shelves + crates + barrels (el juego bloquea los barriles vivos)
function obstacles(def) {
  const s = new Set();
  for (const k of ['walls', 'shelves', 'crates', 'barrels']) for (const [x, y] of def[k]) s.add(key(x, y));
  return s;
}

// BFS ignorando unidades (idéntico a pathDist, L1426-1434)
function pathDist(obs, a, b) {
  if (a.x === b.x && a.y === b.y) return 0;
  const seen = new Set([key(a.x, a.y)]);
  let q = [{x: a.x, y: a.y, d: 0}];
  while (q.length) {
    const c = q.shift();
    for (const [dx, dy] of [[1,0],[-1,0],[0,1],[0,-1]]) {
      const nx = c.x + dx, ny = c.y + dy, k = key(nx, ny);
      if (nx < 0 || ny < 0 || nx >= W || ny >= H || seen.has(k) || obs.has(k)) continue;
      if (nx === b.x && ny === b.y) return c.d + 1;
      seen.add(k); q.push({x: nx, y: ny, d: c.d + 1});
    }
  }
  return 99;
}
function minDist(obs, from, to) {
  let best = 99;
  for (const a of from) for (const b of to) best = Math.min(best, pathDist(obs, a, b));
  return best;
}
// casillas libres conectadas: BFS desde una celda libre (sin wall/shelf/crate)
function connectedFree(obs) {
  let start = null;
  for (let y = 0; y < H && !start; y++) for (let x = 0; x < W; x++) if (!obs.has(key(x, y))) { start = {x, y}; break; }
  if (!start) return 0;
  const seen = new Set([key(start.x, start.y)]);
  let q = [start];
  while (q.length) {
    const c = q.shift();
    for (const [dx, dy] of [[1,0],[-1,0],[0,1],[0,-1]]) {
      const nx = c.x + dx, ny = c.y + dy, k = key(nx, ny);
      if (nx < 0 || ny < 0 || nx >= W || ny >= H || seen.has(k) || obs.has(k)) continue;
      seen.add(k); q.push({x: nx, y: ny, d: 0});
    }
  }
  return seen.size;
}
function sym180(list) {
  const s = new Set(list.map(([x, y]) => key(x, y)));
  if (s.size !== list.length) return 'dup';            // piezas repetidas dentro de la familia
  for (const [x, y] of list) if (!s.has(key(11 - x, 11 - y))) return 'no';
  return 'ok';
}

// --- 4. Medir los 13 tableros ---
const boards = Object.keys(MAP_DEFS).filter(k => MAP_DEFS[k] && Array.isArray(MAP_DEFS[k].walls));
const rows = [];
for (const id of boards) {
  const def = MAP_DEFS[id];
  const obs = obstacles(def);
  const libres = connectedFree(obs);
  const balA = minDist(obs, SPAWNS_A, BEACON);
  const balB = minDist(obs, SPAWNS_B, BEACON);
  const dron = minDist(obs, [ESCORT_START], ESCORT_EXT);
  const sim = ['walls','shelves','crates','barrels','medkits'].every(k => sym180(def[k]) === 'ok');
  const simDetail = ['walls','shelves','crates','barrels','medkits'].map(k => k[0] + ':' + sym180(def[k])).join(' ');
  // solapes entre todas las familias
  const cells = new Set();
  let overlaps = 0;
  for (const k of ['walls','shelves','crates','barrels','medkits']) for (const [x, y] of def[k]) { if (cells.has(key(x, y))) overlaps++; else cells.add(key(x, y)); }
  rows.push({id, libres, balA, balB, bal: Math.min(balA, balB), dron, sim, simDetail, overlaps});
}

console.log('=== MEDICIÓN EJECUTABLE (pathDist BFS sobre MAP_DEFS reales) ===');
console.log('Tablero        libres  balizaA  balizaB  dron  sim180  solapes  detalle');
for (const r of rows) {
  console.log(
    r.id.padEnd(15), String(r.libres).padEnd(7), String(r.balA).padEnd(8), String(r.balB).padEnd(8),
    String(r.dron).padEnd(5), (r.sim ? 'ok' : 'FALLA').padEnd(7), String(r.overlaps).padEnd(8), r.simDetail
  );
}

// --- 5. Cotejo contra las dos tablas publicadas ---
// Formato: [baliza, dron, libres]
const auditTable = {
  almacen: [11, 21, 114], patio: [8, 17, 118], skirmish01: [6, 11, 114], skirmish02: [6, 11, 114],
  skirmish: [7, 19, 116], skirmish04: [7, 13, 116], skirmish05: [7, 12, 114], skirmish06: [6, 12, 112],
  skirmish07: [6, 11, 114], skirmish08: [4, 11, 114], skirmish09: [6, 11, 114], skirmish10: [6, 11, 114], skirmish11: [6, 11, 114]
};
// Formato: [libres, baliza, dron]  (orden de la entrada de la página, L464)
const pageTable = {
  almacen: [114, 11, 22], patio: [118, 8, 17], skirmish01: [114, 6, 11], skirmish02: [114, 6, 11],
  skirmish: [116, 7, 15], skirmish04: [116, 6, 13], skirmish05: [114, 7, 12], skirmish06: [112, 6, 12],
  skirmish07: [114, 6, 11], skirmish08: [114, 4, 11], skirmish09: [114, 6, 11], skirmish10: [114, 6, 11], skirmish11: [114, 6, 11]
};
console.log('\n=== COTEJO CONTRA LAS TABLAS PUBLICADAS (medido = baliza/dron/libres) ===');
console.log('Tablero        medido            auditoría 16/11      página L464        veredicto');
for (const r of rows) {
  const mine = `${r.bal}/${r.dron}/${r.libres}`;
  const a = auditTable[r.id] ? `${auditTable[r.id][0]}/${auditTable[r.id][1]}/${auditTable[r.id][2]}` : '—';
  const p = pageTable[r.id] ? `${pageTable[r.id][1]}/${pageTable[r.id][2]}/${pageTable[r.id][0]}` : '—';
  const matchA = auditTable[r.id] && auditTable[r.id][0] === r.bal && auditTable[r.id][1] === r.dron && auditTable[r.id][2] === r.libres;
  const matchP = pageTable[r.id] && pageTable[r.id][1] === r.bal && pageTable[r.id][2] === r.dron && pageTable[r.id][0] === r.libres;
  const verdict = matchA ? (matchP ? 'ambas' : 'auditoría') : (matchP ? 'página' : 'NINGUNA');
  console.log(r.id.padEnd(15), mine.padEnd(17), a.padEnd(18), p.padEnd(18), verdict);
}
