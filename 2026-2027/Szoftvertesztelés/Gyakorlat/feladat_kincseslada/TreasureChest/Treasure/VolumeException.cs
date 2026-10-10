using System;
using System.Collections.Generic;
using System.Text;

namespace Treasure
{
    public class VolumeException : Exception
    {
        public VolumeException() : base("Volume can't be 0 or below 0")
        {

        }
    }
}