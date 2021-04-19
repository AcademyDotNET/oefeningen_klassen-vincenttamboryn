using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetlat
{
    class Meetlat
    {
        public Meetlat(double lengteM)
        {
            beginLengte = lengteM;
        }
        private double beginLengte;
        public double BeginLengte
        {
            set
            {
                beginLengte = value;
            }

        }
        public double LengteInCm
        {
            get
            {
                return beginLengte * 100;
            }
        }
        public double LengteInM
        {
            get
            {
                return beginLengte;
            }
        }
        public double LengteInKm
        {
            get
            {
                return beginLengte / 1000;
            }
        }
        public double LengteInVoet
        {
            get
            {
                return beginLengte * 3.2808;
            }
        }
    }
}
