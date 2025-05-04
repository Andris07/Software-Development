using System.Diagnostics.Contracts;

namespace VB_LIB
{
    public class VB
    {
        public VB(string adatSor)
        {
            string[] adatReszek = adatSor.Split(";");
            VarosNev = adatReszek[0];
            StadionNev1 = adatReszek[1];
            StadionNev2 = adatReszek[2];
            FerohelyekSzama = int.Parse(adatReszek[3]);
        }

        //varos; nev1; nev2; ferohely

        public string VarosNev { get; init; }
        public string StadionNev1 { get; init; }
        public string StadionNev2 { get; init; }
        public int FerohelyekSzama { get; init; }
    }
}
