using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class MapElement:IMapObjects
    {
        public static List<MapElement> allElements = new List<MapElement>();
        protected char drawChar;
        protected ConsoleColor drawColor = ConsoleColor.White;

        public ICoordinates Location { get; set; }
        public MapElement()
        {
            Object[] location = { 1, 1 };
            Location = CoordinateFactory.Build("Point", location);
            drawChar = 'O';
            allElements.Add(this);
        }
        public MapElement(char toDraw)
        {
            Object[] location = { 1, 1 };
            Location = CoordinateFactory.Build("Point", location);
            drawChar = toDraw;
            allElements.Add(this);
        }
        public MapElement(char toDraw, ICoordinates location)
        {
            drawChar = toDraw;
            Location = location;
            allElements.Add(this);
        }
        public virtual void Draw()
        {
            Console.ForegroundColor = drawColor;
            Console.SetCursorPosition(Location.X * 2, Location.Y);
            Console.Write(drawChar);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public virtual void Die()
        {
            allElements.Remove(this);
        }
    }
}
