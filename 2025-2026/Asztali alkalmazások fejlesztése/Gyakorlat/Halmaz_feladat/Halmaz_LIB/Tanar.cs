using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halmaz_LIB
{
    public class Tanar : Szemely
    {
        public string Szak { get; init; }

        public Tanar(string oktatasiAzonosito, string nev, string foglalkoztatottsag, string szak) : base(oktatasiAzonosito, nev, foglalkoztatottsag)
        {
            this.Szak = szak;
        }

        public override string ToString()
        {
            return base.ToString() + $"\tSzak: {Szak}\n";
        }
    }
}
