Console.WriteLine("Calculadora: escribe una operación como 8 * 3");
// Split con RemoveEmptyEntries elimina los segmentos vacíos si el usuario escribe espacios extra.
string[] partes = (Console.ReadLine() ?? "8 * 3").Split(' ', StringSplitOptions.RemoveEmptyEntries);

// Guard clause: sale temprano si el formato no es correcto, evitando anidamiento profundo.
// decimal.TryParse es más seguro que decimal.Parse: devuelve false en lugar de lanzar excepción.
if (partes.Length != 3 ||
    !decimal.TryParse(partes[0], out decimal izquierda) ||
    !decimal.TryParse(partes[2], out decimal derecha))
{
    Console.WriteLine("Formato incorrecto.");
    return;
}

// El patrón switch concentra la selección y validación de operaciones.
// La cláusula "when derecha != 0" es un guard: la división solo aplica si el divisor no es cero.
decimal? resultado = partes[1] switch
{
    "+" => izquierda + derecha,
    "-" => izquierda - derecha,
    "*" => izquierda * derecha,
    "/" when derecha != 0 => izquierda / derecha,
    _   => null  // operador desconocido o división por cero
};

Console.WriteLine(resultado is null ? "Operación no válida." : $"Resultado: {resultado}");
