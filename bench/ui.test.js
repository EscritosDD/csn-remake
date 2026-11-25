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

test('la primera partida usa un HUD guiado y el registro es compacto', () => {
  assert.match(html, /document\.body\.dataset\.firstGame=lsGet\('radsoldiers_tut'\)\?'0':'1'/);
  assert.match(html, /document\.body\.dataset\.firstGame='0'/);
  assert.match(css, /body\[data-first-game="1"\] #roundLabel/);
  assert.match(css, /body\[data-first-game="1"\] \.actionBar \[data-act="gas"\]/);
  assert.match(css, /body\[data-first-game="1"\] \.actionBar \.actions button small\{display:block\}/);
  assert.match(indexHtml, /<summary>Registro<\/summary>/);
});

test('el retrato usa la piel y el personaje reales, y se actualiza tras el recorte', () => {
  assert.match(html, /export function portraitKey\(role,char,skin,nation\)/);
  assert.match(html, /rolePortraitURL\(u\.role,u,skin,\{nation:nation,authored:true\}\)/);
  assert.match(html, /renderRealSprite\(u,\{authored:!!o\.authored\}\)/);
  assert.match(html, /charTexture\|\|char\.texture/);
  assert.match(html, /charMesh\|\|char\.mesh/);
  assert.match(html, /el\.dataset\.portraitKey!==pkey\)return/);
  assert.match(html, /data-portrait-key=/);
  assert.match(html, /im\.onerror=\(\)=>\{delete PORTRAIT_CACHE\[pkey\];\}/);
});

test('la tarjeta condensa el texto y muestra un solo nombre de habilidad', () => {
  assert.match(html, /const roundLabelText=g=>/);
  assert.match(html, /const hudAbility=u=>/);
  assert.doesNotMatch(html, /ABILITY_IMPL\[a\.icon\]/);
  assert.doesNotMatch(html, /Quedan '\+aliveCount/);
  assert.doesNotMatch(html, /id="roster"/);
  assert.match(html, /★ Especial \[5\]<small>'\+ab\.d/);
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

test('el tema militar y vino es la única fuente de color', () => {
  const theme = fs.readFileSync(path.join(root, 'styles', 'theme.css'), 'utf8');
  const cards = fs.readFileSync(path.join(root, 'styles', 'cards.css'), 'utf8');
  const viewer = fs.readFileSync(path.join(root, 'styles', 'viewer.css'), 'utf8');
  const layout = fs.readFileSync(path.join(root, 'styles', 'layout.css'), 'utf8');
  for (const token of [
    '--bg:#14160f;', '--bg-elev:#23261c;', '--surface:#2e3224;', '--surface-2:#3a3f2f;',
    '--stage:radial-gradient(circle at 50% 35%, #3a3f2f 0%, #23261c 68%, #14160f 100%);',
    '--ink-vino:#7a2230;', '--ink-vino-bright:#9c3040;', '--ink-oliva:#8a9a5b;', '--ink-caqui:#c2b280;', '--ink-gold:#c9a227;',
    '--ink:#f2ede4;', '--muted:#a89d8a;', '--faint:#7a7263;',
    '--line:rgba(242,237,228,.12);', '--line-strong:rgba(242,237,228,.24);'
  ]) assert.ok(theme.includes(token), token);
  assert.doesNotMatch(css, /prefers-color-scheme:\s*light/);
  assert.match(indexHtml, /name="color-scheme" content="dark"/);
  assert.doesNotMatch(css, /#0c100b|#f0b234|#283224|#182016|#3ec5db|#f27446/);
  assert.equal((theme.match(/\.btn\{/g) || []).length, 1);
  assert.doesNotMatch(cards, /\n\.btn\{/);
  assert.doesNotMatch(viewer, /\n\.btn\{|\n\.troop-grid\{|\n\.troop-filters\{/);
  assert.doesNotMatch(layout, /\n\.btn\{/);
  assert.ok(cards.includes('border:2px solid var(--line);border-radius:12px;background:var(--surface)'));
  assert.ok(cards.includes('transform:translateY(-5px) rotate(-0.3deg)'));
  assert.ok(cards.includes('box-shadow:0 6px 0 rgba(0,0,0,.42)'));
  assert.ok(theme.includes('color:#0d1117;box-shadow:0 4px 0 var(--amber-dark)'));
  assert.ok(theme.includes('transform:translateY(3px);box-shadow:none'));
  assert.ok(theme.includes('.tag,.kicker{transform:skewX(-6deg)'));
  assert.ok(theme.includes('@media(prefers-reduced-motion:reduce)'));
  assert.doesNotMatch(cards, /#faf8f2|#1c211a|#626a5c/);
  assert.doesNotMatch(css, /min-height:\s*(?:[12]?\d|3\d)px/);
});

test('la portada prioriza el arte y pliega la ficha técnica', () => {
  for (const id of ['menuModes', 'menuExtras']) assert.match(indexHtml, new RegExp('id="' + id + '"'), id);
  assert.match(indexHtml, /class="menu-section menu-dossier" id="menuModes" open/);
  assert.match(css, /\.heroOrigen\{[^}]*background:var\(--stage\)/);
  assert.match(html, /#menuArea > \.menu-dossier/);
  for (const screen of ['menu: ', 'campanhub: ', 'setup: ', 'troops: ', 'armory: ']) assert.match(capture, new RegExp(screen.replace(' ', '\\s*')));
});

test('las capturas permiten monitoreo móvil y de reglas', () => {
  assert.match(capture, /CSN_WINDOW/);
  assert.match(capture, /how: /);
  assert.match(capture, /const mobileUiMode = !!\(mobileMode && mobileMode !== 'game'\)/);
  assert.match(capture, /const sceneOk = uiMode \|\| mobileUiMode \? true : !!\(parsed && parsed\.units > 0\)/);
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

test('la campaña tiene vista propia y el briefing no usa handlers inline', () => {
  for (const id of ['campaignHub','campaignHubSummary','campaignHubBack','campaignContinue','campaignTutorial','campaignRadio','campaignList']) {
    assert.match(indexHtml, new RegExp('id="' + id + '"'), id);
  }
  assert.equal((indexHtml.match(/id="campaignPanel"/g)||[]).length,0);
  const campaignUiSource=fs.readFileSync(path.join(root,'src','ui','campaign-ui.js'),'utf8');
  assert.doesNotMatch(campaignUiSource,/onclick="/);
  assert.match(html,/function showMissionBriefing\(index\)\{[\s\S]*?id="briefDeploy"[\s\S]*?getElementById\('briefDeploy'\)/);
  assert.match(html,/deployMission\(idx\)/);
  assert.match(html,/function deployMissionData\(mission,mode,idx\)\{/);
  assert.match(html,/function deployCampaignMission\(idx\)\{const index=Math\.max\(0,Math\.min\(CAMPAIGN_MISSIONS\.length-1,idx\|\|0\)\)/);
  assert.match(html,/deployMissionData\(CAMPAIGN_MISSIONS\[index\],'campana',index\)/);
  assert.doesNotMatch(html,/function deployCampaignMission\(idx\)\{openSetup\('campana'/);
  assert.match(html,/data-campaign-brief/);
  assert.match(html,/closest\('\[data-campaign-brief\]'\)/);
  assert.match(html,/campaignBtn'\);if\(cb\)cb\.onclick=openView/);
  assert.match(html,/mnuChallenges'\);if\(ch\)ch\.onclick=openView/);
  assert.match(capture,/campanhub: "showScreen\('scr-play'\);showCampaignView\(\)"/);
  assert.match(capture,/brief: "showScreen\('scr-play'\);showMissionBriefing\(0\)"/);
  const bridgeSource=fs.readFileSync(path.join(root,'src','bridge.js'),'utf8');
  assert.match(bridgeSource,/d\('showCampaignView',\(\)=>r\.showCampaignView\)/);
  assert.match(bridgeSource,/d\('hideCampaignView',\(\)=>r\.hideCampaignView\)/);
});

test('Configurar partida muestra mapa y tarjetas visuales sin otro renderer', async () => {
  const { mapPreviewURL, squadCardMarkup } = await import('../src/ui/setup-preview.js');
  const { MAP_DEFS, SKIRMISH_GEO } = await import('../src/data/maps.js');
  assert.match(indexHtml,/id="setupMapPreview"/);
  assert.equal(mapPreviewURL('skirmish04',MAP_DEFS,SKIRMISH_GEO),SKIRMISH_GEO.skirmish04.top);
  assert.equal(mapPreviewURL('inexistente',MAP_DEFS,SKIRMISH_GEO),'assets/ui/modo_eliminacion.png');
  const card=squadCardMarkup({team:'A',i:0,role:'Comando',weapon:'M4A1',ROLES:{Comando:{weapons:['M4A1']}},BODIES:{},WEAPONS:{M4A1:{cost:3,dmg:28,rng:6}},ROLE_NAMES:['Comando'],portraitURL:()=> 'assets/ui/portrait.png',weaponURL:()=> 'assets/weapons/covers/m4a1.png'});
  for (const token of ['class="squad-card"','class="sq-ico"','class="sq-weapon-cover"','sq-bar-hp','data-kind="role"','data-kind="weapon"','data-kind="char"','⚡ 3 · 💥 28 · 🎯 6']) assert.match(card,new RegExp(token.replace(/[.*+?^${}()|[\]\\]/g,'\\$&')),token);
  assert.match(html,/updateSquadCard\(row,\{/);
  assert.match(css,/\.setup-map-preview/);
  assert.match(css,/\.squad-card/);
  assert.match(css,/\.sq-weapon-cover/);
});

test('las tarjetas de escuadra pueblan rol, arma y personaje', async () => {
  const { fillSquadSelects } = await import('../src/ui/setup-preview.js');
  const mk = () => ({ innerHTML: '', value: '' });
  const fields = { role: mk(), weapon: mk(), char: mk() };
  const row = { querySelector: sel => fields[sel.match(/data-kind="([^"]+)"/)[1]] };
  const ROLES = { Comando: { weapons: ['M4A1', 'MP5'] }, Médico: { weapons: ['M4A1'] } };
  const chars = [{ key: 'original:Hipster Dave', name: 'Hipster Dave' }];
  const characterKey = c => c.key;
  const picked = fillSquadSelects(row, { role: 'Comando', weapon: 'M4A1', chars, characterKey, ROLES, selectedCharKey: 'original:Hipster Dave' });
  assert.equal(fields.role.value, 'Comando');
  assert.equal(fields.weapon.value, 'M4A1');
  assert.equal(fields.char.value, 'original:Hipster Dave');
  assert.match(fields.role.innerHTML, /value="Médico"/);
  assert.match(fields.char.innerHTML, /value="original:Hipster Dave"/);
  assert.equal(picked.charKey, 'original:Hipster Dave');
  assert.equal(picked.chars.length, 1);
  assert.match(html, /fillSquadSelects\(row,\{role:r,weapon,fixedDef/);
});

test('el HUD de batalla y el resultado usan tarjetas arcade reutilizables', async () => {
  const { vitalsMarkup, resultMarkup } = await import('../src/ui/arcade-hud.js');
  const ally = { role: 'Comando', weapon: 'M4A1', hp: 75, maxHp: 100, alive: true, team: 'A', stunned: true, energy: 2, maxEnergy: 5 };
  const foe = { role: '<img>', weapon: 'RPG', hp: 0, maxHp: 90, alive: false, team: 'B' };
  const cards = vitalsMarkup([ally, foe], 'A', ally, { Comando: '#00e5ff' });
  assert.match(cards, /class="hud-vital A ready sel"/);
  assert.match(cards, /data-hud-unit="0"/);
  assert.match(cards, /width:75%/);
  assert.match(cards, /class="hud-vital B dead"/);
  assert.match(cards, /Aturdido/);
  assert.match(cards, /2 \/ 5 ⚡/);
  assert.doesNotMatch(cards, /<img>/);
  assert.match(cards, /&lt;img&gt;/);
  const escaped = resultMarkup({ winner: 'A', round: 3, title: '<b>x</b>', reason: '<img>', survivors: '4' });
  assert.match(escaped, /&lt;b&gt;x&lt;\/b&gt;/);
  assert.match(escaped, /&lt;img&gt;/);
  const result = resultMarkup({ winner: 'A', round: 3, modeLabel: 'BALIZA', art: 'assets/ui/modo_baliza.png', title: '¡Victoria!', reason: 'Rival eliminado.', survivors: '4', buttons: '<button>ok</button>' });
  assert.match(result, /class="result-card"/);
  assert.match(result, /class="endBanner">VICTORIA/);
  assert.match(result, /class="result-round">R3/);
  assert.match(result, /class="result-actions"><button>ok<\/button>/);
  for (const id of ['hudScoreA', 'hudScoreB', 'squadVitals', 'hudSquadTitle']) assert.match(indexHtml, new RegExp('id="' + id + '"'), id);
  assert.match(indexHtml, /class="turn-banner hud-topbar"/);
  assert.match(html, /vitalsMarkup\(G\.units,G\.turn,G\.selected,ROLES\)/);
  assert.match(html, /resultMarkup\(\{winner:winner,round:G\.round/);
  assert.match(css, /\.hud-topbar\{/);
  assert.match(css, /\.hud-vital\{/);
  assert.match(css, /\.result-card\{/);
  assert.match(css, /html\.is-playing \.topbar/);
  assert.match(css, /html\[data-view="3d"\] \.legend/);
  assert.match(css, /\.gl-controls\{position:absolute/);
  assert.match(css, /\.game-layout\{display:grid;grid-template-columns:minmax\(0,1fr\) 320px/);
  assert.match(indexHtml, /id="logDrawer"/);
  assert.match(indexHtml, /<div class="gl-controls"><button/);
  assert.doesNotMatch(indexHtml, /class="legend"/);
  assert.doesNotMatch(indexHtml, /id="roster"/);
  assert.equal((indexHtml.match(/class="turn-banner hud-topbar"/g) || []).length, 1);
});

test('el HUD de combate queda en una barra compacta con registro plegado', () => {
  const topbar = indexHtml.split('class="turn-banner hud-topbar"')[1]?.split('<div class="game-layout">')[0] || '';
  assert.doesNotMatch(topbar, /<img\b|hud-kicker|Urban Tactical Arcade/);
  assert.doesNotMatch(topbar, /Turno: Jugador 1|Cerrar turno ⏭|>Abandonar</);
  for (const id of ['turnPill', 'roundLabel', 'hudScoreA', 'hudScoreB', 'undoBtn', 'soundBtn', 'logBtn', 'endTurnBtn', 'quitBtn']) {
    assert.match(topbar, new RegExp('id="' + id + '"'), id);
  }
  const view = indexHtml.split('id="viewSeg"')[1]?.split('</div>')[0] || '';
  assert.match(view, /data-view="3d"[^>]*>3D<\/button>/);
  assert.match(view, /data-view="2d"[^>]*>2D<\/button>/);
  assert.doesNotMatch(view, /Vista 3D · el tablero con volumen|Vista 2D \(alternativa\)/);
  assert.match(indexHtml, /<details class="weapon-drawer">[\s\S]*?id="weaponInfo"/);
  assert.doesNotMatch(indexHtml, /<h3>Ficha del arma<\/h3>/);
  assert.match(css, /\.weapon-drawer\{/);
  assert.match(html, /getElementById\('logBtn'\)\?\.addEventListener\('click'/);
  assert.match(html, /getElementById\('logDrawer'\);if\(d\)d\.open=!d\.open/);
  assert.match(html, /pill\.textContent=G\.over\?'FIN'/);
  assert.match(css, /@media\(max-width:900px\)\{\.hud-topbar\{grid-template-columns:minmax\(0,1fr\) auto/);
  assert.match(css, /\.hud-actions\{grid-column:1\/-1;grid-row:2/);
  assert.match(css, /\.hud-btn\{padding:6px 7px;font-size:11px\}/);
});

test('los retratos 2D del original están en assets/ui/portraits y se usan antes que el render 3D', () => {
  const shell = fs.readFileSync(path.join(root, 'src', 'ui', 'ui-shell.js'), 'utf8');
  const m = shell.match(/export const CHAR_PORTRAIT=\{([\s\S]*?)\};/);
  assert.ok(m, 'CHAR_PORTRAIT no existe en ui-shell.js');
  const entries = [...m[1].matchAll(/'([^']+)':'(portraits\/[^']+|original\/portrait\.png)'/g)];
  assert.ok(entries.length >= 14, 'CHAR_PORTRAIT tiene menos de 14 retratos: ' + entries.length);
  for (const [, name, file] of entries) {
    assert.ok(fs.existsSync(path.join(root, 'assets', 'ui', file)), 'falta el retrato de ' + name + ': assets/ui/' + file);
  }
  assert.match(shell, /if\(cname&&CHAR_PORTRAIT\[cname\]\)/);
  assert.ok(shell.indexOf('CHAR_PORTRAIT[cname]') < shell.indexOf('REAL.ready'), 'el retrato 2D debe comprobarse antes del render 3D');
});
