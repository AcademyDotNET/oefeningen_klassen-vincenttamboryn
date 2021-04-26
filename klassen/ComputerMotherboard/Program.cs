using System;

namespace ComputerMotherboard
{
    class Program
    {
        static void Main(string[] args)
        {
            Motherboard newMotherboard = new Motherboard("MAG_X570_Tomahawk_Wifi",4,2);
            newMotherboard.TestMotherboard();
            newMotherboard.CPU.Name = "AMD Ryzen 5 5600x";
            AGPSlot nvidia3070 = new AGPSlot();
            nvidia3070.Name = "GeForce RTX 3070";
            newMotherboard.GPU = nvidia3070;
            newMotherboard.rAmS[0].Name = newMotherboard.rAmS[1].Name = "Trident Z RGB";
            newMotherboard.mDot2S[0].Name = "Samsung 970 Evo";
            newMotherboard.TestMotherboard();
            Console.WriteLine(newMotherboard.ToString());
        }
    }
}
