> **Nota de alcance:** este documento es histórico. Cita arte y material del original que vive fuera del repositorio (carpeta `_original/`), y capturas que no se guardan aquí por tamaño. No son enlaces rotos: son referencias al material de trabajo local.
>
> `referencia_original/` ya no existe: si hay que tirar del original, se tira
> directamente del IPA en `_original/` y de los modelos, rigs, texturas, audio y
> mapas extraídos en `assets/`.

# Referencia del RAD Soldiers original — auditoría para CSN

Documento de referencia para el remake CSN, sacado del código descompilado del juego original (Assembly-CSharp, build de Unity 4.2, Chrome/iOS 2014) y de sus archivos `.assets`. No es una copia: el arte y el código de CSN siguen siendo originales por decisión del proyecto. Esto sirve para que los números y las estructuras de CSN se acerquen a los reales donde convenga.

**Fuentes usadas:** `hidden_files/original/decompiled/` (528 archivos `.cs`) y `hidden_files/original/rad-soldiers-unity3d-unpacked-quickbms.zip` (level0-3, mainData, resources.assets y sharedassets0-4.assets), leídos con UnityPy 1.25.4. Cada dato cita su archivo `.cs` o su archivo de assets.

**Límites de esta auditoría (léelo antes de fiarte de un número):**
- Gran parte de la lógica del juego está en clases ofuscadas (espacios de nombres `딶`, `땃`, `딢`, `딧`): los nombres de métodos, campos y miembros de enum son símbolos sin sentido (`딟`, `땄`...). Se puede leer la estructura, pero no siempre el significado exacto de cada valor.
- Los datos numéricos de armas, habilidades, personajes y niveles **no están** en los `.assets` que se pudieron leer: viven en paquetes UnityWeb (formato Unity 4.2) incrustados como TextAssets (`Characters`, `Weapons03`, `Weapons05`, `Abilities02`, `MapPacks`, `AtlasPack02`), que no se pudieron desempaquetar con las herramientas disponibles (UnityPy no admite ese formato antiguo, no hay Java para disunity y la descompresión LZMA directa falla). Donde un número no se pudo verificar, el documento lo dice.
- Los mapas de batalla no están en el archivo: los niveles se descargaban del servidor como paquetes (`BuildManifestLevelData.cs`), y aquí solo hay level0-3, que son las escenas de menú/cuartel, HUD, resultados y tutorial.
- El juego original no se puede ejecutar: los servidores Fireteam están apagados y la build de Chrome es NaCl, no ejecutable en Chrome moderno.

---

## 1. Reglas de juego

### Turnos

- Juega un bando entero y luego el otro, como en el ajedrez. El estado de cada turno guarda el equipo activo (`ActiveTeam`), la semilla aleatoria del turno (`StartSeed`, `Seed`), el valor de clasificación (`RatingValue`), las unidades y las acciones realizadas (`TacticsGameStateTurnData.cs`).
- La partida es asíncrona por servidor: el estado completo se guarda como JSON (`TacticsGameStateData.cs`: `Session` + `Turns[]`, que son los turnos ya jugados en formato texto). Cada turno lleva sus acciones, así que el rival puede reproducir la partida.
- **La aleatoriedad es determinista por semilla**: cada turno tiene su `Seed`, así que el daño, la puntería y los críticos se calculan igual en los dos dispositivos (`TacticsGameStateTurnData.cs`). No hay dados ocultos sin semilla: el azar existe, pero es reproducible.

### Energía (puntos de acción) y movimiento

La energía no es por rol, es por **tipo de cuerpo** (`UnitBodyType.cs`, valores reales leídos de los assets en `sharedassets0.assets`):

| Tipo de cuerpo | Vida máxima (`MaxHealth`) | Energía por turno (`BasicActionPoints`) | Coste por casilla (`ActionPointsPerMove`) | Casillas por turno a pleno |
|---|---|---|---|---|
| Ligero (`LightBodyType`, id `...bodytypes.light`) | 200 | 12 | 1 | 12 |
| Medio (`MediumBodyType`, id `...bodytypes.medium`) | 250 | 14 | 2 | 7 |
| Pesado (`HeavyBodyType`, id `...bodytypes.heavy`) | 300 | 18 | 3 | 6 |
| Tutorial (`TutorialBodyType`, id `...bodytypes.tutorial`) | 325 | 14 | 2 | 7 |

- Moverse una casilla cuesta 1, 2 o 3 de energía según el cuerpo, no 1 fijo (`UnitBodyType.cs`). Esto es exactamente lo que recordaba Dani: el pesado tiene 18 de energía pero gasta 3 por casilla, así que anda 6 casillas; el ligero tiene 12 y gasta 1, así que anda 12.
- Disparar cuesta lo que indique el arma (`RequiredActionPoints`, `WeaponGameplayData.cs`); usar una habilidad cuesta su `RequiredAP` (`AbilityGameplayData.cs`). La energía es una sola reserva por soldado y turno para moverse, disparar y usar especiales.
- El estado de cada soldado en cada turno guarda: casilla (`TileX`, `TileY`), energía restante (`ActionPoints`), vida (`Health`), equipo (`TeamIndex`), **dirección a la que mira** (`Direction`, 4 direcciones cardinales) y sus bonificaciones activas (`Buffs[]`) (`UnitTurnDataJson.cs`).
- Cada soldado tiene dirección de mira (norte/sur/este/oeste). El código no deja claro si la dirección afecta a la puntería o al daño; solo consta que existe y se guarda en cada turno (`UnitTurnDataJson.cs`, enum `딢.딯` con 4 valores).

### Victoria

- **Eliminación**: se gana eliminando a toda la escuadra enemiga (modo clásico; la condición se evalúa sobre el estado de las unidades, `TacticsGameStateTurnData.cs`).
- **Captura y aguante (baliza)**: hay que aguantar la zona **5 turnos** seguidos. Literal en el código: `TurnsToCaptureZone = 5` (`ControlPointManagerComponent.cs`). La zona tiene una bandera con los colores de los equipos (azul y rojo, `ControlPointObjectiveComponent.cs`) y sonidos distintos para cuando entra tu equipo, el rival o los dos a la vez.
- La zona de captura es un índice de zona (`CaptureZone`, `ControlPointComponent.cs`); los puntos de aparición guardan su distancia precalculada a la zona (`DistanceToControlPoint`, `SpawnPointComponent.cs`).

### Puntos de escuadra (presupuesto)

- Cada arma cuesta puntos de escuadra (`SquadPoints`, por defecto 3, `WeaponGameplayData.cs`). Cada habilidad también cuesta puntos.
- Por nivel de emparejamiento (`Tier`) hay topes: puntos máximos para unidades (`MaxUnitSquadPoints`), puntos máximos para habilidades (`MaxAbilitySquadPoints`) y unidades mínimas en propiedad (`MinOwnedUnits`) (`SquadPointsTierEntry.cs`). El nivel de emparejamiento de la partida se guarda en la sesión (`MatchMakingTier`, `FireTeamTurnBasedSessionAttributes.cs`).
- La sesión de partida guarda: versión, id de nivel, id de subnivel, **tamaño de ejército** (`ArmySize`), invitado, nivel de emparejamiento y nombre (`FireTeamTurnBasedSessionAttributes.cs`). El tamaño de ejército es un campo de la sesión, no una constante del código: el formato 5 contra 5 es el clásico, pero el tamaño se elige al crear la partida.

### Cajas de botín durante la partida

- La sesión guarda un `LootDropTurn`: en un turno determinado de la partida cae una caja de botín (`TacticsSessionStateData.cs`, `GlobalAppState.cs` con `LootDropPrefabId`). Hay 4 tipos de caja con nombre propio: Salud, Munición mejorada, Analgésicos y Espíritu de equipo (`Health CrateName`, `ImprovedAmmoCrateName`, `PainKillerCrateName`, `TeamSpiritCrateName` en los datos de localización).

### Otras reglas

- Límite de partidas simultáneas por cuenta (`MaxConcurrentGames`, `TacticsBuildManifestDataJson.cs`; el valor concreto no está en el código, venía del servidor). No afecta al remake sin servidor.
- Doble clic en una casilla confirma la acción; un clic la selecciona (`GameTileComponent.cs`). Mantener pulsado sobre una casilla (`OnHoldStart`/`OnHoldStop`) dispara una acción de apuntado en el código original (`GameTileComponent.cs`); su efecto exacto está en código ofuscado.

---

## 2. Personajes

### Estructura de un personaje

Cada personaje jugable se define por (`UnitClass.cs`, `UnitCharacterData.cs`):
- Nombre, nombre por defecto, biografía y texto de ambientación (localizables).
- `BodyTypeId`: ligero, medio o pesado (lo que fija vida, energía y coste de movimiento; ver §1).
- `ClassType`: la clase/rol (enum ofuscado, número de clases no verificable en el código).
- `Abilities[]`: sus habilidades.
- `SupportedWeaponCategories[]`: las categorías de arma que puede usar.
- `Gender`, icono de interfaz e icono de personaje.
- Cada soldado concreto en una partida guarda: arma (`WeaponId`), traje (`OutfitId`), personaje (`CharacterId`), experiencia (`XP`), nombre, id único y habilidades elegidas (`SelectedAbilities[]`) (`UnitCharacterData.cs`).

### Roles (clases)

El diseño actual de CSN lista 5 clases del original (Médico, Ingeniero, Comando, Capitán, Agente). En el código descompilado solo se confirman por nombre tres: `Medic`, `Engineer` y `Agent` (entradas de localización). `Commando` y `Captain` no aparecen como entradas de localización en los assets leídos, así que su nombre exacto en el original no queda verificado aquí (pueden vivir en los paquetes UnityWeb sin desempaquetar). **No se puede confirmar desde el código cuántas clases había en total.**

### Personajes con nombre (coleccionables)

El original no tenía soldados genéricos: tenía personajes con nombre, voz, biografía y trajes propios. Los paquetes de datos de personaje que hay en `resources.assets` son (nombres de TextAsset):
Hipster Dave, Sneaky Pete, Sister Florence, Archie Fletcher, Ivan Tkilya, Mme La Hacque, Soap, Riot Medic, Big Time Taschmann, Megan McNick (más un paquete de trajes de Halloween). Cada personaje trae su arma por defecto (`DefaultWeaponId`), su paquete de voz (`VoicePackId`), su traje por defecto (`DefaultOutfitId`), el nivel necesario para desbloquearlo (`LevelRequired`) y una misión de prueba (`TryoutMissionId`) (`BuildManifestCharacterData.cs`). Los personajes y las armas se desbloqueaban por nivel de jugador (`LevelRequired`).

### Habilidades: lista real (28)

Nombres sacados de las entradas de localización de los assets (no del código ofuscado, que no conserva los nombres):

Artillería (`Artillery`), Bomba de abejas (`BeeBomb`), Granada de concusión (`ConcGrenade`), Cobertura desplegable (`DeployableCover`), Mina desplegable (`DeployableMine`), Barrido detector (`DetectoSweep`), Ballesta explosiva (`ExplosiveCrossbow`), Granada de gas (`GasGrenade`), Torreta Gatling (`GatlingTurret`), Fantasma (`Ghost`, invisibilidad), Granada (`Grenade`), Tiro a la cabeza (`Headshot`), Caja de salud (`HealthCrate`), Caja de munición de alta velocidad (`HighVelocityAmmoCrate`), Botiquín (`Medkit`), Cóctel molotov (`MolotovCocktail`), Láser orbital (`OrbitalLaser`), Caja de analgésicos (`PainKillerCrate`), Carga remota (`RemoteCharge`), Escudo antidisturbios (`RiotShield`), Lanzacohetes (`RocketLauncher`), Torreta de cohetes (`RocketTurret`), Caja de espíritu de equipo (`TeamSpiritCrate`), Granada de teletransporte (`TeleportGrenade`), Kit de herramientas (`Toolkit`), Tranquilizante (`Trunkquilizer`, así escrito en el original), UAV y Cañón de agua (`WaterCannon`).

Cada habilidad se define por (`AbilityGameplayData.cs`):
- `RequiredAP` (energía que cuesta), `MaxUses` (usos por partida), `MinRange`/`MaxRange`, `Radius` (área), `MaxHealth` (vida de lo desplegado, p. ej. una torreta), `ActionPoints`, `ThermalVisionRange` (alcance de visión térmica), `MaxDeployables` (cuántos desplegables a la vez), `HealAmount`, `CanHealSelf` (por defecto sí), `TickDamage` (daño por turno), `DamageBonus`/`DamageReduction`/`DamageModifier`, `MaxOpFirePerTurn` (fuego de reacción por turno), `DoWeaponCheck`, `WeaponId`, `Duration`, `BuffType`, `XPForUse` y `APFraction`.
- Las habilidades de caja crean cajas en el mapa (salud, munición, analgésicos, espíritu de equipo); las de torreta despliegan torretas Gatling o de cohetes; las de cobertura y mina despliegan cobertura y minas.

### Bonificaciones (buffs)

- Cada soldado lleva una lista de bonificaciones activas (`Buffs[]`, `UnitTurnDataJson.cs`). Los tipos de bonificación existen como enum ofuscado (`BuffType`, `AbilityGameplayData.cs`); sus nombres no se pueden leer. La baliza (ver §4) referencia cinco bonificaciones con nombre: Salud, Munición de alta velocidad, Analgésicos, Espíritu de equipo y Barrido detector (`BeaconGameObjectComponent.cs`).

### Habilidades de comandante

Existe una selección aparte de habilidades de comandante (`CommanderAbilitySelectionScreenHandler.cs`, `BarracksCommanderAbilitiesPanelHandler.cs`): el Capitán (comandante) tenía habilidades propias además de las de su clase. Su contenido concreto no está en el código legible.

---

## 3. Armas

### Esquema de datos de un arma (`WeaponGameplayData.cs`)

| Campo | Significado | Valor por defecto |
|---|---|---|
| `IsPrimaryWeapon` | Es el arma principal | — |
| `IgnoreVisCheck` | Ignora la comprobación de visión | — |
| `MinRange` / `MaxRange` | Alcance mínimo y máximo en casillas | — |
| `SplashRange` | Radio de daño en área | — |
| `LineRange` | Alcance en línea (p. ej. lanzallamas o rayo) | — |
| `ShotsPerAttack` | Disparos por ataque | 1 |
| `MaxUses` | Usos por partida | 1 |
| `MinDamage` | Daño mínimo | — |
| `DamageSpread` | Variación del daño | — |
| `Accuracy` | Puntería | — |
| `CritChance` | Probabilidad de crítico | — |
| `RequiredActionPoints` | Energía que cuesta disparar | — |
| `AllowsReturnFire` | Permite fuego de respuesta | sí (`true`) |
| `UseType` | Tipo de uso (por turno, por partida, etc.) | — |
| `DamageType` | Tipo de daño | — |
| `RequiredAbility` | Habilidad necesaria para usarla | — |
| `Category` | Categoría del arma | — |
| `WeaponDamageFallOffCurve` | Curva de caída de daño con la distancia | — |
| `WeaponSplashDamageFallOffCurve` | Curva de caída del daño en área | — |
| `KnockbackDistance` / `KnockbackRange` | Empujón al impactar | distancia —, alcance 1 |
| `SquadPoints` | Puntos de escuadra que cuesta | 3 |
| `TwoStageAttack` | Ataque en dos fases | — |

### Modelo de daño

- **El daño no es fijo**: cada arma tiene daño mínimo (`MinDamage`) y dispersión (`DamageSpread`), puntería (`Accuracy`) y probabilidad de crítico (`CritChance`). La escala del crítico está en `CriticalHitDamageScale` (`GenericGameplayData.cs`; su valor concreto vive en los datos, no en el código).
- **Caída de daño con la distancia**: el daño se multiplica por una curva de caída evaluada en `distancia / alcance máximo` (`WeaponGameplayData.cs`). La curva por defecto es lineal de 1 a 1 (sin caída); cada arma puede tener la suya (`WeaponFalloffCurve.cs`). Lo mismo para el daño en área (`SplashRange`).
- **Fuego de respuesta (return fire)**: existe. Por defecto todas las armas lo permiten (`AllowsReturnFire = true`) y su daño se escala con `ReturnFireDamageScale` (`GenericGameplayData.cs`; valor no verificable aquí). Es un mecanismo central del original que CSN no tiene.
- **Fuego de reacción (overwatch)**: las habilidades tienen `MaxOpFirePerTurn`, disparos de reacción por turno (`AbilityGameplayData.cs`).
- **Empujón**: las armas pueden empujar al objetivo (`KnockbackDistance`, `KnockbackRange = 1`).
- **Modos de disparo** (`UnitWeapon.cs`, enum de modos): Ligero (`Fire_Light`), Pesado (`Fire_Heavy`), Ráfaga (`Fire_Burst`), Montado al hombro (`Fire_ShoulderMount`, lanzacohetes), Minigun (`Fire_MiniGun`) y Lanzar (`Throw`). Posturas: una mano, dos manos y cuerpo a cuerpo (`1H_`, `2H_`, `Melee_`).
- **Tipos de daño** (`UnitWeapon.cs`): bala, explosión (dos variantes), incapacitación (dos variantes) y cuerpo a cuerpo. Las animaciones de impacto y muerte cambian según el tipo (`Hit_Explosion`, `Hit_Burst`, `Disable`, `Hit_Melee`, `Death_Explosion`, `Death_Bullet`).
- **Proyectiles**: velocidad 6, explosión de 0,15 s, sacudida de cámara de 0,5 s con fuerza 0,25, fogonazo de 0,15 s (`UnitWeapon.cs`).

### Qué NO se pudo verificar de las armas

**Los números por arma (daño, alcance y coste de cada arma concreta) no están en este material.** Viven en los paquetes UnityWeb `Weapons03` y `Weapons05` (TextAssets en `resources.assets`), que no se pudieron desempaquetar (ver límites). Los esquemas de arriba son exactos; los valores por arma, no. Las cifras de `Arsenal_real.md` siguen siendo nuestras, no las del original.

---

## 4. Mapas

### Cuadrícula

- Cada nivel tiene su `SizeX` y `SizeY` (`GameGridComponent.cs`), pero **los tamaños reales de los mapas no están en este archivo**: los niveles se descargaban del servidor y aquí no hay ninguna instancia de `GameGridComponent` con medidas (level0-3 son escenas de menú, HUD, resultados y tutorial, no mapas de batalla). El tamaño 12×12 de CSN es una estimación nuestra sin verificar.
- Cada casilla mide 1×1 unidades de mundo, con altura en pasos de 1/32 (`GetTileCentre`: `x - (SizeX-1)*0.5`, `z * (1/32)`, `y - (SizeY-1)*0.5`, `GameGridComponent.cs`). La cámara asume 1 casilla = 1 unidad.
- La distancia de ataque se mide en Chebyshev (el mayor de |Δx| y |Δy|), no en Manhattan ni en línea recta (`GameGridComponent.cs`, `TestLineOfSight`).
- La vista de casillas atacables en el depurador llega por defecto a 20 casillas (`ShowAttackableTilesDistance = 20`, `GameGridComponent.cs`). No es el tamaño del mapa, solo un valor de depuración.

### Coberturas (el sistema más elaborado del juego)

Cada casilla tiene, por dirección (`GameTileComponent.cs`):
- `SolidWest/East/North/South`: bloquean el paso.
- `VisBlocker`: bloquea la visión por completo.
- `WestCover/EastCover/NorthCover/SouthCover`: cobertura en cada borde, con **4 niveles (0-3)**.
- `Height`: altura de la casilla.

Cómo funciona:
- La cobertura es **direccional**: al disparar, el juego traza la línea del atacante al defensor y comprueba qué borde de la casilla del defensor cruza (y el borde enfrentado de la casilla vecina), con intersección de segmentos (`GameTileComponent.cs`, `GetCoverType`).
- El nivel de cobertura se precalcula para **todos los pares atacante-defensor** en una matriz (`CoverMap.cs`): 2 bits por par, valores 0-3 (`MaxValue = (1<<2)-1 = 3`). La matriz se construye al cargar el nivel (`CoverMap.Build`) y la IA la usa directamente (`GameGridComponent.cs`, `InitAI`).
- El nivel máximo de cobertura (valor 3) **bloquea la línea de visión** (`BlocksLine`, `GameTileComponent.cs`); los niveles intermedios dan protección sin bloquear la visión. Los nombres exactos de los 4 niveles no se pueden leer (enum ofuscado `딶.딥` con 4 valores).
- La línea de visión se comprueba avanzando por el rayo en pasos de 0,25 unidades y mirando cada casilla que cruza; las unidades que bloquean la visión también cortan el rayo (`TestLineOfSight`, `GameGridComponent.cs`). Si el objetivo está en una casilla con `VisBlocker`, no hay tiro.
- La visibilidad tiene su propio mapa precalculado (`VisibilityMap`, `GameGridComponent.cs`, `InitAI`): cobertura y visión son dos mapas distintos.

### Elementos del mapa

- **Cobertura desplegable** (`DeployableCoverGameObjectComponent.cs`): objeto con modelo, esqueleto, sonidos de despliegue, de impacto y de destrucción, y efecto de muerte. La puede desplegar el Ingeniero (habilidad `DeployableCover`).
- **Cajas** (`CrateGameObjectComponent.cs`): 4 tipos (salud, munición mejorada, analgésicos, espíritu de equipo). Tienen modelo, segundo modelo, sonidos de despliegue y muerte, y efecto de destrucción. Caen en el turno programado (`LootDropTurn`).
- **Baliza** (`BeaconGameObjectComponent.cs`): tiene modelo, esqueleto, sonido de despliegue y referencia a cinco bonificaciones con nombre e icono: Salud, Munición de alta velocidad, Analgésicos, Espíritu de equipo y Barrido detector (más una «desconocida»). **No queda claro en el código si la baliza es la zona de captura o un objeto que da bonificaciones**: la zona de captura la gestiona `ControlPointManagerComponent.cs` y la baliza es un componente aparte. Es posible que la baliza del modo Captura sea el objeto físico de la zona, y que las bonificaciones sean lo que da al entrar. Marcar como no verificado.
- **Torretas**: Gatling y de cohetes, como habilidades desplegables (`AbilityGatlingTurret`, `AbilityRocketTurret`).
- **Minas**: habilidad `DeployableMine`.
- Los mapas se organizan en **paquetes de mapas** (`BuildManifestMapPackData.cs`: id, paquete, título, lista de niveles) y cada nivel trae sus prefabs de jugabilidad, geometría, iluminación, audio, efectos, fuera de límites, recorte, **mapa de coberturas**, **mapa de visibilidad**, lightmaps e icono (`BuildManifestLevelData.cs`). Algunos niveles son solo para un jugador (`SinglePlayerOnly`).

---

## 5. Cámara

Cifras exactas de `CameraController.cs` (valores por defecto del componente):

| Parámetro | Valor |
|---|---|
| Inclinación (`pitch`) mínima / máxima | 40° / 60° |
| Distancia mínima / máxima | 6 / 11 (unidades = casillas) |
| Campo de visión (`FOV`) mínimo / máximo | 30° / 45° |
| Zoom por defecto (usuario) | 0,5 |
| Ángulo inicial (yaw) | 335° |
| Zoom interno | `0,7 × zoom + 0,15` (a zoom 0,5 → 0,5) |
| Ventana jugable (`playableViewportSize`) | 70 % × 70 % de la pantalla |
| Velocidad de giro (`turnRate`) | 5 (×5 máx. con ratón) |
| Velocidad de movimiento cinematográfico | 20 (aceleración 50, deceleración 100) |
| Fricción de arrastre (`dragFriction`) | 30 |
| Velocidad del muelle de borde (`borderSpringSpeed`) | 60 |
| Margen de cámara en el mapa | 2 casillas por lado + muelle de 2 (`GameGridComponent.cs`) |

En la práctica, con el zoom por defecto la cámara está a **50° de inclinación, 8,5 casillas de distancia y 37,5° de FOV**, mirando con un yaw de 335° (casi norte, ligeramente girada). Al acercar el zoom la cámara baja a 40° y 6 de distancia con FOV 30°; al alejar sube a 60° y 11 con FOV 45°.

Comportamiento (`CameraController.cs`):
- **Giro libre**: con dos dedos o con Q/E (teclas 113/101), y con el ratón en los bordes. La cámara rota 360°.
- **Zoom**: pellizco con dos dedos o rueda del ratón; con muelle que lo devuelve a los límites 0,15–0,85.
- **Desplazamiento**: arrastre con un dedo o ratón, con inercia y muelle en los bordes del mapa.
- **Seguimiento**: la cámara sigue a la unidad activa, va al punto de aparición al empezar el turno (`MoveToSpawn`, `OnTurnStart`) y centra en los objetivos (`CalculateFocusOnTargets`).
- **Sacudida**: al disparar y explotar (`ShakeCamera`; 0,5 s y fuerza 0,25 por defecto en las armas).
- Cada nivel puede cambiar el color de fondo, la luz ambiental y la niebla (`CameraSettingsOverride.cs`).

Para CSN (canvas 2D): la referencia visual es una inclinación cercana a 50°, con la cámara mirando desde arriba y ligeramente girada; el original permitía girar y acercar, CSN de momento es fijo.

---

## 6. IA

Lo que se puede afirmar desde el código legible:

- **Despliegue**: `AIDeployComponent.cs` guarda los tipos de despliegue por equipo (`DeployTypes[]`, `Team`) y un índice llamado (`Call/Uncall/IsCalled`). La IA elige dónde desplegar a sus soldados entre los puntos de aparición del mapa.
- **Mapas precalculados**: la IA se inicializa con el mapa de coberturas y el mapa de visibilidad ya calculados (`GameGridComponent.cs`, `InitAI(BundleCoverMap, BundleVismap)`). Es decir, la IA no calcula coberturas sobre la marcha: consulta las matrices.
- **Distancias precalculadas**: cada punto de aparición guarda su distancia a la zona de captura (`DistanceToControlPoint`, `SpawnPointComponent.cs`).
- **Interfaz**: existe una pantalla de «la IA está pensando» (`AIThinkingOverlayHandler.cs`); el controlador principal del juego guarda una referencia a ella (`딶.딡`).
- **El cerebro de la IA no es legible**: la lógica que elige movimientos y disparos vive en las clases ofuscadas (el controlador principal `딶.딡` y las clases `땃.*`). No se pueden verificar ni las puntuaciones ni los pesos ni el orden de decisión. **No se puede afirmar desde este material cómo decide la IA del original.**
- La IA juega con el mismo formato de turno que un jugador humano (el estado de turno es JSON con unidades, acciones y semilla), así que en el original la IA era, a efectos prácticos, otro jugador que enviaba turnos.

---

## 7. Qué corrige o mejora esto de nuestro diseño actual

Comparado con `Diseno_del_juego.md` y `Arsenal_real.md` (vida 100, energía 6–10 por rol, 1 de energía por casilla, mapa ~12×12, daño fijo por arma):

### Números que están mal en CSN y conviene corregir

1. **La escala de vida y energía es distinta.** El original no usa vida 100 ni energía 6–10: usa **vida 200–325 y energía 12–18**, con el coste de movimiento 1–3 por casilla según el cuerpo. El diseño de CSN comprime la escala a la mitad. No es un error de jugabilidad (la proporción importa más que la cifra), pero si queremos acercarnos al original habría que multiplicar la vida por ~2–3 y la energía por ~1,5–2, y con ello todos los daños del arsenal.
2. **El coste de moverse no es 1 por casilla para todos.** En el original el ligero gasta 1, el medio 2 y el pesado 3. En CSN todos gastan 1 y la diferencia está solo en la reserva (Espía 10, resto 8, Artillero 6). El efecto final es parecido (el Espía anda 10 casillas, el Artillero 6; en el original el ligero anda 12 y el pesado 6), pero el original ata velocidad y resistencia: el que más aguanta es el que menos anda. **Recomendación**: mantener en CSN la idea de «coste por casilla según el cuerpo» (p. ej. Espía 1, resto 2, Artillero 3) o, si se prefiere la simplicidad actual, dejar constancia de que es una simplificación deliberada.
3. **«Sin azar tramposo» es falso respecto al original.** El diseño de CSN dice que los disparos aciertan o fallan por posición, no por dados. El original **sí** tiene puntería (`Accuracy`), probabilidad de crítico (`CritChance`) y dispersión de daño (`DamageSpread`), con RNG determinista por semilla de turno. Si CSN quiere ser fiel, necesita puntería y críticos (con semilla, para que las partidas sean reproducibles); si prefiere no tener azar, es una decisión de diseño nuestra, no del original. Hay que corregir esa frase del documento de diseño.
4. **La captura en 5 turnos está bien.** `TurnsToCaptureZone = 5` coincide exactamente con lo que pusimos. ✓

### Mecánicas del original que CSN no tiene y valen la pena

5. **Fuego de respuesta.** En el original, disparar a un enemigo puede provocar que te devuelva el disparo (por defecto activado en todas las armas, con daño escalado). Es una mecánica central del original y CSN no la tiene. Añadirla cambiaría mucho el equilibrio: disparar deja de ser gratis.
6. **Fuego de reacción (overwatch).** Las habilidades tienen `MaxOpFirePerTurn`: disparos automáticos contra enemigos que se mueven en tu turno de espera. CSN no lo tiene.
7. **Dirección de mira.** Cada soldado mira hacia un lado (4 direcciones) y eso se guarda en cada turno. Podría usarse para puntería, cobertura o fuego de respuesta por la espalda. CSN no tiene orientación.
8. **Cobertura direccional de 4 niveles.** CSN tiene cobertura binaria (bloquea o no, destructible o no). El original tiene 4 niveles por borde de casilla, direccionales y precalculados, y solo el nivel máximo bloquea la visión. Es el sistema más fino del original; merece una versión simplificada en CSN (p. ej. sin cobertura / media / total, según el lado desde el que disparan).
9. **Caída de daño con la distancia.** El original multiplica el daño por una curva según `distancia / alcance máximo`. CSN tiene daño fijo por arma. Añadir una caída suave haría que el alcance importara de verdad.
10. **Cajas de botín programadas.** En el original caen cajas en un turno determinado de la partida (salud, munición, analgésicos, espíritu de equipo). CSN solo tiene botiquines fijos en el mapa (+25). Las cajas programadas dan un motivo para moverse a mitad de partida.
11. **Puntos de escuadra por niveles.** El original limita por nivel de emparejamiento los puntos de unidades y de habilidades por separado (`MaxUnitSquadPoints`, `MaxAbilitySquadPoints`). CSN tiene un solo límite de puntos de escuadra. Separar unidades y habilidades es más fiel.
12. **Empujón (knockback).** Las armas pueden empujar al objetivo. CSN no lo tiene.

### Cosas de CSN que el original no tenía (y están bien)

13. **Roles propios.** El original tenía 5 clases y personajes con nombre; CSN tiene 7 roles (añade Francotirador y Artillero como roles separados, y el Capitán con orden de mando). Es una ampliación nuestra, coherente con lo que pidió Dani.
14. **Arsenal real.** El original usaba armas ficticias con nombres propios; CSN usa armas reales con datos verificados. Es el cambio central del remake y no hay nada que corregir ahí, salvo reescalar los daños si se adopta la escala de vida del original.
15. **Elementos accionables.** Barriles explosivos, torreta capturable, puertas, botiquines y C4 son de CSN. El original tenía cobertura desplegable, minas, torretas Gatling y de cohetes, y cajas; no tenía barriles ni torreta capturable ni puertas.
16. **Naciones y Guerra de Naciones.** Invención de CSN, no existe en el original.

### Dudas que el código no resuelve (no inventar)

- El tamaño real de los mapas del original (no hay niveles en el archivo).
- Los números por arma y por habilidad (viven en los paquetes UnityWeb sin desempaquetar).
- Cómo decide la IA (código ofuscado).
- Si la baliza del original daba bonificaciones o solo era la zona de captura.
- El valor exacto de la escala de fuego de respuesta y de crítico.
- El número total de clases del original.

---

## 8. Inventario a alto nivel de los `.assets` de Unity

Archivos en `rad-soldiers-unity3d-unpacked-quickbms.zip` (113 MB en total), extraídos a `/tmp` solo para esta auditoría, sin copiar nada al proyecto:

| Archivo | Tamaño | Objetos | Contenido principal |
|---|---|---|---|
| `resources.assets` | 81 MB | 114 | 87 TextAssets (paquetes UnityWeb: personajes, armas, habilidades, mapas, atlas), 13 materiales, 11 shaders, 3 texturas |
| `sharedassets0.assets` | 12,6 MB | 3.415 | 877 MonoScripts (las definiciones de script), tipos de cuerpo, localización, prefabs de interfaz |
| `sharedassets1.assets` | 8,6 MB | 13.751 | Prefabs, mallas y texturas (la mayor parte del contenido 3D) |
| `sharedassets2.assets` | 2 MB | 1.747 | Prefabs y localización (habilidades, cajas, torretas) |
| `sharedassets3.assets` | 1,1 MB | 535 | Prefabs, materiales, texturas |
| `sharedassets4.assets` | 244 KB | 113 | Prefabs pequeños, audio |
| `level0` | 1,3 MB | 5.630 | Escena de menú/cuartel (1.447 GameObjects: barracas, selección de mapa, cámaras) |
| `level1` | 541 KB | 4.124 | Escena de HUD de partida (1.113 GameObjects) |
| `level2` | 474 KB | 3.274 | Escena de resultados (917 GameObjects) |
| `level3` | 111 KB | 226 | Escena de tutorial (54 GameObjects) |
| `mainData` | 92 KB | 70 | Datos principales (12 GameObjects, 2 cámaras, ajustes) |

Totales: **19.675 objetos** en los `.assets` y **~14.254** en los niveles. Por tipo: 4.190 GameObjects, 2.371 MeshFilters, 2.059 MonoBehaviours, 1.163 mallas, 877 MonoScripts, 475 materiales, 436 texturas 2D, 390 animaciones, 192 clips de animación, 139 Rigidbody, 132 clips de audio, 108 sistemas de partículas, 87 TextAssets, 75 fuentes de audio, 49 shaders.

Los 87 TextAssets incluyen los paquetes de datos del juego (formato UnityWeb, Unity 4.2.0b5): `Characters` (290 KB), `Weapons03` (470 KB), `Weapons05` (1,18 MB), `Abilities02` (1 MB), `MapPacks` (117 KB), `AtlasPack02` (2,36 MB), `Theme_02_Levels_Gameplay_DLC1` (99 KB), paquetes de trajes y audio por personaje (HipsterDave, SneakyPete, SisterFlorence, ArchieFletcher, IvanTkilya, MmeLaHacque, Soap, RiotMedic, BigTimeTaschmann, MeganMcNick, HalloweenOutfits) y 3 temas de audio grandes (`Theme_01_Skirmish_03/04/09`, 3–4,7 MB cada uno).

**Qué no se extrajo:** ningún arte, modelo, textura ni audio se copió al proyecto. Solo se leyeron nombres y valores numéricos de datos de juego, y se listaron los tipos de contenido. Los paquetes UnityWeb no se pudieron desempaquetar con las herramientas disponibles (UnityPy 1.25.4 no admite el formato web de Unity 4.2; no hay Java para disunity; la descompresión LZMA directa no funciona). Si alguien los desempaqueta en el futuro, ahí dentro están los números por arma, por habilidad, por personaje y por nivel que aquí faltan.

El `rad-soldiers.zip` (165 MB, la app de Chrome) no se usó para esta auditoría más allá de listar su contenido: es una build Unity NaCl (no ejecutable en Chrome moderno) con vídeos de introducción, fuentes y scripts de la envoltura web. El `Assembly-CSharp.dll` (1,95 MB) es el código descompilado que se auditó.
