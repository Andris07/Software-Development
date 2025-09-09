namespace hataratkelok_LIB
{
    public class Hataratkelo
    {
        public string TelepulesNev { get; init; }
        public string TelepulesTipus { get; init; }
        public string Megye { get; init; }
        public string SzomszedTelepules { get; init; }
        public string Orszag { get; init; }
        public string AtkeloTipus { get; init; }

        public Hataratkelo(string telepulesNev, string telepulesTipus, string megye, string szomszedTelepules, string orszag, string atkeloTipus)
        {
            this.TelepulesNev = telepulesNev;
            this.TelepulesTipus = telepulesTipus;
            this.Megye = megye;
            this.SzomszedTelepules = szomszedTelepules;
            this.Orszag = orszag;
            this.AtkeloTipus = atkeloTipus;
        }
    }
}
