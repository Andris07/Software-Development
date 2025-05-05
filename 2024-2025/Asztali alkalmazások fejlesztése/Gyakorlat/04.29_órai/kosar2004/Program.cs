using System.Collections.Concurrent;
using kosar2004_LIB;

Merkozesek merkozesekFeladat = new (File.ReadAllLines("eredmenyek.csv").Skip(1));

//4. feladat
Console.Write($"4. feladat: ");
Console.Write($"Csapat neve: ");
string csapatNev = Console.ReadLine();
Console.WriteLine($"\tHazai mérkőzések száma: {merkozesekFeladat.HazaiMerkozesekSzama(csapatNev)}");
Console.WriteLine($"\tIdegen mérkőzések száma: {merkozesekFeladat.IdegenMerkozesekSzama(csapatNev)}");

//5. feladat
Console.Write($"5. feladat: ");
if (merkozesekFeladat.VoltEDontetlen)
{
    Console.WriteLine($"Volt döntetlen mérkőzés");
}
else
{
    Console.WriteLine($"Nem volt döntetlen mérkőzés");
}

//6. feladat
Console.Write($"6. feladat: ");
Console.Write($"A város neve: ");
string varosNeve = Console.ReadLine();
string? keresettCsapat = merkozesekFeladat.Csapatneve(varosNeve);
if (keresettCsapat != null)
{
    Console.WriteLine($"\tA csapat neve: {keresettCsapat}");
}
else
{
    Console.WriteLine($"\tNincs ilyen városnevet tartalmazó csapat.");
}

//7. feladat
Console.Write($"7. feladat: ");
Console.WriteLine($"100 pont felett dobtak hazai meccsen: ");
foreach (var merkozes in merkozesekFeladat.SzazPontnalTobbetDobtakOtthon)
{
    Console.WriteLine($"\t{merkozes.ToString()}");
}

//8. feladat
Console.Write($"8. feladat: ");
Console.Write($"Az időpont (pl.: 2004.11.21): ");
try
{
    DateOnly bekertDatum = DateOnly.Parse(Console.ReadLine());
    foreach (var merkozes in merkozesekFeladat.MerkozesekAdottNapon(bekertDatum))
    {
        Console.WriteLine($"\t{merkozes.Hazai} - {merkozes.Idegen} ({merkozes.Hazai_pont}:{merkozes.Idegen_pont})");
    }
}
catch
{
    Console.WriteLine($"\tNem megfelelő dátum formátum.");
}

//9. feladat
Console.Write($"9. feladat: ");
Console.WriteLine($"A legnagyobb pontkülönbségű mérkőzés adatai: ");
Console.WriteLine($"\t{merkozesekFeladat.LegnagyobbPontkulonbseguMerkozes.ToString()}");

//10. feladat
Console.Write($"10. feladat: ");
Console.WriteLine($"Stadionok, ahol 20-nál több mérkőzést játszottak: ");
foreach (var stadion in merkozesekFeladat.StadionokSokMerkozessel(20))
{
    Console.WriteLine($"\t{stadion.Key}: {stadion.Value}");
}