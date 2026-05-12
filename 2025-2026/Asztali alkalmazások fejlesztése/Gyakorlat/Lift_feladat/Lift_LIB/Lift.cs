using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift_LIB
{
    public class Lift : IMozog
    {
        public int EmeletekSzama { get; init; }
        public int AktualisEmelet { get; set; }
        Random r = new Random();

        public Lift(int emeletekSzama)
        {
            this.EmeletekSzama = emeletekSzama;
            this.AktualisEmelet = r.Next(1, EmeletekSzama + 1);
        }

        public void felfele()
        {
            try
            {
                if (r.Next(1, 101) == 1)
                {
                    throw new Exception("A lift elromlott");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (AktualisEmelet == EmeletekSzama)
            {
                throw new HibasIranyException();
            }
            else
            {
                AktualisEmelet++;
            }
        }

        public void lefele()
        {
            try
            {
                if (r.Next(1, 101) == 1)
                {
                    throw new Exception("A lift elromlott");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (AktualisEmelet == 1)
            {
                throw new HibasIranyException();
            }
            else
            {
                AktualisEmelet--;
            }
        }

        public override string ToString()
        {
            return $"Emeletek Száma: {EmeletekSzama}\n- Aktuális Emelet: {AktualisEmelet}.";
        }
    }
}
