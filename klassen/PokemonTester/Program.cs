using System;
using System.Linq;


namespace PokemonTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Battler competition = new Battler(new ConsoleLogger());
            competition.BattleStart();
        }
    }
}
