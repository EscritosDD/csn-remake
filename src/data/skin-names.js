const VARIANTS=[
  ['DeltaForce','Delta Force'],
  ['DeerHunter','Deer Hunter'],
  ['GermanSpecialForces','Fuerzas especiales alemanas'],
  ['JewelThief','Ladrona'],
  ['Spetsnaz','Spetsnaz'],
  ['Halloween','Halloween'],
  ['Decon','Decon'],
  ['EOD','EOD'],
  ['Rescue','Rescate'],
  ['Trinity','Trinity'],
  ['Surgeon',' Cirujana'],
  ['Veteran','Veterano'],
  ['African','Africana'],
  ['Asian','Asiática'],
  ['Latino','Latino'],
  ['ForestCamo',' Camuflaje forestal'],
  ['Skin1',' Alternativa']
];

export function prettySkinName(file,index){
  const raw=String(file||'').trim();
  const base=raw.replace(/\.png$/i,'').replace(/_d$/i,'');
  if(!base)return 'Estándar '+(Number(index)+1);
  for(const [needle,label] of VARIANTS){
    if(base.toLowerCase().includes(needle.toLowerCase()))return label.trim();
  }
  const tokens=base.split('_');
  if(tokens.length<3||/^Soldier(_Light)?$|^Agent_light$/i.test(base))return 'Estándar';
  const last=tokens[tokens.length-1];
  return String(last).replace(/([a-z])([A-Z])/g,'$1 $2').trim()||'Estándar '+(Number(index)+1);
}
