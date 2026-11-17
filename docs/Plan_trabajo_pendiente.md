# Plan de trabajo pendiente (tras la auditoría de Gemini Studio)

Estado de partida: repo sincronizado en `7db5f1a` (44 commits de Gemini +
auditoría). El juego carga, los 8 mapas reales se renderizan, Dominación
está arreglada y medida, suite de pruebas 6/6, 13 tableros correctos.

Permiso del propietario: **se puede usar el original como fuente** (código
descompilado en `referencia_original/decompiled/`, datos en
`referencia_original/datos/`, documentos de `docs/`, capturas oficiales).
La revisión de derechos queda para más adelante.

Regla de oro de todo el plan: **el juego no se rompe** — cada cambio deja
`index.html` cargando y la partida jugable; sintaxis 0; tableros correctos;
cada cambio de equilibrio se mide con el harness y se entregan los números.

---

## FASE 0 — Base y herramientas (medio día)

1. Verificar el entorno de trabajo: servidor, harness, boards, test suite,
   verificador CDP (`window.__csn3d`, capturas 2D).
2. Reparar el script de captura 3D (fotogramas congelados): usar Chrome
   headful fuera de pantalla o captura por canvas; dejar un comando único
   de captura para cada fase.
3. Crear `docs/Plan_seguimiento.md` con la tabla de fases, estado y fechas.

**Aceptado**: `node bench/check-syntax.js` 0 errores, `node bench/boards.js`
13/13, `node bench/rules.test.js` 6/6, harness 2 partidas OK, y una captura
2D y una 3D generadas con el comando único.

## FASE 1 — Escolta: arreglar la entrega del dron (1-2 días)

Problema medido: 4/4 partidas con el dron muerto en (4-5,5); nunca llega a
la extracción. La defensa gana siempre.

1. Diagnóstico con trazas: por qué el dron no avanza (¿la IA de la escolta
   no guía? ¿el guiado no se ejecuta? ¿el dron muere antes por foco?).
   Usar el harness con `dronePos/droneDelivered/droneAlive`.
2. Leer las reglas del original en `referencia_original/decompiled/`
   (`UAVGameObjectComponent.cs`, `GameRulesComponent.cs` y los handlers de
   escolta) para el comportamiento correcto del dron.
3. Arreglo propuesto: la IA de la escolta debe priorizar guiar el dron
   (asignar 1-2 guías por ronda, escolta adyacente, curar con el Médico),
   y el dron no debe quedarse bloqueado por muros/cajas del camino.
4. Medir: 10 partidas de Escolta en Almacén y 10 en un Skirmish real;
   entregar victorias de escolta/defensa, rondas medias y veces que el
   dron llega a la extracción.

**Aceptado**: la escolta gana algunas partidas (objetivo 30-50 % en 20
partidas), el dron llega a la extracción en al menos un tercio, y el juego
sigue intacto.

## FASE 2 — Equilibrio completo y tabla por modo/mapa (2-3 días)

1. **Dominación**: 40 partidas (10 por mapa en Almacén y Skirmish_03, más
   S05 y S08) para confirmar el sesgo a B (7-3 y 6-4 en la auditoría).
2. **Eliminación y Baliza**: medir en Almacén, S03, S05 y S08 (el encargo
   citaba S05 3-7 y S08 7-3).
3. **Efectividad por rol**: ampliar `bench/harness.js` con un informe de
   daño/kills/objetivo por rol y medir los 7 roles en ambos bandos.
4. Ajustar **solo disposición** (salidas, baliza, cobertura) si los números
   lo piden; nunca daños/vidas/costes sin demostrar que están rotos.
5. Entregar la **tabla de equilibrio completa**: modo × mapa, victorias A/B,
   rondas medias, y nota de cada ajuste con su medición.

**Aceptado**: tabla completa en `docs/`, ningún modo con sesgo > 70/30 tras
los ajustes, y el harness extendido pasando.

## FASE 3 — Informe CSN contra el original (2 días)

1. Estructura de tres columnas: **qué tiene el original · qué tiene CSN ·
   qué falta o falla**, con **fuente** por fila (archivo `.cs`, JSON de
   `referencia_original/datos/`, documento de `docs/` o captura oficial).
2. Cubrir: reglas, modos, mapas, personajes/roles, habilidades, armas,
   economía, campaña, HUD/interfaz, presentación (cámara, ritmo, sonido).
3. Actualizarlo con lo ya hecho (arma, mapas, HUD, efectos, deshacer,
   habilidades) y con lo pendiente.
4. `docs/Informe_CSN_vs_original.md`.

**Aceptado**: cada afirmación con su fuente; ninguna fila "inventada";
revisión contra 3 documentos y al menos 10 `.cs` citados.

## FASE 4 — Contenido del original: personajes, habilidades, modos (4-6 días)

1. Leer en el `.cs` el catálogo real: **10 personajes con nombre**,
   **28 habilidades**, modos y campaña.
2. Añadir a CSN lo que falte, con la lógica leída (no inventada):
   - Roles/personajes nuevos con su habilidad y estadísticas del original.
   - Habilidades que faltan del catálogo (con su coste, alcance y efecto).
   - Modos del original que CSN no tenga (lista cerrada y priorizada).
3. Medir cada añadido con el harness y anotar su efecto.

**Aceptado**: inventario original vs CSN completo en el informe; cada
añadido probado, documentado y sin romper partidas.

## FASE 5 — Mapas terminados (5-7 días)

1. **Skirmish_03**: terminarlo del todo (es el de referencia).
2. **Los otros 7 reales** (04, 05, 06, 08, 09, 10, 11): props, detalle y
   atmósfera propios con la geometría del IPA y las capturas como modelo;
   que cada uno se lea como un lugar distinto.
3. **Los 3 inventados** (01 plaza, 02 embarcadero, 07 mercado): pulirlos
   hasta que parezcan del juego.
4. **Almacén y Patio**: texturizar con `procTex3` para que no desentonen.
5. Props que falten (puesto de mercado, farola, contenedor…): construirlos
   en código (formas simples + textura procedural), nunca dejar un mapa a
   medias.

**Aceptado**: los 13 mapas con su atmósfera propia, sin errores, y captura
de cada uno para revisión.

## FASE 6 — Interfaz del original (4-5 días)

1. **Cuadrados de daño previsto** en el suelo (por casilla, con caída por
   distancia y cobertura ya existentes; sin inventar fórmulas).
2. **Arco circular segmentado verde/azul** a los pies de cada soldado (la
   vida en el suelo).
3. **Vida en el HUD**: nombre, retrato, vida con su número en verde,
   energía con su rayo.
4. **Menú principal del original**: PLAY ONLINE (con globo), CHALLENGES,
   EXPANSIONS, QUICK GAME, monedas.
5. **Bocadillos de tutorial** con botones (deshacer, ajustes, inicio,
   confirmar).
6. Todo funcionando **en 3D y en la vista clásica**.

**Aceptado**: las cinco piezas visibles en ambas vistas, con captura, y sin
texto de relleno.

## FASE 7 — Contenido y pantallas (2-3 días)

1. **Las 3 imágenes de aistudio**: integrarlas donde correspondan o dejar
   escrito para qué son.
2. **Iconos de estado (5) y de objeto (7)** en el estilo del juego.
3. **Pantallas de carga, victoria y derrota** acabadas con arte del juego.
4. **Decisión del arte Fase 0/1**: recuperar los PNG de botones/panel o
   rehacerlos o quedarse con el CSS — decidido y escrito.

**Aceptado**: ningún asset huérfano; pantallas presentes; decisión escrita.

## FASE 8 — Personajes: diferenciación y naciones (5-7 días)

1. Personalidad visual por rol: complexión, colores, atuendos, tocados.
2. Diferenciación clara aliado/enemigo (más allá del tinte de nación).
3. **Nuevas personalidades por nación** acorde a los estigmas sociales
   reales (con nota de sensibilidad: sin caricatura ofensiva).
4. **Skins por nación**: colorear y diseñar las 12 insignias existentes y
   sus uniformes.
5. **Diseños de armas**: coger las del original como lógica y crear más
   sobre las ya implementadas.
6. Medir que ninguna skin/personalidad altera el equilibrio (son aspecto).

**Aceptado**: los 7 roles se distinguen sin leer el nombre; cada nación
tiene su skin legible; arsenal con al menos X diseños nuevos coherentes.

## FASE 9 — Interfaz minimalista cartoon (3-4 días)

1. Reducir el texto de la interfaz (regla: una línea por tarjeta, tooltip
   para el detalle).
2. Estética cartoon compacta y accesible, parecida al original.
3. Pantallas: ver tropas, skins, armas y desbloqueos en un espacio único.
4. Revisar en 3D y clásica; medir legibilidad a 1080p y móvil.

**Aceptado**: portada y HUD sin párrafos; toda la información accesible en
dos toques; captura comparativa antes/después.

---

## Orden de ejecución y dependencias

```
F0 base ──> F1 escolta ──> F2 equilibrio ──> F3 informe
                                   │
                                   ├──> F4 contenido original
                                   ├──> F5 mapas
                                   ├──> F6 interfaz
                                   ├──> F7 pantallas
                                   └──> F8 personajes ──> F9 UI minimalista
```

- F0 y F1 primero: desbloquean la medición fiable.
- F2 antes de tocar contenido: fija la línea base del equilibrio.
- F3 se puede escribir en paralelo desde F2.
- F4, F5, F6, F7 y F8 no dependen entre sí; F9 al final porque toca la
  presentación de todo.

## Verificación común a todas las fases

- `node bench/check-syntax.js` → 0 errores.
- `node bench/boards.js` → 13/13.
- `node bench/rules.test.js` → 6/6.
- Harness: 2 partidas de humo por modo tocado.
- Verificador CDP: carga, `quickStart`, `__csn3d.geo === true`, 0
  excepciones.
- Captura 2D (`#board.toDataURL`) y 3D (comando único de F0) por pieza.
- Commit por fase con mensaje claro; push al repo privado.
