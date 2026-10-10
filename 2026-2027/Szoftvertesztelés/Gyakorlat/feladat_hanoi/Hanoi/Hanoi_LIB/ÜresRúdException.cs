using System;
using System.Collections.Generic;
using System.Text;

namespace Hanoi_LIB
{
    public class ÜresRúdException : Exception
    {
        public ÜresRúdException() : base("Üres rúdról nem tudsz áthelyezni korongot.")
        {

        }
    }
}
