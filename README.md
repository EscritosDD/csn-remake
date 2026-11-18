# CSN — Chess Soldier Nation

Remake jugable de **RAD Soldiers** (Splash Damage / WarChest, 2012) como juego
web por turnos, **en 3D como el original**: escuadras de soldados con roles y
armas reales, modos Eliminación, Captura de baliza, Dominación, Escolta y
guerra por naciones, 13 tableros (8 Skirmish con geometría real del IPA y 5
propios) y una campaña de 6 misiones.

## Cómo jugar

- En Windows: doble clic en `D:\Juegos\CSN\JUGAR.bat` (levanta el servidor y
  abre el navegador).
- O servir la carpeta con un estático y abrir `http://127.0.0.1:8000`:

```
python -m http.server 8000 --bind 127.0.0.1
```

No vale abrirlo como archivo (`file://`): el juego carga assets por HTTP.

## Verificar que todo está sano

```
powershell -ExecutionPolicy Bypass -File bench\bench/VERIFICAR.ps1
```

Hace cinco comprobaciones y devuelve 0 si todo pasa: sintaxis del script,
13 tableros (simetría y solapes), reglas del motor (`rules.test.js`),
integridad de datos (`data.test.js`) y humo 3D en navegador con captura.

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
| `referencia_original/` | Código descompilado y datos del original (solo lectura, referencia para desarrollo). |

## Herramientas de medida

- **Balance**: `node bench/harness.js <modo> <mapa> <partidas> <formato 4>`
  (Eliminación, Baliza, Dominación, Escolta). Resultados en
  `docs/Equilibrio_medido.md` (muestras de n≥30).
- **Capturas**: `node _capture_all.mjs <mapa|campana:N> <prefijo> [ms]`.
  Captura en 3D y solo baja a 2D si la 3D no arranca.

## Documentos clave

- [Arquitectura](docs/ARQUITECTURA.md) — estructura, funciones con su línea y reglas de edición.
- [Plan director](docs/§§docs/historico/Plan_director_original_base.md) — fases, criterios y estado.
- [Catálogo de habilidades del original](docs/Catalogo_habilidades_original.md) — las 44 con su estado.
- [Capturas 3D](docs/Capturas_3D.md) — los 13 mapas y las 6 misiones.
- [Equilibrio medido](docs/Equilibrio_medido.md) — cifras por modo×mapa.
- [Informe CSN vs original](docs/Informe_CSN_vs_original.md) — 16 áreas con fuentes.

## Aviso sobre los assets del original

El código y el arte propio de CSN son de Dani. El repositorio **incluye
material extraído del IPA de RAD Soldiers** (modelos, texturas, audio, mapas,
arte de la portada y logo) por permiso expreso del autor **solo para
desarrollo**. Ese material es propiedad de Splash Damage / WarChest: **no se
puede redistribuir ni licenciar** y deberá sustituirse por arte propio antes
de cualquier publicación.

## Licencia

Sin licencia decidida por ahora (`all rights reserved`). La decisión sobre el
código propio queda pendiente de Dani; los assets del original no son
licenciables.


## Estructura del repositorio

```
index.html            el juego completo (un solo archivo)
assets/               mallas, texturas, audio, iconos y geometria de mapas
bench/                verificacion y pruebas (VERIFICAR.ps1, rules, datos, tableros, harness)
docs/                 documentacion (indice en docs/README.md)
docs/historico/       planes y auditorias de sesiones anteriores
tools/                utilidades sueltas (servidor node, package.json)
_capture_all.mjs      generador de capturas 3D
```

El material de referencia del IPA está en `referencia_original/` (código descompilado del
original y datos de animaciones/prefabs). Es solo lectura y no lo usa el juego en ejecución.
