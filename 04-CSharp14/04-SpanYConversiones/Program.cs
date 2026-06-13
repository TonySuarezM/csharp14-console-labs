int[] numeros = [10, 20, 30, 40];

// C# 14 mejora las conversiones implícitas y la inferencia con Span<T>.
Console.WriteLine($"Suma del array: {Sumar(numeros)}");
Console.WriteLine($"Suma de una sección: {Sumar(numeros.AsSpan(1, 2))}");

static int Sumar(ReadOnlySpan<int> valores)
{
    int total = 0;
    foreach (int valor in valores) total += valor;
    return total;
}
