int temperatura = 24;

if (temperatura < 10)
    Console.WriteLine("Hace frío.");
else if (temperatura < 25)
    Console.WriteLine("La temperatura es agradable.");
else
    Console.WriteLine("Hace calor.");

string consejo = temperatura switch
{
    < 10 => "Lleva abrigo.",
    > 30 => "Bebe agua.",
    _ => "Disfruta del día."
};
Console.WriteLine(consejo);
