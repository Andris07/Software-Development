using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar_LIB
{
    public class Konyvtarak
    {
        List<Konyvtar> konyvtarak = new List<Konyvtar>();

        public Konyvtarak(IEnumerable<string> fajlSorok)
        {
            foreach (string fajlSor in fajlSorok.Skip(1))
            {
                string[] sor = fajlSor.Split(';');
                string cim = sor[0];
                string szerzo = sor[1];
                int kiadasEv = int.Parse(sor[2]);
                string kolcsonozheto = sor[3];

                konyvtarak.Add(new Konyvtar(cim, szerzo, kiadasEv, kolcsonozheto));
            }
        }

        public int KonyvekSzama() => konyvtarak.Count();
        public int KolcsonozhetoKonyvekSzama() => konyvtarak.Count(x => x.Kolcsonozheto);
        public int HarryPotterKonyvekSzama() => konyvtarak.Count(x => x.Cim.Contains("Harry Potter"));
        public IEnumerable<IGrouping<int, Konyvtar>> LegtobbKonyvkiadasEgyEvben() => konyvtarak.GroupBy(x => x.KiadasEv).OrderByDescending(x => x.Count()).Take(1);
        public IEnumerable<IGrouping<int, Konyvtar>> EvenkentiKiadasokSzama() => konyvtarak.GroupBy(x => x.KiadasEv);
        public IEnumerable<IGrouping<string, Konyvtar>> SzerzonkentiKiadasokSzama() => konyvtarak.GroupBy(x => x.Szerzo).OrderBy(x => x.Key);
        public bool LetezoKonyv(string cim) => konyvtarak.Any(x => x.Cim == cim);
        public bool KolcsonozhetoKonyv(string cim) => konyvtarak.Any(x => x.Cim == cim && x.Kolcsonozheto);
        public List<string> KolcsonozhetoKonyvek() => konyvtarak.Where(x => x.Kolcsonozheto).Select(x => x.Cim).Distinct().Order().ToList();
    }
}
