using LabdarugasLIB;

DataStore.InitCSV();

Console.WriteLine("4. feladat: A legtöbb trófeával rendelkező csapat leírása: ");
Console.WriteLine(DataStore.Instance!.LegtobbTrofeavalRendelkezoCsapat);
Console.WriteLine();

Console.Write("5. feladat: Kérem adja meg melyik tornán szerzett átlag pontra kíváncsi (1=BL / 2=EL): ");
int tornaSorszam = int.Parse(Console.ReadLine()!);

if (tornaSorszam != 1 && tornaSorszam != 2)
{
    Console.WriteLine($"\tIlyen sorszámú torna ({tornaSorszam}) nincs az adatbázisunkban!");
}
else
{
    var pontszam = DataStore.Instance!.AtlagTornaPontokEgyTornan(tornaSorszam);
    Console.Write($"\t{pontszam} az átlagosan megszerzett pont a(z) ");
    if (tornaSorszam == 1) Console.WriteLine("Bajnokok ligájában");
    else Console.WriteLine("Európa ligában");
}
Console.WriteLine();

Console.WriteLine("6. feladat: Tornánként az összes megszerzett pont: ");

var pontok = DataStore.Instance!.Csapatok.GroupBy(x => x.Torna!.Nev).Select(x => new { TornaNev = x.Key, OsszPont = x.Sum(c => c.TornaPontok) });
foreach (var adat in pontok)
{
    Console.WriteLine($"\t{adat.TornaNev}: {adat.OsszPont} pont");
}
Console.WriteLine();

Console.WriteLine("7. feladat: A három legeredményesebb edző trófeák alapján: ");
foreach (var edzo in DataStore.Instance!.LegeredmenyesebbEdzok(3))
{
    Console.WriteLine($"\t{edzo.Nev} ({edzo.Csapat}): {edzo.Trofeak}");
}
Console.WriteLine();

Console.WriteLine("8. feladat: A legtöbb bevétellel rendelkező edző: ");

var legtobbBevetelEdzo = DataStore.Instance!.Edzok.MaxBy(x => x.OsszBevetel);
Console.WriteLine($"\t{legtobbBevetelEdzo!.Nev} ({legtobbBevetelEdzo.Csapat})");
Console.WriteLine($"\tÖsszbevétele: {legtobbBevetelEdzo.OsszBevetel:N0} Ft");
Console.WriteLine($"\tAz edző leírása: {legtobbBevetelEdzo}");