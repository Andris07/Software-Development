using Cseveges;
using System.Globalization;

Beszelgetesek beszelgetesek = BeszelgetesekBeolvasas("csevegesek.txt", 1);
List<string> tagok = new List<string>();

foreach (var fajlSor in File.ReadAllLines("tagok.txt"))
{
    tagok.Add(fajlSor);
}

// 4. feladat
Console.WriteLine($"4. feladat: Tagok száma: {tagok.Count}fő - Beszélgetések: {beszelgetesek.BeszelgetesekSzama}db");

// 5. feladat
var leghosszabb = beszelgetesek.LeghosszabbBeszelgetes;

Console.WriteLine($"5. feladat: Leghosszabb beszélgetés adatai");
Console.WriteLine($"\tKezdeményező:\t{leghosszabb.Kezdemenyezo}");
Console.WriteLine($"\tFogadó:\t\t{leghosszabb.Fogado}");
Console.WriteLine($"\tKezdete:\t{leghosszabb.Kezdet:yy.MM.dd-HH:mm:ss}");
Console.WriteLine($"\tVége:\t\t{leghosszabb.Veg:yy.MM.dd-HH:mm:ss}");
Console.WriteLine($"\tHossz:\t\t{leghosszabb.Hossz.TotalSeconds}mp");

// 6. feladat
Console.Write("6. feladat: Adja meg egy tag nevét: ");
string keresettNev = Console.ReadLine()?.Trim() ?? "";

TimeSpan erentettOsszIdeje = beszelgetesek.SzemelyOsszBeszelgetesenekIdeje(keresettNev);

Console.WriteLine("\tA beszélgetések összes ideje: {0}", erentettOsszIdeje);

// 7. feladat
Console.WriteLine("7. feladat: Nem beszélgettek senkivel");

var nemBeszelgetok = tagok.Where(t => !beszelgetesek.Beszelgetok().Contains(t));
foreach (var t in nemBeszelgetok) Console.WriteLine($"\t{t}");

// 8. feladat
Console.WriteLine("8. feladat: Leghosszabb csendes időszak 15h-tól");

DateTime kezdoIdo = DateTime.ParseExact("21.09.27-15:00:00", "yy.MM.dd-HH:mm:ss", CultureInfo.InvariantCulture);

var rendezett = beszelgetesek.RendezettBeszelgetesek;

DateTime aktualisVege = kezdoIdo;
TimeSpan maxCsend = TimeSpan.Zero;
DateTime maxCsendKezdet = kezdoIdo;
DateTime maxCsendVeg = kezdoIdo;

foreach (var b in rendezett)
{
    if (b.Kezdet > aktualisVege)
    {
        TimeSpan csend = b.Kezdet - aktualisVege;

        if (csend > maxCsend)
        {
            maxCsend = csend;
            maxCsendKezdet = aktualisVege;
            maxCsendVeg = b.Kezdet;
        }
    }

    if (b.Veg > aktualisVege) aktualisVege = b.Veg;
}

Console.WriteLine("\tKezdete: {0:yy.MM.dd-HH:mm:ss}", maxCsendKezdet);
Console.WriteLine("\tVége: \t {0:yy.MM.dd-HH:mm:ss}", maxCsendVeg);
Console.WriteLine("\tHossza:\t {0:00}:{1:00}:{2:00}", (int)maxCsend.TotalHours, maxCsend.Minutes, maxCsend.Seconds);

Beszelgetesek BeszelgetesekBeolvasas(string fajlNev, int kihagyas)
{
    return new Beszelgetesek(File.ReadAllLines(fajlNev).Skip(kihagyas));
}