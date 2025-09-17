using teszt_kiertekeles_LIB;

// 1. feladat
Console.WriteLine("1. feladat");
Console.Write($"Hányadik csoport teszt eredményét szeretné kiértékelni? ");
int csoportSzam = int.Parse( Console.ReadLine());
string fajlNev = $"csoport{csoportSzam}.csv";

Tesztek tesztek;

if (File.Exists(fajlNev))
{
    string[] fajlBeolvasas = File.ReadAllLines(fajlNev);

    tesztek = new Tesztek(fajlBeolvasas);
    
    if (tesztek.ures())
    {
        Console.WriteLine($"A(z) {csoportSzam}. csoport még nem írt tesztet");
    }
    else
    {
        Console.WriteLine($"A(z) {csoportSzam}. csoport közül {tesztek.tesztIrokLetszam()} tanuló írt tesztet és {tesztek.csoportLetszam() - tesztek.tesztIrokLetszam()} tanuló hiányzott a tesztről\n");
        // 1. feladat vége

        // 2. feladat
        Console.WriteLine("2. feladat");
        Console.Write($"Kérem adja meg a tanuló nevét: ");
        string? nev = Console.ReadLine();

        if (tesztek.irtTesztet(nev))
        {
            foreach (var tanulo in tesztek.tesztIro(nev))
            {
                Console.WriteLine($"{nev} írt tesztet, és az alábbi eredményeket érte el: ");
                Console.WriteLine($"\t1. feladat: {tanulo.Kotojelezes(tanulo.ElsoFeladat)} pont");
                Console.WriteLine($"\t2. feladat: {tanulo.Kotojelezes(tanulo.MasodikFeladat)} pont");
                Console.WriteLine($"\t3. feladat: {tanulo.Kotojelezes(tanulo.HarmadikFeladat)} pont");
                Console.WriteLine($"\t4. feladat: {tanulo.Kotojelezes(tanulo.NegyedikFeladat)} pont");
                Console.WriteLine($"\t5. feladat: {tanulo.Kotojelezes(tanulo.OtodikFeladat)} pont");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"{nev} nem írt tesztet\n");
        }

        // 3. feladat
        Console.WriteLine("3. feladat: ");

        for (int i = 1; i <= 5; i++)
        {
            var (megoldok, atlag, kihagyok) = tesztek.feladatStatisztika(i);
            Console.WriteLine($"{i}. feladat statisztikái:\n\tMegoldotta: {megoldok} tanuló\n\tMeogoldottak Átlaga: {atlag}\n\tKihagyta: {kihagyok} tanuló\n");
        }

        // 4. feladat
        Console.WriteLine("4. feladat: ");
        tesztek.mentesSzazalekCsv(csoportSzam);
        Console.WriteLine($"A szazalek{csoportSzam}.csv fájl elkészült");
    }
}
else
{
    Console.WriteLine($"Nincs ilyen csoport az alábbi azonosítóval: {csoportSzam}");
}