namespace Hegyek_LIB
{
    public class Hegy
    {
        const double LAB = 3.280839895;
        //public Hegy(string hegycsucs, string hegyseg, int magassag)
        //{
        //    Hegycsucs = hegycsucs;
        //    Hegyseg = hegyseg;
        //    Magassag = magassag;
        //}

        public Hegy(string adatSor)
        {
            string[] adatReszek = adatSor.Split(";");
            Hegycsucs = adatReszek[0];
            Hegyseg = adatReszek[1];
            Magassag = int.Parse(adatReszek[2]);
        }

        //Hegycsúcs neve; Hegység; Magasság

        public string Hegycsucs { get; init; }
        public string Hegyseg { get; init; }
        public int Magassag { get; init; }
        public double MagassagLabban => Magassag * LAB;
        public override string ToString()
        {
            return $"{Hegycsucs} - {Hegyseg}: {Magassag}m";
        }
    }
}