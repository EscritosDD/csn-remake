const escapeHtml=value=>String(value==null?'':value).replace(/[&<>"']/g,ch=>({'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;',"'":'&#39;'}[ch]));
const hpPercent=(hp,max)=>{const a=Number(hp),b=Number(max);return b>0&&Number.isFinite(a)&&Number.isFinite(b)?Math.max(0,Math.min(100,Math.round(a/b*100))):0;};

export function vitalsMarkup(units,turn,selected,roleColors){
  if(!Array.isArray(units))return '';
  return units.map((u,i)=>{
    const alive=!!u.alive,ready=alive&&u.team===turn;
    const cls='hud-vital '+(u.team==='A'?'A':'B')+(ready?' ready':'')+(u===selected?' sel':'')+(alive?'':' dead');
    const color=roleColors&&roleColors[u.role]?roleColors[u.role]:'var(--ink-cyan)';
    const label=alive?escapeHtml(u.hp+' / '+u.maxHp):'K.O.';
    return '<button type="button" class="'+cls+'" data-hud-unit="'+i+'" style="--vital:'+escapeHtml(color)+'" title="'+escapeHtml(u.role||'')+' · '+label+' · '+escapeHtml(u.weapon||'')+'"><span class="hud-vital-ico">'+escapeHtml((u.role||'?').slice(0,1))+'</span><span class="hud-vital-name"><b>'+escapeHtml(u.role||'')+'</b><small>'+escapeHtml(u.weapon||'')+'</small></span><span class="hud-vital-bar"><i style="width:'+hpPercent(u.hp,u.maxHp)+'%"></i></span><b class="hud-vital-hp">'+label+'</b></button>';
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
    '<h2>'+o.title+'</h2><p class="result-reason"><b>'+o.reason+'</b></p>'+
    (o.extra||'')+
    '<p class="sub">Partida de '+escapeHtml(o.round)+' rondas. Supervivientes: '+escapeHtml(o.survivors)+'</p>'+
    (o.table||'')+(o.squadLine||'')+
    '<div class="result-actions">'+(o.buttons||'')+'</div>'+
  '</div></div>';
}
