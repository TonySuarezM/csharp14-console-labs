var cliente = new Cliente("Ana");
cliente.Cambio += (_, mensaje) => Console.WriteLine(mensaje);
cliente.Notificar();

// PARTE 1: declaraciones (simula lo que generaría un source generator automáticamente)
partial class Cliente
{
    // C# 14 permite declarar constructores y eventos parciales.
    // La declaración anuncia la firma; la implementación se escribe en otra parte del código.
    public partial Cliente(string nombre);
    public partial event EventHandler<string> Cambio;
}

// PARTE 2: implementaciones (escrita por el desarrollador)
partial class Cliente
{
    public string Nombre { get; }
    // Implementación del constructor parcial: asigna el parámetro a la propiedad.
    public partial Cliente(string nombre) => Nombre = nombre;

    // Evento parcial con accessors explícitos: el desarrollador controla cómo
    // se suscribe (add) y desuscribe (remove) al evento.
    private EventHandler<string>? cambio;
    public partial event EventHandler<string> Cambio
    {
        add    => cambio += value;
        remove => cambio -= value;
    }

    public void Notificar() => cambio?.Invoke(this, $"Cambio en {Nombre}");
}
