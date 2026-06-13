int[] numeros = [10, 20, 30, 40];

// C# 14 mejora las conversiones implícitas y la inferencia con Span<T>.
// La conversión int[] -> ReadOnlySpan<int> es ahora implícita: no hace falta cast explícito.
// ReadOnlySpan<T> es una "ventana" sobre la memoria del array: no copia datos.
Console.WriteLine($"Suma del array: {Sumar(numeros)}");
// AsSpan(inicio, longitud): segmento sin copia -> elementos en posiciones 1 y 2 (20 y 30).
Console.WriteLine($"Suma de una sección: {Sumar(numeros.AsSpan(1, 2))}");

static int Sumar(ReadOnlySpan<int> valores)
{
    int total = 0;
    // foreach sobre ReadOnlySpan no genera asignaciones en heap: es altamente eficiente.
    foreach (int valor in valores) total += valor;
    return total;
}
