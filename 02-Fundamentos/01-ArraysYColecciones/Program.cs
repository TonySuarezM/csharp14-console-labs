// Array de tamaño fijo: una vez creado no puede crecer ni reducirse.
// La sintaxis [...] de C# 12+ inicializa el array de forma concisa.
int[] notas = [7, 9, 6];
// List<T> es dinámica: crece con Add() y se reduce con Remove().
// Es la colección más usada cuando el tamaño no es conocido de antemano.
List<string> alumnos = ["Ana", "Luis"];
alumnos.Add("Marta"); // añade al final; ahora tiene 3 elementos
// Dictionary<K,V> almacena pares clave-valor; la clave debe ser única.
// El acceso por clave es O(1) promedio, mucho más rápido que buscar en una lista.
Dictionary<string, int> puntuaciones = new() { ["Ana"] = 10, ["Luis"] = 8 };

Console.WriteLine($"Primera nota: {notas[0]}"); // índice 0 = primer elemento
// string.Join une todos los elementos con el separador indicado.
Console.WriteLine($"Alumnos: {string.Join(", ", alumnos)}");
Console.WriteLine($"Puntos de Ana: {puntuaciones["Ana"]}");
