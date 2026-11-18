# Arquitectura de CSN (para quien siga el proyecto)

Todo el juego vive en **`index.html`** (un solo archivo, ~7.000 lineas de
script inline) mas la carpeta `assets/`. Three.js r158 esta vendorizado en
`assets/three.min.js`. No hay build: se sirve con cualquier servidor de
estaticos (`python -m http.server 8000`) y se abre en el navegador.

## Datos (bloques `const`)

| Bloque | Linea | Contenido |
|---|---|---|
| `MAP_DEFS` | 1292 |
| `WEAPONS` | 815 |
| `ROLES` | 877 |
| `CHARACTERS` | 864 |
| `OWN_CAST` | 6932 |
| `ORIG_CAST` | 6960 |
| `NATIONS` | 778 |
| `SKINS` | 808 |
| `CAMPAIGN_MISSIONS` | 956 |
| `DEFAULT_SQUADS` | 887 |
| `BODIES` | 856 |
| `DOM_ZONES` | 934 |
| `ESCORT_START` | 951 |
| `ESCORT_EXT` | 952 |
| `ROLE_MODEL_FILES` | 4731 |
| `CHAR_VOICE` | 1997 |
| `MUSIC_TRACKS` | 2017 |
| `WEAPON_SFX` | 1994 |
| `LS_CHARS` | 6927 |

## Motor (funciones clave)

| Funcion | Linea |
|---|---|
| `startGame()` | 1727 |
| `endTurn()` | 2581 |
| `tryShoot()` | 1815 |
| `damage()` | 1781 |
| `hitChance()` | 1681 |
| `hasLOS()` | 1651 |
| `coverLevel()` | 1659 |
| `isFlanked()` | 1674 |
| `aiUnitAct()` | 2652 |
| `endGame()` | 2528 |
| `updateUI()` | 3401 |
| `draw()` | 3704 |
| `build3DWorld()` | 5952 |
| `makeRealSoldier3()` | 4993 |
| `makeSoldier3()` | 4560 |
| `makeGunProp3()` | 4882 |
| `buildThemedProps3()` | 5768 |
| `renderBarracks()` | 7061 |
| `renderAbilityCatalog()` | 7052 |
| `renderCampaignPanel()` | 1073 |
| `openSetup()` | 1103 |
| `squadRows()` | 1154 |
| `loadRealSoldier()` | 4732 |
| `auVoice()` | 2006 |
| `auMusicStart()` | 2019 |
| `quickStart()` | 6913 |
| `deployTurret()` | 2428 |
| `fireArtillery()` | 2149 |
| `fireOrbital()` | 2079 |
| `throwGrenade()` | 1949 |
| `placeMine()` | 2250 |
| `setOverwatch()` | 1892 |
| `guideDrone()` | 2332 |

## Flujo de una partida

1. `openSetup(mode)` prepara `setup` y pinta la configuracion.
2. `squadRows` / `readSquad` construyen las escuadras por hueco (rol + arma).
3. `startGame(squadA, squadB)` crea `G` (unidades, mapa, zonas, estadisticas)
   y arranca el ambiente y la musica del original.
4. `updateUI` pinta HUD y tarjeta; `draw` pinta la vista clasica; en 3D,
   `build3DWorld` + `__render3D` construyen y animan la escena.
5. `tryShoot` / `damage` resuelven el combate (con `hitChance`, `coverLevel`,
   `hasLOS`); `endTurn` cierra el turno, dispara torretas y pasa a la IA
   (`aiUnitAct`).
6. `endGame` decide el ganador y pinta resultados + monedas.

## Escena 3D

- `build3DWorld` monta tablero, props del tema (`buildThemedProps3`),
  unidades (`makeRealSoldier3` con el modelo de su clase del IPA) y utileria
  (armas con `makeGunProp3`).
- Los modelos de clase estan en `assets/soldier/<Clase>.obj` + `_rig.json` +
  `_tex.png`, con escala en `assets/soldier_scales.json`.
- La vista 3D es la principal; la 2D es alternativa.

## Verificacion (usar siempre)

```
powershell -ExecutionPolicy Bypass -File bench\VERIFICAR.ps1
```

Sintaxis (0 errores), 13 tableros (simetria y solapes), `rules.test.js`
(6/6), `data.test.js` (6/6) y humo 3D en navegador. El balance se mide con
`bench/harness.js <modo> <mapa> <partidas> <formato>` y las capturas con
`_capture_all.mjs`.

## Reglas de edicion que han costado errores

1. **Anclas unicas**: muchos fragmentos se repiten (dos `army`/`squad`,
   varios `</style>`, `if(theme===...)`). Comprobar `s.count(old)==1` antes
   de reemplazar.
2. **Bloques de props**: todo `if(theme===...){` insertado debe cerrarse
   antes de la linea original. Si no, "Unexpected end of input".
3. **`byName` en el rig** se define despues del `bind`; no usar antes.
4. **Escala por clase**: los modelos del IPA vienen en unidades distintas.
5. Tras cada cambio: `node bench/check-syntax.js` y la bateria completa.
