using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Point
    {
        private int x;
        private int y;
        public Point()
        {
            X = 1;
            Y = 1;
        }
        public Point(int inx, int iny)
        {
            X = inx;
            Y = iny;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
