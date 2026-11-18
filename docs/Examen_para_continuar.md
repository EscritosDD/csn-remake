# Examen y guía para continuar CSN con otras IAs (Gemini Studio, Z.ai)

Este documento es el punto de partida para quien retome el proyecto. Está
escrito para que una IA (o una persona) pueda **entender el estado real,
verificar que todo está sano y seguir sin romper nada**.

## 1. Qué es CSN y en qué estado está

Remake web de **RAD Soldiers** (Splash Damage / WarChest, 2012): táctico por
turnos en cuadrícula 12×12, en **3D como vista principal**. Un solo archivo
(`index.html`) con todo el juego y la carpeta `assets/`.

Estado actual (verificado, no prometido):

| Área | Estado |
|---|---|
| Motor de reglas | 6/6 tests propios (`bench/rules.test.js`) |
| Tableros | 19, todos simétricos 180° y sin solapes (`bench/boards.js`) |
| Datos (personajes, naciones, skins, misiones, voces) | 6/6 (`bench/data.test.js`) |
| 3D | `window.__csn3d` con `units:8` y `geo:true` en todos los mapas |
| Soldados | **Un solo cuerpo del IPA (Soldier_Light) con 7 uniformes del original** y proporciones por clase (ROLE_LOOK 0,84-1,30); las 7 mallas de clase están extraídas pero **no se pueden usar todavía** (ver §5) |
| Interfaz | Portada centrada con logo del original, menú en columna, campaña por capítulos con arte y progreso, Cuartel visual, Armería en pestañas, setup en rejilla y HUD con **barra inferior de acciones** |
| Audio | 195 clips del IPA (armas, voces por personaje, ambiente, música) |

## 2. Cómo se ejecuta y se verifica (obligatorio antes y después de tocar)

```powershell
# 1) servidor estatico (si no esta ya)
python -m http.server 8000 --bind 127.0.0.1

# 2) verificacion completa: sintaxis, tableros, reglas, datos y humo 3D
powershell -ExecutionPolicy Bypass -File bench\VERIFICAR.ps1
```

Debe terminar en `TODO OK`. Si algo falla, **no sigas**: la salida dice qué
bloque (`[1/5]`…`[5/5]`).

Para medir equilibrio: `node bench/harness.js <modo> <mapa> <partidas> 4`
(Eliminación, Baliza, Dominación, Escolta). Nunca dar un modo por arreglado
con n<30.

Para capturar: `node _capture_all.mjs <mapa|campana:N> <prefijo> [ms]`.
**Si cambias una imagen o un asset, borra el perfil de captura**
(`_chrome_*`) antes: el navegador cachea y la captura miente (nos pasó con
el arte de la portada).
Captura 3D y solo baja a 2D si la 3D no arranca. Con la ventana tapada Chrome
estrangula el render: usar `Page.bringToFront` (ya está en el script).

## 3. Dónde está cada cosa

- `docs/ARQUITECTURA.md` — bloques y funciones clave **con su línea real**, y
  las trampas de edición.
- `docs/Auditoria_profunda_v2.md` — los fallos encontrados en la auditoría de
  la ronda de corrección y cómo se arreglaron.
- `docs/Capturas_3D.md` — galería con triángulos y llamadas por mapa.
- `docs/Equilibrio_medido.md` — cifras por modo×mapa con n.
- `docs/Catalogo_habilidades_original.md` — las 44 habilidades y su estado.
- `assets/soldier/outfits/` — **los 7 uniformes del original** que se usan hoy.

## 4. Tareas pendientes, en orden de valor

### T1 · Soldados con las mallas de clase (BLOQUEADA, ver §5)
Hoy las 7 clases comparten cuerpo y cambian de uniforme. El objetivo real es
que cada clase tenga su cuerpo (Soldier_Heavy, Agent_Light/Heavy, Medic,
Engineer, Commander). **Requiere resolver el skinning + animación** (ver §5).

### T2 · Interfaz del original — hecha en la tanda de corrección
- **HUD**: acciones en una **barra inferior fija** (icono + etiqueta + detalle).
- **Cuartel**: pantalla visual de tropas con retrato del modelo.
- **Portada**: logo grande centrado, menú en columna, demo después.
- **Campaña**: selección de capítulos en tarjetas con arte y progreso.
- **Retratos**: renderizados del modelo real.
- Pendiente menor: comparar el HUD con capturas del original lado a lado.

### T3 · Mapas
- Revisar **escala de props** sueltos (algunos contenedores parecen grandes).
- Revisar la **densidad del anillo exterior** en los 13 tableros con captura.
- Añadir prop propio a los temas que aún comparten rama (`terminal`/`depot`).

### T4 · Campaña
Las 6 misiones ya tienen tablero propio (`campana01..06`) y se juegan en el
motor. Falta: **arte de capítulo** (los iconos del IPA son GameObjects de
atlas), textos de misión más ricos y una pantalla de selección de capítulo.

### T5 · Arte propio
Sustituir los assets del IPA (modelos, texturas, audio, logo) por arte propio
antes de publicar. Los del original están incluidos **solo por permiso de
desarrollo**.

## 5. El problema abierto: mallas de clase y animación

**Qué se probó** (y por qué no funcionó):

1. El rig de cada clase se extrajo con sus huesos, bind poses y pesos de
   skinning (`MeshHandler`), en tres variantes: transformaciones de Unity
   (Y-up), transformaciones derivadas de las bind poses (Z-up) y esqueleto
   solo con los huesos del skin.
2. En todos los casos, al **aplicar los clips horneados** de CSN, el esqueleto
   se colapsaba o se deformaba: los huesos acababan en el origen y la malla
   skinned no se dibujaba (se veían solo las piezas de equipo).
3. La malla base del IPA (Soldier_Light) con su rig horneado sí funciona.

**Datos concretos de los clips** (`assets/soldier_clips.json`): 22 clips, cada
uno con `dur`, `loop`, `rot` (por **nombre de hueso**: tiempos `t` y
cuaterniones `q`) y `root` (desplazamiento), más `rootScale: 0.5122`. Es decir:
**animan rotaciones por nombre + un desplazamiento de raíz**, no posiciones de
huesos; las posiciones vienen del rig. Por eso un rig distinto debería poder
animarse con los mismos clips… pero el resultado se colapsa, así que el
sospechoso es la **conversión de espacio** (los clips están en el espacio
Z-up del juego y los rigs de clase, derivados de bind poses, no coinciden en
convención con lo que espera el retargeting).

**Hipótesis para quien lo retome**: los clips de `assets/soldier_clips.json`
fueron horneados para un esqueleto concreto (nombres y orden de huesos) y
aplican **rotaciones absolutas por nombre**; las mallas de clase tienen
jerarquías y nombres ligeramente distintos (y un hueso raíz extra). El camino
razonable es **rehornear los clips por clase** con el mismo pipeline que
generó `soldier_clips.json` (hay que localizar ese pipeline en
`D:\Juegos\CSN\_original` o reconstruirlo con UnityPy) o **reapuntar** los
clips por nombre de hueso con una tabla de correspondencia.

**Mientras no se resuelva**: no sustituir `assets/soldier.obj` /
`soldier_rig.json` por los de clase; el juego se rompería (ya pasó).

## 6. Reglas de la casa

1. **Verificar antes y después** con `VERIFICAR.ps1`; nunca dejar `main` en
   rojo.
2. **No tocar daño, vida ni costes base** sin medir con `harness.js` y
   documentarlo en `docs/Equilibrio_medido.md`.
3. **Anclas únicas** al editar: comprobar que el texto a reemplazar aparece
   una sola vez (hay fragmentos duplicados).
4. **Bloques de props**: todo `if(theme===...){` insertado debe cerrarse antes
   de la línea original (es el error más repetido).
5. **Commit y push por fase**, con mensaje que diga qué se verificó.
6. La vista **3D es la principal**; la 2D es alternativa y no se usa para
   verificar.

## 7. Cómo saber si has terminado una tarea

- `VERIFICAR.ps1` en `TODO OK`.
- Captura 3D (o de la pantalla tocada) que **demuestre** el cambio.
- Si toca reglas: harness con n≥30 y tabla actualizada.
- Commit empujado a `main`.


## 8. Tanda de corrección (rondas 1-14) — qué se arregló y con qué prueba

| Commit | Qué |
|---|---|
| `1fe168c` | Soldados visibles otra vez: malla del IPA + uniformes del original, escala 0,95, equipo proporcionado |
| `9a22ce2` | `docs/Auditoria_profunda_v2.md` con hallazgos y plan |
| `a9b749f` | Retratos de la UI renderizados del modelo real |
| `ffac286` | Pantalla de crear partida reestructurada |
| `a508f87` | HUD compacto, sin desbordes, tooltips |
| `84d42a5` | Unidades a 1,15 y busto del retrato |
| `03007f6` | Este examen |
| `51943a5` | Cuartel visual |
| `e97527b` | Props del anillo al 74 % y más lejos |
| `ceb1ff7` | Portada centrada con el logo del original |
| `bcd3dbb` | Menú en columna |
| `2af6db8` | Menú antes del demo |
| `d7ba435` | Datos de los clips de animación en §5 |
| `32545b4` | Jerga de proyecto fuera de la UI |
| `c1b8b46` | Barra inferior de acciones |
| `d5d4432` | Campaña como selección de capítulos |

**Prueba de extremo a extremo** (navegador headless, 0 errores): nación →
menú → Challenges (6 misiones, 1 disponible) → misión 1 → setup de campaña →
lanzar → partida en 3D (`theme:"plaza"`, 8 unidades, barra con 8 acciones).
Capturas: `docs/capturas/E2E_CAMPANA.png` y `docs/capturas/UI_HUD_barra.png`.


## 9. Mallas de clase: RESUELTO (causa raíz: triangle strip)

**La causa raíz del destrozo de las mallas era el decodificador de índices.**
`MeshHandler.m_IndexBuffer` del IPA devuelve un **triangle strip** (p. ej. 2923
índices con parejas repetidas de costura), no una lista de triángulos. Al
agruparlo de tres en tres salían 974 triángulos con 480 degenerados y la malla
se veía como fragmentos negros. Decodificándolo como strip (invertir el orden
en los índices impares y saltar degenerados) salen **1456 triángulos**, los
mismos que la malla base que ya funcionaba.

Con eso, las siete mallas de clase se regeneran con:

1. strip → triángulos;
2. **orden de huesos del rig base** (los clips se aplican por índice);
3. **escala horneada** en vértices y bind poses (factor 1/k en las inversas),
   de modo que todas usan `mesh.scale = 0,95`;
4. OBJ con la **X ya invertida** (porque `parseOBJ3` la niega);
5. `bone.scale` en el juego y retargeting por delta de los clips.

Las mallas de clase están **activas por defecto**; el retrato/sprite se sigue
fotografiando con la malla base. Solo el **Comando** (Agent_Heavy, skin de 17
huesos, bind con escala 2,5) sigue sin cuadrar y va con la malla base
(`CLASS_MODEL_SKIP`).

### Historia anterior (para no repetir callejones sin salida)

Estado: **RESUELTO** (ronda 8 de esta tanda). Todo el código está
hecho y probado; se activa con `window.__classModels=true` y por defecto
queda la malla base con su uniforme.

### Lo que se probó y qué se aprendió

1. **El rig base manda el orden.** `driveClipSoldier` aplica los clips por
   **índice**: `clip.rot[pack.bones[i]]` → `ud.bones[i].quaternion`. Si el rig
   de clase no tiene exactamente los mismos 20 huesos en el mismo orden que
   `assets/soldier_rig.json`, las rotaciones caen en huesos equivocados. Los
   rigs de clase ya se reextraen en ese orden exacto (20/20).
2. **Los vértices van espejados en X.** `parseOBJ3` hace
   `P.push([-(+p[1]), +p[2], +p[3]])`: la geometría se dibuja con el eje X
   invertido. Por eso hay que espejar también el rig: posiciones `(-x,y,z)`,
   cuaterniones `(x,-y,-z,w)` y matrices de bind `S·M·S` con
   `S=diag(-1,1,1,1)`. Los rigs actuales en `assets/soldier/*_rig.json` ya
   están espejados así.
3. **Las bind poses llevan ESCALA.** Comando y Espía tienen escala 0,4 en
   todas sus bind poses (determinante 0,06 = 0,4³) y el resto de mallas
   esconden escalas menores. Un rig de pos+quat la pierde y el skinning
   explota. Ya está implementado: el rig guarda `scale` por hueso (para
   `bone.scale`) y las matrices locales se descomponen normalizando la parte
   rotacional. Además los OBJ de clase se escriben con la **X ya invertida**
   para que `parseOBJ3` (que niega x) devuelva la geometría original, sin
   espejar el rig.
4. **Aun así la malla se deforma.** Con el orden y el espejo corregidos la
   malla sigue explotando en reposo (sin clips), lo que apunta a que las
   **bind poses del IPA no están en el mismo espacio que los vértices** para
   estas mallas (posible transformación del `SkinnedMeshRenderer` o bind
   poses pre-multiplicadas). Siguiente paso concreto: comparar la matriz
   `m_LocalToWorldMatrix` del SkinnedMeshRenderer con las bind poses y
   aplicarla si falta; o generar el rig con el mismo pipeline que produjo
   `assets/soldier_rig.json`.
4. **Truco de diagnóstico**: `window.__classModels=true` activa las mallas de
   clase; `window.__forceBaseModel` ya existía para forzar la base. Con
   ambos se compara en el navegador sin tocar código.

### Mientras tanto

Cada clase se distingue por **uniforme del original** (Veteran, Spetsnaz,
DeltaForce, Rambo, Decon, DeerHunter, base), **proporciones** (`ROLE_LOOK`,
0,84-1,30) y **equipo propio** (mochila, placas, antena, emblema). No es el
cuerpo distinto del original, pero se leen como siete soldados distintos.
