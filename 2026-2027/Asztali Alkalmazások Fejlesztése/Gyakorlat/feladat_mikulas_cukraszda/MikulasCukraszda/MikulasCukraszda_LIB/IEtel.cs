using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_LIB
{
    public interface IEtel
    {
        string Azonosito { get; }
        string Tipus { get; }
        string Megnevezes { get; }
        int ElkeszitesiIdo { get; }
    }
}
