using var cancelacion = new CancellationTokenSource(TimeSpan.FromMilliseconds(250));

try
{
    await Parallel.ForEachAsync(Enumerable.Range(1, 20), cancelacion.Token,
        async (numero, token) =>
        {
            await Task.Delay(50, token);
            Console.WriteLine($"{numero} procesado por el hilo {Environment.CurrentManagedThreadId}");
        });
}
catch (OperationCanceledException)
{
    // La cancelación cooperativa permite detener trabajo sin finalizar bruscamente.
    Console.WriteLine("Procesamiento cancelado de forma controlada.");
}
