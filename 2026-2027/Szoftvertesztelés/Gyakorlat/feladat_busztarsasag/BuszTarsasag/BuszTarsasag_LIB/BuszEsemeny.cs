namespace BuszTarsasag_LIB
{
    // egy megállóban történt csere (ki szállt fel és le), a busz ebből tudja, mennyit szállított addig
    public class BuszEsemeny
    {
        public string MegalloNev { get; init; }
        public int Felszallt { get; init; }
        public int Leszallt { get; init; }

        public BuszEsemeny(string megalloNev, int felszallt, int leszallt)
        {
            MegalloNev = megalloNev;
            Felszallt = felszallt;
            Leszallt = leszallt;
        }
    }
}
