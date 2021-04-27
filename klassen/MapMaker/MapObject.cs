﻿using System;
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
        private Point location;
        private double price;
        private char drawChar;
        public Point Location
        {
            get { return location; }
            set { location = value; }
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
