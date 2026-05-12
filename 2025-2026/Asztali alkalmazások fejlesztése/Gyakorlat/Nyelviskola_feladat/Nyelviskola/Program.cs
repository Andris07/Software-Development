using NyelviskolaLIB;

DataStore.InitCSV();
DataStore.Instance!.ExportToJSon();

Console.Write($"6. feladat: ");
Console.WriteLine($"{DataStore.Instance.TanitasiAlkalmak.Count(x => x.AdottHonapbanVanE(2023, 4))} alkalmat jegyeztek fel 2023. áprilisában.");

Console.Write("7. feladat: ");
Console.Write("A tanár neve: ");
var nev = Console.ReadLine();
var keresettTanar = DataStore.Instance.Tanarok.FirstOrDefault(x => x.Nev == nev);

if (keresettTanar is null)
{
    Console.WriteLine($"\tIlyen néven nem található tanár");
}
else
{
    Console.WriteLine($"\tTelefon: {keresettTanar.Telefon}");
    Console.WriteLine($"\tEmail: {keresettTanar.Email}");
}

Console.Write("8. feladat: ");
Console.WriteLine("A 3 legtöbb alkalmat tanító tanár: ");
var top3Alkalom = DataStore.Instance.TanitasiAlkalmak.GroupBy(x => x.TanarID).Select(x => new { id = x.Key, db = x.Count() }).OrderByDescending(x => x.db).Take(3).ToList();

foreach (var tanarInstance in top3Alkalom)
{
    var tanar = DataStore.Instance.Tanarok.First(x => x.TanarID == tanarInstance.id);
    var nyelv = DataStore.Instance.Nyelvek.First(x => x.NyelvID == tanar.NyelvID);
    Console.WriteLine($"\t{tanar} ({nyelv}): {tanarInstance.db} alkalom");
}

Console.Write("8. feladat: ");
Console.WriteLine("A 3 legtöbb pénzt kereső tanító tanár: ");
var top3Fizetes = DataStore.Instance.TanitasiAlkalmak.GroupBy(x => x.TanarID).Select(x => new { id = x.Key, dij = x.Sum(y => y.Dij) }).OrderByDescending(x => x.dij).Take(3).ToList();

foreach (var tanarInstance in top3Fizetes)
{
    var tanar = DataStore.Instance.Tanarok.First(x => x.TanarID == tanarInstance.id);
    var nyelv = DataStore.Instance.Nyelvek.First(x => x.NyelvID == tanar.NyelvID);
    Console.WriteLine($"\t{tanar} ({nyelv}): {tanarInstance.dij:C0}");
}