using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halmaz_LIB
{
    public abstract class Szemely
    {
        public string OktatasiAzonosito { get; init; }
        public string Nev { get; init; }
        public string Foglalkoztatottsag { get; init; }

        protected Szemely(string oktatasiAzonosito, string nev, string foglalkoztatottsag)
        {
            this.OktatasiAzonosito = oktatasiAzonosito;
            this.Nev = nev;
            this.Foglalkoztatottsag = foglalkoztatottsag;
        }

        public override string ToString()
        {
            return $"A kiválasztott személy adatai: \n\tOktatási Azonosító: {OktatasiAzonosito}\n\tNév: {Nev}\n\tFoglalkoztatottság: {Foglalkoztatottsag}\n";
        }
    }
}
