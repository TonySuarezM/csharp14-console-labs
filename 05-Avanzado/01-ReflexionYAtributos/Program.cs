using System.Reflection;

// typeof obtiene el objeto Type de InformeVentas en tiempo de compilación.
// Con Type podemos inspeccionar la clase en tiempo de ejecución (reflexión).
Type tipo = typeof(InformeVentas);
// BindingFlags.Instance | Public: solo métodos de instancia públicos (excluye privados y estáticos).
foreach (MethodInfo metodo in tipo.GetMethods(BindingFlags.Instance | BindingFlags.Public))
{
    // GetCustomAttribute<T> devuelve el atributo si existe, o null si no.
    // Nota: la reflexión tiene un coste en rendimiento; úsala en inicialización, no en bucles críticos.
    DescripcionAttribute? descripcion = metodo.GetCustomAttribute<DescripcionAttribute>();
    if (descripcion is not null)
        Console.WriteLine($"{metodo.Name}: {descripcion.Texto}");
}

// AttributeUsage restringe el atributo a métodos; el compilador avisa si se aplica en otro lugar.
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
