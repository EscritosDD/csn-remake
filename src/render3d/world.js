import { hash2 } from '../render2d/tiles.js';
import { cheb, dist } from '../core-and-audio.js';
import { WEAPONS, PISTOL } from '../data/weapons.js';
import { T3, w2cx, mat3, box3, TEX3, procTex3, texMat3, makeContactShadow3, skyTheme3, nationTintColor, emblemTexture } from './scene.js';
import { makeGunProp3 } from './gun.js';
import { makeSoldier3 } from './fallback-soldier.js';
import { REAL } from './assets-real.js';
import { skState, loadSkirmishGeo, buildSkirmishGeo3, makeDrone3 } from './assets-geo.js';
import { makeRealSoldier3 } from './soldiers.js';
import { getRealSpriteImage } from './real-sprites.js';
import { buildThemedProps3 } from './world-props.js';

export function build3DWorld(){
  if(!T3||!G)return;
  const sc=T3.scene;
  if(T3.world){sc.remove(T3.world);}
  ['unitsGroup','dynGroup','hlGroup','aimGroup','fxGroup'].forEach(k=>{if(T3[k])sc.remove(T3[k]);});
  const world=new THREE.Group();sc.add(world);T3.world=world;
  T3.unitsGroup=new THREE.Group();sc.add(T3.unitsGroup);
  T3.dynGroup=new THREE.Group();sc.add(T3.dynGroup);
  T3.hlGroup=new THREE.Group();sc.add(T3.hlGroup);
  T3.aimGroup=new THREE.Group();sc.add(T3.aimGroup);
  T3.fxGroup=new THREE.Group();sc.add(T3.fxGroup);
  T3.fxItems=[];T3.units=new Map();T3.dynSig='__none__';T3.hlSig='__none__';T3.hoverSig='__none__';
  if(T3.hudPool){T3.hudPool.forEach(rec=>{if(rec&&rec.el)rec.el.remove();});T3.hudPool.clear();}
  const flEl=document.getElementById('glFloats');if(flEl)flEl.innerHTML='';
  const sky=skyTheme3(G.map.theme);
  sc.background=new THREE.Color(sky.bg);
  sc.fog=new THREE.Fog(sky.fog,28,50);
  const skSt=skState(G.map.theme);
  const skTheme=!!skSt;
  const depotTheme=G.map.theme==='depot';
  const platformTheme=G.map.theme==='platform';
  const marketTheme=G.map.theme==='market';
  const terminalTheme=G.map.theme==='terminal';
  const plazaTheme=G.map.theme==='plaza';
  const dockTheme=G.map.theme==='dock';
  const rotondaTheme=G.map.theme==='rotonda';
  const cruceTheme=G.map.theme==='cruce';
  const astilleroTheme=G.map.theme==='astillero';
  const geoShown=skTheme&&skSt.ready;
  if(skTheme&&!skSt.ready)loadSkirmishGeo(G.map.theme);
  if(!geoShown){
    /* Entorno diorama exterior para los tableros sin .bin del IPA: plataforma urbana
       y acera perimetral para que el tablero no flote en el vacío. */
    const apronMat=texMat3('apron',null,0.95);
    const apron=new THREE.Mesh(new THREE.PlaneGeometry(34,34),apronMat);
    apron.rotation.x=-Math.PI/2;apron.position.y=-0.12;apron.receiveShadow=true;world.add(apron);
    const tileCol=(x,y)=>{const h=hash2(x,y);
      const asphalt=(y===H-1);
      return skTheme?['#7e8288','#787c82','#868a90','#74787e'][Math.floor(h*4)]:plazaTheme?['#a8a294','#9f9a8c','#b0aa9c','#97927f'][Math.floor(h*4)]:cruceTheme?['#6b5850','#63524b','#736259','#5b4c45'][Math.floor(h*4)]:astilleroTheme?['#42565e','#3c5058','#4a5e66','#364a52'][Math.floor(h*4)]:rotondaTheme?['#5f5b52','#57534b','#67635b','#4f4c44'][Math.floor(h*4)]:dockTheme?['#4e5d5c','#465554','#576664','#3f4f4e'][Math.floor(h*4)]:depotTheme?['#7d838a','#757b83','#858b91','#6f757d'][Math.floor(h*4)]:platformTheme?['#6f6259','#665a50','#786a5e','#5d5148'][Math.floor(h*4)]:marketTheme?['#8a7a5c','#82724f','#93835f','#7a6a4e'][Math.floor(h*4)]:terminalTheme?['#4f5a63','#48525b','#57626c','#424c54'][Math.floor(h*4)]:asphalt?['#5b5e63','#56595e','#5f6267','#53565b'][Math.floor(h*4)]:['#99968e','#918e85','#a09d94','#8b887f'][Math.floor(h*4)];};
    let done=false;
    try{
      const cv=document.createElement('canvas');cv.width=cv.height=1024;
      const g2=cv.getContext('2d');
      const cell=1024/W;
      for(let y=0;y<H;y++)for(let x=0;x<W;x++){
        const px=Math.floor(x*cell),py=Math.floor(y*cell),cw=Math.ceil(cell),ch=Math.ceil(cell),h=hash2(x,y);
        g2.fillStyle=tileCol(x,y);g2.fillRect(px,py,cw,ch);
        g2.fillStyle='rgba(255,255,255,0.08)';g2.fillRect(px,py,cw,3);g2.fillRect(px,py,3,ch);
        g2.fillStyle='rgba(0,0,0,0.14)';g2.fillRect(px,py+ch-3,cw,3);g2.fillRect(px+cw-3,py,3,ch);
        if(y===H-1&&!skTheme&&!plazaTheme&&!marketTheme){
          if(x%2===0){g2.fillStyle='rgba(242,240,224,0.52)';g2.fillRect(px+cw*0.18,py+ch*0.47,cw*0.64,5);}
        } else if(h<0.18){
          g2.strokeStyle='rgba(30,32,36,0.28)';g2.lineWidth=2;g2.beginPath();g2.moveTo(px+cw*0.25,py+ch*0.25);g2.lineTo(px+cw*0.55,py+ch*0.52);g2.lineTo(px+cw*0.42,py+ch*0.72);g2.stroke();
        } else if(h>0.91){
          g2.fillStyle='rgba(242,178,52,0.28)';g2.fillRect(px+cw*0.15,py+ch*0.8,cw*0.7,4);
        }
      }
      g2.strokeStyle='rgba(20,22,18,0.48)';g2.lineWidth=2;
      for(let k=0;k<=W;k++){const p=Math.round(k*cell);
        g2.beginPath();g2.moveTo(p,0);g2.lineTo(p,1024);g2.stroke();
        g2.beginPath();g2.moveTo(0,p);g2.lineTo(1024,p);g2.stroke();}
      const ftex=new THREE.CanvasTexture(cv);ftex.colorSpace=THREE.SRGBColorSpace;ftex.anisotropy=4;
      const slab=new THREE.Mesh(new THREE.BoxGeometry(W,0.09,H),new THREE.MeshStandardMaterial({color:0xffffff,map:ftex,roughness:0.92}));
      slab.position.y=0;slab.receiveShadow=true;world.add(slab);
      const curb=new THREE.Mesh(new THREE.BoxGeometry(W+0.56,0.14,H+0.56),mat3('#4f534c',0.9));
      curb.position.y=-0.06;curb.receiveShadow=true;world.add(curb);
      /* Bolardos y jardineras decorativas fuera del tablero 12×12 para enmarcar el diorama */
      [[-6.65,-6.65],[6.65,-6.65],[-6.65,6.65],[6.65,6.65]].forEach(cp=>{
        const bollard=new THREE.Mesh(new THREE.CylinderGeometry(0.14,0.16,0.45,10),mat3('#3a3e42',0.7));
        bollard.position.set(cp[0],0.12,cp[1]);bollard.castShadow=true;world.add(bollard);
        const cap=new THREE.Mesh(new THREE.CylinderGeometry(0.15,0.15,0.06,10),mat3('#f2b234',0.5));
        cap.position.set(cp[0],0.36,cp[1]);world.add(cap);
      });
      done=true;
    }catch(e){}
    if(!done){
      for(let y=0;y<H;y++)for(let x=0;x<W;x++){
        const tile=box3(0.97,0.09,0.97,tileCol(x,y),w2cx(x),0,w2cx(y),0.95);
        tile.castShadow=false;world.add(tile);
      }
    }
  } else {
    const plinth=box3(Math.max(16,W+2),0.12,Math.max(16,H+2),'#1f2428',0,-0.16,0,0.95);plinth.castShadow=false;world.add(plinth);
    const geoMesh=buildSkirmishGeo3(G.map.theme);
    if(geoMesh)world.add(geoMesh);
  }
  if(DEBUG_GRID){
    const dbg=new THREE.Group();dbg.name='debugGrid3D';
    const fine=new THREE.LineBasicMaterial({color:0x35e0c8,transparent:true,opacity:0.72,depthTest:false});
    const hard=new THREE.LineBasicMaterial({color:0xff3b5c,transparent:true,opacity:0.95,depthTest:false});
    const segment=(a,b,mat)=>{
      const g=new THREE.BufferGeometry().setFromPoints([new THREE.Vector3(a[0],a[1],a[2]),new THREE.Vector3(b[0],b[1],b[2])]);
      const line=new THREE.Line(g,mat);line.renderOrder=999;dbg.add(line);
    };
    for(let y=0;y<H;y++)for(let x=0;x<W;x++){
      const cx=w2cx(x),cz=w2cx(y),yy=tileWorldY(x,y)+0.14,h=0.5;
      segment([cx-h,yy,cz-h],[cx+h,yy,cz-h],fine);
      segment([cx+h,yy,cz-h],[cx+h,yy,cz+h],fine);
      segment([cx+h,yy,cz+h],[cx-h,yy,cz+h],fine);
      segment([cx-h,yy,cz+h],[cx-h,yy,cz-h],fine);
      [[x+1,y,cx+h,cz-h,cx+h,cz+h],[x-1,y,cx-h,cz-h,cx-h,cz+h],
       [x,y+1,cx-h,cz+h,cx+h,cz+h],[x,y-1,cx-h,cz-h,cx+h,cz-h]].forEach(e=>{
        if(nativeSolidEdge(x,y,e[0],e[1]))segment([e[2],yy+0.01,e[3]],[e[4],yy+0.01,e[5]],hard);
      });
    }
    world.add(dbg);T3.debugGrid=dbg;
  }
  /* props decorativos del tema: solo en tableros sin geometria IPA */
  if(!geoShown){try{buildThemedProps3(world,G.map.theme);}catch(e){}}
  /* zonas de despliegue */
  const zoneDisc=(list,col)=>{list.forEach(s=>{
    const p=new THREE.Mesh(new THREE.PlaneGeometry(0.94,0.94),new THREE.MeshBasicMaterial({color:col,transparent:true,opacity:0.13,depthWrite:false}));
    p.rotation.x=-Math.PI/2;p.position.set(w2cx(s.x),0.055,w2cx(s.y));world.add(p);});};
  zoneDisc(spawnsFor('A'),0x39c2d7);zoneDisc(spawnsFor('B'),0xff7a45);
  /* baliza: zona ámbar que pulsa */
  const beacon=new THREE.Mesh(new THREE.PlaneGeometry(1.94,1.94),new THREE.MeshBasicMaterial({color:0xf2b234,transparent:true,opacity:0.16,depthWrite:false}));
  const bx=BEACON[0].x+0.5,by=BEACON[0].y+0.5;
  beacon.rotation.x=-Math.PI/2;beacon.position.set(w2cx(bx),0.06,w2cx(by));world.add(beacon);T3.beacon=beacon;
  /* Anillos de Dominación en 3D */
  T3.domRings=[];
  if(effMode(G)==='dominacion'){domZones().forEach(z=>{const anchor=z.id==='centro'?{x:BEACON[0].x+0.5,y:BEACON[0].y+0.5}:z.tiles[0];const ring=new THREE.Mesh(new THREE.TorusGeometry(z.id==='centro'?1.15:0.44,0.03,8,40),new THREE.MeshBasicMaterial({color:0xf4f1e6}));ring.rotation.x=Math.PI/2;ring.position.set(w2cx(anchor.x),0.07,w2cx(anchor.y));world.add(ring);T3.domRings.push({zone:z,ring:ring});});}
  [[0,-1.0,2.06,0.07],[0,1.0,2.06,0.07],[-1.0,0,0.07,2.06],[1.0,0,0.07,2.06]].forEach(e=>{
    const bar=new THREE.Mesh(new THREE.BoxGeometry(e[2],0.035,e[3]),new THREE.MeshBasicMaterial({color:0xf2b234}));
    bar.position.set(w2cx(bx)+e[0],0.03,w2cx(by)+e[1]);world.add(bar);
  });
  /* Zona de extracción de Escolta en 3D */
  T3.extMats=null;T3.droneMesh=null;
  if(effMode(G)==='escolta'){T3.extMats=[];escortExt().forEach(t2=>{const p=new THREE.Mesh(new THREE.PlaneGeometry(0.94,0.94),new THREE.MeshBasicMaterial({color:0x57c46a,transparent:true,opacity:0.2,depthWrite:false}));p.rotation.x=-Math.PI/2;p.position.set(w2cx(t2.x),0.058,w2cx(t2.y));world.add(p);T3.extMats.push(p.material);});}
  /* plataforma y cañón de la torreta central */
  const plat=new THREE.Group();plat.position.set(w2cx(TURRET_POS.x),0,w2cx(TURRET_POS.y));world.add(plat);
  const platSh=makeContactShadow3(0.48,0.048);if(platSh)plat.add(platSh);
  const platBase=new THREE.Mesh(new THREE.CylinderGeometry(0.4,0.44,0.14,24),mat3('#9aa1a7',0.6));
  platBase.position.y=0.1;platBase.castShadow=true;platBase.receiveShadow=true;plat.add(platBase);
  const cannon=new THREE.Group();cannon.position.y=0.2;plat.add(cannon);
  cannon.add(box3(0.42,0.06,0.07,'#2c2f33',0.18,0,0,0.5));
  cannon.add(box3(0.1,0.09,0.09,'#454a4f',0,0.02,0,0.5));
  T3.cannon=cannon;T3.cannonCore=cannon.children[1];
  /* obstáculos, barriles y botiquines con texturas procedurales propias y sombra de contacto */
  T3.obMeshes=[];T3.barrelMeshes=[];T3.medkitMeshes=[];
  const wallGeo=new THREE.BoxGeometry(0.86,0.62,0.86),wallMat=texMat3('wall',null,0.85);
  const crateGeo=new THREE.BoxGeometry(0.7,0.44,0.7),crateMat=texMat3('crate',null,0.9);
  const shelfGeo=new THREE.BoxGeometry(0.8,0.56,0.8);
  const barrelGeo=new THREE.CylinderGeometry(0.26,0.26,0.62,18),barrelMat=texMat3('barrel',null,0.55);
  const medGeo=new THREE.BoxGeometry(0.55,0.22,0.4),medMat=texMat3('medkit',null,0.6);
  G.map.obstacles.forEach(o=>{
    let m=new THREE.Group();
    const ox=w2cx(o.x),oz=w2cx(o.y);
    const sh=makeContactShadow3(0.5,0.05);if(sh){sh.position.set(ox,0.05,oz);m.add(sh);}
    if(o.type==='wall'){
      const body=new THREE.Mesh(wallGeo,wallMat);body.position.set(ox,0.34,oz);body.castShadow=true;body.receiveShadow=true;m.add(body);
      m.add(box3(0.9,0.1,0.9,'#585e64',ox,0.07,oz,0.85));
      m.add(box3(0.9,0.06,0.9,'#b4bac0',ox,0.68,oz,0.75));
    } else if(o.type==='shelf'){
      const pal=[['#d9b13a','#a9862a'],['#c9762f','#9c5a24'],['#3f8b93','#2e6a71']][Math.floor(hash2(o.x*11,o.y*5)*3)];
      const body=new THREE.Mesh(shelfGeo,texMat3('shelf',pal[0],0.8));body.position.set(ox,0.3,oz);body.castShadow=true;body.receiveShadow=true;m.add(body);
      m.add(box3(0.84,0.05,0.84,pal[1],ox,0.6,oz,0.8));
      m.add(box3(0.04,0.36,0.3,pal[1],ox+0.41,0.3,oz,0.7));
    } else {
      const body=new THREE.Mesh(crateGeo,crateMat);body.position.set(ox,0.26,oz);body.castShadow=true;body.receiveShadow=true;m.add(body);
      m.add(box3(0.74,0.05,0.74,'#b88b50',ox,0.5,oz,0.88));
    }
    world.add(m);T3.obMeshes.push({o:o,mesh:m});
  });
  G.map.barrels.forEach(b=>{
    const grp=new THREE.Group();grp.position.set(w2cx(b.x),0,w2cx(b.y));
    const sh=makeContactShadow3(0.36,0.05);if(sh)grp.add(sh);
    const cyl=new THREE.Mesh(barrelGeo,barrelMat);
    cyl.position.y=0.35;cyl.castShadow=true;cyl.receiveShadow=true;grp.add(cyl);
    const ring1=new THREE.Mesh(new THREE.TorusGeometry(0.265,0.016,8,24),mat3('#7c1d18',0.5));
    ring1.rotation.x=Math.PI/2;ring1.position.y=0.22;grp.add(ring1);
    const ring2=ring1.clone();ring2.position.y=0.5;grp.add(ring2);
    const lid=new THREE.Mesh(new THREE.CylinderGeometry(0.24,0.24,0.02,16),mat3('#e87266',0.45));
    lid.position.y=0.66;grp.add(lid);
    world.add(grp);T3.barrelMeshes.push({b:b,mesh:grp});
  });
  G.map.medkits.forEach(mk=>{
    const grp=new THREE.Group();grp.position.set(w2cx(mk.x),0,w2cx(mk.y));
    const sh=makeContactShadow3(0.34,0.05);if(sh)grp.add(sh);
    const bx=new THREE.Mesh(medGeo,medMat);bx.position.y=0.16;bx.castShadow=true;bx.receiveShadow=true;grp.add(bx);
    grp.add(box3(0.28,0.04,0.08,'#d92c2c',0,0.29,0,0.5));
    grp.add(box3(0.08,0.04,0.24,'#d92c2c',0,0.29,0,0.5));
    world.add(grp);T3.medkitMeshes.push({m:mk,mesh:grp});
  });
  /* polvo en suspensión */
  const dustGeo=new THREE.BufferGeometry();
  const dp=[];
  for(let i=0;i<70;i++)dp.push((Math.random()-0.5)*12,0.4+Math.random()*2.6,(Math.random()-0.5)*12);
  dustGeo.setAttribute('position',new THREE.Float32BufferAttribute(dp,3));
  const dust=new THREE.Points(dustGeo,new THREE.PointsMaterial({color:0xfff2cf,size:0.045,transparent:true,opacity:0.5}));
  world.add(dust);T3.dust=dust;
  /* soldados */
  G.units.forEach(un=>{
    const mesh=REAL.ready?makeRealSoldier3(un):makeSoldier3(un);
    mesh.position.set(w2cx(un.x),0.05+tileWorldY(un.x,un.y),w2cx(un.y));
    T3.unitsGroup.add(mesh);T3.units.set(un.id,mesh);
  });
  /* el dron de Escolta */
  if(G.drone){const dm=makeDrone3();dm.position.set(w2cx(G.drone.x),0.42+tileWorldY(G.drone.x,G.drone.y),w2cx(G.drone.y));T3.unitsGroup.add(dm);T3.droneMesh=dm;}
  /* anillo de casilla al pasar el cursor */
  const hover=new THREE.Mesh(new THREE.TorusGeometry(0.42,0.02,8,36),new THREE.MeshBasicMaterial({color:0xffffff}));
  hover.rotation.x=Math.PI/2;hover.position.y=0.06;hover.visible=false;world.add(hover);T3.hoverRing=hover;
}

export function rebuildDyn3(){
  if(!T3||!G)return;
  while(T3.dynGroup.children.length)T3.dynGroup.remove(T3.dynGroup.children[0]);
  (G.lootBoxes||[]).forEach(b=>{
    const grp=new THREE.Group();grp.position.set(w2cx(b.x),0,w2cx(b.y));grp.userData.loot=true;
    const sh=makeContactShadow3(0.36,0.05);if(sh)grp.add(sh);
    const lc={salud:['#e8e6da','#d92c2c'],municion:['#4f7a3a','#8fbf6a'],analgesico:['#4a6f92','#8fb4d8'],espiritu:['#c98f12','#f2b234']}[b.kind]||['#c98f12','#f2b234'];
    grp.add(box3(0.6,0.42,0.6,lc[0],0,0.3,0,0.6));
    grp.add(box3(0.64,0.12,0.64,lc[1],0,0.55,0,0.5));
    T3.dynGroup.add(grp);
  });
  G.deployed.forEach(t=>{
    if(!t.alive)return;
    const grp=new THREE.Group();grp.position.set(w2cx(t.x),0,w2cx(t.y));
    const sh=makeContactShadow3(0.38,0.048);if(sh)grp.add(sh);
    const disc=new THREE.Mesh(new THREE.CylinderGeometry(0.3,0.34,0.16,20),mat3('#79828a',0.6));
    disc.position.y=0.12;disc.castShadow=true;grp.add(disc);
    grp.add(box3(0.44,0.06,0.07,'#23262a',0.18,0.26,0,0.5));
    const ring=new THREE.Mesh(new THREE.TorusGeometry(0.4,0.015,8,32),new THREE.MeshBasicMaterial({color:t.team==='A'?0x39c2d7:0xff7a45}));
    ring.rotation.x=Math.PI/2;ring.position.y=0.04;grp.add(ring);
    grp.rotation.y=t.team==='A'?0:Math.PI;
    T3.dynGroup.add(grp);
  });
  if(G.map.turret.owner&&T3.cannonCore)T3.cannonCore.material=mat3(G.map.turret.owner==='A'?'#387EC9':'#C95338',0.5);
  (G.smoke||[]).forEach(sm=>{
    const grp=new THREE.Group();grp.position.set(w2cx(sm.x),0,w2cx(sm.y));
    const cloud=new THREE.Mesh(new THREE.SphereGeometry(0.52,10,8),new THREE.MeshBasicMaterial({color:0xd6dbe0,transparent:true,opacity:sm.left<=1?0.42:0.55,depthWrite:false}));
    cloud.scale.set(1,0.62,1);cloud.position.y=0.42;grp.add(cloud);
    const puff=new THREE.Mesh(new THREE.SphereGeometry(0.34,9,7),new THREE.MeshBasicMaterial({color:0xe8ecef,transparent:true,opacity:sm.left<=1?0.36:0.48,depthWrite:false}));
    puff.position.set(0.18,0.62,-0.1);grp.add(puff);
    T3.dynGroup.add(grp);
  });
  (G.mines||[]).forEach(mn=>{
    if(mn.team!==viewerTeam())return;
    const grp=new THREE.Group();grp.position.set(w2cx(mn.x),0,w2cx(mn.y));
    const body=new THREE.Mesh(new THREE.BoxGeometry(0.34,0.1,0.2),mat3('#3d4436',0.7));body.position.y=0.06;body.castShadow=true;grp.add(body);
    const led=new THREE.Mesh(new THREE.SphereGeometry(0.035,8,6),new THREE.MeshBasicMaterial({color:0xff4747}));led.position.set(0,0.13,0);grp.add(led);
    const ring=new THREE.Mesh(new THREE.TorusGeometry(0.3,0.014,8,28),new THREE.MeshBasicMaterial({color:mn.team==='A'?0x39c2d7:0xff7a45}));ring.rotation.x=Math.PI/2;ring.position.y=0.03;grp.add(ring);
    T3.dynGroup.add(grp);
  });
  G.units.forEach(un=>{
    if(!un.alive||!un.stunned)return;
    const grp=new THREE.Group();grp.position.set(w2cx(un.x),0,w2cx(un.y));
    const star=new THREE.Mesh(new THREE.OctahedronGeometry(0.13),new THREE.MeshBasicMaterial({color:0xffd23e}));star.position.y=1.78;grp.add(star);
    const ring=new THREE.Mesh(new THREE.TorusGeometry(0.42,0.016,8,28),new THREE.MeshBasicMaterial({color:0xffd23e}));ring.rotation.x=Math.PI/2;ring.position.y=0.05;grp.add(ring);
    T3.dynGroup.add(grp);
  });
}

export function rebuildHighlights3(){
  if(!T3||!G)return;
  while(T3.hlGroup.children.length)T3.hlGroup.remove(T3.hlGroup.children[0]);
  const u=G.selected;
  if(!u||!u.alive||u.team!==G.turn||G.aiBusy||G.over)return;
  if(!T3.hlTileGeo)T3.hlTileGeo=new THREE.PlaneGeometry(0.88,0.88);
  if(!T3.hlRingGeo)T3.hlRingGeo=new THREE.RingGeometry(0.33,0.45,24);
  if(!T3.hlMatCache)T3.hlMatCache={};
  const getMat=(key,col,op,mask)=>{const k=key+':'+col+':'+op+(mask?':'+mask:'');if(!T3.hlMatCache[k]){const mm={color:col,transparent:true,opacity:op,depthWrite:false,side:THREE.DoubleSide};if(mask&&T3.tileMasks&&T3.tileMasks[mask])mm.alphaMap=T3.tileMasks[mask];T3.hlMatCache[k]=new THREE.MeshBasicMaterial(mm);}return T3.hlMatCache[k];};
  const addTile=(x,y,key,col,op,mask)=>{
    const p=new THREE.Mesh(T3.hlTileGeo,getMat('t:'+key+(mask?':'+mask:''),col,op,mask));
    p.rotation.x=-Math.PI/2;p.position.set(w2cx(x),0.064,w2cx(y));T3.hlGroup.add(p);
  };
  const addRing=(x,y,key,col,op)=>{
    const p=new THREE.Mesh(T3.hlRingGeo,getMat('r:'+key,col,op));
    p.rotation.x=-Math.PI/2;p.position.set(w2cx(x),0.068,w2cx(y));T3.hlGroup.add(p);
  };
  if(G.actionMode==='move'){
    reachable(u,u.energy).forEach((d,k)=>{const parts=k.split(',');addTile(+parts[0],+parts[1],'move',0x2690ff,0.34,'placement');});
  } else if(G.actionMode==='shoot'||G.actionMode==='pistol'){
    const w=G.actionMode==='pistol'?WEAPONS[PISTOL]:WEAPONS[u.weapon];
    G.units.forEach(foe=>{
      if(!foe.alive||foe.team===u.team)return;
      const p=hitChance(u,foe,w);
      if(p>0){addTile(foe.x,foe.y,'tgtBg',0xe5484d,0.22,'attack');addRing(foe.x,foe.y,'tgt',0xff3d3d,0.92);}
      else if(cheb(u,foe)<=w.rng)addRing(foe.x,foe.y,'tgtDim',0x994848,0.45);
    });
    if(effMode(G)==='escolta'&&u.team==='B'&&G.drone&&G.drone.alive){
      const dp=hitChance(u,G.drone,w);
      if(dp>0)addRing(G.drone.x,G.drone.y,'tgt',0xff3d3d,0.92);
    }
    G.map.barrels.forEach(b=>{if(b.alive&&cheb(u,b)<=w.rng&&hasLOS(u,b)&&!smokeBlocksLOS(u,b))addRing(b.x,b.y,'prop',0xf2b234,0.85);});
    G.map.obstacles.forEach(o=>{if(o.type==='crate'&&cheb(u,o)<=w.rng&&hasLOS(u,o)&&!smokeBlocksLOS(u,o))addRing(o.x,o.y,'prop',0xf2b234,0.75);});
  } else if(G.actionMode==='grenade'){
    for(let y=0;y<H;y++)for(let x=0;x<W;x++)if(cheb(u,{x:x,y:y})<=3&&cheb(u,{x:x,y:y})>0)addTile(x,y,'gren',0xe5484d,0.25,'aoe');
  } else if(G.actionMode==='smoke'){
    for(let y=0;y<H;y++)for(let x=0;x<W;x++)if(cheb(u,{x:x,y:y})<=4&&cheb(u,{x:x,y:y})>0)addTile(x,y,'smoke',0xd6dbe0,0.22,'aoe');
  } else if(G.actionMode==='flash'){
    for(let y=0;y<H;y++)for(let x=0;x<W;x++)if(cheb(u,{x:x,y:y})<=4)addTile(x,y,'flash',0xffd23e,0.22,'aoe');
  } else if(G.actionMode==='mine'){
    [[1,0],[-1,0],[0,1],[0,-1]].forEach(dd=>{const mx=u.x+dd[0],my=u.y+dd[1];if(mx>=0&&my>=0&&mx<W&&my<H&&!blocked(mx,my)&&!mineAt(mx,my))addTile(mx,my,'mine',0xe5484d,0.32,'placement');});
  } else if(G.actionMode==='deploy'){
    [[1,0],[-1,0],[0,1],[0,-1]].forEach(dd=>{const mx=u.x+dd[0],my=u.y+dd[1];if(mx>=0&&my>=0&&mx<W&&my<H&&!blocked(mx,my))addTile(mx,my,'deploy',0x57c46a,0.36,'placement');});
  } else if(G.actionMode==='drone'&&G.drone&&G.drone.alive){
    addRing(G.drone.x,G.drone.y,'heal',0x57c46a,0.9);
    [[1,0],[-1,0],[0,1],[0,-1]].forEach(dd=>{const mx=G.drone.x+dd[0],my=G.drone.y+dd[1];if(mx>=0&&my>=0&&mx<W&&my<H&&!blocked(mx,my))addTile(mx,my,'deploy',0x57c46a,0.36,'placement');});
  } else if(G.actionMode==='special'){
    if(u.role==='Médico'){
      G.units.forEach(a=>{if(a.team===u.team&&dist(u,a)<=1&&((!a.alive&&u.revives>0)||(a.alive&&a.hp<a.maxHp&&u.heals>0))){addTile(a.x,a.y,'deploy',0x57c46a,0.34);addRing(a.x,a.y,'heal',0x57c46a,0.92);}});
      if(G.drone&&G.drone.alive&&u.team==='A'&&dist(u,G.drone)<=1&&G.drone.hp<G.drone.maxHp&&u.heals>0)addRing(G.drone.x,G.drone.y,'heal',0x57c46a,0.92);
    } else if(u.role==='Capitán'){
      G.units.forEach(a=>{if(a.alive&&a.team===u.team&&a!==u){addTile(a.x,a.y,'cmd',0xf2b234,0.28);addRing(a.x,a.y,'prop',0xf2b234,0.9);}});
    } else if(u.role==='Francotirador'){
      const w=WEAPONS[u.weapon];
      G.units.forEach(foe=>{if(foe.alive&&foe.team!==u.team&&hitChance(u,foe,w)>0)addRing(foe.x,foe.y,'tgt',0xff3d3d,0.95);});
    }
  }
}
