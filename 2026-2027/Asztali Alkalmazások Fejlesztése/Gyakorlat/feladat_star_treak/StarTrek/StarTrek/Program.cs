using StarTrek_LIB;

DataStore.InitCSV();

Console.WriteLine($"4. feladat: {DataStore.Instance!.HanyUrhajoTartalmazza("Enterprise")} darab űrhajó nevében szerepel az Enterprise név.");

Console.Write("5. feladat: A szerep neve: ");
string szerepNev = Console.ReadLine()!;
HajoSzerepek szerep = DataStore.Instance.SzerepNevAlapjan(szerepNev);

if (szerep is null)
{
    Console.WriteLine("\tIlyen szerep nincs az adatbázisban.");
}
else
{
    Console.WriteLine($"\t{DataStore.Instance!.HanyHajoSzerepRendelteteseAzAdottSzerep(szerep)} hajóosztály rendeltetése a megadott szerep.");
}

Console.WriteLine("6. feladat:");

foreach(var hajoOsztaly in DataStore.Instance!.LegtobbUrhajovalRendelkezoHajoOsztaly())
{
    Console.WriteLine($"\t{hajoOsztaly.HajoOsztaly.Nev}: {hajoOsztaly.Darab} űrhajó");
}