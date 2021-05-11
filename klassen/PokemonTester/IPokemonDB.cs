using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTester
{
    interface IPokemonDB
    {
        public IPocketMonster[] Dex { get; }
        public IPocketMonster[] AllPokemonsInitialiser();
        public IPocketMonster ChooseAPokemon();
        public void ListAllPokemon();
        public void WritePokemon();
    }
}
