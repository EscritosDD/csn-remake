# -*- coding: utf-8 -*-
"""Decodifica PNG de Apple (CgBI) a PNG normal.

Los splash/iconos de la app iOS vienen con el chunk CgBI y deflate en crudo;
PIL no los abre. Uso:
  python bench/decode_cgbi.py <entrada.png> <salida.png>
"""
import sys, struct, zlib
from PIL import Image

def decode_cgbi(path):
    d = open(path, "rb").read()
    pos = 8; idat = b""; w = h = ct = None
    while pos < len(d):
        ln = struct.unpack(">I", d[pos:pos+4])[0]
        typ = d[pos+4:pos+8]; data = d[pos+8:pos+8+ln]; pos += 12+ln
        if typ == b"IHDR": w, h, bd, ct = struct.unpack(">IIBB", data[:10])
        elif typ == b"IDAT": idat += data
        elif typ == b"IEND": break
    raw = zlib.decompressobj(-15).decompress(idat)
    bpp = 4 if ct == 6 else 3
    stride = w*bpp
    out = bytearray(h*stride); prev = bytearray(stride); ip = 0
    for y in range(h):
        f = raw[ip]; ip += 1
        line = bytearray(raw[ip:ip+stride]); ip += stride
        if f == 1:
            for x in range(bpp, stride): line[x] = (line[x]+line[x-bpp]) & 255
        elif f == 2:
            for x in range(stride): line[x] = (line[x]+prev[x]) & 255
        elif f == 3:
            for x in range(stride):
                a = line[x-bpp] if x >= bpp else 0
                line[x] = (line[x]+((a+prev[x]) >> 1)) & 255
        elif f == 4:
            for x in range(stride):
                a = line[x-bpp] if x >= bpp else 0
                b = prev[x]; c = prev[x-bpp] if x >= bpp else 0
                p = a+b-c; pa = abs(p-a); pb = abs(p-b); pc = abs(p-c)
                pr = a if (pa <= pb and pa <= pc) else (b if pb <= pc else c)
                line[x] = (line[x]+pr) & 255
        out[y*stride:(y+1)*stride] = line; prev = line
    mode = "RGBA" if ct == 6 else "RGB"
    return Image.frombytes(mode, (w, h), bytes(out), "raw", "BGRA" if ct == 6 else "BGR")

if __name__ == "__main__":
    src, dst = sys.argv[1], sys.argv[2]
    decode_cgbi(src).save(dst)
    print("ok", dst)
