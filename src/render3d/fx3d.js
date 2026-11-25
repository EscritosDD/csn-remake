import { tileWorldY, falloffFactor } from '../game/board.js';
import { cheb } from '../core-and-audio.js';
import { WEAPONS, PISTOL } from '../data/weapons.js';
import { VIEW_MODE, T3, w2cx, w2cz } from './scene.js';
import { TEAM_A, TEAM_B } from './env.js';
import { arcadeTracer, arcadeHit, arcadeExplosion, arcadeFloat, tickArcadeFx } from './fx-arcade.js';

let _energyPrev=-1;
export function setEnergyPreview(cost){
  if(cost===_energyPrev)return;_energyPrev=cost;
  const pips=document.querySelectorAll('#unitCard .epips i');
  if(!pips||typeof pips.length!=='number')return;
  for(let i=0;i<pips.length;i++)pips[i].classList.remove('prev');
  if(cost>0){
    const lit=[];for(let i=0;i<pips.length;i++)if(!pips[i].classList.contains('off'))lit.push(pips[i]);
    const start=Math.max(0,lit.length-cost);
    for(let i=start;i<lit.length;i++)lit[i].classList.add('prev');
  }
}

export function fx3Spawn(mesh,life,onTick){
  if(!T3||!T3.fxGroup)return;
  if(T3.fxItems.length>42){const old=T3.fxItems.shift();if(old&&old.mesh)T3.fxGroup.remove(old.mesh);}
  T3.fxGroup.add(mesh);
  T3.fxItems.push({mesh:mesh,born:FX.t,life:life,onTick:onTick});
}

export function fx3Shot(from,to,cat){
  if(!T3||VIEW_MODE!=='3d'||REDUCED_MOTION||!from||!to||from.x==null||to.x==null)return;
  arcadeTracer(from,to,cat,G&&G.turn||'A',FX.t,REDUCED_MOTION);
}

export function fx3Proj(from,to,kind){
  if(!T3||VIEW_MODE!=='3d'||REDUCED_MOTION||!from||!to)return;
  const p0=new THREE.Vector3(w2cx(from.x),0.75,w2cz(from.y));
  const p1=new THREE.Vector3(w2cx(to.x),0.2,w2cz(to.y));
  const col=kind==='smoke'?0xdde2e6:(kind==='flash'?0xfff199:0x577043);
  const orb=new THREE.Mesh(new THREE.SphereGeometry(0.11,10,8),new THREE.MeshBasicMaterial({color:col}));
  orb.position.copy(p0);
  fx3Spawn(orb,300,(it,k)=>{
    orb.position.lerpVectors(p0,p1,k);
    orb.position.y+=Math.sin(k*Math.PI)*1.35;
    orb.rotation.x=k*8;
  });
}

export function fx3Explosion(x,y,kind){
  if(!T3||VIEW_MODE!=='3d'||REDUCED_MOTION)return;
  arcadeExplosion(x,y,kind,FX.t,REDUCED_MOTION);
}

export function fx3Sparks(x,y,n,col){
  if(!T3||VIEW_MODE!=='3d'||REDUCED_MOTION)return;
  arcadeHit(x,y,n,col,FX.t,REDUCED_MOTION);
}

export function fx3Float(x,y,txt,col){
  if(!T3||VIEW_MODE!=='3d'||REDUCED_MOTION)return;
  arcadeFloat(x,y,txt,col,FX.t,REDUCED_MOTION);
}

export function tickFx3D(w,h){
  if(!T3||!T3.fxGroup)return;
  const now=FX.t;
  for(let i=T3.fxItems.length-1;i>=0;i--){
    const it=T3.fxItems[i],age=now-it.born;
    if(age>=it.life){T3.fxGroup.remove(it.mesh);T3.fxItems.splice(i,1);}
    else{it.onTick(it,Math.max(0,Math.min(1,age/it.life)));}
  }
  tickArcadeFx(w,h,FX.t);
}

export function updateHover3D(w,h){
  const tip=document.getElementById('glTooltip');
  if(!T3||!G||!T3.aimGroup){if(tip)tip.style.display='none';return;}
  const sel=G.selected;
  const sig=[hoverTile?(hoverTile.x+','+hoverTile.y):'-',sel?sel.id:'-',sel?sel.x+','+sel.y:'-',sel?sel.energy:'-',G.actionMode,G.turn,G.aiBusy?1:0].join('#');
  if(sig!==T3.hoverSig){
    T3.hoverSig=sig;
    while(T3.aimGroup.children.length)T3.aimGroup.remove(T3.aimGroup.children[0]);
    if(hoverTile&&sel&&sel.alive&&sel.team===G.turn&&!G.aiBusy&&!G.over){
      const hx=hoverTile.x,hy=hoverTile.y;
      if(G.actionMode==='grenade'&&cheb(sel,hoverTile)<=3&&cheb(sel,hoverTile)>0){
        for(let dy=-1;dy<=1;dy++)for(let dx=-1;dx<=1;dx++){const tx=hx+dx,ty=hy+dy;if(tx<0||ty<0||tx>=W||ty>=H)continue;
          const p=new THREE.Mesh(new THREE.PlaneGeometry(0.92,0.92),new THREE.MeshBasicMaterial({color:0xff6458,transparent:true,opacity:0.38,depthWrite:false,alphaMap:(T3.tileMasks&&T3.tileMasks['aoe'])||null}));
          p.rotation.x=-Math.PI/2;p.position.set(w2cx(tx),tileWorldY(tx,ty)+0.072,w2cz(ty));T3.aimGroup.add(p);}
      } else if(G.actionMode==='smoke'&&cheb(sel,hoverTile)<=4&&cheb(sel,hoverTile)>0){
        [[0,0],[1,0],[-1,0],[0,1],[0,-1]].forEach(dd=>{const tx=hx+dd[0],ty=hy+dd[1];if(tx<0||ty<0||tx>=W||ty>=H)return;
          const p=new THREE.Mesh(new THREE.PlaneGeometry(0.92,0.92),new THREE.MeshBasicMaterial({color:0xe8ecf0,transparent:true,opacity:0.42,depthWrite:false,alphaMap:(T3.tileMasks&&T3.tileMasks['aoe'])||null}));
          p.rotation.x=-Math.PI/2;p.position.set(w2cx(tx),tileWorldY(tx,ty)+0.072,w2cz(ty));T3.aimGroup.add(p);});
      } else if(G.actionMode==='flash'&&cheb(sel,hoverTile)<=4){
        for(let dy=-1;dy<=1;dy++)for(let dx=-1;dx<=1;dx++){const tx=hx+dx,ty=hy+dy;if(tx<0||ty<0||tx>=W||ty>=H)continue;
          const p=new THREE.Mesh(new THREE.PlaneGeometry(0.92,0.92),new THREE.MeshBasicMaterial({color:0xffe26a,transparent:true,opacity:0.36,depthWrite:false,alphaMap:(T3.tileMasks&&T3.tileMasks['aoe'])||null}));
          p.rotation.x=-Math.PI/2;p.position.set(w2cx(tx),tileWorldY(tx,ty)+0.072,w2cz(ty));T3.aimGroup.add(p);}
      } else if(G.actionMode==='move'){
        const reach=reachable(sel,sel.energy);
        reach.forEach((c,k)=>{const [cx,cy]=k.split(',').map(Number);if(cx===hx&&cy===hy)return;
          if([[1,0],[-1,0],[0,1],[0,-1]].some(dd=>!!obAt(cx+dd[0],cy+dd[1]))){
            const mk=new THREE.Mesh(new THREE.CircleGeometry(0.16,20),new THREE.MeshBasicMaterial({color:0x57c46a,transparent:true,opacity:0.55,side:THREE.DoubleSide}));
            mk.rotation.x=-Math.PI/2;mk.position.set(w2cx(cx),tileWorldY(cx,cy)+0.075,w2cz(cy));T3.aimGroup.add(mk);
          }
        });
        if(reach.has(hx+','+hy)){
          [[1,0,0.44,0,0],[ -1,0,-0.44,0,0],[0,1,0,0.44,Math.PI/2],[0,-1,0,-0.44,Math.PI/2]].forEach(dd=>{
            const ob=obAt(hx+dd[0],hy+dd[1]);
            if(ob){
              const sh=new THREE.Mesh(new THREE.BoxGeometry(0.07,0.22,0.46),new THREE.MeshBasicMaterial({color:0x57c46a,transparent:true,opacity:0.88}));
              sh.position.set(w2cx(hx)+dd[2],tileWorldY(hx,hy)+0.2,w2cz(hy)+dd[3]);sh.rotation.y=dd[4];T3.aimGroup.add(sh);
            }
          });
        }
      }
      const foe=unitAt(hx,hy)||(effMode(G)==='escolta'&&sel.team==='B'?droneAt(hx,hy):null);
      const bar=barrelAt(hx,hy),ob=obAt(hx,hy);
      const isAimTarget=(foe&&foe.team!==sel.team&&(G.actionMode==='shoot'||G.actionMode==='pistol'||G.actionMode==='move'||G.actionMode==='special'))||((bar||(ob&&ob.type==='crate'))&&(G.actionMode==='shoot'||G.actionMode==='pistol'));
      if(isAimTarget){
        const w2=G.actionMode==='pistol'?WEAPONS[PISTOL]:WEAPONS[sel.weapon];
        const okLOS=foe?hitChance(sel,foe,w2)>0:(cheb(sel,hoverTile)<=w2.rng&&hasLOS(sel,hoverTile)&&!smokeBlocksLOS(sel,hoverTile));
        const pts=[new THREE.Vector3(w2cx(sel.x),tileWorldY(sel.x,sel.y)+0.72,w2cz(sel.y)),new THREE.Vector3(w2cx(hx),tileWorldY(hx,hy)+0.64,w2cz(hy))];
        const lg=new THREE.BufferGeometry().setFromPoints(pts);
        const lm=new THREE.Line(lg,new THREE.LineBasicMaterial({color:okLOS?0xf2b234:0xe5484d,transparent:true,opacity:0.85}));
        T3.aimGroup.add(lm);
        const tr=new THREE.Mesh(new THREE.RingGeometry(0.36,0.48,28),new THREE.MeshBasicMaterial({color:okLOS?0xff3d3d:0x883838,side:THREE.DoubleSide}));
        tr.rotation.x=-Math.PI/2;tr.position.set(w2cx(hx),tileWorldY(hx,hy)+0.075,w2cz(hy));T3.aimGroup.add(tr);
      }
    }
  }
  if(!tip)return;
  let txt='',cls='',wx=0,wy=1.7,wz=0,show=false,moveCost=0;
  if(hoverTile&&sel&&sel.alive&&sel.team===G.turn&&!G.aiBusy&&!G.over){
    const hx=hoverTile.x,hy=hoverTile.y;
    const foe=unitAt(hx,hy)||(effMode(G)==='escolta'&&sel.team==='B'?droneAt(hx,hy):null);
    const bar=barrelAt(hx,hy),ob=obAt(hx,hy);
    wx=w2cx(hx);wz=w2cz(hy);wy+=tileWorldY(hx,hy);
    if(foe&&foe.team!==sel.team&&(G.actionMode==='shoot'||G.actionMode==='pistol'||G.actionMode==='move'||G.actionMode==='special')){
      const w2=G.actionMode==='pistol'?WEAPONS[PISTOL]:WEAPONS[sel.weapon];
      const p=hitChance(sel,foe,w2);
      if(p>0){
        const flk=foe.role&&isFlanked(sel,foe),covLvl=coverLevel(foe,sel);
        const fo=falloffFactor(sel,foe,w2),eff=Math.max(1,Math.round(w2.dmg*fo));
        txt='Acierto '+p+'% · '+eff+' daño'+(fo<1?' · −'+Math.round((1-fo)*100)+'% distancia':'')+(flk?' · ⚡ Flanqueo':covLvl>0?' · 🛡️ Cobertura '+covLvl+' (−'+[0,12,25,40][covLvl]+'%)':'');
        cls=covLvl>0?'cov':'';
      } else {
        txt=foe.invisible?'Invisible':(smokeBlocksLOS(sel,foe)?'Sin tiro · humo M18':'Sin tiro · fuera de alcance/VDV');
        cls='bad';
      }
      wy=1.82;show=true;
    } else if(bar&&(G.actionMode==='shoot'||G.actionMode==='pistol')){
      const w2=G.actionMode==='pistol'?WEAPONS[PISTOL]:WEAPONS[sel.weapon];
      const ok=cheb(sel,bar)<=w2.rng&&hasLOS(sel,bar)&&!smokeBlocksLOS(sel,bar);
      txt=ok?'💥 Barril · 70 daño en área':'Sin tiro al barril';cls=ok?'':'bad';wy=1.25;show=true;
    } else if(ob&&ob.type==='crate'&&(G.actionMode==='shoot'||G.actionMode==='pistol')){
      const w2=G.actionMode==='pistol'?WEAPONS[PISTOL]:WEAPONS[sel.weapon];
      const ok=cheb(sel,ob)<=w2.rng&&hasLOS(sel,ob)&&!smokeBlocksLOS(sel,ob);
      txt=ok?('📦 Caja · '+ob.hp+'/'+ob.maxHp+' PV'):'Sin tiro a la caja';cls=ok?'':'bad';wy=1.1;show=true;
    } else if(G.actionMode==='grenade'&&cheb(sel,hoverTile)<=3&&cheb(sel,hoverTile)>0){
      txt='💣 Granada M67 · 75 daño área';wy=0.95;show=true;
    } else if(G.actionMode==='smoke'&&cheb(sel,hoverTile)<=4&&cheb(sel,hoverTile)>0){
      txt='💨 Cortina M18 · 2 rondas';wy=0.95;show=true;
    } else if(G.actionMode==='flash'&&cheb(sel,hoverTile)<=4){
      txt='✸ Aturdidora M84 · −6⚡ / −25%';wy=0.95;show=true;
    } else if(G.actionMode==='move'&&reachable(sel,sel.energy).has(hx+','+hy)){
      const cost=reachable(sel,sel.energy).get(hx+','+hy);moveCost=cost;
      const hasC=[[1,0],[-1,0],[0,1],[0,-1]].some(dd=>!!obAt(hx+dd[0],hy+dd[1]));
      txt='−'+cost+' ⚡'+(hasC?' · 🛡️ Cobertura aquí':'');cls=hasC?'cov':'';wy=0.95;show=true;
    }
  }
  if(!show){setEnergyPreview(0);tip.style.display='none';return;}
  const v=T3._projV||(T3._projV=new THREE.Vector3());
  v.set(wx,wy,wz).project(T3.camera);
  if(v.z<-1||v.z>1){setEnergyPreview(0);tip.style.display='none';return;}
  tip.className='gl-tooltip'+(cls?' '+cls:'');
  tip.textContent=txt;
  tip.style.left=((v.x*0.5+0.5)*w).toFixed(1)+'px';
  tip.style.top=((-v.y*0.5+0.5)*h).toFixed(1)+'px';
  tip.style.display='block';
  setEnergyPreview(moveCost);
}

export function updateUnitHuds3D(w,h){
  const host=document.getElementById('glUnitHuds');if(!host||!T3||!G)return;
  if(!T3.hudPool)T3.hudPool=new Map();
  const v=T3._projV||(T3._projV=new THREE.Vector3());
  const seen=new Set();
  const syncEntity=(key,rx,ry,hp,maxHp,team,tag,vet,energy,maxEnergy,selected)=>{
    seen.add(key);
    let rec=T3.hudPool.get(key);
    if(!rec){
      const el=document.createElement('div');el.className='gl-unit-hud';
      el.innerHTML='<div class="gl-hp-pill"><span class="gl-hp-dot"></span><div class="gl-hp-track"><div class="gl-hp-fill"></div></div><span class="gl-hp-num"></span><span class="gl-en-num" style="display:none"></span></div><div class="gl-unit-tag" style="display:none"></div>';
      host.appendChild(el);
      rec={el:el,dot:el.querySelector('.gl-hp-dot'),fill:el.querySelector('.gl-hp-fill'),num:el.querySelector('.gl-hp-num'),en:el.querySelector('.gl-en-num'),tagEl:el.querySelector('.gl-unit-tag'),lastSig:''};
      T3.hudPool.set(key,rec);
    }
    v.set(w2cx(rx),tileWorldY(rx,ry)+1.55,w2cz(ry)).project(T3.camera);
    if(v.z<-1||v.z>1){rec.el.style.display='none';return;}
    const sx=(v.x*0.5+0.5)*w,sy=(-v.y*0.5+0.5)*h;
    if(sx<-40||sx>w+40||sy<0||sy>h+40){rec.el.style.display='none';return;}
    rec.el.style.display='flex';
    rec.el.style.left=sx.toFixed(1)+'px';rec.el.style.top=sy.toFixed(1)+'px';
    const pct=Math.max(0,Math.min(100,Math.round((hp/(maxHp||1))*100)));
    const sig=pct+'|'+hp+'/'+maxHp+'|'+team+'|'+tag+'|'+(vet||0)+'|'+(selected?energy+'/'+maxEnergy:'');
    if(sig!==rec.lastSig){
      rec.lastSig=sig;
      rec.dot.style.background=team==='A'?TEAM_A:TEAM_B;
      rec.fill.style.width=pct+'%';
      rec.fill.className='gl-hp-fill'+(pct<=30?' low':pct<=55?' med':'');
      if(rec.num)rec.num.textContent=hp+'/'+maxHp;
      if(rec.en){if(selected&&Number.isFinite(Number(energy))){rec.en.textContent='⚡'+energy+'/'+maxEnergy;rec.en.style.display='';}else rec.en.style.display='none';}
      if(tag||vet){rec.tagEl.textContent=(vet?'★'+vet+' ':'')+tag;rec.tagEl.style.display='block';}
      else rec.tagEl.style.display='none';
    }
  };
  G.units.forEach(un=>{
    if(!un.alive)return;
    const rx=un.dx!=null?un.dx:un.x,ry=un.dy!=null?un.dy:un.y;
    const tags=[];
    if(un.overwatch)tags.push('👁');
    if(un.stunned)tags.push('💫');
    if(un.invisible)tags.push('👻');
    if(un.suppressed)tags.push('−2⚡');
    syncEntity('u:'+un.id,rx,ry,un.hp,un.maxHp,un.team,tags.join(' '),un.vetLevel,un.energy,un.maxEnergy,G.selected===un);
  });
  if(G.drone&&G.drone.alive){
    const d=G.drone,rx=d.dx!=null?d.dx:d.x,ry=d.dy!=null?d.dy:d.y;
    syncEntity('drone',rx,ry,d.hp,d.maxHp,'A','🤖 DRON',0);
  }
  T3.hudPool.forEach((rec,k)=>{if(!seen.has(k)){rec.el.remove();T3.hudPool.delete(k);}});
}
