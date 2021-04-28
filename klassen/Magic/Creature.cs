using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class Creature : Card
    {
        public int health;
        public int attack;
        public Creature():base()
        {
            health = 5;
            attack = 2;
        }
        public override string ToString()
        {
            return "a creature card";
        }
    }
}
