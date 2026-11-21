// bench/check-syntax.js — Verifica que el JavaScript incrustado de index.html
// y los modulos de src/ parsean sin errores. No ejecuta el código: solo lo compila.
'use strict';
const fs = require('fs');
const path = require('path');
const vm = require('vm');
const { execFileSync } = require('child_process');

const root = path.join(__dirname, '..');
const html = fs.readFileSync(path.join(root, 'index.html'), 'utf8');
const re = /<script(?![^>]*\bsrc=)[^>]*>([\s\S]*?)<\/script>/gi;
let m, i = 0, errors = 0;
while ((m = re.exec(html))) {
  i++;
  const source = m[1].replace(/^\s*import\s+[^;]+;\s*$/gm, '');
  try { new vm.Script(source, { filename: 'inline-' + i }); }
  catch (e) { errors++; console.log('BLOQUE ' + i + ' ERROR: ' + e.message); }
}
let modules = 0;
function walk(dir) {
  for (const entry of fs.readdirSync(dir, { withFileTypes: true })) {
    const file = path.join(dir, entry.name);
    if (entry.isDirectory()) walk(file);
    else if (entry.name.endsWith('.js')) {
      modules++;
      try { execFileSync(process.execPath, ['--check', file], { stdio: 'pipe' }); }
      catch (e) { errors++; console.log('MODULO ' + entry.name + ' ERROR: ' + (e.stderr || e.message).toString().trim()); }
    }
  }
}
const srcScripts = [...html.matchAll(/<script type="module" src="([^"]+)"/gi)].map(x => x[1]);
for (const src of srcScripts) {
  if (!fs.existsSync(path.join(root, src))) { errors++; console.log('SCRIPT MODULO NO ENCONTRADO: ' + src); }
}
walk(path.join(root, 'src'));
console.log('bloques inline: ' + i + ' · scripts modulo: ' + srcScripts.length + ' · modulos src: ' + modules + ' · errores de sintaxis: ' + errors);
process.exit(errors ? 1 : 0);
