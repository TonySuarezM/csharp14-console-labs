var contador = new Contador();
// += suscribe un manejador al evento: la lambda se ejecutará cuando el evento se dispare.
// El parámetro _ (sender) se descarta porque no lo necesitamos.
contador.LimiteAlcanzado += (_, valor) => Console.WriteLine($"Límite alcanzado: {valor}");

// Func<int, int>: tipo delegate predefinido para funciones que reciben y devuelven int.
// La lambda "numero => numero * numero" define el comportamiento en línea.
Func<int, int> cuadrado = numero => numero * numero;
Console.WriteLine($"Cuadrado: {cuadrado(5)}");
contador.Incrementar();
contador.Incrementar(); // al llegar a 2, dispara el evento LimiteAlcanzado

class Contador
{
    private int valor;
    public event EventHandler<int>? LimiteAlcanzado;

    public void Incrementar()
    {
        valor++;
        // El operador ?. invoca el evento solo cuando tiene suscriptores.
        // Sin ?., si nadie se ha suscrito lanzaría NullReferenceException.
        if (valor >= 2) LimiteAlcanzado?.Invoke(this, valor);
    }
}
