using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports
{
    class BeerPongPlayer
    {
        public enum Beers { Jupiler, Stella, Cara, Hopfil, Buval, Duvel, Crystal }
        private string name;
        private double accuracy;
        private bool isDrunk;
        private string team;
        private int beersDrunk = 0;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != "")
                {
                    name = value;
                }
            }
        }
        public Beers FavouriteBeer { get; set; }
        public double Accuracy
        {
            get
            {
                return accuracy;
            }
            set
            {
                if (value <= 100 && value > 0 && Microsoft.VisualBasic.Information.IsNumeric(value))
                {
                    accuracy = value;
                }
            }
        }
        public bool IsDrunk
        {
            get
            {
                return isDrunk;
            }
            set
            {
                if ((value == true) || (value == false))
                {
                    isDrunk = value;
                }
            }
        }
        public string Team
        {
            get
            {
                return team;
            }
            set
            {
                if (value != "")
                {
                    team = value;
                }
            }
        }

        public void StelIn(string name, Beers beer, double accuracy, bool isDrunk, string team)
        {
            Name = name;
            FavouriteBeer = beer;
            Accuracy = accuracy;
            IsDrunk = isDrunk;
            Team = team;
        }
        public void ThrowBall()
        {
            Random myGen = new Random();
            double rNG = myGen.Next(1, 101);
            if (accuracy >= rNG)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine($"{name} throws the ball");
                System.Threading.Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Score!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine($"{name} throws the ball");
                System.Threading.Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{name} missed!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void drinkBeer()
        {
            beersDrunk++;
            Random myGen = new Random();
            int rNG = myGen.Next(0, Math.Max(1, 12-beersDrunk));
            System.Threading.Thread.Sleep(500);
            if (rNG < 2)
            {
                isDrunk = true;
            }
            Console.WriteLine($"{name} drinks a beer. {name} has drunk {beersDrunk} beers. ");
            if (isDrunk)
            {
                Console.WriteLine($"{name} is drunk.");
            }
            Console.WriteLine("");
        }
    } 
} 
