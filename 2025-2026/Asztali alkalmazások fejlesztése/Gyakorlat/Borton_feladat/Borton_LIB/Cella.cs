using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borton_LIB
{
    public sealed class Cella
    {
        public int Azonosito { get; init; }

        public List<Rab> Rabok { get; internal set; }

        public Cella(int azonosito)
        {
            this.Azonosito = azonosito;

            this.Rabok = new List<Rab>();
        }

        public void RabHozzaad(Rab rab)
        {
            if (rab.Allapot == RabAllapot.Halott)
                throw new SzabalyKivetel("Halott a rab!");

            if (Rabok.Count >= 2)
                throw new SzabalyKivetel("Megtelt a cella!");

            if (Rabok.Count > 0)
            {
                var cellaTars = Rabok[0];

                if (cellaTars.Nem != rab.Nem || cellaTars.BuntetesTipus != rab.BuntetesTipus)
                    throw new SzabalyKivetel("Nem egyező nem vagy büntetés!");
            }

            Rabok.Add(rab);
            rab.Cella = this;
        }

        public override string ToString()
        {
            string rabLista = Rabok.Count == 0 ? "Üres" : string.Join("\n\t", Rabok.Select(r => r.Nev));

            return $"Cella #{Azonosito}\n" +
                   $"\tRabok:\n" +
                   $"\t{rabLista}";
        }
    }
}
