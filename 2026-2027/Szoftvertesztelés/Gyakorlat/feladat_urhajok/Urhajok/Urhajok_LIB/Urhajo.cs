namespace Urhajok_LIB
{
    public class Urhajo
    {
        public string Nev { get; init; }
        public UrhajoTipus Tipus { get; init; }
        public UrhajoOsztaly Osztaly { get; init; }
        public int GyartasiEv { get; init; }
        public int Ferohely { get; init; }

        readonly List<LegenysegiTag> legenyseg = new List<LegenysegiTag>();
        public List<LegenysegiTag> Legenyseg => legenyseg;
        public int SzabadHely => Ferohely - legenyseg.Count;

        public Urhajo(string nev, UrhajoTipus tipus, UrhajoOsztaly osztaly, int gyartasiEv, int ferohely)
        {
            Nev = nev;
            Tipus = tipus;
            Osztaly = osztaly;
            GyartasiEv = gyartasiEv;
            Ferohely = ferohely;
        }

        public bool Felvesz(LegenysegiTag legenysegiTag)
        {
            if (SzabadHely <= 0) throw new InvalidOperationException($"Az űrhajón nincs szabad hely!");

            legenyseg.Add(legenysegiTag);
            return true;
        }

        public bool Levesz(LegenysegiTag legenysegiTag) => legenyseg.Remove(legenysegiTag);

        public bool Indithato => Tipus.ElvartKepzettsegek.All(x => legenyseg.Sum(y => y.KepzettsegSzint(x.Nev)) >= x.Szint);
    }
}