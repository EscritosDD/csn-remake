import json
import math
import os

ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
ASSETS = os.path.join(ROOT, "assets")
OUTPUT = os.path.join(ROOT, "docs", "auditoria_global_3d.md")


def rel(path):
    return os.path.relpath(path, ROOT).replace("\\", "/")


def scan_obj(path):
    with open(path, "rb") as handle:
        lines = handle.read().decode("latin1").splitlines()
    vertices = []
    uvs = 0
    faces = 0
    nan = 0
    for line in lines:
        if line.startswith("v "):
            values = line[2:].split()
            if len(values) < 3:
                continue
            xyz = [float(value) for value in values[:3]]
            vertices.append(xyz)
            nan += sum(1 for value in xyz if math.isnan(value) or math.isinf(value))
        elif line.startswith("vt "):
            uvs += 1
        elif line.startswith("f "):
            faces += 1
    if vertices:
        bounds = [
            (min(point[axis] for point in vertices), max(point[axis] for point in vertices))
            for axis in range(3)
        ]
    else:
        bounds = [(0.0, 0.0)] * 3
    status = "OK" if faces and not nan else ("SIN CARAS" if not faces else "NaN/Inf")
    return {
        "path": rel(path),
        "v": len(vertices),
        "vt": uvs,
        "f": faces,
        "nan": nan,
        "bounds": bounds,
        "status": status,
        "size": os.path.getsize(path),
    }


def scan_rig(path):
    with open(path, "r", encoding="utf-8") as handle:
        data = json.load(handle)
    bones = data.get("bones", [])
    root = next((bone.get("name", "?") for bone in bones if bone.get("parent") == -1), "?")
    note = data.get("notes", "")
    if isinstance(note, list):
        note = " ".join(str(item) for item in note)
    return {
        "path": rel(path),
        "bones": len(bones),
        "root": root,
        "skinned": bool(data.get("skinBones")),
        "note": note,
    }


def fmt_bounds(bounds):
    return "X[%0.2f,%0.2f] Y[%0.2f,%0.2f] Z[%0.2f,%0.2f]" % (
        bounds[0][0], bounds[0][1], bounds[1][0], bounds[1][1], bounds[2][0], bounds[2][1]
    )


def main():
    objs = sorted(
        os.path.join(dp, fn)
        for dp, _, fs in os.walk(ASSETS)
        for fn in fs
        if fn.lower().endswith(".obj")
    )
    rigs = sorted(
        os.path.join(dp, fn)
        for dp, _, fs in os.walk(ASSETS)
        for fn in fs
        if fn.lower().endswith("_rig.json")
    )
    obj_rows = [scan_obj(path) for path in objs]
    rig_rows = [scan_rig(path) for path in rigs]

    manifest_path = os.path.join(ASSETS, "soldier_clip_manifest.json")
    manifest = {}
    if os.path.isfile(manifest_path):
        with open(manifest_path, "r", encoding="utf-8") as handle:
            manifest = json.load(handle)

    png_count = sum(1 for dp, _, fs in os.walk(ASSETS) for fn in fs if fn.lower().endswith(".png"))
    glb_count = sum(
        1 for dp, _, fs in os.walk(ASSETS) for fn in fs
        if fn.lower().endswith((".glb", ".gltf"))
    )
    sin_caras = [row for row in obj_rows if row["status"] == "SIN CARAS"]
    nan_rows = [row for row in obj_rows if row["status"] == "NaN/Inf"]

    lines = [
        "# Auditoria global 3D",
        "",
        "Generada por `tools/auditar_assets_3d.py`. Fuente: `assets/`.",
        "",
        "## Resumen",
        "",
        "- OBJ: %d" % len(obj_rows),
        "- OBJ sin caras: %d" % len(sin_caras),
        "- OBJ con NaN/Inf: %d" % len(nan_rows),
        "- Rigs: %d" % len(rig_rows),
        "- Texturas PNG: %d" % png_count,
        "- GLB/GLTF en `assets/`: %d" % glb_count,
        "- Clips IPA: %s" % manifest.get("total", "?"),
        "- Origen clips: `%s`" % manifest.get("sourcePath", "?"),
        "- Commit clips: `%s`" % manifest.get("sourceCommit", "?"),
        "",
    ]

    if sin_caras:
        lines += ["### Sin caras", ""] + ["- `%s`" % row["path"] for row in sin_caras] + [""]
    if nan_rows:
        lines += ["### NaN/Inf", ""] + ["- `%s`" % row["path"] for row in nan_rows] + [""]

    lines += [
        "## Mallas OBJ",
        "",
        "| archivo | v | vt | f | NaN | bounds | estado |",
        "|---|---:|---:|---:|---:|---|---|",
    ]
    for row in obj_rows:
        lines.append(
            "| `%s` | %d | %d | %d | %d | %s | %s |"
            % (
                row["path"], row["v"], row["vt"], row["f"], row["nan"],
                fmt_bounds(row["bounds"]), row["status"],
            )
        )

    lines += ["", "## Rigs", "", "| archivo | huesos | root | skin | nota |", "|---|---:|---|---|---|"]
    for row in rig_rows:
        lines.append(
            "| `%s` | %d | %s | %s | %s |"
            % (row["path"], row["bones"], row["root"], "sí" if row["skinned"] else "no", row["note"])
        )

    lines += [
        "",
        "## Notas de separación de fuentes",
        "",
        "- `assets/soldier/` y `assets/soldier_rig.json` son la fuente IPA: rig Z-up, clips nativos y bounds reales.",
        "- `assets/personajes_propios/` son derivados Meshy con rig de caja generado por pipeline; no deben sobrescribir la fuente IPA ni recibir retarget.",
        "- No existe `.glb/.gltf` original en disco; `server.js` y el visor necesitan soporte explícito antes de usarlos.",
        "",
    ]

    os.makedirs(os.path.dirname(OUTPUT), exist_ok=True)
    with open(OUTPUT, "w", encoding="utf-8", newline="\r\n") as handle:
        handle.write("\n".join(lines))
    print("OBJ=%d sin_caras=%d NaN=%d rigs=%d png=%d glb=%d" % (
        len(obj_rows), len(sin_caras), len(nan_rows), len(rig_rows), png_count, glb_count
    ))
    print("escrito %s" % rel(OUTPUT))


if __name__ == "__main__":
    main()
