# Cadenas y enumeraciones

**Nivel:** 2 — Fundamentos  |  **Concepto clave:** Manipulación de `string` y tipo `enum`

## ¿Qué aprenderás?

Los `string` en C# son **inmutables**: cada método como `Trim()` o `ToUpperInvariant()`
devuelve una nueva cadena, no modifica la original. Entender esto evita confusiones frecuentes.

Los `enum` son tipos que asignan **nombres legibles** a valores enteros. Hacen el código más
expresivo y evitan usar "números mágicos" para representar estados o categorías.

## Conceptos cubiertos

- **`Trim()`** — elimina espacios en blanco al inicio y al final.
- **`ToUpperInvariant()`** — convierte a mayúsculas ignorando la cultura del sistema (más seguro que `ToUpper()`).
- **`Contains(subcadena)`** — devuelve `true` si la cadena contiene el texto indicado.
- **`enum`** — tipo enumerado; cada nombre tiene un valor entero asignado.
- **Valores explícitos** — `Lunes = 1` fija el entero; los siguientes se incrementan automáticamente.

## Análisis del código

```csharp
string texto = "  aprender C# 14  ";
// Trim() quita los espacios extremos; ToUpperInvariant() convierte a mayúsculas.
// Ambos devuelven una nueva cadena; la variable "texto" no cambia.
string limpio = texto.Trim().ToUpperInvariant();
Console.WriteLine(limpio);                              // "APRENDER C# 14"
Console.WriteLine($"Contiene C#: {limpio.Contains("C#")}");

DiaLaboral hoy = DiaLaboral.Viernes;
// El cast (int) extrae el valor entero del miembro del enum.
Console.WriteLine($"Hoy es {hoy} ({(int)hoy}).");       // "Hoy es Viernes (5)."

// Lunes=1 fija el inicio; Martes=2, Miercoles=3... se asignan automáticamente.
enum DiaLaboral { Lunes = 1, Martes, Miercoles, Jueves, Viernes }
```

> Usa `ToUpperInvariant()` en lugar de `ToUpper()` para operaciones de comparación o
> búsqueda que no dependan del idioma del sistema operativo.

## Ejercicio propuesto

1. Añade `Sabado` y `Domingo` a la enumeración y muestra si el día actual es fin de semana.
2. Escribe un método `bool EsPalindromo(string texto)` que devuelva `true` si la cadena
   es igual al revés. Pista: `new string(texto.Reverse().ToArray())`.
3. Pide una frase al usuario, limpia los espacios, pásala a minúsculas con `ToLowerInvariant()`
   y cuenta cuántas veces aparece la letra 'a'.

## Referencias

- [string (tipo)](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)
- [Métodos de string](https://learn.microsoft.com/dotnet/api/system.string)
- [enum](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/enum)
