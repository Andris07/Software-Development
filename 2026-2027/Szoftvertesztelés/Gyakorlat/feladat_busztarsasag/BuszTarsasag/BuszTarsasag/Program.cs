using BuszTarsasag_LIB;

// megállók: név + várakozók száma
Megallok megallok = new Megallok(new Dictionary<string, int>
{
    { "Örs Vezér Tere", 70 },
    { "Deák Ferenc Tér", 80 },
    { "Kálvin Tér", 60 },
    { "Astoria", 40 },
    { "Blaha Lujza Tér", 35 }
});

// buszok: méret;férőhely;rendszám (mintha .csv v .txt fájlból jönne)
Buszok flotta = new Buszok(new List<string>
{
    "mini;20;ABC-123",
    "normal;40;DEF-456",
    "csuklos;60;GHI-789"
});

// minden busz ugyanazt az útvonalat járja, megállónként ennyien szállnak le rajta
Dictionary<string, int[]> leszallokBuszonkent = new Dictionary<string, int[]>
{
    { "ABC-123", new[] { 0, 5, 3, 4, 6 } },
    { "DEF-456", new[] { 0, 8, 10, 5, 12 } },
    { "GHI-789", new[] { 0, 10, 7, 9, 15 } }
};

foreach (Busz busz in flotta.Buszflotta)
{
    Console.WriteLine(busz);
    for (int i = 0; i < megallok.MegalloHelyek.Count; i++)
    {
        Megall(busz, megallok.MegalloHelyek[i], leszallokBuszonkent[busz.Rendszam][i]);
    }
    Console.WriteLine();
}

Console.WriteLine("Összesen szállított utasok: " + flotta.OsszesSzallitottUtas());
Console.WriteLine();

Console.WriteLine("Megállók forgalma:");
foreach (Megallo megallo in megallok.MegalloHelyek)
{
    Console.WriteLine($"\t{megallo.Nev}: felszállt={megallo.FelszalltOsszesen}, leszállt={megallo.LeszalltOsszesen}, még vár={megallo.MegallobanVarakozoEmberek}");
}
Console.WriteLine();

// lekérdezés megállóra, üres sorra kilép
while (true)
{
    Console.Write("Melyik megállónál kérdezed le a szállított utasokat? (üres = kilépés): ");
    string? nev = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(nev))
        break;

    nev = nev.Trim();
    if (megallok.MegalloNevAlapjan(nev) == null)
    {
        Console.WriteLine("Nincs ilyen megálló.");
        continue;
    }

    Dictionary<string, int> eredmeny = flotta.SzallitottUtasokMegalloig(nev);
    foreach (Busz busz in flotta.Buszflotta)
    {
        if (eredmeny.ContainsKey(busz.Rendszam))
            Console.WriteLine($"\t{busz.Rendszam}: {eredmeny[busz.Rendszam]} utast szállított eddig");
        else
            Console.WriteLine($"\t{busz.Rendszam}: nem járt ezen a megállón");
    }
}

// egy busz egy megállóban: először leszállnak, aztán felszállnak, akinek jut hely
static void Megall(Busz busz, Megallo megallo, int leszallokSzama)
{
    int varakozok = megallo.MegallobanVarakozoEmberek;
    int leszallok = Math.Min(leszallokSzama, busz.FoglaltFerohely);
    busz.MegalloUtasCsere(megallo, 0, leszallok);

    int felszallok = Math.Min(varakozok, busz.SzabadFerohely);
    busz.MegalloUtasCsere(megallo, felszallok, 0);

    int lentMaradt = varakozok - felszallok;

    Console.Write($"  {megallo.Nev}: le {leszallok}, fel {felszallok}, a buszon {busz.FoglaltFerohely}/{busz.Ferohely}");

    if (lentMaradt > 0)
        Console.Write($" (lent maradt {lentMaradt})");
    Console.WriteLine();
}
