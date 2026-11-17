# Plan director: el original como base reconocible

Objetivo: que CSN sea reconocible como **RAD Soldiers** (Splash Damage, 2012)
en pantalla —mapas, personajes, habilidades, interfaz y presentación— y que
esa base quede lista para que IAs más capaces (Gemini Studio, z.ai…) la
lleven a otro nivel. No es «un juego inspirado»: es coger el original,
reconstruirlo con fidelidad y ampliarlo con contenido propio encima.

Fuentes disponibles: el IPA completo (`_original/ipa/…/Data/Raw`), el
código descompilado (`referencia_original/decompiled`), los datos del
original (`referencia_original/datos`) y los documentos de `docs/`.

---

## 1. Inventario real del original (extraído del IPA)

### Mapas
- **8 Skirmish con geometría real**: S03, S04, S05, S06, S08, S09, S10 y
  S11 (los ocho bundles `Theme_01_Skirmish_XX`). Ya integrados.
- **S07 no está en el IPA** (solo existe en servidor). Nuestro S07 es de
  código.
- **La campaña no está en el IPA**: los niveles se descargaban del servidor
  (`BuildManifestLevelData.cs`). Lo que sí hay son sus **prefabs de
  gameplay** (`Theme_01_Levels_Gameplay[_DLC1]`): losas, puntos de
  control, bordes, tutoriales, cohete… material para reconstruir niveles.

### Personajes y cuerpos
- **9 cuerpos de clase** con malla y rig propios: `Soldier_Light`,
  `Soldier_Heavy`, `Agent_Light`, `Agent_Heavy`, `Medic`, `Medic_therapist`,
  `Engineer`, `Engineer_Light`, `Commander`.
- **17 personajes con nombre** con paquetes de traje: Hipster Dave,
  Sneaky Pete, Sister Florence, Archie Fletcher, Ivan Tkilya, Mme La
  Hacque, Soap, Big Time Taschmann, Megan McNick, Carlito Grosso, Spud,
  Textbook Kate, Riot Medic, Riot Agent, Riot Engineer, Comandante
  (masculino y femenino) — y variantes étnicas del Comandante (Latino,
  Asiático, Africano).
- **Trajes por personaje**: `*Outfits` y `*Outfits02` (DLC), 256² y 512².
  Los 7 primeros ya están integrados como modelos por clase.

### Habilidades (catálogo real de **44**)
`GameData.assetbundle` lista las habilidades con **icono** (`*_alpha`):
Walkshoot, Adrenaline, AR/HMG/Pistol/Shotgun/SMG/Sniper/Melee
Specialization, Armour Piercing, Backlash Aura, Backstab, Caltrops, Charm,
Concussion Grenade, Da Boot, Dead Eye Aura, Detection Aura, Frag Grenade,
Gas Grenade, Ghost, Hack, Healing Aura, Healing Grenade, Health Buff Aura,
Juggernaut (+ Passive), Kinetic Animal, Last Stand (+ Aura), Medkit,
Metabolism, Nail Mines, Revive, Rush Aura, Slayer, Support Fire, Swarm
Aura, Toolkit, Vampire, Bazooka, Crossbow, MolotovCocktail, WaterCannon.
De ellas, CSN tiene ya 14 equivalentes.

### Armas e iconos
- `Weapons`, `Weapons02`, `Weapons03`, `BasicWeapons`: prefabs y mallas de
  arma (los números vivían en servidor).
- Iconos de UI en `GameData`: capítulos (`Chapter01-03Icon`), candado
  (`LockIcon`), icono de nivel, iconos de habilidad con alfa.

---

## 2. Fases (exigentes, con criterio de aceptación)

### F1 · Catálogo completo del original (iconos e identificadores)
- Extraer los **iconos de las 44 habilidades** con alfa a `assets/ui/`.
- Extraer iconos de capítulo, candado y nivel.
- Tabla de las 44 con lo que CSN tiene y lo que falta.
**Aceptado** cuando las 44 están en `assets/ui/`, la tabla está en docs y no
falta ningún icono.

### F2 · Mapas completos
- Los 8 Skirmish: repaso de atmósfera y props por mapa (ya hay base).
- **Campaña**: reconstruir los niveles a partir de los prefabs de gameplay
  disponibles (losas, puntos de control, cohete) o diseñarlos con el motor
  actual siguiendo el original (tutorial + 5 misiones con objetivos:
  eliminar, capturar, escoltar, sobrevivir, jefe).
- S07 (mercado) y S01/S02: pulirlos para que no desentonen.
**Aceptado** cuando el juego tenga 8 Skirmish + 6 niveles de campaña
jugables, todos con su geometría o su set de props propio y captura.

### F3 · Interfaz del original (la gran pieza)
Reconstruir la estructura del original y colocar dentro lo que CSN añade:

| Pantalla del original | En CSN | Qué contiene |
|---|---|---|
| Título | Portada | PLAY ONLINE (aviso sin servidor), CHALLENGES, EXPANSIONS, QUICK GAME, monedas |
| Barracas (Barracks) | **Cuartel** (ya existe) | Tus personajes con nombre, trajes/skins, armas y desbloqueos |
| Selección de escuadra | Configuración de partida | Rol/personaje, arma y skin por hueco; puntos de escuadra |
| Tienda | **Armería** | Desbloquear personajes y skins con monedas |
| Campaña por capítulos | **Campaña** (5 misiones) | Capítulos con icono, progreso y candados |
| HUD de partida | HUD actual | Retratos, vida/energía, daño previsto, arco de vida, acción, registro |
| Resultados | Pantalla de fin | Pancarta, estadísticas y monedas |

Lo que CSN añade, en su sitio lógico:
- **Naciones y Guerra de Naciones** → evento destacado del título (ya).
- **Dominación y Escolta** → «modos extra» en la selección de partida.
- **Habilidades nuevas** → tarjeta de habilidad en el HUD con icono.
- **Cuartel/Armería** → sustituyen a Barracas/Tienda, mismo flujo.

**Aceptado** cuando la portada, el cuartel, la configuración y el HUD
usen la estética del original (compacta, tarjetas, iconos propios) sin
párrafos largos y con los mismos flujos que el original.

### F4 · Personajes y skins
- Usar los **9 cuerpos** y los **17 trajes** del IPA: cada personaje con
  su cuerpo y su uniforme.
- **Skins por nación**: colores de bandera en uniforme + emblema en el
  pecho; 12 naciones.
- **Personajes nuevos propios** sobre los cuerpos disponibles.
**Aceptado** cuando cada personaje con nombre del original tiene su
aspecto y las 12 naciones tienen skin legible.

### F5 · Presentación fiel
- **Audio del IPA** (voces y disparos por personaje/arma).
- Cámara, sacudida y efectos del original.
**Aceptado** cuando hay voz por personaje, disparo por arma y la cámara
respeta las cifras medidas.

### F6 · Calidad
En cada fase: sintaxis 0, tableros 13/13, suite 6/6, harness con números,
headless con `__csn3d.geo` y captura 2D. Commit y push por fase.

---

## 3. Deudas conocidas (a resolver dentro del plan)

1. **Modelos por clase**: extraídos e integrados (F8 lote 3), con escala
   normalizada por clase; hay que comprobar en pantalla que ninguno sale
   deformado.
2. **S07 y campaña**: no están en el IPA; se reconstruyen (F2).
3. **Números del original**: viven en servidor (paquetes UnityWeb); la
   fidelidad es estructural, no cifra a cifra.
4. **Arte propio definitivo**: los trajes del IPA son de Splash Damage;
   las skins propias y la UI nueva son el camino para publicar.

## 4. Criterio de «base reconocible» (checklist final)

- [ ] Título con las 4 entradas del original y monedas.
- [ ] Campaña por capítulos con iconos y progreso.
- [ ] Barracas/Cuartel con personajes con nombre y trajes.
- [ ] 8 mapas Skirmish + campaña jugable.
- [ ] 44 habilidades catalogadas (las que CSN tenga, con su icono).
- [ ] HUD con retratos, vida/energía, daño previsto y arco de vida.
- [ ] Audio por personaje y arma.
- [ ] Estética compacta cartoon en todas las pantallas.
