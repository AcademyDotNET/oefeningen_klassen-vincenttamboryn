using System;

namespace Figuren
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle driehoek1 = new Triangle();
            Triangle driehoek2 = new Triangle();
            Rectangle rechthoek1 = new Rectangle();
            Rectangle rechthoek2 = new Rectangle();
            driehoek1.Basis = 5;
            driehoek1.Hoogte = 3;

            driehoek2.Basis = 2;
            driehoek2.Hoogte = 6;

            rechthoek1.Basis = 8;
            rechthoek1.Hoogte = 4;

            rechthoek2.Basis = 3;
            rechthoek2.Hoogte = 1;

            driehoek1.ToonOppervlakte("driehoek1");
            driehoek2.ToonOppervlakte("driehoek2");
            rechthoek1.ToonOppervlakte("rechthoek1");
            rechthoek2.ToonOppervlakte("rechthoek2");

        }
    }
}
