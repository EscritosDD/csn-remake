'use strict';
/* Test de las MALLAS de clase y del rig base (F4): la receta del examen
   (§11) convertida en aserciones. Comprueba, sin navegador:
   1. las 7 mallas de clase existen (obj/rig/tex) y sus OBJ tienen
      vertices y caras;
   2. cada rig de clase tiene EXACTAMENTE los huesos del rig base en el
      MISMO orden (los clips se aplican por indice: pack.bones[i] ->
      bones[i]); el Comando (Agent_Heavy) es la excepcion documentada
      (17 huesos, CLASS_MODEL_SKIP);
   3. el rig base y las bind poses cuadran: boneWorld x boneInverse ~ I
      no se puede verificar sin three, pero el orden de nombres si;
   4. las escalas de soldier_scales.json estan en rango y todas las
      mallas comparten la altura normalizada (la escala va horneada);
   5. parseOBJ3 niega la X: los OBJ de clase ya salen espejados y por
      eso el rig espejado (pos -x, quat x/-y/-z/w) no debe existir dos
      veces — solo se verifica que la malla base y las de clase usan el
      mismo formato (v x y z) con caras f con indice valido.

   Uso: node bench/meshes.test.js
*/
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');

const ROOT = path.join(__dirname, '..');

const FILES = ['Francotirador', 'Artillero', 'Espia', 'Medico', 'Ingeniero', 'Comando', 'Capitan'];
const ROLES = ['Francotirador', 'Artillero', 'Espía', 'Médico', 'Ingeniero', 'Comando', 'Capitán'];

function readObj(p) {
  const txt = fs.readFileSync(p, 'utf8');
  let v = 0, f = 0, maxIdx = 0, minIdx = Infinity;
  for (const ln of txt.split('\n')) {
    if (ln.startsWith('v ')) v++;
    else if (ln.startsWith('f ')) {
      f++;
      for (const part of ln.slice(2).trim().split(/\s+/)) {
        const i = parseInt(part.split('/')[0], 10);
        if (!isNaN(i)) { maxIdx = Math.max(maxIdx, i); minIdx = Math.min(minIdx, i); }
      }
    }
  }
  return { v, f, maxIdx, minIdx };
}

test('las 7 mallas de clase existen y sus OBJ tienen geometría válida', () => {
  for (const f of FILES) {
    const p = path.join(ROOT, 'assets', 'soldier', f + '.obj');
    const o = readObj(p);
    assert.ok(o.v > 500, f + ': pocos vértices (' + o.v + ')');
    assert.ok(o.f > 1000, f + ': pocas caras (' + o.f + ')');
    assert.ok(o.minIdx >= 1, f + ': índice de cara < 1');
    assert.ok(o.maxIdx <= o.v, f + ': cara indexa vértice inexistente (' + o.maxIdx + ' > ' + o.v + ')');
  }
});

test('los rigs de clase comparten huesos y orden con el rig base (salvo Comando)', () => {
  const base = JSON.parse(fs.readFileSync(path.join(ROOT, 'assets', 'soldier_rig.json'), 'utf8'));
  const baseNames = base.bones.map(b => b.name);
  assert.ok(baseNames.length >= 20, 'rig base con menos de 20 huesos');
  for (const f of FILES) {
    const rig = JSON.parse(fs.readFileSync(path.join(ROOT, 'assets', 'soldier', f + '_rig.json'), 'utf8'));
    const names = rig.bones.map(b => b.name);
    if (f === 'Comando') {
      /* Agent_Heavy: su rig original traia 17 huesos y una bind que no
         cerraba (residuo 90°/escala 1,283); §11 lo resolvio con
         boneInverses autoconstantes y el rig reextraido ya trae los 20
         huesos del rig base. CLASS_MODEL_SKIP esta vacio: el Comando
         usa su malla de clase. Se exige lo mismo que las demas. */
      assert.equal(names.length, baseNames.length, 'Comando: huesos ' + names.length + ' != base ' + baseNames.length);
      assert.deepEqual(names, baseNames, 'Comando: orden de huesos distinto al rig base');
    } else {
      assert.equal(names.length, baseNames.length, f + ': huesos ' + names.length + ' != base ' + baseNames.length);
      assert.deepEqual(names, baseNames, f + ': orden de huesos distinto al rig base');
    }
  }
});

test('rigs con la estructura que espera el juego (pos/quat/skinBones/boneInverses)', () => {
  const rigs = [path.join(ROOT, 'assets', 'soldier_rig.json')]
    .concat(FILES.map(f => path.join(ROOT, 'assets', 'soldier', f + '_rig.json')));
  for (const p of rigs) {
    const r = JSON.parse(fs.readFileSync(p, 'utf8'));
    assert.ok(Array.isArray(r.bones) && r.bones.length > 0, p + ': sin bones');
    for (const b of r.bones) {
      assert.ok(Array.isArray(b.pos) && b.pos.length === 3, p + ': hueso sin pos xyz');
      assert.ok(Array.isArray(b.quat) && b.quat.length === 4, p + ': hueso sin quat');
      assert.ok(typeof b.parent === 'number' && b.parent < r.bones.length, p + ': parent fuera de rango');
    }
    assert.ok(Array.isArray(r.skinBones) && r.skinBones.length > 0, p + ': sin skinBones');
    assert.ok(Array.isArray(r.boneInverses) && r.boneInverses.length === r.skinBones.length,
      p + ': boneInverses != skinBones');
    for (const m of r.boneInverses) {
      assert.ok(Array.isArray(m) && m.length === 16, p + ': boneInverse sin 16 elementos');
    }
  }
});

test('escalas de clase en rango y altura horneada común', () => {
  const scales = JSON.parse(fs.readFileSync(path.join(ROOT, 'assets', 'soldier_scales.json'), 'utf8'));
  for (const f of FILES) assert.ok(scales[f] > 0.2 && scales[f] < 2, 'escala rara para ' + f + ': ' + scales[f]);
  /* la escala de clase va horneada en los vértices: todas las mallas
     comparten la misma altura normalizada (Z) tras hornear */
  let zs = null;
  for (const f of FILES) {
    let min = Infinity, max = -Infinity;
    for (const ln of fs.readFileSync(path.join(ROOT, 'assets', 'soldier', f + '.obj'), 'utf8').split('\n')) {
      if (ln.startsWith('v ')) {
        const z = parseFloat(ln.split(/\s+/)[3]);
        min = Math.min(min, z); max = Math.max(max, z);
      }
    }
    const h = max - min;
    if (zs === null) zs = h;
    else assert.ok(Math.abs(h - zs) < 0.01, f + ': altura horneada ' + h.toFixed(4) + ' != ' + zs.toFixed(4));
  }
});

test('los clips existen y cubren los huesos por nombre', () => {
  const pack = JSON.parse(fs.readFileSync(path.join(ROOT, 'assets', 'soldier_clips.json'), 'utf8'));
  const clips = pack.clips;
  assert.ok(clips && typeof clips === 'object', 'pack sin clips');
  const keys = Object.keys(clips);
  assert.ok(keys.length >= 20, 'faltan clips (hay ' + keys.length + ')');
  assert.ok(pack.rootScale > 0.3 && pack.rootScale < 1, 'rootScale fuera de rango: ' + pack.rootScale);
  const base = JSON.parse(fs.readFileSync(path.join(ROOT, 'assets', 'soldier_rig.json'), 'utf8'));
  const names = new Set(base.bones.map(b => b.name));
  for (const k of keys) {
    const c = clips[k];
    assert.ok(c.dur > 0, k + ': clip sin duración');
    for (const bone of Object.keys(c.rot || {})) {
      assert.ok(names.has(bone), k + ': clip con hueso ajeno al rig base: ' + bone);
    }
  }
  /* los clips que usa el motor por nombre clave existen */
  for (const need of ['idle2h', 'walk2h', 'fire2h', 'hit']) {
    assert.ok(clips[need], 'clip requerido por el motor ausente: ' + need);
  }
});
