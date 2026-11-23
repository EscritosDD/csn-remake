# Arquitectura de CSN

CSN es un juego estático HTML5/Canvas/Three.js sin bundlers ni dependencias npm.
`index.html` contiene HTML/CSS y dos tags module: `src/main.js` y
`src/viewer/main.js`. El JavaScript vivo está en `src/**/*.js`; `src/package.json`
declara los módulos ES. `assets/three.min.js` se carga como script clásico.

## Árbol funcional

| Ruta | Contenido |
|---|---|
| `styles/` | `theme.css`, `layout.css`, `game.css`, `viewer.css`, `cards.css`. |
| `src/data/` | Naciones, armas, roles, cast, mapas, map-pieces, textos UI, desplegables, nombres de skins y catálogo competitivo. |
| `src/core/` | Storage, RNG, tiempo y geometría. |
| `src/audio/` | Sonido sintetizado y audio original. |
| `src/core-and-audio.js` | Agregador de `core/` y `audio/`. |
| `src/game/` | Reglas, IA, input, turnos, misiones, personajes, demo, teclado y quick actions. |
| `src/render2d/` | Tablero, tiles, sprites, FX y fachada `index.js`. |
| `src/render3d/` | Escena, assets, clips, retarget, soldados, armas, FX, cámara, runtime, carga GLTF, actor GLB, caché de assets y fachada `index.js`. |
| `src/ui/` | Shell, campaña, previsualización de escuadra, unit card, arsenal, habilidades, cuartel, laboratorio GLB, wiring y fachada `index.js`. |
| `src/bridge.js` | `installEarlyBridge` e `installFullBridge`; expone estado de `main.js` a capturas, visor y tests. |
| `src/viewer/` | `main.js` (visor/galería), `card-stage.js` (único renderer), `inspector.js` y `troop-cards.js`. |
| `assets/competitive/` | `manifest.json` y contenedores `chars/`, `weapons/`, `anims/` para modelos `.glb`. |
| `bench/` | Tests y verificaciones; no se sirve por HTTP. |

## Arranque y gate

```
node server.js
npm run lint && npm test
powershell -ExecutionPolicy Bypass -File bench\VERIFICAR.ps1
```

`VERIFICAR.ps1` comprueba sintaxis, tableros, reglas, datos, winding, suite
npm, rejillas IPA, capturas `debugGrid`, clips, humo 3D, auditoría del visor,
movimiento, combate y móvil/SwiftShader. Debe terminar en **TODO OK 13/13**.
Si el humo headless falla de forma aislada con `visor: exit -1073740791`, se
repite `VERIFICAR.ps1` antes de investigar.

## Flujo de una partida

1. Desde `Jugar`, `campaignBtn` y `mnuChallenges` abren `#campaignHub`
   (`showCampaignView`), no más cajas encadenadas en el menú.
2. La misión seleccionada pasa por `showMissionBriefing(index)`: radio, roster
   fijo y un único botón de despliegue enlazado tras `showModal()`.
3. `openSetup(mode)` prepara `setup`; para Modo Historia fija mapa, formato e IA
   y muestra `#setupMapPreview` con la miniatura del tablero.
4. `squadRows()` genera tarjetas con retrato, cobertura de arma, estadísticas y
   selects funcionales; `readSquad(team)` sigue leyendo esos selects.
5. `startGame(squadA, squadB)` crea `G` (unidades, mapa, zonas, estadísticas) y
   arranca ambiente y música del original.
6. `updateUI` pinta HUD y tarjeta; en 3D, `build3DWorld` y `__render3D`
   construyen y animan la escena. La vista 2D es alternativa.
7. `tryShoot` / `damage` resuelven combate con `hitChance`, `coverLevel`,
   `hasLOS` e `isFlanked`; `endTurn` dispara torretas y pasa a la IA.
8. `endGame` decide ganador, premios y pantalla de resultados.

`src/main.js` conserva el marcador `/* ================= INIT ================= */`
antes del IIFE de INIT. El bridge se instala en dos fases:
`installEarlyBridge` antes del marcador y `installFullBridge` después.

## Escena 3D y visor

- Modo Historia usa el IPA en `assets/soldier/`; Modo Competitivo usa `.glb` en
  `assets/competitive/`. No se mezclan fuentes.
- `src/viewer/card-stage.js` es el único `WebGLRenderer`. El visor y el
  Inspector reutilizan ese renderer mediante `getCardStage()`.
- Los modelos de clase del IPA viven en `assets/soldier/<Clase>.obj` con su
  `_rig.json` y `_tex.png`; escalas en `assets/soldier_scales.json`.
- Las armas comparten holder con cañón `+X` y empuñadura `(0,0,0)`; se acoplan
  con `fitGunToHand3()` y sockets reales de `assets/weapons/weapon_sockets.json`.
- Los cinco personajes Meshy siguen aislados: no reciben pose, clips,
  retarget ni acople de arma.
- `mount()` reengancha el modelo sin saltos y alinea la plataforma antes de
  medir bounds.
- Depuración: `?debugGrid=1` muestra rejillas 2D/3D; `?debugWeapons=1` marca el
  socket real de cada arma.

## Reglas de edición

1. No reintroducir `<script>` inline en `index.html`.
2. No añadir `"type":"module"` a `package.json` raíz.
3. No crear otro `WebGLRenderer`; usar `getCardStage()`.
4. No mezclar IPA/Modo Historia con `.glb`/Modo Competitivo.
5. Conservar alias históricos usados por tests y capturas (`MESHY_LOADING`,
   `DOM_MAX_ROUNDS`, `ESCORT_DRONE_*`, `LS_WINS`, `FLASH_RANGE`, etc.).
6. No sobreescribir con bridge getters los wrappers de `src/main.js`:
   `__build3D`, `__render3D`, `__renderDemo`, `quickStart`, `quickSmoke`,
   `quickFlash`.
7. Comprobar unicidad de anclas antes de reemplazar; hay fragmentos repetidos.
8. Cada módulo en `src/` debe mantenerse por debajo de 450 líneas; ahora hay 75 módulos y `src/ui/ui-shell.js` está en 448.
9. La campaña usa `#campaignHub` y `showMissionBriefing()`; los botones del modal se enlazan después de `showModal()`, sin `onclick` inline.
10. Tras cualquier cambio: `npm run lint`, `npm test` y `VERIFICAR.ps1`.

## Documentación

El índice limpio está en `docs/README.md`. Los informes y planes antiguos viven
en `docs/historico/` y no son fuente de verdad.
