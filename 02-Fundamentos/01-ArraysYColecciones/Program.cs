int[] notas = [7, 9, 6];
List<string> alumnos = ["Ana", "Luis"];
alumnos.Add("Marta");
Dictionary<string, int> puntuaciones = new() { ["Ana"] = 10, ["Luis"] = 8 };

Console.WriteLine($"Primera nota: {notas[0]}");
Console.WriteLine($"Alumnos: {string.Join(", ", alumnos)}");
Console.WriteLine($"Puntos de Ana: {puntuaciones["Ana"]}");
