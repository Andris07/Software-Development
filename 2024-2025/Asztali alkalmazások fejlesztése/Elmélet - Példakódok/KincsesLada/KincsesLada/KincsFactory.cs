using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KincsesLada
{
    class KincsFactory
    {
        static Random random = new Random();

        public IKincs Create()
        {
            int tipus = random.Next(2);
            if (tipus == 0)
                return new Erme(random.Next(3));
            else
                return new Dragako(random.Next(3), random.Next(3));

        }
    }
}
