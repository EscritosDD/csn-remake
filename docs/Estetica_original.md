> **Nota de alcance:** este documento es histórico. Cita arte y material del original que vive fuera del repositorio (carpeta `_original/`), y capturas que no se guardan aquí por tamaño. No son enlaces rotos: son referencias al material de trabajo local.

# Estética del RAD Soldiers original — auditoría visual para CSN

Cómo construyeron los personajes y los mapas del original, medido en sus archivos. Esto es la lógica de construcción, no sus archivos: el arte de CSN sigue siendo original, nada de sus texturas, modelos ni audio va al juego. Cada cifra cita su fuente (archivo `.assets`, prefab o `.cs`).

**Fuentes:** `hidden_files/original/rad-soldiers-unity3d-unpacked-quickbms.zip` (level0-3, mainData, resources.assets, sharedassets0-4.assets), leído con UnityPy 1.25.4; `hidden_files/original/decompiled/` (528 `.cs`); capturas del original subidas por Dani (`~/workspace/user/media_library/image/image-2.png` … `image-8.png`).

**Límites (léelo antes de fiarte de una cifra):**
- Los mapas de batalla NO están en el archivo: se descargaban del servidor como paquetes (`BuildManifestLevelData.cs`). level0-3 son menú/cuartel, HUD, resultados y tutorial. Las medidas de sacos, muros y barriles del mapa NO se pudieron medir; lo que se dice de ellos viene de las capturas y va marcado como estimación.
- La malla de soldado con skinning del juego NO está en el archivo: vive en los paquetes descargables de personajes (`Characters`, UnityWeb, sin desempaquetar). Lo que se midió es la malla estática `Soldier` de sharedassets1 (la de cuartel/vista de personaje), que es la misma base de proporciones.
- Los números por arma y por habilidad y los retratos de 8 de los 10 personajes viven en esos paquetes sin desempaquetar. Solo hay retrato legible de Hipster Dave y de Carlito Grosso.
- Los valores de color de las barras de vida y de los materiales de resaltado viven en el asset, no en el código: se sabe que existen, no su valor exacto.

**Corrección (16/11/2026, tras extraer los rigs y las animaciones a `arte-original/`):** dos cifras de esta biblia estaban mal.
- **No hay un solo rig, hay cuatro.** `SoldierSkeleton`, `AgentSkeleton`, `MedicSkeleton` y `EngineerSkeleton`: misma estructura Bip001 de 22 huesos, proporciones distintas por clase. El Agente y el Médico son altos y flacos (pelvis a 0,59, piernas de 0,54); el Soldado y el Ingeniero son bajos y anchos (pelvis a 0,36, piernas de 0,30). La malla `Soldier` sí es una sola para todos; lo que cambia por clase es el esqueleto que la mueve. Ver `arte-original/rigs.json` y `arte-original/INVENTARIO.md` §3.
- **No son 36 animaciones de cuerpo completo, son 38.** La tabla del §2 ya listaba 38 (1H 9 + 2H 11 + Melee 7 + comunes 11); el «36» del título era un error de conteo. Además hay 2 clips de 3 huesos (`Death`, `Idle_01`, probablemente de la caja o del anillo) y 38 de UI/efectos. Ver `arte-original/animaciones/` y `INVENTARIO.md` §4.
- El cuaternión de conversión Max→Unity (−0,5, 0,5, 0,5, 0,5) está en el hueso `Bip001` mismo, no en la raíz del prefab. La malla está en espacio Max (Z arriba) y el rig en espacio Unity (Y arriba): para Three.js, rotar la malla −90° en X.

---

## 1. Personajes: proporciones exactas

### La malla del soldado

Una sola malla para todos los personajes: `Soldier` (sharedassets1.assets). 599 vértices, 1154 triángulos, con UV (599 coordenadas de textura) y sin normales guardadas (las calcula el motor o el shader). Es una malla estática: sin pesos de hueso, sin bind pose, sin skinning en este archivo. La variedad entre personajes NO está en la malla: está en la textura, la cara, el traje (outfit) y el arma.

Medidas de la malla exportada a OBJ (espacio de 3ds Max, Z arriba; una casilla del tablero = 1 unidad):

| Medida | Valor |
|---|---|
| Altura total (Z) | 1,024 unidades (el soldado mide ~1 casilla de alto) |
| Ancho total (X) | 0,752 (de mano a mano con los brazos caídos) |
| Profundidad total (Y) | 0,612 |
| Cabeza: alto × ancho | ~0,19 × 0,19 (Z 0,83–1,02; X 0,9–1,0: 0,19) |
| Cabeza / altura total | ~1/5 (0,19 / 1,02). Un humano real es ~1/7,5 |
| Altura de la pelvis (hueso Bip001) | 0,36 (el 35 % de la altura; piernas cortas) |
| Hombros (huesos Neck/Spine1) | ~0,83 |
| Manos colgando | hasta Z ~0,48 (mitad del muslo) |
| Pies | separados ±0,24 en X; planta de ~0,35 de largo en Y |

La silueta (renderizada desde el OBJ) confirma: postura relajada de pie, brazos caídos ligeramente hacia adelante, piernas separadas, cabeza redonda y grande con casco o pelo integrado. No es pose en T: es la pose de reposo del personaje.

### Proporciones del esqueleto (rig Bip001)

Las longitudes salen de los offsets entre huesos (sharedassets0, prefab `SoldierSkeleton`):

| Segmento | Longitud |
|---|---|
| Muslo (Thigh → Calf) | 0,17 |
| Pantorrilla (Calf → Foot) | 0,13 |
| Pierna total (pelvis 0,36 al suelo) | 0,36 |
| Columna (Spine → Spine1 → Neck) | 0,08 + 0,20 + 0,19 ≈ 0,47 |
| Brazo superior (UpperArm → Forearm) | 0,23 |
| Antebrazo (Forearm → Hand) | 0,15 |
| Mano (Hand → gunBone) | 0,15 (0,10 hasta el hueso del arma) |
| Brazo total (hombro a mano) | ~0,53 |
| Caderas (Thigh L/R desde Spine) | ±0,11 en Z, 0,08 en X |
| Hombros (Clavicle L/R desde Neck) | ±0,10 en Z |

Lectura: torso largo (0,47) y piernas cortas (0,36), brazos largos (0,53, llegan a mitad del muslo), hombros anchos. Es un chibi de torso grande, no un muñeco cabezón de piernas largas.

### El arma es ENORME (medido)

Malla `AssaultRifle` (sharedassets1, dos copias): 0,776 de largo × 0,108 × 0,30, 170 triángulos. Frente a la altura del soldado (1,024), **el fusil mide el 76 % de la altura del personaje**. Un fusil real (0,7–1,0 m) frente a una persona (1,75 m) es el 40–55 %. El original sobredimensiona el arma casi al doble de lo real: el arma es la mitad de la silueta, no un accesorio. Las armas son mallas separadas con 2 huesos propios (`gunMuzzleBone`, `gunRootBone`: boca y raíz, para el fogonazo y el retroceso) y se montan en los huesos `gunBone_L` / `gunBone_R` de las manos.

### Una sola base, diez personalidades

Los 10 personajes con nombre (Hipster Dave, Sneaky Pete, Sister Florence, Archie Fletcher, Ivan Tkilya, Mme La Hacque, Soap, Riot Medic, Big Time Taschmann, Megan McNick) comparten la malla `Soldier`, la estructura de rig Bip001 (con 4 variantes de proporciones por clase, ver §2) y las 38 animaciones. Lo que cambia por personaje (`UnitCharacterData.cs`, `BuildManifestCharacterData.cs`): arma por defecto, paquete de voz, traje por defecto, nivel de desbloqueo y misión de prueba. Los trajes (outfits) son prefabs descargables por personaje (`BuildManifestOutfitData.cs`: id, paquete, personaje dueño, ruta del prefab, nivel): piezas que se montan sobre la base, no mallas nuevas del cuerpo.

Paleta por personaje (solo lo verificable):
- **Hipster Dave** (retrato `char-hipster_dave`, 128×128, y HUD de las capturas): piel #E0A080, pelo naranja/rojo, gafas de sol verdes, camisa azul abierta, chaleco marrón, pantalón oscuro, fusil negro enorme. Cara pintada con ceño marcado, nariz grande, expresión de enfado.
- **El gordo del cartel** (image-7, probablemente Big Time Taschmann, sin verificar el nombre): camiseta blanca de tirantes con ribete azul y amarillo, pantalón corto negro, piel morena, maza de madera enorme (más alta que su torso), sonrisa ancha.
- **Resto del cartel** (image-7, sin nombres asignables): mujer de pelo rojo (azul y rojo), soldado de gorra azul con mochila (oliva y azul), robot gris y naranja, soldado con máscara de gas (oliva), chico de camiseta amarilla. La regla visible: ropa civil de colores saturados mezclada con lo militar (oliva, gris, negro), caras expresivas y visibles, cada uno con un acento de color propio.
- **Carlito Grosso**: existe su retrato (`char-carlito _grosso`, 128×128) en los assets; no consta su papel exacto.
- Los otros 8 retratos no están en los assets legibles (viven en los paquetes descargables).

### Números de malla para comparar

| Pieza | Vértices | Triángulos | Tamaño (unidades) |
|---|---|---|---|
| Soldado (`Soldier`) | 599 | 1154 | 0,752 × 0,612 × 1,024 |
| Fusil (`AssaultRifle`) | — | 170 | 0,776 × 0,108 × 0,30 |
| Caja de comandante (`CommCrate`, 2 copias) | — | 124 / 180 | 0,675 × 0,675 × 0,609 |
| Cubo de tutorial (`TutorialCube_01/02/03`) | — | 44 | 0,156 × 0,156 × 0,156 |
| Globo del menú (`EARTHFRONTEND`) | — | 1910 | 3,24 × 3,23 × 3,34 |

El soldado es low-poly de móvil de 2012: 599 vértices. Nuestro sprite 2D no necesita ese presupuesto, pero la lección es la contraria: con muy poco consiguen mucho, porque el peso visual está en la proporción, la cara y el arma, no en el detalle.

---

## 2. Esqueleto y animación

### El rig: cuatro esqueletos, misma estructura (Bip001, 22 huesos)

Cuatro prefabs con la misma jerarquía (`SoldierSkeleton`, `AgentSkeleton`, `MedicSkeleton`, `EngineerSkeleton`, en sharedassets0), con proporciones distintas por clase (ver la corrección al principio del documento: Agente y Médico son altos y flacos; Soldado e Ingeniero, bajos y anchos). La jerarquía del Soldado, con el cuaternión de conversión Max→Unity en el hueso `Bip001` (−0,5/0,5/0,5/0,5), no en la raíz:

```
Soldier
└── Bip001 (y=0,36)
    └── Bip001 Pelvis
        ├── Bip001 Spine
        │   ├── Bip001 L Thigh → L Calf → L Foot
        │   ├── Bip001 R Thigh → R Calf → R Foot
        │   └── Bip001 Spine1
        │       ├── Bip001 Neck → Bip001 Head
        │       ├── Bip001 L Clavicle → L UpperArm → L Forearm → L Hand → gunBone_L
        │       └── Bip001 R Clavicle → R UpperArm → R Forearm → R Hand → gunBone_R
```

22 huesos en total. Sin huesos de dedos, sin huesos de cara: las manos son bloques y la cara no se anima por huesos (la expresión está pintada en la textura). Las armas cuelgan de `gunBone_L/R` en las manos.

### Las 38 animaciones (un solo set, tres posturas de arma)

Componente `Animation` del prefab `Soldier` (sharedassets0). Cada clip anima los 22 huesos con 44 canales (22 de posición + 22 de rotación comprimida). Duraciones medidas del último keyframe de cada clip:

| Grupo | Clips | Duración medida |
|---|---|---|
| Una mano (1H) | Fire_Burst, Fire_Heavy, Fire_Light, Idle_01, Idle_02, Turn_180, Turn_L, Turn_R, Walk | Walk 0,40 s; Idle_01 2,50 s; Idle_02 4,23 s; Fire_Light 2,03 s; Fire_Burst 2,83 s; Fire_Heavy 2,03 s; Turn 0,67 s |
| Dos manos (2H) | Fire_Burst, Fire_Heavy, Fire_Light, Fire_MiniGun, Fire_ShoulderMount, Idle_01, Idle_02, Turn_180, Turn_L, Turn_R, Walk | Walk 0,40 s; Idle_01 2,50 s; Fire_Light 3,40 s; Fire_Burst 3,57 s; Fire_Heavy 2,83 s; Fire_MiniGun 3,23 s; Fire_ShoulderMount 2,00 s; Turn 0,67 s |
| Cuerpo a cuerpo (Melee) | Fire, Idle_01, Idle_02, Turn_180, Turn_L, Turn_R, Walk | Walk 0,40 s; Idle_01 2,50 s; Fire 2,17 s; Turn 0,67 s |
| Comunes | Death_Bullet, Death_Explosion, Deploy, Hit, Hit_Burst, Hit_Explosion, Hit_Melee, Interact, Throw, Commander_Order, 1H_PickUp | Death_Bullet 1,07 s; Death_Explosion 3,07 s; Deploy 0,60 s; Hit 0,90 s; Hit_Burst 1,67 s; Hit_Explosion 3,17 s; Hit_Melee 1,83 s; Interact 2,07 s; Throw 1,60 s; Commander_Order 3,80 s; PickUp 2,33 s |

Lectura: el paso es rapidísimo (ciclo de 0,40 s, 2,5 pasos por segundo: el soldado casi corre al andar una casilla); el giro es 0,67 s en los tres casos; los disparos duran 2–3,5 s porque incluyen apuntar, disparar y recuperarse; morir por explosión dura 3 s y por bala 1 s. Los idles son dos: uno corto (2,5 s) y uno largo (4,23 s, probablemente con un gesto propio).

Postura base en el tablero: de pie, relajado, brazos caídos ligeramente hacia adelante, mirando en una de las 4 direcciones cardinales (la dirección se guarda en cada turno). En las capturas el soldado se ve en tres cuartos desde arriba, nunca de frente plano.

---

## 3. Materiales y texturas

### Shaders: seis propios, el resto estándar de Unity

En `TacticsGameAssets.cs` (código): `CharShader`, `CharHiddenShader`, `CharTransparentShader`, `WeaponShader`, `WeaponHiddenShader`, `WeaponTransparentShader`. Son shaders propios de Splash Damage para personajes y armas, en tres variantes: normal, oculto y transparente (la invisibilidad del Espía/Fantasma se hace con el transparente; `GhostVisFrac = 0,7`: el fantasma se ve al 70 %). El resto de shaders en los assets son estándar de Unity 4: `Diffuse`, `VertexLit`, `Alpha-Diffuse`, `Unlit`, `UnlitAlphaAndTexture`, `VertexColour`, `VertexColourAlphaBlend`, `ControlPointOutline`, `CoverHighlight` y variantes `Clipped` para la interfaz. Los shaders `Character`/`Weapon` no se pudieron leer por dentro (UnityPy no extrae el código del shader en este formato): se sabe el nombre y las tres variantes, no sus propiedades (rim, brillo) exactas.

### Texturas: pequeñas, pintadas a mano, saturadas

436 texturas en total. Tamaños: 128×128 (249), 256×256 (118), 64×64 (43), 32×32 (13), 512×512 (4), 1024×1024 (1, atlas de la fuente `Eyeful_0`) y 8 misceláneas menores. Nada de texturas grandes: el juego es de móvil de 2012 y todo cabe en 128–256 px.

- **Textura de la caja de botín** (`TreasureCrate_d`, 512×512, la más grande del juego junto al logo): atlas pintado a mano — tablones de madera en marrones cálidos (#602000, #A06020), medallones dorados con `?` y marcas de visto, cantoneras de metal oscuro con remaches, placas gris-azuladas. Pinceladas visibles, sombras suaves, contornos oscuros gruesos. Nada fotorrealista: todo pintado.
- **Retrato de Hipster Dave** (`char-hipster_dave`, 128×128): cara pintada con contorno oscuro grueso, colores planos con sombreado suave, piel #E0A080, pelo naranja, acento rojo #E04000. El mismo estilo que la caja: pintura, no foto.
- **Marcadores de casilla** (`floortile_*`, 256×256): son máscaras blancas sobre negro, no texturas de color. El color lo pone el material en el juego. Formas medidas viendo las imágenes: ataque = punto de mira (círculo con 4 marcas); colocación = círculo relleno con anillo, 4 triángulos hacia dentro y punto central; curar, área, fuego de respuesta y «te van a atacar» son variantes de la misma idea. El marcador NO es un cuadrado: es un símbolo dentro de la casilla.
- **Fondos de carta de personaje** (`char-bg_blue/green/red/yellow/grey`, 128×128): un color plano por bando, para la carta del cuartel.
- **Iconos de habilidad** (`CharAbility_XX_Nombre`, 128×128): un icono por habilidad, mismo estilo pintado.
- **Sin textura de piel del soldado legible**: la textura del cuerpo no está en los assets legibles (vive en los paquetes descargables). La paleta del cuerpo se deduce de las capturas, no de una textura.

### Paleta medida (colores exactos del código)

De `TacticsGameAssets.cs` (valores literales en el código):

| Color | RGB 0–1 | Hex | Uso |
|---|---|---|---|
| Azul de bando | (0,22, 0,49, 0,79) | #387EC9 | Equipo azul: anillo, cartas, HUD |
| Rojo de bando | (0,79, 0,33, 0,22) | #C95338 | Equipo rojo: anillo, cartas, HUD |
| Gris | (0,50, 0,50, 0,50) | #7F7F7F | Neutro / orientación |
| Blanco | (1, 1, 1) | #FFFFFF | Zona de captura por defecto |
| Fondo de cámara (menú) | (0,25, 0,47, 0,81) | #4078CF | Azul cielo del fondo |
| Fondo de cámara (oscuro) | (0,19, 0,30, 0,47) | #304D78 | Azul acero del fondo |

Paleta general vista en las capturas: suelos grises-azulados de adoquín, asfalto con líneas amarillas, arena, hierba verde; props en naranja (barreras, sacos), rojo (tren, barreras), amarillo (contenedores, líneas), madera marrón y metal gris; personajes con acentos saturados (naranja, azul, rojo, verde) sobre base oliva/gris/negra. Todo saturado, nada apagado.

### Iluminación medida

- Tutorial (level3): 2 luces direccionales blancas, intensidad 0,85, alcance 10.
- Menú/cuartel (level0): focos puntuales blancos de 1,2–3,0, más 2 direccionales: una fría azulada (0,65, 0,81, 1,0) a 0,51 y una cálida naranja (0,92, 0,51, 0,36) a 0,92. Mezcla frío + cálido, luz cálida desde arriba.
- Por nivel se puede cambiar color de fondo, luz ambiental y niebla (`CameraSettingsOverride.cs`).

---

## 4. Mapa: cómo se monta

### Lo que sí se midió

- **Casilla: 1×1 unidades de mundo**, altura en pasos de 1/32 (`GameGridComponent.cs`). El soldado (1,02 de alto) ocupa una casilla entera de alto.
- **Suelo: un plano grande con textura pintada** (adoquín gris-azulado, asfalto con líneas amarillas, arena, hierba). Las juntas de las casillas se ven sutiles en la textura; la rejilla blanca solo aparece como resaltado de las casillas alcanzables (image-5 y 6: cuadrados blancos huecos en las casillas a las que se puede ir, casillas azules rellenas para el camino).
- **Caja de comandante** (`CommCrate`): 0,675 × 0,675 × 0,609, 124–180 triángulos, con 3 huesos (`RootChunkBone`, `RightChunkBone`, `LeftChunkBone`): la caja se rompe en trozos al abrirse.
- **Cubo de tutorial** (`TutorialCube`): 0,156³, 44 triángulos.
- **La línea azul de zona**: en las capturas hay una línea azul discontinua que marca el borde de la zona o del mapa (image-2: borde del andén; image-3: línea cruzando el mapa). Es una línea, no un muro.
- **Atmósfera de set**: tren rojo, coches negros, estatuas (image-8: estatua ecuestre de bronce verde sobre plinto), carteles («Manson House», «TRANS»), periódicos y hojas en el suelo, farolas con luz amarilla, vallas, sacos. El mapa es una calle o estación realista en miniatura, no un tablero abstracto.

### Lo que NO se pudo medir (y no se inventa)

Los prefabs de los mapas de batalla (sacos, muros, barriles, torretas, cajas, coberturas) no están en el archivo: se descargaban del servidor. Estimaciones solo por las capturas, marcadas como tales: un saco mide ~1/3 de casilla de alto, una barrera ~1/2 casilla, un coche ~1,5 casillas de largo, el tren varias casillas. El tamaño real de los mapas tampoco está (los niveles se descargaban).

### Cómo se colocan las cosas (del código)

- Las coberturas son direccionales por borde de casilla, con matriz precalculada para todos los pares atacante-defensor (`CoverMap.cs`, ver Referencia_original.md).
- Los puntos de aparición guardan su distancia precalculada a la zona de captura (`SpawnPointComponent.cs`).
- Cada nivel trae prefabs de jugabilidad, geometría, iluminación, audio, efectos, fuera de límites, recorte, mapa de coberturas, mapa de visibilidad, lightmaps e icono (`BuildManifestLevelData.cs`). Algunos niveles son solo para un jugador.
- La cámara de cada nivel puede cambiar color de fondo, luz ambiental y niebla (`CameraSettingsOverride.cs`).

---

## 5. Cámara y presentación

### Cámara (cifras auditadas, ver Referencia_original.md)

Inclinación 40–60°, distancia 6–11, FOV 30–45°, zoom por defecto 0,5 → **50°, 8,5 de distancia, FOV 37,5°**, yaw inicial 335°, giro libre 360°, ventana jugable del 70 %. En las capturas se ve exactamente eso: vista cenital inclinada, ligeramente girada, con el norte arriba a la izquierda.

### El anillo bajo cada soldado (medido)

Prefab `CharacterHighlightBlobPrefab` (sharedassets0):
- Malla `140x140`: plano de 0,438 × 0,438, 2 triángulos, a 0,01 sobre el suelo.
- Escala del anillo: 1,43 × 1,44 (padre) × 1,14 (hijo) → **diámetro final ~0,71 unidades** (el 71 % de la casilla).
- Tiene animación propia (pulso) y un sistema de partículas `Pulse_Floor` hijo.
- En las capturas el anillo es un círculo segmentado (arcos con huecos, como un círculo discontinuo) en el color del bando (azul #387EC9 / rojo #C95338, y verde en algunas capturas para el bando propio en tutorial). El enemigo seleccionado lleva el anillo rojo.
- Además existe `UnitShadow` (sombra del soldado, en `TacticsGameAssets.cs`).

### La orientación (hacia dónde mira)

Prefab `UnitOrientationPrefab` (sharedassets0): un círculo `CharacterFaceCircle` de 1,005 × 1,14 × 0,08 (tamaño de casilla, plano) con 4 flechas `CharacterFaceArrow` de 0,475 × 0,462, una por dirección cardinal, en dos variantes (gris y azul, las azules desplazadas 0,10 hacia fuera). La flecha marca hacia dónde mira el soldado.

### Los iconos de cobertura (medidos)

Prefabs `CoverHighlightHigh/Medium/Low` (sharedassets0): un icono `Shield_cover_high/medium/low` de 0,48 × 0,067 × 0,603 (los tres del mismo tamaño, ~100–108 triángulos), colocado a (−0,40, 0,50, 0) sobre la cobertura. El nivel de cobertura se muestra con un escudo flotante, no solo con color.

### Las casillas marcadas (modelos, del código)

En `TacticsGameAssets.cs`: `MovementHighlightModel` (movimiento), `EnemyHighlightModel` (enemigo), `ReturnFireHighlightModel` (fuego de respuesta), `FirePossibleHighlightModelHigh/Medium/Low` (se puede disparar, 3 niveles), `CanAttackAfterMoveModel`, `HealHighlightModel`, `PlacementHighlightModel`, `SpawnHighlightModel`, `AIVisBlocked/CurrentlyVisible/NeverVisible/RecentlyVisibleHighlightModel` (visibilidad de la IA, 4 estados), `CoverHighlightLow/Medium/High`. El camino de movimiento se dibuja con 5 piezas: `MovementModelStart`, `MovementModelStraight`, `MovementModelTurn`, `MovementModelTurn2`, `MovementModelEnd`, más `MovementCostBubbleUI` (la burbuja con el coste en energía). Cada estado de casilla tiene su propio modelo y su propia textura de máscara (`floortile_*`).

### El HUD (de las capturas image-5 y 6)

- Arriba a la izquierda: retrato pintado del soldado activo, nombre («Hipster Dave»), vida 200 con cruz verde, energía 12 con rayo, icono de habilidad con usos (3 ×1).
- Abajo a la izquierda: deshacer y ajustes. Abajo a la derecha: tick verde grande (terminar turno). Arriba a la derecha: bandera blanca.
- Al disparar: el objetivo lleva anillo rojo y sus casillas se tiñen de rojo; el daño aparece como número flotante sobre el objetivo (36 en la captura; en el código hay textos distintos para daño, crítico, veneno, abejas, fuego, curación y recuperación).
- Barras de vida verde/naranja/roja/amarilla y barra de energía (`HealthBarGreen/Orange/Red/Yellow`, `APBarColor` en `TacticsGameAssets.cs`; los valores exactos viven en el asset, no en el código).
- El tutorial explica tocando el anillo a los pies del enemigo («Tap the target at his feet to fire at him»): el anillo ES el botón de disparar.

---

## 6. Los moldes

La plantilla que se repite en todo el original, solo con lo medido:

1. **Una sola base chibi para todos**: malla única de 599 vértices y 1154 triángulos, 1,02 de alto en una casilla de 1×1, cabeza de ~1/5 de la altura, torso largo (0,47) y piernas cortas (0,36), brazos largos (0,53) que llegan a mitad del muslo, hombros anchos. La variedad no está en el cuerpo: está en la cara, el traje y el arma.
2. **Un solo rig para todos**: Bip001 de 22 huesos, sin dedos ni cara; las armas cuelgan de `gunBone_L/R`.
3. **Un solo set de animaciones**: 36 clips (1H/2H/Melee + comunes), 44 canales por clip, paso de 0,40 s, giro de 0,67 s, disparos de 2–3,5 s, muertes de 1–3 s.
4. **Armas sobredimensionadas**: el fusil mide el 76 % de la altura del soldado; el arma es la mitad de la silueta.
5. **Caras expresivas y visibles**: ceño, nariz grande, gafas de sol, bigotes, sonrisas; la expresión está pintada, no animada.
6. **Ropa civil de colores sobre base militar**: oliva, gris y negro de fondo; naranja, azul, rojo, verde y amarillo como acentos por personaje.
7. **Texturas pintadas a mano, pequeñas**: 128–256 px, colores planos con sombreado suave y contorno oscuro grueso; nada fotorrealista.
8. **Colores de bando exactos**: azul #387EC9 y rojo #C95338, gris #7F7F7F neutro; fondos azul cielo #3F78CF y azul acero #304C78.
9. **Anillo segmentado bajo los pies**: plano de 0,44 escalado a ~0,71 de diámetro, color de bando, con pulso; el anillo es el botón de disparar.
10. **Símbolos, no cuadrados, para marcar casillas**: punto de mira para atacar, círculo con triángulos para moverse; cada estado tiene su modelo y su máscara.
11. **Mapa como calle en miniatura**: suelo pintado (adoquín, asfalto, arena, hierba), set de estación o calle con tren, coches, estatuas y carteles; línea azul de zona.
12. **Luz cálida desde arriba**: direccional blanca 0,85 en tutorial; en menú, mezcla de fría azulada y cálida naranja; cámara a 50°, 8,5 de distancia, FOV 37,5°.
13. **Shaders propios en tres variantes**: normal, oculto y transparente por personaje y por arma; el fantasma se ve al 70 %.

---

## 7. Prompt para Argon (v4)

Prompt listo para copiar y pegar en Gemini Argon (web), con las capturas del original adjuntas como referencia de estilo. Argon devuelve SVG por código: los sprites deben ser originales nuestros siguiendo estos moldes, no copias de los suyos.

**Imágenes que hay que adjuntarle** (Dani ya las subió; están en `~/workspace/user/media_library/image/`):
- `image-2.png` (mapa de estación, anillos de bando, sacos y barreras), `image-3.png` (mapa de arena, explosión), `image-4.png` (tren rojo, anillo rojo de enemigo), `image-5.png` (HUD, casillas azules y blancas), `image-6.png` (tutorial, anillo rojo, bocadillo), `image-7.png` (cartel «CREA TU SUPER EQUIPO»: los 10 personajes en fila, personalidades distintas), `image-8.png` (calle con estatua, anillos verdes, sacos naranjas).

**Prompt:**

```
Eres el dibujante de sprites de un juego de táctica por turnos en cuadrícula, vista cenital inclinada a 50 grados. Necesito los 7 soldados del juego como símbolos SVG en una sola hoja, cada uno en su viewBox 0 0 200 200, con ids francotirador, artillero, espia, medico, ingeniero, comando y capitan. Los sprites deben ser ORIGINALES, creados por ti siguiendo las medidas y el estilo de las imágenes de referencia que te adjunto, sin copiar ningún personaje concreto de ellas.

MEDIDAS EXACTAS (la proporción es lo más importante, respétala en cada soldado):
- Cada soldado mide 200 px de alto dentro de su viewBox y ocupa de pie casi toda la altura. La cabeza mide 40 px de alto (1/5 de la altura total, cabezona como en las referencias). El torso es largo y las piernas cortas: la pelvis está a 70 px del suelo, los hombros a 165 px, las manos cuelgan hasta 95 px del suelo. Hombros anchos, brazos largos, pies separados.
- El arma es ENORME: mide entre 130 y 160 px de largo, el 70-80 % de la altura del soldado, y es la mitad de la silueta. Se sujeta con las dos manos por delante del cuerpo (o con una mano en el caso del espía). El arma no flota: las manos la agarran de verdad, con los dedos cerrados sobre ella.
- Cada personaje es una personalidad distinta, con cuerpo distinto: el artillero es gordo y ancho, con barriga; el francotirador es alto y flaco; el espía es bajo y ágil; el médico lleva bata o cruz visible; el ingeniero lleva herramientas y casco de obra; el comando es atlético y estándar; el capitán lleva gorra de mando. Todos con caras EXPRESIVAS Y VISIBLES: ojos grandes con cejas marcadas, sonrisas, bigotes, gafas de sol en alguno, nariz grande. Nada de caras vacías ni de puntos por ojos.
- Ropa: base militar oliva y gris, pero cada rol lleva un acento de color propio bien visible (francotirador verde oscuro, artillero naranja, espía negro y gris, médico blanco y rojo, ingeniero amarillo, comando azul, capitán rojo). Mezcla ropa civil de colores con lo militar, como en las referencias: camisetas, chalecos abiertos, gorras, no todo uniforme.
- Cámara en tres cuartos desde arriba: se ve la parte superior de la cabeza y los hombros, los pies apuntan ligeramente hacia el espectador, nunca de frente plano como un muñeco de papel. Postura relajada de pie, piernas separadas, peso repartido.
- Estilo: dibujo 2D pintado a mano, colores planos saturados con sombreado suave, contorno oscuro grueso, nada fotorrealista, nada de degradados de render 3D. Piel #E0A080. Azul de bando #387EC9 y rojo #C95338 para los detalles de equipo.
- Técnica SVG: usa las clases uniforme, casco, piel y botas para las partes que se tiñen por nación, y los degradados grad-uniforme y grad-casco para el volumen. Cada soldado debe leerse a 48 px de alto en el tablero: silueta clara, cabeza grande, arma enorme.

ERRORES PROHIBIDOS (los cometiste en la versión anterior, no los repitas):
- Nada de muñecos de frente plano como recortables de papel, todos en la misma postura estática.
- Nada de manos en círculos sin dedos ni armas flotando sin agarrar.
- Nada de caras con ojos de puntos ni bocas ausentes.
- Nada de siete soldados idénticos cambiando solo el color: cada uno tiene cuerpo, cara y ropa distintos.
- Nada de armas pequeñas: si el arma mide menos de la mitad de la altura del soldado, está mal.
- Nada de estilo 3D realista ni de foto: es dibujo pintado 2D con contorno.

LISTA DE VERIFICACIÓN ANTES DE ENTREGAR: cada soldado mide 200 px de alto; la cabeza mide 40 px; el arma mide 130-160 px y está agarrada con las manos; la cara tiene ojos, cejas, nariz y boca visibles; el cuerpo es distinto en cada rol; la vista es en tres cuartos, no de frente plano; las clases uniforme, casco, piel y botas están puestas.
```

**Segundo prompt (objetos del mapa + logo, para después):** se redacta cuando los 7 soldados estén aprobados; usará los mismos moldes (textura pintada, contorno grueso, colores saturados, medidas de `CommCrate` 0,675 y anillo 0,71 de diámetro).


## Nota: bios de personaje en CSN

El original **no trae bios escritas** en el IPA (solo nombres, trajes, voces y
paletas). Las bios de los 17 personajes que muestra el Cuartel de CSN son
**redaccion propia inspirada en los rasgos documentados** de esta pagina
(Hipster Dave y sus gafas verdes, Taschmann y su maza, Sister Florence y su
papel de medica, etc.); no son canon del original.
