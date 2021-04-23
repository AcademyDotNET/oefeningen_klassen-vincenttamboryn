using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DierenTuin
{
    abstract class Dier
    {
        public double Gewicht { get; set; }
        public string Naam { get; set; }
        public abstract void Zegt(); 
    }
}
