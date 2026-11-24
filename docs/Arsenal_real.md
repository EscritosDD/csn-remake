# Arsenal real — Remake de RAD Soldiers

Base de datos del arsenal para el remake de RAD Soldiers, el juego de táctica por turnos en cuadrícula que estamos reconstruyendo desde cero. Dani pidió un juego más profesional y complicado, con armas reales y nombres técnicos, y este documento es la base de diseño de ese arsenal.

## Cómo se lee este documento

Cada entrada tiene dos bloques separados y nunca se mezclan:

- **Datos reales:** lo que el arma es en la vida real. Calibre, peso, alcance efectivo, cadencia, país y época, y si sigue en servicio. Todo verificado en Wikipedia y en manuales militares estadounidenses (FM 3-22.31, FM 3-23.30, FM 23-90) y páginas del fabricante. Si un dato no se pudo verificar, va marcado como **sin verificar** y no se inventa. Las discrepancias entre fuentes se anotan en la propia entrada y se recogen al final del documento.
- **En el juego:** los valores del código (`src/data/weapons.js`): daño, alcance en casillas y coste de energía reales del juego, con el rol que la usa según `src/data/roles.js` y su efecto especial. Las 37 armas del catálogo `WEAPONS` llevan estos valores. Las 20 entradas marcadas como no catalogadas son gadgets, desplegables o habilidades, no armas del código, y sus cifras son propuestas de diseño, no valores del juego.

## Escala de juego (la del código)

Para que las cifras sean coherentes entre sí, todas las propuestas usan la misma escala, tomada del original y verificada en su código descompilado (ver docs/historico/Referencia_original.md):

- **Vida base de un soldado:** según el tipo de cuerpo, no por rol: Ligero 200, Medio 250, Pesado 300.
- **Energía por turno:** Ligero 12, Medio 14, Pesado 18. Moverse una casilla cuesta 1 de energía para el Ligero, 2 para el Medio y 3 para el Pesado. Disparar cuesta lo que indique cada arma.
- **Alcance en casillas:** aproximación jugable. Una casilla equivale a unos 50 metros a efectos de alcance, con un tope de diseño pensado para mapas de unas 12 × 12 casillas. Un fusil de asalto real llega a 500 metros, pero en el mapa eso serían 10 casillas y rompería el juego, así que los alcances están comprimidos y el francotirador es el único que dispara casi de punta a punta del mapa.
- **Roles:** Francotirador, Artillero, Espía, Médico, Ingeniero, Comando y Capitán. El Médico y el Capitán no tienen arma propia en esta lista: usan el arsenal general y sus especiales son de apoyo y de mando. Por cuerpo: Espía y Francotirador son Ligeros; Comando, Capitán, Médico e Ingeniero son Medios; el Artillero es Pesado.
- **Daño:** en la escala del código (`src/data/weapons.js`). Un fusil de asalto quita 28 por impacto (M4A1), un francotirador de cerrojo 70 (M40), un antimaterial 100 (Barrett M82) y un lanzacohetes 70 (RPG-7) u 85 (AT4). Ninguno mata de un golpe a un Medio de 250 PV. Los daños de este documento son los del código (factor ×0,4 respecto a la propuesta original).

---

## 1. Fusiles de asalto y carabinas

El arma estándar del soldado. Alcance medio, daño medio, coste de energía medio. Son la referencia contra la que se mide todo lo demás.

### M4A1

**Datos reales:** calibre 5,56×45 mm NATO · peso 2,92 kg vacío, 3,52 kg con cargador de 30 y correa · cadencia cíclica 700–950 disparos/min · alcance efectivo 500 m a objetivos puntuales, 600 m a objetivos de área; máximo 3.600 m · Estados Unidos · en servicio 1994–presente · Colt / FN Herstal.

**En el juego:** rol Comando, Capitán · daño 28 · alcance 6 casillas · coste 3 de energía · ráfaga de 3 disparos: +6 de daño si el objetivo está a 3 casillas o menos. El fusil de referencia: sin sorpresas, fiable en cualquier mapa.

### AK-12

**Datos reales:** calibre 5,45×39 mm (variantes AK-15 en 7,62×39, AK-19 en 5,56 y AK-308 en 7,62×51) · peso 3,5 kg vacío según la ficha, aunque la tabla comparativa de la misma fuente dice 3,3 kg (discrepancia anotada) · cadencia 700 disparos/min · alcance efectivo 440 m · Rusia · en servicio 2018–presente · Kalashnikov Concern · diseñado en 2011.

**En el juego:** rol Comando · daño 30 · alcance 6 casillas · coste 3 de energía · un punto más de daño que el M4A1 a cambio de un punto menos de precisión a larga distancia. La variante AK-15 (7,62×39) sube a 34 de daño y baja a 5 casillas de alcance.

### HK416

**Datos reales:** calibre 5,56×45 mm NATO · cadencia 850 disparos/min en la versión A5, 700–900 disparos/min cíclica en la base · Alemania · en servicio 2004–presente · Heckler & Koch. **Peso y alcance efectivo: sin verificar**, no aparecieron en las fuentes consultadas.

**En el juego:** rol Comando, Espía · daño 28 · alcance 6 casillas · coste 3 de energía · +1 de precisión respecto al M4A1 en todos los rangos, porque su sistema de pistón de gas es más fiable con el cañón sucio. Arma de élite: cuesta más desbloquearla que el M4A1.

### FN SCAR-L

**Datos reales:** calibre 5,56×45 mm NATO · cadencia 650 disparos/min · alcance efectivo 500 m en la versión estándar · Bélgica / Estados Unidos · en servicio 2009–presente · FN Herstal. La variante SCAR-H usa 7,62×51 mm NATO, cadencia 550 disparos/min y alcance efectivo 600 m. **Peso: sin verificar**, no apareció en las fuentes consultadas.

**En el juego:** rol Comando · daño 30 · alcance 6 casillas · coste 3 de energía · la SCAR-H (7,62×51) es una variante desbloqueable: daño 38, alcance 7 casillas, coste 4 de energía y cadencia menor, un solo disparo por turno. El SCAR es el puente entre el fusil de asalto y el fusil de tirador.

---

### G36C

**Datos reales:** calibre 5,56×45 mm NATO · peso 2,8 kg · Alemania, 1996. Datos de la cadena `real` de `src/data/weapons.js`.

**En el juego:** rol Comando · daño 29 · alcance 6 casillas · coste 2 de energía · compacto y estable.

### FAMAS

**Datos reales:** calibre 5,56×45 mm NATO · peso 3,6 kg · Francia, 1978. Datos de la cadena `real` de `src/data/weapons.js`.

**En el juego:** rol Comando · daño 27 · alcance 6 casillas · coste 2 de energía · bullpup: corto de longitud, pegada seca.

## 2. Subfusiles

Armas cortas y ligeras, pensadas para distancias cortas. Poco alcance y poco daño por disparo, pero cuestan poca energía y permiten disparar dos veces por turno o moverse mucho antes de disparar.

### MP5

**Datos reales:** calibre 9×19 mm Parabellum · peso 2,54 kg (la versión corta MP5K, 2,00 kg) · cadencia 800 disparos/min (700 la versión con silenciador integrado SD, 900 la MP5K) · alcance efectivo 200 m · Alemania Occidental · en servicio 1966–presente · Heckler & Koch.

**En el juego:** rol Espía, Comando · daño 22 · alcance 4 casillas · coste 2 de energía · puede disparar dos veces por turno si no se ha movido más de 3 casillas. El subfusil clásico: silencioso con la variante SD (ver Silenciador, categoría 11).

### MP7

**Datos reales:** calibre 4,6×30 mm · peso 1,90 kg con cargador vacío de 20 cartuchos · cadencia 950 disparos/min · alcance efectivo 200 m · Alemania · en servicio 2001–presente · Heckler & Koch. Su cartucho pequeño y rápido está diseñado para perforar chalecos antibalas.

**En el juego:** rol Espía · daño 20 · alcance 4 casillas · coste 2 de energía · ignora la mitad de la protección de chalecos y coberturas ligeras. El arma del Espía por excelencia: ligera, rápida y pensada para colarse por detrás.

### FN P90

**Datos reales:** calibre 5,7×28 mm · peso 2,6 kg · cadencia 850–1.100 disparos/min · alcance efectivo 200 m, máximo 1.800 m · Bélgica · en producción desde 1990 · FN Herstal · cargador de 50 cartuchos montado sobre el arma.

**En el juego:** rol Espía, Comando · daño 18 · alcance 4 casillas · coste 2 de energía · su cargador de 50 cartuchos le permite disparar tres turnos seguidos sin recargar, mientras el resto de subfusiles recarga cada dos. Menos daño por disparo, pero nunca te deja tirado a mitad de un asalto.

### UMP45

**Datos reales:** calibre .45 ACP · peso 2,5 kg sin cargador, 2,65 kg con cargador vacío · cadencia 600–700 disparos/min · alcance efectivo 65 m en .45 ACP (100 m en la versión de 9 mm) · Alemania · en servicio 2000–presente · Heckler & Koch.

**En el juego:** rol Comando, Espía · daño 26 · alcance 3 casillas · coste 2 de energía · +8 de daño a 1 casilla de distancia: es el subfusil de pegar el tiro a quemarropa y desaparecer. Su alcance corto es su límite real, no un invento de equilibrio.

---

### KRISS Vector

**Datos reales:** calibre 9×19 mm · peso 2,7 kg · EE. UU., 2006–presente. Datos de la cadena `real` de `src/data/weapons.js`.

**En el juego:** rol Espía · daño 26 · alcance 4 casillas · coste 1 de energía · ráfaga corta con muy poco retroceso.

## 3. Ametralladoras ligeras y medias

Potencia de fuego sostenida. Mucho daño acumulado y alcance largo, pero pesan, cuestan mucha energía y el soldado que las lleva se mueve poco. Son el arma del Artillero.

### M249 SAW (Squad Automatic Weapon)

**Datos reales:** calibre 5,56×45 mm NATO · peso 7,5 kg vacío, 10 kg con bolsa de 200 cartuchos · cadencia cíclica 850 disparos/min · alcance efectivo 700 m con cañón de 465 mm, 800 m con cañón de 521 mm, a objetivo puntual · adaptación estadounidense del FN Minimi belga. **Año de entrada en servicio: sin verificar**, no apareció en las fuentes consultadas.

**En el juego:** rol Artillero · daño 24 por impacto · alcance 6 casillas · coste 4 de energía · fuego de supresión: el enemigo alcanzado pierde 2 de energía en su siguiente turno y sufre −1 de precisión. Puede disparar en ráfaga larga: 3 impactos repartidos entre enemigos en un cono de 3 casillas de ancho.

### M240B

**Datos reales:** calibre 7,62×51 mm NATO · peso 12,5 kg · cadencia 650–950 disparos/min según el ajuste de gas · alcance efectivo 800–1.800 m según el montaje · designación estadounidense del FN MAG belga. **Año de entrada en servicio: sin verificar**, no apareció en las fuentes consultadas.

**En el juego:** rol Artillero · daño 30 · alcance 7 casillas · coste 4 de energía · fuego de supresión como la M249, pero con más daño por impacto y un alcance mayor. A cambio, el Artillero que la lleva mueve 1 casilla menos por turno: el peso se nota.

### PKM

**Datos reales:** calibre 7,62×54 mmR · peso 7,5 kg con arma y bípode · cadencia 650 disparos/min (cíclica 600–800) · alcance efectivo 1.000 m, máximo 3.800 m · URSS / Rusia · la PKM adoptada en 1969, sigue en servicio · cartucho con pestaña (rimmed), distinto del 7,62×51 de la OTAN.

**En el juego:** rol Artillero · daño 30 · alcance 7 casillas · coste 4 de energía · fuego de supresión como la M240B, pero con una ventaja logística: su munición de cinta es más barata en el juego, así que recargar cuesta 1 de energía menos. La ametralladora fiable y barata frente a la cara y precisa.

### MG3

**Datos reales:** calibre 7,62×51 mm NATO · peso 11,5 kg (27,5 kg en trípode) · cadencia 800–950 disparos/min con cerrojo pesado, 1.000–1.200 disparos/min con cerrojo estándar · alcance efectivo 200–1.200 m según los ajustes de mira; máximo 600 m en bípode, 1.200–1.600 m en trípode · Alemania Occidental · en servicio 1959–presente · Rheinmetall · derivada directa de la MG42 de la Segunda Guerra Mundial.

**En el juego:** rol Artillero · daño 26 · alcance 6 casillas · coste 4 de energía · su cadencia altísima se traduce en dos ataques por turno contra el mismo objetivo o dos objetivos adyacentes, con −1 de precisión en el segundo. La ametralladora de saturar una casilla: poco daño por bala, imposible de ignorar en conjunto.

---

## 4. Fusiles de francotirador

Un solo disparo, mucho daño, mucho alcance. El Francotirador se mueve menos que el Espía y más que el Artillero, y su arma decide partidas desde lejos. Se distingue entre cerrojo (un disparo, máximo daño), semiautomáticos (dos disparos, menos daño) y antimaterial (atraviesa coberturas).

### M40 (M40A1 / A3 / A5)

**Datos reales:** calibre 7,62×51 mm NATO · acción de cerrojo · peso 6,57 kg la M40A1, 7,5 kg la M40A3 · alcance efectivo 800 m · velocidad inicial 777 m/s con munición M118LR · Cuerpo de Marines de Estados Unidos · introducido en 1966 · retirado en 2018, sustituido por el Mk 13 Mod 7 · cadencia aproximada de 6 disparos/min según fuente secundaria.

**En el juego:** rol Francotirador · daño 70 · alcance 9 casillas · coste 4 de energía · un solo disparo por turno, con probabilidad de crítico (daño ×1,5) si el objetivo no se ha movido este turno. El francotirador clásico: paciente y letal contra objetivos quietos.

### Accuracy International AW50

**Datos reales:** calibre .50 BMG (12,7×99 mm NATO) · acción de cerrojo · peso 15 kg con bípode · alcance efectivo 1.500 m · cargador de 5 cartuchos · Reino Unido · Accuracy International · en servicio 2000–presente · fusil antimaterial: dispara el cartucho Raufoss Mk 211, pensado contra vehículos y equipos, no solo contra personas.

**En el juego:** rol Francotirador · daño 95 · alcance 10 casillas · coste 5 de energía · antimaterial: atraviesa coberturas ligeras (muros bajos, sacos) e ignora la mitad de la protección de escudos. Un solo disparo por turno y el Francotirador no puede moverse en el mismo turno en que dispara: hay que plantarse.

### M24 SWS (Sniper Weapon System)

**Datos reales:** calibre 7,62×51 mm NATO (la variante M24A3 usa .338 Lapua Magnum, con alcance efectivo de 1.500 m) · acción de cerrojo · peso 5,4 kg vacío sin mira, 7,3 kg equipado · alcance efectivo 800 m · Ejército de Estados Unidos · adoptado en 1988, sigue en servicio · basado en el Remington 700 civil.

**En el juego:** rol Francotirador · daño 65 · alcance 9 casillas · coste 4 de energía · la variante M24A3 (.338 Lapua Magnum) es desbloqueable: daño 80, alcance 10 casillas, coste 5 de energía. Un punto intermedio entre el M40 y el AW50: menos daño que el antimaterial, más movilidad.

### M110 SASS (Semi-Automatic Sniper System)

**Datos reales:** calibre 7,62×51 mm NATO (variantes en 6,5 Creedmoor) · semiautomático · peso 6,27 kg sin cargar (la M110A2, 4,76 kg) · alcance efectivo 800 m a objetivos puntuales · Estados Unidos · Knight's Armament · en servicio 2008–presente.

**En el juego:** rol Francotirador · daño 45 · alcance 8 casillas · coste 3 de energía · semiautomático: puede disparar dos veces por turno, pero el segundo disparo pierde 2 casillas de alcance por el retroceso. El francotirador que prefiere dos tiros buenos a un tiro perfecto.

### SVD Dragunov

**Datos reales:** calibre 7,62×54 mmR · semiautomático · peso 4,30 kg con mira y cargador vacío · alcance efectivo 800 m · URSS / Rusia · adoptado en 1963, sigue en servicio en 2026 · fusil de tirador designado, no de francotirador puro: está pensado para acompañar a la escuadra, no para disparar solo desde lejos.

**En el juego:** rol Francotirador, Comando · daño 50 · alcance 8 casillas · coste 3 de energía · puede disparar dos veces por turno y, a diferencia de los de cerrojo, puede moverse 2 casillas y disparar en el mismo turno. El tirador de escuadra: menos daño que el M40, mucha más libertad de movimiento.

### Barrett M82 / M107

**Datos reales:** calibre .50 BMG · semiautomático por retroceso · peso 13,5–14,8 kg · alcance efectivo 1.800 m (la M107, máximo efectivo 1.830 m) · cargador de 5 o 10 cartuchos · Estados Unidos · Barrett · fusil antimaterial, apodado «Light Fifty».

**En el juego:** rol Francotirador · daño 100 · alcance 10 casillas · coste 5 de energía · antimaterial como el AW50, pero semiautomático: puede disparar dos veces por turno si no se mueve, con −2 de precisión en el segundo disparo. Además empuja al objetivo una casilla hacia atrás. El arma más dañina del juego, y la más cara de desbloquear y de mover.

---

### Mk 14 EBR

**Datos reales:** calibre 7,62×51 mm NATO · semiautomático · 5,1 kg · EE. UU., 2004–presente. Datos de la cadena `real` de `src/data/weapons.js`.

**En el juego:** rol Francotirador · daño 74 · alcance 9 casillas · coste 4 de energía · DMR: más rápido que el cerrojo, menos letal que un Barrett.

### PSG-1

**Datos reales:** calibre 7,62×51 mm NATO · semiautomático · 8,1 kg · Alemania, 1985. Datos de la cadena `real` de `src/data/weapons.js`.

**En el juego:** rol Francotirador · daño 72 · alcance 10 casillas · coste 4 de energía · precisión de banco: castiga la distancia larga.

### Electri-Fryer

**Datos reales:** arma de ficción del RAD Soldiers original (Splash Damage / WarChest, actualización Party in Rio, abril de 2013) · no existe en el mundo real · en el original: alcance 9, el más largo del juego, daño 54, coste 5 de energía, 5 puntos de escuadra, solo para Agente, precio 40.000 monedas, 2 cartuchos, recarga 6 de energía.

**En el juego:** rol Francotirador · daño 54 · alcance 9 casillas · coste 5 de energía · en el original el daño varía con la distancia (62 a alcance óptimo, 24 cuerpo a cuerpo); en CSN usa el daño base 54. El fusil de Tito Tesla, con la malla Sniper Rifle 1 del original.

## 5. Escopetas y pistolas

Las escopetas son armas de corta distancia con mucho daño concentrado: devastadoras a una casilla, casi inútiles a tres. Las pistolas son el arma secundaria de todos los soldados: poco daño, pero cuestan 1 de energía y salvan partidas cuando el arma principal se queda sin munición o sin energía para disparar.

### Remington 870

**Datos reales:** calibre 12 (también fabricada en 16, 20, 28 y .410) · acción de corredera (pump-action) · peso 3,2–3,6 kg · Estados Unidos · en servicio 1950–presente · más de 11 millones fabricadas, la escopeta más vendida de la historia. **Alcance efectivo: sin verificar en la ficha de Wikipedia**; las fuentes secundarias lo sitúan en unos 40 m con perdigones y hasta 100 m con bala sólida.

**En el juego:** rol Comando, Espía, Ingeniero · daño 45 a 1 casilla, 20 a 2 casillas · alcance 2 casillas · coste 3 de energía · cada disparo afecta a todas las casillas en un cono de 3 casillas de ancho delante del soldado: ideal para limpiar una esquina. Recarga lenta: después de disparar dos turnos seguidos, el tercero hay que dedicarlo a recargar.

### Benelli M4 (M1014)

**Datos reales:** calibre 12 · semiautomática por gas · peso 3,82 kg · alcance efectivo 50 m, máximo 150 m con bala sólida · Italia · Benelli Armi · en servicio 1999–presente · adoptada por el Cuerpo de Marines de Estados Unidos como M1014.

**En el juego:** rol Comando · daño 40 a 1 casilla, 7 a 2 casillas · alcance 2 casillas · coste 3 de energía · semiautomática: puede disparar dos veces por turno, sin la recarga forzada de la 870. Menos daño por disparo que la corredera, más ritmo.

### Mossberg 500

**Datos reales:** calibre 12/70 · peso 3,2 kg · EE. UU., 1961–presente. Datos de la cadena `real` de `src/data/weapons.js`.

**En el juego:** rol Ingeniero · daño 66 · alcance 2 casillas · coste 2 de energía · bomba de corredera: castiga a bocajarro.

### Saiga-12

**Datos reales:** calibre 12 (también en 20 y .410) · semiautomática, con conversión a automática posible · peso 3,6 kg · cadencia 200 disparos/min en semiautomático, 450 disparos/min en automático · Rusia · Kalashnikov Concern · producida 1997–presente · cargadores de 2, 5, 8 y 10 cartuchos y tambores de 12, 20 y 30. **Alcance efectivo: discrepancia entre fuentes**, Wikipedia dice 70 m y otras fuentes dicen 100 m o 50 m.


> **No es un arma del catálogo `WEAPONS` del código: escopeta no incluida en el arsenal jugable.**

**En el juego:** rol Comando · daño 90 a 1 casilla, 15 a 2 casillas · alcance 2 casillas · coste 2 de energía · su tambor de 12 cartuchos le permite disparar cuatro turnos seguidos sin recargar, y la variante automática (desbloqueable) dispara dos veces por turno con −1 de precisión. La escopeta de asalto: menos daño por disparo, más disparos que nadie.

### Beretta M9

**Datos reales:** calibre 9×19 mm Parabellum · semiautomática · peso 970 g sin cargar · alcance efectivo 50 m, máximo 100 m · cargador de 15 cartuchos · Italia / Estados Unidos · adoptada por las Fuerzas Armadas de Estados Unidos en 1985 · sustituida por la SIG P320 (M17) desde 2017.

**En el juego:** rol todos (arma secundaria) · daño 22 · alcance 3 casillas · coste 1 de energía · la secundaria de referencia: nunca falla, nunca sorprende. Cualquier soldado puede dispararla aunque le quede solo 1 de energía.

### Glock 17

**Datos reales:** calibre 9×19 mm Parabellum · semiautomática · alcance efectivo 50 m · cargador de 17 cartuchos (opcionales de 19 y 33) · Austria · Glock · en servicio 1982–presente. **Peso sin cargar: discrepancia entre fuentes**, entre 625 g y 710 g según la generación (625 g, 650 g y 703 g en distintas fuentes).

**En el juego:** rol todos (arma secundaria) · daño 22 · alcance 3 casillas · coste 1 de energía · igual que la M9 en daño y alcance, pero con 2 cartuchos más por cargador: un disparo extra antes de recargar. La diferencia es pequeña y es justo así en la realidad.

### M1911

**Datos reales:** calibre .45 ACP · semiautomática de acción simple · peso 1.100 g vacía con cargador · cargador de 7 cartuchos (+1 en recámara) · Estados Unidos · diseño de John Browning · arma reglamentaria de Estados Unidos de 1911 a 1985, sigue en uso en unidades especiales. **Alcance efectivo: 50 m según la mayoría de fuentes, 62 m según el manual FM 23-35 de 1940.**

**En el juego:** rol todos (arma secundaria) · daño 28 · alcance 3 casillas · coste 1 de energía · la secundaria con más pegada: 6 puntos más de daño que la M9 o la Glock a cambio de 8 cartuchos menos por cargador. El clásico que nunca se retira del todo.

### Desert Eagle

**Datos reales:** calibres .50 Action Express, .44 Magnum y .357 Magnum · semiautomática por gas, con cerrojo rotativo (un sistema más propio de un fusil que de una pistola) · peso unos 2,0 kg en la versión Mark XIX · cargador de 7 cartuchos en .50 AE, 8 en .44 Magnum, 9 en .357 Magnum · Estados Unidos / Israel · Magnum Research e Israel Military Industries · diseñada 1979–1982, en producción desde 1982 · uso civil (caza y tiro deportivo), no es un arma militar estándar. **Alcance efectivo: discrepancia entre fuentes**, 50 m según la mayoría y hasta 200 m según el manual original de 1987.

**En el juego:** rol Comando, Capitán · daño 40 · alcance 3 casillas · coste 2 de energía · la pistola que se juega como un arma principal: daño de escopeta a distancia de pistola, pero con retroceso: después de disparar, el soldado no puede moverse en ese turno. No es secundaria, es una declaración de intenciones.

---

## 6. Lanzacohetes y antitanque

Un disparo, mucho daño en área, y un coste de energía que deja al soldado casi sin turno. La diferencia entre ellos está en el peso (lo que se puede mover con ellos), en si se recargan o son de un solo uso, y en si el proyectil es guiado.

### RPG-7

**Datos reales:** calibre del tubo 40 mm, granada de 85 mm · peso 6,3 kg sin mira, 7 kg con la mira telescópica PGO-7 · alcance efectivo 330 m con la granada PG-7V · máximo 700 m con la OG-7V, con autodestrucción a unos 920 m · URSS / Rusia · en servicio 1961–presente · Bazalt · recargable, con una familia enorme de granadas distintas (antitanque, antipersonal, de humo, termobárica) · más de 9 millones de lanzadores fabricados.

**En el juego:** rol Artillero · daño 70 directo, 30 de salpicadura en las casillas adyacentes al impacto · alcance 6 casillas · coste 5 de energía · recargable: después de disparar hay que gastar 1 turno en recargar, pero se puede volver a disparar en la partida. Su familia de granadas se traduce en munición alternativa desbloqueable: termobárica (más salpicadura, menos daño directo) y de humo (sin daño, nube de humo de 2 turnos).

### AT4

**Datos reales:** calibre 84 mm · peso 6,7 kg (8 kg la versión CS, para disparar desde espacios cerrados) · alcance efectivo 300 m a objetivo puntual, 500 m a objetivo de área · máximo 2.100 m · penetración de unos 400–450 mm de blindaje homogéneo (RHA) según la fuente · Suecia · en servicio 1987–presente · Saab Bofors Dynamics · desechable, de un solo disparo: se dispara y se tira el tubo. Su nombre es un juego de palabras con el calibre: 84, «eighty-four», suena como «AT-4».

**En el juego:** rol Artillero · daño 85 directo, 30 de salpicadura en las casillas adyacentes · alcance 6 casillas · coste 5 de energía · **un solo uso por partida**: es más potente que el RPG-7, pero cuando se dispara, se acabó. Decidir cuándo gastarlo es una de las decisiones de la partida.

### M72 LAW (Light Anti-tank Weapon)

**Datos reales:** calibre 66 mm · peso 2,5 kg en las versiones A1–A3, 3,6 kg en las A4–A7 · alcance efectivo 200 m (220 m en las A4–A7) · máximo 1.000 m · penetración 300 mm de blindaje homogéneo · Estados Unidos · en servicio 1963–presente · desechable, de un solo disparo · alcance mínimo de armado 10 m: por debajo de esa distancia la granada no se arma.

**En el juego:** rol Artillero, Comando · daño 55 directo, 20 de salpicadura en las casillas adyacentes · alcance 5 casillas · coste 4 de energía · **un solo uso por partida**, como el AT4, pero pesa la mitad: el soldado que lo lleva se mueve con normalidad, mientras que el del AT4 mueve 1 casilla menos. Además no se puede disparar a 1 casilla de distancia: el proyectil no se arma tan cerca, igual que en la realidad.

### FGM-148 Javelin

**Datos reales:** calibre 127 mm · peso 22,3 kg listo para disparar (15,9 kg el misil en su tubo, 6,4 kg la unidad de lanzamiento CLU) · alcance efectivo 2.500 m con el CLU original, 4.000 m con el CLU ligero · ojiva tándem HEAT de 8,4 kg · Estados Unidos · en servicio 1996–presente · Raytheon / Lockheed Martin · misil guiado «dispara y olvida» (fire-and-forget): se fija el objetivo antes de lanzar y el misil lo sigue solo · dos modos de ataque: superior, subiendo a 150 m y cayendo sobre el techo del objetivo, o directo, volando a 60 m · alcance mínimo 65 m.


> **No es un arma del catálogo `WEAPONS` del código: lanzacohetes guiado no incluido (sería un especial de élite).**

**En el juego:** rol Artillero (especial de élite) · daño 300 · alcance 8 casillas · coste 6 de energía · **ataque superior: ignora las coberturas**, porque el misil cae desde arriba y no hay muro que lo pare. Exige un turno entero de fijación antes de disparar: en el turno de fijación no se puede mover ni disparar, y si el objetivo se mueve detrás de una cobertura total, se pierde la fijación. El arma más cara y más lenta del juego, y la única que no entiende de escondites.

---

## 7. Lanzagranadas

Granadas de 40 mm con arco parabólico: llegan por encima de las coberturas bajas y explotan en área. Los de un solo disparo van bajo el cañón de un fusil; el M32 es un tambor de seis; el Mk 19 es una ametralladora de granadas y solo tiene sentido como emplazamiento.

### M203

**Datos reales:** calibre 40×46 mm SR · peso 1,36 kg (solo el lanzador, sin el fusil al que va acoplado) · tiro único · cadencia 5–7 disparos/min apuntados · alcance efectivo 350 m a objetivo de área, 150 m a objetivo puntual · máximo 400 m · Estados Unidos · entrada en servicio 1969 · AAI / Colt · lanzagranadas bajo el cañón, el clásico de Vietnam en adelante.

**En el juego:** rol Comando, Ingeniero · daño 45 con salpicadura en las casillas adyacentes al impacto · alcance 5 casillas · coste 3 de energía · va acoplado al fusil del soldado: el soldado conserva su fusil de asalto y puede elegir cada turno entre disparar el fusil o la granada. Munición alternativa desbloqueable: humo (ver M18) y bengala (revela una zona 1 turno).

### M320

**Datos reales:** calibre 40×46 mm SR · peso 1,5 kg (1,62 kg en su configuración base, 2,2 kg con la culata acoplada) · tiro único, doble acción · cadencia 5–7 disparos/min · alcance efectivo 150 m a objetivo puntual, 350 m a objetivo de área · máximo 400 m · Alemania / Estados Unidos · Heckler & Koch · en servicio 2009–presente · diseñado para reemplazar al M203, con la ventaja de que se puede desmontar y usar como arma independiente.


> **No es un arma del catálogo `WEAPONS` del código: lanzagranadas no incluido; el M203 cubre ese papel.**

**En el juego:** rol Comando, Ingeniero · daño 110 con salpicadura en las casillas adyacentes · alcance 5 casillas · coste 3 de energía · igual que el M203 en cifras, pero se puede usar como arma independiente: el soldado puede llevarlo en la mano y seguir moviéndose con normalidad, sin el fusil acoplado. La diferencia es de manejo, no de daño.

### Mk 19

**Datos reales:** calibre 40×53 mm (ojo: no es intercambiable con el 40×46 del M203 y el M320, es un cartucho más potente) · peso 35,2 kg vacío y sin accesorios · automático, alimentado por cinta de 32 o 48 granadas · cadencia cíclica 325–375 disparos/min, práctica de 60 disparos/min en tiro rápido y 40 en tiro sostenido · alcance efectivo 1.500 m · máximo 2.212 m · Estados Unidos · en servicio 1968–presente · Saco Defense / General Dynamics · munición principal M430 HEDP (alto explosivo de doble propósito): radio letal 5 m, radio de heridas 15 m, penetra unos 5 cm de blindaje homogéneo.

**En el juego:** rol Ingeniero (emplazamiento) · daño 85 con salpicadura en un radio de 2 casillas · alcance 5 casillas · **no es un arma de soldado: es un emplazamiento que el Ingeniero despliega** (ver categoría 10). Una vez desplegado, dispara 3 granadas por turno repartidas en la zona elegida. Es el arma de área más potente del juego, y por eso no se mueve.

### M32 (Milkor MGL)

**Datos reales:** calibre 40×46 mm · peso 5,3 kg en la versión MGL original, unos 5,9 kg en la versión M32 del Cuerpo de Marines · tambor giratorio de 6 granadas · cadencia 3 disparos por segundo en tiro rápido, 18–21 disparos/min en tiro sostenido · alcance efectivo 375–400 m · Sudáfrica · Milkor · en servicio 1983–presente · el Cuerpo de Marines de Estados Unidos lo adoptó en 2005 como M32.

**En el juego:** rol Comando, Artillero · daño 40 con salpicadura en las casillas adyacentes · alcance 5 casillas · coste 3 de energía · su tambor de 6 granadas permite disparar hasta tres turnos seguidos sin recargar, algo que ningún otro lanzagranadas puede hacer. La recarga, cuando llega, cuesta un turno entero.

---

## 8. Morteros

Fuego indirecto: el proyectil cae desde arriba y no necesita línea de visión. El mortero no lo lleva un soldado en la mano como un fusil, sino que se despliega en una casilla y dispara a cualquier punto del mapa con un turno de espera. Su debilidad es justo esa espera: el enemigo ve venir el impacto y se mueve.

### M224 (60 mm)

**Datos reales:** calibre 60 mm · peso 21,1 kg completo en modo convencional, 8,2 kg en modo a mano (solo el tubo) · cadencia máxima 30 disparos/min, sostenida 20 disparos/min · alcance con munición HE de 70 a 3.490 m · tripulación de 3 · Estados Unidos · en servicio 1978–presente (la versión ligera M224A1 desde 2011) · se puede disparar en modo convencional (con bípode y placa base) o a mano, sujetando el tubo.


> **No es un arma del catálogo `WEAPONS` del código: mortero desplegable, no un arma de soldado.**

**En el juego:** rol Artillero (apoyo desplegable) · daño 140 con salpicadura en un radio de 2 casillas · alcance: cualquier casilla del mapa · coste 5 de energía · **fuego indirecto con 1 turno de espera**: se marca la zona objetivo y el proyectil cae al final del siguiente turno, avisando al enemigo con un marcador visible. En modo a mano (desbloqueable) pierde el turno de espera pero el daño baja a 35 y el radio a 1 casilla.

### M252 (81 mm)

**Datos reales:** calibre 81 mm · cadencia sostenida 8–16 disparos/min (el manual FM 23-90 dice 15 disparos/min), máxima 20–30 disparos/min en periodos cortos · alcance con munición HE de 91 a 5.935 m según Wikipedia, de 83 a 5.608 m según el FM 23-90 · adaptación estadounidense del mortero británico L16 · Estados Unidos · en servicio 1987–presente. **Peso del sistema: discrepancia entre fuentes**, 41,3 kg según Wikipedia y 55 kg con el equipo básico según el FM 23-90. **Tripulación: discrepancia**, 5 según Wikipedia y 3 según el FM 23-90.


> **No es un arma del catálogo `WEAPONS` del código: mortero desplegable, no un arma de soldado.**

**En el juego:** rol Artillero (apoyo desplegable) · daño 190 con salpicadura en un radio de 3 casillas · alcance: cualquier casilla del mapa · coste 6 de energía · **fuego indirecto con 1 turno de espera**, como el M224, pero con más daño y más radio. A cambio, desplegarlo cuesta un turno entero y desmontarlo otro: es un compromiso de posición, no un arma de quita y pon.

---

## 9. Granadas de mano

Consumibles que se lanzan a 3 casillas. Cada soldado lleva un número limitado por partida y cada granada hace una cosa distinta: daño en área, humo que ciega, luz y ruido que aturden, fuego que quema, o una onda de choque que pega más fuerte en espacios cerrados.

### M67 de fragmentación

**Datos reales:** peso 400 g · relleno de 180 g de Composition B · espoleta pirotécnica M213 con retardo de 4 a 5,5 segundos · un soldado medio la lanza a unos 35 m · radio de bajas 15 m, radio letal 5 m · Estados Unidos · la granada de fragmentación estándar, en servicio desde finales de los años 60.


> **No es un arma del catálogo `WEAPONS` del código: granada consumible (gadget).**

**En el juego:** rol todos (consumible) · daño 125 con salpicadura en las casillas adyacentes al impacto · alcance de lanzamiento 3 casillas · coste 2 de energía · **detona al final del turno en que se lanza**, no al instante: el enemigo tiene un turno para apartarse de la casilla marcada, igual que con los morteros pero en pequeño. Es la granada de referencia: daño limpio y sin efectos raros.

### M18 de humo

**Datos reales:** peso 540 g · relleno de 320 g de mezcla de humo coloreado · espoleta M201A1 con retardo de 1,0 a 2,3 segundos · produce humo de 50 a 90 segundos (media de 60) · un soldado medio la lanza a 35 m · colores disponibles: rojo, verde, amarillo y violeta · Estados Unidos · Pine Bluff Arsenal · en servicio desde 1943, cuando se fabricó la primera.


> **No es un arma del catálogo `WEAPONS` del código: granada consumible (gadget).**

**En el juego:** rol Espía, Comando (consumible) · sin daño · alcance de lanzamiento 3 casillas · coste 2 de energía · crea una nube de humo en un radio de 2 casillas que dura 2 turnos: **nadie puede disparar a través de ella ni ver lo que hay dentro**. Sirve para cruzar un pasillo, para cubrir una retirada o para que el Espía se cuele sin que lo vean. El color del humo es cosmético, pero el rojo marca la zona propia y el violeta la enemiga si se juega con dos equipos.

### M84 aturdidora (flashbang)

**Datos reales:** peso 370 g · relleno de 4,5 g de mezcla pirotécnica de magnesio y nitrato de amonio · espoleta M201A1 con retardo de 1,0 a 2,3 segundos · al detonar emite un estruendo de 170–180 decibelios y un destello de 6–8 millones de candelas a 1,5 m · causa desorientación, confusión y pérdida temporal de audición hasta 9 m · Estados Unidos · Picatinny Arsenal · en servicio 1995–presente · clasificada como arma no letal. **Peso: discrepancia entre fuentes**, la Wikipedia actual dice 370 g, el manual FM 3-23.30 dice 13,3 onzas (unos 377 g) y algunas versiones antiguas de la ficha dicen 236 g.


> **No es un arma del catálogo `WEAPONS` del código: granada consumible (gadget).**

**En el juego:** rol Espía, Comando (consumible) · sin daño · alcance de lanzamiento 3 casillas · coste 2 de energía · **aturde a todos los enemigos en un radio de 1 casilla durante 1 turno**: no pueden moverse ni disparar, y pierden su especial si lo tenían preparado. No hace daño, pero un turno entero sin que el enemigo actúe vale más que 125 de daño. La granada del Espía para entrar en una casilla defendida.

### AN-M14 de termita (incendiaria)

**Datos reales:** peso 900 g · relleno de 751 g de mezcla de termita TH3 · espoleta M201A1 · la termita arde unos 40 segundos a unos 2.200 °C (4.000 °F) · perfora una placa de acero homogéneo de 12,7 mm · un soldado medio la lanza a 25 m · produce su propio oxígeno y arde bajo el agua · Estados Unidos · pensada para destruir equipo, no para lanzar contra personas: funde las partes metálicas de lo que toca.


> **No es un arma del catálogo `WEAPONS` del código: granada consumible (gadget).**

**En el juego:** rol Ingeniero (consumible) · daño 40 por turno durante 2 turnos en la casilla afectada · alcance de lanzamiento 2 casillas · coste 3 de energía · **crea una zona de fuego que dura 2 turnos y destruye la cobertura de la casilla**: un muro bajo o unos sacos dejan de existir, y quien entre en la casilla se quema. Su uso natural es abrir un hueco en una defensa, no matar soldados.

### Mk3A2 de concusión (ofensiva)

**Datos reales:** peso 440 g · relleno de 230 g de TNT · espoleta M206A1 o M206A2 con retardo de 4 a 5 segundos · cuerpo de fibra prensada, sin fragmentación: el daño lo hace la onda de choque, no la metralla · un soldado medio la lanza a 40 m · radio efectivo de bajas de 2 m en campo abierto, mucho mayor en espacios cerrados · Estados Unidos · en servicio 1968–presente · aprobada su sustituta, la M111, para reemplazo total en marzo de 2026.


> **No es un arma del catálogo `WEAPONS` del código: granada consumible (gadget).**

**En el juego:** rol Comando, Ingeniero (consumible) · daño 90 en campo abierto, **70 en casillas cerradas o con cobertura en tres lados o más** · alcance de lanzamiento 3 casillas · coste 2 de energía · la granada de asaltar habitaciones: en el mapa abierto es mediocre, pero si el enemigo se ha atrincherado en una casilla cerrada, la onda de choque rebota en las paredes y pega el doble. Es el motivo para no acampar en un rincón.

---

## 10. Torretas y emplazamientos

Armas que no se llevan en la mano: se despliegan en una casilla y se quedan ahí. Las instala el Ingeniero, disparan automáticamente o con el turno del soldado que las maneja, y el enemigo puede destruirlas. Son la forma de convertir una casilla en una fortaleza.

### M2 Browning .50

**Datos reales:** calibre .50 BMG (12,7×99 mm NATO) · peso 38 kg (58 kg con trípode y mecanismo de puntería) · cadencia 450–600 disparos/min en la versión M2HB · alcance efectivo 1.800 m, máximo 7.400 m · Estados Unidos · diseñada por John Browning · en servicio 1933–presente (la M2HB desde 1921) · apodada «Ma Deuce», más de 3 millones fabricadas.

**En el juego:** rol Ingeniero (emplazamiento) · daño 38 · alcance 7 casillas · **el Ingeniero tarda 1 turno en desplegarla y no se puede mover mientras está montada** · dispara automáticamente al final del turno del Ingeniero contra el enemigo más cercano en su arco de tiro, y además aplica supresión (−2 de energía al objetivo en su siguiente turno). Tiene 120 puntos de vida propios y el enemigo puede destruirla. La torreta de referencia: la que defiende la baliza.

### Mk 19 de 40 mm

**Datos reales:** ver su entrada completa en la categoría 7 (lanzagranadas). Resumen: calibre 40×53 mm · peso 35,2 kg vacío · automática por cinta, 325–375 disparos/min cíclicos · alcance efectivo 1.500 m, máximo 2.212 m · Estados Unidos · en servicio 1968–presente · munición M430 HEDP con radio letal de 5 m.

**En el juego:** rol Ingeniero (emplazamiento) · daño 85 con salpicadura en un radio de 2 casillas · alcance 5 casillas · **el Ingeniero tarda 1 turno en desplegarla** · dispara 3 granadas por turno repartidas en la zona elegida, con 1 turno de espera entre la designación y el impacto. Tiene 80 puntos de vida propios. Es la torreta de área: menos precisa que la M2, imposible de ignorar si caen tres granadas en tu casilla.

### M134 Minigun

**Datos reales:** calibre 7,62×51 mm NATO · peso 39 kg (19 kg en la versión ligera) · 6 cañones giratorios accionados eléctricamente · cadencia variable de 2.000 a 6.000 disparos/min, típicamente 3.000–4.000 en uso real · alcance máximo 1.000 m · Estados Unidos · General Electric · en servicio 1963–presente · necesita una fuente eléctrica externa para girar los cañones, no es un arma que se dispare a pulso.


> **No es un arma del catálogo `WEAPONS` del código: emplazamiento, no un arma de soldado.**

**En el juego:** rol Ingeniero (emplazamiento) · daño 75 por impacto, 3 impactos por turno · alcance 7 casillas · **el Ingeniero tarda 1 turno en desplegarla y necesita 1 turno de arranque de los cañones antes del primer disparo** · los 3 impactos se reparten entre los enemigos de la zona elegida. Tiene 60 puntos de vida propios. La torreta de saturación: mucho ruido, mucho plomo, poca precisión por disparo.

### DShK

**Datos reales:** calibre 12,7×108 mm · peso 34 kg solo el arma, 157 kg con el afuste de ruedas · cadencia 600 disparos/min · alcance efectivo 2.000 m, máximo 2.500 m · penetra hasta 20 mm de blindaje a 500 m · URSS · en servicio 1938–presente · Degtyaryov y Shpagin · unas 1 millón fabricadas. **Alcance efectivo: discrepancia entre fuentes**, la ficha dice 2.000 m y el texto del artículo dice 2,4 km.


> **No es un arma del catálogo `WEAPONS` del código: emplazamiento, no un arma de soldado.**

**En el juego:** rol Ingeniero (emplazamiento) · daño 120 · alcance 8 casillas · **el Ingeniero tarda 1 turno en desplegarla** · como la M2, pero con un punto más de daño y un punto menos de precisión: la versión soviética de la misma idea. Tiene 80 puntos de vida propios. Sirve para que los dos bandos no tengan exactamente el mismo arsenal: la M2 es OTAN y la DShK es del bloque del Este.

### KPV

**Datos reales:** calibre 14,5×114 mm · cadencia 600 disparos/min · velocidad inicial 1.005 m/s · alcance efectivo 3.000 m, máximo 4.000 m · energía en boca 31 kJ, aproximadamente el doble que un proyectil .50 BMG · URSS · entró en servicio como arma de infantería en 1949, retirada de infantería en los años 60 por ser demasiado grande y pesada, sigue en uso antiaéreo y en vehículos · Semyon Vladimirov. **Peso: discrepancia entre fuentes**, 49 kg según Wikipedia y 52,3 kg según otras fuentes.


> **No es un arma del catálogo `WEAPONS` del código: emplazamiento, no un arma de soldado.**

**En el juego:** rol Ingeniero (emplazamiento) · daño 150 · alcance 9 casillas · **el Ingeniero tarda 1 turno en desplegarla** · antimaterial: ignora la mitad de la protección de escudos y destruye coberturas ligeras con dos impactos. Tiene 100 puntos de vida propios, más que las demás torretas, porque es la más pesada. La torreta de élite: el cañón más grande del juego, y el que más cuesta desplegar.

---

## 11. Equipo táctico

No son armas de fuego, son herramientas que cambian cómo se juega una casilla o un turno: una mina que vigila un pasillo, un explosivo que abre un muro, un dron que revela el mapa, un botiquín que devuelve a un soldado al combate, un escudo que convierte a un soldado en una pared, una mira que ve a través del humo y un silenciador que borra tu posición del mapa enemigo.

### Mina Claymore M18A1

**Datos reales:** peso 1,6 kg · relleno de 680 g de C-4 · unas 700 bolas de acero de 3,2 mm · al detonar las proyecta en un abanico de 60° delante del dispositivo, a 1.218 m/s · alcance efectivo 50 m (moderadamente efectiva hasta 100 m, los fragmentos llegan hasta 250 m) · probabilidad de impacto del 30 % sobre un objetivo del tamaño de una persona a 50 m · Estados Unidos · en servicio 1960–presente · diseñada 1952–1956 por Norman MacLeod · se dispara por mando a distancia con el dispositivo M57, no por pisarla.


> **No es un arma del catálogo `WEAPONS` del código: desplegable del Ingeniero (en el código hace 60 de daño a quien la pisa).**

**En el juego:** rol Ingeniero, Espía · daño 150 en un cono de 3 casillas de ancho y 2 de profundidad delante de la mina · coste 3 de energía colocarla · **se coloca en una casilla mirando a una dirección y detona cuando un enemigo entra en su cono, o cuando el soldado que la puso la detona a distancia**. Una sola mina por soldado y partida. La herramienta de defender un pasillo o la baliza mientras el resto del equipo ataca en otro lado.

### C4 (Composition C-4)

**Datos reales:** compuesto por un 91 % de RDX, con plastificante, aglutinante y aceite mineral · el bloque de demolición M112 pesa 0,57 kg · velocidad de detonación 8.092 m/s · muy estable: no detona por un disparo, por una caída ni por el fuego, solo por la onda de choque de un detonador · Estados Unidos · diseñado en 1956, en producción desde entonces · textura de plastilina, se moldea a mano en cualquier forma.


> **No es un arma del catálogo `WEAPONS` del código: gadget del Ingeniero/Espía; corresponde a la habilidad #35 Carga remota (pendiente).**

**En el juego:** rol Ingeniero, Espía · daño 225 con salpicadura en las casillas adyacentes · coste 4 de energía colocarlo · **se coloca en una casilla o pegado a una cobertura y se detona a distancia en cualquier turno posterior**. Destruye la cobertura de la casilla y cualquier emplazamiento que haya en ella. Dos bloques por soldado y partida. La herramienta de abrir un muro o de volar una torreta enemiga sin acercarse a dispararle.

### Dron de reconocimiento RQ-11 Raven

**Datos reales:** peso 1,9 kg (las versiones nuevas, 2,2 kg) · envergadura 1,37 m · autonomía 60–90 minutos · radio operativo de unos 10 km · velocidad 32–81 km/h · altitud de operación 100–500 m sobre el terreno · cargas útiles estándar: cámara de vídeo en color y cámara infrarroja de visión nocturna · Estados Unidos · AeroVironment · en servicio 2004–presente, con retirada progresiva anunciada por el Ejército desde 2024 · se lanza a mano, como un avión de papel, y lleva un motor eléctrico en configuración de hélice trasera.


> **No es un arma del catálogo `WEAPONS` del código: gadget de reconocimiento; corresponde a la habilidad #46 UAV (pendiente).**

**En el juego:** rol Espía, Capitán · sin daño · coste 3 de energía lanzarlo · **revela todas las posiciones enemigas durante 3 turnos, incluidas las que están detrás de coberturas**, y marca en el mapa las minas y el C4 enemigos. No ataca. Un solo uso por partida. Es el especial de reconocimiento del Espía: saber dónde está todo el mundo vale más que un disparo.

### Botiquín de combate IFAK (Individual First Aid Kit)

**Datos reales:** peso aproximado de 0,45 kg en su versión original · kit individual de trauma, no un botiquín general: está pensado para una sola cosa, mantener viva a una persona con una hemorragia grave, una vía aérea obstruida o un pulmón colapsado hasta que llegue la evacuación · contenido mínimo según el CoTCCC (Comité de Atención Táctica al Herido en Combate): un torniquete C-A-T, gasa hemostática (QuikClot), vendaje de presión (estilo israelí), un par de sellos torácicos ventilados HyFin, una vía aérea nasofaríngea de 28 Fr con lubricante, gasa comprimida, guantes de nitrilo, tijeras de trauma, un marcador permanente y una manta térmica de emergencia · la versión IFAK II, en uso desde 2023, lleva dos torniquetes C-A-T · Estados Unidos.


> **No es un arma del catálogo `WEAPONS` del código: consumible de curación (el Médico cura 80 en el código con su especial).**

**En el juego:** rol Médico (todos llevan uno básico) · **el Médico cura 50 puntos de vida a un aliado adyacente o a sí mismo, coste 3 de energía, 2 usos por partida** · cualquier otro soldado lleva un IFAK básico que cura 25 puntos, 1 uso por partida, coste 3 de energía. Curar no resucita: un soldado eliminado sigue eliminado. El Médico además tiene su especial de reanimación (ver documento de roles), que es otra cosa y no sale de este botiquín.

### Escudo balístico

**Datos reales:** los escudos policiales y militares se clasifican según la norma NIJ 0108.01 del Instituto Nacional de Justicia de Estados Unidos · Nivel IIIA: detiene munición de pistola, incluidos 9 mm, .357 SIG y .44 Magnum; los modelos habituales pesan entre 6 y 10 kg, hasta 14 kg en los más grandes · Nivel III: detiene munición de fusil, incluido el 7,62×51 mm NATO; pesa entre 14 y 20 kg en los modelos ligeros, hasta 20 kg en los grandes · Nivel IV: detiene munición perforante de fusil, como el .30-06 M2 AP; unos 9 kg en los modelos más ligeros · **no hay un modelo único con especificaciones cerradas: los pesos son rangos típicos de mercado**, no la ficha de un escudo concreto.


> **No es un arma del catálogo `WEAPONS` del código: equipo táctico; corresponde a la habilidad #24 Juggernaut (escudo del Comando).**

**En el juego:** rol Comando, Capitán · **equipar el escudo cuesta 2 de energía y añade 40 puntos de vida temporales que solo se pierden por disparos frontales** · mientras lo lleva, el soldado mueve 1 casilla menos por turno y no puede usar armas de dos manos (fusiles de asalto, ametralladoras, lanzacohetes): solo pistola o subfusil. El escudo se rompe cuando se agotan sus 40 puntos. Es la forma de avanzar por un pasillo bajo fuego: lento, pero vivo.

### Mira térmica AN/PAS-13

**Datos reales:** mira térmica de arma ligera, media y pesada, desarrollada por Raytheon para el Ejército de Estados Unidos · capacidad operativa inicial en 1998, 33.400 unidades producidas hasta 2010 · la versión Media pesa 2,3 kg, con zoom de 5×, detecta a una persona a 1,2 km y un vehículo a 4,2 km · la versión Pesada pesa 2,5 kg, con zoom de 10×, detecta a una persona a 2,8 km y un vehículo a 6,9 km · batería de unas 7 horas de operación continua · las versiones modernas son más ligeras (0,82–1,8 kg) · es un sistema pasivo: no emite nada que el enemigo pueda detectar · ve a través del humo, la niebla y la oscuridad, porque detecta calor, no luz.


> **No es un arma del catálogo `WEAPONS` del código: accesorio, no un arma.**

**En el juego:** rol Francotirador, Espía · **equipar la mira cuesta 1 de energía y permite disparar a través del humo de la M18 y en casillas oscuras sin penalización, con +2 casillas de alcance en el arma que la lleve** · no revela enemigos detrás de coberturas sólidas, solo ignora el humo y la oscuridad. Es la respuesta directa a la granada de humo: si el enemigo se esconde en humo, la térmica lo encuentra. Una mira por soldado, ocupa la ranura de accesorio.

### Silenciador (supresor)

**Datos reales:** un cilindro metálico con deflectores internos que retienen y enfrían los gases de la boca del cañón · inventado por Hiram Maxim en 1902 · reduce el ruido del disparo en unos 20–35 decibelios, típicamente unos 30 dB: un fusil de 5,56 mm sin supresor genera unos 165 dB y con supresor baja a unos 135–140 dB, que sigue siendo alto pero menos dañino para el oído · pesa entre unos 170 g y más de 1 kg según el modelo y el calibre, y mide entre 7,5 y 25 cm · no elimina el chasquido supersónico del proyectil, solo el estruendo de la boca · además reduce el retroceso y elimina el fogonazo · **no hay un modelo único con especificaciones cerradas: las cifras son rangos típicos**.


> **No es un arma del catálogo `WEAPONS` del código: accesorio, no un arma.**

**En el juego:** rol Espía, Francotirador · **equipar el silenciador cuesta 1 de energía, reduce el daño del arma en 1 punto y hace que disparar no revele la posición del soldado en el mapa enemigo** · sin silenciador, cada disparo marca la casilla del tirador durante 1 turno; con silenciador, el enemigo solo sabe que le han disparado, no desde dónde. La combinación natural es Espía con MP7 silenciada: poco daño por disparo, posición desconocida, y el enemigo no sabe por dónde le vienen los tiros.

---

## 12. Armas cuerpo a cuerpo

El original tenía varias armas cuerpo a cuerpo (cuchillo, katana, hacha, maza...), pero en CSN solo una está cableada como arma jugable: el hacha de Tree Mendez. Las demás existen como mallas del original sin equivalente en el arsenal de CSN.

### Lumber Numberer

**Datos reales:** arma de ficción del RAD Soldiers original (Splash Damage / WarChest, actualización Party in Rio, abril de 2013) · no existe en el mundo real · en el original: alcance 1 (cuerpo a cuerpo), daño 76, coste 4 de energía, 5 puntos de escuadra, para Soldado, Médico, Ingeniero y Agente, precio 40.000 monedas, 1 de empuje.

**En el juego:** rol Artillero · daño 76 · alcance 1 casilla · coste 4 de energía · empuja al objetivo 1 casilla. El hacha de Tree Mendez, con la malla WoodAxe del original.

---

## Datos sin verificar y discrepancias entre fuentes

Todo lo que no se pudo cerrar con una fuente fiable, para no inventar nada y saber qué queda por comprobar:

- **HK416:** peso y alcance efectivo sin verificar (no aparecieron en las fuentes consultadas).
- **FN SCAR:** peso sin verificar.
- **M249 SAW:** año de entrada en servicio sin verificar.
- **M240B:** año de entrada en servicio sin verificar.
- **Remington 870:** alcance efectivo sin verificar en la ficha de Wikipedia; las fuentes secundarias lo sitúan en unos 40 m con perdigones y hasta 100 m con bala sólida.
- **Saiga-12:** alcance efectivo con discrepancia entre fuentes (50 m, 70 m o 100 m).
- **Glock 17:** peso sin cargar con discrepancia entre fuentes (625 g, 650 g o 703 g según la generación).
- **AK-12:** peso con discrepancia entre fuentes (3,5 kg en la ficha, 3,3 kg en la tabla comparativa).
- **M40:** cadencia de unos 6 disparos/min según fuente secundaria, sin confirmar en el manual.
- **M84:** peso con discrepancia entre fuentes (370 g en la ficha actual, 377 g según el FM 3-23.30, 236 g en versiones antiguas de la ficha).
- **M252:** peso del sistema con discrepancia (41,3 kg según Wikipedia, 55 kg con el equipo básico según el FM 23-90), tripulación con discrepancia (5 según Wikipedia, 3 según el FM 23-90) y alcance con discrepancia (91–5.935 m según Wikipedia, 83–5.608 m según el FM 23-90).
- **DShK:** alcance efectivo con discrepancia (2.000 m en la ficha, 2,4 km en el texto del artículo).
- **KPV:** peso con discrepancia (49 kg según Wikipedia, 52,3 kg según otras fuentes).
- **Desert Eagle:** alcance efectivo con discrepancia (50 m según la mayoría de fuentes, hasta 200 m según el manual original de 1987).
- **M1911:** alcance efectivo con discrepancia menor (50 m según la mayoría, 62 m según el manual FM 23-35 de 1940).
- **Escudo balístico y silenciador:** no hay un modelo único con especificaciones cerradas; los pesos y las reducciones de ruido son rangos típicos de mercado, no la ficha de un modelo concreto.

## Fuentes consultadas

- Wikipedia (fichas en inglés de cada arma y equipo).
- Manuales del Ejército de Estados Unidos: FM 3-22.31 (M203), FM 3-23.30 (granadas y señales pirotécnicas, 2005), FM 23-90 (morteros M224 y M252), FM 3-23.25 (armas ligeras antitanque) y FM 23-35 (M1911, 1940).
- Federation of American Scientists (FAS): ficha de la AN-M14 TH3.
- PEO Soldier (Ejército de Estados Unidos): ficha de la mira térmica AN/PAS-13.
- Páginas del fabricante: Milkor USA (M32A1), Heckler & Koch (M320) y AeroVironment (RQ-11 Raven).
- American College of Emergency Physicians (ACEP): artículo sobre supresores y salud auditiva.

## Notas de equilibrio (para las pruebas)

- La vida real es Ligero 200, Medio 250 y Pesado 300 (`src/data/roles.js`). Con los daños del código, un Medio de 250 PV muere en 9 impactos de M4A1 (28 de daño), en 4 de M40 (70), en 3 de Barrett M82 (100) o de AT4 (85) y en 4 de RPG-7 (70). Un Ligero de 200 PV muere en 8 de M4A1, en 3 de M40 y en 2 de Barrett. Un Pesado de 300 PV muere en 11 de M4A1, en 5 de M40 y en 3 de Barrett. Si en las pruebas las partidas se acaban demasiado rápido, lo primero que hay que bajar es el daño de los francotiradores, no su alcance.
- Las armas de un solo uso (AT4, M72 LAW) y los consumibles (granadas, Claymore, C4, dron) son el recurso escaso del juego: si un jugador los gasta todos en los dos primeros turnos, el resto de la partida la juega con fusiles. Esa tensión es intencionada.
- El Ingeniero es el rol que más cambia el mapa (torretas, Claymore, C4, morteros), y por eso es el más lento: casi todo lo que despliega cuesta un turno entero. Si el Ingeniero resulta demasiado fuerte, lo primero es subir el coste de despliegue, no bajar el daño de las torretas.
- La mira térmica existe para que el humo no sea una victoria automática: si en las pruebas el humo domina las partidas, la térmica tiene que ser más barata de equipar, no más potente.
