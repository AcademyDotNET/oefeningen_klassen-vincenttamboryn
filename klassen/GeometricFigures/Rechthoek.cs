using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    class Rechthoek:GeometricFigure
    {
        public Rechthoek(int breedte, int hoogte)
        {
            Breedte = breedte;
            Hoogte = hoogte;
        }
        public override double BerekenOppervlakte()
        {
            return Breedte * Hoogte;
        }
    }
}
