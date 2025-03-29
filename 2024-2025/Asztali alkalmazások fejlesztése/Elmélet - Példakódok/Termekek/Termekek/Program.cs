using Termekek;

Termek termek = new Termek("alma", 200);
Console.WriteLine(termek.Informacio()); 
if (termek.Eladas(5))
{
    Console.WriteLine("Sikeres eladás.");
    Console.WriteLine(termek.Informacio());
}
else
{
    Console.WriteLine("Sikertelen eladás.");
    Console.WriteLine(termek.Informacio());
}
if (termek.Eladas(1))
{
    Console.WriteLine("Sikeres eladás.");
    Console.WriteLine(termek.Informacio());
}
else
{
    Console.WriteLine("Sikertelen eladás.");
    Console.WriteLine(termek.Informacio());
}
termek.Beszerzes(-1);
Console.WriteLine(termek.Informacio());
termek.Beszerzes(6);
Console.WriteLine(termek.Informacio());

Termek termek2 = new("tigris", 5_000_000, 3);
Console.WriteLine(termek2.Informacio());
