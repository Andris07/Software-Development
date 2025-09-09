using hataratkelok_LIB;

// 1. feladat
Console.WriteLine("1. feladat: ");

string[] fajlBeolvasas = File.ReadAllLines("hataratkelok.csv");
Hataratkelok hataratkelok = new Hataratkelok(fajlBeolvasas);

Console.WriteLine($"A fájl adatainak száma: {hataratkelok.hatarAtkelok_db()}\n");

// 2. feladat
Console.WriteLine("2. feladat: ");
Console.WriteLine($"A vasúti átkelők száma: {hataratkelok.vasutAtkelok_db()}\n");

// 3. feladat
Console.WriteLine("3. feladat: ");

foreach (var hataratkelo in hataratkelok.megyeJoguVarosAtkelok())
{
    Console.WriteLine($"{hataratkelo.TelepulesNev} - {hataratkelo.SzomszedTelepules}: {hataratkelo.AtkeloTipus}");
}
Console.WriteLine();

// 4. feladat
Console.WriteLine("4. feladat: ");
Console.WriteLine($"Az Ausztriába vezető városi határátkelőhelyek száma: {hataratkelok.varosVagyMegyeJoguAusztriabaVezetoAtkelok_db()}\n");

// 5. feladat
Console.WriteLine("5. feladat: ");
Console.WriteLine($"Ábécérendben az első olyan település, amelyikből határátkelő vezet Ausztriába: {hataratkelok.elsoAusztriabaVezetoAtkelo()}\n");

// 6. feladat
Console.WriteLine("6. feladat: ");
Console.WriteLine($"Magyarországgal szomszédos országok: {String.Join(", ", hataratkelok.magyarorszagraVezetoAtkelokOrszagai())}\n");

// 7. feladat
Console.WriteLine("7. feladat: ");
Console.WriteLine($"Közúti és vasúti határátkelővel is rendelkező városok: {String.Join(", ", hataratkelok.kozutiEsVasutiAtkelokVarosai())}\n");

// 8. feladat
Console.WriteLine("8. feladat: ");

foreach (var orszag in hataratkelok.orszagokAtkeloi_db())
{
    Console.WriteLine($"{orszag.Key}: {orszag.Value} határátkelő.");
}
Console.WriteLine();

// 9. feladat
Console.WriteLine("9. feladat: ");

Console.WriteLine("Vas: ");
foreach (var hataratkelo in hataratkelok.megyenkentiAtkelok("Vas"))
{
    Console.WriteLine($"{hataratkelo.TelepulesNev} - {hataratkelo.SzomszedTelepules} ({hataratkelo.Orszag}) - {hataratkelo.AtkeloTipus}");
}
Console.WriteLine();

Console.WriteLine("Zala: ");
foreach (var hataratkelo in hataratkelok.megyenkentiAtkelok("Zala"))
{
    Console.WriteLine($"{hataratkelo.TelepulesNev} - {hataratkelo.SzomszedTelepules} ({hataratkelo.Orszag}) - {hataratkelo.AtkeloTipus}");
}
Console.WriteLine();