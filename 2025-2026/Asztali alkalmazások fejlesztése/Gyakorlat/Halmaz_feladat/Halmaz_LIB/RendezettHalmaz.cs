using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halmaz_LIB
{
    public class RendezettHalmaz<Tipus> : Halmaz<Tipus> where Tipus : IComparable<Tipus>
    {
        public new void HozzaAd(Tipus elem)
        {
            base.HozzaAd(elem);
            lista.Sort();
        }

        public new void Torol(Tipus elem)
        {
            base.Torol(elem);
            lista.Sort();
        }

        // Unió
        public static RendezettHalmaz<Tipus> operator +(RendezettHalmaz<Tipus> a, RendezettHalmaz<Tipus> b)
        {
            RendezettHalmaz<Tipus> eredmeny = new RendezettHalmaz<Tipus>();

            foreach (var elem in a.Sorozat()) eredmeny.HozzaAd(elem);
            foreach (var elem in b.Sorozat()) eredmeny.HozzaAd(elem);

            return eredmeny;
        }

        // Metszet
        public static RendezettHalmaz<Tipus> operator *(RendezettHalmaz<Tipus> a, RendezettHalmaz<Tipus> b)
        {
            RendezettHalmaz<Tipus> eredmeny = new RendezettHalmaz<Tipus>();

            foreach (var elem in a.Sorozat())
            {
                if (b.Tartalmazza(elem)) eredmeny.HozzaAd(elem);
            }

            return eredmeny;
        }

        // Különbség
        public static RendezettHalmaz<Tipus> operator -(RendezettHalmaz<Tipus> a, RendezettHalmaz<Tipus> b)
        {
            RendezettHalmaz<Tipus> eredmeny = new RendezettHalmaz<Tipus>();

            foreach (var elem in a.Sorozat())
            {
                if (!b.Tartalmazza(elem)) eredmeny.HozzaAd(elem);
            }

            return eredmeny;
        }
    }
}
