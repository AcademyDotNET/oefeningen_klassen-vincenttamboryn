using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTester
{
    class Battler:IMatch
    {
        public IPocketMonster myPokemon { get; }
        public IPocketMonster enemy { get; }
        static IOutput output;
        private static int draws = 0;
        private static int numberOfBattles = 0;
        public static int Draws
        {
            get { return draws; }
            set { draws = value; }
        }

        public static int NumberOfBattles
        {
            get
            {
                return numberOfBattles;
            }
            set
            {
                numberOfBattles = value;
            }
        }
        public Battler(IOutput logger)
        {
            output = logger;
            Pokemon.NoLevelingAllowed = false;
            Random rNG = new Random();
            IPocketMonster[] pokedex = AllPokemonsInitialiser();

            myPokemon = ChooseAPokemon(pokedex);
            enemy = pokedex[rNG.Next(0, pokedex.Length)];

            Levels();
            WriteInfo();
        }
        public void BattleStart()
        {
            output.Log("ready to battle?");
            Console.ReadLine();
            Battle(myPokemon, enemy);
        }
        public void WriteInfo()
        {
            myPokemon.ShowInfo();
            enemy.ShowInfo();
        }
        private void Levels()
        {
            myPokemon.LevelUp(49);
            enemy.LevelUp(49);
        }
        public IPocketMonster[] AllPokemonsInitialiser()
        {
            string[,] stats = CSV_reader.readCsvWeb();
            IPocketMonster[] arrayOfPokemons = new Pokemon[stats.GetLength(0) - 1];
            for (int i = 0; i < arrayOfPokemons.Length; i++)
            {
                arrayOfPokemons[i] = new Pokemon(stats[i + 1, 1], Convert.ToInt32(stats[i + 1, 5]), Convert.ToInt32(stats[i + 1, 6]), Convert.ToInt32(stats[i + 1, 7]), Convert.ToInt32(stats[i + 1, 8]), Convert.ToInt32(stats[i + 1, 9]), Convert.ToInt32(stats[i + 1, 10]));
            }
            return arrayOfPokemons;
        }
        public IPocketMonster ChooseAPokemon(IPocketMonster[] dex)
        {
            //allows the user to choose a pokemon, checks if the input is the name of a pokemon.
            //repeats this loop untill the input corresponds to a pokemon.
            //if the input does not correspond to a pokemon the programs asks if you want to see a list of all available pokemons.
            bool condition = true;
            int index = 0;
            do
            {
                output.Log("which pokemon would you like to use?");
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
                    output.Log("This is not a valid pokemon, try again.\nWould you like a list of all available pokemon? (yes or no)");
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
        private void ListAllPokemon(IPocketMonster[] dex)
        {
            Console.WriteLine();
            for (int i = 0; i < dex.Length; i++)
            {
                Console.WriteLine(dex[i].Name);
            }
            Console.WriteLine();
        }
        public static int Battle(IPocketMonster poke1, IPocketMonster poke2)
        {
            NumberOfBattles++;
            //check if a pokemon is null
            if (poke1 == null && poke2 == null)
            {
                output.Log("no winner");
                return 0;
            }
            if (poke1 == null)
            {
                return Won(poke2, 2);
            }
            if (poke2 == null)
            {
                return Won(poke1, 1);
            }

            // initialise changeable values for the hp of both pokemon
            int health1 = poke1.Full_HP;
            int health2 = poke2.Full_HP;

            Random rNG = new Random();

            // Power of a used move (moves not inplemented so base 80) & randomness of damage
            int power = 80;

            // attack sequance, fastest pokemon attacks first, then slowest, both attack with with their highest attack stat, minimum 2 damage, until one has 0 hp. 
            do
            {
                if (poke1.Full_Speed > poke2.Full_Speed)
                {
                    attackSequence(poke1,poke2, ref health1, ref health2);
                }
                else
                {
                    attackSequence(poke2, poke1, ref health2, ref health1);
                }
            } while (health1 > 0 && health2 > 0);

            //who won
            if (health1 <= 0 && health2 <= 0)
            {
                Draws++;
                output.Log("it's a draw");
                return 0;
            }
            else if (health1 <= 0)
            {
                return Won(poke2, 2);
            }
            else
            {
                return Won(poke1, 1);
            }
        }
        static void attackSequence(IPocketMonster fastestMon, IPocketMonster slowestMon, ref int health1, ref int health2, int power = 80)
        {
            if (fastestMon.Full_Attack > fastestMon.Full_SpecialAttack)
            {
                health2 -= DamageCalculations(fastestMon, slowestMon, "normal", power);
                output.Log($"{slowestMon.Name} has {Math.Max(health2, 0)} HP left\n");
            }
            else
            {
                health2 -= DamageCalculations(fastestMon, slowestMon, "special", power);
                output.Log($"{slowestMon.Name} has {Math.Max(health2, 0)} HP left\n");
            }
            if (slowestMon.Full_Attack > slowestMon.Full_SpecialAttack)
            {
                health1 -= DamageCalculations(slowestMon, fastestMon, "normal", power);
                output.Log($"{fastestMon.Name} has {Math.Max(health1, 0)} HP left\n");
            }
            else
            {
                health1 -= DamageCalculations(slowestMon, fastestMon, "special", power);
                output.Log($"{fastestMon.Name} has {Math.Max(health1, 0)} HP left\n");
            }
        }
        static int Won(IPocketMonster poke, int number)
        {
            output.Log($"{poke.Name} has won this battle!");
            return number;
        }
        static int DamageCalculations(IPocketMonster attackingPoke, IPocketMonster defendingPoke, string normalSpecial, int power)
        {
            //calculates the damage a pokemon would take and returns it. Randomness makes it so damage isn't predetermined

            Random rNG = new Random();
            int randomnessLowerBound = 85;
            int hpLost;
            if (normalSpecial == "special")
            {
                hpLost = Convert.ToInt32(Convert.ToDouble(((2 * attackingPoke.Level / 5) * (attackingPoke.Full_SpecialAttack / defendingPoke.Full_SpecialDefense) * power / 50) + 2) * (Convert.ToDouble(rNG.Next(randomnessLowerBound, 101)) / 100.0));
                output.Log($"{attackingPoke.Name} hits {defendingPoke.Name} with a special attack!");
            }
            else
            {
                hpLost = Convert.ToInt32(Convert.ToDouble(((2 * attackingPoke.Level / 5) * (attackingPoke.Full_Attack / defendingPoke.Full_Defense) * power / 50) + 2) * (Convert.ToDouble(rNG.Next(randomnessLowerBound, 101)) / 100.0));
                output.Log($"{attackingPoke.Name} hits {defendingPoke.Name} with a regular attack!");
            }
            return hpLost;
        }
    }
}
