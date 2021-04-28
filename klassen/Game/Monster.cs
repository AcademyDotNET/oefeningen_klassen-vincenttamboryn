using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Monster : MapElement,IMoveable
    {
        public Monster() : base()
        { }
        public Monster(char toDraw) : base(toDraw)
        { }
        public Monster(char toDraw, Point location) : base(toDraw, location)
        { }

        public void MoveDown()
        {
            bool canMove = true;
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.Y-1 == item.Location.Y)
                {
                    canMove = false;
                }
            }
            if (canMove)
            {
                this.Location.Y -= 1;
            }
        }

        public void MoveLeft()
        {
            bool canMove = true;
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.X - 1 == item.Location.X)
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
                if (this.Location.X + 1 == item.Location.X)
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
                if (this.Location.Y + 1 == item.Location.Y)
                {
                    canMove = false;
                }
            }
            if (canMove)
            {
                this.Location.Y += 1;
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
    }
}
