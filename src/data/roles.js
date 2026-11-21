export const BODIES={
 'ligero':{name:'Ligero',hp:200,energy:12,moveCost:1},
 'medio':{name:'Medio',hp:250,energy:14,moveCost:2},
 'pesado':{name:'Pesado',hp:300,energy:18,moveCost:3}
};

export const ROLES={
 'Francotirador':{body:'ligero',color:'#b8d94e',weapons:['M40','M24 SWS','M110 SASS','SVD Dragunov','AW50','Barrett M82','Mk 14 EBR','PSG-1'],special:'Tiro certero',sdesc:'Especial (3 ⚡): disparo con daño ×1,5 si el objetivo no se ha movido este turno.',desc:'Cuerpo ligero: decide partidas desde 9–10 casillas. Un disparo de cerrojo por turno.'},
 'Artillero':{body:'pesado',color:'#e07b39',weapons:['M249 SAW','M240B','PKM','MG3','RPG-7','AT4','M72 LAW','Browning M2','Mk 19'],special:'Supresión',sdesc:'Sus ametralladoras suprimen: el enemigo alcanzado pierde 2 de energía en su siguiente turno. Los lanzacohetes hacen daño en área.',desc:'Cuerpo pesado: el que más aguanta (300 PV) y el que más daño hace en área, pero paga 3 ⚡ por casilla.'},
 'Espía':{body:'ligero',color:'#9a6ee8',weapons:['MP7','MP5','FN P90','UMP45','KRISS Vector'],special:'Invisibilidad',sdesc:'Especial (3 ⚡): 1 turno sin poder ser objetivo de disparos. Se rompe al disparar. Además lleva 2 granadas de humo M18 (botón Humo, 2 ⚡): cortina en cruz que bloquea la visión 2 rondas, sin daño y sin bloquear el movimiento.',desc:'Cuerpo ligero: el que más lejos llega por turno. Frágil, pero se cuela por cualquier pasillo.'},
 'Médico':{body:'medio',color:'#4ecb71',weapons:['M4A1','AK-12','HK416'],special:'Curar / Reanimar',sdesc:'Especial: curar 80 de vida a un aliado adyacente (3 ⚡, 2 usos) o reanimar a un caído adyacente con 80 de vida (4 ⚡, 1 uso). Pulsa el especial y luego al aliado.',desc:'Cuerpo medio. Mantiene viva a la escuadra. Sin él, cada baja es definitiva.'},
 'Ingeniero':{body:'medio',color:'#4ea8e8',weapons:['Remington 870','Benelli M4','M4A1','M203','Mossberg 500'],special:'Desplegar torreta',sdesc:'Especial (5 ⚡): despliega una torreta M2 Browning (120 PV) en una casilla adyacente libre. Dispara sola al final de tu turno: 45 de daño, alcance 6. Además lleva 2 minas Claymore M18A1 (botón Claymore, 3 ⚡): ocultas para el enemigo, 60 de daño a quien las pise.',desc:'Cuerpo medio. El rol que más cambia el mapa: torretas y demolición.'},
 'Comando':{body:'medio',color:'#e8c84e',weapons:['M4A1','AK-12','HK416','FN SCAR-L','M32 MGL','G36C','FAMAS'],special:'Granada extra',sdesc:'Lleva 2 granadas M67 en vez de 1: 75 de daño en área, lanzamiento a 3 casillas, coste 2 ⚡. Además lleva 2 granadas aturdidoras M84 (botón Aturdidora, 2 ⚡, lanzamiento a 4): sin daño, aturden a todo soldado en radio 1 durante 1 turno (−6 ⚡ y −25 de puntería en su turno, sin fuego de respuesta ni vigilancia).',desc:'Cuerpo medio. El soldado de asalto equilibrado, con una granada de más.'},
 'Capitán':{body:'medio',color:'#e84e7a',weapons:['M4A1','FN SCAR-L','Desert Eagle'],special:'Orden de mando',sdesc:'Especial (0 ⚡, 1 uso por turno): un aliado recupera 3 de energía este turno. Pulsa el especial y luego al aliado.',desc:'Cuerpo medio. Su orden convierte un turno agotado en otro asalto.'}
};

export const ROLE_NAMES=Object.keys(ROLES);

export const DEFAULT_SQUADS={2:['Comando','Francotirador'],4:['Comando','Francotirador','Médico','Ingeniero'],5:['Comando','Francotirador','Médico','Ingeniero','Espía']};

export const ROLE_LOOK={
 'Francotirador':{s:[0.84,1.07,0.88],silueta:'Flaco y alto',pose:null},
 'Artillero':{s:[1.30,1.04,1.22],silueta:'Enorme y ancho',pose:null},
 'Espía':{s:[0.86,0.90,0.88],silueta:'Pequeño y flaco',pose:null},
 'Médico':{s:[0.95,1.00,0.94],silueta:'Esbelto',pose:{clip:'interact',ct:0.95}},
 'Ingeniero':{s:[1.14,0.90,1.08],silueta:'Bajito y rechoncho',pose:{clip:'deploy',ct:0.32}},
 'Comando':{s:[1.07,1.02,1.03],silueta:'Atlético',pose:null},
 'Capitán':{s:[1.00,1.10,1.00],silueta:'Alto y erguido',pose:{clip:'interact',ct:0.45}}
};

export function roleLook(role){return ROLE_LOOK[role]||{s:[1,1,1],silueta:'',pose:null};}

export function gameplayModelPresentation(role,authoredModel){
  return {
    scale:authoredModel?[1,1,1]:roleLook(role).s,
    addRoleGear:!authoredModel,
    preserveTexture:authoredModel,
    twoSided:authoredModel,
    emissiveIntensity:authoredModel?0.18:0
  };
}

export const ROLE_PORTRAIT={'Francotirador':'retrato_francotirador.png','Artillero':'retrato_artillero.png','Espía':'retrato_espia.png','Médico':'retrato_medico.png','Ingeniero':'retrato_ingeniero.png','Comando':'retrato_comando.png','Capitán':'retrato_capitan.png'};

export const VOICE_FILES={'Francotirador':'Francotirador','Artillero':'Artillero','Espía':'Espia','Médico':'Medico','Ingeniero':'Ingeniero','Comando':'Comando','Capitán':'Capitan'};
