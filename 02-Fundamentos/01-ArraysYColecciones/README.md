# Arrays y colecciones

**Nivel:** 2 — Fundamentos  |  **Concepto clave:** `int[]`, `List<T>` y `Dictionary<K,V>`

## ¿Qué aprenderás?

Casi siempre trabajamos con grupos de datos, no con valores aislados. C# ofrece varias
estructuras según la necesidad: los **arrays** tienen tamaño fijo y acceso rápido por índice;
las **listas** crecen dinámicamente; los **diccionarios** permiten acceder a valores por clave.

## Conceptos cubiertos

- **`int[]`** — array de tamaño fijo; el tamaño no cambia después de crearlo.
- **`List<T>`** — lista genérica de tamaño dinámico; métodos `Add`, `Remove`, `Count`.
- **`Dictionary<K,V>`** — mapa clave→valor; acceso en O(1) promedio.
- **Sintaxis de colección `[...]`** — forma concisa de inicializar arrays y listas (C# 12+).
- **`string.Join(sep, colección)`** — une todos los elementos con un separador.

## Análisis del código

```csharp
int[] notas = [7, 9, 6];                       // array de tamaño fijo (3 elementos)
List<string> alumnos = ["Ana", "Luis"];         // lista dinámica, inicializada con 2 elementos
alumnos.Add("Marta");                           // ahora tiene 3 elementos
Dictionary<string, int> puntuaciones = new() { ["Ana"] = 10, ["Luis"] = 8 };

Console.WriteLine($"Primera nota: {notas[0]}");           // índice 0 = primer elemento
Console.WriteLine($"Alumnos: {string.Join(", ", alumnos)}");
Console.WriteLine($"Puntos de Ana: {puntuaciones["Ana"]}");
```

| Tipo | Tamaño | Acceso | Cuándo usarlo |
|------|--------|--------|---------------|
| `int[]` | Fijo | Por índice `[i]` | Datos de tamaño conocido y constante |
| `List<T>` | Dinámico | Por índice `[i]` | Cuando añades o eliminas elementos |
| `Dictionary<K,V>` | Dinámico | Por clave `["Ana"]` | Búsqueda rápida por identificador |

## Ejercicio propuesto

1. Calcula la media de `notas` usando un bucle `foreach` y muéstrala con un decimal.
2. Añade una tercera entrada al diccionario `puntuaciones` para "Marta" con 9 puntos.
3. Recorre el diccionario con `foreach (var par in puntuaciones)` y muestra `par.Key: par.Value`.

## Referencias

- [Arrays](https://learn.microsoft.com/dotnet/csharp/programming-guide/arrays/)
- [List\<T\>](https://learn.microsoft.com/dotnet/api/system.collections.generic.list-1)
- [Dictionary\<K,V\>](https://learn.microsoft.com/dotnet/api/system.collections.generic.dictionary-2)
- [Expresiones de colección](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/collection-expressions)
