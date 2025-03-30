Console.WriteLine("Snooker feladat");

// 1. feladat
StreamReader fajl_beolvasas = new StreamReader("snooker.txt");
List<Versenyzo> versenyzok = new List<Versenyzo>();
string[] adatok = fajl_beolvasas.ReadLine().Split(";");

while (!fajl_beolvasas.EndOfStream)
{
    string[] sor = fajl_beolvasas.ReadLine().Split(";");
    Versenyzo versenyzo = new Versenyzo(int.Parse(sor[0]), sor[1], sor[2], int.Parse(sor[3]));
    versenyzok.Add(versenyzo);
}
fajl_beolvasas.Close();

// 2. feladat
Console.Write("2. feladat: ");
Console.WriteLine($"A világranglistán {versenyzok.Count} versenyző szerepel");

// 3. feladat
Console.Write("3. feladat: ");
Console.WriteLine("Az első helyen áll: ");

int elso_helyezett_index = versenyzok.FindIndex(x => x.helyezes == 1);
Console.WriteLine($"\tNév: {versenyzok[elso_helyezett_index].nev}");
Console.WriteLine($"\tOrszág: {versenyzok[elso_helyezett_index].orszag}");
Console.WriteLine($"\tNyeremény: {versenyzok[elso_helyezett_index].nyeremeny} font");

// 4. feladat
Console.Write("4. feladat: ");
double atlag_nyeremeny = versenyzok.Average(x => x.nyeremeny);
Console.WriteLine($"A versenyzők átlagosan {atlag_nyeremeny.ToString("0.00")} fontot kerestek");

// 5. feladat
Console.Write("5. feladat: ");
int nem_angol_db = versenyzok.Count(x => x.orszag != "Anglia");
Console.WriteLine($"{nem_angol_db} versenyző nem Anglia színeiben indul");

// 6. feladat
Console.Write("6. feladat: ");
int legjobban_kereso_kinai = versenyzok.Where(x => x.orszag == "Kína").Max(x => x.nyeremeny);
int legjobban_kereso_kinai_index = versenyzok.FindIndex(x => (x.orszag == "Kína") && (x.nyeremeny == legjobban_kereso_kinai));
Console.WriteLine($"A legjobban kereső kínai versenyző: ");
Console.WriteLine($"\tHelyezés: {versenyzok[legjobban_kereso_kinai_index].helyezes}");
Console.WriteLine($"\tNév: {versenyzok[legjobban_kereso_kinai_index].nev}");
Console.WriteLine($"\tNyeremény összege: {versenyzok[legjobban_kereso_kinai_index].nyeremeny*380} Ft");

// 7. feladat
Console.Write("7. feladat: ");
Console.Write("A versenyző országa: ");
string orszag = Console.ReadLine();

bool indulo = versenyzok.Any(x => x.orszag == orszag);
if (indulo)
{
    Console.WriteLine($"\tVan {orszag} színeiben induló versenyző.");
}
else
{
    Console.WriteLine($"\tNincs {orszag} színeiben induló versenyző.");
}

// 8. feladat
Console.Write("8. feladat: ");
Console.WriteLine("A 3 legelőkelőbb helyen álló angol versenyző: ");
List<Versenyzo> angol_top3 = versenyzok.Where(x => x.orszag == "Anglia").OrderBy(x => x.helyezes).Take(3).ToList();
for (int i = 0; i < angol_top3.Count; i++)
{
    Console.WriteLine($"\t{i+1}. {angol_top3[i].nev}");
}

// 9. feladat
Console.Write("9. feladat: ");
Console.Write("Az országok nevei: ");
List<string> orszagok = versenyzok.DistinctBy(x => x.orszag).OrderBy(x => x.orszag).Select(x => x.orszag).ToList();
Console.WriteLine($"{string.Join(", ", orszagok)}");

// 10. feladat
Console.Write("10. feladat: ");
Console.Write($"Skócia színeiben induló versenyzők: ");
List<string> skot_versenyzok = versenyzok.Where(x => x.orszag == "Skócia").Select(x => x.nev).OrderBy(x => x).ToList();
Console.WriteLine($"{string.Join(", ", skot_versenyzok)}");

public record Versenyzo(int helyezes, string nev, string orszag, int nyeremeny);