using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Rock : MapElement
    {
        public Rock():base()
        { }
        public Rock(char toDraw) : base(toDraw)
        { }
        public Rock(char toDraw, Point location) : base(toDraw, location)
        { }
    }
}
