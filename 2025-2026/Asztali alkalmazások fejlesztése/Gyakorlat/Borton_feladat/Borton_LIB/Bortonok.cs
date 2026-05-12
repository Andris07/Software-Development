using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borton_LIB
{
    public sealed class Bortonok
    {
        public List<Borton> BortonokLista { get; } = new();

        public void Hozzaad(Borton borton)
        {
            if (BortonokLista.Any(b => b.Nev == borton.Nev))
                throw new SzabalyKivetel("Már létezik ilyen nevű börtön!");

            BortonokLista.Add(borton);
        }

        public Borton? KeresNevAlapjan(string nev)
        {
            return BortonokLista.FirstOrDefault(b => b.Nev.Equals(nev, StringComparison.OrdinalIgnoreCase));
        }

        public override string ToString()
        {
            if (BortonokLista.Count == 0)
                return "Nincs létrehozva börtön!";

            return string.Join
            (
                "\n\n----------------------------------------\n\n",
                BortonokLista.Select(b => b.ToString())
            );
        }
    }
}
