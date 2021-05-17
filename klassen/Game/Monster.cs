using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Monster : MapElement,IMoveable,IDestroyer
    {
        public Monster() : base('M')
        { drawColor = ConsoleColor.Red; }
        public Monster(ICoordinates location) : base('M', location)
        { drawColor = ConsoleColor.Red; }
        public Monster(char toDraw) : base(toDraw)
        { drawColor = ConsoleColor.Red; }
        public Monster(char toDraw, ICoordinates location) :base(toDraw, location)
        { drawColor = ConsoleColor.Red; }

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
                this.Location.X -= 1;
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
        public virtual bool ItemLeft()
        {
            foreach (var item in MapElement.allElements)
            {
                if (item is IPlayerCharacter)
                {
                    if (this.Location.X - 1 == item.Location.X && this.Location.Y == item.Location.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public virtual void Shoot()
        {
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.X - 1 == item.Location.X && this.Location.Y == item.Location.Y && item is IPlayerCharacter)
                {
                    item.Die();
                    return;
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
