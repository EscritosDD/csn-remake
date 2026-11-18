> **Nota de alcance:** las fuentes citadas (`referencia_original/decompiled`, `referencia_original/datos`) viven **fuera del repositorio**, en `D:\Juegos\CSN\_referencia_original`, para no versionar 1.625 archivos de material de referencia que el juego no usa.

# Informe CSN contra el original, punto por punto

Fecha: 18 nov 2026. Encargo pendiente de la lista de Gemini Studio: informe
completo con tres columnas (original · CSN · qué falta o falla) y **fuente
por fila**.

**Fuentes**: `referencia_original/decompiled/*.cs` (1.578 archivos del
original), `referencia_original/datos/` (rigs, prefabs, materiales, 41
animaciones), `docs/§§docs/historico/Referencia_original.md` (auditoría con cada dato y su
archivo), `docs/Estetica_original.md`, el propio `index.html` de CSN, el
harness (`bench/`) y las mediciones de `docs/Equilibrio_medido.md`.
Cuando un dato del original no se pudo verificar (código ofuscado o
paquetes UnityWeb sin desempaquetar) la fila lo dice; no se inventa nada.

---

## 1. Turnos y determinismo

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| Se juega un bando entero y luego el otro; estado del turno con equipo activo, semilla, unidades y acciones | Igual: `endTurn` pasa el turno completo al otro bando | — | `TacticsGameStateTurnData.cs` · `index.html` `endTurn()` |
| Azar determinista por semilla de turno (`StartSeed`, `Seed`) | `rng()` sembrado por turno; el harness reproduce partidas | — | `TacticsGameStateTurnData.cs` · `index.html` `rng()` |
| Partida asíncrona por servidor con turnos en JSON | Sin servidor; todo local | **Falla por diseño**: no hay asíncrono ni PvP online | `TacticsGameStateData.cs` |
| Semilla de despliegue por equipo (`AIDeployComponent`) | Despliegue fijo por casillas `SPAWNS_A/B` | Sin despliegue libre al desplegar | `AIDeployComponent.cs` · `index.html` `SPAWNS_A/B` |

## 2. Energía y cuerpos

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| Vida 200/250/300 y energía 12/14/18 con coste por casilla 1/2/3 según cuerpo ligero/medio/pesado | **Coincide exacto**: `BODIES` ligero 200/12/1, medio 250/14/2, pesado 300/18/3 | — | `UnitBodyType.cs` · `index.html` `BODIES` |
| Una sola reserva de energía por soldado y turno para mover, disparar y usar especiales | Igual | — | `UnitBodyType.cs` · `index.html` `spendEnergy()` |
| El estado de turno guarda casilla, energía, vida, equipo y **dirección de mira** (4 cardinales) | Casilla, energía, vida y equipo sí; la dirección se dibuja (`facing`) pero **no afecta a reglas** | Falla parcial: orientación solo visual | `UnitTurnDataJson.cs` · `index.html` `u.facing` |

## 3. Victoria y modos

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| Eliminación: aniquilar al rival | Sí | — | `TacticsGameStateTurnData.cs` · `index.html` `checkWin()` |
| Captura: aguantar la zona **5 turnos**; bandera con colores de equipo y sonidos propios | Baliza a 5 turnos (`checkBeaconAtTurnEnd`, motivo «Baliza aguantada durante 5 turnos»); zona con anillo | Falta el sonido de captura por bando | `ControlPointManagerComponent.cs` · `index.html` `checkWin()` |
| Modos del original: Eliminación y Captura (2 confirmados), niveles de un jugador (`SinglePlayerOnly`) | 5 modos: eliminación, baliza, **dominación**, **escolta** y **campaña** | Dominación, Escolta y Campaña son añadidos propios, no del original | `BuildManifestLevelData.cs` · `index.html` `effMode()` |
| **Dominación no está confirmada** en el material leído | Existe y está medida (ver §13 de este informe) | Añadido propio (decisión de diseño) | `docs/§§docs/historico/Referencia_original.md` §1 |
| El original tenía los modos de la lista de niveles descargados del servidor | El jugador elige modo, mapa, formato y roles en la configuración | — | `BuildManifestMapPackData.cs` · `index.html` pantalla de configuración |

## 4. Cobertura, visión y orientación

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| Cobertura **direccional de 4 niveles** por borde de casilla, precalculada para todos los pares atacante-defensor (`CoverMap`, 2 bits por par) | `coverLevel` direccional 0-3 y `isFlanked` (probado en la suite: «coverLevel directional levels (0/1/2/3) and isFlanked») | Falla la parte de **precálculo**: CSN lo calcula al vuelo; el original usaba matrices al cargar el nivel | `GameTileComponent.cs` · `CoverMap.cs` · `bench/rules.test.js` |
| Solo el nivel máximo de cobertura **bloquea la visión**; el resto protege sin cortar la línea | `hasLOS` corta por muros y humo; la cobertura reduce daño/puntería | Ajustar a la regla exacta del original (nivel 3 bloquea la visión) | `GameTileComponent.cs` · `index.html` `hasLOS()` |
| Visibilidad con mapa precalculado aparte de la cobertura (`VisibilityMap`) | Un solo `hasLOS` al vuelo | Sin mapa de visibilidad precalculado | `VisibilityMap.cs` · `index.html` `hasLOS()` |
| Luz y visión térmica por habilidad (`ThermalVisionRange`) | No existe | **Falta**: visión térmica como habilidad | `AbilityGameplayData.cs` |

## 5. Daño y combate

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| Daño con mínimo + dispersión + puntería + probabilidad de crítico (escala por datos) | Daño con variación 0,85-1,15, puntería `hitChance`, crítico 15 % ×1,5, caída por distancia | — | `WeaponGameplayData.cs` · `index.html` `tryShoot()` |
| Caída de daño por curva según distancia/alcance | `falloffFactor` | Curva propia, no la tabla del original | `WeaponFalloffCurve.cs` · `index.html` `falloffFactor()` |
| **Fuego de respuesta** en todas las armas por defecto (`AllowsReturnFire`) | Existe: respuesta gratis con −20 de puntería y daño ×0,6 | Falla el valor exacto (`ReturnFireDamageScale` no verificable) | `WeaponGameplayData.cs` · `index.html` `tryShoot()` rama de respuesta |
| **Fuego de reacción (vigilancia)** por habilidad (`MaxOpFirePerTurn`) | Vigilancia global (22 referencias en el código) | La del original era por habilidad con cupo; CSN es global | `AbilityGameplayData.cs` · `index.html` `overwatch` |
| **Empujón** al impactar (`KnockbackDistance`, rango 1) | No existe | **Falta** (arma y granadas) | `WeaponGameplayData.cs` |
| Modos de disparo: ligero, pesado, ráfaga, hombro, minigun, lanzar; posturas 1H/2H/melee | Armas por categoría con silueta propia; clip de disparo por tipo | Sin los 5 modos del original (sí hay animación por categoría) | `UnitWeapon.cs` · `index.html` `fireClipFor()` |
| Tipos de daño: bala, explosión (2), incapacitación (2), melee; muerte e impacto según tipo | Impacto/muerte por tipo (bala, explosión, ráfaga) | Falta la distinción de transmisión de daño (`Disable`) | `UnitWeapon.cs` · `index.html` `damage()` `_hitKind` |

## 6. Personajes

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| **Personajes con nombre** (10): Hipster Dave, Sneaky Pete, Sister Florence, Archie Fletcher, Ivan Tkilya, Mme La Hacque, Soap, Riot Medic, Big Time Taschmann, Megan McNick, con voz, biografía y traje propio | 7 roles genéricos (Francotirador, Artillero, Espía, Médico, Ingeniero, Comando, Capitán) | **Falta**: personajes con nombre y personalidad (F8) | `BuildManifestCharacterData.cs` · `index.html` `ROLES` |
| Cada personaje: arma por defecto, voz, traje, nivel de desbloqueo y misión de prueba | Rol con arma por defecto y traje por nación | Falta desbloqueo por nivel y misiones de prueba | `BuildManifestCharacterData.cs` · `index.html` `ROLES` |
| Clases del original: **Medic, Engineer, Agent** confirmadas; Commando y Captain no verificados; total de clases **no verificable** | 7 roles definidos | CSN amplía a 7 (decisión propia); el original no confirma 7 | `UnitClass.cs` · `index.html` `ROLES` |
| Bonificaciones (buffs) por soldado con tipo y duración | Supresión (−energía), reanimación, orden de mando | Sin lista de buffs con duración (parcial) | `UnitTurnDataJson.cs` · `index.html` `u.suppressed` |

## 7. Habilidades (28 del original)

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| **28 habilidades** con parámetros completos (`RequiredAP`, `MaxUses`, alcance, radio, `HealAmount`, `TickDamage`, `Duration`, `BuffType`…) | **7 especiales de rol** + **14 habilidades nuevas de F4** (cobertura desplegable, granada de gas, barrido detector, molotov, caja de salud, teletransporte, escudo antidisturbios, artilleria, bomba de abejas, tranquilizante, canon de agua, kit de herramientas, torreta de cohetes y laser orbital) + 5 lanzables/colocables previos (humo, claymore, aturdidora, minas, torreta M2) | **Quedan 4 sin equivalente directo** (carga remota, UAV, torreta Gatling, ballesta explosiva), cubiertas funcionalmente por claymore+artilleria, barrido, torreta M2 y fusiles; tambien cajas de municion/analgesicos/espiritu ya como botin de partida | `AbilityGameplayData.cs` · `docs/§§docs/historico/Referencia_original.md` §2 · `index.html` (F4: `throwGas`, `placeCover`, `sweepDetect`, `throwMolotov`, `placeHealthCrate`, `teleportUnit`, `useShield`, `fireArtillery`, `throwBees`, `throwTranq`, `waterCannon`, `useToolkit`, `fireOrbital`, `deployTurret(...,'rocket')`) |
| Cajas de habilidad (salud, munición de alta velocidad, analgésicos, espíritu de equipo) | Botiquines fijos + cajas de botín de la partida | Falta la habilidad de colocar cajas | `AbilityGameplayData.cs` |
| Habilidades de comandante aparte (Capitán con habilidades propias) | «Orden de mando» del Capitán (+3 ⚡ a un aliado) | Falta la selección de habilidades de comandante | `CommanderAbilitySelectionScreenHandler.cs` · `index.html` `useSpecial()` |

## 8. Armas

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| Esquema completo: `MinDamage`/`DamageSpread`, `Accuracy`, `CritChance`, `SplashRange`, `LineRange`, `ShotsPerAttack`, `MaxUses`, caída, empuje, puntos de escuadra, `TwoStageAttack` | 29 armas reales con daño, alcance, coste, categoría y nota histórica | Falta `SplashRange` por arma (salpicadura genérica), empuje y ataque en dos fases | `WeaponGameplayData.cs` · `index.html` `WEAPONS` |
| Armas ficticias con nombres propios | Armas reales verificadas (M4A1, M9, M40, M67, M84…) | Cambio central del remake (decisión propia) | `docs/Arsenal_real.md` |
| Números por arma **no verificables** (paquetes UnityWeb sin desempaquetar) | Números propios documentados | No se puede comparar cifra a cifra | `docs/§§docs/historico/Referencia_original.md` §3 |

## 9. Puntos de escuadra

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| Cada arma/habilidad cuesta puntos; topes separados por nivel de emparejamiento (`MaxUnitSquadPoints`, `MaxAbilitySquadPoints`, `MinOwnedUnits`) | Formato de partida (2/4/5 por bando) sin puntos por pieza | **Falta** el sistema de puntos y los niveles de emparejamiento | `SquadPointsTierEntry.cs` · `index.html` `setup.fmt` |

## 10. Botín y objetos del mapa

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| Caja de botín en un turno programado (`LootDropTurn`) con 4 tipos | «Caja de botín» que cae a mitad de partida (rondas 3 y 6) | Parcial: tipos propios (cura/energía/granada), no los 4 del original | `TacticsSessionStateData.cs` · `index.html` `maybeDropLoot()` |
| Baliza con 5 bonificaciones (salud, munición de alta velocidad, analgésicos, espíritu, barrido) | Baliza = zona de captura | Falta la baliza como objeto que da bonificaciones | `BeaconGameObjectComponent.cs` |
| Torretas Gatling y de cohetes, minas y cobertura desplegables | Torreta capturable central + torreta M2 desplegada + claymore + minas | Falta la Gatling y la torreta de cohetes | `AbilityGameplayData.cs` |
| Cajas de mapa (4 tipos) con modelo y efectos | Botiquines + barriles + cajas de cobertura | Falta munición/analgésicos/espíritu | `CrateGameObjectComponent.cs` · `index.html` `G.map.obstacles` |

## 11. Mapas y cuadrícula

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| Cuadrícula con `SizeX`/`SizeY` por nivel; **tamaño real no verificable** (niveles descargados del servidor) | 13 tableros de 12×12 | El 12×12 de CSN es estimación, no dato del original | `GameGridComponent.cs` · `index.html` `MAP_DEFS` |
| Casilla 1×1 unidad, altura en pasos de 1/32; distancia en Chebyshev | Casilla 1×1, distancia Chebyshev (`cheb`) | — | `GameGridComponent.cs` · `index.html` `cheb()` |
| Mapas con geometría, iluminación, audio, efectos, cobertura y lightmaps por nivel | 8 mapas con **geometría real del IPA** (S03/04/05/06/08/09/10/11) + 5 de código | Faltan lightmaps/audio por mapa; S1/S2/S7 sin geometría original | `BuildManifestLevelData.cs` · `index.html` `SKIRMISH_GEO` |

## 12. Cámara

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| Pitch 40-60°, distancia 6-11, FOV 30-45°, yaw 335°, zoom interno `0,7×z+0,15`, seguimiento de unidad, sacudida al disparar | Implementado con esas cifras; giro Q/E, zoom +/−, reset C, sacudida | Faltan los muelles de borde y el arrastre con inercia | `CameraController.cs` · `index.html` `setViewMode()` y `__render3D` |

## 13. IA

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| Usa mapas precalculados de cobertura y visibilidad; el cerebro es código ofuscado (**no verificable**) | IA propia: objetivos por modo, cobertura, humo, minas, granadas, escolta del dron, dificultad recluta/normal/veterano/élite | Sin comparación posible (el original no es legible); **medida** en `docs/Equilibrio_medido.md` | `GameGridComponent.cs` (`InitAI`) · `index.html` `aiUnitAct()` |

## 14. Interfaz y presentación

| Original | CSN | Falta / falla | Fuente |
|---|---|---|---|
| Menús de barracas, selección de escuadra, tienda, retratos, HUD con vida/energía y bocadillos de tutorial | Portada con modos, configuración, HUD con retratos (7), barras, registro, deshacer, vista 3D/clásica | Faltan: menú PLAY ONLINE/CHALLENGES/EXPANSIONS/QUICK GAME, monedas, tienda, bocadillos de tutorial con botones (F6/F7 del plan) | `BaseMenuHandler.cs`, `GameTitleScreenHandler.cs`, `TutorialTextBubble.cs` · `index.html` |
| Animaciones: 390 en los assets, 41 en `datos/` | 22 clips del IPA + animaciones procedurales | Faltan clips propios para habilidades nuevas | `referencia_original/datos/` · `assets/soldier_clips.json` |
| Audio: 132 clips, 75 fuentes, shaders de audio por arma y unidad | Efectos sintetizados (WebAudio) | **Falta** audio propio por arma/unidad/voz | `UnityCacheGroup.cs` · `index.html` `sfx()` |
| Escala de crítico y respuesta por datos del servidor | Crítico ×1,5 y respuesta ×0,6 fijos | Valores no verificables en el original | `GenericGameplayData.cs` |

## 15. Resumen de lo que falta (priorizado)

1. **~16 habilidades** del catálogo de 28 (con sus parámetros) — F4.
2. **Personajes con nombre** (10) con personalidad, voz y traje — F4/F8.
3. **Menú del original** (PLAY ONLINE, CHALLENGES, EXPANSIONS, QUICK GAME,
   monedas) y bocadillos de tutorial — F6.
4. **Sistema de puntos de escuadra** y niveles de emparejamiento — F4.
5. **Empujón**, visión térmica, cajas de habilidad y bonificaciones de la
   baliza — F4.
6. **Audio propio** por arma/unidad y lightmaps por mapa — F5/F7.
7. **Orientación de mira con efecto en reglas** (no solo visual).

## 16. Lo que el original no tenía y CSN sí (decidido, no error)

- 7 roles con Francotirador y Artillero separados, y Capitán con orden.
- Arsenal real de 29 armas con datos históricos.
- Barriles explosivos, torreta capturable, puertas, C4, minas claymore.
- Naciones (12) y Guerra de Naciones.
- Modos Dominación, Escolta y Campaña (propios).
- Vista clásica 2D y vista 3D intercambiables.
