var cliente = new Cliente("Ana");
cliente.Cambio += (_, mensaje) => Console.WriteLine(mensaje);
cliente.Notificar();

partial class Cliente
{
    // C# 14 permite declarar constructores y eventos parciales.
    public partial Cliente(string nombre);
    public partial event EventHandler<string> Cambio;
}

partial class Cliente
{
    public string Nombre { get; }
    public partial Cliente(string nombre) => Nombre = nombre;

    private EventHandler<string>? cambio;
    public partial event EventHandler<string> Cambio
    {
        add => cambio += value;
        remove => cambio -= value;
    }

    public void Notificar() => cambio?.Invoke(this, $"Cambio en {Nombre}");
}
