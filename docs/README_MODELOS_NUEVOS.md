# README — Los 3 modelos nuevos de Dani en el juego

Este paquete resuelve lo que avisaste: **tres diseños 3D nuevos, 125.000–232.000
triángulos cada uno, cuando el objetivo del juego es 2.000–5.000**, y hay que
**riggearlos al esqueleto para que se muevan** con las animaciones del juego.

## Qué hay en este paquete

| Fichero | Qué es |
|---|---|
| `zai_adelgazar_modelos.py` | El pipeline: decima la malla a 2k–5k tris, genera el OBJ con la X invertida y las caras invertidas (regla de `parseOBJ3`), el rig de 20 huesos **en el orden del rig base** y la textura |
| `validar_assets_reales.py` | Valida la salida contra las reglas del motor (réplica de `parseOBJ3`): orden de huesos, pesos, round-trip de la X, rango de triángulos y UV |
| `guia_rapida.md` | Los 5 comandos exactos para tus 3 modelos |

## Lo que hace el pipeline (y por qué)

Cada regla viene de `docs/Examen_para_continuar.md` §9 y §11 (la receta
cerrada de las 7 mallas de clase):

1. **Decimación por quadrics** (`fast_simplification`, algoritmo de Garland
   que es el estándar de Blender) a `--tri-target 4000` por defecto.
2. **OBJ con la X invertida**: `parseOBJ3` en `index.html` niega el eje X
   (`P.push([-(+p[1]), ...])`), así que la malla se escribe espejada para que
   al parsearla vuelva a la geometría correcta.
3. **Caras invertidas**: `parseOBJ3` lee los índices directos
   (`for(i=1;i<=3;i++)`) y recalcula las normales desde la geometría; por eso
   el OBJ se escribe con el orden de caras invertido para dejar volumen
   positivo y caras visibles en el juego.
4. **Rig de 20 huesos en el ORDEN del rig base** (`Bip001…`, el de
   `assets/soldier_rig.json`): los clips de `soldier_clips.json` se aplican
   **por índice de hueso**, no por nombre, así que este orden es innegociable.
5. **Skning automático por proximidad** (4 influencias, pesos 1/d²
   normalizados): suficiente para que los clips muevan la malla; si tus
   modelos traen pesos propios y quieres conservarlos, ver «Rig real» abajo.
6. **Textura**: la embebida del GLB/FBX si la hay, o `<nombre>_tex.png`
   junto al modelo; si no hay nada, una neutra para que el material no falle.

## Los 5 comandos (en tu repo, con Python 3.10+)

```powershell
pip install trimesh fast_simplification scipy pillow

# desde la raíz del repo, con los modelos en modelos_nuevos\
python zai_adelgazar_modelos.py modelos_nuevos\Modelo1.fbx modelos_nuevos\Modelo2.fbx modelos_nuevos\Modelo3.fbx --tri-target 4000

# revisar el informe de cada uno
type modelos_nuevos\Modelo1_zai\Modelo1_informe.json

# validar la salida contra las reglas del motor
python validar_salida_motor.py modelos_nuevos\Modelo1_zai Modelo1
```

La salida por modelo queda en `modelos_nuevos/<Nombre>_zai/`:

```
<Nombre>.obj            → copiar a assets/soldier/<Nombre>.obj
<Nombre>_rig.json       → copiar a assets/soldier/<Nombre>_rig.json
<Nombre>_tex.png        → copiar a assets/soldier/<Nombre>_tex.png
```

Y para que el juego los cargue, añade la clase en `index.html` (línea ~4862):

```javascript
const ROLE_MODEL_FILES={'Francotirador':'Francotirador', ... ,'Modelo1':'Modelo1'};
// (o sustituye el fichero de una clase existente para probarla sin tocar datos)
```

`ROLE_SCALES` (`assets/soldier_scales.json`) fija la escala si la necesitas.

## Rig real vs rig de caja

El pipeline genera un **rig de caja humanoides** (posiciones fraccionarias
estándar ajustadas a la altura de tu malla) + **skinning por proximidad**.
Es el arranque más rápido: los clips del juego moverán brazos, piernas y
columna desde el primer minuto.

Si tus modelos traen **esqueleto y pesos propios** (FBX/GLB con skinning),
la vía limpia es reaprovecharlos: el script trae el hueco preparado
(`rig_source` en el informe marca «A REVISAR»), pero la conversión
FBX→formato del juego es específica de cada exportador. Con el pipeline
validado en verde, mi recomendación: **primero caja+proximidad (ya
funciona), y afinamos con el rig real en cuanto veamos cómo exporta tu
herramienta**.

## Verificación (tú, con ojos)

Yo no puedo ver el 3D (sandbox sin WebGL). Lista para tu `zai-ver.ps1`:

1. El modelo carga en partida (sin caer al modelo base).
2. Se ve **desde fuera** (caras no culled) — prueba el winding.
3. La **X no está espejada** respecto a tus capturas del original.
4. La **textura** se aplica (no gris plano).
5. Camina: brazos y piernas se mueven con el clip `walk2h`.
6. Dispara: la postura `fire2h` se ve natural (sin retorcimientos).
7. La silueta a 4000 tris **conserva la lectura** del diseño original.
8. Nada de bolos flotando ni extremidades colapsadas (síntomas §5 del examen).

Si algo falla: `window.__forceBaseModel=true` en la consola devuelve al
modelo base sin tocar nada, y me mandas captura.
