using System.Text.Json;

var configuracion = new Configuracion("es-ES", true);
// JsonSerializer.Serialize convierte el record a su representación JSON.
// WriteIndented=true produce JSON con sangría, más legible para el ojo humano.
string json = JsonSerializer.Serialize(configuracion, new JsonSerializerOptions
{
    WriteIndented = true
});

// Path.GetTempPath() devuelve la carpeta temporal del sistema (%TEMP% en Windows).
// Es una ruta válida en Windows, Linux y macOS, adecuada para ejemplos y tests.
string ruta = Path.Combine(Path.GetTempPath(), "configuracion-csharp14.json");
File.WriteAllText(ruta, json);

// Deserialize puede devolver null si el JSON contiene literalmente el valor null.
// El tipo Configuracion? y el operador ?. gestionan ese caso de forma segura.
Configuracion? recuperada = JsonSerializer.Deserialize<Configuracion>(File.ReadAllText(ruta));

Console.WriteLine($"Archivo: {ruta}");
Console.WriteLine($"Idioma recuperado: {recuperada?.Idioma}");

record Configuracion(string Idioma, bool ModoOscuro);
