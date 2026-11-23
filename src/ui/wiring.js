import { audioCtx, lsSet } from '../core-and-audio.js';
import { REAL } from '../render3d/index.js';
import { undoLastMove } from '../game/index.js';
import { CHAR_PREFS, charsForRole, loadChars, saveChars, setCHAR_PREFS } from '../game/chars.js';
import { armTab, buildSquads, coinsGet, coinsSet, openBarracks, renderAbilityCatalog, rolePortraitURL, showScreen, syncPlayingViewport, toast, updateUI } from './index.js';

export function wireUI(ctx){
const {TUT_TEXTS,tutShow,tutHide}=ctx;
document.addEventListener('pointerdown',()=>{audioCtx();});
document.getElementById('undoBtn')?.addEventListener('click',undoLastMove);
document.getElementById('logBtn')?.addEventListener('click',()=>{const d=document.getElementById('logDrawer');if(d)d.open=!d.open;});
document.getElementById('quickStartBtn').onclick=()=>window.quickStart('almacen');
document.getElementById('quickSkirmishBtn').onclick=()=>window.quickStart('skirmish');
document.getElementById('heroSkirmishBtn').onclick=()=>window.quickStart('skirmish');
(function(){
  const ga=document.getElementById('gameArea');
  if(ga&&!document.getElementById('actionBar')){
    const bar=document.createElement('div');bar.id='actionBar';bar.className='actionBar';
    document.body.appendChild(bar);
  }
  syncPlayingViewport();
  window.addEventListener('resize',()=>requestAnimationFrame(syncPlayingViewport),{passive:true});
})();
document.addEventListener('mouseover',e=>{
  const b=e.target&&e.target.closest?e.target.closest('.actions button'):null;
  if(b&&!b.title){b.title=b.textContent.replace(/\s+/g,' ').trim();}
},{passive:true});
(function wireTutorial(){
  const b=document.getElementById('tutBubble');if(!b)return;
  b.querySelectorAll('[data-tut]').forEach(btn=>btn.onclick=()=>{const k=btn.dataset.tut;const t=document.getElementById('tutText');if(t)t.textContent=TUT_TEXTS[k]||'';toast(TUT_TEXTS[k]||'');});
  const d=document.getElementById('tutDone');if(d)d.onclick=tutHide;
})();
(function wireOrigMenu(){
  const q=document.getElementById('mnuQuick');if(q)q.onclick=()=>window.quickStart('almacen');
  const o=document.getElementById('mnuOnline');if(o)o.onclick=()=>toast('Sin servidor de partidas: el online del original no está disponible. Juega contra la IA o a dos jugadores en local.');
  const e=document.getElementById('mnuExpansions');if(e)e.onclick=()=>toast('Expansiones: aún no hay contenido descargable. El arte propio y las skins llegan por fases.');
  const bk=document.getElementById('mnuBarracks');if(bk)bk.onclick=openBarracks;
  document.addEventListener('change',(e)=>{const t=e.target;if(t&&t.dataset&&t.dataset.charrole){const role=t.dataset.charrole;setCHAR_PREFS(loadChars());CHAR_PREFS[role]=t.value;saveChars(CHAR_PREFS);const opts=charsForRole(role),cur=opts.find(o=>o.name===t.value)||opts[0],card=t.closest('.barrack-card'),img=card&&card.querySelector('.barrack-portrait');if(img)img.src=rolePortraitURL(role,cur)||'assets/ui/retrato_capitan.png';if(ctx.G)updateUI();else if(typeof buildSquads==='function')buildSquads();toast('Personaje de '+role+': '+t.value+'.');}});
  const ar=document.getElementById('mnuArmory');if(ar)ar.onclick=()=>{showScreen('scr-arsenal');armTab('armas');};
  const bb=document.getElementById('barrBack');if(bb)bb.onclick=()=>showScreen('scr-play');
  coinsSet(coinsGet());
  renderAbilityCatalog();
  /* Reglas plegables: el muro de texto de "Como se juega" pasa a 23
     resumenes de una linea que se abren al tocar (F9). */
  try{
    document.querySelectorAll('.howto > div').forEach(d=>{
      if(d.dataset.plegado)return;d.dataset.plegado='1';
      const t=d.querySelector('b');const ps=Array.from(d.querySelectorAll('p'));
      const det=document.createElement('details');det.className='rule';
      const sum=document.createElement('summary');
      sum.innerHTML=t?t.innerHTML:'Regla';
      det.appendChild(sum);
      ps.forEach(p=>det.appendChild(p));
      d.innerHTML='';d.appendChild(det);
    });
  }catch(e){}
})();
(function bootScreen(){
  const start=()=>{
    const el=document.getElementById('bootScreen'),fill=document.getElementById('bootFill'),msg=document.getElementById('bootMsg');
    if(!el)return;
    let p=6;const t0=Date.now();
    const it=setInterval(()=>{
      p=Math.min(96,p+2+Math.random()*3);
      if(typeof REAL!=='undefined'&&REAL.ready){p=Math.min(100,p+12);if(msg)msg.textContent='Listo: soldado, animaciones y mapas cargados.';}
      if(fill)fill.style.width=p+'%';
      if(p>=100||Date.now()-t0>9000){clearInterval(it);el.style.transition='opacity .45s';el.style.opacity='0';setTimeout(()=>{el.style.display='none';},480);}
    },130);
  };
  if(document.readyState==='loading')document.addEventListener('DOMContentLoaded',start);else start();
})();
document.getElementById('quickSmokeBtn').onclick=()=>window.quickSmoke();
document.getElementById('quickFlashBtn').onclick=()=>window.quickFlash();
}
