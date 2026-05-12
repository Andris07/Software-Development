using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borton_LIB
{
    public abstract class Szemely
    {
        public abstract SzemelyTipus Tipus { get; }
        public string Azonosito { get; init; }
        public string Nev { get; init; }
        public Nem Nem { get; init; }

        public Szemely(string azonosito, string nev, Nem nem)
        {
            this.Azonosito = azonosito;
            this.Nev = nev;
            this.Nem = nem;
        }

        public override string ToString()
        {
            return $"{TipusKiiras()}\n" +
                   $"\tNév: {Nev}\n" +
                   $"\tNem: {Nem}\n" +
                   $"\tAzonosító: {Azonosito}";
        }

        protected virtual string TipusKiiras()
        {
            return "Személy";
        }
    }
}
