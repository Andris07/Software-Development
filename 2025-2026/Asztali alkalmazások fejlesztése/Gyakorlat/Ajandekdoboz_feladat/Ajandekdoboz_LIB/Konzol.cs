using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_LIB
{
    public abstract class Konzol : Ajandek
    {
        public bool CrossPlay { get; init; }

        public Konzol(string nev, int ar, string leiras, bool crossPlay) : base(nev, ar, leiras)
        {
            this.CrossPlay = crossPlay;
        }

        public override string ToString()
        {
            return base.ToString() + $"\tTöbbplatformos: {CrossPlay}\n";
        }
    }
}
