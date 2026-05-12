using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borton_LIB
{
    public sealed class Cellak
    {
        public List<Cella> Lista { get; } = new();

        public void Hozzaad(Cella cella)
        {
            if (Lista.Any(c => c.Azonosito == cella.Azonosito))
                throw new SzabalyKivetel("Már létezik ilyen azonosítójú cella!");

            Lista.Add(cella);
        }

        public Cella? KeresAzonosito(int id)
        {
            return Lista.FirstOrDefault(c => c.Azonosito == id);
        }

        public IEnumerable<Cella> SzabadCellak()
        {
            return Lista.Where(c => c.Rabok.Count < 2);
        }

        public override string ToString()
        {
            if (!Lista.Any())
                return "Nincs cella.";

            return string.Join("\n\n", Lista.Select(c => c.ToString()));
        }
    }
}
