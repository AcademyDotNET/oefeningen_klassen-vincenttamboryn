using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports
{
    interface ISpeler
    {
        public void ThrowBall();
        public void DrinkBeer();
        public static void SimulateGame(ISpeler player)
        { }
        public static void SimulateCompertion(ISpeler player1, ISpeler player2)
        { }
        public static ISpeler BestPlayer(ISpeler player1, ISpeler player2)
        {
            return player1;
        }
    }
}
