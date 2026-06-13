# Proyecto: Analizador de archivos

**Nivel:** 6 — Proyectos integradores

## ¿Qué integra este proyecto?

Un analizador de código fuente que recorre un directorio de forma recursiva, lee todos los
archivos `.cs` en paralelo y muestra los 10 más extensos ordenados por número de líneas.

## Tecnologías integradas

| Concepto | Dónde se usa |
|----------|-------------|
| Argumento CLI `args` | Carpeta de análisis configurable desde terminal |
| `Directory.GetFiles` + LINQ `Where` | Búsqueda recursiva excluyendo `bin` y `obj` |
| `Task.WhenAll` + `async` | Lectura en paralelo de todos los archivos (IO-bound) |
| `OrderByDescending + Take(10)` | Ranking de los 10 archivos más extensos |
| `record ResultadoArchivo` | Tipo inmutable para almacenar ruta y líneas |
| `File.ReadAllTextAsync` | Lectura asíncrona de archivos sin bloquear hilos |

## ¿Por qué `Task.WhenAll` en lugar de `await` secuencial?

```
// Secuencial: el total es la suma de todos los tiempos de lectura
foreach (string archivo in archivos)
    resultados.Add(await AnalizarAsync(archivo)); // cada lectura espera a la anterior

// Paralelo con Task.WhenAll: todas las lecturas se lanzan a la vez
// Total ≈ tiempo del archivo más lento (no la suma de todos)
var resultados = await Task.WhenAll(archivos.Select(AnalizarAsync));
```

## Análisis del código

```csharp
// args.FirstOrDefault() toma el primer argumento CLI, o el directorio actual si no hay ninguno.
// Ejecución: dotnet run --project . -- C:\mis-fuentes
string carpeta = args.FirstOrDefault() ?? Directory.GetCurrentDirectory();

// Excluimos archivos generados por el compilador dentro de bin y obj.
// Split(Path.DirectorySeparatorChar) maneja rutas en Windows (\) y Linux (/).
string[] archivos = Directory
    .GetFiles(carpeta, "*.cs", SearchOption.AllDirectories)
    .Where(ruta => !ruta.Split(Path.DirectorySeparatorChar)
        .Any(parte => parte is "bin" or "obj"))
    .ToArray();

// Lanza todas las lecturas en paralelo; espera a que todas terminen.
var resultados = await Task.WhenAll(archivos.Select(AnalizarAsync));

// Top-10 por número de líneas, descendente.
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
```

## Cómo ejecutarlo

```powershell
# Analiza el directorio actual
dotnet run --project .\06-Proyectos\03-AnalizadorArchivos

# Analiza un directorio específico
dotnet run --project .\06-Proyectos\03-AnalizadorArchivos -- C:\source\mi-proyecto
```

## Ampliaciones propuestas

1. Cuenta las líneas que contienen `//` (comentarios) y muestra el porcentaje de comentarios.
2. Agrupa los resultados por extensión de archivo (`.cs`, `.json`, `.md`) usando `GroupBy`.
3. Añade una opción CLI `--top N` para mostrar los N archivos más extensos (en lugar de 10).

## Referencias

- [Directory.GetFiles](https://learn.microsoft.com/dotnet/api/system.io.directory.getfiles)
- [Task.WhenAll](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task.whenall)
- [File.ReadAllTextAsync](https://learn.microsoft.com/dotnet/api/system.io.file.readalltextasync)
