export function classicBoardMetrics(width,height){
  const S=Math.min(width/W,height/H)*0.9;
  return {S,offsetX:(width-W*S)/2,offsetY:(height-H*S)/2};
}

export function classicTileFromPoint(px,py,width,height){
  const {S,offsetX,offsetY}=classicBoardMetrics(width,height);
  const x=Math.floor((px-offsetX)/S),y=Math.floor((py-offsetY)/S);
  return (x>=0&&y>=0&&x<W&&y<H)?{x,y}:null;
}

export function draw(){
  if(!G)return;
  /* Interpolación de posiciones: la posición de dibujo persigue a la
     casilla lógica, y así ningún soldado se teletransporta. */
  const drawNow=FX.t||performance.now();
  G.units.forEach(un=>updateUnitDrawPosition(un,drawNow));
  if(G.drone)updateUnitDrawPosition(G.drone,drawNow);
  if(VIEW_MODE==='3d'){if(FX.shake>0.4&&!REDUCED_MOTION)FX.shake*=0.86;else FX.shake=0;return;}
  const {S,offsetX,offsetY}=classicBoardMetrics(canvas.width,canvas.height);
  const boardW=W*S,boardH=H*S;
  ctx.clearRect(0,0,canvas.width,canvas.height);
  ctx.save();
  ctx.translate(offsetX,offsetY);
  if(FX.shake>0.4&&!REDUCED_MOTION){ctx.translate((Math.random()-.5)*FX.shake,(Math.random()-.5)*FX.shake);FX.shake*=0.86;}else FX.shake=0;
  /* suelo urbano */
  for(let y=0;y<H;y++)for(let x=0;x<W;x++)drawFloorTile(x,y,S);
  /* Skirmish del IPA: el suelo de verdad es su plano cenital, generado
     desde la geometría real del paquete (las caras superiores de
     Theme_01_Skirmish_03 o de Theme_01_Skirmish_04 con el color de sus
     atlas), dibujado sobre las losas de reserva con la misma escala y
     el mismo centro que usa la capa 3D, y con las juntas de la
     cuadrícula repasadas muy tenues para que las casillas se sigan
     leyendo. Es solo el escenario: las piezas jugables se dibujan
     encima como en los otros tableros. */
  const skTop=skState(G.map.theme);
  if(skTop&&skTop.topReady&&skTop.topImg){
    ctx.drawImage(skTop.topImg,0,0,boardW,boardH);
    ctx.strokeStyle='rgba(16,18,22,.38)';ctx.lineWidth=1;
    ctx.beginPath();
    for(let i=1;i<W;i++){ctx.moveTo(i*S+.5,0);ctx.lineTo(i*S+.5,boardH);ctx.moveTo(0,i*S+.5);ctx.lineTo(boardW,i*S+.5);}
    ctx.stroke();
  }
  if(DEBUG_GRID){
    ctx.strokeStyle='rgba(120,200,255,.35)';ctx.lineWidth=1;ctx.beginPath();
    for(let i=1;i<W;i++){ctx.moveTo(i*S+.5,0);ctx.lineTo(i*S+.5,boardH);ctx.moveTo(0,i*S+.5);ctx.lineTo(boardW,i*S+.5);}
    ctx.stroke();
    if(NATIVE_GRID){
      ctx.strokeStyle='rgba(255,84,84,.95)';ctx.lineWidth=3;ctx.beginPath();
      for(let y=0;y<H;y++)for(let x=0;x<W;x++){
        const t=nativeTile(x,y);
        if(!t)continue;
        if(t[1]&1){ctx.moveTo(x*S,y*S);ctx.lineTo((x+1)*S,y*S);}
        if(t[1]&2){ctx.moveTo((x+1)*S,y*S);ctx.lineTo((x+1)*S,(y+1)*S);}
        if(t[1]&4){ctx.moveTo(x*S,(y+1)*S);ctx.lineTo((x+1)*S,(y+1)*S);}
        if(t[1]&8){ctx.moveTo(x*S,y*S);ctx.lineTo(x*S,(y+1)*S);}
      }
      ctx.stroke();
      ctx.font='700 9px monospace';ctx.textAlign='center';ctx.fillStyle='rgba(255,255,255,.85)';
      for(let y=0;y<H;y++)for(let x=0;x<W;x++){
        const t=nativeTile(x,y);
        if(!t||!t[6])continue;
        ctx.fillText('V',x*S+S/2,y*S+S/2+3);
      }
      ctx.textAlign='left';
    }
  }
  /* luz cenital suave */
  const light=ctx.createRadialGradient(boardW*.32,boardH*.2,Math.min(boardW,boardH)*.08,boardW*.32,boardH*.2,Math.max(boardW,boardH)*.95);
  light.addColorStop(0,'rgba(255,244,214,.13)');light.addColorStop(1,'rgba(255,244,214,0)');
  ctx.fillStyle=light;ctx.fillRect(0,0,boardW,boardH);
  /* zonas de despliegue */
  const zone=(list,col)=>{list.forEach(s=>{rr(s.x*S+3,s.y*S+3,S-6,S-6,8);ctx.fillStyle=col;ctx.fill();});};
  zone((G&&G.spawnSlots&&G.spawnSlots.A)||spawnsFor('A'),'rgba(57,194,215,.13)');zone((G&&G.spawnSlots&&G.spawnSlots.B)||spawnsFor('B'),'rgba(255,122,69,.13)');
  /* baliza: zona ámbar con esquinas de mira */
  const beaconAlpha=REDUCED_MOTION?.16:(.13+.05*Math.sin(FX.t/520));
  BEACON.forEach(b=>{ctx.fillStyle='rgba(242,178,52,'+beaconAlpha.toFixed(3)+')';ctx.fillRect(b.x*S,b.y*S,S,S);});
  ctx.strokeStyle='#f2b234';ctx.lineWidth=4;
  const bx=BEACON[0].x*S,by=BEACON[0].y*S,bs=2*S,cl=S*.3;
  [[bx,by,1,1],[bx+bs,by,-1,1],[bx,by+bs,1,-1],[bx+bs,by+bs,-1,-1]].forEach(c=>{
    ctx.beginPath();ctx.moveTo(c[0]+cl*c[2],c[1]);ctx.lineTo(c[0],c[1]);ctx.lineTo(c[0],c[1]+cl*c[3]);ctx.stroke();});
  rr(bx+6,by+bs-28,86,22,6);ctx.fillStyle='rgba(16,14,6,.82)';ctx.fill();
  ctx.fillStyle='#f2b234';ctx.font='700 14px Barlow Condensed';ctx.fillText('⚑ BALIZA',bx+13,by+bs-14);
  /* Zona de extracción de Escolta: verde pulsante con su rótulo, en el este */
  if(effMode(G)==='escolta'){
    const extAlpha=REDUCED_MOTION?.18:(.15+.06*Math.sin(FX.t/520));
    const ext=escortExt();
    ext.forEach(t2=>{ctx.fillStyle='rgba(87,196,106,'+extAlpha.toFixed(3)+')';ctx.fillRect(t2.x*S,t2.y*S,S,S);rr(t2.x*S+4,t2.y*S+4,S-8,S-8,10);ctx.strokeStyle='#57c46a';ctx.lineWidth=3;ctx.stroke();});
    const ex=Math.min(...ext.map(t=>t.x))*S,ey=Math.min(...ext.map(t=>t.y))*S;
    ctx.font='800 13px Barlow Condensed';ctx.textAlign='center';
    rr(ex+4,ey-22,2*S-8,18,6);ctx.fillStyle='rgba(8,14,8,.85)';ctx.fill();
    ctx.fillStyle='#57c46a';ctx.fillText('⇪ EXTRACCIÓN',ex+S,ey-9);ctx.textAlign='left';
  }
  /* Zonas de Dominación: anillo y letra por zona, teñidos por quién la controla ahora */
  if(effMode(G)==='dominacion'){
    domZones().forEach((z,zi)=>{
      const c=domControl(z);
      const col=c==='A'?'#39c2d7':c==='B'?'#ff7a45':'#f4f1e6';
      z.tiles.forEach(t=>{rr(t.x*S+4,t.y*S+4,S-8,S-8,10);ctx.strokeStyle=col;ctx.lineWidth=3;ctx.stroke();ctx.fillStyle=c==='A'?'rgba(57,194,215,.14)':c==='B'?'rgba(255,122,69,.14)':'rgba(255,255,255,.07)';ctx.fill();});
      const anchor=z.tiles[0];
      const b0=BEACON[0];
      const lx=(z.id==='centro'?((b0.x+1)*S):(anchor.x*S+S/2)), ly=(z.id==='centro'?(b0.y*S-8):(anchor.y*S+16));
      ctx.font='800 13px Barlow Condensed';ctx.textAlign='center';rr(lx-52,ly-13,104,18,6);ctx.fillStyle='rgba(10,12,8,.85)';ctx.fill();ctx.fillStyle=col;ctx.fillText('⬢ '+z.name.toUpperCase(),lx,ly);ctx.textAlign='left';
    });
  }
  /* casillas alcanzables: azul brillante del original */
  const u=G.selected;
  if(u&&u.alive&&u.team===G.turn&&!G.aiBusy&&G.actionMode==='move'){
    reachable(u,u.energy).forEach((d,k)=>{const [x,y]=k.split(',').map(Number);
      rr(x*S+5,y*S+5,S-10,S-10,10);ctx.fillStyle='rgba(38,144,255,'+(REDUCED_MOTION?.36:(.30+.09*Math.sin(FX.t/600))).toFixed(3)+')';ctx.fill();
      ctx.strokeStyle='rgba(110,196,255,.95)';ctx.lineWidth=2.2;ctx.stroke();
      rr(x*S+9,y*S+9,S-18,S-18,7);ctx.strokeStyle='rgba(255,255,255,.30)';ctx.lineWidth=1.2;ctx.stroke();});
  }
  if(u&&G.actionMode==='grenade'){for(let y=0;y<H;y++)for(let x=0;x<W;x++)if(cheb(u,{x,y})<=3&&cheb(u,{x,y})>0){
    rr(x*S+5,y*S+5,S-10,S-10,10);ctx.fillStyle='rgba(229,72,77,.26)';ctx.fill();ctx.strokeStyle='rgba(255,110,100,.7)';ctx.lineWidth=1.6;ctx.stroke();}}
  /* Claymore: las casillas adyacentes donde el Ingeniero puede colocarla */
  if(u&&G.actionMode==='mine'){[[1,0],[-1,0],[0,1],[0,-1]].forEach(dd=>{const mx=u.x+dd[0],my=u.y+dd[1];if(mx<0||my<0||mx>=W||my>=H||blocked(mx,my)||mineAt(mx,my))return;
    rr(mx*S+5,my*S+5,S-10,S-10,10);ctx.fillStyle='rgba(229,72,77,.22)';ctx.fill();ctx.strokeStyle='rgba(255,110,100,.85)';ctx.lineWidth=1.8;ctx.stroke();});}
  /* M18: alcance de lanzamiento del humo (4) y la cruz que tapará */
  if(u&&G.actionMode==='smoke'){for(let y=0;y<H;y++)for(let x=0;x<W;x++)if(cheb(u,{x,y})<=4&&cheb(u,{x,y})>0){
    rr(x*S+5,y*S+5,S-10,S-10,10);ctx.fillStyle='rgba(207,212,217,.20)';ctx.fill();ctx.strokeStyle='rgba(230,235,240,.65)';ctx.lineWidth=1.6;ctx.stroke();}
    if(hoverTile&&cheb(u,hoverTile)<=4&&cheb(u,hoverTile)>0){[[0,0],[1,0],[-1,0],[0,1],[0,-1]].forEach(dd=>{const hx=hoverTile.x+dd[0],hy=hoverTile.y+dd[1];if(hx<0||hy<0||hx>=W||hy>=H)return;
      rr(hx*S+3,hy*S+3,S-6,S-6,9);ctx.fillStyle='rgba(235,238,242,.38)';ctx.fill();ctx.strokeStyle='rgba(255,255,255,.85)';ctx.lineWidth=2;ctx.stroke();});}}
  /* M84: alcance de lanzamiento de la aturdidora (4) y el radio 1 que cegará */
  if(u&&G.actionMode==='flash'){for(let y=0;y<H;y++)for(let x=0;x<W;x++)if(cheb(u,{x,y})<=4){
    rr(x*S+5,y*S+5,S-10,S-10,10);ctx.fillStyle='rgba(242,210,62,.16)';ctx.fill();ctx.strokeStyle='rgba(255,232,138,.6)';ctx.lineWidth=1.6;ctx.stroke();}
    if(hoverTile&&cheb(u,hoverTile)<=4){for(let dy=-1;dy<=1;dy++)for(let dx=-1;dx<=1;dx++){const hx=hoverTile.x+dx,hy=hoverTile.y+dy;if(hx<0||hy<0||hx>=W||hy>=H)continue;
      rr(hx*S+3,hy*S+3,S-6,S-6,9);ctx.fillStyle='rgba(255,240,170,.34)';ctx.fill();ctx.strokeStyle='rgba(255,214,64,.9)';ctx.lineWidth=2;ctx.stroke();}}}
  /* Guiado del dron: las casillas adyacentes libres a las que puede avanzar */
  if(u&&G.actionMode==='drone'&&G.drone&&G.drone.alive){
    [[1,0],[-1,0],[0,1],[0,-1]].forEach(dd=>{const nx=G.drone.x+dd[0],ny=G.drone.y+dd[1];if(nx<0||ny<0||nx>=W||ny>=H||blocked(nx,ny))return;
      rr(nx*S+5,ny*S+5,S-10,S-10,10);ctx.fillStyle='rgba(87,196,106,.34)';ctx.fill();ctx.strokeStyle='rgba(140,240,160,.95)';ctx.lineWidth=2.2;ctx.stroke();});
    rr(G.drone.x*S+2,G.drone.y*S+2,S-4,S-4,9);ctx.strokeStyle='#57c46a';ctx.lineWidth=3;ctx.stroke();
  }
  /* botiquines */
  G.map.medkits.forEach(m=>{if(!m.used)drawMedkit(m,S);});
  /* cajas de botín programadas (rondas 3 y 6) */
  (G.lootBoxes||[]).forEach(b=>{
    const px=b.x*S,py=b.y*S+(REDUCED_MOTION?0:Math.sin(FX.t/480+b.x*2.1+b.y)*3);
    ctx.fillStyle='rgba(0,0,0,.3)';ctx.beginPath();ctx.ellipse(px+S/2,py+S*.84,S*.34,S*.09,0,0,7);ctx.fill();
    rr(px+S*.18,py+S*.3,S*.64,S*.48,5);ctx.fillStyle='#c98f12';ctx.fill();ctx.lineWidth=2;ctx.strokeStyle='#6e4d05';ctx.stroke();
    rr(px+S*.18,py+S*.3,S*.64,S*.13,5);ctx.fillStyle='#f2b234';ctx.fill();
    ctx.fillStyle='#fff7d6';ctx.font='700 '+Math.round(S*.3)+'px Barlow';ctx.textAlign='center';
    ctx.fillText(b.kind==='salud'?'✚':b.kind==='municion'?'▲':b.kind==='analgesico'?'💊':'⚑',px+S/2,py+S*.68);ctx.textAlign='left';
  });
  /* plataforma de la torreta central */
  drawPlatform(S);
  /* obstáculos con volumen, ordenados por fila para que se solapen bien */
  G.map.obstacles.slice().sort((a,b)=>a.y-b.y).forEach(o=>{
    if(o.type==='wall')drawWall(o,S);
    else if(o.type==='shelf')drawContainer(o,S);
    else if(o.type==='crate')drawCrate(o,S);
  });
  /* barriles */
  G.map.barrels.forEach(b=>{if(b.alive)drawBarrel(b,S);});
  /* viñeta de cámara */
  const vg=ctx.createRadialGradient(boardW/2,boardH/2,Math.min(boardW,boardH)*.42,boardW/2,boardH/2,Math.max(boardW,boardH)*.78);
  vg.addColorStop(0,'rgba(10,12,16,0)');vg.addColorStop(1,'rgba(10,12,16,.20)');
  ctx.fillStyle=vg;ctx.fillRect(0,0,boardW,boardH);
  /* torretas desplegadas */
  G.deployed.slice().sort((a,b)=>a.y-b.y).forEach(t=>{if(t.alive)drawDeployed(t,S);});
  /* puntería al pasar el cursor */
  if(hoverTile&&u&&u.alive){
    const t=unitAt(hoverTile.x,hoverTile.y);
    rr(hoverTile.x*S+2,hoverTile.y*S+2,S-4,S-4,8);ctx.strokeStyle='rgba(255,255,255,.6)';ctx.lineWidth=2;ctx.stroke();
    if(t&&t.team!==u.team&&(G.actionMode==='shoot'||G.actionMode==='pistol'||G.actionMode==='move'||G.actionMode==='special')){
      const w=G.actionMode==='pistol'?WEAPONS[PISTOL]:WEAPONS[u.weapon];const p=hitChance(u,t,w);
      /* anillo rojo de objetivo a los pies, como en el original */
      ctx.beginPath();ctx.ellipse(t.x*S+S/2,t.y*S+S*.88,S*.4,S*.15,0,0,7);ctx.strokeStyle='#ff4747';ctx.lineWidth=3.5;ctx.stroke();
      ctx.beginPath();ctx.ellipse(t.x*S+S/2,t.y*S+S*.88,S*.47,S*.19,0,0,7);ctx.strokeStyle='rgba(255,71,71,.45)';ctx.lineWidth=1.6;ctx.setLineDash([7,6]);ctx.stroke();ctx.setLineDash([]);
      if(p>0&&(G.actionMode==='shoot'||G.actionMode==='pistol')){
        ctx.beginPath();ctx.moveTo(u.x*S+S/2,u.y*S+S*.42);ctx.lineTo(t.x*S+S/2,t.y*S+S*.42);
        ctx.strokeStyle='rgba(242,178,52,.55)';ctx.lineWidth=2;ctx.setLineDash([6,6]);ctx.stroke();ctx.setLineDash([]);
      }
      const label=p>0?('Acierto '+p+'% · '+w.dmg+' daño'):(t.invisible?'Invisible':(smokeBlocksLOS(u,t)?'Sin tiro · humo M18':'Sin tiro'));
      ctx.font='700 14px JetBrains Mono';const tw=ctx.measureText(label).width+18;
      let tx=hoverTile.x*S,ty=hoverTile.y*S-34;if(ty<0)ty=hoverTile.y*S+S+8;if(tx+tw>boardW)tx=boardW-tw;
      rr(tx,ty,tw,24,7);ctx.fillStyle='rgba(10,12,8,.9)';ctx.fill();ctx.strokeStyle=p>0?'#f2b234':'#e5484d';ctx.lineWidth=1.5;ctx.stroke();
      ctx.fillStyle=p>0?'#f2b234':'#ff8a80';ctx.fillText(label,tx+9,ty+16);
    }
  }
  /* el dron de Escolta, entre las torretas y los soldados */
  if(G.drone)drawDrone(S);
  /* soldados, ordenados por fila: los de abajo tapan a los de arriba */
  G.units.slice().sort((a,b)=>((a.dy!=null?a.dy:a.y)-(b.dy!=null?b.dy:b.y))).forEach(un=>drawSoldier(un,S));
  /* Claymores M18A1: solo las ve el bando que las colocó (contra la
     IA, siempre el jugador; a dos jugadores, el que tiene el turno).
     A ras de suelo, en la esquina de la casilla, con su LED rojo: el
     enemigo las descubre pisándolas. */
  (G.mines||[]).forEach(mn=>{
    if(mn.team!==viewerTeam())return;
    const px=mn.x*S,py=mn.y*S;
    ctx.save();ctx.translate(px+S*.78,py+S*.8);
    rr(-S*.16,-S*.07,S*.32,S*.14,3);ctx.fillStyle='#3d4436';ctx.fill();ctx.lineWidth=1.6;ctx.strokeStyle='rgba(0,0,0,.6)';ctx.stroke();
    ctx.beginPath();ctx.arc(0,0,Math.max(2,S*.045),0,7);ctx.fillStyle=(REDUCED_MOTION||Math.sin(FX.t/300+mn.x*1.3+mn.y)>0)?'#ff4747':'#7a1616';ctx.fill();
    ctx.restore();
  });
  /* Cortinas de humo de las M18: nube gris por casilla, sobre los
     soldados, porque el humo tapa la vista de quien está detrás y
     también envuelve a quien está dentro. Los bordes se deshacen en
     círculos sueltos para que no se lea como un bloque sólido. */
  (G.smoke||[]).forEach(sm=>{
    const px=sm.x*S,py=sm.y*S,cx=px+S/2,cy=py+S/2;
    const fade=sm.left<=1?0.72:0.92;
    const drift=REDUCED_MOTION?0:Math.sin(FX.t/700+sm.x*1.7+sm.y*2.3)*3;
    for(let i=0;i<5;i++){
      const a=hash2(sm.x*7+i,sm.y*13+i*3),b=hash2(sm.x*3+i*5,sm.y*11+i);
      const ox=(a-0.5)*S*0.52+drift*(i%2?1:-0.6),oy=(b-0.5)*S*0.4;
      const r=S*(0.3+0.16*((i*37)%10)/10);
      ctx.beginPath();ctx.arc(cx+ox,cy+oy,r,0,7);ctx.fillStyle='rgba(196,202,208,'+(0.30*fade).toFixed(2)+')';ctx.fill();
    }
    ctx.beginPath();ctx.arc(cx+drift*0.4,cy,S*0.4,0,7);ctx.fillStyle='rgba(214,219,224,'+(0.34*fade).toFixed(2)+')';ctx.fill();
    ctx.font='700 10px Barlow';ctx.textAlign='center';ctx.fillStyle='rgba(30,34,38,.75)';
    ctx.fillText('💨 '+(sm.left>1?'2 rondas':'última ronda'),cx,py+S-6);ctx.textAlign='left';
  });
  /* Aturdidos por la M84: estrellas dando vueltas sobre la cabeza y
     su rótulo, sobre el soldado y en su posición interpolada, para
     que el estado se lea en el tablero sin abrir la ficha. */
  G.units.forEach(un=>{
    if(!un.alive||!un.stunned)return;
    const rx=un.dx!=null?un.dx:un.x, ry=un.dy!=null?un.dy:un.y;
    const cx=rx*S+S/2, topY=ry*S+2;
    const wob=REDUCED_MOTION?0:Math.sin(FX.t/280+un.id*2.1)*S*0.05;
    ctx.font=Math.round(S*.3)+'px Barlow';ctx.textAlign='center';
    ctx.fillText('💫',cx+wob,topY+S*.3);ctx.textAlign='left';
    rr(cx-32,topY+S*.34,64,14,7);ctx.fillStyle='rgba(24,20,4,.78)';ctx.fill();
    ctx.font='700 9.5px Barlow';ctx.textAlign='center';ctx.fillStyle='#ffd23e';
    ctx.fillText('ATURDIDO',cx,topY+S*.34+10.5);ctx.textAlign='left';
  });
  drawFX(S);
  ctx.restore();
}

export function drawDrone(S){
  const d=G.drone;if(!d)return;
  const rx=d.dx!=null?d.dx:d.x, ry=d.dy!=null?d.dy:d.y;
  const cx=rx*S+S/2, cy=ry*S+S/2;
  const hov=d.alive?(REDUCED_MOTION?0:Math.sin(FX.t/480+d.x*1.7)*S*0.03):0;
  ctx.beginPath();ctx.ellipse(cx,cy+S*.36,S*.32,S*.09,0,0,7);ctx.fillStyle='rgba(0,0,0,.35)';ctx.fill();
  if(!d.alive){
    ctx.save();ctx.translate(cx,cy+S*.16);ctx.rotate(.5);
    rr(-S*.26,-S*.09,S*.52,S*.18,6);ctx.fillStyle=lg(-S*.26,0,S*.26,0,[[0,'#4a5058'],[.5,'#33383f'],[1,'#22262b']]);ctx.fill();
    ctx.lineWidth=2;ctx.strokeStyle='rgba(0,0,0,.55)';ctx.stroke();
    ctx.fillStyle='#f2b234';rr(-S*.07,-S*.035,S*.14,S*.07,2);ctx.fill();
    ctx.restore();
    ctx.strokeStyle='rgba(229,72,77,.9)';ctx.lineWidth=3;ctx.beginPath();
    ctx.moveTo(cx-S*.3,cy-S*.3);ctx.lineTo(cx-S*.18,cy-S*.18);ctx.moveTo(cx-S*.18,cy-S*.3);ctx.lineTo(cx-S*.3,cy-S*.18);ctx.stroke();
    return;
  }
  /* anillo de bando a ras de suelo */
  ctx.beginPath();ctx.ellipse(cx,cy+S*.34,S*.4,S*.14,0,0,7);ctx.strokeStyle='#39c2d7';ctx.lineWidth=3;ctx.stroke();
  ctx.beginPath();ctx.ellipse(cx,cy+S*.34,S*.46,S*.18,0,0,7);ctx.strokeStyle='rgba(57,194,215,.4)';ctx.lineWidth=1.4;ctx.setLineDash([6,6]);ctx.stroke();ctx.setLineDash([]);
  const bodyY=cy-S*.06+hov;
  /* brazos y rotores en las cuatro esquinas, girando */
  const spin=REDUCED_MOTION?0.7:FX.t/45;
  [[-1,-1],[1,-1],[-1,1],[1,1]].forEach(c=>{
    const ax=cx+c[0]*S*.3, ay=bodyY+c[1]*S*.13;
    ctx.strokeStyle='#22262b';ctx.lineWidth=3.4;ctx.beginPath();ctx.moveTo(cx,bodyY);ctx.lineTo(ax,ay);ctx.stroke();
    ctx.save();ctx.translate(ax,ay);ctx.rotate(spin+c[0]*c[1]);
    ctx.fillStyle='rgba(210,216,222,.85)';ctx.fillRect(-S*.14,-1.8,S*.28,3.6);ctx.fillRect(-1.8,-S*.14,3.6,S*.28);
    ctx.restore();
    ctx.beginPath();ctx.arc(ax,ay,3.4,0,7);ctx.fillStyle='#3a4148';ctx.fill();ctx.strokeStyle='rgba(0,0,0,.5)';ctx.lineWidth=1.2;ctx.stroke();
  });
  /* casco del dron */
  rr(cx-S*.27,bodyY-S*.15,S*.54,S*.3,8);
  ctx.fillStyle=lg(cx,bodyY-S*.15,cx,bodyY+S*.15,[[0,'#5a626c'],[.55,'#3a4148'],[1,'#23272c']]);ctx.fill();
  ctx.lineWidth=2.2;ctx.strokeStyle='rgba(0,0,0,.55)';ctx.stroke();
  rr(cx-S*.1,bodyY-S*.21,S*.2,S*.07,2);ctx.fillStyle='#f2b234';ctx.fill();ctx.strokeStyle='rgba(0,0,0,.4)';ctx.lineWidth=1.2;ctx.stroke();
  /* ojo / sensor frontal y luz de aviso */
  ctx.beginPath();ctx.arc(cx+S*.13,bodyY, S*.055,0,7);ctx.fillStyle='#8fd8ff';ctx.fill();ctx.lineWidth=1.6;ctx.strokeStyle='rgba(0,0,0,.6)';ctx.stroke();
  const blink=REDUCED_MOTION?0.9:(0.45+0.55*Math.abs(Math.sin(FX.t/330)));
  ctx.beginPath();ctx.arc(cx-S*.16,bodyY-S*.05,S*.04,0,7);ctx.fillStyle='rgba(255,176,58,'+blink.toFixed(2)+')';ctx.fill();
  /* humo de avería cuando le queda poca vida */
  if(d.hp<d.maxHp*0.45&&!REDUCED_MOTION){
    for(let i=0;i<3;i++){
      const ph=((FX.t/900+i/3)%1), sx=cx-S*.08+Math.sin(FX.t/300+i*2.1)*4, sy=bodyY-S*.2-ph*S*.34;
      ctx.beginPath();ctx.arc(sx,sy,3+ph*6,0,7);ctx.fillStyle='rgba(70,70,70,'+(0.4*(1-ph)).toFixed(2)+')';ctx.fill();
    }
  }
  /* barra de vida flotante, como la de los soldados */
  const bw=S*.64,bx=cx-bw/2,by=ry*S+3;
  rr(bx,by,bw,9,4.5);ctx.fillStyle='rgba(10,12,8,.72)';ctx.fill();
  ctx.lineWidth=1.6;ctx.strokeStyle='rgba(255,255,255,.85)';ctx.stroke();
  if(d.hp>0){rr(bx+1.6,by+1.6,(bw-3.2)*d.hp/d.maxHp,5.8,2.9);ctx.fillStyle=d.hp>d.maxHp*0.3?lg(bx,by,bx,by+9,[[0,'#8df09a'],[1,'#3fb950']]):lg(bx,by,bx,by+9,[[0,'#ff9a8a'],[1,'#e5484d']]);ctx.fill();}
  ctx.font='700 10.5px Barlow';ctx.textAlign='center';
  rr(cx-24,bodyY+S*.2,48,14,7);ctx.fillStyle='rgba(10,10,8,.66)';ctx.fill();
  ctx.fillStyle='#ffd98a';ctx.fillText('🤖 DRON',cx,bodyY+S*.2+10.5);ctx.textAlign='left';
}

export function drawDeployed(t,S){
  const cx=t.x*S+S/2,cy=t.y*S+S/2;
  ctx.beginPath();ctx.ellipse(cx,cy+S*.34,S*.36,S*.11,0,0,7);ctx.fillStyle='rgba(0,0,0,.32)';ctx.fill();
  segRing(cx,cy+S*.3,S*.4,S*.15,{maxEnergy:4,energy:4,hp:t.hp,maxHp:t.maxHp,team:t.team});
  ctx.beginPath();ctx.ellipse(cx,cy+S*.06,S*.3,S*.24,0,0,7);
  ctx.fillStyle=rg(cx,cy+S*.06,S*.3,[[0,'#aeb6bd'],[.6,'#79828a'],[1,'#565e65']]);ctx.fill();
  ctx.lineWidth=2.4;ctx.strokeStyle=t.team==='A'?'#39c2d7':'#ff7a45';ctx.stroke();
  let ang=t.team==='A'?0:Math.PI;
  const foes=G.units.filter(e=>e.alive&&e.team!==t.team);
  if(foes.length){foes.sort((a,b)=>cheb(t,a)-cheb(t,b));ang=Math.atan2(foes[0].y-t.y,foes[0].x-t.x);}
  /* El cañón de la torreta desplegada también gira suavemente. */
  if(t._dispYaw==null||REDUCED_MOTION)t._dispYaw=ang;else t._dispYaw+=shortestArc(ang-t._dispYaw)*0.25;
  ang=t._dispYaw;
  ctx.save();ctx.translate(cx,cy);ctx.rotate(ang);
  ctx.fillStyle='#23262a';rr(S*.08,-3.6,S*.36,7.2,2.5);ctx.fill();
  ctx.fillStyle='#3d434a';rr(S*.08,-5.4,S*.12,3.4,1.6);ctx.fill();
  ctx.restore();
  ctx.fillStyle='#fff';ctx.font='700 12px Barlow';ctx.textAlign='center';ctx.fillText('M2',cx,cy+S*.1);ctx.textAlign='left';
  rr(t.x*S+9,t.y*S+4,S-18,6,3);ctx.fillStyle='rgba(0,0,0,.65)';ctx.fill();
  rr(t.x*S+10,t.y*S+5,(S-20)*t.hp/t.maxHp,4,2);ctx.fillStyle='#57c46a';ctx.fill();
}
