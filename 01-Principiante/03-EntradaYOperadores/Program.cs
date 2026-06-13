// Console.Write (sin Line) deja el cursor en la misma línea para que el usuario escriba ahí.
Console.Write("Introduce el primer número: ");
// Console.ReadLine() devuelve string?, que puede ser null si la entrada está redirigida.
// El operador ?? proporciona un valor por defecto ("0") en ese caso.
// int.Parse lanza FormatException si el texto no es un número entero válido.
int primero = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Introduce el segundo número: ");
int segundo = int.Parse(Console.ReadLine() ?? "0");

// Los operadores aritméticos (+, -, *, /) realizan cálculos con los valores introducidos.
// El operador == compara por valor y devuelve bool (true o false).
Console.WriteLine($"Suma: {primero + segundo}");
Console.WriteLine($"Producto: {primero * segundo}");
Console.WriteLine($"¿Son iguales? {primero == segundo}");
