// args.FirstOrDefault() toma el primer argumento de la línea de comandos.
// Si no se proporciona ninguno, usa el directorio actual.
// Ejecución con argumento: dotnet run -- C:\source\mi-proyecto
string carpeta = args.FirstOrDefault() ?? Directory.GetCurrentDirectory();

// Excluimos archivos generados por el compilador dentro de bin y obj.
// Split(Path.DirectorySeparatorChar) divide la ruta en segmentos, compatible con Windows y Linux.
string[] archivos = Directory
    .GetFiles(carpeta, "*.cs", SearchOption.AllDirectories)
    .Where(ruta => !ruta.Split(Path.DirectorySeparatorChar)
        .Any(parte => parte is "bin" or "obj"))
    .ToArray();
// Task.WhenAll lanza todas las lecturas en paralelo y espera a que terminen todas.
// Más eficiente que await secuencial: el tiempo total ~ tiempo del archivo más lento.
var resultados = await Task.WhenAll(archivos.Select(AnalizarAsync));

// OrderByDescending + Take(10): patrón "top-N", muestra los 10 archivos más extensos.
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
