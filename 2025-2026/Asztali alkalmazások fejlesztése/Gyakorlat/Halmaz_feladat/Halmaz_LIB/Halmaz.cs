namespace Halmaz_LIB
{
    public class Halmaz<Tipus>
    {
        protected readonly List<Tipus> lista;

        public Halmaz()
        {
            this.lista = new List<Tipus>();
        }

        // a. feladat
        public int listaDB => lista.Count();

        // b. feladat
        public bool Tartalmazza(Tipus elem) => lista.Contains(elem);

        // c. feladat
        // Elem Hozzáadása
        public void HozzaAd(Tipus elem)
        {
            if (!Tartalmazza(elem)) lista.Add(elem);
        }

        // Elem Törlése
        public void Torol(Tipus elem)
        {
            if (Tartalmazza(elem)) lista.Remove(elem);
        }

        // d. feladat
        public IEnumerable<Tipus> Sorozat() => lista;

        // e. feladat
        // Unió
        public static Halmaz<Tipus> operator +(Halmaz<Tipus> a, Halmaz<Tipus> b)
        {
            Halmaz<Tipus> eredmeny = new Halmaz<Tipus>();

            foreach (var elem in a.lista) eredmeny.HozzaAd(elem);
            foreach (var elem in b.lista) eredmeny.HozzaAd(elem);

            return eredmeny;
        }

        // Metszet
        public static Halmaz<Tipus> operator *(Halmaz<Tipus> a, Halmaz<Tipus> b)
        {
            Halmaz<Tipus> eredmeny = new Halmaz<Tipus>();

            foreach (var elem in a.lista)
            {
                if (b.Tartalmazza(elem)) eredmeny.HozzaAd(elem);
            }

            return eredmeny;
        }

        // Különbség
        public static Halmaz<Tipus> operator -(Halmaz<Tipus> a, Halmaz<Tipus> b)
        {
            Halmaz<Tipus> eredmeny = new Halmaz<Tipus>();

            foreach (var elem in a.lista)
            {
                if (!b.Tartalmazza(elem)) eredmeny.HozzaAd(elem);
            }

            return eredmeny;
        }

        // f. feladat
        public override string ToString()
        {
            return $"{string.Join(", ", lista)}";
        }
    }
}
