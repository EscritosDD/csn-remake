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
  assert.match(html, /const hardTrack=!!\(ud\._firePulse>0\|\|ud\._testFlash>0/);
  assert.match(html, /pose\.origin\.addScaledVector\(pose\.dir,-0\.055\*ud\._firePulse\)/);
  assert.match(html, /pose\.quat\.multiply\(_gpRecoil\.setFromAxisAngle/);
  assert.doesNotMatch(html, /FX\.t-un\._shootT\)\/220/);
});

test('el impacto visual espera al disparo y el audio va limitado por unidad', () => {
  assert.match(html, /_shootTarget\._visualDelayUntil=FX\.t\+1200/);
  assert.match(html, /releasePendingVisualHit\(shooter\)/);
  assert.match(html, /t-un\._pendingHit\.t>1200/);
  assert.match(html, /now-\(shooter&&shooter\._lastFxAt\|\|0\)>=100/);
  assert.match(html, /shooter\._voicedShotAt!==shot/);
  const viewer = fs.readFileSync(path.join(root, 'src', 'viewer', 'main.js'), 'utf8');
  assert.match(viewer, /weaponSelect\.value=viewer\.weapon\|\|''/);
  assert.match(viewer, /rigPose:!!character\.rigPose\|\|!!bodyRole/);
  assert.match(viewer, /idleForWeapon\(wanted\)/);
  assert.match(viewer, /viewerFireBtn/);
});

test('la captura de combate registra clip, eventos y pulsos', () => {
  assert.match(capture, /const combatMode = mapId\.startsWith\('combat:'\)/);
  assert.match(capture, /window\.__combatProbe/);
  assert.match(capture, /p\.events=window\.__csnEvents\.slice\(\)/);
  assert.match(capture, /e\.f==='PlayWeaponFire'/);
  assert.match(capture, /const combatOk = !combatMode/);
});

test('cada bala del clip lleva su sonido y trazadora, y el daño espera al evento', () => {
  const combat = fs.readFileSync(path.join(root, 'src', 'game', 'combat.js'), 'utf8');
  const clips = fs.readFileSync(path.join(root, 'src', 'render3d', 'clips.js'), 'utf8');
  assert.match(combat, /export function applyShotDamage\(shooter\)/);
  assert.match(combat, /shooter\._pendingShot=\{target:target/);
  assert.match(combat, /shooter\._resolveShot=\(\)=>applyShotDamage\(shooter\)/);
  assert.match(clips, /export function fireBulletFeedback\(un,ud,e,ct,t\)/);
  assert.match(clips, /auWeapon\(shooter\._shootCat,shooter\._shootW\)/);
  assert.match(clips, /fx3Shot\(shooter,shooter\._shootAt,shooter\._shootCat\)/);
  assert.match(clips, /if\(shooter\._resolveShot\)\{const resolve=shooter\._resolveShot;/);
});

test('el despliegue reparte casillas lejanas y la explosion es volumetrica', () => {
  const combat = fs.readFileSync(path.join(root, 'src', 'game', 'combat.js'), 'utf8');
  const board = fs.readFileSync(path.join(root, 'src', 'game', 'board.js'), 'utf8');
  const fx = fs.readFileSync(path.join(root, 'src', 'render3d', 'fx-arcade.js'), 'utf8');
  assert.match(board, /export const SPAWN_MIN_CHEB=8/);
  assert.match(combat, /G\.spawnSlots=spawnSlots/);
  assert.match(board, /spreadSlots\(poolA,countA,seedB\)/);
  assert.match(fx, /new THREE\.SphereGeometry\(0\.32,14,12\)/);
  assert.match(fx, /shock\.scale\.setScalar\(1\+k\*2\*grow\)/);
});
