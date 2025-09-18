// 1. feladat
StreamReader fajlBeolvasas = new StreamReader("terkep.txt");
string[] elsoSor = fajlBeolvasas.ReadLine().Split(" ");
int sorok = int.Parse(elsoSor[0]);
int oszlopok = int.Parse(elsoSor[1]);
int[,] fenyszennyezesek = new int[sorok, oszlopok];

for (int i = 0; i < sorok; i++)
{
    string[] sor = fajlBeolvasas.ReadLine().Split("\t");

    for (int j = 0; j < oszlopok; j++)
    {
        fenyszennyezesek[i, j] = int.Parse(sor[j]);
    }
}

// 2. feladat
Console.WriteLine("2. feladat: ");
Console.Write("A mérés sorának azonosítója: ");
int meresSor = int.Parse(Console.ReadLine()) - 1;
Console.Write("A mérés oszlopának azonosítója: ");
int meresOszlop = int.Parse(Console.ReadLine()) - 1;
Console.WriteLine($"Az adott helyen {fenyszennyezesek[meresSor, meresOszlop]} a mért fényesség értéke.");

// 3. feladat
Console.WriteLine("3. feladat: ");
double sotetTeruletekSzazalekban = 0;

for (int i = 0; i < sorok; i++)
{
    for (int j = 0; j < oszlopok; j++)
    {
        if (fenyszennyezesek[i, j] == 0)
        {
            sotetTeruletekSzazalekban++;
        }
    }
}
sotetTeruletekSzazalekban /= sorok * oszlopok;
sotetTeruletekSzazalekban *= 100;
Console.WriteLine($"A terület {sotetTeruletekSzazalekban.ToString("0.0")} %-a teljesen sötét.");

// 4. feladat
Console.WriteLine("4. feladat: ");
int legnagyobbFenyessegErtek = fenyszennyezesek[0, 0];
List<(int, int)> legnagyobbFenyessegErtekekKoordinatak = new List<(int, int)>();

for (int i = 0; i < sorok; i++)
{
    for (int j = 0; j < oszlopok; j++)
    {
        if (fenyszennyezesek[i, j] > legnagyobbFenyessegErtek)
        {
            legnagyobbFenyessegErtek = fenyszennyezesek[i, j];
            legnagyobbFenyessegErtekekKoordinatak.Clear();
            legnagyobbFenyessegErtekekKoordinatak.Add((i, j));
        }
        else if (fenyszennyezesek[i, j] == legnagyobbFenyessegErtek)
        {
            legnagyobbFenyessegErtekekKoordinatak.Add((i, j));
        }
    }
}
Console.WriteLine($"A legnagyobb fényességérték: {legnagyobbFenyessegErtek}");
Console.WriteLine($"A legfényesebb helyek koordinátái: ");
foreach (var koordinatak in legnagyobbFenyessegErtekekKoordinatak)
{
    Console.Write($"({koordinatak.Item1}, {koordinatak.Item2}) ");
}
Console.WriteLine();

// 5. feladat
Console.WriteLine("5. feladat: ");
int[] szomszedokX = { -1, 1, 0, 0 };
int[] szomszedokY = { 0, 0, -1, 1 };
int fenyesPontok = 0;
List<(int, int)> fenyesPontokKoordinatak = new List<(int, int)>();

for (int i = 0; i < sorok; i++)
{
    for (int j = 0; j < oszlopok; j++)
    {
        int fenyErtek = fenyszennyezesek[i, j];
        bool nagyobb = true;

        for (int szomszed = 0; szomszed < 4; szomszed++)
        {
            int szomszedX = i + szomszedokX[szomszed];
            int szomszedY = j + szomszedokY[szomszed];
            if (szomszedX >= 0 && szomszedX < sorok && szomszedY >= 0 && szomszedY < oszlopok)
            {
                if (fenyErtek <= fenyszennyezesek[szomszedX, szomszedY])
                {
                    nagyobb = false;
                    break;
                }
            }
        }
        if (nagyobb)
        {
            fenyesPontok++;
            fenyesPontokKoordinatak.Add((i, j));
        }
    }
}
Console.WriteLine($"A fényes területek száma: {fenyesPontok} db.");

// 6. feladat
Console.WriteLine("6. feladat: ");
int minSor = fenyesPontokKoordinatak.Min(x => x.Item1);
int maxSor = fenyesPontokKoordinatak.Max(x => x.Item1);
int minOszlop = fenyesPontokKoordinatak.Min(x => x.Item2);
int maxOszlop = fenyesPontokKoordinatak.Max(x => x.Item2);

Console.WriteLine("A legkisebb téglalap, amely az összes fényes pontot tartalmazza:");
Console.WriteLine($"bal-felső: ({minSor + 1}, {minOszlop + 1}), jobb-alsó: ({maxSor + 1}, {maxOszlop + 1})");

// 7. feladat
Console.WriteLine("7. feladat: ");
Console.Write("A vizsgált oszlop sorszáma: ");
int oszlopDiagram = int.Parse(Console.ReadLine()) - 1;
StreamWriter fajlBeiras = new StreamWriter("diagram.txt");

for (int i = 0; i < sorok; i++)
{
    int fenyErtek = fenyszennyezesek[i, oszlopDiagram];
    int csillagok = (int)Math.Round(fenyErtek / 10.0);
    fajlBeiras.WriteLine(new string('*', csillagok));
}
fajlBeiras.Close();
Console.WriteLine("A diagram.txt fájl elkészült.");