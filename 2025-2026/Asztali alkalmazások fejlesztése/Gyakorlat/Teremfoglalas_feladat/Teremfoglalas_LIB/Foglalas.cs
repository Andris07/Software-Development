using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teremfoglalas_LIB
{
    public class Foglalas : IFoglalas
    {
        public string HelyszinAzonosito { get; init; }
        public DateTime Kezdete { get; init; }
        public int IdotartamPercben { get; init; }
        public string TanarAzonosito { get; init; }
        public DateTime Vege => Kezdete.AddMinutes(IdotartamPercben);

        public Foglalas(DateTime kezdete, int idotartamPercben, string helyszinAzonosito, string tanarAzonosito)
        {
            this.HelyszinAzonosito = helyszinAzonosito;
            this.Kezdete = kezdete;

            if (idotartamPercben < 15 || idotartamPercben%15 != 0)
            {
                throw new IdotartamException();
            }

            this.IdotartamPercben = idotartamPercben;
            this.TanarAzonosito = tanarAzonosito;
        }

        public override string ToString()
        {
            return $"{Kezdete:yyyy.MM.dd.} {Kezdete.TimeOfDay} - {Vege.TimeOfDay} {TanarAzonosito}";
        }
    }
}
