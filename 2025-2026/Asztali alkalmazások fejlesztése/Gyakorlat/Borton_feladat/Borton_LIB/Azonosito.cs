using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Borton_LIB
{
    public class Azonosito
    {
        static readonly string Betuk = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        static readonly string Szamok = "0123456789";
        static readonly string Specialis = "!@#$%^&*()-_=+[]{};:<>/?";
        static readonly Random r = new Random();

        public string General(Nem nem, SzemelyTipus tipus)
        {
            char tipusBetu = tipus switch
            {
                SzemelyTipus.Rab => 'R',
                SzemelyTipus.Or => 'O',
                SzemelyTipus.Tulajdonos => 'T',
                _ => throw new ArgumentOutOfRangeException()
            };

            char nemBetu = nem == Nem.Ferfi ? 'F' : 'N';

            // Betűkészlet, amiből kivesszük a típus betűjét
            string koztesKeszlet = Betuk + Szamok + Specialis;
            koztesKeszlet = koztesKeszlet.Replace(tipusBetu.ToString(), "");

            char[] azonosito = new char[8];

            // 1. karakter: csak betű
            azonosito[0] = Betuk[r.Next(Betuk.Length)];

            // 8. karakter: csak speciális
            azonosito[7] = Specialis[r.Next(Specialis.Length)];

            // Típus betűjének pozíciója (2–7 között, de 7 már foglalt)
            int tipusPoz = r.Next(1, 7);
            azonosito[tipusPoz] = tipusBetu;

            // Nem betűjének pozíciója (nem lehet azonos a típus pozícióval)
            int nemPoz;
            do
            {
                nemPoz = r.Next(1, 7);
            } while (nemPoz == tipusPoz);

            azonosito[nemPoz] = nemBetu;

            // A többi hely kitöltése
            for (int i = 1; i < 7; i++)
            {
                if (i == tipusPoz || i == nemPoz) continue;
                azonosito[i] = koztesKeszlet[r.Next(koztesKeszlet.Length)];
            }

            return new string(azonosito);
        }
    }
}
