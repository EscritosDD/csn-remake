# Personajes propios de Dani (Meshy AI) — guía breve para Studio

Tres diseños 3D de Dani, generados con Meshy AI y procesados para el juego.
Están en `assets/personajes_propios/` como **añadido**: no sustituyen nada.
El juego sigue cargando las mallas del IPA de `assets/soldier/`.

## Qué hay

| Modelo Meshy | Clase | Ficheros | Triángulos |
|---|---|---|---|
| Heavy_Gunner | Artillero | `Artillero{.obj,_rig.json,_tex.png}` | 203.336 → 4.000 |
| Shadow_Sentinel | Espía | `Espia{.obj,_rig.json,_tex.png}` | 124.790 → 4.000 |
| Ghillie_Guardian | Francotirador | `Francotirador{.obj,_rig.json,_tex.png}` | 232.126 → 4.000 |

## Cómo se hicieron

Pipeline `zai_adelgazar_modelos.py` (trabajo de Z.ai): decimación por
quadrics a 4.000 tris, OBJ con la X ya invertida (regla de `parseOBJ3`),
rig de 20 huesos en el orden del rig base (los clips se aplican por
índice), skinning por proximidad (4 influencias, pesos 1/d²) y textura
reescalada de 2048 a 512. Escala horneada 0,90 (1,9 → 1,71 de alto),
pies a y=0. Detalle y verificación en `docs/Modelos_propios_Meshy.md`
(rama `zai/pruebas`).

## Cómo usarlos

Para probarlos en una clase, copia sus tres ficheros a
`assets/soldier/<Clase>.obj`, `<Clase>_rig.json` y `<Clase>_tex.png`
(el juego ya carga `assets/soldier/<Clase>.obj` por su cuenta; no hace
falta tocar código). Para volver al modelo del IPA, restaura esos
ficheros desde la historia de git. Si algo falla al verlos:
`window.__forceBaseModel=true` en la consola devuelve al modelo base.

## Checklist visual (Studio no ve el 3D; lo revisa Dani)

1. Los tres modelos cargan (no caen al modelo base).
2. Frente hacia el arma (de espaldas o girado 90° = espejo X).
3. Caras visibles (hueco = winding).
4. Textura aplicada (gris plano = UV).
5. `walk2h`: brazos y piernas se mueven, torso estable.
6. `fire2h`: postura de disparo sin retorcidos.
7. Silueta reconocible a 4.000 tris.
8. Altura ~1,7 junto a los soldados IPA.
9. Pies a y=0, nada flotando ni hundido.
