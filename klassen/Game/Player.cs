using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player : MapElement,IMoveable,IDestroyer
    {
        public Player() : base()
        { }
        public Player(char toDraw) : base(toDraw)
        { }
        public Player(char toDraw, Point location) : base(toDraw, location)
        { }
        public void MoveDown()
        {
            bool canMove = true;
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.Y - 1 == item.Location.Y)
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
