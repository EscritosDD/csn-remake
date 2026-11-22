'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');

const root = path.dirname(__dirname);
const html = require('./source');
const indexHtml = fs.readFileSync(path.join(root, 'index.html'), 'utf8');
const capture = fs.readFileSync(path.join(root, '_capture_all.mjs'), 'utf8');
const cssFiles = ['layout.css', 'game.css', 'viewer.css', 'theme.css', 'cards.css'];
const css = cssFiles.map(name => fs.readFileSync(path.join(root, 'styles', name), 'utf8')).join('\n');
let uiDataPromise;
function loadUiData() {
  if (!uiDataPromise) uiDataPromise = import('../src/data/ui-copy.js');
  return uiDataPromise;
}

test('el indicador de pasos tiene progreso real', async () => {
  const { STEP_META } = await loadUiData();
  assert.match(html, /id="stepHint"[^>]*data-step="nation"/);
  for (const id of ['stepCount', 'stepLabel', 'stepDetail']) assert.match(html, new RegExp('id="' + id + '"'));
  assert.match(html, /class="step-dots"[^>]*><i><\/i><i><\/i><i><\/i><i><\/i>/);
  assert.deepEqual(Object.keys(STEP_META), ['nation', 'mode', 'squad', 'battle']);
  ['nation', 'mode', 'squad', 'battle'].forEach((step, i) => {
    assert.equal(STEP_META[step].n, i + 1);
    assert.ok(STEP_META[step].label.length > 2);
  });
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
  assert.match(css, /:focus-visible/);
  assert.match(css, /min-height:44px/);
  assert.match(css, /nav\.tabs button:hover/);
});

test('las capturas permiten monitoreo móvil y de reglas', () => {
  assert.match(capture, /CSN_WINDOW/);
  assert.match(capture, /how: /);
});

test('la navegación principal usa los cuatro nombres del usuario', async () => {
  const tabs = indexHtml.split('id="mainTabs"')[1]?.split('</nav>')[0] || '';
  const esperados = [['play','Jugar'],['arsenal','Armería'],['viewer','Tropas'],['how','Cómo se juega']];
  assert.equal((tabs.match(/data-tab="/g)||[]).length,4);
  for (const [tab,label] of esperados) assert.match(tabs,new RegExp('data-tab="'+tab+'"[^>]*>'+label+'</button>'));
  assert.match(indexHtml,/id="mnuArmory"[^>]*>[\s\S]*?Catálogo de armas y desplegables/);
  assert.match(indexHtml,/id="mnuViewer"[^>]*>[\s\S]*?Personajes con visor 3D integrado/);
  assert.match(html,/#mainTabs button'\)\.forEach\(b=>b\.onclick=\(\)=>\{showScreen\('scr-'\+b\.dataset\.tab\);if\(b\.dataset\.tab==='arsenal'\)armTab\('armas'\);\}\)/);
  assert.match(html,/getElementById\('mnuArmory'\);if\(ar\)ar\.onclick=\(\)=>\{showScreen\('scr-arsenal'\);armTab\('armas'\);\}/);
  const { AUX_LABELS, AUX_HINTS } = await loadUiData();
  assert.equal(AUX_LABELS['scr-arsenal'],'Armería');
  assert.equal(AUX_LABELS['scr-viewer'],'Tropas');
  assert.equal(AUX_HINTS['scr-arsenal'],'Armas originales, CSN y desplegables · opcional');
  assert.equal(AUX_HINTS['scr-viewer'],'Personajes con visor 3D integrado · opcional');
});

test('Armería y Tropas tienen los contenedores de la nueva navegación', () => {
  for (const id of ['arsSectionSeg','deployableGrid','troopFilters','troopGrid']) assert.match(indexHtml,new RegExp('id="'+id+'"'),id);
  assert.match(indexHtml,/<link rel="stylesheet" href="styles\/cards\.css">/);
  assert.match(indexHtml,/<h1>Armería<\/h1>/);
  assert.match(indexHtml,/<h1>Tropas<\/h1>/);
  assert.ok(indexHtml.indexOf('id="arsSectionSeg"')<indexHtml.indexOf('id="arsFilters"'));
  assert.ok(indexHtml.indexOf('id="arsenalGrid"')<indexHtml.indexOf('id="deployableGrid"'));
  assert.ok(indexHtml.indexOf('id="troopGrid"')<indexHtml.indexOf('id="viewerLegacy"'));
  assert.match(indexHtml,/id="viewerLegacy" class="viewer-legacy" hidden/);
  assert.doesNotMatch(indexHtml,/data-kind="pieces"/);
  assert.doesNotMatch(indexHtml,/id="viewerPieceControls"/);
  for (const id of ['viewerKinds','viewerCharacterControls','viewerCanvas','viewerStatus','viewerList','viewerWeaponSelect','viewerFireBtn']) assert.match(indexHtml,new RegExp('id="'+id+'"'),id);
  for (const selector of ['\\.troop-filters','\\.troop-grid','\\.deployable-grid','\\.viewer-legacy\\[hidden\\]\\{display:none!important\\}']) assert.match(css,new RegExp(selector));
});
