import { lsGet, lsSet } from '../core-and-audio.js';
import { CAST_TEXTURE_FILE, MESHY_CAST, OWN_CAST, ORIG_CAST } from '../data/cast.js';

export const LS_CHARS='csn_chars_v1';
export const CLASS_ORDER=['Soldier_Light','Soldier_Heavy','Agent_Light','Medic','Engineer','Agent_Heavy','Commander'];
export let CHAR_PREFS={};
export function setCHAR_PREFS(v){CHAR_PREFS=v;}

export function loadChars(){try{const r=JSON.parse(lsGet(LS_CHARS)||'{}');if(!r||typeof r!=='object'||Array.isArray(r))return {};const out={};for(const role of Object.keys(r)){const v=r[role];if(typeof v!=='string')continue;if(charsForRole(role).some(c=>c.name===v||c.key===v))out[role]=v;}return out;}catch(e){return {};}}

export function saveChars(v){try{lsSet(LS_CHARS,JSON.stringify(v));}catch(e){}}

export function CAST_BODIES(){
  const seen=[];OWN_CAST.concat(ORIG_CAST).forEach(c=>{if(!seen.includes(c.body))seen.push(c.body);});
  return seen.sort((a,b)=>{const ia=CLASS_ORDER.indexOf(a),ib=CLASS_ORDER.indexOf(b);return (ia<0?99:ia)-(ib<0?99:ib);});
}

export const ROLE_BODY={'Francotirador':'Soldier_Light','Artillero':'Soldier_Heavy','Espía':'Agent_Light','Médico':'Medic','Ingeniero':'Engineer','Comando':'Agent_Heavy','Capitán':'Commander'};

export function charsForRole(role,origOnly){
  const orig=ORIG_CAST.filter(c=>c.play&&c.role===role).map(c=>Object.assign({},c,{texture:CAST_TEXTURE_FILE[c.name]||''}));
  if(origOnly)return orig;
  const meshy=MESHY_CAST.filter(c=>c.play&&c.role===role);
  const own=OWN_CAST.filter(c=>c.role===role);
  return orig.concat(meshy).concat(own);
}

export function characterForRole(role,slot,origOnly){
  const opts=charsForRole(role,origOnly);if(!opts.length)return null;
  const prefs=(typeof CHAR_PREFS!=='undefined'&&CHAR_PREFS)?CHAR_PREFS:{};
  const chosen=opts.find(c=>c.name===prefs[role]||c.key===prefs[role]);
  return chosen||opts[slot%opts.length];
}

export function characterKey(ch){return ch?(ch.key||((ch.own?'own:':'original:')+ch.name)):'';}
