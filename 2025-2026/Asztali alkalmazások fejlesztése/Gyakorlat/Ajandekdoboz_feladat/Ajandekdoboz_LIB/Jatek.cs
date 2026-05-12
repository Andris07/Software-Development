using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_LIB
{
    public class Jatek : Ajandek
    {
        public enum PlatformTipus { Playstation, Xbox, Nintendo }
        public PlatformTipus Platform { get; init; }
        public bool Elofizetes { get; init; }
        public bool Online { get; init; }

        public Jatek(string nev, int ar, string leiras, PlatformTipus platform, bool elofizetes, bool online) : base(nev, ar, leiras)
        {
            this.Platform = platform;
            this.Elofizetes = elofizetes;
            this.Online = online;
        }

        public override string ToString()
        {
            return base.ToString() + $"\tPlatform: {Platform}\n\tElőfizetés szükséges: {Elofizetes}\n\tOnline: {Online}\n\n";
        }
    }
}
