using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Net;

namespace PokemonTester
{
    class CSV_reader
    {
        const string delimeter = ",";
        public static string[,] ReadCsv()
        {
            StreamReader streamReader;
            try
            {
                //streamReader = new StreamReader(@"D:\downloads\pokemon.CSV");
                streamReader = new StreamReader(@"C:\Users\vincent\Documents\Pokemon.csv");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception opgetreden");
                Console.WriteLine("Message:" + e.Message);
                throw;
            }
            {
                int csvlenght = 13;
                int csvhight = 801;

                string[,] values = new string[csvhight, csvlenght];
                string[] linesplit;

                for (int j = 0; j < csvhight; j++)
                {
                    string line = streamReader.ReadLine();
                    linesplit = line.Split(',');
                    for (int i = 0; i < linesplit.Length; i++)
                    {
                        values[j, i] = linesplit[i];
                    }
                }
                return values;
            }
        }
        public static string[,] ReadCsvWeb()
        {
            string result = "";
            try
            {
                using (var client = new WebClient())
                {
                    result = client.DownloadString(@"https://gist.githubusercontent.com/armgilles/194bcff35001e7eb53a2a8b441e8b2c6/raw/92200bc0a673d5ce2110aaad4544ed6c4010f687/pokemon.csv");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            string[] lines = result.Split("\n");
            string[] lenght = lines[0].Split(',');
            string[,] values = new string[lines.Length-1, lenght.Length];
            for (int j = 0; j < values.GetLength(0); j++)
            {
                string[] data = lines[j].Split(',');
                for (int i = 0; i < values.GetLength(1); i++)
                {
                    values[j, i] = data[i];
                }
            }
            return values;
        }
    }
}
