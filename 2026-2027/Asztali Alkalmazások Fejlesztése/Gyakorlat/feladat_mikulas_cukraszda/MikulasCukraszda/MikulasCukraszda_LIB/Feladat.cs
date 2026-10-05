using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_LIB
{
    public class Feladat
    {
        // SutemenyTipus;Darabszam
        public int Darabszam { get; init; }
        public const int MaxPerc = 8 * 60;
        public Sutemeny Sutemeny { get; init; }

        public Feladat(Sutemeny sutemeny, int darabszam)
        {
            this.Sutemeny = sutemeny;
            this.Darabszam = darabszam;

            if (ElkeszitesiIdo > MaxPerc)
            {
                throw new TulSokFeladatException();
            }
        }

        public int ElkeszitesiIdo => Sutemeny.ElkeszitesiIdo * Darabszam;

        public override string ToString()
        {
            return $"{Sutemeny.Megnevezes}: {Darabszam} adag, elkészítési idő: {ElkeszitesiIdo} perc";
        }
    }
}
