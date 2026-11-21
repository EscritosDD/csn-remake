'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');

const root = path.dirname(__dirname);
const html = require('./source');
const capture = fs.readFileSync(path.join(root, '_capture_all.mjs'), 'utf8');

test('los eventos reales del clip alimentan el feedback de combate', () => {
  for (const name of ['CLIP_EVENT_LOG', 'dispatchClipEvents', 'clipEventFeedback', 'fireWeaponFeedback', '_flashPulse', '_firePulse', '_hitPulse']) {
    assert.ok(html.includes(name), name);
  }
  assert.match(html, /f==='PlayWeaponFire'/);
  assert.match(html, /f==='PlayHit'\|\|f==='PlayPain'\|\|f==='PlayBulletBy'/);
  assert.match(html, /f==='PlayBodyFall'\|\|f==='PlayDeath'\|\|f==='PlayWeaponDrop'/);
  assert.match(html, /deferredFire\?\?|const deferredFire=/);
  assert.match(html, /!deferredFire\)\{const m3=T3/);
});

test('el retroceso del arma sigue el pulso del evento, no un temporizador fijo', () => {
  assert.match(html, /if\(isLive&&ud\._firePulse>0\)\{/);
  assert.match(html, /pose\.origin\.addScaledVector\(pose\.dir,-0\.055\*ud\._firePulse\)/);
  assert.match(html, /pose\.quat\.multiply\(_gpRecoil\.setFromAxisAngle/);
  assert.doesNotMatch(html, /FX\.t-un\._shootT\)\/220/);
});

test('la captura de combate registra clip, eventos y pulsos', () => {
  assert.match(capture, /const combatMode = mapId\.startsWith\('combat:'\)/);
  assert.match(capture, /window\.__combatProbe/);
  assert.match(capture, /p\.events=window\.__csnEvents\.slice\(\)/);
  assert.match(capture, /e\.f==='PlayWeaponFire'/);
  assert.match(capture, /const combatOk = !combatMode/);
});
