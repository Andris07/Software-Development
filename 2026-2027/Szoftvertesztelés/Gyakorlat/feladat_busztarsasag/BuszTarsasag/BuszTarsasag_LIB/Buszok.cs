using System;
using System.Collections.Generic;
using System.Text;

namespace BuszTarsasag_LIB
{
    public class Buszok
    {
        readonly List<Busz> buszok = new List<Busz>();
        public List<Busz> Buszflotta => buszok;

        public Buszok(IEnumerable<string> fajlSorok)
        {
            foreach (var fajlSor in fajlSorok)
            {
                string[] adatok = fajlSor.Split(";");
                string meret = adatok[0];
                int ferohely = int.Parse(adatok[1]);
                string rendszam = adatok[2];

                if (Buszflotta.Select(x => x.Rendszam).Contains(rendszam)) throw new AzonosRendszamException();
                else
                {
                    buszok.Add(new Busz(meret, ferohely, rendszam));
                }
            }
            if (buszok.Count == 0) throw new UresBuszflottaException();
        }

        public Busz? BuszRendszamAlapjan(string rendszam) => buszok.FirstOrDefault(x => x.Rendszam == rendszam);

        public int OsszesSzallitottUtas() => buszok.Sum(x => x.Szallitott);

        // megállóig szállított utasok, csak azok a buszok szerepelnek, amik voltak a megállónál
        public Dictionary<string, int> SzallitottUtasokMegalloig(string megalloNev)
        {
            Dictionary<string, int> eredmeny = new Dictionary<string, int>();

            foreach (var busz in buszok)
            {
                int? fo = busz.SzallitottUtasokMegalloig(megalloNev);
                if (fo != null)
                    eredmeny.Add(busz.Rendszam, fo.Value);
            }
            return eredmeny;
        }
    }
}
