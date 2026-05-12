using Mikulas_Jatekgyar_LIB;

File.Delete("hibalista.txt");

GyartasAdatok gyartasTipusok = new(GyartasTipusBeolvasas("gyartas.txt"));
Console.WriteLine($"Elérhető gyártás azonosítók: {string.Join("; ", gyartasTipusok.ElerhetoGyartasAzonositok)}");
Console.WriteLine();

Jatekok jatekTipusok = new(AjandekTipusBeolvasas("ajandekok.txt"));
Console.WriteLine($"A gyártott játékok: {string.Join(", ", jatekTipusok.JatekTipusok)}");
Console.WriteLine();

Feladatok feladatok = FeladatHozzaadas();
Console.WriteLine("Az elvégzendő feladatok: ");
foreach (var feladat in feladatok.FeladatLista)
{
	Console.WriteLine($"\t{feladat}");
}
Console.WriteLine();

Console.WriteLine("Játékonként a készítendő darabszámok: ");
foreach (var feladat in feladatok.FeladatokOsszmennyisege())
{
	Console.WriteLine($"\t{feladat.Key}: {feladat.Value} db");
}

IEnumerable<GyartasAdat> GyartasTipusBeolvasas(string fajlNev)
{
	foreach (var fajlSor in File.ReadAllLines(fajlNev).Skip(1))
	{
		string[] adatSor = fajlSor.Split(";");
		yield return new GyartasAdat(adatSor[0], adatSor[1], int.Parse(adatSor[2]));
	}
}

IEnumerable<Jatek> AjandekTipusBeolvasas(string fajlNev)
{
    foreach (var fajlSor in File.ReadAllLines(fajlNev).Skip(1))
    {
        yield return JatekFactory.Factory(fajlSor, gyartasTipusok);
    }
}

IEnumerable<Feladat> FeladatokBeolvasas(string fajlNev)
{
	foreach (var fajlSor in File.ReadAllLines(fajlNev).Skip(1))
	{
		string[] adatSor = fajlSor.Split(";");
		Jatek? jatek = jatekTipusok[adatSor[0]];
		int darabszam = int.Parse(adatSor[1]);

		if (jatek is null)
		{
			File.AppendAllText("hibalista.txt", $"{adatSor[0]}: Ilyen azonosítójú játékot nem gyártanak.\n");
		}
		else
		{
			Feladat? feladat = null;

			try
			{
				feladat = new Feladat(jatek, darabszam);
			}
			catch (TulSokFeladatException ex)
			{
				File.AppendAllText("hibalista.txt", $"{ex.Message} - {darabszam} db {jatek.Megnevezes}: {jatek.ElkeszitesiIdo * darabszam} perc\n");
			}

            if (feladat is not null)
            {
				yield return feladat;
            }
        }
	}
}

Feladatok FeladatHozzaadas()
{
	Feladatok feladatok = new();
	foreach (var feladat in FeladatokBeolvasas("feladatok.txt"))
	{
		feladatok += feladat;
	}
	return feladatok;
}