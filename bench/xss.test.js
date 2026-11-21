'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const vm = require('node:vm');

const root = path.dirname(__dirname);
const html = require('./source');

function extraerFn(src, nombre) {
  const inicio = src.indexOf('function ' + nombre + '(');
  assert.notEqual(inicio, -1, 'no existe ' + nombre);
  let i = src.indexOf('{', inicio);
  let depth = 0;
  let quote = null;
  let escape = false;
  for (; i < src.length; i++) {
    const c = src[i];
    if (quote) {
      if (escape) escape = false;
      else if (c === '\\') escape = true;
      else if (c === quote) quote = null;
      continue;
    }
    if (c === "'" || c === '"' || c === '`') { quote = c; continue; }
    if (c === '{') depth++;
    else if (c === '}') {
      depth--;
      if (depth === 0) return src.slice(inicio, i + 1);
    }
  }
  throw new Error('llaves desbalanceadas en ' + nombre);
}

const fnLoad = extraerFn(html, 'loadChars');
const fnLog = extraerFn(html, 'log');

function cargarPreferencias(raw) {
  const ctx = {
    LS_CHARS: 'csn_chars_v1',
    lsGet: () => raw,
    charsForRole: role => role === 'Francotirador'
      ? [{ name: 'Lobo', key: 'own:Lobo' }]
      : [],
    JSON
  };
  vm.createContext(ctx);
  vm.runInContext(fnLoad + '\nthis.loadChars = loadChars;', ctx);
  return JSON.parse(JSON.stringify(ctx.loadChars()));
}

function capturarLog(msg) {
  let salida = '';
  const ctx = {
    G: { round: 3 },
    $: () => ({ prepend: d => { salida = d.innerHTML; } }),
    document: { createElement: () => ({ innerHTML: '' }) }
  };
  vm.createContext(ctx);
  vm.runInContext(fnLog + '\nthis.log = log;', ctx);
  ctx.log(msg);
  return salida;
}

test('loadChars descarta nombres inyectados en localStorage', () => {
  assert.deepEqual(cargarPreferencias('{"Francotirador":"<img src=x onerror=alert(1)>"}'), {});
});

test('loadChars conserva solo nombres y claves del catalogo', () => {
  assert.deepEqual(cargarPreferencias('{"Francotirador":"Lobo","Espia":"Sombra"}'), { Francotirador: 'Lobo' });
  assert.deepEqual(cargarPreferencias('{"Francotirador":"own:Lobo"}'), { Francotirador: 'own:Lobo' });
});

test('loadChars ignora JSON que no sea un objeto', () => {
  assert.deepEqual(cargarPreferencias('null'), {});
  assert.deepEqual(cargarPreferencias('[1,2]'), {});
  assert.deepEqual(cargarPreferencias('{"Francotirador":42}'), {});
});

test('log escapa HTML y conserva solo negrita', () => {
  const malo = capturarLog('<img src=x onerror=alert(1)>');
  assert.ok(!malo.includes('<img'));
  assert.ok(malo.includes('&lt;img'));
  assert.ok(malo.includes('R3'));
  const bueno = capturarLog('daño <b>12</b>');
  assert.ok(bueno.includes('<b>12</b>'));
});
