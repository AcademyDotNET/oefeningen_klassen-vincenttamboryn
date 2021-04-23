using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    class Vierkant:Rechthoek
    {
        public Vierkant(int zijde1, int zijde2):base(zijde1,zijde2)
        {
            if (zijde1 != zijde2)
            {
                Breedte = zijde1;
                Hoogte = zijde1;
            }
        }
        public Vierkant(int zijde): base(zijde,zijde)
        {
        }
    }
}
