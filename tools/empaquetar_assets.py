#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""Empaqueta las mallas decimadas (weld/<n>_D_*.npy) como assets del juego:
OBJ con X invertida y caras invertidas, para que parseOBJ3 (niega X, lee caras
directas y recalcula normales) deje volumen positivo; rig de 20 huesos en el
orden del rig base espejado en X, skinning por proximidad (4 influencias) y
textura PNG. Clases: Heavy_Gunner→Artillero, Shadow_Sentinel→Espía,
Ghillie_Guardian→Francotirador."""
import json, os
import numpy as np
import trimesh
from scipy.spatial import cKDTree
from rig_base import RIG_BASE_BONES, RIG_PARENTS

ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
WELD = os.path.join(ROOT, "weld")

# (x, y, z) fraccionales sobre la altura, humanoide estándar — igual que el
# pipeline validado, con brazos ligeramente caídos para la pose de armas.
FRAC = {
    "Bip001":           (0.00, 0.50, 0.00),
    "Bip001 Pelvis":    (0.00, 0.50, 0.00),
    "Bip001 Spine":     (0.00, 0.56, 0.00),
    "Bip001 Spine1":    (0.00, 0.63, 0.00),
    "Bip001 Neck":      (0.00, 0.75, 0.00),
    "Bip001 Head":      (0.00, 0.84, 0.00),
    "Bip001 L Clavicle":( 0.06, 0.75, 0.00),
    "Bip001 L UpperArm":( 0.13, 0.74, 0.00),
    "Bip001 L Forearm": ( 0.20, 0.73, 0.00),
    "Bip001 L Hand":    ( 0.26, 0.72, 0.00),
    "Bip001 R Clavicle":(-0.06, 0.75, 0.00),
    "Bip001 R UpperArm":(-0.13, 0.74, 0.00),
    "Bip001 R Forearm": (-0.20, 0.73, 0.00),
    "Bip001 R Hand":    (-0.26, 0.72, 0.00),
    "Bip001 L Thigh":   ( 0.05, 0.48, 0.00),
    "Bip001 L Calf":    ( 0.05, 0.26, 0.00),
    "Bip001 L Foot":    ( 0.05, 0.02, 0.06),
    "Bip001 R Thigh":   (-0.05, 0.48, 0.00),
    "Bip001 R Calf":    (-0.05, 0.26, 0.00),
    "Bip001 R Foot":    (-0.05, 0.02, 0.06),
}

MAP = {  # fichero de salida (clase del juego) <- modelo Meshy
    "Artillero":      "Heavy_Gunner",
    "Espia":          "Shadow_Sentinel",
    "Francotirador":  "Ghillie_Guardian",
}

OUT = os.path.join(ROOT, "assets_juego")
os.makedirs(OUT, exist_ok=True)

def build_rig(verts):
    """Rig espejado en X (convención del motor: pos (-x,y,z), quat espejo),
    posiciones locales, altura real de la malla."""
    lo, hi = verts.min(axis=0), verts.max(axis=0)
    h = hi[1] - lo[1]
    cx, cz = (lo[0]+hi[0])/2, (lo[2]+hi[2])/2
    world = {}
    for i, name in enumerate(RIG_BASE_BONES):
        fx, fy, fz = FRAC[name]
        world[i] = np.array([-(cx + fx*h), lo[1] + fy*h, cz + fz*h])
    bones = []
    for i, name in enumerate(RIG_BASE_BONES):
        p = RIG_PARENTS[i]
        local = world[i] if p < 0 else (world[i] - world[p])
        bones.append({"name": name, "pos": [float(x) for x in local],
                      "quat": [0.0, 0.0, 0.0, 1.0], "parent": p, "scale": [1, 1, 1]})
    return bones, world

def auto_skin(verts, world):
    tree = cKDTree(np.array([world[i] for i in range(len(world))]))
    d, idx = tree.query(verts, k=4)
    w = 1.0 / np.maximum(d, 1e-6)**2
    w = w / w.sum(axis=1, keepdims=True)
    return idx.astype(np.int32), w.astype(np.float32)

for clase, mesh_name in MAP.items():
    V = np.load(os.path.join(WELD, f"{mesh_name}_D_V.npy")).astype(np.float64)
    F = np.load(os.path.join(WELD, f"{mesh_name}_D_F.npy")).astype(np.int64)
    UV = np.load(os.path.join(WELD, f"{mesh_name}_D_UV.npy"))

    bones, world = build_rig(V)
    si, sw = auto_skin(V, world)

    # normales suaves de la malla decimada
    m = trimesh.Trimesh(vertices=V, faces=F, process=False)
    N = np.asarray(m.vertex_normals, dtype=np.float64)

    # --- OBJ: X invertida y caras invertidas (parseOBJ3 lee v1,v2,v3) ---
    obj = [f"# CSN — modelo propio de Dani (Meshy) decimado por el pipeline zai",
           f"# clase {clase} · fuente {mesh_name} · 4000 tris · X invertida y caras invertidas"]
    for v in V:
        obj.append("v %.6f %.6f %.6f" % (-v[0], v[1], v[2]))
    for uv in UV:
        obj.append("vt %.6f %.6f" % (uv[0], uv[1]))
    for n in N:
        obj.append("vn %.6f %.6f %.6f" % (-n[0], n[1], n[2]))
    for f in F:
        a, b, c = f[2], f[1], f[0]
        obj.append("f %d/%d/%d %d/%d/%d %d/%d/%d" % (
            a+1, a+1, a+1, b+1, b+1, b+1, c+1, c+1, c+1))
    with open(f"{OUT}/{clase}.obj", "w", encoding="utf-8") as fh:
        fh.write("\n".join(obj) + "\n")

    # --- rig json (formato del juego) ---
    rig = {"bones": bones, "skinBones": list(range(20)),
           "skinIndex": si.tolist(), "skinWeight": sw.tolist(),
           "boneInverses": [],  # autoconstantes: inv(world_i) en el juego
           "notes": "rig de caja generado por el pipeline zai; skinning por proximidad"}
    with open(f"{OUT}/{clase}_rig.json", "w", encoding="utf-8") as fh:
        json.dump(rig, fh)

    print(f"{clase} <- {mesh_name}: OBJ {len(V)} verts / {len(F)} tris · rig 20 huesos · skin {si.shape}")
print("assets en", OUT)
