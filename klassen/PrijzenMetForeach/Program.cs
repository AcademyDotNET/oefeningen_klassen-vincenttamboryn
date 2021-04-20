using System;

namespace PrijzenMetForeach
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] prices = new double[20];
            for (int i = 0; i < prices.Length; i++)
            {
                prices[i] = GiveNumber("+", $"give price number {i+1}");
            }
            double sum = 0;
            Console.WriteLine("\nthese prices were higher than 5");
            foreach (var item in prices)
            {
                if (item >= 5.00)
                {
                    Console.WriteLine(item);
                }
                sum += item;
            }
            Console.WriteLine($"\nThe mean price is {sum/prices.Length}");
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
    }
}
