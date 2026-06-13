IRepositorioMensajes repositorio = new RepositorioMemoria();
var servicio = new ServicioSaludo(repositorio);
servicio.Saludar("Ana");

interface IRepositorioMensajes
{
    string ObtenerSaludo();
}

class RepositorioMemoria : IRepositorioMensajes
{
    public string ObtenerSaludo() => "Bienvenida";
}

class ServicioSaludo(IRepositorioMensajes repositorio)
{
    // La dependencia llega por el constructor, no se crea dentro del servicio.
    public void Saludar(string nombre) =>
        Console.WriteLine($"{repositorio.ObtenerSaludo()}, {nombre}.");
}
