using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borton_LIB
{
    public sealed class Or : Szemely
    {
        public override SzemelyTipus Tipus => SzemelyTipus.Or;
        public OrBeosztasTipus BeosztasTipus { get; internal set; }

        public Borton? Borton { get; internal set; }

        public Or(string azonosito, string nev, Nem nem, OrBeosztasTipus beosztasTipus, Borton? borton) : base(azonosito, nev, nem)
        {
            this.BeosztasTipus = beosztasTipus;

            this.Borton = borton;
        }

        public void Megver(Rab rab)
        {
            if (BeosztasTipus != OrBeosztasTipus.CellaOr)
                throw new JogosultsagKivetel("Nem cellaőr az őr, nem verhet!");

            if (rab.Borton != this.Borton)
                throw new SzabalyKivetel("Nem ebben a börtönben van a rab, nem verhető!");

            if (rab.Allapot == RabAllapot.Halott)
                throw new AllapotKivetel("Halott a rab, nem verhető!");

            if (rab.BuntetesTipus == RabBuntetesTipus.Halalbuntetes)
                throw new SzabalyKivetel("Halálbüntetéses a rab, nem verhető!");

            rab.VeresekSzama++;
        }

        protected override string TipusKiiras()
        {
            return "Őr";
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                   $"\tBeosztás: {BeosztasTipus}\n" +
                   $"\tBörtön: {Borton?.Nev ?? "Nincs"}";
        }
    }
}
