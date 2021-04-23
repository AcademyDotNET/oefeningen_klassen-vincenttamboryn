using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Block
    {
        public int X { get { return x; } }
        public int Y { get { return y; } }
        protected int x = 0;
        protected int y = 0;
        protected char drawChar = '#';
        protected ConsoleColor drawColor = ConsoleColor.White;
        public Block(int xin, int yin)
        {
            x = xin;
            y = yin;
        }
        public void Delete()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(drawChar);
            Console.ResetColor();
            x = 0;
            y = 0;
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = drawColor;
            Console.Write(drawChar);
            Console.ResetColor();
        }
        public bool CheckHit(Block block, Bullet bullet)
        {

            if (block.X == bullet.X && block.Y == bullet.Y)
                return true;

            return false;
        }
    }
}
