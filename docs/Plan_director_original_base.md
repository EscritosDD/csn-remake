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

## 3.bis Estado a fecha de hoy (rondas 1-4 del objetivo)

| Fase | Estado | Evidencia |
|---|---|---|
| F1 catálogo | **hecho** | 42 iconos en `assets/ui/ability/`; `docs/Catalogo_habilidades_original.md` con las 44 y su estado (19 implementadas) |
| F2 mapas | **en curso** | 8 Skirmish reales + 6 misiones de campaña (la 6.ª, El convoy, escolta en Skirmish_10); ambiente en los 13 temas |
| F3 interfaz | **en curso** | título con Quick/Online/Challenges/Expansions/Cuartel/Armería; campaña por capítulos; Armería con catálogo; tabla de resultados; escuadra por hueco ya existente |
| F4 personajes | **en curso** | 7 modelos por clase del IPA; 17 personajes del reparto; 7 personajes propios; skin de nación con tinte y emblema; bando enemigo teñido; selector de personaje por rol |
| F5 audio | **hecho** | 77 clips (armas, voces, ambientes) conectados |
| F6 calidad | **en curso** | batería completa por ronda (sintaxis, tableros, tests, harness, headless) |

## 3.ter Decisión de vista (ronda 8)

**La vista 3D es la principal**, como el original. La vista 2D queda como
alternativa accesible (botón pequeño «Vista 2D (alternativa)») y solo se
usa para capturas si el 3D no arranca. `_capture_all.mjs` captura 3D por
defecto y la 2D únicamente con `--2d` o como respaldo; la verificación de
cada fase se hace con `__csn3d.geo` y capturas 3D.

## 3.quater Verificacion en un solo comando

```powershell
powershell -ExecutionPolicy Bypass -File bench\VERIFICAR.ps1
```

Hace las cinco comprobaciones: sintaxis del script inline, 13 tableros
(simetria y solapes), reglas del motor (`rules.test.js`), integridad de datos
(`data.test.js`: 12 naciones con personalidad, 17+12 personajes, 3 skins,
6 misiones, voces y los 7 modelos por clase) y humo 3D en navegador
(`_capture_all.mjs`, exige unidades y captura la imagen). Devuelve 0 si todo
pasa. Es el comando que deben usar las IAs que sigan el proyecto.

## 4. Criterio de «base reconocible» (checklist final)

- [x] Título con las 4 entradas del original, monedas en el chip y accesos
  directos (Quick, Online, Challenges, Expansions, Cuartel, Armería).
- [x] Campaña por capítulos con arte de icono, progreso x/y y candados
  (3 capítulos, 6 misiones).
- [x] Barracas/Cuartel con los 24 personajes (17 del original + 7 propios),
  su clase, su traje y selector de personaje por rol.
- [x] 8 mapas Skirmish reales + 6 misiones de campaña jugables, con capturas
  2D y 3D de todos.
- [x] 44 habilidades catalogadas con su icono del IPA en la Armería
  (42 iconos extraídos; 19 con equivalente en juego).
- [x] HUD con retratos, vida/energía, daño previsto, arco de vida y tabla de
  resultados (vivos/daño/derribos).
- [x] Audio del IPA: armas por categoría, voces por rol, ambiente por mapa
  y sonidos de habilidad.
- [x] Estética compacta cartoon en todas las pantallas (tarjetas a 2 líneas,
  mapas plegados, títulos cortos).

Pendiente para las siguientes rondas: campaña reconstruida con los prefabs
del original (los niveles del IPA son prefabs de gameplay, la geometría de
campaña venía del servidor), más variantes de skin y capturas de campaña.


## Aviso tecnico: insertar props por tema

En `buildThemedProps3` las ramas son una cadena `if(theme==='x'){ ... } else if...`.
Al anadir un bloque nuevo ANTES de una rama existente, hay que CERRAR el
bloque nuevo con su propia llave: es el error que mas veces ha aparecido
(quiosco de la plaza, noray, semaforo y cabina del puente). Regla practica:
todo bloque `if(theme===...){` que se inserte debe terminar en `}` antes de
la linea original, y `node bench/check-syntax.js` lo detecta al instante.
