import { CAMPAIGN_MISSIONS, CAMPAIGN_CHAPTERS, TUTORIAL_MISSION, MAP_DEFS, SKIRMISH_GEO, radioLines, rosterKey } from '../data/maps.js';
import { mapPreviewURL } from './setup-preview.js';
import { tallyStars, campaignObjectiveLabel, nextMissionIndex } from './campaign-tally.js';

const CAMPAIGN_CITIES=[
  {id:'london',name:'Londres',sub:'Capítulos 1–4 · Operación Londres',from:0,to:55,chapters:[0,1,2,3]},
  {id:'rio',name:'Río',sub:'Capítulos 5–7 · Operación Río',from:56,to:91,chapters:[4,5,6]},
  {id:'final',name:'Pruebas individuales',sub:'Capítulo 8',from:92,to:108,chapters:[7]},
];
let campaignMapView='world';
let campaignMapProgress={next:0,done:false,medals:[]};

export function setCampaignMapView(view){
  campaignMapView=CAMPAIGN_CITIES.some(c=>c.id===view)?view:'world';
  renderCampaignMap(campaignMapProgress);
}

function missionState(c,i){
  if(c.done||i<c.next)return 'done';
  if(i===c.next)return 'current';
  return 'locked';
}

function cityProgress(c,city){
  let done=0;
  for(let i=city.from;i<=city.to;i++)if(c.done||i<c.next)done++;
  return done+'/'+(city.to-city.from+1);
}

function campaignMapWorldMarkup(c){
  const cities=CAMPAIGN_CITIES.map(city=>{
    const done=cityProgress(c,city);
    const locked=!c.done&&c.next<city.from;
    return '<button class="cmap-city'+(locked?' locked':'')+'" type="button" data-cmap-city="'+city.id+'"'+(locked?' disabled':'')+'>'+
      '<span class="cmap-city-pin">●</span><b>'+esc(city.name)+'</b><small>'+esc(city.sub)+'</small><span class="cmap-city-prog">'+done+' superadas</span>'+(locked?'<span class="ch-lock" aria-hidden="true">🔒</span>':'')+'</button>';
  }).join('');
  return '<div class="campaign-map world"><div class="cmap-globe"><img src="assets/ui/original/GeoEarth_01.png" alt="Mapa del mundo"/><p class="cmap-globe-cap">TOMA MISIONES POR TODO EL MUNDO</p></div><div class="cmap-cities">'+cities+'</div><p class="sub cmap-hint">Elige una ciudad para ver sus misiones. La siguiente misión está marcada en vino.</p></div>';
}

function campaignMapCityMarkup(c,city){
  const nodes=city.chapters.map(ci=>{
    const ch=CAMPAIGN_CHAPTERS[ci];
    if(!ch)return '';
    let out='<h4 class="cmap-chapter">'+esc(ch.name)+'</h4><div class="cmap-path">';
    for(let i=ch.from;i<=ch.to;i++){
      const m=CAMPAIGN_MISSIONS[i];
      const state=missionState(c,i);
      const stars=c.medals&&c.medals[i]||0;
      out+='<button class="cmap-node '+state+'" type="button" data-campaign-brief="'+i+'"'+(state==='locked'?' disabled':'')+' title="Misión '+(i+1)+' · '+esc(m?m.title:'')+'">'+
        '<span class="cmap-node-num">'+(state==='done'?'✓':(i+1))+'</span>'+
        '<span class="cmap-node-stars">'+tallyStars(stars)+'</span>'+
        (state==='locked'?'<span class="ch-lock" aria-hidden="true">🔒</span>':'')+'</button>';
    }
    return out+'</div>';
  }).join('');
  return '<div class="campaign-map city"><div class="cmap-city-head"><button class="btn ghost" type="button" data-cmap-city="world">← Mapa del mundo</button><h3>'+esc(city.name)+'</h3><span class="sub">'+esc(city.sub)+' · '+cityProgress(c,city)+' superadas</span></div>'+nodes+'</div>';
}

export function renderCampaignMap(progress){
  const list=document.getElementById('campaignList');
  if(!list)return;
  const c=progress||campaignMapProgress;
  campaignMapProgress=c;
  const city=CAMPAIGN_CITIES.find(x=>x.id===campaignMapView);
  list.className='campaign-map-wrap';
  list.innerHTML=city?campaignMapCityMarkup(c,city):campaignMapWorldMarkup(c);
  list.querySelectorAll('[data-cmap-city]').forEach(b=>{
    b.onclick=()=>{setCampaignMapView(b.dataset.cmapCity);};
  });
}

let radioMissionId=TUTORIAL_MISSION.id;
let radioIndex=0;
let campaignActions={};
let currentBrief=-1;

function esc(s){return String(s==null?'':s).replace(/&/g,'&amp;').replace(/</g,'&lt;').replace(/>/g,'&gt;').replace(/"/g,'&quot;');}

export function starMarkup(n){const v=Math.max(0,Math.min(3,n|0));return '★★★'.slice(0,v)+'☆☆☆'.slice(0,3-v);}

export function radioMarkup(mission,index){
  const lines=radioLines(mission&&mission.id);
  if(!lines.length)return '';
  const at=((index|0)%lines.length+lines.length)%lines.length;
  return '<div class="radio-head"><span class="radio-dot"></span><b>Radio de Operación Londres</b><span class="sub">Línea '+(at+1)+' / '+lines.length+'</span></div><p class="radio-line">'+esc(lines[at])+'</p>';
}

export function setRadioMission(id){
  if(radioMissionId!==id){radioMissionId=id;radioIndex=0;}
}

export function renderCampaignRadio(containerId,mission){
  const el=document.getElementById(containerId);
  if(!el)return;
  setRadioMission(mission&&mission.id||TUTORIAL_MISSION.id);
  el.innerHTML=radioMarkup(mission,radioIndex);
}

export function cycleCampaignRadio(containerId,mission){
  const lines=radioLines(mission&&mission.id||radioMissionId);
  if(!lines.length)return;
  setRadioMission(mission&&mission.id||radioMissionId);
  radioIndex=(radioIndex+1)%lines.length;
  renderCampaignRadio(containerId,mission);
  return lines[radioIndex];
}

export function renderTutorialStep(step,index,total){
  const root=document.getElementById('tutorialPanel');
  if(!root)return;
  const title=document.getElementById('tutorialTitle');
  const text=document.getElementById('tutorialText');
  const count=document.getElementById('tutorialCount');
  if(title)title.textContent=step&&step.title||'Instrucción de Dave';
  if(text)text.textContent=step&&step.text||'';
  if(count)count.textContent=(index+1)+' / '+(total||1);
  root.style.display='block';
  root.dataset.step=step&&step.id||'';
}

export function hideTutorialStep(){
  const root=document.getElementById('tutorialPanel');
  if(root)root.style.display='none';
}

export function tutorialHint(text){
  const t=document.getElementById('tutorialText');
  if(t&&text)t.textContent=text;
}

export function briefingMarkup(mission,index,progress){
  if(!mission)return '<h2>Sin misión</h2>';
  const tutorial=index<0;
  const done=tutorial?(progress&&progress.tutorialDone?3:0):(progress&&progress.medals&&progress.medals[index]||0);
  const roster=(list)=>list.map(r=>'<li><b>'+esc(r.charName)+'</b> · '+esc(r.role)+' · '+esc(r.weapon)+'</li>').join('');
  const label=tutorial?'Fase 0 · Instrucción':'Misión '+(index+1)+' de '+CAMPAIGN_MISSIONS.length;
  const limit=tutorial?'Sin límite de rondas':'3 ★ con 0 bajas en '+mission.turnLimit+' rondas.';
  const thumb=mapPreviewURL(mission.map,MAP_DEFS,SKIRMISH_GEO);
  return '<div class="briefWrap"><div class="brief-hero"><img src="'+esc(thumb)+'" alt=""/><div><span class="tag amber">'+esc(label)+'</span><h2>'+esc(mission.title)+'</h2><p>'+esc(mission.brief)+'</p><div class="brief-badges"><span>'+esc(campaignObjectiveLabel(mission.objective))+'</span><span>'+mission.playerRoster.length+' vs '+mission.enemyRoster.length+'</span><span>IA '+esc(mission.difficulty)+'</span></div></div></div>'+radioMarkup(mission,radioIndex)+'<div class="brief-grid"><div><h3>Tu escuadra</h3><ul>'+roster(mission.playerRoster)+'</ul></div><div><h3>Rival</h3><ul>'+roster(mission.enemyRoster)+'</ul></div></div><p class="sub">Medallas: '+tallyStars(done)+' · '+esc(limit)+'</p></div>';
}

export function setCampaignActions(actions){campaignActions=actions||{};}

export function showMissionBriefing(index){
  const a=campaignActions;
  if(!a||!a.showModal)return;
  const idx=Number(index);
  const tutorial=!Number.isInteger(idx)||idx<0;
  currentBrief=tutorial?-1:idx;
  const mission=tutorial?TUTORIAL_MISSION:CAMPAIGN_MISSIONS[idx];
  if(!mission)return;
  const progress=a.getProgress?a.getProgress():null;
  setRadioMission(mission.id);
  const buttons=tutorial
    ? '<button class="btn primary big" id="briefDeploy" type="button">▶ Iniciar instrucción</button>'
    : '<button class="btn primary big" id="briefDeploy" type="button">▶ Desplegar misión</button>';
  a.showModal(briefingMarkup(mission,currentBrief,progress)+'<div class="brief-actions">'+buttons+'<button class="btn big" id="briefClose" type="button">Cerrar</button></div>');
  const box=document.getElementById('modalBox');
  if(box)box.classList.add('brief-modal');
  const deploy=document.getElementById('briefDeploy');
  if(deploy)deploy.onclick=()=>{
    if(box)box.classList.remove('brief-modal');
    if(a.closeModal)a.closeModal();
    if(tutorial&&a.startTutorial)a.startTutorial();
    else if(!tutorial&&a.deployMission)a.deployMission(idx);
  };
  const close=document.getElementById('briefClose');
  if(close)close.onclick=()=>{if(box)box.classList.remove('brief-modal');if(a.closeModal)a.closeModal();};
  try{if(a.audio)a.audio({name:'Hipster Dave',role:'Comando'},'select',0.45);}catch(e){}
}

export function renderCampaignRadioForHub(mission){
  renderCampaignRadio('campaignRadio',mission);
}

export function wireCampaignUI(ctx){
  setCampaignActions(ctx);
  const openView=()=>{if(ctx.showCampaignView)ctx.showCampaignView();else{const p=document.getElementById('campaignPanel');if(p){p.style.display='block';renderCampaignPanelSafe(ctx);}}};
  const cb=document.getElementById('campaignBtn');if(cb)cb.onclick=openView;
  const ch=document.getElementById('mnuChallenges');if(ch)ch.onclick=openView;
  const br=document.getElementById('campaignHubBack');if(br)br.onclick=()=>{if(ctx.hideCampaignView)ctx.hideCampaignView();};
  const cont=document.getElementById('campaignContinue');if(cont)cont.onclick=()=>{const c=ctx.getProgress?ctx.getProgress():null;showMissionBriefing(c&&!c.done?c.next:0);};
  const nextBtn=document.getElementById('campaignNextBtn');if(nextBtn)nextBtn.onclick=()=>{const c=ctx.getProgress?ctx.getProgress():null;const idx=nextMissionIndex(c,CAMPAIGN_MISSIONS);if(ctx.deployMission)ctx.deployMission(idx);};
  const tut=document.getElementById('campaignTutorial');if(tut)tut.onclick=()=>showMissionBriefing(-1);
  const tutBtn=document.getElementById('tutorialBtn');if(tutBtn)tutBtn.onclick=()=>showMissionBriefing(-1);
  const reset=document.getElementById('campaignResetBtn');if(reset)reset.onclick=()=>{
    if(!ctx.showModal)return;
    ctx.showModal('<h2>¿Reiniciar la campaña?</h2><p>Se borrarán medallas, veterania y misiones superadas de este dispositivo. La instrucción de Dave no se borra.</p><div class="brief-actions"><button class="btn danger big" id="campaignResetConfirm" type="button">Reiniciar progreso</button><button class="btn big" id="campaignResetCancel" type="button">Cancelar</button></div>');
    const yes=document.getElementById('campaignResetConfirm');
    if(yes)yes.onclick=()=>{
      const c=ctx.getProgress?ctx.getProgress():null;
      if(ctx.saveCampaign)ctx.saveCampaign({next:0,vet:[],done:false,tutorialDone:c?c.tutorialDone:false,medals:[]});
      if(ctx.closeModal)ctx.closeModal();
      if(ctx.renderCampaignPanel)ctx.renderCampaignPanel();
      if(ctx.toast)ctx.toast('Campaña reiniciada: vuelves a la Misión 1, sin veterania.');
    };
    const no=document.getElementById('campaignResetCancel');
    if(no)no.onclick=()=>{if(ctx.closeModal)ctx.closeModal();};
  };
  const radio=document.getElementById('campaignRadioNext');
  if(radio)radio.onclick=()=>{
    const active=ctx.getMission?ctx.getMission():null;
    const progress=ctx.getProgress?ctx.getProgress():null;
    const mission=active&&active.id!==TUTORIAL_MISSION.id?active:(progress&&!progress.done?CAMPAIGN_MISSIONS[progress.next]||TUTORIAL_MISSION:TUTORIAL_MISSION);
    const line=cycleCampaignRadio('campaignRadio',mission);
    try{if(ctx.audio)ctx.audio({name:'Hipster Dave',role:'Comando'},'select',0.45);}catch(e){}
    if(ctx.toast&&line)ctx.toast(line);
  };
  const skip=document.getElementById('tutorialSkip');
  if(skip)skip.onclick=()=>{if(ctx.skipTutorial)ctx.skipTutorial();};
  const repeat=document.getElementById('tutorialRepeat');
  if(repeat)repeat.onclick=()=>{if(ctx.replayTutorial)ctx.replayTutorial();};
  const done=document.getElementById('tutorialDoneBtn');
  if(done)done.onclick=()=>{if(ctx.tutorialAdvance)ctx.tutorialAdvance();};
  document.addEventListener('click',(e)=>{
    const b=e.target&&e.target.closest?e.target.closest('[data-campaign-brief]'):null;
    if(!b)return;
    const idx=Number(b.dataset.campaignBrief);
    showMissionBriefing(Number.isInteger(idx)&&idx>=0?idx:-1);
  });
}

function renderCampaignPanelSafe(ctx){
  if(ctx.renderCampaignPanel)ctx.renderCampaignPanel();
}

export function campaignKey(charName){return rosterKey(charName);}
