# Excepciones

**Nivel:** 2 — Fundamentos  |  **Concepto clave:** `try/catch/finally` y gestión de errores

## ¿Qué aprenderás?

Los errores en tiempo de ejecución (entrada inválida, división por cero, archivo no encontrado)
se representan como **excepciones**. El bloque `try/catch/finally` permite capturarlas y
reaccionar de forma controlada en lugar de dejar que el programa termine abruptamente.

## Conceptos cubiertos

- **`try`** — envuelve el código que puede fallar.
- **`catch (TipoExcepcion)`** — captura un tipo específico de error y gestiona el caso.
- **`finally`** — se ejecuta siempre, haya habido excepción o no; ideal para liberar recursos.
- **Múltiples `catch`** — se evalúan en orden; el primero que coincide se ejecuta. Ordénalos de más específico a más general.
- **`FormatException`** — lanzada por `int.Parse` cuando el texto no es un número válido.
- **`DivideByZeroException`** — lanzada al dividir un entero por 0.

## Análisis del código

```csharp
try
{
    Console.Write("Divisor: ");
    // int.Parse lanza FormatException si la entrada no es un número entero válido.
    int divisor = int.Parse(Console.ReadLine() ?? "0");
    // La división de enteros lanza DivideByZeroException si divisor == 0.
    Console.WriteLine($"10 / {divisor} = {10 / divisor}");
}
catch (FormatException)
{
    // Se captura primero porque es más específica que Exception.
    Console.WriteLine("Debes introducir un número entero.");
}
catch (DivideByZeroException)
{
    Console.WriteLine("No se puede dividir entre cero.");
}
finally
{
    // finally se ejecuta tanto si hubo error como si no.
    // Útil para cerrar archivos, conexiones de red, etc.
    Console.WriteLine("Operación finalizada.");
}
```

> **Regla:** ordena los `catch` de más específico a más general. Si pones `catch (Exception)`
> primero, los bloques más específicos nunca se alcanzarán.

## Ejercicio propuesto

1. Reemplaza `int.Parse` por `int.TryParse` y elimina el bloque `catch (FormatException)`.
   ¿Cuándo es mejor cada enfoque?
2. Crea una excepción personalizada `DivisorNegativoException : Exception` y lánzala
   si el divisor es negativo.
3. Añade un segundo `try/catch` que intente leer un archivo que no existe y capture
   `FileNotFoundException`.

## Referencias

- [Excepciones en C#](https://learn.microsoft.com/dotnet/csharp/fundamentals/exceptions/)
- [try-catch-finally](https://learn.microsoft.com/dotnet/csharp/language-reference/statements/exception-handling-statements)
- [Crear excepciones personalizadas](https://learn.microsoft.com/dotnet/standard/exceptions/how-to-create-user-defined-exceptions)
