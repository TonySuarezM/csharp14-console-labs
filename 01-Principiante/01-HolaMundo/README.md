# Hola mundo

**Nivel:** 1 — Principiante  |  **Concepto clave:** Top-level statements y salida por consola

## ¿Qué aprenderás?

Desde .NET 6, los programas de C# pueden prescindir de la clase `Program` y el método
`static void Main`. Basta con escribir instrucciones directamente en el archivo `Program.cs`;
el compilador genera el punto de entrada automáticamente. Esto se llama **top-level statements**
y hace que los programas pequeños sean mucho más limpios.

## Conceptos cubiertos

- **`Console.WriteLine(texto)`** — escribe `texto` en la consola y añade un salto de línea al final.
- **`Console.Write(texto)`** — escribe `texto` sin salto de línea; el cursor queda al final.
- **Top-level statements** — permiten escribir código ejecutable directamente sin clase ni `Main`.

## Análisis del código

```csharp
// Console.WriteLine muestra texto y añade un salto de línea al final.
Console.WriteLine("¡Hola, C# 14!");
Console.WriteLine("Este es nuestro primer programa de consola.");
```

| Línea | Qué hace |
|-------|----------|
| `Console.WriteLine("¡Hola, C# 14!")` | Imprime el saludo y mueve el cursor a la línea siguiente |
| `Console.WriteLine("Este es nuestro...")` | Imprime la segunda frase también con salto de línea |

> `Console` es una clase estática del espacio de nombres `System` (incluido automáticamente
> en .NET 6+). No es necesario escribir `using System;`.

## Ejercicio propuesto

1. Muestra tu nombre en la primera línea.
2. En la segunda línea muestra la fecha y hora actual usando `DateTime.Now`.
   - Pista: `Console.WriteLine(DateTime.Now);`
3. Prueba a cambiar `Console.WriteLine` por `Console.Write` en la primera línea y
   observa cómo cambia la salida.

## Referencias

- [Console.WriteLine](https://learn.microsoft.com/dotnet/api/system.console.writeline)
- [Top-level statements](https://learn.microsoft.com/dotnet/csharp/fundamentals/program-structure/top-level-statements)
