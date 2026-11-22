> **Nota:** las capturas que cita este documento no se guardan en el repositorio; se regeneran con `node _capture_all.mjs` (ver `docs/Capturas_3D.md`).

# Auditoría profunda v2 y plan exigente (ronda de corrección)

Auditoría hecha **mirando el juego de cerca** (capturas con cámara acercada a
una unidad, no solo el tablero entero) y con sondas instrumentadas
(`window.__csnCam`, escena THREE, esqueletos y materiales).

## Qué estaba mal (con evidencia)

### 1. Soldados: cuerpos invisibles y equipo flotando (CRÍTICO)
- Con la cámara a 3,4 unidades de una unidad se veían **solo las placas de
  equipo** (pecho, hombreras, antena) flotando sobre el anillo: la malla
  skinned **no se dibujaba**.
- Causa raíz: los **rigs por clase** extraídos del IPA conservan la
  convención de Unity (Y arriba) y sus huesos no reproducen el reposo que
  espera el **sistema de animación horneado** de CSN. Al aplicar los clips,
  el esqueleto se colapsaba y la malla se deformaba hasta desaparecer.
  Se probaron tres reconstrucciones (desde bind poses, solo huesos del skin,
  con y sin ancestros) y ninguna fue compatible con los clips: el cuerpo
  seguía roto.
- Segundo error, este sí decisivo: se aplicaba `ROLE_SCALES` (la escala de
  las mallas de clase, 0,31 para el Comando) a la **malla base**, dejando al
  soldado **diminuto** aunque el esqueleto estuviera bien.

**Solución aplicada** (`1fe168c`): volver a la **malla del IPA que ya
funcionaba** (Soldier_Light) para todas las clases y diferenciarlas con los
**uniformes del propio original** —`veteran`, `spetsnaz`, `deltaforce`,
`rambo`, `decon`, `deerhunter`, `base`—, escala única 0,95 y equipo
(pecho/franja/hombreras) reducido a proporción. Verificado con capturas de
cerca: el soldado se ve de pie, con casco, mochila, arma y uniforme.

### 2. Cámara: los mapas se veían pequeños (ALTO)
- La cámara arrancaba a **14,8** unidades de distancia y el zoom mínimo era
  9,5, así que el tablero ocupaba poco más de la mitad del encuadre.
- **Aplicado**: distancia por defecto **11,6**, zoom mínimo **7,5** y el
  botón de acercar permite llegar más cerca. El tablero ahora llena la vista.

### 3. Interfaz: disonante con el original (ALTO, pendiente)
- La portada usa arte de referencia (aistudio) que **no es del juego** y se
  nota: mezcla estilos y compite con el arte del RAD Soldiers.
- La **creación de partida** acumula selects y textos propios (dos escuadras
  enteras, skins, dificultad, mapas…) en una sola pantalla larga, sin la
  jerarquía del original.
- **Pendiente** (siguiente fase): portada y menú con la composición del
  original, flujo de partida en dos pasos (modo → escuadra) y HUD con la
  jerarquía del original.

### 4. Mapas (MEDIO)
- La geometría real y los props están bien; el problema de "se ven pequeños"
  era la cámara (punto 2). Queda revisar la escala de props sueltos y la
  densidad del anillo exterior.

## Plan exigente (fases siguientes)

| Fase | Objetivo | Criterio de aceptación |
|---|---|---|
| **A1** | Portada/menú con la composición del original y **fuera el arte de Muse/aistudio** | captura de portada; sin imágenes de referencia en la UI |
| **A2** | Creación de partida en dos pasos (modo → escuadra) con la estética del original | captura del flujo completo; sin scroll de más de 2 pantallas |
| **A3** | HUD con la jerarquía del original (retrato, vida, energía, acciones) | captura en partida; comparación lado a lado |
| **A4** | Soldados: revisar a distancia de juego que se leen (casco, uniforme, arma) | captura a 6 y a 3 unidades |
| **A5** | Reconstrucción de las mallas de clase con esqueletos compatibles (investigación) | captura de las 7 clases con el mismo pipeline de animación |
| **A6** | Repaso de props y escala por mapa | captura de los 13 tableros |

## Estado verificado de esta fase

- `VERIFICAR.ps1`: sintaxis 0, 19/19 tableros, reglas 6/6, datos 6/6, humo 3D.
- Capturas de cerca (la captura de cerca de una unidad) y de tablero (la captura del tablero completo).
- Commit `1fe168c` empujado a `main`.

## Auditoría de la fase de personajes (19/11/2026)

Esta ronda se ejecutó sobre los commits `c570135` (retirada de
`referencia_original/`) y `434211a` (personajes por rol con textura y lógica).
Se combinaron cuatro fuentes: lectura estática de `index.html`, carga del motor
en los stubs de `bench/`, inspección en navegador mediante CDP de los 12
personajes jugables, y contraste con `_original/decompiled/` y
`docs/Informe_CSN_vs_original.md`.

### Fallos reales encontrados y corregidos

| # | Fallo | Evidencia | Arreglo |
|---|---|---|---|
| 1 | Una unidad muerta durante su activación de IA seguía disparando y agotando energía. | Tras pisar una Claymore, `alive:false`, pero el bucle de tiro causaba daño. `tryShoot` no comprobaba `shooter.alive`. | Guarda en `tryShoot` y altas después de minas/aturdimiento en los puntos de la IA donde la unidad puede morir. |
| 2 | El daño de gas, fuego y abejas no resolvía victoria/derrota. | Con el último enemigo a 1 PV, `endTurn()` dejaba `over:false` y al enemigo muerto. | `checkWin()` inmediatamente después del bloque de daño por turno, antes de cambiar de bando. |
| 3 | `hasLOS` cortaba la visión con cajas de nivel 1/2. | `_original/decompiled/GameGridComponent.cs:77` y `GameTileComponent.cs:154-160` bloquean solo el nivel máximo; el propio comentario de `hasLOS` lo decía. | Solo `wall` y `shelf` cortan LOS; las cajas siguen dando cobertura y penalización de puntería. |
| 4 | Granadas, artillería, minas, torretas, gas, fuego y abejas no contabilizaban daño/bajas en `G.stats`. | `G._dmgTeam` solo se fijaba en `tryShoot`. | `damage()` acepta equipo de origen y todas las fuentes de daño lo pasan explícitamente. |
| 5 | Decisiones de IA usaban `Math.random()` pese a existir semilla por turno. | `setTurnSeed`/`rng()` se fijaban en `startGame` y `endTurn`, pero seis decisiones salían de `Math.random()`. | Esas decisiones usan `rng()`; se conservan umbrales y probabilidades. |
| 6 | La campaña anunciaba 5 misiones aunque los datos y tests tienen 6. | `CAMPAIGN_MISSIONS.length === 6`. | Los textos usan `CAMPAIGN_MISSIONS.length`. |
| 7 | Retratos de roster y ficha ignoraban al personaje elegido. | `rolePortraitURL(u.role)` sin segundo argumento en `updateUI`. | Se pasa la unidad completa; el caché usa clave por personaje. |
| 8 | Contadores del HUD y botones podían describir acciones que el personaje no tiene. | P. ej. Riot Agent mostraba M84 pero su lógica es Fantasma + Molotov; Sister Florence mostraba Reanimación sin tener el icono. | Los textos de recursos usan `unitHasAction`, `canHealSpecial` y `canReviveSpecial`; la IA usa los mismos predicados. |
| 9 | Cambiar personaje en el Cuartel no refrescaba el retrato ni la escuadra. | El handler solo guardaba `localStorage`. | Se actualizan la tarjeta, `updateUI()` y `buildSquads()`. |
| 10 | Atajos `1`-`5` apuntaban a `#unitCard`, pero los botones están en `#actionBar`. | Selector obsoleto tras el rediseño del HUD. | Selector corregido. |
| 11 | Cachés con fallback permanente o clave equivocada. | Miniaturas de armas cacheaban `null` mientras cargaban; fallo de red cacheaba `false`; fallback de retrato guardaba con clave de rol; materiales de resaltado ignoraban color/opacidad; textura superior fallida se reintentaba siempre. | Reintentos permitidos, clave por personaje/color/opacidad y marca de fallo en mapas. |
| 12 | Retratos/sprites generados antes de cargar cast y Meshy podían quedarse obsoletos. | `REAL.ready` se marcaba antes de que terminaran las texturas cast y los rigs Meshy. | Se limpian `PORTRAIT_CACHE` y `REAL_SPRITES.cache` al terminar la carga, y se redibuja la UI. |
| 13 | `__forceBaseModel` no se respetaba para las mallas Meshy en sprites/retratos. | La cámara del sprite está calibrada para la malla base. | La geometría Meshy se fuerza a base en el renderer de sprites; la textura cast del personaje se conserva. |
| 14 | Tooltip de la torreta Gatling mostraba `undefined`. | `CharAbility_16_Gatling_Turret_alpha` estaba implementada pero no en `ABILITY_IMPL`. | Añadida descripción "Torreta M2". |
| 15 | Personajes propios de `OWN_CAST` se etiquetaban como `original:` en `charKey`. | Falta de `key` en esas entradas. | `characterKey()` distingue `own:` de `original:`. |

### Verificación

- `node bench/check-syntax.js`: 2 bloques, 0 errores.
- `node bench/boards.js`: 19/19 tableros `ok`, 0 solapes.
- `node bench/rules.test.js`: 10/10 (4 regresiones nuevas: LOS de cajas,
  contabilidad de daño, victoria por daño por turno y tirador muerto).
- `node --test bench/data.test.js`: 6/6.
- CDP sobre los 12 personajes jugables: 12/12 nombres, texturas/rigs y sin
  excepciones; los botones y chips corresponden a la lógica de cada personaje.
- Smoke `?autostart=1`: 3 canvas, 8 unidades, modo `baliza`, 0 errores.

### Sin cambios deliberados

- No se han creado texturas, habilidades ni estadísticas nuevas.
- No se han modificado tableros, armas, daños, costes ni el catálogo de 18
  personajes propios pendientes.
- El cerebro de IA del IPA sigue ofuscado y no permite contrastar decisiones
  concretas más allá de la semilla; las cifras de armas servidas por
  UnityWeb/IPA tampoco se han desempaquetado en esta ronda.
