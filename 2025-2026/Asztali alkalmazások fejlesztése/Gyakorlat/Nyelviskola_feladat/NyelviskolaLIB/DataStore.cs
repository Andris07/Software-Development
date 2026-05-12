using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NyelviskolaLIB
{
    public class DataStore
    {
        readonly List<Nyelv> nyelvek;
        readonly List<Tanar> tanarok;
        readonly List<TanitasiAlkalom> tanitasiAlkalmak;

        DataStore()
        {
            this.tanarok = File.ReadAllLines("Input\\tanar.csv").Skip(1).Select(x => new Tanar(x)).ToList();
            this.tanitasiAlkalmak = File.ReadAllLines("Input\\tanitasi_alkalom.csv").Skip(1).Select(x => new TanitasiAlkalom(x)).ToList();
            this.nyelvek = File.ReadAllLines("Input\\nyelv.csv").Skip(1).Select(x => new Nyelv(x)).ToList();
        }

        public static DataStore? Instance { get; private set; }
        public static void InitCSV()
        {
            if (Instance is not null) throw new InvalidOperationException("Már inicializált");
            Instance = new DataStore();
        }

        public IEnumerable<Nyelv> Nyelvek => nyelvek;
        public IEnumerable<Tanar> Tanarok => tanarok;
        public IEnumerable<TanitasiAlkalom> TanitasiAlkalmak => tanitasiAlkalmak;

        static void ExportToJson<T>(IEnumerable<T> elemek, string fajlNev)
        {
            var content = JsonSerializer.Serialize(elemek);
            File.WriteAllText(fajlNev, content, Encoding.UTF8);
        }

        public void ExportToJSon()
        {
            ExportToJson(nyelvek, "nyelv.json");
            ExportToJson(tanarok, "tanar.json");
            ExportToJson(tanitasiAlkalmak, "tanitasi_alkalom.json");
        }
    }
}
