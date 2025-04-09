using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hegyek_Lib
{
    public class Hegyek
    {
        readonly List<Hegy> hegyek = new List<Hegy>();

        public Hegyek(IEnumerable<string> fajlSorok) 
        {
            foreach (var item in fajlSorok)
            {
                hegyek.Add(new Hegy(item));
            }
        }

        public int HegyekSzama => hegyek.Count;

        public Hegy LegalacsonyabbHegy 
            => hegyek.MinBy(x => x.Magassag);

        public double AtlagMagassag => hegyek.Average(x => x.Magassag);

        public int HegycsucsokSzama(string hegyseg)
        {
            return hegyek.Count(x => x.Hegyseg == hegyseg);
        }

        public int SzovegReszTalalatSzam(string szovegResz)
        {
            return hegyek.Count(x => x.Nev.Contains(szovegResz));
        }

        public IEnumerable<string> HegysegekNevei 
            => hegyek.Select(x => x.Hegyseg).Order().Distinct();

        public IEnumerable<Hegy> LegmagasabbHegyek(int darabSzam)
        {
            return hegyek.OrderByDescending(x => x.Magassag).Take(darabSzam);
        }
    }
}
