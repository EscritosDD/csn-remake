export const CHARACTERS=[
 /* Los 7 jugables del original (ORIG_CAST, play:true): un personaje por rol.
    La lista antigua tenía los roles equivocados (Hipster Dave como Artillero,
    Big Time Taschmann como Capitán, no jugables como Archie Fletcher, Mme La
    Hacque, Soap, Riot Medic y Megan McNick con rol) y dejaba fuera a Riot
    Agent (Comando) y a Commander (M) (Capitán), así que en partida los
    soldados llevaban el nombre equivocado. */
 {name:'Hipster Dave',role:'Francotirador',bio:'Gafas verdes, pelo naranja y un fusil enorme. Cara de enfado permanente.'},
 {name:'Ivan Tkilya',role:'Artillero',bio:'Pesado de manual: donde se planta, hay que rodearlo.'},
 {name:'Sneaky Pete',role:'Espía',bio:'Nadie le vio llegar; nadie le vio irse.'},
 {name:'Sister Florence',role:'Médico',bio:'Reza por ti y luego te cose la herida.'},
 {name:'Big Time Taschmann',role:'Ingeniero',bio:'Maza más alta que su torso y sonrisa de oreja a oreja.'},
 {name:'Riot Agent',role:'Comando',bio:'Antidisturbios: escudo primero, preguntas después.'},
 {name:'Commander (M)',role:'Capitán',bio:'Manda con la voz y con el ejemplo.'}
];

export const CHARACTER_ABILITIES={
 'Hipster Dave':[
  {icon:'CharAbility_43_Support_Fire_alpha',n:'Fuego de apoyo',d:'Dispara contra el enemigo que se mueve para proteger a los compañeros.',obj:null},
  {icon:'CharAbility_14_Frag_Grenade_alpha',n:'Granada de fragmentación',d:'Granada con daño en área.',obj:null}],
 'Archie Fletcher':[
  {icon:'CharAbility_43_Support_Fire_alpha',n:'Fuego de apoyo',d:'Dispara contra el enemigo que se mueve para proteger a los compañeros.',obj:null},
  {icon:'CharAbility_49_crossbow_alpha',n:'Ballesta explosiva',d:'Ballesta con daño en área.',obj:null}],
 'Soap':[
  {icon:'CharAbility_43_Support_Fire_alpha',n:'Fuego de apoyo',d:'Dispara contra el enemigo que se mueve para proteger a los compañeros.',obj:null},
  {icon:'CharAbility_35_Remote_Charge_alpha',n:'Carga remota',d:'Carga C4 oculta por control remoto.',obj:'charge'}],
 'Spud':[
  {icon:'CharAbility_43_Support_Fire_alpha',n:'Fuego de apoyo',d:'Dispara contra el enemigo que se mueve para proteger a los compañeros.',obj:null},
  {icon:'CharAbility_48_bazooka_alpha',n:'Lanzacohetes',d:'Cohete con daño en área de radio amplio.',obj:null}],
 'Ivan Tkilya':[
  {icon:'CharAbility_43_Support_Fire_alpha',n:'Fuego de apoyo',d:'Dispara contra el enemigo que se mueve para proteger a los compañeros.',obj:null},
  {icon:'CharAbility_09_Concussion_Grenade_alpha',n:'Granada de concusión',d:'Reduce la energía de enemigos y desplegables.',obj:null}],
 'Mme La Hacque':[
  {icon:'CharAbility_17_Ghost_alpha',n:'Fantasma',d:'Invisible durante 3 turnos.',obj:null},
  {icon:'CharAbility_46_UAV_alpha',n:'UAV',d:'Dron explorador por control remoto que explota.',obj:'uav'}],
 'Sneaky Pete':[
  {icon:'CharAbility_17_Ghost_alpha',n:'Fantasma',d:'Invisible durante 3 turnos.',obj:null},
  {icon:'CharAbility_19_Headshot_alpha',n:'Tiro a la cabeza',d:'Crítico garantizado.',obj:null}],
 'Sister Florence':[
  {icon:'CharAbility_30_Medkit_alpha',n:'Botiquín',d:'Cura a un compañero.',obj:null},
  {icon:'CharAbility_20_Healing_Aura_alpha',n:'Aura curativa',d:'Cura a varios compañeros en un área.',obj:null}],
 'Riot Medic':[
  {icon:'CharAbility_30_Medkit_alpha',n:'Botiquín',d:'Cura a un compañero.',obj:null},
  {icon:'CharAbility_52_WaterCannon_alpha',n:'Cañón de agua',d:'Chorro que empuja a los enemigos.',obj:null}],
 'Textbook Kate':[
  {icon:'CharAbility_30_Medkit_alpha',n:'Botiquín',d:'Cura a un compañero.',obj:null},
  {icon:'CharAbility_15_Gas_Grenade_alpha',n:'Granada de gas',d:'Envenena a los enemigos.',obj:null}],
 'Big Time Taschmann':[
  {icon:'CharAbility_16_Gatling_Turret_alpha',n:'Torreta Gatling',d:'Torreta desplegable.',obj:'gatling'},
  {icon:'CharAbility_45_Toolkit_alpha',n:'Reparar',d:'Repara los desplegables aliados.',obj:null}],
 'Megan McNick':[
  {icon:'CharAbility_27_Landmines_alpha',n:'Minas',d:'Minas ocultas desplegables.',obj:'mine'},
  {icon:'CharAbility_45_Toolkit_alpha',n:'Reparar',d:'Repara los desplegables aliados.',obj:null}],
 'Carlito Grosso':[
  {icon:'CharAbility_37_Rocket_Turret_alpha',n:'Torreta de cohetes',d:'Torreta de cohetes desplegable.',obj:'rocket'},
  {icon:'CharAbility_45_Toolkit_alpha',n:'Reparar',d:'Repara los desplegables aliados.',obj:null}],
 'Riot Agent':[
  {icon:'CharAbility_17_Ghost_alpha',n:'Fantasma',d:'Invisible durante 3 turnos.',obj:null},
  {icon:'CharAbility_50_Molotov_alpha',n:"Flamin' Nora",d:'Granada incendiaria: daña a todos los enemigos en un radio de 3 casillas. Sin icono propio extraído; usa el de Molotov, el incendiario más cercano.',obj:null}],
 'Riot Engineer':[
  {icon:'CharAbility_51_RiotShield_alpha',n:'Shield-O-Bot',d:'Robot escudo por control remoto. Sin icono propio extraído; usa el de Escudo antidisturbios, el desplegable de escudo más cercano.',obj:'shieldbot'},
  {icon:'CharAbility_45_Toolkit_alpha',n:'Reparar',d:'Repara los desplegables aliados.',obj:null}],
 'Commander (M)':[],
 'Commander (F)':[]
};

export const ABILITY_OBJECTS={
 'uav':{name:'UAV',icon:'CharAbility_46_UAV_alpha',model:'UAV',note:'Dron explorador (mesh_UAV de BasicAbilities).'},
 'gatling':{name:'Torreta Gatling',icon:'CharAbility_16_Gatling_Turret_alpha',model:'GatlingTurret',note:'Torreta desplegable (MGTurret de Abilities).'},
 'rocket':{name:'Torreta de cohetes',icon:'CharAbility_37_Rocket_Turret_alpha',model:'RocketTurret',note:'Torreta de cohetes desplegable (RocketTurretBase de Abilities).'},
 'mine':{name:'Mina',icon:'CharAbility_27_Landmines_alpha',model:'SpiderMine',note:'Mina oculta (SpiderMine de BasicAbilities).'},
 'charge':{name:'Carga remota',icon:'CharAbility_35_Remote_Charge_alpha',model:'RemoteCharge',note:'Carga C4 oculta (Box001 con RemoteCharge_d de BasicAbilities).'},
 'shieldbot':{name:'Shield-O-Bot',icon:'CharAbility_51_RiotShield_alpha',model:'RiotShieldBot',note:'Robot escudo por control remoto (RiotShieldBot de Abilities02).'},
 'cover':{name:'Cobertura desplegable',icon:'PlayerAbility_04_Deployo-Cover_alpha',model:'DeployableCover',note:'Cobertura desplegable (DeployableCover de BasicAbilities).'},
 'objective':{name:'Cohete objetivo',icon:'PlayerAbility_09_Orbital_Laser_alpha',model:'ObjectiveRocket',note:'Cohete objetivo del mapa (Rocket de BasicAbilities).'},
 'crate':{name:'Caja de botín',icon:'PlayerAbility_06_Health_Crate_alpha',model:'CommCrate_124tri',note:'Caja de comandante / botín (CommCrate).'}
};

export const CAST_TEXTURE_FILE={
 'Hipster Dave':'Soldier_Light_DeltaForce_d.png',
  'Archie Fletcher':'Soldier_Light_Rambo_DeerHunter_d.png',
  'Soap':'Soldier_SAS_d.png',
  'Spud':'Soldier_d.png',
 'Ivan Tkilya':'Soldier_heavy_GermanSpecialForces_d.png',
 'Mme La Hacque':'Agent_light_JewelThief_d.png',
 'Sneaky Pete':'Agent_light_d.png',
 'Sister Florence':'Medic_Rescue_d.png',
 'Riot Medic':'Medic_Therapist_d.png',
 'Textbook Kate':'Medic_d.png',
 'Big Time Taschmann':'Engineer_Spetsnaz_d.png',
 'Megan McNick':'Engineer_Light_Trinity_d.png',
 'Carlito Grosso':'Engineer_Heavy_EOD_d.png',
 'Riot Agent':'Agent_Heavy_Skin1_d.png',
 'Riot Engineer':'Engineer_RiotCop_d.png',
 'Commander (M)':'Commander_d.png',
 'Commander (F)':'Commander_F_d.png'
};

export const CHAR_ABILITY_ACTIONS={
  'CharAbility_14_Frag_Grenade_alpha':'grenade',
  'CharAbility_15_Gas_Grenade_alpha':'gas',
  'CharAbility_09_Concussion_Grenade_alpha':'flash',

 'CharAbility_50_Molotov_alpha':'molotov',
 'CharAbility_45_Toolkit_alpha':'toolkit',
 'CharAbility_52_WaterCannon_alpha':'water',
 'CharAbility_13_Detection_Aura_alpha':'sweep',
 'CharAbility_43_Support_Fire_alpha':'arty',
 'CharAbility_24_Juggernaut_alpha':'shield',
 'CharAbility_17_Ghost_alpha':'special',
  'CharAbility_30_Medkit_alpha':'special',
  'PlayerAbility_06_Health_Crate_alpha':'crate',

 'CharAbility_36_Revive_alpha':'special',
 'CharAbility_42_Sniper_Rifle_Specialization_alpha':'special',
 'CharAbility_23_HMG_Specialization_alpha':'special',
 'CharAbility_07_Caltrops_alpha':'mine',
 'CharAbility_33_Nail_Mines_alpha':'mine',
 'CharAbility_12_Deployable_Cover_alpha':'cover',
 'CharAbility_27_Landmines_alpha':'mine',
 'CharAbility_37_Rocket_Turret_alpha':'deployRocket',
 'CharAbility_38_Rush_Aura_alpha':'teleport',
 'CharAbility_44_Swarm_Aura_alpha':'bees',
 'CharAbility_16_Gatling_Turret_alpha':'deploy'
};

export const CHAR_VOICE={'Hipster Dave':'Hipster_Dave','Archie Fletcher':'Archie_Fletcher','Soap':'Soap','Spud':'Spud','Ivan Tkilya':'Ivan_Tkilya','Mme La Hacque':'Mme_La_Hacque','Sneaky Pete':'Sneaky_Pete','Sister Florence':'Sister_Florence','Textbook Kate':'Textbook_Kate','Riot Medic':'Riot_Medic','Big Time Taschmann':'Big_Time_Taschmann','Megan McNick':'Megan_McNick','Carlito Grosso':'Carlito_Grosso','Riot Agent':'Riot_Agent','Riot Engineer':'Riot_Engineer','Commander (M)':'Commander_M','Commander (F)':'Commander_F','Lobo':'Generico_M','Mula':'Generico_M','Sombra':'Generico_M','Alfiler':'Generico_M','Tuerca':'Generico_M','Faro':'Generico_M','Brújula':'Generico_M','Yunque':'Generico_M','Gacela':'Generico_M','Bisturí':'Generico_M','Llave':'Generico_M','Trueno':'Generico_M','Ciclón':'Generico_M','Roca':'Generico_M','Víbora':'Generico_M','Venda':'Generico_M','Engranaje':'Generico_M','Centella':'Generico_M'};

export const MESHY_CAST=[
 {key:'own:09',label:'Diseño Meshy 09',name:'Diseño Meshy 09',role:'Francotirador',mesh:'Francotirador',texture:'assets/personajes_propios/Francotirador_tex.png',bio:'Diseño propio de Dani.',play:true,sculptedWeapon:true},
 {key:'own:10',label:'Diseño Meshy 10',name:'Diseño Meshy 10',role:'Artillero',mesh:'Artillero',texture:'assets/personajes_propios/Artillero_tex.png',bio:'Diseño propio de Dani.',play:true,sculptedWeapon:true},
 {key:'own:11',label:'Diseño Meshy 11',name:'Diseño Meshy 11',role:'Espía',mesh:'Espia',texture:'assets/personajes_propios/Espia_tex.png',bio:'Diseño propio de Dani.',play:true,sculptedWeapon:true},
 {key:'own:12',label:'Diseño Meshy 12',name:'Diseño Meshy 12',role:'Médico',mesh:'Medico',texture:'assets/personajes_propios/Medico_tex.png',bio:'Diseño propio de Dani.',play:true,sculptedWeapon:true},
 {key:'own:13',label:'Diseño Meshy 13',name:'Diseño Meshy 13',role:'Ingeniero',mesh:'Ingeniero',texture:'assets/personajes_propios/Ingeniero_tex.png',bio:'Diseño propio de Dani.',play:true,sculptedWeapon:true}
];

export const OWN_CAST=[
 {name:'Lobo',body:'Soldier_Light',outfit:'Veterano de CSN',role:'Francotirador',play:true,bio:'Frío, paciente, siempre el último en disparar.',own:true,tint:'#3c4436'},
 {name:'Mula',body:'Soldier_Heavy',outfit:'Porteador de asalto',role:'Artillero',play:true,bio:'Carga con todo lo que la escuadra no quiere llevar.',own:true,tint:'#4b4235'},
 {name:'Sombra',body:'Agent_Light',outfit:'Infiltración CSN',role:'Espía',play:true,bio:'Entra donde no hay puerta.',own:true,tint:'#2b2738'},
 {name:'Alfiler',body:'Medic',outfit:'Sanitario de trinchera',role:'Médico',play:true,bio:'Cose heridas y parche egos.',own:true,tint:'#d8dcd2'},
 {name:'Tuerca',body:'Engineer',outfit:'Manitas de campaña',role:'Ingeniero',play:true,bio:'Una torreta suya vale por dos soldados.',own:true,tint:'#b8891f'},
 {name:'Faro',body:'Agent_Heavy',outfit:'Punta de lanza',role:'Comando',play:true,bio:'Abre camino a tiros y avisa a los suyos.',own:true,tint:'#3a4050'},
 {name:'Brújula',body:'Commander',outfit:'Mando de campo',role:'Capitán',play:true,bio:'Se orienta en cualquier tablero.',own:true,tint:'#2f3540'},
 {name:'Yunque',body:'Soldier_Heavy',outfit:'Asalto pesado CSN',role:'Artillero',play:true,bio:'Donde pone el pie, no se pasa.',own:true,tint:'#4d3f2f'},
 {name:'Gacela',body:'Agent_Light',outfit:'Exploradora CSN',role:'Espía',play:true,bio:'Llega antes de que el rival se gire.',own:true,tint:'#6b7a52'},
 {name:'Bisturí',body:'Medic',outfit:'Cirujana de campaña',role:'Médico',play:true,bio:'Precisión quirúrgica, dentro y fuera del quirófano.',own:true,tint:'#e2e6dc'},
 {name:'Llave',body:'Engineer',outfit:'Zapadora CSN',role:'Ingeniero',play:true,bio:'Todo lo que se rompe lo arregla; lo que no, lo desmonta.',own:true,tint:'#7a5a2e'},
 {name:'Trueno',body:'Agent_Heavy',outfit:'Asalto CSN',role:'Comando',play:true,bio:'Ruido, humo y una vía abierta.',own:true,tint:'#3f4a3a'},
 {name:'Ciclón',body:'Soldier_Light',outfit:'Tiradora de precisión',role:'Francotirador',play:true,bio:'Un tiro, un blanco.',own:true,tint:'#5a5f6b'},
 {name:'Roca',body:'Soldier_Heavy',outfit:'Ametrallador de CSN',role:'Artillero',play:true,bio:'Aguanta el fuego para que otros avancen.',own:true,tint:'#4a4034'},
 {name:'Víbora',body:'Agent_Light',outfit:'Infiltración nocturna',role:'Espía',play:true,bio:'Se cuela por la cobertura y no deja rastro.',own:true,tint:'#31402c'},
 {name:'Venda',body:'Medic',outfit:'Camillera de asalto',role:'Médico',play:true,bio:'Recoge a los caídos sin dejar de disparar.',own:true,tint:'#cfd6cc'},
 {name:'Engranaje',body:'Engineer',outfit:'Especialista en torretas',role:'Ingeniero',play:true,bio:'Convierte chatarra en defensa.',own:true,tint:'#6a5a3a'},
 {name:'Centella',body:'Agent_Heavy',outfit:'Reacción rápida',role:'Comando',play:true,bio:'Primero en entrar, último en irse.',own:true,tint:'#4a3f52'}
];

export const ORIG_CAST=[
 {name:'Hipster Dave',body:'Soldier_Light',outfit:'Soldier_Light_d / DeltaForce / Veteran',role:'Francotirador',bio:'Gafas verdes, pelo naranja y un fusil enorme. Cara de enfado permanente.',play:true},
  {name:'Archie Fletcher',body:'Soldier_Light_Rambo',outfit:'Rambo / DeerHunter',role:'Francotirador',bio:'Rambo de mercadillo: cinta en la cabeza y más valor que puntería.',play:true},
  {name:'Soap',body:'Soldier_SAS',outfit:'Soldier_SAS',role:'Francotirador',bio:'El nombre que todos recuerdan y nadie explica.',play:true},
  {name:'Spud',body:'Soldier_Spud',outfit:'Soldier_ForestCamo',role:'Francotirador',bio:'Patata de nombre, roca de aguante.',play:true},
 {name:'Ivan Tkilya',body:'Soldier_Heavy',outfit:'Soldier_heavy / GermanSpecialForces',role:'Artillero',bio:'Pesado de manual: donde se planta, hay que rodearlo.',play:true},
  {name:'Mme La Hacque',body:'Agent_Light',outfit:'Agent_light / JewelThief',role:'Espía',bio:'Elegancia francesa con un cuchillo en la bota.',play:true},
 {name:'Sneaky Pete',body:'Agent_Light',outfit:'Agent_light (base)',role:'Espía',bio:'Nadie le vio llegar; nadie le vio irse.',play:true},
 {name:'Sister Florence',body:'Medic',outfit:'Medic / Medic_Rescue',role:'Médico',bio:'Reza por ti y luego te cose la herida.',play:true,rigPose:true},
  {name:'Riot Medic',body:'Medic_therapist',outfit:'Medic_therapist',role:'Médico',bio:'Casco antidisturbios y camilla blindada.',play:true},
  {name:'Textbook Kate',body:'Medic',outfit:'Medic (variante)',role:'Médico',bio:'Se sabe el manual de memoria; por eso cura mejor.',play:true},
 {name:'Big Time Taschmann',body:'Engineer',outfit:'Engineer / Spetsnaz',role:'Ingeniero',bio:'Maza más alta que su torso y sonrisa de oreja a oreja.',play:true},
  {name:'Megan McNick',body:'Engineer_Light',outfit:'Engineer_Light / Trinity',role:'Ingeniero',bio:'Ingeniera de Trinity: torretas antes que palabras.',play:true},
  {name:'Carlito Grosso',body:'Engineer_Heavy',outfit:'Engineer_Heavy / EOD',role:'Ingeniero',bio:'Siempre vuelve con el blindaje puesto.',play:true},
 {name:'Riot Agent',body:'Agent_Heavy',outfit:'Agent_Heavy / Skin1',role:'Comando',bio:'Antidisturbios: escudo primero, preguntas después.',play:true},
  {name:'Riot Engineer',body:'Engineer (RiotCop)',outfit:'Engineer_RiotCop',role:'Ingeniero',bio:'Convierte una calle en una fortaleza en tres turnos.',play:true},
 {name:'Commander (M)',body:'Commander',outfit:'Commander / Latino / Asian / African',role:'Capitán',bio:'Manda con la voz y con el ejemplo.',play:true},
  {name:'Commander (F)',body:'Commander_F',outfit:'Commander_F / Latino / Asian / African',role:'Capitán',bio:'Misma autoridad, otro acento.',play:true}
];

export function sculptedWeaponUnit(un){return !!(un&&un.charMesh&&MESHY_CAST.some(entry=>entry.mesh===un.charMesh&&entry.sculptedWeapon));}
