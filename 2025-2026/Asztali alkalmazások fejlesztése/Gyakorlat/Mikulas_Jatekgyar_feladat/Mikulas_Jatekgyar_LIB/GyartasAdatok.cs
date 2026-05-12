using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_Jatekgyar_LIB
{
    public class GyartasAdatok
    {
        readonly Dictionary<string, GyartasAdat> tipusok;

        public GyartasAdatok(IEnumerable<GyartasAdat> tipus)
        {
            this.tipusok = tipus.ToDictionary(x => x.Azonosito);
        }

        public GyartasAdat? this[string azonosito] => tipusok[azonosito];

        public IEnumerable<string> ElerhetoGyartasAzonositok => tipusok.Keys.Order();
    }
}
