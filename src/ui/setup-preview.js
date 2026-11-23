export function mapPreviewURL(mapId,defs,geo){
  const def=defs&&defs[mapId]||null;
  const entry=geo&&(geo[def&&def.theme]||geo[mapId])||null;
  return entry&&entry.top?entry.top:'assets/ui/modo_eliminacion.png';
}

function previewEsc(v){return String(v==null?'':v).replace(/&/g,'&amp;').replace(/</g,'&lt;').replace(/>/g,'&gt;').replace(/"/g,'&quot;');}

export function squadCardMarkup(opts){
  const role=opts.role||'Comando';
  const weapon=opts.weapon||((opts.ROLES&&opts.ROLES[role]&&opts.ROLES[role].weapons[0])||'M4A1');
  const roleData=opts.ROLES&&opts.ROLES[role]||{};
  const body=opts.BODIES&&opts.BODIES[roleData.body]||{hp:250,energy:14,moveCost:2};
  const w=opts.WEAPONS&&opts.WEAPONS[weapon]||{};
  const hp=(body.hp||0)+(opts.bonusHp||0);
  const energy=(body.energy||0)+(opts.bonusEnergy||0);
  const moveCost=body.moveCost||2;
  const locked=opts.fixedDef?'disabled':'';
  const portrait=opts.portraitURL?opts.portraitURL(role,opts.fixedDef||opts.char,opts.skin):'';
  const cover=opts.weaponURL?opts.weaponURL(weapon):'';
  return '<div class="squad-card" data-slot="'+previewEsc(opts.i)+'" data-team="'+previewEsc(opts.team)+'">'+
    '<div class="sq-card-head"><span class="slot-num">'+(opts.i+1)+'</span>'+
    '<img class="sq-ico" src="'+previewEsc(portrait||'assets/ui/retrato_capitan.png')+'" alt=""/>'+
    '<div class="sq-id"><b class="sq-role">'+previewEsc(role)+'</b><span class="sq-char">'+previewEsc(opts.fixedDef&&opts.fixedDef.charName||(opts.char&&opts.char.name)||'')+'</span>'+
    '<small class="sq-body">'+previewEsc(body.name||'')+' · '+hp+' PV · '+energy+' ⚡</small></div></div>'+
    '<div class="sq-weapon">'+(cover?'<img class="sq-weapon-cover" src="'+previewEsc(cover)+'" alt=""/>':'')+
    '<div><b class="sq-weapon-name">'+previewEsc(weapon)+'</b><span class="sq-weapon-stats">⚡ '+(w.cost==null?'—':w.cost)+' · 💥 '+(w.dmg==null?'—':w.dmg)+' · 🎯 '+(w.rng==null?'—':w.rng)+'</span></div></div>'+
    '<div class="sq-bars"><div><span>PV</span><i class="sq-bar sq-bar-hp"><b style="width:'+Math.min(100,hp/3)+ '%"></b></i><em class="sq-hp">'+hp+'</em></div>'+
    '<div><span>⚡</span><i class="sq-bar sq-bar-en"><b style="width:'+Math.min(100,energy/18*100)+'%"></b></i><em class="sq-en">'+energy+'</em></div>'+
    '<div><span>MOV</span><i class="sq-bar sq-bar-mv"><b style="width:'+(moveCost/3*100)+'%"></b></i><em class="sq-mv">'+moveCost+' ⚡</em></div></div>'+
    '<div class="sq-picks"><label>Rol<select data-kind="role" data-team="'+previewEsc(opts.team)+'" data-slot="'+previewEsc(opts.i)+'" '+locked+'></select></label>'+
    '<label>Arma<select data-kind="weapon" data-team="'+previewEsc(opts.team)+'" data-slot="'+previewEsc(opts.i)+'" '+locked+'></select></label>'+
    '<label>Personaje<select data-kind="char" data-team="'+previewEsc(opts.team)+'" data-slot="'+previewEsc(opts.i)+'" aria-label="Personaje" '+locked+'></select></label></div></div>';
}

export function fillSquadSelects(row,opts){
  const roles=Object.keys(opts.ROLES||{});
  const role=roles.includes(opts.role)?opts.role:(roles[0]||'Comando');
  const rsel=row&&row.querySelector('[data-kind="role"]');
  const wsel=row&&row.querySelector('[data-kind="weapon"]');
  const csel=row&&row.querySelector('[data-kind="char"]');
  const option=(value,label)=>'<option value="'+previewEsc(value)+'">'+previewEsc(label)+'</option>';
  if(rsel)rsel.innerHTML=roles.map(r=>option(r,r)).join('');
  if(rsel)rsel.value=role;
  const weapons=opts.fixedDef?[opts.fixedDef.weapon]:(((opts.ROLES||{})[role]||{}).weapons||[]);
  const weapon=weapons.includes(opts.weapon)?opts.weapon:(weapons[0]||'');
  if(wsel)wsel.innerHTML=weapons.map(w=>option(w,w)).join('');
  if(wsel)wsel.value=weapon;
  const chars=(opts.chars||[]).map(c=>({key:opts.characterKey(c),name:c.name,ref:c}));
  const charOptions=opts.fixedDef&&opts.fixedCharKey?[{key:opts.fixedCharKey,name:opts.fixedDef.charName||opts.fixedDef.role,ref:null}]:chars;
  const charKey=charOptions.some(c=>c.key===opts.selectedCharKey)?opts.selectedCharKey:(charOptions[0]&&charOptions[0].key||'');
  if(csel)csel.innerHTML=charOptions.map(c=>option(c.key,c.name)).join('');
  if(csel)csel.value=charKey;
  return {role,weapon,charKey,chars:charOptions.map(c=>c.ref).filter(Boolean)};
}

export function updateSquadCard(row,opts){
  if(!row)return;
  const rsel=row.querySelector('[data-kind="role"]');
  const wsel=row.querySelector('[data-kind="weapon"]');
  const csel=row.querySelector('[data-kind="char"]');
  const role=rsel&&rsel.value||opts.role||'Comando';
  const weapon=wsel&&wsel.value||opts.weapon||'M4A1';
  const charKey=csel&&csel.value||'';
  const roleData=opts.ROLES&&opts.ROLES[role]||{};
  const body=opts.BODIES&&opts.BODIES[roleData.body]||{hp:250,energy:14,moveCost:2};
  const w=opts.WEAPONS&&opts.WEAPONS[weapon]||{};
  const chars=opts.chars||[];
  const char=chars.find(c=>opts.characterKey(c)===charKey)||opts.fixedDef||null;
  const hp=(body.hp||0)+(opts.bonusHp||0);
  const energy=(body.energy||0)+(opts.bonusEnergy||0);
  const set=(sel,value)=>{const el=row.querySelector(sel);if(el)el.textContent=value;};
  set('.sq-role',role);
  set('.sq-char',opts.fixedDef&&opts.fixedDef.charName||(char&&char.name)||'');
  set('.sq-body',(body.name||'')+' · '+hp+' PV · '+energy+' ⚡');
  set('.sq-weapon-name',weapon);
  set('.sq-weapon-stats','⚡ '+(w.cost==null?'—':w.cost)+' · 💥 '+(w.dmg==null?'—':w.dmg)+' · 🎯 '+(w.rng==null?'—':w.rng));
  set('.sq-hp',hp);
  set('.sq-en',energy);
  set('.sq-mv',(body.moveCost||2)+' ⚡');
  const portrait=row.querySelector('.sq-ico');
  if(portrait)portrait.src=opts.portraitURL?opts.portraitURL(role,char||opts.fixedDef,opts.skin)||'assets/ui/retrato_capitan.png':'assets/ui/retrato_capitan.png';
  const cover=row.querySelector('.sq-weapon-cover');
  if(cover&&opts.weaponURL)cover.src=opts.weaponURL(weapon)||'';
  const hpBar=row.querySelector('.sq-bar-hp b'),enBar=row.querySelector('.sq-bar-en b'),mvBar=row.querySelector('.sq-bar-mv b');
  if(hpBar)hpBar.style.width=Math.min(100,hp/3)+'%';
  if(enBar)enBar.style.width=Math.min(100,energy/18*100)+'%';
  if(mvBar)mvBar.style.width=((body.moveCost||2)/3*100)+'%';
  row.dataset.role=role;
  row.dataset.weapon=weapon;
}
