# Constructor y evento parciales (C# 14)

**Nivel:** 4 — C# 14  |  **Concepto clave:** `partial` constructor y `partial` evento con accessors

## ¿Qué aprenderás?

Las **clases parciales** existen desde C# 2 y permiten dividir una clase entre varios archivos.
Hasta C# 14, solo los **métodos y propiedades** podían ser parciales. C# 14 añade soporte
para **constructores parciales** y **eventos parciales**, completando el modelo de generación
de código con source generators.

## Caso de uso real: source generators

Un source generator puede declarar el constructor o evento en un archivo generado:

```
Cliente.g.cs (generado automáticamente)  →  declara "public partial Cliente(string nombre);"
Cliente.cs   (escrito por el dev)        →  implementa "public partial Cliente(string nombre) => Nombre = nombre;"
```

El desarrollador nunca toca el archivo generado; solo implementa las partes declaradas.

## Análisis del código

```csharp
var cliente = new Cliente("Ana");
cliente.Cambio += (_, mensaje) => Console.WriteLine(mensaje);
cliente.Notificar();

// PARTE 1: Declaraciones (simula lo que generaría un source generator)
partial class Cliente
{
    // C# 14 permite declarar constructores y eventos parciales.
    // La declaración solo anuncia la firma; no contiene implementación.
    public partial Cliente(string nombre);
    public partial event EventHandler<string> Cambio;
}

// PARTE 2: Implementaciones (escrita por el desarrollador)
partial class Cliente
{
    public string Nombre { get; }
    public partial Cliente(string nombre) => Nombre = nombre;

    // Evento parcial con accessors explícitos: el dev controla cómo se suscribe/desuscribe.
    private EventHandler<string>? cambio;
    public partial event EventHandler<string> Cambio
    {
        add    => cambio += value;
        remove => cambio -= value;
    }

    public void Notificar() => cambio?.Invoke(this, $"Cambio en {Nombre}");
}
```

## Ejercicio propuesto

1. Añade un segundo evento parcial `Eliminado` de tipo `EventHandler<string>` y
   suscríbete a él en el programa principal.
2. Crea un método `Eliminar()` que dispare el evento `Eliminado` con el nombre del cliente.
3. Investiga cómo funcionan los source generators en .NET: busca `ISourceGenerator` en la
   documentación oficial.

## Referencias

- [Novedades de C# 14 — miembros parciales](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-14)
- [Clases parciales y métodos](https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods)
- [Source generators](https://learn.microsoft.com/dotnet/csharp/roslyn-sdk/source-generators-overview)
