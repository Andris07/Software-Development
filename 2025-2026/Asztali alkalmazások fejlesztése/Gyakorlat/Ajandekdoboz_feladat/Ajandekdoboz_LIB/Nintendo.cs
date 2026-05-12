using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_LIB
{
    public class Nintendo : Konzol
    {
        public bool OldGen { get; init; }
        public readonly string[] JatekKartyak;

        public Nintendo(string nev, int ar, string leiras, bool crossPlay, bool oldGen, string[] jatekKartyak) : base(nev, ar, leiras, crossPlay)
        {
            this.OldGen = oldGen;
            this.JatekKartyak = jatekKartyak;
        }

        public override string ToString()
        {
            return base.ToString() + $"\tKlasszikus Nintendo: {OldGen}\n\tNintendo játékkártyák: {string.Join(", ", JatekKartyak)}\n\n";
        }
    }
}
