using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift_LIB
{
    public class Liftek
    {
        private readonly List<Lift> liftek = new List<Lift>();

        public Liftek(IEnumerable<Lift> liftek)
        {
            this.liftek = liftek.ToList();
        }

        public Lift this[int i]
        {
            get
            {
                return this.liftek[i - 1];
            }
            set
            {
                try
                {
                    if (this.liftek[i] == null)
                    {
                        throw new Exception("Nem található ilyen lift");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                this.liftek[i] = value;
            }
        }
    }
}
