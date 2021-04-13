using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuren
{
    class Rectangle
    {
        private double basis = 1;
        private double hoogte = 1;
        public double Basis
        {
            get
            {
                return basis;
            }
            set
            {
                if (value > 0 && Microsoft.VisualBasic.Information.IsNumeric(value))
                { 
                    basis = value;
                }
            }
        }
        public double Hoogte
        {
            get
            {
                return hoogte;
            }
            set
            {
                if (value > 0 && Microsoft.VisualBasic.Information.IsNumeric(value))
                {
                    hoogte = value;
                }
            }
        }
        public void ToonOppervlakte(string name)
        {
            Console.WriteLine($"De oppervlakte van {name} bedraagt {basis*hoogte}");
        }
    }
}
