# Catálogo de habilidades del original (52)

Fuente: nombres y iconos (`*_alpha`) de `GameData.assetbundle` del IPA.
Iconos extraídos en `assets/ui/ability/`.

| Nº | Habilidad (original) | Icono | Equivalente en CSN | Estado |
|---|---|---|---|---|
| 00 | Walkshoot | sí | — | pendiente |
| 01 | Adrenaline | sí | — | pendiente |
| 03 | AR Specialization | sí | — | pendiente |
| 04 | Armour Piercing | sí | — | pendiente |
| 05 | Backlash Aura | sí | Cobertura desplegable | implementada (equivalente) |
| 06 | Backstab | sí | — | pendiente |
| 07 | Caltrops | sí | Minas/claymore | implementada |
| 08 | Charm | sí | — | pendiente |
| 09 | Concussion Grenade | sí | Aturdidora M84 | implementada |
| 10 | Da Boot | sí | — | pendiente |
| 11 | Dead Eye Aura | sí | — | pendiente |
| 12 | Deployable Cover | sí | Cobertura desplegable | implementada |
| 13 | Detection Aura | sí | Barrido detector | implementada |
| 14 | Frag Grenade | sí | Granada M67 | implementada |
| 15 | Gas Grenade | sí | Granada de gas | implementada |
| 16 | Gatling Turret | sí | Torreta Gatling | pendiente (la torreta desplegable de CSN es M2 Browning, no Gatling) |
| 17 | Ghost | sí | Invisibilidad del Espía | implementada |
| 18 | Hack | sí | — | pendiente |
| 19 | Headshot | sí | Tiro a la cabeza | pendiente (documentado en el acta de Sneaky Pete; sin mecánica de crítico garantizado) |
| 20 | Healing Aura | sí | — | pendiente |
| 21 | Healing Grenade | sí | — | pendiente |
| 22 | Health Buff Aura | sí | — | pendiente |
| 23 | HMG Specialization | sí | Supresión | implementada |
| 24 | Juggernaut | sí | Escudo antidisturbios | implementada |
| 25 | Juggernaut Passive | sí | — | pendiente |
| 26 | Kinetic Animal | sí | — | pendiente |
| 27 | Landmines | sí | Minas | implementada |
| 28 | Last Stand | sí | — | pendiente |
| 29 | Last Stand Aura | sí | — | pendiente |
| 30 | Medkit | sí | Curación del Médico | implementada |
| 31 | Melee Specialization | sí | — | pendiente |
| 32 | Metabolism | sí | — | pendiente |
| 33 | Nail Mines | sí | Claymore M18A1 | implementada |
| 34 | Pistol Specialization | sí | — | pendiente |
| 35 | Remote Charge | sí | Carga remota C4 | pendiente (el C4 sigue como diseño del arsenal completo) |
| 36 | Revive | sí | Reanimación | parcial (cura a distancia) |
| 37 | Rocket Turret | sí | Torreta de cohetes | implementada |
| 38 | Rush Aura | sí | Teletransporte | implementada (equivalente) |
| 39 | Shotgun Specialization | sí | — | pendiente |
| 40 | Slayer | sí | — | pendiente |
| 41 | SMG Specialization | sí | — | pendiente |
| 42 | Sniper Rifle Specialization | sí | Tiro certero (Francotirador) | implementada |
| 43 | Support Fire | sí | Artillería | implementada |
| 44 | Swarm Aura | sí | Bomba de abejas | implementada |
| 45 | Toolkit | sí | Kit de herramientas | implementada |
| 46 | UAV | sí | UAV | pendiente (documentado como objeto en el visor; sin mecánica de dron explorador) |
| 47 | Vampire | sí | — | pendiente |
| 48 | Bazooka | sí | — | pendiente |
| 49 | Crossbow | sí | — | pendiente |
| 50 | Molotov | sí | Cóctel molotov | implementada |
| 51 | RiotShield | sí | Shield-O-Bot | pendiente (documentado como objeto en el visor; el escudo del juego es el del Comando, ver 24) |
| 52 | WaterCannon | sí | Cañón de agua | implementada |

## Resumen

- **Iconos**: 52 de 52 extraídos.
- **Implementadas o con equivalente**: 21.
- **Parcial**: 1 (36 Revive: la reanimación de CSN es adyacente, no a distancia).
- **Pendientes**: 30.

El juego marca 21 como «en juego» (ABILITY_IMPL): las 21 de la tabla salvo la 05 Backlash Aura, más la 36 Revive. La 05 figura como equivalente en la tabla, pero el juego no la marca: el equivalente directo de la cobertura desplegable es la 12 Deployable Cover.

## Nota

El original tenía además **auras** (Dead Eye, Detection, Healing, Health
Buff, Last Stand, Rush, Swarm, Backlash), **especializaciones de arma**
(AR, HMG, Pistol, Shotgun, SMG, Sniper, Melee) y **pasivas** (Adrenaline,
Armour Piercing, Juggernaut Passive, Kinetic Animal, Metabolism, Slayer,
Vampire). Son el catálogo natural para las siguientes fases: las auras ya
tienen base en el motor (buffs de turno), y las pasivas se pueden añadir
como bonus de personaje.
