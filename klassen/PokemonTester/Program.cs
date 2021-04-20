using System;
using System.Linq;


namespace PokemonTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokemon.NoLevelingAllowed = false;
            Random rNG = new Random();
            Pokemon[] pokedex = AllPokemonsInitialiser();


            Pokemon myPokemon = ChooseAPokemon(pokedex);
            Pokemon enemy = pokedex[rNG.Next(0,pokedex.Length)];
            Pokemon Poke3 = new Pokemon { Name = "Pikachu", Base_HP = 35, Base_Attack = 55, Base_Defense = 40, Base_SpecialAttack = 50, Base_SpecialDefense = 50, Base_Speed = 90 };

            myPokemon.LevelUp(49);
            enemy.LevelUp(49);

            myPokemon.ShowInfo();
            enemy.ShowInfo();

            Console.WriteLine("ready to battle?");
            Console.ReadLine();

            Pokemon.Battle(myPokemon, enemy);


        }
        static Pokemon PokemonInitialiser()
        {
            Pokemon pokemon1 = new Pokemon();

            Console.WriteLine("Which pokemon would you like to create? ");
            string name = Console.ReadLine();

            pokemon1.Name = name;
            pokemon1.Base_HP = Convert.ToInt32(GiveNumber("int", "What is the base HP of this pokemon?", 0, 255));
            pokemon1.Base_Attack = Convert.ToInt32(GiveNumber("int", "What is the base attack of this pokemon?", 0, 255)); ;
            pokemon1.Base_Defense = Convert.ToInt32(GiveNumber("int", "What is the base defense of this pokemon?", 0, 255)); ;
            pokemon1.Base_SpecialAttack = Convert.ToInt32(GiveNumber("int", "What is the base special attack of this pokemon?", 0, 255)); ;
            pokemon1.Base_SpecialDefense = Convert.ToInt32(GiveNumber("int", "What is the base special defense of this pokemon?", 0, 255)); ;
            pokemon1.Base_Speed = Convert.ToInt32(GiveNumber("int", "What is the base speed of this pokemon?", 0, 255)); ;
            int levelUps = Convert.ToInt32(GiveNumber("int", "which level do you want this pokemon to be?", 1, 100));
            if (levelUps > 1)
            {
                pokemon1.LevelUp(levelUps - 1);
            }
            return pokemon1;
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
        static Pokemon[] AllPokemonsInitialiser()
        {
            string[,] stats = CSV_reader.readCsv();
            Pokemon[] arrayOfPokemons = new Pokemon[stats.GetLength(0) - 1];
            for (int i = 0; i < arrayOfPokemons.Length; i++)
            {
                arrayOfPokemons[i] = new Pokemon(stats[i + 1, 1], Convert.ToInt32(stats[i + 1, 5]), Convert.ToInt32(stats[i + 1, 6]), Convert.ToInt32(stats[i + 1, 7]), Convert.ToInt32(stats[i + 1, 8]), Convert.ToInt32(stats[i + 1, 9]), Convert.ToInt32(stats[i + 1, 10]));
            }
            return arrayOfPokemons;
        }
        static Pokemon ChooseAPokemon(Pokemon[]dex)
        {
            bool condition = true;
            int index = 0;
            do
            {
                Console.WriteLine("which pokemon would you like to use?");
                string input = Console.ReadLine();
                input.ToLower();
                string pokemon = input[0].ToString().ToUpper() + input.Substring(1);
                for (int i = 0; i < dex.Length; i++)
                {
                    if (dex[i].Name == pokemon)
                    {
                        index = i;
                        condition = false;
                    }
                }
                if (condition)
                {
                    Console.WriteLine("This is not a valid pokemon, try again.\n Would you like a list of all available pokemon?(yes or no)");
                    string yesNo = Console.ReadLine().ToLower();
                    switch (yesNo)
                    {
                        case "yes":
                            ListAllPokemon(dex);
                            break;
                        default:
                            break;
                    }
                }
            } while (condition);
            return dex[index];
        }
        static void ListAllPokemon(Pokemon[]dex)
        {
            Console.WriteLine();
            for (int i = 0; i < dex.Length; i++)
            {
                Console.WriteLine(dex[i].Name);
            }
            Console.WriteLine();
        }
    }
}
