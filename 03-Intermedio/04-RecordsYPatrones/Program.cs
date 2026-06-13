Persona original = new("Ana", 28);
Persona copia = original with { Edad = 29 };
Console.WriteLine($"{original} / {copia}");
Console.WriteLine(Clasificar(copia));

static string Clasificar(object valor) => valor switch
{
    Persona { Edad: < 18 } => "Persona menor de edad",
    Persona { Edad: >= 18, Nombre: var nombre } => $"{nombre} es adulta",
    null => "Sin valor",
    _ => "Tipo desconocido"
};

// Los records proporcionan igualdad por valor y una sintaxis concisa.
record Persona(string Nombre, int Edad);
