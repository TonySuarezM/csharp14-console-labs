# Reflexión y atributos

**Nivel:** 5 — Avanzado  |  **Concepto clave:** `Attribute`, `Type`, `MethodInfo` y `GetCustomAttribute<T>`

## ¿Qué aprenderás?

Los **atributos** son metadatos que se adjuntan a clases, métodos, propiedades, etc. usando la
sintaxis `[NombreAtributo]`. La **reflexión** permite inspeccionar esos metadatos en tiempo de
ejecución: descubrir qué métodos existen, qué atributos tienen, cuáles son sus parámetros, etc.

Frameworks como ASP.NET Core (`[HttpGet]`), xUnit (`[Fact]`) y Entity Framework (`[Key]`) se
basan en este mecanismo para encontrar controladores, tests y columnas automáticamente.

## Conceptos cubiertos

- **`Attribute`** — clase base de todos los atributos; se subclasifica para crear atributos propios.
- **`[AttributeUsage(AttributeTargets.Method)]`** — restringe dónde se puede aplicar el atributo.
- **`typeof(T)`** — obtiene el objeto `Type` de un tipo conocido en tiempo de compilación.
- **`GetMethods(BindingFlags)`** — devuelve los métodos que cumplen los flags indicados.
- **`GetCustomAttribute<T>()`** — obtiene el atributo del tipo `T` si existe; `null` si no.

## Análisis del código

```csharp
using System.Reflection;

// typeof obtiene el descriptor Type de InformeVentas en tiempo de compilación.
Type tipo = typeof(InformeVentas);
// GetMethods filtra: solo métodos de instancia y públicos (excluye privados y estáticos).
foreach (MethodInfo metodo in tipo.GetMethods(BindingFlags.Instance | BindingFlags.Public))
{
    // GetCustomAttribute devuelve null si el método no tiene el atributo.
    DescripcionAttribute? descripcion = metodo.GetCustomAttribute<DescripcionAttribute>();
    if (descripcion is not null)
        Console.WriteLine($"{metodo.Name}: {descripcion.Texto}");
}

// AttributeUsage restringe el atributo a métodos; el compilador avisa si se usa en otro lugar.
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
```

> **Advertencia de rendimiento:** la reflexión es lenta comparada con llamadas directas.
> Úsala en rutas de inicialización (arranque de la app), no en bucles de alto rendimiento.
> Para escenarios críticos considera `source generators` o `compiled expressions`.

## Ejercicio propuesto

1. Añade un segundo método `Exportar()` con `[Descripcion("Exporta a CSV")]` y comprueba
   que aparece en la salida.
2. Crea un atributo `[Prioridad(int nivel)]` y aplícalo a los métodos. Modifica el bucle
   para mostrar también la prioridad.
3. Usa `tipo.GetProperties()` para listar las propiedades de una clase propia.

## Referencias

- [Reflexión en .NET](https://learn.microsoft.com/dotnet/fundamentals/reflection/reflection)
- [Atributos en C#](https://learn.microsoft.com/dotnet/csharp/advanced-topics/reflection-and-attributes/)
- [BindingFlags](https://learn.microsoft.com/dotnet/api/system.reflection.bindingflags)
