# LINQ

**Nivel:** 3 — Intermedio  |  **Concepto clave:** Consultas declarativas sobre colecciones

## ¿Qué aprenderás?

**LINQ** (Language Integrated Query) permite filtrar, ordenar y transformar colecciones con
una sintaxis declarativa: describes *qué* quieres, no *cómo* obtenerlo. Internamente usa
delegados y lambdas para ejecutar cada operación.

Una característica clave es la **ejecución diferida**: la consulta LINQ no se ejecuta cuando
se define, sino cuando se itera (en el `foreach` o al llamar a `.ToList()`).

## Conceptos cubiertos

- **`Where(predicado)`** — filtra elementos que cumplen la condición.
- **`OrderBy(selector)`** / **`OrderByDescending`** — ordena la secuencia.
- **`Select(proyección)`** — transforma cada elemento en otro (mapeo).
- **Encadenamiento fluent** — los métodos se encadenan; cada uno recibe y devuelve `IEnumerable<T>`.
- **Ejecución diferida** — la consulta se evalúa al iterar, no al definirla.

## Análisis del código

```csharp
List<Producto> productos =
[
    new("Teclado", 45m),
    new("Ratón", 20m),
    new("Monitor", 180m)
];

// La consulta se construye aquí pero NO se ejecuta todavía.
// Where filtra, OrderBy ordena, Select proyecta a string.
var caros = productos
    .Where(producto => producto.Precio >= 40m)
    .OrderBy(producto => producto.Precio)
    .Select(producto => $"{producto.Nombre}: {producto.Precio:C}");

// La consulta se ejecuta AQUÍ, al iterar con foreach.
foreach (string descripcion in caros)
    Console.WriteLine(descripcion);

record Producto(string Nombre, decimal Precio);
```

> Si añades un producto a la lista después de definir `caros` pero antes del `foreach`,
> el nuevo producto también aparecerá. Eso es la ejecución diferida en acción.

## Ejercicio propuesto

1. Calcula el precio medio con `.Average(p => p.Precio)` y muéstralo.
2. Usa `.GroupBy(p => p.Precio >= 100m)` para separar productos caros (≥ 100€) de baratos
   y muestra cada grupo.
3. Usa `.First()` y `.FirstOrDefault()` para obtener el producto más barato. ¿Qué diferencia
   hay si la lista está vacía?

## Referencias

- [LINQ en C#](https://learn.microsoft.com/dotnet/csharp/linq/)
- [Métodos de extensión LINQ](https://learn.microsoft.com/dotnet/api/system.linq.enumerable)
- [Ejecución diferida](https://learn.microsoft.com/dotnet/standard/linq/deferred-execution-lazy-evaluation)
