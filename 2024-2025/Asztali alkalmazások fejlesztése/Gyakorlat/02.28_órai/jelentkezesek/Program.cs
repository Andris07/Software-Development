Console.WriteLine("Felvételi feladat");

// 1. feladat
Console.WriteLine("1. feladat: ");
StreamReader fajl_beolvasasas = new StreamReader("jelentkezesek.csv");
List<Jelentkezo> jelentkezok = new List<Jelentkezo>();
string[] adatok = fajl_beolvasasas.ReadLine().Split(";");

while (!fajl_beolvasasas.EndOfStream)
{
    string[] sor = fajl_beolvasasas.ReadLine().Split(";");
    Jelentkezo jelentkezo = new Jelentkezo(sor[0], sor[1], sor[2], int.Parse(sor[3]), int.Parse(sor[4]), int.Parse(sor[5]), int.Parse(sor[6]));
    jelentkezok.Add(jelentkezo);
}
fajl_beolvasasas.Close();
Console.WriteLine($"Az iskolába összesen {jelentkezok.Count} jelentkezés történt.\n");

// 2. feladat
Console.WriteLine("2. feladat: ");
int info_lany_db = jelentkezok.Count(x => (x.nem == "l") && (x.kepzes == "informatika"));
Console.WriteLine($"Az informatika szakra jelentkező lányok száma: {info_lany_db}\n");

// 3. feladat
Console.WriteLine("3. feladat: ");
int kozgazdasag_fiu_db = jelentkezok.Count(x => (x.nem == "f") && (x.kepzes == "közgazdasági"));
int kozgazdasag_lany_db = jelentkezok.Count(x => (x.nem == "l") && (x.kepzes == "közgazdasági"));
if (kozgazdasag_fiu_db > kozgazdasag_lany_db)
{
    Console.WriteLine($"Fiúk jelentkeztek többen közgazdasági szakra.\n");
}
else if (kozgazdasag_fiu_db < kozgazdasag_lany_db)
{
    Console.WriteLine($"Lányok jelentkeztek többen közgazdasági szakra.\n");
}
else
{
    Console.WriteLine($"Ugyanannyian jelentkeztek közgazdasági szakra.\n");
}

// 4. feladat
Console.WriteLine("4. feladat: ");
Console.WriteLine($"A következő képzésekre lehetett jelentkezni az iskolában: ");
List<Jelentkezo> kepzesek = jelentkezok.DistinctBy(x => x.kepzes).ToList();
Console.WriteLine($"{string.Join(", ", kepzesek.Select(x => x.kepzes))}");
Console.WriteLine();

// 5. feladat
Console.WriteLine("5. feladat: ");
int max_pont = jelentkezok.Max(x => x.szerzett);
int max_pont_index = jelentkezok.FindIndex(x => x.szerzett == max_pont);

Console.WriteLine($"A legtöbb pontot szerző jelentkező: ");
Console.Write($"\t{jelentkezok[max_pont_index].nev}");
if (jelentkezok[max_pont_index].nem == "l")
{
    Console.WriteLine(" (lány)");
}
else
{
    Console.WriteLine(" (fiú)");
}
Console.WriteLine($"\tképzés: {jelentkezok[max_pont_index].kepzes}");
Console.WriteLine($"\tszerzett pontszám: {jelentkezok[max_pont_index].szerzett}");
Console.WriteLine($"\tjelentkezési sorrend: {jelentkezok[max_pont_index].sorrend}\n");

// 6. feladat
Console.WriteLine("6. feladat: ");
List<Jelentkezo> informatika_felvettek = jelentkezok.Where(x => (x.kepzes == "informatika") && (x.szerzett >= x.minimum)).ToList();
double informatika_felvettek_atlag = informatika_felvettek.Select(x => x.szerzett).Average();
Console.WriteLine($"Az informatika képzésre a ponthatárt elérők átlag szerzett pontszáma: {informatika_felvettek_atlag.ToString("0.0")} pont\n");

// 7. feladat
Console.WriteLine("7. feladat: ");
Console.WriteLine("Az angol és francia képzésre is jelentkezők nevei: ");
List<string> angol_francia = jelentkezok.Where(x => x.kepzes == "angol" || x.kepzes == "francia").GroupBy(x => x.nev).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
angol_francia.Sort();
Console.WriteLine(string.Join(", ", angol_francia));
Console.WriteLine();

// 8. feladat
Console.WriteLine("8. feladat: ");
Console.WriteLine($"Az egyes szakokra elsősorban jelentkezők száma: ");
int angol_db = jelentkezok.Count(x => (x.kepzes == "angol") && (x.sorrend == 1));
int francia_db = jelentkezok.Count(x => (x.kepzes == "francia") && (x.sorrend == 1));
int informatika_db = jelentkezok.Count(x => (x.kepzes == "informatika") && (x.sorrend == 1));
int kornyezetvedelmi_db = jelentkezok.Count(x => (x.kepzes == "környezetvédelmi") && (x.sorrend == 1));
int kozgazdasagi_db = jelentkezok.Count(x => (x.kepzes == "közgazdasági") && (x.sorrend == 1));
int matematika_db = jelentkezok.Count(x => (x.kepzes == "matematika") && (x.sorrend == 1));

Console.WriteLine($"angol: {angol_db}");
Console.WriteLine($"francia: {francia_db}");
Console.WriteLine($"informatika: {informatika_db}");
Console.WriteLine($"környezetvédelmi: {kornyezetvedelmi_db}");
Console.WriteLine($"közgazdasági: {kozgazdasagi_db}");
Console.WriteLine($"matematika: {matematika_db}");

public record Jelentkezo(string nev, string nem, string kepzes, int felveheto, int minimum, int sorrend, int szerzett);