using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sikolcsonzo_lib
{
    public class Berles : IBerles
    {
        public string BerloNev {  get; init; }
        public string SporteszkozID { get; }
        public DateOnly BerlesKezdet { get; }
        public int NapokSzama { get; }
        public DateOnly BerlesVeg => BerlesKezdet.AddDays(NapokSzama);

        public Berles(string sporteszkozID, DateOnly berlesKezdet, int napokSzama, string berloNev)
        {
            DateOnly idoszakKezdete = new DateOnly(2024,12,2);
            DateOnly idoszakVege = new DateOnly(2025,4,21);
            SporteszkozID = sporteszkozID;
            BerlesKezdet = berlesKezdet;
            NapokSzama = napokSzama;
            BerloNev = berloNev;

            if (idoszakKezdete > berlesKezdet || berlesKezdet > idoszakVege || BerlesVeg > idoszakVege)
            {
                throw new HibasDatumException();
            }
        }

        public override string ToString()
        {
            return $"{BerlesKezdet} - {BerlesVeg} {BerloNev}";
        }
    }
}
