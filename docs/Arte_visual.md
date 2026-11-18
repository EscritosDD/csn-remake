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
