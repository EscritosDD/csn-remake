import { tileWorldY } from '../game/board.js';
import { T3, VIEW_MODE, w2cx, w2cz } from './scene.js';
import { TEAM_A_HEX, TEAM_B_HEX, SELECT_LIME_HEX, SELECT_GOLD, SELECT_GOLD_HEX } from './env.js';

const CAPS={tracer:12,hit:16,boom:8,float:10};
const pools={tracer:[],hit:[],boom:[],float:[]};
const live=[];

function makeTracer(){
  const mesh=new THREE.Mesh(new THREE.BoxGeometry(0.08,0.08,1),new THREE.MeshBasicMaterial({color:SELECT_GOLD_HEX,transparent:true,opacity:0.95,depthWrite:false}));
  mesh.visible=false;return mesh;
}

function makeHit(){
  const grp=new THREE.Group();
  const ring=new THREE.Mesh(new THREE.RingGeometry(0.11,0.2,20),new THREE.MeshBasicMaterial({color:SELECT_GOLD_HEX,transparent:true,opacity:0.9,side:THREE.DoubleSide,depthWrite:false}));
  ring.rotation.x=-Math.PI/2;grp.add(ring);
  const spark=new THREE.Mesh(new THREE.PlaneGeometry(0.14,0.14),new THREE.MeshBasicMaterial({color:0xffffff,transparent:true,opacity:0.85,side:THREE.DoubleSide,depthWrite:false}));
  spark.rotation.x=-Math.PI/2;spark.position.y=0.12;grp.add(spark);
  grp.userData={ring:ring,spark:spark};grp.visible=false;return grp;
}

function makeBoom(){
  const grp=new THREE.Group();
  const outer=new THREE.Mesh(new THREE.RingGeometry(0.2,0.31,28),new THREE.MeshBasicMaterial({color:0xff7b29,transparent:true,opacity:0.85,side:THREE.DoubleSide,depthWrite:false}));
  outer.rotation.x=-Math.PI/2;grp.add(outer);
  const inner=new THREE.Mesh(new THREE.RingGeometry(0.1,0.18,24),new THREE.MeshBasicMaterial({color:SELECT_GOLD_HEX,transparent:true,opacity:0.9,side:THREE.DoubleSide,depthWrite:false}));
  inner.rotation.x=-Math.PI/2;inner.position.y=0.03;grp.add(inner);
  const core=new THREE.Mesh(new THREE.SphereGeometry(0.22,12,10),new THREE.MeshBasicMaterial({color:0xff7b29,transparent:true,opacity:0.7,depthWrite:false}));
  core.position.y=0.36;grp.add(core);
  grp.userData={outer:outer,inner:inner,core:core};grp.visible=false;return grp;
}

function take(kind){
  if(typeof THREE==='undefined'||!T3||!T3.fxGroup)return null;
  let node=pools[kind].pop();
  if(!node)node=kind==='tracer'?makeTracer():kind==='hit'?makeHit():kind==='boom'?makeBoom():null;
  if(!node)return null;
  node.visible=true;T3.fxGroup.add(node);return node;
}

function recycle(item){
  const node=item&&item.node;if(!node)return;
  if(item.kind==='float'){
    if(node.parentNode)node.parentNode.removeChild(node);
    if(pools.float.length<CAPS.float)pools.float.push(node);
    return;
  }
  if(node.parent)node.parent.remove(node);
  node.visible=false;
  if(pools[item.kind].length<CAPS[item.kind])pools[item.kind].push(node);
  else if(node.traverse)node.traverse(o=>{if(o.geometry)o.geometry.dispose();if(o.material)o.material.dispose();});
}

function enforceCap(kind){
  let n=0;for(const it of live)if(it.kind===kind)n++;
  while(n>CAPS[kind]){
    const i=live.findIndex(it=>it.kind===kind);
    if(i<0)break;
    recycle(live[i]);live.splice(i,1);n--;
  }
}

function push(kind,node,born,life,tick){
  live.push({kind:kind,node:node,born:born,life:life,tick:tick});
  enforceCap(kind);
}

function ready(now,REDUCED_MOTION){
  return !REDUCED_MOTION&&typeof THREE!=='undefined'&&!!T3&&!!T3.fxGroup&&VIEW_MODE==='3d'&&Number.isFinite(now);
}

export function arcadeTracer(from,to,cat,team,now,REDUCED_MOTION){
  if(!ready(now,REDUCED_MOTION)||!from||!to||from.x==null||to.x==null)return;
  const node=take('tracer');if(!node)return;
  const p0=new THREE.Vector3(w2cx(from.x),tileWorldY(from.x,from.y)+0.72,w2cz(from.y));
  const p1=new THREE.Vector3(w2cx(to.x),tileWorldY(to.x,to.y)+0.64,w2cz(to.y));
  const len=Math.max(0.2,p1.clone().sub(p0).length());
  const col=team==='B'?TEAM_B_HEX:TEAM_A_HEX;
  node.material.color.setHex(cat==='Francotirador'?SELECT_LIME_HEX:(cat==='Lanzacohetes'||cat==='Lanzagranadas'?SELECT_GOLD_HEX:col));
  node.position.copy(p0);node.lookAt(p1);node.scale.set(1,1,Math.min(0.9,len*0.45));
  push('tracer',node,now,180,(it,k)=>{
    node.position.lerpVectors(p0,p1,k);
    node.material.opacity=Math.max(0,0.95-k*0.7);
  });
}

export function arcadeHit(x,y,n,col,now,REDUCED_MOTION){
  if(!ready(now,REDUCED_MOTION))return;
  const node=take('hit');if(!node)return;
  const cx=w2cx(x),cz=w2cz(y),crit=(Number(n)||0)>=60;
  const color=crit?SELECT_GOLD_HEX:(col||SELECT_LIME_HEX);
  const {ring,spark}=node.userData;
  node.position.set(cx,tileWorldY(x,y)+0.1,cz);
  ring.material.color.set(color);spark.material.color.set(color);
  push('hit',node,now,280,(it,k)=>{
    ring.scale.setScalar(1+k*2.2);
    ring.material.opacity=Math.max(0,0.9*(1-k));
    spark.scale.setScalar(0.5+(0.9+Math.min(1.6,(Number(n)||6)/40))*k);
    spark.position.x=Math.cos(k*6.28)*0.4*k;
    spark.position.z=Math.sin(k*6.28)*0.4*k;
    spark.material.opacity=Math.max(0,0.85*(1-k));
  });
}

export function arcadeExplosion(x,y,kind,now,REDUCED_MOTION){
  if(!ready(now,REDUCED_MOTION))return;
  const node=take('boom');if(!node)return;
  const cx=w2cx(x),cz=w2cz(y);
  const col=kind==='heal'?SELECT_LIME_HEX:(kind==='smoke'?0xd6dbe0:(kind==='flash'?SELECT_GOLD_HEX:0xff7b29));
  const {outer,inner,core}=node.userData;
  node.position.set(cx,tileWorldY(x,y)+0.08,cz);
  outer.material.color.setHex(col);inner.material.color.setHex(kind==='heal'?SELECT_LIME_HEX:SELECT_GOLD_HEX);core.material.color.setHex(col);
  push('boom',node,now,480,(it,k)=>{
    outer.scale.setScalar(1+k*3.4);
    inner.scale.setScalar(1+k*2.1);
    core.scale.setScalar(1+k*1.9);
    core.position.y=0.36+k*(kind==='heal'?0.9:0.2);
    outer.material.opacity=Math.max(0,0.85*(1-k));
    inner.material.opacity=Math.max(0,0.9*(1-k*0.8));
    core.material.opacity=Math.max(0,0.7*(1-k));
  });
}

function takeFloat(){
  const host=document.getElementById('glFloats');if(!host)return null;
  let el=pools.float.pop();
  if(!el){el=document.createElement('div');el.className='gl-float comic';}
  if(el.parentNode!==host)host.appendChild(el);
  return el;
}

export function arcadeFloat(x,y,txt,col,now,REDUCED_MOTION){
  if(!ready(now,REDUCED_MOTION))return;
  const el=takeFloat();if(!el)return;
  el.textContent=String(txt==null?'':txt);
  el.style.color=col||SELECT_GOLD;
  el.dataset.wx=String(w2cx(x));el.dataset.wz=String(w2cz(y));el.dataset.wy=String(tileWorldY(x,y));el.dataset.born=String(now);
  push('float',el,now,950,null);
}

function projectFloat(el,k,w,h){
  if(!el||!T3.camera||typeof THREE==='undefined')return;
  const v=T3._arcV||(T3._arcV=new THREE.Vector3());
  v.set(+el.dataset.wx,(+el.dataset.wy||0)+1.58+k*0.85,+el.dataset.wz).project(T3.camera);
  if(v.z<-1||v.z>1){el.style.opacity='0';return;}
  el.style.left=((v.x*0.5+0.5)*w).toFixed(1)+'px';
  el.style.top=((-v.y*0.5+0.5)*h).toFixed(1)+'px';
  el.style.opacity=k<0.65?'1':String(Math.max(0,1-(k-0.65)/0.35));
}

export function tickArcadeFx(w,h,now){
  if(!T3||!T3.fxGroup||VIEW_MODE!=='3d'||typeof THREE==='undefined')return;
  const time=Number.isFinite(now)?now:(typeof performance!=='undefined'?performance.now():Date.now());
  for(let i=live.length-1;i>=0;i--){
    const it=live[i],age=time-it.born;
    if(age>=it.life){recycle(it);live.splice(i,1);continue;}
    const k=Math.max(0,Math.min(1,age/it.life));
    if(it.tick)it.tick(it,k);
    if(it.kind==='float')projectFloat(it.node,k,w,h);
  }
}

export function resetArcadeFx(){
  for(const it of live)recycle(it);
  live.length=0;
}

export function arcadeFxStats(){
  return {live:live.length,pools:{tracer:pools.tracer.length,hit:pools.hit.length,boom:pools.boom.length,float:pools.float.length}};
}
