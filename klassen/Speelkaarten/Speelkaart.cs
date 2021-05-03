using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speelkaarten
{
    public enum Suit {Spades, Clubs, Diamonds, Hearts }
    class Speelkaart
    {
        public Speelkaart(Suit suit, int number)
        {
            Suits = suit;
            Number = number;
        }
        private int _Number;
        private Suit _Suits;
        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        public Suit Suits
        {
            get { return _Suits; }
            set { _Suits = value; }
        }
        public override string ToString()
        {
            if (Number == 1)
            {
                return $"Ace of {Suits}";
            }
            else if (Number == 11)
            {
                return $"Jack of {Suits}";
            }
            else if (Number == 12)
            {
                return $"Queen of {Suits}";
            }
            else if (Number == 13)
            {
                return $"King of {Suits}";
            }
            else
            {
                return $"{Number} of {Suits}";
            }

        }
    }
}
