export const ROLE_SVG_ID={'Francotirador':'francotirador','Artillero':'artillero','Espía':'espia','Médico':'medico','Ingeniero':'ingeniero','Comando':'comando','Capitán':'capitan'};

export let ARGON_DEFS='', ARGON_SYMBOLS={}, ARGON_READY=false;

export const SPRITE_CACHE={};

export function shadeHex(hex,amt){
  if(!hex||hex[0]!=='#'||hex.length<7)return hex;
  const n=parseInt(hex.slice(1),16);let r=(n>>16)+amt,g=(n>>8&255)+amt,b=(n&255)+amt;
  r=Math.max(0,Math.min(255,r));g=Math.max(0,Math.min(255,g));b=Math.max(0,Math.min(255,b));
  return '#'+((r<<16)|(g<<8)|b).toString(16).padStart(6,'0');
}

export function buildSpriteSVG(svgId,skin,nation){
  let defs=ARGON_DEFS;const inner=ARGON_SYMBOLS[svgId]||'';
  if(skin==='nacion'&&nation){
    const nc=nation.colors,uni=nc[0];
    let helm=nc[2];if(!helm||helm.toUpperCase()==='#FFFFFF')helm=nc[1];
    const rep=(s,a,b)=>s.split(a).join(b);
    /* Degradados de la hoja nueva de Argon: el uniforme y el casco se
       tiñen con los colores de la bandera sustituyendo sus tres paradas
       (luz, tono medio y sombra) por las equivalentes de la nación. */
    defs=rep(defs,'#6E7F48',shadeHex(uni,48));defs=rep(defs,'#6e7f48',shadeHex(uni,48));
    defs=rep(defs,'#536234',uni);defs=rep(defs,'#536234'.toLowerCase(),uni);
    defs=rep(defs,'#3B4723',shadeHex(uni,-40));defs=rep(defs,'#3b4723',shadeHex(uni,-40));
    /* degradado del casco -> tercer color de la bandera */
    defs=rep(defs,'#7B8864',shadeHex(helm,38));defs=rep(defs,'#7b8864',shadeHex(helm,38));
    defs=rep(defs,'#556143',shadeHex(helm,-4));defs=rep(defs,'#556143'.toLowerCase(),shadeHex(helm,-4));
    defs=rep(defs,'#38412B',shadeHex(helm,-32));defs=rep(defs,'#38412b',shadeHex(helm,-32));
  }
  return '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 200 200" width="240" height="240"><defs>'+defs+'</defs><g>'+inner+'</g></svg>';
}

export function spriteDataURI(svgId,skin,nation){return 'data:image/svg+xml;charset=utf-8,'+encodeURIComponent(buildSpriteSVG(svgId,skin,nation));}

export function getSpriteImage(un){
  if(!ARGON_READY)return null;
  const svgId=ROLE_SVG_ID[un.role];if(!svgId)return null;
  const key=un.role+'|'+un.skin+'|'+(un.skin==='nacion'&&un.nation?un.nation.id:'std');
  let img=SPRITE_CACHE[key];
  if(img===undefined){
    img=new Image();
    img.onload=()=>{if(G)draw();};
    img.onerror=()=>{SPRITE_CACHE[key]=null;};
    img.src=spriteDataURI(svgId,un.skin,un.nation);
    SPRITE_CACHE[key]=img;
  }
  return (img&&img.complete&&img.naturalWidth>0)?img:null;
}

export function buildSpriteStrip(){
  const strip=document.getElementById('spriteStrip');if(!strip)return;
  /* Las tarjetas de rol muestran los retratos de busto de
     assets/ui/retrato_*.png: son archivos, así que la tira se dibuja
     al momento, sin esperar a que cargue el modelo 3D ni los SVG. */
  strip.innerHTML=ROLE_NAMES.map(r=>{
    const cap='<figcaption><span style="display:inline-block;width:9px;height:9px;border-radius:50%;background:'+ROLES[r].color+';margin-right:5px"></span>'+r+'<small>'+roleLook(r).silueta+' · cuerpo '+BODIES[ROLES[r].body].name.toLowerCase()+'</small></figcaption>';
    return '<figure class="sprite-cell"><img src="'+rolePortraitURL(r)+'" alt="Retrato del '+r+' ('+roleLook(r).silueta.toLowerCase()+')"/>'+cap+'</figure>';
  }).join('');
}

export const SKIN_TONES=['#f6cfa0','#eebd8d','#dda06a','#b97e46','#8a5a30'];

export function drawSoldier(un,S){
  const rx=un.alive&&un.dx!=null?un.dx:un.x, ry=un.alive&&un.dy!=null?un.dy:un.y;
  const cx=rx*S+S/2, cy=ry*S+S/2;
  const feetY=cy+S*.38;
  if(!un.alive){
    ctx.save();ctx.translate(cx,feetY-4);ctx.rotate(-.35);
    ctx.beginPath();ctx.ellipse(0,4,S*.34,S*.13,0,0,7);ctx.fillStyle='rgba(0,0,0,.35)';ctx.fill();
    const deadCol=un.skin==='nacion'?un.nation.colors[0]:SKINS.estandar.uniform;
    ctx.beginPath();ctx.ellipse(-2,0,S*.3,S*.15,0,0,7);ctx.fillStyle=lg(-S*.3,0,S*.3,0,[[0,shade(deadCol,-25)],[.5,deadCol],[1,shade(deadCol,-15)]]);ctx.fill();
    ctx.lineWidth=2;ctx.strokeStyle='rgba(0,0,0,.4)';ctx.stroke();
    ctx.beginPath();ctx.arc(S*.3,-3,S*.13,0,7);ctx.fillStyle=SKIN_TONES[un.id%SKIN_TONES.length];ctx.fill();ctx.stroke();
    ctx.beginPath();ctx.arc(S*.3,-3,S*.14,Math.PI,Math.PI*2);ctx.fillStyle=un.skin==='nacion'?shade(un.nation.colors[2],-20):SKINS.estandar.helmet;ctx.fill();
    ctx.restore();
    ctx.strokeStyle='rgba(229,72,77,.9)';ctx.lineWidth=3;ctx.beginPath();
    ctx.moveTo(cx-S*.3,cy-S*.3);ctx.lineTo(cx-S*.18,cy-S*.18);ctx.moveTo(cx-S*.18,cy-S*.3);ctx.lineTo(cx-S*.3,cy-S*.18);ctx.stroke();
    return;
  }
  const nc=un.nation.colors, roleCol=ROLES[un.role].color, skin=SKIN_TONES[un.id%SKIN_TONES.length];
  const isNat=un.skin==='nacion';
  const uniCol=isNat?nc[0]:SKINS.estandar.uniform, helmetCol=isNat?nc[2]:SKINS.estandar.helmet, bandCol=isNat?nc[1]:'#3e4630';
  const lk2=roleLook(un.role);
  const bulky=1; /* el ancho de cada rol lo da la escala de silueta de abajo, no una constante por pieza */
  ctx.save();
  if(un.invisible)ctx.globalAlpha=.45;
  if(!REDUCED_MOTION)ctx.translate(0,Math.sin(FX.t/430+un.id*1.93)*S*0.02);
  /* sombra suave y anillo segmentado de energía */
  ctx.beginPath();ctx.ellipse(cx,feetY+3,S*.37,S*.115,0,0,7);ctx.fillStyle='rgba(8,10,8,.38)';ctx.fill();
  segRing(cx,feetY,S*.43,S*.155,un);
  /* Arco de vida en el suelo (verde el jugador, azul el rival), como el original */
  if(un.hp>0){
    const hpF=Math.max(0,Math.min(1,un.hp/un.maxHp)),a0=Math.PI*0.5,a1=a0+Math.PI*2*hpF;
    ctx.beginPath();ctx.ellipse(cx,feetY,S*.55,S*.21,0,a0,a1);ctx.strokeStyle='rgba(6,8,6,.5)';ctx.lineWidth=7;ctx.stroke();
    ctx.beginPath();ctx.ellipse(cx,feetY,S*.55,S*.21,0,a0,a1);ctx.strokeStyle=un.team==='A'?'#4fdc6e':'#4f8fe0';ctx.lineWidth=4;ctx.stroke();
  }
  if(G.selected===un){
    ctx.beginPath();ctx.ellipse(cx,feetY,S*.5,S*.19,0,0,7);ctx.strokeStyle='#ffffff';ctx.lineWidth=2.6;ctx.setLineDash([9,6]);ctx.lineDashOffset=REDUCED_MOTION?0:-FX.t/45;ctx.stroke();ctx.setLineDash([]);
  }
  /* === SOLDADO REAL: el sprite SVG de Argon, dibujado en la casilla ===
     Si el sprite está cargado, este es el cuerpo del soldado en partida
     (con la variante teñida por nación cuando toca). Debajo quedan el
     anillo de energía y la sombra; encima, la barra de vida flotante y,
     con skin de Nación, la pastilla con las franjas y el emblema. */
  /* === SPRITE DESDE EL MODELO REAL: el mismo soldado de la vista 3D ===
     Si el sprite renderizado desde la malla del IPA está disponible, este
     es el cuerpo del soldado en la vista clásica (con su arma, su mochila
     y el tinte de su skin ya horneados en el fotograma). Debajo quedan el
     anillo de energía y la sombra, como siempre; encima, la barra de vida
     flotante. Sin pastilla de nación: la 3D tampoco la lleva, el tinte de
     la textura ya dice de quién es el uniforme. */
  /* Giro en la clásica: el sprite se voltea según la dirección de mira
     lógica (ya no según el bando) y, mientras el giro dura, se estrecha
     un instante, que es como un dibujo plano enseña que está rotando. */
  const yaw2=advanceUnitYaw(un,FX.t);
  const cosY=Math.cos(yaw2);
  if(cosY>0.35)un._flip2d=false;else if(cosY<-0.35)un._flip2d=true;
  const turnW=(un._turning&&!REDUCED_MOTION)?(1-0.30*Math.sin(Math.PI*(un._turnProg||0))):1;
  const realSprImg=getRealSpriteImage(un);
  if(realSprImg){
    const swd=S*1.9*turnW;
    const bobY=REDUCED_MOTION?0:Math.sin(FX.t/430+un.id*1.93)*S*0.02;
    ctx.save();
    if(un._flip2d){ctx.translate(cx,0);ctx.scale(-1,1);ctx.translate(-cx,0);}
    ctx.drawImage(realSprImg,cx-swd/2,feetY-REAL_SPRITE_FEET*swd+bobY,swd,swd);
    ctx.restore();
    ctx.restore();
    const bw3=S*.64,bx3=cx-bw3/2,by3=ry*S+3;
    rr(bx3,by3,bw3,9,4.5);ctx.fillStyle='rgba(10,12,8,.72)';ctx.fill();
    ctx.lineWidth=1.6;ctx.strokeStyle='rgba(255,255,255,.85)';ctx.stroke();
    if(un.hp>0){rr(bx3+1.6,by3+1.6,(bw3-3.2)*un.hp/un.maxHp,5.8,2.9);ctx.fillStyle=un.hp>un.maxHp*0.3?lg(bx3,by3,bx3,by3+9,[[0,'#8df09a'],[1,'#3fb950']]):lg(bx3,by3,bx3,by3+9,[[0,'#ff9a8a'],[1,'#e5484d']]);ctx.fill();}
    if(un.energy===0&&un.team===G.turn&&!G.over){
      rr(cx-26,feetY+8,52,15,7);ctx.fillStyle='rgba(10,10,8,.66)';ctx.fill();
      ctx.fillStyle='#fff';ctx.font='700 10.5px Barlow';ctx.textAlign='center';ctx.fillText('SIN ⚡',cx,feetY+19);ctx.textAlign='left';
    }
    return;
  }
  const sprImg=getSpriteImage(un);
  if(sprImg){
    const swd=S*1.52*turnW;
    const bobY=REDUCED_MOTION?0:Math.sin(FX.t/430+un.id*1.93)*S*0.02;
    ctx.save();
    if(un._flip2d){ctx.translate(cx,0);ctx.scale(-1,1);ctx.translate(-cx,0);}
    ctx.drawImage(sprImg,cx-swd/2,feetY-swd*0.99+bobY,swd,swd);
    ctx.restore();
    if(isNat){
      const bw=S*.17,bh=S*.05,bx=cx-bw/2,by=feetY-swd*0.99+bobY+S*.1;
      ctx.save();rr(bx,by,bw,bh*2.6,3);ctx.clip();
      nc.forEach((c,i)=>{ctx.fillStyle=c;ctx.fillRect(bx,by+i*bh*.87,bw,bh*.87);});
      ctx.restore();
      rr(bx,by,bw,bh*2.6,3);ctx.strokeStyle='rgba(0,0,0,.6)';ctx.lineWidth=1.2;ctx.stroke();
      ctx.beginPath();ctx.arc(cx+S*.3,by+2,S*.075,0,7);ctx.fillStyle='#20261a';ctx.fill();
      ctx.lineWidth=1.5;ctx.strokeStyle='#f2b234';ctx.stroke();
      ctx.fillStyle='#f2b234';ctx.font='700 '+Math.round(S*.105)+'px Barlow';ctx.textAlign='center';
      ctx.fillText(un.nation.emblem,cx+S*.3,by+2+S*.038);ctx.textAlign='left';
    }
    ctx.restore();
    const bw3=S*.64,bx3=cx-bw3/2,by3=ry*S+3;
    rr(bx3,by3,bw3,9,4.5);ctx.fillStyle='rgba(10,12,8,.72)';ctx.fill();
    ctx.lineWidth=1.6;ctx.strokeStyle='rgba(255,255,255,.85)';ctx.stroke();
    if(un.hp>0){rr(bx3+1.6,by3+1.6,(bw3-3.2)*un.hp/un.maxHp,5.8,2.9);ctx.fillStyle=un.hp>un.maxHp*0.3?lg(bx3,by3,bx3,by3+9,[[0,'#8df09a'],[1,'#3fb950']]):lg(bx3,by3,bx3,by3+9,[[0,'#ff9a8a'],[1,'#e5484d']]);ctx.fill();}
    if(un.energy===0&&un.team===G.turn&&!G.over){
      rr(cx-26,feetY+8,52,15,7);ctx.fillStyle='rgba(10,10,8,.66)';ctx.fill();
      ctx.fillStyle='#fff';ctx.font='700 10.5px Barlow';ctx.textAlign='center';ctx.fillText('SIN ⚡',cx,feetY+19);ctx.textAlign='left';
    }
    return;
  }
  /* Silueta por rol también en este dibujo de reserva: todo el cuerpo
     (piernas, torso, arma y cabeza) se estira o se encoge desde los
     pies con la escala de ROLE_LOOK, la misma del modelo 3D, así el
     Artillero se ve enorme y el Espía pequeño en las dos vistas. La
     sombra, el anillo de energía y la barra de vida quedan fuera de
     la escala: se dibujaron antes o se dibujan tras el restore. */
  ctx.translate(cx,feetY);ctx.scale(lk2.s[0],lk2.s[1]);ctx.translate(-cx,-feetY);
  /* dirección del arma: la de mira lógica, con su giro animado */
  const ang=yaw2;
  const faceDir=Math.max(-1,Math.min(1,Math.cos(ang)));
  /* mochila / botiquín trasero según rol */
  if(un.role==='Médico'||un.role==='Ingeniero'||un.role==='Espía'){
    rr(cx-S*.3,cy+S*.02,S*.17,S*.24,4);
    ctx.fillStyle=un.role==='Médico'?'#eef0e6':un.role==='Ingeniero'?'#5b5348':'#353144';ctx.fill();
    ctx.lineWidth=1.6;ctx.strokeStyle='rgba(0,0,0,.4)';ctx.stroke();
    if(un.role==='Médico'){ctx.fillStyle='#d92c2c';ctx.fillRect(cx-S*.235-1.5,cy+S*.08,3,11);ctx.fillRect(cx-S*.235-5.5,cy+S*.12,11,3);}
  }
  /* piernas y botas */
  ctx.fillStyle=shade(uniCol,-32);
  rr(cx-S*.17,cy+S*.26,S*.13,S*.13,4);ctx.fill();rr(cx+S*.04,cy+S*.26,S*.13,S*.13,4);ctx.fill();
  ctx.fillStyle='#241f1a';
  rr(cx-S*.19,feetY-5,S*.16,6,3);ctx.fill();rr(cx+S*.03,feetY-5,S*.16,6,3);ctx.fill();
  /* torso con volumen: uniforme de la nación y chaleco del rol */
  const twd=S*.60*bulky,th=S*.36,tx=cx-twd/2,ty=cy+S*.03;
  rr(tx,ty,twd,th,10);
  ctx.fillStyle=lg(tx,ty,tx,ty+th,[[0,shade(uniCol,28)],[.55,uniCol],[1,shade(uniCol,-30)]]);ctx.fill();
  ctx.lineWidth=2.4;ctx.strokeStyle='rgba(12,12,10,.55)';ctx.stroke();
  rr(cx-S*.19*bulky,ty+4,S*.38*bulky,th-9,7);
  ctx.fillStyle=lg(cx,ty,cx,ty+th,[[0,shade(roleCol,22)],[1,shade(roleCol,-26)]]);ctx.fill();
  ctx.lineWidth=1.6;ctx.strokeStyle='rgba(0,0,0,.35)';ctx.stroke();
  /* cinturón y cartucheras */
  ctx.fillStyle='rgba(20,16,10,.65)';ctx.fillRect(tx+4,ty+th-8,twd-8,5);
  ctx.fillStyle='rgba(255,255,255,.16)';ctx.fillRect(cx-S*.13,ty+th-7,S*.07,3.4);ctx.fillRect(cx+S*.02,ty+th-7,S*.07,3.4);
  if(isNat){
    /* escudo de pecho con las franjas de la nación y su emblema */
    const bw=S*.15,bh=S*.045,bx=cx-bw/2,by=ty+5;
    ctx.save();rr(bx,by,bw,bh*2.4,3);ctx.clip();
    nc.forEach((c,i)=>{ctx.fillStyle=c;ctx.fillRect(bx,by+i*bh*.8,bw,bh*.8);});
    ctx.restore();
    rr(bx,by,bw,bh*2.4,3);ctx.strokeStyle='rgba(0,0,0,.55)';ctx.lineWidth=1.2;ctx.stroke();
    ctx.beginPath();ctx.arc(cx+S*.235*bulky,ty+9,S*.072,0,7);ctx.fillStyle='#20261a';ctx.fill();
    ctx.lineWidth=1.5;ctx.strokeStyle='#f2b234';ctx.stroke();
    ctx.fillStyle='#f2b234';ctx.font='700 '+Math.round(S*.1)+'px Barlow';ctx.textAlign='center';
    ctx.fillText(un.nation.emblem,cx+S*.235*bulky,ty+9+S*.036);ctx.textAlign='left';
  } else {
    ctx.fillStyle='rgba(0,0,0,.16)';rr(cx-S*.07,ty+6,S*.14,S*.08,2);ctx.fill();
  }
  if(un.role==='Artillero'){ /* cinta de munición cruzada */
    ctx.strokeStyle='#e8c84e';ctx.lineWidth=4.4;ctx.beginPath();ctx.moveTo(tx+5,ty+4);ctx.lineTo(tx+twd-5,ty+th-6);ctx.stroke();
    ctx.strokeStyle='rgba(90,64,8,.8)';ctx.lineWidth=1.2;ctx.setLineDash([3,4]);ctx.beginPath();ctx.moveTo(tx+5,ty+4);ctx.lineTo(tx+twd-5,ty+th-6);ctx.stroke();ctx.setLineDash([]);
  }
  if(un.role==='Comando'){ctx.fillStyle='#42591c';[-.09,-.03,.03,.09].forEach(o=>{rr(cx+o*S-3.4,ty+th-16,6.8,9,2.4);ctx.fill();ctx.strokeStyle='rgba(0,0,0,.35)';ctx.lineWidth=1;ctx.stroke();});}
  /* brazos */
  ctx.fillStyle=shade(uniCol,-8);
  ctx.beginPath();ctx.arc(cx-S*.3*bulky,cy+S*.13,S*.085,0,7);ctx.fill();
  ctx.beginPath();ctx.arc(cx+S*.3*bulky,cy+S*.13,S*.085,0,7);ctx.fill();
  ctx.lineWidth=1.6;ctx.strokeStyle='rgba(0,0,0,.3)';
  ctx.beginPath();ctx.arc(cx-S*.3*bulky,cy+S*.13,S*.085,0,7);ctx.stroke();
  ctx.beginPath();ctx.arc(cx+S*.3*bulky,cy+S*.13,S*.085,0,7);ctx.stroke();
  /* arma con volumen, apuntando al enemigo más cercano */
  ctx.save();ctx.translate(cx,cy+S*.17);ctx.rotate(ang);
  const wcat=WEAPONS[un.weapon].cat;
  const gl=wcat==='Francotirador'?S*.5:(wcat==='Ametralladoras'||wcat==='Lanzacohetes')?S*.44:(wcat==='Escopetas')?S*.34:S*.37;
  if(wcat==='Lanzacohetes'){
    rr(S*.02,-S*.075,gl*1.08,S*.15,5);ctx.fillStyle=lg(0,-S*.075,0,S*.075,[[0,'#6d8140'],[.5,'#4a5d23'],[1,'#33431a']]);ctx.fill();
    ctx.lineWidth=2;ctx.strokeStyle='rgba(0,0,0,.5)';ctx.stroke();
    ctx.beginPath();ctx.moveTo(S*.02+gl*1.08,-S*.05);ctx.lineTo(S*.02+gl*1.24,0);ctx.lineTo(S*.02+gl*1.08,S*.05);ctx.closePath();ctx.fillStyle='#8a8f7a';ctx.fill();ctx.stroke();
  } else {
    rr(S*.06,-3.4,gl,6.8,2.6);ctx.fillStyle=lg(0,-3.4,0,3.4,[[0,'#4a4d52'],[.45,'#26282c'],[1,'#101114']]);ctx.fill();
    ctx.lineWidth=1.4;ctx.strokeStyle='rgba(0,0,0,.6)';ctx.stroke();
    rr(S*.06+gl*.5,2.6,gl*.17,5.4,1.6);ctx.fillStyle='#1b1d20';ctx.fill(); /* cargador */
    rr(S*.06-4,-2.2,6,4.4,1.6);ctx.fillStyle='#33363b';ctx.fill(); /* culata */
    if(wcat==='Francotirador'){
      rr(S*.06+gl*.32,-8.6,gl*.26,5,2);ctx.fillStyle='#0c0d0f';ctx.fill();
      ctx.beginPath();ctx.arc(S*.06+gl*.45,-6,S*.028,0,7);ctx.fillStyle='#8fd8ff';ctx.fill();
      ctx.strokeStyle='#3a3d40';ctx.lineWidth=2;ctx.beginPath();
      ctx.moveTo(S*.06+gl*.6,3);ctx.lineTo(S*.06+gl*.78,10);ctx.moveTo(S*.06+gl*.6,3);ctx.lineTo(S*.06+gl*.44,10);ctx.stroke();
    }
    if(wcat==='Ametralladoras'){
      rr(S*.06+gl*.34,3,S*.15,S*.11,2);ctx.fillStyle='#3f6216';ctx.fill();ctx.strokeStyle='rgba(0,0,0,.5)';ctx.lineWidth=1.2;ctx.stroke();
    }
    if(wcat==='Escopetas'){rr(S*.06+gl*.4,3.4,gl*.22,3.6,1.6);ctx.fillStyle='#7a4a22';ctx.fill();}
    ctx.fillStyle='rgba(255,255,255,.35)';ctx.fillRect(S*.09,-2.6,gl*.8,1.4);
  }
  ctx.restore();
  /* manos sobre el arma */
  ctx.fillStyle=skin;
  ctx.beginPath();ctx.arc(cx+Math.cos(ang)*S*.2-Math.sin(ang)*2,cy+S*.17+Math.sin(ang)*S*.2,S*.05,0,7);ctx.fill();
  ctx.beginPath();ctx.arc(cx+Math.cos(ang)*S*.36,cy+S*.17+Math.sin(ang)*S*.36,S*.048,0,7);ctx.fill();
  /* CABEZA GRANDE con volumen */
  const hr=S*.265, hy=cy-S*.15;
  ctx.beginPath();ctx.ellipse(cx,hy+hr*.92,S*.1,S*.05,0,0,7);ctx.fillStyle=shade(skin,-30);ctx.fill(); /* cuello */
  if(un.role==='Espía'){
    ctx.beginPath();ctx.arc(cx,hy,hr*1.14,0,7);
    ctx.fillStyle=lg(cx,hy-hr,cx,hy+hr,[[0,'#453e5c'],[1,'#241f33']]);ctx.fill();
    ctx.lineWidth=2.2;ctx.strokeStyle='rgba(0,0,0,.55)';ctx.stroke();
  }
  ctx.beginPath();ctx.arc(cx,hy,hr,0,7);
  ctx.fillStyle=rg(cx,hy,hr,[[0,shade(skin,26)],[.6,skin],[1,shade(skin,-24)]]);ctx.fill();
  ctx.lineWidth=2.2;ctx.strokeStyle='rgba(60,32,14,.5)';ctx.stroke();
  /* orejas */
  ctx.fillStyle=shade(skin,-8);
  ctx.beginPath();ctx.arc(cx-hr*.97,hy+hr*.14,hr*.15,0,7);ctx.arc(cx+hr*.97,hy+hr*.14,hr*.15,0,7);ctx.fill();
  if(un.role!=='Espía'){
    /* casco abovedado con brillo, ala y banda de la nación */
    const helmetBase=!isNat?helmetCol:((helmetCol==='#FFFFFF'||helmetCol===nc[0])?shade(nc[0],-25):helmetCol);
    ctx.beginPath();ctx.arc(cx,hy-hr*.06,hr*1.05,Math.PI*.98,Math.PI*2.02);
    ctx.fillStyle=lg(cx,hy-hr*1.2,cx,hy,[[0,shade(helmetBase,42)],[.55,helmetBase],[1,shade(helmetBase,-28)]]);ctx.fill();
    ctx.lineWidth=2.2;ctx.strokeStyle='rgba(0,0,0,.45)';ctx.stroke();
    ctx.beginPath();ctx.arc(cx,hy-hr*.06,hr*1.05,Math.PI*1.28,Math.PI*1.72);ctx.strokeStyle=bandCol;ctx.lineWidth=S*.075;ctx.stroke();
    rr(cx-hr*1.14,hy-hr*.24,hr*2.28,hr*.17,4);ctx.fillStyle=shade(helmetBase,-12);ctx.fill();
    ctx.lineWidth=1.6;ctx.strokeStyle='rgba(0,0,0,.45)';ctx.stroke();
    ctx.beginPath();ctx.ellipse(cx-hr*.42,hy-hr*.78,hr*.3,hr*.11,-.5,0,7);ctx.fillStyle='rgba(255,255,255,.4)';ctx.fill();
    /* correa */
    ctx.strokeStyle='rgba(30,24,16,.65)';ctx.lineWidth=2;ctx.beginPath();ctx.moveTo(cx-hr*.8,hy+hr*.3);ctx.quadraticCurveTo(cx,hy+hr*1.04,cx+hr*.8,hy+hr*.3);ctx.stroke();
  }
  /* equipo de rol sobre el casco */
  if(un.role==='Médico'){
    rr(cx-hr*.32,hy-hr*1.06,hr*.64,hr*.44,3);ctx.fillStyle='#fff';ctx.fill();ctx.lineWidth=1.4;ctx.strokeStyle='rgba(0,0,0,.3)';ctx.stroke();
    ctx.fillStyle='#d92c2c';ctx.fillRect(cx-2.2,hy-hr*1.0,4.4,hr*.32);ctx.fillRect(cx-hr*.12,hy-hr*.9,hr*.24,4.4);
  }
  if(un.role==='Capitán'){
    ctx.fillStyle='#ffd94d';ctx.font='700 '+Math.round(S*.21)+'px Barlow';ctx.textAlign='center';
    ctx.fillText('★',cx,hy-hr*.6);ctx.textAlign='left';
  }
  if(un.role==='Ingeniero'){ /* gafas de trabajo levantadas */
    rr(cx-hr*.66,hy-hr*.52,hr*1.32,hr*.3,6);ctx.fillStyle='rgba(18,22,26,.88)';ctx.fill();
    ctx.fillStyle='rgba(127,212,255,.85)';
    ctx.beginPath();ctx.arc(cx-hr*.32,hy-hr*.37,hr*.17,0,7);ctx.arc(cx+hr*.32,hy-hr*.37,hr*.17,0,7);ctx.fill();
    ctx.fillStyle='rgba(255,255,255,.75)';
    ctx.beginPath();ctx.arc(cx-hr*.38,hy-hr*.44,hr*.06,0,7);ctx.arc(cx+hr*.26,hy-hr*.44,hr*.06,0,7);ctx.fill();
  }
  if(un.role==='Francotirador'){ /* red de camuflaje */
    ctx.strokeStyle='#4d6b1f';ctx.lineWidth=2.6;
    for(let i=-2;i<=2;i++){ctx.beginPath();ctx.moveTo(cx+i*hr*.32,hy-hr*.95);ctx.quadraticCurveTo(cx+i*hr*.4,hy-hr*1.18,cx+i*hr*.3,hy-hr*1.34);ctx.stroke();}
    ctx.strokeStyle='#6d8a3e';ctx.lineWidth=1.6;
    for(let i=-1;i<=1;i++){ctx.beginPath();ctx.moveTo(cx+i*hr*.34,hy-hr*.9);ctx.lineTo(cx+i*hr*.44,hy-hr*1.2);ctx.stroke();}
  }
  if(un.role==='Artillero'){ /* cascos de comunicaciones */
    ctx.fillStyle='#2b2b2e';
    ctx.beginPath();ctx.arc(cx-hr*1.0,hy+hr*.1,hr*.2,0,7);ctx.arc(cx+hr*1.0,hy+hr*.1,hr*.2,0,7);ctx.fill();
    ctx.strokeStyle='#2b2b2e';ctx.lineWidth=3.4;ctx.beginPath();ctx.arc(cx,hy-hr*.04,hr*1.08,Math.PI*1.05,Math.PI*1.95);ctx.stroke();
  }
  /* cara: ojos que miran hacia el enemigo, cejas decididas */
  const ey=hy+hr*.24, ex=hr*.37, look=faceDir*hr*.05;
  if(un.role==='Espía'){
    rr(cx-hr*.92,ey-hr*.3,hr*1.84,hr*.52,8);ctx.fillStyle='#14111d';ctx.fill();
    ctx.fillStyle='#fff';ctx.beginPath();ctx.arc(cx-ex,ey,hr*.14,0,7);ctx.arc(cx+ex,ey,hr*.14,0,7);ctx.fill();
    ctx.fillStyle='#14111d';ctx.beginPath();ctx.arc(cx-ex+look,ey,hr*.075,0,7);ctx.arc(cx+ex+look,ey,hr*.075,0,7);ctx.fill();
  } else {
    ctx.fillStyle='#fff';
    ctx.beginPath();ctx.arc(cx-ex,ey,hr*.18,0,7);ctx.arc(cx+ex,ey,hr*.18,0,7);ctx.fill();
    ctx.fillStyle='#1c1a17';
    ctx.beginPath();ctx.arc(cx-ex+look,ey+1,hr*.095,0,7);ctx.arc(cx+ex+look,ey+1,hr*.095,0,7);ctx.fill();
    ctx.fillStyle='#fff';
    ctx.beginPath();ctx.arc(cx-ex+look-1.4,ey-.6,hr*.032,0,7);ctx.arc(cx+ex+look-1.4,ey-.6,hr*.032,0,7);ctx.fill();
    ctx.strokeStyle='#241a12';ctx.lineWidth=2.4;ctx.beginPath();
    ctx.moveTo(cx-ex-hr*.17,ey-hr*.34);ctx.lineTo(cx-ex+hr*.15,ey-hr*.22);
    ctx.moveTo(cx+ex+hr*.17,ey-hr*.34);ctx.lineTo(cx+ex-hr*.15,ey-hr*.22);ctx.stroke();
    if(un.role==='Capitán'){ /* bigote de oficial */
      ctx.strokeStyle='#3a2c1c';ctx.lineWidth=3.2;ctx.beginPath();
      ctx.arc(cx-hr*.14,hy+hr*.52,hr*.15,Math.PI*.15,Math.PI*.8);ctx.stroke();
      ctx.beginPath();ctx.arc(cx+hr*.14,hy+hr*.52,hr*.15,Math.PI*.2,Math.PI*.85);ctx.stroke();
    } else if(un.role==='Comando'){ /* pintura de guerra */
      ctx.fillStyle='rgba(38,44,30,.75)';
      ctx.save();ctx.translate(cx-ex,ey+hr*.3);ctx.rotate(-.25);ctx.fillRect(-hr*.16,-2,hr*.32,3.6);ctx.restore();
      ctx.save();ctx.translate(cx+ex,ey+hr*.3);ctx.rotate(.25);ctx.fillRect(-hr*.16,-2,hr*.32,3.6);ctx.restore();
      ctx.strokeStyle='rgba(70,42,22,.85)';ctx.lineWidth=1.8;ctx.beginPath();ctx.moveTo(cx-hr*.13,hy+hr*.66);ctx.lineTo(cx+hr*.13,hy+hr*.66);ctx.stroke();
    } else {
      ctx.strokeStyle='rgba(70,42,22,.85)';ctx.lineWidth=1.8;ctx.beginPath();
      ctx.arc(cx,hy+hr*.5,hr*.26,Math.PI*.3,Math.PI*.7);ctx.stroke();
    }
  }
  if(un.role==='Médico'){ /* botiquín en la mano */
    rr(cx+S*.21,cy+S*.24,S*.15,S*.12,3);ctx.fillStyle='#f2f2ea';ctx.fill();ctx.lineWidth=1.5;ctx.strokeStyle='rgba(0,0,0,.4)';ctx.stroke();
    ctx.fillStyle='#d92c2c';ctx.fillRect(cx+S*.278,cy+S*.262,3,S*.075);ctx.fillRect(cx+S*.252,cy+S*.288,S*.05,3);
  }
  ctx.restore();
  /* barra de vida flotante, pastilla con borde blanco */
  const bw=S*.64,bx=cx-bw/2,by=ry*S+3;
  rr(bx,by,bw,9,4.5);ctx.fillStyle='rgba(10,12,8,.72)';ctx.fill();
  ctx.lineWidth=1.6;ctx.strokeStyle='rgba(255,255,255,.85)';ctx.stroke();
  if(un.hp>0){rr(bx+1.6,by+1.6,(bw-3.2)*un.hp/un.maxHp,5.8,2.9);ctx.fillStyle=un.hp>un.maxHp*0.3?lg(bx,by,bx,by+9,[[0,'#8df09a'],[1,'#3fb950']]):lg(bx,by,bx,by+9,[[0,'#ff9a8a'],[1,'#e5484d']]);ctx.fill();}
  if(un.energy===0&&un.team===G.turn&&!G.over){
    rr(cx-26,feetY+8,52,15,7);ctx.fillStyle='rgba(10,10,8,.66)';ctx.fill();
    ctx.fillStyle='#fff';ctx.font='700 10.5px Barlow';ctx.textAlign='center';ctx.fillText('SIN ⚡',cx,feetY+19);ctx.textAlign='left';
  }
}
