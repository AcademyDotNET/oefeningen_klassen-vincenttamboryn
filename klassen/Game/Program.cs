using System;
using System.Collections.Generic;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager firstLevel = new(30, 20, 15, 25);
            firstLevel.Start();
        }
    }
}
