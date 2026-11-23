# Rediseño Urban Tactical Arcade · Splatoon Pop (2026-11-23)

Informe ejecutivo de los seis sprints ejecutados sobre CSN. El objetivo era
convertir la presentación del juego en una experiencia **Urban Tactical Arcade ·
Splatoon Pop** sin tocar las reglas tácticas, sin bundlers, sin dependencias npm
en runtime y manteniendo separados Modo Historia (IPA) y Modo Competitivo
(`.glb`).

## Resumen final

- `npm run lint`: limpio.
- `npm test`: **131/131**.
- `bench/VERIFICAR.ps1`: **TODO OK 13/13**.
- `src/`: **79 módulos ESM**, 0 `<script>` inline en `index.html`, 2 tags module.
- `index.html`: 2 module tags (`src/main.js`, `src/viewer/main.js`).
- 19 tableros, 40 clips IPA, 5 modelos Meshy heredados sin pose/clips/retarget.
- 1 `WebGLRenderer` en el visor (`src/viewer/card-stage.js`); 4 en `src/`.
- 0 errores de sintaxis y 0 ciclos ESM nuevos.
- Módulos más largos: `card-stage.js` 449, `ui-shell.js` 433, `viewer/main.js`
  420, `data/maps.js` 360. Ninguno supera 450.

## Sprint 1 — Carga y pose fiable del visor

- Extraído `src/viewer/body-loader.js` desde `src/viewer/main.js` (448 → 420
  líneas) usando `parseOBJ3`: el cargador original reflejaba X y arreglaba el
  winding de esa forma, así que se conservó el comportamiento exacto.
- Añadida verificación real con THREE de los inversos del rig
  (`validatedRigBoneInverses()`).
- Creado `src/render3d/gun-pose.js` y `assets/weapons/weapon_calibrations.json`.
- Corregido el pitch de la Minigun reconstruyendo la dirección horizontal tras
  limitar `_gpDir.y` a `[-0.14, 0.16]`. Calibración: `targetLength` `0.64 → 0.76`,
  `scale` `0.754256244 → 0.895679290`.
- Gate: lint limpio, 129/129 tests, `viewer:audit-all` con `ok true`, `errores []`.

## Sprint 2 — Sistema de color arcade

- Reescrito `styles/theme.css` con tokens pop: fondo azul noche, superficies
  frías y acentos cian/coral/lima/dorado.
- Tokens fijados que no deben cambiar: `--ink-cyan:#00e5ff`,
  `--ink-coral:#ff3d71`, `--ink-lime:#b8ff2c`, `--ink-gold:#ffc933`.
- Actualizados `cards.css`, `layout.css`, `viewer.css`, `index.html` y los tests
  de UI/tarjetas para eliminar la paleta militar anterior.
- Gate: lint limpio, 129/129 tests.

## Sprint 3 — Portada, campaña y despliegue directo

- `index.html` reconstruido: hero de dos bloques, acceso directo a partida,
  campaña con vista propia, setup/Armería/Tropas reorganizados.
- Ocultados/retirados `#origMenu`, `#demoSlotPlay`, `#menuExtras`, pills y filas
  redundantes, conservando IDs históricos para tests y capturas.
- Nuevo `src/ui/campaign-tally.js`; `renderCampaignPanel()` usa ese módulo.
- `src/ui/campaign-ui.js`: briefing arcade y botón «SIGUIENTE MISIÓN ▶» que
  llama directamente a `deployMission(next)`, nunca a `openSetup`.
- Restaurados los textos exactos exigidos por tests:
  `Personajes con visor 3D integrado` y `Catálogo de armas y desplegables`.
- Gate: lint limpio, 129/129 tests, `npm run build` con 0 bloques inline, 2
  scripts module, 77 módulos y 0 errores. Capturas `SPRINT3_*` con `ok true`,
  `errores []`: menú, hub, briefing, setup, tropas y armería.

## Sprint 4 — Look 3D y FX arcade con pool

- `src/render3d/env.js` centraliza la paleta de equipo/selección para que 3D,
  HUD y resultados compartan los mismos tokens.
- `toonGrad3()` y `soldierColors3()` usan rampas más duras y colores de equipo
  cian/coral; selección lima y objetivos dorados en `world.js`, `soldiers.js`,
  `fallback-soldier.js` y `assets-geo.js`.
- `camera3d.js` y `demo.js`: exposición `1.12`, sol atenuado y luz de borde fría
  (`0x9fe8ff`, intensidad `0.85`).
- Nuevo `src/render3d/fx-arcade.js`: trazadoras, impactos, exploraciones en
  capas y números flotantes comic con pool de meshes/nodos. No contiene renderer
  y recibe `REDUCED_MOTION` desde `fx3d.js` para evitar el ciclo
  `fx.js → fx3d.js → fx-arcade.js → fx.js`.
- `resetArcadeFx()` se llama al inicio de `build3DWorld()`, antes de
  `disposeObject3D()`, para que los recursos del pool no se destruyan.
- `fx3d.js` delega los cuatro efectos y llama `tickArcadeFx()` al final del
  frame; `window.__csn3d` expone `exp`, `rim` y `arc` para capturas.
- Gate: lint limpio, 130/130 tests. Capturas `COMBAT_S4`, `MOVE_S4`,
  `MOBILE_SW_S4`, `VIEW_S4` y `GRID_S4` con `ok true`, `errores []`.
  Telemetría de combate: `exp:1.12`, `rim:true`, pools activos y 0 errores.

## Sprint 5 — HUD de batalla y pantalla de resultado

- Nuevo `src/ui/arcade-hud.js`, sin imports, con:
  - `vitalsMarkup()`: tarjetas de vida por soldado con barra, rol, arma, estado
    de turno y selección; escapa HTML.
  - `resultMarkup()`: tarjeta de resultado arcade con rango de modo, ronda,
    banner VICTORIA/DERROTA/EMPATE, arte, estadísticas y acciones.
- `index.html`: barra superior `.hud-topbar` con identidad, marcador J1/Rival,
  contadores de vida, medidores de modo y acciones compactas; panel lateral
  `.battle-side` con `#squadVitals` y `#hudSquadTitle`.
- `src/ui/unit-card.js`: actualiza `#hudScoreA`, `#hudScoreB`,
  `#hudSquadTitle` y `#squadVitals`; la delegación de clics permite seleccionar
  soldado desde la tarjeta sin handlers inline.
- `src/game/missions.js`: `endGame()` usa `resultMarkup()` y conserva todos los
  botones, textos, medallas y lógica de campaña/tutorial.
- `styles/game.css` y `styles/layout.css`: estilos de topbar, vitals y tarjeta de
  resultado con los tokens del Sprint 2.
- Gate: lint limpio, 131/131 tests. Capturas `HUD_S5`, `COMBAT_S5` y
  `MOBILE_S5` con `ok true`, `errores []`.

## Sprint 6 — Documentación y cierre

- Actualizados `README.md`, `docs/README.md` y `docs/ARQUITECTURA.md` con los
  recuentos y la nueva arquitectura de HUD/FX.
- Añadido este informe y enlazado desde el índice de documentación.
- Registro de los módulos nuevos en las dos listas `modules`
  (`bench/harness.js`, `bench/rules.test.js`): `render3d/env`,
  `render3d/fx-arcade`, `ui/arcade-hud`.
- Gate final ejecutado desde cero:

```
npm run lint
npm test
powershell -ExecutionPolicy Bypass -File bench/VERIFICAR.ps1
```

Resultado: `TODO OK 13/13`. Incluye 19 tableros, 40 clips, 193 muestras de
movimiento, 157 muestras de combate, visor `ok=True` con 55 modelos y
móvil/SwiftShader a 390×844, ~16–17 fps.

## Invariantes preservadas

- `/* ================= INIT ================= */` sigue antes del IIFE de INIT.
- Bridge en dos fases: `installEarlyBridge` antes de INIT y
  `installFullBridge` después.
- `window.__build3D`, `__render3D`, `__renderDemo`, `quickStart`, `quickSmoke` y
  `quickFlash` siguen siendo wrappers de `src/main.js`.
- Alias históricos y setters del bridge intactos.
- Campaña: `#campaignHub` → `showMissionBriefing()` → `deployMissionData()` →
  `startGame()`; sin pasar por `openSetup`.
- Modo Historia usa IPA en `assets/soldier/`; Modo Competitivo usa `.glb` en
  `assets/competitive/`. No se mezclaron fuentes.
- `assets/three.min.js` sigue cargándose como script clásico.

## Reproducción rápida

```
node server.js
npm run lint && npm test
node _capture_all.mjs game HUD_S5 8000
node _capture_all.mjs combat:skirmish COMBAT_S5 8000
node _capture_all.mjs mobile:sw:game MOBILE_S5 8000
node _capture_all.mjs viewer:audit-all VIEWS4 9000
powershell -ExecutionPolicy Bypass -File bench/VERIFICAR.ps1
```

Las capturas viven en `docs/capturas/` y están ignoradas por Git. Todos los
cambios de esta entrega quedan sin commitear en el árbol de trabajo.
