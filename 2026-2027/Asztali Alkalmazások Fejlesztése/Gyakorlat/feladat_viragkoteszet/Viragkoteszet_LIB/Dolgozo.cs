using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public abstract class Dolgozo
    {
        public int DolgozoID { get; init; }
        public string DolgozoNev { get; init; }
        public abstract double Gyakorlottsag { get; }
        public abstract int MunkaraForditottIdo { get; }
        public FeladatLista feladatok = new FeladatLista();

        public Dolgozo(int dolgozoID, string dolgozoNev)
        {
            this.DolgozoID = dolgozoID;
            this.DolgozoNev = dolgozoNev;
        }

        public virtual void UjFeladatHozzaadasa(Termek feladat)
        {
            feladatok += feladat;
        }

        public override string ToString()
        {
            return $"{DolgozoNev} - {MunkaraForditottIdo} perc";
        }
    }
}
