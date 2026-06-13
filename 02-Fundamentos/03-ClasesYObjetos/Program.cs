var cuenta = new CuentaBancaria("Ana", 100m);
cuenta.Ingresar(50m);
Console.WriteLine($"{cuenta.Titular}: {cuenta.Saldo:C}");

// Primary constructor (C# 12+): los parámetros se declaran en la cabecera de la clase.
// Se usan directamente para inicializar propiedades, sin necesidad de un cuerpo de constructor.
class CuentaBancaria(string titular, decimal saldoInicial)
{
    // Propiedad solo de lectura: se asigna en la declaración y ya no puede cambiar.
    public string Titular { get; } = titular;
    // El setter privado protege el saldo frente a cambios externos.
    // Solo los métodos de esta clase pueden modificar Saldo (encapsulamiento).
    public decimal Saldo { get; private set; } = saldoInicial;

    public void Ingresar(decimal cantidad)
    {
        // Validación antes de modificar el estado: solo ingresamos cantidades positivas.
        if (cantidad > 0) Saldo += cantidad;
    }
}
