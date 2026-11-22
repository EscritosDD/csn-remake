'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const vm = require('node:vm');

const root = path.dirname(__dirname);
const html = require('./source');

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
vm.runInContext(extraerFn(html, 'parseOBJStatic') + '\nthis.parseOBJStatic = parseOBJStatic;', ctx);
const parseOBJ3 = ctx.parseOBJ3;
const parseOBJStatic = ctx.parseOBJStatic;

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

test('parseOBJStatic corrige winding negativo y recalcula normales', () => {
  const obj = [
    'v 0 0 0', 'v 1 0 0', 'v 0 1 0', 'v 0 0 1',
    'vt 0 0', 'vt 1 0', 'vt 0 1',
    'vn 0 0 1',
    'f 1/1/4 2/2/4 3/3/4',
    'f 1/1/4 4/2/4 2/3/4',
    'f 1/1/4 3/2/4 4/3/4',
    'f 2/1/4 4/2/4 3/3/4'
  ].join('\n');
  const m = metricas(parseOBJStatic(obj));
  assert.ok(m.volumen > 0, 'volumen firmado ' + m.volumen.toFixed(4));
  assert.ok(m.ratio > 0.9, 'normales alineadas ' + (m.ratio * 100).toFixed(1) + '%');
});

test('las 23 armas tienen volumen positivo con parseOBJStatic', () => {
  const dir = path.join(root, 'assets', 'weapons');
  const files = fs.readdirSync(dir).filter(f => f.toLowerCase().endsWith('.obj'));
  assert.equal(files.length, 23);
  for (const file of files) {
    const txt = fs.readFileSync(path.join(dir, file), 'latin1');
    const puntos = [];
    let degeneradas = 0;
    for (const linea of txt.split(/\r?\n/)) {
      const p = linea.trim().split(/\s+/);
      if (p[0] === 'v') puntos.push([+p[1], +p[2], +p[3]]);
      else if (p[0] === 'f') {
        const ids = p.slice(1).map(token => parseInt(token.split('/')[0], 10) - 1);
        const [a, b, c] = ids.map(i => puntos[i]);
        const ux = b[0] - a[0], uy = b[1] - a[1], uz = b[2] - a[2];
        const vx = c[0] - a[0], vy = c[1] - a[1], vz = c[2] - a[2];
        const nx = uy * vz - uz * vy, ny = uz * vx - ux * vz, nz = ux * vy - uy * vx;
        if (Math.sqrt(nx * nx + ny * ny + nz * nz) * 0.5 < 1e-8) degeneradas++;
      }
    }
    const geo = parseOBJStatic(txt);
    const m = metricas(geo);
    assert.equal(degeneradas, 0, file + ': ' + degeneradas + ' caras degeneradas');
    assert.ok(m.volumen > 0, file + ': volumen ' + m.volumen.toFixed(4));
    assert.ok(Array.from(geo.normal.array).every(Number.isFinite), file + ': normales no finitas');
  }
});

test('los sockets de mano se reflejan en X al acoplar el arma', () => {
  const sockets = JSON.parse(fs.readFileSync(path.join(root, 'assets', 'weapons', 'weapon_sockets.json'), 'utf8'));
  const pose = fs.readFileSync(path.join(root, 'src', 'render3d', 'gun-pose.js'), 'utf8');
  assert.ok(sockets.handRight.pos[0] > 0);
  assert.ok(sockets.handLeft.pos[0] > 0);
  assert.match(pose, /_gpPalmR\.x=-Math\.abs\(_gpPalmR\.x\)/);
  assert.match(pose, /_gpPalmL\.x=-Math\.abs\(_gpPalmL\.x\)/);
  assert.match(pose, /_gpRPalm\.copy\(_gpPalmR\)\.applyMatrix4\(bR\.matrixWorld\)/);
});

test('el RPG se gira 90 grados en X y mantiene el cañón horizontal', () => {
  const src = fs.readFileSync(path.join(root, 'src', 'render3d', 'assets-weapons.js'), 'utf8');
  assert.match(src, /if\(file==='RPG'\)return \{x:Math\.PI\/2,y:0,z:0\}/);
  assert.match(src, /mesh\.rotation\.set\(rot\.x,rot\.y,rot\.z\)/);
  assert.match(src, /holder\.rotation\.x=-Math\.PI\/2/);
  const txt = fs.readFileSync(path.join(root, 'assets', 'weapons', 'RPG.obj'), 'latin1');
  const geo = parseOBJStatic(txt);
  const puntos = geo.position.array;
  const min = [Infinity, Infinity, Infinity], max = [-Infinity, -Infinity, -Infinity];
  for (let i = 0; i < puntos.length; i += 3) {
    for (let eje = 0; eje < 3; eje++) { min[eje] = Math.min(min[eje], puntos[i + eje]); max[eje] = Math.max(max[eje], puntos[i + eje]); }
  }
  const size = max.map((n, eje) => n - min[eje]);
  assert.ok(size[1] > size[2], 'sección del RPG en el eje correcto: ' + size.map(n => n.toFixed(3)).join(' × '));
});

test('los 11 originales tienen rig de 20 huesos con pesos normalizados', () => {
  const dir = path.join(root, 'assets', 'soldier', 'bodies');
  const bodies = ['Soldier_SAS', 'Soldier_Spud', 'Soldier_Heavy', 'Soldier_Light_Rambo', 'Agent_Light',
    'Medic_therapist_1248v', 'Engineer_Light', 'Engineer_Heavy', 'Engineer_RiotCop', 'CommanderM', 'CommanderF'];
  for (const body of bodies) {
    const obj = fs.readFileSync(path.join(dir, body + '.obj'), 'latin1');
    const vertexCount = obj.split(/\r?\n/).filter(line => line.startsWith('v ')).length;
    const rig = JSON.parse(fs.readFileSync(path.join(dir, body + '_rig.json'), 'utf8'));
    assert.equal(rig.bones.length, 20, body + ': huesos');
    assert.deepEqual(rig.skinBones, [...Array(20).keys()], body + ': skinBones');
    assert.equal(rig.boneInverses.length, 20, body + ': inversas');
    assert.ok(rig.boneInverses.every(matrix => matrix.length === 16), body + ': inversas 4x4');
    assert.equal(rig.skinIndex.length, vertexCount * 4, body + ': skinIndex');
    assert.equal(rig.skinWeight.length, vertexCount * 4, body + ': skinWeight');
    for (let i = 0; i < rig.skinIndex.length; i++) assert.ok(rig.skinIndex[i] >= 0 && rig.skinIndex[i] < 20, body + ': hueso de piel fuera de rango');
    for (let i = 0; i < rig.skinWeight.length; i += 4) {
      const suma = rig.skinWeight.slice(i, i + 4).reduce((a, b) => a + b, 0);
      assert.ok(Math.abs(suma - 1) < 1e-3, body + ': pesos ' + suma);
    }
  }
});
