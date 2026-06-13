// TryParse<T>: delegate genérico personalizado que modela el patrón "TryParse" del BCL.
// C# 14 permite asignar una lambda con parámetro "out" a un delegate de este tipo.
TryParse<int> convertir = (texto, out resultado) => int.TryParse(texto, out resultado);

if (convertir("42", out int numero))
    Console.WriteLine($"Resultado: {numero}");

// Desde C# 14, nameof acepta tipos genéricos abiertos (con comas en lugar de argumentos).
// Devuelve el nombre del tipo sin los argumentos: útil para mensajes de error y logs.
// nameof(Dictionary<,>) es más seguro que el string "Dictionary": si renombras el tipo, el
// compilador avisa automáticamente.
Console.WriteLine($"Nombre del tipo: {nameof(Dictionary<,>)}");

delegate bool TryParse<T>(string texto, out T resultado);
