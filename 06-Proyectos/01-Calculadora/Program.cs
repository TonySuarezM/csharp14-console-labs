Console.WriteLine("Calculadora: escribe una operación como 8 * 3");
string[] partes = (Console.ReadLine() ?? "8 * 3").Split(' ', StringSplitOptions.RemoveEmptyEntries);

if (partes.Length != 3 ||
    !decimal.TryParse(partes[0], out decimal izquierda) ||
    !decimal.TryParse(partes[2], out decimal derecha))
{
    Console.WriteLine("Formato incorrecto.");
    return;
}

// El patrón switch concentra la selección y validación de operaciones.
decimal? resultado = partes[1] switch
{
    "+" => izquierda + derecha,
    "-" => izquierda - derecha,
    "*" => izquierda * derecha,
    "/" when derecha != 0 => izquierda / derecha,
    _ => null
};

Console.WriteLine(resultado is null ? "Operación no válida." : $"Resultado: {resultado}");
