# Nivel 5: Avanzado

Este nivel cubre tres patrones que se utilizan habitualmente en aplicaciones de producción:
reflexión y atributos para añadir metadatos al código y consultarlos en tiempo de ejecución,
paralelismo con cancelación cooperativa para aprovechar múltiples núcleos sin bloquear, e
inyección de dependencias para desacoplar componentes y facilitar las pruebas unitarias.

> **Nota:** Estos son patrones reales de producción. Si algo no queda claro a la primera,
> es normal. Vuelve a los niveles anteriores si necesitas repasar clases, interfaces o `async/await`.

## Prerrequisitos

Haber completado los **Niveles 1, 2 y 3**. En particular:
- Entender interfaces y clases abstractas (`02-Fundamentos/04-HerenciaEInterfaces`).
- Conocer `async/await` y `Task<T>` (`03-Intermedio/06-AsyncYNullable`).

## Laboratorios

| # | Carpeta | Concepto clave | Tiempo estimado |
|---|---------|----------------|-----------------|
| 1 | `01-ReflexionYAtributos` | `Attribute`, `Type`, `MethodInfo`, `GetCustomAttribute<T>` | 20 min |
| 2 | `02-ParalelismoYCancelacion` | `Parallel.ForEachAsync`, `CancellationTokenSource` | 20 min |
| 3 | `03-InyeccionDependencias` | Principio DIP, constructor injection, `interface` como contrato | 20 min |

## ¿Por qué estos temas son importantes?

- **Reflexión y atributos**: marcos como ASP.NET Core, Entity Framework y xUnit los usan
  extensamente para descubrir controladores, mapear columnas y encontrar métodos de test.
- **Paralelismo y cancelación**: las aplicaciones modernas deben responder a cancelaciones
  (botón "Cancelar", timeout de HTTP) sin terminar abruptamente.
- **Inyección de dependencias**: es la base del contenedor de DI de .NET (`IServiceCollection`),
  presente en todas las plantillas de proyectos web y de trabajo en segundo plano.

## Objetivo global del nivel

Crear un mini-framework de comandos que:
- Descubra clases marcadas con un atributo `[Comando("nombre")]` mediante reflexión.
- Ejecute los comandos en paralelo con soporte de cancelación.
- Obtenga sus dependencias (p. ej. un logger) a través de inyección por constructor.

## Referencias

- [Reflexión en .NET](https://learn.microsoft.com/dotnet/fundamentals/reflection/reflection)
- [Parallel.ForEachAsync](https://learn.microsoft.com/dotnet/api/system.threading.tasks.parallel.foreachasync)
- [Inyección de dependencias en .NET](https://learn.microsoft.com/dotnet/core/extensions/dependency-injection)
