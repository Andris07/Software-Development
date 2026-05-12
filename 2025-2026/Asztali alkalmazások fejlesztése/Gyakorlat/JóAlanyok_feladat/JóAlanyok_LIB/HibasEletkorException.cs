using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JóAlanyok_LIB
{
    public class HibasEletkorException : Exception
    {
        public HibasEletkorException() : base("Az életkor beállítása nem megfelelő!")
        {

        }
    }
}
