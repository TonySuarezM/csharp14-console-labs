Console.WriteLine(CrearSaludo("Lucía"));
Console.WriteLine($"Área: {CalcularArea(4, 3)}");

// Los métodos agrupan lógica reutilizable y pueden devolver un resultado.
static string CrearSaludo(string nombre) => $"Hola, {nombre}.";
static int CalcularArea(int ancho, int alto) => ancho * alto;
