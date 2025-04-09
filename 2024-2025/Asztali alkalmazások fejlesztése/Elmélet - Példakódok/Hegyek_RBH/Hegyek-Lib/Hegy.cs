namespace Hegyek_Lib
{
    public class Hegy
    {
        public Hegy(string nev, string hegyseg, int magassag)
        {
            Nev = nev;
            Hegyseg = hegyseg;
            Magassag = magassag;
        }

        public Hegy(string adatSor)
        {
            string[] adatReszek = adatSor.Split(';');
            Nev = adatReszek[0];
            Hegyseg = adatReszek[1];
            Magassag = int.Parse(adatReszek[2]);
        }

        //Hegycsúcs neve;Hegység;Magasság
        public string Nev { get; init; }
        public string Hegyseg { get; init; }
        public int Magassag { get; init; }

        public override string ToString()
        {
            return $"{Magassag} - {Hegyseg}: {Nev}";
        }

        public double MagassagLabban => Magassag * 3.28;
    }
}
