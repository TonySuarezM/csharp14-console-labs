List<Animal> animales = [new Perro("Luna"), new Gato("Milo")];
foreach (Animal animal in animales)
    Console.WriteLine($"{animal.Nombre}: {animal.EmitirSonido()}");

interface INombrable { string Nombre { get; } }

abstract class Animal(string nombre) : INombrable
{
    public string Nombre { get; } = nombre;
    // Cada clase derivada debe proporcionar su propia implementación.
    public abstract string EmitirSonido();
}

sealed class Perro(string nombre) : Animal(nombre)
{
    public override string EmitirSonido() => "guau";
}

sealed class Gato(string nombre) : Animal(nombre)
{
    public override string EmitirSonido() => "miau";
}
