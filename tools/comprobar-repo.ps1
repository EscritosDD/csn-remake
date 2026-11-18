# Comprueba en 2 segundos si el repo esta sano y sincronizado con GitHub.
# Uso: powershell -ExecutionPolicy Bypass -File tools\comprobar-repo.ps1
$ErrorActionPreference = "Continue"
$repo = Split-Path -Parent $PSScriptRoot
Set-Location $repo
$env:GIT_SSH_COMMAND = "ssh -i `"D:\Juegos\CSN\hermes_deploy_key`" -o IdentitiesOnly=yes -o StrictHostKeyChecking=accept-new"

Write-Host "== CSN · comprobacion del repositorio ==" -ForegroundColor Cyan

$rama = (git rev-parse --abbrev-ref HEAD).Trim()
$head = (git rev-parse --short HEAD).Trim()
Write-Host "Rama actual : $rama"
Write-Host "HEAD local  : $head"

git fetch origin --quiet 2>$null
$originMain = (git rev-parse --short origin/main).Trim()
Write-Host "origin/main : $originMain"

$pendientes = git status --porcelain
if ($pendientes) {
  Write-Host "Cambios sin commitear: $($pendientes.Count)" -ForegroundColor Yellow
  $pendientes | Select-Object -First 10 | ForEach-Object { "   $_" }
} else {
  Write-Host "Cambios sin commitear: 0" -ForegroundColor Green
}

if ($rama -eq "main") {
  if ($head -eq $originMain) { Write-Host "main local == main remoto  -> OK" -ForegroundColor Green }
  else {
    $adelante = git log "origin/main..HEAD" --oneline
    $detras   = git log "HEAD..origin/main" --oneline
    Write-Host "main local y remoto NO coinciden:" -ForegroundColor Red
    if ($adelante) { Write-Host "  sin subir:" -ForegroundColor Yellow; $adelante | ForEach-Object { "   $_" } }
    if ($detras)   { Write-Host "  sin bajar:" -ForegroundColor Yellow; $detras   | ForEach-Object { "   $_" } }
  }
} else {
  Write-Host "Estas en una rama de trabajo (no en main). Comparando con main:" -ForegroundColor Yellow
  $diff = git log "main..$rama" --oneline
  if ($diff) { Write-Host "  commits por delante de main:" -ForegroundColor Yellow; $diff | ForEach-Object { "   $_" } }
  else { Write-Host "  sin cambios respecto a main" }
}

Write-Host "`n-- ficheros criticos (local vs GitHub) --"
foreach ($f in @("index.html","assets/soldier.obj","assets/soldier_rig.json","assets/weapons/AssaultRifle.obj","assets/soldier_clips.json","docs/Examen_para_continuar.md")) {
  if (-not (Test-Path $f)) { "{0,-42} NO EXISTE EN LOCAL" -f $f; continue }
  $loc = (git hash-object -- $f)
  $rem = (git rev-parse "origin/main:$f" 2>$null)
  "{0,-42} {1}" -f $f, $(if ($loc -eq $rem) { "IGUAL" } else { "DISTINTO" })
}

Write-Host "`nTotal versionado: $((git ls-files | Measure-Object).Count) ficheros" -ForegroundColor Cyan
