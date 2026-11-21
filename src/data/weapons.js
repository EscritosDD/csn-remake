export const WEAPONS={
 'M4A1':{dmg:28,rng:6,cost:3,cat:'Fusiles de asalto',real:'5,56×45 mm NATO · 2,92 kg vacío · 700–950 disp/min · alcance efectivo 500 m · EE. UU., 1994–presente',note:'El fusil de referencia: ráfaga fiable sin sorpresas.'},
 'AK-12':{dmg:30,rng:6,cost:3,cat:'Fusiles de asalto',real:'5,45×39 mm · 3,5 kg · 700 disp/min · alcance efectivo 440 m · Rusia, 2018–presente',note:'Un punto más de daño que el M4A1.'},
 'HK416':{dmg:28,rng:6,cost:3,cat:'Fusiles de asalto',real:'5,56×45 mm NATO · 700–900 disp/min · Alemania, 2004–presente · Heckler & Koch',note:'Sistema de pistón de gas: el fusil de élite del Comando.'},
 'FN SCAR-L':{dmg:30,rng:6,cost:3,cat:'Fusiles de asalto',real:'5,56×45 mm NATO · 650 disp/min · alcance efectivo 500 m · Bélgica/EE. UU., 2009–presente',note:'Puente entre fusil de asalto y fusil de tirador.'},
 'MP7':{dmg:20,rng:4,cost:2,cat:'Subfusiles',real:'4,6×30 mm · 1,90 kg · 950 disp/min · alcance efectivo 200 m · Alemania, 2001–presente',note:'Diseñada para perforar chalecos. El arma del Espía.'},
 'MP5':{dmg:22,rng:4,cost:2,cat:'Subfusiles',real:'9×19 mm · 2,54 kg · 800 disp/min · alcance efectivo 200 m · Alemania, 1966–presente',note:'El subfusil clásico de las fuerzas especiales.'},
 'FN P90':{dmg:18,rng:4,cost:2,cat:'Subfusiles',real:'5,7×28 mm · 2,6 kg · 850–1.100 disp/min · cargador de 50 cartuchos · Bélgica, 1990–presente',note:'Poco daño por tiro, pero su cargador de 50 nunca te deja tirado.'},
 'UMP45':{dmg:26,rng:3,cost:2,cat:'Subfusiles',real:'.45 ACP · 2,5 kg · 600–700 disp/min · alcance efectivo 65 m · Alemania, 2000–presente',note:'Pegar el tiro a quemarropa y desaparecer.'},
 'M249 SAW':{dmg:24,rng:6,cost:4,cat:'Ametralladoras',real:'5,56×45 mm · 7,5 kg (10 kg con 200 cartuchos) · 850 disp/min · alcance efectivo 700–800 m',note:'Fuego de supresión: el alcanzado pierde 2 de energía el próximo turno.',supp:true},
 'M240B':{dmg:30,rng:7,cost:4,cat:'Ametralladoras',real:'7,62×51 mm · 12,5 kg · 650–950 disp/min · alcance efectivo 800–1.800 m · designación de EE. UU. del FN MAG',note:'Más daño y más alcance que la SAW; el peso se nota al moverse.',supp:true},
 'PKM':{dmg:30,rng:7,cost:4,cat:'Ametralladoras',real:'7,62×54 mmR · 7,5 kg · 650 disp/min · alcance efectivo 1.000 m · URSS/Rusia, 1969–presente',note:'La ametralladora fiable del bloque del Este, con supresión.',supp:true},
 'MG3':{dmg:26,rng:6,cost:4,cat:'Ametralladoras',real:'7,62×51 mm · 11,5 kg · hasta 1.200 disp/min · Alemania, 1959–presente · derivada de la MG42',note:'Cadencia altísima para saturar una casilla.',supp:true},
 'M40':{dmg:70,rng:9,cost:4,cat:'Francotirador',real:'7,62×51 mm · cerrojo · 6,57 kg · alcance efectivo 800 m · Marines de EE. UU., 1966–2018',note:'Un disparo por turno. Crítico ×1,5 con el especial Tiro certero.'},
 'M24 SWS':{dmg:65,rng:9,cost:4,cat:'Francotirador',real:'7,62×51 mm · cerrojo · 5,4 kg vacío · alcance efectivo 800 m · Ejército de EE. UU., 1988–presente',note:'Intermedio entre el M40 y el antimaterial.'},
 'M110 SASS':{dmg:45,rng:8,cost:3,cat:'Francotirador',real:'7,62×51 mm · semiautomático · 6,27 kg · alcance efectivo 800 m · EE. UU., 2008–presente',note:'Semiautomático: dos tiros buenos en vez de uno perfecto.'},
 'SVD Dragunov':{dmg:50,rng:8,cost:3,cat:'Francotirador',real:'7,62×54 mmR · semiautomático · 4,30 kg · alcance efectivo 800 m · URSS, 1963–presente',note:'Fusil de tirador designado: acompaña a la escuadra.'},
 'AW50':{dmg:95,rng:10,cost:5,cat:'Francotirador',real:'.50 BMG · cerrojo · 15 kg con bípode · alcance efectivo 1.500 m · Reino Unido, 2000–presente',note:'Antimaterial: atraviesa coberturas ligeras.'},
 'Barrett M82':{dmg:100,rng:10,cost:5,cat:'Francotirador',kb:1,real:'.50 BMG · semiautomático · 13,5–14,8 kg · alcance efectivo 1.800 m · EE. UU. · «Light Fifty»',note:'El arma más dañina del juego.'},
 'Remington 870':{dmg:45,rng:2,cost:3,cat:'Escopetas',kb:1,real:'Calibre 12 · corredera · 3,2–3,6 kg · EE. UU., 1950–presente · más de 11 millones fabricadas',note:'45 de daño a 1 casilla, 20 a 2 casillas. Limpia esquinas.'},
 'Benelli M4':{dmg:40,rng:2,cost:3,cat:'Escopetas',kb:1,real:'Calibre 12 · semiautomática por gas · 3,82 kg · alcance efectivo 50 m · Italia, 1999–presente',note:'La M1014 de los Marines: ritmo sobre daño bruto.'},
 'RPG-7':{dmg:70,rng:6,cost:5,cat:'Lanzacohetes',kb:1,real:'Tubo de 40 mm, granada de 85 mm · 6,3 kg · alcance efectivo 330 m · URSS, 1961–presente · recargable',note:'70 directo y 30 de salpicadura en las casillas adyacentes.',aoe:true},
 'AT4':{dmg:85,rng:6,cost:5,cat:'Lanzacohetes',kb:1,real:'84 mm · 6,7 kg · alcance efectivo 300 m · Suecia, 1987–presente · desechable, un solo disparo',note:'Un solo uso por partida. Decidir cuándo gastarlo es la decisión.',once:true},
 'M72 LAW':{dmg:55,rng:5,cost:4,cat:'Lanzacohetes',kb:1,real:'66 mm · 2,5 kg · alcance efectivo 200 m · EE. UU., 1963–presente · desechable',note:'Un solo uso, pero ligero: no resta movimiento.',once:true},
 'M203':{dmg:45,rng:5,cost:3,cat:'Lanzagranadas',real:'40×46 mm · 1,36 kg bajo el cañón · alcance efectivo 350 m (área) · EE. UU., 1969–presente',note:'Granada con arco: salpicadura en las casillas adyacentes.',aoe:true},
 'M32 MGL':{dmg:40,rng:5,cost:3,cat:'Lanzagranadas',kb:1,real:'40×46 mm · tambor de 6 granadas · 5,3 kg · alcance efectivo 375–400 m · Sudáfrica, 1983–presente',note:'Tambor de seis: fuego de área sostenido.',aoe:true},
 'M9':{dmg:22,rng:3,cost:1,cat:'Pistolas',real:'9×19 mm · 970 g · cargador de 15 · Italia/EE. UU., reglamentaria 1985–2017',note:'La secundaria de todos: cuesta solo 1 de energía.'},
 'Glock 17':{dmg:22,rng:3,cost:1,cat:'Pistolas',real:'9×19 mm · cargador de 17 · Austria, 1982–presente',note:'Como la M9, con dos cartuchos más por cargador.'},
 'M1911':{dmg:28,rng:3,cost:1,cat:'Pistolas',real:'.45 ACP · 1.100 g · cargador de 7 · EE. UU., reglamentaria 1911–1985 · diseño de Browning',note:'La secundaria con más pegada.'},
 'Desert Eagle':{dmg:40,rng:3,cost:2,cat:'Pistolas',real:'.50 AE / .44 Magnum · unos 2,0 kg · EE. UU./Israel, 1982–presente · uso civil, no militar estándar',note:'Daño de escopeta a distancia de pistola.'},
 'Mk 14 EBR':{dmg:74,rng:9,cost:4,cat:'Francotirador',real:'7,62x51 mm NATO · semiautomatico · 5,1 kg · EE. UU., 2004-presente',note:'DMR: mas rapido que el cerrojo, menos letal que un Barrett.'},
 'PSG-1':{dmg:72,rng:10,cost:4,cat:'Francotirador',real:'7,62x51 mm NATO · semiautomatico · 8,1 kg · Alemania, 1985',note:'Precision de banco: castiga la distancia larga.'},
 'Browning M2':{dmg:38,rng:7,cost:3,cat:'Ametralladoras',real:'12,7x99 mm · 38 kg · EE. UU., 1933-presente',note:'Fuego pesado: borra coberturas ligeras.'},
 'Mk 19':{dmg:85,rng:5,cost:4,cat:'Lanzagranadas',real:'40 mm · 35 kg · EE. UU., 1968-presente',note:'Salvas de 40 mm: castigo en area.'},
 'KRISS Vector':{dmg:26,rng:4,cost:1,cat:'Subfusiles',real:'9x19 mm · 2,7 kg · EE. UU., 2006-presente',note:'Rafaga corta con muy poco retroceso.'},
 'G36C':{dmg:29,rng:6,cost:2,cat:'Fusiles de asalto',real:'5,56x45 mm NATO · 2,8 kg · Alemania, 1996',note:'Compacto y estable.'},
 'FAMAS':{dmg:27,rng:6,cost:2,cat:'Fusiles de asalto',real:'5,56x45 mm NATO · 3,6 kg · Francia, 1978',note:'Bullpup: corto de longitud, pegada seca.'},
 'Mossberg 500':{dmg:66,rng:2,cost:2,cat:'Escopetas',real:'12/70 · 3,2 kg · EE. UU., 1961-presente',note:'Bomba de corredera: castiga a bocajarro.'},

};

export const PISTOL='M9';

export const WEAPON_SFX={'Fusiles de asalto':'assaultrifle_fire','Subfusiles':'assaultrifle_fire','Ametralladoras':'assaultrifle_fire','Escopetas':'shotgun_fire','Francotirador':'sniperrifle_fire','Lanzacohetes':'rocketlauncher_fire','Lanzagranadas':'cluster_explode','Pistolas':'beretta_fire'};

export const DMR_WEAPONS=['M110 SASS','Mk 14 EBR','SVD Dragunov','Mk 14'];
