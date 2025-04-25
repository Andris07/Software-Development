using Szeleromuvek_Lib;

Szeleromuvek szeleromuvek = new(Beolvasas());

Console.WriteLine("1. feladat:");
Console.WriteLine($"A beolvasott adatok száma: {szeleromuvek.TelepitesekSzama}");
Console.WriteLine();

Console.WriteLine("2.feladat:");
Console.WriteLine("Régiónként a szélerőmű telepítések száma:");
foreach (var item in szeleromuvek.RegionkentTelepitesekSzama())
{
    Console.WriteLine($"{item.Key}: {item.Value} db helyszín");
}
Console.WriteLine();

Console.WriteLine("3. feladat:");
Console.WriteLine($"{szeleromuvek.LegtobbSzeleromutTartalmazoRegio} régióban " +
	$"volt a legtöbbször szélerőmű telepítés.");
Console.WriteLine();

Console.WriteLine("4. feladat:");
Console.WriteLine("Régiónként a szélerőművek száma:");
foreach (var item in szeleromuvek.RegionkentSzeleromuvekSzama())
{
    Console.WriteLine($"{item.Key}: {item.Value} db szélerőmű");
}


static IEnumerable<Szeleromu> Beolvasas()
{
	foreach (var item in File.ReadLines("szeleromuvek.csv").Skip(1))
	{
		string[] adatSor = item.Split(';');
		yield return new Szeleromu(adatSor[0], adatSor[1], adatSor[2],
			int.Parse(adatSor[3]), int.Parse(adatSor[4]), int.Parse(adatSor[5]));
	}
}