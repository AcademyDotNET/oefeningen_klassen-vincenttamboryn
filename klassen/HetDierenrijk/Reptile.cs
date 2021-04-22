using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetDierenrijk
{
    class Reptile: Animal
    {
        public bool isScaley;
        public bool isVenomous;
        public Reptile(string species) : base(species)
        {
            name = species;
        }
        public override void ToonInfo()
        {
            base.ToonInfo();
            if (isScaley)
            {
                Console.WriteLine($"The {name} has scales.");
            }
            else
            {
                Console.WriteLine($"The {name} does not have scales.");
            }
            if (isVenomous)
            {
                Console.WriteLine($"The {name} is venomous.");
            }
            else
            {
                Console.WriteLine($"The {name} is not venomous.");
            }
        }
    }
}
