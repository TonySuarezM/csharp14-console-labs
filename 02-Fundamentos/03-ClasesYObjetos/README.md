# Clases y objetos

**Nivel:** 2 — Fundamentos  |  **Concepto clave:** Primary constructors, propiedades y encapsulamiento

## ¿Qué aprenderás?

Una **clase** agrupa datos (propiedades) y comportamiento (métodos) en una unidad reutilizable.
El **encapsulamiento** protege el estado interno: en este ejemplo, `Saldo` solo puede cambiar
a través del método `Ingresar`, nunca directamente desde fuera.

Los **primary constructors** (C# 12+) permiten declarar los parámetros del constructor
directamente en la cabecera de la clase, reduciendo el código repetitivo.

## Conceptos cubiertos

- **Primary constructor `class Foo(string param)`** — declara y asigna parámetros en la cabecera.
- **Propiedad automática `{ get; }`** — getter público sin setter; el valor se asigna en la declaración.
- **Setter privado `{ get; private set; }`** — solo los métodos de la misma clase pueden modificar el valor.
- **`new CuentaBancaria("Ana", 100m)`** — crea una instancia (objeto) de la clase.

## Análisis del código

```csharp
var cuenta = new CuentaBancaria("Ana", 100m);
cuenta.Ingresar(50m);
Console.WriteLine($"{cuenta.Titular}: {cuenta.Saldo:C}");

// Primary constructor: los parámetros "titular" y "saldoInicial" están disponibles
// para inicializar las propiedades directamente.
class CuentaBancaria(string titular, decimal saldoInicial)
{
    public string Titular { get; } = titular;
    // El setter privado protege el saldo frente a cambios externos.
    // Solo "Ingresar" (u otros métodos internos) pueden modificar Saldo.
    public decimal Saldo { get; private set; } = saldoInicial;

    public void Ingresar(decimal cantidad)
    {
        if (cantidad > 0) Saldo += cantidad; // validación antes de modificar estado
    }
}
```

## Ejercicio propuesto

1. Añade un método `Retirar(decimal cantidad)` que:
   - Lance `ArgumentException` si `cantidad <= 0`.
   - Lance `InvalidOperationException` si `cantidad > Saldo`.
   - Reste del saldo en caso contrario.
2. Añade una propiedad `int NumeroOperaciones { get; private set; }` que se incremente
   en cada `Ingresar` y `Retirar`.

## Referencias

- [Clases en C#](https://learn.microsoft.com/dotnet/csharp/fundamentals/types/classes)
- [Primary constructors](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-12#primary-constructors)
- [Propiedades](https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/properties)
