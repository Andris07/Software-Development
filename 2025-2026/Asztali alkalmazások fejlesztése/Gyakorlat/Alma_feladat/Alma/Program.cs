using Alma_LIB;
using System.Text.Json;

ISzimulacio szimulacio;

string fajlNev = "alma.json";
try
{
    szimulacio = JsonSerializer.Deserialize<Alma>(File.ReadAllText(fajlNev))!;
}
catch
{
    szimulacio = new Alma();
}

/*
// Billentyűs
ConsoleKey keyChar;
do
{
    szimulacio.Kor();
    Console.Clear();
    Console.WriteLine(szimulacio.ToString());
    Thread.Sleep(100);
    keyChar = Console.ReadKey().Key;
}   while (keyChar != ConsoleKey.Escape && szimulacio.EletbenVan);

if (szimulacio.EletbenVan)
{
    File.WriteAllText(fajlNev, JsonSerializer.Serialize<Alma>((szimulacio as Alma)!));
}
else
{
    if (File.Exists(fajlNev))
    {
        File.Delete(fajlNev);
    }
}
*/

// Automatikus
bool kilepes = false;

Parallel.Invoke
(
    () =>
    {
        while (!kilepes && szimulacio.EletbenVan)
        {
            szimulacio.Kor();
            Console.Clear();
            Console.WriteLine(szimulacio.ToString());
            Thread.Sleep(100);
        }

        if (szimulacio.EletbenVan)
        {
            File.WriteAllText(fajlNev, JsonSerializer.Serialize<Alma>((szimulacio as Alma)!));
        }
        else
        {
            if (File.Exists(fajlNev))
            {
                File.Delete(fajlNev);
            }
        }
    },
    () =>
    {
        Console.ReadLine();
        kilepes = true;
    }
);