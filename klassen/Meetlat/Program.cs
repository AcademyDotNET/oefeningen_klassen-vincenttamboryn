using System;

namespace Meetlat
{
    class Program
    {
        static void Main(string[] args)
        {
            Meetlat mijnLat = new Meetlat(2.5);
            Console.WriteLine($"{mijnLat.LengteInM} meter is {mijnLat.LengteInVoet} voet.");
        }
    }
}
