# Resumen del desarrollo nocturno (F0–F9)

Rango de commits: `234a5e3..4aadb98` (tras la auditoría de Gemini en
`7db5f1a`). Todo empujado a `main`. El juego nunca dejó de cargar ni de
ser jugable; cada fase se verificó con sintaxis, tableros, tests, harness,
headless (`__csn3d`) y capturas cuando la herramienta lo permitió.

## Fases cerradas

### F0 · Base y capturas — `234a5e3`
`_capture_all.mjs`: captura 3D (ventana real) y 2D (tablero clásico por
`toDataURL`) con estado `__csn3d`. Nota: con la ventana tapada, Chrome
estrangula rAF y la 3D no arranca; para verificar estado se usa headless.

### F1 · Escolta arreglada — `b049f28`, `528e51c`
Causa: solo el Médico guiaba y 1 casilla por ronda; al empujar, la escolta
se quedaba atrás y el candado `keepGuard` bloqueaba el segundo guiado; el
dron entraba con 180 PV contra fuego concentrado. Arreglo: la escolta
**camina con el dron**, guiado en cadena, cualquier escolta con energía
guía, blindaje ×0,47 y 240 PV. Resultado: **de 0-20 a A 14-6 (Almacén) y
7-3 (S03)**; con las habilidades nuevas, el dron se entrega en 8/10.

### F2 · Equilibrio medido — `c72f4d4`, `4aadb98`
200+ partidas en dos pasadas. Los extremos de muestras pequeñas eran
ruido. Tabla final tras F4-F9 en `docs/Equilibrio_medido.md`:
Eliminación Almacén **10-10**, Baliza S03 6-4, Dominación Almacén 12-8,
Escolta 8-2. **Dominación S03 (3-17)** queda como outlier documentado:
mapas, zonas, salidas y escuadras son 180°-simétricos; es la iniciativa
del segundo en mover en un mapa con cobertura densa, no la disposición.
Harness ampliado con informe de daño/kills por rol y log del dron.

### F3 · Informe CSN vs original — `b65db20`
`docs/Informe_CSN_vs_original.md`: 16 áreas en tres columnas con **fuente
por fila** (`.cs`, datos, docs o `index.html`). Coincidencias (cuerpos
200/12/1-300/18/3, baliza 5 turnos, sémilla, respuesta, vigilancia, cámara)
y lo que faltaba, actualizado tras F4.

### F4 · Contenido del original — `a64160d`, `5f37dc1`, `635f2d9`, `0d251d6`, `e21d29e`, `fa1096b`
- **10 personajes con nombre** con rol, bio y nombre en el roster.
- **4 cajas de habilidad** del original (salud, munición mejorada,
  analgésicos, espíritu de equipo) con efectos, ticks y visual por tipo.
- **Empujón** en escopetas, lanzadores y Barrett.
- **14 habilidades nuevas** con parámetros del esquema del original, botón,
  acción sobre casilla/unidad, uso por la IA y registro: cobertura
  desplegable, granada de gas, barrido detector, molotov, caja de salud,
  teletransporte, escudo antidisturbios, artillería, bomba de abejas,
  tranquilizante, cañón de agua, kit de herramientas, torreta de cohetes y
  láser orbital.
- 4 sin equivalente directo (carga remota, UAV, Gatling, ballesta)
  documentadas como cubiertas funcionalmente.

### F5 · Mapas — `15633bf`, `8005cde`
`buildThemedProps3`: props construidos en código con textura procedural en
el anillo exterior, por tema — contenedores y grúas (astillero), puestos
con toldo (mercado), bancos y farolas (calles/plaza), buzón y coches
(Londres), fuente (plaza), grúa de muelle (embarcadero), bolardos (dock).
Cada mapa sale con tris/llamadas distintos en headless.

### F6 · Interfaz del original — `9a62989`, `bfe888f`
- Comprobado que el **daño previsto** (acierto % + daño + cobertura y
  flanqueo) y el HUD (retratos, vida, energía) ya existían en ambas vistas.
- **Arco de vida en el suelo** verde/azul por bando, en 3D (drawRange sobre
  anillo de 64 segmentos) y en clásica.
- **Menú estilo original**: Quick game, Play online, Challenges,
  Expansions y **monedas** (500 iniciales, +25 por victoria contra la IA).
- **Tutorial en bocadillo** con deshacer, ajustes, inicio y confirmar
  (una vez por dispositivo).
- Iconos de estado por soldado en el roster.

### F7 · Pantallas y assets — `bfe888f`, `87e82da`
- Las 3 imágenes de aistudio: borradores de interfaz; quedan como
  referencia de arte (documentadas en `docs/Arte_visual.md`), no en la
  portada.
- **Pantalla de carga** con logo y barra (se cierra al cargar el soldado o
  a los 9 s; arreglado el orden respecto al DOM).
- **Victoria/derrota**: pancarta VICTORIA/EMPATE/DERROTA con arte del modo.
- Decisiones de arte: botones/panel se quedan en CSS; iconos tipográficos.

### F8 · Personajes y naciones — `0d8951b`, `5d34682`
- **Personalidad por nación** (12: Temple, Fuego sostenido, Puntería,
  Maniobra, Ingeniería, Resistencia, Logística, Disciplina, Terreno,
  Iniciativa, Paciencia, Exploradores), solo visual.
- **Anillo del color del rol** en el suelo de cada soldado en 3D.
- **Arsenal de 37 armas**: 8 nuevas (Mk 14 EBR, PSG-1, Browning M2, Mk 19,
  KRISS Vector, G36C, FAMAS, Mossberg 500) con datos reales, al final de
  los pools para no cambiar el arma por defecto de la IA.

### F9 · Interfaz minimalista — `6cfd463`
- Tarjetas de modo a 2 líneas con el texto completo al pasar.
- Lista de los 13 tableros plegada.
- **Pantalla Cuartel**: nación con personalidad y monedas, los 7 roles con
  retrato y personaje, el arsenal por categoría y los desbloqueos.

## Verificación final (esta noche)

- Sintaxis del script inline: **0 errores**.
- Tableros: **13/13** simétricos a 180° y sin solapes.
- Suite de pruebas: **6/6**.
- Headless: `__csn3d = {geo:true, 63.061 tris, 482 llamadas}` y **0
  excepciones**.
- Harness: matriz de 80 partidas (ver `docs/Equilibrio_medido.md`).
- Capturas 2D reales de tableros (`_captures/FINAL_*_2d.png`); las de 3D
  solo son válidas cuando la ventana queda visible (limitación de Chrome,
  ya documentada).

## Decisiones pendientes para el jugador

1. **Dominación en Skirmish_03** (85 % B): iniciativa alterna o subir la
   dificultad de la IA en ese modo/mapa.
2. **Las 4 habilidades** sin equivalente directo: añadirlas o dejarlas
   cubiertas como están.
3. **Arte propio definitivo** (Muse): atlas de Londres, textura del
   soldado y UI, con la biblia de `docs/Informe_sesion_y_plan_Muse.md`.
