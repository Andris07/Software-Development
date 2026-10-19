namespace StarTrek_LIB
{
    public class Fajok
    {
        // faj_id;faj_nev
        public int ID { get; init; }
        public string Nev { get; init; }

        public Fajok(string sor)
        {
            string[] adatok = sor.Split(";");

            ID = int.Parse(adatok[0]);
            Nev = adatok[1];
        }
    }
}
