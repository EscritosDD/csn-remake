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
const html = fs.readFileSync(path.join(ROOT, 'index.html'), 'utf8');

function block(marker, endMark) {
  const i = html.indexOf(marker);
  assert.ok(i >= 0, 'marcador no encontrado: ' + marker);
  const j = html.indexOf(endMark, i);
  assert.ok(j > i, 'cierre no encontrado para ' + marker);
  return html.slice(i, j);
}

test('12 naciones con personalidad propia', () => {
  const b = block('const NATIONS=[', '];');
  const ids = [...b.matchAll(/\{id:'([a-z]{2})'/g)].map(m => m[1]);
  assert.equal(ids.length, 12, 'deben ser 12 naciones');
  const pers = [...b.matchAll(/pers:\{name:'([^']+)'/g)].map(m => m[1]);
  assert.equal(pers.length, 12, 'cada nacion debe tener personalidad');
  for (const p of pers) assert.ok(p.length > 2, 'personalidad vacia');
});

test('reparto: 17 personajes del original y 18 propios', () => {
  const orig = block('const ORIG_CAST=[', '];');
  const own = block('const OWN_CAST=[', '];');
  const nOrig = (orig.match(/\{name:'/g) || []).length;
  const nOwn = (own.match(/\{name:'/g) || []).length;
  assert.equal(nOrig, 17, 'deben ser 17 personajes del IPA');
  assert.equal(nOwn, 18, 'deben ser 18 personajes propios');
  assert.equal((own.match(/bio:'/g) || []).length, 18, 'cada personaje propio debe tener bio');
  assert.equal((orig.match(/bio:'/g) || []).length, 17, 'cada personaje del original debe tener bio');
  for (const m of own.matchAll(/role:'([^']+)'/g)) {
    assert.ok(['Francotirador', 'Artillero', 'Espía', 'Médico', 'Ingeniero', 'Comando', 'Capitán'].includes(m[1]), 'rol invalido: ' + m[1]);
  }
});

test('tres skins y todas sin pasivas', () => {
  const b = block('const SKINS={', '};');
  const keys = [...b.matchAll(/\n ([a-z]+):\{name:/g)].map(m => m[1]);
  assert.deepEqual(keys.sort(), ['camuflaje', 'clase', 'estandar', 'nacion'], 'skins: ' + keys.join(','));
  assert.equal((b.match(/Sin pasiva/g) || []).length, 4, 'las cuatro skins dicen "Sin pasiva"');
});

test('6 misiones de campana con mapa, objetivo y formato validos', () => {
  const b = block('const CAMPAIGN_MISSIONS=[', '];');
  const ms = [...b.matchAll(/map:'([^']+)',objective:'([^']+)',fmt:(\d)/g)];
  assert.equal(ms.length, 6, 'deben ser 6 misiones');
  const maps = new Set([...html.matchAll(/^ ([a-z0-9]+):\{id:'/gm)].map(m => m[1]));
  for (const [, map, obj, fmt] of ms) {
    assert.ok(maps.has(map), 'mapa inexistente: ' + map);
    assert.ok(['eliminacion', 'baliza', 'dominacion', 'escolta'].includes(obj), 'objetivo invalido: ' + obj);
    assert.ok([2, 4, 5].includes(Number(fmt)), 'formato invalido: ' + fmt);
  }
});

test('cada personaje tiene su voz extraida', () => {
  const map = block('const CHAR_VOICE={', '};');
  const pairs = [...map.matchAll(/'([^']+)':'([^']+)'/g)];
  assert.ok(pairs.length >= 35, 'deben estar los 17 del original y los 18 propios');
  for (const [, name, slug] of pairs) {
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
  }
});

test('la captura auditoriza el visor y la verificacion la ejecuta', () => {
  const cap = fs.readFileSync(path.join(ROOT, '_capture_all.mjs'), 'utf8');
  const verify = fs.readFileSync(path.join(ROOT, 'bench', 'VERIFICAR.ps1'), 'utf8');
  assert.ok(cap.includes("mapId.startsWith('viewer:')"));
  assert.ok(cap.includes("result.viewerAudit = result.viewer"));
  assert.ok(verify.includes('viewer:audit-all'));
  for (const mode of ['soap', 'sneaky', 'meshy09', 'mp5k', 'minigun', 'setup']) {
    assert.ok(cap.includes(mode + ':'), 'falta modo de captura ' + mode);
  }
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
  assert.match(html, /const holder=GUN_MESH_CACHE\[file\];/);
  assert.match(html, /const meshFile=weaponFileForRef\(wanted\);/);
  assert.match(html, /position\.set\(0\.18,0\.62,0\)/);
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
