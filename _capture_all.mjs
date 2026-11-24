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
const auditMode = mapId.startsWith('viewer:');
const uiMode = auditMode || (mapId.startsWith('ui:') ? mapId.slice(3) : null);
const moveMode = mapId.startsWith('move:') ? mapId.slice(5) : null;
const combatMode = mapId.startsWith('combat:') ? mapId.slice(7) : null;
const mobileArg = mapId.startsWith('mobile:') ? mapId.slice(7) : null;
const software = /^(1|true|yes)$/i.test(process.env.CSN_SOFTWARE || '') || !!(mobileArg && mobileArg.startsWith('sw:'));
const mobileMode = mobileArg ? (mobileArg.startsWith('sw:') ? mobileArg.slice(3) : mobileArg) : null;
const PORT = 9360 + Math.floor(Math.random() * 40);
const sleep = ms => new Promise(r => setTimeout(r, ms));
const viewerAuditProbeExpr = `(async function(){
 const sleep=ms=>new Promise(r=>setTimeout(r,ms));
 const statusEl=document.getElementById('viewerStatus');
 const state=()=>window.__csnViewer&&window.__csnViewer.state;
 const model=()=>{const v=state(),c=v&&v.spin&&v.spin.children&&v.spin.children[0];return (c&&c.children&&c.children[0])||null;};
  const probe=label=>{const v=state(),m=model();let size=[0,0,0];if(m){const box=new THREE.Box3().setFromObject(m),s=new THREE.Vector3();box.getSize(s);size=[s.x,s.y,s.z].map(n=>+n.toFixed(4));}
  const gun=m&&m.userData&&m.userData.viewerGun;let grip=null;
  if(gun&&typeof THREE!=='undefined'&&m.userData.byName&&m.userData.bones&&typeof WEAPON_SOCKETS!=='undefined'){
    m.updateMatrixWorld(true);const parent=gun.parent||m,ud=m.userData,sr=WEAPON_SOCKETS.handRight.pos,sl=WEAPON_SOCKETS.handLeft.pos;
    const palm=(joint,socket)=>{const b=ud.bones[ud.byName[joint]];if(!b)return null;return parent.worldToLocal(new THREE.Vector3(-Math.abs(socket[0]),socket[1],socket[2]).applyMatrix4(b.matrixWorld));};
    const rp=palm('Bip001 R Hand',sr),lp=palm('Bip001 L Hand',sl),bFA=ud.bones[ud.byName['Bip001 R Forearm']];
    if(rp&&lp&&bFA){const fa=parent.worldToLocal(new THREE.Vector3().setFromMatrixPosition(bFA.matrixWorld));
      const two=lp.clone().sub(rp),dir=new THREE.Vector3(1,0,0).applyQuaternion(gun.quaternion),span=two.length(),ly=lp.y;
      const sm=(a,b,x)=>{const t=Math.max(0,Math.min(1,(x-a)/(b-a)));return t*t*(3-2*t);};
      const w2h=sm(0.28,0.42,ly)*sm(0.20,0.28,span)*(1-sm(0.52,0.62,span));
      const arr=p=>[p.x,p.y,p.z].map(n=>+n.toFixed(3));
      grip={socketR:[-Math.abs(sr[0]),sr[1],sr[2]].map(n=>+n.toFixed(3)),rPalm:arr(rp),lPalm:arr(lp),gripDist:+rp.distanceTo(gun.position).toFixed(3),gripDot:+dir.dot(two.normalize()).toFixed(3),w2h:+w2h.toFixed(3),faDist:+rp.distanceTo(fa).toFixed(3)};
    }
  }
  const st=statusEl,wEl=document.getElementById('viewerWeaponSelect');return {label,name:(v&&v.name)||'',kind:(v&&v.kind)||'',weapon:(v&&v.weapon)||'',weaponChar:(v&&v.weaponChar)||'',weaponTouched:!!(v&&v.weaponTouched),weaponOptions:wEl?[...wEl.options].map(o=>o.value).filter(Boolean):[],testFire:!!(v&&v.testFire),status:(st.textContent||'').trim(),statusHidden:!!(st.hidden||st.style.display==='none'),size,meshy:!!(m&&m.userData&&m.userData.meshy),gun:!!gun,grip,geometryOk:size.some(n=>Number.isFinite(n)&&n>0.001)};};

 const settle=async()=>{await sleep(400);for(let i=0;i<120;i++){const st=statusEl,t=(st.textContent||'').trim();if((st.hidden||st.style.display==='none')&&!t)return true;if(/No se pudo|todav/.test(t))return false;await sleep(250);}return false;};
 const out=[];
  const roles=async key=>{document.querySelector('#viewerKinds [data-kind="roles"]').click();await sleep(250);const c=document.getElementById('viewerCharacterSelect');c.value=key;c.dispatchEvent(new Event('change',{bubbles:true}));await settle();out.push(probe(key));};
  const pickWeapon=async(key,weapon,label)=>{await roles(key);const w=document.getElementById('viewerWeaponSelect');w.value=weapon;w.dispatchEvent(new Event('change',{bubbles:true}));await settle();out.push(probe(label||key+'+'+weapon));};
  const fireWeapon=async(label)=>{const b=document.getElementById('viewerFireBtn');if(!b||b.disabled)return;b.click();await sleep(1300);out.push(probe(label+'@fire'));await sleep(3200);out.push(probe(label+'@idle'));};
  await roles('original:01');
  const w=document.getElementById('viewerWeaponSelect'),opts=[...w.options].map(o=>o.value).filter(Boolean);
  if(opts.length){w.value=opts[0];w.dispatchEvent(new Event('change',{bubbles:true}));await settle();out.push(probe('original:01+weapon'));}
  await pickWeapon('original:03','M110 SASS','Soap+M110 SASS');
  await pickWeapon('original:08','M4A1','Sister Florence+M4A1');
  await pickWeapon('original:12','Benelli M4','Megan McNick+Benelli M4');
  await roles('original:01');
  await fireWeapon('Hipster+M40');
  await roles('original:05');
  await roles('original:09');
  await roles('own:09');
  document.querySelector('#viewerKinds [data-kind="weapons"]').click();await sleep(250);
  const wb=document.querySelector('#viewerList button');if(wb){wb.click();await settle();out.push(probe('weapon:'+wb.textContent.trim()));}
  const rb=[...document.querySelectorAll('#viewerList button')].find(b=>/RPG/i.test(b.textContent));
  if(rb){rb.click();await settle();out.push(probe('weapon:'+rb.textContent.trim()));}
  document.querySelector('#viewerKinds [data-kind="props"]').click();await sleep(250);

 const pb=document.querySelector('#viewerList button');if(pb){pb.click();await settle();out.push(probe('prop:'+pb.textContent.trim()));}
  document.querySelector('#viewerKinds [data-kind="roles"]').click();await sleep(250);await roles('original:01');
  window.__viewerAuditProbe=out;return JSON.stringify(out);

})()`;

const result = {
  map: mapId,
  ok: false,
  csn3d: null,
  vistaClasica: 'skip',
  png3d: 0,
  pngUi: 0,
  pngMobile: 0,
  png2d: 0,
  ui: null,
  viewer: null,
  viewerAudit: null,
  viewerProbe: null,
  moduleProbe: null,
  catalogAudit: null,
  arsenalAudit: null,
  inspectorAudit: null,
  move: null,
  combat: null,
  mobile: null,
  software: software,
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
  const chromeArgs = [
    '--remote-debugging-port=' + PORT,
    '--window-size=' + WINDOW,
    '--window-position=40,40',
    '--no-first-run',
    '--no-default-browser-check',
    '--disable-background-timer-throttling',
    '--disable-backgrounding-occluded-windows',
    '--disable-renderer-backgrounding',
    '--disable-features=CalculateNativeWinOcclusion'
  ];
  if (software) chromeArgs.push('--use-gl=angle', '--use-angle=swiftshader', '--enable-unsafe-swiftshader');
  chromeArgs.push('--user-data-dir=' + profile);
  chrome = spawn(CHROME, chromeArgs, { stdio: 'ignore' });
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
    if (m.method === 'Log.entryAdded' && m.params?.entry?.level === 'error') {
      errs.push(String((m.params.entry.url ? m.params.entry.url + ' ' : '') + (m.params.entry.text || '')).slice(0, 140));
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
    if (r.result?.exceptionDetails) errs.push(String(r.result.exceptionDetails.exception?.description || '').slice(0, 140));
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
  await send('Log.enable');
  if (mobileMode) {
    const dpr = Number(process.env.CSN_DPR || (software ? 1 : 2)) || 2;
    await send('Emulation.setDeviceMetricsOverride', { width: 390, height: 844, deviceScaleFactor: dpr, mobile: true, screenOrientation: { type: 'portraitPrimary', angle: 0 } });
    await send('Emulation.setTouchEmulationEnabled', { enabled: true, maxTouchPoints: 1 });
    try { await send('Emulation.setEmitTouchEventsForMouse', { enabled: true, configuration: 'mobile' }); } catch {}
  }
  await send('Page.navigate', { url: BASE_URL });
  await sleep(3000);
  try { await send('Page.bringToFront'); } catch {}

  await ev("localStorage.setItem('radsoldiers_nation','es');location.reload();");
  await sleep(10000);
  try { await send('Page.bringToFront'); } catch {}

  let mobileStart = null;
  if (uiMode || mobileMode) {
    const viewerScreen=(char,weapon,wait,fire)=>{const fireAction=fire?"document.getElementById('viewerFireBtn').click();await sleep("+wait+");":"";return "(async function(){const sleep=ms=>new Promise(r=>setTimeout(r,ms));document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();await sleep(1500);const c=document.getElementById('viewerCharacterSelect');c.value='"+char+"';c.dispatchEvent(new Event('change',{bubbles:true}));await sleep(1800);const w=document.getElementById('viewerWeaponSelect');for(let i=0;i<100&&(w.options.length<2||w.disabled);i++)await sleep(100);for(let a=0;a<4;a++){w.value='"+weapon+"';w.dispatchEvent(new Event('change',{bubbles:true}));for(let i=0;i<50&&!(window.__csnViewer.state.gripActor&&window.__csnViewer.state.gripActor.userData.gun);i++)await sleep(100);if(w.value==='"+weapon+"'&&window.__csnViewer.state.gripActor&&window.__csnViewer.state.gripActor.userData.gun)break;await sleep(300);}await sleep(150);const b=document.querySelector('#troopGrid .card-3d-box[data-card-spec]');if(b&&window.__csnCardEngine)await window.__csnCardEngine.activate(b,{kind:'roles',key:'"+char+"',skinIndex:0,weapon:'"+weapon+"'});await sleep(300);"+fireAction+"const s=window.__csnViewer.state,ia=s.idleActor,ga=s.gripActor,g=ga&&ga.userData.gun,f=g&&g.userData.flash;return JSON.stringify({weapon:w.value,idle:s.idleClipKey,fire:s.testFire,same:ia===ga,idleGun:!!(ia&&ia.userData.gun),gripGun:!!g,events:ia&&ia.userData._viewerFireEvents?ia.userData._viewerFireEvents.shots:null,testFlash:g&&g.userData._testFlash,flash:f?f.children.map(o=>o.material?o.material.opacity:o.intensity):null,last:s.lastFrame,now:performance.now(),frameReq:s.frameRequested,visible:document.getElementById('scr-viewer').classList.contains('on'),card:!!window.__csnViewer.getCardBox()});})()";};
    const screens = {
      nation: "localStorage.removeItem('radsoldiers_nation');location.reload();",
      menu: "showScreen('scr-play')",
      campanhub: "showScreen('scr-play');showCampaignView()",
      brief: "showScreen('scr-play');showMissionBriefing(0)",
      campaign1: "deployMission(0)",
      setup: "openSetup('eliminacion')",
      barracks: "document.getElementById('mnuBarracks').click()",
      viewer: "document.querySelector('#mainTabs [data-tab=\"viewer\"]').click()",
      hipster: "(async function(){document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();await new Promise(r=>setTimeout(r,1500));const s=document.getElementById('viewerCharacterSelect');s.value='original:01';s.dispatchEvent(new Event('change',{bubbles:true}));return s.value;})()",
      soap: "(async function(){document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();await new Promise(r=>setTimeout(r,1500));const c=document.getElementById('viewerCharacterSelect');c.value='original:03';c.dispatchEvent(new Event('change',{bubbles:true}));await new Promise(r=>setTimeout(r,1800));const w=document.getElementById('viewerWeaponSelect');w.value='M110 SASS';w.dispatchEvent(new Event('change',{bubbles:true}));return c.value+'|M110 SASS';})()",
      sneaky: "(async function(){document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();await new Promise(r=>setTimeout(r,1500));const c=document.getElementById('viewerCharacterSelect');c.value='original:06';c.dispatchEvent(new Event('change',{bubbles:true}));await new Promise(r=>setTimeout(r,1800));const w=document.getElementById('viewerWeaponSelect');w.value='MP7';w.dispatchEvent(new Event('change',{bubbles:true}));return c.value+'|MP7';})()",
      megan: "(async function(){document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();await new Promise(r=>setTimeout(r,1500));const c=document.getElementById('viewerCharacterSelect');c.value='original:12';c.dispatchEvent(new Event('change',{bubbles:true}));await new Promise(r=>setTimeout(r,1800));return c.value+'|Benelli M4';})()",
      sister: "(async function(){document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();await new Promise(r=>setTimeout(r,1500));const c=document.getElementById('viewerCharacterSelect');c.value='original:08';c.dispatchEvent(new Event('change',{bubbles:true}));await new Promise(r=>setTimeout(r,1800));return c.value+'|M4A1';})()",
      rpg: "(async function(){document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();await new Promise(r=>setTimeout(r,1500));document.querySelector('#viewerKinds [data-kind=\"weapons\"]').click();await new Promise(r=>setTimeout(r,1500));const b=[...document.querySelectorAll('#viewerList button')].find(x=>x.textContent.includes('RPG'));if(!b)throw new Error('no RPG');b.click();return b.textContent;})()",
      fire: "(async function(){document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();await new Promise(r=>setTimeout(r,1500));const c=document.getElementById('viewerCharacterSelect');c.value='original:01';c.dispatchEvent(new Event('change',{bubbles:true}));await new Promise(r=>setTimeout(r,1800));document.getElementById('viewerFireBtn').click();await new Promise(r=>setTimeout(r,1300));return JSON.stringify(window.__csnViewer.state.testFire);})()",
      pistol: viewerScreen('original:01','Pistol',0,false),
      pistolfire: viewerScreen('original:01','Pistol',1260,true),
      assaultfire: viewerScreen('original:01','AssaultRifle',1100,true),
      mp5kfire: viewerScreen('original:06','MP5K',1100,true),
      meshy09: "(async function(){document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();await new Promise(r=>setTimeout(r,1500));const c=document.getElementById('viewerCharacterSelect');c.value='own:09';c.dispatchEvent(new Event('change',{bubbles:true}));return c.value;})()",
      mp5k: "(async function(){document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();await new Promise(r=>setTimeout(r,1500));document.querySelector('#viewerKinds [data-kind=\"weapons\"]').click();await new Promise(r=>setTimeout(r,1500));const b=[...document.querySelectorAll('#viewerList button')].find(x=>x.textContent.includes('MP5K'));if(!b)throw new Error('no MP5K');b.click();return b.textContent;})()",
      minigun: "(async function(){document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();await new Promise(r=>setTimeout(r,1500));document.querySelector('#viewerKinds [data-kind=\"weapons\"]').click();await new Promise(r=>setTimeout(r,1500));const b=[...document.querySelectorAll('#viewerList button')].find(x=>x.textContent.includes('Minigun'));if(!b)throw new Error('no Minigun');b.click();return b.textContent;})()",
      how: "document.querySelector('#mainTabs [data-tab=\"how\"]').click()",
      troops: "document.querySelector('#mainTabs [data-tab=\"viewer\"]').click()",
      armory: "document.querySelector('#mainTabs [data-tab=\"arsenal\"]').click()",
      deployables: "document.querySelector('#mainTabs [data-tab=\"arsenal\"]').click();document.querySelector('#arsSectionSeg [data-arssec=\"deployables\"]').click()",
      inspector: "(async function(){document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();await new Promise(r=>setTimeout(r,1500));const b=document.querySelector('#troopGrid .troop-card[data-origin=\"Juego original\"] [data-inspector-open]')||document.querySelector('#troopGrid [data-inspector-open]');if(!b)throw new Error('no inspector');b.click();await new Promise(r=>setTimeout(r,2500));return !!(window.__csnInspector&&window.__csnInspector.isOpen());})()",
      game: "quickStart('almacen')",
      game3d: "quickStart('skirmish')",
      resume: "quickStart('almacen');document.querySelector('#mainTabs [data-tab=\"viewer\"]').click();document.querySelector('#mainTabs [data-tab=\"play\"]').click()"
    };
    const screenKey = auditMode ? 'viewer' : (mobileMode === 'game' ? 'game3d' : (mobileMode || uiMode));
    if (!screens[screenKey]) throw new Error('Pantalla ui no valida: ' + screenKey);
    const uiProbe = await ev(screens[screenKey]);
    if (uiMode && uiProbe !== null && uiProbe !== undefined) { try { result.uiProbe = JSON.parse(uiProbe); } catch { result.uiProbe = uiProbe; } }
    if (auditMode) {
      await ev("document.querySelector('#mainTabs [data-tab=\"viewer\"]').click()");
      await sleep(350);
      const rawModule = await ev("JSON.stringify({viewer:!!window.__csnViewer,cardEngine:!!window.__csnCardEngine,troopGrid:!!document.getElementById('troopGrid'),scripts:[...document.scripts].filter(s=>s.src).map(s=>s.src.split('/').slice(-2).join('/'))})");
      try { result.moduleProbe = JSON.parse(rawModule); } catch { result.moduleProbe = rawModule; }
      const rawCatalog = await ev("JSON.stringify((function(){const cards=[...document.querySelectorAll('#troopGrid .card-3d-box[data-card-spec]')],first=cards[0];if(first&&window.__csnCardEngine)window.__csnCardEngine.activate(first,JSON.parse(first.dataset.cardSpec));const troops=document.querySelectorAll('#troopGrid .troop-card').length,orig=document.querySelectorAll('#troopGrid .troop-card[data-origin=\"Juego original\"]').length,csn=document.querySelectorAll('#troopGrid .troop-card[data-origin=\"CSN\"]').length,files=(window.__csnViewer&&window.__csnViewer.getWeaponFiles&&window.__csnViewer.getWeaponFiles())||[];return {troops,orig,csn,weapons:files.length,opens:document.querySelectorAll('#troopGrid [data-inspector-open]').length,cards:cards.length,cardEngine:!!window.__csnCardEngine};})())");
      try { result.catalogAudit = JSON.parse(rawCatalog); } catch { result.catalogAudit = rawCatalog; }
      const rawInspector = await ev(`(async function(){
        const sleep=ms=>new Promise(r=>setTimeout(r,ms));
        const button=document.querySelector('#troopGrid .troop-card[data-origin="Juego original"] [data-inspector-open]')||document.querySelector('#troopGrid [data-inspector-open]');
        if(!button||!window.__csnInspector)return {ok:false,reason:'sin boton de inspector'};
        button.click();await sleep(1800);
        const root=document.getElementById('inspectorRoot'),stage=document.getElementById('inspectorStage');
        const select=document.querySelector('[data-inspector-weapon]'),fire=document.getElementById('inspectorFire');
        const auto=document.getElementById('inspectorAuto'),reset=document.getElementById('inspectorReset');
        const label=document.querySelector('[data-inspector-skin-name]');
        const startFireLabel=fire?fire.textContent.trim():'',startFireDisabled=!!fire&&fire.disabled;
        const weaponOption=select&&[...select.options].find(option=>option.value);
        if(select&&weaponOption){select.value=weaponOption.value;select.dispatchEvent(new Event('change',{bubbles:true}));await sleep(900);}
        const data={ok:!root.hidden&&!!stage&&stage.isConnected,open:!root.hidden,stage:!!stage&&stage.isConnected,skins:label?label.textContent.trim():'',weaponOptions:select?select.options.length:0,startFireLabel,startFireDisabled,fireLabel:fire?fire.textContent.trim():'',fireDisabled:!!fire&&fire.disabled,dragBound:!!stage&&stage.dataset.csnDragBound==='1',autoButton:!!auto,paused:!!(window.__csnViewer&&window.__csnViewer.state.inspectorOpen)};
        if(auto){auto.click();await sleep(200);data.autoPressedAfter=auto.getAttribute('aria-pressed');data.autoState=!!(window.__csnViewer&&window.__csnViewer.state.inspectorAutoSpin);}
        if(reset)reset.click();
        window.__csnInspector.close();await sleep(300);
        data.closed=root.hidden&&!document.body.classList.contains('inspector-open');
        return data;
      })()`, 30000);
      try { result.inspectorAudit = JSON.parse(rawInspector); } catch { result.inspectorAudit = rawInspector; }
      await sleep(1200);
      await ev("document.querySelector('#mainTabs [data-tab=\"arsenal\"]').click()");
      await sleep(350);
      const rawArsenal = await ev("JSON.stringify((function(){const original=document.querySelectorAll('#arsenalGrid .weapon-original').length,csn=document.querySelectorAll('#arsenalGrid .weapon-csn').length,placeholder=document.querySelectorAll('#arsenalGrid .card-3d-empty').length;document.querySelector('#arsSectionSeg [data-arssec=\"deployables\"]').click();const deployables=document.querySelectorAll('#deployableGrid [data-card-spec]').length;return {original,csn,placeholder,deployables};})())");
      try { result.arsenalAudit = JSON.parse(rawArsenal); } catch { result.arsenalAudit = rawArsenal; }
      await sleep(1200);
      await ev("document.querySelector('#mainTabs [data-tab=\"viewer\"]').click()");
      await sleep(350);
      const rawProbe = await ev(viewerAuditProbeExpr, 90000);
      try { result.viewerProbe = JSON.parse(rawProbe); } catch { result.viewerProbe = rawProbe; }
    }
    if (mobileMode === 'game') {
      for (let i = 0; i < 24; i++) {
        let g = null;
        try { g = JSON.parse(await ev('JSON.stringify(window.__csn3d||{})')); } catch {}
        if (g && g.geo === true) break;
        await sleep(500);
      }
    }
    if (mobileMode) mobileStart = { frame: await ev('(window.__csn3d&&window.__csn3d.frame)||0'), ms: Date.now() };
    else await sleep(waitMs);
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
    await ev("window.quickStart(" + JSON.stringify(moveMode || combatMode || mapId) + ")");
  }

  await sleep(waitMs);
  result.errores = errs.slice(0, 5);
  if (moveMode) {
    await ev("(function(){const u=G.units.find(x=>x.alive&&x.team===G.turn&&x.energy>0);if(!u)return 'no unit';selectUnit(u);const cells=[...reachable(u,u.energy).entries()].filter(e=>e[1]>0);cells.sort((a,b)=>b[1]-a[1]||a[0].localeCompare(b[0]));const c=cells[0];if(!c)return 'no tile';const xy=c[0].split(',').map(Number);const p={unitId:u.id,from:[u.x,u.y],to:xy,samples:[]};window.__moveProbe=p;const t0=performance.now();function step(){const m=T3.units&&T3.units.get(u.id),ud=m&&m.userData;p.samples.push({t:Math.round(performance.now()-t0),lx:u.x,ly:u.y,x:+(u.dx!=null?u.dx:u.x).toFixed(4),y:+(u.dy!=null?u.dy:u.y).toFixed(4),f:u.facing,yaw:+(u._dispYaw||0).toFixed(4),turn:!!u._turning,clip:(ud&&ud._clipKey)||null,ct:+(ud&&ud._clipCt||0).toFixed(3)});if(performance.now()-t0<3200)requestAnimationFrame(step);else p.done=true;}boardTileClick({x:xy[0],y:xy[1]});requestAnimationFrame(step);return 'ok';})()");
    await sleep(3900);
    const rawMove = await ev('JSON.stringify(window.__moveProbe||{})');
    try { result.move = JSON.parse(rawMove); } catch { result.move = rawMove; }
  }
  if (combatMode) {
    const fired = await ev("(function(){const shooter=G.units.find(u=>u.alive&&u.team===G.turn&&u.weapon);if(!shooter)return 'no shooter';const target=G.units.find(u=>u.alive&&u.team!==shooter.team&&u.role);if(!target)return 'no target';const dirs=[[1,0],[-1,0],[0,1],[0,-1]];const spot=dirs.map(d=>[shooter.x+d[0],shooter.y+d[1]]).find(p=>p[0]>=0&&p[1]>=0&&p[0]<W&&p[1]<H&&!blocked(p[0],p[1])&&!G.units.some(o=>o!==target&&o.alive&&o.x===p[0]&&o.y===p[1]));if(!spot)return 'no spot';target.x=spot[0];target.y=spot[1];target.dx=spot[0];target.dy=spot[1];selectUnit(shooter);window.__csnEvents.length=0;const fireKey=fireClipFor(shooter.weapon);const p={unitId:shooter.id,targetId:target.id,weapon:shooter.weapon,fireKey,fireEvents:!!(CLIPLIB.pack&&CLIPLIB.pack.clips&&CLIPLIB.pack.clips[fireKey]&&CLIPLIB.pack.clips[fireKey].events&&CLIPLIB.pack.clips[fireKey].events.length),view:VIEW_MODE,reduced:REDUCED_MOTION,noClips:!!window.__noClips,samples:[],events:[],ok:false};window.__combatProbe=p;const t0=performance.now();function step(){const m=T3&&T3.units&&T3.units.get(shooter.id),ud=m&&m.userData,mt=T3&&T3.units&&T3.units.get(target.id),ut=mt&&mt.userData;p.samples.push({t:Math.round(performance.now()-t0),key:(ud&&ud._clipKey)||null,ct:+(ud&&ud._clipCt||0).toFixed(3),ev:window.__csnEvents.length,flash:+((ud&&ud._flashPulse)||0).toFixed(2),recoil:+((ud&&ud._firePulse)||0).toFixed(2),hit:+((ud&&ud._hitPulse)||0).toFixed(2),keyT:(ut&&ut._clipKey)||null,ctT:+(ut&&ut._clipCt||0).toFixed(3),hitT:+((ut&&ut._hitPulse)||0).toFixed(2)});p.events=window.__csnEvents.slice();p.ok=p.events.some(e=>e.f==='PlayWeaponFire');if(performance.now()-t0<2600)requestAnimationFrame(step);else{p.done=true;}}const fired=tryShoot(shooter,target,shooter.weapon,null,{freeCost:true,silent:true,noReturn:true});p.fired=!!fired;if(!fired){p.done=true;return 'no fire';}requestAnimationFrame(step);return 'ok';})()");
    if (fired !== 'ok') result.errores.push('combate: ' + fired);
    await sleep(3300);
    const rawCombat = await ev('JSON.stringify(window.__combatProbe||{})');
    try { result.combat = JSON.parse(rawCombat); } catch { result.combat = rawCombat; }
  }
  let state = await ev('JSON.stringify(window.__csn3d)');
  let tries = 0;
  let parsed = null;
  while (!uiMode && !mobileMode && tries < 3) {
    try { parsed = JSON.parse(state); } catch { parsed = null; }
    if (parsed && parsed.units > 0) break;
    tries++;
    try { await send('Page.bringToFront'); } catch {}
    await ev("(function(){try{window.dispatchEvent(new Event('focus'));}catch(e){}try{window.__render3D&&window.__render3D();}catch(e){}return 1})()");
    await sleep(2500);
    state = await ev('JSON.stringify(window.__csn3d)');
  }

  const shotSize = await shot(prefix + (mobileMode ? '_mobile' : uiMode ? '_ui' : '_3d'));
  result.csn3d = state;
  result.png3d = uiMode || mobileMode ? 0 : shotSize;
  result.pngUi = uiMode ? shotSize : 0;
  result.pngMobile = mobileMode ? shotSize : 0;
  if (uiMode || mobileMode) {
    const uiState = await ev("JSON.stringify({step:document.body.dataset.step,state:document.body.dataset.state,count:document.getElementById('stepCount')?.textContent,label:document.getElementById('stepLabel')?.textContent,detail:document.getElementById('stepDetail')?.textContent,screen:[...document.querySelectorAll('.screen.on')].map(s=>s.id)})");
    try { result.ui = JSON.parse(uiState); } catch { result.ui = uiState; }
  }
  if (uiMode) {
    const viewerState = await ev("(function(){try{const v=window.__csnViewer&&window.__csnViewer.state;if(!v)return JSON.stringify({error:'sin viewer'});const models=[];Object.keys(v.models||{}).forEach(kind=>{Object.keys(v.models[kind]||{}).forEach(k=>{const m=v.models[kind][k],mesh=(m.userData&&m.userData.mesh3)||m.getObjectByProperty('isSkinnedMesh',true)||m.getObjectByProperty('isMesh',true);if(!mesh||!mesh.geometry)return;const g=mesh.geometry,p=g.attributes&&g.attributes.position&&g.attributes.position.array,idx=g.index&&g.index.array;let vol=0;if(p&&idx){for(let i=0;i<idx.length;i+=3){const a=idx[i]*3,b=idx[i+1]*3,c=idx[i+2]*3;vol+=(p[a]*(p[b+1]*p[c+2]-p[b+2]*p[c+1])-p[a+1]*(p[b]*p[c+2]-p[b+2]*p[c])+p[a+2]*(p[b]*p[c+1]-p[b+1]*p[c]))/6;}}const box=new THREE.Box3().setFromObject(m),size=new THREE.Vector3();box.getSize(size);models.push({kind,key:k,vol:+vol.toFixed(3),size:[+size.x.toFixed(3),+size.y.toFixed(3),+size.z.toFixed(3)],side:mesh.material.side,transparent:!!mesh.material.transparent,opacity:+mesh.material.opacity.toFixed(2),alphaTest:+(mesh.material.alphaTest||0).toFixed(2),grip:!!(m.userData&&m.userData.grip),gun:!!(m.userData&&m.userData.viewerGun),meshy:!!(m.userData&&m.userData.meshy)});});});return JSON.stringify({name:v.name,kind:v.kind,models});}catch(e){return JSON.stringify({error:String(e.message||e)});}})()");
    try { result.viewer = JSON.parse(viewerState); } catch { result.viewer = viewerState; }
    if (auditMode) result.viewerAudit = result.viewer;
  }
  if (mobileMode) {
    try { parsed = JSON.parse(state); } catch { parsed = null; }
    const rawMobile = await ev("JSON.stringify((function(){const b=document.getElementById('board'),br=b&&b.getBoundingClientRect(),acts=[...document.querySelectorAll('.actions button')].map(e=>e.getBoundingClientRect().height).filter(h=>h>0),tabs=[...document.querySelectorAll('nav.tabs button')].map(e=>e.getBoundingClientRect().height).filter(h=>h>0),de=document.documentElement;return {w:innerWidth,h:innerHeight,dpr:devicePixelRatio,touch:'ontouchstart' in window,scrollW:de.scrollWidth,clientW:de.clientWidth,board:br?{x:+br.x.toFixed(1),y:+br.y.toFixed(1),w:+br.width.toFixed(1),h:+br.height.toFixed(1),shown:br.width>0&&br.height>0}:null,actions:{count:acts.length,min:acts.length?Math.min(...acts):0},tabs:{count:tabs.length,min:tabs.length?Math.min(...tabs):0},sw:!!(window.__csn3d&&window.__csn3d.sw),fps:0};})())");
    try {
      result.mobile = JSON.parse(rawMobile);
      if (mobileStart && result.mobile && parsed && parsed.frame > mobileStart.frame) {
        result.mobile.fps = +((parsed.frame - mobileStart.frame) / ((Date.now() - mobileStart.ms) / 1000)).toFixed(1);
      }
    } catch { result.mobile = rawMobile; }
  }

  let want2d = false;
  try { parsed = JSON.parse(state); } catch { parsed = null; }
  want2d = !uiMode && !mobileMode && (process.argv.includes('--2d') || !(parsed && parsed.units > 0));
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

  const mobileUiMode = !!(mobileMode && mobileMode !== 'game');
  const sceneOk = uiMode || mobileUiMode ? true : !!(parsed && parsed.units > 0);
  const pngOk = uiMode ? result.pngUi > 0 : mobileMode ? result.pngMobile > 0 : result.png3d > 0;
  const moveOk = !moveMode || !!(result.move && result.move.samples && result.move.samples.length > 10);
  const combatOk = !combatMode || !!(result.combat && result.combat.ok && result.combat.samples && result.combat.samples.length > 10 && result.combat.events && result.combat.events.length > 0);
  const mobileOk = !mobileMode || !!(result.mobile && result.mobile.w <= 430 && result.mobile.scrollW <= result.mobile.clientW + 2 && (!result.mobile.board || !result.mobile.board.shown || result.mobile.board.w <= result.mobile.w + 2) && (!result.mobile.actions.count || result.mobile.actions.min >= 44));
  const geoOk = !mobileMode || mobileMode !== 'game' || !!(parsed && parsed.geo === true);
  const softwareOk = !software || !!(parsed && parsed.sw === true);
  let viewerOk = !auditMode || !!(result.viewerAudit && Array.isArray(result.viewerAudit.models) && result.viewerAudit.models.length > 0 && result.viewerAudit.models.every(m => {
    if (!Number.isFinite(m.vol) || m.transparent !== false || m.opacity !== 1) return false;
    if (!m.size.every(n => Number.isFinite(n) && n > 0.001)) return false;
    if (m.kind === 'roles' || m.kind === 'weapons') return (m.side === 0 || (m.kind === 'roles' && m.meshy && m.side === 2)) && m.alphaTest === 0 && (m.kind !== 'roles' || m.meshy || m.vol > 0);
    return m.size.every(Number.isFinite);
  }));
  if (auditMode) {
    const catalog = result.catalogAudit && typeof result.catalogAudit === 'object' ? result.catalogAudit : {};
    const arsenalAudit = result.arsenalAudit && typeof result.arsenalAudit === 'object' ? result.arsenalAudit : {};
    const inspectorAudit = result.inspectorAudit && typeof result.inspectorAudit === 'object' ? result.inspectorAudit : {};
    const catalogOk = catalog.troops === 24 && catalog.orig === 19 && catalog.csn === 5 && catalog.weapons === 23 && catalog.opens === 24 && catalog.cardEngine === true;
    const arsenalOk = arsenalAudit.original === 23 && arsenalAudit.csn === 39 && arsenalAudit.deployables === 10;
    const inspectorOk = inspectorAudit.ok === true && inspectorAudit.open === true && inspectorAudit.stage === true && inspectorAudit.paused === true && inspectorAudit.weaponOptions >= 24 && /Elige/.test(inspectorAudit.startFireLabel || '') && inspectorAudit.startFireDisabled === true && /Probar/.test(inspectorAudit.fireLabel || '') && inspectorAudit.fireDisabled === false && inspectorAudit.dragBound === true && inspectorAudit.autoButton === true && inspectorAudit.autoPressedAfter === 'true' && inspectorAudit.autoState === true && inspectorAudit.closed === true;
    viewerOk = viewerOk && catalogOk && arsenalOk && inspectorOk;
    const probes = Array.isArray(result.viewerProbe) ? result.viewerProbe : [];
    const required = ['original:01', 'original:01+weapon', 'original:05', 'own:09'];
    const gunOk = probes.some(p => p.label === 'original:01+weapon' && p.gun);
    const meshyOk = probes.some(p => p.label === 'own:09' && p.meshy);
    const individualOk = probes.some(p => p.label.startsWith('weapon:') && p.geometryOk) && probes.some(p => p.label.startsWith('prop:') && p.geometryOk);
    const probeOk = probes.length >= 6 && required.every(label => probes.some(p => p.label === label && p.statusHidden && !p.status && p.geometryOk)) && gunOk && meshyOk && individualOk;
    viewerOk = viewerOk && probeOk;
  }
  result.ok = sceneOk && pngOk && moveOk && combatOk && mobileOk && geoOk && softwareOk && viewerOk && errs.length === 0;
  if (moveMode && !moveOk) result.errores.push('movimiento sin muestras');
  if (combatMode && !combatOk) result.errores.push('combate sin eventos de clip');
  if (mobileMode && !mobileOk) result.errores.push('movil: layout fuera de viewport');
  if (mobileMode && !geoOk) result.errores.push('movil: geometria del mapa no lista');
  if (software && !softwareOk) result.errores.push('swiftshader no activo');
  if (auditMode && !viewerOk) result.errores.push('auditoria de visor/catalogo/inspector incompleta');
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
