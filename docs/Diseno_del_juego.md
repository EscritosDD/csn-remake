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
- **Cobertura direccional.** Cada borde de casilla tiene cobertura en cuatro niveles (0–3): sin cobertura, ligera, media y total. Solo la total bloquea la visión. La penalización de puntería por nivel es [0, 12, 25, 40] %. La protección depende del lado desde el que disparan, no es igual en todas las direcciones.
- **Cajas de botín programadas.** En un turno determinado de la partida cae una caja en el mapa (salud, munición mejorada, analgésicos o espíritu de equipo). Dan un motivo para moverse a mitad de partida.
- **Empujón.** Las armas pesadas y las explosiones pueden empujar al objetivo una casilla.

## Roles (7)

La vida y la energía van por tipo de cuerpo, como en el original: Ligero 200 de vida y 12 de energía, Medio 250 y 14, Pesado 300 y 18. Moverse cuesta 1 de energía por casilla al Ligero, 2 al Medio y 3 al Pesado.

| Rol | Cuerpo | Vida | Energía | Armas principales | Especial |
|---|---|---|---|---|---|
| Francotirador | Ligero | 200 | 12 | M40, M24, M110, SVD, AW50, Barrett M82, Mk 14 EBR, PSG-1 | Tiro certero: un disparo con daño ×1,5 si el objetivo no se ha movido este turno |
| Artillero | Pesado | 300 | 18 | M249 SAW, M240B, PKM, MG3, RPG-7, AT4, M72 LAW, Browning M2, Mk 19 | Fuego de supresión: el enemigo alcanzado pierde 2 de energía en su siguiente turno |
| Espía | Ligero | 200 | 12 | MP7, MP5, P90, UMP45, KRISS Vector | Invisibilidad: 1 turno sin poder ser objetivo de disparos, se rompe al disparar |
| Médico | Medio | 250 | 14 | M4A1, AK-12, HK416 | Curar 80 de vida a un aliado adyacente (2 usos); reanimar a un caído adyacente con 80 de vida (1 uso) |
| Ingeniero | Medio | 250 | 14 | Remington 870, Benelli M4, M4A1, M203, Mossberg 500 | Torreta M2 (120 PV) y 2 minas Claymore M18A1 (60 de daño) |
| Comando | Medio | 250 | 14 | M4A1, AK-12, HK416, FN SCAR-L, M32 MGL, G36C, FAMAS | Granada de fragmentación extra: lleva una M67 más que los demás |
| Capitán | Medio | 250 | 14 | M4A1, FN SCAR-L, Desert Eagle | Orden de mando: un aliado recupera 3 de energía en este turno (1 uso por turno) |

El Francotirador y el Espía se mueven igual: ambos son Ligeros y llegan a 12 casillas por turno. El Artillero es el más lento y el que más daño hace en área.

## Arsenal

La base completa está en [Arsenal_real.md](Arsenal_real.md): 57 entradas en 11 categorías, 37 armas del catálogo `WEAPONS` del código y 20 gadgets, desplegables y equipo táctico que no están en ese catálogo. Resumen por categoría (daños en la escala del código, ×0,4 respecto a la propuesta original):

- **Fusiles de asalto y carabinas:** M4A1, AK-12, HK416, FN SCAR-L, G36C, FAMAS. Daño 27–30, alcance 6 casillas, coste 2–3 de energía.
- **Subfusiles:** MP5, MP7, P90, UMP45, KRISS Vector. Daño 18–26, alcance 3–4 casillas, coste 1–2 de energía. Armas del Espía.
- **Ametralladoras:** M249 SAW, M240B, PKM, MG3, Browning M2. Daño 24–38, alcance 6–7 casillas, coste 3–4 de energía, con supresión. Armas del Artillero.
- **Francotiradores:** M40, AW50, M24, M110, SVD, Barrett M82, Mk 14 EBR, PSG-1. Daño 45–100, alcance 8–10 casillas, coste 3–5 de energía. Los de cerrojo disparan una vez por turno; los semiautomáticos, dos.
- **Escopetas y pistolas:** Remington 870, Benelli M4, Mossberg 500; M9, Glock 17, M1911, Desert Eagle. La pistola es el arma secundaria de todos: daño 22–40, coste 1–2 de energía.
- **Lanzacohetes:** RPG-7 (recargable), AT4 y M72 LAW (un solo uso por partida). Daño 55–85.
- **Lanzagranadas:** M203 (acoplado al fusil), M32 (tambor de 6), Mk 19 (emplazamiento). Daño 40–85 en área.
- **Morteros:** M224 (60 mm) y M252 (81 mm). No están en el código: fuego indirecto de diseño, a cualquier casilla del mapa, con 1 turno de espera y marcador visible para el enemigo.
- **Granadas de mano:** M67 de fragmentación, M18 de humo, M84 aturdidora, AN-M14 de termita, Mk3A2 de concusión. Consumibles, no están en el catálogo `WEAPONS` del código; se lanzan a 2–3 casillas.
- **Torretas:** solo la M2 Browning está en el juego (la despliega el Ingeniero; 120 PV). Mk 19, M134 Minigun, DShK y KPV son diseño, no están en el código.
- **Equipo táctico:** mina Claymore M18 (en el código, 60 de daño), C4, dron RQ-11 Raven, botiquín IFAK, escudo balístico, mira térmica AN/PAS-13, silenciador. Gadgets, no están en el catálogo `WEAPONS` del código.

## Modos de juego

- **Eliminación.** Gana quien elimine a toda la escuadra enemiga. El modo clásico.
- **Captura de baliza.** Gana quien elimine al rival o aguante 5 turnos seguidos con la zona central sin enemigos dentro. El modo del original.
- **Dominación.** Tres zonas en el mapa. Cada turno que un bando aguanta una zona suma 1 punto; gana quien llegue a 10 puntos o elimine al rival.
- **Escolta.** Un dron averiado debe llegar a la zona de extracción y quedarse 1 turno. El bando que lo escolta gana si lo logra; el otro, si destruye el dron o elimina a los escoltas.

La v1 trae Eliminación, Captura de baliza, Dominación y Escolta.

## Formatos de escuadra

- **2 contra 2.** Partidas rápidas, de pocos turnos. Para aprender y para jugar en ratos cortos.
- **4 contra 4.** El formato principal del remake, más táctico que el 5 contra 5 del original y más manejable en una tablet.
- **5 contra 5.** El formato del original, para quien quiera la escuadra completa.

Cada jugador elige sus soldados y sus armas antes de la partida. No hay puntos de escuadra (esa economía no existe en el código): la moneda del juego son las monedas.

## Mapas con elementos accionables

El mapa ya no es solo un tablero con coberturas: tiene cosas que se pueden usar, romper o capturar.

- **Coberturas:** muros bajos, sacos de arena, cajas y coches. Cada borde de casilla tiene cobertura en cuatro niveles (0–3) y solo la total bloquea la visión; la protección depende del lado desde el que disparan. Los sacos y las cajas se pueden destruir; los muros, no.
- **Barriles explosivos:** al recibir un disparo explotan y hacen 100 de daño en las casillas adyacentes. Están colocados donde duelen.
- **Torreta capturable:** en el centro de algunos mapas hay un emplazamiento vacío. El primer soldado que llega a su casilla y gasta 2 de energía lo captura para su bando, y dispara automáticamente al final de cada turno.
- **Botiquines en el mapa:** un soldado que pasa por la casilla recupera 60 de vida. Un solo uso por partida.
- **Cajas de botín programadas:** en un turno determinado de la partida cae una caja en el mapa (salud, munición mejorada, analgésicos o espíritu de equipo).
- **Puertas y portones:** algunas casillas se abren o se cierran con 1 de energía y bloquean la visión y el paso mientras están cerradas.
- **Minas y C4:** los pone el Ingeniero y el Espía, y quedan en el mapa hasta que detonan o alguien las desactiva.

### Mapas

El juego tiene 19 entradas en `MAP_DEFS` (`src/data/maps.js`): los 8 Skirmish reales del IPA (`skirmish03`–`06` y `08`–`11`, con geometría `.bin` 1:1), los mapas propios `almacen` y `patio`, los mapas de campaña `skirmish01`, `skirmish02` y `skirmish07`, y las 6 misiones de `campana01`–`campana06`. No hay «Plaza urbana» ni «Base desértica»: esos nombres eran de un diseño anterior y no existen en el código.

## Progresión y personalización

- **Desbloqueos por jugar.** Las armas, los trajes y los accesorios se desbloquean jugando partidas, no pagando. El arsenal potente cuesta más partidas.
- **Skins iniciales.** Al empezar, cada jugador tiene dos: la Estándar, el soldado genérico sin nada especial, como la estándar de Fortnite, y la de su Nación, con los colores de su bandera y su escudo militar. Las dos son solo aspecto, sin pasivas.
- **Skins sin pasivas.** Todas las skins son solo aspecto, sin pasivas: la estándar, la de nación y las que lleguen después no dan ninguna ventaja (`src/data/nations.js`: «Sin pasiva»).
- **Perfiles de soldado.** Cada soldado tiene nombre, rol, arma, accesorio y traje. Se pueden guardar varias escuadras y elegir una antes de cada partida.

## Naciones y Guerra de Naciones (evento de fin de semana)

- **Elegir nación al entrar.** La primera vez que se abre el juego, hay que elegir una nación. La elección es permanente: no se puede cambiar después. El juego lo advierte antes de confirmar.
- **Skin de nación.** Una de las dos skins con las que empieza cada jugador. Los soldados llevan los colores de la bandera de su nación en el uniforme, el casco y el distintivo, con el escudo oficial de sus fuerzas armadas como emblema. Es algo puntual: luego el juego irá sacando más skins.
- **Naciones disponibles.** Solo los países importantes, no todos: España, Estados Unidos, Reino Unido, Francia, Alemania, Rusia, China, Japón, Italia, Brasil, Canadá y Australia. Cada nación se identifica por el escudo oficial de sus fuerzas armadas y por los colores de su bandera. Más naciones llegarán después. Dani puede corregir la lista.
- **Evento de fin de semana: Guerra de Naciones.** Solo se puede jugar sábado y domingo. Son partidas de Captura de baliza en las que tu escuadra lucha por tu nación contra la escuadra de una nación rival. Cada victoria suma un punto a tu nación.
- **Marcador.** En esta primera versión no hay servidor, así que el marcador es local: el juego guarda tus victorias por tu nación en tu propio dispositivo. Un marcador mundial compartido por todos los jugadores exigiría una versión con servidor y queda para después.
- **Fuera del fin de semana.** El modo aparece bloqueado y muestra el tiempo que falta para el sábado.

## Tecnología

- **Juego web en 3D.** HTML5 y Three.js: tablero 3D con volumen, soldados con mallas y rigs del original y cámara táctica. Se juega desde el navegador, en el ordenador y en la tablet, con ratón o con el dedo. Hay una vista 2D alternativa (Canvas) por si el 3D falla o para móviles.
- **Sin servidor.** La v1 funciona sin conexión: partidas contra la máquina y a dos jugadores en el mismo dispositivo, pasándose el turno. El multijugador en línea queda fuera de la v1.
- **IA enemiga.** La máquina juega con una lógica sencilla: avanza hacia la baliza o hacia el enemigo más cercano, dispara cuando tiene tiro y usa su especial cuando le conviene. Suficiente para aprender y para partidas rápidas.

## Alcance de la v1 (prototipo jugable)

- 19 mapas en `MAP_DEFS`, 4 modos (Eliminación, Captura de baliza, Dominación y Escolta), formatos 2v2, 4v4 y 5v5.
- Los 7 roles con sus armas básicas del arsenal y sus especiales, con vida y energía por tipo de cuerpo (Ligero 200/12, Medio 250/14, Pesado 300/18) y coste de movimiento por casilla según el cuerpo.
- Azar con semilla (puntería, crítico, dispersión y caída de daño con la distancia), fuego de respuesta, vigilancia, dirección de mira y cobertura direccional en cuatro niveles (0–3).
- Barriles explosivos, coberturas destructibles, botiquín en el mapa, cajas de botín programadas y torreta capturable.
- Partida contra la IA y a dos jugadores en el mismo dispositivo.
- Selección de escuadra antes de la partida y pantalla de victoria con el resumen.
- Elección de nación permanente al entrar por primera vez entre los 12 países importantes, skins iniciales Estándar y Nación, y modo Guerra de Naciones disponible sábado y domingo.

Después de la v1, por orden: el resto del arsenal y los desbloqueos, y el equilibrio fino con las partidas de prueba de Dani.

## Decisiones abiertas para Dani

- **Roles.** ¿Se quedan los 7 o sobra alguno? ¿Falta alguno, como un piloto de dron o un francotirador de apoyo?
- **Modos.** Dominación y Escolta ya están implementadas. ¿Se pulen los cuatro modos que hay o prefiere otro modo nuevo antes?
- **Mapas.** Los 19 de `MAP_DEFS` ya están. ¿Alguno distinto, como un puerto, una selva o una ciudad en ruinas?
