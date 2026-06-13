// Los métodos se pueden usar antes de declararlos en top-level statements ("hoisting").
Console.WriteLine(CrearSaludo("Lucía"));
Console.WriteLine($"Área: {CalcularArea(4, 3)}");

// Los métodos agrupan lógica reutilizable y pueden devolver un resultado.
// En top-level statements los métodos locales deben ser static: no hay instancia de clase.
// El cuerpo de expresión "=>" es azúcar sintáctico de "{ return ...; }" para una sola línea.
static string CrearSaludo(string nombre) => $"Hola, {nombre}.";
static int CalcularArea(int ancho, int alto) => ancho * alto;
