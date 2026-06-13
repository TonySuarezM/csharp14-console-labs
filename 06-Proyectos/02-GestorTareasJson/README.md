# Proyecto: Gestor de tareas JSON

**Nivel:** 6 — Proyectos integradores

## ¿Qué integra este proyecto?

Un gestor de tareas persistente que guarda y carga datos de un archivo JSON. Combina records
inmutables con la expresión `with`, colecciones dinámicas, y serialización/deserialización JSON.

## Tecnologías integradas

| Concepto | Dónde se usa |
|----------|-------------|
| `record Tarea` | Tipo inmutable con igualdad por valor para representar cada tarea |
| `List<Tarea>` | Colección dinámica de tareas |
| `File.Exists` + `JsonSerializer.Deserialize` | Carga el archivo si existe, o crea lista vacía |
| Expresión `with` | Crea una copia de la tarea con `Completada = true` sin mutar el original |
| `JsonSerializer.Serialize` + `File.WriteAllText` | Persiste el estado actualizado en disco |
| `Guid.NewGuid()` | Identificador único para cada tarea |

## Flujo del programa (ciclo CRUD básico)

```
1. Cargar tareas del archivo JSON (o lista vacía si no existe)
2. Añadir nueva tarea con Add()
3. Marcar la primera tarea como completada con "with"
4. Guardar todas las tareas en el archivo JSON
5. Mostrar el estado actual en consola
```

## Análisis del código

```csharp
string ruta = Path.Combine(Path.GetTempPath(), "tareas-csharp14.json");

// Carga condicional: si el archivo existe, deserializa; si no, empieza con lista vacía.
// ?? [] maneja el caso en que Deserialize devuelva null.
List<Tarea> tareas = File.Exists(ruta)
    ? JsonSerializer.Deserialize<List<Tarea>>(File.ReadAllText(ruta)) ?? []
    : [];

tareas.Add(new Tarea(Guid.NewGuid(), "Repasar LINQ", false));

// "with" crea una NUEVA Tarea con Completada=true.
// El record original no se modifica (es inmutable).
if (tareas.Count > 0)
    tareas[0] = tareas[0] with { Completada = true };

File.WriteAllText(ruta, JsonSerializer.Serialize(tareas, new JsonSerializerOptions
{
    WriteIndented = true // JSON legible en el archivo
}));

foreach (Tarea tarea in tareas)
    Console.WriteLine($"[{(tarea.Completada ? 'x' : ' ')}] {tarea.Titulo}");

record Tarea(Guid Id, string Titulo, bool Completada);
```

## Ampliaciones propuestas

1. Convierte el programa en un **menú interactivo** con opciones:
   - `1` — Añadir tarea
   - `2` — Completar tarea por número
   - `3` — Eliminar tarea
   - `0` — Salir (y guardar)
2. Añade un campo `DateTime FechaCreacion` al record `Tarea`.
3. Muestra las tareas ordenadas: primero las pendientes, luego las completadas.

## Referencias

- [System.Text.Json](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/overview)
- [Records en C#](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/record)
- [Guid.NewGuid](https://learn.microsoft.com/dotnet/api/system.guid.newguid)
