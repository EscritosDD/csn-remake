'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');

const root = path.dirname(__dirname);
const html = fs.readFileSync(path.join(root, 'index.html'), 'utf8');
const capture = fs.readFileSync(path.join(root, '_capture_all.mjs'), 'utf8');

test('el movimiento 3D sigue un camino de casillas', () => {
  assert.match(html, /function drawMovePath\(unit,from,to\)\{/);
  assert.match(html, /function startDrawMove\(un,path\)\{/);
  assert.match(html, /function updateUnitDrawPosition\(un,now\)\{/);
  assert.match(html, /G\.units\.forEach\(un=>updateUnitDrawPosition\(un,drawNow\)\)/);
  assert.match(html, /un\._drawPath=pts;un\._drawSegs=segs;un\._drawLen=total/);
  assert.match(html, /un\._moveYaw=Math\.atan2\(s\.b\.y-s\.a\.y,s\.b\.x-s\.a\.x\)/);
  assert.match(html, /function facingYaw\(u\)\{if\(u\._moveYaw!=null\)return u\._moveYaw/);
});

test('el paso de la marcha sigue la distancia real', () => {
  assert.match(html, /ud\._gaitPhase=\(ud\._gaitPhase\|\|0\)\+gstep\/0\.42/);
  assert.match(html, /ct=\(\(ud\._gaitPhase\|\|0\)\+ud\.clipPhase\)%clips\[key\]\.dur/);
  assert.match(html, /const walking=!REDUCED_MOTION&&\(gspeed>0\.15\|\|moving\|\|un\._turning\)/);
  assert.match(html, /\|\|!!un\._drawPath/);
});

test('los giros usan los clips reales de 90 y 180 grados', () => {
  assert.match(html, /un\._turning&&clips\['turn'\+stance\+'L'\]/);
  assert.match(html, /Math\.abs\(arc\)>2\.3\?\('turn'\+stance\+'180'\)/);
  assert.match(html, /'turn'\+stance\+\(arc>0\?'L':'R'\)/);
  assert.match(html, /ct=\(un\._turnProg\|\|0\)\*clips\[key\]\.dur/);
  assert.match(capture, /clip:\(ud&&ud\._clipKey\)\|\|null,ct:/);
});

test('las texturas de soldado evitan sangrado de atlas', () => {
  assert.match(html, /t\.generateMipmaps=false/);
  assert.match(html, /t\.minFilter=THREE\.LinearFilter/);
  assert.match(html, /t\.wrapS=THREE\.ClampToEdgeWrapping/);
  assert.match(html, /Math\.min\(0\.998,Math\.max\(0\.002,UV\[ti\]\[0\]\)\)/);
});

test('las capturas registran movimiento y estado de textura', () => {
  assert.match(capture, /const moveMode = mapId\.startsWith\('move:'\)/);
  assert.match(capture, /window\.__moveProbe/);
  assert.match(capture, /result\.tex = JSON\.parse\(rawTex\)/);
  assert.match(capture, /const moveOk = !moveMode/);
});
