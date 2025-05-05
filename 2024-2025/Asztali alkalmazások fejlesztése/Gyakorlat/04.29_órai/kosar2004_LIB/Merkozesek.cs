using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosar2004_LIB
{
    public class Merkozesek
    {
        private readonly List<Merkozes> merkozesek = [];

        public Merkozesek(IEnumerable<string> fajlSorok)
        {
            foreach (var fajlSor in fajlSorok)
            {
                merkozesek.Add(new Merkozes(fajlSor));
            }
        }

        public int HazaiMerkozesekSzama(string csapatNev) => merkozesek.Count(x => x.Hazai == csapatNev);
        public int IdegenMerkozesekSzama(string csapatNev) => merkozesek.Count(x => x.Idegen == csapatNev);
        public bool VoltEDontetlen => merkozesek.Any(x => x.Dontetlen);
        public string? Csapatneve(string varos) => merkozesek.Find(x => x.Hazai.ToLower().Contains(varos.ToLower()))?.Hazai;
        public IEnumerable<Merkozes> SzazPontnalTobbetDobtakOtthon => merkozesek.Where(x => x.SzazPontnalTobbHazai).OrderBy(x => x.Idopont).ThenBy(x => x.Hazai);
        public IEnumerable<Merkozes> MerkozesekAdottNapon(DateOnly datum) => merkozesek.Where(x => x.Idopont == datum);
        public Merkozes LegnagyobbPontkulonbseguMerkozes => merkozesek.MaxBy(x => x.PontKulonbseg);
        public Dictionary<string, int> StadionokSokMerkozessel(int merkozesekSzama) => merkozesek.GroupBy(x => x.Helyszin).Where(x => x.Count() > merkozesekSzama).ToDictionary(x => x.Key, x => x.Count());
    }
}