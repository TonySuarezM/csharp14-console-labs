string? nombre = ObtenerNombre();
Console.WriteLine(nombre is null ? "No hay nombre." : nombre.ToUpperInvariant());

Console.WriteLine("Esperando de forma asíncrona...");
string resultado = await ObtenerResultadoAsync();
Console.WriteLine(resultado);

static string? ObtenerNombre() => DateTime.Now.Second % 2 == 0 ? "Ana" : null;

static async Task<string> ObtenerResultadoAsync()
{
    // await libera el hilo mientras termina una operación asíncrona.
    await Task.Delay(300);
    return "Operación terminada.";
}
