> **Nota de alcance:** este documento es histórico. Cita arte y material del original que vive fuera del repositorio (carpeta `_original/`), y capturas que no se guardan aquí por tamaño. No son enlaces rotos: son referencias al material de trabajo local.

# Informe de sesión y plan de arte completo para Muse

Fecha: 17 nov 2026 (sesión nocturna). Autor: el agente (DeepSeek Harness).
Estado del repo: todo lo descrito está en `main` y empujado a
github.com/EscritosDD/csn-remake.

> **Cómo leer este documento.**
> La **Parte 1** es el informe honesto de lo trabajado esta sesión (qué se
> arregló, qué se verificó y qué quedó pendiente). La **Parte 2** es la
> biblia de producción de arte para dejar el juego acabado: qué generar con
> Muse, con qué especificaciones, en qué orden, dónde va cada archivo y qué
> se considera "terminado" en cada área.

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
   privado); para publicar hay que sustituirlas por arte propio → Parte 2.

---

# PARTE 2 — Plan de arte completo para Muse

Objetivo: dejar CSN **visualmente acabado como videojuego**: interfaz de
juego completa, personajes terminados, mapas con piel propia y pantallas de
arranque/cierre. Todo el arte 2D y de texturas se genera en Muse; el motor
(sigue igual) solo cambia archivos o pide una pequeña edición de código.

## 2.0 Reglas de trabajo con Muse

1. Un lote = una tanda de Muse con un prompt. Genera 4-6 variantes por lote
   y elige una; no encadenes variantes sobre variantes.
2. **Siempre pedir formato**: PNG, resolución exacta de la tabla, sin texto
   (el texto va en HTML), sin marcos que no se pidan.
3. **Seamless** cuando se indique: la textura debe repetir sin costura al
   testearla en la vista 3D.
4. Los assets de UI se generan como **piezas sueltas con fondo
   transparente** (bordes de botón, iconos), no como capturas de pantalla.
5. Guarda cada archivo **con el nombre exacto de la tabla** y en su carpeta
   destino; así la integración es copiar/pegar sin tocar código.
6. Si Muse produce algo con estilo distinto al resto, se descarta: la
   coherencia vale más que la pieza aislada.

## 2.1 Definición de "juego acabado" (checklist global)

El juego se considera visualmente terminado cuando:

- [ ] **Portada** con logotipo, fondo propio, tarjetas de modo y naciones
      con arte (no bloques de texto).
- [ ] **Configuración** con selectores de escuadra, mapa y modo con
      miniaturas y arte propio.
- [ ] **HUD en partida** con iconos para todo (armas, acciones, estados) y
      el retrato del soldado seleccionado.
- [ ] **Soldado** con textura propia (3 cuerpos × 2 skins), tocados y
      armas coherentes.
- [ ] **Los 8 mapas de Londres** con atlas propios (mismos UVs).
- [ ] **Los 5 mapas de código** con suelo y props texturizados.
- [ ] **13 planos cenitales** propios para la vista clásica.
- [ ] **Efectos** (humo, chispas, viñeta) y **pantallas de carga,
      victoria y derrota**.
- [ ] Ningún icono con emoji, ningún placeholder "Cargando".

## 2.2 Dirección de arte y sistema de diseño

### 2.2.1 Paleta maestra

| Uso | Hex |
|---|---|
| Acero / metal | `#A9AEB2` |
| Hormigón / muro | `#7F858B` |
| Asfalto | `#5B5E63` |
| Madera / caja | `#8D6436` (cuerpo) · `#AB8248` (tapa) |
| Óxido / barril explosivo | `#CF3A30` (cuerpo) · `#7C1D18` (flebres) |
| Ámbar de UI / baliza | `#F2B234` |
| Cian aliado | `#39C2D7` |
| Nación azul | `#387EC9` |
| Nación roja | `#C95338` |
| Papel / texto claro | `#F4F1E6` |
| Fondo oscuro | `#141A12` |
| Verde vida / OK | `#69D66F` |

Regla: **escenario apagado (saturación baja), personajes y UI saturados**.
Así el jugador lee la partida de un vistazo.

### 2.2.2 Tipografía

- Títulos: condensada, mayúsculas, con tracking ligero (la UI actual ya usa
  este aire). Mantener la familia que ya carga el juego; no introducir otra.
- Cuerpo: la misma familia a tamaños 14/16 px.
- Números de daño/energía: negrita, alineados a la derecha.

### 2.2.3 Formas y materiales (UI)

- Radios de esquina: 10 px (tarjetas), 8 px (botones), 6 px (insignias).
- Bordes: 1 px `rgba(0,0,0,.18)` + sombra suave `0 2px 6px rgba(0,0,0,.15)`.
- Botón primario: relleno ámbar `#F2B234`, texto oscuro.
- Botón secundario: relleno papel `#F4F1E6`, texto oscuro, borde.
- Botón peligro: relleno rojo `#C95338`, texto blanco.
- Estados: normal, hover (+8 % de brillo), pulsado (−8 %), deshabilitado
  (opacidad 45 %).

### 2.2.4 Estilo de personajes

- Proporción chibi (cabeza grande), cuerpo simple, sin anatomía detallada.
- Pintado plano con **contorno oscuro fino** (2 px a 512) y sombra suave.
- Uniforme verde oliva base; franjas de nación en hombros y brazos.
- Cada rol se distingue por **tocado + mochila + arma**, no por cara.

## 2.3 Inventario completo de assets

Formato de la tabla: **archivo** · tamaño · notas. Destino: `assets/`
salvo que se indique. Todas las fases van numeradas en 2.6.

### 2.3.1 Marca e identidad (Fase 0)

| Archivo | Tamaño | Notas |
|---|---|---|
| `logo_csn.png` | 1024×320 | Logotipo "CSN" estilizado militar, papel + ámbar |
| `logo_csn_blanco.png` | 1024×320 | Versión para fondos oscuros |
| `favicon.png` | 64×64 | Insignia reducida |
| `key_art_portada.jpg` | 1920×1080 | Escena clave: soldados en la calle de Londres, 3D estilizado |
| `fondo_menu.jpg` | 1920×1080 | Fondo tenue (mapa desenfocado) para el menú |

### 2.3.2 Interfaz — portada y menú (Fase 1)

| Archivo | Tamaño | Notas |
|---|---|---|
| `ui_boton_primario.png` | 256×96 | 9-slice, ámbar |
| `ui_boton_secundario.png` | 256×96 | 9-slice, papel |
| `ui_boton_peligro.png` | 256×96 | 9-slice, rojo |
| `ui_panel.png` | 256×256 | 9-slice, papel claro con borde |
| `ui_panel_oscuro.png` | 256×256 | 9-slice, para el HUD |
| `ui_tarjeta.png` | 256×256 | 9-slice, tarjeta de modo/arma |
| `modo_eliminacion.png` | 256² | Insignia: dos escuadras frente a frente |
| `modo_baliza.png` | 256² | Insignia: baliza central |
| `modo_dominacion.png` | 256² | Insignia: anillos concéntricos |
| `modo_escolta.png` | 256² | Insignia: dron protegido |
| `nacion_<n>.png` | 256² × N | Insignia de cada nación (leer `NATIONS`): escudo + colores |
| `map_min_<mapa>.png` | 256² × 13 | Miniatura de cada tablero para el selector |

### 2.3.3 Interfaz — configuración de partida (Fase 1)

| Archivo | Tamaño | Notas |
|---|---|---|
| `setup_marco_escuadra.png` | 512×256 | Marco de slot de escuadra |
| `setup_slot_vacio.png` | 128² | Silueta "sin soldado" |
| `ui_interruptor_on.png` / `_off.png` | 128×64 | Interruptores (IA, sonido) |
| `ui_barra_fondo.png` / `_relleno.png` | 256×32 | Barra de vida/energía |

### 2.3.4 Interfaz — HUD en partida (Fase 2)

| Archivo | Tamaño | Notas |
|---|---|---|
| `hud_retrato_<rol>.png` | 512² × 7 | Retrato pintado de cada rol (chibi, estilo 2.2.4) |
| `hud_icono_<accion>.png` | 128² × 9 | disparar, granada, aturdir, energía, mover, capturar, reparar, recoger, esperar |
| `hud_icono_<estado>.png` | 96² × 5 | aturdido, cubierto, vigilancia, cegado, herido |
| `hud_icono_<objeto>.png` | 96² × 7 | botiquín, baliza, torreta, mina, botín cura, botín energía, botín granada |
| `hud_turno_aliado.png` / `_rival.png` | 512×64 | Cabecera de turno |
| `hud_log_borde.png` | 512×64 | Cabecera del registro de combate |
| `hud_fin_victoria.png` / `hud_fin_derrota.png` | 1250×400 | Pancartas de fin de partida |

### 2.3.5 Iconografía de armas (Fase 2)

Una ficha por arma del arsenal (leer `ARSENAL`/`WEAPONS` en el código para
la lista exacta; cubrir estas familias):

| Familia | Archivos |
|---|---|
| Fusiles de asalto y carabinas | `arma_fusil_<n>.png` (4-5 variantes) |
| Subfusiles | `arma_subfusil.png` |
| Escopetas | `arma_escopeta.png` |
| Francotiradores | `arma_sniper_<n>.png` (2) |
| Ametralladoras | `arma_ametralladora.png` |
| Lanzacohetes / lanzagranadas | `arma_lanzador.png`, `arma_lanzagranadas.png` |
| Pistolas | `arma_pistola_<n>.png` (2) |
| Granadas y aturdidoras | `arma_granada_<tipo>.png` (3), `arma_aturdidora.png` |
| Cuerpo a cuerpo | `arma_cuchillo.png` |

Todas 128², vista lateral, 2 tonos + detalle, mismo ángulo y grosor de trazo.

### 2.3.6 Personajes (Fase 3)

| Archivo | Tamaño | Notas |
|---|---|---|
| `soldier_tex_ligero.png` | 256² RGBA | Mismo Layout UV que la textura actual |
| `soldier_tex_medio.png` | 256² RGBA | Base verde oliva + correajes |
| `soldier_tex_pesado.png` | 256² RGBA | Armadura ligera + correajes gruesos |
| `tex_casco_emblema.png` | 128² | Emblema de nación para el casco (plano, se pega) |
| `skin_nacion_<n>_overlay.png` | 256² RGBA | Franjas de nación sobre el uniforme (opcional; hoy va por tinte) |

Notas de producción:
- Los tres cuerpos usan **el mismo despiece UV**; solo cambia el pintado.
- Las naciones se resuelven hoy con un tinte del material: si se quiere
  más detalle, usar los overlays y desactivar el tinte.
- Prohibido: caras detalladas, pelo, camuflajes finos (no se leen a tamaño
  de juego).

### 2.3.7 Mapas (Fase 4)

| Archivo | Tamaño | Notas |
|---|---|---|
| `skirmish_atlas0.png` | 1024² | Reemplaza el atlas 0 de los 8 mapas de Londres: fachadas de ladrillo, tejados, asfalto, aceras, marcas viales, farolas |
| `skirmish_atlas1.png` | 1024² | Reemplaza el atlas 1: contenedores, vallas, señales de obra, rejas, grafitis suaves |
| `suelo_almacen.png` | 1024² | 12×12 casillas, hormigón de nave |
| `suelo_patio.png` | 1024² | Asfalto portuario |
| `suelo_plaza.png` | 1024² | Losas de plaza |
| `suelo_embarcadero.png` | 1024² | Muelle de hormigón y tablones |
| `suelo_mercado.png` | 1024² | Adoquín / tierra |
| `top_<mapa>.jpg` | 700² × 13 | Plano cenital de cada tablero |
| `tex_caja_madera.png` | 256² | Tablones y esquinas metálicas |
| `tex_barril.png` | 256² | Chapa roja con fleje y símbolo de peligro |
| `tex_muro.png` | 256² | Hormigón con manchas |
| `tex_contenedor_<color>.png` | 256² × 4 | Corrugado azul/rojo/amarillo/verde |
| `tex_baliza.png` | 128² | Panel ámbar de la baliza |
| `tex_torreta.png` | 256² | Metal de la torreta |
| `tex_dron.png` | 256² | Casco del dron |

### 2.3.8 Efectos y atmósfera (Fase 5)

| Archivo | Tamaño | Notas |
|---|---|---|
| `fx_humo.png` | 512² (hoja 4×4) | Nubes suaves para granadas |
| `fx_chispas.png` | 512² (hoja 4×4) | Chispas de impacto |
| `fx_explosion.png` | 512² (hoja 4×4) | Bola de fuego de barriles |
| `fx_vineta.png` | 1920×1080 RGBA | Viñeta suave para encuadrar la acción |
| `fx_grano.png` | 512² | Grano sutil (opacidad baja) |

### 2.3.9 Pantallas especiales (Fase 5)

| Archivo | Tamaño | Notas |
|---|---|---|
| `pantalla_carga.jpg` | 1920×1080 | Fondo + hueco central para la barra |
| `carga_barra.png` | 512×32 | 9-slice de la barra de carga |
| `transicion_rayos.png` | 1920×1080 RGBA | Barrido opcional entre pantallas |

## 2.4 Prompts por lote (copy-paste para Muse)

> Ajusta el estilo con la frase maestra: *"hand-painted stylized cartoon
> game art, muted palette, soft ambient occlusion, flat shading, no text,
> no logos, transparent background when applicable"*.

**L1 — Logotipo**: "Military stylized game logo 'CSN' in bold condensed
letters, paper-white fill with amber #F2B234 accents and a thin dark
outline, slight 3D extrusion, on transparent background, 1024x320".

**L2 — Key art**: "Stylized cartoon key art of a chibi military squad
advancing through a deserted London street at dusk, brick buildings,
shipping crates and barrels, amber lighting, hand-painted style, muted
palette, no text, 1920x1080".

**L3 — Insignias de modo (4)**: "Four square game-mode badges, flat
hand-painted style, 1) two opposing squads face to face, 2) a glowing amber
beacon in the center, 3) concentric capture rings, 4) a small drone with a
shield ring. Muted military palette with amber and cyan accents, dark
outline, 256x256 each".

**L4 — Retratos de rol (7)**: "Chibi military soldier portrait, bust
view, painted flat style with thin dark outline, olive drab uniform, role
distinctive gear: [sniper hood and scope / heavy gunner with ammo belt /
spy with scarf / medic with red cross backpack / engineer with tool belt /
commando with balaclava / captain with peaked cap and gold trim]. Neutral
gray background, 512x512 each".

**L5 — Iconos de arma (serie)**: "Game inventory icons, side view, painted
flat style, thin dark outline, two tones plus metallic highlights, same
angle and stroke weight across the set: assault rifle, SMG, pump shotgun,
bolt-action sniper rifle, light machine gun, rocket launcher, grenade
launcher, pistol, fragmentation grenade, stun grenade, smoke grenade,
combat knife. 128x128 each, transparent background".

**L6 — Atlas de Londres 0**: "Hand-painted stylized game texture atlas,
1024x1024, 4x4 grid of seamless patches: london brick facades with windows,
slate roofs, wet asphalt, pavement slabs, road markings, street lamps,
drain covers, painted wall patches; muted desaturated colors, flat painted
style, soft ambient occlusion, no text, no logos, even neutral lighting".

**L7 — Atlas de Londres 1**: "…4x4 grid: shipping containers in blue, red
and yellow, wooden construction barriers, road-works signs, chain-link
fence, metal vents, subtle graffiti, stacked pallets; same muted painted
style, no text".

**L8 — Suelos (5)**: "Top-down seamless game floor texture, 1024x1024,
faint 12x12 grid of square tiles, hand-painted cartoon style, muted palette,
[warehouse concrete with oil stains / harbor asphalt / plaza stone slabs /
dock concrete and planks / cobblestone market dirt], no text".

**L9 — Textura del soldado**: "Video-game character texture sheet for a
chibi military soldier, flat hand-painted style, olive drab uniform, black
boots, leather straps and pouches, subtle dark outlines, no gradients, no
face detail, designed for a 256x256 UV layout, top-down painted".

**L10 — Props**: "Hand-painted game prop texture, 256x256, seamless,
[wooden crate planks with metal corners / red steel explosive barrel with
hazard band / stained concrete wall / corrugated shipping container in
blue], muted palette, flat cartoon style".

**L11 — Efectos**: "Game VFX sprite sheet, 4x4 frames, 512x512, soft
painted smoke puffs / orange sparks / fireball explosion / subtle vignette /
film grain overlay, transparent background, cartoon style".

## 2.5 Guía de integración técnica (archivo → código)

### 2.5.1 Sustituciones directas (sin tocar código)

| Archivo | Destino | Efecto |
|---|---|---|
| `skirmish_atlas0/1.png` | `assets/maps/` | Cambia la piel de los 8 mapas de Londres al recargar |
| `soldier_tex.png` | `assets/` | Nueva piel del soldado en 3D y en los sprites del tablero |
| `top_<mapa>.jpg` | `assets/maps/<key>_top.jpg` | Plano cenital de la vista clásica |

### 2.5.2 Cambios de código pequeños (los hago yo cuando existan los archivos)

| Archivo | Punto de integración |
|---|---|
| `suelo_*.png` | En `build3DWorld`, el `CanvasTexture` del suelo continuo pasa a cargar el PNG (1 línea por tema) |
| `tex_*.png` (props) | `mat3(color)` acepta un `map` opcional; los props pasan su textura |
| `hud_icono_*.png`, `arma_*.png` | Sustituyen los emoji/pictogramas de las tarjetas del HUD por `<img>` |
| `hud_retrato_<rol>.png` | `<img>` en la tarjeta del soldado seleccionado y en el roster |
| `modo_*.png`, `nacion_<n>.png`, `map_min_<mapa>.png` | `<img>` en las tarjetas de la portada/selector |
| `hud_fin_*.png` | Pancarta en el overlay de fin de partida |
| `pantalla_carga.jpg`, `carga_barra.png` | Overlay de carga al abrir el juego |
| `logo_csn*.png`, `favicon.png` | Cabecera y `<link rel="icon">` |
| `key_art_portada.jpg`, `fondo_menu.jpg` | Fondo de la portada y del menú |

### 2.5.3 Nombres exactos de los mapas en los planos

`almacen`, `patio`, `skirmish01`, `skirmish02`, `skirmish`, `skirmish04`,
`skirmish05`, `skirmish06`, `skirmish07`, `skirmish08`, `skirmish09`,
`skirmish10`, `skirmish11` (los `_top.jpg` existentes ya siguen este patrón).

## 2.6 Fases de producción con criterios de aceptación

### Fase 0 — Sistema de diseño (0,5 día)
Genera la paleta de referencia como *swatch sheet* y 3 botones de muestra.
**Aceptado cuando**: los 3 botones y un panel se ven coherentes entre sí y
con la paleta 2.2.1.

### Fase 1 — Interfaz de videojuego (2-3 días)
L1-L3, botones, paneles, tarjetas, insignias de modo y nación, miniaturas
de mapa, favicon y key art.
**Aceptado cuando**: portada y selector de partida están hechos con arte y
no con bloques de texto; no queda ningún emoji en esas pantallas.

### Fase 2 — HUD e iconografía (2-3 días)
L4-L5, acciones, estados, objetos, barras, registro, pancartas de fin.
**Aceptado cuando**: en partida cada botón y cada tarjeta tiene su icono;
el retrato del soldado seleccionado se ve; victoria/derrota muestran
pancarta.

### Fase 3 — Personajes (3-4 días)
L9, los 3 cuerpos, casco con emblema, overlays de nación opcionales.
**Aceptado cuando**: en la vista 3D el soldado tiene textura propia legible
a tamaño de juego; ligero/medio/pesado se distinguen.

### Fase 4 — Mapas (4-6 días, es el bloque grande)
L6-L7 (atlas), L8 (suelos), L10 (props), planos cenitales.
**Aceptado cuando**: los 8 mapas de Londres llevan los atlas nuevos sin
desalinear; los 5 mapas de código tienen su suelo; las 13 miniaturas y los
13 planos están puestos.

### Fase 5 — Efectos y pantallas (1-2 días)
L11, carga, transiciones, viñeta.
**Aceptado cuando**: abrir el juego muestra pantalla de carga; las granadas
de humo y las explosiones usan sprites nuevos; el encuadre lleva viñeta.

### Fase 6 — Pasada de coherencia (1 día)
Repasar todo en juego: tamaños, contraste, legibilidad a 1080p y en móvil.
**Aceptado cuando**: la checklist de 2.1 está entera marcada.

## 2.7 Cómo verificar cada fase sin capturas 3D

1. `JUGAR.bat` → recargar con Ctrl+F5 → mirar en pantalla (test definitivo).
2. Consola del navegador:
   - `window.skState('depot')` → `ready:true` y vértices del mapa.
   - `window.__csn3d` → tema, `geo`, unidades y triángulos del render.
3. Captura del tablero clásico: consola →
   `document.querySelector('#board').toDataURL()` y guardar.
4. Para comprobar que una textura sustituida carga:
   `performance.getEntriesByType('resource').filter(r=>r.name.includes('atlas'))`
   debe listar el PNG nuevo.

## 2.8 Qué NO debe generar Muse (y por qué)

- **Modelos 3D**: Muse es 2D. Si se quieren modelos nuevos (soldados,
  props) hacen falta generadores 3D (Meshy/Tripo) o modelado manual; el
  pipeline actual (box3 + texturas) cubre ya el juego.
- **Animaciones**: las 22 del IPA ya están integradas; las de código cubren
  el resto.
- **Texto en imagen**: siempre texto real en HTML (se traduce y se ve nítido).
- **Capturas de pantalla**: no sirven como arte; se genera pieza a pieza.

## 2.9 Orden de ataque recomendado (si solo puede hacerse una cosa por día)

1. Día 1: atlas de Londres 0 y 1 (los 8 mapas cambian enteros).
2. Día 2: textura del soldado (los personajes dejan de ser el IPA).
3. Día 3: botones/paneles/insignias de modo + nación + miniaturas.
4. Día 4: iconos de arma y acciones del HUD + retratos de rol.
5. Día 5: suelos y props de los mapas de código.
6. Día 6: plano cenital y pantallas de carga/fin.
7. Día 7: pasada de coherencia y limpieza.

Con eso el juego queda, en lo visual, **acabado como videojuego**: arte
propio en personajes, mapas y toda la interfaz, sin depender de los assets
del original salvo el modelo y las animaciones que ya están integradas.
