using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class HibasFeladatException : Exception
    {
        public HibasFeladatException() : base("A feladathoz nincs elegendő tudása a gyakornoknak.")
        {

        }
    }
}
