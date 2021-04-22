using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallGame
{
    class CirculatingBall : Ball
    {
        private double time;
        public CirculatingBall(int xin, int yin, int vxin, int vyin) :base(xin, yin, vxin, vyin)
        {
            drawChar = '@';
            drawColor = ConsoleColor.Blue;
        }
        public override void Update()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            time += 0.2;
            x = Convert.ToInt32(Math.Min(((Console.WindowWidth) / 2 - 1), (Console.WindowHeight) / 2 - 1) * Math.Cos(time) + (Console.WindowWidth)/2 -1);
            y = Convert.ToInt32(Math.Min(((Console.WindowWidth) / 2 - 1), (Console.WindowHeight) / 2 - 1) * Math.Sin(time) + (Console.WindowHeight) / 2 - 1);
        }
    }
}
