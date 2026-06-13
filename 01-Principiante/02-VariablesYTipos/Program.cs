string nombre = "Ana";
int edad = 28;
decimal precio = 19.95m; // El sufijo m indica que el literal es decimal.
bool estaAprendiendo = true;
const string Lenguaje = "C# 14"; // Una constante no puede cambiar después.

Console.WriteLine($"{nombre} tiene {edad} años.");
Console.WriteLine($"Curso: {Lenguaje}, precio: {precio:C}, activo: {estaAprendiendo}");
