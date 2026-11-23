export const CAMPAIGN_ID='operacion-londres';

export const TUTORIAL_DATA_STEPS=[
  {id:'select',title:'1/6 · Selecciona y lee la energía',text:'Toca a Hipster Dave. Fíjate en la barra de energía: cada movimiento, disparo y granada cuesta ⚡.',event:'select'},
  {id:'move',title:'2/6 · Muévete a cobertura',text:'Toca una casilla iluminada junto a un muro o una caja. La cobertura reduce el daño recibido.',event:'move',require:'cover'},
  {id:'shoot',title:'3/6 · Dispara con línea de visión',text:'Pulsa «Disparar» y toca a un rival. Si el humo o un muro cortan la línea, el juego lo dirá.',event:'shoot'},
  {id:'grenade',title:'4/6 · Usa una granada',text:'Pulsa «Granada M67» y lánzala a 3 casillas como máximo. También sirve una aturdidora M84 o una habilidad.',event:'grenade'},
  {id:'endTurn',title:'5/6 · Cierra el turno',text:'Pulsa «Terminar turno». La IA responderá y volverás a mandar en la ronda siguiente.',check:'turnReturn'},
  {id:'kill',title:'6/6 · Remata la instrucción',text:'Elimina a un rival. Cuando caiga el primero, Dave dará por terminado el entrenamiento.',check:'kill'}
];

export const TUTORIAL_DATA_MISSION={
  id:'tutorial',title:'Instrucción de Dave',map:'skirmish',objective:'eliminacion',fmt:3,difficulty:'normal',turnLimit:8,
  brief:'Skirmish_03 · La plaza · 3 contra 3 · IA Normal. Hipster Dave te enseña a seleccionar, moverte, disparar, lanzar una granada, cerrar el turno y rematar.',
  playerRoster:[
    {charName:'Hipster Dave',role:'Comando',weapon:'M4A1'},
    {charName:'Sister Florence',role:'Médico',weapon:'M4A1'},
    {charName:'Sneaky Pete',role:'Francotirador',weapon:'M40'}
  ],
  enemyRoster:[
    {charName:'Riot Agent',role:'Espía',weapon:'MP5'},
    {charName:'Riot Medic',role:'Médico',weapon:'M4A1'},
    {charName:'Riot Engineer',role:'Ingeniero',weapon:'M4A1'}
  ]
};

export const CAMPAIGN_DATA_MISSIONS=[
  {id:'london-1',title:'Primer contacto',map:'skirmish',objective:'eliminacion',fmt:4,difficulty:'normal',turnLimit:10,
   brief:'Skirmish_03 · La plaza · Eliminación · 4 contra 4 · IA Normal. Dave y su escuadra hacen la primera prueba de fuego en el corazón de Londres.',
   playerRoster:[
    {charName:'Hipster Dave',role:'Comando',weapon:'M4A1'},
    {charName:'Sister Florence',role:'Médico',weapon:'M4A1'},
    {charName:'Sneaky Pete',role:'Francotirador',weapon:'M40'},
    {charName:'Big Time Taschmann',role:'Ingeniero',weapon:'Remington 870'}
   ],
   enemyRoster:[
    {charName:'Soap',role:'Artillero',weapon:'M240B'},
    {charName:'Archie Fletcher',role:'Artillero',weapon:'M249 SAW'},
    {charName:'Mme La Hacque',role:'Espía',weapon:'MP7'},
    {charName:'Riot Medic',role:'Médico',weapon:'M4A1'}
   ]},
  {id:'london-2',title:'Señal en el patio',map:'skirmish04',objective:'baliza',fmt:4,difficulty:'normal',turnLimit:12,
   brief:'Skirmish_04 · El puente · Captura de baliza · 4 contra 4 · IA Normal. Mantén la zona central despejada hasta que la señal sea tuya.',
   playerRoster:[
    {charName:'Hipster Dave',role:'Comando',weapon:'M4A1'},
    {charName:'Archie Fletcher',role:'Artillero',weapon:'M249 SAW'},
    {charName:'Mme La Hacque',role:'Espía',weapon:'MP7'},
    {charName:'Megan McNick',role:'Ingeniero',weapon:'Benelli M4'}
   ],
   enemyRoster:[
    {charName:'Ivan Tkilya',role:'Artillero',weapon:'M249 SAW'},
    {charName:'Spud',role:'Artillero',weapon:'RPG-7'},
    {charName:'Riot Agent',role:'Espía',weapon:'MP5'},
    {charName:'Textbook Kate',role:'Médico',weapon:'M4A1'}
   ]},
  {id:'london-3',title:'Londres, tres frentes',map:'skirmish05',objective:'dominacion',fmt:4,difficulty:'veterano',turnLimit:15,
   brief:'Skirmish_05 · El depósito · Dominación · 4 contra 4 · IA Veterano. Reparte la escuadra entre Depósito, Centro y Muelle y llega a 10 puntos.',
   playerRoster:[
    {charName:'Hipster Dave',role:'Comando',weapon:'M4A1'},
    {charName:'Soap',role:'Artillero',weapon:'M240B'},
    {charName:'Sneaky Pete',role:'Francotirador',weapon:'M40'},
    {charName:'Sister Florence',role:'Médico',weapon:'M4A1'}
   ],
   enemyRoster:[
    {charName:'Spud',role:'Artillero',weapon:'RPG-7'},
    {charName:'Ivan Tkilya',role:'Artillero',weapon:'M249 SAW'},
    {charName:'Riot Engineer',role:'Ingeniero',weapon:'M4A1'},
    {charName:'Riot Medic',role:'Médico',weapon:'M4A1'}
   ]},
  {id:'london-4',title:'El puente no cae',map:'skirmish06',objective:'baliza',fmt:4,difficulty:'veterano',turnLimit:12,
   brief:'Skirmish_06 · Los andenes · Captura de baliza · 4 contra 4 · IA Veterano. La baliza está en el centro; aguanta el contraataque.',
   playerRoster:[
    {charName:'Hipster Dave',role:'Comando',weapon:'M4A1'},
    {charName:'Big Time Taschmann',role:'Ingeniero',weapon:'Remington 870'},
    {charName:'Sneaky Pete',role:'Francotirador',weapon:'M40'},
    {charName:'Sister Florence',role:'Médico',weapon:'M4A1'}
   ],
   enemyRoster:[
    {charName:'Archie Fletcher',role:'Artillero',weapon:'M249 SAW'},
    {charName:'Soap',role:'Artillero',weapon:'M240B'},
    {charName:'Mme La Hacque',role:'Espía',weapon:'MP7'},
    {charName:'Textbook Kate',role:'Médico',weapon:'M4A1'}
   ]},
  {id:'london-5',title:'Última guardia',map:'skirmish08',objective:'eliminacion',fmt:5,difficulty:'elite',turnLimit:12,
   brief:'Skirmish_08 · La terminal · Eliminación · 5 contra 5 · IA Élite. La guardia rival llega con +2 ⚡, +25 PV y +15 % de daño. Tu veterania es la ventaja.',
   playerRoster:[
    {charName:'Hipster Dave',role:'Comando',weapon:'M4A1'},
    {charName:'Sister Florence',role:'Médico',weapon:'M4A1'},
    {charName:'Sneaky Pete',role:'Francotirador',weapon:'M40'},
    {charName:'Big Time Taschmann',role:'Ingeniero',weapon:'Remington 870'},
    {charName:'Megan McNick',role:'Ingeniero',weapon:'Benelli M4'}
   ],
   enemyRoster:[
    {charName:'Ivan Tkilya',role:'Artillero',weapon:'M249 SAW'},
    {charName:'Spud',role:'Artillero',weapon:'RPG-7'},
    {charName:'Archie Fletcher',role:'Artillero',weapon:'M249 SAW'},
    {charName:'Riot Agent',role:'Espía',weapon:'MP5'},
    {charName:'Riot Engineer',role:'Ingeniero',weapon:'M4A1'}
   ]},
  {id:'london-6',title:'El convoy',map:'skirmish10',objective:'escolta',fmt:5,difficulty:'veterano',turnLimit:15,
   brief:'Skirmish_10 · El cruce · Escolta · 5 contra 5 · IA Veterano. Guía el dron hasta la salida este con la escolta pegada; el rival intentará pararlo.',
   playerRoster:[
    {charName:'Hipster Dave',role:'Comando',weapon:'M4A1'},
    {charName:'Sister Florence',role:'Médico',weapon:'M4A1'},
    {charName:'Megan McNick',role:'Ingeniero',weapon:'Benelli M4'},
    {charName:'Soap',role:'Artillero',weapon:'M240B'},
    {charName:'Sneaky Pete',role:'Francotirador',weapon:'M40'}
   ],
   enemyRoster:[
    {charName:'Archie Fletcher',role:'Artillero',weapon:'M249 SAW'},
    {charName:'Ivan Tkilya',role:'Artillero',weapon:'M249 SAW'},
    {charName:'Riot Agent',role:'Espía',weapon:'MP5'},
    {charName:'Riot Medic',role:'Médico',weapon:'M4A1'},
    {charName:'Textbook Kate',role:'Médico',weapon:'M4A1'}
   ]}
];

export const CAMPAIGN_DATA_CHAPTERS=[
  {name:'Capítulo 1 · Primer contacto',icon:'assets/ui/modo_eliminacion.png',from:0,to:1},
  {name:'Capítulo 2 · Londres en llamas',icon:'assets/ui/modo_dominacion.png',from:2,to:3},
  {name:'Capítulo 3 · La última guardia',icon:'assets/ui/modo_eliminacion.png',from:4,to:5}
];

export const RADIO_DATA_LINES={
  tutorial:[
    'DAVE — Bienvenido al entrenamiento. Toca a uno de los tuyos y mira cuánto ⚡ le queda.',
    'DAVE — Muévete pegado a una cobertura. Los muros no son decoración: te mantienen vivo.',
    'DAVE — Apunta, comprueba la línea de visión y dispara. Si el humo estorba, rodea la cortina.',
    'DAVE — Una M67 bien puesta arregla más discusiones que tres cargadores. úsala.',
    'DAVE — Cierra el turno. El rival también juega, y conviene haberlo visto venir.',
    'DAVE — Un rival menos. Ya sabes lo suficiente; ahora vamos en serio.'
  ],
  'london-1':['DAVE — Primera parada: la plaza. Si disparas primero, acabas antes.','CENTRAL — Escuadra, despejad la plaza. Sin bajas sería aún mejor.'],
  'london-2':['DAVE — La baliza está en el puente. No hace falta ser héroe, basta con no dejarla libre.','CENTRAL — Mantened el centro. Repetidlo hasta que suene la señal.'],
  'london-3':['DAVE — Tres zonas y solo cuatro pares de botas. Repartid bien o perderemos el depósito.','CENTRAL — Dominación en marcha. Centro, Depósito y Muelle: queremos los tres.'],
  'london-4':['DAVE — Los andenes son un pasillo: cuidado con los francotiradores.','CENTRAL — El puente no se cae. La baliza sigue siendo nuestra prioridad.'],
  'london-5':['DAVE — Guardia de élite. Vienen con más energía y más blindaje; usad la veterania.','CENTRAL — Última guardia en la terminal. No retrocedáis.'],
  'london-6':['DAVE — El dron va como va. Pegad la escolta, guiadlo y que no le den Alcance.','CENTRAL — Convoy en el cruce. Si el dron llega al este, ganamos.']
};

export function missionByIdData(id){
  if(id==='tutorial')return TUTORIAL_DATA_MISSION;
  return CAMPAIGN_DATA_MISSIONS.find(m=>m.id===id)||CAMPAIGN_DATA_MISSIONS[0]||TUTORIAL_DATA_MISSION;
}

export function rosterKeyData(charName){return 'original:'+charName;}

export function campaignStarsData(won,casualties,rounds,mission){
  if(!won)return 0;
  let stars=1;
  if(casualties<=1)stars=2;
  if(casualties===0&&rounds<=(mission&&mission.turnLimit||Infinity))stars=3;
  return stars;
}

export function radioLinesData(id){return (RADIO_DATA_LINES[id]||RADIO_DATA_LINES['london-1']||[]).slice();}
