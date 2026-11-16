# CSN — Chess Soldier Nation

Remake de RAD Soldiers (Splash Damage / WarChest, 2012), reconstruido desde cero como juego web por turnos en 2D y 3D: escuadras de soldados con roles y armas reales, modos Eliminación, Captura de baliza, Dominación y Escolta, 13 tableros (8 Skirmish del original y 5 nuevos) y campaña.

## Contenido

- `index.html` — el juego completo, exportación autocontenida del artefacto web: incluye Three.js vendorizado, la malla y la textura del soldado y los mapas Skirmish_03 y Skirmish_04.
- `assets/soldier_clips.json` — los 22 clips de animación del soldado. Es el único asset que la exportación no incrusta; el juego lo carga en tiempo de ejecución desde `assets/soldier_clips.json`.
- `docs/` — documentos del proyecto: diseño del juego, arsenal real, referencia y estética del original, prompts de Argon, plan de operación, desarrollo continuo y auditoría independiente.

## Cómo jugar

Servir la carpeta con un servidor estático (por ejemplo `python3 -m http.server`) y abrir `http://localhost:8000`. Abrirlo directamente como archivo local no basta: la carga del JSON de animaciones no funciona desde `file://` en la mayoría de navegadores.

## Aviso sobre los assets de referencia

El código y el dibujo de CSN son propios, pero `index.html` y `assets/soldier_clips.json` incrustan material extraído del IPA del original (malla y textura del soldado, geometría y texturas de Skirmish_03 y Skirmish_04, y los clips de animación) usado **solo como referencia medida**, propiedad de Splash Damage / WarChest. Ese material **no debe redistribuirse** y no puede licenciarse como propio.

## Excluido a propósito

La extracción completa del IPA del original (assets de Splash Damage, más de 100 MB) no está en este repo. Tampoco los archivos internos de trabajo (`hidden_files`) ni las claves de despliegue.

## Licencia

Sin licencia decidida por ahora (`all rights reserved`). La decisión sobre el código propio queda pendiente de Dani; los assets del original no son licenciables.
