using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Monster : MapElement,IMoveable
    {
        public Monster() : base('M')
        { }
        public Monster(Point location) : base('M', location)
        { }
        public Monster(char toDraw) : base(toDraw)
        { }
        public Monster(char toDraw, Point location) :base(toDraw, location)
        { }

        public void MoveDown()
        {
            bool canMove = true;
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.Y+1 == item.Location.Y || this.Location.Y + 1 >= 21)
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
                if (this.Location.X - 1 == item.Location.X || this.Location.X -1 <= 0)
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
        public bool ItemLeft()
        {
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.X - 1 == item.Location.X && this.Location.Y == item.Location.Y)
                {
                    return true;
                }
            }
            return false;
        }
        public bool PlayerLeft()
        {
            foreach (var item in MapElement.allElements)
            {
                if (item is Player)
                {
                    if (this.Location.X - 1 == item.Location.X && this.Location.Y == item.Location.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void ShootPlayer()
        {
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.X + 1 == item.Location.X && this.Location.Y == item.Location.Y && item is Player)
                {
                    item.Die();
                }
            }
        }
        public void Move(int input)
        {
            switch (input)
            {
                case 0:
                    MoveLeft();
                    break;
                case 1:
                    MoveUp();
                    break;
                case 2:
                    MoveRight();
                    break;
                case 3:
                    MoveDown();
                    break;
                default:
                    break;
            }
        }
    }
}
