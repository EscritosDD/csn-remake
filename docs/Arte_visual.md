# Dirección de arte — CSN

Guía visual vigente. El juego usa mallas 3D, rigs, texturas, audio y geometría de mapas extraídos del IPA de RAD Soldiers, integrados en `assets/` por decisión expresa del autor (ver `README.md` §Aviso sobre los assets del original). Los SVG de Argon y los PNG sueltos de `files/arte/` quedan como referencia histórica, no como arte en uso.

## Estilo

El espíritu de RAD Soldiers: 3D estilizado, no dibujo plano. Soldados cabezones con volumen real, sombras suaves, texturas pintadas y colores saturados, cámara cenital inclinada (tres cuartos). Mapas urbanos con detalle (calles, trenes, coches, cajas, barreras y farolas) con la cuadrícula marcada en el suelo. Bajo cada soldado, un anillo de color: azul aliado, rojo rival. Cada soldado debe leerse en una casilla pequeña: silueta clara, arma visible y rol reconocible a golpe de vista.

## Paleta

- **Skin Estándar:** verde oliva, chaleco táctico oscuro, casco oliva, sin emblema.
- **Skin de Nación:** colores de la bandera de la nación, con su escudo militar como distintivo.
- **Bandos:** el jugador en azul, el rival en rojo, para que el turno sea legible siempre.

## Material en uso

- `assets/soldier/`: 7 mallas por clase con rig, textura y escala; 5 diseños propios jugables se añaden desde `assets/personajes_propios/`.
- `assets/maps/`: geometría y atlas de los 8 Skirmish reales del IPA, más mapas propios.
- `assets/weapons/`: 23 mallas y sus carátulas para la Armería.
- `assets/ui/`: retratos, iconos de nación, habilidad y HUD del original.
- `assets/audio/`: armas, voces, ambiente, música y habilidades.

## Interfaz

La interfaz es CSS (consistente, responsive y con estados normal/hover/pulsado). Los botones y paneles PNG conservados en `assets/ui/` son referencia, no se aplican como 9-slice para no romper la legibilidad en pantallas pequeñas. El estado se expresa con iconos tipográficos coherentes (aturdido, invisible, vigilancia, suprimido, escudo, herido, granada, humo, aturdidora, claymore, cobertura, kit, teletransporte, barrido). No requiere assets y escala con el texto.

Las pantallas de carga y fin de partida usan el logo y el arte del modo ya integrados en `assets/ui/`.

## Referencia histórica

Los borradores de interfaz generados con IA (`image_13b112b1.png`, `image_26054cf1.png`, `image_5061c313.png`) y el primer SVG de Argon se conservan solo como referencia de dirección de arte; no se cargan en la portada para no despistar al jugador. Si alguna de esas pantallas se quiere recuperar, se integra de forma explícita.
