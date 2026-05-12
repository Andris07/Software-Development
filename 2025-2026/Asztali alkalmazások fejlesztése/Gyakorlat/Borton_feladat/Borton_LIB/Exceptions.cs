using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borton_LIB
{
    public class SzabalyKivetel : Exception
    {
        public SzabalyKivetel(string msg) : base(msg) { }
    }

    public class JogosultsagKivetel : Exception
    {
        public JogosultsagKivetel(string msg) : base(msg) { }
    }

    public class AllapotKivetel : Exception
    {
        public AllapotKivetel(string msg) : base(msg) { }
    }
}
