using JóAlanyok_LIB;

string[] fajlNev = File.ReadAllLines("input.txt");
Nyilvantartas szemelyekLista = new Nyilvantartas(fajlNev);
Nyilvantartas szemelyek = szemelyekLista;

foreach (var szemely in szemelyek.Szemelyek)
{
    try
    {
        Console.WriteLine(szemely.ToString());
    }
    catch
    {
        throw new Exception();
    }
}
Console.WriteLine();

Console.WriteLine($"Diákok száma: {szemelyek.DiakokSzama()}");
Console.WriteLine($"Tanárok száma: {szemelyek.TanarokSzama()}");
Console.WriteLine($"Tanárok átlagos életkora: {szemelyek.AtlagTanarEletkor()}");
Console.WriteLine();

foreach (var puska in szemelyek.DiakokSzamaPuskakSzamaSzerint())
{
    Console.WriteLine($"{puska.Key} db csalás: {string.Join(", ", puska.Value)} fő");
}