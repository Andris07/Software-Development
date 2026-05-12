using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_LIB
{
    public class Playstation : Konzol
    {
        public int PSPlusAr { get; init; }
        public IReadOnlyList<string> Exkluzivak;

        public Playstation(string nev, int ar, string leiras, bool crossPlay, int psPlusAr, string[] exkluzivak) : base(nev, ar, leiras, crossPlay)
        {
            this.PSPlusAr = psPlusAr;
            this.Exkluzivak = exkluzivak;
        }

        public override string ToString()
        {
            return base.ToString() + $"\tPlaystation Plus havi előfizetés: {PSPlusAr} Ft\n\tExklúzív játékok: {string.Join(", ", Exkluzivak)}\n\n";
        }
    }
}
