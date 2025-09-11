namespace konyvtar_LIB
{
    public class Konyvtar
    {
        public string Cim { get; init; }
        public string Szerzo { get; init; }
        public int KiadasEv { get; init; }
        public bool Kolcsonozheto { get; init; }

        public Konyvtar(string cim, string szerzo, int kiadasEv, string kolcsonozheto)
        {
            this.Cim = cim;
            this.Szerzo = szerzo;
            this.KiadasEv = kiadasEv;
            this.Kolcsonozheto = kolcsonozheto == "igen" ? true : false;
        }
    }
}
