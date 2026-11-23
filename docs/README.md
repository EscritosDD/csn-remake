# Documentación de CSN

Índice único de documentación. Fuentes de verdad: `AGENTS.md`, `README.md`,
`docs/ARQUITECTURA.md` y este archivo. El resto es referencia o histórico.

## Estado vigente (2026-11-23)

- 79 módulos ESM en `src/`, 0 `<script>` inline, 2 tags module en `index.html`.
- `npm test`: 136 pruebas en verde; `VERIFICAR.ps1`: **TODO OK 13/13**.
- Módulos más largos: `src/viewer/card-stage.js` (449 líneas), `src/ui/ui-shell.js`
  (434), `src/viewer/main.js` (420), `src/data/maps.js` (360).
- Rediseño **Urban Tactical Arcade · Splatoon Pop** cerrado en seis sprints;
  detalle en [REDISENO_ARCADE_2026-11-23.md](REDISENO_ARCADE_2026-11-23.md).
- Modo Historia: `mnuChallenges` → `#campaignHub` →
  `showMissionBriefing()` → despliegue directo; tutorial de Dave con 6 pasos y
  radio/medallas/veterania persistidos.
- Configuración: `#setupMapPreview` y tarjetas de `src/ui/setup-preview.js`;
  `readSquad(team)` sigue leyendo los selects funcionales de cada tarjeta.
- Modo Competitivo: catálogo `.glb` en `assets/competitive/`, separado del IPA.

## Para seguir desarrollando

| Documento | Para qué |
|---|---|
| [ARQUITECTURA.md](ARQUITECTURA.md) | Módulos ESM reales, flujo de partida, visor 3D y trampas al editar |
| [REDISENO_ARCADE_2026-11-23.md](REDISENO_ARCADE_2026-11-23.md) | Informe ejecutivo de los seis sprints, gates y capturas del rediseño |
| [Equilibrio_medido.md](Equilibrio_medido.md) | Cifras de balance por modo y mapa, con n y metodología |
| [Catalogo_habilidades_original.md](Catalogo_habilidades_original.md) | Las 52 habilidades del original: 22 implementadas en CSN y el resto pendiente |
| [Capturas_3D.md](Capturas_3D.md) | Cómo regenerar capturas, rejilla de depuración, auditoría del visor y verificación móvil |

## Diseño y referencia

| Documento | Para qué |
|---|---|
| [Diseno_del_juego.md](Diseno_del_juego.md) | Reglas, modos, economía y estructura de partida |
| [Arsenal_real.md](Arsenal_real.md) | Las 37 armas con sus datos reales y su traducción al juego |
| [Estetica_original.md](Estetica_original.md) | Paletas y aspecto del original |
| [Arte_visual.md](Arte_visual.md) | Material en uso (mallas, mapas, audio, UI) y referencia histórica |
| [auditoria_global_3d.md](auditoria_global_3d.md) | Auditoría generada de todos los OBJ/rigs/texturas: 338 OBJ, 0 sin caras, 0 NaN, 24 rigs |

## Histórico (`historico/`)

Planes, informes y notas de sesiones anteriores. Se conservan como registro;
algunos describen estados que ya no existen. **No son la fuente de verdad**.

| Documento | Para qué |
|---|---|
| [ESTADO_SESION_2026-11-21.md](historico/ESTADO_SESION_2026-11-21.md) |Estado final de la última sesión con gates y archivos tocados |
| [Examen_para_continuar.md](historico/Examen_para_continuar.md) |Informe de traspaso con estado verificado, pendientes y recetas |
| [COMO_TRABAJAR_CON_ZAI.md](historico/COMO_TRABAJAR_CON_ZAI.md) |Flujo con rama de pruebas: aplicar patch, verlo, promoverlo o descartarlo |
| [Prompt_arranque_Z.ai.md](historico/Prompt_arranque_Z.ai.md) |Prompt histórico para retomar el trabajo con otra IA |
| [README_ENTREGA.md](historico/README_ENTREGA.md) |Entrega de modelos propios de Dani (Meshy AI) |
| [README_MODELOS_NUEVOS.md](historico/README_MODELOS_NUEVOS.md) |Guía histórica de los modelos nuevos |
| [Modelos_propios_Meshy.md](historico/Modelos_propios_Meshy.md) |Mapeo, pipeline y verificación de modelos Meshy |
| [Personajes_propios_Studio.md](historico/Personajes_propios_Studio.md) |Guía breve de personajes propios para Studio |
| [guia_rapida.md](historico/guia_rapida.md) |Comandos históricos del pipeline de modelos |
| [Auditoria_profunda_v2.md](historico/Auditoria_profunda_v2.md) |Fallos de la tanda de corrección y cómo se arreglaron |
| [Auditoria_visual_profunda_2026-11-19.md](historico/Auditoria_visual_profunda_2026-11-19.md) |Hallazgos visuales reproducibles e hipótesis separadas |
| [Informe_CSN_vs_original.md](historico/Informe_CSN_vs_original.md) |Comparación lado a lado con RAD Soldiers |
| [Auditoria_desarrollo_Gemini.md](historico/Auditoria_desarrollo_Gemini.md) |Auditoría del desarrollo con Gemini Studio (17/11/2026, 44 commits) |
| [Auditoria_independiente_DeepSeek.md](historico/Auditoria_independiente_DeepSeek.md) |Auditoría independiente con harness (DeepSeek) |
| [Desarrollo_continuo.md](historico/Desarrollo_continuo.md) |Prompt de trabajo autónomo y registro del desarrollo continuo |
| [Equilibrio_medido.md](historico/Equilibrio_medido.md) |Balance medido con harness IA-vs-IA en un motor ya sustituido; cifras no reproducibles con el harness actual |
| [Estetica_original.md](historico/Estetica_original.md) |Auditoría visual de la estética del RAD Soldiers original |
| [Informe_cierre_objetivo.md](historico/Informe_cierre_objetivo.md) |Informe de cierre del objetivo (rondas 1–43) del plan director |
| [Informe_sesion_y_plan_Muse.md](historico/Informe_sesion_y_plan_Muse.md) |Informe de sesión y plan de arte completo |
| [Plan_de_operacion.md](historico/Plan_de_operacion.md) |Plan de operación del remake |
| [Plan_director_original_base.md](historico/Plan_director_original_base.md) |Plan director: el original como base reconocible |
| [Plan_seguimiento.md](historico/Plan_seguimiento.md) |Seguimiento del plan de trabajo (tabla de fases) |
| [Plan_trabajo_pendiente.md](historico/Plan_trabajo_pendiente.md) |Plan de trabajo pendiente tras la auditoría de Gemini Studio |
| [Prompt_Argon_sprites.md](historico/Prompt_Argon_sprites.md) |Prompts para Gemini Argon (arte SVG; herramienta retirada) |
| [Referencia_original.md](historico/Referencia_original.md) |Referencia del original (la carpeta `referencia_original/` ya no existe) |
| [Resumen_desarrollo_noche.md](historico/Resumen_desarrollo_noche.md) |Resumen del desarrollo nocturno (fases F0–F9) |
| [Vacios_y_Argon.md](historico/Vacios_y_Argon.md) |Vacíos del original y qué se le pedía a Argon |

`docs/capturas/` contiene capturas locales generadas por `_capture_all.mjs`;
está ignorado por Git.
