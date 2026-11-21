import { draw } from './board.js';
import { fx3Float, fx3Sparks } from '../render3d/fx3d.js';

export const REDUCED_MOTION=!!(window.matchMedia&&window.matchMedia('(prefers-reduced-motion: reduce)').matches);

export const FX={t:0,lastDraw:0,parts:[],floats:[],tracers:[],shake:0};

export function fxFloat(x,y,txt,col){if(REDUCED_MOTION)return;FX.floats.push({x:x,y:y,txt:txt,col:col||'#ffffff',born:FX.t});if(FX.floats.length>14)FX.floats.shift();if(typeof fx3Float==='function')fx3Float(x,y,txt,col);}

export function fxBurst(x,y,n,col){if(REDUCED_MOTION)return;for(let i=0;i<n;i++){const a=Math.random()*Math.PI*2,sp=.5+Math.random()*1.7;FX.parts.push({x:x+.5,y:y+.45,vx:Math.cos(a)*sp,vy:Math.sin(a)*sp-.7,born:FX.t,life:420+Math.random()*380,col:col});}if(FX.parts.length>220)FX.parts.splice(0,FX.parts.length-220);if(typeof fx3Sparks==='function')fx3Sparks(x,y,n,col);}

export function fxTracer(a,b){if(REDUCED_MOTION)return;FX.tracers.push({x0:a.x,y0:a.y,x1:b.x,y1:b.y,born:FX.t});if(FX.tracers.length>10)FX.tracers.shift();}

export function drawFX(S){
  if(REDUCED_MOTION)return;
  const now=FX.t;
  /* polvo en suspensión: el almacén respira aunque nadie se mueva */
  ctx.fillStyle='rgba(255,246,220,.10)';
  for(let i=0;i<12;i++){
    const mx=((i*173.3+now*.006*(1+(i%4)*.37))%(W*S));
    const my=((i*97.7)%(H*S))+Math.sin(now/900+i*1.7)*7;
    ctx.beginPath();ctx.arc(mx,my,1.6+(i%3)*.7,0,7);ctx.fill();
  }
  /* trazadoras de los disparos recientes */
  FX.tracers=FX.tracers.filter(tr=>now-tr.born<150);
  FX.tracers.forEach(tr=>{
    const k=1-(now-tr.born)/150;
    ctx.beginPath();ctx.moveTo((tr.x0+.5)*S,(tr.y0+.42)*S);ctx.lineTo((tr.x1+.5)*S,(tr.y1+.42)*S);
    ctx.strokeStyle='rgba(255,214,110,'+(0.85*k).toFixed(3)+')';ctx.lineWidth=2.6;ctx.stroke();
    ctx.beginPath();ctx.arc((tr.x1+.5)*S,(tr.y1+.42)*S,5*k+1.5,0,7);ctx.fillStyle='rgba(255,240,190,'+(0.9*k).toFixed(3)+')';ctx.fill();
  });
  /* partículas de impacto y de explosión */
  FX.parts=FX.parts.filter(p=>now-p.born<p.life);
  FX.parts.forEach(p=>{
    const age=(now-p.born)/1000,k=1-(now-p.born)/p.life;
    const px=(p.x+p.vx*age)*S, py=(p.y+p.vy*age+1.4*age*age)*S;
    ctx.beginPath();ctx.arc(px,py,2.6*k+0.7,0,7);ctx.fillStyle=p.col;ctx.globalAlpha=Math.max(0,k);ctx.fill();ctx.globalAlpha=1;
  });
  /* números de daño flotantes */
  FX.floats=FX.floats.filter(f=>now-f.born<950);
  FX.floats.forEach(f=>{
    const age=now-f.born,k=age<650?1:1-(age-650)/300;
    const px=(f.x+.5)*S, py=f.y*S+16-age/950*30;
    ctx.font='700 17px JetBrains Mono, monospace';ctx.textAlign='center';
    ctx.globalAlpha=Math.max(0,k);
    ctx.lineWidth=3.5;ctx.strokeStyle='rgba(8,10,6,.85)';ctx.strokeText(f.txt,px,py);
    ctx.fillStyle=f.col;ctx.fillText(f.txt,px,py);
    ctx.globalAlpha=1;ctx.textAlign='left';
  });
}

export function fxLoop(ts){
  FX.t=ts||0;
  const ga=document.getElementById('gameArea');
  if(G&&ga&&ga.style.display!=='none'&&FX.t-FX.lastDraw>=(REDUCED_MOTION?500:33)){FX.lastDraw=FX.t;draw();}
  if(G&&ga&&ga.style.display!=='none'&&window.__render3D)window.__render3D();
  if(window.__renderDemo)window.__renderDemo();
  requestAnimationFrame(fxLoop);
}
