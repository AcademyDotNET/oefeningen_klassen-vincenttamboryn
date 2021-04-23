using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    abstract class GeometricFigure
    {
        public double Hoogte { get; set; }
        public double Breedte { get; set; }
        public double Oppervlakte { get => BerekenOppervlakte();}
        public abstract double BerekenOppervlakte();
    }
}
