using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetDierenrijk
{
    class Animal
    {
        public bool hasLegs;
        public bool isAquatic;
        public string name;
        public Animal(string spicies)
        {
            name = spicies;
        }
        public virtual void ToonInfo()
        {
            if (hasLegs)
            {
                Console.WriteLine($"The {name} has legs.");
            }
            else
            {
                Console.WriteLine($"The {name} does not have legs.");
            }
            if (isAquatic)
            {
                Console.WriteLine($"The {name} lives in water.");
            }
            else
            {
                Console.WriteLine($"The {name} does not live in water.");
            }
        }
    }
}
