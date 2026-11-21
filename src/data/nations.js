export const NATIONS=[
 {id:'es',name:'España',colors:['#AA151B','#F1BF00','#AA151B'],dir:'h',emblem:'♛',emblemName:'Corona del escudo de las Fuerzas Armadas',pers:{name:'Temple',desc:'Aguantar la posición: veteranía en la defensa.'}},
 {id:'us',name:'Estados Unidos',colors:['#B22234','#FFFFFF','#3C3B6E'],dir:'h',emblem:'★',emblemName:'Estrella de las Fuerzas Armadas de EE. UU.',pers:{name:'Fuego sostenido',desc:'Doctrina de apoyos largos y potencia de fuego.'}},
 {id:'gb',name:'Reino Unido',colors:['#012169','#FFFFFF','#C8102E'],dir:'h',emblem:'⚔',emblemName:'Espadas cruzadas y corona del Ejército británico',pers:{name:'Puntería',desc:'Precisión de tiro y disciplina de cobertura.'}},
 {id:'fr',name:'Francia',colors:['#0055A4','#FFFFFF','#EF4135'],dir:'v',emblem:'⚜',emblemName:'Flor de lis de la tradición militar francesa',pers:{name:'Maniobra',desc:'Movimiento rápido y flanqueos.'}},
 {id:'de',name:'Alemania',colors:['#1a1a1a','#DD0000','#FFCC00'],dir:'h',emblem:'✠',emblemName:'Cruz de la Bundeswehr',pers:{name:'Ingeniería',desc:'Técnica de torretas y equipos de apoyo.'}},
 {id:'ru',name:'Rusia',colors:['#FFFFFF','#0039A6','#D52B1E'],dir:'h',emblem:'★',emblemName:'Estrella roja de las Fuerzas Armadas rusas',pers:{name:'Resistencia',desc:'Aguantar el castigo y contraatacar.'}},
 {id:'cn',name:'China',colors:['#DE2910','#FFDE00','#DE2910'],dir:'h',emblem:'★',emblemName:'Estrella del Ejército Popular de Liberación',pers:{name:'Logística',desc:'Economía de energía y apoyo de escuadra.'}},
 {id:'jp',name:'Japón',colors:['#FFFFFF','#BC002D','#FFFFFF'],dir:'h',emblem:'◎',emblemName:'Sol naciente de las Fuerzas de Autodefensa',pers:{name:'Disciplina',desc:'Coordinación silenciosa y precisión.'}},
 {id:'it',name:'Italia',colors:['#009246','#FFFFFF','#CE2B37'],dir:'v',emblem:'✪',emblemName:'Estrella de las Fuerzas Armadas italianas',pers:{name:'Terreno',desc:'Lectura del mapa y la cobertura.'}},
 {id:'br',name:'Brasil',colors:['#009739','#FEDD00','#012169'],dir:'h',emblem:'✶',emblemName:'Estrella del Ejército brasileño',pers:{name:'Iniciativa',desc:'Empuje y primeros asaltos.'}},
 {id:'ca',name:'Canadá',colors:['#FF0000','#FFFFFF','#FF0000'],dir:'v',emblem:'✦',emblemName:'Hoja de arce de las Fuerzas Armadas canadienses',pers:{name:'Paciencia',desc:'Tiros largos y calma bajo presión.'}},
 {id:'au',name:'Australia',colors:['#00247D','#FFCD00','#FF0000'],dir:'h',emblem:'✸',emblemName:'Sol naciente del Ejército australiano',pers:{name:'Exploradores',desc:'Movilidad y visión.'}}
];

export const NATION_ART={es:'espana',us:'eeuu',gb:'reinounido',fr:'francia',de:'alemania',ru:'rusia',cn:'china',jp:'japon',it:'italia',br:'brasil',ca:'canada',au:'australia'};

export const SKINS={
 estandar:{name:'Estándar',desc:'El soldado genérico: uniforme verde oliva liso, sin colores de nación ni emblema. Sin pasiva.',uniform:'#66704f',vest:null,helmet:'#59613f',badge:null},
 camuflaje:{name:'Camuflaje',desc:'Patrón de camuflaje generado sobre el uniforme del soldado. Sin pasiva.',uniform:'#5a6346',vest:null,helmet:null,badge:null},
 clase:{name:'Clase',desc:'Uniforme teñido con el color de la clase del soldado (cada rol, su color). Sin pasiva.',uniform:null,vest:null,helmet:null,badge:null},
 nacion:{name:'Nación',desc:'Los colores de la bandera de tu nación en el uniforme y el casco, con el emblema de sus fuerzas armadas en el pecho. Sin pasiva.',uniform:null,vest:null,helmet:null,badge:'nation'}
};
