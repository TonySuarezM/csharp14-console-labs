# Asignación condicional nula `?.=` (C# 14)

**Nivel:** 4 — C# 14  |  **Concepto clave:** Operador `?.` en el lado izquierdo de una asignación

## ¿Qué aprenderás?

Antes de C# 14, el operador `?.` solo podía aparecer en el lado **derecho** de una expresión
(para leer o invocar). C# 14 extiende su uso al lado **izquierdo**: ahora puedes asignar o
modificar una propiedad de forma condicional sin escribir un `if` explícito.

## El problema antes de C# 14

```csharp
// ANTES: había que comprobar nulidad antes de asignar
if (pedido != null)
{
    pedido.Estado = "Preparado";
    pedido.Intentos += 1;
}
```

## La solución en C# 14

```csharp
// En C# 14, ?. puede aparecer a la izquierda de una asignación.
// Si pedido es null, la asignación se omite silenciosamente.
pedido?.Estado = "Preparado";
pedido?.Intentos += 1;   // equivale a: if (pedido != null) pedido.Intentos += 1;
```

## Análisis del código

```csharp
// La variable puede ser null según el segundo actual (para demostrar ambos casos).
Pedido? pedido = DateTime.Now.Second % 2 == 0 ? new Pedido() : null;

pedido?.Estado = "Preparado";
pedido?.Intentos += 1;

// ?? devuelve "No existe pedido." si pedido es null o Estado es null.
Console.WriteLine(pedido?.Estado ?? "No existe pedido.");

class Pedido
{
    public string Estado { get; set; } = "Nuevo";
    public int Intentos { get; set; }
}
```

| Expresión C# 14 | Equivalente anterior |
|---|---|
| `pedido?.Estado = "X"` | `if (pedido != null) pedido.Estado = "X";` |
| `pedido?.Intentos += 1` | `if (pedido != null) pedido.Intentos += 1;` |
| `pedido?.Lista.Add(x)` | `if (pedido != null) pedido.Lista.Add(x);` |

## Ejercicio propuesto

1. Añade una propiedad `string? Notas` a `Pedido` y asígnale texto condicionalmente.
2. Crea una `List<string>? etiquetas` en `Pedido` y usa `pedido?.etiquetas?.Add("urgente")`
   para observar el encadenamiento de `?.`.
3. Fuerza `pedido` a `null` y ejecuta el programa para confirmar que no lanza excepción.

## Referencias

- [Novedades de C# 14](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-14)
- [Operadores de acceso a miembros y null-conditional](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-)
