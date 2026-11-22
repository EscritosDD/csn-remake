import { shadeHex } from '../render2d/sprites.js';
import { roleLook } from '../data/roles.js';
import { mat3, box3, makeContactShadow3, soldierColors3 } from './scene.js';
import { makeGunProp3 } from './gun.js';

export function makeSoldier3(un){
  const c=soldierColors3(un);
  const g=new THREE.Group();
  const lk3=roleLook(un.role);
  const bulky=lk3.s[0];
  /* disco de bando, sombra de contacto, flecha de orientación y anillo de energía */
  const contactSh=makeContactShadow3(0.42,0.008);if(contactSh)g.add(contactSh);
  const base=new THREE.Mesh(new THREE.CylinderGeometry(0.31,0.34,0.035,24),mat3(c.team,0.6));
  base.position.y=0.02;base.receiveShadow=true;g.add(base);
  const chev=new THREE.Mesh(new THREE.ConeGeometry(0.085,0.14,3),new THREE.MeshBasicMaterial({color:un.team==='A'?0x7ae7ff:0xffa07a}));
  chev.rotation.z=-Math.PI/2;chev.scale.set(0.28,1,1);chev.position.set(0.37,0.036,0);g.add(chev);
  const segs=[];
  for(let i=0;i<un.maxEnergy;i++){
    const a=-Math.PI/2+i*(Math.PI*2/un.maxEnergy);
    const s=box3(0.075,0.028,0.045,'#69d66f',Math.cos(a)*0.42,0.035,Math.sin(a)*0.42,0.5);
    s.rotation.y=-a;g.add(s);segs.push(s);
  }
  const selRing=new THREE.Mesh(new THREE.TorusGeometry(0.5,0.016,8,40),new THREE.MeshBasicMaterial({color:0xffffff}));
  selRing.rotation.x=Math.PI/2;selRing.position.y=0.03;selRing.visible=false;g.add(selRing);
  /* cuerpo articulado: caderas, hombros, cuello y arma con pivote propio.
     Este soldado de cajas es solo la reserva: se usa si la malla real del
     IPA no ha cargado. El soldado de verdad es el de makeRealSoldier3, con
     la malla, el skinning y la textura del original. Cada pieza cuelga del
     hueso más cercano (cadera para
     pierna y bota, hombro para brazo y mano, cuello para la cabeza, hombros
     para el arma) y el sistema de animación mueve los pivotes, no la malla. */
  const body=new THREE.Group();body.scale.set(1,lk3.s[1],1);g.add(body);
  function makeLeg(sideZ){
    const hip=new THREE.Group();hip.position.set(0,0.28,sideZ);
    const leg=box3(0.11,0.27,0.13,shadeHex(c.uni,-34),0,-0.135,0);
    const boot=box3(0.17,0.06,0.12,'#241f1a',0.03,-0.27,0);
    hip.add(leg,boot);body.add(hip);return hip;
  }
  const hipL=makeLeg(0.1*bulky), hipR=makeLeg(-0.1*bulky);
  const torso=box3(0.26,0.36,0.4*bulky,c.uni,0,0.45,0);
  const chest=box3(0.05,0.26,0.3*bulky,c.role,0.14,0.45,0);
  body.add(torso,chest);
  if(un.role==='Artillero'){ /* cinta de munición cruzada */
    const belt=box3(0.3,0.05,0.44,'#e8c84e',0.02,0.5,0,0.6);belt.rotation.x=0.6;body.add(belt);
  }
  if(un.role==='Médico'){ /* botiquín a la espalda */
    const kit=box3(0.1,0.2,0.24,'#eef0e6',-0.19,0.48,0);body.add(kit);
    body.add(box3(0.03,0.13,0.045,'#d92c2c',-0.25,0.48,0,0.5));
    body.add(box3(0.03,0.045,0.13,'#d92c2c',-0.25,0.48,0,0.5));
  }
  if(un.role==='Ingeniero'){ /* mochila de herramientas */
    body.add(box3(0.12,0.26,0.28,'#5b5348',-0.2,0.5,0));
  }
  /* brazos con pivote en el hombro: sujetan el arma y absorben el retroceso */
  function makeArm(sideZ){
    const sh=new THREE.Group();sh.position.set(0,0.60,sideZ);
    const arm=box3(0.26,0.09,0.1,shadeHex(c.uni,-8),0.13,-0.06,0);
    const hand=new THREE.Mesh(new THREE.SphereGeometry(0.05,10,8),mat3(c.skin,0.65));
    hand.position.set(0.27,-0.07,0);hand.castShadow=true;
    sh.add(arm,hand);body.add(sh);return sh;
  }
  const armL=makeArm(0.21*bulky), armR=makeArm(-0.21*bulky);
  /* === EL ARMA, ENORME: la misma silueta por categoría del soldado real === */
  const gun=makeGunProp3(un);gun.position.set(0.08,0.52,0);body.add(gun);
  const muzzle=gun.userData.flash;
  /* CABEZA GRANDE con casco abovedado y banda de nación */
  const head=new THREE.Group();head.position.y=0.82;body.add(head);
  const skull=new THREE.Mesh(new THREE.SphereGeometry(0.17,22,18),mat3(c.skin,0.65));
  skull.castShadow=true;head.add(skull);
  if(un.role==='Espía'){
    const hood=new THREE.Mesh(new THREE.SphereGeometry(0.185,22,18,0,Math.PI*2,0,Math.PI*0.62),mat3('#353144',0.8));
    hood.castShadow=true;head.add(hood);
  } else {
    const helm=new THREE.Mesh(new THREE.SphereGeometry(0.185,22,14,0,Math.PI*2,0,Math.PI*0.55),mat3(c.helm,0.7));
    helm.position.y=0.015;helm.castShadow=true;head.add(helm);
    const brim=box3(0.4,0.03,0.42,shadeHex(c.helm,-14),0.01,0.045,0,0.7);head.add(brim);
    const band=new THREE.Mesh(new THREE.CylinderGeometry(0.188,0.188,0.05,22,1,true),mat3(c.band,0.7));
    band.position.y=0.045;head.add(band);
  }
  if(un.role==='Capitán'){
    const star=box3(0.02,0.09,0.09,'#ffd94d',0.16,0.1,0,0.4);head.add(star);
  }
  if(un.role==='Médico'){
    head.add(box3(0.1,0.05,0.14,'#ffffff',0,0.19,0,0.5));
    head.add(box3(0.03,0.035,0.05,'#d92c2c',0,0.225,0,0.5));
  }
  if(un.role==='Ingeniero'){
    head.add(box3(0.4,0.025,0.42,'#e8c84e',0.01,0.085,0,0.7));
  }
  if(un.role==='Comando'){
    head.add(box3(0.34,0.06,0.34,shadeHex(c.role,-18),0,0.075,0,0.7));
  }
  if(un.role==='Francotirador'){ /* flecos de ghillie sobre el casco */
    for(let i=0;i<6;i++){const a=i/6*Math.PI*2+0.3;head.add(box3(0.03,0.13,0.03,i%2?'#5d7a28':'#3e5620',Math.sin(a)*0.14,0.02,Math.cos(a)*0.14,0.85));}
  }
  if(un.role==='Artillero'){ /* cascos de comunicaciones a las orejas */
    head.add(box3(0.1,0.12,0.045,'#1e1e22',0,-0.02,0.185,0.6));
    head.add(box3(0.1,0.12,0.045,'#1e1e22',0,-0.02,-0.185,0.6));
  }
  if(un.role==='Médico'){ /* la cruz también sobre la gorra blanca */
    head.add(box3(0.13,0.03,0.045,'#d92c2c',0,0.232,0,0.5));
    head.add(box3(0.045,0.03,0.13,'#d92c2c',0,0.232,0,0.5));
  }
  /* ojos que miran al frente (hacia donde apunta el arma) */
  [-0.065,0.065].forEach(z=>{
    const eye=new THREE.Mesh(new THREE.SphereGeometry(0.02,8,8),new THREE.MeshBasicMaterial({color:0x1c1a17}));
    eye.position.set(0.155,0.01,z);head.add(eye);
  });
  g.userData={body:body,segs:segs,selRing:selRing,contactSh:contactSh,baseChev:chev,hipL:hipL,hipR:hipR,armL:armL,armR:armR,head:head,gun:gun,muzzle:muzzle,walkPhase:Math.random()*6.28,prevX:null,prevY:null,deathK:0,aimAng:un.team==='A'?0:Math.PI};
  return g;
}
