using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Rock : MapElement
    {
        public Rock():base('O')
        { }
        public Rock(Point location) : base('O', location)
        { }
    }
}
