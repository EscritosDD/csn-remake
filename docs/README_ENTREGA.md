# Entrega Z.ai — Modelos propios de Dani (Meshy AI) en CSN

Todo el trabajo de esta sesión (y el anterior) en un paquete. **Nov 2026.**

## Qué hay aquí

| Ruta | Qué es |
|---|---|
| `zai_meshy.patch` | **El patch para `git apply`** (rutas `a/…` `b/…` desde la raíz del repo): los 9 ficheros nuevos + el bloque de 9 líneas en `index.html`. Probado en un repo limpio: aplica, sintaxis 0, tableros 19/19, reglas 6/6 |
| `assets_soldier/` | Los 9 ficheros listos: `Artillero/Espia/Francotirador` × `.obj` + `_rig.json` + `_tex.png` (por si prefieres copiarlos a mano en vez del patch) |
| `docs/Modelos_propios_Meshy.md` | Documentación para el repo: mapeo, pipeline, verificación y **checklist visual para tu `zai-ver.ps1`** |
| `zai_adelgazar_modelos.py` | Pipeline genérico (por si traes más modelos Meshy) |
| `weld_meshy.py` · `empaquetar_assets.py` · `validar_assets_reales.py` | Los tres pasos del pipeline tal como corrieron tus 3 modelos, y el validador contra las reglas del motor |
| `guia_rapida.md` (de la entrega anterior) | Los 5 comandos si usas el pipeline con otros modelos |

## Los números

| Modelo Meshy | Clase | Triángulos | Textura |
|---|---|---|---|
| Heavy_Gunner | Artillero | 203.336 → **4.000** | 2048 → 512 (402 KB) |
| Shadow_Sentinel | Espía | 124.790 → **4.000** | 2048 → 512 (217 KB) |
| Ghillie_Guardian | Francotirador | 232.126 → **4.000** | 2048 → 512 (374 KB) |

Objetivo cumplido: 2.000–5.000 triángulos por modelo, riggearlos al
esqueleto del juego (20 huesos en el orden del rig base, clips de
animación reutilizados vía el retargeting delta que ya vive en el motor).

## Cómo aplicarlo (en tu repo, rama `zai/pruebas`)

```powershell
git checkout zai/pruebas
git apply zai_meshy.patch
git add -A
git commit -m "zai: modelos propios Meshy en Artillero/Espia/Francotirador"
powershell -ExecutionPolicy Bypass -File bench\VERIFICAR.ps1
git push origin zai/pruebas
```

O sin patch: copia `assets_soldier/*` a `assets/soldier/` y añade el bloque
de comentario de 9 líneas (ver el .patch, hunk @@ -4859) antes de
`const ROLE_MODEL_FILES`. El diff de `index.html` es SOLO eso: 9 líneas
de comentario documentando el cambio — el juego ya carga
`assets/soldier/<Clase>.obj` por su cuenta.

## Verificación hecha por Z.ai (sin WebGL)

- Sintaxis 0 errores · 19/19 tableros · 6/6 reglas (batería completa).
- Validador de las 5 reglas del motor sobre los 3 assets: orden de
  huesos del rig base, 4 influencias con pesos 1 (±4e-8), volumen firmado
  positivo en el espacio del juego (normales hacia fuera), bbox con pies
  a y=0, UV en [0,1], índices en rango.
- Bind de skinning cerrado: error ~1e-8 (boneWorld × boneInverse = I).
- Prueba de fuego del patch: repo limpio → `git apply` OK → batería OK.

## Lo que TÚ tienes que ver (checklist `zai-ver.ps1`)

1. Los tres modelos cargan (no caen al modelo base: el Artillero de
   Meshy es inconfundible).
2. Orientación: frente hacia el arma (si sale de espaldas o girado 90°,
   es el espejo X — me mandas captura).
3. Caras visibles (hueco/semitransparente = winding).
4. Textura aplicada (gris plano = UV).
5. `walk2h`: brazos y piernas se mueven, torso estable.
6. `fire2h`: postura de disparo sin retorcidos.
7. Silueta reconocible a 4.000 tris.
8. Altura ~1,7 junto a los soldados IPA.
9. Nada flotando ni hundido (pies a y=0).

Si algo falla: `window.__forceBaseModel=true` en la consola devuelve al
modelo del IPA al instante. Con capturas tuyo ajusto el rig (las
posiciones de hueso son fracciones humanoides estándar; con frente y
perfil las afino en una iteración).
