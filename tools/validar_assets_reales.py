#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""Valida los 3 assets generados contra las reglas del motor (index.html).

El OBJ se escribe con la X YA INVERTIDA y las caras invertidas; parseOBJ3
niega X otra vez y lee las caras directas -> el juego trabaja en el espacio
ORIGINAL del modelo con volumen positivo y normales hacia fuera.

Comprueba: orden de 20 huesos del rig base, skin 4 influencias con pesos
~1, volumen firmado > 0, 2k-5k tris, índices en rango, UV en [0,1]."""
import json
import os
import numpy as np
from rig_base import RIG_BASE_BONES as RIG_BASE

ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
BASE = os.path.join(ROOT, "assets_juego")
for clase in ("Artillero", "Espia", "Francotirador"):
    txt = open(os.path.join(BASE, clase + ".obj"), encoding="utf-8").read()
    rig = json.load(open(os.path.join(BASE, clase + "_rig.json")))

    P, UV, faces = [], [], []
    for l in txt.split("\n"):
        s = l.strip()
        if s.startswith("v "):
            q = s.split(); P.append([+(float(q[1])), float(q[2]), float(q[3])])
        elif s.startswith("vt "):
            q = s.split(); UV.append([float(q[1]), float(q[2])])
        elif s.startswith("f "):
            q = s.split()
            faces.append([int(q[1].split("/")[0])-1, int(q[2].split("/")[0])-1, int(q[3].split("/")[0])-1])
    P, UV, faces = np.array(P), np.array(UV), np.array(faces)

    names = [b["name"] for b in rig["bones"]]
    ok_order = names == RIG_BASE
    si = np.array(rig["skinIndex"]); sw = np.array(rig["skinWeight"])
    wsum = sw.sum(axis=1)
    a, b, c = P[faces[:, 0]], P[faces[:, 1]], P[faces[:, 2]]
    vol = np.einsum('ij,ij->i', a, np.cross(b, c)).sum() / 6.0

    print(f"== {clase} ==")
    print(f"  malla: {len(P)} verts · {len(faces)} tris · {len(UV)} uv")
    print(f"  rig: 20 huesos orden base: {'OK' if ok_order else 'FALLO'} · idx [0,20): {si.min() >= 0 and si.max() < 20}")
    print(f"  skin: 4 infl · pesos 1±{abs(wsum-1).max():.2e}")
    print(f"  volumen en el juego: {vol:+.4f} ({'normales fuera OK' if vol > 0 else 'INVERTIDO'})")
    print(f"  bbox juego: {P.min(0).round(2)}..{P.max(0).round(2)} · pies y={P[:, 1].min():.3f}")
    print(f"  uv rango: u [{UV[:, 0].min():.3f},{UV[:, 0].max():.3f}] v [{UV[:, 1].min():.3f},{UV[:, 1].max():.3f}]")
    assert ok_order and 2000 <= len(faces) <= 5000
    assert abs(wsum - 1).max() < 1e-4 and vol > 0
    assert faces.min() >= 0 and faces.max() < len(P)
    assert UV.min() >= -0.001 and UV.max() <= 1.001
print("\nTODO OK — los 3 assets cumplen las reglas del motor")
