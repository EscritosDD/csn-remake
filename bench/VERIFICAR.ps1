# Verificacion completa de CSN (sintaxis, tableros, reglas, datos y humo 3D)
# Uso:  powershell -ExecutionPolicy Bypass -File bench\VERIFICAR.ps1
# Deja el juego arrancado en http://127.0.0.1:8000/ si no lo estaba.

$ErrorActionPreference = "Continue"
Set-Location (Split-Path $PSScriptRoot -Parent)
Write-Host "== CSN · verificacion completa ==" -ForegroundColor Cyan

$fail = 0

Write-Host "`n[1/5] Sintaxis del script inline" -ForegroundColor Yellow
node bench/check-syntax.js
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n[2/5] Tableros (13, simetria 180 y solapes)" -ForegroundColor Yellow
$boards = node bench/boards.js 2>&1
$okBoards = ($boards | Select-String " ok " | Measure-Object).Count
$boards | Select-Object -Last 3
if ($okBoards -lt 13) { $fail++; Write-Host "  tableros ok: $okBoards (esperado 13)" -ForegroundColor Red }

Write-Host "`n[3/5] Reglas (motor)" -ForegroundColor Yellow
node bench/rules.test.js 2>&1 | Select-String "pass|fail"
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n[4/5] Datos (personajes, naciones, skins, misiones, voces)" -ForegroundColor Yellow
node bench/data.test.js 2>&1 | Select-String "pass|fail"
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n[5/5] Humo 3D en navegador (headless)" -ForegroundColor Yellow
$alive = $false
try { $r = Invoke-WebRequest -Uri "http://127.0.0.1:8000/" -UseBasicParsing -TimeoutSec 4; $alive = ($r.StatusCode -eq 200) } catch { $alive = $false }
if (-not $alive) {
  Write-Host "  arrancando servidor local en 127.0.0.1:8000 ..." -ForegroundColor DarkYellow
  Start-Process -WindowStyle Hidden python -ArgumentList "-m","http.server","8000","--bind","127.0.0.1"
  Start-Sleep -Seconds 2
}
node _capture_all.mjs skirmish05 VERIF 12000
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n== RESULTADO ==" -ForegroundColor Cyan
if ($fail -eq 0) { Write-Host "TODO OK: sintaxis, tableros, reglas, datos y humo 3D." -ForegroundColor Green }
else { Write-Host "FALLOS: $fail bloque(s). Revisa la salida de arriba." -ForegroundColor Red }
exit $fail
