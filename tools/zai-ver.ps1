# Levanta el servidor local y abre el juego para ver la rama de pruebas.
# Uso: powershell -ExecutionPolicy Bypass -File tools\zai-ver.ps1 [-Rama zai/pruebas] [-Puerto 8000]
param(
  [string]$Rama = "zai/pruebas",
  [int]$Puerto = 8000
)
$ErrorActionPreference = "Stop"
$repo = Split-Path -Parent $PSScriptRoot
Set-Location $repo

$actual = (git rev-parse --abbrev-ref HEAD).Trim()
if ($actual -ne $Rama) {
  Write-Host "Estas en '$actual'. Cambiando a '$Rama'..." -ForegroundColor Yellow
  git checkout $Rama
  if ($LASTEXITCODE -ne 0) { Write-Host "No pude cambiar de rama." -ForegroundColor Red; exit 1 }
}

Write-Host "Rama: $Rama" -ForegroundColor Cyan
git log --oneline -3 | Out-String | Write-Host
Write-Host "Abriendo http://127.0.0.1:$Puerto/  (Ctrl+C para parar el servidor)" -ForegroundColor Green
Start-Process "http://127.0.0.1:$Puerto/"
try {
  python -m http.server $Puerto --bind 127.0.0.1
} catch {
  py -m http.server $Puerto --bind 127.0.0.1
}
