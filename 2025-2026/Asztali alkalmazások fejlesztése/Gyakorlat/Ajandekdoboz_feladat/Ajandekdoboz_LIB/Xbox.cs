using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_LIB
{
    public class Xbox : Konzol
    {
        public int XboxPremiumAr { get; init; }
        public bool CloudGaming { get; init; }

        public Xbox(string nev, int ar, string leiras, bool crossPlay, int xboxPremiumAr, bool cloudGaming) : base(nev, ar, leiras, crossPlay)
        {
            this.XboxPremiumAr = xboxPremiumAr;
            this.CloudGaming = cloudGaming;
        }

        public override string ToString()
        {
            return base.ToString() + $"\tXbox Game Pluss Prémium havi előfizetés: {XboxPremiumAr} Ft\n\tFelhőalapú játék: {CloudGaming}\n\n";
        }
    }
}
