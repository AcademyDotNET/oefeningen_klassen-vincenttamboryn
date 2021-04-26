using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHouse
{
    class Room
    {
        public double Oppervlakte { get; set; }
        public string Name { get; set; }
        public virtual double Price { get; set; } = 400;

    }
}
