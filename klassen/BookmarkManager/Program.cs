using System;
using System.Diagnostics;

namespace BookmarkManager
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfBookmarks = Convert.ToInt32(GiveNumber("int","How many bookmarks would you like to make?",0));
            BookMark[] arrayBookmarks = new BookMark[numberOfBookmarks];
            for (int i = 0; i < numberOfBookmarks; i++)
            {
                arrayBookmarks[i] = new BookMark();
            }
            foreach (var item in arrayBookmarks)
            {
                CheckAndCreateURL(item);
            }
            Menu(arrayBookmarks);
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
        static void CheckAndCreateURL(BookMark site)
        {
            Console.WriteLine("What is the name of the next website?");
            site.Naam = Console.ReadLine();
            bool result = false;
            string url;
            do
            {
                Console.WriteLine($"What is the URL of {site.Naam}?");
                url = Console.ReadLine();

                //uri... checks if a url is valid (as found on stack overflow) only full urls will be accepted, so https://google.com, but not google.com
                Uri uriResult;
                result = Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            } while (!result);
            site.URL = url;
        }
        static void Menu(BookMark[]websites)
        {
            Console.WriteLine($"which website would you like to open?");
            for (int i = 0; i < websites.Length; i++)
            {
                Console.WriteLine($"{i+1}. {websites[i].Naam}");
            }
            int input = Convert.ToInt32(GiveNumber("int", "", 1, websites.Length+1));
            Console.WriteLine($"Now opening website {websites[input-1].Naam}");
            websites[input-1].OpenSite();
        }

    }
}
