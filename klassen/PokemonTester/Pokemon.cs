using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTester
{
    class Pokemon
    {
        private int hP_Base;
        private int attack_Base;
        private int defense_Base;
        private int specialAttack_Base;
        private int specialDefense_Base;
        private int speed_Base;
        private int level = 1;
        private static int numberOfBattles = 0;
        private static int levelups = 0;
        private static int draws = 0;
        private static int howManyRandomMons = 0;
        public Pokemon()
        {
            Base_HP = 10;
            Base_Attack = 10;
            Base_Defense = 10;
            Base_SpecialAttack = 10;
            Base_SpecialDefense = 10;
            Base_Speed = 10;
        }
        public Pokemon(string name, int hp, int att, int def, int spAtt, int spDef, int speed)
        {
            Name = name;
            Base_HP = hp;
            Base_Attack = att;
            Base_Defense = def;
            Base_SpecialAttack = spAtt;
            Base_SpecialDefense = spDef;
            Base_Speed = speed;
        }
        public static int HowManyRandomMons
        {
            get { return howManyRandomMons; }
            private set { howManyRandomMons = value; }
        }
        public static int Levelups
        {
            get { return levelups; }
            private set { levelups = value; }
        }
        public static int Draws
        {
            get { return draws; }
            private set { draws = value; }
        }

        public static int NumberOfBattles
        {
            get
            {
                return numberOfBattles;
            }
            private set
            {
                numberOfBattles = value;
            }
        }
        public static bool NoLevelingAllowed { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int PokedexNumber { get; set; }
        public int Base_HP
        {
            get
            {
                return hP_Base;
            }
            set
            {
                hP_Base = value;
            }
        }
        public int Base_Attack
        {
            get
            {
                return attack_Base;
            }
            set
            {
                attack_Base = value;
            }
        }
        public int Base_Defense
        {
            get
            {
                return defense_Base;
            }
            set
            {
                defense_Base = value;
            }
        }
        public int Base_SpecialAttack
        {
            get
            {
                return specialAttack_Base;
            }
            set
            {
                specialAttack_Base = value;
            }
        }
        public int Base_SpecialDefense
        {
            get
            {
                return specialDefense_Base;
            }
            set
            {
                specialDefense_Base = value;
            }
        }
        public int Base_Speed
        {
            get
            {
                return speed_Base;
            }
            set
            {
                speed_Base = value;
            }
        }
        public int Level
        {
            get
            {
                return level;
            }
            private set
            {
                level = value;
            }
        }
        public double Average
        {
            get { return Convert.ToDouble(Base_HP + Base_Attack + Base_Defense + Base_SpecialAttack + Base_SpecialDefense + Base_Speed) / 6; }

        }
        public int Total
        {
            get { return Base_HP + Base_Attack + Base_Defense + Base_SpecialAttack + Base_SpecialDefense + Base_Speed; }
        }
        public int Full_HP
        {
            get 
            { return (((Base_HP + 50) * Level) / 50) + 10; }
        }
        public int Full_Attack
        {
            get
            { return (((Base_Attack + 50) * Level) / 50) + 5; }
        }
        public int Full_Defense
        {
            get
            { return (((Base_Defense + 50) * Level) / 50) + 5; }
        }
        public int Full_SpecialAttack
        {
            get
            { return (((Base_SpecialAttack + 50) * Level) / 50) + 5; }
        }
        public int Full_SpecialDefense
        {
            get
            { return (((Base_SpecialDefense + 50) * Level) / 50) + 5; }
        }
        public int Full_Speed
        {
            get
            { return (((Base_Speed + 50) * Level) / 50) + 5; }
        }

        public void LevelUp(int xLevels = 1)
        {
            if (NoLevelingAllowed)
            {
                Console.WriteLine("No leveling allowed! No levels were gained!");
            }
            else
            {
                Levelups += xLevels;
                Level = Level + xLevels;
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{Name} (level {Level})\nBase stats:\n\t * Health = {Base_HP}\n\t * Attack = {Base_Attack}\n\t * Defense = {Base_Defense}\n\t" +
                $" * Special Attack = {Base_SpecialAttack}\n\t * Special Defense = {Base_SpecialDefense}\n\t * Speed = {Base_Speed}\n\n\t * Total = {Total}\n\t * Avarage = {Average}" +
                $"\nFull stats:\n\t * Health = {Full_HP}\n\t * Attack = {Full_Attack}\n\t * Defense = {Full_Defense}\n\t" +
                $" * Special Attack = {Full_SpecialAttack}\n\t * Special Defense = {Full_SpecialDefense}\n\t * Speed = {Full_Speed}");
        }
        public static Pokemon PokemonGenerator()
        {
            Pokemon pokemon2 = new Pokemon();
            Random randomGenerator = new Random();
            Console.WriteLine("what is the name of this pokemon");
            pokemon2.Name = Console.ReadLine();
            pokemon2.Base_HP = randomGenerator.Next(10, 255);
            pokemon2.Base_Attack = randomGenerator.Next(10, Math.Max(Math.Min(650 - pokemon2.Base_HP, 255), 20));
            pokemon2.Base_Defense = randomGenerator.Next(10, Math.Max(Math.Min(650 - pokemon2.Base_HP - pokemon2.Base_Attack, 200), 20));
            pokemon2.Base_SpecialAttack = randomGenerator.Next(10, Math.Max(Math.Min(650 - pokemon2.Base_HP - pokemon2.Base_Attack - pokemon2.Base_Defense, 200), 20));
            pokemon2.Base_SpecialDefense = randomGenerator.Next(10, Math.Max(Math.Min(650 - pokemon2.Base_HP - pokemon2.Base_Attack - pokemon2.Base_Defense - pokemon2.Base_SpecialAttack, 200), 20));
            pokemon2.Base_Speed = randomGenerator.Next(10, Math.Max(Math.Min(650 - pokemon2.Base_HP - pokemon2.Base_Attack - pokemon2.Base_Defense - pokemon2.Base_SpecialAttack - pokemon2.Base_SpecialDefense, 200), 20));
            pokemon2.LevelUp(49);
            HowManyRandomMons++;
            return pokemon2;
        }
        public static int Battle(Pokemon poke1, Pokemon poke2)
        {
            NumberOfBattles++;
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

            // Power of a used move (moves not inplemented so base 80) & randomness of damage
            int power = 80;
            int randomnessLowerBound = 85;
            // attack sequance, fastest pokemon attacks first, then slowest, both attack with with their highest attack stat, minimum 2 damage, until one has 0 hp. 
            do
            {
                if (poke1.Full_Speed > poke2.Full_Speed)
                {
                    if (poke1.Full_Attack > poke1.Full_SpecialAttack)
                    {
                        health2 -= DamageCalculations(poke1,poke2,"normal",80);
                        Console.WriteLine($"{poke2.Name} has {Math.Max(health2, 0)} HP left\n");
                    }
                    else
                    {
                        health2 -= DamageCalculations(poke1, poke2, "special", 80);
                        Console.WriteLine($"{poke2.Name} has {Math.Max(health2, 0)} HP left\n");
                    }
                    if (poke2.Full_Attack > poke2.Full_SpecialAttack)
                    {
                        health1 -= DamageCalculations(poke2, poke1, "normal", 80);
                        Console.WriteLine($"{poke1.Name} has {Math.Max(health1, 0)} HP left\n");
                    }
                    else
                    {
                        health1 -= DamageCalculations(poke2, poke1, "special", 80);
                        Console.WriteLine($"{poke1.Name} has {Math.Max(health1, 0)} HP left\n");
                    }
                }
                else
                {
                    if (poke2.Full_Attack > poke2.Full_SpecialAttack)
                    {
                        health1 -= DamageCalculations(poke2, poke1, "normal", 80);
                        Console.WriteLine($"{poke1.Name} has {Math.Max(health1, 0)} HP left\n");
                    }
                    else
                    {
                        health1 -= DamageCalculations(poke2, poke1, "special", 80);
                        Console.WriteLine($"{poke1.Name} has {Math.Max(health1, 0)} HP left\n");
                    }
                    if (poke1.Full_Attack > poke1.Full_SpecialAttack)
                    {
                        health2 -= DamageCalculations(poke1, poke2, "normal", 80);
                        Console.WriteLine($"{poke2.Name} has {Math.Max(health2, 0)} HP left\n");
                    }
                    else
                    {
                        health2 -= DamageCalculations(poke1, poke2, "special", 80);
                        Console.WriteLine($"{poke2.Name} has {Math.Max(health2, 0)} HP left\n");
                    }
                }
            } while (health1 > 0 && health2 > 0);

            //who won
            if (health1 <= 0 && health2 <= 0)
            {
                Draws++;
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
        static int DamageCalculations(Pokemon attackingPoke, Pokemon defendingPoke, string normalSpecial,int power)
        {
            Random rNG = new Random();
            int randomnessLowerBound = 85;
            int hpLost;
            if (normalSpecial == "special")
            {
                hpLost = Convert.ToInt32(Convert.ToDouble(((2 * attackingPoke.Level / 5) * (attackingPoke.Full_SpecialAttack / defendingPoke.Full_SpecialDefense) * power / 50) + 2) * (Convert.ToDouble(rNG.Next(randomnessLowerBound, 101)) / 100.0));
                Console.WriteLine($"{attackingPoke.Name} hits {defendingPoke.Name} with a special attack!");
            }
            else
            {
                hpLost = Convert.ToInt32(Convert.ToDouble(((2 * attackingPoke.Level / 5) * (attackingPoke.Full_Attack / defendingPoke.Full_Defense) * power / 50) + 2) * (Convert.ToDouble(rNG.Next(randomnessLowerBound, 101)) / 100.0));
                Console.WriteLine($"{attackingPoke.Name} hits {defendingPoke.Name} with a regular attack!");
            }
            return hpLost;
        }
        public static void Info()
        {
            Console.WriteLine($"\nA total of {Levelups} levels have been gained");
            Console.WriteLine($"There have been a total of {NumberOfBattles} battles");
            Console.WriteLine($"{Draws} of those ended in a draw");
            Console.WriteLine($"{HowManyRandomMons} random pokemons were generated");
        }
    }
}
