using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    class Engine
    {
        public Crankshaft EngineCrankshaft { get; set; }
        private readonly int minPistons = 4;
        private readonly int maxPistons = 8;
        public Piston[] enginePistons;

        public Engine(int howManyPiston)
        {
            if (howManyPiston < minPistons)
            {
                enginePistons = new Piston[minPistons];
            }
            else if (howManyPiston > maxPistons)
            {
                enginePistons = new Piston[maxPistons];
            }
            else 
            {
                enginePistons = new Piston[howManyPiston];
            }
            for (int i = 0; i < enginePistons.Length; i++)
            {
                enginePistons[i] = new Piston();
            }
            EngineCrankshaft = new Crankshaft();
        }
    }
}
