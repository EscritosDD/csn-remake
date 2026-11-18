# Aplica un patch de Z.ai en la rama de pruebas, verifica y sube.
# Uso:
#   powershell -ExecutionPolicy Bypass -File tools\zai-aplicar.ps1 -Patch "D:\ruta\cambio.patch" [-Mensaje "texto"]
param(
  [Parameter(Mandatory=$true)][string]$Patch,
  [string]$Mensaje = "zai: cambio sin describir",
  [string]$Rama = "zai/pruebas"
)
$ErrorActionPreference = "Stop"
$repo = Split-Path -Parent $PSScriptRoot
Set-Location $repo

function Fallo($txt) { Write-Host ""; Write-Host "FALLO: $txt" -ForegroundColor Red; exit 1 }

if (-not (Test-Path $Patch)) { Fallo "no encuentro el patch: $Patch" }
$Patch = (Resolve-Path $Patch).Path

# 1) limpio?
$sucio = git status --porcelain
if ($sucio) { Fallo "tienes cambios sin commitear. Guardalos o descartalos antes:`n$sucio" }

# 2) a la rama de pruebas
git rev-parse --verify $Rama 2>$null | Out-Null
if ($LASTEXITCODE -ne 0) {
  Write-Host "La rama $Rama no existe; la creo desde main..." -ForegroundColor Yellow
  git checkout main | Out-Null
  git checkout -b $Rama | Out-Null
}
git checkout $Rama | Out-Null
if ($LASTEXITCODE -ne 0) { Fallo "no puedo cambiar a la rama $Rama" }

# 3) aplicar
Write-Host "Aplicando $Patch ..." -ForegroundColor Cyan
git apply --check $Patch 2>&1 | Out-String | Write-Host
if ($LASTEXITCODE -ne 0) { Fallo "el patch no aplica limpio (revisa que sea un git diff desde la raiz del repo)" }
git apply $Patch
if ($LASTEXITCODE -ne 0) { Fallo "git apply fallo" }

# 4) verificar
Write-Host "`nVerificando..." -ForegroundColor Cyan
powershell -ExecutionPolicy Bypass -File "bench\VERIFICAR.ps1"
if ($LASTEXITCODE -ne 0) {
  Write-Host "`nLa verificacion FALLO. No commiteo; deshago el patch." -ForegroundColor Red
  git checkout -- .
  exit 1
}

# 5) commit y push
git add -A
git commit -m $Mensaje | Out-String | Write-Host
git push -u origin $Rama 2>&1 | Out-String | Write-Host
if ($LASTEXITCODE -ne 0) { Fallo "no pude empujar la rama $Rama" }

Write-Host "`nOK: patch aplicado, verificado y subido a $Rama." -ForegroundColor Green
Write-Host "Para verlo:  powershell -File tools\zai-ver.ps1"
Write-Host "Para promoverlo a main:  powershell -File tools\zai-promover.ps1"
