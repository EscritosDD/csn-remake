> **Nota de alcance:** este documento es histórico. Cita arte y material del original que vive fuera del repositorio (carpeta `_original/`), y capturas que no se guardan aquí por tamaño. No son enlaces rotos: son referencias al material de trabajo local.

# Auditoría independiente de CSN — DeepSeek Harness

**Fecha:** 17/11/2026 · **Alcance:** Fase 1 (repo contra docs y contra el código real). La Fase 2 (comparación contra el original descargado de archive.org) queda pendiente y se marca en su sección.

> Papel de este informe: es la auditoría independiente que pedía `Prompt_Hermes_CSN.md` — comparar lo que afirma el repositorio con lo que dice su propio código, y someter a prueba la auditoría del 16/11. No cambia ningún número del juego.

## Método

- Repo clonado: `github.com/EscritosDD/csn-remake` (rama `main`, commit `63266d6`).
- `index.html` (4.711 líneas, 19,2 MB) inspeccionado directamente; las citas `L####` son líneas reales de ese fichero.
- `docs/` cotejado contra los PDF de la carpeta de trabajo (mismo contenido, texto fuente de verdad).
- No se ha descargado aún el original (build Chrome ni IPA): ver sección 5.

---

## 0. Fuentes del original — metadatos verificados (Fase 2, sección 1)

Verificado contra `archive.org/metadata/...` (metadatos; descarga de binarios aún pendiente):

| Fuente | Fichero | Tamaño | Contenido |
|---|---|---|---|
| `archive.org/details/rad-soldiers` | `rad-soldiers-assembly-csharp-decompiled.zip` | 2.476.556 B · 1.583 ficheros | Assembly-CSharp descompilado |
| ídem | `rad-soldiers-unity3d-unpacked-quickbms.zip` | 94.471.362 B · 17 ficheros | assets Unity (level0-3, mainData, resources.assets, sharedassets0-4) |
| ídem | `rad-soldiers.zip` | 165.286.837 B · 85 ficheros | build Chrome (NaCl) |
| `archive.org/details/virtually-extinct-ipas` | `RAD_Soldiers_v1_0_9.ipa` | 77.161.300 B · 128 ficheros · md5 `f5ce3ca7…` · sha1 `32f9be62…` | IPA iOS con `Data/Raw` |

Coincide con lo que afirman los documentos (`RAD_Soldiers_v1_0_9.ipa`, 73,6 MB; build Chrome descompilada y `.assets`). Nota menor: `Referencia_original.md` dice que el zip desempaquetado pesa «113 MB»; archive.org lo lista en 94,47 MB. La descarga y extracción del contenido (los 60 assetbundles de `Data/Raw`, mallas, mapas, clips) queda para la Fase 2 completa.

---

## 1. Veredicto sobre la auditoría del 16/11 (sección 3 del prompt)

### Conclusión 1 — «No hay banco ejecutable; la auditoría de 113 comprobaciones existe solo como texto» → **CONFIRMADA**

- El repo solo contiene: `README.md`, `index.html`, `assets/soldier_clips.json` y `docs/*.md`. **No hay ningún fichero de banco ejecutable** (ni `package.json`, ni `test/`, ni script de `node --check`, ni `report.json`).
- En `index.html` no existen `autoplay` ni `simulate` (búsqueda exhaustiva: 0 coincidencias).
- La entrada de la página que dice «113 comprobaciones, 0 fallos … ejecutando el motor del juego fuera del navegador» (`L464`) es **prosa**, sin artefacto que la respalde. La palabra «verificado con banco» no tiene banco detrás en el repo.

### Conclusión 2 — «Dominación/Escolta/campaña/dificultades SIN VERIFICAR por banco; humo/Claymore/M84/sonido en código, no en vivo» → **CONFIRMADA** (constantes presentes en código, banco ausente)

Las constantes SÍ están en el código (lo que la auditoría llamó «correctas por lectura»):

| Sistema | Código | Cita |
|---|---|---|
| Escolta | `ESCORT_MAX_ROUNDS=15, ESCORT_DRONE_MAXHP=180, ESCORT_DRONE_HP=120, ESCORT_GUIDES_PER_ROUND=2` | `L773` |
| Dificultad Veterano | `maxEnergy+=1` | `L1503` |
| Dificultad Élite | `maxEnergy+=2; maxHp+=25` | `L1503` |
| Daño Recluta / Élite | `dmg*0.85` / `dmg*1.15` | `L1611` |
| M84 | `FLASH_COST=2, FLASH_RANGE=4, STUN_ENERGY_PEN=6, STUN_AIM_PEN=25` | `L1804` |

Pero **no existe banco ejecutable en el repo** que las ejercite; la calificación «SIN VERIFICAR por banco» es correcta. La ausencia de `autoplay`/`simulate` confirma también que «ninguna partida completa registrada» y «arma en reposo SIN VERIFICAR» son coherentes.

### Conclusión 3 — «Los 13 tableros cuadran por cómputo manual; tabla medida» → **REFUTADA en 3 celdas (la auditoría erró; la página tenía razón)**

La tabla «medida» **no es consistente entre los propios artefactos del proyecto**:

| Tablero (baliza / dron / libres) | Auditoría 16/11 (`Desarrollo_continuo.md`) | Página del juego (`L464`) | ¿Coinciden? |
|---|---|---|---|
| Almacén | 11 / **21** / 114 | 11 / **22** / 114 | ❌ dron 21 vs 22 |
| Patio | 8 / 17 / 118 | 8 / 17 / 118 | ✅ |
| S01 | 6 / 11 / 114 | 6 / 11 / 114 | ✅ |
| S02 | 6 / 11 / 114 | 6 / 11 / 114 | ✅ |
| S03 | 7 / **19** / 116 | 7 / **15** / 116 | ❌ dron 19 vs 15 |
| S04 | **7** / 13 / 116 | **6** / 13 / 116 | ❌ baliza 7 vs 6 |
| S05–S11 | … | … | ✅ |

**Resuelto con banco ejecutable** (`bench/boards.js`, subido al repo): replica `pathDist` (BFS, `L1426`) sobre los `MAP_DEFS` reales y mide los 13 tableros. Resultado: **la página (`L464`) es correcta en los 13; la auditoría del 16/11 erró en 3 celdas** — Almacén dron **22** (no 21), Skirmish_03 dron **15** (no 19), Skirmish_04 baliza **6** (no 7). Además `Desarrollo_continuo.md` es internamente inconsistente (a las ~18:24 dice «Almacén 22», la auditoría profunda dice «21, no 22»). La afirmación de que la tabla quedaba «cerrada por cómputo manual» queda refutada: el cómputo manual se equivocó, y solo un banco ejecutable lo destapa. Los 13 tableros sí pasan simetría 180° y 0 solapes (confirmado por el banco).

### Conclusión 4 — «Conteo cerrado: 8 originales (03,04,05,06,08,09,10,11); 01,02,07 invención; la geometría de S05,S06,S08,S09,S10,S11 SÍ existe» → **CONFIRMADA**

- El conteo de 8 originales y de `01/02/07` como invención está en `L458` y `L460`.
- La página **se contradice a sí misma**: `L424–427` dicen «su paquete *no está* entre los extraídos», pero `L458` dice «el IPA guardaba los ocho … **cada uno con su geometría, su layout y sus texturas**». La segunda es la correcta; la frase «cuando su paquete se extraiga algún día» (en `L426` S07, `L428` S01, `L429` S02) es obsoleta/falsa.
- Solo `Skirmish_03` (84.939 vértices) y `Skirmish_04` (80.571) están incrustados (`L3500`, `L3501`, `L3519`, `L3520`). Los otros seis no están integrados.

### Conclusión 5 — Fallos nuevos detectados en código → **CONFIRMADA** (con citas)

| Fallo | Código | Veredicto |
|---|---|---|
| Espía fuma hacia el dron en Escolta (bloquea a su bando) | `L2129–2135`: `const foe=drone||target` → lanza humo hacia el dron al que la defensa debe destruir | ✅ |
| Espía quema el humo sin condiciones | `L2129–2134`: fuma si `cheb(u,foe)<=6 && hasLOS`, sin mirar dificultad ni calidad de tiro | ✅ |
| Veteranía farmeable sin límite | `L2010–2014`: `vet[s]=(vet[s]||0)+1` en **cada** victoria, sin tope ni chequeo de misión ya superada | ✅ |
| Reanimación solo Élite (página la da en Veterano y Élite) | `L2091`: `if(deadAlly && G.difficulty==='elite' ...)` vs página `L329`/`L443` «Veterano y Élite … revive» | ✅ |
| Fuego concentrado también en Normal y Veterano (página solo Élite) | `L2182–2183`: sort por `a.hp-b.hp` para **todo** salvo Recluta vs página `L505`/`L631` | ✅ |
| Impacto directo 0,79 (página) vs 0,90 (código) | página `L465` «0,79 entrando directo» vs código `L3838` «0,90 dejándolo entrar directo» | ✅ |
| `hitChance` resta 25 fijo, no `STUN_AIM_PEN` | `L1474`: `if(shooter.stunned)p-=25` (literal) vs constante `STUN_AIM_PEN=25` en `L1804` | ✅ |

### Conclusión 6 — «Medición de equilibrio bloqueada: no hay harness IA contra IA ni simulate» → **CONFIRMADA**

No existen `autoplay`, `simulate`, ni ningún harness de IA-contra-IA en el código ni en el repo. La tabla de equilibrio está vacía por ese motivo, tal como afirma la auditoría.

---

## 2. Hallazgos nuevos (sección 4 del prompt)

**A. `Diseno_del_juego.md` está desactualizado frente al código** (la auditoría del 16/11 no lo lista):

| Regla | `Diseno_del_juego.md` | Código (`index.html`) |
|---|---|---|
| Curar del Médico | «curar 125 de vida» | 80 PV (`L1898`) |
| Reanimar | «vuelve con 60 de vida» | 80 PV (`L1893`) |
| Orden de mando del Capitán | «recupera 4 de energía» | +3 (`L1904`) |

**B. La tabla de los 13 tableros discrepa entre la auditoría y la página, y la equivocada es la auditoría** (resuelto con `bench/boards.js`): Almacén dron 22 (no 21), Skirmish_03 dron 15 (no 19), Skirmish_04 baliza 6 (no 7).

**C. Higiene del repo:** `README.md` dice literalmente «**Repositorio privado**: el juego incluye modelos, texturas y animaciones extraídos del original» cuando el repo es **público**; y no hay `LICENSE`. Detalle en sección 4.

---

## 3. Comparación repo ↔ docs (sección 2 del prompt, parcial)

Verificación de consistencia interna (repo contra sus propios documentos), sin el original:

| Afirmación del proyecto | Estado | Prueba |
|---|---|---|
| 7 roles, vida/energía por cuerpo (200/12, 250/14, 300/18) | ✅ coherente | `L1498–1508` |
| 13 tableros (Almacén + Patio + S01–S11) | ✅ coherente | `L286`, `L329`, `L479–489` |
| Solo S03/S04 con geometría real; el resto en código | ✅ coherente | `L458`, `L3500–3520` |
| Three.js vendorizado (sin CDN) | ✅ coherente | `L11`, `L4560` (`data:application/javascript`) |
| Malla `Soldier_Light` (1.211 vértices, 18 huesos) | ✅ coherente | `L3471`, `L437`, `L448` |
| 22 clips de animación (soldier_clips.json + copia incrustada) | ✅ coherente | `assets/soldier_clips.json`, `L3807` |
| «verificado con banco» | ❌ sin banco ejecutable en el repo | ausencia de artefacto |

> La comparación **contra el original** (cobertura direccional de 4 niveles, cámara 50°/8,5/37,5°, rig Bip001, clips, geometría/layout Skirmish, turnos y energía) exige descargar el original y queda en Fase 2 (sección 5).

---

## 4. Higiene del repo (urgente)

1. **Visibilidad.** El repo está público pero su README lo declara privado y admite por escrito que incrusta assets del original. Decisión de Dani (la deploy key no puede cambiar la visibilidad): volver a privado, o público sin assets derivados del IPA.
2. **Assets del original.** `index.html` incrusta malla + textura del soldado y geometría/texturas de `Skirmish_03`/`04`; `assets/soldier_clips.json` son 22 clips derivados del IPA. Son assets de Splash Damage/WarChest y **no deben redistribuirse**.
3. **LICENSE.** No hay licencia. No se puede licenciar lo que no es propio (los assets del original); la decisión sobre el código propio es de Dani.

---

## 5. Pendiente de Fase 2 (secciones 1 y 5 del prompt)

Queda por hacer, descargando el original de archive.org:

1. **Fuentes descargadas** — `archive.org/details/rad-soldiers` (Chrome descompilado) y `archive.org/details/virtually-extinct-ipas` (IPA iOS, `Data/Raw`, 60 assetbundles): URL exacta, fecha, tamaño y contenido.
2. **Comparación repo ↔ original** — turnos/energía por cuerpo, victoria por baliza en 5 turnos, cobertura direccional, cámara, proporciones soldado/arma, rig Bip001, clips, geometría/layout Skirmish y conteo de mapas, marcando COINCIDE / NO COINCIDE / NO VERIFICABLE con el archivo concreto.
3. **Riesgos del 3D** — qué le falta al 3D del remake frente a lo que el original trae (mallas, clips, mapas, texturas), en piezas concretas, sin proponer copiar assets.

---

## 6. Fase 2 (parte 1, hecha): comparación contra el original — código descompilado

Descargué `rad-soldiers-assembly-csharp-decompiled.zip` de archive.org (2.476.556 B, verificado contra el metadata) y lo extraje: **1.578 ficheros `.cs`**. Cotejé las afirmaciones de `docs/Referencia_original.md` contra ese código real. Resultado: **todas COINCIDEN** en lo verificable:

| Afirmación del repo | Código real | Veredicto |
|---|---|---|
| Victoria por baliza en 5 turnos | `ControlPointManagerComponent.cs:11` `TurnsToCaptureZone = 5` | COINCIDE |
| Fuego de respuesta por defecto | `WeaponGameplayData.cs:27` `AllowsReturnFire = true` | COINCIDE |
| Puntos de escuadra por defecto 3 | `WeaponGameplayData.cs:36` `SquadPoints = 3` | COINCIDE |
| Fuego de reacción por turno | `AbilityGameplayData.cs:26` `MaxOpFirePerTurn` | COINCIDE |
| Esquema de cuerpo (vida/energía/coste) | `UnitBodyType.cs:11-13` `MaxHealth`, `BasicActionPoints`, `ActionPointsPerMove` | COINCIDE (esquema) |
| Empujón (alcance 1) | `WeaponGameplayData.cs:34-35` `KnockbackDistance`, `KnockbackRange = 1` | COINCIDE |
| Línea de visión por raycast | `GameGridComponent.cs:40` `TestLineOfSight` | COINCIDE |
| Cobertura direccional 4 niveles por borde | `GameTileComponent.cs:17-21` `WestCover/EastCover/NorthCover/SouthCover` + `VisBlocker` | COINCIDE |
| Matriz de cobertura 2 bits (0–3) | `CoverMap.cs:72` `MaxValue = (1<<n)-1` | COINCIDE |
| Cámara pitch 40°/60° | `CameraController.cs:92-93` | COINCIDE |
| Cámara distancia 6/11 | `CameraController.cs:94-95` | COINCIDE |
| Cámara FOV 30°/45° | `CameraController.cs:96-97` | COINCIDE |
| Giro `turnRate = 5` (×5 ratón) | `CameraController.cs:98-99` | COINCIDE |
| Yaw inicial 335° | `CameraController.cs:106` | COINCIDE |
| Zoom interno 0,7×z + 0,15 | `CameraController.cs:1059` | COINCIDE |
| Zoom usuario por defecto 0,5 | `CameraController.cs:187` | COINCIDE |

**Discrepancias menores:**
- `Referencia_original.md` dice «528 archivos .cs»; el zip real trae **1.578**. (No afecta a las cifras, pero el conteo de ficheros está mal.)
- Los **valores** de vida/energía por cuerpo (200/12/1, 250/14/2, 300/18/3) **no están en el `.cs`** (viven en los assets Unity `sharedassets0.assets`). El repo ya lo marcaba como «leído de los assets», así que es NO VERIFICABLE desde el código descompilado, correctamente señalado.

**Pendiente de Fase 2 (parte 2):** el IPA iOS (`RAD_Soldiers_v1_0_9.ipa`, 73,6 MB) para verificar mallas, texturas, mapas Skirmish y clips (la parte de arte, que no se puede comprobar con el código).

---

## 7. Fase 2 (parte 2, hecha): verificación del IPA (arte)

Descargué `RAD_Soldiers_v1_0_9.ipa` (77.161.300 B, coincide con archive.org y con el «73,6 MB» de los docs) y lo extraje. Resultado:

- **`Data/Raw` contiene 72 assetbundles** (los docs decían «60»; discrepancia menor de conteo).
- **Conteo de mapas CONFIRMADO por disco**: hay 8 `Theme_01_Skirmish_XX` — 03, 04, 05, 06, 08, 09, 10, 11 — y **NO hay 01, 02 ni 07**. La conclusión 4 de la auditoría del 16/11 (8 números originales; 01/02/07 invención del remake) queda **CONFIRMADA**.
- **La geometría real de S05, S06, S08, S09, S10 y S11 SÍ existe** (assetbundles de 6,2–8,4 MB con mallas y texturas). La afirmación de la página de que «su paquete no está entre los extraídos» era falsa, como ya señaló la auditoría.
- **Vértices medidos con UnityPy** (confirman las cifras de la auditoría):

| Paquete | Mallas | Vértices medidos | Auditoría 16/11 | |
|---|---|---|---|---|
| S05 | 32 | 61.593 | 61.617 | ✅ |
| S06 | 31 | 69.512 | 69.570 | ✅ |
| S03 | 45 | 85.777 | 85.818 (OBJ) | ✅ |
| S04 | 42 | 81.660 | 81.701 (OBJ) | ✅ |

- `Characters.assetbundle` trae 48 texturas (los retratos `char-*`) y 0 mallas: la malla con skinning del soldado no vive en `Characters` sino en otro paquete (los docs la sitúan en `mallas_soldado/`).

Con esto, **la Fase 2 queda completa**: las reglas/cámara/cobertura (código descompilado) y el arte/mapas (IPA) del repo están verificados contra el original real, y las 6 conclusiones del 16/11 tienen veredicto con prueba.
