using System;
using System.Collections.Generic;
namespace Speelkaarten
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Speelkaart> cards = new List<Speelkaart>();
            foreach (var item in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                for (int i = 1; i < 14; i++)
                {
                    cards.Add(new Speelkaart(item,(i)));
                }
            }
            Random rNG = new Random();
            Console.WriteLine("i'll show you a random card");
            int randomcard = rNG.Next(0, cards.Count);
            Console.WriteLine($"{cards[randomcard].Suits} {cards[randomcard].Number}");
            cards.RemoveAt(randomcard);
        }
    }
}
