namespace ForditoIrodaLIB
{
    public class Fordito
    {
        public int ForditoID { get; init; }
        public string Nev { get; init; }
        public int NyelvID { get; init; }
        public int ForditasDij { get; init; }
        public int NapiOldalszam { get; init; }
        public string Telefon { get; init; }
        public string Email { get; init; }

        public Fordito(string fajlSor)
        {
            string[] adatok = fajlSor.Split(";");
            this.ForditoID = int.Parse(adatok[0]);
            this.Nev = adatok[1];
            this.NyelvID = int.Parse(adatok[2]);
            this.ForditasDij = int.Parse(adatok[3]);
            this.NapiOldalszam = int.Parse(adatok[4]);
            this.Telefon = adatok[5];
            this.Email = adatok[6];
        }
    }
}
