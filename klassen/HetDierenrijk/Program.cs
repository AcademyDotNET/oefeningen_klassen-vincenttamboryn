using System;
using System.Collections.Generic;

namespace HetDierenrijk
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal wurm = new Animal("wurm");
            wurm.hasLegs = false;
            wurm.isAquatic = false;

            Mammal monkey = new Mammal("monkey");
            monkey.hasLegs = true;
            monkey.isAquatic = false;
            monkey.isCarnivorous = true;
            monkey.livesInPacks = true;

            Reptile rattlesnake = new Reptile("rattlesnake");
            rattlesnake.hasLegs = false;
            rattlesnake.isAquatic = false;
            rattlesnake.isScaley = true;
            rattlesnake.isVenomous = true;

            List<Animal> animalList = new List<Animal>() { wurm ,monkey ,rattlesnake };
            foreach (var item in animalList)
            {
                item.ToonInfo();
                Console.WriteLine();
            }
        }
    }
}
