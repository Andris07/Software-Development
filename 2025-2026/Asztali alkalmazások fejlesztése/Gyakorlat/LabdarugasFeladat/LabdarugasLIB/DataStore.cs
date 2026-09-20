using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabdarugasLIB
{
    public class DataStore
    {
        readonly List<Edzo> edzok;
        readonly List<Csapat> csapatok;
        readonly List<Torna> tornak;

        public DataStore()
        {
            this.edzok = File.ReadAllLines("Inputs\\edzok.txt").Skip(1).Select(fájlSor => new Edzo(fájlSor)).ToList();
            this.csapatok = File.ReadAllLines("Inputs\\csapatok.txt").Skip(1).Select(fájlSor => new Csapat(fájlSor)).ToList();
            this.tornak = File.ReadAllLines("Inputs\\tornak.txt").Skip(1).Select(fájlSor => new Torna(fájlSor)).ToList();
        }

        public static void InitCSV()
        {
            if (Instance is not null) throw new InvalidOperationException("Inicializáltunk már!");
            Instance = new DataStore();
        }

        public static DataStore? Instance;

        public IEnumerable<Edzo> Edzok => this.edzok;
        public IEnumerable<Csapat> Csapatok => this.csapatok;
        public IEnumerable<Torna> Tornak => this.tornak;

        // Számított tulajdonságok
        public Csapat LegtobbTrofeavalRendelkezoCsapat => DataStore.Instance!.Csapatok.MaxBy(x => x.Trofeak)!;
        public double AtlagTornaPontokEgyTornan(int tornaID) => DataStore.Instance!.Csapatok.Where(x => x.TornaID == tornaID).Average(x => x.TornaPontok);
        public IEnumerable<Edzo> LegeredmenyesebbEdzok(int edzoDB) => DataStore.Instance!.Edzok.OrderByDescending(x => x.Trofeak).Take(edzoDB);
    }
}
