import { spawn } from 'node:child_process';
import fs from 'node:fs';
import os from 'node:os';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const CHROME = process.env.CHROME_PATH || process.env.CSN_CHROME || 'C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe';
const ROOT = path.dirname(fileURLToPath(import.meta.url));
const BASE_URL = process.env.CSN_URL || 'http://127.0.0.1:8000/';
const WINDOW = /^\d{3,4},\d{3,4}$/.test(process.env.CSN_WINDOW || '') ? process.env.CSN_WINDOW : '1500,950';
const CAP = process.env.CSN_CAPTURE_DIR || path.join(ROOT, 'docs', 'capturas');
const mapId = process.argv[2] || 'skirmish';
const prefix = process.argv[3] || ('cap_' + mapId);
const waitMs = Number(process.argv[4] || 10000);
const uiMode = mapId.startsWith('ui:') ? mapId.slice(3) : null;
const moveMode = mapId.startsWith('move:') ? mapId.slice(5) : null;
const PORT = 9360 + Math.floor(Math.random() * 40);
const sleep = ms => new Promise(r => setTimeout(r, ms));

const result = {
  map: mapId,
  ok: false,
  csn3d: null,
  vistaClasica: 'skip',
  png3d: 0,
  pngUi: 0,
  png2d: 0,
  ui: null,
  move: null,
  tex: null,
  errores: []
};

let chrome = null;
let ws = null;
let profile = null;
let spawnError = null;
let id = 0;
const pend = new Map();
let send = async () => ({});

async function getWs() {
  for (let i = 0; i < 60; i++) {
    if (spawnError) throw spawnError;
    try {
      const r = await fetch(`http://127.0.0.1:${PORT}/json`);
      const ps = await r.json();
      const p = ps.find(x => x.type === 'page');
      if (p?.webSocketDebuggerUrl) return p.webSocketDebuggerUrl;
    } catch {}
    await sleep(400);
  }
  throw new Error('no CDP');
}

try {
  if (!/^[A-Za-z0-9_:-]+$/.test(mapId)) throw new Error('mapId no valido');
  fs.mkdirSync(CAP, { recursive: true });
  profile = fs.mkdtempSync(path.join(os.tmpdir(), 'csn-chrome-cap-'));
  chrome = spawn(CHROME, [
    '--remote-debugging-port=' + PORT,
    '--window-size=' + WINDOW,
    '--window-position=40,40',
    '--no-first-run',
    '--no-default-browser-check',
    '--disable-background-timer-throttling',
    '--disable-backgrounding-occluded-windows',
    '--disable-renderer-backgrounding',
    '--disable-features=CalculateNativeWinOcclusion',
    '--user-data-dir=' + profile
  ], { stdio: 'ignore' });
  chrome.on('error', e => { spawnError = e; });

  const wsUrl = await getWs();
  ws = new WebSocket(wsUrl);
  await new Promise((res, rej) => { ws.onopen = res; ws.onerror = rej; });

  const errs = [];
  ws.onmessage = ev => {
    const m = JSON.parse(ev.data);
    if (m.id && pend.has(m.id)) { pend.get(m.id)(m); pend.delete(m.id); return; }
    if (m.method === 'Runtime.exceptionThrown') {
      errs.push(String(m.params.exceptionDetails?.exception?.description || '').slice(0, 140));
    }
  };
  send = (method, params = {}) => new Promise(res => {
    const i = ++id;
    pend.set(i, res);
    ws.send(JSON.stringify({ id: i, method, params }));
  });
  const ev = async (expression, t = 20000) => {
    const p = send('Runtime.evaluate', { expression, returnByValue: true, awaitPromise: true });
    const to = new Promise(r => setTimeout(() => r({ TIMEOUT: 1 }), t));
    const r = await Promise.race([p, to]);
    return r.TIMEOUT ? 'TIMEOUT' : (r.result?.result?.value ?? null);
  };
  const shot = async name => {
    const r = await send('Page.captureScreenshot', { format: 'png' });
    if (r.result?.data) {
      const f = path.join(CAP, name + '.png');
      fs.writeFileSync(f, Buffer.from(r.result.data, 'base64'));
      return fs.statSync(f).size;
    }
    return 0;
  };

  await send('Page.enable');
  await send('Runtime.enable');
  await send('Page.navigate', { url: BASE_URL });
  await sleep(3000);
  try { await send('Page.bringToFront'); } catch {}

  await ev("localStorage.setItem('radsoldiers_nation','es');location.reload();");
  await sleep(10000);
  try { await send('Page.bringToFront'); } catch {}

  if (uiMode) {
    const screens = {
      nation: "localStorage.removeItem('radsoldiers_nation');location.reload();",
      menu: "showScreen('scr-play')",
      setup: "openSetup('eliminacion')",
      barracks: "document.getElementById('mnuBarracks').click()",
      viewer: "document.querySelector('#mainTabs [data-tab=\"viewer\"]').click()",
      how: "document.querySelector('#mainTabs [data-tab=\"how\"]').click()",
      pieces: "document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();document.querySelector('#viewerKinds [data-kind=\"pieces\"]').click()",
      game: "quickStart('almacen')",
      resume: "quickStart('almacen');document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();document.querySelector('#mainTabs [data-tab=\"play\"]').click()"
    };
    if (!screens[uiMode]) throw new Error('Pantalla ui no valida: ' + uiMode);
    await ev(screens[uiMode]);
    await sleep(waitMs);
  } else if (/^campana:\d+$/.test(mapId)) {
    const missionNumber = Number(mapId.split(':')[1]);
    if (!Number.isInteger(missionNumber) || missionNumber < 1 || missionNumber > 6) {
      throw new Error('La mision debe estar entre 1 y 6.');
    }
    await ev("openSetup('campana', " + JSON.stringify(missionNumber - 1) + ")");
    await sleep(1500);
    const setupText = await ev("document.getElementById('setupSub')?.textContent||''");
    if (!String(setupText).includes(`Misión ${missionNumber} ·`)) {
      throw new Error(`Esperaba la mision ${missionNumber}, pero el juego muestra: ${setupText}`);
    }
    const launched = await ev("(function(){const b=document.getElementById('launchBtn');if(!b)return 0;b.click();return 1})()");
    if (launched !== 1) throw new Error('No se encontro el boton para desplegar la mision.');
  } else {
    await ev("window.quickStart(" + JSON.stringify(moveMode || mapId) + ")");
  }

  await sleep(waitMs);
  if (moveMode) {
    await ev("(function(){const u=G.units.find(x=>x.alive&&x.team===G.turn&&x.energy>0);if(!u)return 'no unit';selectUnit(u);const cells=[...reachable(u,u.energy).entries()].filter(e=>e[1]>0);cells.sort((a,b)=>b[1]-a[1]||a[0].localeCompare(b[0]));const c=cells[0];if(!c)return 'no tile';const xy=c[0].split(',').map(Number);const p={unitId:u.id,from:[u.x,u.y],to:xy,samples:[]};window.__moveProbe=p;const t0=performance.now();function step(){const m=T3.units&&T3.units.get(u.id),ud=m&&m.userData;p.samples.push({t:Math.round(performance.now()-t0),lx:u.x,ly:u.y,x:+(u.dx!=null?u.dx:u.x).toFixed(4),y:+(u.dy!=null?u.dy:u.y).toFixed(4),f:u.facing,yaw:+(u._dispYaw||0).toFixed(4),turn:!!u._turning,clip:(ud&&ud._clipKey)||null});if(performance.now()-t0<2600)requestAnimationFrame(step);else p.done=true;}boardTileClick({x:xy[0],y:xy[1]});requestAnimationFrame(step);return 'ok';})()");
    await sleep(3300);
    const rawMove = await ev('JSON.stringify(window.__moveProbe||{})');
    try { result.move = JSON.parse(rawMove); } catch { result.move = rawMove; }
  }
  let state = await ev('JSON.stringify(window.__csn3d)');
  let tries = 0;
  let parsed = null;
  while (!uiMode && tries < 3) {
    try { parsed = JSON.parse(state); } catch { parsed = null; }
    if (parsed && parsed.units > 0) break;
    tries++;
    try { await send('Page.bringToFront'); } catch {}
    await ev("(function(){try{window.dispatchEvent(new Event('focus'));}catch(e){}try{window.__render3D&&window.__render3D();}catch(e){}return 1})()");
    await sleep(2500);
    state = await ev('JSON.stringify(window.__csn3d)');
  }

  const shotSize = await shot(prefix + (uiMode ? '_ui' : '_3d'));
  result.csn3d = state;
  result.png3d = uiMode ? 0 : shotSize;
  result.pngUi = uiMode ? shotSize : 0;
  if (uiMode) {
    const uiState = await ev("JSON.stringify({step:document.body.dataset.step,state:document.body.dataset.state,count:document.getElementById('stepCount')?.textContent,label:document.getElementById('stepLabel')?.textContent,detail:document.getElementById('stepDetail')?.textContent,screen:[...document.querySelectorAll('.screen.on')].map(s=>s.id)})");
    try { result.ui = JSON.parse(uiState); } catch { result.ui = uiState; }
  }

  let want2d = false;
  try { parsed = JSON.parse(state); } catch { parsed = null; }
  want2d = !uiMode && (process.argv.includes('--2d') || !(parsed && parsed.units > 0));
  if (want2d) {
    result.vistaClasica = await ev("(function(){const b=document.querySelector('#viewSeg button[data-view=\"2d\"]');if(!b)return 'no btn';b.click();return 'ok'})()");
    await sleep(1500);
    await ev('try{window.draw&&window.draw()}catch(e){}');
    await sleep(800);
    const d2d = await ev("(function(){const b=document.getElementById('board');if(!b)return '';try{return b.toDataURL('image/png')}catch(e){return ''}})()");
    if (typeof d2d === 'string' && d2d.startsWith('data:image/png;base64,')) {
      const f = path.join(CAP, prefix + '_2d.png');
      fs.writeFileSync(f, Buffer.from(d2d.split(',')[1], 'base64'));
      result.png2d = fs.statSync(f).size;
    }
  }

  if (!uiMode) {
    const rawTex = await ev("(function(){const a=[];try{T3.units.forEach((m,id)=>{const mesh=m.userData.mesh3||m.getObjectByProperty('isSkinnedMesh',true)||m;const mat=mesh.material;if(!mat||!mat.map)return;const t=mat.map;a.push({id,side:mat.side,mip:!!t.generateMipmaps,min:t.minFilter,cs:t.colorSpace,w:t.image&&t.image.width,h:t.image&&t.image.height,transparent:!!mat.transparent,opacity:+mat.opacity.toFixed(2)});});}catch(e){}return JSON.stringify(a);})()");
    try { result.tex = JSON.parse(rawTex); } catch { result.tex = rawTex; }
  }

  result.errores = errs.slice(0, 5);
  const sceneOk = uiMode ? true : !!(parsed && parsed.units > 0);
  const pngOk = uiMode ? result.pngUi > 0 : result.png3d > 0;
  const moveOk = !moveMode || !!(result.move && result.move.samples && result.move.samples.length > 10);
  result.ok = sceneOk && pngOk && moveOk && errs.length === 0;
  if (moveMode && !moveOk) result.errores.push('movimiento sin muestras');
  if (!result.ok && errs.length === 0) result.errores.push('escena o captura vacia');
} catch (e) {
  result.errores.push(String(e.message || e).slice(0, 200));
  result.error = String(e.message || e).slice(0, 200);
} finally {
  try {
    if (ws && ws.readyState === 1) await Promise.race([send('Browser.close'), sleep(1000)]);
  } catch {}
  try { ws?.close(); } catch {}
  if (chrome && chrome.exitCode === null) {
    chrome.kill();
    await new Promise(resolve => {
      const done = () => resolve();
      chrome.once('close', done);
      setTimeout(done, 2000);
    });
  }
  if (profile) {
    try { fs.rmSync(profile, { recursive: true, force: true, maxRetries: 10, retryDelay: 200 }); } catch {}
  }
  process.stdout.write(JSON.stringify(result) + '\n');
  process.exitCode = result.ok ? 0 : 1;
}
