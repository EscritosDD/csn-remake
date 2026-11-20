'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');

const root = path.dirname(__dirname);
const read = name => JSON.parse(fs.readFileSync(path.join(root, name), 'utf8'));
const pack = read('assets/soldier_clips.json');
const manifest = read('assets/soldier_clip_manifest.json');
const rig = read('assets/soldier_rig.json');

test('the original 40 aligned clips are all packed and mapped once', () => {
  assert.equal(manifest.total, 40);
  assert.equal(manifest.clips.length, 40);
  assert.equal(new Set(manifest.clips.map(entry => entry.key)).size, 40);
  assert.equal(new Set(manifest.clips.map(entry => entry.source)).size, 40);
  assert.equal(pack.bones.length, 20);
  assert.equal(Object.keys(pack.clips).length, 40);
  assert.equal(pack.rootScale, manifest.rootScale);
  for (const entry of manifest.clips) {
    assert.ok(pack.clips[entry.key], entry.key);
    assert.equal(pack.clips[entry.key].dur, entry.duration);
    assert.equal(pack.clips[entry.key].events.length, entry.events);
  }
});

test('reference clip is the exact base bind pose', () => {
  const bind = new Map(rig.bones.map(bone => [bone.name, bone.quat]));
  const reference = pack.clips.reference;
  assert.ok(reference);
  assert.equal(reference.events.length, 0);
  assert.deepEqual(reference.root.p, [[0, 0, 0], [0, 0, 0]]);
  for (const bone of pack.bones) {
    const track = reference.rot[bone];
    assert.deepEqual(track.t, [0, reference.dur]);
    assert.deepEqual(track.q[0], bind.get(bone));
    assert.deepEqual(track.q[1], bind.get(bone));
  }
});

test('every baked clip event uses the runtime shape', () => {
  for (const [key, clip] of Object.entries(pack.clips)) {
    assert.ok(Number.isFinite(clip.dur), key);
    for (const event of clip.events) {
      assert.ok(Number.isFinite(event.t), key);
      assert.equal(typeof event.f, 'string', key);
      assert.equal(typeof event.i, 'number', key);
      assert.ok(event.t >= 0 && event.t <= clip.dur + 0.001, key + ' ' + event.f);
    }
  }
});
