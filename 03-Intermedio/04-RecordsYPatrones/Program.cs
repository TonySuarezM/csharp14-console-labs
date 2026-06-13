Persona original = new("Ana", 28);
// "with" crea una COPIA del record con Edad=29 modificado.
// El record original no cambia: los records son inmutables por diseño.
Persona copia = original with { Edad = 29 };
// Los records tienen ToString autogenerado que muestra todos sus campos.
Console.WriteLine($"{original} / {copia}");
Console.WriteLine(Clasificar(copia));

static string Clasificar(object valor) => valor switch
{
    // Property pattern: coincide si valor es Persona Y la propiedad Edad < 18.
    Persona { Edad: < 18 } => "Persona menor de edad",
    // Var pattern: captura el valor de Nombre en la nueva variable "nombre".
    Persona { Edad: >= 18, Nombre: var nombre } => $"{nombre} es adulta",
    null => "Sin valor",
    _ => "Tipo desconocido"
};

// Los records proporcionan igualdad por valor: dos records con los mismos datos son iguales.
// Contrasta con las clases, donde la igualdad por defecto es por referencia.
record Persona(string Nombre, int Edad);
