using Tanacsado_LIB;

DataStore.InitCSV();

Console.WriteLine($"5. feladat: {DataStore.Instance!.TalalkozokSzamaIdotartamAlapjan(3)} találkozó tartott legalább 3 órát");

Console.Write("6. feladat: A tanácsadó neve: ");
string tanacsadoNev = Console.ReadLine()!;
Tanacsado tanacsado = DataStore.Instance.TanacsadoNevAlapjan(tanacsadoNev);

if (tanacsado is null)
{
    Console.WriteLine("\tIlyen néven nem található tanácsadó");
}
else
{
    Console.WriteLine($"\tTelefon: {tanacsado.Telefon}");
    Console.WriteLine($"\tEmail: {tanacsado.Email}");
    Console.WriteLine($"\tSzakterület: {DataStore.Instance.SzakteruletIDAlapjan(tanacsado.SzakteruletID).Megnevezes}");
    Console.WriteLine($"\tÓradíj: {tanacsado.Oradij}");
}

Console.WriteLine("7. feladat: A 3 legtöbbet kereső tanácsadó:");
foreach(var adat in DataStore.Instance.LegtobbPenztKeresok())
{
    Console.WriteLine($"\t{adat.Tanacsado.Nev}: {adat.Kereset} Ft");
}