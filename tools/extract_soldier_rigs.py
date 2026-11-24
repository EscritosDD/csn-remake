import json, math, os, sys
UNITYPY = os.environ.get('CSN_UNITYPY_PATH', r'C:\Users\danie\AppData\Local\Temp\opencode\unitypy')
if UNITYPY not in sys.path:
    sys.path.insert(0, UNITYPY)
import UnityPy
from UnityPy.helpers.MeshHelper import MeshHandler

RAW = r'D:\Juegos\CSN-repo\_original\ipa\Payload\radtactics.app\Data\Raw'
OBJ_BODIES = r'D:\Juegos\CSN-repo\assets\soldier\bodies'
BODIES = os.environ.get('CSN_RIG_OUT', OBJ_BODIES)
ONLY = set(filter(None, os.environ.get('CSN_RIG_ONLY', '').split(',')))
ORDER = ['Bip001','Bip001 Pelvis','Bip001 Spine','Bip001 Spine1','Bip001 Neck','Bip001 Head',
         'Bip001 L Clavicle','Bip001 L UpperArm','Bip001 L Forearm','Bip001 L Hand',
         'Bip001 R Clavicle','Bip001 R UpperArm','Bip001 R Forearm','Bip001 R Hand',
         'Bip001 L Thigh','Bip001 L Calf','Bip001 L Foot','Bip001 R Thigh','Bip001 R Calf','Bip001 R Foot']
PARENTS = [-1,0,1,2,3,4,4,6,7,8,4,10,11,12,2,14,15,2,17,18]
SPEC = [
 ('Soldier_SAS','SoapOutfits.assetbundle',157),
 ('Soldier_Spud','SpudOutfits.assetbundle',156),
 ('Soldier_Heavy','IvanTkilyaOutfits.assetbundle',155),
 ('Soldier_Light_Rambo','ArchieFletcherOutfits.assetbundle',155),
 ('Agent_Light','MmeLaHacqueOutfits.assetbundle',155),
 ('Medic_therapist_1248v','TextbookKateOutfits.assetbundle',155),
 ('Engineer_Light','MeganMcNickOutfits.assetbundle',155),
 ('Engineer_Heavy','CarlitoGrossoOutfits.assetbundle',155),
 ('Engineer_RiotCop','RiotEngineerOutfits.assetbundle',258),
 ('CommanderM','CommanderMaleOutfits.assetbundle',263),
 ('CommanderF','CommanderFemaleOutfits.assetbundle',263),
 ('Agent','SneakyPeteOutfits.assetbundle',206),
 ('Agent_Heavy','RiotAgentOutfits.assetbundle',257),
 ('Engineer','BigTimeTaschmannOutfits.assetbundle',206),
 ('Medic','SisterFlorenceOutfits.assetbundle',206),
 ('Medic_therapist_959v','RiotMedicOutfits.assetbundle',257),
 ('Soldier_Light','HipsterDaveOutfits.assetbundle',190)
]
GUN_ALIAS = {'gunBone_L':'Bip001 L Hand','gunBone_R':'Bip001 R Hand'}

def inv(a):
    m = [row[:] for row in a]
    b = [[1.0 if i == j else 0.0 for j in range(4)] for i in range(4)]
    for c in range(4):
        p = next(r for r in range(c, 4) if abs(m[r][c]) > 1e-12)
        m[c], m[p] = m[p], m[c]
        b[c], b[p] = b[p], b[c]
        d = m[c][c]
        m[c] = [x / d for x in m[c]]
        b[c] = [x / d for x in b[c]]
        for r in range(4):
            if r == c:
                continue
            f = m[r][c]
            if f:
                m[r] = [x - f * y for x, y in zip(m[r], m[c])]
                b[r] = [x - f * y for x, y in zip(b[r], b[c])]
    return b

def mm(a, b):
    return [[sum(a[i][k] * b[k][j] for k in range(4)) for j in range(4)] for i in range(4)]

def mat_of(m):
    return [[float(getattr(m, 'e%d%d' % (r, c))) for c in range(4)] for r in range(4)]

def local_trs(tr):
    q, p, s = tr.m_LocalRotation, tr.m_LocalPosition, tr.m_LocalScale
    x, y, z, w = q.x, q.y, q.z, q.w
    cols = [[1.0 - 2.0 * (y * y + z * z), 2.0 * (x * y + z * w), 2.0 * (x * z - y * w)],
            [2.0 * (x * y - z * w), 1.0 - 2.0 * (x * x + z * z), 2.0 * (y * z + x * w)],
            [2.0 * (x * z + y * w), 2.0 * (y * z - x * w), 1.0 - 2.0 * (x * x + y * y)]]
    scale = (s.x, s.y, s.z)
    pos = (p.x, p.y, p.z)
    return [[cols[c][r] * scale[c] for c in range(3)] + [pos[r]] for r in range(3)] + [[0.0, 0.0, 0.0, 1.0]]

def unit_quat(q):
    length = math.sqrt(sum(value * value for value in q))
    return [value / length for value in q] if length > 1e-12 else [0.0, 0.0, 0.0, 1.0]

def quat_from_mat(m):
    tr = m[0][0] + m[1][1] + m[2][2]
    if tr > 0:
        s = math.sqrt(tr + 1.0) * 2.0
        return unit_quat([(m[2][1] - m[1][2]) / s, (m[0][2] - m[2][0]) / s, (m[1][0] - m[0][1]) / s, 0.25 * s])
    i = max(range(3), key=lambda k: m[k][k])
    j, k = (i + 1) % 3, (i + 2) % 3
    s = math.sqrt(1.0 + m[i][i] - m[j][j] - m[k][k]) * 2.0
    q = [0.0, 0.0, 0.0, 0.0]
    q[i] = 0.25 * s
    q[3] = (m[k][j] - m[j][k]) / s
    q[j] = (m[j][i] + m[i][j]) / s
    q[k] = (m[k][i] + m[i][k]) / s
    return unit_quat(q)

def rotation_of(m):
    out = [row[:] for row in m]
    for c in range(3):
        length = math.sqrt(sum(out[r][c] * out[r][c] for r in range(3)))
        if length > 1e-12:
            for r in range(3):
                out[r][c] /= length
    return out

def bind_world(m, zscale):
    bind = inv(mat_of(m))
    scales = [math.sqrt(sum(bind[r][c] * bind[r][c] for r in range(3))) for c in range(3)]
    scale = sum(scales) / 3.0 or 1.0
    out = rotation_of(bind)
    for r in range(3):
        out[r][3] = out[r][3] / scale * zscale
    return out

def mesh_p95(path):
    zs = []
    with open(path, encoding='latin1') as handle:
        for line in handle:
            if line.startswith('v '):
                zs.append(float(line.split()[3]))
    zs.sort()
    return zs[int(len(zs) * 0.95)] or 1.0

def obj_z_scale(path):
    return 1.14 / mesh_p95(path)

def normalize_weights(weights):
    out = [max(0.0, float(w)) for w in weights]
    total = sum(out)
    if total <= 1e-8:
        out[0] = 1.0
        return out
    return [w / total for w in out]

for body, bundle, smr_pid in SPEC:
    if ONLY and body not in ONLY:
        continue
    zscale = obj_z_scale(os.path.join(OBJ_BODIES, body + '.obj'))
    env = UnityPy.load(os.path.join(RAW, bundle))
    objects = {o.path_id: o for o in env.objects}
    names, transforms = {}, {}
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
    smr = objects[smr_pid].read()
    mesh_obj = objects[smr.m_Mesh.m_PathID].read()
    handler = MeshHandler(mesh_obj)
    handler.process()
    bone_names = []
    for ptr in smr.m_Bones:
        tr = transforms.get(ptr.m_PathID)
        bone_names.append(names.get(tr.m_GameObject.m_PathID) if tr and tr.m_GameObject else None)
    if any(name not in ORDER and name not in GUN_ALIAS for name in bone_names):
        raise RuntimeError(body + ': hueso no reconocido ' + repr(bone_names))
    remap = [ORDER.index(GUN_ALIAS.get(name, name)) for name in bone_names]
    world = {}
    for slot, name in enumerate(bone_names):
        world[name] = bind_world(mesh_obj.m_BindPose[slot], zscale)
    for side in ('L', 'R'):
        clavicle = 'Bip001 %s Clavicle' % side
        upper_name = 'Bip001 %s UpperArm' % side
        if clavicle in world:
            continue
        slot = next(i for i, name in enumerate(bone_names) if name == upper_name)
        upper_tr = transforms[smr.m_Bones[slot].m_PathID]
        father = upper_tr.m_Father
        father_tr = transforms.get(father.m_PathID) if father else None
        if not father_tr or not father_tr.m_GameObject or names.get(father_tr.m_GameObject.m_PathID) != clavicle:
            raise RuntimeError(body + ': no se pudo localizar ' + clavicle)
        local = local_trs(upper_tr)
        local[2][3] *= zscale
        world[clavicle] = mm(world[upper_name], inv(local))
    world['Bip001'] = [[1.0 if r == c else 0.0 for c in range(4)] for r in range(4)]
    world['Bip001 Neck'] = world['Bip001 Spine1']
    if abs(world['Bip001 Pelvis'][0][3]) > 0.3:
        world['Bip001 Pelvis'][0][3] = 0.0
    top = max(world[name][2][3] for name in ORDER)
    p95 = mesh_p95(os.path.join(OBJ_BODIES, body + '.obj'))
    if top > p95:
        factor = p95 / top
        for name in world:
            for r in range(3):
                world[name][r][3] *= factor
    bones = []
    inverses = []
    for i, name in enumerate(ORDER):
        parent = PARENTS[i]
        local = world[name] if parent < 0 else mm(inv(world[ORDER[parent]]), world[name])
        bones.append({'name': name, 'parent': parent,
                      'pos': [float(local[r][3]) for r in range(3)],
                      'quat': quat_from_mat(local),
                      'scale': [1.0, 1.0, 1.0]})
        bind = inv(world[name])
        inverses.append([bind[r][c] for r in range(4) for c in range(4)])
    skin_index, skin_weight = [], []
    for i in range(len(handler.m_Vertices)):
        indices = list(handler.m_BoneIndices[i])[:4]
        weights = normalize_weights(handler.m_BoneWeights[i][:4])
        while len(indices) < 4:
            indices.append(0)
            weights.append(0.0)
        skin_index.extend(remap[j] for j in indices)
        skin_weight.extend(weights)
    rig = {'bones': bones, 'skinBones': list(range(20)), 'boneInverses': inverses,
           'skinIndex': skin_index, 'skinWeight': skin_weight}
    out_path = os.path.join(BODIES, body + '_rig.json')
    with open(out_path, 'w', encoding='utf-8') as handle:
        json.dump(rig, handle, separators=(',', ':'))
    print(body, len(handler.m_Vertices), 'v', len(skin_index), 'skin', os.path.basename(out_path))
