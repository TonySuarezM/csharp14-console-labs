int temperatura = 24;

// if/else if/else evalúa condiciones en orden de arriba a abajo.
// En cuanto una condición es verdadera, ejecuta ese bloque y omite el resto.
if (temperatura < 10)
    Console.WriteLine("Hace frío.");
else if (temperatura < 25)
    Console.WriteLine("La temperatura es agradable.");
else
    Console.WriteLine("Hace calor.");

// Switch expression: alternativa compacta cuando el resultado es un único valor.
// Los patrones relacionales (< 10, > 30) evalúan rangos sin condiciones encadenadas.
// El patrón _ (guion bajo) actúa como "else": captura cualquier valor no cubierto.
string consejo = temperatura switch
{
    < 10 => "Lleva abrigo.",
    > 30 => "Bebe agua.",
    _    => "Disfruta del día."
};
Console.WriteLine(consejo);
