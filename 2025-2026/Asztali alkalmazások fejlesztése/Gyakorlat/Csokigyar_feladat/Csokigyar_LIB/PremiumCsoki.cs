using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csokigyar_LIB
{
    internal sealed class PremiumCsoki : Csoki
    {
        public PremiumCsoki(string csokifajta, string[] alapanyagok, int kakaoTartalom) : base(csokifajta, alapanyagok, kakaoTartalom)
        {

        }

        public override bool MegfeleloMinoseg => KakaoTartalom switch
        {
            > 80 => true,
            >= 0 => false,
            _ => throw new SilanyMinosegException()
        };

        public override string ToString()
        {
            return $"Prémium: {base.ToString()}";
        }
    }
}
