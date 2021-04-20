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

    }
}
