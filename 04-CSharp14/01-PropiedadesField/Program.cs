var usuario = new Usuario { Nombre = "  Ana  " };
Console.WriteLine(usuario.Nombre); // "Ana" (los espacios se eliminaron en el setter)

class Usuario
{
    // Antes de C# 14, para validar en un setter había que declarar un backing field manual:
    //   private string _nombre = string.Empty;
    //   public string Nombre { get => _nombre; set => _nombre = ...; }
    //
    // C# 14 permite usar "field" para referirse al campo generado por el compilador.
    // Ya no es necesario declarar _nombre manualmente.
    public string Nombre
    {
        get;
        // "field" es el campo privado que el compilador genera para esta propiedad.
        // value.Trim() elimina espacios; el pattern { Length: > 0 } comprueba que no quede vacío.
        set => field = value.Trim() is { Length: > 0 } limpio
            ? limpio
            : throw new ArgumentException("El nombre es obligatorio.");
    } = string.Empty; // valor inicial del campo generado
}
