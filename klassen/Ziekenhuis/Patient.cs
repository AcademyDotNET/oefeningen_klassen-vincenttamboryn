using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ziekenhuis
{
    class Patient
    {
        public string name;
        public int hoursInTheHospital;
        public virtual double BerekenKost()
        {
            return 50 + 20 * hoursInTheHospital;
        }
        public void ToonInfo() 
        {
            Console.WriteLine($"Patient {name}");
            Console.WriteLine($"Total time in the hospital {hoursInTheHospital}");
            Console.WriteLine($"Total cost:{BerekenKost()}");
        }
    }
}
