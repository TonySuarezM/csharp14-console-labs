# `Span<T>` y conversiones implícitas (C# 14)

**Nivel:** 4 — C# 14  |  **Concepto clave:** `ReadOnlySpan<T>`, slicing sin copias y conversión implícita mejorada

## ¿Qué aprenderás?

`Span<T>` y `ReadOnlySpan<T>` son tipos de alto rendimiento que representan una **ventana** sobre
un segmento de memoria contigua (un array, una cadena, memoria de pila) sin copiar los datos.
C# 14 mejora las conversiones implícitas de `T[]` a `ReadOnlySpan<T>`, reduciendo la necesidad
de castings explícitos.

## ¿Por qué es eficiente?

```
int[] numeros = [10, 20, 30, 40];         // array en el heap

// Sumar(numeros): en C# 14, la conversión int[] → ReadOnlySpan<int> es implícita.
// No se copia el array; Span es solo un puntero + longitud.
Sumar(numeros);

// AsSpan(1, 2): "ventana" sobre los elementos en posiciones 1 y 2 (20, 30).
// Tampoco copia nada; simplemente ajusta inicio y longitud.
Sumar(numeros.AsSpan(1, 2));
```

## Análisis del código

```csharp
int[] numeros = [10, 20, 30, 40];

// C# 14 mejora las conversiones implícitas y la inferencia con Span<T>.
// La llamada Sumar(numeros) convierte int[] → ReadOnlySpan<int> sin cast explícito.
Console.WriteLine($"Suma del array: {Sumar(numeros)}");
// AsSpan(inicio, longitud): ventana sin copia sobre elementos 1 y 2 → {20, 30}
Console.WriteLine($"Suma de una sección: {Sumar(numeros.AsSpan(1, 2))}");

static int Sumar(ReadOnlySpan<int> valores)
{
    int total = 0;
    // foreach sobre ReadOnlySpan no genera asignaciones en heap
    foreach (int valor in valores) total += valor;
    return total;
}
```

| Tipo | Mutabilidad | Uso típico |
|------|-------------|------------|
| `Span<T>` | Lectura y escritura | Transformar datos sin copias |
| `ReadOnlySpan<T>` | Solo lectura | Consumir datos sin copias |
| `Memory<T>` | Lectura y escritura | Como `Span` pero puede usarse en métodos `async` |

## Ejercicio propuesto

1. Crea un método `static int Maximo(ReadOnlySpan<int> valores)` que retorne el valor máximo.
2. Llámalo con el array completo y con una sección `numeros.AsSpan(0, 3)`.
3. Prueba a pasar `stackalloc int[] { 1, 2, 3 }` al método y observa que también funciona
   (memoria en la pila, sin asignación en heap).

## Referencias

- [Span\<T\>](https://learn.microsoft.com/dotnet/api/system.span-1)
- [Guía de uso de Span\<T\>](https://learn.microsoft.com/dotnet/standard/memory-and-spans/memory-t-usage-guidelines)
- [Novedades de C# 14](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-14)
