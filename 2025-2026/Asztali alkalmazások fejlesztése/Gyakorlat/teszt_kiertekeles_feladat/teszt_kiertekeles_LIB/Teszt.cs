namespace teszt_kiertekeles_LIB
{
    public class Teszt
    {
        public string? Nev { get; init; }
        public int? ElsoFeladat { get; init; }
        public int? MasodikFeladat { get; init; }
        public int? HarmadikFeladat { get; init; }
        public int? NegyedikFeladat { get; init; }
        public int? OtodikFeladat { get; init; }

        public Teszt(string? nev, int? elsoFeladat, int? masodikFeladat, int? harmadikFeladat, int? negyedikFeladat, int? otodikFeladat)
        {
            this.Nev = nev;
            this.ElsoFeladat = elsoFeladat;
            this.MasodikFeladat = masodikFeladat;
            this.HarmadikFeladat = harmadikFeladat;
            this.NegyedikFeladat = negyedikFeladat;
            this.OtodikFeladat = otodikFeladat;
        }

        // 2. feladat
        public string Kotojelezes(int? pontszam) => pontszam?.ToString() ?? "-";

        // 3. feladat
        public int osszPont => new int?[] { ElsoFeladat, MasodikFeladat, HarmadikFeladat, NegyedikFeladat, OtodikFeladat }.Where(x => x.HasValue).Sum(x => x.Value);

        // 4. feladat
        public double szazalek => osszPont / 25.0 * 100;
        public string eredmeny => szazalek >= 40 ? "sikeres" : "sikertelen";

        public int? FeladatPontszamLekeres(int index) => index switch
        {
            1 => ElsoFeladat,
            2 => MasodikFeladat,
            3 => HarmadikFeladat,
            4 => NegyedikFeladat,
            5 => OtodikFeladat,
            _ => null
        };
    }
}
