export const COMPETITIVE_MANIFEST_URL='assets/competitive/manifest.json';

export function validateManifest(manifest){
  const errors=[];
  if(!manifest||typeof manifest!=='object'||Array.isArray(manifest))return {ok:false,errors:['El manifest debe ser un objeto JSON.']};
  if(manifest.schemaVersion!==1)errors.push('schemaVersion debe ser 1.');
  if(!Array.isArray(manifest.chars))errors.push('chars debe ser un array.');
  if(!Array.isArray(manifest.weapons))errors.push('weapons debe ser un array.');
  if(!manifest.anims||typeof manifest.anims!=='object'||Array.isArray(manifest.anims))errors.push('anims debe ser un objeto.');
  const seen=new Set();
  const checkEntries=(list,kind)=>{
    if(!Array.isArray(list))return;
    list.forEach((entry,index)=>{
      const where=kind+'['+index+']';
      if(!entry||typeof entry!=='object'||Array.isArray(entry)){errors.push(where+' debe ser un objeto.');return;}
      if(typeof entry.id!=='string'||!entry.id.trim())errors.push(where+'.id es obligatorio.');
      if(typeof entry.file!=='string'||!/\.glb$/i.test(entry.file))errors.push(where+'.file debe terminar en .glb.');
      if(!entry.file||!/^assets\/competitive\/(chars|weapons)\//.test(entry.file)){errors.push(where+'.file debe estar bajo assets/competitive/.');}
      const key=kind+':'+(entry.id||index);
      if(seen.has(key))errors.push(where+'.id duplicado.');
      seen.add(key);
      if(entry.scale!=null&&(!Number.isFinite(entry.scale)||entry.scale<=0))errors.push(where+'.scale debe ser un número positivo.');
      if(entry.anims!=null&&(typeof entry.anims!=='object'||Array.isArray(entry.anims)))errors.push(where+'.anims debe ser un objeto.');
    });
  };
  checkEntries(manifest.chars,'chars');
  checkEntries(manifest.weapons,'weapons');
  return {ok:errors.length===0,errors};
}

export async function loadCompetitiveManifest(url=COMPETITIVE_MANIFEST_URL){
  if(typeof fetch!=='function')throw new Error('loadCompetitiveManifest requiere fetch.');
  const response=await fetch(url);
  if(!response||response.ok===false)throw new Error('No se pudo cargar el manifest competitivo: '+url);
  const manifest=await response.json();
  const validation=validateManifest(manifest);
  if(!validation.ok)throw new Error('Manifest competitivo inválido: '+validation.errors.join('; '));
  return manifest;
}

export function resolveCompetitiveSkin(manifest,id){
  if(!manifest||!Array.isArray(manifest.chars))return null;
  return manifest.chars.find(entry=>entry.id===id)||null;
}

export function resolveCompetitiveWeapon(manifest,id){
  if(!manifest||!Array.isArray(manifest.weapons))return null;
  return manifest.weapons.find(entry=>entry.id===id)||null;
}

export function competitiveAnimationFor(manifest,kind,id,state){
  const entry=kind==='weapons'?resolveCompetitiveWeapon(manifest,id):resolveCompetitiveSkin(manifest,id);
  if(!entry)return null;
  const local=entry.anims&&entry.anims[state];
  if(local)return local;
  return manifest.anims&&manifest.anims[state]||null;
}
