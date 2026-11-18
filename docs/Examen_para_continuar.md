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
| Soldados | **Un solo cuerpo del IPA (Soldier_Light) con 7 uniformes del original**; las 7 mallas de clase están extraídas pero **no se pueden usar todavía** (ver §5) |
| Interfaz | Portada con arte/logo del original, menú, campaña por capítulos, Cuartel, Armería, setup en rejilla, HUD compacto |
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

### T2 · Interfaz del original, segunda pasada
- HUD: mover las acciones a una **barra inferior** con iconos grandes y el
  detalle en tooltip (ahora es una tarjeta lateral).
- Cuartel: la ficha de personaje debe ser **visual** (retrato grande + stats),
  no una tarjeta de texto.
- Portada: probar la composición del original (logo grande centrado, menú
  debajo, soldados a los lados).

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
