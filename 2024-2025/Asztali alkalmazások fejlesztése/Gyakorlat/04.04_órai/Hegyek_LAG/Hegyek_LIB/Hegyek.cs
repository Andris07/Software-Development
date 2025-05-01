using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hegyek_LIB
{
    public class Hegyek
    {
        private readonly List<Hegy> hegyek = [];

        public Hegyek(IEnumerable<string> fajlSorok)
        {
            foreach (var fajlSor in fajlSorok)
            {
                hegyek.Add(new Hegy(fajlSor));
            }
        }

        public int HegyekSzama => hegyek.Count;
        public Hegy LegalacsonyabbHegy => hegyek.MinBy(x => x.Magassag);
        public double AtlagMagassag => hegyek.Average(x => x.Magassag);
        public int HegycsucsokSzama(string hegyseg) => hegyek.Count(x => x.Hegyseg == hegyseg);
        public int SzovegReszTalalatSzam(string szovegResz) => hegyek.Count(x => x.Hegycsucs.Contains(szovegResz));
        public IEnumerable<string> HegysegekNevei => hegyek.Select(x => x.Hegyseg).Distinct().Order();
        public int AdottLabnalMagasabbHegyek(int magassag) => hegyek.Count(x => x.MagassagLabban > magassag);
        public IEnumerable<Hegy> LegmagasabbHegyek(int darabSzam) => hegyek.OrderByDescending(x => x.Magassag).Take(darabSzam);
    }
}