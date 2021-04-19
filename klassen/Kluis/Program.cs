using System;

namespace Kluis
{
    class Program
    {
        static void Main(string[] args)
        {
            DigitaleKluis kluis1 = new DigitaleKluis(3546);
            Console.WriteLine($"this safe is of level {kluis1.CodeLevel}");
            kluis1.Trycode(3756);
            kluis1.Trycode(3541);
            kluis1.Trycode(3256);
            kluis1.Trycode(3416);
            kluis1.Trycode(3546);

            DigitaleKluis kluis2 = new DigitaleKluis(3646);
            Console.WriteLine($"this safe is of level {kluis2.CodeLevel}");
            kluis2.Trycode(3756);
            kluis2.Trycode(3541);
            kluis2.Trycode(3256);
            kluis2.Trycode(3416);
            int a = kluis2.Code;
            Console.WriteLine($"is the code {a}?");
            kluis2.Trycode(a);
            kluis2.Trycode(3646);

            DigitaleKluis kluis3 = new DigitaleKluis(3646);
            Console.WriteLine($"this safe is of level {kluis3.CodeLevel}");
            kluis3.Trycode(3756);
            kluis3.Trycode(3541);
            kluis3.Trycode(3256);
            kluis3.Trycode(3416);
            kluis3.CanShowCode = true;
            int b = kluis3.Code;
            Console.WriteLine($"is the code {b}?");
            kluis3.Trycode(b);
        }
    }
}
