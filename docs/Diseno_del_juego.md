# Diseño del juego — CSN

Documento de diseño del remake. El original es RAD Soldiers (Splash Damage / WarChest, 2012, iPad), un juego de táctica por turnos en cuadrícula que ya no se puede descargar ni jugar porque sus servidores están apagados. Este remake lo reconstruye desde cero y lo hace más profesional y complejo, como pidió Dani: arsenal real, más roles, más modos, escuadras de 2 contra 2 y 4 contra 4, y mapas con elementos accionables.

**Nombre:** CSN, siglas de Chess Soldier Nation, decidido por Dani.

## La idea en una frase

Dos escuadras de soldados se enfrentan por turnos en una cuadrícula, cada soldado con su rol, su arma real y su especial, y se gana eliminando al rival o aguantando cinco turnos en la baliza.

## Reglas centrales (del original, verificadas en su código descompilado; ver docs/historico/Referencia_original.md)

- **Turnos alternos.** Juega un bando entero y luego el otro, como en el ajedrez. Cada soldado actúa en el turno de su bando.
- **Energía y vida por tipo de cuerpo, no por rol.** Ligero: 200 de vida, 12 de energía, 1 por casilla (12 casillas por turno). Medio: 250 de vida, 14 de energía, 2 por casilla (7 casillas). Pesado: 300 de vida, 18 de energía, 3 por casilla (6 casillas). El que más aguanta es el que menos anda, como en el original. Disparar cuesta lo que indique el arma y usar el especial cuesta lo suyo, todo de la misma reserva.
- **Cuadrícula cenital.** Mapa de unas 12 × 12 casillas, vista desde arriba, con coberturas. Sin casillas de movimiento libre: todo se mide en casillas. La distancia se mide en Chebyshev (el mayor de los dos desplazamientos).
- **Victoria doble.** Se gana eliminando a todos los soldados enemigos o aguantando la zona objetivo sin enemigos dentro durante 5 turnos. En el modo Eliminación solo vale la primera; en el modo Baliza valen las dos.
- **Azar con semilla, como el original.** Los disparos tienen puntería, probabilidad de crítico y dispersión de daño, y el daño cae con la distancia. El azar es determinista por semilla de turno, así que una partida se puede reproducir igual en los dos dispositivos. La puntería se ve antes de disparar.
- **Fuego de respuesta.** Disparar a un enemigo puede provocar que te devuelva el disparo, con daño reducido. En el original venía activado en todas las armas: disparar deja de ser gratis.
- **Fuego de reacción (vigilancia).** Un soldado en vigilancia dispara automáticamente contra enemigos que se muevan a su alcance durante el turno rival, con un máximo de disparos por turno.
- **Dirección de mira.** Cada soldado mira hacia un lado (norte, sur, este u oeste) y eso se guarda en cada turno. La dirección la fija el último movimiento o el último disparo.
- **Cobertura direccional.** Cada borde de casilla tiene cobertura en tres niveles: sin cobertura, media y total. Solo la total bloquea la visión. La protección depende del lado desde el que disparan, no es igual en todas las direcciones.
- **Cajas de botín programadas.** En un turno determinado de la partida cae una caja en el mapa (salud, munición mejorada, analgésicos o espíritu de equipo). Dan un motivo para moverse a mitad de partida.
- **Empujón.** Las armas pesadas y las explosiones pueden empujar al objetivo una casilla.

## Roles (7)

La vida y la energía van por tipo de cuerpo, como en el original: Ligero 200 de vida y 12 de energía, Medio 250 y 14, Pesado 300 y 18. Moverse cuesta 1 de energía por casilla al Ligero, 2 al Medio y 3 al Pesado.

| Rol | Cuerpo | Vida | Energía | Armas principales | Especial |
|---|---|---|---|---|---|
| Francotirador | Ligero | 200 | 12 | M40, M24, M110, SVD, AW50, Barrett M82 | Tiro certero: un disparo con daño ×1,5 si el objetivo no se ha movido este turno |
| Artillero | Pesado | 300 | 18 | M249 SAW, M240B, PKM, MG3, RPG-7, AT4, M72 LAW, Javelin | Fuego de supresión: el enemigo alcanzado pierde 2 de energía en su siguiente turno |
| Espía | Ligero | 200 | 12 | MP7, MP5, P90, UMP45 | Invisibilidad: 1 turno sin poder ser objetivo de disparos, se rompe al disparar |
| Médico | Medio | 250 | 14 | Fusil de asalto, pistola | Curar 125 de vida a un aliado adyacente (2 usos por partida); reanimación: un aliado caído vuelve con 60 de vida (1 uso) |
| Ingeniero | Medio | 250 | 14 | Escopeta, M203, M320 | Desplegar torreta (M2, Mk 19, M134, DShK, KPV), Claymore, C4, mortero |
| Comando | Medio | 250 | 14 | M4A1, AK-12, HK416, SCAR, M32 | Granada de fragmentación extra: lleva una M67 más que los demás |
| Capitán | Medio | 250 | 14 | M4A1, Desert Eagle | Orden de mando: un aliado recupera 4 de energía en este turno (1 uso por turno) |

El Francotirador se mueve más que el Artillero y menos que el Espía, como recordaba Dani. El Artillero es el más lento y el que más daño hace en área. El Espía es el más rápido y el más frágil.

## Arsenal

La base completa está en [Arsenal_real.md](Arsenal_real.md): 51 entradas en 11 categorías, cada una con sus datos reales verificados y su traducción a estadísticas de juego. Resumen por categoría:

- **Fusiles de asalto y carabinas:** M4A1, AK-12, HK416, FN SCAR. Daño 70–95, alcance 6–7 casillas, coste 3–4 de energía.
- **Subfusiles:** MP5, MP7, P90, UMP45. Daño 45–65, alcance 3–4 casillas, coste 2 de energía. Armas del Espía.
- **Ametralladoras:** M249 SAW, M240B, PKM, MG3. Daño 60–75, alcance 6–7 casillas, coste 4 de energía, con supresión. Armas del Artillero.
- **Francotiradores:** M40, AW50, M24, M110, SVD, Barrett M82. Daño 110–250, alcance 8–10 casillas, coste 3–5 de energía. Los de cerrojo disparan una vez por turno; los semiautomáticos, dos.
- **Escopetas y pistolas:** Remington 870, Benelli M4, Saiga-12; M9, Glock 17, M1911, Desert Eagle. La pistola es el arma secundaria de todos: daño 55–100, coste 1–2 de energía.
- **Lanzacohetes:** RPG-7 (recargable), AT4 y M72 LAW (un solo uso por partida), Javelin (guiado, ignora coberturas, exige un turno de fijación). Daño 140–300.
- **Lanzagranadas:** M203, M320 (acoplados al fusil), M32 (tambor de 6), Mk 19 (emplazamiento). Daño 100–125 en área.
- **Morteros:** M224 (60 mm) y M252 (81 mm). Fuego indirecto a cualquier casilla del mapa, con 1 turno de espera y marcador visible para el enemigo.
- **Granadas de mano:** M67 de fragmentación, M18 de humo, M84 aturdidora, AN-M14 de termita, Mk3A2 de concusión. Consumibles, se lanzan a 2–3 casillas.
- **Torretas:** M2 Browning, Mk 19, M134 Minigun, DShK, KPV. Las despliega el Ingeniero en 1 turno; tienen vida propia y el enemigo puede destruirlas.
- **Equipo táctico:** mina Claymore M18, C4, dron RQ-11 Raven, botiquín IFAK, escudo balístico, mira térmica AN/PAS-13, silenciador.

## Modos de juego

- **Eliminación.** Gana quien elimine a toda la escuadra enemiga. El modo clásico.
- **Captura de baliza.** Gana quien elimine al rival o aguante 5 turnos seguidos con la zona central sin enemigos dentro. El modo del original.
- **Dominación.** Tres zonas en el mapa. Cada turno que un bando aguanta una zona suma 1 punto; gana quien llegue a 10 puntos o elimine al rival. (Después de la v1.)
- **Escolta.** Un dron averiado debe llegar a la zona de extracción y quedarse 1 turno. El bando que lo escolta gana si lo logra; el otro, si destruye el dron o elimina a los escoltas. (Después de la v1.)

La v1 trae Eliminación y Captura de baliza. Dominación y Escolta se añaden cuando la v1 esté equilibrada.

## Formatos de escuadra

- **2 contra 2.** Partidas rápidas, de pocos turnos. Para aprender y para jugar en ratos cortos.
- **4 contra 4.** El formato principal del remake, más táctico que el 5 contra 5 del original y más manejable en una tablet.
- **5 contra 5.** El formato del original, para quien quiera la escuadra completa.

Cada jugador elige sus soldados y sus armas antes de la partida, con dos límites de puntos de escuadra separados, como en el original: uno para las unidades y otro para las habilidades. Los soldados y las armas potentes cuestan más puntos, así que una escuadra de élite es pequeña y una escuadra grande es modesta.

## Mapas con elementos accionables

El mapa ya no es solo un tablero con coberturas: tiene cosas que se pueden usar, romper o capturar.

- **Coberturas:** muros bajos, sacos de arena, cajas y coches. Cada borde de casilla tiene cobertura en tres niveles (sin cobertura, media y total) y solo la total bloquea la visión; la protección depende del lado desde el que disparan. Los sacos y las cajas se pueden destruir; los muros, no.
- **Barriles explosivos:** al recibir un disparo explotan y hacen 100 de daño en las casillas adyacentes. Están colocados donde duelen.
- **Torreta capturable:** en el centro de algunos mapas hay un emplazamiento vacío. El primer soldado que llega a su casilla y gasta 2 de energía lo captura para su bando, y dispara automáticamente al final de cada turno.
- **Botiquines en el mapa:** un soldado que pasa por la casilla recupera 60 de vida. Un solo uso por partida.
- **Cajas de botín programadas:** en un turno determinado de la partida cae una caja en el mapa (salud, munición mejorada, analgésicos o espíritu de equipo).
- **Puertas y portones:** algunas casillas se abren o se cierran con 1 de energía y bloquean la visión y el paso mientras están cerradas.
- **Minas y C4:** los pone el Ingeniero y el Espía, y quedan en el mapa hasta que detonan o alguien las desactiva.

### Tres mapas de la v1

- **Almacén industrial.** 12 × 12, simétrico, con estanterías como cobertura, barriles en los pasillos y una torreta capturable en el centro. El mapa de aprender.
- **Plaza urbana.** 12 × 12, con coches, muros bajos y una baliza en la fuente central. Más abierto, para francotiradores.
- **Base desértica.** 14 × 12, con trincheras, sacos y dos botiquines. Más grande, para partidas de 5 contra 5.

## Progresión y personalización

- **Desbloqueos por jugar.** Las armas, los trajes y los accesorios se desbloquean jugando partidas, no pagando. El arsenal potente cuesta más partidas.
- **Skins iniciales.** Al empezar, cada jugador tiene dos: la Estándar, el soldado genérico sin nada especial, como la estándar de Fortnite, y la de su Nación, con los colores de su bandera y su escudo militar. Las dos son solo aspecto, sin pasivas.
- **Skins con pasivas.** Las skins que lleguen después no serán solo aspecto: cada una dará una pasiva pequeña (por ejemplo, +1 casilla de movimiento en el primer turno, o recargar un turno antes). La skin de nación y la estándar no dan pasivas.
- **Perfiles de soldado.** Cada soldado tiene nombre, rol, arma, accesorio y traje. Se pueden guardar varias escuadras y elegir una antes de cada partida.

## Naciones y Guerra de Naciones (evento de fin de semana)

- **Elegir nación al entrar.** La primera vez que se abre el juego, hay que elegir una nación. La elección es permanente: no se puede cambiar después. El juego lo advierte antes de confirmar.
- **Skin de nación.** Una de las dos skins con las que empieza cada jugador. Los soldados llevan los colores de la bandera de su nación en el uniforme, el casco y el distintivo, con el escudo oficial de sus fuerzas armadas como emblema. Es algo puntual: luego el juego irá sacando más skins.
- **Naciones disponibles.** Solo los países importantes, no todos: España, Estados Unidos, Reino Unido, Francia, Alemania, Rusia, China, Japón, Italia, Brasil, Canadá y Australia. Cada nación se identifica por el escudo oficial de sus fuerzas armadas y por los colores de su bandera. Más naciones llegarán después. Dani puede corregir la lista.
- **Evento de fin de semana: Guerra de Naciones.** Solo se puede jugar sábado y domingo. Son partidas de Captura de baliza en las que tu escuadra lucha por tu nación contra la escuadra de una nación rival. Cada victoria suma un punto a tu nación.
- **Marcador.** En esta primera versión no hay servidor, así que el marcador es local: el juego guarda tus victorias por tu nación en tu propio dispositivo. Un marcador mundial compartido por todos los jugadores exigiría una versión con servidor y queda para después.
- **Fuera del fin de semana.** El modo aparece bloqueado y muestra el tiempo que falta para el sábado.

## Tecnología

- **Juego web en 2D.** HTML5 y Canvas, sin modelado 3D: vista cenital con sprites dibujados, como el original. Se juega desde el navegador, en el ordenador y en la tablet, con ratón o con el dedo.
- **Sin servidor.** La v1 funciona sin conexión: partidas contra la máquina y a dos jugadores en el mismo dispositivo, pasándose el turno. El multijugador en línea queda fuera de la v1.
- **IA enemiga.** La máquina juega con una lógica sencilla: avanza hacia la baliza o hacia el enemigo más cercano, dispara cuando tiene tiro y usa su especial cuando le conviene. Suficiente para aprender y para partidas rápidas.

## Alcance de la v1 (prototipo jugable)

- 1 mapa (Almacén industrial), 2 modos (Eliminación y Captura de baliza), formatos 2v2, 4v4 y 5v5.
- Los 7 roles con sus armas básicas del arsenal y sus especiales, con vida y energía por tipo de cuerpo (Ligero 200/12, Medio 250/14, Pesado 300/18) y coste de movimiento por casilla según el cuerpo.
- Azar con semilla (puntería, crítico, dispersión y caída de daño con la distancia), fuego de respuesta, vigilancia, dirección de mira y cobertura direccional en tres niveles.
- Barriles explosivos, coberturas destructibles, botiquín en el mapa, cajas de botín programadas y torreta capturable.
- Partida contra la IA y a dos jugadores en el mismo dispositivo.
- Selección de escuadra antes de la partida y pantalla de victoria con el resumen.
- Elección de nación permanente al entrar por primera vez entre los 12 países importantes, skins iniciales Estándar y Nación, y modo Guerra de Naciones disponible sábado y domingo.

Después de la v1, por orden: Dominación y Escolta, los otros dos mapas, el resto del arsenal y los desbloqueos, y el equilibrio fino con las partidas de prueba de Dani.

## Decisiones abiertas para Dani

- **Roles.** ¿Se quedan los 7 o sobra alguno? ¿Falta alguno, como un piloto de dron o un francotirador de apoyo?
- **Modos.** ¿Dominación y Escolta en ese orden, o prefiere otro modo antes?
- **Mapas.** ¿Los tres temas propuestos o alguno distinto, como un puerto, una selva o una ciudad en ruinas?
