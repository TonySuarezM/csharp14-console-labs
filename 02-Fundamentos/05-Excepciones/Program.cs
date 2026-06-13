try
{
    Console.Write("Divisor: ");
    // int.Parse lanza FormatException si la entrada no es un número entero válido.
    int divisor = int.Parse(Console.ReadLine() ?? "0");
    // La división de enteros lanza DivideByZeroException si divisor == 0.
    Console.WriteLine($"10 / {divisor} = {10 / divisor}");
}
// Los bloques catch se evalúan en orden: el primero que coincide se ejecuta.
// Ordénalos siempre de más específico a más general para no ocultar información.
catch (FormatException)
{
    Console.WriteLine("Debes introducir un número entero.");
}
catch (DivideByZeroException)
{
    Console.WriteLine("No se puede dividir entre cero.");
}
finally
{
    // finally se ejecuta tanto si hubo error como si no.
    // Es el lugar adecuado para liberar recursos (archivos, conexiones, etc.).
    Console.WriteLine("Operación finalizada.");
}
