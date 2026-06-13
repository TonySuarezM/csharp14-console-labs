// string? es un nullable reference type: el compilador avisa si se usa sin comprobar null.
string? nombre = ObtenerNombre();
// "is null" es pattern matching para nulidad; más expresivo que "== null".
Console.WriteLine(nombre is null ? "No hay nombre." : nombre.ToUpperInvariant());

Console.WriteLine("Esperando de forma asíncrona...");
// En top-level statements, "await" funciona directamente: .NET genera el async Task Main.
// El hilo no queda bloqueado; puede atender otras tareas mientras espera.
string resultado = await ObtenerResultadoAsync();
Console.WriteLine(resultado);

static string? ObtenerNombre() => DateTime.Now.Second % 2 == 0 ? "Ana" : null;

static async Task<string> ObtenerResultadoAsync()
{
    // await libera el hilo mientras termina una operación asíncrona.
    // Task.Delay simula una operación lenta (llamada a base de datos, API web, etc.).
    await Task.Delay(300);
    return "Operación terminada.";
}
