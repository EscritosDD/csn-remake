# CSN — Chess Soldier Nation

Remake jugable de **RAD Soldiers** (Splash Damage / WarChest, 2012) como juego
web por turnos, **en 3D como el original**: escuadras de soldados con roles y
armas reales, modos Eliminación, Captura de baliza, Dominación, Escolta y
guerra por naciones, 19 tableros (8 Skirmish con geometría real del IPA, 5
propios y 6 de campaña) y una campaña de 6 misiones.

## Cómo jugar

- En Windows: doble clic en `D:\Juegos\CSN\JUGAR.bat` (levanta el servidor y
  abre el navegador).
- O levantar el servidor del repo y abrir `http://127.0.0.1:8000`:

```
node server.js
```

El servidor del repo sirve también `.glb`/`.gltf` con MIME correcto.

No vale abrirlo como archivo (`file://`): el juego carga assets por HTTP.

## Verificar que todo está sano

```
npm run lint && npm test
powershell -ExecutionPolicy Bypass -File bench/VERIFICAR.ps1
```

`VERIFICAR.ps1` hace 13 comprobaciones: sintaxis, 19 tableros, reglas, datos,
winding, suite npm, rejillas IPA, capturas `debugGrid`, clips, humo 3D,
auditoría del visor, movimiento, combate y móvil/SwiftShader. Último cierre:
**TODO OK 13/13**, **77/77 tests** y `viewer:audit-all ok=True` (4 modelos).
Los siete cuerpos IPA han sido restaurados, Meshy sigue aislado en
`assets/personajes_propios/`, los materiales usan `alphaTest:0` y las armas
comparten cañón `+X` con empuñadura `(0,0,0)`.

Depuración en el navegador: `?debugGrid=1` muestra rejillas 2D/3D y
`?debugWeapons=1` marca el socket real de cada arma.

## Qué hay dentro

| Ruta | Qué es |
|---|---|
| `index.html` | El juego completo: interfaz, motor, escena 3D y datos (un solo archivo). |
| `assets/soldier/` | Los **7 modelos por clase** del IPA (malla + rig + textura) y sus escalas. |
| `assets/audio/` | **195 clips del original**: armas, voces por personaje, ambiente por mapa, música y habilidades. |
| `assets/maps/` | Geometría de los 8 Skirmish del IPA y sus atlas. |
| `assets/ui/` | Retratos, naciones, modos, iconos de habilidad del original, logo y arte de la portada. |
| `bench/` | Verificación: `bench/VERIFICAR.ps1`, `check-syntax.js`, `boards.js`, `rules.test.js`, `data.test.js`, `harness.js`. |
| `docs/` | Diseño, arquitectura, equilibrio medido, catálogo de habilidades, capturas 3D y planes. |
| `_original/` | IPA, zip y código descompilado del original: referencia privada, no la carga el juego. |

## Herramientas de medida

- **Balance**: `node bench/harness.js <modo> <mapa> <partidas> <formato 4>`
  (Eliminación, Baliza, Dominación, Escolta). Resultados en
  `docs/Equilibrio_medido.md` (muestras de n≥30).
- **Capturas**: `node _capture_all.mjs <mapa|campana:N> <prefijo> [ms]`.
  Captura en 3D y solo baja a 2D si la 3D no arranca. También están los modos
  `ui:hipster`, `ui:soap`, `ui:sneaky`, `ui:meshy09`, `ui:mp5k`, `ui:minigun`
  y `ui:setup` para revisar armas, diseños propios y selector de personaje.

## Documentos clave

- [Estado final de sesión](docs/ESTADO_SESION_2026-11-21.md) — cambios, gates, pendientes y plan para mañana.
- [Arquitectura](docs/ARQUITECTURA.md) — estructura, funciones con su línea y reglas de edición.
- [Auditoría global 3D](docs/auditoria_global_3d.md) — 338 OBJ, 0 sin caras, 0 NaN, 13 rigs.
- [Plan director](docs/historico/Plan_director_original_base.md) — fases, criterios y estado.
- [Catálogo de habilidades del original](docs/Catalogo_habilidades_original.md) — las 52 con su estado.
- [Capturas 3D](docs/Capturas_3D.md) — los 13 mapas y las 6 misiones.
- [Equilibrio medido](docs/Equilibrio_medido.md) — cifras por modo×mapa.
- [Informe CSN vs original](docs/Informe_CSN_vs_original.md) — 16 áreas con fuentes.

## Aviso sobre los assets del original

El código y el arte propio de CSN son de Dani. El repositorio **incluye
material extraído del IPA de RAD Soldiers** (modelos, texturas, audio, mapas,
arte de la portada y logo) porque el original es la base del juego: su
material se copia, adapta y reutiliza por decisión expresa del autor. Ese
material es propiedad de Splash Damage / WarChest (RAD Soldiers, 2012).

## Licencia

Sin licencia decidida por ahora (`all rights reserved`). La decisión sobre el
código propio queda pendiente de Dani.


## Estructura del repositorio

```
index.html            el juego completo (un solo archivo)
assets/               mallas, texturas, audio, iconos y geometria de mapas
bench/                verificacion y pruebas (VERIFICAR.ps1, rules, datos, tableros, harness)
docs/                 documentacion (indice en docs/README.md)
docs/historico/       planes y auditorias de sesiones anteriores
tools/                reparacion y auditoria de assets (repair_zero_face_objs.py, auditar_assets_3d.py, generate_weapon_calibrations.py, extract_maps_grid.py)
_capture_all.mjs      generador de capturas 3D
```

El material de referencia del IPA está en `_original/` (el `.ipa`, el zip y el
código descompilado). Los modelos, rigs, texturas, audio y mapas que usa el
juego están en `assets/`. Si hay que tirar del original, se tira directamente
del IPA y de `assets/`, no de una traducción descompilada intermedia. El
material de `_original/` es solo de consulta: no lo carga el juego en ejecución.
