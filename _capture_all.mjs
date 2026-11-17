// Comando unico de capturas CSN: 3D (ventana real) + 2D (vista clasica).
// Uso: node _capture_all.mjs <mapId> <prefijo> [espera3d_ms]
import { spawn } from "node:child_process";
import fs from "node:fs";
const CHROME = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
const mapId = process.argv[2] || "skirmish";
const prefix = process.argv[3] || ("cap_" + mapId);
const waitMs = Number(process.argv[4] || 10000);
const PORT = 9360 + Math.floor(Math.random() * 40);
const CAP = "D:\\Juegos\\CSN\\_captures"; fs.mkdirSync(CAP, { recursive: true });
const chrome = spawn(CHROME, ["--remote-debugging-port=" + PORT, "--window-size=1500,950", "--window-position=40,40", "--no-first-run", "--no-default-browser-check", "--user-data-dir=D:\\Juegos\\CSN\\_chrome_cap_" + PORT], { stdio: "ignore" });
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
await send("Page.navigate", { url: "http://127.0.0.1:8000/" }); await sleep(3000);
await ev("localStorage.setItem('radsoldiers_nation','es');location.reload();"); await sleep(10000);
await ev(`window.quickStart('${mapId}')`); await sleep(waitMs);
const state = await ev("JSON.stringify(window.__csn3d)");
const s3d = await shot(prefix + "_3d");
/* La vista 2D queda como alternativa: solo se captura si se pide con
   --2d o si la 3D no arranco (ventana tapada). */
let s3ok = false;
try { const st = JSON.parse(state); s3ok = !!(st && st.geo); } catch (e) { s3ok = false; }
const want2d = process.argv.includes("--2d") || !s3ok;
let toClassic = "skip";
let s2d = 0;
if (want2d) {
  toClassic = await ev(`(function(){const b=document.querySelector('#viewSeg button[data-view="2d"]');if(!b)return 'no btn';b.click();return 'ok'})()`);
  await sleep(1500);
  await ev("try{window.draw&&window.draw()}catch(e){}"); await sleep(800);
  const d2d = await ev("(function(){const b=document.querySelector('#board');if(!b)return '';try{return b.toDataURL('image/png')}catch(e){return ''}})()");
  if (typeof d2d === "string" && d2d.startsWith("data:image/png;base64,")) { const f = `${CAP}\\${prefix}_2d.png`; fs.writeFileSync(f, Buffer.from(d2d.split(",")[1], "base64")); s2d = fs.statSync(f).size; }
}
console.log(JSON.stringify({ map: mapId, csn3d: state, vistaClasica: toClassic, png3d: s3d, png2d: s2d, errores: errs.slice(0, 5) }));
chrome.kill(); process.exit(0);

