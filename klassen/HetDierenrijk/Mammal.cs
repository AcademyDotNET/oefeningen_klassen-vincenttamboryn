using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetDierenrijk
{
    class Mammal: Animal
    {
        public bool isCarnivorous;
        public bool livesInPacks;
        public Mammal(string species) : base(species)
        {
            name = species;
        }
        public override void ToonInfo()
        {
            base.ToonInfo();
            if (isCarnivorous)
            {
                Console.WriteLine($"The {name} is carnivorous.");
            }
            else
            {
                Console.WriteLine($"The {name} is not carnivorous.");
            }
            if (livesInPacks)
            {
                Console.WriteLine($"The {name} lives in packs.");
            }
            else
            {
                Console.WriteLine($"The {name} does not live in packs.");
            }
        }
    }
}
