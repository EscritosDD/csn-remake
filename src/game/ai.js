import { WEAPONS, PISTOL } from '../data/weapons.js';
import { cheb, dist, angleToFacing } from '../core/geometry.js';
import { rng } from '../core/rng.js';
import { effMode, domZones, domControl, inDomZone, isExtraction } from '../ui/ui-shell.js';
import { blocked, coverLevel, coverBonus, hasLOS, hitChance, inBeacon, moveCostOf, obAt, pathDist, reachable, smokeAt, smokeBlocksLOS } from './board.js';
import { log, playOnce, checkOverwatch, pickupLoot, tryShoot, unitHasAction, canSnipeSpecial, throwGrenade } from './combat.js';
import { checkMines, mineAt, placeMine, deployTurret, captureTurret, throwFlash, useSpecial, FLASH_COST, FLASH_RANGE, MINE_COST } from './missions.js';
import { throwGas, placeCover, sweepDetect, throwTranq, waterCannon, useToolkit, useShield, fireArtillery, throwBees, throwMolotov, placeHealthCrate, throwSmoke, GAS_COST, COVER_COST, SWEEP_COST, TRANQ_COST, TRANQ_RANGE, WATER_COST, WATER_RANGE, TOOL_COST, TOOL_RANGE, SHIELD_COST, ARTY_COST, ARTY_RANGE, BEES_COST, BEES_RANGE, MOLOTOV_COST, CRATE_COST } from './gadgets.js';
import { aiEscort } from './ai-escort.js';
import { endTurn } from './turn.js';

export function aiUnitAct(u){
  return new Promise(res=>{
    setTimeout(()=>{
      if(!G||G.over||!u.alive)return res();
      const enemies=G.units.filter(e=>e.alive&&e.team!==u.team&&!e.invisible);
      if(!enemies.length)return res();
      enemies.sort((a,b)=>dist(u,a)-dist(u,b));
      let target=enemies[0];
      const w=WEAPONS[u.weapon];
      const drone=(effMode(G)==='escolta'&&G.drone&&G.drone.alive)?G.drone:null;
      const hardAI=(G.difficulty==='veterano'||G.difficulty==='elite');
      /* ESCOLTA (bando A): el Francotirador cubre desde atrás; el resto abre brecha, limpia barriles peligrosos, guía, repara y protege el dron */
      if(u.team==='A'&&drone){
        if(aiEscort({u,G,drone,w,enemies,target,hardAI}))return res();
      }
      /* Médico: cura a un aliado adyacente, o se acerca a un aliado muy herido para curarlo */
      if(u.role==='Médico'){
        if(hardAI){const deadAlly=G.units.find(a=>!a.alive&&a.team===u.team&&dist(u,a)<=1);if(deadAlly&&G.difficulty==='elite'&&u.revives>0&&u.energy>=4){useSpecial(u,deadAlly);return res();}}
        const healThresh=hardAI?0.75:0.60;
        const hurtAdj=G.units.filter(a=>a.alive&&a.team===u.team&&a.hp<a.maxHp*healThresh&&dist(u,a)<=1).sort((a,b)=>(a.hp/a.maxHp)-(b.hp/b.maxHp))[0];
        if(hurtAdj&&u.heals>0&&u.energy>=3){useSpecial(u,hurtAdj);return res();}
        if(!drone&&u.heals>0&&u.energy>=moveCostOf(u)+3){
          const hurtFar=G.units.filter(a=>a.alive&&a.team===u.team&&a!==u&&a.hp<a.maxHp*0.58).sort((a,b)=>(a.hp/a.maxHp)-(b.hp/b.maxHp))[0];
          if(hurtFar){
            const reachH=reachable(u,u.energy-3);
            let bh=null,bhS=1e9;
            reachH.forEach((dd,k)=>{const [x,y]=k.split(',').map(Number);if(dist({x,y},hurtFar)<=1){const cov=coverLevel({x,y},target)>0?-2:0;if(dd+cov<bhS){bhS=dd+cov;bh={x,y,d:dd};}}});
            if(bh){
              const ff=angleToFacing(bh.x-u.x,bh.y-u.y);if(ff!=null)u.facing=ff;
              u.x=bh.x;u.y=bh.y;u.energy-=bh.d;u.movedThisTurn=true;checkMines(u);checkOverwatch(u);pickupLoot(u);
              if(!u.alive||!G||G.over)return res();
              if(hurtFar.alive&&dist(u,hurtFar)<=1&&u.energy>=3){useSpecial(u,hurtFar);return res();}
            }
          }
        }
      }
      /* Ingeniero Veterano/Élite: despliega su torreta si le queda energía tras acercarse */
      if(hardAI&&u.role==='Ingeniero'&&u.energy>=5&&!G.deployed.some(t=>t.alive&&t.team===u.team)){
        const spots=[[1,0],[-1,0],[0,1],[0,-1]].map(d=>({x:u.x+d[0],y:u.y+d[1]})).filter(p=>!blocked(p.x,p.y));
        if(spots.length&&cheb(u,target)<=6){deployTurret(u,spots[0].x,spots[0].y);}
      }
      if(u.role==='Espía'&&u.energy>=6&&cheb(u,target)>3&&cheb(u,target)<=8){useSpecial(u,null);}
      /* Capitán Veterano/Élite: da su orden al aliado con más arma y menos energía */
      if(hardAI&&u.role==='Capitán'&&!u.captainUsed){const ally=G.units.filter(a=>a.alive&&a.team===u.team&&a!==u).sort((a,b)=>a.energy-b.energy)[0];if(ally&&ally.energy<=ally.maxEnergy-3)useSpecial(u,ally);}
      /* move toward target, beacon or distributed domination zone */
      const nearestZTile=(z)=>z.tiles.slice().sort((a,b)=>pathDist(u,a)-pathDist(u,b)||dist(u,a)-dist(u,b))[0];
      let goal=target,goalZone=null;
      if(effMode(G)==='dominacion'){
        const allies=G.units.filter(a=>a.alive&&a.team===u.team);
        const alreadyIn=domZones().find(z=>inDomZone(u.x,u.y,z));
        const zoneLoad=(z)=>allies.filter(a=>a!==u&&(inDomZone(a.x,a.y,z)||a._domGoal===z.id)).length;
        const zoneOrder=u.team==='B'?['sur','centro','norte']:['norte','centro','sur'];
        const homeZone=domZones().find(z=>z.id===zoneOrder[0]);
        if(w.rng>=8){
          u._domGoal=homeZone.id;goal=nearestZTile(homeZone);goalZone=homeZone;
        } else if(alreadyIn&&(domControl(alreadyIn)!==u.team||zoneLoad(alreadyIn)===0)){
          u._domGoal=alreadyIn.id;goal=nearestZTile(alreadyIn);goalZone=alreadyIn;
        } else {
          const cand=domZones().slice().sort((a,b)=>{
            const aMine=domControl(a)===u.team?1:0,bMine=domControl(b)===u.team?1:0;
            if(aMine!==bMine)return aMine-bMine;
            const aSoloCentro=(G.round<=2&&a.id==='centro'&&zoneLoad(a)===0&&allies.length>=3)?1:0;
            const bSoloCentro=(G.round<=2&&b.id==='centro'&&zoneLoad(b)===0&&allies.length>=3)?1:0;
            if(aSoloCentro!==bSoloCentro)return aSoloCentro-bSoloCentro;
            const aLoad=zoneLoad(a),bLoad=zoneLoad(b);
            if(aLoad!==bLoad)return aLoad-bLoad;
            const pdA=pathDist(u,nearestZTile(a)),pdB=pathDist(u,nearestZTile(b));
            if(pdA!==pdB)return pdA-pdB;
            return zoneOrder.indexOf(a.id)-zoneOrder.indexOf(b.id);
          });
          const zone=cand[0];
          u._domGoal=zone.id;
          goal=nearestZTile(zone);goalZone=zone;
        }
      } else if(drone){
        /* Escolta: la defensa juega el objetivo, no solo a eliminar:
           marcha a interceptar al dron y se planta en su ruta; quien ya
           lo tiene a tiro y con visión no se mueve y le dispara. */
        goal=drone;
      } else if(effMode(G)==='baliza'&&!inBeacon(u.x,u.y)&&(hardAI||rng()<0.65)){
        goal=BEACON.slice().sort((a,b)=>pathDist(u,a)-pathDist(u,b))[0];
      }
      const hasCleanShot=target&&cheb(u,target)<=w.rng&&hasLOS(u,target)&&!smokeBlocksLOS(u,target);
      const lateStall=(!goalZone&&!drone&&G.round>=12);
      const holdFireDom=goalZone&&hasCleanShot&&(w.rng>=8||enemies.some(e=>cheb(u,e)<=4));
      if(!u.movedThisTurn&&(goalZone?(!inDomZone(u.x,u.y,goalZone)&&!holdFireDom):(cheb(u,goal)>w.rng||!hasLOS(u,goal)||smokeBlocksLOS(u,goal)))){
        const canRecruitSkip=G.difficulty==='recluta';
        const reserveBudget=(u.energy>w.cost&&cheb(u,goal)<=w.rng+4)?w.cost:((!drone&&!lateStall&&G.round>=2&&u.energy>=moveCostOf(u)+3&&!canRecruitSkip)?3:0);
        const reach=reachable(u,Math.max(0,u.energy-reserveBudget));
        let best=null,bestScore=1e9;
        const distW=lateStall?4.8:(G.round>=10?3.4:(G.round<=2?2.8:2.5));
        const optApproach=goalZone?(w.rng>=8?4:1):(lateStall?0:(G.round>=10?(w.rng>=8?4:2):(w.rng>=8?(G.round===1?10:7):(w.rng>=5?4:(G.round<=2?2:2)))));
        const alliesNow=G.units.filter(a=>a.alive&&a.team===u.team&&a!==u);
        reach.forEach((d,k)=>{
          const [x,y]=k.split(',').map(Number);
          const pos={x,y};
          const rawPD=pathDist(pos,goal);
          const effPD=Math.max(0,rawPD-optApproach);
          let s=effPD*distW+d*0.45;
          if(u._prevPos&&u._prevPos.x===x&&u._prevPos.y===y)s+=5;
          if(effMode(G)==='dominacion'&&goalZone&&inDomZone(x,y,goalZone))s-=(w.rng>=8?2:8);
          if(effMode(G)==='dominacion'&&domZones().some(z=>inDomZone(x,y,z)))s-=(w.rng>=8?1:(hardAI?5:3));
          if(effMode(G)==='baliza'&&inBeacon(x,y))s-=(hardAI?5:3);
          if(!canRecruitSkip&&!lateStall){
            const dirCov=target?coverLevel(pos,target):0;
            const centerCov=coverLevel(pos,{x:u.team==='A'?11:0,y:u.team==='A'?5:6});
            const effCov=Math.min(dirCov,centerCov||dirCov);
            const nearCov=[[1,0],[-1,0],[0,1],[0,-1]].some(dd=>obAt(x+dd[0],y+dd[1]));
            if(effCov>0)s-=(1.8+effCov*1.05);
            else if(dirCov>0)s-=(1.2+dirCov*0.55);
            else if(nearCov)s-=1;
            else if(target&&cheb(pos,target)<=6&&hasLOS(target,pos))s+=4.5;
            if(G.round<=2&&(x===0||x===W-1))s+=4;
            if(target&&w.rng>=8&&cheb(pos,target)<5)s+=(5-cheb(pos,target))*5;
            if(w.rng>=5&&target){
              const nearFoes=enemies.filter(e=>cheb(pos,e)<=3).length;
              if(nearFoes>0)s+=nearFoes*(w.rng>=8?10:5);
            }
            const threatCnt=enemies.filter(e=>cheb(pos,e)<=WEAPONS[e.weapon].rng+2&&hasLOS(e,pos)&&!smokeBlocksLOS(e,pos)).length;
            if(G.round<=4&&threatCnt>0&&effCov<2&&(centerCov===0||dirCov<2)){
              s+=effCov===0?(threatCnt*(G.round<=2?6.5:4)):(threatCnt*2.2);
            }
            if(G.round===1&&!drone){
              const pastMid=(u.team==='A'?x>=6:x<=5);
              if(pastMid&&(!goalZone||!inDomZone(x,y,goalZone)||effCov<2))s+=(effCov>=2?4:11);
              if(w.rng>=8&&(u.team==='A'?x>=3:x<=8)&&effCov<2)s+=14;
              if(w.rng>=8&&cheb(pos,target)<=7)s+=9;
              if(alliesNow.length&&!alliesNow.some(a=>cheb(pos,a)<=4))s+=6;
            }
            if(G.round<=3&&u.energy-d<w.cost){
              const threat=enemies.some(e=>{
                const ew=WEAPONS[e.weapon];
                const eStep=Math.max(0,Math.floor((e.maxEnergy-ew.cost)/moveCostOf(e)));
                const reachRng=Math.min(10,ew.rng+Math.min(3,eStep));
                return cheb(pos,e)<=reachRng&&(hasLOS(e,pos)||cheb(pos,e)<=ew.rng+2);
              });
              if(threat&&dirCov<2)s+=6;
            }
            if(G.round===1)s+=Math.max(Math.abs(x-5.5),Math.abs(y-5.5))*0.35;
            if(G.map.barrels.some(b=>b.alive&&cheb(pos,b)<=1))s+=18;
            else if(target&&cheb(pos,target)<=6&&G.map.barrels.some(b=>b.alive&&cheb(pos,b)<=2))s+=8;
            if(w.rng>=8&&target&&cheb(pos,target)<=7&&effCov<2)s+=7;
            const adjAllies=alliesNow.filter(a=>cheb(pos,a)<=1).length;
            if(adjAllies>0&&target&&cheb(pos,target)<=8)s+=adjAllies*4.5;
            if(target&&cheb(pos,target)<=w.rng&&hasLOS(pos,target)&&!smokeBlocksLOS(pos,target))s-=(G.round===1&&u.energy-d<w.cost?0:5);
            if(effMode(G)!=='dominacion'&&G.round>=2&&x===TURRET_POS.x&&y===TURRET_POS.y&&G.map.turret.owner!==u.team&&u.energy-d>=2)s-=6;
          } else if(lateStall){
            if(target&&cheb(pos,target)<=w.rng&&hasLOS(pos,target)&&!smokeBlocksLOS(pos,target))s-=12;
          }
          if(s<bestScore){bestScore=s;best={x,y,d};}
        });
        if(best&&(best.x!==u.x||best.y!==u.y)){
          const fx=u.x,fy=u.y;u._prevPos={x:fx,y:fy};const ff=angleToFacing(best.x-fx,best.y-fy);if(ff!=null)u.facing=ff;u.x=best.x;u.y=best.y;u.energy-=best.d;u.movedThisTurn=true;checkMines(u);checkOverwatch(u);pickupLoot(u);
          if(!u.alive||!G||G.over)return res();
          log('IA: '+u.role+' avanza de ('+(fx+1)+','+(fy+1)+') a ('+(u.x+1)+','+(u.y+1)+').');
          const mk=G.map.medkits.find(m=>!m.used&&m.x===u.x&&m.y===u.y);
          if(mk&&u.alive&&u.hp<u.maxHp){mk.used=true;u.hp=Math.min(u.maxHp,u.hp+50);playOnce(u,'pickup');log('IA: '+u.role+' usa el botiquín (+50 PV).');}
          if(effMode(G)!=='dominacion'&&G.round>=2&&u.x===TURRET_POS.x&&u.y===TURRET_POS.y&&G.map.turret.owner!==u.team&&u.energy>=2)captureTurret(u);
        }
      }
      /* Espía: cortina de humo M18 táctica (sin desperdiciar en turno 1 ni
         cegar a aliados que ya tienen tiro limpio): solo se lanza si el
         dron de Escolta está bajo fuego, si el Espía está expuesto/herido
         bajo tiro rival o si necesita cubrir un avance sin arriesgarse. */
      if(unitHasAction(u,'smoke')&&(u.smokes||0)>0&&u.energy>=2&&!smokeAt(u.x,u.y)){
        const smokeFocus=(effMode(G)==='escolta'&&drone&&cheb(target,drone)<=7&&hasLOS(target,drone))?drone:u;
        const foe=target;
        const exposed=foe&&cheb(smokeFocus,foe)<=6&&hasLOS(foe,smokeFocus)&&!coverBonus(smokeFocus,foe);
        const hurtOrPinned=(u.hp<u.maxHp*0.75)||u.energy<w.cost+2;
        const hurtsAllies=G.units.some(a=>a.alive&&a.team===u.team&&a!==u&&cheb(a,smokeFocus)<=1&&hasLOS(a,foe));
        if(foe&&(exposed||hurtOrPinned)&&!hurtsAllies){
          const stepX=Math.sign(foe.x-smokeFocus.x),stepY=Math.sign(foe.y-smokeFocus.y);
          const tx=Math.max(0,Math.min(W-1,smokeFocus.x+stepX)),ty=Math.max(0,Math.min(H-1,smokeFocus.y+stepY));
          if(cheb(u,{x:tx,y:ty})>=1&&cheb(u,{x:tx,y:ty})<=4)throwSmoke(u,tx,ty);
        }
      }
      /* Ingeniero: siembra una Claymore en un paso hacia el objetivo
         si le queda energía: casillas adyacentes libres que caigan en
         la baliza, en una zona de Dominación o en la extracción, o de
         cara al enemigo cercano. La coloca con la misma función que
         usa el jugador, así que paga su coste y gasta su cupo. */
      if(unitHasAction(u,'mine')&&(u.mines||0)>0&&u.energy>=MINE_COST){
        const cands=[[1,0],[-1,0],[0,1],[0,-1]].map(d=>({x:u.x+d[0],y:u.y+d[1]})).filter(p=>p.x>=0&&p.y>=0&&p.x<W&&p.y<H&&!blocked(p.x,p.y)&&!mineAt(p.x,p.y)&&!(p.x===TURRET_POS.x&&p.y===TURRET_POS.y)&&!G.map.medkits.some(m=>!m.used&&m.x===p.x&&m.y===p.y));
        let bestM=null,bestMS=-1;
        cands.forEach(p=>{let s=0;if(inBeacon(p.x,p.y))s+=3;if(domZones().some(z=>inDomZone(p.x,p.y,z)))s+=3;if(effMode(G)==='escolta'&&isExtraction(p.x,p.y))s+=3;if(cheb(p,target)<cheb(u,target))s+=1;if(cheb(p,target)<=3)s+=2;if(s>bestMS){bestMS=s;bestM=p;}});
        if(bestM&&(bestMS>=3||cheb(u,target)<=4))placeMine(u,bestM.x,bestM.y);
      }
      /* Comando: aturdidora M84 antes de abrir fuego. Busca la casilla
         a su alcance que más enemigos no aturdidos ciegue en radio 1,
         descontando a los aliados propios que el fogonazo también
         cegaría, y la lanza si el saldo es positivo (con dos o más
         enemigos cegados, siempre; con uno, la mitad de las veces).
         Va con la misma función que usa el jugador: paga su coste,
         gasta su cupo y el fogonazo le niega al objetivo el fuego de
         respuesta de este turno, que es justo lo que la IA aprovecha
         disparando después. */
      if(unitHasAction(u,'flash')&&(u.flashes||0)>0&&u.energy>=FLASH_COST){
        let bestF=null,bestFS=0,bestFE=0;
        for(let fy2=0;fy2<H;fy2++)for(let fx3=0;fx3<W;fx3++){
          if(cheb(u,{x:fx3,y:fy2})>FLASH_RANGE)continue;
          let fe=0,fa=0;
          G.units.forEach(e=>{if(!e.alive||e===u||cheb(e,{x:fx3,y:fy2})>1)return;if(e.team!==u.team){if(!e.stunned)fe++;}else fa++;});
          const fs=fe-fa;
          if(fe>0&&(fs>bestFS||(fs===bestFS&&fe>bestFE))){bestFS=fs;bestFE=fe;bestF={x:fx3,y:fy2};}
        }
        if(bestF&&(bestFE>=2||rng()<0.5))throwFlash(u,bestF.x,bestF.y);
      }
      /* Escolta: granada al dron cuando flaquea o sin blindaje */
      const droneGuarded=drone&&G.units.some(a=>a.alive&&a.team==='A'&&dist(a,drone)<=1);
      if(drone&&u.grenades>0&&u.energy>=2&&cheb(u,drone)<=3&&cheb(u,drone)>=2&&(!droneGuarded||drone.hp<=160)&&rng()<0.55){throwGrenade(u,drone.x,drone.y);return res();}
      /* Granada M67 táctica: busca la casilla óptima sin fuego amigo */
      if(u.grenades>0&&u.energy>=2){
        let bestG=null,bestGS=0,bestGE=0;
        for(let gy=0;gy<H;gy++)for(let gx=0;gx<W;gx++){
          if(cheb(u,{x:gx,y:gy})>3||cheb(u,{x:gx,y:gy})<=1)continue;
          let ge=0,ga=0,direct=0;
          G.units.forEach(e=>{if(!e.alive||cheb(e,{x:gx,y:gy})>1)return;if(e.team!==u.team){ge++;if(e.x===gx&&e.y===gy)direct=1;}else ga++;});
          if(ga>0)continue;
          const bHit=G.map.barrels.some(b=>b.alive&&cheb(b,{x:gx,y:gy})<=1&&G.units.some(e=>e.alive&&e.team!==u.team&&cheb(e,b)<=1));
          const gs=ge*2+(bHit?2:0)+direct;
          if((ge>=2||(ge>=1&&bHit))&&gs>bestGS){bestGS=gs;bestGE=ge;bestG={x:gx,y:gy};}
        }
        if(bestG){throwGrenade(u,bestG.x,bestG.y);return res();}
      }
      if(unitHasAction(u,'tranq')&&(u.tranqs||0)>0&&u.energy>=TRANQ_COST){
        const tgt=enemies.filter(e=>e.alive&&!e.stunned&&cheb(u,e)<=TRANQ_RANGE).sort((a,b)=>b.hp-a.hp)[0];
        if(tgt){throwTranq(u,tgt);return res();}
      }
      if(unitHasAction(u,'water')&&(u.water||0)>0&&u.energy>=WATER_COST){
        const tgt=enemies.filter(e=>e.alive&&cheb(u,e)<=WATER_RANGE).sort((a,b)=>cheb(u,a)-cheb(u,b))[0];
        if(tgt){waterCannon(u,tgt);return res();}
      }
      if(unitHasAction(u,'toolkit')&&(u.toolkits||0)>0&&u.energy>=TOOL_COST){
        const tur=G.deployed.filter(d=>d.alive&&d.team===u.team&&d.hp<d.maxHp&&cheb(u,d)<=TOOL_RANGE)[0];
        if(tur){useToolkit(u);}
      }
      if(unitHasAction(u,'shield')&&(u.shields||0)>0&&u.energy>=SHIELD_COST&&u.hp<=u.maxHp*0.6&&enemies.some(e=>cheb(u,e)<=6)){useShield(u);}
      if(unitHasAction(u,'arty')&&(u.arty||0)>0&&u.energy>=ARTY_COST){
        let bestA=null,bestAN=0;
        for(let gy=0;gy<H;gy++)for(let gx=0;gx<W;gx++){
          if(cheb(u,{x:gx,y:gy})>ARTY_RANGE||cheb(u,{x:gx,y:gy})===0)continue;
          let e=0,f=0;G.units.forEach(x=>{if(!x.alive||cheb(x,{x:gx,y:gy})>1)return;if(x.team!==u.team)e++;else f++;});
          if(e>f&&e>bestAN){bestAN=e;bestA={x:gx,y:gy};}
        }
        if(bestA&&bestAN>=1){fireArtillery(u,bestA.x,bestA.y);return res();}
      }
      if(unitHasAction(u,'bees')&&(u.bees||0)>0&&u.energy>=BEES_COST){
        const fat=enemies.filter(e=>e.alive&&cheb(u,e)<=BEES_RANGE).sort((a,b)=>b.hp-a.hp)[0];
        if(fat&&fat.beesT==null){throwBees(u,fat);return res();}
      }
      if(unitHasAction(u,'molotov')&&(u.molotovs||0)>0&&u.energy>=MOLOTOV_COST){
        let bestF=null,bestFN=0;
        for(let gy=0;gy<H;gy++)for(let gx=0;gx<W;gx++){
          if(cheb(u,{x:gx,y:gy})>3||cheb(u,{x:gx,y:gy})===0)continue;
          let e=0,f=0;G.units.forEach(x=>{if(!x.alive||cheb(x,{x:gx,y:gy})>1)return;if(x.team!==u.team)e++;else f++;});
          if(e>f&&e>bestFN){bestFN=e;bestF={x:gx,y:gy};}
        }
        if(bestF&&bestFN>=1){throwMolotov(u,bestF.x,bestF.y);return res();}
      }
      if(unitHasAction(u,'crate')&&(u.crates||0)>0&&u.energy>=CRATE_COST){
        const hurt=G.units.filter(a=>a.alive&&a.team===u.team&&a!==u&&a.hp<=a.maxHp*0.55).sort((a,b)=>a.hp-b.hp)[0];
        if(hurt){const spots=[[1,0],[-1,0],[0,1],[0,-1]].map(d=>({x:u.x+d[0],y:u.y+d[1]})).filter(p=>p.x>=0&&p.y>=0&&p.x<W&&p.y<H&&!blocked(p.x,p.y)&&!inBeacon(p.x,p.y));
          if(spots.length)placeHealthCrate(u,spots[0].x,spots[0].y);}
      }
      /* Habilidades nuevas (F4): gas del Artillero, cobertura del Ingeniero y barrido del Espía */
      if(unitHasAction(u,'gas')&&(u.gases||0)>0&&u.energy>=GAS_COST){
        let bestG=null,bestN=0;
        for(let gy=0;gy<H;gy++)for(let gx=0;gx<W;gx++){
          if(cheb(u,{x:gx,y:gy})>3||cheb(u,{x:gx,y:gy})===0)continue;
          let e=0,f=0;G.units.forEach(x=>{if(!x.alive||cheb(x,{x:gx,y:gy})>1)return;if(x.team!==u.team)e++;else f++;});
          if(e>f&&e>bestN){bestN=e;bestG={x:gx,y:gy};}
        }
        if(bestG&&bestN>=1){throwGas(u,bestG.x,bestG.y);return res();}
      }
      if(unitHasAction(u,'cover')&&(u.covers||0)>0&&u.energy>=COVER_COST&&enemies.some(e=>cheb(u,e)<=6)&&rng()<0.5){
        const spots=[[1,0],[-1,0],[0,1],[0,-1]].map(d=>({x:u.x+d[0],y:u.y+d[1]})).filter(p=>p.x>=0&&p.y>=0&&p.x<W&&p.y<H&&!blocked(p.x,p.y)&&!inBeacon(p.x,p.y));
        const ally=G.units.filter(a=>a.alive&&a.team===u.team&&a!==u&&a.hp<=a.maxHp*0.7).sort((a,b)=>a.hp-b.hp)[0];
        if(spots.length&&ally)placeCover(u,spots[0].x,spots[0].y);
      }
      if(unitHasAction(u,'sweep')&&(u.sweeps||0)>0&&u.energy>=SWEEP_COST){
        const inv=enemies.find(e=>e.invisible);
        if(inv){sweepDetect(u,inv.x,inv.y);return res();}
      }
      /* Escolta: si el dron está sin escolta pegada o tocado, concentrar fuego; si está bien escoltado, castiga al escolta crítico o presiona al dron */
      if(drone&&cheb(u,drone)<=w.rng&&hasLOS(u,drone)&&hitChance(u,drone,w)>0){
        if(hardAI&&unitHasAction(u,'special')&&canSnipeSpecial(u)&&!drone.movedThisTurn&&u.energy>=w.cost+3){useSpecial(u,drone);return res();}
        const weakEscort=G.units.some(a=>a.alive&&a.team==='A'&&a.hp<=50&&cheb(u,a)<=w.rng&&hasLOS(u,a)&&!smokeBlocksLOS(u,a));
        if(!droneGuarded||!weakEscort){
          let dshots=0;
          const maxDShots=(!droneGuarded||hardAI)?3:(drone.hp<=170?2:1);
          while(u.energy>=w.cost&&dshots<maxDShots&&G.drone&&G.drone.alive){if(!tryShoot(u,drone,u.weapon,null))break;dshots++;}
          if(!G||G.over||!G.drone||!G.drone.alive)return res();
        }
      }
      /* shoot: Élite/Normal concentran fuego en el objetivo alcanzable más herido; Recluta, en el más cercano */
      const pickShootTarget=()=>{
        const hittable=G.units.filter(e=>e.alive&&e.team!==u.team&&!e.invisible&&cheb(u,e)<=w.rng&&hasLOS(u,e)&&!smokeBlocksLOS(u,e)&&hitChance(u,e,w)>0);
        const pool=hittable.length?hittable:G.units.filter(e=>e.alive&&e.team!==u.team&&!e.invisible);
        pool.sort((a,b)=>G.difficulty==='recluta'?(dist(u,a)-dist(u,b)):(a.hp-b.hp||hitChance(u,b,w)-hitChance(u,a,w)));
        return pool[0]||null;
      };
      target=pickShootTarget();
      /* Francotirador Veterano/Élite: tiro certero sobre objetivo quieto */
      if(hardAI&&unitHasAction(u,'special')&&canSnipeSpecial(u)&&target&&!target.movedThisTurn&&u.energy>=WEAPONS[u.weapon].cost+3){useSpecial(u,target);return res();}
      let shots=0;
      const maxShots=(G.round===1&&w.rng>=8)?1:3;
      while(target&&u.energy>=w.cost&&shots<maxShots){if(!tryShoot(u,target,u.weapon,null))break;shots++;if(!target.alive)target=pickShootTarget();}
      if(u.energy>=1&&target&&cheb(u,target)<=3&&u.energy<w.cost)tryShoot(u,target,PISTOL,null);
      if(u.alive&&u.energy>=3&&shots===0&&!u.overwatch&&!u.stunned&&!lateStall&&rng()<(G.round===1?0.5:0.75)){u.energy-=3;u.overwatch=true;log('IA: '+u.role+' se queda en vigilancia.');}
      res();
    },420);
  });
}

export async function runAI(){
  if(!G||G.over)return;G.aiBusy=true;updateUI();
  const units=G.units.filter(u=>u.team==='B'&&u.alive);
  for(const u of units){if(!G||G.over)break;G.selected=u;draw();await aiUnitAct(u);draw();updateUI();}
  G.aiBusy=false;
  if(G&&!G.over)endTurn();
}
