using kiralyok_LIB;

// 1. feladat
string[] fileReader = File.ReadAllLines("uralkodo.csv");
Kings kings = new Kings(fileReader);

// 2. feladat
Console.Write("2. feladat: ");
Console.WriteLine("A 14. században megkoronázott uralkodók: ");
IEnumerable<King> kingsWhoRuledInThe14ThCentury = kings.kingsWhoRuledInThisCentury(14);

foreach (var king in kingsWhoRuledInThe14ThCentury)
{
    Console.WriteLine($"\t{king.Name.PadRight(12)}{king.StartOfRuling.ToString().PadRight(6)}{king.EndOfRuling}");
}

// 3. feladat
Console.Write("3. feladat: ");
Console.WriteLine("Magyar királyok: ");
IEnumerable<King> kingsOrderedByBirthdate = kings.kingsOrderedByBirthdate();

foreach (var king in kingsOrderedByBirthdate)
{
    Console.Write($"\t{king.Name} ");

    if (king.HasNickName())
    {
        Console.Write($"({king.NickName}) ");
    }
    Console.WriteLine($"\t{king.BirthDate}");
}

// 4. feladat
Console.Write("4. feladat: ");
Console.WriteLine("Fiatal uralkodók: ");
IEnumerable<King> kingsWhoWereRulersBeforeTheAgeOf14 = kings.kingsSeperatedByAge(14);

foreach (var king in kingsWhoWereRulersBeforeTheAgeOf14)
{
    Console.Write($"\t{king.Name.PadRight(12)}");

    if (king.StartOfRuling - king.BirthDate == 0)
    {
        Console.WriteLine($"újszülött");
    }
    else
    {
        Console.WriteLine($"{king.StartOfRuling - king.BirthDate} éves");
    }
}

// 5. feladat
Console.Write("5. feladat: ");
Console.WriteLine("Hosszú uralkodás: ");
IEnumerable<King> kingsWhoRuledTheMost = kings.kingsWhoRuledTheMostByYears(10);

foreach (var king in kingsWhoRuledTheMost)
{
    Console.Write($"\t{king.Name} ");

    if (king.HasNickName())
    {
        Console.Write($"({king.NickName}) ");
    }
    Console.WriteLine($"\t{king.EndOfRuling - king.StartOfRuling} év");
}

// 6. feladat
Console.Write("6. feladat: ");
Console.WriteLine("Uralkodó házak: ");
Dictionary<string, int> housesAndTheirMemberCount = kings.housesOrderedByHouseMembersCount();

foreach (var house in housesAndTheirMemberCount)
{
    Console.WriteLine($"\t{house.Key}\t{house.Value} király");
}

// 7. feladat
Console.Write("7. feladat: ");
Console.WriteLine("Koronázás előtt már uralkodó: ");
List<string> kingsWhoRuledBeforeCrowning = kings.kingsWhoRuledBeforeBeingCrowded();

foreach (var king in kingsWhoRuledBeforeCrowning)
{
    Console.WriteLine($"\t{king}");
}

// 8. feladat
kings.FileWrite("melleknev.txt");