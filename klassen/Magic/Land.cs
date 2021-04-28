using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class Land : Card
    {
        public int bonusAttack;
        public int costReduction;
        public Land() : base()
        {
            bonusAttack = 1;
            costReduction = 1;
        }
        public override string ToString()
        {
            return "a land card";
        }
    }
}
