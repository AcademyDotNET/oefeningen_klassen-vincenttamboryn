using System;

namespace GeometricFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            GeometricFigure[] array = new GeometricFigure[4];
            array[0] = new Driehoek(5, 2);
            array[1] = new Rechthoek(5, 6);
            array[2] = new Vierkant(3, 2);
            array[3] = new Vierkant(4);
            foreach (var item in array)
            {
                Console.WriteLine($"{item.GetType()} heeft een oppervlakte van {item.BerekenOppervlakte()}");
            }
        }
    }
}
