import { loadCompetitiveManifest } from '../data/catalog-competitive.js';
import { playOnce, crossFadeTo } from '../render3d/actor-glb.js';

const labState={kind:'chars',url:'',label:'',actor:null,manifest:null};
const labEsc=value=>String(value==null?'':value).replace(/[&<>"]/g,char=>({'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;'}[char]));

export function getGlbLabState(){return labState;}

export function setGlbLabActor(actor){labState.actor=actor||null;}

export function playGlbAction(action){
  if(!labState.actor)return null;
  if(action==='fire')return playOnce(labState.actor,'fire');
  return crossFadeTo(labState.actor,action,0.18,true);
}

export async function openGlbLab(kind='chars',url='',label=''){
  labState.kind=kind==='weapons'?'weapons':'chars';
  labState.url=url||labState.url;
  labState.label=label||labState.label||(labState.kind==='weapons'?'Laboratorio de arma .glb':'Laboratorio de personaje .glb');
  const inspector=typeof window!=='undefined'?window.__csnInspector:null;
  if(!inspector||!inspector.open)return false;
  const spec={kind:'glb',key:'glb:'+labState.kind,glbUrl:labState.url,label:labState.label,inspect:true,labKind:labState.kind};
  const opened=await inspector.open(spec);
  if(!opened)return false;
  const panel=document.getElementById('inspectorPanel');
  if(panel)await mountGlbLab(panel,{kind:labState.kind,url:labState.url,label:labState.label});
  return true;
}

export async function mountGlbLab(container,options={}){
  if(!container)return null;
  labState.kind=options.kind==='weapons'?'weapons':'chars';
  if(options.url!=null)labState.url=options.url;
  if(options.label)labState.label=options.label;
  if(!labState.manifest){
    try{labState.manifest=await loadCompetitiveManifest();}catch(error){labState.manifest={chars:[],weapons:[],anims:{}};}
  }
  const entries=(labState.kind==='weapons'?labState.manifest.weapons:labState.manifest.chars)||[];
  const stats=labState.actor&&labState.actor.stats||{};
  const host=document.createElement('div');
  host.className='glb-lab';
  host.innerHTML='<h3>Laboratorio .glb</h3>'+
    '<p class="note sub">Modelo competitivo sin tocar los prototipos IPA ni Meshy. Se reutiliza el renderer del inspector.</p>'+
    '<label class="glb-lab-field"><span>Modelo del manifest</span><select data-glb-entry><option value="">Seleccionar…</option>'+entries.map(entry=>'<option value="'+labEsc(entry.file)+'"'+(entry.file===labState.url?' selected':'')+'>'+labEsc(entry.label||entry.id)+'</option>').join('')+'</select></label>'+
    '<label class="glb-lab-field"><span>Archivo local .glb</span><input type="file" accept=".glb,model/gltf-binary" data-glb-file/></label>'+
    '<label class="glb-lab-field"><span>Ruta .glb</span><input type="text" data-glb-url value="'+labEsc(labState.url)+'" placeholder="assets/competitive/chars/nombre.glb"/></label>'+
    '<div class="glb-lab-actions"><button type="button" class="btn" data-glb-load>📥 Cargar .glb</button>'+
    ['idle','walk','fire','hit','death','victory'].map(action=>'<button type="button" class="btn ghost" data-glb-play="'+action+'">'+action+'</button>').join('')+'</div>'+
    '<p class="note sub" data-glb-status>'+labEsc(labState.label)+(stats.animations!=null?' · '+stats.animations+' clips · '+stats.triangles+' tris':' · sin modelo cargado')+'</p>';
  container.appendChild(host);
  const input=host.querySelector('[data-glb-url]');
  const entry=host.querySelector('[data-glb-entry]');
  const status=host.querySelector('[data-glb-status]');
  if(entry)entry.onchange=()=>{if(entry.value&&input)input.value=entry.value;};
  const file=host.querySelector('[data-glb-file]');
  if(file)file.onchange=()=>{
    const chosen=file.files&&file.files[0];
    if(!chosen||typeof URL==='undefined'||typeof URL.createObjectURL!=='function')return;
    labState.url=URL.createObjectURL(chosen);
    labState.label=chosen.name;
    if(input)input.value=labState.url;
    if(status)status.textContent=chosen.name;
  };
  const load=host.querySelector('[data-glb-load]');
  if(load)load.onclick=()=>{
    const url=input&&input.value.trim();
    if(!url){if(status)status.textContent='Selecciona un archivo o una ruta .glb.';return;}
    openGlbLab(labState.kind,url,labState.label).catch(error=>{if(status)status.textContent=String(error&&error.message||error);});
  };
  host.querySelectorAll('[data-glb-play]').forEach(button=>{button.onclick=()=>playGlbAction(button.dataset.glbPlay);});
  return host;
}

if(typeof window!=='undefined'&&!window.__csnGlbLab)window.__csnGlbLab={open:openGlbLab,mount:mountGlbLab,play:playGlbAction,state:getGlbLabState};
