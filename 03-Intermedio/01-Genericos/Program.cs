var caja = new Caja<string>("mensaje importante");
Console.WriteLine(caja.Contenido);
Console.WriteLine($"Máximo: {Maximo(4, 9)}");

static T Maximo<T>(T primero, T segundo) where T : IComparable<T>
    => primero.CompareTo(segundo) >= 0 ? primero : segundo;

// T representa un tipo que se decide al utilizar la clase o el método.
record Caja<T>(T Contenido);
