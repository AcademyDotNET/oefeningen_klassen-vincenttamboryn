using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nummers
{
    class Nummers
    {
        public double Getal1 { get; set; }
        public double Getal2 { get; set; }
        public double Som()
        {
            return Getal1 + Getal2;
        }
        public double Verschil()
        {
            return Getal1 - Getal2;
        }
        public double Product()
        {
            return Getal1 * Getal2;
        }
        public double Quotient()
        {
            if (Getal2 != 0)
            {
                return Getal1 / Getal2;
            }
            else
            {
                Console.WriteLine("error");
                return double.PositiveInfinity;
            }
        }
    }
}
