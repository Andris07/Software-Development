using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borton_LIB
{
    public sealed class Tulajdonos : Szemely
    {
        public override SzemelyTipus Tipus => SzemelyTipus.Tulajdonos;

        public Borton? Borton { get; internal set; }

        public Tulajdonos(string azonosito, string nev, Nem nem, Borton? borton) : base(azonosito, nev, nem)
        {
            this.Borton = borton;
        }

        public void BortonBeallit(Borton borton)
        {
            this.Borton = borton;
        }

        public void RabFelvetel(Rab rab)
        {
            if (Borton == null)
                throw new SzabalyKivetel("Nincs börtöne a tulajdonosnak!");

            Borton.RabFelvetel(rab);
        }

        public void OrFelvetel(Or or)
        {
            if (Borton == null)
                throw new SzabalyKivetel("Nincs börtöne a tulajdonosnak!");

            Borton.OrFelvetel(or);
        }

        public void CellaEpites()
        {
            if (Borton == null)
                throw new SzabalyKivetel("Nincs börtöne a tulajdonosnak!");

            Borton.CellaEpites();
        }

        public void Kivegez(Rab rab)
        {
            if (Borton == null)
                throw new SzabalyKivetel("Nincs börtöne a tulajdonosnak!");

            if (rab.BuntetesTipus != RabBuntetesTipus.Halalbuntetes)
                throw new SzabalyKivetel("Nem halálbüntetéses a rab, nem kivégezhető!");

            rab.Allapot = RabAllapot.Halott;
            rab.Cella?.Rabok.Remove(rab);
            rab.Cella = null;
        }

        protected override string TipusKiiras()
        {
            return "Tulajdonos";
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                   $"\tBörtön: {Borton?.Nev ?? "Nincs"}";
        }
    }
}
