using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KincsesLada
{
    interface IKincs
    {
        string Nev { get; }
        string Leiras { get; }
        string Tipus { get; }
        int Ertek { get; }
    }
}
