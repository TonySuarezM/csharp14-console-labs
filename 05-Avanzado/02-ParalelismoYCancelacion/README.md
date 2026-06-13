# Paralelismo y cancelación cooperativa

**Nivel:** 5 — Avanzado  |  **Concepto clave:** `Parallel.ForEachAsync`, `CancellationTokenSource` y cancelación cooperativa

## ¿Qué aprenderás?

El **paralelismo** permite procesar múltiples elementos al mismo tiempo aprovechando varios
núcleos del procesador. La **cancelación cooperativa** es el mecanismo estándar de .NET para
detener trabajo en curso de forma controlada: en lugar de terminar el hilo bruscamente, se
señaliza un `CancellationToken` y el código cancela voluntariamente.

## Cancelación cooperativa vs abrupta

| Tipo | Mecanismo | Problema |
|------|-----------|---------|
| **Abrupta** (`Thread.Abort`) | Lanza una excepción en cualquier punto del hilo | Puede dejar recursos sin liberar; eliminado en .NET 5+ |
| **Cooperativa** (`CancellationToken`) | El código comprueba el token y cancela cuando es seguro | El código cancela en un punto conocido y limpio |

## Análisis del código

```csharp
// CancellationTokenSource(TimeSpan): cancela automáticamente tras 250 ms.
// Es equivalente a un timeout de petición HTTP.
using var cancelacion = new CancellationTokenSource(TimeSpan.FromMilliseconds(250));

try
{
    // Parallel.ForEachAsync procesa los elementos en paralelo usando el ThreadPool.
    // El token se pasa a cada iteración para que pueda cancelarse.
    await Parallel.ForEachAsync(Enumerable.Range(1, 20), cancelacion.Token,
        async (numero, token) =>
        {
            await Task.Delay(50, token); // el delay también respeta la cancelación
            Console.WriteLine($"{numero} procesado por el hilo {Environment.CurrentManagedThreadId}");
        });
}
catch (OperationCanceledException)
{
    // La cancelación cooperativa permite detener trabajo sin finalizar bruscamente.
    // OperationCanceledException es la señal normal de cancelación, no un error real.
    Console.WriteLine("Procesamiento cancelado de forma controlada.");
}
```

> **¿Por qué `using var`?** `CancellationTokenSource` implementa `IDisposable`. El `using`
> garantiza que sus recursos se liberen cuando el bloque termina, incluso si hay excepción.

## Ejercicio propuesto

1. Cambia el timeout a 500 ms y observa cuántos elementos se procesan antes de cancelar.
2. Sustituye el timeout automático por cancelación manual: crea el `CancellationTokenSource`
   sin argumentos y llama a `cancelacion.Cancel()` desde otro contexto (p. ej. después de
   los primeros 5 elementos procesados).
3. Añade un bloque `finally` después del `catch` que muestre "Recursos liberados." y
   comprueba que se ejecuta siempre.

## Referencias

- [Parallel.ForEachAsync](https://learn.microsoft.com/dotnet/api/system.threading.tasks.parallel.foreachasync)
- [CancellationToken](https://learn.microsoft.com/dotnet/standard/threading/cancellation-in-managed-threads)
- [Patrón de cancelación cooperativa](https://learn.microsoft.com/dotnet/standard/parallel-programming/task-cancellation)
