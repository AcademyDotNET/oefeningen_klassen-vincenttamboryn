using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTester
{
    class ConsoleLogger:IOutput
    {
        public void Log(string message = "")
        {
            Console.WriteLine(message);
        }
    }
}
