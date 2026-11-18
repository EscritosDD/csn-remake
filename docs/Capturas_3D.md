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
```

El script arranca Chrome headless, entra al mapa, fuerza el render 3D, espera y
guarda `_captures/<prefijo>_3d.png` (y `_2d.png` solo si el 3D fallara). Imprime
ademas el estado de `window.__csn3d` (tema, geometria real, unidades,
triangulos, llamadas) y los errores de consola.

**Si cambias un asset, borra antes el perfil `_chrome_*`**: el navegador cachea y
la captura miente.

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
