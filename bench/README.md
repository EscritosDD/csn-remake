# Banco ejecutable de CSN (`bench/`)

Herramientas que ejecutan el motor real del juego fuera del navegador, sin cambiar ningún número.

## Qué hay aquí

- `boards.js` — mide los 13 tableros con el BFS real (`pathDist`) sobre los `MAP_DEFS` de `index.html`: casillas libres conectadas, pasos a la baliza, ruta del dron, simetría 180° y solapes. **Resolvió la discrepancia del 16/11**: la página (L464) era correcta; la auditoría erró en 3 celdas.
- `harness.js` — **harness IA contra IA** sobre el motor real (carga el `<script>` inline en un contexto sin navegador y juega partidas con `startGame`/`aiUnitAct`/`endTurn`). Es el banco que la auditoría del 16/11 declaraba inexistente.
- `check-syntax.js` — comprueba que el JS incrustado de `index.html` parsea (0 errores).

## Uso

```
node bench/boards.js
node bench/check-syntax.js
node bench/harness.js <modo> <mapa> <partidas> <formato>
# modo: eliminacion | baliza | dominacion   (escolta aún no: IA asimétrica)
# mapa: almacen | patio | skirmish | skirmish04 | ...
```

## Primera medición de equilibrio (IA contra IA, 4v4)

| Modo | Almacén | Skirmish_03 | Patio |
|---|---|---|---|
| Eliminación | A 20 · B 0 | A 0 · B 15 | A 0 · B 15 |
| Baliza | A 6 · B 14 | A 4 · B 11 | A 7 · B 8 |
| Dominación | A 19 · B 0 · 1 empate | A 6 · B 9 | A 0 · B 13 · 2 empates |

### Lecturas

1. **El resultado es muy dependiente del mapa**, no de un "primer turno" universal: en Almacén domina A (excepto Baliza), en Skirmish_03 y Patio domina B. La ventaja de mover primero no es uniforme.
2. **La IA es casi determinista** (combate con semilla por turno + pocas decisiones con `Math.random()`): las partidas se repiten casi idénticas, así que esto mide *resultados casi fijos por mapa/escuadra*, no probabilidades. Para un equilibrio estadístico habría que añadir aleatoriedad a la IA o muestrear más mapas/escuadras.
3. **Correcciones de IA hechas para habilitar la medición**: la lógica de zonas de Dominación estaba hardcodeada para el bando B (`domControl(z)!=='B'`) y trataba la casilla de zona como objetivo de disparo (se paraba a distancia de tiro sin entrar). Ahora es agnóstica de bando y entra a ocupar la zona.
4. **Escolta (preliminar)**: ya hay una IA de escolta para el bando A (guiar el dron hacia la extracción, apartarse si bloquea el paso y defender). En IA-vs-IA la **defensa (B) gana sistemáticamente**: en Almacén el dron nace encajonado (caja al este en `2,5`, muro al norte en `1,4`, y sus dos salidas libres `0,5`/`1,6` ocupadas por los propios spawns), así que no avanza y B gana por agotar 15 rondas; en Patio el dron sí avanza pero la defensa lo destruye en 6–8 rondas antes de llegar. Queda la medición por rol (efectividad individual).

> Los ajustes de equilibrio (números de daño, costes, cobertura) **son decisión de Dani**; este banco solo mide.
