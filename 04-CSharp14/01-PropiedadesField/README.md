# Propiedades con `field` (C# 14)

**Nivel:** 4 — C# 14  |  **Concepto clave:** Palabra clave `field` en setters de propiedades automáticas

## ¿Qué aprenderás?

Antes de C# 14, si querías validar el valor asignado a una propiedad tenías que abandonar
la sintaxis de propiedad automática y declarar un campo de respaldo (`backing field`) manual.
Con C# 14, la palabra clave `field` referencia directamente el campo generado por el
compilador, permitiendo validar sin sacrificar la concisión.

## El problema antes de C# 14

```csharp
// ANTES: había que declarar el backing field manualmente
class Usuario
{
    private string _nombre = string.Empty; // campo de respaldo manual

    public string Nombre
    {
        get => _nombre;
        set => _nombre = value.Trim() is { Length: > 0 } limpio
            ? limpio
            : throw new ArgumentException("El nombre es obligatorio.");
    }
}
```

## La solución en C# 14

```csharp
class Usuario
{
    // C# 14 permite validar una propiedad automática usando la palabra field.
    // "field" hace referencia al campo privado que el compilador genera internamente.
    // Ya no es necesario declarar "_nombre" manualmente.
    public string Nombre
    {
        get;
        set => field = value.Trim() is { Length: > 0 } limpio
            ? limpio
            : throw new ArgumentException("El nombre es obligatorio.");
    } = string.Empty; // valor inicial del campo generado
}
```

## Análisis del código

```csharp
var usuario = new Usuario { Nombre = "  Ana  " }; // espacios se eliminan en el setter
Console.WriteLine(usuario.Nombre); // "Ana"
```

| Elemento | Explicación |
|----------|-------------|
| `field` | Referencia al campo privado que el compilador generó para esta propiedad |
| `value.Trim() is { Length: > 0 } limpio` | Pattern matching: si Trim() produce algo no vacío, lo captura en `limpio` |
| `= string.Empty` | Valor inicial del campo (equivale al de la propiedad automática clásica) |

## Ejercicio propuesto

1. Limita el `Nombre` a un máximo de 50 caracteres: si tiene más, lanza `ArgumentException`.
2. Añade una propiedad `Email` que use `field` para validar que el valor contiene `@`.
3. Prueba a asignar `""` (cadena vacía) al nombre y observa la excepción.

## Referencias

- [Novedades de C# 14 — field](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-14)
- [Propiedades en C#](https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/properties)
