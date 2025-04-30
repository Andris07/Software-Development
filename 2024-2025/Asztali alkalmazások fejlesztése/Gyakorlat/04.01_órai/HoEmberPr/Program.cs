using HoEmberPr;

// 1. feladat
HoEmber hoember = new HoEmber();
Console.WriteLine("Elkészült egy hóember");

string valasz = "";

while (valasz.ToLower() != "n")
{
    Console.WriteLine(hoember.Info());
    Console.WriteLine("Időjárás (i) / Seprűlopás (l) / Paraméteres hóember (n)");
    valasz = Console.ReadLine()!;

    if(valasz == "i")
    {
        bool naposvagyfagyos = false;
        if (Random.Shared.Next(0, 2) == 0)
        {
            naposvagyfagyos = true;
        }

        int randertek = Random.Shared.Next(1, 4);
        if (naposvagyfagyos)
        {
            hoember.VisszaFagy(randertek);
            Console.WriteLine("Fagyos idő van, a hóember vissza fagy.");
        }
        else
        {
            hoember.Olvad(randertek);
            Console.WriteLine("Napos idő van, a hóember olvadni kezd");

            if (hoember.Meret == 0)
            {
                Console.WriteLine("A hóember teljesen elolvadt!");
            }
        }
    }
    else if (valasz == "l")
    {
        if (hoember.SepruLopas(Random.Shared.Next(1,11)))
        {
            Console.WriteLine("Valaki ellopta a hóember seprűjét!");
        }
        else
        {
            Console.WriteLine("Nem sikerült ellopni a hóember seprűjét!");
        }
    }
}

// 2. feladat
bool naposvagyfagyos2 = false;

if (Random.Shared.Next(0, 2) == 0)
{
    naposvagyfagyos2 = true;
}

Console.WriteLine("Mennyi a gombócok száma (2/3)?");
int gombocszam = int.Parse(Console.ReadLine()!);
Console.WriteLine("Létezik seprű? (igen/nem)");
bool sepru = false;

if (Console.ReadLine()!.ToLower()=="igen")
{
    sepru = true;
}

HoEmber hoember2 = new HoEmber(gombocszam, sepru);

while (valasz.ToLower() != "n")
{
    Console.WriteLine(hoember2.Info());
    Console.WriteLine("Időjárás (i) / Seprűlopás (l) / Paraméteres hóember (n)");
    valasz = Console.ReadLine()!;

    if (valasz.ToLower() == "i")
    {
        bool naposvagyfagyos = false;
        if (Random.Shared.Next(0, 2) == 0)
        {
            naposvagyfagyos = true;
        }

        int randertek = Random.Shared.Next(1, 4);
        if (naposvagyfagyos)
        {
            hoember2.VisszaFagy(randertek);
            Console.WriteLine("Fagyos idő van, a hóember vissza fagy.");
        }
        else
        {
            hoember2.Olvad(randertek);
            Console.WriteLine("Napos idő van, a hóember olvadni kezd");
            if (hoember2.Meret == 0)
            {
                Console.WriteLine("A hóember teljesen elolvadt!");
            }
        }
    }
    else if (valasz.ToLower() == "l")
    {
        if (hoember2.SepruLopas(Random.Shared.Next(1, 11)))
        {
            Console.WriteLine("Valaki ellopta a hóember seprűjét!");
        }
        else
        {
            Console.WriteLine("Nem sikerült ellopni a hóenmber seprűjét!");
        }
    }
}
