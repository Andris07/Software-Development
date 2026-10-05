using MikulasCukraszda_LIB;

KeszitesAdatok keszitesAdatok = new KeszitesAdatok(File.ReadAllLines("keszites.txt").Skip(1));

Console.WriteLine($"Elérhető sütemény készítési azonosítók: {String.Join("; ", keszitesAdatok.ElerhetoKeszitesAzonositok)}");
Console.WriteLine();

Console.WriteLine($"A készíthető sütemények:");
Sutemenyek sutemenyek = new Sutemenyek(sutemenyekBeolvasas());
Console.WriteLine($"\t{String.Join("\n\t", sutemenyek.SutemenyTipusok)}");

IEnumerable<Sutemeny> sutemenyekBeolvasas()
{
    foreach (var fajlSor in File.ReadAllLines("sutemenyek.txt").Skip(1))
    {
        yield return SutemenyFactory.Factory(fajlSor, keszitesAdatok);
    }
}

File.WriteAllText("hibalista.txt", "");
Feladatok feladatok = new Feladatok();

foreach (var sor in File.ReadAllLines("feladatok.txt").Skip(1))
{
    string[] adatok = sor.Split(';');
    int darab = int.Parse(adatok[1]);
    Sutemeny? sutemeny = sutemenyek.SutemenyTipusok.FirstOrDefault(s => s.Azonosito == adatok[0]);

    if (sutemeny == null)
    {
        File.AppendAllText("hibalista.txt", $"{adatok[0]}: Ilyen azonosítójú süteményt nem készítenek.\n");
        continue;
    }
    try
    {
        feladatok += new Feladat(sutemeny, darab);
    }
    catch (TulSokFeladatException ex)
    {
        File.AppendAllText("hibalista.txt", $"{ex.Message} - {darab} adag {sutemeny.Megnevezes}: {sutemeny.ElkeszitesiIdo * darab} perc\n");
    }
}

Console.WriteLine("\nAz elvégzendő feladatok:");
Console.WriteLine($"\t{String.Join("\n\t", feladatok.FeladatLista)}");

Console.WriteLine("\nSüteményenként az elkészítendő adagok száma:");
Console.WriteLine($"\t{String.Join("\n\t", feladatok.FeladatLista.GroupBy(f => f.Sutemeny.Megnevezes).Select(g => $"{g.Key}: {g.Sum(f => f.Darabszam)} adag"))}");