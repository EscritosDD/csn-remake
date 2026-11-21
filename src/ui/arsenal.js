import { BODIES, ROLES, ROLE_NAMES, roleLook } from '../data/roles.js';
import { WEAPONS } from '../data/weapons.js';
import { makeRealGun3, renderWeaponThumb, weaponCoverURL } from '../render3d/assets-weapons.js';
import { $, rolePortraitURL } from './ui-shell.js';

export const CATS=['Todas','Fusiles de asalto','Subfusiles','Ametralladoras','Francotirador','Escopetas','Lanzacohetes','Lanzagranadas','Pistolas'];
export let arsFilter='Todas';
export function setArsFilter(v){arsFilter=v;}

export function buildArsenal(){
  const f=$('#arsFilters');f.innerHTML='';
  CATS.forEach(c=>{const b=document.createElement('button');b.textContent=c;b.className=c===arsFilter?'on':'';b.onclick=()=>{arsFilter=c;buildArsenal();};f.appendChild(b);});
  const g=$('#arsenalGrid');g.innerHTML='';
  Object.entries(WEAPONS).filter(([n,w])=>arsFilter==='Todas'||w.cat===arsFilter).forEach(([name,w])=>{
    const roles=ROLE_NAMES.filter(r=>ROLES[r].weapons.includes(name)).join(', ')||(w.cat==='Pistolas'?'Todos (secundaria)':'—');
    const d=document.createElement('div');d.className='weapon';
    const cover=weaponCoverURL(name);
    d.innerHTML='<div class="wcoverWrap">'+(cover?('<img class="wcover" src="'+cover+'" alt="" loading="lazy">'):'')+'</div><span class="tag">'+w.cat+'</span><h3>'+name+'</h3><p class="real">'+w.real+'</p><div class="wstats"><div><b>'+w.dmg+'</b><span>Daño</span></div><div><b>'+w.rng+'</b><span>Casillas</span></div><div><b>'+w.cost+' ⚡</b><span>Coste</span></div><div><b style="font-size:12px;padding-top:4px">'+roles.split(',')[0]+'</b><span>Rol</span></div></div><p class="note">'+w.note+(w.once?' <b>Un solo uso por partida.</b>':'')+(w.aoe?' Daño en área.':'')+'</p>';
    g.appendChild(d);
    if(!cover){
      const img=d.querySelector('.wcoverWrap');
      const tryThumb=()=>{const u=renderWeaponThumb(name)||(makeRealGun3(name),renderWeaponThumb(name));if(u&&img){img.innerHTML='<img class="wcover" src="'+u+'" alt="">';}else{setTimeout(tryThumb,700);}};
      setTimeout(tryThumb,500);
    }
  });
  const rt=$('#rolesTable');rt.innerHTML=ROLE_NAMES.map(r=>{const bd=BODIES[ROLES[r].body];return '<div style="display:flex;gap:10px;padding:9px 0;border-bottom:1px dashed var(--line);flex-wrap:wrap;align-items:center"><span class="role-dot" style="background:'+ROLES[r].color+';margin-top:5px"></span>'+(rolePortraitURL(r)?'<img class="role-thumb" src="'+rolePortraitURL(r)+'" alt="Retrato del '+r+'"/>':'')+'<b style="min-width:120px">'+r+'</b><span class="mono" style="font-size:13.5px">'+bd.name+' · '+roleLook(r).silueta+' · '+bd.hp+' PV · '+bd.energy+' ⚡ · mover '+bd.moveCost+' ⚡/casilla</span><span style="flex:1;min-width:220px" class="sub">'+ROLES[r].desc+' Armas: '+ROLES[r].weapons.join(', ')+'.</span></div>';}).join('');
}
