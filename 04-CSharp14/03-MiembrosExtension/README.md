# Miembros de extensión (C# 14)

**Nivel:** 4 — C# 14  |  **Concepto clave:** Bloque `extension` con propiedades de instancia y estáticas

## ¿Qué aprenderás?

Los **métodos de extensión** clásicos (desde C# 3) permiten añadir métodos a tipos existentes.
C# 14 introduce el bloque `extension`, que va más allá: permite añadir también **propiedades
de instancia** y **miembros estáticos** a cualquier tipo sin modificarlo ni heredarlo.

## El estado anterior (C# 3 — métodos de extensión clásicos)

```csharp
// ANTES: solo se podían añadir métodos, no propiedades
static class ExtensionesTextoAntes
{
    // Método de extensión: primer parámetro "this string texto"
    public static int NumeroPalabras(this string texto) =>
        texto.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    // No era posible crear "frase.NumeroPalabras" como propiedad
}
```

## La novedad en C# 14

```csharp
static class ExtensionesTexto
{
    // Un bloque extension puede añadir propiedades de instancia y estáticas.
    // "extension(string texto)" declara que los miembros siguientes extienden string.
    extension(string texto)
    {
        // Propiedad de instancia: se usa como frase.NumeroPalabras
        public int NumeroPalabras =>
            texto.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

        // Propiedad estática: se usa como string.Vacio (igual que string.Empty)
        public static string Vacio => string.Empty;
    }
}
```

## Análisis del código

```csharp
string frase = "C# 14 añade miembros de extensión";
Console.WriteLine($"Palabras: {frase.NumeroPalabras}"); // propiedad de instancia
Console.WriteLine($"Vacío: '{string.Vacio}'");           // propiedad estática
```

| Característica | C# clásico | C# 14 con `extension` |
|---|---|---|
| Método de extensión | ✅ `this string s` | ✅ dentro de `extension(string s)` |
| Propiedad de instancia | ❌ | ✅ |
| Miembro estático | ❌ | ✅ |

## Ejercicio propuesto

1. Añade una propiedad `bool EstaVacia => texto.Trim().Length == 0` al bloque de extensión.
2. Crea un bloque `extension(int numero)` en la misma clase con una propiedad
   `bool EsPar => numero % 2 == 0` y pruébala con `5.EsPar`.
3. Añade un miembro estático `int.MaximoSeguro` que retorne `int.MaxValue - 1`.

## Referencias

- [Novedades de C# 14 — miembros de extensión](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-14)
- [Métodos de extensión clásicos](https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)
