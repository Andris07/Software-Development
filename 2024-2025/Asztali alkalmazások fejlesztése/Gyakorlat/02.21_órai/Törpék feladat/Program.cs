Console.WriteLine("Törpék feladat");

// 1. feladat
StreamReader fajl_beolvasas = new StreamReader("torpek.txt");
string[] adattipusok = fajl_beolvasas.ReadLine().Split(";");
List<Torpe> torpek = new List<Torpe>();

while (!fajl_beolvasas.EndOfStream && torpek.Count < 50)
{
    string[] sor = fajl_beolvasas.ReadLine().Split(";");
    Torpe torpe = new Torpe(sor[0], sor[1], sor[2], int.Parse(sor[3]), int.Parse(sor[4]));
    torpek.Add(torpe);
}
fajl_beolvasas.Close();

// 2. feladat
Console.Write("2. feladat: ");
Console.WriteLine($"Az állományban található törpék száma: {torpek.Count} db");

// 3. feladat
Console.Write("3. feladat: ");
Console.WriteLine($"A törpék átlagos súlya: {torpek.Average(x => x.suly).ToString("0.0")} kg");

// 4. feladat
Console.Write("4. feladat: ");
int legmagasabb = torpek.Max(x => x.magassag);
int legmagasabb_index = torpek.FindIndex(x => x.magassag == legmagasabb);

Console.WriteLine("A legmagasabb törpe adatai: ");
Console.WriteLine($"\tNév: {torpek[legmagasabb_index].nev}");
Console.WriteLine($"\tKlán: {torpek[legmagasabb_index].klan}");
if (torpek[legmagasabb_index].nem == "N")
{
    Console.WriteLine($"\tNem: lány");
}
else
{
    Console.WriteLine($"\tNem: férfi");
}
Console.WriteLine($"\tSúly: {torpek[legmagasabb_index].suly} kg");
Console.WriteLine($"\tMagasság: {torpek[legmagasabb_index].magassag} cm");

// 5. feladat
Console.Write("5. feladat: ");
Console.Write("A klán neve: ");
string klan_nev = Console.ReadLine();

bool klan_van = torpek.Any(x => x.klan.ToLower() == klan_nev);
if (klan_van)
{
    Console.WriteLine($"\tVan {klan_nev} nevű klánba tartozó törpe.");
}
else
{
    Console.WriteLine($"\tNincs {klan_nev} nevű klánba tartozó törpe.");
}

// 6. feladat
Console.Write("6. feladat: ");
double legkisebb_testtomegindex = torpek.Min(x => x.suly/Math.Pow(x.magassag, 2)*10000);
Console.WriteLine($"A legkisebb TTI érték: {legkisebb_testtomegindex.ToString("0.##")}");

// 7. feladat
Console.Write("7. feladat: ");
Console.Write("Nőnemü törpék: ");
List<Torpe> nonemu_torpek = torpek.Where(x => x.nem == "N").ToList();
Console.WriteLine(string.Join(", ", nonemu_torpek.Select(x => $"{x.nev} ({x.klan})")));

// 8. feladat
Console.Write("8. feladat: ");
Console.WriteLine("Résztvevők: ");
Console.WriteLine(string.Join("\n", torpek.OrderBy(x => x.klan).ThenBy(x => x.nev).Select(x => $"\t{x.nev} ({x.klan})")));

// 9. feladat
Console.Write("9. feladat: ");
Console.Write("Klánok: ");
List<string> klan_nevek = torpek.DistinctBy(x => x.klan).Select(x => x.klan).ToList();
Console.WriteLine($"{string.Join(", ", klan_nevek)}");

// 10. feladat
Console.Write("10. feladat: ");
Console.WriteLine("A 3 legnagyobb TTI-vel rendelkező törpe: ");

List<Torpe> legnagyobb_tti_torpek = torpek.OrderByDescending(x => (x.suly / Math.Pow(x.magassag, 2))*10000).Take(3).ToList();
Console.WriteLine(string.Join("\n", legnagyobb_tti_torpek.Select(x => $"\t{x.nev} ({x.klan})")));

public record Torpe(string nev, string klan, string nem, int suly, int magassag);