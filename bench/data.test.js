'use strict';
/* Integridad de DATOS del juego: personajes, naciones, skins, misiones y
   voces. No carga el motor (para eso esta rules.test.js): comprueba que los
   catalogos del original y los anadidos no se desincronicen.

   Uso: node bench/data.test.js
*/
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');

const ROOT = path.join(__dirname, '..');
const html = require('./source');
let dataPromise;
function loadData() {
  if (!dataPromise) {
    dataPromise = Promise.all([
      import('../src/data/nations.js'),
      import('../src/data/weapons.js'),
      import('../src/data/roles.js'),
      import('../src/data/cast.js'),
      import('../src/data/maps.js'),
      import('../src/data/map-pieces.js'),
      import('../src/data/ui-copy.js')
    ]).then(mods => Object.assign({}, ...mods));
  }
  return dataPromise;
}

function block(marker, endMark) {
  const i = html.indexOf(marker);
  assert.ok(i >= 0, 'marcador no encontrado: ' + marker);
  const j = html.indexOf(endMark, i);
  assert.ok(j > i, 'cierre no encontrado para ' + marker);
  return html.slice(i, j);
}

test('12 naciones con personalidad propia', async () => {
  const { NATIONS } = await loadData();
  assert.equal(NATIONS.length, 12, 'deben ser 12 naciones');
  assert.equal(NATIONS.filter(n => /^[a-z]{2}$/.test(n.id)).length, 12);
  assert.equal(NATIONS.filter(n => n.pers && n.pers.name).length, 12, 'cada nacion debe tener personalidad');
  for (const n of NATIONS) assert.ok(n.pers.name.length > 2, 'personalidad vacia');
});

test('reparto: 17 personajes del original y 18 propios', async () => {
  const { ORIG_CAST, OWN_CAST } = await loadData();
  assert.equal(ORIG_CAST.length, 17, 'deben ser 17 personajes del IPA');
  assert.equal(OWN_CAST.length, 18, 'deben ser 18 personajes propios');
  assert.equal(OWN_CAST.filter(c => c.bio).length, 18, 'cada personaje propio debe tener bio');
  assert.equal(ORIG_CAST.filter(c => c.bio).length, 17, 'cada personaje del original debe tener bio');
  for (const c of OWN_CAST) {
    assert.ok(['Francotirador', 'Artillero', 'Espía', 'Médico', 'Ingeniero', 'Comando', 'Capitán'].includes(c.role), 'rol invalido: ' + c.role);
  }
});

test('tres skins y todas sin pasivas', async () => {
  const { SKINS } = await loadData();
  const keys = Object.keys(SKINS).sort();
  assert.deepEqual(keys, ['camuflaje', 'clase', 'estandar', 'nacion'], 'skins: ' + keys.join(','));
  assert.equal(Object.values(SKINS).filter(s => /Sin pasiva/.test(s.desc)).length, 4, 'las cuatro skins dicen "Sin pasiva"');
});

test('6 misiones de campana con mapa, objetivo y formato validos', async () => {
  const { CAMPAIGN_MISSIONS, MAP_DEFS } = await loadData();
  assert.equal(CAMPAIGN_MISSIONS.length, 6, 'deben ser 6 misiones');
  const maps = new Set(Object.keys(MAP_DEFS));
  for (const m of CAMPAIGN_MISSIONS) {
    assert.ok(maps.has(m.map), 'mapa inexistente: ' + m.map);
    assert.ok(['eliminacion', 'baliza', 'dominacion', 'escolta'].includes(m.objective), 'objetivo invalido: ' + m.objective);
    assert.ok([2, 4, 5].includes(Number(m.fmt)), 'formato invalido: ' + m.fmt);
  }
});

test('cada personaje tiene su voz extraida', async () => {
  const { CHAR_VOICE } = await loadData();
  const pairs = Object.entries(CHAR_VOICE);
  assert.ok(pairs.length >= 35, 'deben estar los 17 del original y los 18 propios');
  for (const [name, slug] of pairs) {
    for (const ev of ['select', 'confirm', 'pain', 'death', 'firing', 'thanks']) {
      const f = path.join(ROOT, 'assets', 'audio', 'voice', slug, ev + '.mp3');
      assert.ok(fs.existsSync(f), 'falta voz ' + slug + '/' + ev + '.mp3 (' + name + ')');
    }
  }
});

test('el servidor sirve GLB/GLTF con MIME correcto', () => {
  const server = fs.readFileSync(path.join(ROOT, 'server.js'), 'utf8');
  assert.match(server, /'\.glb':\s*'model\/gltf-binary'/);
  assert.match(server, /'\.gltf':\s*'model\/gltf\+json'/);
});

test('el servidor sirve styles/ y src/ sin abrir _original/ ni bench/', () => {
  const server = fs.readFileSync(path.join(ROOT, 'server.js'), 'utf8');
  assert.match(server, /parts\[0\] === 'assets' \|\| parts\[0\] === 'styles' \|\| parts\[0\] === 'src'/);
  assert.doesNotMatch(server, /parts\[0\] === '_original'/);
  assert.doesNotMatch(server, /parts\[0\] === 'bench'/);
  assert.ok(fs.existsSync(path.join(ROOT, 'src', 'package.json')));
  const pkg = JSON.parse(fs.readFileSync(path.join(ROOT, 'src', 'package.json'), 'utf8'));
  assert.equal(pkg.type, 'module');
});

test('las 23 armas tienen calibracion por bounds reales', () => {
  const cal = JSON.parse(fs.readFileSync(path.join(ROOT, 'assets', 'weapons', 'weapon_calibrations.json'), 'utf8'));
  const files = fs.readdirSync(path.join(ROOT, 'assets', 'weapons')).filter(f => f.endsWith('.obj'));
  assert.equal(Object.keys(cal).length, 23);
  for (const file of files) {
    const key = file.slice(0, -4);
    const entry = cal[key];
    assert.ok(entry, 'falta calibracion de ' + key);
    assert.deepEqual(entry.meshPivot, [0, 0, 0], 'pivote de malla debe ser nulo en ' + key);
    assert.ok(entry.scale > 0 && entry.scale < 20, 'escala rara de ' + key);
    assert.equal(entry.gripOffset.length, 3);
    assert.equal(Object.hasOwn(entry, 'socket'), false, 'las calibraciones no deben fijar socket por nombre');
    assert.deepEqual(entry.forwardAxis, [1, 0, 0], 'eje de boca en +X para ' + key);
    assert.deepEqual(entry.muzzleDir, [1, 0, 0], 'direccion de boca en +X para ' + key);
    assert.equal(entry.muzzlePos.length, 3, 'boca real de ' + key);
    assert.ok(entry.muzzlePos.every(Number.isFinite), 'boca finita de ' + key);
    assert.ok(entry.muzzlePos[0] > 0, 'boca hacia +X en ' + key);
    assert.equal(entry.sourceDims.length, 3);
    assert.ok(entry.sourceDims.every(value => Number.isFinite(value) && value > 0), 'dimensiones reales de ' + key);
    assert.ok(entry.sourceBounds.min.every(Number.isFinite) && entry.sourceBounds.max.every(Number.isFinite));
  }
});

test('los sockets de mano y las bocas del IPA estan extraidos', () => {
  const sockets = JSON.parse(fs.readFileSync(path.join(ROOT, 'assets', 'weapons', 'weapon_sockets.json'), 'utf8'));
  assert.ok(sockets.handRight && sockets.handRight.pos.length === 3 && sockets.handRight.pos.every(Number.isFinite));
  assert.ok(sockets.handLeft && sockets.handLeft.pos.length === 3 && sockets.handLeft.pos.every(Number.isFinite));
  assert.ok(Object.keys(sockets.muzzles).length >= 14);
  for (const muzzle of Object.values(sockets.muzzles)) {
    assert.ok(muzzle.pos.every(Number.isFinite));
    assert.ok(muzzle.rot.length === 4 && muzzle.rot.every(Number.isFinite));
  }
});

test('el audio de armas procede de los AudioClip del original', () => {
  const dir = path.join(ROOT, 'assets', 'audio', 'sfx', 'weapons');
  const files = ['assaultrifle_fire.mp3', 'semiautorifle_fire.mp3', 'submachinegun_fire.mp3', 'mp5k_fire.mp3',
    'lmg_fire.mp3', 'minigun_fire.mp3', 'm95_fire.mp3', 'sniperrifle_fire.mp3', 'shotgun_fire.mp3',
    'riotshotgun_fire.wav', 'jackhammer_fire.mp3', 'rocketlauncher_fire.mp3', 'launcher_explode.mp3',
    'cluster_explode.mp3', 'beretta_fire.mp3', 'revolver_fire.mp3', 'grenade_throw_02.mp3',
    'knife_slash_01.mp3', 'knife_stab_01.mp3', 'axe_swing_01.mp3', '2h_swing_01.mp3',
    'spikedclub_hit_01.mp3', 'baseballbat_hit_01.mp3', 'chainsaw_swing_01.mp3'];
  for (const file of files) assert.ok(fs.existsSync(path.join(dir, file)), 'falta ' + file);
  const weapons = fs.readFileSync(path.join(ROOT, 'src', 'data', 'weapons.js'), 'utf8');
  assert.doesNotMatch(weapons, /Lanzagranadas':'cluster_explode/);
  assert.match(weapons, /WEAPON_SFX_BY_WEAPON/);
});

test('los 23 perfiles originales enlazan clips, audio y acciones', async () => {
  const { WEAPONS_ORIGINAL, originalWeaponProfile } = await import('../src/render3d/assets-weapons.js');
  const { auWeaponFile } = await import('../src/audio/sound.js');
  const soundSrc = fs.readFileSync(path.join(ROOT, 'src', 'audio', 'sound.js'), 'utf8');
  const clips = JSON.parse(fs.readFileSync(path.join(ROOT, 'assets', 'soldier_clips.json'), 'utf8')).clips;
  const dir = path.join(ROOT, 'assets', 'audio', 'sfx', 'weapons');
  const esperado = {
    AssaultRifle: ['idle2h', 'fireBurst', 'assaultrifle_fire.mp3', true, 'Probar disparo'],
    Rifle: ['idle2h', 'fire2h', 'semiautorifle_fire.mp3', true, 'Probar disparo'],
    Pistol: ['idle1h', 'fire1h', 'beretta_fire.mp3', true, 'Probar disparo'],
    Revolver: ['idle1h', 'fire1hHeavy', 'revolver_fire.mp3', true, 'Probar disparo'],
    Uzi: ['idle1h', 'fire1hBurst', 'submachinegun_fire.mp3', true, 'Probar disparo'],
    MP5K: ['idle2h', 'fireBurst', 'mp5k_fire.mp3', true, 'Probar disparo'],
    LightMachineGun: ['idle2h', 'fireBurst', 'lmg_fire.mp3', true, 'Probar disparo'],
    Minigun: ['idle2h', 'fireMini', 'minigun_fire.mp3', true, 'Probar disparo'],
    SniperRifle_weapon: ['idle2h', 'fireHeavy', 'sniperrifle_fire.mp3', true, 'Probar disparo'],
    M95: ['idle2h', 'fireHeavy', 'm95_fire.mp3', true, 'Probar disparo'],
    Shotgun: ['idle2h', 'fireHeavy', 'shotgun_fire.mp3', true, 'Probar disparo'],
    RiotShotgun: ['idle2h', 'fireHeavy', 'riotshotgun_fire.wav', true, 'Probar disparo'],
    RPG: ['idle2h', 'fireShoulder', 'rocketlauncher_fire.mp3', true, 'Probar disparo'],
    Crossbow: ['idle2h', 'fire2h', 'crossbow_fire.mp3', false, 'Probar disparo'],
    Knife: ['idleMelee', 'fireMelee', 'knife_slash_01.mp3', false, 'Probar ataque'],
    Katana: ['idleMelee', 'fireMelee', 'knife_slash_01.mp3', false, 'Probar ataque'],
    WoodAxe: ['idleMelee', 'fireMelee', 'axe_swing_01.mp3', false, 'Probar ataque'],
    SledgeHammer: ['idleMelee', 'fireMelee', '2h_swing_01.mp3', false, 'Probar ataque'],
    BaseballBat_SOURCE: ['idleMelee', 'fireMelee', 'baseballbat_hit_01.mp3', false, 'Probar ataque'],
    SpikedClub_weapon: ['idleMelee', 'fireMelee', 'spikedclub_hit_01.mp3', false, 'Probar ataque'],
    Chainsaw: ['idleMelee', 'fireMelee', 'chainsaw_swing_01.mp3', false, 'Probar ataque'],
    FragGrenade: ['idle1h', 'throw', 'grenade_throw_01.mp3', false, 'Probar lanzamiento'],
    Molotov: ['idle1h', 'throw', 'grenade_throw_01.mp3', false, 'Probar lanzamiento']
  };
  assert.equal(Object.keys(esperado).length, 23);
  assert.deepEqual(Object.keys(WEAPONS_ORIGINAL).sort(), Object.keys(esperado).sort());
  for (const [file, values] of Object.entries(esperado)) {
    const [idleClip, fireClip, sfx, hasMuzzleFlash, actionLabel] = values;
    assert.deepEqual(originalWeaponProfile(file), { idleClip, fireClip, sfx, hasMuzzleFlash, actionLabel }, 'perfil de ' + file);
    assert.ok(fs.existsSync(path.join(dir, sfx)), 'falta audio ' + sfx + ' (' + file + ')');
    assert.ok(clips[idleClip], 'falta clip ' + idleClip + ' (' + file + ')');
    assert.ok(clips[fireClip], 'falta clip ' + fireClip + ' (' + file + ')');
    assert.doesNotThrow(() => auWeaponFile(file), 'auWeaponFile ' + file);
  }
  assert.equal(WEAPONS_ORIGINAL.AssaultRifle.name, 'Assault Rifle');
  assert.equal(WEAPONS_ORIGINAL.Rifle.name, 'Semi Auto Rifle');
  assert.match(soundSrc, /import\s*\{[^}]*originalWeaponProfile[^}]*\}\s*from\s*'\.\.\/render3d\/assets-weapons\.js'/);
  assert.match(soundSrc, /export function auWeaponFile\(file\)/);
  assert.match(soundSrc, /originalWeaponProfile\(file\)/);
  assert.match(soundSrc, /auPlay\('sfx\/weapons\/'\+profile\.sfx,profile\.sfx\.endsWith\('\.wav'\)\?0\.35:0\.45\)/);
});

test('el material de las armas usa la textura del IPA sin alias ni mipmaps', () => {
  const src = fs.readFileSync(path.join(ROOT, 'src', 'render3d', 'assets-weapons.js'), 'utf8');
  assert.match(src, /color:0xb8b8b8,roughness:0\.80,metalness:0\.03/);
  assert.match(src, /side:THREE\.FrontSide/);
  assert.match(src, /t\.generateMipmaps=false;t\.minFilter=THREE\.LinearFilter;t\.magFilter=THREE\.LinearFilter/);
  assert.match(src, /t\.wrapS=THREE\.ClampToEdgeWrapping;t\.wrapT=THREE\.ClampToEdgeWrapping/);
  const socketSrc = fs.readFileSync(path.join(ROOT, 'src', 'render3d', 'gun-pose.js'), 'utf8');
  assert.match(socketSrc, /WEAPON_SOCKETS\.handRight/);
});

test('la captura auditoriza el visor y la verificacion la ejecuta', () => {
  const cap = fs.readFileSync(path.join(ROOT, '_capture_all.mjs'), 'utf8');
  const verify = fs.readFileSync(path.join(ROOT, 'bench', 'VERIFICAR.ps1'), 'utf8');
  assert.ok(cap.includes("mapId.startsWith('viewer:')"));
  assert.ok(cap.includes("result.viewerAudit = result.viewer"));
  assert.ok(verify.includes('viewer:audit-all'));
  for (const mode of ['soap', 'sneaky', 'megan', 'sister', 'rpg', 'fire', 'meshy09', 'mp5k', 'minigun', 'inspector', 'setup']) {
    assert.ok(cap.includes(mode + ':'), 'falta modo de captura ' + mode);
  }
  assert.ok(cap.includes('inspectorAudit'));
});

test('los siete modelos por clase estan en assets/soldier', () => {
  const files = ['Francotirador', 'Artillero', 'Espia', 'Medico', 'Ingeniero', 'Comando', 'Capitan'];
  for (const f of files) {
    for (const ext of ['.obj', '_rig.json', '_tex.png']) {
      const p = path.join(ROOT, 'assets', 'soldier', f + ext);
      assert.ok(fs.existsSync(p), 'falta ' + f + ext);
    }
  }
  const scales = JSON.parse(fs.readFileSync(path.join(ROOT, 'assets', 'soldier_scales.json'), 'utf8'));
  for (const f of files) assert.ok(scales[f] > 0.2 && scales[f] < 2, 'escala rara para ' + f);
});

function conteoOBJ(archivo) {
  const lineas = fs.readFileSync(archivo, 'latin1').split(/\r?\n/);
  return {
    v: lineas.reduce((n, l) => n + (/^v\s/.test(l.trim()) ? 1 : 0), 0),
    f: lineas.reduce((n, l) => n + (/^f\s/.test(l.trim()) ? 1 : 0), 0),
    txt: lineas.join('\n')
  };
}

test('assets/soldier solo contiene los siete cuerpos IPA originales', () => {
  const files = ['Francotirador', 'Artillero', 'Espia', 'Medico', 'Ingeniero', 'Comando', 'Capitan'];
  for (const f of files) {
    const m = conteoOBJ(path.join(ROOT, 'assets', 'soldier', f + '.obj'));
    assert.ok(m.v < 1600, f + ' tiene ' + m.v + ' vértices (Meshy no debe estar en soldier)');
    assert.ok(m.f < 4000, f + ' tiene ' + m.f + ' caras (Meshy no debe estar en soldier)');
    assert.equal(/Meshy/i.test(m.txt), false, f + ' lleva cabecera Meshy');
  }
  assert.equal(fs.readdirSync(path.join(ROOT, 'assets', 'soldier')).filter(f => f.endsWith('.obj')).length, 7);
});

test('los cinco diseños Meshy siguen intactos en assets/personajes_propios', () => {
  const files = ['Francotirador', 'Artillero', 'Espia', 'Medico', 'Ingeniero'];
  for (const f of files) {
    const m = conteoOBJ(path.join(ROOT, 'assets', 'personajes_propios', f + '.obj'));
    assert.ok(m.f >= 4000, f + ' ya no conserva la malla Meshy completa');
    assert.ok(fs.existsSync(path.join(ROOT, 'assets', 'personajes_propios', f + '_rig.json')));
    assert.ok(fs.existsSync(path.join(ROOT, 'assets', 'personajes_propios', f + '_tex.png')));
  }
});

test('sin alphaTest especular y sin parches por nombre de personaje', () => {
  assert.doesNotMatch(html, /alphaTest:\s*0\.5/);
  assert.doesNotMatch(html, /if\s*\(\s*entry\.name\s*===/);
  assert.match(html, /if\(ud&&ud\.meshy\)return/);
});

test('el visor no aplica pose, clips ni retarget a los modelos Meshy', () => {
  const loader = block('async function loadViewerMeshy(entry){', '\n  function makeViewerRiggedModel');
  assert.doesNotMatch(loader, /poseViewerRest/);
  assert.doesNotMatch(loader, /retargetPoseToRig/);
  assert.match(loader, /meshy:true/);
  assert.doesNotMatch(loader, /baseRestQ/);
  assert.match(html, /if\(ud&&ud\.meshy\)return false;\s*if\(!clip/);
  assert.match(html, /const ud=mesh\.userData;if\(ud&&ud\.meshy\)return;/);
});

test('el visor usa el cargador de armas compartido sin alias temporales', () => {
  assert.doesNotMatch(html, /viewerWeaponCacheKey/);
  assert.doesNotMatch(html, /WEAPON_MESH_FILE\[key\]=file/);
  assert.match(html, /const sourceGun=GUN_MESH_CACHE\[meshFile\];/);
  assert.match(html, /const meshFile=weaponFileForRef\(wanted\);/);
  assert.doesNotMatch(html, /position\.set\(0\.18,0\.62,0\)/);
  assert.doesNotMatch(html, /if\(bS\)\{/);
  assert.match(html, /viewerWeaponLabelText/);
  assert.doesNotMatch(html, /weaponLabel\.textContent=/);
});

test('mount() reengancha el modelo sin saltos y alinea la plataforma', () => {
  assert.match(html, /if\(model\.parent\)model\.parent\.remove\(model\);/);
  assert.match(html, /model\.position\.set\(0,0,0\);/);
  assert.match(html, /viewer\.platform\.position\.y=bounds\.min\.y-center\.y-0\.02;/);
});

test('Configurar partida permite elegir personaje por ranura', () => {
  assert.match(html, /data-kind="char"/);
  assert.match(html, /out\.push\(\{role,weapon,charKey\}\);/);
  assert.match(html, /function charForKey\(role,key\)\{/);
  assert.match(html, /def\.charKey\?charForKey\(def\.role,def\.charKey\)/);
  assert.match(html, /MESHY_CAST\.map\(c=>\(\{\.\.\.c,key:c\.key/);
  assert.match(html, /geometry\.deleteAttribute\('skinWeight'\)[\s\S]{0,400}side:THREE\.FrontSide/);
});

test('los originales del visor traen arma por defecto y pueden equipar las 23 armas originales', () => {
  const viewer = fs.readFileSync(path.join(ROOT, 'src', 'viewer', 'main.js'), 'utf8');
  const troops = fs.readFileSync(path.join(ROOT, 'src', 'viewer', 'troop-cards.js'), 'utf8');
  const cast = fs.readFileSync(path.join(ROOT, 'src', 'data', 'cast.js'), 'utf8');
  const defaults = Object.fromEntries([...cast.matchAll(/name:'([^']+)'[^\n]*?defaultWeapon:'([^']+)'/g)].map(m => [m[1], m[2]]));
  assert.equal(Object.keys(defaults).length, 17);
  const esperado = {
    'Hipster Dave': 'M4A1', 'Archie Fletcher': 'M249 SAW', 'Soap': 'M240B', 'Spud': 'RPG-7',
    'Ivan Tkilya': 'M249 SAW', 'Mme La Hacque': 'MP7', 'Sneaky Pete': 'M40',
    'Sister Florence': 'M4A1', 'Riot Medic': 'M4A1', 'Textbook Kate': 'M4A1',
    'Big Time Taschmann': 'Remington 870', 'Megan McNick': 'Benelli M4', 'Carlito Grosso': 'M203',
    'Riot Agent': 'MP5', 'Riot Engineer': 'M4A1', 'Commander (M)': 'M4A1', 'Commander (F)': 'Desert Eagle'
  };
  assert.deepEqual(defaults, esperado);
  assert.match(viewer, /viewerWeaponFiles=\[/);
  const weapons = viewer.split('const viewerWeaponFiles=[')[1].split('];')[0];
  assert.equal((weapons.match(/'/g)||[]).length/2, 23);
  assert.match(troops, /getWeaponFiles:\(\)=>tcWeaponFiles/);
  assert.match(viewer, /originalWeaponProfile\(file\)/);
  assert.match(viewer, /auWeaponFile\(weaponFileForRef\(weapon\)\|\|weapon\)/);
  assert.doesNotMatch(viewer, /VIEWER_ROLE_WEAPONS/);
  assert.doesNotMatch(viewer, /MAP_PIECES/);
});

test('el visor funde clips y dispara desde eventos del clip', () => {
  const viewer = fs.readFileSync(path.join(ROOT, 'src', 'viewer', 'main.js'), 'utf8');
  assert.match(viewer, /function poseViewerClip\(model,clip,ct,key,signature,now,dtMs\)/);
  assert.match(viewer, /typeof CLIP_BLEND_MS!=='undefined'\?CLIP_BLEND_MS:200/);
  assert.match(viewer, /typeof _smooth01==='function'\?_smooth01\(0,1,p\)/);
  assert.match(viewer, /function dispatchViewerFire\(actor,clip,key,ct,weapon\)/);
  assert.match(viewer, /f==='PlayWeaponFire'\|\|f==='PlayFiring'/);
  assert.match(viewer, /gun\.userData\._testFlash=1/);
  assert.doesNotMatch(viewer, /fireBtn\.onclick[\s\S]{0,600}auWeapon/);
  assert.doesNotMatch(viewer, /position\.set\(0\.18,0\.62,0\)/);
});

test('los roles del reparto original coinciden con el IPA', async () => {
  const { CHARACTERS, ORIG_CAST } = await loadData();
  const jugables = Object.fromEntries(CHARACTERS.map(entry => [entry.name, entry.role]));
  assert.deepEqual(jugables, {
    'Hipster Dave': 'Comando', 'Ivan Tkilya': 'Artillero', 'Sneaky Pete': 'Francotirador',
    'Sister Florence': 'Médico', 'Big Time Taschmann': 'Ingeniero',
    'Riot Agent': 'Espía', 'Commander (M)': 'Capitán'
  });
  const roles = Object.fromEntries(ORIG_CAST.map(entry => [entry.name, entry.role]));
  for (const [name, role] of Object.entries({
    'Hipster Dave': 'Comando', 'Archie Fletcher': 'Artillero', 'Soap': 'Artillero',
    'Spud': 'Artillero', 'Ivan Tkilya': 'Artillero', 'Sneaky Pete': 'Francotirador',
    'Mme La Hacque': 'Espía', 'Riot Agent': 'Espía'
  })) assert.equal(roles[name], role, name);
});

test('los 10 desplegables tienen un SFX original accesible', async () => {
  const { DEPLOYABLES } = await import('../src/data/deployables.js');
  const sound = fs.readFileSync(path.join(ROOT, 'src', 'audio', 'sound.js'), 'utf8');
  const arsenal = fs.readFileSync(path.join(ROOT, 'src', 'ui', 'arsenal.js'), 'utf8');
  const inspector = fs.readFileSync(path.join(ROOT, 'src', 'viewer', 'inspector.js'), 'utf8');
  assert.equal(DEPLOYABLES.length, 10);
  for (const prop of DEPLOYABLES) {
    assert.match(prop.sfx, /^sfx\/abilities\/[\w-]+\.(mp3|wav)$/, prop.key);
    assert.ok(fs.existsSync(path.join(ROOT, 'assets', 'audio', prop.sfx)), prop.sfx);
  }
  assert.match(sound, /export function auDeployable\(key\)/);
  assert.match(arsenal, /data-au-deployable/);
  assert.match(inspector, /auDeployable\(insCurrent\.key\)/);
});
