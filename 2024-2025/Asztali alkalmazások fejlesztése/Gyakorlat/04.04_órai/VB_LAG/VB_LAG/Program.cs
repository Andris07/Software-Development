using VB_LIB;

VBK vbFeladat = new (File.ReadAllLines("vb2018.txt").Skip(1));

// 2. feladat
Console.Write("2. feladat: ");
Console.WriteLine($"{vbFeladat.StadionDarabSzam} stadionban játszották a VB mérkőzéseit");

// 3. feladat
Console.Write("3. feladat: ");
Console.WriteLine($"A legkevesebb férőhelyű stadion adatai: ");
Console.WriteLine($"\tVáros: {vbFeladat.LegkevesebbFerohelyuStadion.VarosNev}");
Console.WriteLine($"\tElsődleges neve: {vbFeladat.LegkevesebbFerohelyuStadion.StadionNev1}");
Console.WriteLine($"\tMásodlagos neve: {vbFeladat.LegkevesebbFerohelyuStadion.StadionNev2}");
Console.WriteLine($"\tFérőhelyek száma: {vbFeladat.LegkevesebbFerohelyuStadion.FerohelyekSzama} fő");

// 4. feladat
Console.Write("4. feladat: ");
Console.WriteLine($"A stadionok férőhelyeinek átlaga {Math.Round(vbFeladat.FerohelyekAtlaga, 1)} fő");

// 5. feladat
Console.Write("5. feladat: ");
Console.WriteLine($"{vbFeladat.AlternativNevuStadionokSzama} stadion rendelkezik alternatív névvel");

// 6. feladat
Console.Write("6. feladat: ");
Console.WriteLine($"{vbFeladat.SzovegResztTartalmazoStadionokSzama("Aréna")} stadion nevében szerepel az \"Aréna\" szó");

// 7. feladat
Console.Write("7. feladat: ");
Console.WriteLine($"A következő városokban rendeztek VB mérkőzéseket: ");
Console.WriteLine($"\t{string.Join("; ", vbFeladat.VarosokNevei)}");

// 8. feladat
Console.Write("8. feladat: ");
vbFeladat.Fajlbairas("stadionok.txt");