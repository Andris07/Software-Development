using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borton_LIB
{
    public sealed class Rab : Szemely
    {
        public override SzemelyTipus Tipus => SzemelyTipus.Rab;
        public RabAllapot Allapot { get; internal set; } = RabAllapot.Elo;
        public RabBuntetesTipus BuntetesTipus { get; internal set; }
        public int VeresekSzama { get; internal set; }

        public Borton? Borton { get; internal set; }
        public Cella? Cella { get; internal set; }

        public Rab(string azonosito, string nev, Nem nem, RabBuntetesTipus buntetesTipus, int veresekSzama = 0) : base(azonosito, nev, nem)
        {
            if (veresekSzama < 0)
                throw new SzabalyKivetel("A verések száma nem lehet negatív.");

            this.BuntetesTipus = buntetesTipus;
            this.VeresekSzama = veresekSzama;
        }

        public void Leszur()
        {
            if (Allapot == RabAllapot.Halott)
                throw new AllapotKivetel("Halott a rab!");

            if (Cella == null)
                throw new SzabalyKivetel("Nincs rab a cellában!");

            var cellatars = Cella.Rabok.FirstOrDefault(r => r != this);

            if (cellatars == null)
                throw new SzabalyKivetel("Nincs cellatárs a cellában!");

            cellatars.Allapot = RabAllapot.Halott;
            Cella.Rabok.Remove(cellatars);
            cellatars.Cella = null;
        }

        protected override string TipusKiiras()
        {
            return "Rab";
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                   $"\tBüntetés: {BuntetesTipus}\n" +
                   $"\tÁllapot: {Allapot}\n" +
                   $"\tVerések száma: {VeresekSzama}\n" +
                   $"\tBörtön: {Borton?.Nev ?? "Nincs"}\n" +
                   $"\tCella: {Cella?.Azonosito.ToString() ?? "Nincs"}";
        }
    }
}
