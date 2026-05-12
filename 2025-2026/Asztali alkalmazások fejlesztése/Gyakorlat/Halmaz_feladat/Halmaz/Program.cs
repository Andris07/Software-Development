using Halmaz_LIB;

// Lottó sorsolás feladat
Console.WriteLine("Lottó sorsolás feladat");
Console.WriteLine("1 - Ötös lottó (5 szám, 1-90)");
Console.WriteLine("2 - Hatos lottó (6 szám, 1-45)");
Console.WriteLine("3 - Skandináv lottó (7 szám, 1-35)");
Console.WriteLine();

Console.Write("Válassz lottót: ");
try
{
    if (!int.TryParse(Console.ReadLine(), out int valasztas)) throw new Exception("Érvénytelen szám formátum!");

    RendezettHalmaz<int> eredmeny = valasztas switch
    {
        1 => Lotto.Sorsolas(5, 90),
        2 => Lotto.Sorsolas(6, 45),
        3 => Lotto.Sorsolas(7, 35),
        _ => throw new Exception("Érvénytelen lottó típus!")
    };

    Console.Write("Kisorsolt számok: ");
    Console.WriteLine(eredmeny);
}
catch (Exception ex)
{
    Console.WriteLine("Hiba történt!");
    Console.WriteLine(ex.Message);
}
Console.WriteLine();

Console.WriteLine("Feladat bezárása!");
Console.ReadKey();
Console.Clear();

try
{
    string fajlNev = "adatok.txt";
    var szemelyek = FajlKezelo.FajlBeolvasas(fajlNev);

    var diakok = szemelyek.OfType<Diak>();
    var tanarok = szemelyek.OfType<Tanar>();

    // Manuálisan megadott darabszám
    int diakSzam;
    int tanarSzam;

    Console.Write("Hány diákot szeretnél kisorsolni? ");
    while (!int.TryParse(Console.ReadLine(), out diakSzam) || diakSzam < 1) Console.Write("Érvénytelen szám vagy formátum, próbáld újra: ");

    Console.Write("Hány tanárt szeretnél kisorsolni? ");
    while (!int.TryParse(Console.ReadLine(), out tanarSzam) || tanarSzam < 1) Console.Write("Érvénytelen szám vagy formátum, próbáld újra: ");

    var kisorsoltDiakok = Kerdoiv.Sorsolas(diakok, diakSzam);
    var kisorsoltTanarok = Kerdoiv.Sorsolas(tanarok, tanarSzam);

    Console.WriteLine("Kisorsolt diákok: ");
    foreach (var d in kisorsoltDiakok.Sorozat())
    {
        Console.WriteLine(d);
    }

    Console.WriteLine("\nKisorsolt tanárok: ");
    foreach (var t in kisorsoltTanarok.Sorozat())
    {
        Console.WriteLine(t);
    }

    Console.Write("Kérem adja meg a diákokhoz lementéséhez tartozó JSON file nevét (.json nélkül): ");
    fajlNev = Console.ReadLine()!;
    JsonKezelo.JsonMentes($"{fajlNev}.json", kisorsoltDiakok);
    Console.WriteLine($"Megtörtént a diákok lementése {fajlNev}.json néven!");

    Console.Write("Kérem adja meg a tanárokhoz lementéséhez tartozó JSON file nevét (.json nélkül): ");
    fajlNev = Console.ReadLine()!;
    JsonKezelo.JsonMentes($"{fajlNev}.json", kisorsoltTanarok);
    Console.WriteLine($"Megtörtént a tanárok lementése {fajlNev}.json néven!");
}
catch (Exception ex)
{
    Console.WriteLine("Hiba történt!");
    Console.WriteLine(ex.Message);
}
Console.WriteLine();

Console.WriteLine("Feladat bezárása!");
Console.ReadKey();
Console.Clear();

try
{
    // Betöltés diákok JSON-ból
    Console.Write("Add meg a diákok JSON file nevét (.json nélkül): ");
    string diakFajl = Console.ReadLine()!;
    var betoltottDiakok = JsonKezelo.JsonBetoltes<Diak>($"{diakFajl}.json"); // visszatér RendezettHalmaz<Diak>-dal
    Console.WriteLine("\nBetöltött diákok:");
    foreach (var d in betoltottDiakok)
    {
        Console.WriteLine(d);
    }

    // Betöltés tanárok JSON-ból
    Console.Write("Add meg a tanárok JSON file nevét (.json nélkül): ");
    string tanarFajl = Console.ReadLine()!;
    var betoltottTanarok = JsonKezelo.JsonBetoltes<Tanar>($"{tanarFajl}.json"); // visszatér RendezettHalmaz<Tanar>-ral
    Console.WriteLine("\nBetöltött tanárok:");
    foreach (var t in betoltottTanarok)
    {
        Console.WriteLine(t);
    }
}
catch (Exception ex)
{
    Console.WriteLine("Hiba történt a JSON fájlok betöltése közben!");
    Console.WriteLine(ex.Message);
}
Console.WriteLine("\nProgram bezárása!");
Console.ReadKey();