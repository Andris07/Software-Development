using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_LIB
{
    public sealed class DiszitettSutemeny : Sutemeny
    {
        readonly IEnumerable<string> osszetevok;
        
        public DiszitettSutemeny(string azonosito, string tipus, string megnevezes, KeszitesAdatok keszitesAdatok, IEnumerable<string> osszetevok) : base(azonosito, tipus, megnevezes, keszitesAdatok)
        {
            this.osszetevok = osszetevok;
        }

        public string TipusMeghatarozas(string osszetevoAzonosito)
        {
            if (osszetevoAzonosito.StartsWith('d'))
            {
                return osszetevoAzonosito;
            }
            return osszetevoAzonosito.Substring(0, 1);
        }

        public override int ElkeszitesiIdo => osszetevok.Sum(x => keszitesAdatok[TipusMeghatarozas(x)].ElkeszitesiIdo);
    }
}
