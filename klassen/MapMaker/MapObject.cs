using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    abstract class MapObject
    {
        public MapObject()
        {
            location = new Point(1,1);
            DrawChar = 'x';
        }
        public MapObject(int x, int y)
        {
            location = new Point(x, y);
            DrawChar = 'x';
        }
        public MapObject(int x, int y, char character)
        {
            location = new Point(1, 1);
            DrawChar = character;
        }
        public MapObject(Point p,char charToDraw ,double priceElement)
        {
            location = p;
            DrawChar = charToDraw;
            Price = priceElement;
        }
        private Point location;
        private double price;
        private char drawChar;
        public Point Location
        {
            get { return location; }
            set 
            {
                Point prevloc = location;
                Point offset = new Point(1, 1);
                if (location != null)
                {

                    offset.X = value.X - prevloc.X;
                    offset.Y = value.Y - prevloc.Y;
                }

                location = value;
                if (this is IComposite)
                {
                    IComposite obj = this as IComposite;
                    obj.UpdateElements(offset);
                }
            }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public char DrawChar
        {
            get { return drawChar; }
            set { drawChar = value; }
        }


        //Teken object in de console
        public abstract void Paint();
    }
}
