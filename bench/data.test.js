'use strict';
/* Integridad de DATOS del juego: personajes, naciones, skins, misiones y
   voces. No carga el motor (para eso esta rules.test.js): comprueba que los
   catalogos del original y los anadidos no se desincronicen.

   Uso: node bench/data.test.js
*/
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');

const ROOT = path.join(__dirname, '..');
const html = fs.readFileSync(path.join(ROOT, 'index.html'), 'utf8');

function block(marker, endMark) {
  const i = html.indexOf(marker);
  assert.ok(i >= 0, 'marcador no encontrado: ' + marker);
  const j = html.indexOf(endMark, i);
  assert.ok(j > i, 'cierre no encontrado para ' + marker);
  return html.slice(i, j);
}

test('12 naciones con personalidad propia', () => {
  const b = block('const NATIONS=[', '];');
  const ids = [...b.matchAll(/\{id:'([a-z]{2})'/g)].map(m => m[1]);
  assert.equal(ids.length, 12, 'deben ser 12 naciones');
  const pers = [...b.matchAll(/pers:\{name:'([^']+)'/g)].map(m => m[1]);
  assert.equal(pers.length, 12, 'cada nacion debe tener personalidad');
  for (const p of pers) assert.ok(p.length > 2, 'personalidad vacia');
});

test('reparto: 17 personajes del original y 12 propios', () => {
  const orig = block('const ORIG_CAST=[', '];');
  const own = block('const OWN_CAST=[', '];');
  const nOrig = (orig.match(/\{name:'/g) || []).length;
  const nOwn = (own.match(/\{name:'/g) || []).length;
  assert.equal(nOrig, 17, 'deben ser 17 personajes del IPA');
  assert.equal(nOwn, 12, 'deben ser 12 personajes propios');
  for (const m of own.matchAll(/role:'([^']+)'/g)) {
    assert.ok(['Francotirador', 'Artillero', 'Espía', 'Médico', 'Ingeniero', 'Comando', 'Capitán'].includes(m[1]), 'rol invalido: ' + m[1]);
  }
});

test('tres skins y todas sin pasivas', () => {
  const b = block('const SKINS={', '};');
  const keys = [...b.matchAll(/\n ([a-z]+):\{name:/g)].map(m => m[1]);
  assert.deepEqual(keys.sort(), ['clase', 'estandar', 'nacion'], 'skins: ' + keys.join(','));
  assert.equal((b.match(/Sin pasiva/g) || []).length, 3, 'las tres skins dicen "Sin pasiva"');
});

test('6 misiones de campana con mapa, objetivo y formato validos', () => {
  const b = block('const CAMPAIGN_MISSIONS=[', '];');
  const ms = [...b.matchAll(/map:'([^']+)',objective:'([^']+)',fmt:(\d)/g)];
  assert.equal(ms.length, 6, 'deben ser 6 misiones');
  const maps = new Set([...html.matchAll(/^ ([a-z0-9]+):\{id:'/gm)].map(m => m[1]));
  for (const [, map, obj, fmt] of ms) {
    assert.ok(maps.has(map), 'mapa inexistente: ' + map);
    assert.ok(['eliminacion', 'baliza', 'dominacion', 'escolta'].includes(obj), 'objetivo invalido: ' + obj);
    assert.ok([2, 4, 5].includes(Number(fmt)), 'formato invalido: ' + fmt);
  }
});

test('cada personaje del original tiene su voz extraida', () => {
  const map = block('const CHAR_VOICE={', '};');
  const pairs = [...map.matchAll(/'([^']+)':'([^']+)'/g)];
  assert.equal(pairs.length, 17, 'deben ser 17 voces de personaje');
  for (const [, name, slug] of pairs) {
    for (const ev of ['select', 'confirm', 'pain', 'death', 'firing', 'thanks']) {
      const f = path.join(ROOT, 'assets', 'audio', 'voice', slug, ev + '.mp3');
      assert.ok(fs.existsSync(f), 'falta voz ' + slug + '/' + ev + '.mp3 (' + name + ')');
    }
  }
});

test('los siete modelos por clase estan en assets/soldier', () => {
  const files = ['Francotirador', 'Artillero', 'Espia', 'Medico', 'Ingeniero', 'Comando', 'Capitan'];
  for (const f of files) {
    for (const ext of ['.obj', '_rig.json', '_tex.png']) {
      const p = path.join(ROOT, 'assets', 'soldier', f + ext);
      assert.ok(fs.existsSync(p), 'falta ' + f + ext);
    }
  }
  const scales = JSON.parse(fs.readFileSync(path.join(ROOT, 'assets', 'soldier_scales.json'), 'utf8'));
  for (const f of files) assert.ok(scales[f] > 0.2 && scales[f] < 2, 'escala rara para ' + f);
});
