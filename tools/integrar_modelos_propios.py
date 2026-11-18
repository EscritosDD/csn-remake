"""Integra los modelos Meshy en el rig del IPA usando solo Python estandar.

Los OBJ de Meshy estan en Y arriba; el motor espera Z arriba (como los
assets del IPA). Ademas, el rig de caja generado por el pipeline no comparte
la jerarquia ni la pose de reposo del rig original, asi que los clips por
indice retorcian los brazos. Este script reutiliza el rig base del IPA:
malla rotada a Z arriba, huesos del original escalados a 1,71 m y pesos
recalculados por proximidad a los segmentos oseos.
"""

import json
import math
import os
import shutil

ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
PROPIOS = os.path.join(ROOT, "assets", "personajes_propios")
SOLDADO = os.path.join(ROOT, "assets", "soldier")
CLASES = ("Artillero", "Espia", "Francotirador")


def qmul(a, b):
    x1, y1, z1, w1 = a
    x2, y2, z2, w2 = b
    return (
        w1 * x2 + x1 * w2 + y1 * z2 - z1 * y2,
        w1 * y2 - x1 * z2 + y1 * w2 + z1 * x2,
        w1 * z2 + x1 * y2 - y1 * x2 + z1 * w2,
        w1 * w2 - x1 * x2 - y1 * y2 - z1 * z2,
    )


def qmat(q):
    x, y, z, w = q
    return (
        (1 - 2 * (y * y + z * z), 2 * (x * y - z * w), 2 * (x * z + y * w)),
        (2 * (x * y + z * w), 1 - 2 * (x * x + z * z), 2 * (y * z - x * w)),
        (2 * (x * z - y * w), 2 * (y * z + x * w), 1 - 2 * (x * x + y * y)),
    )


def mv(m, v):
    return tuple(sum(m[i][j] * v[j] for j in range(3)) for i in range(3))


def world_bones(bones):
    out = []
    for b in bones:
        q = tuple(b["quat"])
        p = tuple(b["pos"])
        if b["parent"] >= 0:
            pp, pq = out[b["parent"]]
            p = tuple(pp[i] + mv(qmat(pq), p)[i] for i in range(3))
            q = qmul(pq, q)
        out.append((p, q))
    return out


def transform_obj(src, dst, altura_base):
    verts = []
    with open(src, encoding="utf8") as fi:
        alturas = [float(l.split()[2]) for l in fi if l.startswith("v ")]
    factor = altura_base / (max(alturas) - min(alturas))
    with open(src, encoding="utf8") as fi, open(dst, "w", encoding="utf8") as fo:
        for line in fi:
            p = line.split()
            if not p:
                fo.write(line)
                continue
            if p[0] == "v":
                x, y, z = float(p[1]), float(p[2]), float(p[3])
                verts.append((x * factor, -z * factor, y * factor))
                fo.write("v %.6f %.6f %.6f\n" % verts[-1])
            elif p[0] == "vn":
                x, y, z = float(p[1]), float(p[2]), float(p[3])
                fo.write("vn %.6f %.6f %.6f\n" % (x, -z, y))
            else:
                fo.write(line)
    return verts


def seg_dist(p, a, b):
    ab = tuple(b[i] - a[i] for i in range(3))
    ap = tuple(p[i] - a[i] for i in range(3))
    den = sum(v * v for v in ab)
    t = max(0.0, min(1.0, sum(ap[i] * ab[i] for i in range(3)) / den)) if den else 0.0
    return math.sqrt(sum((ap[i] - t * ab[i]) ** 2 for i in range(3)))


def make_rig(base, verts):
    with open(base, encoding="utf8") as f:
        src = json.load(f)
    ws = world_bones(src["bones"])
    pts = [tuple(p) for p, _ in ws]
    secs = []
    for i, b in enumerate(src["bones"]):
        if b["parent"] >= 0:
            secs.append((pts[b["parent"]], pts[i]))
        else:
            secs.append((pts[i], pts[i]))
    skin_bones = src["skinBones"]
    slot = {bone: i for i, bone in enumerate(skin_bones)}
    idx, wet = [], []
    for v in verts:
        ds = sorted(
            ((seg_dist(v, a, b), i) for i, (a, b) in enumerate(secs) if i in slot),
            key=lambda x: x[0],
        )[:4]
        ws4 = [1.0 / (d * d + 0.0004) for d, _ in ds]
        total = sum(ws4)
        idx.extend(slot[i] for _, i in ds)
        wet.extend(w / total for w in ws4)
    rig = {
        "bones": src["bones"],
        "skinBones": src["skinBones"],
        "skinIndex": idx,
        "skinWeight": [round(w, 6) for w in wet],
        "boneInverses": src["boneInverses"],
        "notes": "rig y bind del IPA base; clips por indice; pies a y=0",
    }
    return rig


def main():
    base = os.path.join(ROOT, "assets", "soldier_rig.json")
    zs = []
    with open(os.path.join(ROOT, "assets", "soldier.obj"), encoding="utf8") as f:
        for line in f:
            if line.startswith("v "):
                zs.append(float(line.split()[3]))
    altura_base = max(zs) - min(zs)
    for role in CLASES:
        src = os.path.join(PROPIOS, role + ".obj")
        obj = os.path.join(SOLDADO, role + ".obj")
        rig = os.path.join(SOLDADO, role + "_rig.json")
        tex = os.path.join(SOLDADO, role + "_tex.png")
        verts = transform_obj(src, obj, altura_base)
        with open(rig, "w", encoding="utf8") as f:
            json.dump(make_rig(base, verts), f, separators=(",", ":"))
        shutil.copyfile(os.path.join(PROPIOS, role + "_tex.png"), tex)
        print("%s: %d vertices, rig %d huesos, altura %.2f" % (role, len(verts), 20, altura_base))


if __name__ == "__main__":
    main()
