using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_LIB
{
    public abstract class Ajandek : IAjandek
    {
        public string Nev { get; init; }
        public int Ar { get; init; }
        public string Leiras { get; init; }

        public Ajandek(string nev, int ar, string leiras)
        {
            this.Nev = nev;
            this.Ar = ar;
            this.Leiras = leiras;
        }

        public override string ToString()
        {
            return $"{Nev} - {Ar} Ft\n{Leiras}\n\n";
        }
    }
}
