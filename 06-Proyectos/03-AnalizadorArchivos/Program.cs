string carpeta = args.FirstOrDefault() ?? Directory.GetCurrentDirectory();

// Excluimos archivos generados por el compilador dentro de bin y obj.
string[] archivos = Directory
    .GetFiles(carpeta, "*.cs", SearchOption.AllDirectories)
    .Where(ruta => !ruta.Split(Path.DirectorySeparatorChar)
        .Any(parte => parte is "bin" or "obj"))
    .ToArray();
var resultados = await Task.WhenAll(archivos.Select(AnalizarAsync));

foreach (ResultadoArchivo resultado in resultados.OrderByDescending(r => r.Lineas).Take(10))
    Console.WriteLine($"{resultado.Lineas,4} líneas | {resultado.Ruta}");

Console.WriteLine($"Total: {resultados.Sum(resultado => resultado.Lineas)} líneas");

static async Task<ResultadoArchivo> AnalizarAsync(string ruta)
{
    string contenido = await File.ReadAllTextAsync(ruta);
    int lineas = contenido.Split('\n').Length;
    return new ResultadoArchivo(ruta, lineas);
}

record ResultadoArchivo(string Ruta, int Lineas);
