using konyvtar_LIB;

// 3. feladat
Console.Write("3. feladat: ");

string[] fajlBeolvasas = File.ReadAllLines("konyvek.txt");
Konyvtarak konyvtarak = new Konyvtarak(fajlBeolvasas);
Console.WriteLine($"A könyvek száma: {konyvtarak.KonyvekSzama()} db");

// 4. feladat
Console.Write("4. feladat: ");
Console.WriteLine($"A kölcsönözhető könyvek száma: {konyvtarak.KolcsonozhetoKonyvekSzama()} db");

// 5. feladat
Console.Write("5. feladat: ");
Console.WriteLine($"Harry Potter könyvek száma: {konyvtarak.HarryPotterKonyvekSzama()} db");

// 6. feladat
Console.Write("6. feladat: ");

foreach (var ev in konyvtarak.LegtobbKonyvkiadasEgyEvben())
{
    Console.WriteLine($"A legtöbb könyvet {ev.Key} évben adták ki {ev.Count()} db");
}

// 7. feladat
Console.Write("7. feladat: ");
Console.WriteLine("Könyvek évenkénti darabszáma: ");

foreach (var ev in konyvtarak.EvenkentiKiadasokSzama())
{
    Console.WriteLine($"\t{ev.Key}: {ev.Count()} db");
}

// 8. feladat
Console.Write("8. feladat: ");
Console.WriteLine("Szerzők és könyveiknek száma: ");

foreach (var szerzo in konyvtarak.SzerzonkentiKiadasokSzama())
{
    Console.WriteLine($"\t{szerzo.Key}: {szerzo.Count()} db");
}

// 9. feladat
Console.Write("9. feladat: ");
Console.Write("Adjon meg egy könyvcímet: ");
string cim = Console.ReadLine();

if (konyvtarak.LetezoKonyv(cim))
{
    if (konyvtarak.KolcsonozhetoKonyv(cim))
    {
        Console.WriteLine($"A(z) \"{cim}\" című könyv kölcsönözhető.");
    }
    else
    {
        Console.WriteLine($"A(z) \"{cim}\" című könyv nem kölcsönözhető.");
    }
}
else
{
    Console.WriteLine($"Nincs ilyen könyv a könyvtárban.");
}

// 10. feladat
Console.Write("10. feladat: ");
Console.WriteLine($"Kölcsönözhető könyvek listája: {String.Join(", ", konyvtarak.KolcsonozhetoKonyvek())}");