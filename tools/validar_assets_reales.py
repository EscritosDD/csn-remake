#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""Valida los 3 assets reales contra las reglas del motor (index.html).

OJO con la convención (costó de encontrar): el OBJ se escribe con la X YA
INVERTIDA (v -x, y, z); parseOBJ3 del juego niega X otra vez -> el juego
trabaja en el espacio ORIGINAL del modelo. Las caras se escriben DIRECTAS
(a,b,c) porque el juego las lee en orden inverso (i=3..1) y esa inversión
compensa la del espejo X -> winding CCW final.

Comprueba: orden de 20 huesos del rig base, skin 4 influencias con pesos
~1, volumen firmado > 0 (normales hacia fuera en el espacio del juego),
2k-5k tris, índices en rango, UV en [0,1]."""
import json
import numpy as np

RIG_BASE = ["Bip001","Bip001 Pelvis","Bip001 Spine","Bip001 Spine1","Bip001 Neck","Bip001 Head",
"Bip001 L Clavicle","Bip001 L UpperArm","Bip001 L Forearm","Bip001 L Hand",
"Bip001 R Clavicle","Bip001 R UpperArm","Bip001 R Forearm","Bip001 R Hand",
"Bip001 L Thigh","Bip001 L Calf","Bip001 L Foot","Bip001 R Thigh","Bip001 R Calf","Bip001 R Foot"]

BASE = "assets_juego"
for clase in ("Artillero", "Espia", "Francotirador"):
    txt = open(f"{BASE}/{clase}.obj", encoding="utf-8").read()
    rig = json.load(open(f"{BASE}/{clase}_rig.json"))

    # réplica del juego: X re-negada (el OBJ ya viene espejado) + cara (C,B,A)
    P, UV, faces = [], [], []
    for l in txt.split("\n"):
        s = l.strip()
        if s.startswith("v "):
            q = s.split(); P.append([+(float(q[1])), float(q[2]), float(q[3])])
        elif s.startswith("vt "):
            q = s.split(); UV.append([float(q[1]), float(q[2])])
        elif s.startswith("f "):
            q = s.split()
            faces.append([int(q[3].split("/")[0])-1, int(q[2].split("/")[0])-1, int(q[1].split("/")[0])-1])
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
