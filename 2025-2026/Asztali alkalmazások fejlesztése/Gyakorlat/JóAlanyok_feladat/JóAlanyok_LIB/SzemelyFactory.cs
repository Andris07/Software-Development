using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JóAlanyok_LIB
{
    public class SzemelyFactory
    {
        public Szemely Factory(string fajlSor)
        {
            string[] sor = fajlSor.Split(";");
            string nev = sor[1];
            DateOnly szuletesiDatum = DateOnly.Parse(sor[2]);

            switch (sor[0])
            {
                case "t":
                {
                    return new Tanar(nev, szuletesiDatum, Double.Parse(sor[3]));
                }
                case "d":
                {
                    return new Diak(nev, szuletesiDatum, int.Parse(sor[3]));
                }
                default:
                {
                    throw new Exception();
                }
            }
        }
    }
}
