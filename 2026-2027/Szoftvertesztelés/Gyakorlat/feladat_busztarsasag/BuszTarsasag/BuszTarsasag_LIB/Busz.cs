namespace BuszTarsasag_LIB
{
    public class Busz
    {
        public string Meret { get; init; }
        public int Ferohely { get; init; }
        public string Rendszam { get; init; }

        public int FoglaltFerohely { get; private set; }
        public int SzabadFerohely => Ferohely - FoglaltFerohely;

        public Busz(string meret, int ferohely, string rendszam)
        {
            Meret = meret;
            Ferohely = ferohely;
            Rendszam = rendszam;
            FoglaltFerohely = 0;
            // kezdetben a buszon nincs utas, a végállomásokat is egyszerű megállókként fogom kezelni, tehát az első megálló maga a kiindulási pont
        }

        public bool MegalloUtasCsere(Megallo megallo, int buszraFelszalloEmberek, int buszrolLeszalloEmberek)
        {
            if (megallo.MegallobanVarakozoEmberekSzamaErvenytelen(megallo.MegallobanVarakozoEmberek))
                return false;

            if (felEsLeszallokSzamaErvenytelen(buszraFelszalloEmberek, buszrolLeszalloEmberek))
            {
                return false;
            }

            if (felSzallasUtaniFerohelyErvenytelen(buszraFelszalloEmberek))
                return false;

            megallo.UtasCsere(buszraFelszalloEmberek, buszrolLeszalloEmberek);

            FoglaltFerohely += buszraFelszalloEmberek - buszrolLeszalloEmberek;

            if (MegteltBusz() && megallo.MegallobanVarakozoEmberek > 0)
                return false;

            return true;
        }

        public bool MegteltBusz() => SzabadFerohely == 0;
        public bool FelszalloEmberekSzamaErvenytelen(int buszraFelszalloEmberek) => buszraFelszalloEmberek < 0 || buszraFelszalloEmberek > SzabadFerohely;
        public bool LeszalloEmberekSzamaErvenytelen(int buszrolLeszalloEmberek) => buszrolLeszalloEmberek < 0 || buszrolLeszalloEmberek > FoglaltFerohely;
        public bool felEsLeszallokSzamaErvenytelen(int buszraFelszalloEmberek, int buszrolLeszalloEmberek) => LeszalloEmberekSzamaErvenytelen(buszrolLeszalloEmberek) || FelszalloEmberekSzamaErvenytelen(buszraFelszalloEmberek);
        public bool felSzallasUtaniFerohelyErvenytelen(int buszraFelszalloEmberek) => FoglaltFerohely + buszraFelszalloEmberek > Ferohely;
        public bool BuszFoglaltFerohelyErvenytelen() => FoglaltFerohely < 0 || FoglaltFerohely > Ferohely;
        public void BuszFoglaltFerohelySet(int foglaltFerohely) => FoglaltFerohely = foglaltFerohely; // teszteléshez kell csak
        public void SzabadFerohelyreFelszalloUtasok(Megallo megallo, int buszraFelszalloEmberek) => megallo.UtasCsere(buszraFelszalloEmberek - SzabadFerohely, 0);
        public int LentMaradtUtasokSzama(int buszraFelszalloEmberek) => buszraFelszalloEmberek - SzabadFerohely;

        public override string ToString()
        {
            return $"Busz: Méret={Meret}, Férőhely={Ferohely}, Rendszám={Rendszam}";
        }
    }
}
