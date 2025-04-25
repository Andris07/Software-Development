using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szeleromuvek_Lib
{
    public class Szeleromuvek
    {
        readonly List<Szeleromu> szeleromuvek;

        public Szeleromuvek(IEnumerable<Szeleromu> szeleromuvek)
        {
            this.szeleromuvek = szeleromuvek.ToList();
        }

        public int TelepitesekSzama => szeleromuvek.Count;

        public Dictionary<string, int> RegionkentTelepitesekSzama()
        {
            return szeleromuvek.GroupBy(x => x.Regio).ToDictionary(x => x.Key, x => x.Count());
        }

        public string LegtobbSzeleromutTartalmazoRegio =>
            RegionkentTelepitesekSzama().OrderByDescending(x => x.Value).First().Key;

        public Dictionary<string, int> RegionkentSzeleromuvekSzama()
        {
            return szeleromuvek.GroupBy(x => x.Regio)
                .ToDictionary(x => x.Key, x => x.Sum(y=>y.Darab));
        }

    }
}
