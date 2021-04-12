using System;

namespace RapportModule
{
    class Program
    {
        static void Main(string[] args)
        {
            Resultaat rapport = new Resultaat();
            rapport.Percentage = 65;
            rapport.PrintGraad();
        }
    }
}
