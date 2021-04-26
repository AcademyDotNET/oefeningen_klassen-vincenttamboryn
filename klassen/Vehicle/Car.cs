using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    class Car
    {
        public Wheel[] AllWheels = new Wheel[4];
        public Engine CarEngine { get; set; } = null;
        public Car(int howManyPistons, bool hasEngine)
        {
            for (int i = 0; i < AllWheels.Length; i++)
            {
                AllWheels[i] = new Wheel();
            }
            if (hasEngine)
            {
                CarEngine = new Engine(howManyPistons);
            }
        }
    }
}
