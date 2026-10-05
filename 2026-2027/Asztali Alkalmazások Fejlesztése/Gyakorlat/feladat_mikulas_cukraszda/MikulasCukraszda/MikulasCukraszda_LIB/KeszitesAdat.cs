namespace MikulasCukraszda_LIB
{
    public class KeszitesAdat
    {
        // Azonosito;Tipus;ElkeszitesiIdo
        public string Azonosito { get; init; }
        public string Tipus { get; init; }
        public int ElkeszitesiIdo { get; init; }

        public KeszitesAdat(string azonosito, string tipus, int elkeszitesiIdo)
        {
            this.Azonosito = azonosito;
            this.Tipus = tipus;
            this.ElkeszitesiIdo = elkeszitesiIdo;
        }
    }
}
