# Nivel 6: Proyectos integradores

Este nivel reúne todo lo aprendido en los cinco niveles anteriores en aplicaciones completas
y funcionales. Cada proyecto integra varios conceptos simultáneamente, igual que ocurre en
el desarrollo real.

## Prerrequisitos

Haber completado los **Niveles 1 al 5** o, al menos, los niveles 1-3 para los dos primeros
proyectos.

## Proyectos

| # | Carpeta | Tecnologías integradas | Tiempo estimado |
|---|---------|------------------------|-----------------|
| 1 | `01-Calculadora` | `decimal.TryParse`, switch expression con `when`, guard clauses | 20 min |
| 2 | `02-GestorTareasJson` | Records, `List<T>`, `System.Text.Json`, `File`, expresión `with` | 30 min |
| 3 | `03-AnalizadorArchivos` | `async/await`, `Task.WhenAll`, LINQ, `Directory`, argumentos CLI | 30 min |

## Cómo aprovechar estos proyectos

1. **Lee el código antes de ejecutarlo.** Intenta predecir la salida.
2. **Ejecuta y compara** con tu predicción.
3. **Extiende el proyecto** con las ampliaciones propuestas en cada README.
4. **Rompe algo** intencionalmente (p. ej. introduce un divisor 0 en la calculadora) y
   observa qué ocurre. Luego arréglalo.

## Consejo de diseño

Estos proyectos usan top-level statements y clases en el mismo archivo para mantener el
foco en los conceptos. En una aplicación real separarías cada clase en su propio archivo
y usarías espacios de nombres. No es deuda técnica; es una decisión de legibilidad para
el tutorial.

## Referencias

- [Aplicaciones de consola en .NET](https://learn.microsoft.com/dotnet/core/tutorials/with-visual-studio)
- [System.Text.Json](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/overview)
- [File I/O en .NET](https://learn.microsoft.com/dotnet/standard/io/)
