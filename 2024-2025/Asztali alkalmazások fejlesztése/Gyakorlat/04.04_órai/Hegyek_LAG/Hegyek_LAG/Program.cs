using Hegyek_LIB;

Hegyek hegyekMo = new (File.ReadAllLines("hegyekMo.txt").Skip(1));

// 2. feladat
Console.Write("2. feladat: ");
Console.WriteLine($"{hegyekMo.HegyekSzama} db hegy adatai találhatók a fájlban.");

// 3. feladat
Console.Write("3. feladat: ");
Console.WriteLine($"A legalacsonyabb hegy: ");
Hegy legalacsonyabb_hegy = hegyekMo.LegalacsonyabbHegy;
Console.WriteLine($"\t{legalacsonyabb_hegy.Hegycsucs} ({legalacsonyabb_hegy.Hegyseg}), {legalacsonyabb_hegy.Magassag} m");

// 4. feladat
Console.Write("4. feladat: ");
Console.WriteLine($"A hegycsúcsok átlagos magassága: {hegyekMo.AtlagMagassag.ToString("0.0")}");

// 5. feladat
Console.Write("5. feladat: ");
Console.WriteLine($"A Mátrában {hegyekMo.HegycsucsokSzama("Mátra")} db hegycsúcs található.");

// 6. feladat
Console.Write("6. feladat: ");
Console.WriteLine($"{hegyekMo.SzovegReszTalalatSzam("bérc")} hegycsúcs nevében szerepel a \"bérc\" szó.");

// 7. feladat
Console.Write("7. feladat: ");
Console.WriteLine($"A hegységek nevei: {string.Join("; ", hegyekMo.HegysegekNevei)}");

// 8. feladat
Console.Write("8. feladat: ");
Console.WriteLine($"A 3000 lábnál magasabb hegyek száma: {hegyekMo.AdottLabnalMagasabbHegyek(3000)} db");

// 9. feladat
Console.Write("9. feladat: ");
LegmagasabbakFajlbaIrasa(3);
Console.WriteLine($"A 3 legmagasabb hegycsúcs adatainak fájlbaírása megtörtént.");

void LegmagasabbakFajlbaIrasa(int darabSzam)
{
    List<string> kimenet = [];
    foreach (var hegy in hegyekMo.LegmagasabbHegyek(darabSzam))
    {
        kimenet.Add(hegy.ToString());
    }
    File.WriteAllLines("haromlegmag.txt", kimenet);
}