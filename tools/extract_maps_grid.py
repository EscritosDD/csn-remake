import json
import os
import re
import struct
import sys

if len(sys.argv) > 1:
    sys.path.insert(0, sys.argv[1])

import UnityPy

ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
RAW = os.path.join(ROOT, "_original", "ipa", "Payload", "radtactics.app", "Data", "Raw")
OUT = os.path.join(ROOT, "assets", "maps")
BUNDLES = [
    "Theme_01_Levels_Gameplay.assetbundle",
    "Theme_01_Levels_Gameplay_DLC1.assetbundle",
]
SCRIPTS = {"grid": 1644, "tile": 1702, "spawn": 1667, "control": 1555}


def i32(raw, offset):
    return struct.unpack_from("<i", raw, offset)[0]


def script_id(raw):
    if len(raw) < 20:
        return 0
    return i32(raw, 16)


def owner_path(raw):
    if len(raw) < 8:
        return 0
    return i32(raw, 4)


class BundleData:
    def __init__(self, path):
        self.env = UnityPy.load(path)
        self.objects = {obj.path_id: obj for obj in self.env.objects}
        self.names = {}
        self.transforms = {}
        self.mbs = []
        for obj in self.env.objects:
            if obj.type.name == "GameObject":
                self.names[obj.path_id] = obj.read().m_Name
            elif obj.type.name == "Transform":
                data = obj.read()
                self.transforms[obj.path_id] = {
                    "go": data.m_GameObject.m_PathID,
                    "father": data.m_Father.m_PathID,
                    "pos": (data.m_LocalPosition.x, data.m_LocalPosition.y, data.m_LocalPosition.z),
                }
            elif obj.type.name == "MonoBehaviour":
                raw = obj.get_raw_data()
                sid = script_id(raw)
                if sid in SCRIPTS.values():
                    self.mbs.append({"path": obj.path_id, "sid": sid, "raw": raw, "go": owner_path(raw)})
        self.transform_by_go = {t["go"]: path for path, t in self.transforms.items()}
        self.mbs_by_kind = {}
        for kind, sid in SCRIPTS.items():
            self.mbs_by_kind[kind] = [mb for mb in self.mbs if mb["sid"] == sid]

    def grid_root_of(self, go_path):
        transform_path = self.transform_by_go.get(go_path, 0)
        seen = set()
        while transform_path and transform_path not in seen:
            seen.add(transform_path)
            transform = self.transforms.get(transform_path)
            if not transform:
                return 0
            if transform["go"] in {mb["go"] for mb in self.mbs_by_kind["grid"]}:
                return transform["go"]
            transform_path = transform["father"]
        return 0

    def local_pos(self, go_path):
        transform_path = self.transform_by_go.get(go_path, 0)
        transform = self.transforms.get(transform_path)
        return transform["pos"] if transform else (0.0, 0.0, 0.0)


def parse_grid(mb):
    raw = mb["raw"]
    return {
        "go": mb["go"],
        "name": "",
        "w": i32(raw, 24),
        "h": i32(raw, 28),
        "height": i32(raw, 32),
        "tiles": {},
        "spawns": [],
        "controlPoints": [],
    }


DIRECTION_FIELDS = (0, 3, 1, 2)


def parse_tile(mb):
    raw = mb["raw"]
    solid = [i32(raw, 24 + 4 * index) != 0 for index in range(4)]
    cover = [i32(raw, 44 + 4 * index) for index in range(4)]
    return {
        "x": i32(raw, 64),
        "y": i32(raw, 68),
        "h": i32(raw, 72),
        "solid": [solid[i] for i in DIRECTION_FIELDS],
        "cover": [cover[i] for i in DIRECTION_FIELDS],
        "vis": i32(raw, 40) != 0,
    }


def tile_xy(pos, size):
    w, h = size
    return int(round(pos[0] + (w - 1) * 0.5)), int(round(pos[2] + (h - 1) * 0.5))


def export_bundle(path):
    data = BundleData(path)
    grids = {mb["go"]: parse_grid(mb) for mb in data.mbs_by_kind["grid"]}
    for go, grid in grids.items():
        grid["name"] = data.names.get(go, "")
    for mb in data.mbs_by_kind["tile"]:
        root = data.grid_root_of(mb["go"])
        if root not in grids:
            continue
        tile = parse_tile(mb)
        grids[root]["tiles"][(tile["x"], tile["y"])] = tile
    for mb in data.mbs_by_kind["spawn"]:
        root = data.grid_root_of(mb["go"])
        if root not in grids:
            continue
        raw = mb["raw"]
        x, y = tile_xy(data.local_pos(mb["go"]), (grids[root]["w"], grids[root]["h"]))
        grids[root]["spawns"].append([i32(raw, 20), x, y, i32(raw, 24)])
    for mb in data.mbs_by_kind["control"]:
        root = data.grid_root_of(mb["go"])
        if root not in grids:
            continue
        raw = mb["raw"]
        x, y = tile_xy(data.local_pos(mb["go"]), (grids[root]["w"], grids[root]["h"]))
        grids[root]["controlPoints"].append([i32(raw, 20), x, y])
    results = []
    for grid in grids.values():
        match = re.search(r"Skirmish_(\d+)", grid["name"])
        if not match:
            continue
        width, height = grid["w"], grid["h"]
        expected = width * height
        found = len(grid["tiles"])
        if found != expected:
            raise RuntimeError(f"{grid['name']}: {found} tiles, esperados {expected}")
        tiles = []
        for y in range(height):
            for x in range(width):
                tile = grid["tiles"][(x, y)]
                solid = tile["solid"]
                bits = sum((1 << direction) for direction in range(4) if solid[direction])
                tiles.append([
                    tile["h"],
                    bits,
                    *tile["cover"],
                    1 if tile["vis"] else 0,
                ])
        results.append({
            "id": match.group(1),
            "source": grid["name"],
            "size": [width, height],
            "heightSteps": grid["height"],
            "tiles": tiles,
            "spawns": sorted(grid["spawns"], key=lambda item: (item[0], item[1], item[2])),
            "controlPoints": sorted(grid["controlPoints"]),
        })
    return results


def main():
    os.makedirs(OUT, exist_ok=True)
    all_grids = []
    for name in BUNDLES:
        all_grids.extend(export_bundle(os.path.join(RAW, name)))
    for grid in sorted(all_grids, key=lambda item: item["id"]):
        target = os.path.join(OUT, f"{grid['id']}_grid.json")
        with open(target, "w", encoding="utf8", newline="\n") as handle:
            json.dump(grid, handle, ensure_ascii=False, separators=(",", ":"))
        spawns = len(grid["spawns"])
        controls = len(grid["controlPoints"])
        print(f"{grid['id']} {grid['size'][0]}x{grid['size'][1]} tiles={len(grid['tiles'])} spawns={spawns} control={controls} -> {target}")


if __name__ == "__main__":
    main()
