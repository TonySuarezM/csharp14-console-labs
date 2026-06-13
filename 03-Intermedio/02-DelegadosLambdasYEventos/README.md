# Delegados, lambdas y eventos

**Nivel:** 3 — Intermedio  |  **Concepto clave:** `Func<>`, lambdas y patrón de eventos

## ¿Qué aprenderás?

Un **delegado** es un tipo que representa una referencia a un método: permite pasar funciones
como argumentos, almacenarlas en variables y llamarlas más tarde. `Func<>` y `Action<>` son
delegados predefinidos en .NET para los casos más comunes.

Los **eventos** utilizan delegados para implementar el patrón observador: un objeto publica
un evento y otros objetos se suscriben para ser notificados cuando ocurre.

## Conceptos cubiertos

- **`Func<TEntrada, TSalida>`** — delegado predefinido para funciones con retorno.
- **Lambda `x => expresión`** — función anónima concisa; define el comportamiento en línea.
- **`event EventHandler<T>`** — evento tipado con el argumento del evento.
- **`+=` y `-=`** — suscripción y des-suscripción a un evento.
- **`?.Invoke(...)`** — invoca el evento solo si hay al menos un suscriptor (evita `NullReferenceException`).

## Análisis del código

```csharp
var contador = new Contador();
// Suscripción: cuando LimiteAlcanzado se dispare, ejecuta esta lambda.
// El primer parámetro _ (sender) se descarta porque no lo necesitamos.
contador.LimiteAlcanzado += (_, valor) => Console.WriteLine($"Límite alcanzado: {valor}");

// Func<int, int>: delegado que recibe un int y devuelve un int.
// La lambda "numero => numero * numero" es la implementación.
Func<int, int> cuadrado = numero => numero * numero;
Console.WriteLine($"Cuadrado: {cuadrado(5)}");
contador.Incrementar();
contador.Incrementar(); // al llegar a 2, dispara el evento

class Contador
{
    private int valor;
    public event EventHandler<int>? LimiteAlcanzado;

    public void Incrementar()
    {
        valor++;
        // El operador ?. invoca el evento solo cuando tiene suscriptores.
        // Sin ?., si nadie se ha suscrito lanzaría NullReferenceException.
        if (valor >= 2) LimiteAlcanzado?.Invoke(this, valor);
    }
}
```

## Ejercicio propuesto

1. Añade un segundo suscriptor al evento que escriba en mayúsculas: `Console.WriteLine($"ALERTA: {valor}")`.
2. Des-suscribe el primer suscriptor con `-=` y verifica que solo se ejecuta el segundo.
3. Crea un `Func<string, string>` que convierta texto a Title Case (primera letra de cada
   palabra en mayúscula) y pruébalo.

## Referencias

- [Delegados](https://learn.microsoft.com/dotnet/csharp/programming-guide/delegates/)
- [Lambdas](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/lambda-expressions)
- [Eventos](https://learn.microsoft.com/dotnet/csharp/programming-guide/events/)
- [Func\<T,TResult\>](https://learn.microsoft.com/dotnet/api/system.func-2)
