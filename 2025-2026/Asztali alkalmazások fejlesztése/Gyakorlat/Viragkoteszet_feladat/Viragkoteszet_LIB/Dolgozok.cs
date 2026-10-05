using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class Dolgozok
    {
        readonly List<MunkaeroFelvetel> munkaerok = new List<MunkaeroFelvetel>();

        public Dolgozok(IEnumerable<string> fájlSorok)
        {
            foreach (var fájlSor in fájlSorok)
            {
                munkaerok.Add(new MunkaeroFelvetel(fájlSor));
            }
        }

        public MunkaeroFelvetel this[int ID] => munkaerok.Where(x => x.)
    }
}
