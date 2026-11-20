import itertools
import json
import math
import os
import subprocess
import sys

ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
PACK_PATH = os.path.join(ROOT, "assets", "soldier_clips.json")
MANIFEST_PATH = os.path.join(ROOT, "assets", "soldier_clip_manifest.json")
RIG_PATH = os.path.join(ROOT, "assets", "soldier_rig.json")


def load_json(path):
    with open(path, encoding="utf-8") as handle:
        return json.load(handle)


def git_json(commit, path):
    raw = subprocess.check_output(["git", "-C", ROOT, "show", commit + ":" + path])
    return json.loads(raw.decode("utf-8"))


def close(a, b, tolerance):
    return abs(a - b) <= tolerance


def compare_times(original, baked, tolerance):
    if len(original) != len(baked):
        return "claves: " + str(len(original)) + " vs " + str(len(baked))
    for a, b in zip(original, baked):
        if not close(a, b, tolerance):
            return "tiempo " + str(a) + " vs " + str(b)
    return None


def main():
    errors = []
    pack = load_json(PACK_PATH)
    manifest = load_json(MANIFEST_PATH)
    rig = load_json(RIG_PATH)
    bind = {bone["name"]: bone["quat"] for bone in rig["bones"]}
    entries = manifest.get("clips", [])
    keys = [entry["key"] for entry in entries]
    sources = [entry["source"] for entry in entries]
    if manifest.get("total") != 40 or len(entries) != 40:
        errors.append("el manifiesto debe cubrir 40 clips")
    if len(set(keys)) != len(keys):
        errors.append("claves de pack duplicadas")
    if len(set(sources)) != len(sources):
        errors.append("clips originales duplicados")
    if len(pack.get("bones", [])) != 20:
        errors.append("el pack debe tener 20 huesos")
    if len(pack.get("clips", {})) != 40:
        errors.append("el pack debe tener 40 clips")
    if not close(pack.get("rootScale", 0), manifest.get("rootScale", 0), 1e-6):
        errors.append("rootScale distinto entre pack y manifiesto")
    for key in keys:
        if key not in pack.get("clips", {}):
            errors.append("falta el clip " + key)
    for bone in pack.get("bones", []):
        if bone not in bind:
            errors.append("hueso sin bind: " + bone)
    commit = manifest.get("sourceCommit", "")
    source_path = manifest.get("sourcePath", "").strip("/")
    for entry in entries:
        key = entry.get("key")
        clip = pack.get("clips", {}).get(key)
        if not clip:
            continue
        if not close(clip.get("dur", 0), entry.get("duration", 0), 0.0002):
            errors.append(key + ": duracion distinta")
        for event in clip.get("events", []):
            if not isinstance(event.get("t"), (int, float)) or not isinstance(event.get("f"), str) or not isinstance(event.get("i"), int):
                errors.append(key + ": evento mal formado")
        if len(clip.get("events", [])) != entry.get("events"):
            errors.append(key + ": numero de eventos distinto")
        if key == "reference":
            for bone in pack["bones"]:
                track = clip.get("rot", {}).get(bone)
                if not track or compare_times(track.get("t", []), [0, clip["dur"]], 0.0002):
                    errors.append("reference: pista de " + bone + " no constante")
                    continue
                for quat in track.get("q", []):
                    if max(abs(a - b) for a, b in zip(quat, bind[bone])) > 1e-6:
                        errors.append("reference: bind de " + bone + " distinto")
            if clip.get("root", {}).get("p") != [[0, 0, 0], [0, 0, 0]]:
                errors.append("reference: root no neutro")
            continue
        original = git_json(commit, source_path + "/" + entry["file"])
        if not close(original["duracion_seg"], clip["dur"], 0.0002):
            errors.append(key + ": duracion original distinta")
        source_events = original.get("eventos", [])
        if len(source_events) != len(clip.get("events", [])):
            errors.append(key + ": eventos originales distintos")
        else:
            for src, dst in zip(source_events, clip["events"]):
                if not close(src["tiempo"], dst["t"], 0.0002) or src["funcion"] != dst["f"] or src["intParam"] != dst["i"]:
                    errors.append(key + ": evento " + str(dst.get("f")) + " desalineado")
                    break
        rotations = {track["hueso_corto"]: track for track in original["tracks_rotacion"]}
        for bone in pack["bones"]:
            track = clip.get("rot", {}).get(bone)
            source = rotations.get(bone)
            if not track or not source:
                errors.append(key + ": falta rotacion de " + bone)
                continue
            if compare_times(source["tiempos"], track["t"], 0.0002):
                errors.append(key + ": tiempos de " + bone + " desalineados")
            for quat in track["q"]:
                norm = math.sqrt(sum(value * value for value in quat))
                if not close(norm, 1, 0.01):
                    errors.append(key + ": cuaternion no normalizado en " + bone)
                    break
        positions = {track["hueso_corto"]: track for track in original["tracks_posicion"]}
        root_source = positions.get("Bip001")
        root = clip.get("root")
        if not root_source or not root:
            errors.append(key + ": falta root")
            continue
        if compare_times(root_source["tiempos"], root["t"], 0.0002):
            errors.append(key + ": tiempos de root desalineados")
        origin = root_source["posiciones"][0]
        scale = pack["rootScale"]
        deltas = [[value - origin[i] for i, value in enumerate(src)] for src in root_source["posiciones"]]
        candidates = []
        for axes in itertools.permutations(range(3)):
            for signs in itertools.product((-1, 1), repeat=3):
                candidates.append((axes, signs))
        matched = False
        for axes, signs in candidates:
            worst = 0
            for delta, dst in zip(deltas, root["p"]):
                expected = [signs[i] * scale * delta[axes[i]] for i in range(3)]
                worst = max(worst, max(abs(a - b) for a, b in zip(expected, dst)))
            if worst <= 0.0005:
                matched = True
                break
        if not matched and entry.get("rootTransform") == "authored":
            matched = all(all(isinstance(value, (int, float)) and math.isfinite(value) and abs(value) <= 0.5 for value in point) for point in root["p"])
            matched = matched and root["p"][0] == [0, 0, 0]
        if not matched:
            errors.append(key + ": root motion desalineado")
    if errors:
        for error in errors[:40]:
            print("ERROR", error)
        print("FALLO", len(errors), "problemas")
        return 1
    print("OK 40 clips originales, 20 huesos, eventos, tiempos, root motion y bind de referencia")
    return 0


if __name__ == "__main__":
    sys.exit(main())
