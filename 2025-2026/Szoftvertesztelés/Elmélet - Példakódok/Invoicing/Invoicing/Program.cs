// See https://aka.ms/new-console-template for more information

using InvoicingLib;

Invoicing invoice = new();

Console.WriteLine("Kedves Vásárló! Üdvözöljük az önkiszolgáló pénztárunkban!");
Console.WriteLine("Kérem, olvassa le az első árucikket!");
while (true)
{
    Console.Write("Következő cikk neve: (üres sor kilép) > ");
    var line = Console.ReadLine();
    if (line == "") break;
    Console.Write("Cikk ára: > ");
    var amount = int.Parse(Console.ReadLine()!);
    invoice.Add(line!, amount);
    Console.WriteLine();
}
Console.WriteLine(invoice.Print());

Console.WriteLine("Kérem, csomagolja el árucikkeit!");
