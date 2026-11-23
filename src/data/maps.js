import { CAMPAIGN_DATA_MISSIONS, TUTORIAL_DATA_MISSION, TUTORIAL_DATA_STEPS, CAMPAIGN_DATA_CHAPTERS, RADIO_DATA_LINES, missionByIdData, rosterKeyData, campaignStarsData, radioLinesData } from './campaign.js';

export const CAMPAIGN_MISSIONS=CAMPAIGN_DATA_MISSIONS;
export const TUTORIAL_MISSION=TUTORIAL_DATA_MISSION;
export const TUTORIAL_STEPS=TUTORIAL_DATA_STEPS;
export const CAMPAIGN_CHAPTERS=CAMPAIGN_DATA_CHAPTERS;
export const RADIO_LINES=RADIO_DATA_LINES;
export const missionById=missionByIdData;
export const rosterKey=rosterKeyData;
export const campaignStars=campaignStarsData;
export const radioLines=radioLinesData;


export const SKIRMISH_GEO={
 skirmish03:{bin:'assets/maps/skirmish03.bin',atlas:['assets/maps/skirmish03_atlas0.jpg','assets/maps/skirmish03_atlas1.jpg'],top:'assets/maps/skirmish03_top.jpg'},
 /* Los atlas de Skirmish_04 son byte a byte los de Skirmish_03: se reutilizan. */
 skirmish04:{bin:'assets/maps/skirmish04.bin',atlas:['assets/maps/skirmish03_atlas0.jpg','assets/maps/skirmish03_atlas1.jpg'],top:'assets/maps/skirmish04_top.jpg'},
 depot:{bin:'assets/maps/skirmish05.bin',atlas:['assets/maps/skirmish_atlas0.png','assets/maps/skirmish_atlas1.png'],top:'assets/maps/skirmish05_top.jpg'},
 platform:{bin:'assets/maps/skirmish06.bin',atlas:['assets/maps/skirmish_atlas0.png','assets/maps/skirmish_atlas1.png'],top:'assets/maps/skirmish06_top.jpg'},
 terminal:{bin:'assets/maps/skirmish08.bin',atlas:['assets/maps/skirmish_atlas0.png','assets/maps/skirmish_atlas1.png'],top:'assets/maps/skirmish08_top.jpg'},
 rotonda:{bin:'assets/maps/skirmish09.bin',atlas:['assets/maps/skirmish_atlas0.png','assets/maps/skirmish_atlas1.png'],top:'assets/maps/skirmish09_top.jpg'},
 cruce:{bin:'assets/maps/skirmish10.bin',atlas:['assets/maps/skirmish_atlas0.png','assets/maps/skirmish_atlas1.png'],top:'assets/maps/skirmish10_top.jpg'},
 astillero:{bin:'assets/maps/skirmish11.bin',atlas:['assets/maps/skirmish_atlas0.png','assets/maps/skirmish_atlas1.png'],top:'assets/maps/skirmish11_top.jpg'},
};

export const MAPS_ORIGINAL=[
  {id:'skirmish_03',name:'Skirmish_03',bundle:'Theme_01_Skirmish_03.assetbundle',board:'skirmish',theme:'skirmish03',verts:84939,pieces:45,floor:[41.33,33.33],floorTiles:[15.0,12.1],bounds:[50.62,13.25,34.56],boundsTiles:[18.37,4.81,12.54],scale:0.3629},
  {id:'skirmish_04',name:'Skirmish_04',bundle:'Theme_01_Skirmish_04.assetbundle',board:'skirmish04',theme:'skirmish04',verts:80571,pieces:42,floor:[42.83,39.33],floorTiles:[15.0,13.77],bounds:[47.54,15.6,40.02],boundsTiles:[16.65,5.46,14.02],scale:0.3502},
  {id:'skirmish_05',name:'Skirmish_05',bundle:'Theme_01_Skirmish_05.assetbundle',board:'skirmish05',theme:'depot',verts:61665,pieces:32,floor:[35.0,37.1551],floorTiles:[15.0,15.92],bounds:[35.0,11.46,37.44],boundsTiles:[15.0,4.91,16.05],scale:0.4286},
  {id:'skirmish_06',name:'Skirmish_06',bundle:'Theme_01_Skirmish_06.assetbundle',board:'skirmish06',theme:'platform',verts:69652,pieces:31,floor:[29.0301,40.5],floorTiles:[15.0,20.93],bounds:[32.09,11.6,40.5],boundsTiles:[16.58,5.99,20.93],scale:0.5167},
  {id:'skirmish_08',name:'Skirmish_08',bundle:'Theme_01_Skirmish_08.assetbundle',board:'skirmish08',theme:'terminal',verts:87338,pieces:44,floor:[34.9112,56.0602],floorTiles:[15.0,24.09],bounds:[40.31,11.27,56.2],boundsTiles:[17.32,4.84,24.15],scale:0.4297},
  {id:'skirmish_09',name:'Skirmish_09',bundle:'Theme_01_Skirmish_09.assetbundle',board:'skirmish09',theme:'rotonda',verts:75576,pieces:36,floor:[60.5457,33.0602],floorTiles:[15.0,8.19],bounds:[60.59,11.6,33.16],boundsTiles:[15.01,2.87,8.21],scale:0.2477},
  {id:'skirmish_10',name:'Skirmish_10',bundle:'Theme_01_Skirmish_10.assetbundle',board:'skirmish10',theme:'cruce',verts:73683,pieces:24,floor:[27.0175,44.5],floorTiles:[15.0,24.71],bounds:[30.02,10.25,44.96],boundsTiles:[16.67,5.69,24.96],scale:0.5552},
  {id:'skirmish_11',name:'Skirmish_11',bundle:'Theme_01_Skirmish_11.assetbundle',board:'skirmish11',theme:'astillero',verts:74344,pieces:27,floor:[41.5721,34.625],floorTiles:[15.0,12.49],bounds:[41.58,11.43,35.62],boundsTiles:[15.0,4.12,12.85],scale:0.3608},
];

export const MAP_DEFS={
 almacen:{id:'almacen',theme:'warehouse',name:'Almacén industrial',
   walls:[[3,2],[3,3],[8,8],[8,9],[3,8],[3,9],[8,2],[8,3],[1,4],[10,7],[1,7],[10,4],[5,1],[6,10]],
   shelves:[[5,2],[6,9],[2,3],[9,8],[2,8],[9,3]],
   crates:[[2,5],[2,6],[9,5],[9,6],[5,3],[6,8],[4,8],[7,3],[5,8],[6,3]],
   barrels:[[4,4],[7,7],[7,4],[4,7]],
   medkits:[[2,9],[9,2]]},
 patio:{id:'patio',theme:'yard',name:'Patio de contenedores',
   walls:[[2,2],[9,9],[9,2],[2,9],[4,1],[7,10],[1,9],[10,2],[5,0],[6,11]],
   shelves:[[5,3],[6,8],[3,5],[8,6],[8,4],[3,7]],
   crates:[[4,4],[7,7],[7,4],[4,7],[2,6],[9,5],[6,2],[5,9],[4,9],[7,2]],
   barrels:[[5,4],[6,7],[3,3],[8,8]],
   medkits:[[1,2],[10,9]]},
 /* Skirmish_01, un tablero de este remake con un número que el
    original no tiene (su numeración Skirmish empieza en el 03):
    entra construido en código, como el 07, porque no hay paquete
    suyo en el IPA y por tanto no hay geometría suya que componer. Su disposición es nueva y propia, la de una plaza
    cerrada sobre el centro: pilares en las esquinas interiores de la
    plaza y en los bordes norte, sur y de los flancos, contenedores
    en un anillo roto alrededor de la baliza (los lados este y oeste
    del anillo y sus esquinas norte y sur), cajas pegadas a los
    cuatro lados de la baliza, en las entradas norte y sur del anillo
    y en los flancos, barriles en las diagonales de la baliza y
    botiquines en esquinas opuestas. Verificado con el mismo banco de
    pruebas de los demás tableros: simetría de 180° en las cinco
    familias de piezas, sin solapes entre ellas, despliegues, baliza,
    zonas de Dominación, salida del dron y extracción libres, baliza
    a 6 pasos de ambos despliegues, ruta del dron de 11 pasos y las
    114 casillas libres conectadas entre sí. Su suelo es el de la
    plaza (losas claras de piedra dibujadas en código en la vista
    clásica y en la 3D), sin plano cenital ni geometría del IPA:
    cuando su paquete se extraiga, entrará como capa visual igual que
    el 03 y el 04, sin tocar ni una regla. */
 skirmish01:{id:'skirmish01',theme:'plaza',name:'Skirmish_01 · Londres · La plaza',
   walls:[[3,3],[8,8],[8,3],[3,8],[5,0],[6,11],[2,0],[9,11],[0,2],[11,9],[11,2],[0,9]],
   shelves:[[4,3],[7,8],[7,3],[4,8],[3,5],[8,6],[8,5],[3,6]],
   crates:[[4,5],[7,6],[7,5],[4,6],[5,3],[6,8],[6,3],[5,8],[2,6],[9,5]],
   barrels:[[4,4],[7,7],[6,4],[5,7]],
   medkits:[[1,10],[10,1]]},
 /* Skirmish_02, el otro tablero de este remake con un número que
    el original no tiene: entra por el mismo camino que el 01,
    construido en código, sin paquete suyo en el IPA. Su disposición es nueva y propia,
    y la contraria a la de la plaza: un embarcadero junto al río, con
    dos bandas de contenedores en las filas 2 y 9 que dejan el canal
    central abierto de lado a lado, pilares en las esquinas, en los
    bordes norte y sur y en los extremos del canal, cajas pegadas a
    los cuatro lados de la baliza, sobre y bajo la zona central, en
    los flancos y en las diagonales exteriores, barriles en dos
    diagonales de la baliza y en los flancos del centro, y botiquines
    en esquinas opuestas. Verificado con el mismo banco de pruebas:
    simetría de 180° en las cinco familias de piezas, sin solapes
    entre ellas, despliegues, baliza, zonas de Dominación, salida del
    dron y extracción libres, baliza a 6 pasos de ambos despliegues,
    ruta del dron de 11 pasos y las 114 casillas libres conectadas
    entre sí. Su suelo es el del embarcadero (losas oscuras verdosas
    dibujadas en código en la vista clásica y en la 3D), sin plano
    cenital ni geometría del IPA: cuando su paquete se extraiga,
    entrará como capa visual igual que el 03 y el 04, sin tocar ni
    una regla. Con este tablero se cierra en el remake la serie del
    01 al 08 (el conteo completo del conjunto, con el 09, el 10 y el
    11, va en la entrada del Skirmish_09). */
 skirmish02:{id:'skirmish02',theme:'dock',name:'Skirmish_02 · Londres · El embarcadero',
   walls:[[1,1],[10,10],[10,1],[1,10],[4,0],[7,11],[0,4],[11,7],[6,0],[5,11],[9,1],[2,10]],
   shelves:[[3,2],[8,9],[8,2],[3,9],[5,2],[6,9],[6,2],[5,9]],
   crates:[[4,5],[7,6],[7,5],[4,6],[5,3],[6,8],[2,5],[9,6],[9,3],[2,8]],
   barrels:[[4,4],[7,7],[3,6],[8,5]],
   medkits:[[0,10],[11,1]]},
 /* Skirmish_03 del IPA (Theme_01_Skirmish_03), integrado con su
    geometría real como capa visual sobre la misma cuadrícula de 12×12:
    el escenario londinense completo del paquete (84.939 vértices y
    45.942 triángulos con sus dos atlas originales, ver loadSkirmishGeo)
    en la vista 3D, y su plano cenital derivado de esa misma geometría
    en la vista clásica. La disposición de piezas jugable sigue siendo
    la del remake sobre la cuadrícula, sin tocar ni una regla: baliza,
    torreta, despliegues y simetría de 180° son los de siempre, así que
    ningún bando nace con ventaja. */
 skirmish:{id:'skirmish',theme:'skirmish03',name:'Skirmish_03 · Londres',
   walls:[[2,1],[9,10],[9,1],[2,10],[0,9],[11,2],[5,2],[6,9],[1,1],[10,10]],
   shelves:[[4,2],[7,9],[7,2],[4,9],[2,4],[9,7],[9,4],[2,7]],
   crates:[[3,5],[8,6],[8,5],[3,6],[5,3],[6,8],[6,3],[5,8],[4,6],[7,5]],
   barrels:[[4,4],[7,7],[7,3],[4,8]],
   medkits:[[0,10],[11,1]]},
 /* Skirmish_04 del IPA (Theme_01_Skirmish_04), el segundo mapa Skirmish
    integrado con su geometría real como capa visual sobre la misma
    cuadrícula de 12×12: el escenario londinense del puente sobre el río
    (80.571 vértices y 45.030 triángulos con los mismos dos atlas del 03,
    compuesto con el mismo método verificado en el 03 y recentrado para
    que su suelo abrace el tablero, ver loadSkirmishGeo) en la vista 3D,
    y su plano cenital derivado de esa misma geometría en la vista
    clásica. La disposición de piezas jugable es nueva y distinta de la
    del 03, con la misma simetría de 180° y las mismas reglas. */
 skirmish04:{id:'skirmish04',theme:'skirmish04',name:'Skirmish_04 · Londres',
   walls:[[1,3],[10,8],[4,0],[7,11],[0,4],[11,7],[8,1],[3,10],[6,4],[5,7]],
   shelves:[[3,1],[8,10],[9,3],[2,8],[2,5],[9,6],[5,9],[6,2]],
   crates:[[4,3],[7,8],[7,3],[4,8],[3,6],[8,5],[8,6],[3,5],[5,4],[6,7]],
   barrels:[[4,5],[7,6],[2,2],[9,9]],
   medkits:[[1,10],[10,1]]},
 /* Skirmish_05, el siguiente mapa del conjunto: entra construido en
    código, como el Patio, porque su paquete Theme_01_Skirmish_05 no
    está entre los archivos del IPA extraídos hasta ahora y por tanto
    no hay geometría suya que componer. Su disposición es nueva y
    propia: pilares de estación en los bordes norte y sur y en las
    esquinas de los flancos, dos filas de contenedores que parten el
    depósito en tres pasillos, cajas pegadas a los lados de la baliza
    (con las entradas norte y sur de la zona libres) y en las
    diagonales interiores, barriles en dos esquinas de la baliza y en
    las diagonales exteriores, y botiquines en esquinas opuestas.
    Verificado: simetría de 180° en las cinco familias de piezas, sin
    solapes entre ellas, despliegues, baliza, zonas de Dominación,
    salida del dron y extracción libres, baliza a 7 pasos de ambos
    despliegues, ruta del dron de 12 pasos y las 114 casillas libres
    conectadas entre sí. Su suelo es el del depósito (losas gris
    azuladas dibujadas en código en la vista clásica y en la 3D), sin
    plano cenital ni geometría del IPA: cuando su paquete se extraiga,
    entrará como capa visual igual que el 03 y el 04, sin tocar ni
    una regla. */
 skirmish05:{id:'skirmish05',theme:'depot',name:'Skirmish_05 · Londres · El depósito',
   walls:[[2,0],[9,11],[9,0],[2,11],[0,2],[11,9],[11,2],[0,9],[4,2],[7,9],[7,2],[4,9]],
   shelves:[[2,4],[9,7],[9,4],[2,7],[5,1],[6,10],[6,1],[5,10]],
   crates:[[4,5],[7,6],[7,5],[4,6],[3,3],[8,8],[8,3],[3,8],[2,6],[9,5]],
   barrels:[[4,4],[7,7],[3,2],[8,9]],
   medkits:[[2,10],[9,1]]},
 /* Skirmish_06, el siguiente mapa del conjunto tras el 05: entra por
    el mismo camino, construido en código, porque su paquete
    Theme_01_Skirmish_06 tampoco está entre los archivos del IPA
    extraídos hasta ahora. Su disposición es nueva y propia, la de
    unos andenes de estación: dos bandas de contenedores en las filas
    3 y 8 que dejan el paso central abierto y solo se cruzan por los
    extremos y por dos pasos con caja destructible, pilares en las
    esquinas, en los bordes norte y sur y cerrando el centro de cada
    banda, cajas pegadas a los cuatro lados de la baliza y en los
    flancos, barriles en las diagonales interiores y junto a los
    pasos de los extremos, y botiquines en esquinas opuestas.
    Verificado con el mismo banco de pruebas de los demás tableros:
    simetría de 180° en las cinco familias de piezas, sin solapes
    entre ellas, despliegues, baliza, zonas de Dominación, salida del
    dron y extracción libres, baliza a 6 pasos de ambos despliegues,
    ruta del dron de 12 casillas y las 112 casillas libres conectadas
    entre sí. Su suelo es el de los andenes (losas cálidas oscuras
    dibujadas en código en la vista clásica y en la 3D), sin plano
    cenital ni geometría del IPA: cuando su paquete se extraiga,
    entrará como capa visual igual que el 03 y el 04, sin tocar ni
    una regla. */
 skirmish06:{id:'skirmish06',theme:'platform',name:'Skirmish_06 · Londres · Los andenes',
   walls:[[1,1],[10,10],[10,1],[1,10],[3,1],[8,10],[8,1],[3,10],[5,3],[6,8],[6,3],[5,8],[0,8],[11,3]],
   shelves:[[2,3],[9,8],[3,3],[8,8],[8,3],[3,8],[9,3],[2,8]],
   crates:[[5,4],[6,7],[6,4],[5,7],[4,5],[7,6],[2,6],[9,5],[4,8],[7,3]],
   barrels:[[4,4],[7,7],[1,8],[10,3]],
   medkits:[[1,2],[10,9]]},
 /* Skirmish_07, el siguiente mapa del conjunto tras el 06: entra por
    el mismo camino, construido en código, porque su paquete
    Theme_01_Skirmish_07 tampoco está entre los archivos del IPA
    extraídos hasta ahora. Su disposición es nueva y propia, la de un
    mercado cerrado sobre el centro: pilares en los bordes norte y
    sur, en las esquinas interiores de los flancos y en el rincón
    noroeste y su pareja, puestos en cruz alrededor de la baliza y
    cruzando las filas centrales, cajas pegadas a los cuatro lados de
    la baliza y en las diagonales y los flancos, barriles en las
    diagonales de la baliza y botiquines en esquinas opuestas.
    Verificado con el mismo banco de pruebas de los demás tableros:
    simetría de 180° en las cinco familias de piezas, sin solapes
    entre ellas, despliegues, baliza, zonas de Dominación, salida del
    dron y extracción libres, baliza a 6 pasos de ambos despliegues,
    ruta del dron de 11 pasos y las 114 casillas libres conectadas
    entre sí. Su suelo es el del mercado (losas cálidas de arena y
    terracota dibujadas en código en la vista clásica y en la 3D),
    sin plano cenital ni geometría del IPA: cuando su paquete se
    extraiga, entrará como capa visual igual que el 03 y el 04, sin
    tocar ni una regla. */
 skirmish07:{id:'skirmish07',theme:'market',name:'Skirmish_07 · Londres · El mercado',
   walls:[[1,2],[10,9],[10,0],[1,11],[2,1],[9,10],[5,0],[6,11],[2,2],[9,9],[4,1],[7,10]],
   shelves:[[3,5],[8,6],[8,5],[3,6],[5,2],[6,9],[2,8],[9,3]],
   crates:[[4,5],[7,6],[7,5],[4,6],[5,3],[6,8],[1,8],[10,3],[3,9],[8,2]],
   barrels:[[4,4],[7,7],[6,4],[5,7]],
   medkits:[[2,10],[9,1]]},
 /* Skirmish_08, el siguiente mapa del conjunto tras el 07: entra por
    el mismo camino, construido en código, porque su paquete
    Theme_01_Skirmish_08 tampoco está entre los archivos del IPA
    extraídos hasta ahora. Su disposición es nueva y propia, y la
    contraria a la del mercado: una terminal de carga abierta, con
    dos bandas de puestos en las filas 4 y 7 que solo cubren los
    flancos del centro y dejan las filas de la baliza despejadas,
    pilares en los bordes y las esquinas, cajas sobre y bajo la
    baliza, a sus lados y en las diagonales exteriores, barriles en
    el centro de los flancos y en las diagonales, y botiquines en
    esquinas opuestas. Es el tablero más rápido del conjunto: la
    baliza queda a solo 4 pasos de ambos despliegues. Verificado con
    el mismo banco de pruebas: simetría de 180° en las cinco familias
    de piezas, sin solapes, despliegues, baliza, zonas de Dominación,
    salida del dron y extracción libres, ruta del dron de 11 pasos y
    las 114 casillas libres conectadas entre sí. Su suelo es el de la
    terminal (hormigón azul oscuro dibujado en código en la vista
    clásica y en la 3D), sin plano cenital ni geometría del IPA:
    cuando su paquete se extraiga, entrará como capa visual igual que
    el 03 y el 04, sin tocar ni una regla. */
 skirmish08:{id:'skirmish08',theme:'terminal',name:'Skirmish_08 · Londres · La terminal',
   walls:[[5,1],[6,10],[6,1],[5,10],[3,0],[8,11],[8,0],[3,11],[1,3],[10,8],[0,2],[11,9]],
   shelves:[[2,4],[9,7],[4,4],[7,7],[9,4],[2,7],[7,4],[4,7]],
   crates:[[5,4],[6,7],[6,4],[5,7],[4,5],[7,6],[2,9],[9,2],[1,9],[10,2]],
   barrels:[[3,5],[8,6],[5,9],[6,2]],
   medkits:[[0,10],[11,1]]},
 /* Skirmish_09, el siguiente mapa del conjunto tras el 08, y el que
   corrige su conteo: la numeración Skirmish del original no acaba
   en el 08, porque salta del 06 al 08 (no hay un Skirmish_07 suyo;
   el 07 de este remake es un tablero construido en código que
   ocupa ese hueco) y sigue con el 09, el 10 y el 11. Entra como
   entraron el 01, el 02 y del 05 al 08, construido en código,
   porque su paquete Theme_01_Skirmish_09 tampoco está entre los
   archivos del IPA extraídos hasta ahora. Su disposición es nueva
   y propia, la de una rotonda: un anillo de contenedores alrededor
   de la baliza, roto en las esquinas y en las casillas de zona, con
   las cajas pegadas a los lados este y oeste de la baliza, sobre
   las entradas norte y sur del anillo y en las esquinas exteriores,
   los barriles en las diagonales de la baliza, los pilares
   cerrando las esquinas y los bordes, y botiquines en esquinas
   opuestas. Verificado con el mismo banco de pruebas de los demás
   tableros: simetría de 180° en las cinco familias de piezas, sin
   solapes entre ellas, despliegues, baliza, zonas de Dominación,
   salida del dron y extracción libres, baliza a 6 pasos de ambos
   despliegues, ruta del dron de 11 pasos y las 114 casillas libres
   conectadas entre sí. Su suelo es el de la rotonda (asfalto cálido
   grisáceo dibujado en código en la vista clásica y en la 3D), sin
   plano cenital ni geometría del IPA: cuando su paquete se
   extraiga, entrará como capa visual igual que el 03 y el 04, sin
   tocar ni una regla. Del conjunto original quedan el 10 y el 11. */
 skirmish09:{id:'skirmish09',theme:'rotonda',name:'Skirmish_09 · Londres · La rotonda',
   walls:[[1,1],[10,10],[10,1],[1,10],[5,0],[6,11],[3,0],[8,11],[0,8],[11,3],[11,9],[0,2]],
   shelves:[[4,3],[7,8],[7,3],[4,8],[3,5],[8,6],[8,5],[3,6]],
   crates:[[4,5],[7,6],[7,5],[4,6],[5,3],[6,8],[2,2],[9,9],[3,9],[8,2]],
   barrels:[[4,4],[7,7],[7,4],[4,7]],
   medkits:[[0,10],[11,1]]},
 /* Skirmish_10, el siguiente mapa del conjunto tras el 09 y uno de
   los dos que quedaban: entra construido en código, como el 01, el
   02 y del 05 al 09, porque su paquete Theme_01_Skirmish_10
   tampoco está entre los archivos del IPA extraídos hasta ahora.
   Su disposición es nueva y propia, la de un cruce de avenidas
   sobre el centro: pilares en las esquinas y en los bordes norte
   y sur, puestos cerrando las filas 4 y 7 (las de las zonas de
   Dominación) y las esquinas en diagonal del centro, cajas
   pegadas a los cuatro lados de la baliza, sobre y bajo la zona
   central y en los flancos, barriles en dos diagonales de la
   baliza y en los carriles de las avenidas, y botiquines en
   esquinas opuestas. Verificado con el mismo banco de pruebas de
   los demás tableros: simetría de 180° en las cinco familias de
   piezas, sin solapes entre ellas, despliegues, baliza, zonas de
   Dominación, salida del dron y extracción libres, baliza a 6
   pasos de ambos despliegues, ruta del dron de 11 pasos y las
   114 casillas libres conectadas entre sí. Su suelo es el del
   cruce (asfalto rojizo dibujado en código en la vista clásica y
   en la 3D), sin plano cenital ni geometría del IPA: cuando su
   paquete se extraiga, entrará como capa visual igual que el 03
   y el 04, sin tocar ni una regla. */
 skirmish10:{id:'skirmish10',theme:'cruce',name:'Skirmish_10 · Londres · El cruce',
   walls:[[2,1],[9,10],[9,1],[2,10],[5,1],[6,10],[4,0],[7,11],[0,8],[11,3],[1,1],[10,10]],
   shelves:[[2,4],[9,7],[9,4],[2,7],[3,3],[8,8],[8,3],[3,8]],
   crates:[[4,5],[7,6],[7,5],[4,6],[5,3],[6,8],[6,3],[5,8],[1,9],[10,2]],
   barrels:[[4,4],[7,7],[3,5],[8,6]],
   medkits:[[1,10],[10,1]]},
 /* Skirmish_11, el último mapa del conjunto: entra por el mismo
   camino que el 10, construido en código, porque su paquete
   Theme_01_Skirmish_11 tampoco está entre los archivos del IPA
   extraídos hasta ahora. Su disposición es nueva y propia, la de
   un astillero con su dique seco en el centro: pilares en las
   esquinas, en los bordes norte y sur y en los extremos del
   dique, dos bandas de contenedores sobre las filas 3 y 8 que
   dejan el dique central abierto de lado a lado, cajas pegadas a
   los cuatro lados de la baliza, en las puertas del dique y en
   los extremos norte y sur, barriles en dos diagonales de la
   baliza y en los carriles del dique, y botiquines en esquinas
   opuestas. Verificado con el mismo banco de pruebas: simetría
   de 180° en las cinco familias de piezas, sin solapes entre
   ellas, despliegues, baliza, zonas de Dominación, salida del
   dron y extracción libres, baliza a 6 pasos de ambos
   despliegues, ruta del dron de 11 pasos y las 114 casillas
   libres conectadas entre sí. Su suelo es el del astillero
   (acero azulado dibujado en código en la vista clásica y en la
   3D), sin plano cenital ni geometría del IPA: cuando su paquete
   se extraiga, entrará como capa visual igual que el 03 y el 04,
   sin tocar ni una regla. Con este tablero el conjunto Skirmish
   del original queda completo en el remake: sus ocho números
   (el 03, el 04, el 05 y el 06, y el 08, el 09, el 10 y el 11) están dentro. */
 skirmish11:{id:'skirmish11',theme:'astillero',name:'Skirmish_11 · Londres · El astillero',
   walls:[[3,1],[8,10],[8,1],[3,10],[1,1],[10,10],[0,1],[11,10],[5,0],[6,11],[2,8],[9,3]],
   shelves:[[4,3],[7,8],[5,3],[6,8],[6,3],[5,8],[7,3],[4,8]],
   crates:[[4,5],[7,6],[7,5],[4,6],[5,9],[6,2],[2,7],[9,4],[3,9],[8,2]],
   barrels:[[4,4],[7,7],[6,4],[5,7]],
   medkits:[[0,10],[11,1]]},
 campana01:{id:'campana01',theme:'plaza',name:'Campana 1 - El primer puesto',
    walls:[[3,2],[8,2],[3,9],[8,9]],
    shelves:[[5,1],[6,1],[5,10],[6,10]],
    crates:[[4,4],[7,4],[4,7],[7,7]],
    barrels:[[3,5],[8,5],[3,6],[8,6]],
    medkits:[[1,2],[10,9]]},
 campana02:{id:'campana02',theme:'market',name:'Campana 2 - El pasillo del mercado',
    walls:[[5,1],[5,2],[5,3],[6,8],[6,9],[6,10]],
    shelves:[[3,3],[3,4],[8,7],[8,8]],
    crates:[[2,3],[8,3],[3,8],[9,8]],
    barrels:[[6,4],[5,7]],
    medkits:[[9,3],[2,8]]},
 campana03:{id:'campana03',theme:'dock',name:'Campana 3 - Los muelles',
    walls:[],
    shelves:[[7,3],[4,8]],
    crates:[[2,2],[3,2],[2,3],[9,8],[8,9],[9,9]],
    barrels:[[5,2],[6,9]],
    medkits:[[10,2],[1,9]]},
 campana04:{id:'campana04',theme:'warehouse',name:'Campana 4 - El anden largo',
    walls:[],
    shelves:[[2,4],[3,4],[4,4],[7,7],[8,7],[9,7]],
    crates:[[9,4],[2,7]],
    barrels:[[8,4],[9,5],[2,6],[3,7]],
    medkits:[[5,1],[6,10]]},
 campana05:{id:'campana05',theme:'yard',name:'Campana 5 - La rotonda',
    walls:[[4,4],[7,4],[4,7],[7,7]],
    shelves:[[2,4],[9,4],[2,7],[9,7]],
    crates:[[5,3],[6,3],[5,8],[6,8]],
    barrels:[[5,4],[6,4],[5,7],[6,7]],
    medkits:[[1,2],[10,9]]},
 campana06:{id:'campana06',theme:'dock',name:'Campana 6 - El cruce de ambulancias',
    walls:[[5,4],[6,4],[5,7],[6,7]],
    shelves:[[5,2],[6,2],[5,9],[6,9]],
    crates:[[2,5],[9,5],[2,6],[9,6]],
    barrels:[[2,4],[9,4],[2,7],[9,7]],
    medkits:[[4,2],[7,9]]}
};
