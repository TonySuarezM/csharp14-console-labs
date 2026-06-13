string texto = "  aprender C# 14  ";
string limpio = texto.Trim().ToUpperInvariant();
Console.WriteLine(limpio);
Console.WriteLine($"Contiene C#: {limpio.Contains("C#")}");

DiaLaboral hoy = DiaLaboral.Viernes;
Console.WriteLine($"Hoy es {hoy} ({(int)hoy}).");

enum DiaLaboral { Lunes = 1, Martes, Miercoles, Jueves, Viernes }
