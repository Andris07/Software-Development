using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teremfoglalas_LIB
{
    public class Orarend
    {
        readonly List<Foglalas> foglaltIdopontok;

        public Orarend()
        {
            this.foglaltIdopontok = new List<Foglalas>();
        }

        public bool FoglaltE(DateTime kezdet, int perc)
        {
            return foglaltIdopontok.Exists(x => x.Kezdete <= kezdet && x.Vege > kezdet || x.Kezdete > kezdet && x.Kezdete < kezdet.AddMinutes(perc));
        }

        public static Orarend operator +(Orarend orarend, Foglalas foglalas)
        {
            if (orarend.FoglaltE(foglalas.Kezdete, foglalas.IdotartamPercben))
            {
                throw new FoglalasException();
            }

            Orarend ujOrarend = new Orarend();
            ujOrarend.foglaltIdopontok.AddRange(orarend.foglaltIdopontok);
            ujOrarend.foglaltIdopontok.Add(foglalas);
            return ujOrarend;
        }

        public override string ToString()
        {
            return $"Foglalt időpontok:\n{string.Join("\n", foglaltIdopontok.OrderBy(x => x.Kezdete))}";
        }

        public IEnumerable<Foglalas> SzemelyFoglaltIdopontjai(string nev)
        {
            return foglaltIdopontok.Where(x => x.TanarAzonosito == nev);
        }
    }
}
