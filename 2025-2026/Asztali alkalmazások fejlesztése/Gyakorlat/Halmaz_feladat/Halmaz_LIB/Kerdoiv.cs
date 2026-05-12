using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halmaz_LIB
{
    public static class Kerdoiv
    {
        static Random r = new Random();

        public static Halmaz<Tipus> Sorsolas<Tipus>(IEnumerable<Tipus> szemelyek, int db)
        {
            var lista = szemelyek.ToList();

            if (lista.Count() < db) throw new Exception("Nincs elegendő személy a sorsoláshoz!");

            Halmaz<Tipus> eredmeny = new Halmaz<Tipus>();

            while (eredmeny.listaDB < db)
            {
                int index = r.Next(lista.Count);
                eredmeny.HozzaAd(lista[index]);
            }

            return eredmeny;
        }
    }
}
