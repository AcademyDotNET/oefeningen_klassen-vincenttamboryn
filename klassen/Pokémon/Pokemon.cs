using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokémon
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
        /*
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
        */
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
            Level = Level + xLevels;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{Name} (level {Level})\nBase stats:\n\t * Health = {Base_HP}\n\t * Attack = {Base_Attack}\n\t * Defense = {Base_Defense}\n\t" +
                $" * Special Attack = {Base_SpecialAttack}\n\t * Special Defense = {Base_SpecialDefense}\n\t * Speed = {Base_Speed}\n\n\t * Total = {Total}\n\t * Avarage = {Average}" +
                $"\nFull stats:\n\t * Health = {Full_HP}\n\t * Attack = {Full_Attack}\n\t * Defense = {Full_Defense}\n\t" +
                $" * Special Attack = {Full_SpecialAttack}\n\t * Special Defense = {Full_SpecialDefense}\n\t * Speed = {Full_Speed}");
        }
    }
}
