# Lambdas con `out` y `nameof` con genéricos abiertos (C# 14)

**Nivel:** 4 — C# 14  |  **Concepto clave:** Lambda con parámetro `out` y `nameof(Tipo<,>)`

## ¿Qué aprenderás?

C# 14 amplía dos áreas del lenguaje:

1. Las **lambdas** ahora pueden tener parámetros `out`, lo que permite asignarles directamente
   métodos como `int.TryParse` que usan el patrón clásico `(texto, out resultado)`.
2. **`nameof`** ahora acepta tipos genéricos **abiertos** (`Dictionary<,>`), devolviendo el
   nombre del tipo sin los argumentos. Útil para logging y mensajes de error sin hardcodear strings.

## El problema antes de C# 14

```csharp
// ANTES: no era posible asignar una lambda con "out" a un delegate personalizado
// Había que usar un método estático completo o un wrapper explícito.
delegate bool TryParse<T>(string texto, out T resultado);
// TryParse<int> convertir = (texto, out resultado) => ...; // ← ERROR antes de C# 14
```

## La solución en C# 14

```csharp
// C# 14 permite lambdas con parámetros out en delegates personalizados.
TryParse<int> convertir = (texto, out resultado) => int.TryParse(texto, out resultado);
```

## Análisis del código

```csharp
TryParse<int> convertir = (texto, out resultado) => int.TryParse(texto, out resultado);

if (convertir("42", out int numero))
    Console.WriteLine($"Resultado: {numero}");

// Desde C# 14, nameof acepta tipos genéricos abiertos.
// Devuelve "Dictionary" sin los argumentos de tipo.
// Útil para mensajes de error, logs, y assertions: sin hardcodear el nombre del tipo.
Console.WriteLine($"Nombre del tipo: {nameof(Dictionary<,>)}");

delegate bool TryParse<T>(string texto, out T resultado);
```

| Expresión | Resultado | Disponible desde |
|---|---|---|
| `nameof(List<>)` | `"List"` | C# 14 |
| `nameof(Dictionary<,>)` | `"Dictionary"` | C# 14 |
| `nameof(string)` | `"String"` | C# 6 |

## Ejercicio propuesto

1. Crea un `TryParse<double>` que use `double.TryParse` y pruébalo con `"3.14"`.
2. Crea un `TryParse<decimal>` que use `decimal.TryParse` y pruébalo con `"19.95"`.
3. Usa `nameof(List<>)` y `nameof(HashSet<>)` en un mensaje de log y observa los resultados.

## Referencias

- [Novedades de C# 14](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-14)
- [Expresiones lambda](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/lambda-expressions)
- [nameof](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/nameof)
