using System.Text.Json;

string ruta = Path.Combine(Path.GetTempPath(), "tareas-csharp14.json");
List<Tarea> tareas = File.Exists(ruta)
    ? JsonSerializer.Deserialize<List<Tarea>>(File.ReadAllText(ruta)) ?? []
    : [];

tareas.Add(new Tarea(Guid.NewGuid(), "Repasar LINQ", false));
if (tareas.Count > 0)
    tareas[0] = tareas[0] with { Completada = true };

File.WriteAllText(ruta, JsonSerializer.Serialize(tareas, new JsonSerializerOptions
{
    WriteIndented = true
}));

foreach (Tarea tarea in tareas)
    Console.WriteLine($"[{(tarea.Completada ? 'x' : ' ')}] {tarea.Titulo}");
Console.WriteLine($"Datos guardados en: {ruta}");

record Tarea(Guid Id, string Titulo, bool Completada);
