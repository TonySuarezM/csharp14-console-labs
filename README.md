# > **Este repositorio es un proyecto personal, abierto y sin pretensiones. Toda la información aquí contenida corresponde a mis apuntes y prácticas personales, no constituye documentación oficial y se publica sin garantía ni responsabilidad.**

# Curso: C# 14 con aplicaciones de consola

**Repositorio:** `csharp14-console-labs`

Este repositorio contiene una ruta de aprendizaje incremental para practicar C# 14,
.NET 10 y Visual Studio 2026 mediante aplicaciones de consola independientes.

Cada laboratorio incluye código ejecutable, comentarios explicativos en español,
un objetivo de aprendizaje y un ejercicio propuesto.

## Estructura del proyecto

- `01-Principiante/` → salida, variables, entrada, condicionales, bucles y métodos.
- `02-Fundamentos/` → colecciones, texto, orientación a objetos y excepciones.
- `03-Intermedio/` → genéricos, eventos, LINQ, records, archivos, JSON y asincronía.
- `04-CSharp14/` → características nuevas y específicas de C# 14.
- `05-Avanzado/` → reflexión, paralelismo e inyección de dependencias.
- `06-Proyectos/` → aplicaciones integradoras para consolidar lo aprendido.
- `EjemplosCSharp14.slnx` → solución que agrupa todos los proyectos.

## Requisitos

- Visual Studio 2026 con la carga de trabajo **Desarrollo de escritorio de .NET**.
- SDK de .NET 10. `global.json` fija el SDK `10.0.301`.
- Git, si deseas clonar y versionar tus propios cambios.

Visual Studio detectará `.vsconfig` al abrir el repositorio y ofrecerá instalar los
componentes necesarios que falten.

## Inicio rápido con Visual Studio 2026

1. Clona el repositorio:

```powershell
git clone https://github.com/TonySuarezM/csharp14-console-labs.git
cd csharp14-console-labs
```

2. Abre `EjemplosCSharp14.slnx` con Visual Studio 2026.
3. Haz clic derecho sobre el laboratorio deseado y selecciona
   **Establecer como proyecto de inicio**.
4. Usa `F5` para depurar o `Ctrl+F5` para ejecutar sin depuración.

También puedes trabajar desde una terminal:

```powershell
dotnet run --project .\01-Principiante\01-HolaMundo
```

## Regla del curso: versión y verificación

Antes de comenzar, verifica que estás utilizando el SDK esperado:

```powershell
dotnet --version
dotnet build .\EjemplosCSharp14.slnx
```

La compilación completa debe finalizar sin advertencias ni errores.

## Temario: ruta guiada

- **Nivel 1 - Principiante:** primeras instrucciones, datos, decisiones y repetición.  
  [Ver laboratorios](01-Principiante/README.md)
- **Nivel 2 - Fundamentos:** colecciones, texto, clases, interfaces y excepciones.  
  [Ver laboratorios](02-Fundamentos/README.md)
- **Nivel 3 - Intermedio:** genéricos, eventos, LINQ, records, JSON y asincronía.  
  [Ver laboratorios](03-Intermedio/README.md)
- **Nivel 4 - C# 14:** `field`, asignación condicional nula, miembros de extensión,
  mejoras de `Span<T>`, lambdas y miembros parciales.  
  [Ver laboratorios](04-CSharp14/README.md)
- **Nivel 5 - Avanzado:** reflexión, paralelismo, cancelación e inyección de dependencias.  
  [Ver laboratorios](05-Avanzado/README.md)
- **Nivel 6 - Proyectos:** calculadora, gestor de tareas JSON y analizador de archivos.  
  [Ver proyectos](06-Proyectos/README.md)

Lee y ejecuta los ejemplos en orden. Modifica valores y completa los ejercicios
propuestos antes de avanzar al siguiente laboratorio.

## Referencias oficiales

### C# y .NET

- https://learn.microsoft.com/dotnet/csharp/
- https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-14
- https://learn.microsoft.com/dotnet/core/whats-new/dotnet-10/overview

### Visual Studio

- https://learn.microsoft.com/visualstudio/
- https://visualstudio.microsoft.com/

---

> **Advertencia:** El contenido de este repositorio se ofrece “tal cual”, sin ningún
> tipo de soporte, garantía o responsabilidad. Úsalo bajo tu propia responsabilidad;
> no es información oficial ni está respaldada por terceros.
