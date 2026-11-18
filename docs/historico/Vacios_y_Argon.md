> **Nota de alcance:** este documento es histórico. Cita arte y material del original que vive fuera del repositorio (carpeta `_original/`), y capturas que no se guardan aquí por tamaño. No son enlaces rotos: son referencias al material de trabajo local.

# Vacíos y Argon — qué falta del original y qué le pedimos a Argon

Documento de trabajo vivo. Dani lo pidió el 16/11/2026 (~06:13): ir apuntando los vacíos y las cosas en las que Argon puede ayudar, trabajar de la mano de él y ser exigente.

## Cómo trabajamos con Argon

Argon (Gemini 4 Argon, en la web) solo devuelve texto y código: SVG, código Three.js, listas. No genera imágenes. Dani le pega mis prompts con las capturas del original adjuntas como referencia, trae el resultado y yo lo integro en el juego. Cada prompt lleva medidas exactas, lista de errores prohibidos y lista de verificación antes de entregar. Si el resultado no cumple una medida, se le devuelve con la corrección exacta; no se acepta un «casi».

Regla: Argon no inventa datos del original. Rellena huecos de ARTE siguiendo las medidas auditadas en `Referencia_original.md` y `Estetica_original.md`.

## Vacíos del original (lo que no se pudo sacar de sus archivos)

| Vacío | Por qué falta | Qué hacemos | ¿Argon ayuda? |
|---|---|---|---|
| Prefabs de los mapas de batalla (sacos, muros, barriles, coches) | No están en el archivo; se descargaban del servidor (confirmado en el inventario) | Medir en las capturas y recrear | SÍ: los dibuja o escribe su geometría con las medidas |
| Textura del cuerpo del soldado | No existe en el archivo; el material apunta a otro paquete descargable | Pintarla nueva | SÍ: Argon la pinta como SVG para usar de textura |
| Malla con skinning del soldado | La extraída es estática (la del cuartel, sin pesos ni bind pose) | Animación por código o skinning por proximidad al rig | NO: trabajo mío |
| Retratos de 8 de los 10 personajes | Solo Hipster Dave y Carlito Grosso son legibles | Dibujarlos de cero | SÍ: los 10 retratos en SVG con los moldes |
| Propiedades internas de los shaders Character/Weapon | UnityPy no las extrae | Aproximar en Three.js con materiales estándar y luz cálida | NO: trabajo mío |
| Números por arma y por habilidad | Viven en paquetes UnityWeb sin desempaquetar | Usar nuestros números del arsenal, verificados con fuentes reales | NO: son datos, no arte |
| Tamaños reales de los mapas | No hay niveles de batalla en el archivo | Nuestros mapas 12×12 y 14×12 | NO: decisión de diseño |
| Lógica de decisión de la IA | Código ofuscado | IA propia, sencilla, ya implementada | NO |
| Malla con skinning del soldado | La extraída es estática (la del cuartel, sin pesos ni bind pose) | Animación por código o skinning por proximidad al rig | NO: trabajo mío |
| Si la baliza daba bonificaciones | No queda claro en el código | Decisión de diseño nuestra | NO |

Corrección de la extracción (16/11 ~06:19): no hay un solo esqueleto, hay CUATRO Bip001 de 22 huesos. Soldado e Ingeniero son bajos y anchos; Agente y Médico son altos y flacos, con piernas de 0,54. El rig se elige por rol.

## Cola de tareas para Argon

1. **Soldados v4 (los 7).** Prompt listo en `Estetica_original.md` §7, con las medidas exactas (cabeza 40 px de 200, arma 130–160 px agarrada con las manos, tres cuartos). **Pendiente de Dani: pegarlo en Argon con las 7 capturas y traer el SVG.**
2. **Objetos del mapa + logo.** Prompt listo en `Prompt_Argon_sprites.md` (segundo prompt, versión medida del 16/11 ~06:16, con caja 0,675, anillo 0,71 y texturas pintadas). Pendiente de Dani, después de los soldados.
3. **Retratos de los 10 personajes.** Prompt listo en `Prompt_Argon_sprites.md` (tercer prompt, del 16/11 ~06:16; rasgos sugeridos por el nombre, Dani corrige). Pendiente de Dani.
4. **Texturas para el 3D (suelo, sacos, muros).** Por definir según el inventario de extracción: lo que no se pueda extraer del original, lo pinta Argon como SVG para usarlo de textura.
5. **Modelos procedurales en código Three.js (si la extracción falla en algo).** Argon escribe la geometría siguiendo las medidas auditadas (soldado 1,02 de alto, cabeza 1/5, arma 76 % de la altura).
6. **Textura del cuerpo del soldado.** No existe en el archivo; Argon la pinta nueva como SVG para usar de textura. Prompt por redactar cuando toque.

## Cómo ser exigente con Argon (la regla)

- Medidas exactas en el prompt, nunca adjetivos vagos («cabezón» no; «cabeza de 40 px en un soldado de 200 px» sí).
- Lista de errores prohibidos con lo que ya hizo mal (muñecos de frente plano, manos en círculos, armas flotando, caras de puntos).
- Lista de verificación antes de entregar, y que la cumpla punto por punto.
- Cada entrega se compara con las medidas; lo que no las cumpla vuelve con la corrección exacta.

## Veredicto sobre Argon (16/11/2026)
Dani trajo la v4 y concluyó que Argon no puede con el diseño 3D del juego. Correcto: Argon devuelve ilustración 2D plana (muy buena), no geometría 3D. Su papel queda en **arte 2D de interfaz** (hoja de soldados v4, objetos del mapa + logo, retratos). El 3D sigue siendo extracción + modelos en código desde los moldes medidos.

**Cola actualizada:**
1. ~~Soldados v4~~ — RECIBIDA (`files/arte/argon_sprites_v4.svg`, 7 símbolos, validada). Integrándose como arte 2D del panel de soldados y la selección de rol, sustituyendo a la v1.
2. Objetos del mapa + logo (prompt listo) — arte 2D.
3. Retratos de los 10 personajes (prompt listo) — arte 2D.
4. Textura para el 3D — en duda: la malla del soldado es estática y el tablero 3D usa modelos en código; solo hace falta si se decide usar la malla extraída.
5. Modelos procedurales en código — hecho en el tablero 3D (v7).
