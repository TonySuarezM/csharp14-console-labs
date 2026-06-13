# Variables y tipos

**Nivel:** 1 — Principiante  |  **Concepto clave:** Tipos primitivos, variables y constantes

## ¿Qué aprenderás?

En C#, cada valor tiene un **tipo** que determina qué datos puede almacenar y qué operaciones
se pueden realizar. Declarar el tipo explícitamente (`string nombre`) comunica claramente la
intención; usar `var` deja que el compilador lo infiera cuando ya es obvio.

Las **constantes** (`const`) son variables cuyo valor no puede cambiar después de declararse;
el compilador lo verifica y avisa si intentas modificarlas.

## Conceptos cubiertos

- **`string`** — cadena de texto (entre comillas dobles).
- **`int`** — número entero de 32 bits.
- **`decimal`** — número con decimales de alta precisión; se usa para dinero. Sufijo: `m`.
- **`bool`** — valor lógico `true` o `false`.
- **`const`** — constante: se declara una vez y no puede cambiar.
- **Interpolación `$"..."`** — permite insertar variables dentro de una cadena con `{variable}`.

## Análisis del código

```csharp
string nombre = "Ana";           // tipo explícito string
int edad = 28;                   // tipo explícito int
decimal precio = 19.95m;         // el sufijo m indica que el literal es decimal
bool estaAprendiendo = true;
const string Lenguaje = "C# 14"; // una constante no puede cambiar después

Console.WriteLine($"{nombre} tiene {edad} años.");
Console.WriteLine($"Curso: {Lenguaje}, precio: {precio:C}, activo: {estaAprendiendo}");
```

| Elemento | Explicación |
|----------|-------------|
| `19.95m` | Sin la `m` el compilador trataría el literal como `double`, no `decimal` |
| `const string Lenguaje` | La mayúscula inicial es convención para constantes de tipo primitivo |
| `{precio:C}` | El especificador `:C` formatea el número como moneda según la cultura del sistema |

## Ejercicio propuesto

1. Añade una variable `double altura = 1.75;` y muéstrala en pantalla.
2. Declara una constante `const int AñoActual = 2025` y muestra cuántos años tiene `nombre`
   si nació en `AñoActual - edad`.
3. Cambia el tipo de `precio` a `double` (elimina la `m`) y observa si el compilador avisa.

## Referencias

- [Tipos integrados de C#](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/built-in-types)
- [Interpolación de cadenas](https://learn.microsoft.com/dotnet/csharp/language-reference/tokens/interpolated)
- [const](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/const)
