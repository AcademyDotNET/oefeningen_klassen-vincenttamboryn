using System;
using System.Collections.Generic;
namespace PoliticalSituation
{
    class Program
    {
        static void Main(string[] args)
        {
            Country belgium = new Country(true,true,2);
            belgium.YearPassed();


            Country newCountry = new Country(false, false, 0);
            List<Minister> ministersOfMyCountry = new List<Minister>();
            ministersOfMyCountry.Add(new Minister());
            ministersOfMyCountry.Add(new Minister());
            ministersOfMyCountry.Add(new Minister());
            ministersOfMyCountry.Add(new Minister());
            ministersOfMyCountry[0].Name = "Bart";
            ministersOfMyCountry[1].Name = "Henk";
            ministersOfMyCountry[2].Name = "Bob";
            ministersOfMyCountry[3].Name = "Bert";
            President presOfMyCountry = new President();
            presOfMyCountry.Name = "John";

            newCountry.MakeGovernment(presOfMyCountry,ministersOfMyCountry);
            newCountry.YearPassed();
            Console.WriteLine(newCountry.ToString());

            newCountry.YearPassed();
            newCountry.YearPassed();
            newCountry.YearPassed();
            newCountry.YearPassed();
            Console.WriteLine(newCountry.ToString());
        }
    }
}
