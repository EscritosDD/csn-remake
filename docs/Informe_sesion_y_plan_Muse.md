# Informe de sesión y plan de arte para Muse

Fecha: 17 nov 2026 (sesión nocturna). Autor: el agente (DeepSeek Harness).
Estado del repo: todo lo descrito está en `main` y empujado a
github.com/EscritosDD/csn-remake.

---

# PARTE 1 — Qué se ha trabajado en esta sesión

## 1.1 Bugs corregidos (críticos, con causa raíz)

**1. Los 6 mapas nuevos no se veían (caían a las losas de reserva).**
Causa: el formato `.bin` del juego exige que `(4 + longitud_cabecera_JSON)`
sea múltiplo de 4, porque se interpreta con `new Float32Array(buf, 4+hlen, …)`.
El pipeline de extracción dejaba la cabecera sin alinear → `RangeError` que
un `catch` silenciaba → el mapa nunca marcaba `ready`.
Arreglo: el pipeline rellena la cabecera con espacios hasta alinearla;
regenerados los 6 `.bin`. Verificado en navegador: los 8 mapas cargan.

**2. Carga frágil de assets.**
El soldado real y los mapas 03/04 iban embebidos como `data:` URIs dentro
del HTML (19 MB). En algunos navegadores/webs el `fetch` de `data:` falla y
el juego cae a la reserva (cajas y losas). Arreglo: todo pasa a archivos
servidos por HTTP (`assets/soldier.obj`, `soldier_rig.json`,
`soldier_tex.png`, `soldier_clips.json`, `assets/maps/*`). El HTML baja a
~8 MB. `JUGAR.bat` arranca el servidor y abre el navegador en un clic.

**3. Sección de la portada que no representaba el juego.**
Eliminada la sección "Tus soldados, dentro del juego" (tira de sprites
generada con imagen IA). Equilibrio de `<div>` verificado (132/132).

## 1.2 Infraestructura creada (la herramienta que faltaba)

**Pipeline de extracción (`D:\Juegos\CSN\_original\pipeline.py`, local).**
UnityPy → mallas + UVs + índices + atlas → `.bin` del juego. Autocomprobado
contra el S03 embebido: los grupos de índices salen **idénticos**
(137.082 + 744), lo que certifica el método. Calcula suelo/escala
(escala = 15 / ancho_del_suelo) y orientación de atlas por material.

**Verificador headless (Chrome DevTools Protocol, sin dependencias).**
Scripts en `D:\Juegos\CSN\_cdp*.mjs` / `_cap*.mjs`. Abre el juego, pone la
nación por localStorage, lanza cualquier mapa con `quickStart(id)` y lee:
- consola y excepciones,
- red fallida,
- estado interno de cada mapa (`window.skState(key).ready` y vértices),
- **`window.__csn3d`** (añadido al juego): tema, geometría real cargada,
  unidades, triángulos y llamadas del último fotograma.

**Captura del tablero 2D por `canvas.toDataURL()`** (lo único que Chrome
headless entrega fiable). Las capturas de pantalla completas
(`Page.captureScreenshot`) salen **congeladas** en esta máquina: devuelven
el fotograma de la portada, no el juego. Por eso las imágenes de "juego 3D"
que presenté no eran válidas; solo `TB_*.png` (tablero clásico) eran reales.

## 1.3 Assets reales integrados (8 mapas del IPA)

`Theme_01_Skirmish_03/04/05/06/08/09/10/11` → `.bin` + atlas compartidos
(verificado por md5: todos los mapas de Londres usan los mismos 2 atlas,
deduplicados a `assets/maps/skirmish_atlas0/1.png`) + planos cenitales
`_top.jpg` para la vista clásica.

Mapas de código sin paquete IPA (Almacén, Patio, Skirmish_01/02/07): siguen
en tablero de código como capa de reserva.

## 1.4 Cambios visuales

- **Material toon** (MeshToonMaterial + rampa de 4 pasos) en el soldado
  real, en los mapas reales y en todas las cajas/props de código (`mat3`).
  Look cel coherente con el original cartoon.
- **Props 3D rediseñados**: muros 0,85→0,62 de alto; estanterías 1,05→0,56;
  cajas 0,70×0,44 con tapa y listón; barriles más finos. La geometría real
  y los soldados mandan en la escena.
- **Suelo continuo** en mapas de código: una losa 12×12 con textura de
  casillas pintada (tono por celda + cuadrícula + fila de asfalto y borde)
  en vez de 144 losas con huecos. Dibujos/partida: 485 → 343.
- **Planos cenitales** de los 6 mapas nuevos para la vista clásica.

## 1.5 Verificación realizada (datos, no impresiones)

| Mapa | theme | datos | render (__csn3d) |
|---|---|---|---|
| Skirmish_03 | skirmish03 | 84.939 v | geo:true · 71.400 tris |
| Skirmish_04 | skirmish04 | 80.571 v | geo:true · 70.478 tris |
| Skirmish_05 | depot | 61.665 v | geo:true · 57.539 tris |
| Skirmish_06 | platform | 69.652 v | geo:true · 62.767 tris |
| Skirmish_08 | terminal | 87.338 v | geo:true · 73.695 tris |
| Skirmish_09 | rotonda | 75.576 v | geo:true · 64.793 tris |
| Skirmish_10 | cruce | 73.683 v | geo:true · 63.798 tris |
| Skirmish_11 | astillero | 74.344 v | geo:true · 65.969 tris |

- 0 errores JS en todas las pruebas; bucle de render hasta el fotograma 3.112.
- Harness IA-vs-IA completo (Eliminación/Baliza/Dominación) sin cuelgues.
- Sintaxis del script inline: 0 errores. Árbol limpio; HEAD = origin/main.

## 1.6 Limitaciones conocidas / pendientes

1. **Las capturas 3D no son fiables en este equipo** (fotogramas
   congelados). Para ver el juego hay que abrirlo con `JUGAR.bat`; el
   tablero 2D sí se captura por `toDataURL`.
2. **Suelo de los mapas nuevos calculado desde la malla** (el layout del
   original no es extraíble): puede quedar ~1,6 % desescalado respecto a la
   cuadrícula. Es un número en la cabecera `.bin` y se corrige al momento.
3. **Soldados a ~1 casilla de alto**; la referencia del original habla de
   ~1,5 casillas. Subirlos requiere reajustar arma/mochila (van colgadas
   del grupo) y está sin hacer.
4. **Contorno tipo dibujo** del soldado (rim/outline) no implementado.
5. Las texturas de los mapas de Londres son las originales del IPA (uso
   privado); para publicar hay que sustituirlas por arte propio → ver plan.

---

# PARTE 2 — Plan de acción completo para Muse

## 2.1 Dirección de arte (la del original, medida)

- **Estilo**: cartoon estilizado, formas simples, sombreado plano con
  contraste suave. Nada fotorrealista.
- **Paleta de referencia**: acero #A9AEB2, hormigón #7F858B, asfalto #5B5E63,
  madera #8D6436/#AB8248, óxido/rojo barril #CF3A30, ámbar #F2B234,
  cian #39C2D7, azul nación #387EC9, rojo nación #C95338, papel #F4F1E6,
  fondo oscuro #141A12.
- **Regla de oro**: saturación media-baja; los personajes y la UI son lo
  más saturado; el escenario se mantiene apagado para que el juego se lea.
- **Formato de entrega**: PNG (o JPEG calidad 85) sin canal alfa salvo que
  se indique; **1024×1024** para atlas y suelos; **256×256** para el
  soldado; **512×512** para iconos grandes; **700×700** para planos.

## 2.2 Lista de assets a generar (con destino exacto)

### A. Atlas de los mapas de Londres (prioridad máxima)
Dos atlas de 1024×1024 que sustituyan a los del IPA sin cambiar UVs.
- `assets/maps/skirmish_atlas0.png` (reemplaza): fachadas de ladrillo
  londinense, ventanas, tejados, asfalto, aceras, pintura vial, farolas.
- `assets/maps/skirmish_atlas1.png` (reemplaza): contenedores, vallas,
  señales de obra, grafitis suaves, detalles metálicos.
- Especificación: **seamless dentro de cada zona**, sin texto legible, sin
  logos, luz neutra (el juego ilumina), margen de seguridad 8 px entre
  zonas. Los UVs actuales esperan un atlas pintado "por zonas": generar un
  atlas de texturas variadas en rejilla de 4×4 zonas de 256 px.

### B. Suelo de los mapas de código
- Un solo PNG tileable 1024×1024 **que represente 12×12 casillas**:
  `suelo_almacen.png` (hormigón de nave industrial con juntas y manchas
  suaves), `suelo_patio.png` (asfalto portuario), `suelo_plaza.png`,
  `suelo_embarcadero.png`, `suelo_mercado.png`.
- Integración: la textura se pinta hoy por canvas; se puede sustituir por
  estos PNG en `build3DWorld` (basta cambiar la fuente del `CanvasTexture`).

### C. Props 3D (texturas, no modelos)
- `tex_caja_madera.png` (256²): tablones, esquinas metálicas.
- `tex_barril.png` (256²): chapa roja con fleje y símbolo de peligro.
- `tex_muro.png` (256²): hormigón con manchas.
- `tex_contenedor_{azul,rojo,amarillo,verde}.png` (256²): corrugado.
- Uso: sustituir el color plano de `mat3` por `map` en los props.

### D. Soldado (sustituir la textura del IPA)
- `assets/soldier_tex.png` (256×256 RGBA): **el mismo espacio UV** que la
  textura actual. Reglas: uniforme verde oliva + franjas de nación en
  hombros/brazos (variantes azul #387EC9 y roja #C95338), correajes,
  botas, guantes; estilo pintado plano, contorno oscuro sutil.
- Generar 3 variantes: ligero/medio/pesado (mismo UV, distinto uniforme).

### E. UI e iconos
- `icon_{fusil,pistola,granada,aturnidora,medico,ingeniero,espia}.png`
  (128²): trazo limpio, 2 tonos + color de rol.
- Fondo de portada: si se mantiene ilustración, **key art propio** en
  lugar de la actual (una escena 3D estilizada, no una foto de estudios).

### F. Efectos y extras
- `tex_humo.png` (256²): nube suave para granadas.
- `tex_ruido.png` (256²): grano sutil para la viñeta del suelo.

## 2.3 Prompts listos para Muse (inglés, ajustables)

**Atlas Londres 0** — "Hand-painted stylized game texture atlas, 1024x1024,
4x4 grid of seamless patches: london brick facades with windows, slate
roofs, wet asphalt, pavement slabs, road markings, street lamps; muted
desaturated colors, flat painted style, soft ambient occlusion, no text,
no logos, even neutral lighting".

**Atlas Londres 1** — "…4x4 grid: shipping containers (blue/red/yellow),
wooden construction barriers, road works signs, chain-link fence, metal
vent grilles, subtle graffiti; same muted painted style, no text".

**Suelo almacén** — "Top-down seamless concrete warehouse floor texture,
12x12 faint grid of square slabs, oil stains and cracks, muted gray-green,
flat painted cartoon style".

**Soldado** — "Video-game character texture sheet painted for a chibi
military soldier, flat hand-painted style, olive drab uniform with blue
shoulder patches, black boots, leather straps, subtle dark outlines, no
shading gradients; designed for a 256x256 UV layout".

## 2.4 Dónde va cada archivo y cómo se integra

| Archivo generado | Destino | Integración |
|---|---|---|
| skirmish_atlas0/1.png | `assets/maps/` | sustitución directa (mismos nombres) |
| suelo_*.png | `assets/maps/` | cambiar la fuente del `CanvasTexture` en `build3DWorld` |
| tex_*.png | `assets/` | `mat3` acepta un `map` opcional; props lo usan |
| soldier_tex.png | `assets/` | sustitución directa (mismo UV) |
| icon_*.png | `assets/` | `<img>` de la UI y tarjetas de arma |
| key art | `assets/` | `<img>` de portada |

## 2.5 Orden recomendado (fases)

1. **Fase 1 (hoy)**: atlas de Londres 0 y 1 → el salto visual más grande en
   los 8 mapas reales. Verificar en juego; los UVs no cambian.
2. **Fase 2**: textura del soldado (3 variantes) → personajes.
3. **Fase 3**: suelos de los 5 mapas de código.
4. **Fase 4**: texturas de props y barriles.
5. **Fase 5**: iconos de arma/rol y key art de portada.
6. **Fase 6**: humo y post-proceso suave.

Cada fase: generar → sustituir archivo → recargar con `JUGAR.bat` →
comprobar en 3D (la vista clásica usa los planos cenitales).

## 2.6 Cómo verificar sin capturas 3D

- Abrir `JUGAR.bat` y mirar en pantalla (es el test definitivo).
- Abrir la consola del navegador y escribir `window.skState('depot')` para
  ver si la geometría está lista, y `window.__csn3d` para el render.
- El tablero 2D se puede capturar con clic derecho → guardar imagen, o
  desde consola: `document.querySelector('#board').toDataURL()`.
