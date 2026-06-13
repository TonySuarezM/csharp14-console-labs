using System.Text.Json;

var configuracion = new Configuracion("es-ES", true);
string json = JsonSerializer.Serialize(configuracion, new JsonSerializerOptions
{
    WriteIndented = true
});

string ruta = Path.Combine(Path.GetTempPath(), "configuracion-csharp14.json");
File.WriteAllText(ruta, json);
Configuracion? recuperada = JsonSerializer.Deserialize<Configuracion>(File.ReadAllText(ruta));

Console.WriteLine($"Archivo: {ruta}");
Console.WriteLine($"Idioma recuperado: {recuperada?.Idioma}");

record Configuracion(string Idioma, bool ModoOscuro);
