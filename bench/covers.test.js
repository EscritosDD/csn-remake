'use strict';
/* Test de las CARATULAS DE LA ARMERIA (F1): las 37 armas del juego.
   Comprueba, sin navegador:
   1. cada arma de WEAPONS tiene malla (WEAPON_MESH_FILE) o no tendra
      ni siquiera render 3D de respaldo;
   2. las que no tienen arte del original (WEAPON_COVER_BY_FILE) son
      exactamente las 6 lanzacohetes/lanzagranadas (malla RPG);
   3. el flujo de respaldo del catalogo (tryThumb) reintenta mientras
      la malla carga pero PARA si la carga fallo definitivamente
      (regresion del bug de la cache envenenada: null mientras cargaba);
   4. la malla RPG y su textura existen en disco.

   Uso: node bench/covers.test.js
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
  assert.ok(j > i, 'cierre no encontrado para: ' + marker);
  return html.slice(i, j);
}

test('las 37 armas del catálogo tienen malla 3D asignada', () => {
  const w = block('const WEAPONS={', '};');
  const names = [...w.matchAll(/^ '([^']+)':\{dmg:/gm)].map(m => m[1]);
  assert.ok(names.length >= 37, 'deben ser >=37 armas (hay ' + names.length + ')');
  const m = block('const WEAPON_MESH_FILE={', '};');
  const mesh = [...m.matchAll(/'([^']+)':'([^']+)'/g)];
  const meshMap = {};
  for (const [, k, v] of mesh) meshMap[k] = v;
  for (const n of names) {
    assert.ok(meshMap[n], 'arma sin malla 3D: ' + n);
    const obj = path.join(ROOT, 'assets', 'weapons', meshMap[n] + '.obj');
    const tex = path.join(ROOT, 'assets', 'weapons', meshMap[n] + '_tex.png');
    assert.ok(fs.existsSync(obj), 'falta .obj de ' + n + ' (' + meshMap[n] + ')');
    assert.ok(fs.existsSync(tex), 'falta _tex.png de ' + n + ' (' + meshMap[n] + ')');
  }
});

test('las armas sin arte original son exactamente las 6 de la malla RPG', () => {
  const w = block('const WEAPONS={', '};');
  const names = [...w.matchAll(/^ '([^']+)':\{dmg:/gm)].map(m => m[1]);
  const m = block('const WEAPON_MESH_FILE={', '};');
  const meshMap = {};
  for (const [, k, v] of [...m.matchAll(/'([^']+)':'([^']+)'/g)]) meshMap[k] = v;
  const c = block('const WEAPON_COVER_BY_FILE={', '};');
  const coverMap = {};
  for (const [, k, v] of [...c.matchAll(/'([^']+)':'([^']+)'/g)]) coverMap[k] = v;
  const sin = names.filter(n => !coverMap[meshMap[n]]);
  assert.deepEqual(sin.sort(), ['AT4', 'M203', 'M32 MGL', 'M72 LAW', 'RPG-7', 'Mk 19'].sort(),
    'esperadas exactamente las 6 de malla RPG; sin arte: ' + sin.join(','));
  for (const n of sin) {
    assert.equal(meshMap[n], 'RPG', n + ' deberia usar la malla RPG');
  }
  const obj = path.join(ROOT, 'assets', 'weapons', 'RPG.obj');
  const tex = path.join(ROOT, 'assets', 'weapons', 'RPG_tex.png');
  assert.ok(fs.existsSync(obj), 'falta assets/weapons/RPG.obj');
  assert.ok(fs.existsSync(tex), 'falta assets/weapons/RPG_tex.png');
});

test('el respaldo de carátulas no envenena la caché mientras la malla carga', () => {
  const r = block('function renderWeaponThumb(', '\nfunction weaponCoverURL(');
  /* Regresión del bug: antes, si la malla estaba cargando (null), la caché
     quedaba null y el reintento del catálogo nunca más probaba. Ahora el
     null "cargando" NO se cachea y solo el false (fallo) corta el reintento. */
  assert.ok(!/if\(!file\|\|!holder\)\{WEAPON_THUMB_CACHE\[weapon\]=null;return null;\}/.test(r),
    'renderWeaponThumb vuelve a cachear null en cargando');
  assert.ok(/holder===false\)\{WEAPON_THUMB_CACHE\[weapon\]=null/.test(r),
    'renderWeaponThumb ya no distingue fallo definitivo (false)');
  const b = block('function buildArsenal(){', '\n}');
  assert.ok(/tries<40&&GUN_MESH_CACHE\[name\]!==false/.test(b),
    'el reintento del catálogo no tiene tope/condición de fallo definitivo');
  /* la textura debe marcarse texReady para que la carátula no salga gris */
  assert.ok(/userData\.texReady=true/.test(html),
    'makeRealGun3 no marca texReady en el holder');
});

test('las 31 fichas con arte original apuntan a PNG existentes', () => {
  const c = block('const WEAPON_COVER_BY_FILE={', '};');
  const arts = [...c.matchAll(/'([^']+)':'([^']+)'/g)];
  let checked = 0;
  for (const [, file, art] of arts) {
    const p = path.join(ROOT, 'assets', 'weapons', 'covers', art + '.png');
    assert.ok(fs.existsSync(p), 'falta cover ' + art + '.png (malla ' + file + ')');
    checked++;
  }
  assert.ok(checked >= 18, 'deben mapear >=18 mallas a covers (hay ' + checked + ')');
});
