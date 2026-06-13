# Herencia e interfaces

**Nivel:** 2 — Fundamentos  |  **Concepto clave:** `interface`, clase `abstract`, `sealed` y polimorfismo

## ¿Qué aprenderás?

La **herencia** permite que una clase hija reutilice y especialice el comportamiento de su
clase padre. Las **interfaces** definen un contrato: un conjunto de miembros que cualquier
clase que las implemente debe proporcionar, sin imponer una jerarquía de herencia.

El **polimorfismo** ocurre cuando, al tener una colección de `Animal`, cada elemento responde
a `EmitirSonido()` según su tipo concreto, sin que el código llamador lo sepa.

## Conceptos cubiertos

- **`interface`** — contrato puro; define qué puede hacer un tipo, no cómo lo hace.
- **Clase `abstract`** — no se puede instanciar directamente; puede tener implementación parcial.
- **Método `abstract`** — obliga a las clases derivadas a proporcionar su propia implementación.
- **`sealed`** — impide que otras clases hereden de esta clase.
- **`override`** — sobreescribe un método virtual o abstracto de la clase base.
- **Polimorfismo** — tratar distintos tipos concretos de forma uniforme a través de un tipo base.

## Análisis del código

```csharp
// La lista contiene objetos de tipo base "Animal", pero en realidad son Perro y Gato.
List<Animal> animales = [new Perro("Luna"), new Gato("Milo")];
foreach (Animal animal in animales)
    // Polimorfismo: cada llamada a EmitirSonido() ejecuta la implementación correcta.
    Console.WriteLine($"{animal.Nombre}: {animal.EmitirSonido()}");

interface INombrable { string Nombre { get; } }

// abstract: clase base con contrato parcial; no se puede hacer "new Animal(...)".
abstract class Animal(string nombre) : INombrable
{
    public string Nombre { get; } = nombre;
    // Cada clase derivada DEBE proporcionar su propia implementación.
    public abstract string EmitirSonido();
}

// sealed: Perro no puede ser heredada de nuevo.
sealed class Perro(string nombre) : Animal(nombre)
{
    public override string EmitirSonido() => "guau";
}

sealed class Gato(string nombre) : Animal(nombre)
{
    public override string EmitirSonido() => "miau";
}
```

## Ejercicio propuesto

1. Crea una clase `Pez(string nombre)` que herede de `Animal` y retorne `"blub"`.
2. Añade la interfaz `IDescribible` con un método `string Describir()` e impleméntala en
   `Perro` para que retorne `$"Perro llamado {Nombre}"`.
3. Cambia `sealed` a `class` en `Perro` y crea una subclase `Labrador` que sobreescriba
   `EmitirSonido()` con `"guau fuerte"`.

## Referencias

- [Herencia](https://learn.microsoft.com/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [Interfaces](https://learn.microsoft.com/dotnet/csharp/fundamentals/types/interfaces)
- [Clases abstractas](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/abstract)
- [Polimorfismo](https://learn.microsoft.com/dotnet/csharp/fundamentals/object-oriented/polymorphism)
