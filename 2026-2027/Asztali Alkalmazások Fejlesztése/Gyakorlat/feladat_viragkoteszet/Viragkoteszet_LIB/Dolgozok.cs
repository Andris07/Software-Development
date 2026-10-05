using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class Dolgozok
    {
        readonly List<Dolgozo> dolgozok = new List<Dolgozo>();

        public Dolgozok(IEnumerable<string> fájlSorok)
        {
            foreach (var fájlSor in fájlSorok)
            {
                dolgozok.Add(new MunkaeroFelvetel(fájlSor).Munkaero);
            }
        }

        public Dolgozo? this[int dolgozoID] => dolgozok.FirstOrDefault(x => x.DolgozoID == dolgozoID);
        public int DolgozokSzama => dolgozok.Count;
        public IEnumerable<Dolgozo> DolgozokListaja => dolgozok;
    }
}
