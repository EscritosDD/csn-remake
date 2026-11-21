# Capturas 3D y cómo regenerarlas

Las capturas **no se guardan en el repositorio** (pesaban ~18,5 MB y el juego no
las usa). Este documento explica cómo volver a generarlas exactamente iguales.

## Cómo regenerarlas

```powershell
# servidor del repo (sirve tambien GLB/GLTF con MIME correcto)
node server.js

# una captura: mapa y prefijo
node _capture_all.mjs skirmish05 REAL_skirmish05

# una mision de campana
node _capture_all.mjs campana:3 CAM_M3B

# pantallas de interfaz
node _capture_all.mjs ui:menu UI_menu 1500
node _capture_all.mjs ui:setup UI_setup 1500
node _capture_all.mjs ui:barracks UI_cuartel 1500
node _capture_all.mjs ui:viewer UI_visor 5000
node _capture_all.mjs ui:hipster FIX_visor_hipster_ui 4000
node _capture_all.mjs ui:soap FIX_visor_soap_svd_ui 4000
node _capture_all.mjs ui:sneaky FIX_visor_sneaky_mp5_ui 4000
node _capture_all.mjs ui:meshy09 FIX_visor_meshy09_ui 4000
node _capture_all.mjs ui:mp5k FIX_visor_mp5k_ui 4000
node _capture_all.mjs ui:minigun FIX_visor_minigun_ui 4000
node _capture_all.mjs ui:pieces UI_piezas 5000
node _capture_all.mjs ui:game UI_partida 4000
node _capture_all.mjs ui:resume UI_reanudar 4000

# rejilla 2D/3D de los mapas IPA: el flag se pasa por CSN_URL
$env:CSN_URL = "http://127.0.0.1:8000/?debugGrid=1"
node _capture_all.mjs skirmish03 GRID_03 6000
node _capture_all.mjs skirmish04 GRID_04 6000
node _capture_all.mjs skirmish09 GRID_09 6000
node _capture_all.mjs skirmish11 GRID_11 6000
Remove-Item Env:CSN_URL

# auditoria del visor (personajes, armas, props y piezas)
node _capture_all.mjs viewer:audit-all VIEWAUDIT_FINAL 8000

# armas y movimiento/combate debugados
$env:CSN_URL = "http://127.0.0.1:8000/?debugWeapons=1"
node _capture_all.mjs ui:viewer VIEW_WEAPONS 8000
Remove-Item Env:CSN_URL
node _capture_all.mjs move:skirmish MOVE 8000
node _capture_all.mjs combat:skirmish COMBAT 8000
node _capture_all.mjs mobile:sw:game MOBILE_SW 8000

# Si el servidor usa otro puerto, y para guardar en otra carpeta:
$env:CSN_URL = "http://127.0.0.1:3000/"
$env:CSN_CAPTURE_DIR = Join-Path $PWD "docs\capturas"
node _capture_all.mjs skirmish05 REAL_skirmish05 6000
```

El script arranca Chrome, entra al mapa, fuerza el render 3D, espera y guarda
`docs/capturas/<prefijo>_3d.png` (y `_2d.png` solo si el 3D fallara). El
servidor y la carpeta de salida se pueden cambiar con `CSN_URL` y
`CSN_CAPTURE_DIR`; la carpeta predeterminada de capturas ya esta ignorada por
Git. Imprime ademas el estado de `window.__csn3d` (tema, geometria real,
unidades, triangulos, llamadas) y los errores de consola.
La numeracion `campana:N` es de 1 a 6, igual que la interfaz; el script la
convierte al indice interno de cero a cinco y comprueba el numero antes de
desplegar.
`ui:<pantalla>` captura menu, setup, cuartel, visor, piezas, partida o
reanudar partida y guarda `<prefijo>_ui.png`; los mapas y las misiones guardan
`<prefijo>_3d.png`. Los modos `ui:hipster`, `ui:soap`, `ui:sneaky`,
`ui:meshy09`, `ui:mp5k` y `ui:minigun` seleccionan personaje/arma mediante el
DOM del visor (`#viewerCharacterSelect`, `#viewerWeaponSelect`,
`#viewerKinds`, `#viewerList`) porque `viewer` y `selectModel` no son globales.
El cierre actual generó `FIX_visor_*_ui.png`, `FIX_setup_selector_ui_ui.png` y
`FIX_skirmish11_3d.png`.
`viewer:audit-all` recorre personajes, armas, props y piezas y guarda la
auditoria en el JSON de resultado (`viewer`, `viewerAudit`) además del PNG.
`move:`, `combat:` y `mobile:` capturan muestras de marcha, eventos de clip y
viewport móvil con SwiftShader.
Cada ejecucion usa un perfil temporal aislado y lo intenta eliminar al cerrar
Chrome.

## Qué capturar para revisar el juego

| Para ver | Mapa / misión | Prefijo sugerido |
|---|---|---|
| Tableros con geometría real del IPA | `skirmish`, `skirmish04/05/06/08/09/10/11` | `REAL_<mapa>` |
| Tableros propios | `almacen`, `patio`, `skirmish01/02/07` | `<mapa>` |
| Campaña (6 misiones) | `campana:1` … `campana:6` | `CAM_M<1-6>` |
| Interfaz | — | portada, setup, HUD, cuartel, armeria |
| Clases | cualquier mapa, con la cámara cerca de una unidad | `CLS_<clase>` |

## Para acercar la cámara a una unidad

La consola del navegador expone `window.__csnCam.cam`:

```js
__csnCam.cam.panX = -5.5;  // centro del tablero = 0, cada casilla = 1
__csnCam.cam.panZ = -2.5;  // equivale a la casilla (0,3) del mapa 12x12
__csnCam.cam.dist = 4.0;   // distancia
__csnCam.cam.yaw  = 2.75;  // giro
```

Y `G.units` da las posiciones: `G.units.map(u => [u.team, u.role, u.x, u.y])`.

## Verificación sin capturas

`powershell -ExecutionPolicy Bypass -File bench\VERIFICAR.ps1` comprueba
sintaxis, tableros, reglas, datos, winding, rejillas IPA, capturas `debugGrid`,
humo 3D, auditoría del visor, clips, movimiento, combate y móvil/SwiftShader.
Último cierre: **TODO OK 13/13**, **77/77 tests**, con `viewer:audit-all
ok=True` (4 modelos) y capturas reales de visor/setup/skirmish generadas.
Es la forma rápida de saber si algo se ha roto sin mirar imágenes.
