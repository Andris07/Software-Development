using darts_statisztika_LIB;

// 1. feladat
string[] fajlBeolvasas = File.ReadAllLines("dobasok.txt");
Dartsok dartsok = new Dartsok(fajlBeolvasas);

// 2. feladat
Console.WriteLine("2. feladat: ");
Console.WriteLine($"Körök száma: {dartsok.korokSzama()}");

// 3. feladat
Console.WriteLine("3. feladat: ");
Console.WriteLine($"3. dobásra Bullseye: {dartsok.harmadikDobasraBullseye()}");

// 4. feladat
Console.WriteLine("4. feladat: ");
Console.Write("Adja meg a szektor értékét! Szektor= ");
string szektor = Console.ReadLine();

Console.WriteLine($"Az 1. játékos a(z) {szektor} szektoros dobásainak száma: {dartsok.szektoronkentiJatekosDobasanakSzama(1, szektor)}");
Console.WriteLine($"A 2. játékos a(z) {szektor} szektoros dobásainak száma: {dartsok.szektoronkentiJatekosDobasanakSzama(2, szektor)}");

// 5. feladat
Console.WriteLine("5. feladat: ");
Console.WriteLine($"Az 1. játékos {dartsok.koronkentiJatekosDobasanakErtekenekSzama(1, "T20")} db 180-ast dobott.");
Console.WriteLine($"A 2. játékos {dartsok.koronkentiJatekosDobasanakErtekenekSzama(2, "T20")} db 180-ast dobott.");