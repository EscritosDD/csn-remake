import json
import math
import os

ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
WEAPONS = os.path.join(ROOT, "assets", "weapons")
OUTPUT = os.path.join(WEAPONS, "weapon_calibrations.json")

TARGETS = {
    "AssaultRifle": 0.54,
    "Rifle": 0.54,
    "Pistol": 0.21,
    "SniperRifle_weapon": 0.72,
    "Shotgun": 0.50,
    "RPG": 0.74,
    "Crossbow": 0.60,
    "SledgeHammer": 0.60,
    "Uzi": 0.36,
    "Revolver": 0.21,
    "RiotShotgun": 0.50,
    "M95": 0.72,
    "LightMachineGun": 0.64,
    "Molotov": 0.50,
    "Knife": 0.60,
    "Katana": 0.60,
    "WoodAxe": 0.60,
    "MP5K": 0.36,
    "Chainsaw": 0.60,
    "Minigun": 0.64,
    "BaseballBat_SOURCE": 0.60,
    "SpikedClub_weapon": 0.60,
    "FragGrenade": 0.50,
}


def bounds(path):
    minimum = [math.inf, math.inf, math.inf]
    maximum = [-math.inf, -math.inf, -math.inf]
    with open(path, "rb") as handle:
        for line in handle.read().decode("latin1").splitlines():
            if not line.startswith("v "):
                continue
            point = [float(value) for value in line[2:].split()[:3]]
            for axis in range(3):
                minimum[axis] = min(minimum[axis], point[axis])
                maximum[axis] = max(maximum[axis], point[axis])
    return minimum, maximum


def main():
    calibrations = {}
    for name, target in TARGETS.items():
        minimum, maximum = bounds(os.path.join(WEAPONS, name + ".obj"))
        size = [maximum[axis] - minimum[axis] for axis in range(3)]
        length = max(size[0], size[2], 0.001)
        center = [(minimum[axis] + maximum[axis]) / 2 for axis in range(3)]
        calibrations[name] = {
            "socket": "Bip001 R Hand",
            "supportSocket": "Bip001 L Hand",
            "scale": target / length,
            "targetLength": target,
            "meshPivot": [-minimum[0], -center[2], -center[1]],
            "gripOffset": [0.0, 0.0, 0.0],
            "sourceBounds": {"min": minimum, "max": maximum},
            "sourceDims": size,
        }
    with open(OUTPUT, "w", encoding="utf-8", newline="\r\n") as handle:
        json.dump(calibrations, handle, ensure_ascii=False, indent=2)
        handle.write("\n")
    print("calibradas %d armas en %s" % (len(calibrations), os.path.relpath(OUTPUT, ROOT)))


if __name__ == "__main__":
    main()
