Pedido? pedido = DateTime.Now.Second % 2 == 0 ? new Pedido() : null;

// En C# 14, ?. puede aparecer a la izquierda de una asignación.
pedido?.Estado = "Preparado";
pedido?.Intentos += 1;

Console.WriteLine(pedido?.Estado ?? "No existe pedido.");

class Pedido
{
    public string Estado { get; set; } = "Nuevo";
    public int Intentos { get; set; }
}
