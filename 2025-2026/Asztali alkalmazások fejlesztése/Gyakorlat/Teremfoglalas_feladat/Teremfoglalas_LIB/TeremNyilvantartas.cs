using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teremfoglalas_LIB
{
    public class TeremNyilvantartas
    {
        readonly List<Terem> termek;

        public TeremNyilvantartas(IEnumerable<Terem> termek)
        {
            this.termek = termek.ToList();
        }

        public IEnumerable<string> TermekAzonositoi() => termek.Select(x => x.TeremAzonosito);

        public Terem? this[string teremAzonosito] => termek.Find(x => x.TeremAzonosito == teremAzonosito);
        public IEnumerable<Terem> Termek() => termek;

        public void TeremFoglalasok(IEnumerable<Foglalas> foglalasok)
        {
            foreach (var helyszin in foglalasok.GroupBy(x => x.HelyszinAzonosito))
            {
                Terem? terem = this[helyszin.Key];

                foreach (var foglalas in helyszin)
                {
                    try
                    {
                        terem?.IdoPontFoglalas(foglalas);
                    }
                    catch (FoglalasException ex)
                    {
                        File.AppendAllText("hibalista.txt", $"{foglalas} - {ex.Message}\n");
                    }
                }
            }
        }

        public IEnumerable<Foglalas> SzemelyFoglalasai(string nev)
        {
            foreach (var terem in termek)
            {
                foreach (var foglalas in terem.TeremOrarend.SzemelyFoglaltIdopontjai(nev))
                {
                    yield return foglalas;
                }
            }
        }
    }
}
