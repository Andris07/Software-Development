using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_LIB
{
    public class Sutemenyek
    {
        readonly List<Sutemeny> sutemenyekLista = new List<Sutemeny>();

        public Sutemenyek(IEnumerable<Sutemeny> sutemenyek)
        {
            this.sutemenyekLista = sutemenyek.ToList();
        }

        public Sutemeny this[string azonosito] => sutemenyekLista.FirstOrDefault(x => x.Azonosito == azonosito)!;

        public IEnumerable<Sutemeny> SutemenyTipusok => sutemenyekLista.Where(x => !x.Tipus.StartsWith("d")).OrderBy(x => x.Azonosito);
    }
}
