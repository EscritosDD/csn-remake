# Modelos propios de Dani (Meshy AI) en el juego — nov 2026

Tres diseños 3D nuevos de Dani, generados con Meshy AI, sustituyen la
malla del IPA en su clase. Llegaron con 125.000–232.000 triángulos cada
uno (objetivo del juego: 2.000–5.000) y **sin esqueleto**; el pipeline
`zai_adelgazar_modelos.py` (rama `zai/pruebas`, trabajo de Z.ai) los
convirtió a los assets que carga el motor.

## Qué modelo va a qué clase

| Modelo Meshy | Ficheros del juego | Clase | Origen |
|---|---|---|---|
| Heavy_Gunner | `assets/soldier/Artillero{.obj,_rig.json,_tex.png}` | Artillero | 203.336 → 4.000 tris |
| Shadow_Sentinel | `assets/soldier/Espia{...}` | Espía | 124.790 → 4.000 tris |
| Ghillie_Guardian | `assets/soldier/Francotirador{...}` | Francotirador | 232.126 → 4.000 tris |

**Sustituyen** la malla del IPA de esas tres clases (se sobrescriben los
ficheros `Artillero.obj` etc. del repo; los originales quedan en la
historia de git, recuperables con `git checkout main -- assets/soldier/`).

## Cómo se fabricaron (pipeline reproducible)

1. **Sueldado por posición**: los OBJ de Meshy separan `v`/`vt`/`vn` y
   duplican vértices en costuras de UV (132.940 `vt` vs 116.011 `v`);
   se sueldan por posición y el UV de cada vértice es el promedio de los
   UV de sus esquinas. Resultado: watertight, 0 aristas de borde.
2. **Decimación por quadrics** (algoritmo de Garland, `fast_simplification`)
   a 4.000 triángulos. Volumen firmado conservado, bbox intacto.
3. **UV transferidos** por vértice más cercano de la malla original.
4. **Escala horneada 0,90** en los vértices (1,9 → 1,71 de alto) porque
   el motor aplica `mesh.scale 0,95` fijo y la escala de clase va horneada
   en la geometría (regla §11.3 del examen). Pies exactamente a y=0.
5. **OBJ con la X ya invertida** (porque `parseOBJ3` niega X) y **caras
   en orden directo** (porque el parser lee los índices en orden inverso
   y esa inversión compensa la del espejo X).
6. **Rig de 20 huesos** en el orden del rig base (los clips se aplican
   por índice), espejado en X como los rigs del juego, con `boneInverses`
   autoconstantes: `inv(world_i)` del propio rig → error de bind ~1e-8
   (skinning cerrado, como exige §11.5).
7. **Skinning por proximidad**: 4 influencias por vértice, pesos 1/d²
   normalizados. No es skinning de escultor: las articulaciones son
   suaves, no perfectas.
8. **Textura**: la PNG 2048 de Meshy reescalada a 512 (mantiene silueta
   y color a tamaño de juego; ahorra 3,5 MB por modelo en carga).

## Verificación hecha (sin navegador)

Sintaxis 0 · tableros 19/19 · reglas 6/6 · datos 4/6 (los 2 fallos son
los conocidos de assets ausentes en el paquete de trabajo, no del cambio).
Validador propio (`validar_assets_reales.py`): orden de huesos, pesos,
volumen firmado +, bbox, UV — TODO OK.

## LO QUE DANI TIENE QUE VER (Z.ai no ve el 3D) — checklist zai-ver.ps1

1. Los tres modelos cargan en partida (nada de caer al modelo base
   con uniforme: se nota porque el Artillero de Meshy es muy distinto).
2. **Orientación**: frente hacia la cámara/arma (si sale de espaldas o
   girado 90°, es el espejo X — avisar a Z.ai).
3. **Caras visibles** (modelo hueco/semitransparente = winding).
4. **Textura aplicada** (gris plano = UV mal mapeados).
5. Animación `walk2h`: piernas y brazos se mueven, torso estable.
6. `fire2h`: postura de disparo sin retorcidos.
7. Silueta reconocible a 4.000 tris (pérdida aceptable de detalle).
8. Altura: ~1,7 de alto al lado de los soldados IPA (0,95 de escala).
9. Nada flotando ni hundido en el suelo (pies a y=0).

Si algo falla: `window.__forceBaseModel=true` en la consola del
navegador devuelve al modelo del IPA sin tocar nada, y captura para Z.ai.

## Pendiente (si el skinning de proximidad no convence)

Rig ajustado a mano: mover las posiciones de hueso a las articulaciones
reales de cada diseño (el pipeline usa fracciones humanoides estándar).
Con capturas de frente/perfil de cada modelo se afinan en una iteración.
