var cuenta = new CuentaBancaria("Ana", 100m);
cuenta.Ingresar(50m);
Console.WriteLine($"{cuenta.Titular}: {cuenta.Saldo:C}");

class CuentaBancaria(string titular, decimal saldoInicial)
{
    public string Titular { get; } = titular;
    // El setter privado protege el saldo frente a cambios externos.
    public decimal Saldo { get; private set; } = saldoInicial;

    public void Ingresar(decimal cantidad)
    {
        if (cantidad > 0) Saldo += cantidad;
    }
}
