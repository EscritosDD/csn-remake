import { shadeHex } from '../render2d/sprites.js';
import { ROLES, gameplayModelPresentation } from '../data/roles.js';
import { sculptedWeaponUnit } from '../data/cast.js';
import { mat3, box3, makeContactShadow3, nationTintColor, camoTexture, emblemTexture, soldierColors3, toonGrad3 } from './scene.js';
import { TEAM_A_HEX, TEAM_B_HEX, TEAM_B, SELECT_LIME_HEX } from './env.js';
import { makeGunAnchor, attachRealGun } from './assets-weapons.js';
import { REAL } from './assets-real.js';
import { MESHY_MODELS, validatedRigBoneInverses, sameRigBoneOrder } from './assets-meshy.js';
import { worldRotationsFromLocal } from './clips.js';

export function makeGlbSoldier3(un){
  const actor=un.glbActor;
  if(!actor||!actor.root)return null;
  const c=soldierColors3(un),g=new THREE.Group();
  g.scale.setScalar(1.15);
  const hpArc=new THREE.Mesh(new THREE.RingGeometry(0.44,0.54,64,1,0,Math.PI*2),new THREE.MeshBasicMaterial({color:un.team==='A'?TEAM_A_HEX:TEAM_B_HEX,transparent:true,opacity:0.92,side:THREE.DoubleSide,depthWrite:false}));
  hpArc.rotation.x=-Math.PI/2;hpArc.position.y=0.05;g.add(hpArc);
  const roleRing=new THREE.Mesh(new THREE.RingGeometry(0.36,0.405,48,1,0,Math.PI*2),new THREE.MeshBasicMaterial({color:new THREE.Color(c.role),transparent:true,opacity:0.85,side:THREE.DoubleSide,depthWrite:false}));
  roleRing.rotation.x=-Math.PI/2;roleRing.position.y=0.055;g.add(roleRing);
  const shadow=makeContactShadow3(0.42,0.008);if(shadow)g.add(shadow);
  g.add(new THREE.Mesh(new THREE.CylinderGeometry(0.31,0.34,0.035,24),mat3(c.team,0.6)));
  const chev=new THREE.Mesh(new THREE.ConeGeometry(0.085,0.14,3),new THREE.MeshBasicMaterial({color:un.team==='A'?TEAM_A_HEX:TEAM_B_HEX}));
  chev.rotation.z=-Math.PI/2;chev.scale.set(0.28,1,1);chev.position.set(0.37,0.036,0);g.add(chev);
  const segs=[];
  for(let i=0;i<un.maxEnergy;i++){
    const a=-Math.PI/2+i*(Math.PI*2/un.maxEnergy);
    const s=box3(0.075,0.028,0.045,'#69d66f',Math.cos(a)*0.42,0.035,Math.sin(a)*0.42,0.5);
    s.rotation.y=-a;g.add(s);segs.push(s);
  }
  const selRing=new THREE.Mesh(new THREE.TorusGeometry(0.5,0.016,8,40),new THREE.MeshBasicMaterial({color:SELECT_LIME_HEX}));
  selRing.rotation.x=Math.PI/2;selRing.position.y=0.03;selRing.visible=false;g.add(selRing);
  const spin=new THREE.Group();spin.rotation.y=Math.PI/2;g.add(spin);spin.add(actor.root);
  g.userData.hpArc=hpArc;g.userData.segs=segs;g.userData.selRing=selRing;g.userData.baseChev=chev;
  g.userData.real=true;g.userData.glbActor=actor;g.userData.glbState='idle';
  return g;
}

export function makeRealSoldier3(un){
  if(un.glbActor&&un.glbActor.root)return makeGlbSoldier3(un);
  const c=soldierColors3(un);
  const g=new THREE.Group();
  g.scale.setScalar(1.15); /* soldados un poco mas grandes que una casilla, como el original */
  /* Arco de vida en el suelo (verde el jugador, azul el rival): media luna
     por PV con drawRange sobre un anillo de 64 segmentos. */
  const hpArc=new THREE.Mesh(new THREE.RingGeometry(0.44,0.54,64,1,0,Math.PI*2),new THREE.MeshBasicMaterial({color:un.team==='A'?TEAM_A_HEX:TEAM_B_HEX,transparent:true,opacity:0.92,side:THREE.DoubleSide,depthWrite:false}));
  hpArc.rotation.x=-Math.PI/2;hpArc.position.y=0.05;g.add(hpArc);g.userData.hpArc=hpArc;
  /* Anillo fino del color del rol: distingue a cada especialista de un vistazo. */
  const roleRing=new THREE.Mesh(new THREE.RingGeometry(0.36,0.405,48,1,0,Math.PI*2),new THREE.MeshBasicMaterial({color:new THREE.Color(c.role),transparent:true,opacity:0.85,side:THREE.DoubleSide,depthWrite:false}));
  roleRing.rotation.x=-Math.PI/2;roleRing.position.y=0.055;g.add(roleRing);
  const contactSh=makeContactShadow3(0.42,0.008);if(contactSh)g.add(contactSh);
  const base=new THREE.Mesh(new THREE.CylinderGeometry(0.31,0.34,0.035,24),mat3(c.team,0.6));
  base.position.y=0.02;base.receiveShadow=true;g.add(base);
  const chev=new THREE.Mesh(new THREE.ConeGeometry(0.085,0.14,3),new THREE.MeshBasicMaterial({color:un.team==='A'?TEAM_A_HEX:TEAM_B_HEX}));
  chev.rotation.z=-Math.PI/2;chev.scale.set(0.28,1,1);chev.position.set(0.37,0.036,0);g.add(chev);
  const segs=[];
  for(let i=0;i<un.maxEnergy;i++){
    const a=-Math.PI/2+i*(Math.PI*2/un.maxEnergy);
    const s=box3(0.075,0.028,0.045,'#69d66f',Math.cos(a)*0.42,0.035,Math.sin(a)*0.42,0.5);
    s.rotation.y=-a;g.add(s);segs.push(s);
  }
  const selRing=new THREE.Mesh(new THREE.TorusGeometry(0.5,0.016,8,40),new THREE.MeshBasicMaterial({color:SELECT_LIME_HEX}));
  selRing.rotation.x=Math.PI/2;selRing.position.y=0.03;selRing.visible=false;g.add(selRing);
  /* la malla real, colgando del giro de ejes: el espacio del IPA es Z
     arriba; el grupo spin+tilt lo deja Y arriba y mirando a +X, y el
     esqueleto va dentro, así que huesos y malla comparten el giro. */
  const spin=new THREE.Group();spin.rotation.y=Math.PI/2;g.add(spin);
  /* Solo el cuerpo generico necesita una silueta sintetica por rol;
     las mallas propias ya traen su proporcion. */
  const lk=roleLook(un.role);
  const tilt=new THREE.Group();spin.add(tilt);
  /* Prefer the authored Meshy or role model when available. */
  const meshy=(!window.__forceBaseModel&&un.charMesh&&MESHY_MODELS[un.charMesh])||null;
  tilt.rotation.x=(meshy&&!meshy.zUp)?0:-Math.PI/2;
  const castTex=(un.charTexture&&REAL.castTex)?REAL.castTex[un.charTexture]:null;
  const RD=meshy||((!window.__forceBaseModel&&REAL.byRole&&REAL.byRole[un.role])||REAL);
  const presentation=gameplayModelPresentation(un.role,!!meshy||RD!==REAL);
  spin.scale.set(presentation.scale[0],presentation.scale[1],presentation.scale[2]);
  const roleTex=castTex||(meshy&&meshy.tex)||RD.tex||(REAL.texByRole&&REAL.texByRole[un.role])||REAL.tex;
  const data=RD.data;
  const bones=data.bones.map(b=>{
    const bone=new THREE.Bone();bone.name=b.name;
    bone.position.fromArray(b.pos);bone.quaternion.fromArray(b.quat);
    if(b.scale)bone.scale.fromArray(b.scale);
    return bone;
  });
  data.bones.forEach((b,i)=>{if(b.parent>=0)bones[b.parent].add(bones[i]);});
  const skinBones=data.skinBones.map(i=>bones[i]);
  let inverses=data.boneInverses.map(a=>new THREE.Matrix4().set(a[0],a[1],a[2],a[3],a[4],a[5],a[6],a[7],a[8],a[9],a[10],a[11],a[12],a[13],a[14],a[15]));
  /* Diagnostico: las bind poses del IPA pueden venir en columnas. Con este
     interruptor se trasponen antes de montar el esqueleto. */
  if(window.__transposeBind)inverses.forEach(m=>m.transpose());
  else inverses=validatedRigBoneInverses(data,bones,inverses);
  const skeleton=new THREE.Skeleton(skinBones,inverses);
  /* Material cartoon: rampa de 4 pasos en el canal de luz (MeshToonMaterial)
     para el look cel del original, con la textura real del IPA. Si algo
     fallara, se queda el material estándar de siempre. */
  const gradTex=toonGrad3();
  const materialSide=presentation.twoSided?THREE.DoubleSide:THREE.FrontSide;
  const mat=presentation.preserveTexture
    ?new THREE.MeshStandardMaterial({map:roleTex,roughness:0.85,metalness:0.02,side:materialSide})
    :(gradTex?new THREE.MeshToonMaterial({map:roleTex,gradientMap:gradTex,side:materialSide}):new THREE.MeshStandardMaterial({map:roleTex,roughness:0.85,metalness:0.02,side:materialSide}));
  /* Keep authored character textures intact; tint only the generic fallback. */
  if(un.skin==='nacion'&&un.nation&&un.nation.colors&&!presentation.preserveTexture){
    mat.color.copy(new THREE.Color(nationTintColor(un.nation))).lerp(new THREE.Color('#ffffff'),0.42);
  }
  /* Equipo enemigo: el uniforme se tine calido para que no se confunda con
     el tuyo ni de espaldas. El bando A conserva el color natural. */
  if(un.skin==='camuflaje'){try{const ct=camoTexture();if(ct){mat.map=ct;mat.color.set(0xffffff);}}catch(e){}}
  if(un.skin==='estandar'&&!castTex&&!meshy&&!presentation.preserveTexture){
    try{const cn=un.name||charNameFor(un.role);const ce=OWN_CAST.concat(ORIG_CAST).find(c=>c.name===cn);if(ce&&ce.tint)mat.color.copy(new THREE.Color(ce.tint)).lerp(new THREE.Color('#ffffff'),0.42);}catch(e){}
  }
  if(un.skin==='clase'&&ROLES[un.role]){mat.color.copy(new THREE.Color(ROLES[un.role].color)).lerp(new THREE.Color('#ffffff'),0.30);}
  if(un.team==='B'&&!presentation.preserveTexture){mat.color.lerp(new THREE.Color(TEAM_B),0.22);}
  if(presentation.emissiveIntensity>0){
    mat.emissiveMap=mat.map;
    mat.emissive.copy(mat.color);
    mat.emissiveIntensity=presentation.emissiveIntensity;
    mat.needsUpdate=true;
  }
  /* El color lo ponen las ramas de skin de arriba (nación, estándar, clase,
     camuflaje) y el tinte rojo del equipo B: no se sobrescribe aquí, porque
     un mat.color.copy(tint) final anulaba todas esas skins. */
  /* Diagnostico: window.__noSkin monta la geometria como malla normal para
     separar un problema de geometria/parseo de uno de skinning. */
  const mesh=window.__noSkin?new THREE.Mesh(RD.geo,mat):new THREE.SkinnedMesh(RD.geo,mat);
  mesh.castShadow=true;mesh.frustumCulled=false;
  mesh.add(bones[0]);
  if(mesh.isSkinnedMesh)mesh.bind(skeleton,new THREE.Matrix4());
  tilt.add(mesh);
  const sculpted=sculptedWeaponUnit(un);
  const gun=makeGunAnchor(un);gun.position.set(0.14,0.62,-0.02);gun.visible=!sculpted;g.add(gun);
  if(!sculpted)attachRealGun(un,gun);
  /* Mochila de rol, construida en código a la espalda (el frente del grupo
     es +X, por donde sale el arma): es lo que distingue a cada rol de un
     vistazo sobre la misma malla del IPA, igual que el arma de su rol. */
  if(presentation.addRoleGear){
  const pack=new THREE.Group();pack.position.set(-0.21*lk.s[2],0.74*lk.s[1],0);
  const packCol=un.role==='Médico'?'#eef0e6':un.role==='Ingeniero'?'#5b5348':shadeHex(c.role,-30);
  const packScale=lk.s[0];
  pack.add(box3(0.13,0.32*packScale,0.3*packScale,packCol,0,0,0,0.8));
  if(un.role==='Médico'){pack.add(box3(0.03,0.2,0.06,'#d92c2c',-0.08,0,0,0.5));pack.add(box3(0.03,0.06,0.2,'#d92c2c',-0.08,0,0,0.5));}
  else if(un.role==='Ingeniero'){pack.add(box3(0.14,0.07,0.31,'#f2b234',0,0.19,0,0.6));}
  else if(un.role==='Francotirador'){pack.add(box3(0.02,0.34,0.02,'#2b2b2e',-0.03,0.3,0.08,0.5));}
  else if(un.role==='Artillero'){pack.add(box3(0.15,0.12,0.32,'#e8c84e',0,0.2,0,0.6));}
  else if(un.role==='Capitán'){pack.add(box3(0.03,0.12,0.12,'#ffd94d',-0.08,0,0,0.4));}
  else if(un.role==='Espía'){pack.add(box3(0.02,0.3,0.02,'#2b2b2e',0,0.28,0.1,0.5));}
  else if(un.role==='Comando'){pack.add(box3(0.1,0.08,0.26,'#3a3f2a',0.02,0.14,0,0.6));}
  g.add(pack);
  /* Banda de la mochila: segundo color de la bandera (Nacion) o color de
     la clase (Clase). */
  if(un.skin==='nacion'&&un.nation&&un.nation.colors&&un.nation.colors[1]){
    try{g.add(box3(0.02,0.10,0.27,un.nation.colors[1],-0.28,0.86,0,0.6));}catch(e){}
  } else if(un.skin==='clase'&&ROLES[un.role]){
    try{g.add(box3(0.02,0.10,0.27,shadeHex(ROLES[un.role].color,10),-0.28,0.86,0,0.6));}catch(e){}
  }
  /* Pecho del color del rol, franja del color de la nacion y hombreras del
     color del equipo: a distancia se leen la clase y el bando de un vistazo,
     encima de la silueta del tocado y de la mochila. */
  g.add(box3(0.024,0.20,0.21,c.role,0.145,0.74,0,0.75));
  g.add(box3(0.028,0.035,0.222,((un.skin==='nacion'&&un.nation)?un.nation.colors[1]:'#2e3226'),0.147,0.865,0,0.6));
  [-1,1].forEach(sd=>{g.add(box3(0.11,0.045,0.085,c.team,0,0.885,0.185*sd,0.8));});
  /* Acentos de silueta por clase sobre la mochila: se distinguen de
     espaldas y a distancia sin tocar los modelos del IPA. */
  const acc=(w,h,d,col,x,y,z,rough)=>{try{g.add(box3(w,h,d,col,x,y,z,rough));}catch(e){}};
  if(un.role==='Francotirador'){acc(0.012,0.24,0.012,'#2f3a2a',-0.26,0.97,0.05,0.5);acc(0.05,0.05,0.05,'#11170f',-0.26,1.10,0.05,0.4);}
  else if(un.role==='Artillero'){acc(0.14,0.11,0.17,'#4a4f38',-0.27,0.85,0,0.8);}
  else if(un.role==='Médico'){acc(0.022,0.10,0.03,'#eceee8',-0.255,0.90,0,0.6);acc(0.062,0.03,0.03,'#eceee8',-0.255,0.90,0,0.6);}
  else if(un.role==='Ingeniero'){acc(0.03,0.16,0.03,'#8a7a3a',-0.26,0.90,0.05,0.6);}
  else if(un.role==='Comando'){acc(0.012,0.20,0.012,'#2a2f38',-0.25,0.95,-0.06,0.5);}
  else if(un.role==='Espía'){acc(0.05,0.07,0.12,'#26222e',-0.24,0.86,0,0.7);}
  else if(un.role==='Capitán'){acc(0.10,0.03,0.14,'#d9a521',-0.25,0.92,0,0.5);}
  /* Emblema de la nacion en el pecho cuando la skin es Nacion. */
  if(un.skin==='nacion'&&un.nation){
    const et=emblemTexture(un.nation);
    if(et){
      const em=new THREE.Mesh(new THREE.PlaneGeometry(0.12,0.12),new THREE.MeshBasicMaterial({map:et,transparent:true,depthWrite:false}));
      em.position.set(0.171,0.76,0);em.rotation.y=Math.PI/2;g.add(em);
    }
  }
  }
  const bindLocal=data.bones.map(b=>new THREE.Quaternion(b.quat[0],b.quat[1],b.quat[2],b.quat[3]));
  /* Retargeting: si este cuerpo es una malla de clase, su reposo no es el
     del rig base con el que se hornearon los clips. Se aplica el clip como
     delta en espacio mundial para respetar los ejes locales de cada rig. */
  const parents=data.bones.map(b=>b.parent);
  const baseData=!meshy&&RD!==REAL&&sameRigBoneOrder(REAL.data&&REAL.data.bones,data.bones)?REAL.data:null;
  const baseRestQ=baseData?baseData.bones.map(b=>new THREE.Quaternion(b.quat[0],b.quat[1],b.quat[2],b.quat[3])):null;
  const sourceParents=baseData?baseData.bones.map(b=>b.parent):parents;
  const bindWorldQ=worldRotationsFromLocal(bindLocal,parents);
  const baseRestWorldQ=baseRestQ?worldRotationsFromLocal(baseRestQ,sourceParents):null;
  const byName={};data.bones.forEach((b,i)=>{byName[b.name]=i;});
  /* Los rigs del repo no traen los huesos gunBone_* del original; se
     aliasan a la mano derecha para que los sockets de UnitWeapon puedan
     resolver el anclaje real sin cambiar la jerarquía de los clips. */
  if(byName.gunBone_R===undefined&&byName['Bip001 R Hand']!==undefined)byName.gunBone_R=byName['Bip001 R Hand'];
  if(byName.gunMuzzleBone===undefined&&byName.gunBone_R!==undefined)byName.gunMuzzleBone=byName.gunBone_R;
  if(byName.gunMuzzleBoneB===undefined&&byName.gunMuzzleBone!==undefined)byName.gunMuzzleBoneB=byName.gunMuzzleBone;
  /* Complexion por rol: se escalan huesos concretos (claviculas, columna,
     cabeza y piernas) para que cada clase tenga cuerpo propio sin tocar la
     malla del IPA. Valores suaves: hombros del artillero anchos, espi­a
     estrecho y bajo, francotirador alto y fino, capitan erguido. */
  /* La complexion ya la trae cada modelo del original (Soldier_Light,
     Soldier_Heavy, Agent, Medic, Engineer, Commander): no se escala nada. */
  /* The 3D viewer's authored models already contain their proportions and
     equipment. ROLE_LOOK and procedural gear are only for the generic body. */
  mesh.scale.setScalar(meshy?meshy.scale:0.95);

  if(presentation.addRoleGear){
  /* Tocados por rol sobre la malla real, colgados del hueso Head: su Z
     local es el arriba del IPA, así que el grupo gira para que su +Y
     apunte a ese arriba y el casco se mueve con la cabeza en reposo,
     giro y disparo. */
  const headBone=bones[byName['Bip001 Head']];
  if(headBone){
    const gear=new THREE.Group();
    gear.rotation.z=Math.PI/2; /* el +Y del grupo sigue al -X local del hueso, que es el arriba renderizado */
    headBone.add(gear);
    /* Tocado propio de cada rol, en su color y no en el de la nación:
       es la segunda cosa que se lee de un soldado tras la silueta.
       Médico: casco blanco con la cruz roja encima. Ingeniero: casco
       de obra amarillo de ala ancha. Capitán: gorra de plato plana
       azul oscuro con galón dorado y visera, sin cúpula. Francotirador:
       cúpula verde con flecos de ghillie colgando. Artillero: cúpula
       grande de acero oscuro con cascos de comunicaciones en las
       orejas. Espía: capucha oscura que baja más que ningún casco.
       Comando: gorra táctica aplastada en el color oscuro de su rol. */
    let gearCol=c.helm;
    if(un.role==='Espía')gearCol='#353144';
    else if(un.role==='Médico')gearCol='#f4f6f0';
    else if(un.role==='Ingeniero')gearCol='#f2b234';
    else if(un.role==='Capitán')gearCol='#232a35';
    else if(un.role==='Francotirador')gearCol='#4d6b1f';
    else if(un.role==='Artillero')gearCol='#33363b';
    else if(un.role==='Comando')gearCol=shadeHex(c.role,-30);
    if(un.role==='Capitán'){
      const capTop=new THREE.Mesh(new THREE.CylinderGeometry(0.12,0.115,0.055,18),mat3(gearCol,0.72));
      capTop.position.y=0.075;capTop.castShadow=true;gear.add(capTop);
      const band=new THREE.Mesh(new THREE.CylinderGeometry(0.121,0.121,0.02,18),mat3('#d9a521',0.5));
      band.position.y=0.042;gear.add(band);
      const visor=new THREE.Mesh(new THREE.CylinderGeometry(0.155,0.155,0.018,18),mat3('#14181f',0.6));
      visor.position.y=0.018;visor.castShadow=true;gear.add(visor);
    } else {
      const helm=new THREE.Mesh(new THREE.SphereGeometry(un.role==='Artillero'?0.128:0.112,22,14,0,Math.PI*2,0,Math.PI*(un.role==='Espía'?0.62:0.55)),mat3(gearCol,0.72));
      helm.position.y=0.05;helm.castShadow=true;
      if(un.role==='Comando')helm.scale.y=0.62;
      gear.add(helm);
      /* Cinta del casco: segundo color de la bandera (Nacion) o color de
         la clase (Clase). Refuerza la lectura del bando y del rol. */
      if(un.skin==='nacion'&&un.nation&&un.nation.colors&&un.nation.colors[1]){
        const rr=un.role==='Artillero'?0.131:0.115;
        const nb=new THREE.Mesh(new THREE.CylinderGeometry(rr,rr,0.022,18),mat3(un.nation.colors[1],0.6));
        nb.position.y=0.038;gear.add(nb);
      } else if(un.skin==='clase'&&ROLES[un.role]){
        const rr=un.role==='Artillero'?0.131:0.115;
        const nb=new THREE.Mesh(new THREE.CylinderGeometry(rr,rr,0.022,18),mat3(shadeHex(ROLES[un.role].color,-20),0.55));
        nb.position.y=0.038;gear.add(nb);
      }
      if(un.role==='Médico'){
        gear.add(box3(0.11,0.016,0.034,'#d92c2c',0,0.163,0,0.5));
        gear.add(box3(0.034,0.016,0.11,'#d92c2c',0,0.163,0,0.5));
      } else if(un.role==='Ingeniero'){
        const brim=new THREE.Mesh(new THREE.CylinderGeometry(0.165,0.165,0.025,16),mat3('#e8c84e',0.72));
        brim.position.y=0.005;brim.castShadow=true;gear.add(brim);
      } else if(un.role==='Francotirador'){
        for(let i=0;i<9;i++){
          const a=(i/9)*Math.PI*2+0.35;
          const strand=box3(0.016,0.105,0.016,i%2?'#5d7a28':'#3e5620',Math.cos(a)*0.118,0.045,Math.sin(a)*0.118,0.85);
          strand.rotation.z=-Math.cos(a)*0.45;strand.rotation.x=Math.sin(a)*0.45;
          gear.add(strand);
        }
      } else if(un.role==='Artillero'){
        [-1,1].forEach(sd=>{
          const cup=box3(0.055,0.075,0.032,'#1e1e22',0,0.005,sd*0.117,0.6);
          gear.add(cup);
        });
        gear.add(box3(0.055,0.03,0.085,'#1e1e22',0,0.172,0,0.6));
      } else if(un.role==='Comando'){
        const brim=new THREE.Mesh(new THREE.CylinderGeometry(0.138,0.138,0.016,16),mat3(shadeHex(c.role,-48),0.72));
        brim.position.y=0.008;brim.castShadow=true;gear.add(brim);
      }
    }
  }
  }
  g.userData={real:true,meshy:!!meshy,animatable:!meshy,body:null,segs:segs,selRing:selRing,baseMesh:base,contactSh:contactSh,baseChev:chev,bones:bones,mesh3:mesh,gun:gun,bindLocal:bindLocal,baseRestQ:baseRestQ,baseRestWorldQ:baseRestWorldQ,isClassRig:!!baseRestQ,bindWorldQ:bindWorldQ,parents:parents,sourceParents:sourceParents,sourcePoseQ:data.bones.map(()=>new THREE.Quaternion()),sourceWorldQ:data.bones.map(()=>new THREE.Quaternion()),targetWorldQ:data.bones.map(()=>new THREE.Quaternion()),targetLocalQ:data.bones.map(()=>new THREE.Quaternion()),byName:byName,curQ:bindLocal.map(q=>q.clone()),curRootP:new THREE.Vector3(),walkPh:Math.random()*6.28,bindPos:data.bones.map(b=>new THREE.Vector3(b.pos[0],b.pos[1],b.pos[2])),curDelta:new THREE.Vector3(),clipPhase:Math.random()*10,hitColor:mat.color.clone()};
  return g;
}
