# Nivel 4: Características de C# 14

Este nivel explora las novedades introducidas en **C# 14** (incluido en .NET 10). Cada laboratorio
muestra una característica concreta, la contrasta con la forma anterior de escribir el mismo
código y explica en qué situaciones resulta útil.

## Prerrequisitos

Haber completado los niveles 1, 2 y 3. Entender propiedades, clases parciales y `Span<T>` básico.

## Laboratorios

| # | Carpeta | Característica C# 14 | ¿Qué había antes? |
|---|---------|----------------------|-------------------|
| 1 | `01-PropiedadesField` | Palabra clave `field` en setters | Backing field manual `private string _nombre;` |
| 2 | `02-AsignacionCondicionalNula` | `?.` en el lado izquierdo de asignación | `if (x != null) x.Prop = valor;` |
| 3 | `03-MiembrosExtension` | Bloque `extension` con propiedades de instancia y estáticas | Solo métodos de extensión estáticos |
| 4 | `04-SpanYConversiones` | Conversión implícita mejorada `T[]` → `ReadOnlySpan<T>` | Cast explícito o sobrecarga adicional |
| 5 | `05-LambdasYNameof` | Lambda con parámetro `out`, `nameof(Tipo<,>)` | No permitido en versiones anteriores |
| 6 | `06-MiembrosParciales` | Constructor parcial y evento parcial | Solo métodos y propiedades parciales |

## Truco de verificación

Para confirmar qué sintaxis depende estrictamente de C# 14, comenta la línea
`<LangVersion>14.0</LangVersion>` en `Directory.Build.props` y observa qué errores aparecen.
Restaura el archivo después.

```xml
<!-- Directory.Build.props -->
<!-- <LangVersion>14.0</LangVersion> -->
```

## Referencias

- [Novedades de C# 14](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-14)
- [Palabra clave field](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/field)
- [Miembros de extensión](https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)
