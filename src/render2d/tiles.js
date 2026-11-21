export function hash2(x,y){let h=(x*374761393+y*668265263)^(x*1274126177);h=Math.imul(h^(h>>>13),1274126177);return ((h^(h>>>16))>>>0)/4294967296;}

export function rr(x,y,w,h,r){r=Math.min(r,w/2,h/2);ctx.beginPath();ctx.moveTo(x+r,y);ctx.arcTo(x+w,y,x+w,y+h,r);ctx.arcTo(x+w,y+h,x,y+h,r);ctx.arcTo(x,y+h,x,y,r);ctx.arcTo(x,y,x+w,y,r);ctx.closePath();}

export function lg(x0,y0,x1,y1,stops){const g=ctx.createLinearGradient(x0,y0,x1,y1);stops.forEach(s=>g.addColorStop(s[0],s[1]));return g;}

export function rg(cx,cy,r,stops){const g=ctx.createRadialGradient(cx-r*.35,cy-r*.4,r*.12,cx,cy,r);stops.forEach(s=>g.addColorStop(s[0],s[1]));return g;}

export function shade(hex,amt){
  if(!hex||hex[0]!=='#'||hex.length<7)return hex;
  const n=parseInt(hex.slice(1),16);let r=(n>>16)+amt,g=(n>>8&255)+amt,b=(n&255)+amt;
  r=Math.max(0,Math.min(255,r));g=Math.max(0,Math.min(255,g));b=Math.max(0,Math.min(255,b));
  return '#'+((r<<16)|(g<<8)|b).toString(16).padStart(6,'0');
}

export function block3D(px,py,S,h,top,front,side,m){
  m=(m==null?3:m);
  const x0=px+m,y0=py+m,x1=px+S-m,y1=py+S-m,dx=S*.1;
  ctx.beginPath(); /* lateral derecho */
  ctx.moveTo(x1,y0);ctx.lineTo(x1+dx,y0-h);ctx.lineTo(x1+dx,y1-h);ctx.lineTo(x1,y1);ctx.closePath();
  ctx.fillStyle=side;ctx.fill();
  ctx.beginPath(); /* frontal */
  ctx.moveTo(x0,y1);ctx.lineTo(x1,y1);ctx.lineTo(x1+dx,y1-h);ctx.lineTo(x0+dx,y1-h);ctx.closePath();
  ctx.fillStyle=front;ctx.fill();
  ctx.beginPath(); /* superior */
  ctx.moveTo(x0,y0);ctx.lineTo(x1,y0);ctx.lineTo(x1+dx,y0-h);ctx.lineTo(x0+dx,y0-h);ctx.closePath();
  ctx.fillStyle=top;ctx.fill();
  ctx.strokeStyle='rgba(0,0,0,.35)';ctx.lineWidth=1.5;
  ctx.beginPath();ctx.moveTo(x0,y0);ctx.lineTo(x1,y0);ctx.lineTo(x1+dx,y0-h);ctx.lineTo(x0+dx,y0-h);ctx.closePath();ctx.stroke();
  ctx.strokeStyle='rgba(255,255,255,.20)';ctx.lineWidth=1.2;
  ctx.beginPath();ctx.moveTo(x0+dx,y0-h);ctx.lineTo(x1+dx,y0-h);ctx.stroke();
  return {x0:x0,y0:y0,x1:x1,y1:y1,dx:dx,h:h};
}

export function drawFloorTile(x,y,S){
  const px=x*S,py=y*S,h=hash2(x,y);
  const skirm=G&&G.map&&!!skState(G.map.theme);
  const depot=G&&G.map&&G.map.theme==='depot';
  const platform=G&&G.map&&G.map.theme==='platform';
  const market=G&&G.map&&G.map.theme==='market';
  const terminal=G&&G.map&&G.map.theme==='terminal';
  const plaza=G&&G.map&&G.map.theme==='plaza';
  const dock=G&&G.map&&G.map.theme==='dock';
  const rotonda=G&&G.map&&G.map.theme==='rotonda';
  const cruce=G&&G.map&&G.map.theme==='cruce';
  const astillero=G&&G.map&&G.map.theme==='astillero';
  const asphalt=(y===H-1);
  let base;
  /* En Skirmish_03 estas losas grises son solo el fondo de reserva: en
     cuanto carga su plano cenital (la imagen derivada de la geometría
     real del IPA), draw() lo dibuja encima y el suelo pasa a ser el
     del mapa de Londres de verdad. El depósito de Skirmish_05 no tiene
     plano cenital (su paquete no se ha extraído): su suelo son estas
     losas gris azuladas, dibujadas en código como las del Patio. */
  if(plaza)base=['#a8a294','#9f9a8c','#b0aa9c','#97927f'][Math.floor(h*4)];
  else if(cruce)base=['#6b5850','#63524b','#736259','#5b4c45'][Math.floor(h*4)];
  else if(astillero)base=['#42565e','#3c5058','#4a5e66','#364a52'][Math.floor(h*4)];
  else if(rotonda)base=['#5f5b52','#57534b','#67635b','#4f4c44'][Math.floor(h*4)];
  else if(dock)base=['#4e5d5c','#465554','#576664','#3f4f4e'][Math.floor(h*4)];
  else if(platform)base=['#6f6259','#665a50','#786a5e','#5d5148'][Math.floor(h*4)];
  else if(market)base=['#8a7a5c','#82724f','#93835f','#7a6a4e'][Math.floor(h*4)];
  else if(terminal)base=['#4f5a63','#48525b','#57626c','#424c54'][Math.floor(h*4)];
  else if(depot)base=['#7d838a','#757b83','#858b91','#6f757d'][Math.floor(h*4)];
  else if(skirm)base=['#7e8288','#787c82','#868a90','#74787e'][Math.floor(h*4)];
  else if(asphalt)base=['#5b5e63','#56595e','#5f6267','#53565b'][Math.floor(h*4)];
  else base=['#99968e','#918e85','#a09d94','#8b887f'][Math.floor(h*4)];
  ctx.fillStyle=base;ctx.fillRect(px,py,S,S);
  /* losa: luz arriba-izquierda y junta oscura */
  ctx.fillStyle='rgba(255,255,255,.09)';ctx.fillRect(px,py,S,2);ctx.fillRect(px,py,2,S);
  ctx.fillStyle='rgba(0,0,0,.20)';ctx.fillRect(px,py+S-2,S,2);ctx.fillRect(px+S-2,py,2,S);
  ctx.strokeStyle='rgba(30,32,36,.55)';ctx.lineWidth=1;ctx.strokeRect(px+.5,py+.5,S-1,S-1);
  if(asphalt){ /* línea de carril discontinua */
    if(x%2===0){ctx.fillStyle='rgba(240,240,230,.55)';ctx.fillRect(px+S*.18,py+S*.48,S*.64,3);}
    return;
  }
  if(h<.16){ /* grietas */
    ctx.strokeStyle='rgba(40,42,46,.4)';ctx.lineWidth=1.2;ctx.beginPath();
    let cx=px+S*(.2+h*.4),cy=py+S*.25;ctx.moveTo(cx,cy);
    ctx.lineTo(cx+S*.14,cy+S*.16);ctx.lineTo(cx+S*.1,cy+S*.3);ctx.lineTo(cx+S*.22,cy+S*.44);ctx.stroke();
  } else if(h<.24){ /* alcantarilla */
    ctx.beginPath();ctx.arc(px+S*.5,py+S*.52,S*.17,0,7);ctx.fillStyle='rgba(52,55,60,.85)';ctx.fill();
    ctx.beginPath();ctx.arc(px+S*.5,py+S*.52,S*.12,0,7);ctx.strokeStyle='rgba(210,214,218,.35)';ctx.lineWidth=2;ctx.stroke();
    ctx.fillStyle='rgba(210,214,218,.3)';ctx.fillRect(px+S*.42,py+S*.5,S*.16,2);
  } else if(h<.31){ /* charco */
    ctx.beginPath();ctx.ellipse(px+S*.55,py+S*.6,S*.24,S*.11,.3,0,7);ctx.fillStyle='rgba(168,205,232,.30)';ctx.fill();
    ctx.beginPath();ctx.ellipse(px+S*.48,py+S*.57,S*.12,S*.045,.3,0,7);ctx.fillStyle='rgba(255,255,255,.28)';ctx.fill();
  } else if(h<.37){ /* papel / cartón tirado */
    ctx.save();ctx.translate(px+S*.62,py+S*.34);ctx.rotate(h*5);
    ctx.fillStyle='rgba(228,224,210,.8)';ctx.fillRect(-S*.09,-S*.06,S*.18,S*.12);
    ctx.fillStyle='rgba(120,116,104,.5)';ctx.fillRect(-S*.06,-S*.02,S*.12,1.6);ctx.fillRect(-S*.06,S*.015,S*.09,1.6);
    ctx.restore();
  } else if(h<.43){ /* mancha de aceite */
    ctx.beginPath();ctx.ellipse(px+S*.4,py+S*.66,S*.2,S*.09,-.2,0,7);ctx.fillStyle='rgba(28,28,34,.28)';ctx.fill();
  } else if(h>.93){ /* pintura de suelo desgastada */
    ctx.strokeStyle='rgba(242,178,52,.4)';ctx.lineWidth=3;ctx.beginPath();
    ctx.moveTo(px+S*.15,py+S*.85);ctx.lineTo(px+S*.85,py+S*.85);ctx.stroke();
  }
}

export function drawWall(o,S){
  const px=o.x*S,py=o.y*S,h=S*.34;
  ctx.fillStyle='rgba(0,0,0,.28)';ctx.beginPath();ctx.ellipse(px+S/2,py+S*.94,S*.44,S*.1,0,0,7);ctx.fill();
  const b=block3D(px,py,S,h,'#a9aeb2','#7f858b','#686e74');
  /* paneles y remaches del frontal */
  ctx.strokeStyle='rgba(0,0,0,.22)';ctx.lineWidth=1.2;
  ctx.beginPath();ctx.moveTo(b.x0+3,b.y1-h+5);ctx.lineTo(b.x1+b.dx-3,b.y1-h+5);ctx.stroke();
  ctx.fillStyle='rgba(255,255,255,.28)';
  [[.14,.62],[.86,.62]].forEach(p=>{ctx.beginPath();ctx.arc(px+S*p[0],py+S*p[1],1.8,0,7);ctx.fill();});
  if(hash2(o.x*3,o.y*7)>.55){ /* banda de peligro */
    ctx.save();rr(b.x0+4,b.y1-11,S*.5,7,2);ctx.clip();
    for(let i=0;i<7;i++){ctx.fillStyle=i%2?'#232323':'#f2b234';ctx.save();ctx.translate(b.x0+i*9,b.y1-13);ctx.rotate(.5);ctx.fillRect(0,0,6,16);ctx.restore();}
    ctx.restore();
  }
}

export function drawContainer(o,S){
  const px=o.x*S,py=o.y*S,h=S*.46;
  const palettes=[['#f4c13d','#dda017','#b57f10'],['#ef7d3c','#d8622b','#ad4c20'],['#4aa3ad','#2e7f86','#256a70']];
  const pal=palettes[Math.floor(hash2(o.x*11,o.y*5)*3)];
  ctx.fillStyle='rgba(0,0,0,.3)';ctx.beginPath();ctx.ellipse(px+S/2,py+S*.95,S*.46,S*.1,0,0,7);ctx.fill();
  const b=block3D(px,py,S,h,pal[0],pal[1],pal[2],2);
  /* corrugación vertical del frontal */
  ctx.strokeStyle='rgba(0,0,0,.10)';ctx.lineWidth=1.5;
  for(let i=1;i<6;i++){const fx=b.x0+ (b.x1-b.x0)*i/6 + b.dx*(1-0)+0;ctx.beginPath();ctx.moveTo(b.x0+(b.x1-b.x0)*i/6+2,b.y1-3);ctx.lineTo(b.x0+(b.x1-b.x0)*i/6+2+b.dx,b.y1-h+3);ctx.stroke();}
  /* marco de puerta y placa */
  ctx.strokeStyle='rgba(0,0,0,.35)';ctx.lineWidth=2;rr(b.x0+S*.3,b.y1-h+6,S*.36,S*.5,2);ctx.stroke();
  ctx.fillStyle='rgba(245,242,230,.85)';ctx.fillRect(b.x0+6,b.y1-h+8,S*.16,S*.12);
  ctx.fillStyle='rgba(30,30,30,.55)';ctx.fillRect(b.x0+8,b.y1-h+11,S*.11,2);ctx.fillRect(b.x0+8,b.y1-h+15,S*.08,2);
}

export function drawCrate(o,S){
  const px=o.x*S,py=o.y*S,h=S*.26;
  ctx.fillStyle='rgba(0,0,0,.28)';ctx.beginPath();ctx.ellipse(px+S/2,py+S*.93,S*.42,S*.09,0,0,7);ctx.fill();
  const b=block3D(px,py,S,h,'#bd8c4e','#9a6c34','#7d5626',4);
  /* tablones y cruceta */
  ctx.strokeStyle='rgba(70,45,16,.55)';ctx.lineWidth=2;
  ctx.beginPath();ctx.moveTo(b.x0+3,b.y1-h+ (S*.28)/2);ctx.lineTo(b.x1+b.dx-3,b.y1-h+(S*.28)/2);ctx.stroke();
  ctx.beginPath();ctx.moveTo(b.x0+4,b.y1-h+4);ctx.lineTo(b.x1+b.dx-4,b.y1-4);ctx.moveTo(b.x1+b.dx-4,b.y1-h+4);ctx.lineTo(b.x0+4,b.y1-4);ctx.stroke();
  ctx.fillStyle='rgba(40,26,8,.7)';
  [[b.x0+6,b.y1-h+6],[b.x1+b.dx-6,b.y1-h+6],[b.x0+6,b.y1-6],[b.x1+b.dx-6,b.y1-6]].forEach(p=>{ctx.beginPath();ctx.arc(p[0],p[1],1.7,0,7);ctx.fill();});
  if(o.hp<o.maxHp){
    rr(px+7,py+S-12,S-14,6,3);ctx.fillStyle='rgba(0,0,0,.65)';ctx.fill();
    rr(px+8,py+S-11,(S-16)*Math.max(0,o.hp/o.maxHp),4,2);ctx.fillStyle='#e5484d';ctx.fill();
  }
}

export function drawBarrel(b,S){
  const px=b.x*S,py=b.y*S,cx=px+S/2,top=py+S*.3,bot=py+S*.82,w=S*.31;
  ctx.fillStyle='rgba(0,0,0,.32)';ctx.beginPath();ctx.ellipse(cx,py+S*.86,S*.36,S*.1,0,0,7);ctx.fill();
  ctx.fillStyle=lg(cx-w,0,cx+w,0,[[0,'#8e231d'],[.3,'#cf3a30'],[.55,'#e0584c'],[1,'#7c1d18']]);
  ctx.beginPath();ctx.moveTo(cx-w,top);ctx.lineTo(cx-w,bot);ctx.ellipse(cx,bot,w,S*.09,0,Math.PI,0,true);ctx.lineTo(cx+w,top);ctx.closePath();ctx.fill();
  ctx.beginPath();ctx.ellipse(cx,top,w,S*.1,0,0,7);ctx.fillStyle='#e88a80';ctx.fill();
  ctx.beginPath();ctx.ellipse(cx,top,w*.72,S*.065,0,0,7);ctx.fillStyle='#c94035';ctx.fill();
  ctx.strokeStyle='rgba(60,8,5,.55)';ctx.lineWidth=2.4;
  [top+S*.16,top+S*.36].forEach(yy=>{ctx.beginPath();ctx.ellipse(cx,yy,w,S*.085,0,0,Math.PI);ctx.stroke();});
  ctx.fillStyle='rgba(255,255,255,.35)';ctx.fillRect(cx-w*.62,top+4,4,bot-top-8);
  /* aviso de peligro */
  ctx.fillStyle='#ffd94d';ctx.beginPath();ctx.moveTo(cx,top+S*.2);ctx.lineTo(cx+S*.075,top+S*.36);ctx.lineTo(cx-S*.075,top+S*.36);ctx.closePath();ctx.fill();
  ctx.fillStyle='#7c1d18';ctx.font='700 '+Math.round(S*.13)+'px Barlow';ctx.textAlign='center';ctx.fillText('!',cx,top+S*.345);ctx.textAlign='left';
}

export function drawMedkit(m,S){
  const px=m.x*S,py=m.y*S;
  ctx.fillStyle='rgba(0,0,0,.25)';ctx.beginPath();ctx.ellipse(px+S/2,py+S*.8,S*.3,S*.08,0,0,7);ctx.fill();
  const b=block3D(px+S*.16,py+S*.2,S*.68,S*.14,'#ffffff','#e8e6da','#c9c6b8',1);
  ctx.fillStyle='#d92c2c';
  const cx=px+S/2+ b.dx/2, cy=py+S*.2 - S*.14 + S*.2;
  ctx.fillRect(cx-2,cy-7,4,14);ctx.fillRect(cx-7,cy-2,14,4);
  ctx.fillStyle='#d92c2c';ctx.fillRect(px+S*.46,py+S*.52,4,12);ctx.fillRect(px+S*.42,py+S*.56,12,4);
}

export function drawPlatform(S){
  const tp=TURRET_POS,cx=tp.x*S+S/2,cy=tp.y*S+S/2;
  ctx.beginPath();ctx.ellipse(cx,cy+S*.3,S*.4,S*.12,0,0,7);ctx.fillStyle='rgba(0,0,0,.3)';ctx.fill();
  ctx.beginPath();ctx.ellipse(cx,cy,S*.4,S*.34,0,0,7);
  ctx.fillStyle=lg(cx,cy-S*.3,cx,cy+S*.3,[[0,'#c7ccd1'],[.55,'#9aa1a7'],[1,'#767d84']]);ctx.fill();
  ctx.lineWidth=2.5;ctx.strokeStyle='#4c5257';ctx.stroke();
  ctx.beginPath();ctx.ellipse(cx,cy,S*.27,S*.22,0,0,7);ctx.fillStyle='#5d646b';ctx.fill();ctx.strokeStyle='rgba(255,255,255,.25)';ctx.lineWidth=1.5;ctx.stroke();
  for(let i=0;i<8;i++){const a=i/8*Math.PI*2;ctx.beginPath();ctx.arc(cx+Math.cos(a)*S*.34,cy+Math.sin(a)*S*.27,2.2,0,7);ctx.fillStyle='#3c4146';ctx.fill();}
  const owner=G.map.turret.owner;
  ctx.beginPath();ctx.ellipse(cx,cy,S*.16,S*.12,0,0,7);
  ctx.fillStyle=owner==='A'?'#39c2d7':owner==='B'?'#ff7a45':'#f2b234';ctx.fill();
  ctx.strokeStyle='rgba(0,0,0,.4)';ctx.lineWidth=1.5;ctx.stroke();
  /* cañón de la torreta central */
  let ang=owner==='B'?Math.PI:0;
  const foes=G.units.filter(e=>e.alive&&e.team!==owner);
  if(owner&&foes.length){foes.sort((a,b)=>cheb(TURRET_POS,a)-cheb(TURRET_POS,b));ang=Math.atan2(foes[0].y-TURRET_POS.y,foes[0].x-TURRET_POS.x);}
  else if(!owner&&!REDUCED_MOTION){ang=Math.sin(FX.t/1500)*1.1;}
  /* Giro suave también aquí: el cañón persigue su ángulo por el arco corto. */
  const tur=G.map.turret;
  if(tur._dispYaw==null||REDUCED_MOTION)tur._dispYaw=ang;else tur._dispYaw+=shortestArc(ang-tur._dispYaw)*0.25;
  ang=tur._dispYaw;
  ctx.save();ctx.translate(cx,cy);ctx.rotate(ang);
  ctx.fillStyle='#2c2f33';rr(S*.06,-3.4,S*.3,6.8,2);ctx.fill();
  ctx.fillStyle='#454a4f';rr(S*.06,-4.6,S*.1,3,1.5);ctx.fill();
  ctx.restore();
  ctx.fillStyle='#fff';ctx.font='700 '+Math.round(S*.16)+'px Barlow';ctx.textAlign='center';
  ctx.fillText('⚙',cx,cy+S*.055);ctx.textAlign='left';
}

export function segRing(cx,cy,rx,ry,un){
  const segs=un.maxEnergy,live=un.energy;
  const ratio=un.maxHp?un.hp/un.maxHp:(un.hp/100);
  const hpCol=ratio>0.5?'#69d66f':ratio>0.25?'#f2b234':'#ff6b5e';
  for(let i=0;i<segs;i++){
    const a0=-Math.PI/2+i*(Math.PI*2/segs)+.07,a1=-Math.PI/2+(i+1)*(Math.PI*2/segs)-.07;
    ctx.beginPath();ctx.ellipse(cx,cy,rx,ry,0,a0,a1);
    ctx.strokeStyle=i<live?hpCol:'rgba(18,20,16,.55)';ctx.lineWidth=5.5;ctx.stroke();
    ctx.beginPath();ctx.ellipse(cx,cy,rx,ry,0,a0,a1);
    ctx.strokeStyle=i<live?'rgba(255,255,255,.35)':'rgba(255,255,255,.06)';ctx.lineWidth=1.4;ctx.stroke();
  }
  /* punto de bando en el frente del anillo */
  ctx.beginPath();ctx.arc(cx,cy+ry,4.6,0,7);ctx.fillStyle=un.team==='A'?'#39c2d7':'#ff7a45';ctx.fill();
  ctx.lineWidth=1.6;ctx.strokeStyle='rgba(0,0,0,.55)';ctx.stroke();
}
