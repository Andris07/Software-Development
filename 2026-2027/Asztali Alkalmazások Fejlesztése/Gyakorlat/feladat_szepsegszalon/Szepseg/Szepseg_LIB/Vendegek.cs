namespace Szepseg_LIB
{
    public class Vendegek
    {
        // vendegId;nev;cim;telefon
        public int ID { get; init; }
        public string Nev { get; init; }
        public string Cim { get; init; }
        public string Telefon { get; init; }

        public Vendegek(string sor)
        {
            string[] adatok = sor.Split(";");

            ID = int.Parse(adatok[0]);
            Nev = adatok[1];
            Cim = adatok[2];
            Telefon = adatok[3];
        }
    }
}
