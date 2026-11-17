// Servidor estatico minimo para CSN (sin dependencias).
// Sirve el juego (index.html + assets/) para la vista previa.
const http = require('http');
const fs = require('fs');
const path = require('path');
const PORT = Number(process.env.PORT) || 3000;
const HOST = '0.0.0.0';
const ROOT = __dirname;
const MIME = { '.html':'text/html', '.js':'text/javascript', '.css':'text/css', '.json':'application/json', '.png':'image/png', '.jpg':'image/jpeg', '.jpeg':'image/jpeg', '.webp':'image/webp', '.svg':'image/svg+xml', '.ico':'image/x-icon', '.bin':'application/octet-stream', '.obj':'text/plain', '.md':'text/markdown' };
http.createServer((req, res) => {
  let rawPath = (req.url || '/').split('?')[0];
  let url;
  try {
    url = decodeURIComponent(rawPath);
  } catch {
    res.writeHead(400);
    return res.end('Bad request');
  }
  if (url === '/') url = '/index.html';
  const file = path.resolve(ROOT, '.' + (url.startsWith('/') ? url : '/' + url));
  if (file !== ROOT && !file.startsWith(ROOT + path.sep)) { res.writeHead(403); return res.end('Forbidden'); }
  fs.readFile(file, (err, data) => {
    if (err) { res.writeHead(404); return res.end('Not found'); }
    res.writeHead(200, { 'Content-Type': MIME[path.extname(file).toLowerCase()] || 'application/octet-stream' });
    res.end(data);
  });
}).listen(PORT, HOST, () => console.log(`CSN en http://${HOST}:${PORT}`));
