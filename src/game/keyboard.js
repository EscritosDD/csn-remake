import { T3, VIEW_MODE, resetCam3D } from '../render3d/index.js';

export const _keysHeld={};
export function wireKeyboard(ctx){
 const {selectUnit,updateUI,draw,undoLastMove}=ctx;
window.addEventListener('blur',()=>{Object.keys(_keysHeld).forEach(k=>{_keysHeld[k]=false;});});
document.addEventListener('visibilitychange',()=>{if(document.hidden)Object.keys(_keysHeld).forEach(k=>{_keysHeld[k]=false;});});
window.addEventListener('keyup',e=>{_keysHeld[e.key.toLowerCase()]=false;});
window.addEventListener('keydown',e=>{
  if(document.body.dataset.state!=='playing'||!ctx.G||ctx.G.over||ctx.G.aiBusy)return;
  const tag=(e.target&&e.target.tagName)||'';
  if(tag==='INPUT'||tag==='TEXTAREA'||tag==='SELECT')return;
  const k=e.key.toLowerCase();
  _keysHeld[k]=true;
  if(['arrowup','arrowdown','arrowleft','arrowright'].includes(k))return;
  if(k==='tab'){
    e.preventDefault();
    const mine=ctx.G.units.filter(u=>u.alive&&u.team===ctx.G.turn);
    if(mine.length){const idx=mine.indexOf(ctx.G.selected);selectUnit(mine[(idx+1)%mine.length]);}
    return;
  }
  if(k==='escape'){if(ctx.G.actionMode!=='move'){ctx.G.actionMode='move';updateUI();draw();}return;}
  if(k==='z'){e.preventDefault();undoLastMove();return;}
  const actMap={'1':'shoot','2':'pistol','3':'grenade','4':'overwatch','5':'special'};
  if(actMap[k]){const btn=document.querySelector('#actionBar [data-act="'+actMap[k]+'"]');if(btn&&!btn.disabled){btn.click();btn.blur();}return;}
  if(T3&&T3.cam&&VIEW_MODE==='3d'){
    if(k==='q')T3.cam.yaw-=0.38;
    else if(k==='e')T3.cam.yaw+=0.38;
    else if(k==='c')resetCam3D();
    else if(k==='+'||k==='=')T3.cam.dist=Math.max(6,T3.cam.dist-1.8);
    else if(k==='-'||k==='_')T3.cam.dist=Math.min(11,T3.cam.dist+1.8);
  }
});
}
