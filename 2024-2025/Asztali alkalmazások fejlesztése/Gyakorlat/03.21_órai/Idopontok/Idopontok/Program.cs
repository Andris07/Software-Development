using Idopontok;

// teszt1
Console.WriteLine("teszt1");
Idopont teszt1 = new Idopont();

// Értékek kiírása
Console.WriteLine($"{teszt1.Ora} óra");
Console.WriteLine($"{teszt1.Perc} perc");
Console.WriteLine($"{teszt1.MasodPerc} másodperc");
Console.WriteLine();

// Metódusok ellenőrzése
Console.WriteLine($"Délelőtt van-e? {teszt1.Delelott}");
Console.WriteLine($"{teszt1.HanyPercEddig()} perc telt el eddig");
Console.WriteLine($"{teszt1.HanyMasodPercEddig()} másodperc telt el eddig");
Console.WriteLine();

// Végső megjelenítés
Console.WriteLine(teszt1.Megjelenites());
Console.WriteLine();

// teszt2
Console.WriteLine("teszt2");
Idopont teszt2 = new Idopont(32, 72, 24);

// Értékek kiírása
Console.WriteLine($"{teszt2.Ora} óra");
Console.WriteLine($"{teszt2.Perc} perc");
Console.WriteLine($"{teszt2.MasodPerc} másodperc");
Console.WriteLine();

// Metódusok ellenőrzése
Console.WriteLine($"Délelőtt van-e? {teszt1.Delelott}");
Console.WriteLine($"{teszt1.HanyPercEddig()} perc telt el eddig");
Console.WriteLine($"{teszt1.HanyMasodPercEddig()} másodperc telt el eddig");
Console.WriteLine();

// Végső megjelenítés
Console.WriteLine(teszt2.Megjelenites());