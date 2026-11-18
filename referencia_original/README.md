# Referencia del juego original — RAD Soldiers

Esta carpeta guarda los archivos del juego original **RAD Soldiers** (Splash Damage / WarChest, 2012) de los que se toma referencia para desarrollar el remake **CSN (Chess Soldier Nation)**.

## Qué es esto

- **El original** es un juego de táctica por turnos para móvil (iOS/Android) que dejó de distribuirse en 2021 y cuyos servidores están apagados. El remake CSN lo reconstruye desde cero, más profesional y complejo, a partir de estos archivos de referencia.
- **Estos archivos son solo referencia.** No forman parte del juego CSN ni se distribuyen con él. Sirven para que quien desarrolla el remake (personas e IAs, como Gemini Studio) pueda consultar cómo funcionaba el original: su código, sus datos y sus decisiones de diseño.
- **El original es propiedad de Splash Damage.** Ni el código ni los datos de esta carpeta son obra propia; se guardan aquí únicamente como material de estudio para el remake, y el remake no copia sus assets (texturas, modelos, audio) ni su código tal cual: los recrea con arte y código propios.

## Contenido

- `decompiled/` — El código fuente del original, descompilado del ensamblado `Assembly-CSharp` (C#, 1.578 archivos `.cs`, más el proyecto `Assembly-CSharp.csproj` y la solución `Assembly-CSharp.sln`). Es la referencia principal para la lógica del juego: turnos, energía, vida, puntería, cobertura, habilidades, IA, modos y mapas. Los nombres con `#Ub...` son espacios de nombres ofuscados del original; se conservan tal cual. **No se incluyen** las librerías compiladas (`.dll` de `lib/`), que son binarios sin valor como referencia de texto.
- `datos/` — Datos de referencia en JSON:
  - `rigs.json` — Los cuatro esqueletos Bip001 del original (22 huesos cada uno), extraídos de la versión web.
  - `prefabs_mapa.json` — Los prefabs de mapa de la versión web (58 entradas; sin ningún prefab de mapa de batalla, que se descargaban del servidor).
  - `materiales.json` — Los materiales de la versión web (498 entradas).
  - `animaciones_alineadas/` — 41 clips de animación del original en JSON, alineados contra la pose de bind (extraídos del IPA de iOS con el decodificador corregido; son la fuente definitiva de animación, no los valores de la versión web).
- `Referencia_original.md` y `Estetica_original.md` — La auditoría del código descompilado y la biblia visual medida del original. **Ya están en `docs/` del repo** (no se duplican aquí); consúltalos allí.

## Qué NO hay aquí (y por qué)

- **El archivo del juego original completo (el `.ipa` de iOS, 77 MB) no está en este repo.** Es el juego comercial completo de Splash Damage; subirlo a un repo público sería distribuir software con copyright. Tampoco ayudaría: una IA no puede leer un binario. El `.ipa` y el código descompilado en bruto se guardan solo en local, como referencia privada.
- **Tampoco hay texturas (PNG), mallas (OBJ) ni mapas binarios (`.bin`).** Son binarios que una IA no puede leer como referencia de texto. Los mapas y el soldado que el remake usa ya están en `assets/` del repo (geometría y datos), y las texturas del original se sustituyen por arte propio para publicar.

## Cómo usar esta referencia

- Para entender una mecánica del original (energía, cobertura, puntería, habilidades), busca en `decompiled/` (el código) y contrasta con `docs/Referencia_original.md`.
- Para la estética (paleta, proporciones, estilo de los mapas y los personajes), usa `docs/Estetica_original.md` y las capturas oficiales del original.
- Para el esqueleto y las animaciones del soldado, usa `datos/rigs.json` y `datos/animaciones_alineadas/`.
- Regla del proyecto: lo que el original hace es **referencia**, no destino. El remake recrea sus sistemas con código y arte propios; los archivos extraídos del original sirven solo como medida y nunca se incorporan tal cual al juego.
