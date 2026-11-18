> **Nota de alcance:** este documento es histórico. Cita arte y material del original que vive fuera del repositorio (carpeta `_original/`), y capturas que no se guardan aquí por tamaño. No son enlaces rotos: son referencias al material de trabajo local.

# Prompts para Gemini Argon — arte SVG de CSN

**Vigente: la v4, en `Estetica_original.md` §7 (16/11, ~06:11).** Es la versión medida del original: proporciones exactas de la malla (cabeza 1/5, arma 76 % de la altura), paleta y moldes. La v3 de abajo queda como historial; no pegarla.

Dani los pega en la app web de Gemini (modelo Argon). **Corrección del 16/11, 05:51: Argon en la web SÍ admite imágenes** (Dani lo comprobó: adjuntó las capturas del original al prompt). El texto del prompt describe el estilo en palabras y las imágenes adjuntas lo muestran; las dos cosas juntas son lo que mejor funciona. Cuanto más contexto lleve el prompt, mejor sale: Argon es un modelo de razonamiento con mucho contexto y rinde más con instrucciones completas y claras.

## Primer prompt: los 7 soldados, versión 3 (pegar ahora)

La v1 del SVG salió usable como base pero no convence: soldados dibujados de frente y planos como muñecos de papel, manos en forma de círculo sin dedos, armas flotando sin que nadie las sujete, los 7 con la misma postura recta y estática y caras con ojos de puntos enormes. La v2 lo corrigió en cámara y volumen, pero al ver las dos imágenes nuevas del original (el equipo en fila y la vista cenital en la calle) quedó claro que faltaba lo principal: en el original cada personaje es una personalidad distinta, con su cuerpo, su cara expresiva, su ropa de colores y un arma enorme. Esta v3 describe eso en texto.

```
Eres un artista técnico de videojuegos y vas a dibujar los 7 sprites de soldado de CSN (Chess Soldier Nation), un remake hecho por fans del juego de táctica por turnos RAD Soldiers (Splash Damage, 2012, ya retirado). El juego es una página web 2D con canvas: dos escuadras se mueven por turnos en una cuadrícula de 12x12 casillas, como el ajedrez, y ganan eliminando al rival o aguantando 5 turnos en la zona de la baliza. Los sprites son código SVG que el juego dibuja en el canvas y tiñe con los colores de cada nación.

Te adjunto las capturas del juego original como referencia visual: míralas antes de dibujar nada y usa este texto para los detalles que las imágenes no dejan claros.

EL ESTILO QUE HAY QUE CONSEGUIR (RAD Soldiers): render 3D estilizado de videojuego, no dibujo plano ni pegatina. Personajes cabezones y corpulentos como muñecos de juguete, con volumen real: la luz crea brillos en la parte superior del casco y los hombros y sombras oscuras donde los brazos se unen al torso y bajo la barbilla. Texturas con pequeños desgastes y costuras. Colores saturados y militares en la base (verde oliva, caqui, gris oscuro, cuero marrón), con acentos de color vivos por personaje (azul, rojo, naranja) en pañuelos, chaquetas y detalles. La cámara está arriba e inclinada, casi cenital: se ve SIEMPRE la parte superior del casco y de la mochila, los hombros vistos desde arriba, las piernas escorzadas (más cortas de lo normal) y los pies apuntando hacia la parte inferior del marco. El personaje ocupa su casilla de forma compacta. Los soldados no miran de frente a la cámara: miran hacia su objetivo, con el arma apuntando en diagonal.

LO MÁS IMPORTANTE, CADA PERSONAJE ES UNA PERSONALIDAD DISTINTA: en el original ningún soldado se parece a otro. Cada uno tiene su propio tipo de cuerpo (gordo, alto y flaco, bajo y ágil, rechoncho, atlético, erguido), su propia cara expresiva y visible (sonrisa grande, bigote, gafas de sol, pañuelo en la cabeza, pelo distinto, tatuajes), su propia ropa (chaqueta abierta, camisa a rayas, chaleco, capucha) y su arma enorme, que es parte principal de su silueta. No dibujes 7 veces el mismo muñeco con distinto sombrero: si dos soldados se confunden por la silueta, están mal.

ERRORES DE LA VERSIÓN ANTERIOR, QUE NO DEBEN REPETIRSE: soldados dibujados de frente, planos como muñecos de papel; manos en forma de círculo sin dedos; armas flotando pegadas al cuerpo sin que nadie las sujete; los 7 con la misma postura recta y estática, el mismo cuerpo y la misma ropa; caras con ojos de puntos enormes y sin expresión; detalles escasos.

EXIGENCIAS:
- Cámara casi cenital en tres cuartos, obligatoria en los 7. Si un soldado parece visto de frente, está mal.
- Volumen real: cada pieza lleva al menos un degradado (luz arriba a la izquierda, sombra abajo a la derecha) y una zona de sombra de contacto donde se une con otra pieza. Prohibidos los rellenos planos sin degradado.
- Anatomía: brazos doblados sujetando el arma con las manos envueltas alrededor de la empuñadura (dedos sugeridos con 2-3 líneas), piernas en postura de combate (un pie adelantado), botas grandes apoyadas sobre la elipse de sombra del suelo.
- Caras expresivas y distintas: ojos visibles con cejas, boca con expresión (sonrisa, gesto serio, bigote), pelo o pañuelo propio de cada uno. La cara es parte de la personalidad del personaje, no un detalle menor.
- Armas enormes: cada arma mide al menos la mitad de la altura del personaje y forma parte principal de su silueta. Un arma pequeña y escondida está mal.
- Detalle: cada soldado lleva al menos 6 piezas de equipo visibles y detalladas (bolsillos con solapa, correas con hebilla, radio, cantimplora, granada, rodilleras, tatuajes). Elige las que correspondan a su rol.
- Coherencia: los 7 con la misma escala, la misma dirección de luz y el mismo grosor de contorno. A 60 píxeles, cada soldado debe reconocerse por su silueta, su cuerpo y su arma.

ESPECIFICACIONES TÉCNICAS:
- Un único archivo SVG, fondo transparente, sin imágenes externas ni texto.
- Cada soldado es un <symbol> independiente con su id (francotirador, artillero, espia, medico, ingeniero, comando, capitan), dentro de un viewBox 0 0 200 200, cuerpo entero centrado.
- Una elipse de sombra suave bajo los pies de cada uno. Sin anillo de equipo: el juego lo dibuja aparte.
- Para teñirlos con los colores de cada nación, usa clases en las partes principales: class="uniforme", class="casco", class="piel", class="botas". Sin style inline en esas partes.
- Skin Estándar: base verde oliva (#6B7248 aprox), casco oliva oscuro, chaleco táctico gris verdoso, botas marrón oscuro, con un color de acento propio por personaje (ver abajo).

LOS 7 SOLDADOS (cada uno con su cuerpo, su cara, su ropa y su arma):
1. francotirador: alto y delgado, agachado en postura de tiro, cara concentrada con pañuelo en la cabeza, capa de francotirador caqui sobre un hombro, fusil largo con mira telescópica enorme apuntando en diagonal.
2. artillero: el más corpulento y gordo de todos, barriga visible, sonrisa grande, ametralladora pesada enorme cruzada sobre el pecho, cintas de munición cruzadas, hombreras grandes, postura firme con las piernas separadas.
3. espia: bajo y ágil, capucha oscura que tapa media cara con solo los ojos visibles, pañuelo rojo al cuello, subfusil compacto pegado al cuerpo, postura sigilosa inclinada hacia adelante, un pie adelantado.
4. medico: complexión normal, cara amable con sonrisa, pelo rubio corto, cruz roja grande en el casco y en un brazalete rojo, botiquín blanco con cruz roja en la espalda, pistola pequeña en la mano.
5. ingeniero: rechoncho y bajo, bigote, gafas de sol subidas en el casco, llave inglesa enorme en una mano, mochila con herramientas y una torreta pequeña plegada, acentos de cuero marrón.
6. comando: atlético, cara seria con cicatriz, chaqueta azul abierta sobre el chaleco, fusil de asalto enorme en las manos apuntando en diagonal, granada colgando del cinturón.
7. capitan: alto y erguido, bigote y gafas de sol, gorra de oficial azul oscuro con visera y estrella dorada, galones dorados en los hombros, chaqueta azul, pistola en la funda, una mano alzada dando la orden.

ANTES DE DEVOLVER EL CÓDIGO, VERIFICA ESTA LISTA Y CORRIGE LO QUE FALLE: 1) ¿Se ve la parte superior del casco en los 7? 2) ¿Cada arma está sujeta por manos con dedos, no flotando, y es grande? 3) ¿Todas las piezas tienen degradado? 4) ¿Cada soldado tiene un cuerpo, una cara y una ropa distintos de los otros 6? 5) ¿Cada soldado se reconoce por su silueta a 60 píxeles? 6) ¿La escala y la luz son iguales en los 7?

SALIDA: devuelve SOLO el código SVG completo y válido, sin explicaciones, sin comentarios y sin texto fuera del código.
```

## Segundo prompt: objetos del mapa y logo (versión medida, lista para pegar)

Actualizado el 16/11 (~06:16) con las medidas auditadas del original. Se adjuntan las capturas image-2, image-3, image-4 e image-8 como referencia de estilo. Los SVG resultantes se usan como texturas y sprites en la versión 3D web (Three.js) del juego.

```
Eres el dibujante de un juego de táctica por turnos en cuadrícula, vista 3D cenital inclinada a 50 grados. Necesito los objetos del mapa y el logo de CSN (Chess Soldier Nation) como símbolos SVG en una sola hoja, cada uno en su viewBox 0 0 200 200, con fondo transparente. Los objetos deben ser ORIGINALES, creados por ti siguiendo las medidas y el estilo de las imágenes de referencia que te adjunto, sin copiar ningún objeto concreto de ellas.

MEDIDAS Y ESTILO (medidos del original, respétalos):
- Textura pintada a mano: colores planos saturados con sombreado suave, contorno oscuro grueso, nada fotorrealista, nada de degradados de render 3D. Las texturas del original son pequeñas (128-256 px) y se nota el pincel.
- Luz cálida desde arriba a la izquierda; cada objeto lleva su sombra de contacto en el suelo.
- Cámara en tres cuartos desde arriba: se ve la parte superior de cada objeto, nunca de frente plano.
- Azul de bando #387EC9 y rojo #C95338 para los detalles de equipo; base militar oliva y gris.
- La caja de botín mide 0,675 unidades en un mundo donde la casilla mide 1x1: es grande, casi dos tercios de casilla. El anillo de la baliza mide 0,71 de diámetro. Los escudos de cobertura miden 0,48 de ancho por 0,60 de alto.

LOS OBJETOS (cada uno un <symbol> con su id):
1. suelo_almacen: baldosa de hormigón de almacén con grietas y una línea amarilla en un borde.
2. suelo_calle: adoquín de calle pintado, con juntas marcadas y desgaste.
3. suelo_arena: arena pintada con pequeñas piedras y huellas.
4. caja_botin: caja de suministro de 0,675, madera con cantoneras metálicas y la palabra SUPPLY.
5. muro_bajo: muro bajo de bloques de hormigón con franjas de peligro amarillas y negras.
6. saco_arena: pila de sacos de arena apilados, tela caqui con costuras.
7. barril: barril explosivo rojo con el símbolo de peligro, abollado.
8. botiquin: botiquín blanco con cruz roja.
9. torreta: ametralladora pesada sobre trípode con cinta de munición.
10. baliza: anillo luminoso segmentado en el suelo (0,71 de diámetro) con una bandera pequeña y una estrella en el centro.
11. puerta: portón metálico con bisagras y un tirador.
12. mina: mina antipersonal redonda, semienterrada, con púas.
13. logo_csn: logotipo del juego, las letras CSN grandes en verde oliva metálico con una estrella dorada encima, una cinta con el texto «Chess Soldier Nation» y un peón de ajedrez con casco a cada lado.

ERRORES PROHIBIDOS:
- Nada de objetos de frente plano como pegatinas sin volumen ni sombra.
- Nada de texturas fotorrealistas ni de degradados de render 3D.
- Nada de objetos diminutos perdidos en el viewBox: cada uno ocupa casi todo su marco.
- Nada de colores apagados: saturados, como en las referencias.

LISTA DE VERIFICACIÓN ANTES DE ENTREGAR: cada objeto ocupa casi todo su viewBox 0 0 200 200; todos tienen sombra de contacto; la caja mide a escala de casilla; el anillo de la baliza es segmentado; el estilo es pintado con contorno grueso en los 13; los ids son los de la lista.

SALIDA: devuelve SOLO el código SVG completo y válido, sin explicaciones, sin comentarios y sin texto fuera del código.
```

## Tercer prompt: retratos de los 10 personajes (versión medida, lista para pegar)

Actualizado el 16/11 (~06:16). Se adjunta la captura image-7 («CREA TU SUPER EQUIPO», los 10 personajes en fila) como referencia de estilo. Los rasgos de cada uno son sugeridos por su nombre y por la fila del cartel; Dani corrige lo que no cuadre. Solo el retrato de Hipster Dave se pudo leer en los archivos del original; los otros 9 se dibujan de cero siguiendo los moldes.

```
Eres el dibujante de un juego de táctica por turnos en cuadrícula. Necesito los retratos de los 10 personajes del juego como símbolos SVG en una sola hoja, cada uno en su viewBox 0 0 200 200, con fondo transparente. Son retratos de busto (cabeza y hombros) para el HUD. Deben ser ORIGINALES, creados por ti siguiendo el estilo de la imagen de referencia que te adjunto, sin copiar ningún retrato concreto de ella.

ESTILO (medido del original, respétalo):
- Dibujo 2D pintado a mano: colores planos saturados con sombreado suave, contorno oscuro grueso, nada fotorrealista.
- Cabeza grande, 1/5 de la altura del personaje entero; en el retrato la cabeza ocupa casi todo el marco.
- Caras EXPRESIVAS Y VISIBLES: ojos grandes con cejas marcadas, nariz grande, boca con expresión (sonrisa, gesto serio, bigote), pelo o sombrero propio. Nada de caras vacías ni de ojos de puntos.
- Ropa civil de colores sobre base militar (oliva, gris, negro de fondo; naranja, azul, rojo, verde y amarillo como acentos por personaje).
- Luz cálida desde arriba a la izquierda; sombra suave bajo la barbilla y en un lado de la cara.

LOS 10 RETRATOS (cada uno un <symbol> con su id):
1. hipster_dave: gafas de pasta, barba cuidada, gorro de lana, sonrisa tranquila, chaqueta abierta.
2. sneaky_pete: capucha oscura, media cara en sombra con solo los ojos visibles, sonrisa pícara, pañuelo al cuello.
3. sister_florence: velo blanco de enfermera, cara amable y serena, cruz roja pequeña en el velo, bata blanca.
4. archie_fletcher: gorra de béisbol hacia atrás, pecas, sonrisa grande, camiseta a rayas.
5. ivan_tkilya: gorro de piel ruso, barba espesa, cara seria y ancha, abrigo militar grueso.
6. mme_la_hacque: boina francesa, pelo oscuro recogido, mirada elegante, pañuelo al cuello, chaqueta azul.
7. soap: cabeza rapada, tatuaje en la sien, gesto duro, chaleco táctico negro.
8. riot_medic: casco antidisturbios con visera subida, mascarilla al cuello, cruz roja en el casco, mirada atenta.
9. big_time_taschmann: el más grande y ancho, gafas de sol, cadena dorada, sonrisa ruidosa, chaqueta llamativa.
10. megan_mcnick: pelo rojo recogido en coleta, pecas, sonrisa decidida, chaleco verde.

ERRORES PROHIBIDOS:
- Nada de diez caras iguales cambiando solo el color: cada retrato se reconoce por su cara y su ropa.
- Nada de caras de frente plano sin volumen ni sombra.
- Nada de ojos de puntos ni bocas ausentes.
- Nada de estilo 3D realista ni de foto.

LISTA DE VERIFICACIÓN ANTES DE ENTREGAR: 10 retratos distintos; cada cara tiene ojos, cejas, nariz y boca visibles; cada uno lleva su rasgo propio de la lista; el estilo es pintado con contorno grueso en los 10; los ids son los de la lista.

SALIDA: devuelve SOLO el código SVG completo y válido, sin explicaciones, sin comentarios y sin texto fuera del código.
```

## Qué hacer con cada respuesta

Dani copia el código que devuelva Argon y lo pega en el chat de CSN (o lo guarda como archivo y avisa). El SVG de los soldados es la vía que cubre los 3 sprites que el generador de imágenes rechazó (francotirador, espía y comando); el SVG de los objetos es la vía alternativa a las imágenes de `files/arte/v2/`. Cuando el código llegue, se integra todo en el prototipo.

## Soldados v4 — RECIBIDA el 16/11/2026
Dani trajo el SVG v4 de Argon: `files/arte/argon_sprites_v4.svg` (55.709 bytes, XML válido, 7 símbolos: francotirador, artillero, espia, medico, ingeniero, comando, capitan; hoja 1400×240 con los 7 en fila). Cumple las medidas del prompt (cabeza 40 px, armas 146–160 px, manos agarrando el arma, clases `uniforme`/`casco`/`piel`/`botas` y degradados para el tinte por nación).

**Veredicto de Dani (16/11): Argon no puede con el diseño 3D de este juego.** Tiene razón: lo que devuelve es ilustración 2D plana, muy detallada y útil, pero sin volumen 3D. El 3D queda en la extracción (mallas, texturas, animaciones) y en los modelos construidos en código desde los moldes medidos. El papel de Argon a partir de aquí es **arte 2D de interfaz**: la hoja v4 va al panel de soldados y a la selección de rol (sustituye a la v1), y los prompts 2 (objetos + logo) y 3 (retratos) siguen valiendo como arte 2D.
