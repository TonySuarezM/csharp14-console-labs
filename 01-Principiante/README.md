# Nivel 1: Principiante

Este nivel cubre los fundamentos absolutos del lenguaje. No se necesita experiencia previa en C#;
basta con tener instalado el SDK de .NET 10 y saber abrir una terminal o Visual Studio.

Al terminar este nivel serás capaz de escribir programas que muestren información, lean datos del
usuario, tomen decisiones y repitan acciones, todo organizado en métodos reutilizables.

## Laboratorios

| # | Carpeta | Concepto clave | Tiempo estimado |
|---|---------|----------------|-----------------|
| 1 | `01-HolaMundo` | Top-level statements, `Console.WriteLine` | 5 min |
| 2 | `02-VariablesYTipos` | Variables, tipos primitivos, constantes, interpolación | 10 min |
| 3 | `03-EntradaYOperadores` | `Console.ReadLine`, `int.Parse`, operadores | 10 min |
| 4 | `04-Condicionales` | `if/else if/else`, switch expression | 10 min |
| 5 | `05-Bucles` | `for`, `foreach`, arrays | 10 min |
| 6 | `06-Metodos` | Métodos locales, expression body `=>` | 10 min |

## Prerrequisitos

- .NET SDK 10 instalado (`dotnet --version` debe mostrar `10.x`).
- Haber leído el [README raíz](../README.md) y ejecutado `dotnet build` sin errores.

## Objetivo global del nivel

Escribir un programa de consola completo que: lea el nombre del usuario, calcule algo con ese
dato (p. ej. cuántas letras tiene) y muestre el resultado usando al menos un método propio.

## Consejo de práctica

Modifica los valores de los ejemplos antes de avanzar al siguiente. Cambiar `temperatura = 24`
por distintos valores en `04-Condicionales` y ver qué rama se ejecuta es más instructivo que
leer la explicación.
