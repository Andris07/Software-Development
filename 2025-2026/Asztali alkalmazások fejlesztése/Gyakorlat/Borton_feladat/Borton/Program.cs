using Borton_LIB;
using Borton_UI_LIB;

internal class Program
{
    static BortonAdatTarolo tarolo = new();
    static Azonosito azonositoGen = new();

    static void Main()
    {
        try
        {
            string fajl = Bevitel.Szoveg("Betöltendő fájl neve (ENTER = alapértelmezett)");
            if (string.IsNullOrWhiteSpace(fajl))
                fajl = "borton.json";

            tarolo = BortonAdatTarolo.Betoltes(fajl);
            Menu.Info("Adatok betöltve.");
        }
        catch
        {
            Menu.Info("Nincs mentett adat, új rendszer indul.");
        }

        while (true)
        {
            int v = Menu.ValasztoMenu("Főmenü", new[]
            {
                "Börtön létrehozása",
                "Rab műveletek",
                "Őr műveletek",
                "Tulajdonos műveletek",
                "Listázások",
                "Mentés",
                "Kilépés"
            });

            switch (v)
            {
                case 1: BortonLetrehozas(); break;
                case 2: RabMuveletek(); break;
                case 3: OrMuveletek(); break;
                case 4: TulajdonosMuveletek(); break;
                case 5: ListazasMenu(); break;
                case 6: Mentes(); break;
                case 7: return;
            }
        }
    }

    // Börtön létrehozása
    static void BortonLetrehozas()
    {
        string nev = Bevitel.Szoveg("Börtön neve");
        string tulNev = Bevitel.Szoveg("Tulajdonos neve");
        Nem nem = SzemelyUI.NemBekeres();

        string az = azonositoGen.General(nem, SzemelyTipus.Tulajdonos);
        var tul = new Tulajdonos(az, tulNev, nem, null);

        var borton = new Borton(nev, tul);
        tarolo.Bortonok.Hozzaad(borton);

        Menu.Info("Börtön létrehozva.");
        Log.Logging($"Börtön létrehozva: {nev}, tulajdonos: {tulNev}");
    }

    // Rab műveletek
    static void RabMuveletek()
    {
        var borton = BortonValasztas();
        if (borton == null) return;

        if (!borton.Rabok.Any())
        {
            Menu.Hiba("Nincs rab!");
            return;
        }

        int v = Menu.ValasztoMenu("Rab műveletek", new[]
        {
            "Rab leszúrása (másik rab)",
            "Rab áthelyezése másik cellába",
            "Vissza"
        });

        switch (v)
        {
            case 1: RabLeszuras(borton); break;
            case 2: RabAthelyezes(borton); break;
            case 3: return;
        }
    }

    static void RabLeszuras(Borton borton)
    {
        var rab = RabValasztas(borton);
        if (rab == null) return;

        try
        {
            rab.Leszur();
            Menu.Info("Leszúrás megtörtént.");
            Log.Logging($"{rab.Nev} leszúrt valakit.");
        }
        catch (Exception ex)
        {
            Menu.Hiba(ex.Message);
        }
    }

    static void RabAthelyezes(Borton borton)
    {
        var rab = RabValasztas(borton);
        if (rab == null) return;

        var cellak = borton.Cellak.Lista;
        string[] cellaNevek = cellak.Select(c => $"Cella #{c.Azonosito}").ToArray();

        int v = Menu.ValasztoMenu("Célcella kiválasztása", cellaNevek);
        var cel = cellak[v - 1];

        try
        {
            rab.Cella?.Rabok.Remove(rab);
            cel.RabHozzaad(rab);

            Menu.Info("Rab áthelyezve.");
            Log.Logging($"{rab.Nev} áthelyezve a(z) {cel.Azonosito} cellába.");
        }
        catch (Exception ex)
        {
            Menu.Hiba(ex.Message);
        }
    }

    // Őr műveletek
    static void OrMuveletek()
    {
        var borton = BortonValasztas();
        if (borton == null) return;

        if (!borton.Orok.Any())
        {
            Menu.Hiba("Nincs őr!");
            return;
        }

        int v = Menu.ValasztoMenu("Őr műveletek", new[]
        {
            "Rab megverése",
            "Őr áthelyezése másik börtönbe",
            "Vissza"
        });

        switch (v)
        {
            case 1: RabMegveres(borton); break;
            case 2: OrAthelyezes(borton); break;
            case 3: return;
        }
    }

    static void RabMegveres(Borton borton)
    {
        var cellaOr = borton.Orok.FirstOrDefault(o => o.BeosztasTipus == OrBeosztasTipus.CellaOr);
        if (cellaOr == null)
        {
            Menu.Hiba("Nincs cellaőr!");
            return;
        }

        var rab = RabValasztas(borton);
        if (rab == null) return;

        try
        {
            cellaOr.Megver(rab);
            Menu.Info("Rab megverve.");
            Log.Logging($"{cellaOr.Nev} megverte {rab.Nev}");
        }
        catch (Exception ex)
        {
            Menu.Hiba(ex.Message);
        }
    }

    static void OrAthelyezes(Borton jelenlegi)
    {
        var or = OrValasztas(jelenlegi);
        if (or == null) return;

        var cel = BortonValasztas();
        if (cel == null) return;

        try
        {
            jelenlegi.Orok.Remove(or);
            cel.Tulajdonos.OrFelvetel(or);

            Menu.Info("Őr áthelyezve.");
            Log.Logging($"{or.Nev} áthelyezve a(z) {cel.Nev} börtönbe.");
        }
        catch (Exception ex)
        {
            Menu.Hiba(ex.Message);
        }
    }

    // Tulajdonos műveletek
    static void TulajdonosMuveletek()
    {
        var borton = BortonValasztas();
        if (borton == null) return;

        int v = Menu.ValasztoMenu("Tulajdonos műveletek", new[]
        {
            "Cella építése",
            "Rab felvétele",
            "Őr felvétele",
            "Rab kivégzése",
            "Vissza"
        });

        switch (v)
        {
            case 1: CellaEpites(borton); break;
            case 2: RabFelvetel(borton); break;
            case 3: OrFelvetel(borton); break;
            case 4: TulajdonosKivegzes(borton); break;
            case 5: return;
        }
    }

    static void CellaEpites(Borton borton)
    {
        borton.Tulajdonos.CellaEpites();
        Menu.Info("Cella megépítve.");
        Log.Logging($"Cella építve a(z) {borton.Nev} börtönben.");
    }

    static void RabFelvetel(Borton borton)
    {
        string nev = Bevitel.Szoveg("Rab neve");
        Nem nem = SzemelyUI.NemBekeres();
        var bunt = SzemelyUI.BuntetesBekeres();

        string az = azonositoGen.General(nem, SzemelyTipus.Rab);
        var rab = new Rab(az, nev, nem, bunt);

        try
        {
            borton.Tulajdonos.RabFelvetel(rab);
            Menu.Info("Rab felvéve.");
            Log.Logging($"Rab felvéve: {nev}");
        }
        catch (Exception ex)
        {
            Menu.Hiba(ex.Message);
        }
    }

    static void OrFelvetel(Borton borton)
    {
        string nev = Bevitel.Szoveg("Őr neve");
        Nem nem = SzemelyUI.NemBekeres();

        int v = Menu.ValasztoMenu("Beosztás", new[] { "Kapuőr", "Cellaőr", "Toronyőr" });
        OrBeosztasTipus beoszt = (OrBeosztasTipus)(v - 1);

        string az = azonositoGen.General(nem, SzemelyTipus.Or);
        var or = new Or(az, nev, nem, beoszt, null);

        try
        {
            borton.Tulajdonos.OrFelvetel(or);
            Menu.Info("Őr felvéve.");
            Log.Logging($"Őr felvéve: {nev}, beosztás: {beoszt}");
        }
        catch (Exception ex)
        {
            Menu.Hiba(ex.Message);
        }
    }

    static void TulajdonosKivegzes(Borton borton)
    {
        var rab = RabValasztas(borton);
        if (rab == null) return;

        try
        {
            borton.Tulajdonos.Kivegez(rab);
            Menu.Info("Rab kivégezve.");
            Log.Logging($"{rab.Nev} kivégezve.");
        }
        catch (Exception ex)
        {
            Menu.Hiba(ex.Message);
        }
    }

    // Listázások
    static void ListazasMenu()
    {
        int v = Menu.ValasztoMenu("Listázások", new[]
        {
            "Börtönök",
            "Cellák",
            "Élő rabok",
            "Őrök",
            "Vissza"
        });

        switch (v)
        {
            case 1: ListazasBortonok(); break;
            case 2: ListazasCellak(); break;
            case 3: ListazasEloRabok(); break;
            case 4: ListazasOrok(); break;
            case 5: return;
        }
    }

    static void ListazasBortonok()
    {
        ConsoleListazo.Lista("Börtönök", tarolo.Bortonok.BortonokLista);
    }

    static void ListazasCellak()
    {
        var borton = BortonValasztas();
        if (borton == null) return;

        ConsoleListazo.Lista($"Cellák a(z) {borton.Nev} börtönben", borton.Cellak.Lista);
    }

    static void ListazasEloRabok()
    {
        var borton = BortonValasztas();
        if (borton == null) return;

        var elok = borton.Rabok.Where(r => r.Allapot == RabAllapot.Elo);
        ConsoleListazo.Lista("Élő rabok", elok);
    }

    static void ListazasOrok()
    {
        var borton = BortonValasztas();
        if (borton == null) return;

        ConsoleListazo.Lista("Őrök", borton.Orok);
    }

    // Mentés
    static void Mentes()
    {
        try
        {
            string fajl = Bevitel.Szoveg("Fájlnév (pl. borton1.json)");
            if (string.IsNullOrWhiteSpace(fajl))
                fajl = "borton.json";

            tarolo.Mentes(fajl);
            Menu.Info($"Mentve: {fajl}");
            Log.Logging($"Adatok mentve: {fajl}");
        }
        catch (Exception ex)
        {
            Menu.Hiba(ex.Message);
        }
    }

    // Segéd metódusok
    static Borton? BortonValasztas()
    {
        if (!tarolo.Bortonok.BortonokLista.Any())
        {
            Menu.Hiba("Nincs börtön!");
            return null;
        }

        string[] nevek = tarolo.Bortonok.BortonokLista.Select(b => b.Nev).ToArray();
        int v = Menu.ValasztoMenu("Börtön kiválasztása", nevek);

        return tarolo.Bortonok.BortonokLista[v - 1];
    }

    static Rab? RabValasztas(Borton borton)
    {
        var rabok = borton.Rabok.ToList();
        string[] nevek = rabok.Select(r => r.Nev).ToArray();

        int v = Menu.ValasztoMenu("Rab kiválasztása", nevek);
        return rabok[v - 1];
    }

    static Or? OrValasztas(Borton borton)
    {
        var orok = borton.Orok.ToList();
        string[] nevek = orok.Select(o => o.Nev).ToArray();

        int v = Menu.ValasztoMenu("Őr kiválasztása", nevek);
        return orok[v - 1];
    }
}