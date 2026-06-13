// La variable puede ser null según el segundo actual (para demostrar ambos casos).
Pedido? pedido = DateTime.Now.Second % 2 == 0 ? new Pedido() : null;

// En C# 14, ?. puede aparecer a la izquierda de una asignación.
// Si pedido es null, la asignación se omite silenciosamente (no lanza excepción).
// Equivale a: if (pedido != null) pedido.Estado = "Preparado";
pedido?.Estado = "Preparado";
// ?. en += también es nuevo en C# 14.
// Equivale a: if (pedido != null) pedido.Intentos += 1;
pedido?.Intentos += 1;

Console.WriteLine(pedido?.Estado ?? "No existe pedido.");

class Pedido
{
    public string Estado { get; set; } = "Nuevo";
    public int Intentos { get; set; }
}
