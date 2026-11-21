import { box3, mat3 } from './scene.js';
import { WEAPONS } from '../data/weapons.js';
import { roleLook } from '../data/roles.js';

export function makeGunProp3(un){
  /* El arma del original es la mitad de la silueta (70-80 % de la altura
     del soldado): cada categoría tiene la suya, de la pistola corta y
     gorda al tubo del lanzacohetes, con culata, cargador, mira, caja de
     munición o corredera según la familia. */
  const wcat=WEAPONS[un.weapon].cat;
  const gun=new THREE.Group();
  const steel='#26282c',dark='#1b1d20',wood='#7a4a22',gripC='#33363b',metal='#4a4e55';
  const piece=(len,wid,hi,col,x,y,z,r)=>gun.add(box3(len,wid,hi,col||steel,x,y||0,z||0,r==null?0.5:r));
  let gl;
  if(wcat==='Lanzacohetes'){
    gl=un.weapon==='M72 LAW'?0.62:0.8;
    const tr=un.weapon==='M72 LAW'?0.06:0.075;
    const tube=new THREE.Mesh(new THREE.CylinderGeometry(tr,tr,gl*1.05,14),mat3('#4a5d23',0.7));
    tube.rotation.z=Math.PI/2;tube.castShadow=true;gun.add(tube);
    const tip=new THREE.Mesh(new THREE.ConeGeometry(tr+0.01,0.16,14),mat3('#8a8f7a',0.6));
    tip.rotation.z=-Math.PI/2;tip.position.x=gl*0.6;gun.add(tip);
    if(un.weapon==='RPG-7'){piece(gl*0.3,0.085,0.085,wood,gl*0.38,0,0,0.7);piece(0.06,0.08,0.05,gripC,gl*0.4,-0.07,0);}
    piece(0.13,0.09,0.09,dark,-0.03,0,0);
  } else if(wcat==='Lanzagranadas'){
    if(un.weapon==='M32 MGL'){
      gl=0.5;
      piece(gl,0.08,0.08,steel,gl*0.5,0,0);
      const drum=new THREE.Mesh(new THREE.CylinderGeometry(0.1,0.1,0.12,16),mat3('#3f6216',0.6));
      drum.rotation.x=Math.PI/2;drum.position.set(gl*0.3,-0.07,0);gun.add(drum);
      piece(0.1,0.09,0.06,gripC,gl*0.55,-0.09,0);
    } else {
      gl=0.42;
      piece(gl,0.1,0.1,steel,gl*0.5,0,0);
      piece(0.1,0.09,0.07,dark,-0.03,0,0);
    }
  } else if(wcat==='Pistolas'){
    gl=un.weapon==='Desert Eagle'?0.42:0.34;
    piece(gl,0.065,0.07,steel,gl*0.5,0,0);
    piece(0.12,0.05,0.06,gripC,0,-0.085,0);
    piece(0.07,0.04,0.05,dark,gl*0.5+0.03,-0.03,0);
  } else if(wcat==='Subfusiles'){
    gl=0.56;
    piece(gl,0.055,0.055,steel,gl*0.5,0,0);
    piece(0.12,0.05,0.05,dark,-0.07,0,0);
    piece(gl*0.16,0.09,0.04,dark,gl*0.42,-0.075,0);
    if(un.weapon==='FN P90')piece(gl*0.32,0.04,0.05,dark,gl*0.55,0.05,0);
    piece(0.035,0.07,0.04,metal,gl*0.58,-0.06,0);
  } else if(wcat==='Escopetas'){
    gl=0.62;
    piece(gl,0.07,0.065,steel,gl*0.5,0,0);
    piece(0.13,0.055,0.05,wood,-0.07,0,0,0.7);
    piece(gl*0.22,0.045,0.05,wood,gl*0.42,-0.055,0,0.7);
    piece(0.05,0.08,0.05,gripC,gl*0.16,-0.08,0);
  } else if(wcat==='Ametralladoras'){
    gl=0.8;
    piece(gl,0.065,0.065,steel,gl*0.5,0,0);
    piece(0.13,0.06,0.06,dark,-0.08,0,0);
    piece(0.15,0.14,0.11,'#3f6216',gl*0.34,-0.11,0,0.6);
    if(un.weapon==='MG3')piece(0.1,0.09,0.05,metal,gl*0.3,-0.05,0.07);
    piece(0.03,0.13,0.03,metal,gl*0.6,-0.13,0);
  } else if(wcat==='Francotirador'){
    gl=0.85;
    piece(gl,0.055,0.055,steel,gl*0.5,0,0);
    piece(0.11,0.06,0.06,wood,-0.07,0,0,0.7);
    piece(gl*0.24,0.055,0.05,dark,gl*0.45,0.065,0,0.4);
    if(un.weapon==='Barrett M82')piece(0.055,0.07,0.07,metal,gl+0.01,0,0);
    const lens=new THREE.Mesh(new THREE.SphereGeometry(0.022,10,10),new THREE.MeshBasicMaterial({color:0x8fd8ff}));
    lens.position.set(gl*0.45,0.065,0.032);gun.add(lens);
  } else { /* Fusiles de asalto y carabinas */
    gl=0.68;
    piece(gl,0.06,0.06,steel,gl*0.5,0,0);
    piece(0.11,0.055,0.05,dark,-0.07,0,0);
    if(un.weapon==='AK-12'){
      piece(gl*0.13,0.095,0.04,dark,gl*0.52,-0.08,0);
      piece(0.045,0.05,0.04,dark,gl*0.56,-0.125,0);
    } else piece(gl*0.16,0.1,0.045,dark,gl*0.5,-0.085,0);
    piece(0.05,0.09,0.05,gripC,gl*0.28,-0.085,0);
    piece(0.035,0.05,0.03,metal,gl*0.66,0.05,0);
  }
  /* Detalles de silueta de las armas nuevas: mira, bipode, cargador y asa
     para que cada arma se distinga de su categoria de un vistazo. */
  if(un.weapon==='PSG-1'){piece(0.18,0.05,0.05,metal,gl*0.5,0.07,0);piece(0.06,0.05,0.05,dark,gl*0.5,0.105,0);}
  else if(un.weapon==='Mk 14 EBR'){piece(0.14,0.045,0.045,metal,gl*0.5,0.075,0);}
  else if(un.weapon==='Browning M2'){piece(0.05,0.07,0.02,dark,gl*0.62,-0.05,0.035);piece(0.05,0.07,0.02,dark,gl*0.62,-0.05,-0.035);}
  else if(un.weapon==='KRISS Vector'){piece(0.09,0.13,0.045,dark,gl*0.42,-0.095,0);}
  else if(un.weapon==='FAMAS'){piece(0.13,0.04,0.04,metal,gl*0.55,0.075,0);}
  else if(un.weapon==='G36C'){piece(0.10,0.04,0.035,dark,gl*0.5,0.07,0);}
  else if(un.weapon==='Mossberg 500'){piece(0.16,0.05,0.05,dark,gl*0.35,-0.02,0);}
  else if(un.weapon==='Mk 19'){piece(0.15,0.15,0.15,dark,gl*0.42,-0.02,0);}
  const flash=new THREE.Mesh(new THREE.SphereGeometry(0.055,8,8),new THREE.MeshBasicMaterial({color:0xffd76a,transparent:true,opacity:0}));
  flash.position.set(gl+0.04,0.01,0);gun.add(flash);gun.userData.flash=flash;
  /* Escala compacta y proporcional a la silueta del rol: el soldado real
     mide ~1,08 m y la separación entre palmas ronda los 0,40 m, así que
     recortar ~14 % las armas largas (26 % las pistolas) y multiplicar por
     el factor medio de ROLE_LOOK evita fusiles desmesurados o pistolas más
     largas que el antebrazo. */
  const lk=roleLook(un.role);
  const roleScale=(lk.s[0]+lk.s[1]+lk.s[2])/3;
  const catScale=(wcat==='Pistolas')?0.74:0.86;
  const gunScale=catScale*roleScale;
  gun.scale.setScalar(gunScale);
  gun.userData.scale=gunScale;
  gun.userData.cat=wcat;
  /* Punto de agarre de cada categoría en el espacio local del arma,
     colocado exactamente dentro de la palma derecha del soldado. */
  if(wcat==='Pistolas')gun.userData.grip={x:0.02,y:-0.06,scale:gunScale};
  else if(wcat==='Lanzacohetes')gun.userData.grip={x:un.weapon==='RPG-7'?gl*0.40:gl*0.18,y:-0.055,scale:gunScale};
  else if(wcat==='Lanzagranadas')gun.userData.grip={x:un.weapon==='M32 MGL'?gl*0.14:gl*0.28,y:-0.055,scale:gunScale};
  else if(wcat==='Escopetas')gun.userData.grip={x:gl*0.16,y:-0.06,scale:gunScale};
  else if(wcat==='Subfusiles')gun.userData.grip={x:gl*0.22,y:-0.055,scale:gunScale};
  else if(wcat==='Ametralladoras')gun.userData.grip={x:gl*0.16,y:-0.055,scale:gunScale};
  else if(wcat==='Francotirador')gun.userData.grip={x:gl*0.18,y:-0.055,scale:gunScale};
  else gun.userData.grip={x:gl*0.28,y:-0.065,scale:gunScale};
  return gun;
}
