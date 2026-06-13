string texto = "  aprender C# 14  ";
// Los strings son inmutables: Trim() y ToUpperInvariant() devuelven NUEVAS cadenas.
// ToUpperInvariant es preferible a ToUpper para operaciones que no deben depender
// del idioma del sistema operativo (p. ej. comparaciones en código de infraestructura).
string limpio = texto.Trim().ToUpperInvariant();
Console.WriteLine(limpio);
Console.WriteLine($"Contiene C#: {limpio.Contains("C#")}");

// Los enums asignan nombres legibles a valores enteros, evitando "números mágicos".
DiaLaboral hoy = DiaLaboral.Viernes;
// El cast (int) extrae el valor numérico subyacente del miembro del enum.
Console.WriteLine($"Hoy es {hoy} ({(int)hoy}).");

// Lunes=1 fija el inicio; los siguientes se asignan automáticamente: Martes=2, Miercoles=3...
enum DiaLaboral { Lunes = 1, Martes, Miercoles, Jueves, Viernes }
