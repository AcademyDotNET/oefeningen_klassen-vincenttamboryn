using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player : MapElement,IMoveable,IDestroyer
    {
        public Player() : base('X', new Point(0,10))
        { }
        public Player(Point location) : base('X', location)
        { }
        public void MoveDown()
        {
            bool canMove = true;
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.Y + 1 == item.Location.Y || this.Location.Y + 1 >= 21)
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
                if (this.Location.X - 1 == item.Location.X || this.Location.X - 1 < 0)
                {
                    canMove = false;
                }
            }
            if (canMove)
            {
                this.Location.X -= 1;
            }
        }

        public void MoveRight()
        {
            bool canMove = true;
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.X + 1 == item.Location.X || this.Location.X + 1 >= 21)
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
                if (this.Location.Y - 1 == item.Location.Y || this.Location.Y - 1 <= 0)
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
                    item.Die();
                }
            }
        }
    }
}
