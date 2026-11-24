# RAD Soldiers — versión Chrome 2014 (v1.0.8)

Esta es la versión más actualizada del juego original que se puede conseguir.
Es la build de Google Chrome v1.0.8, del 11 de diciembre de 2014, equivalente
a la última versión de iOS (v1.1.5, 10 de diciembre de 2014). Sustituye a la
v1.0.9 (enero de 2013) que había antes en `_original/`.

## Por qué esta versión

- Es un superconjunto de la v1.0.9 en contenido: trae los 17 personajes
  originales, los 8 mapas Skirmish y todas las armas, MÁS los dos personajes
  que faltaban (Tito Tesla y Tree Mendez, de Party in Rio, v1.1.0, abril 2013),
  los 6 mapas de Río (Beach, Favela, Old Town, Lapa, Centro, Construction),
  el Electri-Fryer y las mecánicas nuevas (Loot Crates, Quick Match, cartas).
- No se encontró IPA más nueva en ningún sitio ni APK (el juego solo salió
  para iOS y Chrome). Esta build de Chrome es la única copia más nueva que
  se puede descargar gratis.

## Contenido

- `resources.assets` (81 MB) y `sharedassets0-4.assets`: los datos del juego
  en formato Unity (mallas, texturas, animaciones, prefabs). Los cuerpos de
  Tito Tesla (interno `TommyTesla`) y Tree Mendez (interno `LeifTronksson`)
  están aquí, con sus Character, Avatar, Outfits, Audio y misiones Tryout.
  NOTA: `resources.assets` (81 MB) NO está en el repo porque la API de
  GitHub rechaza blobs tan grandes (422). Está en archive.org (el zip
  `rad-soldiers-unity3d-unpacked-quickbms.zip`, 90,1 MB) y en la copia local
  del proyecto. Los `sharedassets0-4.assets` sí están aquí.
- `Assembly-CSharp.dll`: el código del juego (lógica y mecánicas nuevas).
  El código descompilado está en `_original/rad-soldiers-assembly-csharp-decompiled.zip`.
- Fuente: https://archive.org/details/rad-soldiers (item subido el 11/09/2021
  desde una copia instalada de Chrome; los assets se desempaquetaron con
  QuickBMS). El zip original es `rad-soldiers-unity3d-unpacked-quickbms.zip`.

## Notas

- Los nombres internos son `TommyTesla` (Tito Tesla) y `LeifTronksson`
  (Tree Mendez). Las mallas llevan nombres genéricos (polySurface, pCube),
  no el nombre del personaje: para extraer el cuerpo exacto hay que seguir
  las referencias de sus Outfits.
- La economía cambió en v1.1.5 (se quitó RAD Bux, la tienda pasó a cartas
  coleccionables) y Chrome perdió el multijugador en diciembre de 2014.
  Esos cambios son de la capa de servicio en vivo, no del contenido ni de
  la lógica central del juego, que es la que usa el remake.
- Los servidores Fireteam están apagados: el juego ya no se puede jugar
  online ni comprar soldados dentro del juego. Para extraer assets no hace
  falta jugar.
