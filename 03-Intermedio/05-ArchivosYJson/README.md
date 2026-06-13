# Archivos y JSON

**Nivel:** 3 — Intermedio  |  **Concepto clave:** `System.Text.Json`, lectura/escritura de archivos

## ¿Qué aprenderás?

La persistencia de datos es fundamental en cualquier aplicación. `System.Text.Json` es la
librería oficial de .NET para serializar objetos a JSON y deserializarlos de vuelta, sin
dependencias externas. Combinada con `File`, permite guardar y recuperar datos entre
ejecuciones del programa.

## Conceptos cubiertos

- **`JsonSerializer.Serialize(obj, opciones)`** — convierte un objeto a su representación JSON como `string`.
- **`JsonSerializer.Deserialize<T>(json)`** — convierte un `string` JSON al tipo `T`; puede devolver `null`.
- **`JsonSerializerOptions { WriteIndented = true }`** — formatea el JSON con sangría para legibilidad.
- **`File.WriteAllText(ruta, texto)`** — escribe un `string` en disco, creando o sobreescribiendo el archivo.
- **`File.ReadAllText(ruta)`** — lee todo el contenido de un archivo como `string`.
- **`Path.GetTempPath()`** — devuelve la carpeta temporal del sistema, válida en Windows, Linux y macOS.

## Análisis del código

```csharp
using System.Text.Json;

var configuracion = new Configuracion("es-ES", true);
// Serialize convierte el record a JSON. WriteIndented=true lo hace legible.
string json = JsonSerializer.Serialize(configuracion, new JsonSerializerOptions
{
    WriteIndented = true
});

// Path.GetTempPath() + nombre único para no ensuciar el directorio de trabajo.
string ruta = Path.Combine(Path.GetTempPath(), "configuracion-csharp14.json");
File.WriteAllText(ruta, json);

// Deserialize puede devolver null si el JSON contiene literalmente "null".
// El operador ? en Configuracion? y ?. en recuperada?.Idioma gestionan ese caso.
Configuracion? recuperada = JsonSerializer.Deserialize<Configuracion>(File.ReadAllText(ruta));

Console.WriteLine($"Archivo: {ruta}");
Console.WriteLine($"Idioma recuperado: {recuperada?.Idioma}");

record Configuracion(string Idioma, bool ModoOscuro);
```

**JSON generado:**
```json
{
  "Idioma": "es-ES",
  "ModoOscuro": true
}
```

## Ejercicio propuesto

1. Añade una propiedad `int Version` al record `Configuracion` y comprueba que se serializa.
2. Modifica el programa para serializar una `List<Configuracion>` con tres entradas distintas.
3. Usa `JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }` y
   observa cómo cambian los nombres de las propiedades en el JSON resultante.

## Referencias

- [System.Text.Json](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/overview)
- [File (clase)](https://learn.microsoft.com/dotnet/api/system.io.file)
- [Path (clase)](https://learn.microsoft.com/dotnet/api/system.io.path)
