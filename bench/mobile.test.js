'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');

const root = path.dirname(__dirname);
const html = fs.readFileSync(path.join(root, 'index.html'), 'utf8');
const capture = fs.readFileSync(path.join(root, '_capture_all.mjs'), 'utf8');

test('el viewport movil mantiene controles tocables y tablero contenido', () => {
  assert.match(html, /<meta name="viewport" content="width=device-width, initial-scale=1, viewport-fit=cover"\/>/);
  assert.match(html, /#glWrap canvas\{[^}]*touch-action:none/);
  assert.match(html, /canvas#board\{[^}]*touch-action:manipulation/);
  assert.match(html, /@media\(max-width:640px\)\{#glWrap\{aspect-ratio:1\/1;min-height:280px\}/);
  assert.match(html, /min-height:44px/);
});

test('el render reduce resolucion en movil y en software', () => {
  assert.match(html, /function isMobileGL3\(\)/);
  assert.match(html, /renderer\.setPixelRatio\(isSw\?1:Math\.min\(isMobileGL3\(\)\?1\.5:\(window\.devicePixelRatio\|\|1\),2\)\)/);
});

test('la captura emula movil y fuerza SwiftShader cuando se pide', () => {
  assert.match(capture, /const mobileArg = mapId\.startsWith\('mobile:'\)/);
  assert.match(capture, /--use-angle=swiftshader/);
  assert.match(capture, /Emulation\.setDeviceMetricsOverride/);
  assert.match(capture, /Emulation\.setTouchEmulationEnabled/);
  assert.match(capture, /game3d: "quickStart\('skirmish'\)"/);
  assert.match(capture, /result\.pngMobile = mobileMode \? shotSize : 0/);
  assert.match(capture, /const mobileOk = !mobileMode/);
  assert.match(capture, /const geoOk = !mobileMode \|\| mobileMode !== 'game'/);
  assert.match(capture, /const softwareOk = !software/);
});
