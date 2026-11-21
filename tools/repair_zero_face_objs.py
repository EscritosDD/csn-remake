import os
import re
import sys

if len(sys.argv) > 1:
    sys.path.insert(0, sys.argv[1])

import UnityPy
from UnityPy.helpers.MeshHelper import MeshHandler

ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
RAW = os.path.join(ROOT, "_original", "ipa", "Payload", "radtactics.app", "Data", "Raw")

BROKEN = {
    "assets/soldier/bodies/CommanderM.obj": 1218,
    "assets/soldier/bodies/Soldier_SAS.obj": 1234,
    "assets/soldier/bodies/Soldier_Spud.obj": 1065,
    "assets/props/GatlingTurret.obj": 995,
    "assets/props/UAV.obj": 872,
    "assets/props/DeployableCover.obj": 208,
    "assets/props/ObjectiveRocket.obj": 457,
    "assets/props/RemoteCharge.obj": 53,
    "assets/props/RiotShieldBot.obj": 660,
    "assets/props/RocketTurret.obj": 1011,
    "assets/props/SpiderMine.obj": 195,
}

BUNDLES = sorted(
    os.path.join(dp, fn)
    for dp, _, fs in os.walk(RAW)
    for fn in fs
    if fn.endswith(".assetbundle")
)


def fmt(value):
    return format(float(value), ".10g")


def read_obj(path):
    with open(path, "rb") as handle:
        text = handle.read().decode("latin1")
    lines = text.splitlines()
    header = next((line for line in lines if line.startswith("g ")), None)
    if header is None:
        header = "g " + os.path.splitext(os.path.basename(path))[0]
    return {
        "header": header,
        "v": sum(1 for line in lines if line.startswith("v ")),
        "vt": sum(1 for line in lines if line.startswith("vt ")),
        "f": sum(1 for line in lines if line.startswith("f ")),
    }


def mesh_cache():
    by_vertex_count = {}
    for path in BUNDLES:
        env = UnityPy.load(path)
        for obj in env.objects:
            if obj.type.name != "Mesh":
                continue
            data = obj.read()
            try:
                handler = MeshHandler(data)
                handler.process()
                vertices = handler.m_Vertices
            except Exception:
                continue
            if not vertices:
                continue
            by_vertex_count.setdefault(len(vertices), []).append(
                (os.path.basename(path), obj.path_id, data.m_Name, handler)
            )
    return by_vertex_count


def write_obj(path, header, handler):
    vertices = handler.m_Vertices
    uvs = handler.m_UV0
    if len(uvs) != len(vertices):
        uvs = [(0.0, 0.0)] * len(vertices)
    faces = []
    for submesh in handler.get_triangles():
        for a, b, c in submesh:
            faces.append((c, b, a))
    with open(path, "w", encoding="ascii", newline="\r\n") as handle:
        handle.write(header + "\n")
        for x, y, z in vertices:
            handle.write("v %s %s %s\n" % (fmt(-x), fmt(y), fmt(z)))
        for u, v in uvs:
            handle.write("vt %s %s\n" % (fmt(u), fmt(v)))
        for a, b, c in faces:
            handle.write(
                "f %d/%d %d/%d %d/%d\n"
                % (a + 1, a + 1, b + 1, b + 1, c + 1, c + 1)
            )
    return len(faces)


def main():
    cache = mesh_cache()
    for rel, expected_vertices in BROKEN.items():
        path = os.path.join(ROOT, *rel.split("/"))
        current = read_obj(path)
        if current["f"]:
            print("SKIP %s: ya tiene %d caras" % (rel, current["f"]))
            continue
        matches = cache.get(expected_vertices, [])
        if not matches:
            raise SystemExit("sin malla de %d vértices para %s" % (expected_vertices, rel))
        bundle, path_id, name, handler = matches[0]
        count = write_obj(path, current["header"], handler)
        print(
            "REPAIR %s <= %s/%s pathid=%d: v=%d vt=%d f=%d"
            % (rel, bundle, name, path_id, expected_vertices, len(handler.m_UV0), count)
        )


if __name__ == "__main__":
    main()
