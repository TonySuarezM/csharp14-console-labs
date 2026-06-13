# Nivel 3: Intermedio

Este nivel da el salto a los patrones y mecanismos que se encuentran en código profesional:
genéricos para escribir código reutilizable con seguridad de tipos, eventos y delegados para
la comunicación entre objetos, LINQ para expresar consultas de forma declarativa, records y
pattern matching para modelar datos inmutables, y la base de la programación asíncrona.

## Prerrequisitos

Haber completado los **Niveles 1 y 2**. En particular:
- Entender clases, interfaces y herencia (`04-HerenciaEInterfaces`).
- Saber usar `List<T>` y `Dictionary<K,V>` (`01-ArraysYColecciones`).
- Conocer el bloque `try/catch` (`05-Excepciones`).

## Laboratorios

| # | Carpeta | Concepto clave | Tiempo estimado |
|---|---------|----------------|-----------------|
| 1 | `01-Genericos` | Parámetro de tipo `T`, constraints `where` | 15 min |
| 2 | `02-DelegadosLambdasYEventos` | `Func<>`, lambda, `event EventHandler<T>` | 20 min |
| 3 | `03-Linq` | `Where`, `OrderBy`, `Select`, ejecución diferida | 20 min |
| 4 | `04-RecordsYPatrones` | Record posicional, `with`, property patterns | 20 min |
| 5 | `05-ArchivosYJson` | `System.Text.Json`, `File`, `Path` | 15 min |
| 6 | `06-AsyncYNullable` | `async/await`, `Task<T>`, nullable `T?` | 20 min |

## Orden de estudio recomendado

Sigue la numeración. `02-DelegadosLambdasYEventos` introduce los delegados que LINQ usa
internamente, por lo que conviene verlo antes de `03-Linq`. El laboratorio `06-AsyncYNullable`
se apoya en conceptos de los anteriores.

## Objetivo global del nivel

Construir una pequeña librería de productos con:
- Una clase genérica `Repositorio<T>` para almacenar cualquier entidad.
- Un evento `ElementoAgregado` que notifique cada inserción.
- Consultas LINQ para filtrar y ordenar productos.
- Persistencia en un archivo JSON con `System.Text.Json`.
- Una función asíncrona simulada de carga de datos desde "red".

## Referencias

- [Genéricos en C#](https://learn.microsoft.com/dotnet/csharp/fundamentals/types/generics)
- [LINQ](https://learn.microsoft.com/dotnet/csharp/linq/)
- [Programación asíncrona](https://learn.microsoft.com/dotnet/csharp/asynchronous-programming/)
- [Records](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/record)
