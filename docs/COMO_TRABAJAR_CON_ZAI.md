# Cómo trabajar con Z.ai sin tocar `main`

Resumen en una frase: **Z.ai cocina en su sandbox, te pasa un patch, tú lo
pruebas en tu rama `zai/pruebas` y solo si te gusta lo llevas a `main`.**

## El reparto de papeles

| Quién | Qué hace |
|---|---|
| **Z.ai** | Trabaja en su sandbox (sin salida a GitHub) y te devuelve **patches** (`.patch`) o ficheros completos |
| **Tú** | Aplica el patch, lo prueba en local, y decide si pasa a `main` |
| **`main`** | Solo recibe lo que tú apruebas. Nunca recibe trabajo sin revisar |

## Las tres ramas

```
main          ← lo bueno y verificado (lo que ya está en GitHub)
zai/pruebas   ← donde se acumula el trabajo de Z.ai (tu campo de pruebas)
```

## Flujo completo

### 0. Preparación (ya está hecho)

La rama `zai/pruebas` ya existe en tu repo y en GitHub. Para volver a ella:

```powershell
cd D:\Juegos\CSN\csn-remake
git checkout zai/pruebas
```

### 1. Z.ai te entrega un patch

Normalmente un fichero `.patch`. Guárdalo, por ejemplo, en `D:\Juegos\CSN\patches\`.

### 2. Aplicarlo y probarlo (un solo comando)

```powershell
powershell -ExecutionPolicy Bypass -File tools\zai-aplicar.ps1 -Patch "D:\Juegos\CSN\patches\zai-cambio.patch" -Mensaje "zai: caratulas 3D"
```

Ese script, en orden:

1. Se pone en `zai/pruebas` (y comprueba que no tienes cambios a medias).
2. Aplica el patch.
3. Corre la verificación (`bench\VERIFICAR.ps1`).
4. Si va bien: commit y push a `zai/pruebas`.
5. Si algo falla: **no commitea**, te enseña el error y deja el patch sin aplicar.

### 3. Verlo funcionando

```powershell
powershell -ExecutionPolicy Bypass -File tools\zai-ver.ps1
```

Levanta el servidor en `http://127.0.0.1:8000/` y abre Chrome. Ahí juegas con la
versión de pruebas. `main` no se ha tocado.

> **Importante:** si mientras pruebas algo se rompe y quieres volver atrás:
> `git checkout zai/pruebas` + `git reset --hard origin/zai/pruebas`.

### 4. Si te gusta, pasarlo a `main`

```powershell
powershell -ExecutionPolicy Bypass -File tools\zai-promover.ps1
```

Te enseña **qué commits** van a entrar, pide confirmación, hace el merge en
`main`, verifica y lo empuja. Si algo falla, no empuja.

### 5. Si no te gusta, tirarlo

```powershell
git checkout main
git reset --hard origin/zai/pruebas   # opcional: descartar commits de la rama
```

O simplemente no lo promuevas: `main` sigue igual.

## Comprobar que todo sigue sano

```powershell
powershell -ExecutionPolicy Bypass -File tools\comprobar-repo.ps1
```

Dice en 2 segundos si `main` local y el de GitHub son iguales, si hay cambios
sin subir y si `index.html` y los assets críticos coinciden.

## ¿Se puede ver online sin tocar `main`?

Sí, con **GitHub Pages apuntando a la rama `zai/pruebas`** (Settings → Pages →
Deploy from a branch → `zai/pruebas`). Dos avisos:

- **Pages en repo privado exige plan de pago** (Pro/Team). Si tu repo es privado
  y no tienes Pro, Pages no te dejará.
- Si algún día lo activas, **no publiques `main`** con assets del IPA: son solo
  para desarrollo.

La forma barata y siempre disponible es `tools\zai-ver.ps1` (local).

## Qué darle a Z.ai

- **Sube `zai_pack.zip`** (está en `D:\Juegos\CSN\zai_pack.zip`): contiene
  `index.html`, toda la documentación, `bench/`, `package.json` y un
  `LEEME_PRIMERO.md`. Es lo mínimo para que trabaje sin los 43 MB de assets.
- Pídele **patches con `git diff` desde la raíz del repo** (rutas tipo
  `a/index.html` / `b/index.html`), así `git apply` los acepta tal cual.
- Recuérdale: **rama `zai/pruebas`, nunca `main`**; y que no puede ver el 3D
  (sin WebGL en su sandbox), así que lo visual lo revisas tú.

## Reglas que no deben romperse

1. `main` solo recibe trabajo verificado.
2. Nada de `git push --force` a `main`.
3. Si el patch toca `index.html`, **se revisa el diff antes de promover**
   (`git diff main..zai/pruebas -- index.html`).
4. Si algo se tuerce: copia de seguridad del repo en
   `D:\Juegos\CSN\_backup_repo` (espejo completo).
