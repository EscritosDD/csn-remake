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

Navegación principal: **Jugar · Armería · Tropas · Cómo se juega**. El Cuartel
sigue accesible desde el menú de inicio.

En **Jugar**, «Operación Londres» abre una vista propia de campaña: resumen de
progreso, radio, las 6 misiones por capítulos y la instrucción de Dave. Cada
misión muestra un briefing con roster fijo y despliega directamente; la pantalla
de «Configurar partida» añade una vista previa del mapa y tarjetas visuales de
escuadra con retrato, arma y estadísticas, sin crear otro renderer 3D.

## Verificar que todo está sano

```
npm run lint && npm test
powershell -ExecutionPolicy Bypass -File bench/VERIFICAR.ps1
```

La suite `npm test` cubre 125 pruebas; `src/` tiene 75 módulos ESM y todos
quedan por debajo de 450 líneas.

`VERIFICAR.ps1` hace 13 comprobaciones: sintaxis, 19 tableros, reglas, datos,
winding, suite npm, rejillas IPA, capturas `debugGrid`, clips, humo 3D,
auditoría del visor, movimiento, combate y móvil/SwiftShader. El cierre debe
quedar en **TODO OK 13/13** con `viewer:audit-all ok=True`. Los siete cuerpos
IPA están en `assets/soldier/`, Meshy sigue aislado en
`assets/personajes_propios/`, los materiales usan `alphaTest:0` y las armas
comparten cañón `+X` con empuñadura `(0,0,0)`.

Depuración en el navegador: `?debugGrid=1` muestra rejillas 2D/3D y
`?debugWeapons=1` marca el socket real de cada arma.

## Qué hay dentro

| Ruta | Qué es |
|---|---|
| `index.html` | HTML/CSS estático y dos tags module: `src/main.js` y `src/viewer/main.js`. |
| `src/` | JavaScript vivo en módulos ES: datos, núcleo, audio, reglas, render 2D/3D, UI, bridge y visor. |
| `styles/` | `theme.css`, `layout.css`, `game.css`, `viewer.css` y `cards.css`. |
| `assets/soldier/` | Los **7 modelos por clase** del IPA (malla + rig + textura) y sus escalas. |
| `assets/competitive/` | `manifest.json` y contenedores `chars/`, `weapons/`, `anims/` para el Modo Competitivo `.glb`. |
| `assets/audio/` | **195 clips del original**: armas, voces por personaje, ambiente por mapa, música y habilidades. |
| `assets/maps/` | Geometría de los 8 Skirmish del IPA y sus atlas. |
| `assets/ui/` | Retratos, naciones, modos, iconos de habilidad del original, logo y arte de la portada. |
| `bench/` | Verificación: `bench/VERIFICAR.ps1`, `check-syntax.js`, `boards.js`, `rules.test.js`, `data.test.js`, `harness.js`. |
| `docs/` | Diseño, arquitectura, equilibrio medido, catálogo de habilidades, capturas 3D e índice en `docs/README.md`. |
| `_original/` | IPA, zip y código descompilado del original: referencia privada, no la carga el juego. |

## Herramientas de medida

- **Balance**: `node bench/harness.js <modo> <mapa> <partidas> <formato 4>`
  (Eliminación, Baliza, Dominación, Escolta). Resultados en
  `docs/Equilibrio_medido.md` (muestras de n≥30).
- **Capturas**: `node _capture_all.mjs <mapa|campana:N> <prefijo> [ms]`.
  Captura en 3D y solo baja a 2D si la 3D no arranca. También están los modos
  `ui:hipster`, `ui:soap`, `ui:sneaky`, `ui:meshy09`, `ui:mp5k`, `ui:minigun`,
  `ui:setup`, `ui:campanhub` y `ui:brief` para revisar armas, diseños propios,
  selector de personaje, vista de campaña y briefing.

## Documentos clave

- [Índice de documentación](docs/README.md) — entrada limpia a toda la documentación vigente e histórica.
- [Arquitectura](docs/ARQUITECTURA.md) — módulos, flujo de partida, visor 3D y reglas de edición.
- [Auditoría global 3D](docs/auditoria_global_3d.md) — 338 OBJ, 0 sin caras, 0 NaN, 13 rigs.
- [Catálogo de habilidades del original](docs/Catalogo_habilidades_original.md) — las 52 con su estado.
- [Capturas 3D](docs/Capturas_3D.md) — los 13 mapas y las 6 misiones.
- [Equilibrio medido](docs/Equilibrio_medido.md) — cifras por modo×mapa.

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
index.html            HTML/CSS estatico y dos tags module (src/main.js, src/viewer/main.js)
src/                  JavaScript vivo en modulos ES (datos, core, audio, juego, render, UI, visor)
styles/               CSS estatico (theme, layout, game, viewer, cards)
assets/               mallas, texturas, audio, iconos y geometria de mapas
assets/competitive/   manifest y contenedores chars/, weapons/, anims/ para modelos .glb
bench/                verificacion y pruebas (VERIFICAR.ps1, rules, datos, tableros, harness)
docs/                 documentacion (indice en docs/README.md)
docs/historico/       planes y auditorias de sesiones anteriores
docs/capturas/        capturas locales generadas por _capture_all.mjs (ignoradas por Git)
tools/                reparacion y auditoria de assets
_capture_all.mjs      generador de capturas 3D
```

El material de referencia del IPA está en `_original/` (el `.ipa`, el zip y el
código descompilado). Los modelos, rigs, texturas, audio y mapas que usa el
juego están en `assets/`. Si hay que tirar del original, se tira directamente
del IPA y de `assets/`, no de una traducción descompilada intermedia. El
material de `_original/` es solo de consulta: no lo carga el juego en ejecución.
