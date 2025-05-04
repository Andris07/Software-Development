using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VB_LIB
{
    public class VBK
    {
        private readonly List<VB> vbk = [];

        public VBK(IEnumerable<string> fajlSorok)
        {
            foreach (var fajlSor in fajlSorok)
            {
                vbk.Add(new VB(fajlSor));
            }
        }

        public int StadionDarabSzam => vbk.Count;
        public VB LegkevesebbFerohelyuStadion => vbk.MinBy(x => x.FerohelyekSzama);
        public double FerohelyekAtlaga => vbk.Average(x => x.FerohelyekSzama);
        public int AlternativNevuStadionokSzama => vbk.Count(x => x.StadionNev2 != "n.a.");
        public int SzovegResztTartalmazoStadionokSzama(string szovegResz) => vbk.Count(x => x.StadionNev1.Contains(szovegResz));
        public IEnumerable<string> VarosokNevei => vbk.Select(x => x.VarosNev).Distinct().Order();

        public void Fajlbairas(string fajlNev)
        {
            StreamWriter fajlbairas_Stadionok = new StreamWriter(fajlNev);
            foreach (var stadion in vbk)
            {
                fajlbairas_Stadionok.WriteLine($"{stadion.StadionNev1};{stadion.StadionNev2};{stadion.FerohelyekSzama}");
            }
            fajlbairas_Stadionok.Close();

            StreamReader fajlbeolvasas_Stadionok = new StreamReader(fajlNev);
            if (fajlbeolvasas_Stadionok.ReadLine() is null)
            {
                Console.WriteLine("A fájlbaírás nem történt meg");
            }
            else
            {
                Console.WriteLine("A fájlbaírás megtörtént");
            }
            fajlbeolvasas_Stadionok.Close();
        }
    }
}
