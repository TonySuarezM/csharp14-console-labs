using System.Text.Json;

string ruta = Path.Combine(Path.GetTempPath(), "tareas-csharp14.json");
// Patrón de carga condicional: si el archivo existe se deserializa, si no se empieza con lista vacía.
// ?? [] maneja el caso en que Deserialize devuelva null (JSON null o archivo vacío).
List<Tarea> tareas = File.Exists(ruta)
    ? JsonSerializer.Deserialize<List<Tarea>>(File.ReadAllText(ruta)) ?? []
    : [];

tareas.Add(new Tarea(Guid.NewGuid(), "Repasar LINQ", false));
// "with" crea una NUEVA instancia con Completada=true; el record original sigue igual.
// Los records son inmutables: no se puede hacer tareas[0].Completada = true.
if (tareas.Count > 0)
    tareas[0] = tareas[0] with { Completada = true };

// WriteIndented=true produce JSON con sangría, más legible si se abre el archivo manualmente.
File.WriteAllText(ruta, JsonSerializer.Serialize(tareas, new JsonSerializerOptions
{
    WriteIndented = true
}));

foreach (Tarea tarea in tareas)
    Console.WriteLine($"[{(tarea.Completada ? 'x' : ' ')}] {tarea.Titulo}");
Console.WriteLine($"Datos guardados en: {ruta}");

record Tarea(Guid Id, string Titulo, bool Completada);
