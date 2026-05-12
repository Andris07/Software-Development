namespace Celeb_LIB
{
    public class Ember
    {
        // név;foglalkozás;nemzetiség;világhírű;nem
        public string Nev { get; init; }
        public string Foglalkozas { get; init; }
        public string Nemzetiseg { get; init; }
        public string Vilaghiru { get; init; }
        public string Nem { get; init; }

        public Ember(string fajlSor)
        {
            string[] adatok = fajlSor.Split(";");
            this.Nev = adatok[0];
            this.Foglalkozas = adatok[1];
            this.Nemzetiseg = adatok[2];
            this.Vilaghiru = adatok[3];
            this.Nem = adatok[4];
        }
    }
}
