import sys
import re

def clean_obj(in_path, out_path):
    with open(in_path, 'r') as f:
        lines = f.readlines()
    
    cleaned = []
    for line in lines:
        line = line.strip()
        if line.startswith('v '):
            parts = line.split()
            x, y, z = float(parts[1]), float(parts[2]), float(parts[3])
            if not (y < -0.15 and z > 1.0):
                cleaned.append(line + '\n')
        else:
            cleaned.append(line + '\n')
    
    with open(out_path, 'w') as f:
        f.writelines(cleaned)

if __name__ == '__main__':
    if len(sys.argv) != 3:
        print('Usage: python clean_mesh.py <input.obj> <output.obj>')
        sys.exit(1)
    clean_obj(sys.argv[1], sys.argv[2])
