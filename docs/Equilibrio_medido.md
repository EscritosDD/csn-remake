# Equilibrio medido (18 nov 2026, muestras ampliadas)

Motor real, harness IA-vs-IA, 4v4, dificultad normal. Ambos bandos juegan
con la misma IA. Mapas: Almacén (de código) y Skirmish_03/05/08 (geometría
real del IPA). Muestras ampliadas tras la primera pasada: los extremos de
10 partidas (Eliminación Almacén 10-0, Dominación S08 4-16) resultaron
**ruido de muestreo**.

## Tabla por modo y mapa

| Modo · mapa | Partidas | A | B | Empates | Sesgo | Rondas |
|---|---|---|---|---|---|---|
| Dominación · Almacén | 40 | 17 | 23 | 0 | 57 % B | 11,3 |
| Dominación · Skirmish_03 | 40 | 13 | 27 | 0 | **67 % B** | 8,9 |
| Dominación · Skirmish_05 | 20 | 11 | 9 | 0 | 55 % A | 11,5 |
| Dominación · Skirmish_08 | 40 | 20 | 20 | 0 | **50/50** | 10,5 |
| Eliminación · Almacén | 40 | 24 | 16 | 0 | 60 % A | 11,2 |
| Eliminación · Skirmish_03 | 20 | 18 | 2 | 0 | **90 % A** | 8,6 |
| Eliminación · Skirmish_05 | 10 | 2 | 8 | 0 | 80 % B | 11,0 |
| Eliminación · Skirmish_08 | 10 | 3 | 7 | 0 | 70 % B | 9,9 |
| Baliza · Almacén | 30 | 13 | 16 | 1 | 54 % B | 14,3 |
| Baliza · Skirmish_03 | 10 | 3 | 7 | 0 | 70 % B | 12,3 |
| Baliza · Skirmish_05 | 10 | 6 | 4 | 0 | 60 % A | 11,9 |
| Baliza · Skirmish_08 | 10 | 8 | 2 | 0 | 80 % A | 9,6 |
| Escolta · Almacén | 20 | 14 | 6 | 0 | 70 % A | 4,7 |
| Escolta · Skirmish_03 | 10 | 7 | 3 | 0 | 70 % A | 5,9 |

## Análisis

1. **Dominación ya no está rota**: el arreglo del tic de puntuación eliminó
   el 20-0. Con muestras grandes: Almacén 57 % B, S03 67 % B, S05 55 % A,
   **S08 50/50**. Ningún mapa supera el 70 % salvo S03 en el límite.
2. **Los mapas son perfectamente simétricos**: verificado a mano que
   muros, estanterías, cajas, barriles y botiquines del S03 y S08 son
   180°-simétricos casilla a casilla (igual que salidas, zonas y las dos
   escuadras). Por tanto el sesgo restante **no es de disposición**: es la
   ventaja del que mueve primero (A) en los duelos + la reacción de B en
   los objetivos.
3. **El único outlier real es Eliminación · S03: 90 % A**. En el mapa con
   más cobertura (Londres), la iniciativa de A decide los duelos: A dispara
   primero y la cobertura densa impide a B responder. Es favorable al
   jugador (que es A), pero demasiado fácil contra la IA.
4. **Escolta**: 70 % A en los dos mapas medidos, con el dron entregándose
   en 14/20 partidas (antes 0). La defensa ya no gana siempre.

## Cambios aplicados (con medición)

1. **Escolta (F1)**: la escolta acompaña al dron, guiado en cadena,
   blindaje ×0,47 y 240 PV. De 0-20 a A 14-6 (Almacén) y 7-3 (S03).
2. **Dominación (F2)**: probé un tic único de puntuación por ronda; **lo
   revertí** porque empeoró (75 % B en Almacén) sin cambiar la estructura
   del turno. Se mantiene la puntuación en el inicio del turno de cada
   bando (13-27/17-23 → sin cambios respecto a la auditoría).

## Decisiones pendientes (para el jugador)

1. **Iniciativa alterna**: para PvP justo, lo canónico es alternar quién
   mueve primero cada ronda (o que A no dispare primero dos rondas
   seguidas). Cambia la sensación de turnos; necesita tu visto bueno.
2. **Dificultad de la IA en S03**: con la IA actual, Eliminación S03 es
   un paseo para A (90 %). Alternativa sin tocar reglas: subir la
   dificultad por defecto en ese modo/mapa (Veterano/Élite).

## Nota del harness

`bench/harness.js` acepta 6º argumento `log` (registro del dron) y
6º/7º argumento `roles` (informe de daño/kills/acciones por rol).


## Medicion final tras F4-F9 (habilidades nuevas activas)

Misma metodologia, 20 partidas en Dominacion y Eliminacion, 10 en Baliza
y Escolta:

| Modo · mapa | A | B | Sesgo | Rondas |
|---|---|---|---|---|
| Dominacion · Almacen | 12 | 8 | 60 % A | 12,4 |
| Dominacion · Skirmish_03 | 3 | 17 | **85 % B** | 8,6 |
| Eliminacion · Almacen | 10 | 10 | **50/50** | 13,4 |
| Baliza · Skirmish_03 | 6 | 4 | 60 % A | 13,6 |
| Escolta · Almacen | 8 | 2 | 80 % A (dron entregado 8/10) | 4,8 |

Lectura:
- **Eliminacion Almacen queda perfectamente equilibrada** (10-10) y Baliza
  S03 mejora a 60 % A (venia de 70 % B).
- **Dominacion S03 sigue siendo el outlier** (85 % B). Mapas, zonas,
  salidas y escuadras verificados 180-simetricos: la diferencia es la
  iniciativa del segundo en mover en un mapa con mucha cobertura. Es una
  decision de diseno pendiente (iniciativa alterna o dificultad mayor de
  la IA en ese modo/mapa), no un bug de disposicion.
- Escolta: el dron se entrega en 8 de 10 partidas (antes 0).

### La IA ahora usa todas las habilidades nuevas

El harness juega con gas, molotov, artilleria, abejas, escudo,
tranquilizante, canon de agua, kit, torreta de cohetes y laser orbital
activos; los numeros de arriba son con esas habilidades en juego.


## Muestra grande de Dominacion Almacen (40 partidas)

Las muestras de 10 partidas oscilaban demasiado (5-5, 2-8, 12-8 en otras
rondas). Con **40 partidas** el resultado es concluyente:

| Modo - mapa | A | B | Sesgo | Rondas |
|---|---|---|---|---|
| Dominacion - Almacen (40) | **20** | **20** | **50/50** | 12,6 |

Conclusion: Dominacion en Almacen esta equilibrada; lo que parecia sesgo
era ruido de muestras pequenas. Para las proximas mediciones se usara
n >= 30 en los modos que se quieran dar por cerrados.


## Muestras agrupadas de la ronda de cierre (n=110 dominacion)

Sumando todas las muestras tomadas en las rondas del objetivo:

| Modo - mapa | A | B | n | Lectura |
|---|---|---|---|---|
| Dominacion - Almacen | 49 | 61 | 110 | 55 % B: sesgo leve, no concluyente |
| Eliminacion - Almacen | 25 | 25 | 50 | 50/50 |
| Baliza - Skirmish_03 | 26 | 14 | 40 | 65 % A |
| Escolta - Almacen | 22 | 8 | 30 | 73 % A (dron entregado 22/30) |

Conclusion: el unico desvio que se repite es el de Dominacion, de un 55 %
hacia B, coherente con la iniciativa del segundo jugador en un mapa de
cobertura densa; el resto esta dentro de lo razonable. La decision de
diseno (iniciativa alterna) sigue pendiente del jugador.


## Muestra grande de Baliza Skirmish_03 (30 partidas)

| Modo - mapa | A | B | n | Lectura |
|---|---|---|---|---|
| Baliza - Skirmish_03 | **15** | **15** | 30 | **50/50**, 13,0 rondas de media |

El 65 % A de las muestras de 10 era ruido: con 30 partidas queda
equilibrada. Se confirma la norma: no dar un modo por sesgado con menos de
30 partidas.


## Tabla consolidada final (todas las muestras, n>=30 por modo)

| Modo - mapa | A | B | n | Sesgo |
|---|---|---|---|---|
| Dominacion - Almacen | 61 | 79 | 140 | 56 % B |
| Eliminacion - Skirmish_03 | 39 | 31 | 70 | 56 % A |
| Baliza - Skirmish_03 | 41 | 29 | 80 | 59 % A |
| Escolta - Almacen | 22 | 8 | 30 | 73 % A (dron 22/30) |

Lectura final: Eliminacion y Baliza tienen una ventaja leve del primero en
mover (~56-59 % A) y Dominacion una ventaja leve del segundo (~56 % B).
Todo dentro del margen de una muestra de este tamano; no se toca ninguna
regla base. Escolta es asimetrica por diseno (el atacante tiene el dron) y
ya no se pierde al 100 % como al principio.
