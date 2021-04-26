using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMotherboard
{
    class Motherboard
    {
        public string Name { get; set; }
        public AGPSlot GPU { get; set; }
        public CPUSlot CPU { get; set; }
        public RAMSlots[] rAmS;
        public Mdot2Slot[] mDot2S;
        public Motherboard(string name, int ramSlots, int mDot3Slots)
        {
            Name = name;
            GPU = new AGPSlot();
            CPU = new CPUSlot();
            rAmS = new RAMSlots[ramSlots];
            mDot2S = new Mdot2Slot[mDot3Slots];
            for (int i = 0; i < rAmS.Length; i++)
            {
                rAmS[i] = new RAMSlots();
            }
            for (int i = 0; i < mDot2S.Length; i++)
            {
                mDot2S[i] = new Mdot2Slot();
            }
        }
        public void TestMotherboard()
        {
            if (GPU.Name == null)
            {
                Console.WriteLine($"A GPU has not yet been installed.");
            }
            if (CPU.Name == null)
            {
                Console.WriteLine($"A CPU has not yet been installed.");
            }
            for (int i = 0; i < rAmS.Length; i++)
            {
                if (rAmS[i].Name == null)
                {
                    Console.WriteLine($"RAMSlot{i} has not yet been filled.");
                }
            }
            for (int i = 0; i < mDot2S.Length; i++)
            {
                if (mDot2S[i].Name == null)
                {
                    Console.WriteLine($"M.2 Slot{i} has not yet been filled.");
                }
            }
            Console.WriteLine();
        }
        public override string ToString()
        {
            string output = $"Motherboard = {this.Name}\n";
            if (GPU.Name != null)
            {
                output += $"GPU = {GPU.Name}\n";
            }
            if (CPU.Name != null)
            {
                output += $"CPU = {CPU.Name}\n";
            }
            for (int i = 0; i < rAmS.Length; i++)
            {
                if (rAmS[i].Name != null)
                {
                    output += $"RAMSlot{i} = {rAmS[i].Name}\n";
                }
            }
            for (int i = 0; i < mDot2S.Length; i++)
            {
                if (mDot2S[i].Name != null)
                {
                    output += $"M.2 Slot{i} = {mDot2S[i].Name}\n";
                }
            }
            return output;
        }
    }
}
