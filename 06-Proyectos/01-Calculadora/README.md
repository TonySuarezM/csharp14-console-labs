# Proyecto: Calculadora

**Nivel:** 6 — Proyectos integradores

## ¿Qué integra este proyecto?

Una calculadora de consola que lee una expresión como `8 * 3` y evalúa el resultado.
Combina lectura de entrada, validación robusta, y selección de operación con switch expression
incluyendo guard clauses (`when`).

## Tecnologías integradas

| Concepto | Dónde se usa |
|----------|-------------|
| `Console.ReadLine` + `??` | Lectura segura de la expresión con valor por defecto |
| `string.Split` con `RemoveEmptyEntries` | División de la expresión en sus tres partes |
| `decimal.TryParse` | Conversión segura sin excepción si el formato es incorrecto |
| Switch expression con `when` | Selección de operación y validación de división por cero |
| Guard clause de retorno anticipado | Salida limpia cuando el formato es incorrecto |

## Flujo del programa

```
Entrada: "8 * 3"
    ↓ Split(' ') → ["8", "*", "3"]
    ↓ decimal.TryParse("8") → 8m, decimal.TryParse("3") → 3m
    ↓ switch partes[1]:
        "+" → 8 + 3 = 11
        "-" → 8 - 3 = 5
        "*" → 8 * 3 = 24
        "/" when derecha != 0 → 8 / 3 = 2.666...
        _   → null (operación no válida)
    ↓ Mostrar resultado o "Operación no válida."
```

## Análisis del código

```csharp
Console.WriteLine("Calculadora: escribe una operación como 8 * 3");
string[] partes = (Console.ReadLine() ?? "8 * 3").Split(' ', StringSplitOptions.RemoveEmptyEntries);

// Guard clause: sale temprano si el formato no es correcto.
// Más legible que un if-else profundo.
if (partes.Length != 3 ||
    !decimal.TryParse(partes[0], out decimal izquierda) ||
    !decimal.TryParse(partes[2], out decimal derecha))
{
    Console.WriteLine("Formato incorrecto.");
    return;
}

// El patrón switch concentra la selección y validación de operaciones.
// "when derecha != 0" es un guard: la división solo aplica si el divisor no es cero.
decimal? resultado = partes[1] switch
{
    "+" => izquierda + derecha,
    "-" => izquierda - derecha,
    "*" => izquierda * derecha,
    "/" when derecha != 0 => izquierda / derecha,
    _   => null  // operador desconocido o división por cero
};

Console.WriteLine(resultado is null ? "Operación no válida." : $"Resultado: {resultado}");
```

## Ampliaciones propuestas

1. Añade los operadores `%` (resto) y `^` (potencia con `Math.Pow`).
2. Implementa un **historial**: guarda cada operación exitosa en una `List<string>` y
   muéstrala al introducir el comando `historial`.
3. Convierte el programa en un bucle que siga leyendo operaciones hasta que el usuario
   escriba `salir`.

## Referencias

- [decimal.TryParse](https://learn.microsoft.com/dotnet/api/system.decimal.tryparse)
- [Switch expression](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/switch-expression)
- [string.Split](https://learn.microsoft.com/dotnet/api/system.string.split)
