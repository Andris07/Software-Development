using Szankok;
Random r = new Random();

// teszt 1
Console.WriteLine("teszt1");
Szanko teszt1 = new Szanko();

// Értékek kiírása
Console.WriteLine($"Üres-e a szánkó? {teszt1.UresE}");
Console.WriteLine($"Szánkó létszáma: {teszt1.Letszam}");
Console.WriteLine($"Szánkó állapota: {teszt1.Allapot}%");
Console.WriteLine($"Szánkó terhelése: {teszt1.Terheles}");
Console.WriteLine($"Szánkó max teherbírása: {teszt1.MaxTeherBiras}");
Console.WriteLine();

// Metódusok ellenőrzése
Console.WriteLine($"Szánkóra felülés: {teszt1.FelUlValaki(r.Next(40, 81))}");
Console.WriteLine($"{teszt1.Log()}");
Console.WriteLine($"Szánkóval csúszás: {teszt1.Csuszas()}");
Console.WriteLine($"{teszt1.Log()}");
Console.WriteLine($"Szánkó javítása: {teszt1.Javitas(r.Next(0, 26))}");
Console.WriteLine();

// Végső megjelenítés
Console.WriteLine(teszt1.Log());
Console.WriteLine();

// teszt 2
Szanko teszt2 = new Szanko(180);

// Értékek kiírása
Console.WriteLine($"Üres-e a szánkó? {teszt2.UresE}");
Console.WriteLine($"Szánkó létszáma: {teszt2.Letszam}");
Console.WriteLine($"Szánkó állapota: {teszt2.Allapot}%");
Console.WriteLine($"Szánkó terhelése: {teszt2.Terheles}");
Console.WriteLine($"Szánkó max teherbírása: {teszt2.MaxTeherBiras}");
Console.WriteLine();

// Metódusok ellenőrzése
Console.WriteLine($"Szánkóra felülés: {teszt2.FelUlValaki(r.Next(40, 81))}");
Console.WriteLine($"{teszt2.Log()}");
Console.WriteLine($"Szánkóra felülés: {teszt2.FelUlValaki(r.Next(40, 81))}");
Console.WriteLine($"{teszt2.Log()}");
Console.WriteLine($"Szánkóra felülés: {teszt2.FelUlValaki(r.Next(40, 81))}");
Console.WriteLine($"{teszt2.Log()}");
Console.WriteLine($"Szánkóval csúszás: {teszt2.Csuszas()}");
Console.WriteLine($"{teszt2.Log()}");
Console.WriteLine($"Szánkó javítása: {teszt2.Javitas(r.Next(0, 26))}");
Console.WriteLine();

// Végső megjelenítés
Console.WriteLine(teszt2.Log());