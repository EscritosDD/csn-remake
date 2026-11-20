'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');

const root = path.dirname(__dirname);
const html = fs.readFileSync(path.join(root, 'index.html'), 'utf8');
const capture = fs.readFileSync(path.join(root, '_capture_all.mjs'), 'utf8');

test('el indicador de pasos tiene progreso real', () => {
  assert.match(html, /id="stepHint"[^>]*data-step="nation"/);
  for (const id of ['stepCount', 'stepLabel', 'stepDetail']) assert.match(html, new RegExp('id="' + id + '"'));
  assert.match(html, /class="step-dots"[^>]*><i><\/i><i><\/i><i><\/i><i><\/i>/);
  assert.match(html, /const STEP_META=\{/);
  for (const step of ['nation', 'mode', 'squad', 'battle']) assert.match(html, new RegExp(step + ':\\{n:[1-4],label:'));
  assert.match(html, /function setStep\(step,detail\)\{/);
  assert.match(html, /document\.body\.dataset\.step=flowStep/);
  assert.match(html, /chip\.dataset\.step=flowStep/);
});

test('los cuatro pasos están cableados al flujo real', () => {
  assert.match(html, /pickedNation=n;setStep\('nation'/);
  assert.match(html, /function showScreen\(id\)\{[\s\S]*?setStep\(\$\('#setupArea'\)/);
  assert.match(html, /function openSetup\(mode,missionIdx\)\{[\s\S]*?setStep\('squad'/);
  assert.match(html, /function startGame\(squadA,squadB\)\{[\s\S]*?setStep\('battle'/);
  assert.match(html, /function updateUI\(\)\{[\s\S]*?setStep\('battle'/);
  assert.match(html, /function backToMenu\(\)\{[\s\S]*?showScreen\('scr-play'\)/);
  assert.match(html, /#cancelSetup'\)\.onclick=[\s\S]*?setStep\('mode'\)/);
});

test('hay notas guía y el tutorial aparece en batalla', () => {
  for (const id of ['nationGuide', 'modeGuide']) assert.match(html, new RegExp('id="' + id + '"'));
  assert.match(html, /Paso 3 de 4\.<\/b> Revisa mapa/);
  assert.match(html, /Paso 4: toca un botón para saber qué hace en partida/);
  assert.match(html, /if\(!lsGet\('radsoldiers_tut'\)\)setTimeout\(tutShow,900\)/);
  assert.doesNotMatch(html, /if\(!lsGet\('radsoldiers_tut'\)\)setTimeout\(tutShow,1200\)/);
  const menu = html.split('id="menuArea"')[1].split('id="mnuQuick"')[0];
  assert.doesNotMatch(menu, /id="tutBubble"/);
  const play = html.split('id="scr-play"')[1].split('id="scr-barracks"')[0];
  assert.match(play, /id="tutBubble"/);
});

test('las vueltas contextuales siguen al jugador', () => {
  assert.match(html, /inBattle\?'← Volver a la partida':'← Volver al menú'/);
  for (const id of ['scr-arsenal', 'scr-how', 'scr-viewer']) {
    const seccion = html.split('id="' + id + '"')[1]?.split('</section>')[0] || '';
    assert.match(seccion, /data-back/, id + ' necesita un botón de vuelta');
  }
});

test('los controles tienen foco visible y tamaño cómodo', () => {
  assert.match(html, /:focus-visible/);
  assert.match(html, /min-height:44px/);
  assert.match(html, /nav\.tabs button:hover/);
});

test('las capturas permiten monitoreo móvil y de reglas', () => {
  assert.match(capture, /CSN_WINDOW/);
  assert.match(capture, /how: /);
});
