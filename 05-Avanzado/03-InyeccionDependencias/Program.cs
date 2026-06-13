// ServicioSaludo recibe su dependencia por el constructor (constructor injection).
// Esto permite sustituir RepositorioMemoria por cualquier otra implementación
// de IRepositorioMensajes sin modificar ServicioSaludo (principio de inversión de dependencias).
IRepositorioMensajes repositorio = new RepositorioMemoria();
var servicio = new ServicioSaludo(repositorio);
servicio.Saludar("Ana");

// Contrato: define QUÉ puede hacer el repositorio, sin comprometerse a CÓMO lo hace.
interface IRepositorioMensajes
{
    string ObtenerSaludo();
}

// Implementación concreta: se podría sustituir por RepositorioBaseDatos, RepositorioArchivo...
class RepositorioMemoria : IRepositorioMensajes
{
    public string ObtenerSaludo() => "Bienvenida";
}

class ServicioSaludo(IRepositorioMensajes repositorio)
{
    // La dependencia llega por el constructor, no se crea dentro del servicio.
    // En un test unitario se puede pasar un "repositorio falso" sin tocar base de datos.
    public void Saludar(string nombre) =>
        Console.WriteLine($"{repositorio.ObtenerSaludo()}, {nombre}.");
}
