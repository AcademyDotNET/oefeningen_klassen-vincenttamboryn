using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSituation
{
    class President:Minister
    {
        public int counter = 4;
        public void YearPassed()
        {
            counter--;
        }
    }
}
