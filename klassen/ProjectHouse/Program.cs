using System;

namespace ProjectHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Room[] forHouse1 = new Room[4];
            forHouse1[0] = new BathRoom();
            forHouse1[1] = new LivingRoom(true);
            forHouse1[2] = new Hallway(5);
            forHouse1[3] = new Room();

            Room[] forHouse2 = new Room[4];
            forHouse2[0] = new BathRoom();
            forHouse2[1] = new LivingRoom(false);
            forHouse2[2] = new Hallway(3);
            forHouse2[3] = new Room();

            Room[] forHouse3 = new Room[6];
            forHouse3[0] = new BathRoom();
            forHouse3[1] = new LivingRoom(true);
            forHouse3[2] = new Hallway(10);
            forHouse3[3] = new Room();
            forHouse3[4] = new Room();
            forHouse3[5] = new Room();

            House house1 = new House(forHouse1);
            House house2 = new House(forHouse2);
            House house3 = new House(forHouse3);

            Console.WriteLine($"house 1 costs {house1.CalculatePrice()}");
            Console.WriteLine($"house 2 costs {house2.CalculatePrice()}");
            Console.WriteLine($"house 3 costs {house3.CalculatePrice()}");

            house1.AddRoom(new BathRoom());
            Console.WriteLine($"With the extra bathroom house 1 now costs {house1.CalculatePrice()}");
        }
    }
}
