import { validatedRigBoneInverses } from '../render3d/assets-meshy.js';

export const VIEWER_BODY_SKINS={ 'Soldier_SAS':['Soldier_SAS_d.png','Soldier_SAS_Decon_d.png','Soldier_SAS_Veteran_d.png'],
  'Soldier_Spud':['Soldier_d.png','Soldier_Decon_d.png','Soldier_ForestCamo_d.png','Soldier_Veteran_d.png'],
  'Soldier_Light':['Soldier_Light_d.png','Soldier_Light_Decon_d.png','Soldier_Light_DeltaForce_d.png','Soldier_Light_Halloween_d.png','Soldier_Light_Spetsnaz_d.png','Soldier_Light_Veteran_d.png'],
  'Soldier_Light_Rambo':['Soldier_Light_Rambo_d.png','Soldier_Light_Rambo_Decon_d.png','Soldier_Light_Rambo_DeerHunter_d.png','Soldier_Light_Rambo_Veteran_d.png'],
  'Soldier_Heavy':['Soldier_heavy_d.png','Soldier_heavy_GermanSpecialForces_d.png','Soldier_Heavy_Decon_d.png','Soldier_Heavy_Veteran_d.png','Soldier_Heavy_Lumberjack_d.png','Soldier_Heavy_Lumberjack_Football_d.png'],
  'SO_Lief':['Soldier_Heavy_Lumberjack_d.png','Soldier_Heavy_Lumberjack_Football_d.png'],
  'Agent':['Agent_d.png','Agent_Aviator_d.png','Agent_Decon_d.png','Agent_Halloween_d.png','Agent_Spetsnaz_d.png','Agent_Veteran_d.png'],
  'Agent_Light':['Agent_light_d.png','Agent_light_Decon_d.png','Agent_light_JewelThief_d.png','Agent_light_Veteran_d.png','Agent_light_Tesla_d.png','Agent_light_Tesla_Scientist_d.png'],
  'TommyTesla':['Agent_light_Tesla_d.png','Agent_light_Tesla_Scientist_d.png'],
  'Agent_Heavy':['Agent_Heavy_d.png','Agent_Heavy_Decon_d.png','Agent_Heavy_Skin1_d.png','Agent_Heavy_Veteran_d.png'],
  'Medic':['Medic_d.png','Medic_Decon_d.png','Medic_Halloween_d.png','Medic_Rescue_d.png','Medic_Spetsnaz_d.png','Medic_Veteran_d.png'],
  'Medic_therapist':['Medic_Therapist_d.png','Medic_Therapist_Decon_d.png','Medic_Therapist_Surgeon_d.png','Medic_Therapist_Veteran_d.png'],
  'Medic_therapist_959v':['Medic_Heavy_d.png','Medic_Heavy_Decon_d.png','Medic_Heavy_Skin1_d.png','Medic_Heavy_Veteran_d.png'],
  'Engineer':['Engineer_d.png','Engineer_Decon_d.png','Engineer_Halloween_d.png','Engineer_Spetsnaz_d.png','Engineer_Veteran_d.png'],
  'Engineer_Light':['Engineer_Light_d.png','Engineer_Light_Decon_d.png','Engineer_Light_Trinity_d.png','Engineer_Light_Veteran_d.png'],
  'Engineer_Heavy':['Engineer_Heavy2_d.png','Engineer_Heavy_Decon_d.png','Engineer_Heavy_EOD_d.png','Engineer_Heavy_Veteran_d.png'],
  'Engineer (RiotCop)':['Engineer_RiotCop_d.png','Engineer_RiotCop_Decon_d.png','Engineer_RiotCop_Skin1_d.png','Engineer_RiotCop_Veteran_d.png'],
  'Commander':['Commander_d.png','Commander_African_d.png','Commander_Asian_d.png','Commander_Latino_d.png'],
  'CommanderM':['Commander_d.png','Commander_African_d.png','Commander_Asian_d.png','Commander_Latino_d.png'],
  'Commander_F':['Commander_F_d.png','Commander_F_African_d.png','Commander_F_Asian_d.png','Commander_F_Latino_d.png'] };
export const VIEWER_ROLE_FALLBACK={'Riot Medic':'Médico','Megan McNick':'Ingeniero','Carlito Grosso':'Ingeniero', 'Riot Engineer':'Ingeniero','Commander (F)':'Capitán'};
export const VIEWER_BODY_FILE={ 'Soldier_SAS':'Soldier_SAS.obj', 'Soldier_Spud':'Soldier_Spud.obj', 'Soldier_Heavy':'Soldier_Heavy.obj', 'SO_Lief':'SO_Lief.obj', 'Soldier_Light_Rambo':'Soldier_Light_Rambo.obj',
  'Soldier_Light':'Soldier_Light.obj', 'Agent':'Agent.obj', 'Agent_Light':'Agent_Light.obj', 'Agent_Heavy':'Agent_Heavy.obj', 'TommyTesla':'TommyTesla.obj',
  'Medic':'Medic.obj', 'Medic_therapist':'Medic_therapist_1248v.obj', 'Medic_therapist_959v':'Medic_therapist_959v.obj',
  'Engineer':'Engineer.obj', 'Engineer_Light':'Engineer_Light.obj', 'Engineer_Heavy':'Engineer_Heavy.obj',
  'Engineer (RiotCop)':'Engineer_RiotCop.obj', 'CommanderM':'CommanderM.obj', 'Commander_F':'CommanderF.obj' };
export const VIEWER_BODY_OVERRIDE={'Archie Fletcher':'Soldier_Light_Rambo','Commander (M)':'CommanderM'};
export const VIEWER_BODY_ROLE={'Medic':'Médico','Engineer':'Ingeniero','Agent_Heavy':'Comando','Commander':'Capitán'};
export const VIEWER_CARD_PRESENTATION={'Ivan Tkilya':{spinX:0.06,spinY:-2.24,elevation:0.16,fillRatio:0.82,lights:[2.35,2.95,1.65],rim:1.5}};

export function blMul(a,b){
  const o=new Array(16);
  for(let r=0;r<4;r++)for(let c=0;c<4;c++){let s=0;for(let k=0;k<4;k++)s+=a[r*4+k]*b[k*4+c];o[r*4+c]=s;}
  return o; }
export function blInvertRigid(m){
  const o=new Array(16);
  for(let r=0;r<3;r++)for(let c=0;c<3;c++)o[r*4+c]=m[c*4+r];
  const t=[m[3],m[7],m[11]];
  o[3]=-(o[0]*t[0]+o[1]*t[1]+o[2]*t[2]);
  o[7]=-(o[4]*t[0]+o[5]*t[1]+o[6]*t[2]);
  o[11]=-(o[8]*t[0]+o[9]*t[1]+o[10]*t[2]);
  o[12]=0;o[13]=0;o[14]=0;o[15]=1;
  return o; }
export function blWorldMatrices(bones){
  const out=new Array(bones.length),done=new Array(bones.length).fill(false);
  const build=i=>{ if(done[i])return out[i]; const b=bones[i],q=b.quat||[0,0,0,1],s=b.scale||[1,1,1],p=b.pos||[0,0,0];
    const n=Math.hypot(q[0],q[1],q[2],q[3])||1,x=q[0]/n,y=q[1]/n,z=q[2]/n,w=q[3]/n;
    const xx=x*x,yy=y*y,zz=z*z,xy=x*y,xz=x*z,yz=y*z,wx=w*x,wy=w*y,wz=w*z;
    const local=[(1-2*(yy+zz))*s[0],2*(xy-wz)*s[1],2*(xz+wy)*s[2],p[0],
      2*(xy+wz)*s[0],(1-2*(xx+zz))*s[1],2*(yz-wx)*s[2],p[1],
      2*(xz-wy)*s[0],2*(yz+wx)*s[1],(1-2*(xx+yy))*s[2],p[2],0,0,0,1];
    out[i]=b.parent>=0?blMul(build(b.parent),local):local;done[i]=true;return out[i]; };
  for(let i=0;i<bones.length;i++)build(i);
  return out; }
export function rigBindError(world,inverse){
  let maxError=0;
  for(let r=0;r<4;r++)for(let c=0;c<4;c++){let sum=0;for(let k=0;k<4;k++)sum+=world[k*4+r]*inverse[c*4+k];
    maxError=Math.max(maxError,Math.abs(sum-(r===c?1:0)));}
  return maxError; }
export function scaledRigInverse(inverse,scale){
  if(scale===1||!inverse)return inverse;
  const out=inverse.slice();out[3]*=scale;out[7]*=scale;out[11]*=scale;return out; }
export function matrix4ToArray(m){
  const e=m.elements;
  return [e[0],e[4],e[8],e[12],e[1],e[5],e[9],e[13],e[2],e[6],e[10],e[14],e[3],e[7],e[11],e[15]]; }
export function scaleRigForGeometry(rig,scale,three){
  if(!rig||!rig.bones||!rig.boneInverses||scale===1)return {rig:rig,maxError:0};
  const bones=rig.bones.map(b=>Object.assign({},b,{pos:b.pos.map(v=>v*scale)}));
  const data=Object.assign({},rig,{bones,boneInverses:rig.boneInverses.map(a=>scaledRigInverse(a,scale))});
  const worlds=blWorldMatrices(bones);
  let maxError=0;data.skinBones.forEach((bi,i)=>{maxError=Math.max(maxError,rigBindError(worlds[bi],data.boneInverses[i]));});
  if(maxError>0.001)data.skinBones.forEach((bi,i)=>{data.boneInverses[i]=blInvertRigid(worlds[bi]);});
  if(three&&three.Bone&&three.Quaternion&&three.Vector3&&three.Matrix4){
    try{
      const joints=bones.map((b,i)=>{const bone=new three.Bone();bone.name=b.name;bone.position.fromArray(b.pos);
        bone.quaternion.set(b.quat[0],b.quat[1],b.quat[2],b.quat[3]).normalize();if(b.scale)bone.scale.fromArray(b.scale);return bone;});
      bones.forEach((b,i)=>{if(b.parent>=0)joints[b.parent].add(joints[i]);});
      bones.forEach((b,i)=>{if(b.parent<0)joints[i].updateMatrixWorld(true);});
      const validated=validatedRigBoneInverses(data,joints);
      data.boneInverses=validated.map(matrix4ToArray);
      maxError=0;data.skinBones.forEach((bi,i)=>{maxError=Math.max(maxError,rigBindError(matrix4ToArray(joints[bi].matrixWorld),data.boneInverses[i]));});
    }catch(e){}
  }
  return {rig:data,maxError}; }

export function createBodyLoader(ctx){
  const cache=ctx.cache,rigCache=ctx.rigCache,parse=ctx.parse,three=ctx.three;
  return async function loadViewerBody(file){
    const path='assets/soldier/bodies/'+file;
    if(cache[path])return cache[path];
    const rigPath=path.replace(/\.obj$/,'_rig.json');
    const [response,rigResponse]=await Promise.all([fetch(path),fetch(rigPath)]);
    if(!response.ok)throw new Error('No se pudo cargar el cuerpo '+file);
    const text=await response.text(); let count=0;
    for(const line of text.split('\n')){if(line.startsWith('v '))count++;}
    const sourceRig=rigResponse.ok?await rigResponse.json():null;
    const hasRig=!!(sourceRig&&sourceRig.bones&&sourceRig.skinIndex&&sourceRig.skinIndex.length===count*4&&sourceRig.skinWeight&&sourceRig.skinWeight.length===count*4);
    const skin=hasRig?{skinIndex:sourceRig.skinIndex,skinWeight:sourceRig.skinWeight}:{skinIndex:new Array(count*4).fill(0),skinWeight:new Array(count*4).fill(0)};
    const geo=parse(text,skin); const pos=geo.attributes.position.array; const zs=[]; for(let i=2;i<pos.length;i+=3)zs.push(pos[i]); zs.sort((a,b)=>a-b);
    const p95=zs[Math.floor(zs.length*0.95)]||1; const scale=1.14/p95; if(scale!==1)geo.scale(scale,scale,scale);
    cache[path]=geo;
    if(hasRig)rigCache[path]=scale!==1?scaleRigForGeometry(sourceRig,scale,three).rig:sourceRig;
    return geo; }; }
