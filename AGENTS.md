# AGENTS

## Objetivo
- Mantener CSN como juego estático HTML5/Canvas/Three.js, sin bundlers ni dependencias npm.
- `index.html` solo contiene HTML/CSS estático y dos tags module: `src/main.js` y `src/viewer/main.js`.
- Todo JavaScript vivo debe estar en `src/**/*.js`. No reintroducir `<script>` inline.

## Arranque y gate
- Servidor local: `node server.js` → `http://127.0.0.1:8000/`.
- Gate obligatorio tras cualquier cambio:
  - `npm run lint`
  - `npm test`
  - `powershell -ExecutionPolicy Bypass -File "D:\Juegos\CSN-repo\bench\VERIFICAR.ps1"`
- `npm run verify` es atajo equivalente a `VERIFICAR.ps1`.
- `npm run build` equivale al chequeo de sintaxis de `bench/check-syntax.js`.
- Si el humo headless falla de forma aislada con `visor: exit -1073740791`, repetir `VERIFICAR.ps1` antes de investigar.

## Reglas de modificación
- Refactor puro: no cambiar reglas de combate, balance, visuales, controles ni textos.
- No añadir `"type":"module"` a `package.json` raíz; `src/package.json` ya declara módulos ES.
- `assets/three.min.js` se carga como script clásico, no como módulo.
- Modo Historia usa el IPA en `assets/soldier/`; Modo Competitivo usa `.glb` en `assets/competitive/`. No mezclar fuentes.
- `src/viewer/card-stage.js` es el único `WebGLRenderer`; reutilizar `getCardStage()` en lugar de crear otro.
- Todos los módulos nuevos deben añadirse a los arrays `modules` de:
  - `bench/rules.test.js`
  - `bench/harness.js`
- `bench/rules.test.js` exige el marcador literal `/* ================= INIT ================= */` en `src/main.js`; conservarlo antes del IIFE de INIT.
- `src/main.js` debe seguir importando/refreshando el bridge en dos fases: `installEarlyBridge` antes del marcador INIT y `installFullBridge` después.

## Arquitectura actual
- `styles/`: `theme.css`, `layout.css`, `game.css`, `viewer.css`, `cards.css`.
- `src/data/`: naciones, armas, roles, cast, mapas, map-pieces, textos UI, desplegables, nombres de skins y catálogo competitivo.
- `src/core/`: storage, RNG, tiempo y geometría.
- `src/audio/`: sonido sintetizado y audio original.
- `src/core-and-audio.js`: agregador de core/audio.
- `src/game/`: reglas, IA, input, turnos, misiones, personajes, demo, teclado y quick actions.
- `src/render2d/`: tablero, tiles, sprites, FX y fachada `index.js`.
- `src/render3d/`: escena, assets, clips, retarget, soldados, armas, FX, cámara, runtime, carga GLTF, actor GLB, caché de assets y fachada `index.js`.
- `src/ui/`: shell, unit card, arsenal, habilidades, cuartel, laboratorio GLB, wiring y fachada `index.js`.
- `src/bridge.js`: `installEarlyBridge`/`installFullBridge`; exporta las variables de `main.js` a `window` para capturas, visor y tests.
- `src/viewer/`: `main.js` (visor/galería), `card-stage.js` (único renderer), `inspector.js` y `troop-cards.js`.
- `assets/competitive/`: `manifest.json` y contenedores `chars/`, `weapons/`, `anims/` para el Modo Competitivo.

## Alias y compatibilidad
- Conservar alias históricos usados por tests/capturas: `MESHY_LOADING→MESHY_MODELS`, `DOM_MAX_ROUNDS→DOM_TARGET`, `ESCORT_DRONE_*`/`ESCORT_GUIDES_PER_ROUND→ESCORT_MAX_ROUNDS`, `LS_WINS`/`LS_GAMES→LS_NATION`, `FLASH_RANGE`/`STUN_*→FLASH_COST`.
- El bridge completo incluye getters para todo el estado y helpers; los setters activos son: `G`, `W`, `H`, `BEACON`, `TURRET_POS`, `NATIVE_GRID`, `flowStep`, `myNation`, `pickedNation`, `setup`, `uid`, `hoverTile`, `arsFilter`, `DEMO`, `CHAR_PREFS`, `T3` y `viewMode`.
- `window.__build3D`, `window.__render3D`, `window.__renderDemo`, `window.quickStart`, `window.quickSmoke` y `window.quickFlash` son wrappers definidos en `src/main.js`; no sobreescribirlos con bridge getters.

## Tamaño y estilo
- Objetivo: cada módulo en `src/` por debajo de 450 líneas.
- Estado actual: `src/main.js` 302 líneas; `src/viewer/main.js` 449 líneas; `src/viewer/card-stage.js` 449 líneas; módulo más grande `src/ui/ui-shell.js` 377 líneas.
- Preferir extraer bloques completos a módulos con `ctx` antes que duplicar estado.
- Si se compactan líneas, validar siempre con `npm run lint` y la suite headless.
- No añadir comentarios nuevos salvo marcadores funcionales exigidos por tests.

## Archivos generados
- `docs/capturas/` contiene capturas locales generadas por `_capture_all.mjs`; está ignorado por `.gitignore`.
- `_original/` contiene el IPA y artefactos de extracción; el servidor no debe servirlo.
- `bench/` contiene tests y verificaciones; no abrir desde el servidor HTTP.
- Los scripts temporales de refactorización viven fuera del repo, en `%TEMP%\opencode`, y no deben versionarse.

## Notas para el visor
- `src/viewer/main.js` depende de globals exponidas por el bridge de `main.js` (`ROLES`, `WEAPONS`, `CLIPLIB`, `REAL`, etc.).
- El visor no aplica pose, clips ni retarget a los modelos Meshy.
- Las armas comparten el cargador del juego; no reintroducir alias temporales de carga.
- `mount()` debe reenganchar el modelo sin saltos y alinear la plataforma.

## Tests útiles
- `npm test`: suite node:test de reglas, datos, clips, XSS, UI, tarjetas, movimiento, colisiones y combate.
- `node --test bench/map-collision.test.js`: rejillas IPA y físicas.
- `node _capture_all.mjs <mapa> <prefijo> 12000 --2d`: captura/debugGrid.
- `node _capture_all.mjs viewer:audit-all VIEWAUDIT 8000`: auditoría del visor.
- `node _capture_all.mjs move:skirmish MOVE 8000`: movimiento 3D.
- `node _capture_all.mjs combat:skirmish COMBAT 8000`: eventos de clip en combate.
- `node _capture_all.mjs mobile:sw:game MOBILE_SW 8000`: móvil y SwiftShader.
