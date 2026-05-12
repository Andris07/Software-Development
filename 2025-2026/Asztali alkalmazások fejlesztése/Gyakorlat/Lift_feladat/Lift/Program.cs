using Lift_LIB;

// 5. feladat
Liftek liftek = fajlBeolvasas("input.txt");

Liftek fajlBeolvasas(string fajlNev)
{
    List<Lift> liftek = new List<Lift>();
    string[] fajlSorok = File.ReadAllLines(fajlNev);
    int liftekSzama = int.Parse(fajlSorok[0]);

    for (int i = 1; i <= liftekSzama; i++)
    {
        int lift = indexKezeles(fajlSorok[i]);
        liftek.Add(new Lift(lift));
    }

    for (int i = liftekSzama + 1; i < fajlSorok.Count(); i++)
    {
        string[] fajlSor = fajlSorok[i].Split(";");
        int liftSzama = int.Parse(fajlSor[0]) - 1;

        if (liftSzama < 0 || liftSzama >= liftek.Count())
        {
            throw new Exception("Hibás sor!");
        }
        if (fajlSor[1].ToLower() == "fel")
        {
            try
            {
                liftek[liftSzama].felfele();
            }
            catch (HibasIranyException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else if (fajlSor[1].ToLower() == "le")
        {
            try
            {
                liftek[liftSzama].lefele();
            }
            catch (HibasIranyException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            throw new HibasIranyException();
        }
        Console.WriteLine($"{liftSzama + 1}. lift:\n{liftek[liftSzama].ToString()}\n");
    }
    return new Liftek(liftek);
}

int indexKezeles(string szovegSzam)
{
    try
    {
        int szamSzam = int.Parse(szovegSzam);

        if (szamSzam < 2)
        {
            return 10;
        }
        return szamSzam;
    }
    catch
    {
        return 10;
    }
}