'use strict';
const test=require('node:test');
const assert=require('node:assert/strict');
const fs=require('node:fs');
const path=require('node:path');
const vm=require('node:vm');
const { makeTestGLB }=require('./helpers/make-test-glb.js');

const root=path.join(__dirname,'..');
const read=relative=>fs.readFileSync(path.join(root,relative),'utf8');

function loadCompetitive(){
  const sb={console,Math,JSON,Object,Array,String,Number,Boolean,Function,Date,RegExp,Error,TypeError,Promise,Symbol,Map,Set,WeakMap,Reflect,Proxy,TextDecoder,Infinity,NaN,undefined,setTimeout,clearTimeout};
  sb.window=sb;sb.self=sb;sb.globalThis=sb;
  sb.fetch=()=>{
    const fixture=makeTestGLB();
    const copy=fixture.buffer.slice(fixture.byteOffset,fixture.byteOffset+fixture.byteLength);
    return Promise.resolve({ok:true,json:async()=>({schemaVersion:1,chars:[],weapons:[],anims:{}}),arrayBuffer:async()=>copy});
  };
  vm.createContext(sb);
  vm.runInContext(read('assets/three.min.js'),sb,{filename:'assets/three.min.js'});
  for(const name of ['render3d/gltf-loader.js','render3d/asset-cache.js','render3d/actor-glb.js','data/catalog-competitive.js']){
    const source=read('src/'+name)
      .replace(/^\s*import\s+[^;]+;\s*$/gm,'')
      .replace(/^export\s+/gm,'');
    const decls=[...source.matchAll(/^(async function|function|class|let|const|var)\s+([A-Za-z_$][\w$]*)/gm)]
      .map(m=>({name:m[2],mutable:m[1]==='let'||m[1]==='var'}));
    const expose=decls.map(d=>d.mutable
      ? 'Object.defineProperty(globalThis,"'+d.name+'",{configurable:true,get:()=>'+d.name+',set:v=>{'+d.name+'=v;}});'
      : 'globalThis.'+d.name+'='+d.name+';').join('');
    vm.runInContext(source+'\n;'+expose,sb,{filename:'src/'+name});
  }
  return sb;
}

function bufferFromGLB(buffer){
  const copy=new Uint8Array(buffer.length);
  copy.set(buffer);
  return copy.buffer;
}

function srcFiles(dir){
  return fs.readdirSync(dir,{withFileTypes:true}).flatMap(entry=>{
    const full=path.join(dir,entry.name);
    return entry.isDirectory()?srcFiles(full):(entry.name.endsWith('.js')?[full]:[]);
  });
}

test('ningún módulo de src deja un if/for/while/else con cuerpo vacío',()=>{
  const phantom=/\b(?:if|for|while)\s*\([^)]*\)[\r\n\t ]*;|\belse[\r\n\t ]*;/;
  assert.equal(phantom.test('if(x)\n;'),true);
  assert.equal(phantom.test('if(x){}else\n;'),true);
  for(const file of srcFiles(path.join(root,'src'))){
    const source=fs.readFileSync(file,'utf8');
    assert.equal(phantom.test(source),false,file+' contiene un cuerpo vacío fantasma');
  }
});

test('parseGLB lee mallas, skin, material, animación y estadísticas del fixture',()=>{
  const ctx=loadCompetitive();
  const loaded=ctx.parseGLB(bufferFromGLB(makeTestGLB()),{skipTextures:true});
  assert.equal(loaded.stats.triangles,1);
  assert.equal(loaded.stats.skinnedMeshes,1);
  assert.equal(loaded.stats.skins,1);
  assert.equal(loaded.stats.animations,1);
  assert.equal(loaded.stats.vertices,3);
  assert.equal(loaded.animations[0].name,'idle');
  assert.equal(loaded.animations[0].tracks[0].name,'TestRoot.quaternion');
  let skinned=0;loaded.scene.traverse(object=>{if(object.isSkinnedMesh)skinned++;});
  assert.equal(skinned,1);
});

test('parseGLB rechaza magic inválido',()=>{
  const ctx=loadCompetitive();
  const broken=new Uint8Array(32);broken.set([1,2,3,4]);
  assert.throws(()=>ctx.parseGLB(broken.buffer),/magic incorrecto/);
});

test('el actor GLB normaliza altura, expone socket y reproduce clips con AnimationMixer',()=>{
  const ctx=loadCompetitive();
  const loaded=ctx.parseGLB(bufferFromGLB(makeTestGLB()),{skipTextures:true});
  const actor=ctx.createGlbCharacterActor(loaded);
  const box=new ctx.THREE.Box3();
  actor.root.updateMatrixWorld(true);
  actor.root.traverse(object=>{
    if(!object.geometry)return;
    if(!object.geometry.boundingBox)object.geometry.computeBoundingBox();
    if(object.geometry.boundingBox&&!object.geometry.boundingBox.isEmpty())box.union(object.geometry.boundingBox.clone().applyMatrix4(object.matrixWorld));
  });
  const height=box.getSize(new ctx.THREE.Vector3()).y;
  assert.ok(Math.abs(height-1.08)<0.02);
  assert.ok(actor.bones.size>=1);
  assert.ok(actor.sockets.right);
  assert.ok(actor.mixer);
  assert.ok(actor.actions.idle);
  const action=ctx.crossFadeTo(actor,'idle',0.1,true);
  assert.equal(action,actor.actions.idle);
  ctx.updateGlbActor(actor,0.016);
  assert.ok(ctx.getMuzzleWorldPos(actor).isVector3);
  const socket=ctx.resolveWeaponSocket(actor,'left');
  assert.ok(socket);
  assert.equal(ctx.disposeGlbActor(actor)>0,true);
});

test('AssetCache reutiliza entradas y libera la víctima LRU',()=>{
  const ctx=loadCompetitive();
  const cache=new ctx.AssetCache({maxEntries:2});
  let loads=0;
  const loader=key=>{loads++;return {scene:{traverse(){}},key};};
  return Promise.all([cache.get('a',()=>loader('a')),cache.get('b',()=>loader('b'))]).then(()=>cache.get('a',()=>loader('a'))).then(value=>{
    assert.equal(value.key,'a');
    assert.equal(loads,2);
    assert.equal(cache.has('b'),true);
    return cache.get('c',()=>loader('c'));
  }).then(()=>{
    assert.equal(cache.has('b'),false);
    assert.equal(cache.has('a'),true);
    assert.equal(cache.size,2);
    assert.equal(cache.clear(),2);
  });
});

test('el manifest competitivo valida rutas y resuelve entradas bajo demanda',async()=>{
  const ctx=loadCompetitive();
  const manifest=JSON.parse(read('assets/competitive/manifest.json'));
  assert.equal(ctx.validateManifest(manifest).ok,true);
  const loaded=await ctx.loadCompetitiveManifest();
  assert.equal(loaded.schemaVersion,1);
  assert.equal(ctx.resolveCompetitiveSkin(loaded,'inexistente'),null);
  assert.equal(ctx.competitiveAnimationFor(loaded,'chars','inexistente','idle'),null);
  const bad={schemaVersion:1,chars:[{id:'x',file:'../fuera.glb'}],weapons:[],anims:{}};
  const validation=ctx.validateManifest(bad);
  assert.equal(validation.ok,false);
  assert.ok(validation.errors.some(message=>/file/.test(message)));
});
