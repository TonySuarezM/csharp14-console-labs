string frase = "C# 14 añade miembros de extensión";
// NumeroPalabras es una propiedad de instancia de extensión: frase.NumeroPalabras
Console.WriteLine($"Palabras: {frase.NumeroPalabras}");
// Vacio es una propiedad estática de extensión: string.Vacio
Console.WriteLine($"Vacío: '{string.Vacio}'");

static class ExtensionesTexto
{
    // Un bloque extension puede añadir propiedades de instancia y estáticas.
    // "extension(string texto)" indica que los miembros siguientes extienden el tipo string.
    // Antes de C# 14 solo se podían añadir métodos de extensión, no propiedades.
    extension(string texto)
    {
        // Propiedad de instancia: se accede como frase.NumeroPalabras
        public int NumeroPalabras =>
            texto.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

        // Propiedad estática: se accede como string.Vacio (igual que string.Empty)
        public static string Vacio => string.Empty;
    }
}
