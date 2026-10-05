using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public interface ITermek
    {
        string Tipus { get; }
        string Megnevezes { get; }
        int ElkeszitesiIdo { get; }
        int Ar { get; }
    }
}
