import { WEAPONS } from '../data/weapons.js';

export const WEAPON_MESH_FILE={
  'M4A1':'AssaultRifle','AK-12':'Rifle','HK416':'AssaultRifle','FN SCAR-L':'Rifle','G36C':'AssaultRifle','FAMAS':'Rifle',
  'MP7':'Uzi','MP5':'MP5K','FN P90':'Uzi','UMP45':'MP5K','KRISS Vector':'MP5K',
  'M249 SAW':'LightMachineGun','M240B':'LightMachineGun','PKM':'LightMachineGun','MG3':'LightMachineGun','Browning M2':'LightMachineGun',
  'M40':'SniperRifle_weapon','M24 SWS':'SniperRifle_weapon','M110 SASS':'M95','SVD Dragunov':'SniperRifle_weapon',
  'AW50':'M95','Barrett M82':'M95','Mk 14 EBR':'M95','PSG-1':'SniperRifle_weapon','Electri-Fryer':'SniperRifle_weapon',
  'Remington 870':'Shotgun','Benelli M4':'RiotShotgun','Mossberg 500':'Shotgun',
  'RPG-7':'RPG','AT4':'RPG','M72 LAW':'RPG',
  'M203':'RPG','M32 MGL':'RPG','Mk 19':'RPG','M134 Minigun':'Minigun',
  'M9':'Pistol','Glock 17':'Pistol','M1911':'Revolver','Desert Eagle':'Revolver',
  'Lumber Numberer':'WoodAxe'
};

export const WEAPON_LEN={'Fusiles de asalto':0.54,'Subfusiles':0.36,'Ametralladoras':0.64,'Francotirador':0.72,
  'Escopetas':0.50,'Lanzacohetes':0.74,'Lanzagranadas':0.52,'Pistolas':0.21,'Cuerpo a cuerpo':0.32};

export const WEAPON_COVER_BY_FILE={
  'AssaultRifle':'item_weapon_14_Semi_Auto_Rifle_alpha','Rifle':'item_weapon_14_Semi_Auto_Rifle_alpha',
  'Uzi':'item_weapon_08_Uzi_alpha','MP5K':'item_weapon_18_mp5k_alpha',
  'LightMachineGun':'item_weapon_15_Light_Machine_Gun_alpha','Minigun':'item_weapon_16_minigun_alpha',
  'SniperRifle_weapon':'item_weapon_12_Sniper_Rifle_1_alpha','M95':'item_weapon_13_Sniper_Rifle_2_alpha',
  'Shotgun':'item_weapon_10_shotgun_alpha','RiotShotgun':'item_weapon_17_RiotShotgun_alpha',
  'Pistol':'item_weapon_06_M9_alpha','Revolver':'item_weapon_07_Ruger_alpha',
  'Knife':'item_weapon_05_knife_alpha','Katana':'item_weapon_03_Katana_alpha',
  'WoodAxe':'item_weapon_01_axe_alpha','SledgeHammer':'item_weapon_02_Sledgehammer_alpha',
  'BaseballBat_SOURCE':'item_weapon_04_Baseball___bat_alpha','SpikedClub_weapon':'item_weapon_spikedclub_alpha',
  'Chainsaw':'item_large_weapon_chainsaw_alpha'
};

export const WEAPONS_ORIGINAL={
   'AssaultRifle':{name:'Assault Rifle',tex:'AssaultRifle_d',texSize:[256,256],dims:[0.776,0.108,0.3],verts:201,cover:'item_weapon_14_Semi_Auto_Rifle_alpha',cat:'Fusiles de asalto',uses:['M4A1','HK416','G36C','FAMAS'],roles:'Comando, Capitán, Espía'},
 'Rifle':{name:'Semi Auto Rifle',tex:'Rifle_d',texSize:[256,256],dims:[0.945,0.085,0.229],verts:405,cover:'item_weapon_14_Semi_Auto_Rifle_alpha',cat:'Fusiles de asalto',uses:['AK-12','FN SCAR-L'],roles:'Comando',note:'Comparte la carátula 14 con AssaultRifle; la carátula 09 (M16A2) no está asignada a ninguna malla.'},
 'Pistol':{name:'M9',tex:'Pistol_d',texSize:[128,128],dims:[0.86,0.148,0.603],verts:196,cover:'item_weapon_06_M9_alpha',cat:'Pistolas',uses:['M9','Glock 17'],roles:'todos (secundaria)'},
 'SniperRifle_weapon':{name:'Sniper Rifle 1',tex:'SniperRifle_d',texSize:[256,256],dims:[1.13,0.186,0.293],verts:583,cover:'item_weapon_12_Sniper_Rifle_1_alpha',cat:'Francotirador',uses:['M40','M24 SWS','SVD Dragunov','PSG-1','Electri-Fryer'],roles:'Francotirador, Comando'},
 'Shotgun':{name:'Shotgun',tex:'Shotgun_d',texSize:[256,256],dims:[0.711,0.096,0.257],verts:210,cover:'item_weapon_10_shotgun_alpha',cat:'Escopetas',uses:['Remington 870','Mossberg 500'],roles:'Comando, Espía, Ingeniero'},
 'RPG':{name:'RPG',tex:'RPG_d',texSize:[256,256],dims:[0.752,0.385,0.259],verts:254,cover:null,cat:'Lanzacohetes / Lanzagranadas',uses:['RPG-7','AT4','M72 LAW','M203','M32 MGL','Mk 19'],roles:'Artillero, Comando, Ingeniero',note:'Sin carátula en el original.'},
 'Crossbow':{name:'Crossbow',tex:'Crossbow_d',texSize:[256,256],dims:[0.911,0.629,0.281],verts:696,cover:null,cat:'—',uses:[],roles:'sin asignar en el arsenal de CSN',note:'Sin carátula en el original; arma del original sin equivalente en CSN.'},
 'SledgeHammer':{name:'Sledgehammer',tex:'SledgeHammer_d',texSize:[256,256],dims:[0.284,0.176,1.02],verts:98,cover:'item_weapon_02_Sledgehammer_alpha',cat:'Cuerpo a cuerpo',uses:[],roles:'sin asignar en el arsenal de CSN'},
 'Uzi':{name:'Uzi',tex:'Uzi_d',texSize:[128,128],dims:[0.467,0.052,0.386],verts:195,cover:'item_weapon_08_Uzi_alpha',cat:'Subfusiles',uses:['MP7','FN P90'],roles:'Espía, Comando'},
 'Revolver':{name:'Ruger',tex:'Revolver_d',texSize:[128,128],dims:[1.086,0.272,0.674],verts:137,cover:'item_weapon_07_Ruger_alpha',cat:'Pistolas',uses:['M1911','Desert Eagle'],roles:'todos (secundaria), Comando, Capitán'},
 'RiotShotgun':{name:'Riot Shotgun',tex:'RiotShotgun_d',texSize:[256,256],dims:[0.663,0.089,0.202],verts:204,cover:'item_weapon_17_RiotShotgun_alpha',cat:'Escopetas',uses:['Benelli M4'],roles:'Comando'},
 'M95':{name:'Sniper Rifle 2',tex:'M95_d',texSize:[256,256],dims:[1.247,0.276,0.307],verts:620,cover:'item_weapon_13_Sniper_Rifle_2_alpha',cat:'Francotirador',uses:['M110 SASS','AW50','Barrett M82','Mk 14 EBR'],roles:'Francotirador'},
 'LightMachineGun':{name:'Light Machine Gun',tex:'LightMachineGun_d',texSize:[256,256],dims:[0.917,0.281,0.446],verts:246,cover:'item_weapon_15_Light_Machine_Gun_alpha',cat:'Ametralladoras',uses:['M249 SAW','M240B','PKM','MG3','Browning M2'],roles:'Artillero'},
 'Molotov':{name:'Molotov',tex:'Molotov_d',texSize:[64,64],dims:[0.248,0.188,0.43],verts:51,cover:null,cat:'Consumible',uses:[],roles:'sin asignar en el arsenal de CSN',note:'Sin carátula en el original.'},
 'Knife':{name:'Knife',tex:'knife_d',texSize:[128,128],dims:[0.119,0.038,0.497],verts:114,cover:'item_weapon_05_knife_alpha',cat:'Cuerpo a cuerpo',uses:[],roles:'sin asignar en el arsenal de CSN'},
 'Katana':{name:'Katana',tex:'katana_d',texSize:[128,128],dims:[0.322,0.244,2.39],verts:142,cover:'item_weapon_03_Katana_alpha',cat:'Cuerpo a cuerpo',uses:[],roles:'sin asignar en el arsenal de CSN'},
 'WoodAxe':{name:'Axe',tex:'WoodAxe_d',texSize:[128,128],dims:[0.313,0.068,0.854],verts:126,cover:'item_weapon_01_axe_alpha',cat:'Cuerpo a cuerpo',uses:['Lumber Numberer'],roles:'Artillero'},
 'MP5K':{name:'MP5K',tex:'MP5K_d',texSize:[128,128],dims:[0.393,0.08,0.271],verts:204,cover:'item_weapon_18_mp5k_alpha',cat:'Subfusiles',uses:['MP5','UMP45','KRISS Vector'],roles:'Espía, Comando'},
 'Chainsaw':{name:'Chainsaw',tex:'Chainsaw_d',texSize:[256,256],dims:[0.311,0.286,0.877],verts:334,cover:'item_large_weapon_chainsaw_alpha',cat:'Cuerpo a cuerpo',uses:[],roles:'sin asignar en el arsenal de CSN'},
  'Minigun':{name:'Minigun',tex:'Minigun_d',texSize:[256,256],dims:[0.849,0.419,0.402],verts:527,cover:'item_weapon_16_minigun_alpha',cat:'Ametralladoras',uses:['M134 Minigun'],roles:'Ingeniero (torreta)'},

 'BaseballBat_SOURCE':{name:'Baseball Bat',tex:'BaseballBat_d',texSize:[128,128],dims:[0.118,0.098,0.963],verts:179,cover:'item_weapon_04_Baseball___bat_alpha',cat:'Cuerpo a cuerpo',uses:[],roles:'sin asignar en el arsenal de CSN'},
 'SpikedClub_weapon':{name:'Spiked Club',tex:'SpikedClub_d',texSize:[128,128],dims:[0.34,0.971,0.359],verts:331,cover:'item_weapon_spikedclub_alpha',cat:'Cuerpo a cuerpo',uses:[],roles:'sin asignar en el arsenal de CSN'},
 'FragGrenade':{name:'Frag Grenade',tex:'FragGrenade_d',texSize:[64,64],dims:[0.142,0.122,0.194],verts:123,cover:null,cat:'Consumible',uses:['Granada de fragmentación'],roles:'todos (consumible)',note:'Sin carátula en el original.'}
};

const ORIGINAL_MELEE=new Set(['Knife','Katana','WoodAxe','SledgeHammer','BaseballBat_SOURCE','SpikedClub_weapon','Chainsaw']);
const ORIGINAL_THROW=new Set(['FragGrenade','Molotov']);
const ORIGINAL_NO_FLASH=new Set([...ORIGINAL_MELEE,'Crossbow',...ORIGINAL_THROW]);
const ORIGINAL_WEAPON_PROFILES={
  'AssaultRifle':['idle2h','fireBurst','assaultrifle_fire.mp3'], 'Rifle':['idle2h','fire2h','semiautorifle_fire.mp3'],
  'Pistol':['idle1h','fire1h','beretta_fire.mp3'], 'Revolver':['idle1h','fire1hHeavy','revolver_fire.mp3'],
  'Uzi':['idle1h','fire1hBurst','submachinegun_fire.mp3'], 'MP5K':['idle2h','fireBurst','mp5k_fire.mp3'],
  'LightMachineGun':['idle2h','fireBurst','lmg_fire.mp3'], 'Minigun':['idle2h','fireMini','minigun_fire.mp3'],
  'SniperRifle_weapon':['idle2h','fireHeavy','sniperrifle_fire.mp3'], 'M95':['idle2h','fireHeavy','m95_fire.mp3'],
  'Shotgun':['idle2h','fireHeavy','shotgun_fire.mp3'], 'RiotShotgun':['idle2h','fireHeavy','riotshotgun_fire.wav'],
  'RPG':['idle2h','fireShoulder','rocketlauncher_fire.mp3'], 'Crossbow':['idle2h','fire2h','crossbow_fire.mp3'],
  'Knife':['idleMelee','fireMelee','knife_slash_01.mp3'], 'Katana':['idleMelee','fireMelee','knife_slash_01.mp3'],
  'WoodAxe':['idleMelee','fireMelee','axe_swing_01.mp3'], 'SledgeHammer':['idleMelee','fireMelee','2h_swing_01.mp3'],
  'BaseballBat_SOURCE':['idleMelee','fireMelee','baseballbat_hit_01.mp3'], 'SpikedClub_weapon':['idleMelee','fireMelee','spikedclub_hit_01.mp3'],
  'Chainsaw':['idleMelee','fireMelee','chainsaw_swing_01.mp3'],
  'FragGrenade':['idle1h','throw','grenade_throw_01.mp3'], 'Molotov':['idle1h','throw','grenade_throw_01.mp3']
};

export function originalWeaponProfile(file){
  const p=ORIGINAL_WEAPON_PROFILES[file];
  if(!p)return null;
  return {idleClip:p[0],fireClip:p[1],sfx:p[2],hasMuzzleFlash:!ORIGINAL_NO_FLASH.has(file),actionLabel:ORIGINAL_MELEE.has(file)?'Probar ataque':ORIGINAL_THROW.has(file)?'Probar lanzamiento':'Probar disparo'};
}
let _flashTex=null;
function flashTexture(){
  if(_flashTex)return _flashTex;
  if(typeof document==='undefined'||!document.createElement||!THREE.CanvasTexture)return null;
  const canvas=document.createElement('canvas');canvas.width=128;canvas.height=128;
  const ctx=canvas.getContext&&canvas.getContext('2d');if(!ctx)return null;
  ctx.clearRect(0,0,128,128);ctx.translate(64,64);
  for(let i=0;i<6;i++){
    ctx.save();ctx.rotate(i*Math.PI/3);
    const ray=ctx.createLinearGradient(0,0,0,-62);
    ray.addColorStop(0,'rgba(255,248,214,0.95)');ray.addColorStop(0.32,'rgba(255,185,64,0.55)');ray.addColorStop(1,'rgba(255,130,20,0)');
    ctx.fillStyle=ray;ctx.beginPath();ctx.moveTo(-4,0);ctx.lineTo(0,-62);ctx.lineTo(4,0);ctx.closePath();ctx.fill();ctx.restore();
  }
  const core=ctx.createRadialGradient(0,0,0,0,0,32);
  core.addColorStop(0,'rgba(255,255,246,1)');core.addColorStop(0.28,'rgba(255,225,138,0.92)');core.addColorStop(0.62,'rgba(255,168,46,0.48)');core.addColorStop(1,'rgba(255,120,18,0)');
  ctx.fillStyle=core;ctx.beginPath();ctx.arc(0,0,32,0,Math.PI*2);ctx.fill();
  const tex=new THREE.CanvasTexture(canvas);
  if(THREE.SRGBColorSpace)tex.colorSpace=THREE.SRGBColorSpace;
  tex.generateMipmaps=false;tex.minFilter=THREE.LinearFilter;tex.magFilter=THREE.LinearFilter;
  tex.userData={sharedAsset:true};tex.needsUpdate=true;_flashTex=tex;return tex;
}
export function positionGunFlash(gunGroup,holder,cat){
  const flash=gunGroup&&gunGroup.userData&&gunGroup.userData.flash;if(!flash)return null;
  const hud=(holder&&holder.userData)||{};
  const cal=hud.calibration||weaponCalibration(hud.file)||gunGroup.userData.calibration||{};
  const mp=cal.muzzlePos;
  if(Array.isArray(mp)&&mp.length===3&&mp.every(Number.isFinite)){
    const p=new THREE.Vector3(mp[0],mp[1],mp[2]);const rot=hud.rot||{};
    p.applyEuler(new THREE.Euler(rot.x||0,rot.y||0,rot.z||0));
    const pv=hud.pivot||[0,0,0];p.add(new THREE.Vector3(pv[0],pv[1],pv[2]));
    p.applyEuler(new THREE.Euler(-Math.PI/2,0,0)).multiplyScalar(cal.scale||1);flash.position.copy(p);
  }else if(holder&&THREE.Box3){
    const box=new THREE.Box3().setFromObject(holder),size=new THREE.Vector3();box.getSize(size);
    flash.position.set(Math.max(box.max.x,size.x*0.9),0.01,0);
  }else flash.position.set(weaponTargetLength(cat,hud.file)*0.96,0.01,0);
  flash.visible=gunGroup.userData.hasMuzzleFlash!==false;
  return flash;
}

export let WEAPON_METADATA={};
export function setWEAPON_METADATA(v){WEAPON_METADATA=v;}

export let WEAPON_CALIBRATIONS={};
export function setWEAPON_CALIBRATIONS(v){WEAPON_CALIBRATIONS=v;}

export let WEAPON_SOCKETS={};
export function setWEAPON_SOCKETS(v){WEAPON_SOCKETS=v;}

export function weaponCalibration(file){return file&&WEAPON_CALIBRATIONS[file]||null;}


export function weaponMeta(file){
  if(!file)return null;
  const name=(WEAPONS_ORIGINAL[file]||{}).name||'';
  if(WEAPON_METADATA[name])return WEAPON_METADATA[name];
  if(WEAPON_METADATA[file])return WEAPON_METADATA[file];
  const norm=s=>String(s||'').toLowerCase().replace(/[^a-z0-9]/g,'');
  const key=norm(name)||norm(file);
  if(!key)return null;
  for(const [k,v] of Object.entries(WEAPON_METADATA)){
    const nk=norm(k);
    if(nk===key||key.includes(nk)||nk.includes(key))return v;
  }
  return null;
}

export const WEAPON_THUMB_CACHE={};

export let _wThumbR=null;
export function set_wThumbR(v){_wThumbR=v;}

export function renderWeaponThumb(weapon){
  if(WEAPON_THUMB_CACHE[weapon]!==undefined)return WEAPON_THUMB_CACHE[weapon];
  const file=WEAPON_MESH_FILE[weapon];
  if(!file){WEAPON_THUMB_CACHE[weapon]=null;return null;}
  if(!GUN_MESH_CACHE[file])return null;
  WEAPON_THUMB_CACHE[weapon]=weaponCoverURL(weapon);
  return WEAPON_THUMB_CACHE[weapon];
}

export function weaponCoverURL(weapon){
  const file=WEAPON_MESH_FILE[weapon];
  const art=file&&WEAPON_COVER_BY_FILE[file];
  if(art)return 'assets/weapons/covers/'+art+'.png';
  return null;
}

export const GUN_MESH_CACHE={};

export function parseOBJStatic(txt){
  const P=[],UV=[],NO=[],idxMap={};
  const pos=[],uv=[],nor=[],outIdx=[];
  txt.split(/\r?\n/).forEach(line=>{
    const p=line.trim().split(/\s+/);
    if(p[0]==='v')P.push([+p[1],+p[2],+p[3]]);
    else if(p[0]==='vt')UV.push([+p[1],+p[2]]);
    else if(p[0]==='vn')NO.push([+p[1],+p[2],+p[3]]);
    else if(p[0]==='f'){
      for(let i=1;i<p.length;i++){
        const t=p[i].split('/');
        const vi=parseInt(t[0],10)-1,ti=parseInt(t[1],10)-1,ni=parseInt(t[2],10)-1;
        if(!(vi>=0&&P[vi]))continue;
        const key=vi+'/'+ti+'/'+ni;
        if(idxMap[key]==null){
          idxMap[key]=pos.length/3;
          pos.push(P[vi][0],P[vi][1],P[vi][2]);
          if(UV[ti])uv.push(UV[ti][0],UV[ti][1]);else uv.push(0,0);
          if(NO[ni])nor.push(NO[ni][0],NO[ni][1],NO[ni][2]);else nor.push(0,1,0);
        }
        outIdx.push(idxMap[key]);
      }
    }
  });
  let vol=0;
  for(let i=0;i<outIdx.length;i+=3){
    const a=outIdx[i]*3,b=outIdx[i+1]*3,c=outIdx[i+2]*3;
    vol+=(pos[a]*(pos[b+1]*pos[c+2]-pos[b+2]*pos[c+1])-pos[a+1]*(pos[b]*pos[c+2]-pos[b+2]*pos[c])+pos[a+2]*(pos[b]*pos[c+1]-pos[b+1]*pos[c]))/6;
  }
  if(vol<0)for(let i=0;i<outIdx.length;i+=3){const t=outIdx[i+1];outIdx[i+1]=outIdx[i+2];outIdx[i+2]=t;}
  const g=new THREE.BufferGeometry();
  g.setAttribute('position',new THREE.Float32BufferAttribute(pos,3));
  g.setAttribute('uv',new THREE.Float32BufferAttribute(uv,2));
  g.setAttribute('normal',new THREE.Float32BufferAttribute(nor,3));
  g.setIndex(outIdx);
  g.computeVertexNormals();
  return g;
}

export function weaponFileForRef(ref){
  if(!ref)return null;
  if(WEAPON_MESH_FILE[ref])return WEAPON_MESH_FILE[ref];
  if(WEAPONS_ORIGINAL[ref])return ref;
  return /^[\w.-]+$/.test(ref)?ref:null;
}

export function weaponCategoryForFile(file){
  const weapon=Object.keys(WEAPON_MESH_FILE).find(key=>WEAPON_MESH_FILE[key]===file);
  const cat=(WEAPONS[weapon]||{}).cat||(WEAPONS_ORIGINAL[file]||{}).cat||'Fusiles de asalto';
  return String(cat).split(' / ')[0];
}

export function weaponTargetLength(cat,file){
  const cal=file&&weaponCalibration(file);
  if(cal&&Number.isFinite(cal.targetLength)&&cal.targetLength>0)return cal.targetLength;
  return WEAPON_LEN[cat]||0.6;
}

export function gunRotationFor(file,bb,cat){
  const ax=Math.abs(bb.min.x),mx=Math.abs(bb.max.x);
  const ay=Math.abs(bb.min.y),my=Math.abs(bb.max.y);
  const az=Math.abs(bb.min.z),mz=Math.abs(bb.max.z);
  if(file==='RPG')return {x:Math.PI/2,y:0,z:0};
  if(cat==='Cuerpo a cuerpo'){
    if(Math.max(az,mz)>=Math.max(ax,mx)&&Math.max(az,mz)>=Math.max(ay,my))return {x:0,y:mz>=az?Math.PI/2:-Math.PI/2,z:0};
    if(Math.max(ax,mx)>=Math.max(ay,my))return {x:0,y:0,z:mx>=ax?0:Math.PI};
    return {x:0,y:0,z:my>=ay?-Math.PI/2:Math.PI/2};
  }
  return {x:0,y:0,z:ax>mx?Math.PI:0};
}

export function gunRotatedBoundsOf(bb,rot){
  const out=new THREE.Box3();
  const m=new THREE.Matrix4().makeRotationFromEuler(new THREE.Euler(rot.x||0,rot.y||0,rot.z||0));
  for(const x of [bb.min.x,bb.max.x])for(const y of [bb.min.y,bb.max.y])for(const z of [bb.min.z,bb.max.z])
    out.expandByPoint(new THREE.Vector3(x,y,z).applyMatrix4(m));
  return out;
}
export function gunRotatedBounds(geo,rot){return gunRotatedBoundsOf(geo.boundingBox,rot);}

export function gripPointForGun(file,offset){
  const cal=weaponCalibration(file);
  if(!cal||!Array.isArray(offset)||offset.length!==3||!offset.every(Number.isFinite))return {x:0,y:0,z:0};
  const cat=weaponCategoryForFile(file);
  const bb={min:new THREE.Vector3().fromArray(cal.sourceBounds.min),max:new THREE.Vector3().fromArray(cal.sourceBounds.max)};
  const rot=gunRotationFor(file,bb,cat),rb=gunRotatedBoundsOf(bb,rot);
  const pivot=[(rb.min.x>0||rb.max.x<0)?-(rb.min.x+rb.max.x)/2:0,
    (rb.min.y>0||rb.max.y<0)?-(rb.min.y+rb.max.y)/2:0,
    (rb.min.z>0||rb.max.z<0)?-(rb.min.z+rb.max.z)/2:0];
  const p=new THREE.Vector3().fromArray(offset).applyEuler(new THREE.Euler(rot.x||0,rot.y||0,rot.z||0));
  p.x+=pivot[0];p.y+=pivot[1];p.z+=pivot[2];
  p.applyEuler(new THREE.Euler(-Math.PI/2,0,0)).multiplyScalar(cal.scale||1);
  return {x:p.x,y:p.y,z:p.z};
}
export function weaponGrips(file){
  const cal=weaponCalibration(file);
  const grip=gripPointForGun(file,cal&&cal.gripOffset);
  const support=cal&&Array.isArray(cal.supportOffset)?gripPointForGun(file,cal.supportOffset):null;
  return {grip:{x:grip.x,y:grip.y,scale:1},support:support};
}

export function makeRealGun3(ref){
  const file=weaponFileForRef(ref); if(!file)return null;
  const cached=GUN_MESH_CACHE[file]; if(cached!==undefined)return cached;
  GUN_MESH_CACHE[file]=null;
  fetch('assets/weapons/'+file+'.obj').then(r=>{if(!r.ok)throw new Error('obj');return r.text();}).then(txt=>{
    const geo=parseOBJStatic(txt);
    geo.computeBoundingBox();
    const size=new THREE.Vector3();geo.boundingBox.getSize(size);
    const long=Math.max(size.x,size.y,size.z,0.001);
    const cat=weaponCategoryForFile(file);
    const target=weaponTargetLength(cat,file);
    const k=target/long;
    const meta=weaponMeta(file);
    const cal=weaponCalibration(file)||{scale:k,gripOffset:[0,0,0]};
    const rot=gunRotationFor(file,geo.boundingBox,cat);
    const rb=gunRotatedBounds(geo,rot);
    const pivot=[(rb.min.x>0||rb.max.x<0)?-(rb.min.x+rb.max.x)/2:0,
      (rb.min.y>0||rb.max.y<0)?-(rb.min.y+rb.max.y)/2:0,
      (rb.min.z>0||rb.max.z<0)?-(rb.min.z+rb.max.z)/2:0];
    const mat=new THREE.MeshStandardMaterial({color:0xb8b8b8,roughness:0.80,metalness:0.03,transparent:false,opacity:1,depthWrite:true,alphaTest:0,side:THREE.FrontSide});
    const texLoad=new THREE.TextureLoader();
    let resolveTex=null;
    const texReady=new Promise(resolve=>{resolveTex=resolve;});
    texLoad.load('assets/weapons/'+file+'_tex.png',t=>{t.colorSpace=THREE.SRGBColorSpace;t.generateMipmaps=false;t.minFilter=THREE.LinearFilter;t.magFilter=THREE.LinearFilter;t.wrapS=THREE.ClampToEdgeWrapping;t.wrapT=THREE.ClampToEdgeWrapping;t.needsUpdate=true;mat.map=t;mat.color.set(0xffffff);mat.needsUpdate=true;resolveTex(t);},undefined,e=>{console.error('[makeRealGun3:texture]',file,e);resolveTex(null);});
    const mesh=new THREE.Mesh(geo,mat);
    mesh.rotation.set(rot.x,rot.y,rot.z);
    mesh.position.set(pivot[0],pivot[1],pivot[2]);
    const holder=new THREE.Group();
    holder.add(mesh);
    holder.scale.setScalar(cal.scale||k);
    holder.rotation.x=-Math.PI/2;
    const grips=weaponGrips(file);
    holder.userData={file:file,meta:meta||null,calibration:cal,pivot:pivot,rot:rot,grip:grips.grip,support:grips.support,texReady:texReady};
    GUN_MESH_CACHE[file]=holder;
    if(gunSwapWaiters[file]){gunSwapWaiters[file].forEach(fn=>{try{fn(holder);}catch(e){}});gunSwapWaiters[file]=[];}
  }).catch(()=>{delete GUN_MESH_CACHE[file];});
  return null;
}

export const gunSwapWaiters={};

export function attachRealGun(un,gun){
  const file=weaponFileForRef(un&&un.weapon);
  const apply=(holder)=>{
    if(!gun||!gun.parent)return;
    try{
      gun.children.forEach(ch=>{if(ch!==gun.userData.flash&&!(ch.userData&&ch.userData.isFlash))ch.visible=false;});
      const g2=holder.clone(true);
      g2.userData={isRealGun:true,file:holder.userData.file,meta:holder.userData.meta,calibration:holder.userData.calibration,grip:holder.userData.grip,support:holder.userData.support};
      g2.visible=true;
      gun.add(g2);
      gun.scale.setScalar(1);
      gun.visible=true;
      gun.userData.scale=1;
      gun.userData.file=g2.userData.file;
      gun.userData.meta=g2.userData.meta;
      const grips=weaponGrips(file);
      gun.userData.grip=grips.grip;
      gun.userData.support=grips.support;
      if(gun.userData.flash){
        const cat=(WEAPONS[un.weapon]||{}).cat||(file&&String((WEAPONS_ORIGINAL[file]||{}).cat||'').split(' / ')[0])||'Fusiles de asalto';
        positionGunFlash(gun,holder,cat);
      }
    }catch(e){}
  };
  const holder=makeRealGun3(file);
  if(holder)apply(holder);
  else{
    if(!gunSwapWaiters[file])gunSwapWaiters[file]=[];
    gunSwapWaiters[file].push(apply);
  }
}

export function makeGunAnchor(un){
  const gun=new THREE.Group();
  const file=weaponFileForRef(un&&un.weapon);
  const cat=(WEAPONS[un.weapon]||{}).cat||(file&&String((WEAPONS_ORIGINAL[file]||{}).cat||'').split(' / ')[0])||'Fusiles de asalto';
  const profile=originalWeaponProfile(file);
  const hasFlash=!profile||profile.hasMuzzleFlash!==false;
  const flashMat=new THREE.MeshBasicMaterial({map:flashTexture(),color:0xffffff,transparent:true,opacity:0,depthWrite:false,blending:THREE.AdditiveBlending,side:THREE.DoubleSide});
  const flashGeo=new THREE.PlaneGeometry(0.18,0.18);
  const flash=new THREE.Group();
  [[0,0,0],[Math.PI/2,0,0],[0,Math.PI/2,0]].forEach(rot=>{
    const plane=new THREE.Mesh(flashGeo,flashMat);plane.rotation.set(rot[0],rot[1],rot[2]);
    plane.userData.isFlash=true;plane.renderOrder=3;flash.add(plane);
  });
  const flashLight=new THREE.PointLight(0xffb84a,0,2.2);flashLight.userData.isFlashLight=true;flash.add(flashLight);
  flash.position.set(weaponTargetLength(cat,file)*0.96,0.01,0);
  flash.userData.isFlash=true;
  flash.userData.flashLight=flashLight;
  flash.visible=hasFlash;
  gun.add(flash);
  gun.userData.flash=flash;
  gun.userData.flashLight=flashLight;
  gun.userData.hasMuzzleFlash=hasFlash;
  gun.userData.cat=cat;
  const grips=weaponGrips(file);
  gun.userData.grip=grips.grip;
  gun.userData.support=grips.support;
  gun.userData.scale=1;
  gun.scale.setScalar(1);
  return gun;
}
