Console.WriteLine("Gyakorló feladat");

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

// 11. feladat
Console.Write("11. feladat: ");
int nok_db = torpek.Count(x => x.nem == "N");
Console.WriteLine($"{nok_db} nőnemű törpe van");

// 12. feladat
Console.Write("12. feladat: ");
int kova_db = torpek.Count(x => x.klan == "Kova");
Console.WriteLine($"{kova_db} Kova klánba tartozó törpe van");

// 13. feladat
Console.Write("13. feladat: ");
int acel_nok_db = torpek.Count(x => (x.klan == "Acél") && (x.nem == "N"));
Console.WriteLine($"{acel_nok_db} Acél klánba tartozó nőnemű törpe van");

// 14. feladat
Console.Write("14. feladat: ");
double atlagos_testtomegindex = torpek.Average(x => x.suly/Math.Pow(x.magassag, 2)*10000);
Console.WriteLine($"{atlagos_testtomegindex.ToString("0.##")} a törpék átlagos testtömegindexe");

// 15. feladat
Console.Write("15. feladat: ");
double atlagos_ferfi_testtomegindex = torpek.Where(x => x.nem == "F").Average(x => x.suly/Math.Pow(x.magassag, 2)*10000);
Console.WriteLine($"{atlagos_ferfi_testtomegindex.ToString("0.##")} a férfi törpék átlagos testtömegindexe");

// 16. feladat
Console.Write("16. feladat: ");
double legkisebb_testtomegindex = torpek.Min(x => x.suly/Math.Pow(x.magassag, 2)*10000);
int legkisebb_testtomegindex_index = torpek.FindIndex(x => x.suly/Math.Pow(x.magassag, 2)*10000 == legkisebb_testtomegindex);
Console.WriteLine($"{torpek[legkisebb_testtomegindex_index].nev} rendelkezik a legkisebb testtömegindexxel");

// 17. feladat
Console.Write("17. feladat: ");
int legkisebb_ferfi_suly = torpek.Where(x => x.nem == "F").Min(x => x.suly);
Console.WriteLine($"{legkisebb_ferfi_suly} kg a legkisebb súlyú férfi törpe");

// 18. feladat
Console.Write("18. feladat: ");
int legmagasabb_no = torpek.Where(x => x.nem == "N").Max(x => x.magassag);
int legmagasabb_no_index = torpek.FindIndex(x => (x.nem == "N") && (x.magassag == legmagasabb_no));
Console.WriteLine("A legmagasabb törpe adatai: ");
Console.WriteLine($"\tNév: {torpek[legmagasabb_no_index].nev}");
Console.WriteLine($"\tKlán: {torpek[legmagasabb_no_index].klan}");
Console.WriteLine($"\tNem: lány");
Console.WriteLine($"\tSúly: {torpek[legmagasabb_no_index].suly} cm");
Console.WriteLine($"\tMagasság: {torpek[legmagasabb_no_index].magassag} kg");

// 19. feladat
Console.Write($"19. feladat: ");
bool nagyobb_testtomegindex = torpek.Any(x => x.suly/Math.Pow(x.magassag, 2)*10000>40);
if (nagyobb_testtomegindex)
{
    Console.WriteLine("Van olyan törpe, akinek 40-nél nagyobb a testtömegindexe");
}
else
{
    Console.WriteLine("Nincs olyan törpe, akinek 40-nél nagyobb a testtömegindexe");
}

// 20. feladat
Console.Write("20. feladat: ");
bool kova_no_van = torpek.Any(x => (x.klan == "Kova") && (x.nem == "L"));
if (kova_no_van)
{
    Console.WriteLine($"Jött női törpe a Kova klánból");
}
else
{
    Console.WriteLine($"Nem jött női törpe a Kova klánból");
}

// 21. feladat
Console.Write("21. feladat: ");
int ferfi_db = torpek.Count(x => x.nem == "F");
Console.WriteLine($"{Math.Abs(ferfi_db-nok_db)} a férfi és a nő törpék számának a különbsége");

// 22. feladat
Console.WriteLine("22. feladat: ");
List<Torpe> klanonkent_magassag = torpek.OrderBy(x => x.klan).ThenByDescending(x => x.magassag).ToList();
Console.WriteLine($"{string.Join("\n", klanonkent_magassag.Select(x => $"\t{x.klan}: {x.nev}"))}");

// 23. feladat
Console.WriteLine("23. feladat: ");
List<Torpe> rendezett = torpek.OrderByDescending(x => x.nem).ThenBy(x => x.nev).ToList();
Console.WriteLine($"{string.Join("\n", rendezett.Select(x => $"\t{x.nev} ({x.nem})"))}");

// 24. feladat
Console.Write("24. feladat: ");
List<Torpe> kulonbozo_testsuly = torpek.DistinctBy(x => x.suly).OrderBy(x => x.suly).ToList();
int kulonbozo_testsuly_db = kulonbozo_testsuly.Count;
Console.WriteLine($"{kulonbozo_testsuly_db} különböző testsúlyú törpe jött el");
Console.Write("\tKíváncsi vagy a különböző testsúlyakra? (i/n): ");
string testsuly = Console.ReadLine();
if (testsuly.ToLower() == "i")
{
    Console.WriteLine($"{string.Join("\n", kulonbozo_testsuly.Select(x => $"\t{x.suly} kg"))}");
}

// 25. feladat
Console.WriteLine("25. feladat: ");
List<Torpe> legalacsonyabb_ferfi_torpek = torpek.Where(x => x.nem == "F").OrderBy(x => x.magassag).Take(5).ToList();
Console.WriteLine($"{string.Join("\n", legalacsonyabb_ferfi_torpek.Select(x => $"\t{x.nev} ({x.magassag} cm)"))}");

public record Torpe(string nev, string klan, string nem, int suly, int magassag);