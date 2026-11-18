#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""Suelda los OBJ Meshy por posición (las costuras de UV duplican vértices),
promedia UV por grupo y guarda V/F/UV por modelo en work/weld/."""
import glob, os
import numpy as np
import trimesh

os.makedirs("weld", exist_ok=True)

def weld_by_position(path):
    # las caras traen vi/ti/ni con ti INDEPENDIENTE de vi (más vt que v):
    # se parsean las parejas reales y el UV de cada vértice es el promedio
    # de los UV de las esquinas que lo referencian.
    V, UV, corners = [], [], []
    for line in open(path, encoding="utf-8", errors="ignore"):
        p = line.split()
        if not p:
            continue
        if p[0] == "v":
            V.append((float(p[1]), float(p[2]), float(p[3])))
        elif p[0] == "vt":
            UV.append((float(p[1]), float(p[2])))
        elif p[0] == "f":
            for t in p[1:4]:
                vi, ti, _ = (t.split("/") + ["", "", ""])[:3]
                corners.append((int(vi) - 1, int(ti) - 1 if ti else -1))
    V = np.array(V); UV = np.array(UV) if UV else None
    key = np.round(V, 5)
    uniq, inv = np.unique(key, axis=0, return_inverse=True)
    faces = np.array(corners, dtype=np.int64).reshape(-1, 3)
    # caras válidas: vi dentro de rango (descarta vértices negativos del OBJ)
    ok = np.all(faces >= 0, axis=1) & (faces[:, 0] < len(V))
    faces = faces[ok]
    if UV is not None:
        ti = faces[:, 1]
        good = (ti >= 0) & (ti < len(UV))
        newUV = np.zeros((len(uniq), 2)); cnt = np.zeros(len(uniq))
        np.add.at(newUV, inv[faces[good, 0]], UV[ti[good]])
        np.add.at(cnt, inv[faces[good, 0]], 1)
        cnt[cnt == 0] = 1
        newUV /= cnt[:, None]
    else:
        newUV = None
    newF = inv[faces[:, 0]]
    return newF, uniq, newUV, len(V), len(uniq)

for root in sorted(glob.glob("raw/*/Meshy_*")):
    name = root.split("Meshy_AI_")[-1].split("_2026")[0].rstrip("/")
    F, V, UV, nv0, nv1 = weld_by_position(glob.glob(root + "/*.obj")[0])
    F = np.asarray(F, dtype=np.int64).reshape(-1, 3)
    np.save(f"weld/{name}_V.npy", V.astype(np.float32))
    np.save(f"weld/{name}_F.npy", F.astype(np.int32))
    if UV is not None:
        np.save(f"weld/{name}_UV.npy", UV.astype(np.float32))
    m = trimesh.Trimesh(vertices=V, faces=F, process=False)
    uniq, counts = np.unique(m.edges_sorted, axis=0, return_counts=True)
    print(f"{name}: {nv0}->{nv1} verts · borde {int((counts==1).sum()/2)} · watertight {m.is_watertight} · tris {len(m.faces)}")
