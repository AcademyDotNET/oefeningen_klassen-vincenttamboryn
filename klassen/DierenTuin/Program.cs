using System;
using System.Collections.Generic;

namespace DierenTuin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dier> dierenRijk = DierenAanmaken();
            Menu(dierenRijk);

        }
        static double GiveNumber(string test, string question, double minValue = double.NegativeInfinity, double maxvalue = double.PositiveInfinity)
        {
            string numberString;
            do
            {
                Console.WriteLine(question);
                numberString = Console.ReadLine();
            } while (!(Microsoft.VisualBasic.Information.IsNumeric(numberString)));
            double number = Convert.ToDouble(numberString);
            if (number < minValue || number > maxvalue)
            {
                return GiveNumber(test, question, minValue, maxvalue);
            }
            else
            {
                if (test == "+")
                {
                    if (number >= 0)
                    {
                        return number;
                    }
                    else
                    {
                        number = GiveNumber("+", question, minValue, maxvalue);
                        return number;
                    }
                }
                else if (test == "-")
                {
                    if (number < 0)
                    {
                        return number;
                    }
                    else
                    {
                        number = GiveNumber("+", question, minValue, maxvalue);
                        return number;
                    }
                }
                else if (test == "int")
                {
                    char[] komma = { ',' };
                    if (numberString.IndexOfAny(komma) == -1)
                    {
                        return number;
                    }
                    else
                    {
                        number = GiveNumber("int", question, minValue, maxvalue);
                        return number;
                    }
                }
                else
                {
                    return number;
                }
            }

        }
        static List<Dier> DierenAanmaken()
        {
            List<Dier> dierenLijst = new List<Dier>();
            string name = "";
            string sound = "";
            double weight = 0;
            do
            {
                Console.WriteLine("What animal would you like to add? q to stop");
                name = Console.ReadLine();
                if (name != "q" && name != "Q")
                {
                    Console.WriteLine($"What sound does the {name} make?");
                    sound = Console.ReadLine();
                    weight = GiveNumber("+", $"What is the avarage weight of the {name} (in kg)?", 0);
                    dierenLijst.Add(new DierZelf(name, sound, weight));
                }
            } while (name != "q" && name != "Q");
            return dierenLijst;
        }
        static void Menu(List<Dier>dieren)
        {
            Console.WriteLine($"What would you like to do?\n\ta. Delete an animal\n\tb. Calculate the avarage weight of all animals\n\tc. Let all the animals speak\n\td. Quit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "a":
                    DeleteAnimal(dieren);
                    break;
                case "b":
                    CalculateAvarageWeight(dieren);
                    break;
                case "c":
                    LetAllAnimalsSpeak(dieren);
                    Console.WriteLine();
                    break;
                case "d":
                    return;
                default:
                    break;
            }
            Menu(dieren);
        }
        static void DeleteAnimal(List<Dier> dieren)
        {
            Console.WriteLine("What animal do you want to delete?");
            string input = Console.ReadLine();
            foreach (Dier dier in dieren)
            {
                if (dier.Naam == input)
                {
                    dieren.Remove(dier);
                    Console.WriteLine($"{dier.Naam} was succesfully removed\n");
                    return;
                }
            }
            Console.WriteLine("No such animal was found");
        }

        static void CalculateAvarageWeight(List<Dier> dieren)
        {
            double totalWeight = 0;
            foreach (var dier in dieren)
            {
                totalWeight += dier.Gewicht;
            }
            Console.WriteLine($"The avarage weight of all the currently existing animals is {totalWeight/dieren.Count} kg\n");
        }
        static void LetAllAnimalsSpeak(List<Dier> dieren)
        {
            foreach (var dier in dieren)
            {
                dier.Zegt();
            }
        }
    }
}
