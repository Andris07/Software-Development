namespace NyelviskolaLIB
{
    public class Nyelv
    {
        // nyelv_id;nyelvnev
        public int NyelvID { get; init; }
        public string NyelvNev { get; init; }

        public Nyelv(string adatSor)
        {
            string[] adatReszek = adatSor.Split(";");
            this.NyelvID = int.Parse(adatReszek[0]);
            this.NyelvNev = adatReszek[1];
        }

        public override string ToString()
        {
            return NyelvNev;
        }
    }
}
