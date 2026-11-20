const http = require('http');
const fs = require('fs');
const fsp = require('fs/promises');
const path = require('path');

const PORT = Number.parseInt(process.env.PORT, 10) || 8000;
const HOST = process.env.HOST || '127.0.0.1';
const ROOT = fs.realpathSync.native(__dirname);

const MIME = {
  '.html': 'text/html; charset=utf-8',
  '.js': 'text/javascript; charset=utf-8',
  '.mjs': 'text/javascript; charset=utf-8',
  '.css': 'text/css; charset=utf-8',
  '.json': 'application/json; charset=utf-8',
  '.png': 'image/png',
  '.jpg': 'image/jpeg',
  '.jpeg': 'image/jpeg',
  '.webp': 'image/webp',
  '.gif': 'image/gif',
  '.svg': 'image/svg+xml',
  '.ico': 'image/x-icon',
  '.mp3': 'audio/mpeg',
  '.ogg': 'audio/ogg',
  '.wav': 'audio/wav',
  '.woff': 'font/woff',
  '.woff2': 'font/woff2',
  '.bin': 'application/octet-stream',
  '.obj': 'text/plain; charset=utf-8',
  '.md': 'text/markdown; charset=utf-8'
};

const HEADERS = {
  'X-Content-Type-Options': 'nosniff',
  'Referrer-Policy': 'no-referrer',
  'X-Frame-Options': 'deny',
  'Cross-Origin-Resource-Policy': 'same-origin',
  'Cache-Control': 'no-store'
};

const inside = (base, target) => {
  const rel = path.relative(base, target);
  return rel === '' || (rel !== '..' && !rel.startsWith('..' + path.sep) && !path.isAbsolute(rel));
};

const allowed = (rel) => {
  const parts = rel.split(path.sep).filter(Boolean);
  if (parts[0] === 'assets') return true;
  return parts.length === 1 && (parts[0] === 'index.html' || parts[0] === 'favicon.ico');
};

async function resolveFile(rawUrl) {
  let decoded;
  try { decoded = decodeURIComponent(rawUrl.split('?')[0]); } catch { return null; }
  if (decoded === '/') decoded = '/index.html';
  if (/[\u0000-\u001f\\]/.test(decoded) || /^[a-zA-Z]:/.test(decoded) || decoded.startsWith('//')) return null;
  const candidate = path.resolve(ROOT, '.' + (decoded.startsWith('/') ? decoded : '/' + decoded));
  if (!inside(ROOT, candidate)) return null;
  if (!allowed(path.relative(ROOT, candidate))) return null;
  let real;
  try { real = await fsp.realpath(candidate); } catch { return null; }
  if (!inside(ROOT, real) || !allowed(path.relative(ROOT, real))) return null;
  try {
    const stat = await fsp.stat(real);
    return stat.isFile() ? { real, size: stat.size, mtimeMs: stat.mtimeMs } : null;
  } catch { return null; }
}

http.createServer(async (req, res) => {
  if (req.method !== 'GET' && req.method !== 'HEAD') {
    res.writeHead(405, { ...HEADERS, Allow: 'GET, HEAD' });
    return res.end();
  }
  const file = await resolveFile(req.url || '/');
  if (!file) {
    res.writeHead(404, { ...HEADERS, 'Content-Type': 'text/plain; charset=utf-8' });
    return res.end('Not found');
  }
  const type = MIME[path.extname(file.real).toLowerCase()] || 'application/octet-stream';
  const etag = `"${file.size}-${Math.trunc(file.mtimeMs)}"`;
  const headers = {
    ...HEADERS,
    'Content-Type': type,
    'Accept-Ranges': 'bytes',
    ETag: etag
  };
  if (req.headers['if-none-match'] === etag) {
    res.writeHead(304, headers);
    return res.end();
  }
  const match = /^bytes=(\d*)-(\d*)$/.exec(req.headers.range || '');
  if (!match) {
    res.writeHead(200, { ...headers, 'Content-Length': file.size });
    if (req.method === 'HEAD') return res.end();
    return fs.createReadStream(file.real).pipe(res);
  }
  let start = match[1] === '' ? file.size - Number(match[2]) : Number(match[1]);
  let end = match[2] === '' ? file.size - 1 : Math.min(Number(match[2]), file.size - 1);
  if (!Number.isFinite(start) || !Number.isFinite(end) || start < 0 || start > end || start >= file.size) {
    res.writeHead(416, { ...headers, 'Content-Range': `bytes */${file.size}` });
    return res.end();
  }
  res.writeHead(206, {
    ...headers,
    'Content-Length': end - start + 1,
    'Content-Range': `bytes ${start}-${end}/${file.size}`
  });
  if (req.method === 'HEAD') return res.end();
  fs.createReadStream(file.real, { start, end }).pipe(res);
}).listen(PORT, HOST, () => console.log(`CSN en http://${HOST}:${PORT}`));
