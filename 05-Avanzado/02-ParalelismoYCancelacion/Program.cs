// CancellationTokenSource(TimeSpan): el token se cancela automáticamente tras 250 ms.
// Equivale a un timeout de petición HTTP. El using garantiza que los recursos se liberen.
using var cancelacion = new CancellationTokenSource(TimeSpan.FromMilliseconds(250));

try
{
    // Parallel.ForEachAsync procesa los elementos en paralelo usando el ThreadPool.
    // El segundo parámetro es el token: permite cancelar todas las iteraciones en curso.
    await Parallel.ForEachAsync(Enumerable.Range(1, 20), cancelacion.Token,
        async (numero, token) =>
        {
            // Task.Delay también respeta el token: si se cancela, lanza OperationCanceledException.
            await Task.Delay(50, token);
            Console.WriteLine($"{numero} procesado por el hilo {Environment.CurrentManagedThreadId}");
        });
}
catch (OperationCanceledException)
{
    // La cancelación cooperativa permite detener trabajo sin finalizar bruscamente.
    // OperationCanceledException es la señal normal de cancelación, no un error inesperado.
    Console.WriteLine("Procesamiento cancelado de forma controlada.");
}
