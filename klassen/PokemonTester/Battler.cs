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
        public static IOutput output;
        public static IInput input = new ConsoleInputLogger();
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

            IPokemonDB allPokemons = new PokemonDatabase();
            myPokemon = allPokemons.ChooseAPokemon();

            Random rNG = new Random();
            enemy = allPokemons.Dex[rNG.Next(0, allPokemons.Dex.Length)];

            myPokemon.LevelUp(49);
            enemy.LevelUp(49);
            WriteInfo();
        }
        public void BattleStart()
        {
            output.Print("ready to battle?");
            input.ReadInput();
            Battle(myPokemon, enemy);
        }
        public void WriteInfo()
        {
            myPokemon.ShowInfo();
            enemy.ShowInfo();
        }
        public static int Battle(IPocketMonster poke1, IPocketMonster poke2)
        {
            NumberOfBattles++;

            //check if a pokemon is null
            if (NullCheck(poke1, poke2) != -1)
            {
                return NullCheck(poke1, poke2);
            }

            // initialise changeable values for the hp of both pokemon (should probably be a property of the pokemon class)
            int health1 = poke1.Full_HP;
            int health2 = poke2.Full_HP;

            // attack sequance, fastest pokemon attacks first, then slowest, both attack with with their highest attack stat, minimum 2 damage, until one has 0 hp. 
            ActualBattle(poke1, poke2, ref health1, ref health2);

            //check who lost and return a value
            return WhoWon(poke1, poke2, health1, health2);
        }
        static int NullCheck(IPocketMonster poke1, IPocketMonster poke2)
        {//check if a pokemon is null
            if (poke1 == null && poke2 == null)
            {
                output.Print("no winner");
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
            else return -1;
        }
        static void ActualBattle(IPocketMonster poke1, IPocketMonster poke2, ref int health1, ref int health2)
        {// attack sequance, fastest pokemon attacks first, then slowest
            // Power of a used move (moves not inplemented so base 80) & randomness of damage
            int power = 80;
            do
            {
                if (poke1.Full_Speed > poke2.Full_Speed)
                {
                    AttackSequence(poke1, poke2, ref health1, ref health2, power);
                }
                else
                {
                    AttackSequence(poke2, poke1, ref health2, ref health1, power);
                }
            } while (health1 > 0 && health2 > 0);
        }
        static void AttackSequence(IPocketMonster fastestMon, IPocketMonster slowestMon, ref int health1, ref int health2, int power = 80)
        {// attack sequance, both attack with with their highest attack stat, minimum 2 damage, until one has 0 hp. 
            if (fastestMon.Full_Attack > fastestMon.Full_SpecialAttack)
            {
                health2 -= DamageCalculations(fastestMon, slowestMon, "normal", power);
                output.Print($"{slowestMon.Name} has {Math.Max(health2, 0)} HP left\n");
            }
            else
            {
                health2 -= DamageCalculations(fastestMon, slowestMon, "special", power);
                output.Print($"{slowestMon.Name} has {Math.Max(health2, 0)} HP left\n");
            }
            if (health2 > 0)
            {
                if (slowestMon.Full_Attack > slowestMon.Full_SpecialAttack)
                {
                    health1 -= DamageCalculations(slowestMon, fastestMon, "normal", power);
                    output.Print($"{fastestMon.Name} has {Math.Max(health1, 0)} HP left\n");
                }
                else
                {
                    health1 -= DamageCalculations(slowestMon, fastestMon, "special", power);
                    output.Print($"{fastestMon.Name} has {Math.Max(health1, 0)} HP left\n");
                }
            }
        }
        static int WhoWon(IPocketMonster poke1, IPocketMonster poke2, int healthPoke1, int healthPoke2)
        {//check who lost and return a value
            if (healthPoke1 <= 0 && healthPoke2 <= 0)
            {
                Draws++;
                output.Print("it's a draw");
                return 0;
            }
            else if (healthPoke1 <= 0)
            {
                return Won(poke2, 2);
            }
            else
            {
                return Won(poke1, 1);
            }
        }
        static int Won(IPocketMonster poke, int number)
        {//returns the value corresponding to the winning 'Mon
            output.Print($"{poke.Name} has won this battle!");
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
                output.Print($"{attackingPoke.Name} hits {defendingPoke.Name} with a special attack!");
            }
            else
            {
                hpLost = Convert.ToInt32(Convert.ToDouble(((2 * attackingPoke.Level / 5) * (attackingPoke.Full_Attack / defendingPoke.Full_Defense) * power / 50) + 2) * (Convert.ToDouble(rNG.Next(randomnessLowerBound, 101)) / 100.0));
                output.Print($"{attackingPoke.Name} hits {defendingPoke.Name} with a regular attack!");
            }
            return hpLost;
        }
    }
}
