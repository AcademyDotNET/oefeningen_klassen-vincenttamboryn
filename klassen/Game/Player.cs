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
        public Player() : base('X', new Point(0,10))
        {
            drawColor = ConsoleColor.Green;
            Lives = 3;
        }
        public Player(Point location) : base('X', location)
        { 
            drawColor = ConsoleColor.Green;
            Lives = 3;
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
                default:
                    break;
            }
        }
        public void Shoot()
        {
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
                    drawColor = ConsoleColor.DarkGreen;
                    break;
                case 2:
                    drawColor = ConsoleColor.Green;
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
            Console.Write($"\tSCORE: {Score}");
            Console.SetCursorPosition(Location.X, Location.Y);
            Console.Write(drawChar);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
