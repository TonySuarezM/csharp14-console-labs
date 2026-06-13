# Inyección de dependencias

**Nivel:** 5 — Avanzado  |  **Concepto clave:** Principio DIP, constructor injection y testabilidad

## ¿Qué aprenderás?

La **inyección de dependencias** (DI) es un patrón de diseño que implementa el principio de
inversión de dependencias (DIP): los módulos de alto nivel no deben depender de los de bajo nivel;
ambos deben depender de abstracciones (interfaces).

En lugar de que `ServicioSaludo` cree su propio `RepositorioMemoria`, lo **recibe desde fuera**
a través del constructor. Esto permite sustituir la implementación sin modificar el servicio.

## El problema sin inyección de dependencias

```csharp
// SIN DI: el servicio crea su dependencia → acoplamiento fuerte
class ServicioSaludoAcoplado
{
    private readonly RepositorioMemoria repositorio = new(); // dependencia concreta

    public void Saludar(string nombre) =>
        Console.WriteLine($"{repositorio.ObtenerSaludo()}, {nombre}.");
}
// Para cambiar el repositorio hay que modificar ServicioSaludoAcoplado.
```

## La solución con inyección de dependencias

```csharp
// CON DI: el servicio depende de la abstracción, no de la implementación concreta
class ServicioSaludo(IRepositorioMensajes repositorio)
{
    // La dependencia llega por el constructor, no se crea dentro del servicio.
    public void Saludar(string nombre) =>
        Console.WriteLine($"{repositorio.ObtenerSaludo()}, {nombre}.");
}
```

## Análisis del código

```csharp
IRepositorioMensajes repositorio = new RepositorioMemoria();
var servicio = new ServicioSaludo(repositorio);
servicio.Saludar("Ana");

// Contrato: define qué puede hacer el repositorio, sin comprometerse a cómo.
interface IRepositorioMensajes
{
    string ObtenerSaludo();
}

// Implementación concreta: podría ser otra (base de datos, archivo, API...).
class RepositorioMemoria : IRepositorioMensajes
{
    public string ObtenerSaludo() => "Bienvenida";
}
```

## ¿Por qué facilita el testing?

En un test unitario puedes pasar un repositorio ficticio sin tocar la base de datos:

```csharp
class RepositorioFalso : IRepositorioMensajes
{
    public string ObtenerSaludo() => "Hola desde test";
}
var servicio = new ServicioSaludo(new RepositorioFalso());
```

## Ejercicio propuesto

1. Crea `RepositorioArchivo : IRepositorioMensajes` que lea el saludo de un archivo de texto
   y sustitúyelo en el programa sin cambiar `ServicioSaludo`.
2. Crea `RepositorioAleatorio : IRepositorioMensajes` que devuelva uno de tres saludos al azar.
3. Investiga `IServiceCollection` de .NET: `services.AddSingleton<IRepositorioMensajes, RepositorioMemoria>()`.

## Referencias

- [Inyección de dependencias en .NET](https://learn.microsoft.com/dotnet/core/extensions/dependency-injection)
- [Principios SOLID](https://learn.microsoft.com/dotnet/architecture/modern-web-apps-azure/architectural-principles)
- [IServiceCollection](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection)
