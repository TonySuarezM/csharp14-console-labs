# Async y nullable

**Nivel:** 3 — Intermedio  |  **Concepto clave:** `async/await`, `Task<T>` y tipos nullable

## ¿Qué aprenderás?

La programación **asíncrona** permite que el programa siga respondiendo mientras espera
operaciones lentas (red, disco). `async/await` hace que el código asíncrono sea tan legible
como el síncrono. Los **tipos nullable** (`T?`) expresan explícitamente que un valor puede
estar ausente, forzando al programador a gestionarlo.

## Conceptos cubiertos

- **`string?`** — nullable reference type: el compilador avisa si se usa sin comprobar `null`.
- **`is null`** — pattern matching para comprobar nulidad; más expresivo que `== null`.
- **`async Task<T>`** — método asíncrono que devuelve un valor de tipo `T` cuando termina.
- **`await`** — libera el hilo actual mientras espera el `Task`; reanuda la ejecución al completarse.
- **`Task.Delay(ms)`** — espera asíncrona (simula una operación lenta sin bloquear el hilo).

## Análisis del código

```csharp
// string? indica que ObtenerNombre() puede devolver null.
// El compilador obliga a gestionar ese caso antes de usar el valor.
string? nombre = ObtenerNombre();
Console.WriteLine(nombre is null ? "No hay nombre." : nombre.ToUpperInvariant());

Console.WriteLine("Esperando de forma asíncrona...");
// await suspende este método hasta que ObtenerResultadoAsync termine.
// El hilo no queda bloqueado; puede atender otras operaciones mientras espera.
string resultado = await ObtenerResultadoAsync();
Console.WriteLine(resultado);

static string? ObtenerNombre() => DateTime.Now.Second % 2 == 0 ? "Ana" : null;

static async Task<string> ObtenerResultadoAsync()
{
    // await libera el hilo mientras termina una operación asíncrona.
    // Task.Delay simula una llamada lenta a base de datos o API web.
    await Task.Delay(300);
    return "Operación terminada.";
}
```

> **¿Por qué no usar `.Result`?** Llamar a `tarea.Result` bloquea el hilo hasta que la tarea
> termina. En aplicaciones de UI puede congelar la interfaz; en servidores puede causar deadlocks.
> Usa siempre `await`.

## Ejercicio propuesto

1. Crea un segundo método `async Task<int> ContarPalabrasAsync(string texto)` que espere
   100 ms y retorne el número de palabras de `texto`.
2. Ejecuta ambas operaciones en paralelo con `Task.WhenAll` y muestra los resultados.
   ```csharp
   var (r1, r2) = await (ObtenerResultadoAsync(), ContarPalabrasAsync("hola mundo"));
   ```
3. Añade un `CancellationToken` a `ObtenerResultadoAsync` y pásalo a `Task.Delay`.

## Referencias

- [Programación asíncrona](https://learn.microsoft.com/dotnet/csharp/asynchronous-programming/)
- [async y await](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/await)
- [Nullable reference types](https://learn.microsoft.com/dotnet/csharp/nullable-references)
- [Task.WhenAll](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task.whenall)
