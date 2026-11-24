import { REAL } from '../render3d/assets-real.js';
import { portraitKey, rolePortraitURL } from './ui-shell.js';

const escapeHtml=value=>String(value==null?'':value).replace(/[&<>"']/g,ch=>({'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;',"'":'&#39;'}[ch]));
const hpPercent=(hp,max)=>{const a=Number(hp),b=Number(max);return b>0&&Number.isFinite(a)&&Number.isFinite(b)?Math.max(0,Math.min(100,Math.round(a/b*100))):0;};

function unitStatus(u){
  if(!u||!u.alive)return 'K.O.';
  if(u.stunned)return 'Aturdido';
  if(u.invisible)return 'Invisible';
  if(u.suppressed)return 'Suprimido';
  if(u.overwatch)return 'Vigilancia';
  if(u.movedThisTurn)return 'Movido';
  return 'Listo';
}

export function vitalsMarkup(units,turn,selected,roleColors){
  if(!Array.isArray(units))return '';
  return units.map((u,i)=>{
    const alive=!!u.alive,ready=alive&&u.team===turn;
    const cls='hud-vital '+(u.team==='A'?'A':'B')+(ready?' ready':'')+(u===selected?' sel':'')+(alive?'':' dead');
    const color=roleColors&&roleColors[u.role]?roleColors[u.role]:'var(--ink-oliva)';
    const label=alive?escapeHtml(u.hp+' / '+u.maxHp):'K.O.';
    const state=unitStatus(u);
    const energy=alive&&Number.isFinite(Number(u.energy))?Number(u.energy)+' / '+Number(u.maxEnergy)+' ⚡':'— ⚡';
    const title=escapeHtml(u.role||'')+' · '+label+' · '+escapeHtml(state)+' · '+escapeHtml(energy)+' · '+escapeHtml(u.weapon||'');
    const face=REAL&&REAL.ready&&typeof rolePortraitURL==='function'?rolePortraitURL(u.role,u,u.skin,{nation:u.nation,authored:true}):null;
    const faceStyle=face?' style="background-image:url('+escapeHtml(face)+');background-size:cover;background-position:center 15%;color:transparent;border-color:transparent"':'';
    return '<button type="button" class="'+cls+'" data-hud-unit="'+i+'" style="--vital:'+escapeHtml(color)+'" title="'+title+'"><span class="hud-vital-ico" data-portrait-key="'+escapeHtml(face?portraitKey(u.role,u,u.skin,u.nation):'')+'"'+faceStyle+'>'+escapeHtml((u.role||'?').slice(0,1))+'</span><span class="hud-vital-name"><b>'+escapeHtml(u.role||'')+'</b></span><span class="hud-vital-meta"><em>'+escapeHtml(state)+'</em><i>'+escapeHtml(energy)+'</i></span><span class="hud-vital-bar"><i style="width:'+hpPercent(u.hp,u.maxHp)+'%"></i></span><b class="hud-vital-hp">'+label+'</b></button>';
  }).join('');
}

export function resultMarkup(options){
  const o=options||{},winner=o.winner;
  const tag=winner==='draw'?'EMPATE':winner==='A'?'VICTORIA':'DERROTA';
  const cls=winner==='A'?'win':winner==='draw'?'draw':'lose';
  return '<div class="endWrap '+cls+'"><div class="result-card">'+
    '<div class="result-top"><span class="result-kicker">'+escapeHtml(o.eyebrow||'URBAN TACTICAL ARCADE')+' · '+escapeHtml(o.modeLabel||'CSN')+'</span><span class="result-round">R'+escapeHtml(o.round)+'</span></div>'+
    '<div class="endBanner">'+tag+'</div>'+
    (o.art?'<img class="endArt" src="'+escapeHtml(o.art)+'" alt=""/>':'')+
    '<h2>'+escapeHtml(o.title)+'</h2><p class="result-reason"><b>'+escapeHtml(o.reason)+'</b></p>'+
    (o.extra||'')+
    '<p class="sub">Partida de '+escapeHtml(o.round)+' rondas. Supervivientes: '+escapeHtml(o.survivors)+'</p>'+
    (o.table||'')+(o.squadLine||'')+
    '<div class="result-actions">'+(o.buttons||'')+'</div>'+
  '</div></div>';
}
