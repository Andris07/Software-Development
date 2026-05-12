using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_LIB
{
    public class AjandekDoboz<T> where T : IAjandek
    {
        readonly List<T> ajandekDoboz;

        public AjandekDoboz()
        {
            ajandekDoboz = new List<T>();
        }

        public void Hozzaad(T ajandek)
        {
            if (ajandek == null)
            {
                throw new ArgumentNullException(nameof(ajandek), "Nincs megadva a hozzáadandó ajándék");
            }
            ajandekDoboz.Add(ajandek);
        }

        public void Torol(T ajandek)
        {
            if (!ajandekDoboz.Contains(ajandek))
            {
                throw new ArgumentException(nameof(ajandek), "Nem található a törlendő ajándék");
            }
            ajandekDoboz.Remove(ajandek);
        }

        public int OsszAr()
        {
            return ajandekDoboz.Sum(a => a.Ar);
        }

        public IReadOnlyList<T> Tartalom => ajandekDoboz.AsReadOnly();

        public override string ToString()
        {
            string eredmeny = $"Ajándékdoboz típusa: {typeof(T).Name}\n";
            eredmeny += $"Termékek száma: {ajandekDoboz.Count}\n";
            eredmeny += $"Összérték: {OsszAr()} Ft\n\n";

            foreach (var a in ajandekDoboz)
            {
                eredmeny += a.ToString();
            }
            return eredmeny;
        }
    }
}