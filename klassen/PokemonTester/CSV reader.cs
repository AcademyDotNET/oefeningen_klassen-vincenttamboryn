using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
namespace PokemonTester
{
    class CSV_reader
    {
        const string delimeter = ",";
        public static string[,] readCsv()
        {
            //StreamReader streamReader = new StreamReader(@"D:\downloads\pokemon.CSV");
            StreamReader streamReader = new StreamReader(@"C:\Users\vincent\Documents\Pokemon.csv");
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

    }
}
