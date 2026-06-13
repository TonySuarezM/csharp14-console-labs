Console.Write("Introduce el primer número: ");
int primero = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Introduce el segundo número: ");
int segundo = int.Parse(Console.ReadLine() ?? "0");

// Los operadores realizan cálculos con los valores introducidos.
Console.WriteLine($"Suma: {primero + segundo}");
Console.WriteLine($"Producto: {primero * segundo}");
Console.WriteLine($"¿Son iguales? {primero == segundo}");
