using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halmaz_LIB
{
    public class Diak : Szemely
    {
        public string Osztaly { get; init; }

        public Diak(string oktatasiAzonosito, string nev, string foglalkoztatottsag, string osztaly) : base(oktatasiAzonosito, nev, foglalkoztatottsag)
        {
            this.Osztaly = osztaly;
        }

        public override string ToString()
        {
            return base.ToString() + $"\tOsztály: {Osztaly}\n";
        }
    }
}
