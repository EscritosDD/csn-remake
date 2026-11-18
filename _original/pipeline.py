# -*- coding: utf-8 -*-
"""Pipeline local: assetbundle Skirmish del IPA -> .bin del juego (formato S03/S04).
   Se ejecuta sobre la extraccion local (fuera del repo); el .bin y los atlas
   resultantes son los unicos artefactos que entran en el repo (assets/maps/).
   Uso: python pipeline.py <ruta.assetbundle> <salida.bin> <atlas0.png> <atlas1.png>"""
import base64, io, json, struct, sys
import numpy as np
from UnityPy import load
from UnityPy.enums import ClassIDType
from UnityPy.helpers.MeshHelper import MeshHandler


def build_bin(bundle_path):
    env = load(bundle_path)
    objs = env.objects
    by_path = {o.path_id: o for o in objs}

    def rd(pid):
        o = by_path.get(pid)
        if o is None:
            return None
        try:
            return o.read()
        except Exception:
            return None

    def mat_texnames(mat_id):
        md = rd(mat_id)
        if md is None:
            return []
        out = []
        try:
            for te in md.m_SavedProperties.m_TexEnvs:
                try:
                    tptr = te[1].m_Texture
                    if tptr is not None:
                        t = rd(tptr.m_PathID)
                        if t is not None and getattr(t, "m_Name", None):
                            out.append(t.m_Name)
                except Exception:
                    pass
        except Exception:
            pass
        return out

    def atlas_of(texnames):
        for n in texnames:
            if "Atlas_01" in n:
                return 0
            if "Atlas_02" in n:
                return 1
        return -1

    pos_parts, uv_parts, idx_parts = [], [], []
    pieces = []  # (mat, start, count)
    vbase = 0
    for go_obj in objs:
        if go_obj.type != ClassIDType.GameObject:
            continue
        try:
            go = go_obj.read()
        except Exception:
            continue
        comps = []
        try:
            for c in go.m_Component:
                if isinstance(c, tuple) and len(c) == 2:
                    comps.append((c[0], c[1].m_PathID if c[1] is not None else None))
        except Exception:
            continue
        if not any(ct == 23 for ct, _ in comps):  # MeshRenderer
            continue
        mesh_id = None
        render_id = None
        for ct, pid in comps:
            if ct == 33 and pid is not None:  # MeshFilter
                mf = rd(pid)
                try:
                    mesh_id = mf.m_Mesh.m_PathID
                except Exception:
                    mesh_id = None
            elif ct == 23 and pid is not None:
                render_id = pid
        md = rd(mesh_id)
        if md is None:
            continue
        atlases = []
        rend = rd(render_id)
        if rend is not None:
            try:
                for mp in rend.m_Materials:
                    if mp is None:
                        atlases.append(-1)
                    else:
                        atlases.append(atlas_of(mat_texnames(mp.m_PathID)))
            except Exception:
                pass
        try:
            handler = MeshHandler(md)
            handler.process()
            verts = handler.m_Vertices
            uvs = handler.m_UV0
            tris = handler.get_triangles()
        except Exception:
            continue
        if not verts or len(verts) == 0:
            continue
        nsub = len(tris)
        while len(atlases) < nsub:
            atlases.append(-1)
        pos = np.array(verts, dtype=np.float64)
        pos[:, 0] = -pos[:, 0]  # convencion del exportador OBJ (pipeline 03/04)
        uv = np.array(uvs, dtype=np.float64) if uvs and len(uvs) == len(pos) else np.zeros((len(pos), 2))
        pos_parts.append(pos)
        uv_parts.append(uv)
        for si, tri in enumerate(tris):
            if atlases[si] < 0:
                continue  # descartar piezas sin atlas (tarjetas, luces, etiquetas)
            flat = []
            for a, b, c in tri:
                flat += [c, b, a]  # orden del exportador OBJ
            idx = np.array(flat, dtype=np.uint32) + vbase
            idx_parts.append(idx)
            pieces.append((atlases[si], idx))
        vbase += len(pos)

    if not idx_parts:
        raise SystemExit("sin piezas con atlas")
    pos_all = np.concatenate(pos_parts)
    uv_all = np.concatenate(uv_parts)
    # consolidar indices por material (como el bin 03/04: primero todo el mat 0, luego el 1)
    idx0 = np.concatenate([idx for mat, idx in pieces if mat == 0])
    idx1 = np.concatenate([idx for mat, idx in pieces if mat == 1])
    idx_all = np.concatenate([idx0, idx1])
    groups = [{"mat": 0, "start": 0, "count": len(idx0)},
              {"mat": 1, "start": len(idx0), "count": len(idx1)}]

    # suelo: extension horizontal de las losas a ras de suelo (|y| < 0.5)
    ground = pos_all[np.abs(pos_all[:, 1]) < 0.5]
    if len(ground) == 0:
        ground = pos_all
    fx0, fx1 = float(ground[:, 0].min()), float(ground[:, 0].max())
    fz0, fz1 = float(ground[:, 2].min()), float(ground[:, 2].max())
    cx, cz = (fx0 + fx1) / 2, (fz0 + fz1) / 2
    w, d = fx1 - fx0, fz1 - fz0
    pos_all[:, 0] -= cx
    pos_all[:, 2] -= cz
    scale = 15.0 / w
    bmin = pos_all.min(axis=0).tolist()
    bmax = pos_all.max(axis=0).tolist()
    header = {
        "verts": int(len(pos_all)),
        "groups": groups,
        "floor": {"cx": 0.0, "cz": 0.0, "w": round(w, 4), "d": round(d, 4)},
        "scale": float(scale),
        "bounds": {"min": [round(float(v), 2) for v in bmin], "max": [round(float(v), 2) for v in bmax]},
        "source": "pipeline-deepseek",
    }
    hj = json.dumps(header, separators=(",", " :")).encode("utf-8")
    while len(hj) % 4: hj += b" "  # alineacion a 4 bytes (Float32Array lo exige)
    buf = struct.pack("<I", len(hj)) + hj
    buf += pos_all.astype("<f4").tobytes()
    buf += uv_all.astype("<f4").tobytes()
    buf += idx_all.astype("<u4").tobytes()
    return buf, header


if __name__ == "__main__":
    if len(sys.argv) >= 2 and sys.argv[1] == "selfcheck":
        bundle = r"D:\Juegos\CSN\_original\ipa\Payload\radtactics.app\Data\Raw\Theme_01_Skirmish_03.assetbundle"
        buf, hdr = build_bin(bundle)
        html = io.open(r"D:\Juegos\CSN\csn-remake\index.html", "r", encoding="utf-8").read()
        i = html.find("skirmish03:{bin:'data:application/octet-stream;base64,")
        j = html.find("'", i + 40)
        emb = base64.b64decode(html[i + len("skirmish03:{bin:'data:application/octet-stream;base64,"):j])
        hlen = struct.unpack("<I", emb[:4])[0]
        ehdr = json.loads(emb[4:4 + hlen])
        print("EMBEBIDO S03 : verts=%d floor=%s scale=%.6f groups=%s" % (ehdr["verts"], ehdr.get("floor"), ehdr.get("scale"), ehdr["groups"]))
        print("MIO      S03 : verts=%d floor=%s scale=%.6f groups=%s" % (hdr["verts"], hdr["floor"], hdr["scale"], hdr["groups"]))
    else:
        bundle, out = sys.argv[1], sys.argv[2]
        buf, hdr = build_bin(bundle)
        with open(out, "wb") as f:
            f.write(buf)
        print("OK %s: verts=%d floor=%s scale=%.6f groups=%s" % (out, hdr["verts"], hdr["floor"], hdr["scale"], hdr["groups"]))

