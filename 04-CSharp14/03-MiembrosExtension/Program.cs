string frase = "C# 14 añade miembros de extensión";
Console.WriteLine($"Palabras: {frase.NumeroPalabras}");
Console.WriteLine($"Vacío: '{string.Vacio}'");

static class ExtensionesTexto
{
    // Un bloque extension puede añadir propiedades de instancia y estáticas.
    extension(string texto)
    {
        public int NumeroPalabras =>
            texto.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

        public static string Vacio => string.Empty;
    }
}
