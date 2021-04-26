using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class GameObjects
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Describe()
        {
            Console.WriteLine(Name + "," + Description + ".");
        }
    }
}
