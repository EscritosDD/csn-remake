import { mat3, box3, texMat3 } from './scene.js';

export function buildThemedProps3(world,theme){
  if(!world||typeof THREE==='undefined')return;
  let seed=(theme||'x').split('').reduce((a,c)=>a+c.charCodeAt(0),11);
  const rand=()=>{seed=(seed*1103515245+12345)&0x7fffffff;return seed/0x7fffffff;};
  const spots=[];
  for(let a=0;a<30;a++){const ang=a/30*Math.PI*2+rand()*0.1;const rad=7.6+rand()*0.9;spots.push({x:Math.cos(ang)*rad,z:Math.sin(ang)*rad});}
  const take=()=>spots.splice(Math.floor(rand()*spots.length),1)[0];
  const boxp=(w,h,d,col,tex)=>{const sp=take();if(!sp)return null;const S=0.74;w*=S;h*=S;d*=S;let m;
    if(tex){m=new THREE.Mesh(new THREE.BoxGeometry(w,h,d),texMat3(tex,col));m.position.set(sp.x,h/2+0.02,sp.z);m.castShadow=true;m.receiveShadow=true;}
    else m=box3(w,h,d,col,sp.x,h/2+0.02,sp.z,0.85);
    m.rotation.y=rand()*Math.PI;world.add(m);return m;};
  const cylp=(r,h,col)=>{const sp=take();if(!sp)return null;r*=0.8;h*=0.8;const m=new THREE.Mesh(new THREE.CylinderGeometry(r,r,h,12),mat3(col,0.8));m.position.set(sp.x,h/2+0.02,sp.z);m.castShadow=true;world.add(m);return m;};
  const lamp=()=>{const sp=take();if(!sp)return null;const g=new THREE.Group();g.position.set(sp.x,0,sp.z);
    const post=new THREE.Mesh(new THREE.CylinderGeometry(0.05,0.07,2.3,8),mat3('#3b4046',0.6));post.position.y=1.15;post.castShadow=true;g.add(post);
    const head=new THREE.Mesh(new THREE.BoxGeometry(0.3,0.08,0.3),mat3('#f2b234',0.5));head.position.y=2.34;g.add(head);
    world.add(g);return g;};
  if(theme==='warehouse'){
    const cols=['#3f6f8f','#a4432f','#c9a227','#3f7a52'];
    for(let i=0;i<4;i++)boxp(2.2,1.1,1.0,cols[i%4],null);
    for(let i=0;i<3;i++)boxp(0.7,0.12,0.9,'#8d6436','crate');
    /* Carretilla elevadora del almacen: cuerpo, mastil y horquillas. */
    const spF=take();
    if(spF){const g=new THREE.Group();g.position.set(spF.x,0,spF.z);
      const body=new THREE.Mesh(new THREE.BoxGeometry(0.9,0.5,1.4),mat3('#d9a521',0.7));body.position.y=0.45;body.castShadow=true;g.add(body);
      const mast=new THREE.Mesh(new THREE.BoxGeometry(0.12,1.5,0.12),mat3('#3b4046',0.6));mast.position.set(0.35,1.0,0.55);g.add(mast);
      const fork=new THREE.Mesh(new THREE.BoxGeometry(0.7,0.06,0.12),mat3('#3b4046',0.5));fork.position.set(0.7,0.3,0.55);g.add(fork);
      g.rotation.y=rand()*Math.PI*2;world.add(g);}
  }
  if(theme==='yard'){
    /* Caseta de obra con tejado y contenedor volcado. */
    const spY=take();
    if(spY){const g=new THREE.Group();g.position.set(spY.x,0,spY.z);
      const hut=new THREE.Mesh(new THREE.BoxGeometry(1.4,1.0,1.1),mat3('#e6e2d6',0.85));hut.position.y=0.5;hut.castShadow=true;g.add(hut);
      const roof=new THREE.Mesh(new THREE.BoxGeometry(1.6,0.08,1.3),mat3('#3f6f8f',0.7));roof.position.y=1.04;g.add(roof);
      const door=new THREE.Mesh(new THREE.BoxGeometry(0.06,0.7,0.4),mat3('#3b4046',0.7));door.position.set(0.71,0.36,0);g.add(door);
      g.rotation.y=rand()*Math.PI*2;world.add(g);}
    const spC=take();
    if(spC){const m=new THREE.Mesh(new THREE.BoxGeometry(2.2,0.9,1.1),mat3('#a4432f',0.8));m.position.set(spC.x,0.45,spC.z);m.rotation.z=0.42;m.rotation.y=rand()*Math.PI;m.castShadow=true;world.add(m);}
  }
  if(theme==='depot'){
    /* Montacargas: mastil alto y plataforma con palet. */
    const spMk=take();
    if(spMk){const g=new THREE.Group();g.position.set(spMk.x,0,spMk.z);
      const mast=new THREE.Mesh(new THREE.BoxGeometry(0.14,2.4,0.14),mat3('#3b4046',0.6));mast.position.y=1.2;mast.castShadow=true;g.add(mast);
      const plat=new THREE.Mesh(new THREE.BoxGeometry(1.0,0.1,0.5),mat3('#8a7a3a',0.75));plat.position.y=1.2;g.add(plat);
      const pal=new THREE.Mesh(new THREE.BoxGeometry(0.9,0.22,0.45),mat3('#8d6436',0.85));pal.position.y=1.36;g.add(pal);
      g.rotation.y=rand()*Math.PI*2;world.add(g);}
  }
  if(theme==='terminal'||theme==='depot'||theme==='yard'||theme==='astillero'){
    const cols=['#3f6f8f','#a4432f','#c9a227','#3f7a52'];
    for(let i=0;i<5;i++)boxp(2.2,1.1,1.0,cols[i%4],null);
    for(let i=0;i<3;i++)boxp(0.7,0.12,0.9,'#8d6436','crate');
    if(theme==='astillero'){
    /* Pila de contenedores apilados en dos alturas. */
    const spP=take();
    if(spP){const g=new THREE.Group();g.position.set(spP.x,0,spP.z);
      const a=new THREE.Mesh(new THREE.BoxGeometry(2.2,1.0,1.1),mat3('#3f6f8f',0.8));a.position.y=0.5;a.castShadow=true;g.add(a);
      const b=new THREE.Mesh(new THREE.BoxGeometry(2.2,1.0,1.1),mat3('#a4432f',0.8));b.position.y=1.5;b.rotation.y=0.12;g.add(b);
      g.rotation.y=rand()*Math.PI*2;world.add(g);}
    for(let i=0;i<2;i++){const sp=take();if(!sp)continue;const g=new THREE.Group();g.position.set(sp.x,0,sp.z);
      const a=new THREE.Mesh(new THREE.BoxGeometry(0.22,3.2,0.22),mat3('#c9a227',0.6));a.position.set(-0.45,1.6,0);a.castShadow=true;g.add(a);
      const b=new THREE.Mesh(new THREE.BoxGeometry(0.22,3.2,0.22),mat3('#c9a227',0.6));b.position.set(0.45,1.6,0);b.castShadow=true;g.add(b);
      const c=new THREE.Mesh(new THREE.BoxGeometry(1.5,0.18,0.18),mat3('#8a6f1c',0.6));c.position.set(0,3.1,0);g.add(c);world.add(g);}}
    for(let i=0;i<2;i++)lamp();
  } else if(theme==='platform'||theme==='rotonda'||theme==='cruce'){
    if(theme==='cruce'){
      /* Contenedor de obra con valla. */
      const spCf=take();
      if(spCf){const g=new THREE.Group();g.position.set(spCf.x,0,spCf.z);
        const box=new THREE.Mesh(new THREE.BoxGeometry(1.8,1.1,1.0),mat3('#c9a227',0.8));box.position.y=0.55;box.castShadow=true;g.add(box);
        const fence=new THREE.Mesh(new THREE.BoxGeometry(1.9,0.12,0.08),mat3('#e8e2d2',0.7));fence.position.set(0,1.15,0.55);g.add(fence);
        const stripe=new THREE.Mesh(new THREE.BoxGeometry(1.8,0.14,0.02),mat3('#a4432f',0.6));stripe.position.set(0,0.75,0.51);g.add(stripe);
        g.rotation.y=rand()*Math.PI*2;world.add(g);}
    }
    if(theme==='rotonda'||theme==='skirmish03'||theme==='skirmish04'){
      /* Cabina telefonica roja de Londres. */
      const spT=take();
      if(spT){const g=new THREE.Group();g.position.set(spT.x,0,spT.z);
        const body=new THREE.Mesh(new THREE.BoxGeometry(0.7,1.7,0.7),mat3('#b8202a',0.75));body.position.y=0.85;body.castShadow=true;g.add(body);
        const win=new THREE.Mesh(new THREE.BoxGeometry(0.5,1.0,0.06),mat3('#cfe6f2',0.3));win.position.set(0,1.05,0.36);g.add(win);
        const top=new THREE.Mesh(new THREE.BoxGeometry(0.8,0.12,0.8),mat3('#8f1a22',0.7));top.position.y=1.76;g.add(top);
        const lamp=new THREE.Mesh(new THREE.CylinderGeometry(0.16,0.16,0.1,8),mat3('#e8c84e',0.5));lamp.position.y=1.88;g.add(lamp);
        g.rotation.y=rand()*Math.PI*2;world.add(g);}
    }
    if(theme==='platform'){
      /* Banco de anden junto a la maquina. */
      const spBn=take();
      if(spBn){const g=new THREE.Group();g.position.set(spBn.x,0,spBn.z);
        const seat=new THREE.Mesh(new THREE.BoxGeometry(1.3,0.08,0.4),mat3('#8d6436',0.85));seat.position.y=0.45;seat.castShadow=true;g.add(seat);
        const back=new THREE.Mesh(new THREE.BoxGeometry(1.3,0.4,0.07),mat3('#8d6436',0.85));back.position.set(0,0.68,-0.18);g.add(back);
        [-0.5,0.5].forEach(dx=>{const leg=new THREE.Mesh(new THREE.BoxGeometry(0.07,0.45,0.35),mat3('#3b4046',0.6));leg.position.set(dx,0.22,0);g.add(leg);});
        g.rotation.y=rand()*Math.PI*2;world.add(g);}
      /* Maquina expendedora del anden: cuerpo, cristal y botones. */
      const spV=take();
      if(spV){const g=new THREE.Group();g.position.set(spV.x,0,spV.z);
        const body=new THREE.Mesh(new THREE.BoxGeometry(0.8,1.6,0.55),mat3('#a4432f',0.7));body.position.y=0.8;body.castShadow=true;g.add(body);
        const glass=new THREE.Mesh(new THREE.BoxGeometry(0.5,0.9,0.06),mat3('#8fd8ff',0.25));glass.position.set(0,1.1,0.3);g.add(glass);
        const btn=new THREE.Mesh(new THREE.BoxGeometry(0.3,0.16,0.05),mat3('#e8c84e',0.5));btn.position.set(0,0.55,0.3);g.add(btn);
        g.rotation.y=rand()*Math.PI*2;world.add(g);}
    }
    if(theme==='cruce'){
      /* Semaforo de calle: poste y caja con tres luces. */
      const spS=take();
      if(spS){const g=new THREE.Group();g.position.set(spS.x,0,spS.z);
        const post=new THREE.Mesh(new THREE.BoxGeometry(0.1,2.2,0.1),mat3('#2f343a',0.6));post.position.y=1.1;post.castShadow=true;g.add(post);
        const box=new THREE.Mesh(new THREE.BoxGeometry(0.26,0.62,0.24),mat3('#1d2126',0.6));box.position.y=2.1;g.add(box);
        [['#d94040',2.28],['#e8c84e',2.10],['#4fbf6a',1.92]].forEach(([c,y])=>{const l=new THREE.Mesh(new THREE.CylinderGeometry(0.055,0.055,0.06,10),mat3(c,0.4));l.rotation.x=Math.PI/2;l.position.set(0,y,0.13);g.add(l);});
        g.rotation.y=rand()*Math.PI*2;world.add(g);}
    }
    for(let i=0;i<4;i++){const sp=take();if(!sp)continue;const bench=box3(1.1,0.16,0.34,'#7d5a34',sp.x,0.42,sp.z,0.9);const back=box3(1.1,0.3,0.08,'#8d6436',sp.x,0.62,sp.z+0.13,0.9);world.add(bench);world.add(back);}
    for(let i=0;i<3;i++)lamp();
    for(let i=0;i<2;i++)cylp(0.3,0.5,'#5c5346');
  } else if(theme==='market'||theme==='plaza'){
    if(theme==='market'){
      const spBq=take();
      if(spBq){const g=new THREE.Group();g.position.set(spBq.x,0,spBq.z);
        const seat=new THREE.Mesh(new THREE.BoxGeometry(1.2,0.08,0.36),mat3('#7d5a34',0.85));seat.position.y=0.44;seat.castShadow=true;g.add(seat);
        [-0.45,0.45].forEach(dx=>{const leg=new THREE.Mesh(new THREE.BoxGeometry(0.07,0.44,0.3),mat3('#3b4046',0.6));leg.position.set(dx,0.22,0);g.add(leg);});
        g.rotation.y=rand()*Math.PI*2;world.add(g);}
    }
    if(theme==='market'){
      /* Puesto de fruta: mesa, cajas de colores, toldo y postes. */
      const spM=take();
      if(spM){const g=new THREE.Group();g.position.set(spM.x,0,spM.z);
        const table=new THREE.Mesh(new THREE.BoxGeometry(1.6,0.5,0.9),mat3('#8d6436',0.8));table.position.y=0.25;table.castShadow=true;g.add(table);
        ['#c9a227','#a4432f','#3f7a52','#3f6f8f'].forEach((c,i)=>{const b=new THREE.Mesh(new THREE.BoxGeometry(0.3,0.16,0.34),mat3(c,0.7));b.position.set(-0.55+i*0.36,0.58,0);g.add(b);});
        const awn=new THREE.Mesh(new THREE.BoxGeometry(1.8,0.06,1.1),mat3('#e6e2d6',0.7));awn.position.y=1.25;awn.rotation.z=0.08;g.add(awn);
        for(let i=0;i<3;i++){const post=new THREE.Mesh(new THREE.BoxGeometry(0.06,1.2,0.06),mat3('#3b4046',0.6));post.position.set(-0.75+i*0.75,0.6,0.45);g.add(post);}
        g.rotation.y=rand()*Math.PI*2;world.add(g);}
    }
    for(let i=0;i<3;i++){const sp=take();if(!sp)continue;const g=new THREE.Group();g.position.set(sp.x,0,sp.z);
      g.add(box3(1.2,0.5,0.6,'#8d6436',0,0.27,0,0.9));
      const canopy=box3(1.4,0.06,0.8,i%2?'#c9503a':'#3f7a8f',0,1.55,0,0.8);canopy.rotation.z=0.06;g.add(canopy);
      [[-0.6,-0.3],[0.6,-0.3],[-0.6,0.3],[0.6,0.3]].forEach(p=>{const post=new THREE.Mesh(new THREE.CylinderGeometry(0.03,0.03,1.5,6),mat3('#5c5346',0.7));post.position.set(p[0],0.75,p[1]);g.add(post);});
      world.add(g);}
    for(let i=0;i<3;i++)cylp(0.28,0.44,'#6b7a5a');
    for(let i=0;i<2;i++)lamp();
  } else if(theme==='dock'){
    for(let i=0;i<4;i++)cylp(0.12,0.55,'#4a4f55');
    for(let i=0;i<3;i++)boxp(0.8,0.7,0.8,'#8d6436','crate');
    for(let i=0;i<2;i++)lamp();
  } else { /* skirmish03/04 y demas calles: farolas, papeleras y una parada */
    for(let i=0;i<3;i++)lamp();
    for(let i=0;i<3;i++)cylp(0.14,0.5,'#3f444a');
    boxp(1.6,0.5,0.5,'#5c5346','wall');
  }
  /* Remates por mapa para que ninguno se quede a medias. */
  if(theme==='plaza'){const spK=take();if(spK){
      /* Quiosco de prensa: cuerpo, mostrador, tejado y cartel. */
      const g=new THREE.Group();g.position.set(spK.x,0,spK.z);
      const body=new THREE.Mesh(new THREE.BoxGeometry(1.2,1.1,1.0),mat3('#3f6f8f',0.8));body.position.y=0.55;body.castShadow=true;g.add(body);
      const top=new THREE.Mesh(new THREE.BoxGeometry(1.4,0.08,1.2),mat3('#a4432f',0.7));top.position.y=1.14;g.add(top);
      const counter=new THREE.Mesh(new THREE.BoxGeometry(1.3,0.08,0.2),mat3('#8d6436',0.7));counter.position.set(0,0.85,0.5);g.add(counter);
      g.rotation.y=rand()*Math.PI*2;world.add(g);}
  }
  if(theme==='plaza'){lamp();}
  if(theme==='plaza'){const sp=take();if(sp){const g=new THREE.Group();g.position.set(sp.x,0,sp.z);
    const rim=new THREE.Mesh(new THREE.CylinderGeometry(0.92,0.98,0.3,16),mat3('#8a8578',0.85));rim.position.y=0.15;rim.castShadow=true;g.add(rim);
    const water=new THREE.Mesh(new THREE.CylinderGeometry(0.78,0.78,0.06,16),mat3('#3f6f8f',0.35));water.position.y=0.31;g.add(water);
    const jet=new THREE.Mesh(new THREE.CylinderGeometry(0.05,0.09,0.9,8),mat3('#7f9fb4',0.4));jet.position.y=0.75;g.add(jet);
    world.add(g);}}
  if(theme==='dock'){const spB=take();if(spB){
      const g=new THREE.Group();g.position.set(spB.x,0,spB.z);
      const b1=new THREE.Mesh(new THREE.CylinderGeometry(0.16,0.2,0.5,10),mat3('#3b4046',0.75));b1.position.y=0.25;b1.castShadow=true;g.add(b1);
      const cap=new THREE.Mesh(new THREE.CylinderGeometry(0.22,0.22,0.08,10),mat3('#3b4046',0.7));cap.position.y=0.52;g.add(cap);
      const rope=new THREE.Mesh(new THREE.TorusGeometry(0.24,0.045,8,14),mat3('#c9b48a',0.85));rope.rotation.x=Math.PI/2;rope.position.y=0.12;g.add(rope);
      world.add(g);}
  }
  if(theme==='dock'){const sp=take();if(sp){const g=new THREE.Group();g.position.set(sp.x,0,sp.z);
    const a=new THREE.Mesh(new THREE.BoxGeometry(0.28,3.4,0.28),mat3('#c9a227',0.6));a.position.set(0,1.7,0);a.castShadow=true;g.add(a);
    const b=new THREE.Mesh(new THREE.BoxGeometry(1.9,0.2,0.2),mat3('#8a6f1c',0.6));b.position.set(0.85,3.3,0);b.castShadow=true;g.add(b);
    const hook=new THREE.Mesh(new THREE.BoxGeometry(0.06,0.9,0.06),mat3('#3b4046',0.5));hook.position.set(1.7,2.85,0);g.add(hook);
    world.add(g);}
    for(let i=0;i<3;i++)cylp(0.22,0.18,'#5c5346');}
  if(theme==='skirmish03'||theme==='skirmish04'){const spT2=take();if(spT2){
      const g=new THREE.Group();g.position.set(spT2.x,0,spT2.z);
      const body=new THREE.Mesh(new THREE.BoxGeometry(0.7,1.7,0.7),mat3('#b8202a',0.75));body.position.y=0.85;body.castShadow=true;g.add(body);
      const win=new THREE.Mesh(new THREE.BoxGeometry(0.5,1.0,0.06),mat3('#cfe6f2',0.3));win.position.set(0,1.05,0.36);g.add(win);
      const top=new THREE.Mesh(new THREE.BoxGeometry(0.8,0.12,0.8),mat3('#8f1a22',0.7));top.position.y=1.76;g.add(top);
      g.rotation.y=rand()*Math.PI*2;world.add(g);}
  }
  if(theme==='skirmish03'||theme==='skirmish04'){const sp=take();if(sp){
    const g=new THREE.Group();g.position.set(sp.x,0,sp.z);
    const box2=new THREE.Mesh(new THREE.BoxGeometry(0.5,1.0,0.5),mat3('#b3362b',0.7));box2.position.y=0.5;box2.castShadow=true;g.add(box2);
    const cap=new THREE.Mesh(new THREE.BoxGeometry(0.56,0.1,0.56),mat3('#7a1f17',0.7));cap.position.y=1.05;g.add(cap);
    world.add(g);}
    for(let i=0;i<2;i++){const sp2=take();if(!sp2)continue;const g2=new THREE.Group();g2.position.set(sp2.x,0,sp2.z);
      const body=new THREE.Mesh(new THREE.BoxGeometry(1.15,0.42,0.56),mat3(i?'#3f5a74':'#6b6252',0.8));body.position.y=0.3;body.castShadow=true;g2.add(body);
      const roof=new THREE.Mesh(new THREE.BoxGeometry(0.66,0.3,0.5),mat3(i?'#2f4457':'#514a3e',0.8));roof.position.set(-0.05,0.66,0);g2.add(roof);
      ['#1c1f22','#1c1f22'].forEach((c,k)=>{const w2=new THREE.Mesh(new THREE.CylinderGeometry(0.13,0.13,0.1,10),mat3(c,0.6));w2.rotation.x=Math.PI/2;w2.position.set(k?0.34:-0.36,0.13,0.29);g2.add(w2);});
      world.add(g2);}
    for(let i=0;i<2;i++)boxp(0.9,0.5,0.14,'#e0b83a','crate');}
}
