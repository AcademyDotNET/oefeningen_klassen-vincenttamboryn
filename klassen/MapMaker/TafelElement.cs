using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class TafelElement : FurnitureElement
    {
        private int hoogte;
        private int breedte;
        public TafelElement()
        {
            DrawChar = 'T';
            hoogte = 4;
            breedte = 2;
            Location = new Point(1, 1);
        }
        public TafelElement(Point p, int h, int b)
        {
            DrawChar = 'T';
            hoogte = h;
            breedte = b;
            Location = p;
        }
        public override void Paint()
        {
            for (int i = 0; i < hoogte; i++)
            {
                for (int j = 0; j < breedte; j++)
                {
                    Console.SetCursorPosition(Location.X + j, Location.Y + i);
                    Console.Write(DrawChar);
                }
            }
        }
    }

}
