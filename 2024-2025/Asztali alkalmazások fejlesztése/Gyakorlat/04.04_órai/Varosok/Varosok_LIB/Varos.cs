namespace Varosok_LIB
{
    public class Varos
    {
        public const int MILLIO = 1000000;
        public const int EZER = 1000;

        public Varos(string adatSor)
        {
            string[] adatReszek = adatSor.Split(";");
            VarosNev = adatReszek[0];
            OrszagNev = adatReszek[1];
            LakossagSzama = double.Parse(adatReszek[2]);
        }

        //Város; Ország; Népesség
        public string VarosNev { get; init; }
        public string OrszagNev { get; init; }
        public double LakossagSzama { get; init; }

        public override string ToString()
        {
            return $"{VarosNev} ({OrszagNev}): {LakossagSzama * EZER} ezer fő";
        }
    }
}