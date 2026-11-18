> **Nota de alcance:** este documento es histórico. Cita arte y material del original que vive fuera del repositorio (carpeta `_original/`), y capturas que no se guardan aquí por tamaño. No son enlaces rotos: son referencias al material de trabajo local.

# Dirección de arte — CSN

Guía visual para que el juego se parezca a RAD Soldiers. El prototipo actual usa soldados dibujados por código; este documento define el arte que los sustituye.

## Sprites definitivos: el SVG de Argon

Los sprites reales del juego son los de `files/arte/argon_sprites.svg`, el código SVG que Dani trajo de Gemini Argon el 16/11/2026. Un solo archivo con los 7 soldados como `<symbol>` (francotirador, artillero, espia, medico, ingeniero, comando, capitan), cada uno en viewBox 0 0 200 200, con clases `uniforme`, `casco`, `piel` y `botas` para teñirlos con los colores de cada nación. El juego debe dibujar estos símbolos en el canvas como soldados, en lugar de los soldados dibujados por código. Los PNG de `files/arte/` y `files/arte/v2/` quedan como arte de apoyo, no como sprites del juego.

## Estilo

El espíritu de RAD Soldiers, según sus capturas originales: 3D estilizado, no dibujo plano. Soldados cabezones con volumen real, sombras suaves, texturas pintadas y colores saturados, cámara cenital inclinada (tres cuartos). Mapas urbanos con detalle (calles, trenes, coches, cajas, barreras y farolas) con la cuadrícula marcada en el suelo. Bajo cada soldado, un anillo de color (azul aliado, rojo rival). Cada soldado debe leerse en una casilla pequeña: silueta clara, arma visible y rol reconocible a golpe de vista.

La primera versión del arte (`files/arte/`) salió en dibujo plano 2D y no se parece al original; la versión buena va en `files/arte/v2/`.

## Paleta

- **Skin Estándar:** verde oliva, chaleco táctico oscuro, casco oliva, sin emblema.
- **Skin de Nación:** colores de la bandera de la nación, con su escudo militar como distintivo.
- **Bandos:** el jugador en azul, el rival en rojo, para que el turno sea legible siempre.

## Sprites de soldado

Un archivo por rol, con la skin Estándar. Cuerpo entero, centrado, fondo blanco liso para recortarlo fácil, imagen cuadrada, arma en la mano.

| Archivo | Rol | Rasgos que lo distinguen |
|---|---|---|
| `francotirador_estandar.png` | Francotirador | Fusil largo con mira telescópica, capa de francotirador, postura agachada |
| `artillero_estandar.png` | Artillero | Ametralladora pesada o lanzacohetes, corpulento, chaleco con cintas de munición |
| `espia_estandar.png` | Espía | Delgado, capucha, subfusil compacto, postura sigilosa |
| `medico_estandar.png` | Médico | Cruz roja en el casco y el brazo, botiquín en la espalda |
| `ingeniero_estandar.png` | Ingeniero | Llave inglesa, mochila con herramientas, casco con gafas |
| `comando_estandar.png` | Comando | Fusil de asalto, chaleco táctico, aspecto de soldado estándar |
| `capitan_estandar.png` | Capitán | Gorra de oficial, galones, pistola en la funda, porte de mando |

Las variantes de nación de la v1 se hacen tiñendo estos sprites por código con los colores de la bandera; los sprites de nación dedicados llegan después.

## Mapa y objetos (Almacén industrial)

- `suelo_almacen.png`: baldosa de suelo de almacén, hormigón con marcas amarillas.
- `caja.png`: caja de madera, destructible.
- `muro_bajo.png`: muro bajo de hormigón, cobertura.
- `saco_arena.png`: sacos de arena, cobertura destructible.
- `barril.png`: barril explosivo rojo con el símbolo de peligro.
- `botiquin.png`: botiquín blanco con cruz roja.
- `torreta.png`: torreta M2 Browning sobre trípode.
- `baliza.png`: marcador de la zona de baliza, círculo luminoso en el suelo.

## Interfaz

- `logo_csn.png`: logotipo del juego, letras CSN grandes y el texto Chess Soldier Nation debajo, estilo militar de dibujo animado.

## Reglas

- Arte original dibujado para este juego. Nada de copiar archivos de RAD Soldiers, Respawnables ni ningún otro juego; el estilo es libre, los archivos no.
- Si un sprite sale mal (arma irreconocible, proporciones rotas, fondo con objetos), se regenera, no se apaña.
- Todo el arte vive en `files/arte/` dentro de la carpeta del proyecto.


## Imágenes de aistudio (`public/assets/aistudio/` (retirado del repo))

Tres borradores de interfaz generados con IA (`image_13b112b1.png`,
860x485; `image_26054cf1.png` y `image_5061c313.png`, ~500x333; paleta
blanca/gris, sin relacion con las pantallas reales del juego). Decision:
se guardan como **referencia de direccion de arte** para F8 (personajes y
skins) y F9 (UI minimalista), **no se cargan en la portada** para no
despistar al jugador (la misma razon por la que se retiro la imagen de
Muse). Si alguna representa una pantalla concreta que se quiera usar, se
integra entonces.


## Decisiones de arte de interfaz (F7)

- **Botones y panel PNG** (`ui_boton_primario/secundario/peligro.png`,
  `ui_panel.png`): se conservan como referencia, pero la interfaz sigue con
  **CSS** (consistente, responsive y con estados normal/hover/pulsado). Los
  PNG no se aplican como 9-slice para no romper la legibilidad en pantallas
  pequenas. Decision: CSS; los PNG quedan documentados como alternativa.
- **Iconos de estado y objeto**: sistema tipografico coherente (aturdido 💫,
  invisible 👻, vigilancia 👁, suprimido ⚡, abejas 🐝, escudo 🛡, herido 🩹;
  granada 💣, humo 💨, aturdidora ✸, claymore 💥, gas ☣, molotov 🔥,
  cobertura 🧱, tranquilizante 💉, canon de agua 💦, kit 🔧, teletransporte
  🌀, barrido 📡, artilleria 💥). No requiere assets y escala con el texto.
- **Pantallas**: pantalla de carga con logo y barra (se cierra cuando el
  soldado real esta listo o a los 9 s) y fin de partida con pancarta de
  VICTORIA/DERROTA y el arte del modo.
