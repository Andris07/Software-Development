using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_Jatekgyar_LIB
{
    public sealed class InteraktivJatek : Jatek
    {
        readonly List<string> modulok;

        public InteraktivJatek(string azonosito, string tipus, string megnevezes, GyartasAdatok gyartas, IEnumerable<string> modulok) : base(azonosito, tipus, megnevezes, gyartas)
        {
            this.modulok = modulok.ToList();
        }

        public override int ElkeszitesiIdo => modulok.Sum(x => gyartasAdatok[TipusMeghatarozas(x)]?.ElkeszitesiIdo ?? 0);

        static string TipusMeghatarozas(string modul)
        {
            if (modul[0] == 'k') return modul;
            return modul[0].ToString();
        }
    }
}
