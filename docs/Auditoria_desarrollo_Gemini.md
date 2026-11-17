# Auditoría del desarrollo con Gemini Studio (17 nov 2026)

Rango auditado: `66b2cea..b93c324` (44 commits, 1.665 archivos, +180.393 líneas).
Método: pull del remoto, lectura de diffs, suite de pruebas, harness
IA-vs-IA (partidas reales), benchmark de tableros y prueba de humo en
navegador headless con el estado interno del render.

---

## 1. Resumen ejecutivo

**Lo entregado es sólido en lo técnico** (el juego carga, no hay errores JS,
la suite de pruebas pasa y el arreglo de Dominación se midió). El juego se
mantuvo jugable; el índice bajó de ~8 MB a 434 KB al sacar los blobs a
`assets/`. **Lo que falta es sobre todo lo de la segunda mitad del encargo**
(personajes diferenciados, skins por nación, diseño de armas, interfaz
minimalista) y el informe escrito. La Escolta sigue rota y el arte de
botones quedó generado pero sin usar.

## 2. Inventario de lo nuevo

- `referencia_original/decompiled/` — 1.578 `.cs` del original (7,1 MB en
  total con `datos/`). Texto, no binarios: correcto.
- `assets/ui/` — 7 retratos de rol, 12 insignias de nación, 4 de modo,
  3 botones, panel, logo y favicon.
- `assets/three.min.js` y `assets/argon-soldiers.svg` — extraídos del HTML.
- `public/assets/aistudio/` — 3 imágenes (huérfanas, ver 4.2).
- `bench/rules.test.js` — suite nueva (6 pruebas).
- `server.js`, `package.json`, `package-lock.json` — para Gemini Studio.
- `index.html` — reescritura grande: HUD 3D, retratos, personalidad por rol,
  deshacer, habilidades, cielos/nieblas por mapa, texturas procedurales.

## 3. Verificado funcionando (con números)

### 3.1 Dominación — el arreglo funciona y se midió

Cambio leído en el diff: la puntuación ya **no se da al cerrar la ronda**
sino **al iniciar el turno de cada bando** (desde la ronda 2), y la
victoria espera al cierre completo de ronda (`_domRoundDone`). Turreta
desactivada en Dominación y capturable solo desde la ronda 2.

| Medición | Antes (informe del encargo) | Después (esta auditoría, 10 partidas/mapa) |
|---|---|---|
| Dominación · Almacén | 20-0 para A | **A 4 · B 6** |
| Dominación · Skirmish_03 | 20-0 para A | **A 3 · B 7** |

Veredicto: **la ventaja de mover primero está eliminada** (era 20-0). Ahora
hay un ligero sesgo hacia B en los dos mapas (7-3 y 6-4), dentro del ruido
de 10 partidas pero con la misma dirección en ambos; con 30-40 partidas se
puede confirmar si es real.

### 3.2 Resto de modos (10 partidas por combinación)

| Modo · mapa | Antes | Ahora |
|---|---|---|
| Eliminación · Almacén | A 8-2 | **A 6 · B 4** |
| Baliza · Almacén | B 8-2 | **A 5 · B 5** |
| Escolta · Almacén | defensa siempre gana | **B 4-0** (dron nunca entregado) |

Baliza queda equilibrada. Eliminación mejora pero A sigue ligeramente
arriba. **Escolta sigue rota**: en las 4 partidas el dron quedó en (4-5,5)
y murió; el cambio de "−50 % de daño con escolta pegado" no arregla la
entrega.

### 3.3 Calidad técnica

- **Sintaxis del script inline: 0 errores.**
- **Suite nueva `bench/rules.test.js`: 6/6 en verde** (cobertura
  direccional, humo, aturdidora, claymore, Dominación, Escolta).
- **13 tableros**: simétricos y alcanzables (benchmark `boards.js` OK).
- **Prueba de humo en navegador**: el juego carga, entra en partida,
  `__csn3d = {theme:skirmish03, geo:true, units:8, tris:73.128, calls:442}`
  y **0 excepciones JS**.
- Arte UI cargado en la portada: **14 retratos**, 4 insignias de modo,
  **12 de nación**, logo y botón de deshacer presentes.

## 4. Lo que NO está entregado o está roto

### 4.1 El informe escrito (encargo punto 3) — NO ENTREGADO
No existe ningún archivo nuevo en `docs/` con el informe CSN-contra-original
(punto por punto, tres columnas, con fuentes). El único documento nuevo es
la suite de pruebas.

### 4.2 Las 3 imágenes de aistudio — HUÉRFANAS
`public/assets/aistudio/image_13b112b1.png`, `image_26054cf1.png`,
`image_5061c313.png` existen, pero **ninguna está referenciada en
`index.html`** (0 coincidencias). El encargo pedía integrarlas o explicar
para qué son. Decisión pendiente.

### 4.3 Botones y panel PNG — generados, sin usar
`ui_boton_primario/secundario/peligro.png` y `ui_panel.png` están en
`assets/ui/` pero **no se referencian** (0 coincidencias de `ui_boton`). Se
mantuvo el CSS. El encargo pedía decidir y decirlo: queda sin decidir.

### 4.4 Escolta — sigue rota
La defensa gana siempre y el dron no llega nunca a la extracción (4/4
partidas, dron muerto en (4-5,5)). Ni la medición de rol ni el arreglo de
la entrega están hechos.

### 4.5 Personajes, skins y armas — no empezado
La parte final del encargo (diferenciación visual de personalidades,
atuendos por nación, coloración de skins, diseños de armas nuevos, y la
interfaz minimalista cartoon) **no tiene commits**. Lo que hay es
"personalidad por rol" en animación/apariencia simple y los 7 retratos.

### 4.6 Interfaz — integración parcial
- Retratos: sí (14 en portada).
- Insignias de modo y nación: sí (4 y 12).
- `map_min_*.png` (miniaturas de mapa): **no usadas**.
- Pantalla de carga: **no existe**.
- Botones PNG: no usados (ver 4.3).

### 4.7 Reglas del encargo incumplidas
- **`bench/` fue tocado**: se añadió `bench/rules.test.js`. El encargo
  decía expresamente "No toques bench/ ni docs/". (El test en sí es bueno;
  el sitio no era ese.)
- El resto de reglas se cumplen: no hay binarios grandes nuevos (7,1 MB de
  `.cs` de texto), los 13 tableros siguen bien y el juego no se rompe.

## 5. Puntos de equilibrio a vigilar

| Punto | Estado | Acción sugerida |
|---|---|---|
| Dominación sesgo a B (7-3 / 6-4) | Posible | Repetir con 40 partidas; si persiste, revisar orden de puntuación/zonas por mapa |
| Eliminación A 6-4 | Leve | Medir S05 y S08 (el encargo citaba S05 3-7 B y S08 7-3 A) |
| Baliza A 5-5 | Bien | Confirmar en S08 |
| Escolta | Rota | Arreglar la entrega del dron antes de medir roles |
| Rol más efectivo | Sin medir | Ampliar el harness con informe por rol |

## 6. Prioridades recomendadas (tras esta auditoría)

1. **Escolta**: que el dron pueda entregarse (el harness lo mide; en 4/4
   muere antes). Es el agujero funcional más grande.
2. **Informe CSN-contra-original** con fuentes (el encargo punto 3).
3. **Decidir el arte de UI**: usar los PNG de botones/panel o rehacerlos;
   y dar destino a las 3 imágenes de aistudio.
4. **Equilibrio**: 40 partidas de Dominación para confirmar el sesgo a B;
   medir Eliminación/Baliza en S05 y S08; añadir medición por rol.
5. **Personajes/skins/armas/UI minimalista**: la segunda mitad del encargo,
   sin empezar. Ahí sí hace falta la dirección de arte de la Parte 2 del
   documento anterior (Muse).
