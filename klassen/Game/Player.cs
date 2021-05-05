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
            bool canMove = true;
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.Y + 1 == item.Location.Y && this.Location.X == item.Location.X || this.Location.Y + 1 >= Gameboard.BoardSize + 1)
                {
                    canMove = false;
                }
            }
            if (canMove)
            {
                this.Location.Y += 1;
            }
        }

        public void MoveLeft()
        {
            bool canMove = true;
            foreach (var item in MapElement.allElements)
            {
                if (Location.X - 1 == item.Location.X && this.Location.Y == item.Location.Y || Location.X - 1 < 0)
                {
                    canMove = false;
                }
            }
            if (canMove)
            {
                Location.X -= 1;
            }
        }

        public void MoveRight()
        {
            bool canMove = true;
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.X + 1 == item.Location.X && this.Location.Y == item.Location.Y || this.Location.X + 1 >= Gameboard.BoardSize + 1)
                {
                    canMove = false;
                }
            }
            if (canMove)
            {
                this.Location.X += 1;
            }
        }

        public void MoveUp()
        {
            bool canMove = true;
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.Y - 1 == item.Location.Y && this.Location.X == item.Location.X || this.Location.Y - 1 <= 0)
                {
                    canMove = false;
                }
            }
            if (canMove)
            {
                this.Location.Y -= 1;
            }
        }
        public void Move(ConsoleKeyInfo input)
        {
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
            Console.SetCursorPosition(Location.X * 2 + 1, Location.Y);
            Console.Write('-');
            System.Threading.Thread.Sleep(50);
            Console.SetCursorPosition(Location.X * 2 + 2, Location.Y);
            Console.Write('+');
            System.Threading.Thread.Sleep(100);

            foreach (var item in MapElement.allElements)
            {
                if (this.Location.X + 1 == item.Location.X && this.Location.Y == item.Location.Y)
                {
                    if (item is RockDestroyer)
                    {
                        Score += 1000;
                    }
                    else if (item is Monster)
                    {
                        Score += 250;
                    }
                    else if (item is Rock)
                    {
                        Score += 50;
                    }
                    item.Die();
                    return;
                }
            }
        }
        public void LongRangeShot()
        {
            if (LongRangeShots == 0)
            {
                return;
            }
            LongRangeShots--;
            int shootHowFar = 4;
            int tempShot = 4;
            // find out how far the shot goes
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
            // draw the shot
            for (int i = 1; i < shootHowFar * 2; i++)
            {
                Console.SetCursorPosition(Location.X * 2 + i, Location.Y);
                Console.Write('-');
                System.Threading.Thread.Sleep(50);
            }
            Console.SetCursorPosition(Location.X * 2 + shootHowFar * 2, Location.Y);
            Console.Write('+');
            System.Threading.Thread.Sleep(100);
            //kill the entity
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.X + shootHowFar == item.Location.X && this.Location.Y == item.Location.Y)
                {
                    if (item is RockDestroyer)
                    {
                        Score += 1000;
                    }
                    else if (item is Monster)
                    {
                        Score += 250;
                    }
                    else if (item is Rock)
                    {
                        Score += 50;
                    }
                    item.Die();
                    return;
                }
            }
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
                    drawColor = ConsoleColor.DarkYellow;
                    break;
                case 1:
                    drawColor = ConsoleColor.Yellow;
                    break;
                default:
                    base.Die();
                    break;
            }
        }
        public override void Draw()
        {
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
            Console.Write($"\tLongrange Shots: {LongRangeShots}");

            Console.ForegroundColor = drawColor;
            Console.SetCursorPosition(Location.X * 2, Location.Y);
            Console.Write(drawChar);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
