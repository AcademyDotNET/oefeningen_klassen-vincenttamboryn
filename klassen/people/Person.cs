using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace people
{
    class Person
    {
        public Head ThisPersonsHead { get; set; }
        public Hand LeftHand { get; set; }
        public Hand RightHand { get; set; }
        public Leg LeftLeg { get; set; }
        public Leg RightLeg { get; set; }
        Person()
        {
            ThisPersonsHead = new Head();
            LeftHand = new Hand();
            RightHand = new Hand();
            LeftLeg = new Leg();
            RightLeg = new Leg();
        }
    }
}
