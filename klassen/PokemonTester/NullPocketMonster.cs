﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTester
{
    class NullPocketMonster:IPocketMonster
    {
        private int hP_Base;
        private int attack_Base;
        private int defense_Base;
        private int specialAttack_Base;
        private int specialDefense_Base;
        private int speed_Base;
        private int level = 1;
        public static int levelups = 0;
        public static int howManyRandomMons = 0;
        static IInput input = new ConsoleInputLogger();
        static IOutput output = new ConsoleLogger();
        public NullPocketMonster()
        {
            Name = "MissingNo.";
            PokedexNumber = 0;
            Base_HP = 10;
            Base_Attack = 10;
            Base_Defense = 10;
            Base_SpecialAttack = 10;
            Base_SpecialDefense = 10;
            Base_Speed = 10;
        }
        public string Name { get; set; }
        public static bool NoLevelingAllowed { get; set; }
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
            { return (((Base_HP + 50) * Level) / 50) + Level + 10; }
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
        public override string ToString()
        {
            return $"{ Name} (level { Level})\n* Health = { Full_HP }\n* Attack = { Full_Attack }\n* Defense = { Full_Defense }\n" +
                $"* Special Attack = {Full_SpecialAttack}\n* Special Defense = {Full_SpecialDefense}\n* Speed = {Full_Speed}";
        }

        public void LevelUp(int xLevels = 1)
        {
            if (NoLevelingAllowed)
            {
                output.Print("No leveling allowed! No levels were gained!");
            }
            else
            {
                Levelups += xLevels;
                Level += xLevels;
            }
        }
        public void ShowInfo()
        {
            output.Print($"{Name} (level {Level})\nBase stats:\n\t * Health = {Base_HP}\n\t * Attack = {Base_Attack}\n\t * Defense = {Base_Defense}\n\t" +
                $" * Special Attack = {Base_SpecialAttack}\n\t * Special Defense = {Base_SpecialDefense}\n\t * Speed = {Base_Speed}\n\n\t * Total = {Total}\n\t * Avarage = {Average}" +
                $"\nFull stats:\n\t * Health = {Full_HP}\n\t * Attack = {Full_Attack}\n\t * Defense = {Full_Defense}\n\t" +
                $" * Special Attack = {Full_SpecialAttack}\n\t * Special Defense = {Full_SpecialDefense}\n\t * Speed = {Full_Speed}");
        }

        public static void Info()
        {
            output.Print($"\nA total of {Levelups} levels have been gained");
            output.Print($"There have been a total of {Battler.NumberOfBattles} battles");
            output.Print($"{Battler.Draws} of those ended in a draw");
            output.Print($"{HowManyRandomMons} random pokemons were generated");
        }
        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            Pokemon pokemon2 = (Pokemon)obj;
            if (pokemon2.Level == this.Level)
            {
                if (pokemon2.Base_Attack == this.Base_Attack && pokemon2.Base_Defense == this.Base_Defense && pokemon2.Base_HP == this.Base_HP && pokemon2.Base_SpecialAttack == this.Base_SpecialAttack && pokemon2.Base_SpecialDefense == this.Base_SpecialDefense && pokemon2.Base_Speed == this.Base_Speed)
                {
                    return true;
                }
            }
            return false;
        }
    }
}