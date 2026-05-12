using Ajandekdoboz_LIB;

AjandekDoboz<Konzol> konzolDoboz = new AjandekDoboz<Konzol>();

Playstation ps5 = new Playstation
(
    "PlayStation 5",
    200000,
    "Feel incredible gaming possibilities that go beyond the extraordinary with PlayStation®5 and PS5® Digital Edition consoles.",
    true,
    4500,
    new string[] { "God of War", "Marvel's Spider-Man", "The Last of Us™ Part I" }
);
Xbox seriesX = new Xbox
(
    "Xbox Series X",
    280000,
    "Power your dreams",
    true,
    7500,
    true
);

konzolDoboz.Hozzaad(ps5);
konzolDoboz.Hozzaad(seriesX);
Console.WriteLine("Playstation + Xbox felsőkategóriás konzol csomag: ");
Console.WriteLine(konzolDoboz);
Console.WriteLine();

konzolDoboz.Torol(seriesX);
Console.WriteLine("Playstation 5 konzol: ");
Console.WriteLine(konzolDoboz);
Console.WriteLine();

AjandekDoboz<Jatek> jatekDoboz = new AjandekDoboz<Jatek>();

Jatek godOfWar = new Jatek
(
    "God of War",
    17500,
    "Nyílt Világú Akciójáték",
    Jatek.PlatformTipus.Playstation,
    true,
    true
);
Jatek forzaHorizon5 = new Jatek(
    "Forza Horizon 5",
    25000,
    "Valósághű Autóversenyzős játék",
    Jatek.PlatformTipus.Xbox,
    false,
    true
);

jatekDoboz.Hozzaad(godOfWar);
jatekDoboz.Hozzaad(forzaHorizon5);
Console.WriteLine("Playstation + Xbox exklúzív játék csomag:");
Console.WriteLine(jatekDoboz);
Console.WriteLine();

jatekDoboz.Torol(godOfWar);
Console.WriteLine("Xbox Series X-hez ajánlott kezdőbarát játék: ");
Console.WriteLine(jatekDoboz);
Console.WriteLine();

AjandekDoboz<Nintendo> nintendoDoboz = new AjandekDoboz<Nintendo>();

Nintendo nintendo = new Nintendo
(
    "Nintendo Switch 2",
    90000,
    "Hordozható Nintendo konzol",
    false,
    false,
    new string[] { "Mario Kart World", "The Legend of Zelda Breath of the Wild", "Pokémon Legends Z-A" }
);

nintendoDoboz.Hozzaad(nintendo);
Console.WriteLine("Nintendo konzol: ");
Console.WriteLine(nintendoDoboz);

Console.WriteLine("\nProgram vége. Nyomj meg egy gombot a kilépéshez...");
Console.ReadKey();