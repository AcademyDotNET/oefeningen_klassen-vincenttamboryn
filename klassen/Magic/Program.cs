using System;

namespace Magic
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager myHand = new Manager();
            myHand.DrawOpeningHand();
            try
            {
                foreach (var cards in myHand.cards)
                {
                    Console.WriteLine($"In my hand I have a {cards.ToString()} card");
                }
                myHand.cards[2].Use();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
