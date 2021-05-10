using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTester
{
    interface IPocketMonster
    {
        public void LevelUp(int xLevels);
        public void ShowInfo();
        public string ToString();
        public bool Equals(object obj);
    }
}
