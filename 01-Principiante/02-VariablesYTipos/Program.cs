// Declaración con tipo explícito: el compilador conoce el tipo en tiempo de compilación.
string nombre = "Ana";
int edad = 28;
decimal precio = 19.95m; // El sufijo m indica que el literal es decimal, no double.
bool estaAprendiendo = true;
// const: el valor queda fijado en tiempo de compilación y no puede cambiar.
const string Lenguaje = "C# 14";

// La interpolación $"..." evalúa {expresión} e inserta el resultado en la cadena.
// El especificador :C formatea el número como moneda según la cultura del sistema.
Console.WriteLine($"{nombre} tiene {edad} años.");
Console.WriteLine($"Curso: {Lenguaje}, precio: {precio:C}, activo: {estaAprendiendo}");
