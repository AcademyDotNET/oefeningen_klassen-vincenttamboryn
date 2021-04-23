using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Bullet:Block
    {
        private int v;


        public Bullet(int xin, int yin,bool up) : base(xin,yin)
        {
            if (up)
            {
                v = 1;
            }
            else
            {
                v = -1;
            }
            drawChar = '!';
            drawColor = ConsoleColor.Red;
        }
        public void update()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            y += v;
        }
    }
}
