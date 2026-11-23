import { NATIONS, NATION_ART } from '../data/nations.js';
import { ROLES, ROLE_NAMES, DEFAULT_SQUADS, ROLE_PORTRAIT } from '../data/roles.js';
import { CAMPAIGN_MISSIONS, CAMPAIGN_CHAPTERS, TUTORIAL_MISSION, rosterKey } from '../data/maps.js';
import { renderCampaignRadio, starMarkup } from './campaign-ui.js';
import { charsForRole, characterKey } from '../game/chars.js';
import { STEP_META, AUX_LABELS, AUX_HINTS } from '../data/ui-copy.js';
import { lsGet, lsSet } from '../core/storage.js';
import { REAL } from '../render3d/assets-real.js';
import { realSpriteUnit, renderRealSprite } from '../render3d/real-sprites.js';

export const $=s=>document.querySelector(s);

export function nationById(id){return NATIONS.find(n=>n.id===id)||null;}

export function flagHTML(n,cls){return '<span class="flag '+(n.dir==='v'?'vert':'horiz')+' '+(cls||'')+'">'+n.colors.map(c=>'<i style="background:'+c+'"></i>').join('')+'</span>';}

export function emblemHTML(n){return '<span class="emblem" title="'+n.emblemName+'">'+n.emblem+'</span>';}

export const LEAF_SVG='<svg viewBox="0 0 24 24" style="position:absolute;left:50%;top:50%;width:46%;transform:translate(-50%,-50%)" aria-hidden="true"><path d="M12 1 L14.5 6 L18 4 L16.8 8.5 L21 8 L17.5 11.5 L20 14 L15.5 14.5 L16.5 19 L13 16.5 L13 22 L11 22 L11 16.5 L7.5 19 L8.5 14.5 L4 14 L6.5 11.5 L3 8 L7.2 8.5 L6 4 L9.5 6 Z" fill="#FF0000"/></svg>';

export function flagArtHTML(n,sm){
  let inner='';
  if(n.id==='cn')inner='<b class="fsym" style="color:#FFDE00;left:10%;top:4%;font-size:'+(sm?8:12)+'px">★</b>';
  if(n.id==='us')inner='<b class="fsym" style="color:#fff;left:13%;top:0;font-size:'+(sm?7:10)+'px">★</b>';
  if(n.id==='br')inner='<span class="fdia"><span class="fcirc"></span></span>';
  if(n.id==='ca')inner=LEAF_SVG;
  return '<span class="flagart flagart-'+n.id+(sm?' sm':'')+'" role="img" aria-label="Bandera de '+n.name+'">'+inner+'</span>';
}

export const PORTRAIT_CACHE={};

export function rolePortraitURL(role,char){
  try{
    const pkey=role+'|'+((char&&(char.key||char.charKey||char.name))||'');
    if(PORTRAIT_CACHE[pkey])return PORTRAIT_CACHE[pkey];
    if(REAL.ready&&typeof realSpriteUnit==='function'&&typeof renderRealSprite==='function'){
      const r=ROLES[role];
      if(r){
        const skin=myNation?'nacion':'estandar';
         const u=realSpriteUnit(role,r.weapons[0],skin,myNation,char);

        const e=renderRealSprite(u);
        if(e&&e.url){
          /* Busto: recorte de la parte alta del render de cuerpo entero. */
          const im=new Image();
          im.onload=()=>{
            try{
              const cv=document.createElement('canvas');cv.width=128;cv.height=128;
              const cx=cv.getContext('2d');
              const sw=im.width*0.76, sh=im.height*0.44;
              cx.drawImage(im, im.width*0.12, im.height*0.08, sw, sh, 0, 0, 128, 128);
              PORTRAIT_CACHE[pkey]=cv.toDataURL('image/png');
            }catch(err){PORTRAIT_CACHE[pkey]=e.url;}
          };
          im.src=e.url;
           PORTRAIT_CACHE[pkey]=e.url;

          return e.url;
        }
      }
    }
  }catch(e){}
  const f=ROLE_PORTRAIT[role];return f?('assets/ui/'+f):null;
}

export function setStep(step,detail){
  if(step&&STEP_META[step])flowStep=step;
  const meta=STEP_META[flowStep];
  const label=step&&!STEP_META[step]?step:meta.label;
  const text=detail||meta.hint;
  const chip=$('#stepHint'),count=$('#stepCount'),lbl=$('#stepLabel'),desc=$('#stepDetail');
  if(chip){chip.dataset.step=flowStep;chip.setAttribute('aria-label','Paso '+meta.n+' de 4: '+label+'. '+text);}
  if(count)count.textContent=meta.n+'/4';
  if(lbl)lbl.textContent=label;
  if(desc)desc.textContent=text;
  document.body.dataset.step=flowStep;
  const inBattle=!!(G&&!G.over);
  document.querySelectorAll('[data-back]').forEach(b=>b.textContent=inBattle?'← Volver a la partida':'← Volver al menú');
}

export const LS_CAMPAIGN='radsoldiers_campaign_v1';

export const DOM_ZONES=[
 {id:'norte',name:'Depósito',tiles:[{x:3,y:4}]},
 {id:'centro',name:'Centro',tiles:[{x:5,y:5},{x:6,y:5},{x:5,y:6},{x:6,y:6}]},
 {id:'sur',name:'Muelle',tiles:[{x:8,y:7}]}
];

export const DOM_TARGET=10, DOM_MAX_ROUNDS=15;

export const ESCORT_START={x:1,y:5};

export const ESCORT_EXT=[{x:10,y:5},{x:11,y:5},{x:10,y:6},{x:11,y:6}];

export const ESCORT_MAX_ROUNDS=15, ESCORT_DRONE_MAXHP=240, ESCORT_DRONE_HP=240, ESCORT_GUIDES_PER_ROUND=2;

export function isExtraction(x,y){return escortExt().some(t=>t.x===x&&t.y===y);}

export function domZones(){
  if(!NATIVE_GRID)return DOM_ZONES;
  const c=boardCenter();
  return [
    {id:'norte',name:'Depósito',tiles:[{x:Math.floor(W*0.25),y:Math.floor(H*0.33)}]},
    {id:'centro',name:'Centro',tiles:BEACON.map(b=>({x:b.x,y:b.y}))},
    {id:'sur',name:'Muelle',tiles:[{x:Math.floor(W*0.75),y:Math.floor(H*0.67)}]}
  ];
}

export function escortStart(){return NATIVE_GRID?{x:1,y:Math.floor(H/2)}:ESCORT_START;}

export function escortExt(){
  if(!NATIVE_GRID)return ESCORT_EXT;
  const y=Math.floor(H/2);
  return [{x:W-2,y},{x:W-1,y},{x:W-2,y:y+1},{x:W-1,y:y+1}].filter(t=>t.x<W&&t.y<H);
}

function normalizeCampaign(p){
  const base=p&&typeof p==='object'?p:{};
  return {
    next:Math.max(0,Math.min(CAMPAIGN_MISSIONS.length,Number(base.next)||0)),
    vet:Array.isArray(base.vet)?base.vet:[],
    done:!!base.done,tutorialDone:!!base.tutorialDone,
    medals:CAMPAIGN_MISSIONS.map((m,i)=>Math.max(0,Math.min(3,Number(base.medals&&base.medals[i])||0)))
  };
}

export function loadCampaign(){try{const raw=lsGet(LS_CAMPAIGN);if(raw){const p=JSON.parse(raw);if(p&&typeof p.next==='number')return normalizeCampaign(p);}}catch(e){}return normalizeCampaign(null);}

export function saveCampaign(c){try{lsSet(LS_CAMPAIGN,JSON.stringify(normalizeCampaign(c)));}catch(e){}}

export function activeOriginalMission(){
  if(!setup)return null;
  if(setup.mode==='tutorial'||setup.isTutorial)return TUTORIAL_MISSION;
  if(setup.mode==='campana')return CAMPAIGN_MISSIONS[setup.campaignMission||0]||null;
  return null;
}

export function effSetupMode(){
  if(!setup)return 'eliminacion';
  const m=activeOriginalMission();
  if(m)return m.objective;
  return setup.mode;
}

export function effMode(g){if(!g)return 'eliminacion';if(g.mode==='tutorial'||g.isTutorial||g.mode==='campana')return g.campaignObjective||'eliminacion';if(g.mode==='guerra')return 'baliza';return g.mode;}

export function inDomZone(x,y,zone){return zone.tiles.some(t=>t.x===x&&t.y===y);}

export function domControl(zone){if(!G)return null;const a=G.units.some(u=>u.alive&&u.team==='A'&&inDomZone(u.x,u.y,zone));const b=G.units.some(u=>u.alive&&u.team==='B'&&inDomZone(u.x,u.y,zone));if(a&&!b)return 'A';if(b&&!a)return 'B';return null;}

export const LS_NATION='radsoldiers_nation', LS_WINS='radsoldiers_guerra_wins', LS_GAMES='radsoldiers_guerra_games';

export function toast(msg){const t=$('#toast');t.textContent=msg;t.classList.add('on');clearTimeout(t._h);t._h=setTimeout(()=>t.classList.remove('on'),2600);}

export function buildNationGrid(){
  const grid=$('#nationGrid');grid.innerHTML='';
  NATIONS.forEach(n=>{
    const b=document.createElement('button');b.className='nation-card';b.dataset.id=n.id;
    b.innerHTML='<img class="nation-art" src="assets/ui/nacion_'+NATION_ART[n.id]+'.png" alt="Escudo de '+n.name+'"/><span style="display:flex;gap:8px;align-items:center">'+flagArtHTML(n)+emblemHTML(n)+'</span><span>'+n.name+'</span><small style="color:var(--muted);font-weight:500;font-size:12px">'+n.emblemName+'</small>'+(n.pers?'<small style="color:var(--ink);font-weight:600;font-size:12px">'+n.pers.name+' · <span style="color:var(--muted);font-weight:500">'+n.pers.desc+'</span></small>':'')+'<small style="color:var(--muted);font-size:11px">Personalidad solo visual: no altera el equilibrio.</small>';
    b.onclick=()=>{pickedNation=n;setStep('nation',n.name+' seleccionada · confirma abajo');document.querySelectorAll('.nation-card').forEach(c=>c.classList.toggle('sel',c.dataset.id===n.id));$('#confirmNation').disabled=false;$('#nationPickLabel').innerHTML='Has elegido <b>'+n.name+'</b>. Si confirmas, será tu nación para siempre en este dispositivo.';};
    grid.appendChild(b);
  });
  $('#confirmNation').onclick=()=>{
    if(!pickedNation)return;
    lsSet(LS_NATION,pickedNation.id);
    myNation=pickedNation;
    /* Entrar al juego nunca debe depender de que el almacenamiento o un
       panel secundario funcione: si algo falla dentro de enterApp, se
       fuerza igualmente el paso a la pantalla de juego. */
    try{enterApp();}
    catch(e){try{renderNationChip();}catch(e2){} $('#mainTabs').style.display='flex'; showScreen('scr-play');}
    toast('Alistado en '+myNation.name+'. Sus colores van en tus soldados.');
  };
}

export function charNameFor(role){
  try{const c=(typeof CHAR_PREFS!=='undefined'&&CHAR_PREFS&&CHAR_PREFS[role])||((typeof charsForRole==='function'&&charsForRole(role)[0]||{}).name);return c||'';}catch(e){return '';}
}

export function renderNationChip(){
  const chip=$('#nationChip');
  if(!myNation){chip.style.display='none';return;}
  const wins=+(lsGet(LS_WINS)||0);
  chip.style.display='flex';
  chip.innerHTML=flagArtHTML(myNation,true)+emblemHTML(myNation)+'<span title="'+(myNation.pers?myNation.pers.name+': '+myNation.pers.desc:'')+'">'+myNation.name+'</span><span class="mono" style="color:var(--amber);font-size:13px" title="Victorias en Guerra de Naciones">★ '+wins+'</span><span class="mono" style="color:var(--ink);font-size:13px" title="Monedas de CSN">🪙 '+coinsGet()+'</span>';
}

export function screenStateFor(id,game=G){
  if(id==='scr-nation')return 'nation';
  if(id==='scr-play'){
    if(game)return game.over?'gameover':'playing';
    const sa=document.getElementById('setupArea');
    return sa&&sa.style.display==='block'?'setup':'menu';
  }
  return 'menu';
}

export function syncPlayingViewport(){
  const root=document.documentElement;
  root.classList.toggle('is-playing',document.body.dataset.state==='playing');
  const header=document.querySelector('.topbar');
  const bar=document.getElementById('actionBar');
  const headerHeight=header?header.getBoundingClientRect().height:68;
  const footerHeight=bar&&document.body.dataset.state==='playing'?bar.getBoundingClientRect().height:0;
  root.style.setProperty('--csn-play-header',Math.ceil(headerHeight)+'px');
  root.style.setProperty('--csn-play-footer',Math.ceil(footerHeight)+'px');
}

export function showScreen(id){
  document.querySelectorAll('.screen').forEach(s=>s.classList.remove('on'));
  $('#'+id).classList.add('on');
  document.body.dataset.state=screenStateFor(id);
  syncPlayingViewport();
  /* El escenario 3D en vivo acompaña a la pantalla principal que esté
     abierta (selección de nación o menú de juego), para que lo nuevo se
     vea nada más abrir la página y no solo dentro de una partida. */
  const dp=document.getElementById('demoPanel');
  const slot=document.getElementById(id==='scr-nation'?'demoSlotNation':(id==='scr-play'?'demoSlotPlay':''));
  if(dp&&slot&&dp.parentNode!==slot)slot.appendChild(dp);
  if(typeof buildDemo==='function')buildDemo();
  document.querySelectorAll('#mainTabs button').forEach(b=>b.classList.toggle('on',b.dataset.tab===id.replace('scr-','')));
  if(id==='scr-nation')setStep('nation');
  else if(id==='scr-play')setStep($('#setupArea')?.style.display==='block'?'squad':(G&&!G.over?'battle':'mode'));
  else setStep(AUX_LABELS[id]||null,AUX_HINTS[id]||null);
  window.scrollTo({top:0});
}

export function enterApp(){
  renderNationChip();
  if(myNation){
    $('#skinNationName').textContent='· '+myNation.name;
    $('#skinNationSwatch').innerHTML=myNation.colors.map(c=>'<i style="background:'+c+'"></i>').join('')+'<span style="align-self:center">'+emblemHTML(myNation)+'</span>';
    $('#skinNationDesc').textContent='Los colores de la bandera de '+myNation.name+' en el uniforme y el casco, con su emblema en el pecho: '+myNation.emblemName+'.';
  }
  $('#mainTabs').style.display='flex';
  showScreen('scr-play');
  refreshGuerra();
  if(typeof renderCampaignPanel==='function')renderCampaignPanel();
  if(typeof buildSpriteStrip==='function')buildSpriteStrip();
}

export function refreshGuerra(){
  const wk=isWeekend();
  const wins=+(lsGet(LS_WINS)||0), games=+(lsGet(LS_GAMES)||0);
  $('#guerraScore').innerHTML=myNation?('Tu nación, <b>'+myNation.name+'</b> · Victorias en este dispositivo: <b class="mono">'+wins+'</b> · Partidas de evento: <b class="mono">'+games+'</b>'):'';
  $('#guerraLock').style.display=wk?'none':'block';
  $('#guerraBtn').disabled=!wk;
  $('#guerraTag').textContent=wk?'Evento abierto · fin de semana':'Bloqueado · solo sáb y dom';
  $('#guerraTag').className='tag '+(wk?'amber':'lock');
  $('#guerraDesc').innerHTML=wk?'El evento está <b>abierto</b>. Captura de baliza 4 contra 4: tu escuadra, con los colores de '+(myNation?myNation.name:'tu nación')+', contra una nación rival de la IA. Cada victoria suma un punto.':'Captura de baliza por tu nación contra una nación rival controlada por la IA. Cada victoria suma un punto al marcador de tu nación en este dispositivo.';
}

export function syncDiffSeg(){document.querySelectorAll('#diffSeg button').forEach(x=>x.classList.toggle('on',x.dataset.diff===setup.difficulty));}

export function renderCampaignPanel(){
  const c=loadCampaign();
  const prog=document.getElementById('campaignProgress');
  const medals=CAMPAIGN_MISSIONS.map((m,i)=>m.title+' '+starMarkup(c.medals[i]||0)).join(' · ');
  if(prog)prog.innerHTML=(c.tutorialDone?'Instrucción de Dave completada. ':'Pendiente: instrucción de Dave. ')+(c.done?'Operación completada.':('Progreso: <b>'+c.next+' de '+CAMPAIGN_MISSIONS.length+'</b> misiones superadas.'))+'<br>Medallas: '+medals+(c.vet&&c.vet.length?('<br>Veterania por posición: '+c.vet.map((v,i)=>'Pos. '+(i+1)+': +'+(v*25)+' PV').join(' · ')):'');
  const radioMission=CAMPAIGN_MISSIONS[Math.min(c.next,CAMPAIGN_MISSIONS.length-1)]||CAMPAIGN_MISSIONS[0];
  renderCampaignRadio('campaignRadio',radioMission);
  const list=document.getElementById('campaignList');if(!list)return;
  const CHAPTERS=CAMPAIGN_CHAPTERS;
  list.className='chapter-grid';
  list.innerHTML='';
  CHAPTERS.forEach(ch=>{
    const total=ch.to-ch.from+1;
    const doneN=CAMPAIGN_MISSIONS.slice(ch.from,ch.to+1).filter((m,i)=>c.done||(ch.from+i)<c.next).length;
    const card=document.createElement('div');card.className='panel chapter-card';
    const pct=total?Math.round(doneN/total*100):0;
    card.innerHTML='<div class="ch-top"><img class="ch-ico" src="'+ch.icon+'" alt=""/><div style="flex:1"><b>'+ch.name+'</b><div class="ch-bar"><i style="width:'+pct+'%"></i></div></div><span class="mono" style="color:var(--muted);font-size:12px">'+doneN+'/'+total+'</span><button class="btn small" type="button" data-campaign-brief="'+ch.from+'">📻 Briefing</button></div>';
    for(let i=ch.from;i<=ch.to;i++){
      const m=CAMPAIGN_MISSIONS[i];
      const state=c.done||i<c.next?'done':(i===c.next?'current':'locked');
      const b=document.createElement('button');b.className='campaign-mission '+state;b.type='button';
      b.innerHTML='<span class="mission-num">'+(state==='done'?'✓':(i+1))+'</span><span style="flex:1"><b>Misión '+(i+1)+' · '+m.title+(state==='done'?' · superada':state==='current'?' · siguiente':' · bloqueada')+'</b><p>'+m.brief+'</p><span class="mission-stars" title="Medallas">'+starMarkup(c.medals[i]||0)+'</span></span>'+(state==='locked'?'<span class="ch-lock" aria-hidden="true">🔒</span>':'');
      b.disabled=state==='locked';
      b.onclick=()=>{if(state!=='locked')openSetup('campana',i);};
      card.appendChild(b);
    }
    list.appendChild(card);
  });
}

export function openSetup(mode,missionIdx){
  if(mode==='guerra'&&!isWeekend()){toast('Guerra de Naciones solo se juega sábado y domingo.');return;}
  setup.mode=mode;
  setup.campaignId=null;
  setup.isTutorial=mode==='tutorial';
  const banner=$('#campaignBanner');
  if(mode==='campana'){
    const c=loadCampaign();
    setup.campaignMission=(typeof missionIdx==='number')?missionIdx:(c.done?0:c.next);
    const m=CAMPAIGN_MISSIONS[setup.campaignMission];
    setup.map=m.map;setup.fmt=m.fmt;setup.opp='ia';setup.difficulty=m.difficulty;setup.skinA='nacion';setup.rivalNation=null;
    if(banner){banner.style.display='block';banner.innerHTML='<b style="font-family:\'Barlow Condensed\';text-transform:uppercase;font-size:19px">Campaña · Misión '+(setup.campaignMission+1)+' de '+CAMPAIGN_MISSIONS.length+' · '
 +m.title+'</b><br><span class="sub">'+m.brief+'</span>'+(c.vet&&c.vet[setup.campaignMission]!==undefined?'':'')+((c.vet&&c.vet.some(v=>v>0))?'<br><span class="sub">Veterania que entra en esta misión, por posición de escuadra: '+c.vet.map((v,i)=>v>0?('Pos. '+(i+1)+': +'+(v*25)+' PV y +'+v+' ⚡'):null).filter(Boolean).join(' · ')+'</span>':'');}
  } else if(mode==='tutorial'){
    const m=TUTORIAL_MISSION;
    setup.campaignMission=0;setup.map=m.map;setup.fmt=m.fmt;setup.opp='ia';setup.difficulty=m.difficulty;setup.skinA='nacion';setup.rivalNation=null;
    if(banner){banner.style.display='block';banner.innerHTML='<b style="font-family:\'Barlow Condensed\';text-transform:uppercase;font-size:19px">Instrucción de Dave · 6 pasos</b><br><span class="sub">'+m.brief+'</span>';}
  } else {setup.campaignMission=0;if(banner)banner.style.display='none';}
  if(mode==='guerra'){setup.fmt=4;setup.opp='ia';setup.skinA='nacion';const others=NATIONS.filter(n=>n.id!==myNation.id);setup.rivalNation=others[Math.floor(Math.random()*others.length)];}
  else if(mode!=='campana'&&mode!=='tutorial') setup.rivalNation=null;
  if(mode==='dominacion'){/* mapa y formato libres, objetivo fijo */}
  $('#menuArea').style.display='none';$('#gameArea').style.display='none';$('#setupArea').style.display='block';
  document.body.dataset.state='setup';
  const titles={eliminacion:'Eliminación',baliza:'Captura de baliza',guerra:'Guerra de Naciones',dominacion:'Dominación',campana:'Campaña · Operación Londres',tutorial:'Instrucción de Dave',escolta:'Escolta del dron'};
  $('#setupTitle').textContent='Configurar partida · '+(titles[mode]||mode);
  try{const art=$('#setupArt');if(art){const files={eliminacion:'modo_eliminacion',baliza:'modo_baliza',guerra:'modo_baliza',dominacion:'modo_dominacion',escolta:'modo_escolta',campana:'modo_eliminacion',tutorial:'modo_eliminacion'};art.src='assets/ui/'+(files[mode]||'modo_eliminacion')+'.png';}}catch(e){}
  $('#setupSub').textContent=mode==='guerra'
    ? 'Evento de fin de semana: '+myNation.name+' contra '+setup.rivalNation.name+' (IA). 4 contra 4, captura de baliza.'
    : mode==='dominacion' ? 'Dominación: tres zonas (Depósito, Centro y Muelle), primero a 10 puntos.'
    : mode==='escolta' ? 'Escolta: lleva el dron al este con la escolta pegada; el rival intenta pararlo.'
    : mode==='campana' ? 'Misión '+(setup.campaignMission+1)+' · '+CAMPAIGN_MISSIONS[setup.campaignMission].title+' — mapa, formato y dificultad fijos.'
    : mode==='tutorial' ? TUTORIAL_MISSION.brief
    : 'Formato, rival y composición de cada escuadra.';
  $('#setupSub').title=mode==='campana'?CAMPAIGN_MISSIONS[setup.campaignMission].brief:(mode==='tutorial'?TUTORIAL_MISSION.brief:'');
  setStep('squad',(titles[mode]||mode)+' · revisa tu escuadra');
  const locked=(mode==='guerra'||mode==='campana'||mode==='tutorial');
  document.querySelectorAll('#fmtSeg button').forEach(x=>{x.classList.toggle('on',+x.dataset.fmt===setup.fmt);x.disabled=locked;});
  document.querySelectorAll('#oppSeg button').forEach(x=>{x.classList.toggle('on',x.dataset.opp===setup.opp);x.disabled=locked;});
  document.querySelectorAll('#mapSeg button').forEach(x=>{x.disabled=(mode==='campana'||mode==='tutorial');});
  document.querySelectorAll('#diffSeg button').forEach(x=>{x.disabled=(mode==='campana'||mode==='tutorial'||setup.opp==='local');});
  syncDiffSeg();
  syncMapSeg();
  syncSkinSegs();
  buildSquads();
  window.scrollTo({top:0,behavior:'smooth'});
}

export function syncMapSeg(){document.querySelectorAll('#mapSeg button').forEach(x=>x.classList.toggle('on',x.dataset.map===setup.map));}

export function wireSkinSeg(segId,key){
  document.querySelectorAll('#'+segId+' button').forEach(b=>b.onclick=()=>{setup[key]=b.dataset.skin;document.querySelectorAll('#'+segId+' button').forEach(x=>x.classList.toggle('on',x===b));});
}

export function syncSkinSegs(){
  document.querySelectorAll('#skinSegA button').forEach(x=>{x.classList.toggle('on',x.dataset.skin===setup.skinA);x.disabled=(setup.mode==='guerra');});
  document.querySelectorAll('#skinSegB button').forEach(x=>x.classList.toggle('on',x.dataset.skin===setup.skinB));
  $('#skinBWrap').style.display=setup.opp==='local'?'block':'none';
}

export function squadRows(containerId,team){
  const el=$('#'+containerId);el.innerHTML='';
  const def=DEFAULT_SQUADS[setup.fmt];
  const mission=activeOriginalMission();
  const origOnly=!!mission;
  const fixed=mission?(team==='A'?mission.playerRoster:mission.enemyRoster):null;
  for(let i=0;i<setup.fmt;i++){
    const row=document.createElement('div');row.className='squad-row';
    const fixedDef=fixed&&fixed[i];
    const role=fixedDef?fixedDef.role:def[i];
    row.innerHTML='<div class="slot-num">'+(i+1)+'</div>'+
      '<img class="sq-ico" src="'+(rolePortraitURL(role,fixedDef)||'assets/ui/retrato_capitan.png')+'" alt=""/>'+
      '<select data-team="'+team+'" data-slot="'+i+'" data-kind="role" '+(fixedDef?'disabled':'')+'>'+ROLE_NAMES.map(r=>'<option '+(r===role?'selected':'')+'>'+r+'</option>').join('')+'</select>'+
      '<select data-team="'+team+'" data-slot="'+i+'" data-kind="weapon" '+(fixedDef?'disabled':'')+'></select><select data-team="'+team+'" data-slot="'+i+'" data-kind="char" aria-label="Personaje" '+(fixedDef?'disabled':'')+'></select>';
    el.appendChild(row);
    const rsel=row.querySelector('[data-kind="role"]');
    const wsel=row.querySelector('[data-kind="weapon"]');
    const csel=row.querySelector('[data-kind="char"]');
    const fill=()=>{
      const r=rsel.value;
      const weapons=fixedDef?[fixedDef.weapon]:ROLES[r].weapons;
      wsel.innerHTML=weapons.map(w=>'<option '+(w===fixedDef.weapon?'selected':'')+'>'+w+'</option>').join('');
      const opts=charsForRole(r,origOnly);
      csel.innerHTML=opts.map(c=>'<option value="'+characterKey(c)+'">'+c.name+'</option>').join('');
      const chosen=fixedDef?rosterKey(fixedDef.charName):(setup.squadChars[team]&&setup.squadChars[team][i])||characterKey(opts[0]);
      csel.value=opts.some(c=>characterKey(c)===chosen)?chosen:characterKey(opts[0]);
      if(!setup.squadChars[team])setup.squadChars[team]={};
      setup.squadChars[team][i]=csel.value;
      const ch=opts.find(c=>characterKey(c)===csel.value)||opts[0];
      const ico=row.querySelector('.sq-ico');if(ico)ico.src=(rolePortraitURL(r,ch||fixedDef)||'assets/ui/retrato_capitan.png');
    };
    csel.onchange=()=>{if(!setup.squadChars[team])setup.squadChars[team]={};setup.squadChars[team][i]=csel.value;};
    rsel.onchange=fill;fill();
  }
}

export function buildSquads(){
  syncSkinSegs();
  $('#squadALabel').innerHTML='Tu escuadra · '+(myNation?myNation.name:'')+' '+ (myNation?flagHTML(myNation):'');
  squadRows('squadA','A');
  const rivalName=setup.mode==='guerra'?setup.rivalNation.name:(setup.opp==='ia'?'la IA':'Jugador 2');
  $('#squadBLabel').textContent='Escuadra rival · '+rivalName;
  squadRows('squadB','B');
  const bw=$('#squadBWrap');
  if(bw){
    const soloIA=(setup.opp==='ia'&&setup.mode!=='guerra');
    bw.style.opacity='1';
    /* Contra la IA no se enseña la escuadra rival: la pantalla queda para
       la tuya, como en el original. */
    bw.style.display=soloIA?'none':'';
  }
}

export function readSquad(team){
  const out=[];
  document.querySelectorAll('select[data-team="'+team+'"]').forEach(()=>{});
  for(let i=0;i<setup.fmt;i++){
    const role=document.querySelector('select[data-team="'+team+'"][data-slot="'+i+'"][data-kind="role"]').value;
    const weapon=document.querySelector('select[data-team="'+team+'"][data-slot="'+i+'"][data-kind="weapon"]').value;
    const charKey=document.querySelector('select[data-team="'+team+'"][data-slot="'+i+'"][data-kind="char"]').value;
    out.push({role,weapon,charKey});
  }
  return out;
}
