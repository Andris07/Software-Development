using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class Viragkoto : Dolgozo
    {
        public override double Gyakorlottsag => 100;

        public Viragkoto(int dolgozoID, string dolgozoNev) : base(dolgozoID, dolgozoNev)
        {

        }

        public override int MunkaraForditottIdo => feladatok.feladatokLista.Sum(x => x.ElkeszitesiIdo);
    }
}