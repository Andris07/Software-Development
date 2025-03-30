Console.WriteLine("Busójárás feladat");

// a feladat
Console.WriteLine("a feladat");
StreamReader fajl_beolvasas_jelentkezok = new StreamReader("jelentkezok.txt");
List<string> jelentkezok = new List<string>();

while (!fajl_beolvasas_jelentkezok.EndOfStream)
{
    string jelentkezo = fajl_beolvasas_jelentkezok.ReadLine();
    jelentkezok.Add(jelentkezo);
}
fajl_beolvasas_jelentkezok.Close();

Console.WriteLine($"A jelentkezők névsora: ");
Console.WriteLine($"{string.Join("\n", jelentkezok)}");
Console.WriteLine();

// b feladat
Console.WriteLine("b feladat");
List<string> jelentkezok_mehet = new List<string>();

if (jelentkezok.Count >= 40)
{
    jelentkezok_mehet = jelentkezok.GetRange(0, 40);
    jelentkezok_mehet.Sort();
}
Console.WriteLine("Kirándulók névsora: ");
Console.WriteLine($"{string.Join("\n", jelentkezok_mehet)}");
Console.WriteLine();

// c feladat
Console.WriteLine("c feladat");
List<string> jelentkezok_nem_mehet = jelentkezok.Except(jelentkezok_mehet).ToList();

Console.WriteLine("Nem kirándulók névsora: ");
Console.WriteLine($"{string.Join("\n", jelentkezok_nem_mehet)}");
Console.WriteLine();

// d feladat
Console.WriteLine("d feladat");
StreamReader fajl_beolvasas_bukottak = new StreamReader("bukott.txt");
List<string> bukottak = new List<string>();

while (!fajl_beolvasas_bukottak.EndOfStream)
{
    string bukott = fajl_beolvasas_bukottak.ReadLine();
    bukottak.Add(bukott);
}
bukottak.Sort();
fajl_beolvasas_bukottak.Close();
Console.WriteLine($"{bukottak.Count} jelentkezőt kellett utólag törölni a névsorból\n");

for (int i = 0; i < bukottak.Count; i++)
{
    if (jelentkezok.Contains(bukottak[i]))
    {
        jelentkezok_mehet.Remove(bukottak[i]);
    }
}

StreamWriter fajl_iras_bukottak = new StreamWriter("torolt.txt");
fajl_iras_bukottak.WriteLine($"{string.Join("\n", bukottak)}");
fajl_iras_bukottak.Close();

// e feladat
Console.WriteLine("e feladat");
List<string> bukott_kirandulok = jelentkezok_mehet.Intersect(bukottak).ToList();
List<string> bukottak_helyett = new List<string>();
int bukott_kirandulo_db = bukott_kirandulok.Count;
int index = 0;

while (bukottak_helyett.Count < bukott_kirandulo_db && index < jelentkezok_nem_mehet.Count)
{
    string bukott_helyett = jelentkezok_nem_mehet[index];
    if (!bukottak.Contains(bukott_helyett))
    {
        bukottak_helyett.Add(bukott_helyett);
        jelentkezok_mehet.Add(bukott_helyett);
    }
    index++;
}

if (bukottak_helyett.Count < bukott_kirandulo_db)
{
    Console.WriteLine("Nem volt elegendő jelentkező a bukottak helyettesítésére.");
}
else
{
    Console.WriteLine($"A bukottak helyett utólagosan bekerült kirándulók: ");
    Console.WriteLine($"{string.Join("\n", bukottak_helyett)}");
}

// f feladat
StreamWriter fajl_iras_resztvevok = new StreamWriter("resztvevok.txt");
jelentkezok_mehet.Sort();
fajl_iras_resztvevok.WriteLine($"{string.Join("\n", jelentkezok_mehet)}");
fajl_iras_resztvevok.Close();

// g feladat
Console.WriteLine("g feladat");
Console.Write("Kérem adja meg a diák nevét: ");
string nev = Console.ReadLine();

if (jelentkezok.Contains(nev))
{
    if (!bukottak.Contains(nev))
    {
        if (jelentkezok_mehet.Contains(nev))
        {
            Console.WriteLine("Részt vehet a kiránduláson");
        }
        else
        {
            Console.WriteLine("Helyhiány miatt elutasítva");
        }
    }
    else
    {
        Console.WriteLine("Bukás miatt elutasítva");
    }
}
else
{
    Console.WriteLine("Nem jelentkezett a kirándulásra");
}