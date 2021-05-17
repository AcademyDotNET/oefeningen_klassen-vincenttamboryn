using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class RockDestroyer : Monster,IDestroyer
    {
        public RockDestroyer() : base('D')
        { drawColor = ConsoleColor.DarkRed; }
        public RockDestroyer(Point location) : base('D', location)
        { drawColor = ConsoleColor.DarkRed; }
        public override void Shoot()
        {
            foreach (var item in MapElement.allElements)
            {
                if (this.Location.X - 1 == item.Location.X && this.Location.Y == item.Location.Y)
                {
                    item.Die();
                    return;
                }
            }
        }
        public override bool ItemLeft()
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
