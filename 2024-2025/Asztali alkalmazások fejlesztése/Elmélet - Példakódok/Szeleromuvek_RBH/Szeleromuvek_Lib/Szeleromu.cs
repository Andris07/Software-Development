using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szeleromuvek_Lib
{
    public class Szeleromu
    {
        public Szeleromu(string regio, string megye, string telepules, 
            int darab, int teljesitmeny, int ev)
        {
            Regio = regio;
            Megye = megye;
            Telepules = telepules;
            Darab = darab;
            Teljesitmeny = teljesitmeny;
            Ev = ev;
        }

        public string Regio { get; init; }
        public string Megye { get; init; }
        public string Telepules { get; init; }
        public int Darab { get; init; }
        public int Teljesitmeny { get; init; }
        public int Ev { get; init; }


    }
}
