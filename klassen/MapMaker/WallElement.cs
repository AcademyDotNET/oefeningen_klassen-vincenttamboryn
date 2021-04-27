using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class WallElement : MapObject
    {
        public WallElement():base()
        { }
        public WallElement(int x, int y) : base(x,y)
        { }
        public WallElement(int x, int y, char character) : base(x, y, character)
        { }
        public override void Paint()
        {
            Console.SetCursorPosition(Location.X, Location.Y);
            Console.Write(DrawChar);
        }
    }
}
