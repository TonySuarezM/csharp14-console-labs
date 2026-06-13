var contador = new Contador();
contador.LimiteAlcanzado += (_, valor) => Console.WriteLine($"Límite alcanzado: {valor}");

Func<int, int> cuadrado = numero => numero * numero;
Console.WriteLine($"Cuadrado: {cuadrado(5)}");
contador.Incrementar();
contador.Incrementar();

class Contador
{
    private int valor;
    public event EventHandler<int>? LimiteAlcanzado;

    public void Incrementar()
    {
        valor++;
        // El operador ?. invoca el evento solo cuando tiene suscriptores.
        if (valor >= 2) LimiteAlcanzado?.Invoke(this, valor);
    }
}
