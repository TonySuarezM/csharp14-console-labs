// for resulta útil cuando conocemos el número de repeticiones.
// Estructura: for (inicialización; condición; incremento)
// numero++ equivale a numero = numero + 1; se ejecuta al final de cada iteración.
for (int numero = 1; numero <= 5; numero++)
    Console.WriteLine($"Cuadrado de {numero}: {numero * numero}");

// Array literal [...]: sintaxis de C# 12+ para inicializar arrays de forma concisa.
string[] frutas = ["manzana", "pera", "naranja"];
// foreach recorre cada elemento de la colección sin necesidad de gestionar el índice.
// Preferible a for cuando no necesitas modificar la colección ni conocer la posición.
foreach (string fruta in frutas)
    Console.WriteLine(fruta);
