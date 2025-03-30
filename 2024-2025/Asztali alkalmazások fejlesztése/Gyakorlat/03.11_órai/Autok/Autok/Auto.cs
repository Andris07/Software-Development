using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autok
{
    internal class Auto
    {
        List<int> sebessegek = new();

        public string Tipus { get; init; }
        public string Vezeto { get; set; }
        public int MaxSebesseg { get; init; }
        private double AtlagSebesseg
        {
            get
            {
                if (sebessegek.Count ==0)
                    return 0;
                return sebessegek.Average();
            }
        }
        

        public Auto()
        {
            Tipus = "Ismeretlen";
            Vezeto = string.Empty;
            MaxSebesseg = 100;
        }

        public Auto(string tipus, string vezeto, int maximalisSebesseg)
        {
            Tipus = tipus;
            Vezeto = vezeto;
            if (maximalisSebesseg < 100) 
                MaxSebesseg = 100;
            else MaxSebesseg = maximalisSebesseg;
        }

        public int SebessegMeres()
        {
            if (Vezeto==string.Empty) return 0;
            int sebesseg = Random.Shared.Next(MaxSebesseg/4, MaxSebesseg);
            sebessegek.Add(sebesseg);
            return sebesseg;
        }

        public string Log()
        {
            return $"Sofőr: {Vezeto} átlagsebesség: {AtlagSebesseg}";
        }

        public int Osszehasonlitas(Auto auto)
        {
            if (AtlagSebesseg > auto.AtlagSebesseg)
                return 1;
            else if (auto.AtlagSebesseg > AtlagSebesseg)
                return -1;
            else return 0;
        }

    }
}
