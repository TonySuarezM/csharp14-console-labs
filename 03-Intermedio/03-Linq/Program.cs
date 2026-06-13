List<Producto> productos =
[
    new("Teclado", 45m),
    new("Ratón", 20m),
    new("Monitor", 180m)
];

// LINQ expresa filtros, ordenaciones y proyecciones sobre colecciones.
var caros = productos
    .Where(producto => producto.Precio >= 40m)
    .OrderBy(producto => producto.Precio)
    .Select(producto => $"{producto.Nombre}: {producto.Precio:C}");

foreach (string descripcion in caros)
    Console.WriteLine(descripcion);

record Producto(string Nombre, decimal Precio);
