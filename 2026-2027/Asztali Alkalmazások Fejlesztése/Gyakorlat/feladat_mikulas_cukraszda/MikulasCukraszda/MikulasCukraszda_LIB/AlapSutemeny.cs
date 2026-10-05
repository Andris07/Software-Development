using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_LIB
{
    public sealed class AlapSutemeny : Sutemeny
    {
        public AlapSutemeny(string azonosito, string tipus, string megnevezes, KeszitesAdatok keszitesAdatok) : base(azonosito, tipus, megnevezes, keszitesAdatok)
        {

        }

        public override int ElkeszitesiIdo => keszitesAdatok[Tipus].ElkeszitesiIdo;
    }
}
