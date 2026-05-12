using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class Viragkoto : Dolgozo
    {
        public double Gyakorlottsag => 100;

        public Viragkoto(int dolgozoID, string dolgozoNev) : base(dolgozoID, dolgozoNev)
        {

        }

        public int MunkaraForditottIdo
        {
            get
            {
                return MunkaraForditottIdo;
            }
            set
            {
                int munkaraForditottIdo = 0;



                this.MunkaraForditottIdo = munkaraForditottIdo;
            }
        }
    }
}
