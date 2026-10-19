using Szepseg_LIB;

DataStore.InitCSV();

Console.WriteLine($"5. feladat: {DataStore.Instance!.KezelesekSzamaIdopontSzerint(12)} kezelés esett délelőttre");

Console.Write("6. feladat: A vendég neve: ");
string vendegNev = Console.ReadLine()!;
Vendegek vendeg = DataStore.Instance!.VendegNevAlapjan(vendegNev);

if (vendeg is null)
{
    Console.WriteLine("\tIlyen néven nem található vendég");
}
else
{
    Console.WriteLine($"\tCím: {vendeg.Cim}");
    Console.WriteLine($"\tTelefon: {vendeg.Telefon}");
}

Console.WriteLine("7. feladat: A 3 legmagasabb bevételű alkalmazott:");

foreach(var alkalmazott in DataStore.Instance!.LegtobbBevetellelRendelkezoAlkalmazott())
{
    Console.WriteLine($"\t{alkalmazott.Alkalmazott.Nev} ({DataStore.Instance!.Szakmak.First(x => x.ID == alkalmazott.Alkalmazott.SzakmaID).Nev}): {alkalmazott.Kereset} Ft");
}
