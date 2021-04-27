using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class ZetelElement : FurnitureElement
    {
        public ZetelElement() :base()
        {
            Price = 100;
            DrawChar = '+';
            UnitSize = 4;
        }
        public ZetelElement(Point p, double priceZetel)
        {
            Location = p;
            Price = priceZetel;
            DrawChar = '+';
            UnitSize = 4;
        }
        public ZetelElement(Point p, double priceElement, char charToDraw)
        {
            Location = p;
            Price = priceElement;
            DrawChar = charToDraw;
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
