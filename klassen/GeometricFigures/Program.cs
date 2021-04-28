using System;
using System.Collections.Generic;
namespace GeometricFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            //GeometricFigure[] array = new GeometricFigure[4];
            //array[0] = new Driehoek(5, 2);
            //array[1] = new Rechthoek(5, 6);
            //array[2] = new Vierkant(3, 2);
            //array[3] = new Vierkant(4);
            //foreach (var item in array)
            //{
            //    Console.WriteLine($"{item.GetType()} heeft een oppervlakte van {item.BerekenOppervlakte()}");
            //}

            Random rand = new Random();
            List<Rechthoek> figuren = new List<Rechthoek>();
            for (int i = 0; i < 10; i++)
            {
                figuren.Add(new Rechthoek(rand.Next(1,10), rand.Next(1, 10)));
            }
            figuren.Sort((r1,r2) => r1.Oppervlakte.CompareTo(r2.Oppervlakte));
            foreach (var item in figuren)
            {
                Console.WriteLine($"{item.Oppervlakte}");
            }
        }
    }
}
