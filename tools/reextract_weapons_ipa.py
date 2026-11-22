import argparse
import json
import math
import os
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
RAW = ROOT / '_original' / 'ipa' / 'Payload' / 'radtactics.app' / 'Data' / 'Raw'
WEAPONS_DIR = ROOT / 'assets' / 'weapons'
AUDIO_DIR = ROOT / 'assets' / 'audio' / 'sfx' / 'weapons'

SPECS = [
    ('AssaultRifle', 'BasicWeapons.assetbundle', 'AssaultRifle', 'AssaultRifle'),
    ('Rifle', 'BasicWeapons.assetbundle', 'Rifle', 'Rifle'),
    ('Pistol', 'BasicWeapons.assetbundle', 'Pistol', 'Pistol'),
    ('SniperRifle_weapon', 'BasicWeapons.assetbundle', 'SniperRifle_weapon', 'SniperRifle_Mesh'),
    ('Shotgun', 'BasicWeapons.assetbundle', 'Shotgun', 'Shotgun_Mesh'),
    ('RPG', 'BasicWeapons.assetbundle', 'RPG', 'RPG'),
    ('Crossbow', 'BasicWeapons.assetbundle', 'Crossbow', 'Crossbow'),
    ('SledgeHammer', 'BasicWeapons.assetbundle', 'SledgeHammer', None),
    ('FragGrenade', 'BasicWeapons.assetbundle', 'FragGrenade', None),
    ('Uzi', 'Weapons.assetbundle', 'Uzi', 'Uzi'),
    ('Revolver', 'Weapons.assetbundle', 'Revolver', 'Revolver'),
    ('RiotShotgun', 'Weapons.assetbundle', 'RiotShotgun', 'RiotShotgun'),
    ('M95', 'Weapons.assetbundle', 'M95', 'M95'),
    ('LightMachineGun', 'Weapons.assetbundle', 'LightMachineGun', 'LightMachineGun'),
    ('Molotov', 'Weapons.assetbundle', 'Molotov', None),
    ('Knife', 'Weapons.assetbundle', 'Knife', None),
    ('Katana', 'Weapons.assetbundle', 'Katana', None),
    ('WoodAxe', 'Weapons.assetbundle', 'WoodAxe', None),
    ('Minigun', 'Weapons.assetbundle', 'Minigun', 'Minigun_Mesh'),
    ('BaseballBat_SOURCE', 'Weapons.assetbundle', 'BaseballBat_SOURCE', None),
    ('SpikedClub_weapon', 'Weapons02.assetbundle', 'SpikedClub_weapon', None),
    ('MP5K', 'Weapons02.assetbundle', 'MP5K', 'MP5K'),
    ('Chainsaw', 'Weapons03.assetbundle', 'Chainsaw', None),
]

AUDIO_SPECS = [
    'assaultrifle_fire', 'semiautorifle_fire', 'submachinegun_fire', 'mp5k_fire',
    'lmg_fire', 'minigun_fire', 'm95_fire', 'sniperrifle_fire',
    'shotgun_fire', 'riotshotgun_fire', 'jackhammer_fire',
    'rocketlauncher_fire', 'launcher_explode', 'cluster_explode',
    'beretta_fire', 'revolver_fire', 'knife_slash_01', 'knife_stab_01',
    'axe_swing_01', '2h_swing_01', 'spikedclub_hit_01',
    'baseballbat_hit_01', 'chainsaw_swing_01', 'grenade_throw_01',
    'grenade_throw_02', 'grenade_throw_03',
    'shotgun_rack', 'jackhammer_rack', 'riotshotgun_cock',
    'bullet_hit_01', 'bullet_hit_02', 'bulletby_01',
]

BUNDLE_CACHE = {}
MESH_CACHE = {}
MUZZLE_CACHE = {}
SOCKET_CACHE = {}


def fmt(value):
    return format(float(value), '.10g')


def load_bundle(name):
    if name not in BUNDLE_CACHE:
        path = RAW / name
        if not path.exists():
            raise SystemExit('falta bundle ' + str(path))
        BUNDLE_CACHE[name] = UnityPy.load(str(path))
    return BUNDLE_CACHE[name]


def transform_index(env):
    names = {}
    transforms = {}
    for obj in env.objects:
        if obj.type.name == 'GameObject':
            try:
                names[obj.path_id] = obj.read().m_Name
            except Exception:
                pass
        elif obj.type.name == 'Transform':
            try:
                transforms[obj.path_id] = obj.read()
            except Exception:
                pass
    return names, transforms


def transform_name(names, transform):
    if not transform or not transform.m_GameObject:
        return None
    return names.get(transform.m_GameObject.m_PathID)


def parent_transform(transforms, transform):
    if not transform or not transform.m_Father:
        return None
    return transforms.get(transform.m_Father.m_PathID)


def build_caches():
    for bundle_name, mesh_name, prefab in [(s[1], s[2], s[3]) for s in SPECS]:
        env = load_bundle(bundle_name)
        names, transforms = transform_index(env)
        for obj in env.objects:
            if obj.type.name == 'Mesh':
                data = obj.read()
                if data.m_Name != mesh_name or mesh_name in MESH_CACHE:
                    continue
                handler = MeshHandler(data)
                handler.process()
                MESH_CACHE[mesh_name] = handler
        if not prefab:
            continue
        for transform in transforms.values():
            name = transform_name(names, transform)
            if name != 'gunMuzzleBone':
                continue
            root = parent_transform(transforms, transform)
            if transform_name(names, root) != 'gunRootBone':
                continue
            owner = parent_transform(transforms, root)
            if transform_name(names, owner) != prefab:
                continue
            p = transform.m_LocalPosition
            r = transform.m_LocalRotation
            MUZZLE_CACHE[prefab] = {
                'pos': [-float(p.x), float(p.y), float(p.z)],
                'rot': [float(r.x), float(r.y), float(r.z), float(r.w)],
            }
    env = load_bundle('CommanderMaleOutfits.assetbundle')
    names, transforms = transform_index(env)
    for transform in transforms.values():
        name = transform_name(names, transform)
        if name not in ('gunBone_R', 'gunBone_L') or name in SOCKET_CACHE:
            continue
        parent = parent_transform(transforms, transform)
        parent_name = transform_name(names, parent)
        if parent_name not in ('Bip001 R Hand', 'Bip001 L Hand'):
            continue
        p = transform.m_LocalPosition
        r = transform.m_LocalRotation
        SOCKET_CACHE[name] = {
            'bundle': 'CommanderMaleOutfits.assetbundle',
            'pos': [-float(p.x), float(p.y), float(p.z)],
            'rot': [float(r.x), float(r.y), float(r.z), float(r.w)],
            'parent': parent_name,
        }


def faces_from_handler(handler):
    verts = handler.m_Vertices
    faces = []
    degenerate = 0
    for submesh in handler.get_triangles():
        for a, b, c in submesh:
            ax, ay, az = verts[a]
            bx, by, bz = verts[b]
            cx, cy, cz = verts[c]
            ux, uy, uz = bx - ax, by - ay, bz - az
            vx, vy, vz = cx - ax, cy - ay, cz - az
            nx, ny, nz = uy * vz - uz * vy, uz * vx - ux * vz, ux * vy - uy * vx
            if math.sqrt(nx * nx + ny * ny + nz * nz) * 0.5 < 1e-8:
                degenerate += 1
                continue
            faces.append((c, b, a))
    return faces, degenerate


def write_obj(path, header, handler, faces):
    vertices = handler.m_Vertices
    uvs = handler.m_UV0
    if len(uvs) != len(vertices):
        uvs = [(0.0, 0.0)] * len(vertices)
    with open(path, 'w', encoding='ascii', newline='\r\n') as handle:
        handle.write(header + '\n')
        for x, y, z in vertices:
            handle.write('v %s %s %s\n' % (fmt(-x), fmt(y), fmt(z)))
        for u, v in uvs:
            handle.write('vt %s %s\n' % (fmt(u), fmt(v)))
        for a, b, c in faces:
            handle.write('f %d/%d %d/%d %d/%d\n' % (a + 1, a + 1, b + 1, b + 1, c + 1, c + 1))
    return vertices


def obj_header(path):
    text = path.read_text(encoding='latin1')
    header = next((line for line in text.splitlines() if line.startswith('g ')), None)
    return header or 'g ' + path.stem


def bounds_of(vertices):
    exported = [(-x, y, z) for x, y, z in vertices]
    mins = [min(v[i] for v in exported) for i in range(3)]
    maxs = [max(v[i] for v in exported) for i in range(3)]
    return {
        'min': [round(x, 6) for x in mins],
        'max': [round(x, 6) for x in maxs],
    }, [round(maxs[i] - mins[i], 6) for i in range(3)]


def muzzle_from_bounds(bounds, vertices):
    target = bounds['max'][0]
    best = None
    best_dist = float('inf')
    for x, y, z in vertices:
        dist = abs(-x - target) + abs(y) * 0.2 + abs(z) * 0.2
        if dist < best_dist:
            best_dist = dist
            best = [-x, y, z]
    return best or [target, 0.0, 0.0]


def snap_muzzle(candidate, vertices):
    best = None
    best_dist = float('inf')
    for x, y, z in vertices:
        px = -x
        dist = (px - candidate[0]) ** 2 + (y - candidate[1]) ** 2 + (z - candidate[2]) ** 2
        if dist < best_dist:
            best_dist = dist
            best = [px, y, z]
    return best or candidate


def extract_audio():
    created = []
    missing = []
    wanted = set(AUDIO_SPECS)
    for bundle_name in ['BasicWeapons.assetbundle', 'Weapons.assetbundle', 'Weapons02.assetbundle', 'Weapons03.assetbundle']:
        env = load_bundle(bundle_name)
        for obj in env.objects:
            if obj.type.name != 'AudioClip':
                continue
            data = obj.read()
            name = data.m_Name
            if name not in wanted:
                continue
            raw = bytes(data.m_AudioData)
            if len(raw) >= 4 and raw[:4] == b'RIFF' and raw[8:12] == b'WAVE':
                ext = '.wav'
            elif len(raw) >= 2 and raw[0] == 0xff and raw[1] & 0xe0 == 0xe0:
                ext = '.mp3'
            else:
                missing.append(name + ': formato de audio desconocido')
                wanted.discard(name)
                continue
            path = AUDIO_DIR / (name + ext)
            path.write_bytes(raw)
            created.append(name + ext)
            wanted.discard(name)
    missing.extend(sorted(wanted))
    return created, missing


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('--unitypy-path', default=os.environ.get('CSN_UNITYPY_PATH', ''))
    args = parser.parse_args()
    if args.unitypy_path:
        sys.path.insert(0, args.unitypy_path)
    global UnityPy, MeshHandler
    try:
        import UnityPy
        from UnityPy.helpers.MeshHelper import MeshHandler
    except ImportError:
        fallback = Path(os.environ.get('LOCALAPPDATA', '')) / 'Temp' / 'opencode' / 'unitypy'
        if fallback.exists():
            sys.path.insert(0, str(fallback))
            import UnityPy
            from UnityPy.helpers.MeshHelper import MeshHandler
        else:
            raise SystemExit('UnityPy no disponible: usa --unitypy-path')
    WEAPONS_DIR.mkdir(parents=True, exist_ok=True)
    AUDIO_DIR.mkdir(parents=True, exist_ok=True)
    build_caches()
    calibrations_path = WEAPONS_DIR / 'weapon_calibrations.json'
    calibrations = json.loads(calibrations_path.read_text(encoding='utf8'))
    report = []
    for file_name, bundle_name, mesh_name, prefab in SPECS:
        handler = MESH_CACHE.get(mesh_name)
        if handler is None:
            raise SystemExit('no se encontro malla ' + mesh_name)
        faces, degenerate = faces_from_handler(handler)
        if not faces:
            raise SystemExit('sin caras para ' + file_name)
        path = WEAPONS_DIR / (file_name + '.obj')
        vertices = write_obj(path, obj_header(path), handler, faces)
        bounds, dims = bounds_of(vertices)
        if prefab and prefab in MUZZLE_CACHE:
            muzzle = snap_muzzle(MUZZLE_CACHE[prefab]['pos'], vertices)
            muzzle_source = prefab + '/gunMuzzleBone'
        else:
            muzzle = muzzle_from_bounds(bounds, vertices)
            muzzle_source = 'bounds'
        old = calibrations.get(file_name, {})
        target = float(old.get('targetLength') or max(dims))
        scale = target / max(dims) if max(dims) else float(old.get('scale') or 1)
        calibrations[file_name] = {
            'scale': round(scale, 9),
            'targetLength': round(target, 6),
            'meshPivot': [0.0, 0.0, 0.0],
            'gripOffset': [0.0, 0.0, 0.0],
            'sourceBounds': bounds,
            'sourceDims': dims,
            'forwardAxis': [1, 0, 0],
            'muzzleDir': [1, 0, 0],
            'muzzlePos': [round(x, 6) for x in muzzle],
            'muzzleSource': muzzle_source,
        }
        report.append((file_name, len(vertices), len(faces), degenerate, muzzle_source))
    calibrations_path.write_text(json.dumps(calibrations, ensure_ascii=False, indent=2) + '\n', encoding='utf8')
    sockets_path = WEAPONS_DIR / 'weapon_sockets.json'
    sockets_path.write_text(json.dumps({
        'handRight': SOCKET_CACHE.get('gunBone_R'),
        'handLeft': SOCKET_CACHE.get('gunBone_L'),
        'muzzles': MUZZLE_CACHE,
    }, ensure_ascii=False, indent=2) + '\n', encoding='utf8')
    audio_created, audio_missing = extract_audio()
    print('archivo|v|f|degeneradas|boca')
    for row in report:
        print('|'.join(str(x) for x in row))
    print('audio extraido: ' + ', '.join(audio_created))
    if audio_missing:
        print('audio faltante: ' + ', '.join(audio_missing))


if __name__ == '__main__':
    main()
