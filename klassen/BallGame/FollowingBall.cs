using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallGame
{
    class FollowingBall:Ball
    {
        public FollowingBall(int xin, int yin, int vxin, int vyin) : base(xin, yin, vxin, vyin)
        {
            drawChar = '#';
            drawColor = ConsoleColor.DarkMagenta;
        }
        public void UpdateFollow(int folowx,int folowy)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            if (x >= Console.WindowWidth || x < 0)
            {
                vx *= -1;
                x += vx;
            }
            Random rNG = new Random();
            if (rNG.Next(0,3)<2)
            {
                if (y >= Console.WindowHeight || y < 0)
                {
                    vy *= -1;
                    y += vy;
                }
                if (x <= folowx)
                {
                    x += Math.Abs(vx);
                }
                else
                {
                    x -= Math.Abs(vx);
                }
                if (y <= folowy)
                {
                    y += Math.Abs(vy);
                }
                else
                {
                    y -= Math.Abs(vy);
                }
            }
        }
    }
}
