# Nivel 2: Fundamentos

Este nivel presenta las estructuras que aparecen en prácticamente cualquier aplicación C# real:
colecciones para almacenar datos, clases para modelar el dominio, herencia e interfaces para
compartir comportamiento, y excepciones para gestionar errores de forma controlada.

## Prerrequisitos

Haber completado el **Nivel 1 — Principiante** y entender variables, bucles y métodos.

## Laboratorios

| # | Carpeta | Concepto clave | Tiempo estimado |
|---|---------|----------------|-----------------|
| 1 | `01-ArraysYColecciones` | `int[]`, `List<T>`, `Dictionary<K,V>` | 15 min |
| 2 | `02-CadenasYEnumeraciones` | Métodos de `string`, `enum` | 10 min |
| 3 | `03-ClasesYObjetos` | Primary constructors, propiedades, encapsulamiento | 15 min |
| 4 | `04-HerenciaEInterfaces` | `interface`, `abstract`, `sealed`, polimorfismo | 20 min |
| 5 | `05-Excepciones` | `try/catch/finally`, excepciones específicas | 15 min |

## Objetivo global del nivel

Modelar un pequeño sistema de alumnos y notas: una clase `Alumno` con nombre y lista de notas
(`List<decimal>`), un método `Promedio()`, y un programa que lea datos por consola y muestre
los resultados, manejando entradas inválidas con `try/catch`.

## Ejercicios transversales

- Añade un tercer alumno al `Dictionary` de puntuaciones en `01-ArraysYColecciones`.
- Crea una subclase `Pez` en `04-HerenciaEInterfaces` y agrégala a la lista de animales.
- Añade un método `Retirar(decimal cantidad)` a `CuentaBancaria` que lance una excepción
  personalizada si el saldo es insuficiente.
