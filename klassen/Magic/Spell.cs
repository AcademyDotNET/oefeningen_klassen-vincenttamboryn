using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class Spell : Card
    {
        public SpellEffect effect;
        public Spell() : base()
        {
            effect = new SpellEffect();
        }
        public override string ToString()
        {
            return "a spell card";
        }
    }
}
