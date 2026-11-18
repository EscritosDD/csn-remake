# Informe de cierre del objetivo (rondas 1–43)

Objetivo: ejecutar el `Plan_director_original_base.md` hasta dejar CSN como
**base reconocible del original**, fase a fase y con verificación en cada una.

Resultado: **F1 y F5 cerradas; F2, F3, F4 y F6 con todo lo planificado hecho y
ampliado**. El juego sigue jugable en `main` en cada commit.

## Qué se ha hecho

### F1 · Catálogo del original
- **42 iconos** de habilidad extraídos de `GameData.assetbundle` a `assets/ui/ability/`.
- `docs/Catalogo_habilidades_original.md` con **las 44** habilidades, su icono,
  su equivalente en CSN y su estado (19 implementadas o equivalentes).

### F2 · Mapas
- **8 Skirmish con geometría real del IPA** + 3 mapas de código, todos con
  props por tema, cielo propio y ambiente.
- **6 misiones de campaña** en **seis tableros propios** (campana01..06,
  layouts únicos y simétricos 180), en 3 capítulos con candados y progreso;
  la 6.ª, El convoy, es escolta 5v5 con dron. Las seis se jugaron en el
  motor (12 partidas sin fallos).
- Props nuevos construidos en código: contenedores, grúas, carretilla
  elevadora, caseta de obra, búnker, cabina de Londres, semáforo, noray,
  máquina expendedora, banco, quiosco, puesto de fruta, montacargas…
- **20 capturas 3D** en `docs/capturas/` (ya retiradas del repo) y tabla en `docs/Capturas_3D.md`.

### F3 · Interfaz
- Portada con el **arte y el logo del RAD Soldiers original** (splash
  decodificado de CgBI) y el 3D en vivo debajo.
- Menú del original (Quick, Online, Challenges, Expansions), **Cuartel** y
  **Armería** con monedas en el chip.
- Campaña por capítulos, **Armería en dos pestañas** (37 armas / 42 habilidades).
- **Cuartel**: 35 personajes agrupados por clase, bios, selector de personaje
  por rol y las cuatro skins.
- **HUD** con retratos, vida/energía, daño previsto, arco de vida, tooltip de
  ficha real del arma, y **resultados** con tabla (vivos/daño/derribos) y la
  escuadra.
- Estética compacta: tarjetas a 2 líneas, mapas y reglas plegables,
  configuración en una línea.

### F4 · Personajes y skins
- **7 modelos por clase del IPA** (malla + rig + textura + escala): Soldier_Light,
  Soldier_Heavy, Agent_Light, Medic, Engineer, Agent_Heavy, Commander.
- **35 personajes**: 17 del original + 18 propios, con bio y voz.
- **Cuatro skins** por escuadra: Estándar (con tinte propio por personaje),
  Camuflaje (patrón procedural), Clase (color del rol) y Nación (bandera,
  cinta de casco, banda de mochila y emblema).
- Diferenciación de bando: hombreras y tinte cálido en el enemigo.

### F5 · Presentación
- **195 clips del original** (208 archivos de audio, 11,8 MB): armas por
  categoría y arma, **voces por personaje** (17 sets) y por rol, ambiente por
  mapa (13 temas), **música de partida** (7 temas) y sonidos de habilidad.
- **Cámara que acompaña al disparo** (2,6 s, amortiguada) y sacudida de
  impactos.

### F6 · Calidad
- `bench/VERIFICAR.ps1`: sintaxis 0, **19 tableros/19** (13 jugables + 6 de
  campaña, todos simétricos y sin solapes), `rules.test` **6/6**,
  `data.test` **6/6** y humo 3D con captura. **Todo OK** en la última pasada.
- Equilibrio medido con n≥30 (`docs/Equilibrio_medido.md`): Dominación
  Almacén **15-15** (n=30), Eliminación S03 21-9 (n=30), Baliza S03 16-14
  (n=30), Escolta 8-2 con dron 8/10 (n=10). Acumulado: ~55-58 % de ventaja
  leve del primero en mover en Eliminación/Baliza y ~55 % del segundo en
  Dominación, sin tocar reglas base.
- `docs/ARQUITECTURA.md` con líneas reales de los bloques y funciones clave.

## Números del repositorio

- **190+ commits** en `main`.
- `assets/soldier`: 21 archivos (7 × malla/rig/textura).
- `assets/audio`: 208 archivos (11,8 MB).
- `assets/ui/ability`: 42 iconos.
- `docs`: 21 documentos + 20 capturas 3D.

## Qué queda (decisiones y trabajo ajeno al código)

1. **Iniciativa alterna** o subir dificultad para corregir el 56 % B de
   Dominación (decisión de diseño del jugador).
2. **Campaña con geometría propia del original**: la geometría de campaña
   venía del servidor y no está en el IPA; habría que reconstruirla o diseñarla.
3. **Arte propio**: sustituir los assets del IPA (modelos, audio, logo) por
   arte propio antes de publicar; son de Splash Damage / WarChest.
4. **`.git` de 185 MB**: si se quiere aligerar, reescribir historia con
   `git filter-repo` (irreversible; requiere permiso).

## Cómo seguir (para la siguiente IA)

1. Leer `docs/ARQUITECTURA.md` (estructura y reglas de edición).
2. Leer `docs/Plan_director_original_base.md` (fases y checklist con pruebas).
3. Ejecutar `powershell -File bench/VERIFICAR.ps1` antes y después de tocar nada.
4. Medir el balance con `bench/harness.js` (n≥30) y capturar con
   `_capture_all.mjs`.
