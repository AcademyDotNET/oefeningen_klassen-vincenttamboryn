using System;
using System.Collections.Generic;
namespace Speelkaarten
{
    class Program
    {
        static void Main(string[] args)
        {
            GeschudPakKaarten pak = new GeschudPakKaarten();
            BlackJack(pak);
        }
        static void BlackJack(GeschudPakKaarten pak)
        {
            List<Speelkaart> myHand = new List<Speelkaart>();
            List<Speelkaart> dealerHand = new List<Speelkaart>();
            //starting hands
            for (int i = 0; i < 2; i++)
            {
                myHand.Add(pak.GeschudPak.Pop());
                dealerHand.Add(pak.GeschudPak.Pop());
            }
            string anotherCard = "";
            do
            {
                WriteHand(myHand, "Your hand");
                WriteHand(dealerHand, "Dealers hand");

                Console.WriteLine("Would you like another card? q to stop.");
                anotherCard = Console.ReadLine();

                //you draw
                if (anotherCard != "q")
                {
                    myHand.Add(pak.GeschudPak.Pop());
                    Console.WriteLine($"You drew a {myHand[myHand.Count-1]}");
                }

                //dealer draws
                if (HandValue(dealerHand) < 15)
                {
                    dealerHand.Add(pak.GeschudPak.Pop());
                    Console.WriteLine($"The dealer drew a {dealerHand[dealerHand.Count - 1]}");
                }

            } while (anotherCard!= "q" || HandValue(myHand)>21 || HandValue(dealerHand) > 21);

            //dealer can keep drawing if need be
            do
            {
                if (HandValue(dealerHand) < 15)
                {
                    dealerHand.Add(pak.GeschudPak.Pop());
                    Console.WriteLine($"The dealer drew a {dealerHand[dealerHand.Count - 1]}");
                }
            } while (HandValue(dealerHand) < 15);

            //who won/did you get blackjack
            Console.WriteLine($"You had; {HandValue(myHand)}\nThe dealer had had; {HandValue(dealerHand)}");
            if (HandValue(myHand) > 21)
            {
                Console.WriteLine("BUSTED! You lost!");
            }
            if (HandValue(myHand) == 21)
            {
                Console.WriteLine("Blackjack! Well Done!");
            }
            if (HandValue(myHand) > HandValue(dealerHand))
            {
                Console.WriteLine("Congratulations! You Won!");
            }
            else if (HandValue(myHand) < HandValue(dealerHand))
            {
                Console.WriteLine("You lost!");
            }
            else
            {
                Console.WriteLine("It's a draw.");
            }
        }
        static int HandValue(List<Speelkaart> myHand)
        {
            int sum = 0;
            for (int i = 0; i < myHand.Count; i++)
            {
                if (myHand[i].Number > 10)
                {
                    sum += 10;
                }
                else
                {
                    sum += myHand[i].Number;
                }
            }
            for (int i = 0; i < myHand.Count; i++)
            {
                if (myHand[i].Number == 1 && (sum + 10)<=21)
                {
                    sum += 10;
                } 
            }
            return sum;
        }
        static void WriteHand(List<Speelkaart> myHand, string whoseHand)
        {
            Console.WriteLine($"{whoseHand}:");
            foreach (var item in myHand)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"Value:{HandValue(myHand)}\n");

        }
    }
}
