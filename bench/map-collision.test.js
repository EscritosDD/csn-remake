'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');

const root = path.dirname(__dirname);
const html = fs.readFileSync(path.join(root, 'index.html'), 'utf8');
const ids = ['03', '04', '05', '06', '08', '09', '10', '11'];
const grids = new Map(ids.map(id => [id, JSON.parse(fs.readFileSync(path.join(root, 'assets', 'maps', id + '_grid.json'), 'utf8'))]));

function tile(grid, x, y) {
  if (x < 0 || y < 0 || x >= grid.size[0] || y >= grid.size[1]) return null;
  return grid.tiles[y * grid.size[0] + x];
}
function solid(grid, x, y, nx, ny) {
  const a = tile(grid, x, y), b = tile(grid, nx, ny);
  if (!a || !b) return true;
  if (nx === x + 1) return !!(a[1] & 2 || b[1] & 8);
  if (nx === x - 1) return !!(a[1] & 8 || b[1] & 2);
  if (ny === y + 1) return !!(a[1] & 4 || b[1] & 1);
  if (ny === y - 1) return !!(a[1] & 1 || b[1] & 4);
  return true;
}
function connected(grid, from) {
  const seen = new Set([from[0] + ',' + from[1]]);
  const q = [from];
  while (q.length) {
    const [x, y] = q.shift();
    for (const [dx, dy] of [[1, 0], [-1, 0], [0, 1], [0, -1]]) {
      const nx = x + dx, ny = y + dy, k = nx + ',' + ny;
      if (seen.has(k) || solid(grid, x, y, nx, ny)) continue;
      const t = tile(grid, nx, ny);
      if (!t || t[1] === 15) continue;
      seen.add(k); q.push([nx, ny]);
    }
  }
  return seen.size;
}

test('las ocho rejillas IPA conservan su tamaño nativo', () => {
  const expected = { '03': [32, 26], '04': [16, 24], '05': [16, 30], '06': [24, 32], '08': [16, 28], '09': [23, 17], '10': [11, 24], '11': [18, 16] };
  for (const id of ids) {
    const grid = grids.get(id);
    assert.deepEqual(grid.size, expected[id]);
    assert.equal(grid.tiles.length, grid.size[0] * grid.size[1]);
    assert.ok(grid.tiles.every(t => t.length === 7 && t[1] >= 0 && t[1] <= 15));
    assert.ok(grid.tiles.every(t => t.slice(2, 6).every(v => v >= 0 && v <= 3)));
    assert.ok(grid.spawns.every(s => s[1] >= 0 && s[2] >= 0 && s[1] < grid.size[0] && s[2] < grid.size[1]));
    assert.ok(grid.controlPoints.every(p => p[1] >= 0 && p[2] >= 0 && p[1] < grid.size[0] && p[2] < grid.size[1]));
  }
});

test('las rejillas IPA tienen despliegues conectados y sin cruce de aristas sólidas', () => {
  for (const id of ids) {
    const grid = grids.get(id);
    const first = grid.spawns[0];
    assert.ok(connected(grid, [first[1], first[2]]) > 10, id);
    for (let y = 0; y < grid.size[1]; y++) for (let x = 0; x < grid.size[0]; x++) {
      if (x + 1 < grid.size[0]) assert.equal(solid(grid, x, y, x + 1, y), solid(grid, x + 1, y, x, y));
      if (y + 1 < grid.size[1]) assert.equal(solid(grid, x, y, x, y + 1), solid(grid, x, y + 1, x, y));
    }
  }
});

test('el motor usa rejilla nativa, aristas, barriles y cobertura direccional', () => {
  assert.match(html, /let W=12,H=12;/);
  assert.match(html, /function canStep\(x0,y0,x1,y1,ignoreActors\)\{/);
  assert.match(html, /if\(nativeSolidEdge\(x0,y0,x1,y1\)\)return false/);
  assert.match(html, /if\(barrelAt\(x1,y1\)\)return false/);
  assert.match(html, /function gridLineCells\(a,b\)\{/);
  assert.match(html, /Math\.max\(e\[2\],e\[3\]\)\>=3/);
  assert.match(html, /return e\?Math\.max\(e\[2\],e\[3\]\):0/);
  assert.match(html, /function tileWorldY\(x,y\)\{/);
  assert.ok(html.includes("typeof location!=='undefined'&&/(?:^|[?&])debugGrid"));
  assert.match(html, /const sx=W\/\(st\.bounds\.max\[0\]-st\.bounds\.min\[0\]\),sz=H\/\(st\.bounds\.max\[2\]-st\.bounds\.min\[2\]\)/);
  assert.match(html, /dbg\.name='debugGrid3D'/);
  assert.match(html, /nativeSolidEdge\(x,y,e\[0\],e\[1\]\)/);
  assert.match(html, /if\(!geoShown\)\{try\{buildThemedProps3\(world,G\.map\.theme\);\}catch\(e\)\{\}\}/);
});
