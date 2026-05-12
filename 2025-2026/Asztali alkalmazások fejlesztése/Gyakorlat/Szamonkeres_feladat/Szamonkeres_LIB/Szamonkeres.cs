using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamonkeres_LIB
{
    public abstract class Szamonkeres : IPontozhato
    {
        public int Pontszam { get; init; }
        public string Tema { get; init; }

        public Szamonkeres(int pontszam, string tema)
        {
            this.Pontszam = pontszam;
            this.Tema = tema;
        }

        public bool Megfelelt(int elertPontszam)
        {
            if ((double)elertPontszam / Pontszam < 0.40)
            {
                return false;
            }
            else if (elertPontszam == -1)
            {
                throw new HianyzoFeladatException();
            }
            return true;
        }

        public abstract int Jegy(int elertPontszam);
    }
}
