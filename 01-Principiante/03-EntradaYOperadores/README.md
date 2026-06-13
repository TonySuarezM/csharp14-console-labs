# Entrada y operadores

**Nivel:** 1 — Principiante  |  **Concepto clave:** Lectura de consola, conversión de tipos y operadores

## ¿Qué aprenderás?

Los programas útiles necesitan datos del usuario. `Console.ReadLine()` captura una línea de
texto, pero devuelve `string?` (puede ser `null`). Para trabajar con números hay que
**convertir** ese texto: `int.Parse()` lo transforma en `int` o lanza una excepción si no es
un número válido.

## Conceptos cubiertos

- **`Console.ReadLine()`** — lee una línea de la entrada estándar; devuelve `string?`.
- **`int.Parse(texto)`** — convierte un `string` a `int`; lanza `FormatException` si falla.
- **Operador `??`** — "null-coalescing": devuelve el valor de la derecha si el de la izquierda es `null`.
- **Operadores aritméticos** — `+`, `-`, `*`, `/`, `%` (resto).
- **Operador relacional `==`** — compara dos valores y devuelve `bool`.

## Análisis del código

```csharp
Console.Write("Introduce el primer número: ");
int primero = int.Parse(Console.ReadLine() ?? "0");
// Console.ReadLine() puede devolver null (p. ej. si la entrada está redirigida).
// ?? "0" asegura que Parse reciba al menos "0" en lugar de null.

Console.Write("Introduce el segundo número: ");
int segundo = int.Parse(Console.ReadLine() ?? "0");

// Los operadores realizan cálculos con los valores introducidos.
Console.WriteLine($"Suma: {primero + segundo}");
Console.WriteLine($"Producto: {primero * segundo}");
Console.WriteLine($"¿Son iguales? {primero == segundo}");
```

> `Console.Write` (sin `Line`) muestra el texto pero deja el cursor al final, de modo que
> el usuario escribe en la misma línea que el mensaje.

## Ejercicio propuesto

1. Añade la resta y la división al resultado. Para la división usa `decimal` para no perder decimales.
2. Calcula el IMC: pide peso (kg) y altura (m) y muestra `peso / (altura * altura)`.
   - Pista: usa `double.Parse` para los valores con decimales.
3. Usa `int.TryParse` en lugar de `int.Parse` para que el programa no se caiga si el usuario
   introduce letras. Muestra "Entrada inválida" en ese caso.

## Referencias

- [Console.ReadLine](https://learn.microsoft.com/dotnet/api/system.console.readline)
- [int.Parse y int.TryParse](https://learn.microsoft.com/dotnet/api/system.int32.parse)
- [Operadores en C#](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/)
