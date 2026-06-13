# Genéricos

**Nivel:** 3 — Intermedio  |  **Concepto clave:** Parámetro de tipo `T` y constraints

## ¿Qué aprenderás?

Los **genéricos** permiten escribir clases y métodos que funcionan con cualquier tipo sin
perder la seguridad de tipos del compilador. La alternativa sin genéricos sería usar `object`,
lo que requeriría castings manuales y podría generar errores en tiempo de ejecución.

## Conceptos cubiertos

- **Parámetro de tipo `T`** — marcador de posición que el llamador reemplaza con un tipo concreto.
- **Constraint `where T : IComparable<T>`** — garantiza en tiempo de compilación que `T` tiene un método `CompareTo`.
- **Record genérico** — un `record` también puede ser genérico: `record Caja<T>(T Contenido)`.
- **Inferencia de tipo** — cuando llamas a `Maximo(4, 9)` el compilador infiere `T = int` automáticamente.

## Análisis del código

```csharp
var caja = new Caja<string>("mensaje importante"); // T = string
Console.WriteLine(caja.Contenido);
Console.WriteLine($"Máximo: {Maximo(4, 9)}");     // T inferido = int

// Constraint: el compilador garantiza que T tiene CompareTo (necesario para comparar).
// Sin constraint, T podría ser cualquier tipo y no podríamos llamar a CompareTo.
static T Maximo<T>(T primero, T segundo) where T : IComparable<T>
    => primero.CompareTo(segundo) >= 0 ? primero : segundo;

// T representa un tipo que se decide al utilizar la clase o el método.
// Caja<string>, Caja<int>, Caja<decimal>... son todos tipos distintos en tiempo de compilación.
record Caja<T>(T Contenido);
```

| Con `object` (sin genéricos) | Con genéricos `T` |
|---|---|
| `object contenido = "hola"; string s = (string)contenido;` | `Caja<string> caja = new("hola"); string s = caja.Contenido;` |
| El casting puede fallar en tiempo de ejecución | El tipo se verifica en tiempo de compilación |

## Ejercicio propuesto

1. Crea una `Caja<int>` con el valor `42` y muéstrala.
2. Llama a `Maximo` con dos valores `decimal` y luego con dos `string`. Observa cómo
   el compilador infiere el tipo en cada caso.
3. Crea un método genérico `static bool SonIguales<T>(T a, T b) where T : IEquatable<T>`
   que retorne `true` si `a.Equals(b)`.

## Referencias

- [Genéricos en C#](https://learn.microsoft.com/dotnet/csharp/fundamentals/types/generics)
- [Constraints de tipo](https://learn.microsoft.com/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters)
- [IComparable\<T\>](https://learn.microsoft.com/dotnet/api/system.icomparable-1)
