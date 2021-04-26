using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    class Boat
    {
        public Engine BoatEngine { get; set; } = null;
        private readonly int minPropeller = 1;
        private readonly int maxPropeller = 4;
        public Propeller[] BoatPropellers;
        public Boat(int howManyPropeller, int howManyPistons, bool hasEngine)
        {
            if (howManyPropeller < minPropeller)
            {
                BoatPropellers = new Propeller[minPropeller];
            }
            else if (howManyPropeller > maxPropeller)
            {
                BoatPropellers = new Propeller[maxPropeller];
            }
            else
            {
                BoatPropellers = new Propeller[howManyPropeller];
            }
            if (hasEngine)
            {
                BoatEngine = new Engine(howManyPistons);
            }
            for (int i = 0; i < BoatPropellers.Length; i++)
            {
                BoatPropellers[i] = new Propeller();
            }
        }
    }
}
