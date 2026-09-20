using ForditoIrodaLIB;

Adatok adatok = new Adatok();

string[] file = File.ReadAllLines("fordito.csv");
adatok.Beolvasas(file, 1);
file = File.ReadAllLines("nyelv.csv");
adatok.Beolvasas(file, 2);
file = File.ReadAllLines("megrendeles.csv");
adatok.Beolvasas(file, 3);

// 5. feladat
Console.WriteLine($"5. feladat: {adatok.ForditasokAdottEvAdottHonapban(2015, 3)} fordítási feladat rendeltek 2015. márciusában."); // szar a minta szövege, de így hagytam

// 6. feladat
Console.Write("6. feladat: A tanár neve: ");
string nev = Console.ReadLine()!;
Fordito adottFordito = adatok.Forditok.FirstOrDefault(x => x.Nev == nev)!;

if (adottFordito != null)
{
    Console.WriteLine($"\tTelefon: {adottFordito.Telefon}");
    Console.WriteLine($"\tEmail: {adottFordito.Email}");
}
else
{
    Console.WriteLine("\tIlyen néven nem található fordító.");
}

// 7. feladat
Console.WriteLine("7. feladat: A 3 legtöbb megrendelést kapó fordító: ");
IEnumerable<Fordito> forditokLegtobbMegrendelessel = adatok.forditokMegrendelesekAlapjanSorrendben().Take(3);

foreach (Fordito fordito in forditokLegtobbMegrendelessel)
{
    var nyelvNev = adatok.Nyelvek.FirstOrDefault(x => x.NyelvID == fordito.NyelvID)?.Nyelvnev;
    var megrendelesekDB = adatok.Megrendelesek.Count(x => x.ForditoID == fordito.ForditoID);
    Console.WriteLine($"\t{fordito.Nev} ({nyelvNev}): {megrendelesekDB} megrendelés");
}

// 8. feladat
Console.WriteLine("8. feladat: a 3 legtöbb pénzt kereső fordító: ");
IEnumerable<Fordito> forditokLegtobbKeresettPenzzel = adatok.forditokKeresettPenzAlapjanSorrendben().Take(3);

foreach (Fordito fordito in forditokLegtobbKeresettPenzzel)
{
    var nyelvNev = adatok.Nyelvek.FirstOrDefault(x => x.NyelvID == fordito.NyelvID)?.Nyelvnev;
    var keresettPenz = 0;

    foreach (Megrendeles megrendeles in adatok.Megrendelesek)
    {
        if (fordito.ForditoID == megrendeles.ForditoID)
        {
            keresettPenz += (int)adatok.MegrendelesOsszeg(megrendeles.MegrendelesID)!;
        }
    }

    Console.WriteLine($"\t{fordito.Nev} ({nyelvNev}): {keresettPenz} Ft"); // keresettPenz-t nem formáztam meg a mintának megfelelően
}