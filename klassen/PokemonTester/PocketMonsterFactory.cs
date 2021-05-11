using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTester
{
    static class PocketMonsterFactory
    {
        public static IPocketMonster Build(string classname, Object[] constructorArguments)
        {
            var objectType = Type.GetType($"PokemonTester.{classname}");
            IPocketMonster pocketMonster = (IPocketMonster)Activator.CreateInstance(objectType, constructorArguments);
            return pocketMonster;
        }
    }
}
