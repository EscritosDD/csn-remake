# Capturas 3D de los mapas (base reconocible)

Capturas reales del juego en vista 3D (`_capture_all.mjs` con
`Page.bringToFront`), tomadas tras las fases F0-F9 y las rondas del plan
director. Los triangulos y llamadas salen de `window.__csn3d`.

| Mapa | id | Triangulos | Llamadas | Captura |
|---|---|---|---|---|
| Skirmish_03 - Londres | `skirmish03` | 78868 | 539 | [png](capturas/REAL_skirmish_3d.png) |
| Skirmish_05 - El deposito | `depot` | 64769 | 530 | [png](capturas/REAL_skirmish05_3d.png) |
| Skirmish_08 - La terminal | `terminal` | 80871 | 504 | [png](capturas/REAL_skirmish08_3d.png) |
| Skirmish_11 - El astillero | `astillero` | 73311 | 554 | [png](capturas/REAL_skirmish11_3d.png) |
| Skirmish_06 - Los andenes | `platform` | 70239 | 556 | [png](capturas/REAL_skirmish06_3d.png) |
| Skirmish_09 - La rotonda | `rotonda` | 72139 | 546 | [png](capturas/REAL_skirmish09_3d.png) |
| Skirmish_04 - El puente | `skirmish04` | 78088 | 544 | [png](capturas/R4_sk04_3d.png) |
| Skirmish_10 - El cruce | `cruce` | 71344 | 556 | [png](capturas/R5_skirmish10_3d.png) |
| Skirmish_01 - La plaza | `plaza` | 33488 | 567 | [png](capturas/R6_skirmish01_3d.png) |
| Skirmish_02 - El embarcadero | `dock` | 33392 | 564 | [png](capturas/R6_skirmish02_3d.png) |
| Skirmish_07 - El mercado | `market` | 33272 | 562 | [png](capturas/R6_skirmish07_3d.png) |

Notas:
- Los mapas de codigo (skirmish01/02/07) usan losas, por eso tienen menos
  triangulos que los mapas con geometria real del IPA (`geo:true`).
- Las capturas se han verificado con `units:8` (escuadras completas) y con
  `vistaClasica:"skip"`: son 3D, no la vista clasica.
- La vista 2D es una alternativa accesible y no se usa como verificacion.
