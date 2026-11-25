import test from 'node:test';
import assert from 'node:assert/strict';
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const root = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '..');
const MAPS = path.join(root, 'assets', 'maps');

const FILES = {
  skirmish03: 'skirmish03.bin', skirmish04: 'skirmish04.bin',
  skirmish05: 'skirmish05.bin', skirmish06: 'skirmish06.bin',
  skirmish08: 'skirmish08.bin', skirmish09: 'skirmish09.bin',
  skirmish10: 'skirmish10.bin', skirmish11: 'skirmish11.bin',
  skirmish13: 'skirmish13.bin', t2beach: 't2_skirmish01.bin',
  t2favela: 't2_skirmish02.bin', t2oldtown: 't2_skirmish03.bin',
  t2centro: 't2_skirmish04.bin', t2construction: 't2_skirmish05.bin',
  t2lapa: 't2_skirmish06.bin',
};

const THEME = {
  skirmish03: 'skirmish03', skirmish04: 'skirmish04',
  skirmish05: 'depot', skirmish06: 'platform',
  skirmish08: 'terminal', skirmish09: 'rotonda',
  skirmish10: 'cruce', skirmish11: 'astillero',
  skirmish13: 'skirmish13', t2beach: 't2beach',
  t2favela: 't2favela', t2oldtown: 't2oldtown',
  t2centro: 't2centro', t2construction: 't2construction',
  t2lapa: 't2lapa',
};

test('la geometría IPA (.bin) es íntegra y coincide con el catálogo', () => {
  const mapsSrc = fs.readFileSync(path.join(root, 'src', 'data', 'maps.js'), 'utf8');
  for (const [id, file] of Object.entries(FILES)) {
    const buf = fs.readFileSync(path.join(MAPS, file));
    const hlen = buf.readUInt32LE(0);
    const header = JSON.parse(buf.toString('utf8', 4, 4 + hlen));
    const nv = header.verts;
    const nidx = header.groups.reduce((a, g) => a + g.count, 0);
    const expect = 4 + hlen + nv * 3 * 4 + nv * 2 * 4 + nidx * 4;
    assert.equal(expect, buf.length, id + ': tamaño del .bin inconsistente con su cabecera');
    assert.ok(Array.isArray(header.groups) && header.groups.length > 0, id + ': sin grupos');
    assert.match(mapsSrc, new RegExp("theme:'" + THEME[id] + "',verts:" + nv + ","), id + ': vértices del catálogo no coinciden con el .bin');
    const atlas = fs.readdirSync(MAPS).filter(f => f.includes('atlas'));
    assert.ok(atlas.length > 0, id + ': sin atlas en assets/maps');
  }
});
