# Verificacion completa de CSN (sintaxis, tableros, reglas, datos y humo 3D)
# Uso:  powershell -ExecutionPolicy Bypass -File bench\VERIFICAR.ps1
# Deja el juego arrancado en http://127.0.0.1:8000/ si no lo estaba.

$ErrorActionPreference = "Continue"
Set-Location (Split-Path $PSScriptRoot -Parent)
Write-Host "== CSN · verificacion completa ==" -ForegroundColor Cyan

$fail = 0

Write-Host "`n[1/13] Sintaxis del script inline" -ForegroundColor Yellow
node bench/check-syntax.js
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n[2/13] Tableros (19, simetria 180 y solapes)" -ForegroundColor Yellow
$boards = node bench/boards.js 2>&1
$okBoards = ($boards | Select-String " ok " | Measure-Object).Count
$boards | Select-Object -Last 3
if ($okBoards -lt 19) { $fail++; Write-Host "  tableros ok: $okBoards (esperado 19)" -ForegroundColor Red }

Write-Host "`n[3/13] Reglas (motor)" -ForegroundColor Yellow
node bench/rules.test.js 2>&1 | Select-String "pass|fail"
if ($LASTEXITCODE -ne 0) { $fail++ }
node bench/combat.test.js 2>&1 | Select-String "pass|fail"
if ($LASTEXITCODE -ne 0) { $fail++ }
node bench/mobile.test.js 2>&1 | Select-String "pass|fail"
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n[4/13] Datos (personajes, naciones, skins, misiones, voces)" -ForegroundColor Yellow
node bench/data.test.js 2>&1 | Select-String "pass|fail"
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n[5/13] Winding y grip de mallas (node:test)" -ForegroundColor Yellow
node --test bench/winding.test.js 2>&1 | Select-String "pass|fail"
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n[6/13] Suite completa de tests (npm test)" -ForegroundColor Yellow
npm test 2>&1 | Select-String "pass|fail|tests "
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n[7/13] Rejillas IPA 1:1 y fisicas (node:test)" -ForegroundColor Yellow
node --test bench/map-collision.test.js 2>&1 | Select-String "pass|fail|tests "
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n[8/13] Capturas debugGrid de mapas IPA (headless)" -ForegroundColor Yellow
$alive = $false
try { $r = Invoke-WebRequest -Uri "http://127.0.0.1:8000/" -UseBasicParsing -TimeoutSec 4; $alive = ($r.StatusCode -eq 200) } catch { $alive = $false }
if (-not $alive) {
  Write-Host "  arrancando servidor local en 127.0.0.1:8000 ..." -ForegroundColor DarkYellow
  Start-Process -WindowStyle Hidden -FilePath node -ArgumentList "server.js"
  Start-Sleep -Seconds 2
}
$prevUrl = $env:CSN_URL
try {
  $env:CSN_URL = "http://127.0.0.1:8000/?debugGrid=1"
  foreach ($spec in @(@('skirmish', 'GRID03'), @('skirmish04', 'GRID04'), @('skirmish09', 'GRID09'), @('skirmish11', 'GRID11'))) {
    $gridMap = $spec[0]
    $gridPrefix = $spec[1]
    $gOut = & node _capture_all.mjs $gridMap $gridPrefix 12000 --2d 2>&1
    $gCode = $LASTEXITCODE
    if ($gCode -ne 0) { $fail++; Write-Host "  $gridMap : exit $gCode" -ForegroundColor Red; continue }
    try {
      $gLine = $gOut | Where-Object { "$_" -match "^\{" } | Select-Object -Last 1
      $g = "$gLine" | ConvertFrom-Json -ErrorAction Stop
      Write-Host ("  " + $gridMap + ": ok=" + $g.ok + " · " + $g.csn3d) -ForegroundColor DarkYellow
      if ($g.ok -ne $true) { $fail++; Write-Host "  $gridMap : ok=false · $($g.errores -join ' | ')" -ForegroundColor Red }
      elseif (@($g.errores).Count -gt 0) { $fail++; Write-Host "  $gridMap : errores JS · $($g.errores -join ' | ')" -ForegroundColor Red }
    } catch {
      $fail++
      Write-Host "  $gridMap : JSON no valido · $($_.Exception.Message)" -ForegroundColor Red
    }
  }
} finally {
  $env:CSN_URL = $prevUrl
}

Write-Host "`n[9/13] Humo 3D en navegador (headless)" -ForegroundColor Yellow
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

$vaOut = & node _capture_all.mjs viewer:audit-all VIEWAUDIT 8000 2>&1
$vaCode = $LASTEXITCODE
if ($vaCode -ne 0) { $fail++; Write-Host "  visor: exit $vaCode" -ForegroundColor Red }
try {
  $vaLine = $vaOut | Where-Object { "$_" -match "^\{" } | Select-Object -Last 1
  $va = "$vaLine" | ConvertFrom-Json -ErrorAction Stop
  Write-Host ("  visor: ok=" + $va.ok + " · modelos=" + @($va.viewerAudit.models).Count) -ForegroundColor DarkYellow
  if ($va.ok -ne $true) { $fail++; Write-Host "  visor: ok=false · $($va.errores -join ' | ')" -ForegroundColor Red }
} catch {
  $fail++
  Write-Host "  visor: JSON no valido · $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host "`n[10/13] Clips originales (40 contra el IPA historico)" -ForegroundColor Yellow
python tools/validar_clips.py
if ($LASTEXITCODE -ne 0) { $fail++ }

Write-Host "`n[11/13] Movimiento 3D y texturas (headless)" -ForegroundColor Yellow
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

Write-Host "`n[12/13] Combate 3D y eventos del clip (headless)" -ForegroundColor Yellow
$cbOut = & node _capture_all.mjs combat:skirmish COMBAT 8000 2>&1
$cbCode = $LASTEXITCODE
if ($cbCode -ne 0) { $fail++; Write-Host "  captura combate: exit $cbCode" -ForegroundColor Red }
try {
  $cbLine = $cbOut | Where-Object { "$_" -match "^\{" } | Select-Object -Last 1
  $cb = "$cbLine" | ConvertFrom-Json -ErrorAction Stop
  $cbEvents = if ($cb.combat -and $cb.combat.events) { $cb.combat.events.Count } else { 0 }
  Write-Host ("  eventos: " + $cbEvents + " · muestras: " + @($cb.combat.samples).Count) -ForegroundColor DarkYellow
  if ($cb.ok -ne $true) { $fail++; Write-Host "  combate: ok=false · $($cb.errores -join ' | ')" -ForegroundColor Red }
  elseif ($cbEvents -lt 1) { $fail++; Write-Host "  combate: sin eventos de clip" -ForegroundColor Red }
} catch {
  $fail++
  Write-Host "  combate: JSON no valido · $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host "`n[13/13] Movil y SwiftShader (headless)" -ForegroundColor Yellow
$mbOut = & node _capture_all.mjs mobile:sw:game MOBILE_SW 8000 2>&1
$mbCode = $LASTEXITCODE
if ($mbCode -ne 0) { $fail++; Write-Host "  captura movil: exit $mbCode" -ForegroundColor Red }
try {
  $mbLine = $mbOut | Where-Object { "$_" -match "^\{" } | Select-Object -Last 1
  $mb = "$mbLine" | ConvertFrom-Json -ErrorAction Stop
  $mbState = "$($mb.csn3d)" | ConvertFrom-Json -ErrorAction Stop
  Write-Host ("  viewport: " + $mb.mobile.w + "x" + $mb.mobile.h + " · fps: " + $mb.mobile.fps + " · sw: " + $mbState.sw) -ForegroundColor DarkYellow
  if ($mb.ok -ne $true) { $fail++; Write-Host "  movil: ok=false · $($mb.errores -join ' | ')" -ForegroundColor Red }
  elseif ($mbState.sw -ne $true) { $fail++; Write-Host "  movil: SwiftShader no activo" -ForegroundColor Red }
  elseif ([double]$mb.mobile.fps -lt 5) { $fail++; Write-Host "  movil: fps demasiado bajo ($($mb.mobile.fps))" -ForegroundColor Red }
} catch {
  $fail++
  Write-Host "  movil: JSON no valido · $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host "`n== RESULTADO ==" -ForegroundColor Cyan
if ($fail -eq 0) { Write-Host "TODO OK: sintaxis, 19 tableros, reglas, datos, winding, suite npm, rejillas IPA, capturas debugGrid, clips, humo 3D, auditoria del visor, movimiento, combate y movil/SwiftShader." -ForegroundColor Green }
else { Write-Host "FALLOS: $fail bloque(s). Revisa la salida de arriba." -ForegroundColor Red }
exit $fail
