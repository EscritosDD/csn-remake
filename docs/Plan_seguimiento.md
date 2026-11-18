# Seguimiento del plan de trabajo

Tabla de fases. Estado: pendiente / en curso / hecho / bloqueado.
Cada fase se marca hecha solo con su evidencia (números en este doc + commit).

| Fase | Estado | Evidencia | Commit |
|---|---|---|---|
| F0 Base y capturas | **hecho** | `_capture_all.mjs`: captura 3D real (640 KB) + 2D del tablero (1,03 MB) con `__csn3d.geo:true` y 0 errores | 234a5e3 |
| F1 Escolta | **hecho** | ver números abajo | (este commit) |
| F2 Equilibrio | **hecho** | tabla en docs/Equilibrio_medido.md (200+ partidas, muestras ampliadas) | c72f4d4 |
| F3 Informe CSN vs original | **hecho** | docs/Informe_CSN_vs_original.md (16 areas con fuentes) | b65db20 |
| F4 Contenido del original | **hecho** | 10 personajes, 4 cajas, empujon y 14 habilidades nuevas; 4 restantes documentadas como equivalentes. Detalle: lote 1: 10 personajes, 4 cajas de habilidad y empujon. lote 2: cobertura, gas y barrido. lote 3: molotov, caja de salud y teletransporte. lote 4: escudo, artilleria y abejas. lote 5: tranquilizante, canon de agua y kit. lote 6: torreta de cohetes y laser orbital | a64160d, 5f37dc1, 635f2d9, 0d251d6, fa1096b |
| F5 Mapas | **hecho** | props por tema (12 temas) + remates (fuente, grua, buzon/coches); suelo y props de juego ya texturizados | 15633bf, 8005cde |
| F6 Interfaz | **hecho** | arco de vida (2D y 3D), menu original con monedas, tutorial en bocadillo; el dano previsto y el HUD ya existian | 9a62989 + bfe888f |
| F7 Pantallas y assets | **hecho** | aistudio documentadas, iconos de estado en roster, iconos de objeto tipograficos, carga y victoria/derrota, decision CSS vs PNG | 87e82da |
| F8 Personajes y skins | **hecho** | lote 1: personalidad por nacion y anillo de rol. lote 2: 8 armas nuevas (37 total). lote 3: MODELOS POR CLASE del IPA (Soldier_Light/Heavy, Agent_Light/Heavy, Medic, Engineer, Commander) con su rig y textura | 0d8951b, 5d34682, (lote 3) |
| F9 UI minimalista | **hecho** | tarjetas a 2 lineas con texto al pasar, mapas plegados y pantalla Cuartel (tropas, skins, arsenal, desbloqueos) | 6cfd463 |

## F1 — Escolta: diagnóstico y arreglo (hecho)

**Síntoma medido antes**: la defensa ganaba 20/20; el dron quedaba en
(4-5,5) sin entregarse nunca (4/4 partidas, muerto).

**Causa raíz (trazada con `trace_escolta.js`, por acción de IA)**:
1. Solo el Médico guiaba el dron, y solo 1 casilla por ronda: al empujar,
   la escolta se quedaba atrás y el bucle de guiado se cortaba
   (`dist(u,d)>1`).
2. El candado `keepGuard` exigía otra escolta ya colocada en la casilla
   siguiente, así que el segundo guiado de la ronda era imposible.
3. El dron entraba a 180 PV y el fuego concentrado de la defensa (3-4
   unidades con críticos) lo mataba en 2-3 rondas, justo antes de llegar.

**Arreglo (mecánica + IA, medido)**:
- `guideDrone`: la escolta **camina con el dron** (se recoloca en la
  casilla que el dron deja libre), coherente con la regla "el dron avanza
  siempre con escolta al lado". Así el blindaje no se pierde al empujar.
- `tryGuideFwd`: guiado en cadena (empuja, se recoloca y vuelve a
  empujar) y sin el candado de escolta previa (ya la sostiene la propia
  escolta que acompaña).
- IA de escolta: cualquier soldado con energía guía (no solo el Médico);
  bonus para colocarse en el flanco este (delante del dron).
- Blindaje: daño ×0,47 (reducción ≈ 53 %) — verificado con prueba directa
  de `damage()` (100 → 47 con guardia pegado).
- El dron entra a 240 PV (su máximo de la regla).

**Barrido de equilibrio (20 partidas por punto, Almacén)**:

| PV · blindaje | Victorias A (escolta) | B (defensa) |
|---|---|---|
| 180 · ×0,4 | 1 | 19 |
| 200 · ×0,4 | 3 | 17 |
| 220 · ×0,4 | 19 | 1 |
| 240 · ×0,4 | 20 | 0 |
| 240 · ×0,45 | 16 | 4 |
| **240 · ×0,47** | **14** | **6** |
| 240 · ×0,48 | 13 | 7 |
| 240 · ×0,5 | 5 | 15 |
| 260 · ×0,5 | 17 | 3 |
| 280 · ×0,5 | 20 | 0 |

**Medición final (config elegida: 240 PV · ×0,47)**:
- Almacén, 20 partidas: **A 14 · B 6**, rondas medias 4,7, dron entregado
  en 14/20 (muere en (9,5) en las otras 6).
- Skirmish_03, 10 partidas: **A 7 · B 3**, rondas medias 5,9.

Veredicto: el modo pasa de imposible (0-20) a ganable (65-70 % escolta),
con el dron entregándose la mayoría de las veces. Queda en el límite de la
banda 70/30 del plan.


> Nota de herramienta: la captura 3D con ventana headful tapada no siempre
> arranca el render (rAF se estrangula en ventanas ocluidas). Para verificar
> estado, usar headless (el trazador _dbg.mjs da geo:true); para capturas,
> la ventana debe quedar visible.


## Estado tras las rondas del plan director (objetivo automatico)

- **F1 catalogo**: hecho. 42 iconos del IPA en `assets/ui/ability/` y
  `docs/Catalogo_habilidades_original.md` con las 44 y su estado.
- **F2 mapas**: 8 Skirmish reales + 6 misiones de campana, todas con
  captura 3D en `docs/Capturas_3D.md`; ambiente en los 13 temas y cielo
  propio por tema.
- **F3 interfaz**: titulo con el arte y logo del original, menu, campana
  por capitulos, armeria con catalogo, cuartel con 29 personajes, escuadra
  con retratos y personaje, resultados con estadisticas, reglas plegables.
- **F4 personajes**: 7 modelos por clase del IPA (malla+rig+textura),
  29 personajes (17 del original + 12 propios), skins Estandar/Clase/Nacion
  con tinte, cinta de casco, banda de mochila y emblema; enemigo teñido.
- **F5 presentacion**: 77 clips de audio del IPA (armas, voces, ambiente,
  habilidades) y camara que acompaña al disparo con sacudida.
- **F6 calidad**: bateria por ronda (sintaxis 0, tableros 13/13, rules.test
  6/6, harness con n>=30 en los modos cerrados, headless y capturas 3D).


## Cierre del objetivo automatico (rondas 1-47)

- **F1**: 42 iconos y catalogo de las 44 habilidades (`docs/Catalogo_habilidades_original.md`).
- **F2**: 8 Skirmish reales + 3 mapas de codigo + **6 tableros propios de campana**
  (19 tableros, todos simetricos y sin solapes) con props por tema, cielo y ambiente.
- **F3**: portada con el arte y logo del original, menu, campana por capitulos,
  Armeria en dos pestanas, Cuartel por clases con 35 personajes, resultados con
  tabla y escuadra, reglas y fichas plegables, configuracion en una linea.
- **F4**: 7 modelos por clase del IPA, 18 propios + 17 del original con bio y voz,
  cuatro skins (Estandar, Camuflaje, Clase, Nacion) con tinte, casco, mochila y
  emblema; enemigo teñido.
- **F5**: 195 clips del original (armas, voces por personaje, ambiente por mapa,
  musica de partida, habilidades), camara de accion y sacudida.
- **F6**: `VERIFICAR.ps1` con sintaxis, 19 tableros, reglas 6/6, datos 6/6 y humo
  3D; equilibrio medido con n>=30; 26 capturas 3D (que ya no se guardan en el repo), que ya no se guarda en el repo.
