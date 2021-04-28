using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class MapElement
    {
        public static List<MapElement> allElements = new List<MapElement>();
        protected char drawChar;

        public Point Location { get; set; } = new Point();
        public MapElement()
        {
            Location = new Point(1,1);
            drawChar = 'O';
            allElements.Add(this);
        }
        public MapElement(char toDraw)
        {
            Location = new Point(1, 1);
            drawChar = toDraw;
            allElements.Add(this);
        }
        public MapElement(char toDraw, Point location)
        {
            drawChar = toDraw;
            Location = location;
            allElements.Add(this);
        }
        public void Draw()
        {
            Console.SetCursorPosition(Location.X, Location.Y);
            Console.Write(drawChar);
        }
        public void Die()
        {
            allElements.Remove(this);
        }
    }
}
