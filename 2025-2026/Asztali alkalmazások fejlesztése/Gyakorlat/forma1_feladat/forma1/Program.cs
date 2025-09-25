using forma1_LIB;

// 1. feladat
string[] fajlBeolvasas = File.ReadAllLines("eredmenyek.csv");
Forma1k forma1k = new Forma1k(fajlBeolvasas);

// 2. feladat
Console.Write("2. feladat: ");
IEnumerable<Forma1> HillVersenyzok = forma1k.versenyzokNevAlapjan("Hill");

Console.WriteLine("Hill vezetéknevűek: ");
foreach (var versenyzo in HillVersenyzok)
{
    Console.WriteLine($"\t{versenyzo.Nev} ({versenyzo.Nemzetiseg}) {versenyzo.SzuletesDatum}");
}

// 3. feladat
Console.Write("3. feladat: ");
IEnumerable<Forma1> futamGyoztesek = forma1k.futamGyoztesek();

Console.WriteLine("futamgyőztesek: ");
foreach (var versenyzo in futamGyoztesek)
{
    Console.WriteLine($"\t{versenyzo.Nev}");
}

// 4. feladat
Console.Write("4. feladat: ");
Forma1 elsoVerseny = forma1k.elsoVerseny("Juan-Manuel Fangio");
Console.WriteLine($"{elsoVerseny.Nev} {elsoVerseny.Datum.Year - elsoVerseny.SzuletesDatum.Value.Year} éves volt az első versenyén");

// 5. feladat
Console.Write("5. feladat: ");
Dictionary<string, int> ferrariHibak = forma1k.leggyakoribbHibakCsapatonkent("Ferrari", 3);

Console.WriteLine("Ferrariknál a 3 leggyakoribb hiba: ");
foreach (var hiba in ferrariHibak)
{
    Console.WriteLine($"\t{hiba.Key}: {hiba.Value} eset");
}

// 6. feladat
Console.Write("6. feladat: ");
Console.WriteLine($"{forma1k.csapatNelkulVersenyzok()} olyan versenyző volt, akinek valamelyik versenyén nem volt csapata");

// 7. feladat
Console.Write("7. feladat: ");
Console.Write("Nagy-Britannia után rendezték az első nagydíjukat: "); // Nincs Magyarország a csv fájlban
Console.WriteLine($"{ string.Join(", ", forma1k.elsoRendezesUtaniHelyszinek("Nagy-Britannia"))}");

// 8. feladat
forma1k.fajlBeiras("monaco.txt", "Monaco");