using System;


namespace PokemonTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokemon myPokemon = PokemonInitialiser();
            Pokemon enemy = PokemonInitialiser();

            myPokemon.ShowInfo();
            enemy.ShowInfo();

            Battle(myPokemon, enemy);
        }
        static Pokemon PokemonGenerator()
        {
            Pokemon pokemon2 = new Pokemon();
            Random randomGenerator = new Random();
            Console.WriteLine("what is the name of this pokemon");
            pokemon2.Name = Console.ReadLine();
            pokemon2.Base_HP = randomGenerator.Next(10,255);
            pokemon2.Base_Attack = randomGenerator.Next(10, 190);
            pokemon2.Base_Defense = randomGenerator.Next(10, 250);
            pokemon2.Base_SpecialAttack = randomGenerator.Next(10, 194);
            pokemon2.Base_SpecialDefense = randomGenerator.Next(10, 250);
            pokemon2.Base_Speed = randomGenerator.Next(10, 200);
            return pokemon2;
        }
        static Pokemon PokemonInitialiser()
        {
            Pokemon pokemon1 = new Pokemon();

            Console.WriteLine("Which pokemon would you like to create? ");
            string name = Console.ReadLine();

            pokemon1.Name = name;
            pokemon1.Base_HP = Convert.ToInt32(GiveNumber("int","What is the base HP of this pokemon?",0,255));
            pokemon1.Base_Attack = Convert.ToInt32(GiveNumber("int", "What is the base attack of this pokemon?", 0, 255)); ;
            pokemon1.Base_Defense = Convert.ToInt32(GiveNumber("int", "What is the base defense of this pokemon?", 0, 255)); ;
            pokemon1.Base_SpecialAttack = Convert.ToInt32(GiveNumber("int", "What is the base special attack of this pokemon?", 0, 255)); ;
            pokemon1.Base_SpecialDefense = Convert.ToInt32(GiveNumber("int", "What is the base special defense of this pokemon?", 0, 255)); ;
            pokemon1.Base_Speed = Convert.ToInt32(GiveNumber("int", "What is the base speed of this pokemon?", 0, 255)); ;
            int levelUps = Convert.ToInt32(GiveNumber("int", "which level do you want this pokemon to be?",1,100));
            if (levelUps > 1)
            {
               pokemon1.LevelUp(levelUps-1); 
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
        static int Battle(Pokemon poke1, Pokemon poke2)
        {
            //check if a pokemon is null
            if (poke1 == null && poke2 == null)
            {
                Console.WriteLine("no winner");
                return 0;
            }
            if (poke1 == null)
            {
                Console.WriteLine($"{poke2.Name} has won this battle!");
                return 2;
            }
            if (poke2 == null)
            {
                Console.WriteLine($"{poke1.Name} has won this battle!");
                return 1;
            }

            // initialise changeable values for the hp of both pokemon
            int health1 = poke1.Full_HP;
            int health2 = poke2.Full_HP;
            Random rNG = new Random();

            // attack sequance, fastest pokemon attacks first, then slowest, both attack with with their highest attack stat, minimum 2 damage, until one has 0 hp. 
            do
            {
                if (poke1.Full_Speed > poke2.Full_Speed)
                {
                    if (poke1.Full_Attack > poke1.Full_SpecialAttack)
                    {
                        health2 -= Convert.ToInt32((double)(((2 * poke1.Level / 5) * (poke1.Full_Attack / poke2.Full_Defense) / 50) + 2) * ((double)rNG.Next(85,100) /100));
                        Console.WriteLine($"{poke1.Name} hits {poke2.Name} with a regular attack!");
                        Console.WriteLine($"{poke2.Name} has {Math.Max(health2,0)} HP left\n");
                    }
                    else
                    {
                        health2 -= Convert.ToInt32((double)(((2 * poke1.Level / 5) * (poke1.Full_SpecialAttack / poke2.Full_SpecialDefense) / 50) + 2) *((double)rNG.Next(85, 100) / 100));
                        Console.WriteLine($"{poke1.Name} hits {poke2.Name} with a special attack!");
                        Console.WriteLine($"{poke2.Name} has {Math.Max(health2, 0)} HP left\n");
                    }
                    if (poke2.Full_Attack > poke2.Full_SpecialAttack)
                    {
                        health1 -= Convert.ToInt32((double)(((2 * poke2.Level / 5) * (poke2.Full_Attack / poke1.Full_Defense) / 50) + 2) *((double)rNG.Next(85, 100) / 100));
                        Console.WriteLine($"{poke2.Name} hits {poke1.Name} with a regular attack!");
                        Console.WriteLine($"{poke1.Name} has {Math.Max(health1, 0)} HP left\n");
                    }
                    else
                    {
                        health1 -= Convert.ToInt32((double)(((2 * poke2.Level / 5) * (poke2.Full_SpecialAttack / poke1.Full_SpecialDefense) / 50) + 2) *((double)rNG.Next(85, 100) / 100));
                        Console.WriteLine($"{poke2.Name} hits {poke1.Name} with a special attack!");
                        Console.WriteLine($"{poke1.Name} has {Math.Max(health1, 0)} HP left\n");
                    }
                }
                else
                {
                    if (poke2.Full_Attack > poke2.Full_SpecialAttack)
                    {
                        health1 -= Convert.ToInt32((double)(((2 * poke2.Level / 5) * (poke2.Full_Attack / poke1.Full_Defense) / 50) + 2) *((double)rNG.Next(85, 100) / 100));
                        Console.WriteLine($"{poke2.Name} hits {poke1.Name} with a regular attack!");
                        Console.WriteLine($"{poke1.Name} has {Math.Max(health1, 0)} HP left\n");
                    }
                    else
                    {
                        health1 -= Convert.ToInt32((double)(((2 * poke2.Level / 5) * (poke2.Full_Attack / poke1.Full_Defense) / 50) + 2) *((double)rNG.Next(85, 100) / 100));
                        Console.WriteLine($"{poke2.Name} hits {poke1.Name} with a special attack!");
                        Console.WriteLine($"{poke1.Name} has {Math.Max(health1, 0)} HP left\n");
                    }
                    if (poke1.Full_Attack > poke1.Full_SpecialAttack)
                    {
                        health2 -= Convert.ToInt32((double)(((2 * poke1.Level / 5) * (poke1.Full_Attack / poke2.Full_Defense) / 50) + 2) *((double)rNG.Next(85, 100) / 100));
                        Console.WriteLine($"{poke1.Name} hits {poke2.Name} with a regular attack!");
                        Console.WriteLine($"{poke2.Name} has {Math.Max(health1, 0)} HP left\n");
                    }
                    else
                    {
                        health2 -= Convert.ToInt32((double)(((2 * poke1.Level / 5) * (poke1.Full_SpecialAttack / poke2.Full_SpecialDefense) / 50) + 2) *((double)rNG.Next(85, 100) / 100));
                        Console.WriteLine($"{poke1.Name} hits {poke2.Name} with a special attack!");
                        Console.WriteLine($"{poke2.Name} has {Math.Max(health1, 0)} HP left\n");
                    }
                }
            } while (health1 > 0 && health2 > 0);

            //who won
            if (health1 <= 0 && health2 <=0)
            {
                Console.WriteLine("it's a draw");
                return 0;
            }
            else if (health1 <= 0)
            {
                Console.WriteLine($"{poke2.Name} has won this battle!");
                return 2;
            }
            else
            {
                Console.WriteLine($"{poke1.Name} has won this battle!");
                return 1;
            }
        }
    }
}
