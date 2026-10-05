using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class Katalogus
    {
        readonly Dictionary<string, Alapanyag> alapanyagok = new Dictionary<string, Alapanyag>();

        public Katalogus(IEnumerable<Alapanyag> alapanyagok)
        {
            this.alapanyagok = alapanyagok.ToDictionary(x => x.Azonosito);
        }

        public Alapanyag this[string lekerendoAzonosito] => alapanyagok[lekerendoAzonosito];
    }
}
