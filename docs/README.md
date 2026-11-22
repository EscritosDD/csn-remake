# Documentación de CSN

Índice único de documentación. Fuentes de verdad: `AGENTS.md`, `README.md`,
`docs/ARQUITECTURA.md` y este archivo. El resto es referencia o histórico.

## Para seguir desarrollando

| Documento | Para qué |
|---|---|
| [ARQUITECTURA.md](ARQUITECTURA.md) | Módulos ESM reales, flujo de partida, visor 3D y trampas al editar |
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
| [auditoria_global_3d.md](auditoria_global_3d.md) | Auditoría generada de todos los OBJ/rigs/texturas: 338 OBJ, 0 sin caras, 0 NaN, 13 rigs |

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

`docs/capturas/` contiene capturas locales generadas por `_capture_all.mjs`;
está ignorado por Git.
