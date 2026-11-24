# Cuerpos y rigs pendientes del IPA v1.0.9

## Tree Mendez y Tito Tesla: no están en este IPA

El IPA v1.0.9 (enero de 2013) no contiene las mallas de **Tree Mendez** ni de **Tito Tesla**. Ambos personajes llegaron con la expansión *Party in Rio* (abril de 2013), posterior a este IPA. No se han creado ni aproximado sus cuerpos: hacerlo sería inventar geometría y pesos que no existen en la fuente original.

Evidencia de la búsqueda:

- Se recorrieron los **72 `.assetbundle`** de `_original/ipa/Payload/radtactics.app/Data/Raw` con UnityPy (**12.021 objetos con nombre**). No aparece ningún `GameObject`, `Mesh`, `SkinnedMeshRenderer` ni `AnimationClip` con `Tree`, `Mendez`, `TreeMendez`, `Tito`, `Tesla` o `TommyTesla`.
- Los únicos restos relacionados están en `Characters.assetbundle` y son solo arte de interfaz: el material `LeifTronkssonIcon` (prototipo sin malla), los materiales `TommyTeslaIcon` y las texturas `char-tommy_tesla` / `char-tommy_tesla_alpha` (retrato). No hay cuerpo ni rig asociado.
- La búsqueda de `mendez`, `tommytesla`, `tesla` y `tito` en los **1.578 `.cs`** descompilados de `_original/decompiled` dio **0 coincidencias**. Las menciones que existen en el repo (`src/data/cast.js`, `docs/`, tests) son referencias de diseño, no assets originales.

Por tanto se conservan las asignaciones actuales, sin tocar `src/data/cast.js`:

- **Tree Mendez**: `Soldier_Heavy` + skin `Soldier_Heavy_Veteran_d.png` (oscuro).
- **Tito Tesla**: `Agent_Light` + skin `Agent_light_Veteran_d.png` (masculina).

Para darles cuerpo propio hace falta un **IPA v1.1.0 o superior (Party in Rio)** que incluya sus mallas y rigs, o bien modelarlos a mano como assets nuevos, diferenciándolos claramente de los originales.

## Rigs generados en esta tarea

Se generaron los `_rig.json` de los seis cuerpos del IPA v1.0.9 que aún no animaban: `Agent`, `Agent_Heavy`, `Engineer`, `Medic`, `Medic_therapist_959v` y `Soldier_Light`. Los clavicles ausentes de `Agent` y `Agent_Heavy` se derivan del transform real del IPA (padre del hueso UpperArm), sin asignarles pesos inventados; los `gunBone_L` / `gunBone_R` de los médicos se remapean a la mano correspondiente conservando la suma de pesos. Los seis comparten el orden de 20 huesos de `assets/soldier_clips.json` y animan con clips en el visor.
