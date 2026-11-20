# Verificacion completa de CSN (sintaxis, tableros, reglas, datos y humo 3D)
# Uso:  powershell -ExecutionPolicy Bypass -File bench\VERIFICAR.ps1
# Deja el juego arrancado en http://127.0.0.1:8000/ si no lo estaba.

$ErrorActionPreference = "Continue"
Set-Location (Split-Path $PSScriptRoot -Parent)
Write-Host "== CSN · verificacion completa ==" -ForegroundColor Cyan

$fail = 0

Write-Host "`n[1/6] Sintaxis del script inline" -ForegroundColor Yellow
node bench/check-syntax.js
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n[2/6] Tableros (19, simetria 180 y solapes)" -ForegroundColor Yellow
$boards = node bench/boards.js 2>&1
$okBoards = ($boards | Select-String " ok " | Measure-Object).Count
$boards | Select-Object -Last 3
if ($okBoards -lt 19) { $fail++; Write-Host "  tableros ok: $okBoards (esperado 19)" -ForegroundColor Red }

Write-Host "`n[3/6] Reglas (motor)" -ForegroundColor Yellow
node bench/rules.test.js 2>&1 | Select-String "pass|fail"
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n[4/6] Datos (personajes, naciones, skins, misiones, voces)" -ForegroundColor Yellow
node bench/data.test.js 2>&1 | Select-String "pass|fail"
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n[5/6] Humo 3D en navegador (headless)" -ForegroundColor Yellow
$alive = $false
try { $r = Invoke-WebRequest -Uri "http://127.0.0.1:8000/" -UseBasicParsing -TimeoutSec 4; $alive = ($r.StatusCode -eq 200) } catch { $alive = $false }
if (-not $alive) {
  Write-Host "  arrancando servidor local en 127.0.0.1:8000 ..." -ForegroundColor DarkYellow
  Start-Process -WindowStyle Hidden -FilePath node -ArgumentList "server.js"
  Start-Sleep -Seconds 2
}
$capOut = & node _capture_all.mjs skirmish05 VERIF 12000 2>&1
$capCode = $LASTEXITCODE
if ($capCode -ne 0) { $fail++; Write-Host "  captura: exit $capCode" -ForegroundColor Red }
try {
  $capLine = $capOut | Where-Object { "$_" -match "^\{" } | Select-Object -Last 1
  $cap = "$capLine" | ConvertFrom-Json -ErrorAction Stop
  Write-Host ("  csn3d: " + $cap.csn3d) -ForegroundColor DarkYellow
  if ($cap.ok -ne $true) { $fail++; Write-Host "  captura: ok=false · $($cap.errores -join ' | ')" -ForegroundColor Red }
  elseif ($cap.errores.Count -gt 0) { $fail++; Write-Host "  captura con errores JS: $($cap.errores -join ' | ')" -ForegroundColor Red }
} catch {
  $fail++
  Write-Host "  captura: JSON no valido · $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host "`n[6/6] Movimiento 3D y texturas (headless)" -ForegroundColor Yellow
$mvOut = & node _capture_all.mjs move:skirmish MOVE 8000 2>&1
$mvCode = $LASTEXITCODE
if ($mvCode -ne 0) { $fail++; Write-Host "  captura movimiento: exit $mvCode" -ForegroundColor Red }
try {
  $mvLine = $mvOut | Where-Object { "$_" -match "^\{" } | Select-Object -Last 1
  $mv = "$mvLine" | ConvertFrom-Json -ErrorAction Stop
  $mvSamples = if ($mv.move -and $mv.move.samples) { $mv.move.samples.Count } else { 0 }
  Write-Host ("  muestras: " + $mvSamples + " · texturas: " + @($mv.tex).Count) -ForegroundColor DarkYellow
  if ($mv.ok -ne $true) { $fail++; Write-Host "  movimiento: ok=false · $($mv.errores -join ' | ')" -ForegroundColor Red }
  elseif ($mvSamples -lt 30) { $fail++; Write-Host "  movimiento: solo $mvSamples muestras" -ForegroundColor Red }
  elseif (@($mv.tex | Where-Object { $_.mip -eq $false -and $_.cs -eq 'srgb' }).Count -lt 1) { $fail++; Write-Host "  texturas: estado inesperado" -ForegroundColor Red }
} catch {
  $fail++
  Write-Host "  movimiento: JSON no valido · $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host "`n== RESULTADO ==" -ForegroundColor Cyan
if ($fail -eq 0) { Write-Host "TODO OK: sintaxis, 19 tableros, reglas, datos, humo 3D y movimiento." -ForegroundColor Green }
else { Write-Host "FALLOS: $fail bloque(s). Revisa la salida de arriba." -ForegroundColor Red }
exit $fail
