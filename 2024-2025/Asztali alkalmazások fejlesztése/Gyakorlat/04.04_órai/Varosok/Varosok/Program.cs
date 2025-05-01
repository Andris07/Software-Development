using Varosok_LIB;

Varosok varosokFeladat = new (File.ReadAllLines("varosok.csv").Skip(1));

// 3. feladat
Console.Write("3. feladat: ");
Console.WriteLine($"Városok száma: {varosokFeladat.VarosokSzama} db");

// 4. feladat
Console.Write("4. feladat: ");
Console.WriteLine($"india nagyvárosok lakosságának összege: {varosokFeladat.OrszagVarosainakLakossaga("India") * Varos.MILLIO} fő");

// 5. feladat
Console.Write("5. feladat: ");
Varos legnepesebbVaros = varosokFeladat.LegnagyobbLakossaguVaros;
Console.WriteLine($"A legnagyobb lakosságú város adatai: ");
Console.WriteLine($"\tNév: {legnepesebbVaros.VarosNev}");
Console.WriteLine($"\tOrszág: {legnepesebbVaros.OrszagNev}");
Console.WriteLine($"\tLakosság: {legnepesebbVaros.LakossagSzama * Varos.EZER} ezer fő");

// 6. feladat
Console.Write("6. feladat: ");
bool vanMagyar = varosokFeladat.VanEVarosa("Magyarország");
if (vanMagyar)
{
    Console.WriteLine($"Van magyar város az adatok között");
}
Console.WriteLine($"Nincs magyar város az adatok között");

// 7. feladat
Console.Write("7. feladat: ");
Console.WriteLine($"A kínai városok nevei: {string.Join(", ", varosokFeladat.OrszagVarosai("Kína"))}");

// 8. feladat
Console.Write("8. feladat: ");
Console.Write($"Kérem adjon meg egy egész értéket (millióban), amihez viszonyítani szeretné a városok népességét: ");
int viszonyitandoNepesseg = int.Parse(Console.ReadLine());
Console.WriteLine($"\t{varosokFeladat.NepessegetEleroVarosokSzama(viszonyitandoNepesseg)} város népessége éri el vagy haladja meg a {viszonyitandoNepesseg} milliós fő lakosságot");

// 9. feladat
Console.Write("9. feladat: ");
Console.WriteLine($"A következő országok városai találhatók meg a fájlban: ");
Console.WriteLine($"\t{string.Join("; ", varosokFeladat.OrszagokNevei)}");

// 10. feladat
Console.Write("10. feladat: ");
LegnagyobbVarosok(5);
Console.WriteLine($"A fájlbaírás megtörtént");

void LegnagyobbVarosok(int darabSzam)
{
    List<string> kimenet = [];
    foreach (var varos in varosokFeladat.LegnagyobbVarosok(darabSzam))
    {
        kimenet.Add(varos.ToString());
    }
    File.WriteAllLines("otlegnagyobb.txt", kimenet);
}