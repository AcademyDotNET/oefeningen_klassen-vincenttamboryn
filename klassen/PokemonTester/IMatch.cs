using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTester
{
    interface IMatch
    {
        public IPocketMonster myPokemon { get; }
        public IPocketMonster enemy { get; }
        public void BattleStart();
        public void WriteInfo();
    }
}
