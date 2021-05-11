using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTester
{
    static class PocketMonsterFactory
    {
        public static IPocketMonster Build(string classname, Object[] args)
        {
            var y = Type.GetType($"PokemonTester.{classname}");
            IPocketMonster vehicle = (IPocketMonster)Activator.CreateInstance(y, args);
            return vehicle;
        }
    }
}
