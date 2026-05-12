using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class Dolgozo
    {
        public int DolgozoID { get; init; }
        public string DolgozoNev { get; init; }
        public string DolgozoBeosztas { get; }
        public double Gyakorlottsag { get; }
        public int MunkaraForditottIdo { get; }
        public FeladatLista feladatok = new FeladatLista();
        readonly List<Alapanyag> alapanyagok = new List<Alapanyag>();


        public Dolgozo(int dolgozoID, string dolgozoNev)
        {
            this.DolgozoID = dolgozoID;
            this.DolgozoNev = dolgozoNev;
        }

        public void UjFeladatHozzaadasa(string feladat)
        {
            feladatok += feladat;
        }

        public override string ToString()
        {
            return $"{DolgozoNev} - {MunkaraForditottIdo} perc";
        }
    }
}
