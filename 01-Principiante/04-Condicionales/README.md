# Condicionales

**Nivel:** 1 — Principiante  |  **Concepto clave:** Toma de decisiones con `if` y switch expression

## ¿Qué aprenderás?

Los programas necesitan ejecutar distintas acciones según los datos. `if/else if/else` es la
forma clásica; la **switch expression** (C# 8+) es una alternativa más compacta y expresiva
cuando hay múltiples casos basados en el valor de una variable.

## Conceptos cubiertos

- **`if / else if / else`** — evalúa condiciones en orden; ejecuta el primer bloque verdadero.
- **Switch expression** — evalúa una expresión y devuelve un valor según el patrón que coincida.
- **Patrones relacionales** — `< 10`, `> 30` dentro de un switch expression (C# 9+).
- **Patrón comodín `_`** — coincide con cualquier valor que no hayan capturado los casos anteriores.

## Análisis del código

```csharp
int temperatura = 24;

// if/else if/else: clásico, admite condiciones complejas con &&, ||, etc.
if (temperatura < 10)
    Console.WriteLine("Hace frío.");
else if (temperatura < 25)
    Console.WriteLine("La temperatura es agradable.");
else
    Console.WriteLine("Hace calor.");

// Switch expression: más compacta cuando el resultado es un valor único.
// Cada caso es "patrón => valor". El _ al final actúa como "else".
string consejo = temperatura switch
{
    < 10 => "Lleva abrigo.",
    > 30 => "Bebe agua.",
    _    => "Disfruta del día."
};
Console.WriteLine(consejo);
```

| Construcción | Cuándo usarla |
|---|---|
| `if/else if/else` | Condiciones independientes o con lógica compleja (`&&`, `\|\|`) |
| Switch expression | Múltiples casos sobre el mismo valor; resultado es una expresión |

## Ejercicio propuesto

1. Lee la temperatura desde la consola (`int.Parse(Console.ReadLine() ?? "20")`).
2. Amplía la switch expression para cubrir `> 35` con "¡Peligro de golpe de calor!".
3. Crea un sistema de notas: dado un número del 0 al 10, muestra "Suspenso" (< 5),
   "Aprobado" (5-6), "Notable" (7-8) o "Sobresaliente" (9-10).

## Referencias

- [if-else](https://learn.microsoft.com/dotnet/csharp/language-reference/statements/selection-statements)
- [Switch expression](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/switch-expression)
- [Patrones relacionales](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/patterns#relational-patterns)
