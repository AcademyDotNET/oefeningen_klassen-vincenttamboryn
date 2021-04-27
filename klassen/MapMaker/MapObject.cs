using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    abstract class MapObject
    {
        private Point location;
        private double price;
        private char drawChar;

        //Teken object in de console
        public abstract void Paint();
    }
}
