# Seguimiento del plan de trabajo

Tabla de fases. Estado: pendiente / en curso / hecho / bloqueado.
Cada fase se marca hecha solo con su evidencia (números en este doc + commit).

| Fase | Estado | Evidencia | Commit |
|---|---|---|---|
| F0 Base y capturas | **hecho** | `_capture_all.mjs`: captura 3D real (640 KB) + 2D del tablero (1,03 MB) con `__csn3d.geo:true` y 0 errores | 234a5e3 |
| F1 Escolta | **hecho** | ver números abajo | (este commit) |
| F2 Equilibrio | **hecho** | tabla en docs/Equilibrio_medido.md (200+ partidas, muestras ampliadas) | c72f4d4 |
| F3 Informe CSN vs original | **hecho** | docs/Informe_CSN_vs_original.md (16 areas con fuentes) | b65db20 |
| F4 Contenido del original | pendiente | - | - |
| F5 Mapas | pendiente | - | - |
| F6 Interfaz | pendiente | - | - |
| F7 Pantallas y assets | pendiente | - | - |
| F8 Personajes y skins | pendiente | - | - |
| F9 UI minimalista | pendiente | - | - |

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
