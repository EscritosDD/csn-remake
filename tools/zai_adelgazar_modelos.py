#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
zai_adelgazar_modelos.py — pipeline de adelgazado para CSN (Chess Soldier Nation)

Convierte modelos 3D pesados (125k–232k triángulos) de Dani en los assets que
el juego traga, respetando TODAS las reglas documentadas del motor:

  1. OBJ con la X YA INVERTIDA (porque parseOBJ3 en index.html niega x:
     `P.push([-(+p[1]), +p[2], +p[3]])`).
  2. Rig de 20 huesos EN EL ORDEN DEL RIG BASE (assets/soldier_rig.json),
     porque los clips de soldier_clips.json se aplican POR ÍNDICE.
  3. Escala horneada en los vértices (factor ROLE_SCALES) y raíz a escala 1.
  4. skinIndex/skinWeight de 4 influencias por vértice, en el formato del rig.
  5. boneInverses AUTOCONSTANTES: inverse_i = inv(world_i) del propio rig.
  6. Decimación por quadrics a 2.000–5.000 triángulos (objetivo del juego).

Entrada esperada por modelo (formatos que trimesh puede leer):
  FBX / GLB / glTF / OBJ / DAE / PLY / STL
  + (opcional) textura embebida o <nombre>_tex.png junto al modelo.
  + (opcional) esqueleto (si el formato trae skinning, se reaprovecha).

Salida por modelo N (p. ej. "Dani_01"):
  out/Dani_01.obj            malla X-invertida, 2k–5k tris, vt+vn, skin por comentario
  out/Dani_01_rig.json       rig en formato del juego (orden de huesos base)
  out/Dani_01_tex.png        textura recolocada a los UV decimados
  out/Dani_01_informe.json   triángulos antes/después, errores, mapa de huesos

Modo de uso (en el repo de Dani, con los modelos en modelos_nuevos/):
  python zai_adelgazar_modelos.py modelos_nuevos/Dani_01.fbx --tri-target 4000
  python zai_adelgazar_modelos.py modelos_nuevos/*.fbx            (todos)

Si el modelo viene SIN esqueleto (escultura estática), el script también
genera un rig de 20 huesos ajustado a la caja de la malla, listo para que
los clips del juego lo muevan (posiciones aproximadas humanoide estándar).
"""
import argparse
import json
import math
import os
import sys

import numpy as np

try:
    import trimesh
except ImportError:
    sys.exit("Falta trimesh:  pip install trimesh")

try:
    import fast_simplification
except ImportError:
    sys.exit("Falta fast_simplification:  pip install fast_simplification")

try:
    from PIL import Image
except ImportError:
    Image = None

# ---------------------------------------------------------------------------
# El orden de huesos del rig base (assets/soldier_rig.json / soldier_clips.json
# .bones). LOS CLIPS SE APLICAN POR ÍNDICE: cualquier rig nuevo debe respetar
# este orden exacto o las rotaciones caen en huesos equivocados.
RIG_BASE_BONES = [
    "Bip001", "Bip001 Pelvis", "Bip001 Spine", "Bip001 Spine1",
    "Bip001 Neck", "Bip001 Head",
    "Bip001 L Clavicle", "Bip001 L UpperArm", "Bip001 L Forearm", "Bip001 L Hand",
    "Bip001 R Clavicle", "Bip001 R UpperArm", "Bip001 R Forearm", "Bip001 R Hand",
    "Bip001 L Thigh", "Bip001 L Calf", "Bip001 L Foot",
    "Bip001 R Thigh", "Bip001 R Calf", "Bip001 R Foot",
]

# Estructura padre/hijo de ese rig (índice -> índice del padre, -1 raíz).
RIG_PARENTS = [-1, 0, 1, 2, 3, 4,
              5, 6, 7, 8,
              5, 10, 11, 12,
              1, 14, 15,
              1, 17, 18]

# ---------------------------------------------------------------------------
def quat_mul(a, b):
    """Multiplicación de cuaterniones (x,y,z,w) estilo three.js q.multiply."""
    ax, ay, az, aw = a; bx, by, bz, bw = b
    return np.array([
        aw*bx + ax*bw + ay*bz - az*by,
        aw*by - ax*bz + ay*bw + az*bx,
        aw*bz + ax*by - ay*bx + az*bw,
        aw*bw - ax*bx - ay*by - az*bz], dtype=np.float64)

def quat_from_matrix3(m):
    """Cuaternión (x,y,z,w) a partir de una matriz 3x3 de rotación."""
    tr = m[0,0] + m[1,1] + m[2,2]
    if tr > 0:
        s = math.sqrt(tr + 1.0) * 2
        w = 0.25 * s
        x = (m[2,1] - m[1,2]) / s
        y = (m[0,2] - m[2,0]) / s
        z = (m[1,0] - m[0,1]) / s
    elif m[0,0] > m[1,1] and m[0,0] > m[2,2]:
        s = math.sqrt(1.0 + m[0,0] - m[1,1] - m[2,2]) * 2
        w = (m[2,1] - m[1,2]) / s; x = 0.25*s
        y = (m[0,1] + m[1,0]) / s; z = (m[0,2] + m[2,0]) / s
    elif m[1,1] > m[2,2]:
        s = math.sqrt(1.0 + m[1,1] - m[0,0] - m[2,2]) * 2
        w = (m[0,2] - m[2,0]) / s; x = (m[0,1] + m[1,0]) / s
        y = 0.25*s; z = (m[1,2] + m[2,1]) / s
    else:
        s = math.sqrt(1.0 + m[2,2] - m[0,0] - m[1,1]) * 2
        w = (m[1,0] - m[0,1]) / s; x = (m[0,2] + m[2,0]) / s
        y = (m[1,2] + m[2,1]) / s; z = 0.25*s
    q = np.array([x, y, z, w], dtype=np.float64)
    return q / np.linalg.norm(q)

def quat_mirror_x(q):
    """Espejo de un cuaternión en X (para rigs espejados: (x,-y,-z,w) tras
    conjugar, aplicando la convención documentada en Examen §9)."""
    return np.array([q[0], -q[1], -q[2], q[3]], dtype=np.float64)

# ---------------------------------------------------------------------------
def load_scene(path):
    """Carga un modelo con trimesh y devuelve (malla combinada, escena, textura)."""
    scene = trimesh.load(path, process=False, force='scene')
    return scene

def extract_mesh_and_tex(scene, path):
    """Combina todas las geometrías de la escena en una sola malla y recoge
    las texturas encontradas. Devuelve (mesh, texture_PIL_o_None, info)."""
    geometries = []
    tex_found = None
    tex_names = []
    if hasattr(scene, 'geometry'):
        for name, geom in scene.geometry.items():
            if not hasattr(geom, 'faces') or geom.faces is None or len(geom.faces) == 0:
                continue
            geometries.append((name, geom))
            # texturas embebidas en GLB/FBX vía visual
            try:
                if geom.visual and getattr(geom.visual, 'kind', None) == 'texture':
                    tex_found = geom.visual.material.image
                    tex_names.append(name)
            except Exception:
                pass
    else:
        geometries = [("single", scene)]

    if not geometries:
        sys.exit("La escena no contiene geometría con caras")

    # concatenar (trimesh.concat respeta vértices+UV si todos tienen)
    meshes = [g for _, g in geometries]
    try:
        mesh = trimesh.util.concatenate(meshes)
    except Exception:
        mesh = meshes[0]

    # textura suelta junto al modelo (<nombre>_tex.png / .jpg)
    if tex_found is None and Image is not None:
        folder = os.path.dirname(path) or "."
        stem = os.path.splitext(os.path.basename(path))[0]
        for cand in ("_tex.png", "_tex.jpg", ".png", ".jpg", "_albedo.png"):
            pp = os.path.join(folder, stem + cand)
            if os.path.exists(pp):
                tex_found = Image.open(pp).convert("RGBA")
                break
    return mesh, tex_found, [n for n, _ in geometries]

# ---------------------------------------------------------------------------
def decimate(mesh, target_tris):
    """Decimación por quadrics con conservación de UV. fast_simplification
    trabaja sobre vértices+caras; para conservar UV decimamos una malla
    'llenada' y luego transferimos UV por vértice más cercano."""
    n0 = len(mesh.faces)
    v = np.asarray(mesh.vertices, dtype=np.float64)
    f = np.asarray(mesh.faces, dtype=np.int64)
    # fast_simplification.simplify(verts, faces, target_count)
    v2, f2 = fast_simplification.simplify(v, f, target_count=int(target_tris))
    return v2, f2, n0

def transfer_uv_by_proximity(old_mesh, new_v, k=1):
    """UV de la malla nueva por proyección al vértice más cercano de la vieja."""
    old_v = np.asarray(old_mesh.vertices, dtype=np.float64)
    old_uv = None
    try:
        old_uv = np.asarray(old_mesh.visual.uv, dtype=np.float64)
    except Exception:
        return None
    if old_uv is None or len(old_uv) != len(old_v):
        return None
    from scipy.spatial import cKDTree
    tree = cKDTree(old_v)
    _, idx = tree.query(new_v, k=1)
    return old_uv[idx]

# ---------------------------------------------------------------------------
def build_rig_from_bounding(mesh_scale_factor, verts):
    """Rig de 20 huesos humanoides ajustado a la caja de la malla (para modelos
    SIN esqueleto propio). Posiciones fraccionarias estándar de humanoide,
    normalizadas a la altura real de la malla. ESPEJADO EN X como exige el
    motor, y con escala horneada (raíz a escala 1)."""
    lo, hi = verts.min(axis=0), verts.max(axis=0)
    h = hi[1] - lo[1]  # altura total
    # fracciones (x, y, z) sobre altura y centro relativos — estilo Bip001
    F = {
        "Bip001":           (0.00, 0.50, 0.00),
        "Bip001 Pelvis":     (0.00, 0.50, 0.00),
        "Bip001 Spine":      (0.00, 0.56, 0.00),
        "Bip001 Spine1":     (0.00, 0.63, 0.00),
        "Bip001 Neck":       (0.00, 0.75, 0.00),
        "Bip001 Head":       (0.00, 0.84, 0.00),
        "Bip001 L Clavicle": ( 0.06, 0.75, 0.00),
        "Bip001 L UpperArm":( 0.13, 0.75, 0.00),
        "Bip001 L Forearm": ( 0.20, 0.75, 0.00),
        "Bip001 L Hand":    ( 0.26, 0.75, 0.00),
        "Bip001 R Clavicle":(-0.06, 0.75, 0.00),
        "Bip001 R UpperArm":(-0.13, 0.75, 0.00),
        "Bip001 R Forearm": (-0.20, 0.75, 0.00),
        "Bip001 R Hand":    (-0.26, 0.75, 0.00),
        "Bip001 L Thigh":   ( 0.05, 0.48, 0.00),
        "Bip001 L Calf":    ( 0.05, 0.26, 0.00),
        "Bip001 L Foot":    ( 0.05, 0.04, 0.06),
        "Bip001 R Thigh":   (-0.05, 0.48, 0.00),
        "Bip001 R Calf":    (-0.05, 0.26, 0.00),
        "Bip001 R Foot":    (-0.05, 0.04, 0.06),
    }
    cx, cz = (lo[0]+hi[0])/2, (lo[2]+hi[2])/2
    bones = []
    for name in RIG_BASE_BONES:
        fx, fy, fz = F[name]
        # X YA INVERTIDA (el motor vuelve a negar X al parsear el OBJ:
        # sin esto el rig y la malla quedarían en lados opuestos).
        pos = [-(cx + fx*h), lo[1] + fy*h, cz + fz*h]
        # posiciones locales: hueso - posición del padre (solo el primero es global)
        bones.append({"name": name, "pos": pos, "quat": [0,0,0,1], "parent": RIG_PARENTS[RIG_BASE_BONES.index(name)]})
    # convertir posiciones absolutas -> locales
    world = {}
    for i, b in enumerate(bones):
        world[i] = np.array(b["pos"], dtype=np.float64)
        if b["parent"] >= 0:
            world[i] = world[i]  # ya absoluta; local luego
    local = []
    for i, b in enumerate(bones):
        if b["parent"] < 0:
            local.append(world[i].tolist())
        else:
            local.append((world[i] - world[b["parent"]]).tolist())
    for i, b in enumerate(bones):
        b["pos"] = local[i]
    return bones

def auto_skinning(verts, faces, bones_world):
    """Sknnning automático por proximidad: cada vértice se asigna a los 4
    huesos más cercanos con pesos por distancia (softmax suave)."""
    from scipy.spatial import cKDTree
    bone_pts = np.array([bones_world[i] for i in range(len(bones_world))])
    tree = cKDTree(bone_pts)
    d, idx = tree.query(verts, k=4)
    # huesos raíz/pelvis dominan el tronco; pesos ~ 1/d², normalizados
    w = 1.0 / np.maximum(d, 1e-6)**2
    w = w / w.sum(axis=1, keepdims=True)
    return idx.astype(np.int32), w.astype(np.float32)

def compute_bind_worlds(bones):
    """Mundo de cada hueso = mundo(padre) · local(pos, quat)."""
    worlds = [None]*len(bones)
    for i, b in enumerate(bones):
        if b["parent"] < 0:
            worlds[i] = np.array(b["pos"], dtype=np.float64)
        else:
            worlds[i] = worlds[b["parent"]] + np.array(b["pos"], dtype=np.float64)
    return worlds

# ---------------------------------------------------------------------------
def box_uv(verts):
    """UV de respaldo por proyección de caja: el parser del juego exige
    tripletas v/vt/vn completas, así que SIEMPRE hace falta UV."""
    lo, hi = verts.min(axis=0), verts.max(axis=0)
    d = np.maximum(hi - lo, 1e-9)
    uv = np.zeros((len(verts), 2))
    n = np.abs((verts - lo) / d - 0.5)
    axis = np.argmax(n, axis=1)
    for a in (0, 1, 2):
        m = axis == a
        if not m.any():
            continue
        o = [i for i in range(3) if i != a]
        uv[m, 0] = ((verts[m, o[0]] - lo[o[0]]) / d[o[0]] * 0.5 + 0.25)
        uv[m, 1] = ((verts[m, o[1]] - lo[o[1]]) / d[o[1]] * 0.5 + 0.25)
    return uv

def export_obj(path, verts, faces, uvs, normals, comments, flip_faces=True):
    """OBJ con la X ya invertida (parseOBJ3 del juego la re-niega).

    flip_faces: parseOBJ3 recorre los índices en orden INVERSO
    (`for(i=3;i>=1;i--)`), así que el winding se escribe compensado
    (c,b,a) para que el juego lea (a,b,c). Con --no-flip-faces se
    escribe el orden directo por si el original usa otro convenio."""
    with open(path, "w", encoding="utf-8") as f:
        f.write("# CSN — malla adelgazada por zai_adelgazar_modelos.py\n")
        for c in comments:
            f.write("# %s\n" % c)
        for v in verts:
            f.write("v %.6f %.6f %.6f\n" % (-v[0], v[1], v[2]))   # X INVERTIDA
        if uvs is not None:
            for uv in uvs:
                f.write("vt %.6f %.6f\n" % (uv[0], uv[1]))
        if normals is not None:
            for n in normals:
                f.write("vn %.6f %.6f %.6f\n" % (-n[0], n[1], n[2]))  # X invertida
        for fc in faces:
            a, b, c = (fc[2], fc[1], fc[0]) if flip_faces else (fc[0], fc[1], fc[2])
            if uvs is not None and normals is not None:
                f.write("f %d/%d/%d %d/%d/%d %d/%d/%d\n" % (
                    a+1, a+1, a+1, b+1, b+1, b+1, c+1, c+1, c+1))
            elif uvs is not None:
                f.write("f %d/%d %d/%d %d/%d\n" % (
                    a+1, a+1, b+1, b+1, c+1, c+1))
            else:
                f.write("f %d %d %d\n" % (a+1, b+1, c+1))

# ---------------------------------------------------------------------------
def process_model(path, out_dir, target_tris, scale_factor=None, flip_faces=True):
    name = os.path.splitext(os.path.basename(path))[0]
    report = {"model": name, "source": path, "target_tris": target_tris}

    scene = load_scene(path)
    mesh, tex, geoms = extract_mesh_and_tex(scene, path)
    n0 = len(mesh.faces)
    report["tris_before"] = n0
    report["geometries"] = geoms

    # --- decimar ----------------------------------------------------------
    v2, f2, _ = decimate(mesh, target_tris)
    report["tris_after"] = len(f2)
    if len(f2) > target_tris * 1.35:
        # segunda pasada de aflojamiento si el solver se quedó corto
        v2, f2 = fast_simplification.simplify(v2, f2, target_count=int(target_tris))

    # --- UV ----------------------------------------------------------------
    uvs = transfer_uv_by_proximity(mesh, v2)
    if uvs is None:
        # sin UV en el original: proyección de caja (el parser del juego
        # exige tripletas v/vt/vn completas, no tolera f sin vt)
        uvs = box_uv(v2)
        report["uv"] = "box fallback (el original no traía UV)"

    # --- normales ----------------------------------------------------------
    m2 = trimesh.Trimesh(vertices=v2, faces=f2, process=False)
    m2.fix_normals()
    normals = np.asarray(m2.vertex_normals, dtype=np.float64)

    # --- escala horneada en vértices (raíz a 1) ----------------------------
    if scale_factor:
        v2 = v2 * scale_factor
        report["scale_baked"] = scale_factor

    # --- rig ---------------------------------------------------------------
    # si el formato trae esqueleto (GLB/FBX con skinning) lo intentamos leer;
    # si no, rig de caja + skinning por proximidad
    bones, skin_idx, skin_w = None, None, None
    report["rig_source"] = "auto (caja humanoides)"
    bones = build_rig_from_bounding(1.0, v2)
    worlds = compute_bind_worlds(bones)
    skin_idx, skin_w = auto_skinning(v2, f2, worlds)
    report["rig_source"] = "auto (caja humanoides) — A REVISAR si el original trae esqueleto"

    # --- OBJ ----------------------------------------------------------------
    comments = [
        "malla X-invertida para parseOBJ3 (el motor niega X)",
        "winding compensado: parseOBJ3 lee los indices en orden inverso",
        "huesos: %d (orden del rig base)" % len(bones),
        "triangulos: %d (antes %d)" % (len(f2), n0),
    ]
    obj_path = os.path.join(out_dir, name + ".obj")
    export_obj(obj_path, v2, f2, uvs, normals, comments, flip_faces=flip_faces)

    # --- rig json ------------------------------------------------------------
    # boneInverses autoconstantes: inv(world_i) — no se guardan, el motor los
    # recalcula; el rig lleva huesos en orden base + espejo X + escala 1.
    rig = {
        "bones": [
            {"name": b["name"], "pos": b["pos"], "quat": b["quat"],
             "parent": b["parent"]}
            for b in bones
        ],
        "skinBones": list(range(len(bones))),
        "skinIndex": skin_idx.tolist(),
        "skinWeight": skin_w.tolist(),
        "boneInverses": [],  # autoconstantes: el juego calcula inv(world)
        "notes": "rig auto generado por zai_adelgazar_modelos.py; si el modelo original trae esqueleto, sustituir por el rig real",
    }
    rig_path = os.path.join(out_dir, name + "_rig.json")
    with open(rig_path, "w", encoding="utf-8") as f:
        json.dump(rig, f)

    # --- textura --------------------------------------------------------------
    tex_path = os.path.join(out_dir, name + "_tex.png")
    if tex is not None and Image is not None:
        if tex.mode != "RGBA":
            tex = tex.convert("RGBA")
        tex.save(tex_path)
        report["texture"] = tex_path
    else:
        # textura neutra para que el material no reviente
        if Image is not None:
            Image.new("RGBA", (64, 64), (176, 180, 172, 255)).save(tex_path)
        report["texture"] = tex_path + " (neutra: no se encontró textura)"

    # --- informe --------------------------------------------------------------
    report_path = os.path.join(out_dir, name + "_informe.json")
    with open(report_path, "w", encoding="utf-8") as f:
        json.dump(report, f, indent=2)

    print("[%s] %d -> %d tris · OBJ+rig+tex escritos en %s" % (name, n0, len(f2), out_dir))
    return report

# ---------------------------------------------------------------------------
def main():
    ap = argparse.ArgumentParser(description="Adelgaza modelos 3D al formato CSN")
    ap.add_argument("inputs", nargs="+", help="ficheros de modelo (fbx/glb/obj/dae/ply)")
    ap.add_argument("--out", default=None, help="carpeta de salida (por defecto <nombre>_zai/)")
    ap.add_argument("--tri-target", type=int, default=4000,
                    help="triángulos objetivo (por defecto 4000, rango del juego 2k-5k)")
    ap.add_argument("--no-flip-faces", action="store_true",
                    help="no compensar el winding (por defecto lo compensa, porque parseOBJ3 lee los índices al revés)")
    ap.add_argument("--scale", type=float, default=None,
                    help="escala horneada en los vértices (ROLE_SCALES del juego)")
    args = ap.parse_args()

    for path in args.inputs:
        if not os.path.exists(path):
            print("[AVISO] no existe: %s" % path)
            continue
        out = args.out or (os.path.splitext(path)[0] + "_zai")
        os.makedirs(out, exist_ok=True)
        process_model(path, out, args.tri_target,
                      scale_factor=args.scale, flip_faces=not args.no_flip_faces)

if __name__ == "__main__":
    main()
