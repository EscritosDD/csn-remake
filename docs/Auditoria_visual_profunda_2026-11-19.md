# Auditoría visual y técnica de CSN

**Fecha:** 19/11/2026  
**Estado:** auditoría y correcciones en curso; F-01–F-07 implementados en el
árbol de trabajo (F-05 validado visualmente en visor), F-09 mejorado, F-08 por
confirmar. Se añadieron ajustes de retarget/timing para personajes Meshy y
originales en gameplay; pendiente validación visual en partida.  
**Objetivo:** dejar evidencia reproducible, priorizar fallos y preparar una
petición técnica para OpenCode.

## Alcance y método

- Revisión visual de las 13 arenas 3D: Almacén, Patio y Skirmish_01–11.
- Revisión de pantallas de menú, configuración, Cuartel, partida, Visor 3D y
  lista de piezas.
- Revisión de la vista clásica 2D en Almacén y en una misión de campaña.
- Comparación del encuadre del personaje original y los modelos Meshy.
- Comprobación estática de los puntos de código que explican los defectos.
- Pruebas en navegador de navegación entre partida y otras pestañas, y de
  tamaños de escritorio y móvil.

Las 13 arenas 3D cargaron una escena y ocho unidades sin errores de JavaScript
en la sonda de captura. Los cinco personajes Meshy revisados cargaron malla y
textura. Esto no equivale a certificar colisiones, navegación táctica ni
equilibrio de todos los mapas.

## Resumen ejecutivo

| Prioridad | Hallazgo |
|---|---|
| **P1 · Corregido** | Volver a «Jugar» después de abrir otra pestaña dejaba la partida visible pero ocultaba la barra de acciones. |
| **P2 · Corregido** | La barra fija de acciones tapaba el tablero; los controles de cámara podían tapar el HUD de unidades. |
| **P2 · Corregido** | En vista 2D se recortaban sprites situados en los bordes del tablero. |
| **P2 · Corregido y validado visualmente** | El Visor 3D encuadraba mal los personajes Meshy y desplazaba algunos al recentrarlos. |
| **P2 · Corregido** | La lista de piezas repetía nombres genéricos y no permitía identificar de forma inequívoca varias mallas. |
| **P2 · Corregido** | El menú mezclaba español e inglés. |
| **Por confirmar (P3)** | La densidad visual de algunas arenas puede dificultar la lectura; no se ha demostrado que sea una colisión o superposición incorrecta. |
| **P3 · Mejorado** | En móvil, cabecera y controles dejaban muy poco tablero visible; ahora el juego usa un viewport interno desplazable. |

## Hallazgos

### F-01 — La navegación oculta los controles de una partida activa

**Prioridad: P1 · Confirmado**

**Reproducción:** iniciar una partida rápida, abrir «Visor 3D» y volver a
«Jugar».

**Resultado:** `#gameArea` sigue visible y los seis botones de acción siguen en
el DOM, pero desaparece la barra inferior. La medición observada cambia de
`body[data-state="playing"]` con la barra visible a `data-state="menu"` y barra
oculta.

**Causa confirmada:** `showScreen()` asigna el estado `menu` a cualquier
pantalla salvo selección de nación. El CSS muestra `.actionBar` únicamente con
`body[data-state="playing"]`. Volver a la pestaña no reconstruye ni reactiva el
estado de partida.

**Evidencia:** [captura tras volver a Jugar](capturas/AUDIT_UI_resume_ui.png).
Puntos de código: `showScreen()`, `startGame()` y regla CSS de `.actionBar` en
`index.html`.

**Aceptación:** la navegación entre pestañas conserva o restaura el estado
correcto; al volver a una partida activa se ven y funcionan todos los
controles. Añadir una regresión para la secuencia indicada y para abandonar la
partida deliberadamente.

**Implementación y comprobación:** `showScreen()` deriva el estado visible de
la partida mediante `screenStateFor()`. Regresión automatizada para partida
activa, partida terminada y pantallas ajenas al juego; recorrido en navegador
Partida rápida → Visor 3D → Jugar confirmó `playing` y la barra de acciones
visible al regresar.

### F-02 — La barra fija cubre el tablero

**Prioridad: P2 · Confirmado**

**Resultado:** la barra inferior está fijada al viewport y se dibuja encima del
canvas. En la captura tapa filas inferiores del tablero mientras la escena
continúa detrás.

**Causa probable confirmada:** `.actionBar` usa `position: fixed` y un
`z-index` alto. El padding del documento no reducía el área visible del juego
ni evitaba que la barra se superpusiera durante la partida.

**Evidencia:** [captura de partida](capturas/AUDIT_UI_game_ui.png).

**Implementación y comprobación:** la barra se monta fuera de `#gameArea`; el
área de juego reserva el alto medido de cabecera y barra, y desplaza su propio
contenido. Durante la partida se desactiva el scroll de página para que no se
desplace la cabecera; el alto se recalcula después del reflow en cambios de
tamaño. En 390×844 y 1366×768 el tablero no queda debajo de la barra y el
viewport de juego sigue siendo desplazable.

**Aceptación:** controles y tablero no se tapan entre sí en 1500×950,
1366×768 y móvil; todas las casillas siguen visibles o se puede desplazar el
área de juego sin que un control fijo tape destinos interactivos.

### F-03 — Controles de cámara sobre el HUD de unidades

**Prioridad: P2 · Confirmado**

**Resultado:** los botones de cámara de la esquina superior derecha pisan las
barras/etiquetas de unidades que aparecen cerca de ese borde.

**Causa confirmada:** `.gl-controls` se superponía al canvas en una capa fija,
mientras el HUD de vida se posicionaba con coordenadas proyectadas de la cámara.

**Evidencia:** [captura de partida](capturas/AUDIT_UI_game_ui.png) y capturas
de mapa. Puntos de código: estilos `.gl-controls` y actualización del HUD 3D.

**Implementación y comprobación:** los controles se movieron a la fila de
controles de vista, fuera de `#glWrap`; el HUD proyectado ya no comparte esa
zona de superposición. La captura renovada de partida permite revisar el nuevo
layout.

**Aceptación:** los controles no ocultan información de unidades en las cuatro
rotaciones de cámara, niveles de zoom y tamaños de viewport probados.

### F-04 — La vista 2D recorta soldados en los bordes

**Prioridad: P2 · Confirmado en Almacén**

**Resultado:** en la vista clásica, sprites de unidades desplegadas en la
primera/última columna quedan cortados por los límites del canvas.

**Causa probable confirmada por código:** los sprites se dibujan centrados en
el centro de su casilla con un tamaño de hasta 1,9 casillas; el tablero
ocupaba todo el canvas y no dejaba margen para esa extensión. El recorte era
el comportamiento normal del canvas al pintar fuera de sus límites.

**Evidencia:** [captura 2D de Almacén](capturas/AUDIT_almacen_2d.png). Puntos de
código: `draw()` y el bloque de dibujo de sprites en `index.html`.

**Aceptación:** sprites, anillos y barras de vida de unidades de borde se ven
completos sin alterar la correspondencia entre casilla visual y casilla
interactiva. Verificar los cuatro bordes y las esquinas en varios tamaños.

**Implementación y comprobación:** el tablero clásico usa el 90 % del menor
dimensionamiento disponible y queda centrado. Dibujo y puntero comparten la
misma escala y offsets, de modo que el margen no altera la selección de
casillas. Una regresión cubre márgenes y aciertos de casilla en canvas
cuadrado y panorámico; se regeneró la captura 2D de Almacén y se revisaron las
cuatro esquinas.

### F-05 — Encuadre inconsistente de personajes en el Visor 3D

**Prioridad: P2 · Confirmado**

**Resultado:** Meshy 09–13 y dos personajes originales cargan malla y textura.
Inicialmente los Meshy quedaban mucho más pequeños; al normalizar la distancia
se reveló además un desplazamiento que recortaba Meshy 12 y 13.

**Causa confirmada por código:** el encuadre original dependía de multiplicadores
de distancia distintos por categoría en lugar de las dimensiones del modelo.
La corrección de distancia dejó al descubierto otro defecto: `worldToLocal()`
convertía el centro mundial a coordenadas locales de la raíz rotada y ese
vector se restaba de `model.position`, que usa el espacio del padre. En las
mallas Meshy Z-up, mezclar esos espacios desplazaba el modelo.

**Implementación y comprobación:** el encuadre usa bounds precisos de malla,
FOV y aspecto; actualiza el esqueleto antes de medirlos. Un grupo pivote
traslada el modelo por el negativo del centro en el espacio del visor, sin
modificar la transformación local de la raíz. Pruebas cubren el cálculo de
distancia y el desplazamiento del centro. Se revisaron visualmente los cinco
Meshy y dos originales a 1500×950, y Meshy 09 a 390×844; cabeza, pies y base
quedan dentro del canvas.

**Evidencia:** `AUDIT_viewer_meshy09.png`–`AUDIT_viewer_meshy13.png`,
`AUDIT_viewer_original_ivan.png`, `AUDIT_viewer_original_commander.png` y
`AUDIT_viewer_meshy09_mobile.png` en `docs/capturas/` (carpeta local ignorada
por Git).

**Aceptación:** encuadrar modelos por sus bounds en unidades de mundo; mantener
un porcentaje de altura visual coherente, sin cortar armas, cabeza, pies ni
base. **Cumplida en la revisión visual descrita arriba.**

### F-06 — Etiquetas duplicadas en el visor de piezas

**Prioridad: P2 · Confirmado**

**Resultado:** en Skirmish_03, el visor muestra 45 piezas y repite nombres como
`SubMesh0`–`SubMesh8`. El usuario no puede distinguir de forma fiable los
elementos homónimos desde la lista.

**Causa confirmada:** `refreshList()` construye el texto del botón con
`entry.l`; el catálogo sí contiene claves/rutas distintas, pero no se exponen
en la etiqueta.

**Evidencia:** [captura de la lista](capturas/AUDIT_UI_pieces_ui.png).

**Aceptación:** cada entrada muestra un nombre legible y distinguible
(por ejemplo, nombre de malla más índice o ruta abreviada); el nombre accesible
para teclado/lector también debe ser único.

**Implementación y comprobación:** cada botón muestra su ordinal y expone la
ruta como `title` y nombre de malla en su `aria-label`. La captura renovada de
la lista distingue, por ejemplo, `SubMesh0 · 01` de `SubMesh0 · 02`.

### F-07 — Mezcla de idiomas en el menú

**Prioridad: P2 · Confirmado**

**Resultado:** los elementos «Quick game», «Play online», «Challenges» y
«Expansions» aparecen en inglés mientras el resto de la interfaz está en
español.

**Evidencia:** [captura del menú](capturas/AUDIT_UI_menu_ui.png).

**Aceptación:** todos los rótulos visibles del flujo español tienen traducción
consistente; no traducir nombres propios ni etiquetas de contenido que deban
permanecer en su idioma original.

**Implementación y comprobación:** «Partida rápida», «Jugar en local»,
«Desafíos» y «Expansiones» sustituyen los cuatro rótulos pendientes; la
captura renovada de menú confirma el texto.

### F-08 — Densidad visual de arenas originales

**Prioridad: por confirmar · Posible P3**

**Observación:** algunas escenas, en particular Skirmish_03, presentan muchos
elementos de escenario, obstáculos tácticos, unidades, anillos y marcadores en
un encuadre reducido. La cuadrícula y las unidades siguen renderizándose, pero
cuesta separar visualmente decoración, cobertura y objetos interactivos.

**Hipótesis, no causa demostrada:** el mundo original y los elementos tácticos
se componen en la misma escena; `build3DWorld()` también invoca
`buildThemedProps3()`. El documento [Estetica_original.md](Estetica_original.md)
describe deliberadamente los mapas originales como calles/estaciones en
miniatura con props y escenografía; por tanto, la cantidad de decoración por
sí sola no es un bug. Hay que comprobar por arena si los props quedan fuera de
la cuadrícula jugable y si algún elemento tapa una casilla, unidad o marcador
necesario. No asumir que una intersección visual es una colisión.

**Evidencia:** [Skirmish_03 en partida](capturas/AUDIT_skirmish_3d.png) y
resto de capturas de mapas.

**Aceptación previa a cualquier cambio:** comparar las capas de geometría
original, decoración y obstáculos; validar ocupación por celda y raycast. No
retirar ni modificar contenido original hasta identificar una superposición
incorrecta reproducible.

### F-09 — Poco tablero visible al cargar en móvil

**Prioridad: P3 · Confirmado por medición**

**Resultado:** a 390×844 no se detectó desbordamiento horizontal, pero la
cabecera ronda 271 px y el tablero empieza cerca de y=708; queda poco espacio
de juego visible inicialmente.

**Causa probable:** cabecera, estado/controles y paneles conservan alturas
grandes para un viewport vertical estrecho.

**Aceptación:** no exigir scroll para identificar el estado y acceder al
tablero; reducir/compactar cabecera y controles sin esconder acciones ni
reducir objetivos táctiles por debajo de un tamaño utilizable.

**Implementación y comprobación:** cabecera y navegación se compactan en
móvil, y el tablero puede recorrerse en el viewport de juego sin desplazar la
barra de acciones. En 390×844 no hay desbordamiento horizontal ni
superposición de la barra; el propio tablero puede requerir scroll vertical
para caber junto con HUD y controles.

### Observaciones no clasificadas como fallos confirmados

- El Visor 3D puede comenzar mostrando la espalda del personaje antes de que la
  rotación automática enseñe su cara. Revisar orientación inicial; no es un
  error de carga.
- La cámara conservaba zoom/desplazamiento al iniciar otra partida. Se añadió
  un reinicio explícito de yaw, distancia y paneo, con regresión automatizada.
- El tutorial flotante de la portada cubre parte del panel de menú hasta que
  se confirma. Revisar si es una ayuda intencional o un bloqueo visual
  demasiado prominente antes de rediseñarlo.

## Estado de las capturas

Las capturas de 13 mapas 3D están en `docs/capturas/` (directorio ignorado por
Git), junto con capturas actualizadas de menú, partida, reanudación, lista de
piezas, vista 2D de Almacén y la validación del visor F-05. Las capturas no se
incorporan al repositorio.

**Campaña completada:** `AUDIT_campana1_3d.png`–`AUDIT_campana6_3d.png` ya
muestran las misiones indicadas por sus nombres. Se regeneraron las misiones
2–5 después de corregir en `_capture_all.mjs` la conversión 1-based a 0-based;
el helper comprobó antes de desplegar cada misión que el rótulo coincidía con
el índice solicitado. Las cuatro ejecuciones terminaron sin excepciones de
JavaScript y con 8–10 unidades renderizadas.

El helper acepta `ui:resume` y cierra Chrome antes de eliminar el perfil
temporal, con reintentos de limpieza en Windows. La captura nueva
`AUDIT_almacen_2d.png` muestra completo el tablero y sus unidades de borde; se
generó sin excepciones. El script de campaña registró `errores: []` en las
capturas regeneradas.

## Estado de implementación y validación

- `index.html`: correcciones de navegación, reinicio de cámara, layout de
  partida y controles, margen 2D con puntero coordinado, encuadre del visor,
  identificación de piezas, textos del menú y recentrado de modelos con raíz
  rotada en el Visor 3D.
- `index.html` (continuación, traducción de personajes en gameplay): `loadMeshyModel`
  espera a que el rig base/clips estén disponibles antes de fijar el reposo de
  retargeting y, en juego, `makeRealSoldier3` reutiliza el reposo base cacheado
  del modelo cuando existe. Esto alinea la interpretación de clips para rigs con
  mismo orden de huesos (incluidos Meshy con jerarquía/repo pose distinta:
  Francotirador, Artillero, Espía, Ingeniero y Médico) sin alterar balance ni
  geometría. `poseSpriteClip` usa el mismo retargeting/root para sprites 2D.
- `bench/rules.test.js`: 18/18 pruebas pasan; incluye regresiones para estado
  de pantalla, reset de cámara, dimensiones/offsets del tablero 2D, ajuste de
  distancia/centrado del visor y presentación/retarget de rigs.
- `node bench/check-syntax.js`: dos bloques inline sin errores de sintaxis.
- `node bench/data.test.js`: 6/6 pruebas pasan.
- `node bench/boards.js`: 19 mapas y campañas pasan la medición ejecutable;
  no se alteró geometría ni reglas de mapas.
- `powershell -ExecutionPolicy Bypass -File bench\VERIFICAR.ps1`: sintaxis,
  tableros, reglas, datos y humo 3D en navegador OK.
- Revisión visual previa documentada: retorno a Jugar y barra visible
  confirmados; 2D revisado en 390×844 y 627×889; barra y tablero sin
  superposición en 390×844 y 1366×768; los cinco Meshy y dos originales
  encuadraban en 1500×950, y Meshy 09 también en 390×844.
- Pendiente: validar visualmente en partida que los personajes originales y los
  cinco Meshy (`Artillero, Espía, Francotirador, Ingeniero, Médico`) se animan
  sin deformaciones (“destartalados”), con arma/escala y sensación jugable
  coherente con los originales. F-08 sigue siendo hipótesis; no se debe
  modificar contenido de arenas sin probar una obstrucción real. También siguen
  pendientes la revisión de la orientación inicial del visor y la prominencia
  del tutorial de portada.

## Prompt técnico para OpenCode

```text
Actúa como ingeniero sénior de gameplay, UI y renderizado de juegos web.
Trabaja en este repositorio con cambios pequeños, verificables y compatibles
con la arquitectura existente. Usa como especificación de entrada
`docs/Auditoria_visual_profunda_2026-11-19.md` y consulta sus capturas locales
en `docs/capturas/`.

ESTADO DEL REPOSITORIO
F-01 a F-07 ya tienen correcciones en el árbol de trabajo; F-09 se ha mejorado.
Lee el diff y los tests antes de tocar nada. No dupliques, reviertas ni
replantees esas soluciones sin reproducir un defecto que siga presente.

OBJETIVO RESTANTE
1. F-05 ya está corregido y validado en escritorio con los cinco modelos Meshy
   y dos originales, y en móvil con Meshy 09. No rehagas ese cambio; si tocas
   el visor, vuelve a comprobar cabeza, pies, arma y base en todos los modelos.
2. Investiga F-08 por arena. Separa mentalmente/mediante herramientas la
   geometría original, los props y los obstáculos tácticos; demuestra una
   obstrucción de casilla, unidad o marcador antes de cambiar el mapa.
3. Revisa orientación inicial del Visor y tutorial de portada; consérvalos si
   son elecciones intencionales y no bloquean la interacción.
4. Comprueba el flujo de salida y nueva partida, incluyendo reset de cámara,
   sin cambiar balance, reglas ni contenido.

RESTRICCIONES DE TRABAJO
- Cambios quirúrgicos compatibles con la arquitectura existente; no reescribir
  el juego ni formatear el archivo entero.
- No alterar geometría, assets ni reglas por hipótesis. No introducir código,
  arte o contenido de terceros.
- Mantener la interacción, selección por teclado y accesibilidad del visor.
- En Windows usa PowerShell y rutas con barras invertidas; no dependas de
  herramientas Unix como `sed`.

ACEPTACIÓN Y ENTREGA
- Repite `node --test bench/rules.test.js`, `node bench/check-syntax.js` y
  `node bench/boards.js`; ejecuta también la verificación existente pertinente.
- Prueba el layout a 1500×950, 1366×768 y 390×844; el tablero, HUD y acciones
  deben seguir accesibles sin overlays que bloqueen casillas.
- Conserva las seis capturas de campaña verificadas por rótulo y actualiza
  capturas antes/después si una corrección visual adicional es necesaria.
- Resume evidencia, causa raíz, cambios, validaciones y limitaciones.
  Mantén F-08 como hipótesis si no se reproduce; no cambies el mapa a ciegas.
```
