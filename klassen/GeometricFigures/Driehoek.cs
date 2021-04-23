using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    class Driehoek:GeometricFigure
    {
        public Driehoek(int breedte, int hoogte)
        {
            Breedte = breedte;
            Hoogte = hoogte;
        }
        public override double BerekenOppervlakte()
        {
            return Breedte * Hoogte / 2;
        }
    }
}
