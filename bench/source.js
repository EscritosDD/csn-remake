'use strict';
const fs = require('fs');
const path = require('path');
const root = path.join(__dirname, '..');
const files = ['index.html'];
(function walk(dir) {
  for (const e of fs.readdirSync(dir, { withFileTypes: true })) {
    const p = path.join(dir, e.name);
    if (e.isDirectory()) walk(p);
    else if (e.name.endsWith('.js')) files.push(path.relative(root, p).replace(/\\/g, '/'));
  }
})(path.join(root, 'src'));
module.exports = files.map(f => fs.readFileSync(path.join(root, f), 'utf8')).join('\n');
