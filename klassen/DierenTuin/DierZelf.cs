using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DierenTuin
{
    class DierZelf:Dier
    {
        public string Geluid { get; set; }
        public DierZelf(string name, string sound, double weight)
        {
            Geluid = sound;
            Gewicht = weight;
            Naam = name;
        }
        public override void Zegt()
        {
            Console.WriteLine($"The {Naam} goes {Geluid}");
        }
        public override string ToString()
        {
            return Naam;
        }
    }
}
