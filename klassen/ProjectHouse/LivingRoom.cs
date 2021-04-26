using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHouse
{
    class LivingRoom : Room
    {
        public bool hasFireplace;
        public override double Price
        {
            get
            {
                if (hasFireplace)
                {
                    return 500;
                }
                return 300;
            }
        }
        public LivingRoom(bool firePlace) 
        {
            hasFireplace = firePlace;
        }
    }
}
