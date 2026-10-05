using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_LIB
{
    public abstract class Sutemeny : IEtel
    {
        public string Azonosito { get; init; }
        public string Tipus { get; init; }
        public string Megnevezes { get; init; }
        protected readonly KeszitesAdatok keszitesAdatok;

        protected Sutemeny(string azonosito, string tipus, string megnevezes, KeszitesAdatok keszitesAdatok)
        {
            this.Azonosito = azonosito;
            this.Tipus = tipus;
            this.Megnevezes = megnevezes;
            this.keszitesAdatok = keszitesAdatok;
        }

        public abstract int ElkeszitesiIdo { get; }

        public override string ToString()
        {
            return Megnevezes;
        }
    }
}
