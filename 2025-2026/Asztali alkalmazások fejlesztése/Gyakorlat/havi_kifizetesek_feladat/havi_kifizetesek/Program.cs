using havi_kifizetesek_LIB;

// 1. feladat
string[] fileReader = File.ReadAllLines("lista.csv");
Monthly_Payments payments = new Monthly_Payments(fileReader);

// 3. feladat
Console.WriteLine("3. feladat: ");

foreach (var payment in payments.workersOrderedByTheirNamesWithTheirPayments())
{
    Console.WriteLine($"\t{payment.Key} havi fizetése: {payment.Value} Ft.");
}
Console.WriteLine();

// 5. feladat
Console.WriteLine("5. feladat: ");
Console.WriteLine($"A dolgozók kifizetéséhez a következő címletekre van szükség: ");

foreach (var paymentUnit in payments.GetTotalDenominationsForAllWorkers())
{
    Console.WriteLine($"\t{paymentUnit.Value} db {paymentUnit.Key} Ft-os");
}
Console.WriteLine();

// 6. feladat
payments.fileWrite("listaki.csv");