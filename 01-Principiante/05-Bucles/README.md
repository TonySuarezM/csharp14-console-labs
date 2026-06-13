# Bucles

**Nivel:** 1 — Principiante  |  **Concepto clave:** Repetición con `for` y `foreach`

## ¿Qué aprenderás?

Los bucles permiten ejecutar un bloque de código varias veces. `for` es ideal cuando
sabemos cuántas iteraciones necesitamos; `foreach` es la opción preferida para recorrer
todos los elementos de una colección sin gestionar índices manualmente.

## Conceptos cubiertos

- **`for (inicio; condición; paso)`** — repite mientras la condición sea verdadera; útil cuando se conoce el número de iteraciones.
- **`foreach (tipo elemento in colección)`** — recorre cada elemento de un array, lista u otra colección.
- **Array literal `[...]`** — sintaxis de C# 12+ para crear arrays de forma concisa.
- **`numero++`** — incremento postfijo; equivale a `numero = numero + 1`.

## Análisis del código

```csharp
// for resulta útil cuando conocemos el número de repeticiones.
// Estructura: for (inicialización; condición; incremento)
for (int numero = 1; numero <= 5; numero++)
    Console.WriteLine($"Cuadrado de {numero}: {numero * numero}");

string[] frutas = ["manzana", "pera", "naranja"]; // array literal (C# 12+)

// foreach recorre cada elemento de una colección sin necesidad de índice.
foreach (string fruta in frutas)
    Console.WriteLine(fruta);
```

| Bucle | Cuándo es más adecuado |
|-------|------------------------|
| `for` | Número de iteraciones conocido, necesitas el índice, incrementos personalizados |
| `foreach` | Recorrer todos los elementos de una colección, sin modificar la colección |

> Existe también `while` (condición al inicio) y `do/while` (condición al final). Úsalos
> cuando el número de iteraciones dependa de la entrada del usuario u otra condición dinámica.

## Ejercicio propuesto

1. Usa `for` para imprimir la tabla de multiplicar del 7 (del 7×1 al 7×10).
2. Crea un array de tres ciudades y recórrelo con `foreach` para mostrarlas en mayúsculas
   (`ciudad.ToUpperInvariant()`).
3. Escribe un bucle `while` que siga pidiendo un número al usuario hasta que introduzca 0.

## Referencias

- [Instrucciones de iteración](https://learn.microsoft.com/dotnet/csharp/language-reference/statements/iteration-statements)
- [Arrays en C#](https://learn.microsoft.com/dotnet/csharp/programming-guide/arrays/)
