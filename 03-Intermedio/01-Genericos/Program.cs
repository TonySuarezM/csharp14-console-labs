// T se reemplaza por el tipo concreto al usar la clase o el método.
// Caja<string> y Caja<int> son dos tipos distintos en tiempo de compilación.
var caja = new Caja<string>("mensaje importante");
Console.WriteLine(caja.Contenido);
// El compilador infiere T=int a partir de los argumentos (4 y 9).
Console.WriteLine($"Máximo: {Maximo(4, 9)}");

// Constraint "where T : IComparable<T>": el compilador garantiza en tiempo de compilación
// que T tiene un método CompareTo. Sin esto no podríamos llamar a CompareTo.
// Ventaja sobre object: no hay boxing ni castings; los errores se detectan antes de ejecutar.
static T Maximo<T>(T primero, T segundo) where T : IComparable<T>
    => primero.CompareTo(segundo) >= 0 ? primero : segundo;

// T representa un tipo que se decide al utilizar la clase o el método.
record Caja<T>(T Contenido);
