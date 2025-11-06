using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csokigyar_LIB
{
    public interface IEtel
    {
        IEnumerable<string> MibolKeszul();
        bool MegfeleloMinoseg { get; }
    }
}
