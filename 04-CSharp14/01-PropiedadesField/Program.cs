var usuario = new Usuario { Nombre = "  Ana  " };
Console.WriteLine(usuario.Nombre);

class Usuario
{
    // C# 14 permite validar una propiedad automática usando la palabra field.
    public string Nombre
    {
        get;
        set => field = value.Trim() is { Length: > 0 } limpio
            ? limpio
            : throw new ArgumentException("El nombre es obligatorio.");
    } = string.Empty;
}
