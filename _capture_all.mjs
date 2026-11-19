// Comando unico de capturas CSN: 3D (ventana real) + 2D (vista clasica).
// Uso: node _capture_all.mjs <mapId> <prefijo> [espera3d_ms]
import { spawn } from "node:child_process";
import fs from "node:fs";
import os from "node:os";
import path from "node:path";
import { fileURLToPath } from "node:url";
const CHROME = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
const ROOT = path.dirname(fileURLToPath(import.meta.url));
const BASE_URL = process.env.CSN_URL || "http://127.0.0.1:8000/";
const CAP = process.env.CSN_CAPTURE_DIR || path.join(ROOT, "docs", "capturas");
const mapId = process.argv[2] || "skirmish";
const prefix = process.argv[3] || ("cap_" + mapId);
const waitMs = Number(process.argv[4] || 10000);
const uiMode = mapId.startsWith("ui:") ? mapId.slice(3) : null;
const PORT = 9360 + Math.floor(Math.random() * 40);
fs.mkdirSync(CAP, { recursive: true });
const profile = fs.mkdtempSync(path.join(os.tmpdir(), "csn-chrome-cap-"));
const chrome = spawn(process.env.CSN_CHROME || CHROME, ["--remote-debugging-port=" + PORT, "--window-size=1500,950", "--window-position=40,40", "--no-first-run", "--no-default-browser-check", "--user-data-dir=" + profile], { stdio: "ignore" });
const sleep = ms => new Promise(r => setTimeout(r, ms));
async function getWs() { for (let i = 0; i < 60; i++) { try { const r = await fetch(`http://127.0.0.1:${PORT}/json`); const ps = await r.json(); const p = ps.find(x => x.type === "page"); if (p?.webSocketDebuggerUrl) return p.webSocketDebuggerUrl; } catch {} await sleep(400); } throw new Error("no CDP"); }
const ws = new WebSocket(await getWs()); await new Promise((res, rej) => { ws.onopen = res; ws.onerror = rej; });
let id = 0; const pend = new Map(); const errs = [];
ws.onmessage = ev => { const m = JSON.parse(ev.data); if (m.id && pend.has(m.id)) { pend.get(m.id)(m); pend.delete(m.id); return; }
  if (m.method === "Runtime.exceptionThrown") errs.push(String(m.params.exceptionDetails?.exception?.description || "").slice(0, 140)); };
const send = (method, params = {}) => new Promise(res => { const i = ++id; pend.set(i, res); ws.send(JSON.stringify({ id: i, method, params })); });
const ev = async (e, t = 20000) => { const p = send("Runtime.evaluate", { expression: e, returnByValue: true, awaitPromise: true }); const to = new Promise(r => setTimeout(() => r({ TIMEOUT: 1 }), t)); const r = await Promise.race([p, to]); return r.TIMEOUT ? "TIMEOUT" : (r.result?.result?.value ?? null); };
const shot = async (name) => { const r = await send("Page.captureScreenshot", { format: "png" }); if (r.result?.data) { const f = `${CAP}\\${name}.png`; fs.writeFileSync(f, Buffer.from(r.result.data, "base64")); return fs.statSync(f).size; } return 0; };
await send("Page.enable"); await send("Runtime.enable");
await send("Page.navigate", { url: BASE_URL }); await sleep(3000);
try { await send("Page.bringToFront"); } catch (e) {}
await ev("localStorage.setItem('radsoldiers_nation','es');location.reload();"); await sleep(10000);
try { await send("Page.bringToFront"); } catch (e) {}
/* mapId puede ser un mapa, campana:N o ui:<pantalla>. */
if (uiMode) {
  const screens = {
    menu: "showScreen('scr-play')",
    setup: "openSetup('eliminacion')",
    barracks: "document.getElementById('mnuBarracks').click()",
    viewer: "document.querySelector('#mainTabs [data-tab=\"viewer\"]').click()",
    pieces: "document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();document.querySelector('#viewerKinds [data-kind=\"pieces\"]').click()",
    game: "quickStart('almacen')",
    resume: "quickStart('almacen');document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();document.querySelector('#mainTabs [data-tab=\"play\"]').click()"
  };
  if (!screens[uiMode]) throw new Error("Pantalla ui no valida: " + uiMode);
  await ev(screens[uiMode]); await sleep(waitMs);
} else if (/^campana:\d+$/.test(mapId)) {
  const missionNumber = Number(mapId.split(":")[1]);
  if (!Number.isInteger(missionNumber) || missionNumber < 1 || missionNumber > 6) {
    throw new Error("La mision debe estar entre 1 y 6.");
  }
  const mi = missionNumber - 1;
  await ev(`openSetup('campana',${mi})`); await sleep(1500);
  const setupText = await ev("document.getElementById('setupSub')?.textContent||''");
  if (!String(setupText).includes(`Misión ${missionNumber} ·`)) {
    throw new Error(`Esperaba la mision ${missionNumber}, pero el juego muestra: ${setupText}`);
  }
  const launched = await ev("(function(){const b=document.getElementById('launchBtn');if(b){b.click();return 1}return 0})()");
  if (launched !== 1) throw new Error("No se encontro el boton para desplegar la mision.");
} else {
  await ev(`window.quickStart('${mapId}')`);
}
await sleep(waitMs);
let state = await ev("JSON.stringify(window.__csn3d)");
/* Reintento: si la 3D no arranco por rAF estrangulado, traer la ventana al
   frente y esperar otro par de segundos antes de rendirse. */
let tries = 0;
while (!uiMode && tries < 3) {
  let ok = false;
  try { const st = JSON.parse(state); ok = !!(st && st.units > 0); } catch (e) { ok = false; }
  if (ok) break;
  tries++;
  try { await send("Page.bringToFront"); } catch (e) {}
  await ev("(function(){try{window.dispatchEvent(new Event('focus'));}catch(e){}try{window.__render3D&&window.__render3D();}catch(e){}return 1})()");
  await sleep(2500);
  state = await ev("JSON.stringify(window.__csn3d)");
}
const s3d = await shot(prefix + (uiMode ? "_ui" : "_3d"));
/* La vista 2D queda como alternativa: solo se captura si se pide con
   --2d o si la 3D no arranco (ventana tapada). */
let s3ok = false;
try { const st = JSON.parse(state); s3ok = !!(st && st.units > 0); } catch (e) { s3ok = false; }
const want2d = !uiMode && (process.argv.includes("--2d") || !s3ok);
let toClassic = "skip";
let s2d = 0;
if (want2d) {
  toClassic = await ev(`(function(){const b=document.querySelector('#viewSeg button[data-view="2d"]');if(!b)return 'no btn';b.click();return 'ok'})()`);
  await sleep(1500);
  await ev("try{window.draw&&window.draw()}catch(e){}"); await sleep(800);
  const d2d = await ev("(function(){const b=document.querySelector('#board');if(!b)return '';try{return b.toDataURL('image/png')}catch(e){return ''}})()");
  if (typeof d2d === "string" && d2d.startsWith("data:image/png;base64,")) { const f = `${CAP}\\${prefix}_2d.png`; fs.writeFileSync(f, Buffer.from(d2d.split(",")[1], "base64")); s2d = fs.statSync(f).size; }
}
console.log(JSON.stringify({ map: mapId, csn3d: state, vistaClasica: toClassic, png3d: uiMode ? 0 : s3d, pngUi: uiMode ? s3d : 0, png2d: s2d, errores: errs.slice(0, 5) }));
await Promise.race([send("Browser.close"), sleep(1000)]);
ws.close();
if (chrome.exitCode === null) {
  chrome.kill();
  await new Promise(resolve => chrome.once("close", resolve));
}
fs.rmSync(profile, { recursive: true, force: true, maxRetries: 10, retryDelay: 500 });
process.exit(0);

