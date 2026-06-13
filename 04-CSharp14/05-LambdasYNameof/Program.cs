TryParse<int> convertir = (texto, out resultado) => int.TryParse(texto, out resultado);

if (convertir("42", out int numero))
    Console.WriteLine($"Resultado: {numero}");

// Desde C# 14, nameof acepta tipos genéricos abiertos.
Console.WriteLine($"Nombre del tipo: {nameof(Dictionary<,>)}");

delegate bool TryParse<T>(string texto, out T resultado);
