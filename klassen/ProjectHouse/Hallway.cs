using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHouse
{
    class Hallway:Room
    {
        public override double Price { get => Oppervlakte * 10;}
        public Hallway(double size)
        {
            Oppervlakte = size;
        }
    }
}
