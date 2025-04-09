using Hegyek_Lib;

Hegyek hegyekMo = new(File.ReadAllLines("hegyekMO.txt").Skip(1));
Console.WriteLine($"{hegyekMo.HegyekSzama} db hegy adatai találhatók a fájlban.");
Hegy legalacsonyabb = hegyekMo.LegalacsonyabbHegy;
Console.WriteLine($"A legalacsonyabb hegy: {legalacsonyabb.Nev} " +
    $"({legalacsonyabb.Hegyseg}), {legalacsonyabb.Magassag} m.");
Console.WriteLine($"A hegycsúcsok átlagos magassága: {hegyekMo.AtlagMagassag:0.0}");
Console.WriteLine($"A Mátrában {hegyekMo.HegycsucsokSzama("Mátra")} db hegycsúcs található.");
Console.WriteLine($"{hegyekMo.SzovegReszTalalatSzam("bérc")} hegycsúcs nevében szerepel a \"bérc\" szó.");
Console.WriteLine($"A hegységek nevei: {String.Join("; ", hegyekMo.HegysegekNevei)}");

LegmagasabbakFajlbaIrasa(3);

void LegmagasabbakFajlbaIrasa(int darabSzam)
{
    List<string> kimenet = new List<string>();
    foreach (var item in hegyekMo.LegmagasabbHegyek(darabSzam))
    {
        kimenet.Add(item.ToString());
    }
    File.WriteAllLines("haromlegmag.txt", kimenet);
}
