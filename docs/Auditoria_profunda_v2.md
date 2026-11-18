# Auditoría profunda v2 y plan exigente (ronda de corrección)

Auditoría hecha **mirando el juego de cerca** (capturas con cámara acercada a
una unidad, no solo el tablero entero) y con sondas instrumentadas
(`window.__csnCam`, escena THREE, esqueletos y materiales).

## Qué estaba mal (con evidencia)

### 1. Soldados: cuerpos invisibles y equipo flotando (CRÍTICO)
- Con la cámara a 3,4 unidades de una unidad se veían **solo las placas de
  equipo** (pecho, hombreras, antena) flotando sobre el anillo: la malla
  skinned **no se dibujaba**.
- Causa raíz: los **rigs por clase** extraídos del IPA conservan la
  convención de Unity (Y arriba) y sus huesos no reproducen el reposo que
  espera el **sistema de animación horneado** de CSN. Al aplicar los clips,
  el esqueleto se colapsaba y la malla se deformaba hasta desaparecer.
  Se probaron tres reconstrucciones (desde bind poses, solo huesos del skin,
  con y sin ancestros) y ninguna fue compatible con los clips: el cuerpo
  seguía roto.
- Segundo error, este sí decisivo: se aplicaba `ROLE_SCALES` (la escala de
  las mallas de clase, 0,31 para el Comando) a la **malla base**, dejando al
  soldado **diminuto** aunque el esqueleto estuviera bien.

**Solución aplicada** (`1fe168c`): volver a la **malla del IPA que ya
funcionaba** (Soldier_Light) para todas las clases y diferenciarlas con los
**uniformes del propio original** —`veteran`, `spetsnaz`, `deltaforce`,
`rambo`, `decon`, `deerhunter`, `base`—, escala única 0,95 y equipo
(pecho/franja/hombreras) reducido a proporción. Verificado con capturas de
cerca: el soldado se ve de pie, con casco, mochila, arma y uniforme.

### 2. Cámara: los mapas se veían pequeños (ALTO)
- La cámara arrancaba a **14,8** unidades de distancia y el zoom mínimo era
  9,5, así que el tablero ocupaba poco más de la mitad del encuadre.
- **Aplicado**: distancia por defecto **11,6**, zoom mínimo **7,5** y el
  botón de acercar permite llegar más cerca. El tablero ahora llena la vista.

### 3. Interfaz: disonante con el original (ALTO, pendiente)
- La portada usa arte de referencia (aistudio) que **no es del juego** y se
  nota: mezcla estilos y compite con el arte del RAD Soldiers.
- La **creación de partida** acumula selects y textos propios (dos escuadras
  enteras, skins, dificultad, mapas…) en una sola pantalla larga, sin la
  jerarquía del original.
- **Pendiente** (siguiente fase): portada y menú con la composición del
  original, flujo de partida en dos pasos (modo → escuadra) y HUD con la
  jerarquía del original.

### 4. Mapas (MEDIO)
- La geometría real y los props están bien; el problema de "se ven pequeños"
  era la cámara (punto 2). Queda revisar la escala de props sueltos y la
  densidad del anillo exterior.

## Plan exigente (fases siguientes)

| Fase | Objetivo | Criterio de aceptación |
|---|---|---|
| **A1** | Portada/menú con la composición del original y **fuera el arte de Muse/aistudio** | captura de portada; sin imágenes de referencia en la UI |
| **A2** | Creación de partida en dos pasos (modo → escuadra) con la estética del original | captura del flujo completo; sin scroll de más de 2 pantallas |
| **A3** | HUD con la jerarquía del original (retrato, vida, energía, acciones) | captura en partida; comparación lado a lado |
| **A4** | Soldados: revisar a distancia de juego que se leen (casco, uniforme, arma) | captura a 6 y a 3 unidades |
| **A5** | Reconstrucción de las mallas de clase con esqueletos compatibles (investigación) | captura de las 7 clases con el mismo pipeline de animación |
| **A6** | Repaso de props y escala por mapa | captura de los 13 tableros |

## Estado verificado de esta fase

- `VERIFICAR.ps1`: sintaxis 0, 19/19 tableros, reglas 6/6, datos 6/6, humo 3D.
- Capturas de cerca (`AUDIT_UNIT_role.png`) y de tablero (`AUD_FIX1_3d.png`).
- Commit `1fe168c` empujado a `main`.
