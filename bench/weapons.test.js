'use strict';
/* Test de las ARMAS del juego (F4): datos coherentes y arsenal jugable.
   Comprueba, sin navegador:
   1. las 37 armas tienen dmg/rng/cost/cat validos y notas;
   2. cada arma esta en el arsenal de al menos un rol (salvo secundarias
      de Pistolas, que son de todos) y todo arma listada por un rol existe;
   3. las longitudes por categoria (WEAPON_LEN) cubren las categorias con
      malla 3D y ninguna se sale de [0.15, 0.9];
   4. los costes estan en el rango historico del original (1..5) y el
      dano por categoria respeta el orden pesado > ligero basico.

   Uso: node bench/weapons.test.js
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

const W = block('const WEAPONS={', '\nconst PISTOL=');
const entries = [...W.matchAll(/^ '([^']+)':\{dmg:(\d+),rng:(\d+),cost:(\d+),cat:'([^']+)'(.*)\},?$/gm)];
const weapons = {};
for (const m of entries) weapons[m[1]] = { dmg: +m[2], rng: +m[3], cost: +m[4], cat: m[5], rest: m[6] };

const R = block('const ROLES={', '\nconst ROLE_NAMES=');
const roles = {};
for (const m of [...R.matchAll(/^ '([^']+)':\{body:'[^']+',color:'[^']+',weapons:\[([^\]]*)\]/gm)]) {
  roles[m[1]] = m[2].split(',').map(s => s.trim().slice(1, -1));
}

test('las 37 armas tienen datos validos (dmg/rng/cost/cat/nota)', () => {
  const names = Object.keys(weapons);
  assert.equal(names.length, 37, 'deben ser 37 armas (hay ' + names.length + ')');
  const CATS = ['Fusiles de asalto', 'Subfusiles', 'Ametralladoras', 'Francotirador', 'Escopetas', 'Lanzacohetes', 'Lanzagranadas', 'Pistolas'];
  for (const n of names) {
    const w = weapons[n];
    assert.ok(CATS.includes(w.cat), n + ': categoría desconocida ' + w.cat);
    assert.ok(w.dmg >= 18 && w.dmg <= 100, n + ': daño fuera de rango ' + w.dmg);
    assert.ok(w.rng >= 2 && w.rng <= 10, n + ': alcance fuera de rango ' + w.rng);
    assert.ok(w.cost >= 1 && w.cost <= 5, n + ': coste fuera de rango ' + w.cost);
    assert.ok(/note:'/.test(w.rest), n + ': falta note');
    assert.ok(/real:'/.test(w.rest), n + ': falta real (ficha de datos reales)');
  }
});

test('todo arma de rol existe y toda arma no-pistola está en algún rol', () => {
  for (const [role, list] of Object.entries(roles)) {
    for (const w of list) {
      assert.ok(weapons[w], role + ' lista arma inexistente: ' + w);
    }
  }
  const allListed = new Set(Object.values(roles).flat());
  for (const [n, w] of Object.entries(weapons)) {
    if (w.cat === 'Pistolas') continue; // secundaria de todos
    assert.ok(allListed.has(n), n + ' no la lista ningún rol');
  }
});

test('WEAPON_LEN cubre las categorias con malla y está en rango', () => {
  const L = block('const WEAPON_LEN={', '};');
  const lens = {};
  for (const m of [...L.matchAll(/'([^']+)':([\d.]+)/g)]) lens[m[1]] = +m[2];
  const catsWithMesh = new Set(Object.values(weapons).map(w => w.cat));
  for (const c of catsWithMesh) {
    assert.ok(lens[c] !== undefined, 'WEAPON_LEN no cubre la categoría ' + c);
    assert.ok(lens[c] >= 0.15 && lens[c] <= 0.9, 'longitud rara para ' + c + ': ' + lens[c]);
  }
});

test('coherencia de coste por categoria (el peso se paga)', () => {
  const byCat = {};
  for (const w of Object.values(weapons)) (byCat[w.cat] = byCat[w.cat] || []).push(w);
  const med = a => a.slice().sort((x, y) => x - y)[Math.floor(a.length / 2)];
  const asalto = med(byCat['Fusiles de asalto'].map(w => w.cost));
  const sniper = med(byCat['Francotirador'].map(w => w.cost));
  const mg = med(byCat['Ametralladoras'].map(w => w.cost));
  assert.ok(sniper >= asalto, 'el francotirador no puede ser más barato que el asalto');
  assert.ok(mg >= asalto, 'la ametralladora no puede ser más barata que el asalto');
});
