# Métodos

**Nivel:** 1 — Principiante  |  **Concepto clave:** Métodos locales, parámetros y reutilización

## ¿Qué aprenderás?

Cuando una operación se repite o conviene nombrarla claramente, se extrae a un **método**.
Un método tiene un nombre, recibe cero o más **parámetros** y puede devolver un valor
(**tipo de retorno**) o nada (`void`).

En programas con top-level statements los métodos locales se declaran con `static` y pueden
aparecer en cualquier parte del archivo; el compilador los encuentra aunque los uses antes de
declararlos (similar al "hoisting" de funciones en JavaScript).

## Conceptos cubiertos

- **Método local `static`** — función declarada dentro del mismo archivo; no pertenece a ninguna clase.
- **Parámetros** — valores de entrada que recibe el método entre paréntesis.
- **Tipo de retorno** — tipo del valor que devuelve (`string`, `int`, `void`, etc.).
- **Expression body `=>`** — azúcar sintáctico para métodos de una sola expresión.

## Análisis del código

```csharp
Console.WriteLine(CrearSaludo("Lucía"));
Console.WriteLine($"Área: {CalcularArea(4, 3)}");

// Los métodos agrupan lógica reutilizable y pueden devolver un resultado.
// "static" es obligatorio en top-level statements al no haber instancia de clase.
static string CrearSaludo(string nombre) => $"Hola, {nombre}.";
// Expression body (=>) equivale a { return ancho * alto; }
static int CalcularArea(int ancho, int alto) => ancho * alto;
```

| Elemento | Descripción |
|----------|-------------|
| `static string CrearSaludo(string nombre)` | Retorna `string`, recibe un `string` llamado `nombre` |
| `=> $"Hola, {nombre}."` | Cuerpo de expresión: equivale a `{ return $"Hola, {nombre}."; }` |
| `static int CalcularArea(int ancho, int alto)` | Retorna `int`, recibe dos enteros |

## Ejercicio propuesto

1. Crea un método `CalcularPerimetro(int base, int altura)` que devuelva `2 * (base + altura)`.
2. Crea un método `EsPositivo(int numero)` que devuelva `bool` e indique si el número es > 0.
3. Crea un método `AreaTriangulo(double base, double altura)` que retorne `base * altura / 2`
   y muéstralo formateado con dos decimales: `{resultado:F2}`.

## Referencias

- [Métodos en C#](https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/methods)
- [Miembros con cuerpo de expresión](https://learn.microsoft.com/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members)
