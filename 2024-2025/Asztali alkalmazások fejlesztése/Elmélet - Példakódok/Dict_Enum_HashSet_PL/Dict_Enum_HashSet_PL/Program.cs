Dictionary<string, string> allatok = new()
{
    {"tigris", "tiger" },
    {"kutya", "dog" },
    {"macska", "cat" },
    {"leopárd", "leopard" }
};

//allatok.Add("macska", "cat");

Console.WriteLine("A tárolt állatok:");
foreach (var item in allatok)
{
    Console.WriteLine($"\t{item.Key} - {item.Value}");
}

Dictionary<int, int> dobasSzam = new();
List<int> dobas = new();
for (int i = 0; i < 10; i++)
{
    dobas.Add(Random.Shared.Next(1, 7));
}
Console.WriteLine($"A dobások: {String.Join(", ", dobas)}");

foreach (var item in dobas)
{
    if (dobasSzam.ContainsKey(item))
        dobasSzam[item]++;
    else
        dobasSzam.Add(item, 1);
}
Console.WriteLine("Az egyes dobások előfordulásának száma:");
foreach (var item in dobasSzam)
{
    Console.WriteLine($"\t{item.Key}: {item.Value} db");
}

Console.WriteLine("Az egyes dobások előfordulásának száma:");
foreach (var item in dobasSzam.OrderBy(x => x.Key))
{
    Console.WriteLine($"\t{item.Key}: {item.Value} db");
}

Console.WriteLine("Az egyes dobások előfordulásának száma (3 legtöbbször előforduló):");
foreach (var item in dobasSzam.OrderByDescending(x => x.Value).Take(3))
{
    Console.WriteLine($"\t{item.Key}: {item.Value} db");
}

Dictionary<NapNev, DayOfWeek> magyarAngolNapNevek = new()
{
    { NapNev.hétfő, DayOfWeek.Monday },
    { NapNev.kedd, DayOfWeek.Tuesday },
    { NapNev.szerda, DayOfWeek.Wednesday },
    { NapNev.csütörtök, DayOfWeek.Thursday },
    { NapNev.péntek, DayOfWeek.Friday },
    { NapNev.szombat, DayOfWeek.Saturday },
    { NapNev.vasárnap, DayOfWeek.Sunday},
};

Console.WriteLine("Magyar - angol napnevek:");
foreach (var item in magyarAngolNapNevek)
{
    Console.WriteLine($"\t{item.Key} - {item.Value}");
}

HashSet<int> h1 = new() { 2, 3, 4, 5, 6, 7, 8, 6, 5, 4, 4};
HashSet<int> h2 = new() { 9, 8, 6, 4, 5, 3, 6, 11, 21, 44, 32, 1 };

Console.WriteLine($"Első halmaz elemei: {string.Join(", ", h1)}");
Console.WriteLine($"Második halmaz elemei: {string.Join(", ", h2)}");

Console.WriteLine($"Unió: {string.Join(", ", h1.Union(h2))}");
Console.WriteLine($"Metszet: {string.Join(", ", h1.Intersect(h2))}");
Console.WriteLine($"h1 különbség h2: {string.Join(", ", h1.Except(h2))}");
Console.WriteLine($"h2 különbség h1: {string.Join(", ", h2.Except(h1))}");

enum NapNev { hétfő = 1, kedd, szerda, csütörtök, péntek, szombat, vasárnap }

