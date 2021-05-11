using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTester
{
    class ConsoleInputLogger:IInput
    {
        public string InputLog()
        {
            return Console.ReadLine();
        }
    }
}
