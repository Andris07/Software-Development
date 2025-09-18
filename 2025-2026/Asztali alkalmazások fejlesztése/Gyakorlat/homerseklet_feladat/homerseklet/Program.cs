// 1. feladat
Console.WriteLine("1. feladat: ");
StreamReader fajlBeolvasas = new StreamReader("homerseklet.txt");
string[] elsoSor = fajlBeolvasas.ReadLine().Split(" ");
int sorok = int.Parse(elsoSor[0]);
int oszlopok = int.Parse(elsoSor[1]);
int[,] homersekletek = new int[sorok, oszlopok];

for (int i = 0; i < sorok; i++)
{
    string[] sor = fajlBeolvasas.ReadLine().Split(" ");

    for (int j = 0; j < oszlopok; j++)
    {
        homersekletek[i, j] = int.Parse(sor[j]);
    }
}

Console.Write("".PadLeft(15));
for (int i = 0; i < oszlopok; i++)
{
    Console.Write($"{i + 1}. mérés".PadRight(15));
}
Console.WriteLine();

for (int i = 0; i < sorok; i++)
{
    Console.Write($"{i + 1}. nap".PadRight(15));

    for (int j = 0; j < oszlopok; j++)
    {
        Console.Write($"{homersekletek[i, j]}".PadRight(15));
    }
    Console.WriteLine();
}
Console.WriteLine();

// 2. feladat
Console.Write("2. feladat: ");
double atlagHomerseklet = 0;

for (int i = 0; i < sorok; i++)
{
    for (int j = 0; j < oszlopok; j++)
    {
        atlagHomerseklet += homersekletek[i, j];
    }    
}
atlagHomerseklet /= sorok * oszlopok;
Console.WriteLine($"Az átlaghőmérséklet: {atlagHomerseklet.ToString("0.00")} fok\n");

// 3. feladat
Console.Write("3. feladat: ");
Console.WriteLine($"Az átlaghőmérsékletek naponként: ");

for (int i = 0; i < sorok; i++)
{
    double napiAtlagHomerseklet = 0;

    for (int j = 0; j < oszlopok; j++)
    {
        napiAtlagHomerseklet += homersekletek[i, j];
    }
    napiAtlagHomerseklet /= oszlopok;

    Console.WriteLine($"\t{i + 1}. nap: {napiAtlagHomerseklet.ToString("0.00")} fok");
}
Console.WriteLine();

// 4. 5. feladat
int fokAlattAlkalmak = 0;
int fokAlattNapok = 0;

for (int i = 0; i < sorok; i++)
{
    bool fokAlattNap = false;

    for (int j = 0; j < oszlopok; j++)
    {

        if (homersekletek[i, j] < 10)
        {
            fokAlattAlkalmak++;
            fokAlattNap = true;
        }
            
    }
    if (fokAlattNap)
    {
        fokAlattNapok++;
    }
}
Console.Write("4. feladat: ");
Console.WriteLine($"{fokAlattAlkalmak} alkalommal volt 10 fok alatt a hőmérséklet");
Console.WriteLine();
Console.Write("5. feladat: ");
Console.WriteLine($"{fokAlattNapok} nap volt 10 fok alatt a hőmérséklet");
Console.WriteLine();

// 6. feladat
Console.Write("6. feladat: ");
int nap = 0;
int meres = 0;
double legnagyobbHomerseklet = homersekletek[nap, meres];

for (int i = 0; i < sorok; i++)
{
    for (int j = 0; j < oszlopok; j++)
    {
        if (homersekletek[i, j] > legnagyobbHomerseklet)
        {
            legnagyobbHomerseklet = homersekletek[i, j];
            nap = i;
            meres = j;
        }
    }
}
Console.WriteLine($"{nap + 1}. nap {meres + 1}. mérésekor volt a legmagasabb a hőmérséklet: {homersekletek[nap, meres]} fok");
Console.WriteLine();

// 7. feladat
Console.Write("7. feladat: ");
Console.Write("A keresett hőmérséklet: ");
int keresettHomerseklet = int.Parse(Console.ReadLine());
bool voltKeresettHomerseklet = false;

for (int i = 0; i < sorok; i++)
{
    for (int j = 0; j < oszlopok; j++)
    {
        if (homersekletek[i, j] == keresettHomerseklet)
        {
            Console.WriteLine($"\tVolt ilyen mérés: {i + 1}. nap {j + 1}. mérése");
            voltKeresettHomerseklet = true; break;
        }
    }
    if (voltKeresettHomerseklet)
    {
        break;
    }
}
if (!voltKeresettHomerseklet)
{
    Console.WriteLine("\tNem volt ilyen mérés");
}