using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTester
{
    interface IPocketMonster
    {
        public static int HowManyRandomMons { get; set; }
        public static int Levelups { get; set; }
        public static bool NoLevelingAllowed { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int PokedexNumber { get; set; }
        public int Base_HP { get; set; }
        public int Base_Attack { get; set; }
        public int Base_Defense { get; set; }
        public int Base_SpecialAttack { get; set; }
        public int Base_SpecialDefense { get; set; }
        public int Base_Speed { get; set; }
        public int Level { get; }
        public double Average { get; }
        public int Total { get; }
        public int Full_HP { get; }
        public int Full_Attack { get; }
        public int Full_Defense { get; }
        public int Full_SpecialAttack { get; }
        public int Full_SpecialDefense { get; }
        public int Full_Speed { get; }
        public void LevelUp(int xLevels);
        public void ShowInfo();
        public string ToString();
        public bool Equals(object obj);
    }
}
