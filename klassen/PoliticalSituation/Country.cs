using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSituation
{
    class Country
    {
        private readonly int maxMinisters = 4;
        public President presidentOfThisCountry { get; set; } = null;
        public Minister primeMinisterOfThisCountry { get; set; } = null;
        public List<Minister> ministersOfThisCountry = new List<Minister>();
        public Country(bool hasPresident, bool hasPrimeMinister, int ministers)
        {
            if (hasPresident)
            {
                presidentOfThisCountry = new President();
            }
            if (hasPrimeMinister)
            {
                primeMinisterOfThisCountry = new Minister();
            }
            int numberOfMinisters = Math.Min(ministers, 4);
            for (int i = 0; i < numberOfMinisters; i++)
            {
                ministersOfThisCountry.Add(new Minister());
            }
        }
        public void MakeGovernment(President newPresident, List<Minister> newMinisters)
        {
            if (presidentOfThisCountry == null)
            {
                presidentOfThisCountry = newPresident;
                if (newMinisters.Count<1 || newMinisters.Count > 5)
                {
                    Console.WriteLine("list of ministers is too small or too large");
                    return;
                }
                primeMinisterOfThisCountry = newMinisters[0];
                ministersOfThisCountry.Clear();
                for (int i = 1; i < newMinisters.Count; i++)
                {
                    ministersOfThisCountry.Add(newMinisters[i]);
                }
            }
            else
            {
                Console.WriteLine("This country already has a government");
            }
        }
        public void YearPassed()
        {
            if (presidentOfThisCountry != null)
            {
                presidentOfThisCountry.YearPassed();
                if (presidentOfThisCountry.counter <= 0)
                {
                    DownWithTheGovernment();
                }
            }
        }
        private void DownWithTheGovernment()
        {
            presidentOfThisCountry = null;
            primeMinisterOfThisCountry = null;
            ministersOfThisCountry.Clear();
        }
        public override string ToString()
        {
            if (presidentOfThisCountry == null)
            {
                if (primeMinisterOfThisCountry == null)
                {
                    return $"this country has {ministersOfThisCountry.Count()} ministers";
                }
                return $"the prime minister of this country is {primeMinisterOfThisCountry.Name} it has {ministersOfThisCountry.Count()} ministers";
            }
            return $"The president of this country is {presidentOfThisCountry.Name}, the prime minister is {primeMinisterOfThisCountry.Name}, it has {ministersOfThisCountry.Count()} ministers";
        }
    }
}
