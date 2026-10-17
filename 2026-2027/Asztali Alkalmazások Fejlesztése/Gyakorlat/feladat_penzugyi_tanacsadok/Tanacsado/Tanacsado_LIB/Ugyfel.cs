namespace Tanacsado_LIB
{
    public class Ugyfel
    {
        // ugyfel_id;nev;telefon;email
        public int ID { get; init; }
        public string Nev { get; init; }
        public string Telefon { get; init; }
        public string Email { get; init; }

        public Ugyfel(string sor)
        {
            string[] adatok = sor.Split(";");

            ID = int.Parse(adatok[0]);
            Nev = adatok[1];
            Telefon = adatok[2];
            Email = adatok[3];
        }
    }
}
