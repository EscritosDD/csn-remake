# Guía rápida — 3 modelos de Dani → juego

```powershell
# 1) dependencias (una vez)
pip install trimesh fast_simplification scipy pillow

# 2) los tres modelos (desde la raíz del repo)
python zai_adelgazar_modelos.py modelos_nuevos\Modelo1.fbx modelos_nuevos\Modelo2.fbx modelos_nuevos\Modelo3.fbx --tri-target 4000

# 3) validar cada salida contra las reglas del motor
python validar_salida_motor.py modelos_nuevos\Modelo1_zai Modelo1
python validar_salida_motor.py modelos_nuevos\Modelo2_zai Modelo2
python validar_salida_motor.py modelos_nuevos\Modelo3_zai Modelo3

# 4) copiar al juego
copy modelos_nuevos\Modelo1_zai\Modelo1.obj      assets\soldier\Modelo1.obj
copy modelos_nuevos\Modelo1_zai\Modelo1_rig.json assets\soldier\Modelo1_rig.json
copy modelos_nuevos\Modelo1_zai\Modelo1_tex.png  assets\soldier\Modelo1_tex.png
# (ídem Modelo2 y Modelo3)

# 5) registrar la clase en index.html (const ROLE_MODEL_FILES, línea ~4862)
#    y la escala en assets/soldier_scales.json si hace falta
```

Objetivo: cada modelo queda en **2.000–5.000 triángulos**, rig de 20 huesos
en el orden del rig base (los clips se aplican por índice), OBJ con la X ya
invertida y winding compensado (`parseOBJ3`), y textura lista.

Si algo se ve raro en tu Chrome: `window.__forceBaseModel=true` en consola
para volver al modelo base al instante, y captura para mí.
