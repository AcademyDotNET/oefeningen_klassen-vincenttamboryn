using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player : MapElement,IMoveable,IDestroyer
    {
        public int Lives { get; set; }
        public int Score { get; set; }
        public int LongRangeShots { get; set; }
        public Player() : base('X', new Point(0,10))
        {
            drawColor = ConsoleColor.Green;
            Lives = 3;
            LongRangeShots = 3;
        }
        public Player(Point location) : base('X', location)
        { 
            drawColor = ConsoleColor.Green;
            Lives = 3;
            LongRangeShots = 3;
        }

        public void MoveDown()
        {
            if (CanMove(0,1))
            {
                this.Location.Y += 1;
            }
        }

        public void MoveLeft()
        {
            if (CanMove(-1,0))
            {
                Location.X -= 1;
            }
        }

        public void MoveRight()
        {
            if (CanMove(1,0))
            {
                this.Location.X += 1;
            }
        }

        public void MoveUp()
        {
            if (CanMove(0,-1))
            {
                this.Location.Y -= 1;
            }
        }
        private bool CanMove(int x, int y)
        {
            bool canMove = true;
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.Y + y == item.Location.Y && this.Location.X + x == item.Location.X || this.Location.Y + y >= Gameboard.BoardSize + 1 || this.Location.Y + y <= 0 || this.Location.X + x >= Gameboard.BoardSize + 1 || this.Location.X + x <= 0)
                {
                    canMove = false;
                }
            }
            return canMove;
        }
        public void Move(ConsoleKeyInfo input)
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
            switch (input.Key)
            {
                case ConsoleKey.Spacebar:
                    Shoot();
                    break;
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.E:
                    LongRangeShot();
                    break;
                default:
                    break;
            }
        }
        public void Shoot()
        {
            DrawShot(1);
            Kill(1);
        }
        void DrawShot(int shootHowFar)
        {// draw the shot
            for (int i = 1; i < shootHowFar * 2; i++)
            {
                Console.SetCursorPosition(Location.X * 2 + i, Location.Y);
                Console.Write('-');
                System.Threading.Thread.Sleep(50);
            }
            Console.SetCursorPosition(Location.X * 2 + shootHowFar * 2, Location.Y);
            Console.Write('+');
            System.Threading.Thread.Sleep(100);
        }
        static int IncreasePoints(Object entity)
        {
            if (entity is RockDestroyer)
            {
                return 1000;
            }
            else if (entity is Monster)
            {
                return 250;
            }
            else if (entity is Rock)
            {
                return 50;
            }
            return 0;
        }
        public void LongRangeShot()
        {
            if (LongRangeShotsLeft())
            {
                int shootHowFar = ShotLenght();
                DrawShot(shootHowFar);
                Kill(shootHowFar);
            }
        }
        bool LongRangeShotsLeft()
        {
            if (LongRangeShots <= 0)
            {
                return false;
            }
            LongRangeShots--;
            return true;
        }
        void Kill(int shotDistance)
        {//kill an entity at distance shotDistance
            foreach (var item in MapElement.allElements)
            {
                if (Location.X + shotDistance == item.Location.X && Location.Y == item.Location.Y)
                {
                    Score += IncreasePoints(item);
                    item.Die();
                    return;
                }
            }
        }
        int ShotLenght()
        {// find out how far the shot goes
            int shootHowFar = 4;
            int tempShot = 4;
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.X + 3 == item.Location.X && this.Location.Y == item.Location.Y)
                {
                    tempShot = 3;
                }
                if (this.Location.X + 2 == item.Location.X && this.Location.Y == item.Location.Y)
                {
                    tempShot = 2;
                }
                if (this.Location.X + 1 == item.Location.X && this.Location.Y == item.Location.Y)
                {
                    tempShot = 1;
                }
                if (tempShot < shootHowFar)
                {
                    shootHowFar = tempShot;
                }
            }
            if (shootHowFar == 4)
            {
                shootHowFar = 3;
            }
            return shootHowFar;
        }
        public override void Die()
        {
            if (Lives <= 0)
            {
                base.Die();
            }
            else
            {
                Lives--;
            }
            switch (Lives)
            {
                case 3:
                    drawColor = ConsoleColor.Green;
                    break;
                case 2:
                    drawColor = ConsoleColor.Yellow;
                    break;
                case 1:
                    drawColor = ConsoleColor.DarkYellow;
                    break;
                default:
                    base.Die();
                    break;
            }
        }
        public override void Draw()
        {
            DrawStats();
            Console.ForegroundColor = drawColor;
            Console.SetCursorPosition(Location.X * 2, Location.Y);
            Console.Write(drawChar);
            Console.ForegroundColor = ConsoleColor.White;
        }
        void DrawStats()
        {
            DrawLives();
            DrawScore();
            DrawLongShotsLeft();
        }
        void DrawLives()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = drawColor;
            Console.SetCursorPosition(2, Gameboard.BoardSize + 2);
            Console.Write("Lives: ");
            switch (Lives)
            {
                case 3:
                    Console.Write("♥♥♥");
                    break;
                case 2:
                    Console.Write("♥♥");
                    break;
                case 1:
                    Console.Write("♥");
                    break;
                default:
                    Console.Write("DEAD");
                    break;
            }
        }
        void DrawLongShotsLeft()
        {
            switch (LongRangeShots)
            {
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.Write($"\tLong-Range Shots: {LongRangeShots}");
        }
        void DrawScore()
        {
            if (Score < 1000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (Score > 1000 && Score < 2000)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (Score > 2000 && Score < 3500)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write($"\tSCORE: {Score}");
        }
    }
}
