using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_Jatekgyar_LIB
{
    public class Jatekok
    {
        readonly List<Jatek> jatekok;

        public Jatekok(IEnumerable<Jatek> jatekok)
        {
            this.jatekok = jatekok.ToList();
        }

        public Jatek? this[string azonosito] => jatekok.Find(x => x.Azonosito == azonosito);

        public IEnumerable<Jatek> JatekTipusok => jatekok.Where(x => !x.Tipus.StartsWith("k")).OrderBy(x => x.Megnevezes);
    }
}
