using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_LIB
{
    public class Feladatok
    {
        readonly List<Feladat> feladatok;

        public Feladatok()
        {
            this.feladatok = new List<Feladat>();
        }

        public static Feladatok operator +(Feladatok feladatok, Feladat feladat)
        {
            Feladatok feladatokUjLista = new Feladatok();
            feladatokUjLista.feladatok.AddRange(feladatok.feladatok);
            feladatokUjLista.feladatok.Add(feladat);
            return feladatokUjLista;
        }

        public IEnumerable<Feladat> FeladatLista => feladatok;
    }
}
