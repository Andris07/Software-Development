using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class Termek : ITermek
    {
        public int ID { get; init; }
        public string Tipus { get; init; }
        public string Megnevezes { get; init; }
        readonly Dictionary<string, int> alapanyagokLista = new Dictionary<string, int>();
        readonly Katalogus katalogus;

        public Termek(int id, string tipus, string megnevezes, Dictionary<string, int> alapanyagokLista, Katalogus katalogus)
        {
            this.ID = id;
            this.Tipus = tipus;
            this.Megnevezes = megnevezes;
            this.alapanyagokLista = alapanyagokLista;
            this.katalogus = katalogus;
        }

        public int ElkeszitesiIdo
        {
            get
            {
                int elkeszitesiIdo = 0;

                foreach (var alapanyag in alapanyagokLista)
                {
                    elkeszitesiIdo += katalogus[alapanyag.Key].ElkeszitesiIdo * alapanyag.Value;
                }
                return elkeszitesiIdo;
            }
        }

        public int Ar
        {
            get
            {
                int ar = 0;

                foreach (var alapanyag in alapanyagokLista)
                {
                    ar += katalogus[alapanyag.Key].Ar * alapanyag.Value;
                }
                return ar;
            }
        }

        public override string ToString()
        {
            return $"{Megnevezes}: {Ar} HUF darabár";
        }
    }
}
