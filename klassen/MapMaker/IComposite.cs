using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    interface IComposite
    {
        void UpdateElements(Point offset);
    }
}
