using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class Termekek
    {
        readonly List<Termek> termekek = new List<Termek>();

        public Termekek(IEnumerable<Termek> termekek)
        {
            this.termekek = termekek.ToList();
        }

        public Termek? this[int lekerendoID] => termekek.Find(x => x.ID == lekerendoID);

        public override string ToString()
        {
            return String.Join("\n", termekek);
        }
    }
}
