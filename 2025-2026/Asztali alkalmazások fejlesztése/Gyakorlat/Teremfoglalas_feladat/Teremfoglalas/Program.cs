using Teremfoglalas_LIB;

File.Delete("hibalista.txt");

TeremNyilvantartas termek = new(TeremBeolvasas("termek.txt"));

Console.WriteLine("Az elérhető termek: ");
foreach (var terem in termek.TermekAzonositoi())
{
    Console.WriteLine(terem);
}
Console.WriteLine();

termek.TeremFoglalasok(FoglalasBeolvasas("foglalasok.txt"));

Console.WriteLine("A termek a foglalások után: ");
foreach (var terem in termek.Termek())
{
    Console.WriteLine(terem);
}
Console.WriteLine();

Console.Write("Kérem egy tanár azonosítóját: ");
string tanar = Console.ReadLine();

Console.WriteLine("A tanár foglalásai: ");
foreach (var helyszin in termek.SzemelyFoglalasai(tanar).GroupBy(x => x.HelyszinAzonosito))
{
    Console.WriteLine($"{helyszin.Key}");
	foreach (var foglalas in helyszin)
	{
        Console.WriteLine(foglalas);
	}
}

IEnumerable<Terem> TeremBeolvasas(string fajlNev)
{
	foreach (var sor in File.ReadAllLines(fajlNev).Skip(1))
	{
		yield return TeremFactory.TeremLetrehozas(sor);
	}
}

IEnumerable<Foglalas> FoglalasBeolvasas(string fajlNev)
{
	List<string> hibalista = new List<string>();

	foreach (var sor in File.ReadAllLines(fajlNev).Skip(1))
	{
		string[] adatok = sor.Split(";");
		Foglalas? foglalas = null;

		try
		{
			foglalas = new Foglalas(DateTime.Parse(adatok[0]), int.Parse(adatok[1]), adatok[2], adatok[3]);
		}
		catch (IdotartamException ex)
		{
			hibalista.Add($"{sor} - {ex.Message}");
		}

		if (foglalas is not null)
		{
			yield return foglalas;
		}
	}
	File.AppendAllLines("hibalista.txt", hibalista);
}