# Records y patrones

**Nivel:** 3 — Intermedio  |  **Concepto clave:** Records inmutables y pattern matching

## ¿Qué aprenderás?

Un **record** es un tipo de referencia en C# diseñado para representar datos inmutables. A
diferencia de las clases, los records tienen igualdad por valor (dos records con los mismos
datos son iguales) y generan automáticamente `ToString`, `Equals` y `GetHashCode`.

El **pattern matching** (coincidencia de patrones) permite inspeccionar el tipo y las
propiedades de un objeto en una sola expresión, eliminando castings y condiciones anidadas.

## Conceptos cubiertos

- **Record posicional `record Persona(string Nombre, int Edad)`** — declara propiedades y constructor en una línea.
- **Igualdad por valor** — `new Persona("Ana", 28) == new Persona("Ana", 28)` es `true`.
- **Expresión `with`** — crea una copia del record con algunos valores modificados.
- **Property pattern** — `{ Edad: < 18 }` comprueba el valor de una propiedad.
- **Var pattern** — `{ Nombre: var nombre }` captura el valor en una nueva variable.

## Análisis del código

```csharp
Persona original = new("Ana", 28);
// "with" crea una COPIA con Edad=29; "original" sigue siendo { Nombre="Ana", Edad=28 }.
Persona copia = original with { Edad = 29 };
Console.WriteLine($"{original} / {copia}");
Console.WriteLine(Clasificar(copia));

static string Clasificar(object valor) => valor switch
{
    // Property pattern: coincide si valor es Persona Y Edad < 18.
    Persona { Edad: < 18 }                          => "Persona menor de edad",
    // Var pattern: captura Nombre en la variable "nombre" para usarla en la expresión.
    Persona { Edad: >= 18, Nombre: var nombre }      => $"{nombre} es adulta",
    null                                             => "Sin valor",
    _                                                => "Tipo desconocido"
};

// Los records proporcionan igualdad por valor y una sintaxis concisa.
record Persona(string Nombre, int Edad);
```

## Ejercicio propuesto

1. Añade un caso al switch para personas mayores de 65: `"Persona mayor"`.
2. Crea un record `Producto(string Nombre, decimal Precio)` y clasifícalo en switch
   como "barato" (< 10€), "normal" (10-100€) o "caro" (> 100€).
3. Comprueba que dos records con los mismos valores son iguales con `==` y que dos
   instancias de una clase con los mismos valores NO son iguales sin `override`.

## Referencias

- [Records en C#](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/record)
- [Pattern matching](https://learn.microsoft.com/dotnet/csharp/fundamentals/functional/pattern-matching)
- [Expresión with](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/with-expression)
