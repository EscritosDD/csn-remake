// bench/check-syntax.js — Verifica que el JavaScript incrustado de index.html
// parsea sin errores (equivalente a `node --check` para el artefacto HTML).
// No ejecuta el código: solo lo compila.
'use strict';
const fs = require('fs');
const path = require('path');
const vm = require('vm');

const html = fs.readFileSync(path.join(__dirname, '..', 'index.html'), 'utf8');
const re = /<script(?![^>]*\bsrc=)[^>]*>([\s\S]*?)<\/script>/gi;
let m, i = 0, errors = 0;
while ((m = re.exec(html))) {
  i++;
  try { new vm.Script(m[1], { filename: 'inline-' + i }); }
  catch (e) { errors++; console.log('BLOQUE ' + i + ' ERROR: ' + e.message); }
}
console.log('bloques <script> inline: ' + i + ' · errores de sintaxis: ' + errors);
process.exit(errors ? 1 : 0);
