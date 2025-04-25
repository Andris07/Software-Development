using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoEmberPr
{
    internal class HoEmber
    {
        private const int LOPAS = 66;
        private int gombocokSzama;
        private int meret;
        private int fagyott;

        public bool VanSepru { get; set; }

        public int GombocokSzama
        {
            get;
            init;
        }

        public int Meret
        {
            get
            {
                return meret;
            }
            set
            {
                if (value < 0)
                {
                    meret = 0;
                }
                else if (value > 100)
                {
                    meret = 100;
                }
                else
                {
                    meret = value;
                }
            }
        }

        public int Fagyott
        {
            get
            {
                return fagyott;
            }
            set
            {
                if (value < 0)
                {
                    fagyott = 0;
                }
                else if (value > 100)
                {
                    fagyott = 100;
                }
                else
                {
                    fagyott = value;
                }
            }
        }

        public HoEmber()
        {
            GombocokSzama = Random.Shared.Next(2,4);
            Meret = 100;
            Fagyott = 100;
            VanSepru = true;
        }

        public HoEmber(int gombocokSzama, bool vanSepru)
        {
            GombocokSzama = gombocokSzama;
            VanSepru = vanSepru;
            Meret = 100;
            Fagyott = 100;
        }

        public string Info()
        {
            return $"A hóember mérete: {Meret} fagyási állapota: {fagyott} %";
        }

        public void Olvad(int ertek)
        {
            Fagyott -= ertek;
            Meret -= ertek;
        }

        public void VisszaFagy(int ertek)
        {
            Fagyott += ertek;
        }

        public bool SepruLopas(int ertek)
        {
            int esely = ertek + (100 - Fagyott);

            if (esely > LOPAS)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}