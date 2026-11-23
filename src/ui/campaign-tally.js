import { TUTORIAL_MISSION, radioLines } from '../data/maps.js';

const TALLY_STARS='★★★', TALLY_EMPTY='☆☆☆';

function tallyEsc(v){return String(v==null?'':v).replace(/&/g,'&amp;').replace(/</g,'&lt;').replace(/>/g,'&gt;').replace(/"/g,'&quot;');}

export function tallyStars(n){const v=Math.max(0,Math.min(3,Number(n)||0));return TALLY_STARS.slice(0,v)+TALLY_EMPTY.slice(0,3-v);}

export function campaignTally(progress,missions){
  const list=Array.isArray(missions)?missions:[];
  const total=list.length||6;
  const c=progress&&typeof progress==='object'?progress:{};
  const medals=Array.isArray(c.medals)?c.medals:[];
  const stars=list.reduce((sum,m,i)=>sum+Math.max(0,Math.min(3,Number(medals[i])||0)),0);
  const next=Math.max(0,Math.min(total-1,Number(c.next)||0));
  const done=c.done?total:Math.min(total,Math.max(0,Number(c.next)||0));
  return {done,total,stars,maxStars:total*3,next,tutorialDone:!!c.tutorialDone,complete:!!c.done,pct:total?Math.round(done/total*100):0,reward:done*25+stars*10};
}

export function campaignProgressLabel(progress,missions){
  const t=campaignTally(progress,missions);
  return '<b>'+t.done+' / '+t.total+'</b> · <b class="mono">'+t.stars+' / '+t.maxStars+' ★</b>';
}

export function campaignTallyMarkup(progress,missions){
  const t=campaignTally(progress,missions);
  return '<div class="tally-line">'+campaignProgressLabel(progress,missions)+'</div><div class="tally-bar"><i style="width:'+t.pct+'%"></i></div><div class="tally-reward">🪙 '+t.reward+' · '+(t.complete?'OPERACIÓN COMPLETADA':(t.tutorialDone?'Dave listo · '+t.done+' misiones':(t.done?'Racha en curso':'')))+'</div>';
}

export function campaignDaveLine(progress,missions){
  const t=campaignTally(progress,missions);
  const lines=radioLines(TUTORIAL_MISSION&&TUTORIAL_MISSION.id)||[];
  if(!lines.length)return 'DAVE — Toca a un soldado, mueve a cobertura y dispara con línea de visión.';
  if(!t.tutorialDone)return lines[0];
  if(t.complete)return lines[lines.length-1];
  return lines[Math.min(lines.length-1,t.done+1)];
}

export function nextMissionIndex(progress,missions){
  const t=campaignTally(progress,missions);
  return t.complete?0:t.next;
}

export function campaignObjectiveLabel(objective){
  return ({eliminacion:'Eliminación',baliza:'Captura de baliza',dominacion:'Dominación',escolta:'Escolta del dron'})[objective]||(objective||'Operación');
}

export function campaignMissionCardMarkup(mission,index,state,stars,thumb){
  const m=mission||{},locked=state==='locked';
  const src=tallyEsc(thumb||'assets/ui/modo_eliminacion.png');
  return '<button class="campaign-mission '+tallyEsc(state||'locked')+'" type="button" data-campaign-index="'+index+'"'+(locked?' disabled':'')+'>'+
    '<span class="mission-thumb"><img src="'+src+'" alt=""/></span>'+
    '<span class="mission-num">'+(state==='done'?'✓':(index+1))+'</span>'+
    '<span class="mission-copy"><b>Misión '+(index+1)+' · '+tallyEsc(m.title)+'</b><small>'+tallyEsc(campaignObjectiveLabel(m.objective))+'</small><p>'+tallyEsc(m.brief)+'</p></span>'+
    '<span class="mission-stars">'+tallyStars(stars)+'</span>'+
    (locked?'<span class="ch-lock" aria-hidden="true">🔒</span>':'')+'</button>';
}
