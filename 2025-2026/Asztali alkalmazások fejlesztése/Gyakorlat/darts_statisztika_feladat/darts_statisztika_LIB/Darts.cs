namespace darts_statisztika_LIB
{
    public class Darts
    {
        public int JatekosSzam { get; init; }
        public string ElsoDobas { get; init; }
        public string MasodikDobas { get; init; }
        public string HarmadikDobas { get; init; }

        public Darts(int jatekosSzam, string elsoDobas, string masodikDobas, string harmadikDobas)
        {
            this.JatekosSzam = jatekosSzam;
            this.ElsoDobas = elsoDobas;
            this.MasodikDobas = masodikDobas;
            this.HarmadikDobas = harmadikDobas;
        }
    }
}
