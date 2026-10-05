using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_LIB
{
    public class TulSokFeladatException : Exception
    {
        public TulSokFeladatException() : base("Túl sok feladat, több mint 8 óra elkészíteni.")
        {

        }
    }
}
