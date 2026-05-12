using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_Jatekgyar_LIB
{
    public abstract class Jatek : IJatek
    {
        public string Azonosito { get; init; }
        public string Tipus { get; init; }
        public string Megnevezes { get; init; }
        public abstract int ElkeszitesiIdo { get; }
        protected readonly GyartasAdatok gyartasAdatok;
        
        protected Jatek(string azonosito, string tipus, string megnevezes, GyartasAdatok gyartasAdatok)
        {
            this.Azonosito = azonosito;
            this.Tipus = tipus;
            this.Megnevezes = megnevezes;
            this.gyartasAdatok = gyartasAdatok;
        }

        public override string ToString()
        {
            return $"{Megnevezes}";
        }
    }
}
