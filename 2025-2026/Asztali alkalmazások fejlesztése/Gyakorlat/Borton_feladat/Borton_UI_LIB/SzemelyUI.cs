using Borton_LIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borton_UI_LIB
{
    public static class SzemelyUI
    {
        public static Nem NemBekeres()
        {
            int v = Menu.ValasztoMenu("Nem kiválasztása", new[] { "Férfi", "Nő" });
            return v == 1 ? Nem.Ferfi : Nem.No;
        }

        public static RabBuntetesTipus BuntetesBekeres()
        {
            int v = Menu.ValasztoMenu("Büntetés típusa", new[] { "Halálbüntetés", "Életfogytiglan" });
            return v == 1 ? RabBuntetesTipus.Halalbuntetes : RabBuntetesTipus.Eletfogytiglan;
        }
    }
}
