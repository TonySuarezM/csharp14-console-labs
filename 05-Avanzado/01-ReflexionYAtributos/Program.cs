using System.Reflection;

Type tipo = typeof(InformeVentas);
foreach (MethodInfo metodo in tipo.GetMethods(BindingFlags.Instance | BindingFlags.Public))
{
    DescripcionAttribute? descripcion = metodo.GetCustomAttribute<DescripcionAttribute>();
    if (descripcion is not null)
        Console.WriteLine($"{metodo.Name}: {descripcion.Texto}");
}

[AttributeUsage(AttributeTargets.Method)]
class DescripcionAttribute(string texto) : Attribute
{
    public string Texto { get; } = texto;
}

class InformeVentas
{
    // Los atributos añaden metadatos que pueden consultarse mediante reflexión.
    [Descripcion("Genera el resumen mensual")]
    public void Generar() { }
}
