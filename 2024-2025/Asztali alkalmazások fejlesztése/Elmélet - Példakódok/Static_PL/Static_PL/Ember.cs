using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_PL
{
    internal class Ember
    {
        public const int MAXELETKOR = 150; //felvételkor egyből inicializálni kell
        static int MINFIZ = 100000;
        public static int MinimalisFizetes { get => MINFIZ; set => MINFIZ = value; }

        public string Nev { get; private set; }
        readonly int szuletesiEv;
        public int SzuletesiEv => szuletesiEv;
        public int Fizetes { get; init; }

        public Ember(string nev, int szuletesiEv, int fizetes)
        {
            Nev = nev;
            this.szuletesiEv = szuletesiEv;
            // MAXELETKOR = 300; csak egyszer kaphat értéket, amikor felvesszük, egyből inicializálni kell
            Fizetes = fizetes;
        }

        public string Info()
        {
            return $"{Nev} ({DateTime.Now.Year - szuletesiEv}): fizetése: {Fizetes}";
        }

        public bool NevValtoztatas(string nev)
        {
            if (nev.Contains(' '))
            {
                Nev = nev;
                return true;
            }
            return false;
        }

        public static bool MinimalisFizetesValtoztatas(int ertek)
        {
            if (ertek % 5000 == 0)
            {
                MINFIZ += ertek;
                return true;
            }
            return false;
        }
    }
}
