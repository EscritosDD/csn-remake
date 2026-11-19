# Capturas 3D y cómo regenerarlas

Las capturas **no se guardan en el repositorio** (pesaban ~18,5 MB y el juego no
las usa). Este documento explica cómo volver a generarlas exactamente iguales.

## Cómo regenerarlas

```powershell
# servidor estatico
python -m http.server 8000 --bind 127.0.0.1

# una captura: mapa y prefijo
node _capture_all.mjs skirmish05 REAL_skirmish05

# una mision de campana
node _capture_all.mjs campana:3 CAM_M3B

# pantallas de interfaz
node _capture_all.mjs ui:menu UI_menu 1500
node _capture_all.mjs ui:setup UI_setup 1500
node _capture_all.mjs ui:barracks UI_cuartel 1500
node _capture_all.mjs ui:viewer UI_visor 5000
node _capture_all.mjs ui:pieces UI_piezas 5000
node _capture_all.mjs ui:game UI_partida 4000
node _capture_all.mjs ui:resume UI_reanudar 4000

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
`<prefijo>_3d.png`.
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
sintaxis, tableros, reglas, datos y levanta un humo 3D que imprime el estado de
`__csn3d` en consola. Es la forma rápida de saber si algo se ha roto sin mirar
imágenes.
