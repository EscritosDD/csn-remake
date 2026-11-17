# Equilibrio medido (17 nov 2026)

Motor real, harness IA-vs-IA, formato 4v4, dificultad normal. Cada partida
juega ambos bandos con la misma IA. Mapas: Almacén y Patio (de código) y
Skirmish_03/05/08 (geometría real del IPA).

## Tabla por modo y mapa

| Modo · mapa | Partidas | A | B | Sesgo | Rondas medias |
|---|---|---|---|---|---|
| Dominación · Almacén | 40 | 17 | 23 | 57 % B | 11,3 |
| Dominación · Skirmish_03 | 40 | 13 | 27 | **67 % B** | 9,1 |
| Dominación · Skirmish_05 | 20 | 11 | 9 | 55 % A | 11,5 |
| Dominación · Skirmish_08 | 20 | 4 | 16 | **80 % B** | 10,3 |
| Eliminación · Almacén | 10 | 10 | 0 | **100 % A** | 10,4 |
| Eliminación · Skirmish_03 | 10 | 8 | 2 | **80 % A** | 7,8 |
| Eliminación · Skirmish_05 | 10 | 2 | 8 | **80 % B** | 11,0 |
| Eliminación · Skirmish_08 | 10 | 3 | 7 | 70 % B | 9,9 |
| Baliza · Almacén | 10 | 3 | 7 | 70 % B | 15,4 |
| Baliza · Skirmish_03 | 10 | 3 | 7 | 70 % B | 12,3 |
| Baliza · Skirmish_05 | 10 | 6 | 4 | 60 % A | 11,9 |
| Baliza · Skirmish_08 | 10 | 8 | 2 | **80 % A** | 9,6 |
| Escolta · Almacén | 20 | 14 | 6 | 70 % A | 4,7 |
| Escolta · Skirmish_03 | 10 | 7 | 3 | 70 % A | 5,9 |

Lectura: **el sesgo cambia con el mapa**, no con el modo. Dominación ya no
está rota por el orden de turno (de 20-0 a 57-67 % en Almacén y S03); lo
que queda es disposición por mapa. Eliminación en Almacén sale 10-0 con
solo 10 partidas (antes había dado 6-4 y 8-2): hace falta ampliar la
muestra antes de tocar nada.

## Efectividad por rol (agregado de la matriz)

Media de daño por acción (dmg total / acciones), por bando:

| Rol | Rango de media | Notas |
|---|---|---|
| Francotirador | **24–73** | El rol dominante con diferencia: kill-rate alto y daño por acción máximo en todos los mapas |
| Comando | 12–39 | Segundo; el fogonazo M84 marca la diferencia cuando hay varios enemigos |
| Ingeniero | 3,7–48 | Muy variable: brilla con torreta/claymore, flojo cuando no despliega |
| Artillero | (ver A:Comando) | — |
| Médico | 5–27 | Daño bajo por diseño; su aporte es curación (no medida en daño) |

Conclusión: el **Francotirador está por encima del resto** (hasta ×3 en
daño por acción). No se toca el daño base: primero se ajustará la
disposición por mapa (salidas/baliza/cobertura) y se volverá a medir.

## Cambios aplicados hasta ahora (con medición)

1. **Escolta** (F1): mecánica de escolta que acompaña al dron, guiado en
   cadena, blindaje ×0,47 y 240 PV. De 0-20 (defensa siempre gana) a
   A 14-6 en Almacén y 7-3 en S03.

## Pendiente de F2

1. Ampliar Eliminación · Almacén a 40 partidas (el 10-0 pide muestra).
2. Diagnóstico de Dominación en S03 y S08 (¿salidas? ¿cobertura de las
   zonas? ¿orden de zonas de la IA?) y ajuste de disposición sin tocar
   daños ni vidas.
3. Repetir la matriz tras los ajustes y actualizar esta tabla.

## Nota sobre el harness

`bench/harness.js` acepta ahora:
- 6º argumento `log`: imprime las líneas de registro del dron.
- 6º/7º argumento `roles`: informe de daño/kills/acciones por rol.
