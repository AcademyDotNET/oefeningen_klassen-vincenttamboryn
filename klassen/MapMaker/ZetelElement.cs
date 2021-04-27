using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class ZetelElement : FurnitureElement
    {
        public ZetelElement()
        {
            Price = 100;
            DrawChar = '+';
            UnitSize = 4;
        }
        public override void Paint()
        {
            for (int i = 0; i <= UnitSize; i++)
            {
                Console.SetCursorPosition(Location.X+i, Location.Y);
                Console.Write(DrawChar);
            }
            Console.SetCursorPosition(Location.X, Location.Y+1);
            Console.Write(DrawChar);
            Console.SetCursorPosition(Location.X + UnitSize, Location.Y+1);
            Console.Write(DrawChar);
        }
    }
}
