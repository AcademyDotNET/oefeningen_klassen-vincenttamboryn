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
        protected ConsoleColor drawColor = ConsoleColor.White;

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
        public virtual void Draw()
        {
            Console.ForegroundColor = drawColor;
            Console.SetCursorPosition(Location.X, Location.Y);
            Console.Write(drawChar);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public virtual void Die()
        {
            allElements.Remove(this);
        }
    }
}
