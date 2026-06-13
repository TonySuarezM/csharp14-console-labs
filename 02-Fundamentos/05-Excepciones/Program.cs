try
{
    Console.Write("Divisor: ");
    int divisor = int.Parse(Console.ReadLine() ?? "0");
    Console.WriteLine($"10 / {divisor} = {10 / divisor}");
}
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
    Console.WriteLine("Operación finalizada.");
}
