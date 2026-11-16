# CSN — Chess Soldier Nation

Remake de RAD Soldiers (Splash Damage / WarChest, 2012), reconstruido desde cero como juego web por turnos en 2D y 3D: escuadras de soldados con roles y armas reales, modos Eliminación, Captura de baliza, Dominación y Escolta, 13 tableros (8 Skirmish del original y 5 nuevos) y campaña.

Repositorio privado: el juego incluye modelos, texturas y animaciones extraídos del original, cuyos servidores están apagados, como material de referencia para el remake.

## Contenido

- `index.html` — el juego completo, exportación autocontenida del artefacto web: incluye Three.js vendorizado, la malla y la textura del soldado y los mapas Skirmish_03 y Skirmish_04.
- `assets/soldier_clips.json` — los 22 clips de animación del soldado. Es el único asset que la exportación no incrusta; el juego lo carga en tiempo de ejecución desde `assets/soldier_clips.json`.
- `docs/` — documentos del proyecto: diseño del juego, arsenal real, referencia y estética del original, prompts de Argon, plan de operación y desarrollo continuo.

## Cómo jugar

Servir la carpeta con un servidor estático (por ejemplo `python3 -m http.server`) y abrir `http://localhost:8000`. Abrirlo directamente como archivo local no basta: la carga del JSON de animaciones no funciona desde `file://` en la mayoría de navegadores.

## Excluido a propósito

La extracción completa del IPA del original (assets de Splash Damage, más de 100 MB) no está en este repo. Tampoco los archivos internos de trabajo (`hidden_files`).
