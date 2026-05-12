using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_Jatekgyar_LIB
{
    public class Feladat
    {
        public Jatek JatekTipus { get; init; }
        public int Darabszam { get; init; }
        const int MAXIMUM_IDO = 8 * 60;

        public Feladat(Jatek jatek, int darabszam)
        {
            this.JatekTipus = jatek;
            this.Darabszam = darabszam;

            if (ElkeszitesiIdo > MAXIMUM_IDO)
            {
                throw new TulSokFeladatException();
            }
        }

        public int ElkeszitesiIdo => JatekTipus.ElkeszitesiIdo * Darabszam;

        public override string ToString()
        {
            return $"{JatekTipus}: {Darabszam} db, elkészítési idő: {ElkeszitesiIdo} perc";
        }
    }
}
