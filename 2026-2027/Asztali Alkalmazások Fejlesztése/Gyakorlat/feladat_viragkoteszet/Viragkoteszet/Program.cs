using Viragkoteszet_LIB;

var alapanyagok = File.ReadAllLines("alapanyagok.txt").Skip(1).Select(sor =>
{
    string[] adatok = sor.Split(";");
    return new Alapanyag(adatok[0], adatok[1], int.Parse(adatok[2]), int.Parse(adatok[3]));
});
Katalogus katalogus = new Katalogus(alapanyagok);

List<Termek> termekLista = new List<Termek>();
foreach (var sor in File.ReadAllLines("termekek.txt").Skip(1))
{
    string[] adatok = sor.Split(";");
    int id = int.Parse(adatok[0]);
    string tipus = adatok[1];
    string megnevezes = adatok[2];

    Dictionary<string, int> alapanyagIgeny = new Dictionary<string, int>();
    for (int i = 3; i < adatok.Length; i += 2)
    {
        alapanyagIgeny[adatok[i]] = int.Parse(adatok[i + 1]);
    }

    termekLista.Add(new Termek(id, tipus, megnevezes, alapanyagIgeny, katalogus));
}
Termekek termekek = new Termekek(termekLista);

Dolgozok dolgozok = new Dolgozok(File.ReadAllLines("dolgozok.txt").Skip(1));

Console.WriteLine("Elkészíthető termékek:");
Console.WriteLine(termekek);
Console.WriteLine();

List<string> hibaLista = new List<string>();
foreach (var sor in File.ReadAllLines("feladatkiosztas.txt").Skip(1))
{
    try
    {
        FeladatKiosztas.Kioszt(sor, dolgozok, termekek);
    }
    catch (HibasFeladatException ex)
    {
        hibaLista.Add($"{ex.Message} ({sor})");
    }
}
File.WriteAllLines("hibalista.txt", hibaLista);

Console.WriteLine("Dolgozók a rájuk osztott feladatokkal töltött idő szerint:");
foreach (var dolgozo in dolgozok.DolgozokListaja)
{
    Console.WriteLine(dolgozo);
}