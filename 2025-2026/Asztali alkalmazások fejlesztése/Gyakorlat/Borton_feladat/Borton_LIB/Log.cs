using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borton_LIB
{
    public static class Log
    {
        static readonly string Mappa = "saves";

        public static void Logging(string uzenet)
        {
            Directory.CreateDirectory(Mappa);

            string fajl = Path.Combine(Mappa, "log.txt");

            File.AppendAllText(fajl, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {uzenet}\n");
        }
    }
}