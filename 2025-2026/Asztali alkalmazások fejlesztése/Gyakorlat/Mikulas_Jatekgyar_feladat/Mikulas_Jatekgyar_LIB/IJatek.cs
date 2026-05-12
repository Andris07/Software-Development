using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_Jatekgyar_LIB
{
    public interface IJatek
    {
        string Azonosito { get; }
        string Tipus { get; }
        string Megnevezes { get; }
        int ElkeszitesiIdo { get; }
    }
}
