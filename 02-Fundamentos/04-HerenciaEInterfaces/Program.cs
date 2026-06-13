// La lista es de tipo base Animal, pero contiene objetos concretos Perro y Gato.
// Esto es polimorfismo: tratar distintos tipos de forma uniforme.
List<Animal> animales = [new Perro("Luna"), new Gato("Milo")];
foreach (Animal animal in animales)
    // Cada llamada a EmitirSonido() despacha al método correcto según el tipo real.
    Console.WriteLine($"{animal.Nombre}: {animal.EmitirSonido()}");

// interface: contrato puro; define QUÉ puede hacer un tipo, no CÓMO lo hace.
interface INombrable { string Nombre { get; } }

// abstract: la clase base no puede instanciarse directamente con "new Animal()".
// Hereda de INombrable e implementa la propiedad Nombre.
abstract class Animal(string nombre) : INombrable
{
    public string Nombre { get; } = nombre;
    // Cada clase derivada DEBE proporcionar su propia implementación de este método.
    public abstract string EmitirSonido();
}

// sealed: impide que otras clases hereden de Perro, previniendo jerarquías innecesarias.
sealed class Perro(string nombre) : Animal(nombre)
{
    // override: sobreescribe el método abstracto de la clase base.
    public override string EmitirSonido() => "guau";
}

sealed class Gato(string nombre) : Animal(nombre)
{
    public override string EmitirSonido() => "miau";
}
