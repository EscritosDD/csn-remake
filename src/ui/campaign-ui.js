import { CAMPAIGN_MISSIONS, TUTORIAL_MISSION, radioLines, rosterKey } from '../data/maps.js';

let radioMissionId=TUTORIAL_MISSION.id;
let radioIndex=0;

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
  const done=progress&&progress.medals&&progress.medals[index]||0;
  const roster=(list)=>list.map(r=>'<li><b>'+esc(r.charName)+'</b> · '+esc(r.role)+' · '+esc(r.weapon)+'</li>').join('');
  return '<div class="briefWrap"><span class="tag amber">Misión '+(index+1)+' de '+CAMPAIGN_MISSIONS.length+'</span><h2>'+esc(mission.title)+'</h2><p>'+esc(mission.brief)+'</p>'+radioMarkup(mission,radioIndex)+'<div class="brief-grid"><div><h3>Tu escuadra</h3><ul>'+roster(mission.playerRoster)+'</ul></div><div><h3>Rival</h3><ul>'+roster(mission.enemyRoster)+'</ul></div></div><p class="sub">Medallas actuales: '+starMarkup(done)+' · Límite para 3 estrellas: '+mission.turnLimit+' rondas sin bajas.</p></div>';
}

export function wireCampaignUI(ctx){
  const radio=document.getElementById('campaignRadioNext');
  if(radio)radio.onclick=()=>{
    const mission=ctx.getMission?ctx.getMission():TUTORIAL_MISSION;
    const line=cycleCampaignRadio('campaignRadio',mission);
    try{if(ctx.audio)ctx.audio({name:'Hipster Dave',role:'Comando'},'select',0.45);}catch(e){}
    if(ctx.toast&&line)ctx.toast(line);
  };
  const tut=document.getElementById('tutorialBtn');
  if(tut)tut.onclick=()=>{if(ctx.startTutorial)ctx.startTutorial();};
  const skip=document.getElementById('tutorialSkip');
  if(skip)skip.onclick=()=>{if(ctx.skipTutorial)ctx.skipTutorial();};
  const repeat=document.getElementById('tutorialRepeat');
  if(repeat)repeat.onclick=()=>{if(ctx.replayTutorial)ctx.replayTutorial();};
  const done=document.getElementById('tutorialDoneBtn');
  if(done)done.onclick=()=>{if(ctx.tutorialAdvance)ctx.tutorialAdvance();};
  document.addEventListener('click',(e)=>{
    const b=e.target&&e.target.closest?e.target.closest('[data-campaign-brief]'):null;
    if(!b||!ctx.showModal)return;
    const idx=Number(b.dataset.campaignBrief);
    const mission=Number.isInteger(idx)&&idx>=0?CAMPAIGN_MISSIONS[idx]:TUTORIAL_MISSION;
    const progress=ctx.getProgress?ctx.getProgress():null;
    ctx.showModal(briefingMarkup(mission,idx>=0?idx:0,progress)+'<div style="display:flex;gap:10px;justify-content:center;flex-wrap:wrap;margin-top:14px">'+(idx>=0?'<button class="btn primary big" onclick="closeModal();openSetup(\'campana\','+idx+')">Desplegar misión ▶</button>':'<button class="btn primary big" onclick="closeModal();openSetup(\'tutorial\')">Empezar instrucción ▶</button>')+'<button class="btn big" onclick="closeModal()">Cerrar</button></div>');
  });
}

export function campaignKey(charName){return rosterKey(charName);}
