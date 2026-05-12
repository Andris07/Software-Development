using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_Jatekgyar_LIB
{
    public sealed class EgyszeruJatek : Jatek
    {
        public EgyszeruJatek(string azonosito, string tipus, string megnevezes, GyartasAdatok gyartas) : base(azonosito, tipus, megnevezes, gyartas)
        {

        }

        public override int ElkeszitesiIdo => gyartasAdatok[Tipus]?.ElkeszitesiIdo ?? 0;
    }
}
