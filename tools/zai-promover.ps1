# Promueve la rama de pruebas a main, con verificacion y confirmacion.
# Uso: powershell -ExecutionPolicy Bypass -File tools\zai-promover.ps1 [-Rama zai/pruebas]
param([string]$Rama = "zai/pruebas")
$ErrorActionPreference = "Stop"
$repo = Split-Path -Parent $PSScriptRoot
Set-Location $repo

if (git status --porcelain) { Write-Host "Tienes cambios sin commitear. Guardalos antes." -ForegroundColor Red; exit 1 }

git rev-parse --verify $Rama 2>$null | Out-Null
if ($LASTEXITCODE -ne 0) { Write-Host "No existe la rama $Rama." -ForegroundColor Red; exit 1 }

$commits = git log "main..$Rama" --oneline
if (-not $commits) { Write-Host "La rama $Rama no tiene nada nuevo respecto a main." -ForegroundColor Yellow; exit 0 }

Write-Host "Estos commits entrarian en main:" -ForegroundColor Cyan
$commits | Out-String | Write-Host

$ficheros = git diff --stat "main..$Rama"
Write-Host "Ficheros afectados:" -ForegroundColor Cyan
$ficheros | Out-String | Write-Host

if (git diff --name-only "main..$Rama" | Select-String "^index\.html$") {
  Write-Host "AVISO: el cambio toca index.html. Revisa el diff antes de continuar:" -ForegroundColor Yellow
  Write-Host "   git diff main..$Rama -- index.html" -ForegroundColor Yellow
}

$resp = Read-Host "`nSeguro que quieres pasar $Rama a main? (escribe SI)"
if ($resp -ne "SI") { Write-Host "Cancelado. main no se ha tocado." -ForegroundColor Yellow; exit 0 }

git checkout main
if ($LASTEXITCODE -ne 0) { Write-Host "No pude cambiar a main." -ForegroundColor Red; exit 1 }
$antes = (git rev-parse HEAD).Trim()

git merge --no-ff $Rama -m "Merge $Rama"
if ($LASTEXITCODE -ne 0) {
  Write-Host "El merge tiene conflictos. Resuelvelos o aborta con: git merge --abort" -ForegroundColor Red
  exit 1
}

Write-Host "`nVerificando main antes de empujar..." -ForegroundColor Cyan
powershell -ExecutionPolicy Bypass -File "bench\VERIFICAR.ps1"
if ($LASTEXITCODE -ne 0) {
  Write-Host "La verificacion FALLO. Deshago el merge; main no se empuja." -ForegroundColor Red
  git reset --hard $antes
  exit 1
}

git push origin main
if ($LASTEXITCODE -ne 0) { Write-Host "El merge esta hecho en local pero no pude empujar." -ForegroundColor Red; exit 1 }

Write-Host "`nOK: $Rama esta ya en main y subido a GitHub." -ForegroundColor Green
