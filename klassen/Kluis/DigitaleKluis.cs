using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kluis
{
    class DigitaleKluis
    {
        private int code;
        private bool canShowCode;
        private int cheats = 0;
        private int tries = 0;
        public DigitaleKluis(int passnumber)
        {
            code = passnumber;
        }
        
        public bool CanShowCode
        {
            get { return canShowCode; }
            set { canShowCode = value; }
        }
        public int CodeLevel
        {
            get { return (code/1000); }
        }
        public int Code
        {
            get 
            {
                if (CanShowCode)
                {
                    return code;
                }
                else
                {
                    cheats++;
                    return -666;
                }
            }
            private set { code = value; }
        }
        public bool Trycode(int guess)
        {
            tries++;
            if (guess == code)
            {
                Console.WriteLine($"You guessed correctly! {code} was the correct code! It only took you {tries} guesses");
                if (cheats > 0)
                {
                    Console.WriteLine($"You are a cheater, so this achievement is mostly meaningless");
                }
                return true;
            }
            else
            {
                Console.WriteLine($"You guessed incorrectly. {guess} was not correct code. {tries} guesses so far");
                return false;
            }
        }
    }
}
