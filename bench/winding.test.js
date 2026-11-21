'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const vm = require('node:vm');

const root = path.dirname(__dirname);
const html = fs.readFileSync(path.join(root, 'index.html'), 'utf8');

function extraerFn(src, nombre) {
  const inicio = src.indexOf('function ' + nombre + '(');
  assert.notEqual(inicio, -1, 'no existe ' + nombre);
  let i = src.indexOf('{', inicio);
  let depth = 0;
  let quote = null;
  let escape = false;
  for (; i < src.length; i++) {
    const c = src[i];
    if (quote) {
      if (escape) escape = false;
      else if (c === '\\') escape = true;
      else if (c === quote) quote = null;
      continue;
    }
    if (c === "'" || c === '"' || c === '`') { quote = c; continue; }
    if (c === '{') depth++;
    else if (c === '}') {
      depth--;
      if (depth === 0) return src.slice(inicio, i + 1);
    }
  }
  throw new Error('llaves desbalanceadas en ' + nombre);
}

class Attr {
  constructor(array, itemSize) { this.array = array; this.itemSize = itemSize; }
}
class Geometry {
  setAttribute(name, attr) { this[name] = attr; }
  setIndex(index) { this.index = { array: index }; }
  computeVertexNormals() {
    const pos = this.position.array;
    const idx = this.index.array;
    const nor = new Float32Array(pos.length);
    for (let i = 0; i < idx.length; i += 3) {
      const a = idx[i] * 3, b = idx[i + 1] * 3, c = idx[i + 2] * 3;
      const ux = pos[b] - pos[a], uy = pos[b + 1] - pos[a + 1], uz = pos[b + 2] - pos[a + 2];
      const vx = pos[c] - pos[a], vy = pos[c + 1] - pos[a + 1], vz = pos[c + 2] - pos[a + 2];
      const nx = uy * vz - uz * vy, ny = uz * vx - ux * vz, nz = ux * vy - uy * vx;
      for (const o of [a, b, c]) { nor[o] += nx; nor[o + 1] += ny; nor[o + 2] += nz; }
    }
    for (let i = 0; i < nor.length; i += 3) {
      const len = Math.hypot(nor[i], nor[i + 1], nor[i + 2]) || 1;
      nor[i] /= len; nor[i + 1] /= len; nor[i + 2] /= len;
    }
    this.normal = new Attr(nor, 3);
  }
}
const ctx = { THREE: { BufferGeometry: Geometry, Float32BufferAttribute: Attr } };
vm.createContext(ctx);
vm.runInContext(extraerFn(html, 'parseOBJ3') + '\nthis.parseOBJ3 = parseOBJ3;', ctx);
const parseOBJ3 = ctx.parseOBJ3;

function metricas(geo) {
  const pos = geo.position.array;
  const nor = geo.normal.array;
  const idx = geo.index.array;
  let volumen = 0;
  let alineadas = 0;
  let total = 0;
  for (let i = 0; i < idx.length; i += 3) {
    const a = idx[i] * 3;
    const b = idx[i + 1] * 3;
    const c = idx[i + 2] * 3;
    const ax = pos[a], ay = pos[a + 1], az = pos[a + 2];
    const bx = pos[b], by = pos[b + 1], bz = pos[b + 2];
    const cx = pos[c], cy = pos[c + 1], cz = pos[c + 2];
    volumen += (ax * (by * cz - bz * cy) - ay * (bx * cz - bz * cx) + az * (bx * cy - by * cx)) / 6;
    const ux = bx - ax, uy = by - ay, uz = bz - az;
    const vx = cx - ax, vy = cy - ay, vz = cz - az;
    const nx = uy * vz - uz * vy;
    const ny = uz * vx - ux * vz;
    const nz = ux * vy - uy * vx;
    const mx = (nor[a] + nor[b] + nor[c]) / 3;
    const my = (nor[a + 1] + nor[b + 1] + nor[c + 1]) / 3;
    const mz = (nor[a + 2] + nor[b + 2] + nor[c + 2]) / 3;
    if (nx * mx + ny * my + nz * mz > 0) alineadas++;
    total++;
  }
  return { volumen, ratio: alineadas / total };
}

function archivosOBJ(dir) {
  const encontrados = [];
  for (const entrada of fs.readdirSync(dir, { withFileTypes: true })) {
    const ruta = path.join(dir, entrada.name);
    if (entrada.isDirectory()) encontrados.push(...archivosOBJ(ruta));
    else if (entrada.name.toLowerCase().endsWith('.obj')) encontrados.push(ruta);
  }
  return encontrados;
}

const modelos = [
  ['soldier', 'assets', 'soldier.obj'],
  ['Artillero', 'assets', 'soldier', 'Artillero.obj'],
  ['Capitan', 'assets', 'soldier', 'Capitan.obj'],
  ['Comando', 'assets', 'soldier', 'Comando.obj'],
  ['Espia', 'assets', 'soldier', 'Espia.obj'],
  ['Francotirador', 'assets', 'soldier', 'Francotirador.obj'],
  ['Ingeniero', 'assets', 'soldier', 'Ingeniero.obj'],
  ['Medico', 'assets', 'soldier', 'Medico.obj']
];

for (const [nombre, ...ruta] of modelos) {
  test(nombre + ': winding hacia fuera tras reflejar X', () => {
    const txt = fs.readFileSync(path.join(root, ...ruta), 'utf8');
    const nv = txt.split('\n').reduce((n, l) => n + (/^v\s/.test(l.trim()) ? 1 : 0), 0);
    const skin = { skinIndex: new Array(nv * 4).fill(0), skinWeight: new Array(nv * 4).fill(0) };
    const geo = parseOBJ3(txt, skin);
    const m = metricas(geo);
    assert.ok(m.volumen > 0, 'volumen firmado ' + m.volumen.toFixed(3));
    assert.ok(m.ratio > 0.9, 'normales alineadas ' + (m.ratio * 100).toFixed(1) + '%');
  });
}

test('todos los OBJ: caras, coordenadas finitas y volumen calculable', () => {
  const fallos = [];
  for (const archivo of archivosOBJ(path.join(root, 'assets'))) {
    const txt = fs.readFileSync(archivo, 'latin1');
    const lineas = txt.split(/\r?\n/);
    const nv = lineas.reduce((n, l) => n + (/^v\s/.test(l.trim()) ? 1 : 0), 0);
    const nf = lineas.reduce((n, l) => n + (/^f\s/.test(l.trim()) ? 1 : 0), 0);
    if (!nf) { fallos.push(path.relative(root, archivo) + ': sin caras'); continue; }
    if (!nv) { fallos.push(path.relative(root, archivo) + ': sin vértices'); continue; }
    const geo = parseOBJ3(txt, { skinIndex: new Array(nv * 4).fill(0), skinWeight: new Array(nv * 4).fill(0) });
    if (!geo.position || !geo.index || geo.index.array.length < 3) {
      fallos.push(path.relative(root, archivo) + ': geometría vacía');
      continue;
    }
    if (Array.from(geo.position.array).some(v => !Number.isFinite(v))) {
      fallos.push(path.relative(root, archivo) + ': coordenadas no finitas');
      continue;
    }
    const m = metricas(geo);
    if (!Number.isFinite(m.volumen)) fallos.push(path.relative(root, archivo) + ': volumen no finito');
  }
  assert.deepEqual(fallos, []);
});

test('Hipster Dave: arma acoplada a la mano en el visor', () => {
  assert.match(html, /makeViewerRiggedModel\(source\.geo\.clone\(\),source\.data,texture,\{animatable:true,grip:true\}\)/);
});

test('updateHover3D: cobertura sin ReferenceError', () => {
  assert.match(html, /cls=covLvl>0\?'cov':'';/);
  assert.doesNotMatch(html, /cls=cov\?'cov':'';/);
});
