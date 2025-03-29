using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termekek
{
    internal class Termek
    {
        int egysegAr;
        double kedvezmeny;
        int raktarKeszlet;

        public string Nev { get; init; }
        public int EgysegAr 
        {
            get
            {
                return egysegAr;
            }
            set
            {
                if (value > 0)
                    egysegAr = value;
                else
                    egysegAr = 0;
            }
        }

        public double Kedvezmeny 
        {
            get { return kedvezmeny; }
            set
            {
                if (value < 0)
                    kedvezmeny = 0;
                else if (value > 1)
                    kedvezmeny = 1;
                else kedvezmeny = value;
            }
        }

        public int RaktarKeszlet
        {
            get { return raktarKeszlet; }
            set
            {
                if (value < 0)
                    raktarKeszlet = 0;
                else
                    raktarKeszlet = value;
            }
        }

        public Termek(string nev, int ar)
        {
            Nev = nev;
            EgysegAr = ar;
            RaktarKeszlet = 1;
            Kedvezmeny = 0;
        }

        public Termek(string nev, int ar, int keszlet)
        {
            Nev = nev;
            EgysegAr = ar;
            RaktarKeszlet = keszlet;
            Kedvezmeny = 0;
        }

        public string Informacio()
        {
            return $"Név: {Nev} Ár: {EgysegAr} Készlet: {RaktarKeszlet}";
        }

        public bool Eladas(int db)
        {
            if (db > RaktarKeszlet) return false;
            RaktarKeszlet -= db;
            return true; 
        }
        public void Beszerzes(int db)
        {
            if (db>0) RaktarKeszlet += db;
        }

    }
}
