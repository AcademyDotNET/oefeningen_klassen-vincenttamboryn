using System;


namespace PokemonTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokemon.NoLevelingAllowed = false;
            Pokemon myPokemon = new Pokemon("Dragonite",91,134,95,100,100,80);
            myPokemon.LevelUp(49);
            Pokemon enemy = Pokemon.PokemonGenerator();
            Pokemon Poke3 = new Pokemon { Name = "Pikachu", Base_HP=35, Base_Attack = 55, Base_Defense = 40, Base_SpecialAttack = 50, Base_SpecialDefense = 50, Base_Speed = 90};

            myPokemon.ShowInfo();
            enemy.ShowInfo();
            Console.WriteLine("ready to battle?");
            Console.ReadLine();

            Pokemon.Battle(myPokemon, enemy);
            Pokemon.Info();
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
        
    }
}
