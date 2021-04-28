using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class Card
    {
        public int cost;
        public Card()
        {
            cost = 2;
        }
        public void Use()
        {
            Console.WriteLine($"You use this {this.ToString()} card");
            //do something...
        }
    }
}
