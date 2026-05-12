using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borton_LIB
{
    public sealed class Borton
    {
        public string Nev { get; init; }

        public Tulajdonos Tulajdonos { get; internal set; }

        public Cellak Cellak { get; } = new();
        public List<Rab> Rabok { get; } = new();
        public List<Or> Orok { get; } = new();

        public Borton(string nev, Tulajdonos tulajdonos)
        {
            if (string.IsNullOrWhiteSpace(nev))
                throw new SzabalyKivetel("A börtön neve nem lehet üres!");

            if (tulajdonos == null)
                throw new SzabalyKivetel("Nem létező tulajdonos!");

            this.Nev = nev;
            this.Tulajdonos = tulajdonos;

            tulajdonos.Borton = this;
            tulajdonos.BortonBeallit(this);
        }

        public void CellaEpites()
        {
            int ujAzonosito = Cellak.Lista.Any() ? Cellak.Lista.Max(c => c.Azonosito) + 1 : 1;

            Cellak.Hozzaad(new Cella(ujAzonosito));
        }

        public void OrFelvetel(Or or)
        {
            Orok.Add(or);

            or.Borton = this;
        }

        public void RabFelvetel(Rab rab)
        {
            if (Rabok.Contains(rab))
                throw new SzabalyKivetel("A rab már fel van véve!");

            if (Orok.Count == 0)
                throw new SzabalyKivetel("Nincs börtönőr!");

            var szabadCella = Cellak.SzabadCellak().FirstOrDefault(c => c.Rabok.Count == 0 || (c.Rabok[0].Nem == rab.Nem && c.Rabok[0].BuntetesTipus == rab.BuntetesTipus));

            if (szabadCella == null)
                throw new SzabalyKivetel("Nincs szabad cella!");

            Rabok.Add(rab);
            rab.Borton = this;
            szabadCella.RabHozzaad(rab);
        }

        public override string ToString()
        {
            string cellak = Cellak.Lista.Count == 0 ? "Nincs cella" : string.Join("\n\n", Cellak.Lista.Select(c => c.ToString()));

            return $"Börtön:\t{Nev}\n" +
                   $"\tTulajdonos: {Tulajdonos.Nev}\n" +
                   $"\tCellák: \n{cellak}\n\n" +
                   $"\tRabok száma: {Rabok.Count}\n" +
                   $"\tŐrök száma: {Orok.Count}";
        }
    }
}
