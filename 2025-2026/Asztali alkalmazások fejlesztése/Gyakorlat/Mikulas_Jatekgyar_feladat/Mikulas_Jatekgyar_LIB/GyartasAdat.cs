namespace Mikulas_Jatekgyar_LIB
{
    public class GyartasAdat
    {
        public string Azonosito { get; init; }
        public string Tipus { get; init; }
        public int ElkeszitesiIdo { get; init; }

        public GyartasAdat(string azonosito, string tipus, int elkeszitesiIdo)
        {
            this.Azonosito = azonosito;
            this.Tipus = tipus;
            this.ElkeszitesiIdo = elkeszitesiIdo;
        }
    }
}
