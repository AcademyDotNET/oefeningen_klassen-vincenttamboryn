using System;

namespace Nummers
{
    class Program
    {
        static void Main(string[] args)
        {
            Nummers myNumbers = new Nummers();
            myNumbers.Getal1 = 5;
            myNumbers.Getal2 = 10;
            myNumbers.Som();
            Console.WriteLine("getallen:" + myNumbers.Getal1 + ", " + myNumbers.Getal2);
            Console.WriteLine("Som = " + myNumbers.Som());
            Console.WriteLine("Verschil = " + myNumbers.Verschil());
            Console.WriteLine("Product = " + myNumbers.Product());
            Console.WriteLine("Quotient = " + myNumbers.Quotient());
        }
    }
}
