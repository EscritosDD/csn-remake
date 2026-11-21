import { MAP_DEFS } from '../data/maps.js';
import { ROLES, BODIES } from '../data/roles.js';
import { cheb, facingVec } from '../core/geometry.js';

export const GRID_CACHE={};

export const NATIVE_MAP_IDS={skirmish:'03',skirmish04:'04',skirmish05:'05',skirmish06:'06',skirmish08:'08',skirmish09:'09',skirmish10:'10',skirmish11:'11'};

export const DEBUG_GRID=typeof location!=='undefined'&&/(?:^|[?&])debugGrid(?:[=&]|$)/.test(location.search||'');

export const DEBUG_WEAPONS=typeof location!=='undefined'&&/(?:^|[?&])debugWeapons(?:[=&]|$)/.test(location.search||'');

export function setBoardSize(w,h){
  W=w;H=h;
  const cx=Math.floor((w-1)/2),cy=Math.floor((h-1)/2);
  BEACON=[{x:cx,y:cy},{x:cx+1,y:cy},{x:cx,y:cy+1},{x:cx+1,y:cy+1}].filter(b=>b.x<w&&b.y<h);
  TURRET_POS={x:BEACON[0].x,y:BEACON[0].y};
  if(G){G.W=w;G.H=h;}
}

export function applyNativeGrid(grid){
  setBoardSize(grid.size[0],grid.size[1]);
  NATIVE_GRID=grid;
  if(grid.controlPoints&&grid.controlPoints.length){
    const cx=Math.round(grid.controlPoints.reduce((a,p)=>a+p[1],0)/grid.controlPoints.length);
    const cy=Math.round(grid.controlPoints.reduce((a,p)=>a+p[2],0)/grid.controlPoints.length);
    BEACON=[{x:cx,y:cy},{x:cx+1,y:cy},{x:cx,y:cy+1},{x:cx+1,y:cy+1}].filter(b=>b.x>=0&&b.y>=0&&b.x<W&&b.y<H);
    TURRET_POS={x:BEACON[0].x,y:BEACON[0].y};
  }
  if(grid.spawns&&grid.spawns.length&&!grid._spawnsByTeam){
    const axis=(Math.max(...grid.spawns.map(s=>s[1]))-Math.min(...grid.spawns.map(s=>s[1])))>=(Math.max(...grid.spawns.map(s=>s[2]))-Math.min(...grid.spawns.map(s=>s[2])))?1:2;
    const sorted=grid.spawns.slice().sort((a,b)=>a[axis]-b[axis]);
    const half=Math.floor(sorted.length/2);
    grid._spawnsByTeam={A:sorted.slice(0,half).map(s=>({x:s[1],y:s[2]})),B:sorted.slice(half).map(s=>({x:s[1],y:s[2]}))};
  }
}

export function nativeTile(x,y){
  return NATIVE_GRID&&x>=0&&y>=0&&x<W&&y<H?NATIVE_GRID.tiles[y*W+x]:null;
}

export function nativeEdgeBits(x,y,nx,ny){
  const a=nativeTile(x,y),b=nativeTile(nx,ny);
  if(!a||!b)return null;
  if(nx===x+1)return [a[1]&2,b[1]&8,a[3],b[5]];
  if(nx===x-1)return [a[1]&8,b[1]&2,a[5],b[3]];
  if(ny===y+1)return [a[1]&4,b[1]&1,a[4],b[2]];
  if(ny===y-1)return [a[1]&1,b[1]&4,a[2],b[4]];
  return null;
}

export function nativeSolidEdge(x,y,nx,ny){
  const e=nativeEdgeBits(x,y,nx,ny);
  return !!e&&!!(e[0]||e[1]);
}

export function nativeBlocked(x,y){
  const t=nativeTile(x,y);
  return !!t&&t[1]===15;
}

export function tileWorldY(x,y){
  const t=nativeTile(Math.round(x),Math.round(y));
  return t?t[0]/32:0;
}

export function spawnsFor(team){
  return NATIVE_GRID&&NATIVE_GRID._spawnsByTeam?(NATIVE_GRID._spawnsByTeam[team]||[]):(team==='A'?SPAWNS_A:SPAWNS_B);
}

export function boardCenter(){return {x:(W-1)/2,y:(H-1)/2};}

export function preloadNativeGrids(){
  return Promise.all(Object.values(NATIVE_MAP_IDS).map(id=>fetch('assets/maps/'+id+'_grid.json').then(r=>r.ok?r.json():null).then(j=>{if(j)GRID_CACHE[id]=j;}).catch(()=>{})));
}

export function buildMap(mapId){
  setBoardSize(12,12);
  NATIVE_GRID=null;
  const def=MAP_DEFS[mapId]||MAP_DEFS.almacen;
  const nativeId=NATIVE_MAP_IDS[mapId];
  const native=nativeId?GRID_CACHE[nativeId]:null;
  if(native){
    applyNativeGrid(native);
    return {id:def.id,theme:def.theme||'warehouse',name:def.name,obstacles:[],barrels:[],medkits:[],turret:{x:TURRET_POS.x,y:TURRET_POS.y,owner:null},native:native};
  }
  const walls=def.walls.map(([x,y])=>({x,y,type:'wall',hp:Infinity}));
  const shelves=def.shelves.map(([x,y])=>({x,y,type:'shelf',hp:Infinity}));
  const crates=def.crates.map(([x,y])=>({x,y,type:'crate',hp:50,maxHp:50}));
  const barrels=def.barrels.map(([x,y])=>({x,y,hp:1,alive:true}));
  const medkits=def.medkits.map(([x,y])=>({x,y,used:false}));
  return {id:def.id,theme:def.theme||'warehouse',name:def.name,obstacles:walls.concat(shelves,crates),barrels,medkits,turret:{x:TURRET_POS.x,y:TURRET_POS.y,owner:null}};
}

export function obAt(x,y){return G.map.obstacles.find(o=>o.x===x&&o.y===y);}

export function barrelAt(x,y){return G.map.barrels.find(b=>b.alive&&b.x===x&&b.y===y);}

export function unitAt(x,y){return G.units.find(u=>u.alive&&u.x===x&&u.y===y);}

export function deployedAt(x,y){return G.deployed.find(t=>t.alive&&t.x===x&&t.y===y);}

export function droneAt(x,y){return (G&&G.drone&&G.drone.alive&&G.drone.x===x&&G.drone.y===y)?G.drone:null;}

export function blocked(x,y){return x<0||y<0||x>=W||y>=H||!!obAt(x,y)||nativeBlocked(x,y)||!!barrelAt(x,y)||!!unitAt(x,y)||!!deployedAt(x,y)||!!droneAt(x,y);}

export function canStep(x0,y0,x1,y1,ignoreActors){
  if(x1<0||y1<0||x1>=W||y1>=H)return false;
  if(Math.abs(x1-x0)+Math.abs(y1-y0)!==1)return false;
  if(nativeSolidEdge(x0,y0,x1,y1))return false;
  if(barrelAt(x1,y1))return false;
  if(obAt(x1,y1)||nativeBlocked(x1,y1))return false;
  if(!ignoreActors&&(unitAt(x1,y1)||deployedAt(x1,y1)||droneAt(x1,y1)))return false;
  return true;
}

export const SMOKE_TURNS=2;

export function smokeAt(x,y){return (G&&G.smoke||[]).find(s=>s.x===x&&s.y===y&&s.kind!=='fuego')||null;}

export function smokeBlocksLOS(a,b){
  /* Estar dentro del humo también tapa: si el tirador o el objetivo
     están sobre una casilla de humo, no hay tiro a más de 1 casilla
     (ni hacia fuera ni hacia dentro). Sin esta regla, un tiro en
     diagonal se colaba entre los brazos de la cruz y acertaba a un
     soldado envuelto en humo, porque la recta de Bresenham pasaba
     por la esquina libre entre dos casillas de la cruz. */
  if(cheb(a,b)>1&&(smokeAt(a.x,a.y)||smokeAt(b.x,b.y)))return true;
  /* Y cuentan las casillas intermedias de la recta: ni la del
     tirador ni la del objetivo tapan su propio tiro por intermedias.
     A 1 casilla no hay intermedias, así que el cuerpo a cuerpo
     nunca se bloquea. */
  let x0=a.x,y0=a.y,x1=b.x,y1=b.y;const dx=Math.abs(x1-x0),dy=Math.abs(y1-y0),sx=x0<x1?1:-1,sy=y0<y1?1:-1;let err=dx-dy,x=x0,y=y0,guard=0;
  while(guard++<60){if(x===x1&&y===y1)return false;const e2=2*err;
    if(e2>-dy){err-=dy;x+=sx;} if(e2<dx){err+=dx;y+=sy;}
    if(x===x1&&y===y1)return false;
    if(smokeAt(x,y))return true;}
  return false;
}

export function inBeacon(x,y){return BEACON.some(b=>b.x===x&&b.y===y);}

export function moveCostOf(unit){const r=ROLES[unit.role];return r?(BODIES[r.body]||BODIES.medio).moveCost:2;}

export function reachable(unit,budget){
  const mc=moveCostOf(unit);
  const dirs=(unit&&unit.team==='B')?[[-1,0],[1,0],[0,-1],[0,1]]:[[1,0],[-1,0],[0,1],[0,-1]];
  const seen=new Map();const key=(x,y)=>x+','+y;
  const q=[{x:unit.x,y:unit.y,d:0}];seen.set(key(unit.x,unit.y),0);
  while(q.length){const c=q.shift();if(c.d+mc>budget)continue;
    dirs.forEach(([dx,dy])=>{const nx=c.x+dx,ny=c.y+dy,k=key(nx,ny);
      if(nx<0||ny<0||nx>=W||ny>=H||seen.has(k))return;
      if(!canStep(c.x,c.y,nx,ny,false))return;
      seen.set(k,c.d+mc);q.push({x:nx,y:ny,d:c.d+mc});});}
  seen.delete(key(unit.x,unit.y));return seen;
}

export const DRAW_MOVE_MS_PER_TILE=235;

export function drawMovePath(unit,from,to){
  const key=(x,y)=>x+','+y;
  const sx=Math.round(from.x),sy=Math.round(from.y),tx=to.x,ty=to.y;
  if(sx===tx&&sy===ty)return [{x:sx,y:sy},{x:tx,y:ty}];
  const prev=new Map([[key(sx,sy),null]]);
  const q=[{x:sx,y:sy}];
  const dirs=[[1,0],[-1,0],[0,1],[0,-1]];
  let found=false;
  while(q.length&&q.length<4000){
    const c=q.shift();
    if(c.x===tx&&c.y===ty){found=true;break;}
    for(const [dx,dy] of dirs){
      const nx=c.x+dx,ny=c.y+dy,k=key(nx,ny);
      if(nx<0||ny<0||nx>=W||ny>=H||prev.has(k))continue;
      if(!canStep(c.x,c.y,nx,ny,nx===tx&&ny===ty))continue;
      prev.set(k,key(c.x,c.y));q.push({x:nx,y:ny});
    }
  }
  if(!found)return null;
  const out=[];let k=key(tx,ty);
  while(k!=null){const [x,y]=k.split(',').map(Number);out.push({x,y});k=prev.get(k);}
  return out.reverse();
}

export function startDrawMove(un,path){
  const now=FX.t||performance.now();
  un._drawLastX=un.x;un._drawLastY=un.y;
  if(!path||path.length<2){un._drawPath=null;un._drawSegs=[];un._drawLen=0;return;}
  const from={x:un.dx!=null?un.dx:un.x,y:un.dy!=null?un.dy:un.y};
  const a=path[0],b=path[1];
  const start={x:from.x,y:from.y};
  if(Math.abs(b.x-a.x)>=Math.abs(b.y-a.y))start.y=a.y;else start.x=a.x;
  const pts=[start,...path.slice(1)];
  const segs=[];let total=0;
  for(let i=0;i<pts.length-1;i++){
    const len=Math.abs(pts[i+1].x-pts[i].x)+Math.abs(pts[i+1].y-pts[i].y);
    if(len>0.0001){segs.push({a:pts[i],b:pts[i+1],len});total+=len;}
  }
  un._drawPath=pts;un._drawSegs=segs;un._drawLen=total;
  un._drawPathT0=now;
  un._drawPathDur=Math.max(120,total*DRAW_MOVE_MS_PER_TILE);
}

export function smoothDrawStep(p){return p*p*(3-2*p);}

export function updateUnitDrawPosition(un,now){
  if(un.dx==null){un.dx=un.x;un.dy=un.y;un._drawLastX=un.x;un._drawLastY=un.y;un._drawLastT=now;return;}
  if(un._drawLastX==null){un._drawLastX=un.x;un._drawLastY=un.y;}
  if(REDUCED_MOTION){
    un.dx=un.x;un.dy=un.y;un._drawPath=null;un._drawSegs=[];un._moveYaw=null;
    un._drawLastX=un.x;un._drawLastY=un.y;un._drawLastT=now;return;
  }
  if(un.x!==un._drawLastX||un.y!==un._drawLastY){
    const from={x:un.dx,y:un.dy};
    un._drawLastX=un.x;un._drawLastY=un.y;
    if(Math.abs(un.x-from.x)>0.02||Math.abs(un.y-from.y)>0.02){
      const path=drawMovePath(un,from,{x:un.x,y:un.y});
      if(path&&path.length>1)startDrawMove(un,path);
    }
  }
  const segs=un._drawSegs||[];
  if(segs.length&&un._drawLen>0){
    const raw=Math.max(0,Math.min(1,(now-(un._drawPathT0||now))/(un._drawPathDur||120)));
    let left=smoothDrawStep(raw)*un._drawLen;
    for(let i=0;i<segs.length;i++){
      const s=segs[i];
      if(left<=s.len||i===segs.length-1){
        const f=Math.max(0,Math.min(1,left/s.len));
        un.dx=s.a.x+(s.b.x-s.a.x)*f;
        un.dy=s.a.y+(s.b.y-s.a.y)*f;
        un._moveYaw=Math.atan2(s.b.y-s.a.y,s.b.x-s.a.x);
        break;
      }
      left-=s.len;
    }
    if(raw>=1){un.dx=un.x;un.dy=un.y;un._drawPath=null;un._drawSegs=[];un._moveYaw=null;}
  }else{
    const dt=now-(un._drawLastT||now);
    const k=1-Math.pow(0.02,dt/260);
    un.dx+=(un.x-un.dx)*k;un.dy+=(un.y-un.dy)*k;
    if(Math.abs(un.x-un.dx)<0.01)un.dx=un.x;
    if(Math.abs(un.y-un.dy)<0.01)un.dy=un.y;
    un._moveYaw=null;
  }
  un._drawLastT=now;
}

export function pathDist(a,b){ /* BFS distance ignoring units */
  if(a.x===b.x&&a.y===b.y)return 0;
  const seen=new Set([a.x+','+a.y]);let q=[{x:a.x,y:a.y,d:0}];
  while(q.length){const c=q.shift();const dirs=[[1,0],[-1,0],[0,1],[0,-1]];
    for(const [dx,dy] of dirs){const nx=c.x+dx,ny=c.y+dy,k=nx+','+ny;
      if(nx<0||ny<0||nx>=W||ny>=H||seen.has(k)||!canStep(c.x,c.y,nx,ny,true))continue;
      if(nx===b.x&&ny===b.y)return c.d+1;seen.add(k);q.push({x:nx,y:ny,d:c.d+1});}}
  return 99;
}

export function gridLineCells(a,b){
  let x0=a.x,y0=a.y,x1=b.x,y1=b.y;const dx=Math.abs(x1-x0),dy=Math.abs(y1-y0),sx=x0<x1?1:-1,sy=y0<y1?1:-1;let err=dx-dy,x=x0,y=y0,guard=0;
  const out=[{x,y}];
  while(guard++<W+H+2){if(x===x1&&y===y1)break;const e2=2*err;
    if(e2>-dy){err-=dy;x+=sx;} if(e2<dx){err+=dx;y+=sy;}
    out.push({x,y});}
  return out;
}

export function hasLOS(a,b){
  const cells=gridLineCells(a,b);
  if(NATIVE_GRID){
    for(let i=0;i<cells.length;i++){
      const t=nativeTile(cells[i].x,cells[i].y);
      if(t&&i>0&&i<cells.length-1&&t[6])return false;
      if(i===0||i===cells.length-1)continue;
      const e=nativeEdgeBits(cells[i-1].x,cells[i-1].y,cells[i].x,cells[i].y);
      if(e&&((e[0]||e[1])||Math.max(e[2],e[3])>=3))return false;
    }
    return true;
  }
  for(let i=1;i<cells.length-1;i++){const o=obAt(cells[i].x,cells[i].y);if(o&&(o.type==='wall'||o.type==='shelf'))return false;}
  return true;
}

export function coverLevel(target,shooter){
  if(NATIVE_GRID){
    const dx=shooter.x-target.x,dy=shooter.y-target.y;
    let nx=target.x,ny=target.y;
    if(Math.abs(dx)>=Math.abs(dy))nx+=dx>=0?1:-1;else ny+=dy>=0?1:-1;
    const e=nativeEdgeBits(target.x,target.y,nx,ny);
    return e?Math.max(e[2],e[3]):0;
  }
  let best=0;
  const dirs=[[1,0],[-1,0],[0,1],[0,-1]];
  for(const [dx,dy] of dirs){const o=obAt(target.x+dx,target.y+dy);if(!o)continue;
    const toward=dx*(shooter.x-target.x)+dy*(shooter.y-target.y);
    if(toward<=0)continue;
    let lvl=0;
    if(o.type==='wall'||o.type==='shelf')lvl=3;
    else if(o.type==='crate')lvl=(o.hp>o.maxHp/2)?2:1;
    if(lvl>best)best=lvl;}
  return best;
}

export function coverBonus(target,shooter){return coverLevel(target,shooter)>0;}

export function isFlanked(shooter,target){
  if(!target||target.facing==null&&!target.team)return false;
  const fv=facingVec(target);
  const vx=shooter.x-target.x, vy=shooter.y-target.y;
  const len=Math.abs(vx)+Math.abs(vy);if(!len)return false;
  return (fv[0]*vx+fv[1]*vy)/len< -0.2;
}

export function hitChance(shooter,target,weapon){
  if(target.invisible)return 0;
  const d=cheb(shooter,target);if(d>weapon.rng)return 0;
  if(!hasLOS(shooter,target))return 0;
  if(smokeBlocksLOS(shooter,target))return 0;
  let p=92;
  p-=[0,12,25,40][coverLevel(target,shooter)];
  /* Aturdido por una M84: el fogonazo deja al tirador viendo estrellas
     durante su turno aturdido, y cada tiro suyo pierde 25 de puntería. */
  if(shooter.stunned)p-=STUN_AIM_PEN;
  if(d>weapon.rng/2)p-=Math.floor((d-weapon.rng/2)*6);
  if(d===1&&weapon.cat==='Francotirador')p-=20;
  if(target.role&&isFlanked(shooter,target))p+=12;
  return Math.max(25,Math.min(95,p));
}

export function falloffFactor(shooter,target,weapon){
  const d=cheb(shooter,target), half=Math.floor(weapon.rng/2);
  if(d<=half)return 1;
  return Math.max(0.6,1-0.08*(d-half));
}
