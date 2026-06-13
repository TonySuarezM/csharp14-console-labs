List<Producto> productos =
[
    new("Teclado", 45m),
    new("Ratón", 20m),
    new("Monitor", 180m)
];

// LINQ expresa filtros, ordenaciones y proyecciones sobre colecciones de forma declarativa.
// Los métodos se encadenan: cada uno recibe IEnumerable<T> y devuelve IEnumerable<T>.
// IMPORTANTE: la consulta no se ejecuta aquí, sino al iterar con foreach (ejecución diferida).
var caros = productos
    .Where(producto => producto.Precio >= 40m)       // filtro
    .OrderBy(producto => producto.Precio)             // ordenación ascendente
    .Select(producto => $"{producto.Nombre}: {producto.Precio:C}"); // proyección a string

// La consulta se ejecuta AQUÍ al iterar.
foreach (string descripcion in caros)
    Console.WriteLine(descripcion);

record Producto(string Nombre, decimal Precio);
