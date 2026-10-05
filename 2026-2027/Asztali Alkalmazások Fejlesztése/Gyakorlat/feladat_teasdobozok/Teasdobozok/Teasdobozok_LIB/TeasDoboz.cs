using System;
using System.Collections.Generic;
using System.Text;

namespace Teasdobozok_LIB
{
    public abstract class TeasDoboz : IDoboz
    {
        public int DarabSzam { get; init; }
        public abstract int Ar { get; }
        public abstract string Nev { get; }

        readonly List<Filter> filterek = new List<Filter>();

        // Darabszam;Filterek
        public TeasDoboz(int darabSzam)
        {
            this.DarabSzam = darabSzam;
        }

        public override string ToString()
        {
            return $"{Nev} ({Ar} Ft)";
        }
    }
}
