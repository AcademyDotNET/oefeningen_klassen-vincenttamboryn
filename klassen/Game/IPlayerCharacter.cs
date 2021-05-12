using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IPlayerCharacter: IMoveable, IDestroyer
    {
        public int Lives { get; set; }
        public int Score { get; set; }
        public int LongRangeShots { get; set; }
        public void Move(ConsoleKeyInfo input);
        public void LongRangeShot();
    }
}
