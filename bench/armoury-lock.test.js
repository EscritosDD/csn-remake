'use strict';
/* BLOQUEO DE LA ARMERÍA (orden de Dani, 25/11/2026).
   Las armas originales, con su visor y su sonido, están perfectas y NO se tocan.
   Tampoco se tocan los desplegables ni los objetos. Las armas que Dani desarrolle
   en el futuro van en ficheros NUEVOS, sin modificar estos. Si un cambio legítimo
   necesita tocar un fichero protegido, hay que actualizar bench/armoury-lock.json
   con el hash nuevo y que Dani lo apruebe antes. */
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const crypto = require('node:crypto');

const root = path.dirname(__dirname);

function sha256(file) {
  return crypto.createHash('sha256').update(fs.readFileSync(file)).digest('hex');
}

test('la armería, los desplegables y los objetos están bloqueados (hashes intactos)', () => {
  const manifest = JSON.parse(fs.readFileSync(path.join(root, 'bench', 'armoury-lock.json'), 'utf8'));
  const files = Object.keys(manifest).sort();
  assert.ok(files.length >= 100, 'el manifiesto de la armería tiene menos ficheros de los esperados: ' + files.length);
  const changed = [], missing = [];
  for (const f of files) {
    const p = path.join(root, f);
    if (!fs.existsSync(p)) { missing.push(f); continue; }
    if (sha256(p) !== manifest[f]) changed.push(f);
  }
  assert.deepEqual(missing, [], 'ficheros protegidos BORRADOS de la armería: ' + missing.join(', '));
  assert.deepEqual(changed, [], 'ficheros protegidos MODIFICADOS de la armería: ' + changed.join(', '));
});

test('la armería cubre las 23 armas originales con su visor y su sonido', () => {
  const manifest = JSON.parse(fs.readFileSync(path.join(root, 'bench', 'armoury-lock.json'), 'utf8'));
  const files = Object.keys(manifest);
  const objs = files.filter(f => f.startsWith('assets/weapons/') && f.endsWith('.obj'));
  assert.equal(objs.length, 23, 'la armería debe cubrir 23 mallas de arma, hay ' + objs.length);
  for (const f of ['assets/weapons/weapon_calibrations.json', 'assets/weapons/weapon_sockets.json', 'assets/weapons/index.json', 'src/data/weapons.js', 'src/data/deployables.js', 'src/render3d/assets-weapons.js', 'src/render3d/gun-pose.js']) {
    assert.ok(files.includes(f), 'falta en el bloqueo: ' + f);
  }
  const sounds = files.filter(f => f.startsWith('assets/audio/sfx/weapons/'));
  assert.ok(sounds.length >= 30, 'la armería debe cubrir los sonidos de armas, hay ' + sounds.length);
  const props = files.filter(f => f.startsWith('assets/props/'));
  assert.ok(props.length >= 15, 'el bloqueo debe cubrir desplegables y objetos, hay ' + props.length);
});
