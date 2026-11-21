import { cheb, angleToFacing } from '../core/geometry.js';
import { reachable, blocked, pathDist, coverLevel, hasLOS, moveCostOf, hitChance } from './board.js';
import { spendEnergy, explodeBarrel, checkOverwatch, pickupLoot, tryShoot, throwGrenade, canHealSpecial, unitHasAction } from './combat.js';
import { escortExt, isExtraction, domZones, inDomZone } from '../ui/ui-shell.js';
import { checkMines, placeMine, mineAt, deployTurret, throwFlash, guideDrone, useSpecial, FLASH_COST, FLASH_RANGE } from './missions.js';
import { smokeAt } from './board.js';
import { throwSmoke } from './gadgets.js';
import { rng } from '../core/rng.js';

export function aiEscort({u,G,drone,w,enemies,target,hardAI}){
        const d=drone;
        const ext=escortExt().slice().sort((a,b)=>pathDist(a,d)-pathDist(b,d))[0];
        const pathDistBrk=(a,b)=>{
          if(a.x===b.x&&a.y===b.y)return 0;
          const distM=new Int16Array(W*H).fill(999);
          const idx=(x,y)=>y*W+x;
          const dq=[{x:a.x,y:a.y,c:0}];distM[idx(a.x,a.y)]=0;
          while(dq.length){
            dq.sort((p,q)=>p.c-q.c);
            const cur=dq.shift();
            if(cur.x===b.x&&cur.y===b.y)return cur.c;
            if(cur.c>distM[idx(cur.x,cur.y)])continue;
            for(const [dx,dy] of [[1,0],[-1,0],[0,1],[0,-1]]){
              const nx=cur.x+dx,ny=cur.y+dy;
              if(nx<0||ny<0||nx>=W||ny>=H)continue;
              const o=obAt(nx,ny);
              if(o&&o.type!=='crate')continue;
              const nc=cur.c+(o?2:1);
              if(nc<distM[idx(nx,ny)]){distM[idx(nx,ny)]=nc;dq.push({x:nx,y:ny,c:nc});}
            }
          }
          return 99;
        };
        const curExtDist=pathDistBrk(d,ext);
        const blockingCrates=G.map.obstacles.filter(o=>o.type==='crate'&&o.x>=d.x&&o.x<=10&&Math.abs(o.y-d.y)<=2)
          .sort((a,b)=>(cheb(d,a)-cheb(d,b))||(Math.abs(a.y-d.y)-Math.abs(b.y-d.y)));
        const dangerousBarrels=G.map.barrels.filter(b=>b.alive&&b.x>=d.x&&b.x<=d.x+3&&Math.abs(b.y-d.y)<=2
          &&cheb(b,d)>1&&!G.units.some(a=>a.alive&&a.team==='A'&&cheb(a,b)<=1));
        const shootCrateIfNeeded=()=>{
          for(const br of dangerousBarrels){
            if(u.energy<w.cost)break;
            if(cheb(u,br)<=w.rng&&hasLOS(u,br)&&!smokeBlocksLOS(u,br)){
              spendEnergy(u,w.cost);explodeBarrel(br,u.role+' (A)');
              if(!G||G.over)return true;
              return true;
            }
          }
          for(const cr of blockingCrates){
            if(cr.hp<=0)continue;
            if(u.energy<w.cost)break;
            if(cheb(u,cr)<=w.rng&&hasLOS(u,cr)&&!smokeBlocksLOS(u,cr)){
              spendEnergy(u,w.cost);cr.hp-=w.dmg;
              if(cr.hp<=0){G.map.obstacles=G.map.obstacles.filter(o=>o!==cr);}
              return true;
            }
          }
          return false;
        };
        const droneGuards=(ex)=>{
          const exc=ex||null;
          return G.units.filter(a=>a.alive&&a.team==='A'&&a!==exc&&dist(a,d)<=1).length;
        };
        /* El Francotirador apoya desde cobertura a media/larga distancia: limpia cajas/barriles o castiga amenazas, sin meterse al cuerpo a cuerpo */
        if(w.rng>=8){
          const reachS=reachable(u,Math.max(0,u.energy-w.cost));
          let bestS=null,bestScoreS=1e9;
          reachS.forEach((dd,k)=>{
            const [x,y]=k.split(',').map(Number);const pos={x,y};
            const dEnemy=target?cheb(pos,target):8;
            const dDrone=dist(pos,d);
            const cov=target?coverLevel(pos,target):0;
            let s=Math.abs(dDrone-5)*2.2+dd*0.4-cov*2.5;
            if(target&&dEnemy<5)s+=(5-dEnemy)*6;
            if(target&&cheb(pos,target)<=w.rng&&hasLOS(pos,target)&&!smokeBlocksLOS(pos,target))s-=6;
            if(G.map.barrels.some(b=>b.alive&&cheb(pos,b)<=1))s+=16;
            if(s<bestScoreS){bestScoreS=s;bestS={x,y,d:dd};}
          });
          if(!u.movedThisTurn&&bestS&&(bestS.x!==u.x||bestS.y!==u.y)){
            const ff=angleToFacing(bestS.x-u.x,bestS.y-u.y);if(ff!=null)u.facing=ff;
            u.x=bestS.x;u.y=bestS.y;u.energy-=bestS.d;u.movedThisTurn=true;checkMines(u);checkOverwatch(u);pickupLoot(u);
          }
          if(!u.alive||!G||G.over)return true;
          const sFoes=G.units.filter(e=>e.alive&&e.team!==u.team&&!e.invisible&&cheb(u,e)<=w.rng&&hasLOS(u,e)&&!smokeBlocksLOS(u,e)&&hitChance(u,e,w)>0)
            .sort((a,b)=>(dist(a,d)-dist(b,d))||(a.hp-b.hp));
          if(dangerousBarrels.length&&cheb(u,dangerousBarrels[0])<=w.rng&&hasLOS(u,dangerousBarrels[0])&&!smokeBlocksLOS(u,dangerousBarrels[0])&&u.energy>=w.cost){
            shootCrateIfNeeded();
          }
          let ft=sFoes[0]||null;
          if(ft&&!ft.movedThisTurn&&u.energy>=w.cost+3){useSpecial(u,ft);if(!G||G.over)return true;}
          let ss=0;
          while(ft&&ft.alive&&u.energy>=w.cost&&ss<2){if(!tryShoot(u,ft,u.weapon,null))break;ss++;if(!ft.alive)ft=sFoes.find(e=>e.alive)||null;}
          if(!ss&&blockingCrates.length&&u.energy>=w.cost){shootCrateIfNeeded();}
          if(u.alive&&G&&!G.over&&u.energy>=3&&!u.overwatch&&!u.stunned) {u.energy-=3;u.overwatch=true;}
          return true;
        }
        /* 0) Médico: si el dron tiene daño serio (<=155 PV, o <=maxHp-40 desde R3) o un aliado está herido, curarlo */
        if(canHealSpecial(u)&&u.heals>0&&u.energy>=3){
          const hurtAlly=G.units.filter(a=>a.alive&&a.team==='A'&&a.hp<=a.maxHp*0.65&&dist(u,a)<=1).sort((a,b)=>a.hp-b.hp)[0];
          const droneNeedsHeal=(d.hp<=170)||(G.round>=3&&d.hp<=d.maxHp-40);
          const healTgt=droneNeedsHeal?d:hurtAlly;
          if(healTgt){
            if(dist(u,healTgt)<=1){useSpecial(u,healTgt);if(!G||G.over)return true;}
            else if(u.energy>=moveCostOf(u)+3){
              const reach=reachable(u,u.energy-3);
              let best=null,bestS=1e9;
              reach.forEach((dd,k)=>{const [x,y]=k.split(',').map(Number);const s=dist({x,y},healTgt)*4+dd+(G.map.barrels.some(b=>b.alive&&cheb({x,y},b)<=1)?14:0);if(s<bestS){bestS=s;best={x,y,d:dd};}});
              if(best&&dist(best,healTgt)<=1){
                const ff=angleToFacing(best.x-u.x,best.y-u.y);if(ff!=null)u.facing=ff;
                u.x=best.x;u.y=best.y;u.energy-=best.d;u.movedThisTurn=true;checkMines(u);checkOverwatch(u);pickupLoot(u);
                if(!u.alive||!G||G.over)return true;
                if(G.drone&&G.drone.alive&&dist(u,healTgt)<=1&&u.energy>=3){useSpecial(u,healTgt);if(!G||G.over)return true;}
              }
            }
          }
        }
        /* 0b) Despejar barril peligroso o caja bloqueante si hay tiro limpio antes de empujar */
        if((dangerousBarrels.length||blockingCrates.length)&&u.energy>=w.cost+2&&dist(u,d)>1){
          shootCrateIfNeeded();
          if(!G||G.over||!u.alive)return true;
        }
        /* 1) guiar si está pegado y mejora ruta directa al este (garantizando escolta adyacente activa) */
        const tryGuideFwd=(maxGuides, allowUnmovedSelf)=>{
          if(d.movesLeft<=0||u.energy<2)return false;
          const lim=maxGuides||2;
          let guided=0;
          for(let step=0;step<lim;step++){
            if(d.movesLeft<=0||u.energy<2)break;
            /* Si el dron ya se ha ido de su lado, la escolta lo sigue: se
               recoloca pegado (gastando movimiento) y vuelve a empujar. Así
               una sola escolta puede completar los 2 guiados de la ronda. */
            if(dist(u,d)>1){
              if(u.energy<2+moveCostOf(u))break;
              const reachW=reachable(u,u.energy-2);
              let near=null,nearS=1e9;
              reachW.forEach((dd,k)=>{const [x,y]=k.split(',').map(Number);if(dist({x,y},d)>1)return;const s=dd*2;if(s<nearS){nearS=s;near={x,y,d:dd};}});
              if(!near)break;
              const ffw=angleToFacing(near.x-u.x,near.y-u.y);if(ffw!=null)u.facing=ffw;
              u.x=near.x;u.y=near.y;u.energy-=near.d;u.movedThisTurn=true;checkMines(u);checkOverwatch(u);pickupLoot(u);
              if(!u.alive||!G||G.over)return guided>0;
            }
            let bx=null,by=null,bestSc=1e9;
            const curPd=pathDistBrk(d,ext);
            for(const [dx,dy] of [[1,0],[0,1],[0,-1],[-1,0]]){
              const nx=d.x+dx,ny=d.y+dy;
              if(nx<0||ny<0||nx>=W||ny>=H||blocked(nx,ny))continue;
              const pd=pathDistBrk({x:nx,y:ny},ext);
              const allyNext=G.units.some(a=>a.alive&&a.team==='A'&&a!==u&&dist(a,{x:nx,y:ny})<=1);
              const canReachAdj=!u.movedThisTurn&&(()=>{const r=reachable(u,u.energy-2);for(const [k] of r){const [px,py]=k.split(',').map(Number);if(dist({x:px,y:py},{x:nx,y:ny})===1)return true;}return false;})();
              const keepGuard=true; /* la escolta camina con el dron (guideDrone la recoloca), así que el blindaje no se pierde al empujar */
              if(!keepGuard)continue;
              if(pd>curPd&&!isExtraction(nx,ny))continue;
              const nearBarrel=G.map.barrels.some(b=>b.alive&&cheb({x:nx,y:ny},b)<=1)?3.5:0;
              const sc=pd*2+nearBarrel-(nx>d.x?0.6:0)-(isExtraction(nx,ny)?50:0);
              if(sc<bestSc){bestSc=sc;bx=nx;by=ny;}
            }
            if(bx==null)break;
            guideDrone(u,bx,by);
            guided++;
            if(!G||G.over)return true;
          }
          return guided>0;
        };
        /* 1a) Limpiar amenazas pegadas o aturdirlas antes de exponer al dron */
        if(unitHasAction(u,'flash')&&(u.flashes||0)>0&&u.energy>=FLASH_COST){
          const threat=enemies.find(e=>!e.stunned&&cheb(u,e)<=FLASH_RANGE&&!G.units.some(a=>a.alive&&a.team===u.team&&a!==u&&cheb(a,e)<=1));
          if(threat)throwFlash(u,threat.x,threat.y);
        }
        const canExtractNow=escortExt().some(e=>!blocked(e.x,e.y)&&dist(d,e)<=d.movesLeft);
        if(canExtractNow){
          if(tryGuideFwd(2,true)&&(!G||G.over))return true;
        } else if(!u.movedThisTurn&&d.movesLeft>0&&u.energy>=2+moveCostOf(u)){
          /* Cualquier escolta con energía guía (no solo el Médico): si no
             está pegado, el guiado en cadena lo acerca primero. */
          tryGuideFwd(2,false);
          if(!G||G.over)return true;
        }
        /* 1b) si está bloqueando la casilla delantera directa del dron hacia la extracción, apartarse */
        const needForwardTile=(()=>{
          for(const [dx,dy] of [[1,0],[0,1],[0,-1]]){
            const nx=d.x+dx,ny=d.y+dy;
            if(nx>=0&&ny>=0&&nx<W&&ny<H&&!obAt(nx,ny)&&pathDistBrk({x:nx,y:ny},ext)<curExtDist){
              if(u.x===nx&&u.y===ny)return true;
            }
          }
          return false;
        })();
        if(needForwardTile&&!u.movedThisTurn){
          const reach=reachable(u,u.energy);
          let best=null,bestS=1e9;
          reach.forEach((dd,k)=>{const [x,y]=k.split(',').map(Number);const pd=pathDistBrk({x,y},ext);const nearD=dist({x,y},d);const cov=coverLevel({x,y},enemies[0])>0?-3:0;const bPen=G.map.barrels.some(b=>b.alive&&cheb({x,y},b)<=1)?14:0;const s=pd*2+dd+(nearD===1?0:3)+(x>d.x&&Math.abs(y-d.y)<=1?6:0)+cov+bPen;if(s<bestS){bestS=s;best={x,y,d:dd};}});
          if(best){
            const ff=angleToFacing(best.x-u.x,best.y-u.y);if(ff!=null)u.facing=ff;
            u.x=best.x;u.y=best.y;u.energy-=best.d;u.movedThisTurn=true;checkMines(u);checkOverwatch(u);pickupLoot(u);
          }
        }
        /* 2) moverse junto al dron (máx 1–2 escoltas pegados en flancos seguros; obligatorio si nadie lo escolta aún) */
        const needGuards=droneGuards(u);
        if(!u.movedThisTurn&&u.energy>=moveCostOf(u)&&(needGuards<1||(d.movesLeft>0&&needGuards<2))&&dist(u,d)>1){
          const reserveE=(needGuards<1)?0:(d.movesLeft>0?2:Math.min(w.cost,3));
          const reach=reachable(u,Math.max(0,u.energy-reserveE));
          let best=null,bestS=1e9;
          reach.forEach((dd,k)=>{const [x,y]=k.split(',').map(Number);const dToD=dist({x,y},d);const isBlock=(pathDistBrk({x,y},ext)<curExtDist&&dToD===1)?5:0;const covBonus=coverLevel({x,y},enemies[0])>0?-4:0;const guardBonus=(dToD===1)?(needGuards<1?-28:-11):0;const frontGuard=(x>d.x&&Math.abs(y-d.y)===1)?-10:0;const bPen=G.map.barrels.some(b=>b.alive&&cheb({x,y},b)<=1)?14:0;const adjAllies=G.units.filter(a=>a.alive&&a.team===u.team&&a!==u&&cheb({x,y},a)<=1).length;const s=dToD*3.2+dd*0.5+isBlock+covBonus+guardBonus+frontGuard+bPen+adjAllies*2.0;if(s<bestS){bestS=s;best={x,y,d:dd};}});
          if(best&&(best.x!==u.x||best.y!==u.y)){
            const ff=angleToFacing(best.x-u.x,best.y-u.y);if(ff!=null)u.facing=ff;
            u.x=best.x;u.y=best.y;u.energy-=best.d;u.movedThisTurn=true;checkMines(u);checkOverwatch(u);pickupLoot(u);
            if(u.alive&&G.drone&&G.drone.alive&&(d.x<4||droneGuards(u)>=1)){if(tryGuideFwd(2,false)&&(!G||G.over))return true;}
          }
        } else if(!u.movedThisTurn&&u.energy>=moveCostOf(u)){
          const reach=reachable(u,Math.max(0,u.energy-w.cost));
          let best=null,bestS=1e9;
          reach.forEach((dd,k)=>{const [x,y]=k.split(',').map(Number);const isFront=(x>d.x&&Math.abs(y-d.y)<=1&&dist({x,y},d)<=1)?6:0;const covB=coverLevel({x,y},enemies[0])>0?-4.5:0;const guardB=(dist({x,y},d)===1&&needGuards<1)?-22:0;const bPen=G.map.barrels.some(b=>b.alive&&cheb({x,y},b)<=1)?16:0;const adjAllies=G.units.filter(a=>a.alive&&a.team===u.team&&a!==u&&cheb({x,y},a)<=1).length;const wantDist=dist({x,y},d)*1.8+pathDistBrk({x,y},ext)*0.8;const lanePen=(Math.abs(y-d.y)>3)?4:0;const s=wantDist+dd*0.55+isFront+covB+guardB+bPen+adjAllies*2.2+lanePen;if(s<bestS){bestS=s;best={x,y,d:dd};}});
          if(best){
            const ff=angleToFacing(best.x-u.x,best.y-u.y);if(ff!=null)u.facing=ff;
            u.x=best.x;u.y=best.y;u.energy-=best.d;u.movedThisTurn=true;checkMines(u);checkOverwatch(u);pickupLoot(u);
          }
        }
        /* 3) apoyos tácticos de escolta: torreta M2 cuando hay contacto, humo M18 sobre el dron, aturdidora M84 y M67 */
        if(!u.alive||!G||G.over)return true;
        if(unitHasAction(u,'deploy')&&u.energy>=5&&(d.x>=3||enemies.some(e=>cheb(u,e)<=7))&&!G.deployed.some(t=>t.alive&&t.team===u.team)){
          const spots=[[1,0],[0,1],[0,-1],[-1,0]].map(dd=>({x:u.x+dd[0],y:u.y+dd[1]})).filter(p=>p.x>=0&&p.y>=0&&p.x<W&&p.y<H&&!blocked(p.x,p.y));
          if(spots.length)deployTurret(u,spots[0].x,spots[0].y);
        }
        if(unitHasAction(u,'smoke')&&(u.smokes||0)>0&&u.energy>=2&&!smokeAt(d.x,d.y)){
          const shooterThreat=enemies.find(e=>cheb(e,d)<=8&&hasLOS(e,d)&&!smokeBlocksLOS(e,d));
          if(shooterThreat){
            const sx=Math.max(0,Math.min(W-1,d.x+Math.sign(shooterThreat.x-d.x))),sy=Math.max(0,Math.min(H-1,d.y+Math.sign(shooterThreat.y-d.y)));
            if(cheb(u,{x:sx,y:sy})>=1&&cheb(u,{x:sx,y:sy})<=4)throwSmoke(u,sx,sy);
          }
        }
        if(unitHasAction(u,'flash')&&(u.flashes||0)>0&&u.energy>=FLASH_COST){
          const threat=enemies.find(e=>!e.stunned&&cheb(u,e)<=FLASH_RANGE&&!G.units.some(a=>a.alive&&a.team===u.team&&a!==u&&cheb(a,e)<=1));
          if(threat)throwFlash(u,threat.x,threat.y);
        }
        if(u.grenades>0&&u.energy>=2){
          const gTgt=enemies.find(e=>cheb(u,e)<=3&&cheb(u,e)>=2&&!G.units.some(a=>a.alive&&a.team===u.team&&a!==u&&cheb(a,e)<=1)&&cheb(e,d)>1);
          if(gTgt){throwGrenade(u,gTgt.x,gTgt.y);if(!G||G.over)return true;}
        }
        /* 4) combatir amenazas o abrir brecha, reservando 2⚡ si puede empujar al dron hasta 2 pasos */
        const guideReserve=(d.movesLeft>0&&dist(u,d)<=1&&u.energy>=w.cost+2)?2:0;
        if((dangerousBarrels.length||blockingCrates.length)&&u.energy>=w.cost+guideReserve){
          shootCrateIfNeeded();
          if(!G||G.over||!u.alive)return true;
        }
        const foes=G.units.filter(e=>e.alive&&e.team!==u.team&&!e.invisible).sort((a,b)=>(dist(a,d)-dist(b,d))||(a.hp-b.hp));
        let tgt=null;
        for(const e of foes){if(cheb(u,e)<=w.rng&&hasLOS(u,e)&&!smokeBlocksLOS(u,e)&&hitChance(u,e,w)>0){tgt=e;break;}}
        if(tgt){let shots=0;while(tgt&&tgt.alive&&u.energy>=w.cost+guideReserve&&shots<3){if(!tryShoot(u,tgt,u.weapon,null))break;shots++;if(!tgt.alive)tgt=foes.find(e=>e.alive&&cheb(u,e)<=w.rng&&hasLOS(u,e)&&!smokeBlocksLOS(u,e)&&hitChance(u,e,w)>0)||null;}}
        if(u.alive&&G&&!G.over&&dist(u,d)<=1&&d.movesLeft>0&&u.energy>=2){if(tryGuideFwd(2,false)&&(!G||G.over))return true;}
        if(u.alive&&G&&!G.over&&u.energy>=3&&!u.overwatch&&!u.stunned&&rng()<0.65){u.energy-=3;u.overwatch=true;}
        return true;
  return false;
}
